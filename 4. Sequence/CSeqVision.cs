using Cognex.VisionPro;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class CSeqVision : CSeqBase
    {
        private Global Global = Global.Instance;
        public EventHandler<EventArgs> EventInspEnd;
        public CSeqVision(string strName = "")
        {
            if (string.IsNullOrEmpty(strName)) ThreadName = $"SEQ_VISION";
            else ThreadName = strName;

            StartThread();
            Global.resultdrawEvent += ResultDrawHandler;
        }

        public CInspector Inspector = new CInspector();
      

        public enum ManualType { AUTO, GRAB_INSP, IMAGE_INSP };
        public ManualType ManualInsp = ManualType.AUTO;

        private object grabSync = new object();
        private int _InspRetryIndex = 0;
        private bool bRetry = false;
        private List<bool> _Array_Results = new List<bool>();
        private Stopwatch _tt_CycleTime = new Stopwatch();
        private Stopwatch tt_Insp = new Stopwatch();
        public long CycleTime
        {
            get => _tt_CycleTime.ElapsedMilliseconds;
        }

        (bool totalResult, bool qrResult, List<bool> results) results = (false, false, new List<bool>());
        public bool qrResult = false;
        public string LastCommInfo = "";
        private Stopwatch _tt_WaitPCB = new Stopwatch();

        bool[] isGrab = new bool[5] { false, false, false, false, false };

        private object bufferLock = new object();
        public List<(DateTime, string)> NgBuffer { get; set; } = new List<(DateTime, string)>();

        public override void Run()
        {
            try
            {
                this.ThreadSleepTime_ms = 1;
                //AUTO 가 아니고, 매뉴얼 검사도 아니면 retrun;

                if (Global.System.Mode == CSystem.MODE.ALARM) return;
                if (Global.System.Mode != CSystem.MODE.AUTO && ManualInsp == ManualType.AUTO) return;

                CDIO_ADLINK7432 DIO = Global.Device.DIO_BD;
                ImageFocusLightController Light = Global.Device.LightController;
                Camera Camera = Global.Device.Cameras.Count > 0 ? Global.Device.Cameras[0] : null;
                CMewtocol NGBUFFER = Global.Device.NGBUFFER;

                CRecipe Recipe = Global.System.Recipe;
                if (ManualInsp == ManualType.AUTO)
                {
                    if (DIO == null || DIO.IsOpen == false)
                    {
                        CLogger.Add(LOG.ABNORMAL, $"DIO Disconnected");
                        Thread.Sleep(1000);

                        return;
                    }

                    if (Light == null || Light.IsOpen == false)
                    {
                        //CLogger.Add(LOG.ABNORMAL, $"Light Disconnected");
                        //Thread.Sleep(1000);

                        //return;
                    }

                    if (Camera == null || Camera.IsOpen == false)
                    {
                        CLogger.Add(LOG.ABNORMAL, $"Camera Disconnected");
                        Thread.Sleep(1000);

                        return;
                    }
                }

                switch (SeqIndex)
                {
                    case "IDLE":
                        {
                            if (ManualInsp == ManualType.AUTO)
                            {
                                if (_tt_WaitPCB.IsRunning == false)
                                {
                                    _tt_WaitPCB.Reset();
                                    _tt_WaitPCB.Start();
                                }

                                if (_tt_WaitPCB.ElapsedMilliseconds > 60000)
                                {
                                    Global.Data.StopReason = "WAIT PCB";
                                }

                                if (CDIO_BIT.INSP_START_ISDISPLAY == false) return;
                                if (CDIO_BIT.INSP_START == false) return;

                                CDIO_BIT.INSP_START_ISDISPLAY = false;

                                Global.Data.StopReason = "NORMAL";
                                Thread.Sleep(Global.Setting.Equipment.DelayTime_PrevInsp);
                            }
                        }
                        SetStepEx("INIT");
                        break;
                    case "INIT":
                        {
                            Global.Instance.OnStart_Porgess("DEVICE INIT");
                            Global.Data.Result_NG_Count = new int[4];
                            Global.logicCount = 0;
                            Global.NGDataList.Clear();
                            Global.totalCount = Inspector.TotalCount();
                            _InspRetryIndex = 0;
                            Global.Retry_Count = 0;
                            //비트 초기화
                            DIO.Off(CDIO_BITNAME.RESULT_OK);
                            DIO.Off(CDIO_BITNAME.RESULT_NG);

                            _Array_Results = new List<bool>();
                            Global.Result_Array = new bool[4];
                            //for (int i = 0; i < Light.ChannelCount; i++) Light.SetValue(i + 1, 254);
                            //Light.AllOn();

                            //검사 전 메모리 한 번 비우고 가자.
                            GC.Collect();

                            _tt_CycleTime = Stopwatch.StartNew();

                            SetStepEx("GRAB");
                        }
                        break;
                    case "GRAB":
                        {
                            Global.Instance.OnStart_Porgess("GRAB");
                            Stopwatch tt_Grab = Stopwatch.StartNew();
                            //카메라 그랩 실패 할 수 있기 때문에 3번 진행, 완료하면 break                            

                            //for (int arrayIdx = 0; arrayIdx < Global.System.Recipe.JobManager.Length; arrayIdx++)
                            //{
                            //    for (int jobIdx = 0; jobIdx < Global.System.Recipe.JobManager[arrayIdx].Jobs.Count; jobIdx++)
                            //    {
                            //        CJob job = Global.System.Recipe.JobManager[arrayIdx].Jobs[jobIdx];
                            //        isGrab[job.GrabIndex] = true;
                            //    }
                            //}


                            if (ManualInsp == ManualType.GRAB_INSP || ManualInsp == ManualType.AUTO)
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    try
                                    {
                                        //if (isGrab[i] == false)
                                        //{
                                        //    Global.ImagesGrab[i] = null;
                                        //    continue;
                                        //}

                                        Camera.SetExposure(Recipe.GrabManager.Nodes[i].ExposureTime_us);
                                        Camera.SetGain(Recipe.GrabManager.Nodes[i].Gain);

                                        //그랩 실패 시 재 시도
                                        for (int grabRetryIndex = 0; grabRetryIndex < 3; grabRetryIndex++)
                                        {
                                            Camera.Grab();

                                            bool grabSuccess = Camera.IsGrabDone.WaitOne(1000);

                                            if (grabSuccess)
                                            {
                                                lock (grabSync)
                                                {
                                                    //Camera.GrabBuffer[i] = (Bitmap)Camera.ImageGrab.Clone();
                                                    Global.ImagesGrab[i] = new CogImage24PlanarColor(Camera.ImageGrab);
                                                }

                                                CLogger.Add(LOG.SEQ, $"GRAB INDEX #{i} Grab Success");
                                                break;
                                            }
                                            else
                                            {
                                                Thread.Sleep(100);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                                    }
                                }
                            }

                            CLogger.Add(LOG.SEQ, $"#01. Grab Cycle Time : {tt_Grab.ElapsedMilliseconds}ms");

                            SetStepEx("INSP");
                        }
                        break;
                    case "INSP":
                        {
                            tt_Insp = Stopwatch.StartNew();

                            bool inspSuccess = true;

                            try
                            {
                                if (Global.Mode.ReInspecUse == false || ManualInsp == ManualType.GRAB_INSP)
                                {
                                    Global.Retry_Count = _InspRetryIndex = Global.Mode.ReInspecCnt + 1;
                                }
                                if (bRetry == true)
                                {
                                    Global.totalCount = 0;
                                    for (int i = 0; i < Global.Retry_ArrayList.Length; i++)
                                    { 
                                        Global.totalCount += Global.Retry_ArrayList[i].Count;
                                    }
                                } 
                                qrResult = Inspector.Execute(_tt_CycleTime, bRetry, Global.ImagesGrab);
                                if (Global.System.Mode == CSystem.MODE.ALARM)
                                {
                                    return;
                                }

                            }
                            catch (Exception ex)
                            {
                                inspSuccess = false;
                                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                            }


                            //QR 실패 시 어떻게 처리할건지?
                            if (qrResult == false)
                            {
                                CAlarm.Add("QR CODE", "Can't Read the QR Code");
                                Global.Instance.OnEnd_Progress();
                                return;
                            }

                        }

                        _tt_CycleTime.Stop();
                        SetStepEx("Wait_RESULT");
                        break;

                    case "Wait_RESULT":
                        { 
                            break;
                        }

                    case "RESULT_PROCESS":
                        {
                            Stopwatch tt_ResultProcess = Stopwatch.StartNew();
                            Task.Run(() => { Light.AllOff(); });

                            IData Data = Global.Instance.Data;
                            CMode Mode = Global.Instance.Mode;


                            string qrDateToNgBuffer = "";
                            bool totalResult = true;

                            for (int i = 0; i < _Array_Results.Count; i++)
                            {
                                CLogger.Add(LOG.SEQ, $"Array [{i}] Result : {_Array_Results[i]}");

                                if (i == 0)
                                {
                                    qrDateToNgBuffer = Data.Array_QrCodes[i].GetSerialNo();
                                }
                                else
                                {
                                   
                                     qrDateToNgBuffer = qrDateToNgBuffer + "/" + Data.Array_QrCodes[i].GetSerialNo();
                                  
                                }

                                if (_Array_Results[i])
                                {
                                    Data.CountOK++;
                                    Data.CurrentOK++;
                                }
                                else
                                {
                                    Data.CountNG_F++;
                                    Data.CurrentNG++;
                                    totalResult = false;
                                }
                                bool bRecent = false;
                                if (!Global.Instance.Mode.NGisRecent)
                                    bRecent = true;
                                else
                                {
                                    if (!totalResult)
                                        bRecent = true;
                                }

                                try
                                {
                                    if (bRecent)
                                    {
                                        CogRecentImage recent = new CogRecentImage();
                                        recent.Name = qrDateToNgBuffer;
                                        recent.DateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                                        for (int j = 0; j < recent.recentImages.Length; j++)
                                        {
                                            if (Global.Instance.ImagesGrab[j] != null && Global.Instance.ImagesGrab[j].Allocated)
                                            {
                                                recent.recentImages[j] = new Cognex.VisionPro.CogImage24PlanarColor(Global.Instance.ImagesGrab[j]);
                                            }
                                        }

                                        Data.cogRecentImages.Add(recent);

                                        if (Data.cogRecentImages.Count > 20)
                                            Data.cogRecentImages.RemoveAt(0);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, "Recent Image Saving", ex);
                                }

                                try
                                {
                                    Global.Instance.FileManager.IdDataSave(Data.Array_QrCodes[i].GetQR(), _Array_Results[i]);
                                }
                                catch (Exception ex)
                                {
                                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, "Result Data Saving", ex);
                                }

                            }

                            Data.ArrayResults = _Array_Results.ToArray();

                            if (Global.Instance.Setting.Enviroment.Country == Setting_Enviroment.COUNTRY.POL)
                            {
                                if (Mode.isForceJudge == false) //정상 시퀀스
                                {
                                    if (totalResult) //OK
                                    {
                                        CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> OK");
                                        CLogger.Add(LOG.COMM, $"SEQ NORMAL JUDGE ==> OK");
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
                                        NGBUFFER.Command_PCBID_END_JUDGE(true);
                                    }
                                    else//NG
                                    {
                                        CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> NG");
                                        CLogger.Add(LOG.COMM, $"SEQ NORMAL JUDGE ==> NG");

                                        if (!Mode.isDebugMode)
                                        {
                                            DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                                            DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);
                                            NGBUFFER.Command_PCBID_END_JUDGE(false);
                                        }
                                        else // 디버그모드 ON이면 NG시 신호 안나가고 멈추고 수정후 재검사
                                        {
                                            CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> DEBUG");
                                            DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                                            DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
                                        }
                                    }
                                }
                                else
                                {
                                    // 강제 결과 판정...
                                    CLogger.Add(LOG.SEQ, $"SEQ isForceJudge ==> true");
                                    // 강제 OK판정
                                    if (Mode.AutoJudge)
                                    {
                                        CLogger.Add(LOG.SEQ, $"SEQ AUTO JUDGE ==> OK");
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);

                                        NGBUFFER.Command_PCBID_END_JUDGE(true);
                                    }
                                    // 강제 NG판정
                                    else
                                    {
                                        CLogger.Add(LOG.SEQ, $"SEQ AUTO JUDGE ==> NG");
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);

                                        NGBUFFER.Command_PCBID_END_JUDGE(false);
                                    }
                                }
                                Stopwatch sw = Stopwatch.StartNew();
                                while (sw.ElapsedMilliseconds < 200000)
                                {
                                    Thread.Sleep(1);

                                    if (NGBUFFER.GetInPutBoard())
                                    {
                                        CLogger.Add(LOG.SEQ, $"INPUT BOARDING BIT : ON");
                                        break;
                                    }
                                    else
                                    {
                                        CLogger.Add(LOG.SEQ, $"INPUT BOARDING BIT : OFF");
                                    }
                                }
                                if (sw.ElapsedMilliseconds > 200000)
                                {
                                    CAlarm.Add("BOARDING BIT", "BOARDING BIT TimeOut");
                                    Global.Instance.OnEnd_Progress();
                                    return;
                                }
                                NGBUFFER.CommandQueue.Enqueue(("D", "10000", typeof(string), qrDateToNgBuffer));
                                CLogger.Add(LOG.COMM, $"QR Send -> NG Buffer : {qrDateToNgBuffer}");
                            }
                            else
                            {

                                if (Mode.isForceJudge == false) //정상 시퀀스
                                {
                                    CLogger.Add(LOG.SEQ, $"SEQ isForceJudge ==> false");
                                    if (totalResult) //OK
                                    {
                                        CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> OK");
                                        CLogger.Add(LOG.COMM, $"SEQ NORMAL JUDGE ==> OK");
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
                                        NGBUFFER.Command_PCBID_END_JUDGE(true);
                                    }
                                    else//NG
                                    {
                                        CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> NG");
                                        CLogger.Add(LOG.COMM, $"SEQ NORMAL JUDGE ==> NG");
                                        IData.bNGCount = true;
                                        if (Mode.isDebugMode == false)
                                        {
                                            DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                                            DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);
                                            NGBUFFER.Command_PCBID_END_JUDGE(false);
                                        }
                                        else // 디버그모드 ON이면 NG시 신호 안나가고 멈추고 수정후 재검사
                                        {
                                            CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> DEBUG");
                                            DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                                            DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
                                        }
                                    }
                                }
                                else
                                {
                                    // 강제 결과 판정...
                                    CLogger.Add(LOG.SEQ, $"SEQ isForceJudge ==> true");
                                    // 강제 OK판정
                                    if (Mode.AutoJudge)
                                    {
                                        CLogger.Add(LOG.SEQ, $"SEQ AUTO JUDGE ==> OK");
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);

                                        NGBUFFER.Command_PCBID_END_JUDGE(true);
                                    }
                                    // 강제 NG판정
                                    else
                                    {
                                        CLogger.Add(LOG.SEQ, $"SEQ AUTO JUDGE ==> NG");
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                                        DIO.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);

                                        NGBUFFER.Command_PCBID_END_JUDGE(false);
                                        IData.bNGCount = true;
                                    }
                                }
                                Thread.Sleep(200);
                                NGBUFFER.CommandQueue.Enqueue(("D", "9800", typeof(string), qrDateToNgBuffer));
                                CLogger.Add(LOG.COMM, $"QR Send -> NG Buffer : {qrDateToNgBuffer}");

                            }

                            CLogger.Add(LOG.SEQ, $"#03. Result Process Cycle Time : {tt_ResultProcess.ElapsedMilliseconds}ms");
                            Global.Instance.OnEnd_Progress();
                        }
                        SetStepEx("META_DATA_REPORT");
                        break;
                    case "META_DATA_REPORT":
                        {
                            Global.Instance.MetaData.Model = Global.Instance.System.Recipe.Name;
                            Global.Instance.MetaData.Status = Global.Instance.System.Mode.ToString();
                            Global.Instance.MetaData.StopReason = "N/A";
                            Global.Instance.MetaData.NGCount = Global.Instance.DB.Select_NGCount("HISTORY", Global.Instance.System.Recipe.Name, Global.Instance.Recent.szModelChangeTime);
                            Global.Instance.MetaData.OKCount = Global.Instance.DB.Select_OKCount("HISTORY", Global.Instance.System.Recipe.Name, Global.Instance.Recent.szModelChangeTime);
                            Global.Instance.MetaData.TotalCount = Global.Instance.MetaData.OKCount + Global.Instance.MetaData.NGCount;

                            if (Global.Instance.MetaData.TotalCount > 0)
                                Global.Instance.MetaData.PerOK = (double)(Global.Instance.MetaData.OKCount / Global.Instance.MetaData.TotalCount) * 100;

                            else Global.Instance.MetaData.PerOK = 0;
                            Global.Instance.MetaData.TackTime = CycleTime;
                            Global.Instance.MetaData.SaveToCSV();
                        }
                        SetStepEx("COMPLETE");
                        break;
                    case "COMPLETE":
                        {
                            //검사 완료 시 티칭창과 메인창에 뿌려줄 이벤트
                            if (EventInspEnd != null)
                            {
                                EventInspEnd(this, new EventArgs());
                            }
                            ManualInsp = ManualType.AUTO;
                            Thread.Sleep(1000);
                            if (Global.Mode.isJudgeScreenShot) IF_Util.SaveCaptureScreen($"{Application.StartupPath}\\CAPTURE\\{LastCommInfo.Replace("/", "_")}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_JudgeEnd");
                        }
                        SetStepEx("IDLE");
                        break;
                    default:
                        {
                            IF_Util.ShowMessageBox("개발자 버그", $"Thread : {ThreadName} Seq : {SeqIndex} 는 없습니다.");
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //CUtil.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }


        public void SetStepEx(string strStep)
        {
            CLogger.Add(LOG.SEQ, $"{ThreadName} ==> STEP {SeqIndex} ==> {strStep}");
            base.SetStep(strStep);
        }

        private void ResultDrawHandler(object sender, bool drawDone)
        {
            try
            {
                //CLogger.Add(LOG.SEQ, $"SEQ T/T : [{inspectorWatch.ElapsedMilliseconds:D4} ms] ==> inspect Complete");

                (Global.Result_Array, Global.Retry_ArrayList) = Inspector.ArrayJudge(); // 여기서 NG,OK NG list 값 받아옴. 이걸 전역 변수로 사용해서 Retry 진행해야함.
                CLogger.Add(LOG.SEQ, $"#02. Insp [{_InspRetryIndex}] Cycle Time : {tt_Insp.ElapsedMilliseconds}ms");
                if (Global.Result_Array.Contains(false) && Global.Mode.ReInspecUse)
                {
                    if (_InspRetryIndex < Global.Mode.ReInspecCnt)
                    {
                        CLogger.Add(LOG.SEQ, $"Inspection Result : Fail ==> Retry {_InspRetryIndex} Insp Start");
                        bRetry = true;
                        _InspRetryIndex++;
                        Global.Retry_Count++;
                        SetStepEx("GRAB");
                    }
                    else
                    {
                        bRetry = false;
                        CLogger.Add(LOG.SEQ, $"Inspection Result : Fail ==> Retry Insp Over ==> Judge : NG");
                        Inspector.SaveImageAndWriteDB(Global.Result_Array, Global.ImagesGrab, Global.Retry_ArrayList);
                        for (int i = 0; i < Global.Retry_ArrayList.Length; i++)
                        {
                            Global.Data.Result_NG_Count[i] = Global.Retry_ArrayList[i].Count;
                        }
                        SetStepEx("RESULT_PROCESS");
                    }

                }
                else if (Global.Result_Array.Contains(false))
                {
                    CLogger.Add(LOG.SEQ, $"Inspection Result : Fail ==> Retry Insp Over ==> Judge : NG");
                    Inspector.SaveImageAndWriteDB(Global.Result_Array, Global.ImagesGrab, Global.Retry_ArrayList);
                    for (int i = 0; i < Global.Retry_ArrayList.Length; i++)
                    {
                        Global.Data.Result_NG_Count[i] = Global.Retry_ArrayList[i].Count;
                    }
                    SetStepEx("RESULT_PROCESS");
                }
                else
                {
                    CLogger.Add(LOG.SEQ, $"Inspection Result : OK ==> Judge : OK");
                    Inspector.SaveImageAndWriteDB(Global.Result_Array, Global.ImagesGrab, Global.Retry_ArrayList);
                    for (int i = 0; i < Global.Retry_ArrayList.Length; i++)
                    {
                        Global.Data.Result_NG_Count[i] = Global.Retry_ArrayList[i].Count;
                    }
                    SetStepEx("RESULT_PROCESS");
                }
                _Array_Results = Global.Result_Array.ToList();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

        }
    }
}

