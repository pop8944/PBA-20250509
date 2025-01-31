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
        }


        public enum ManualType { AUTO, GRAB_INSP, IMAGE_INSP };
        public ManualType ManualInsp = ManualType.AUTO;

        private object grabSync = new object();
        private int _InspRetryIndex = 0;

        private List<bool> _Array_Results = new List<bool>();
        private Stopwatch _tt_CycleTime = new Stopwatch();
        public long CycleTime
        {
            get => _tt_CycleTime.ElapsedMilliseconds;
        }

        (bool totalResult, bool qrResult, List<bool> results) results = (false, false, new List<bool>());

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

                            _InspRetryIndex = 0;

                            //비트 초기화
                            DIO.Off(CDIO_BITNAME.RESULT_OK);
                            DIO.Off(CDIO_BITNAME.RESULT_NG);

                            _Array_Results = new List<bool>();

                            //for (int i = 0; i < Light.ChannelCount; i++) Light.SetValue(i + 1, 254);
                            //Light.AllOn();

                            //검사 전 메모리 한 번 비우고 가자.
                            GC.Collect();

                            _tt_CycleTime = Stopwatch.StartNew();

                            //for (int arrayIdx = 0; arrayIdx < Global.System.Recipe.JobManager.Length; arrayIdx++)
                            //{
                            //    if (Global.System.Recipe.JobManager[arrayIdx] == null) continue;
                            //    for (int jobIdx = 0; jobIdx < Global.System.Recipe.JobManager[arrayIdx].Jobs.Count; jobIdx++)
                            //    {
                            //        Global.System.Recipe.JobManager[arrayIdx].Jobs[jobIdx].AlreadyPass = false;
                            //    }
                            //}

                            SetStepEx("GRAB");
                        }
                        break;
                    case "GRAB":
                        {
                            Global.Instance.OnStart_Porgess("GRAB");
                            Stopwatch tt_Grab = Stopwatch.StartNew();
                            //카메라 그랩 실패 할 수 있기 때문에 3번 진행, 완료하면 break                            

                            for (int arrayIdx = 0; arrayIdx < Global.System.Recipe.JobManager.Length; arrayIdx++)
                            {
                                for (int jobIdx = 0; jobIdx < Global.System.Recipe.JobManager[arrayIdx].Jobs.Count; jobIdx++)
                                {
                                    CJob job = Global.System.Recipe.JobManager[arrayIdx].Jobs[jobIdx];
                                    isGrab[job.GrabIndex] = true;
                                }
                            }


                            if (ManualInsp == ManualType.GRAB_INSP || ManualInsp == ManualType.AUTO)
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    try
                                    {
                                        if (isGrab[i] == false)
                                        {
                                            Global.ImagesGrab[i] = null;
                                            continue;
                                        }

                                        Camera.SetExposure(Recipe.GrabManager.Nodes[i].ExposureTime_us);

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

                            //ManualInsp = ManualType.AUTO;
                            SetStepEx("INSP");
                        }
                        break;
                    case "INSP":
                        {
                            Stopwatch tt_Insp = Stopwatch.StartNew();

                            bool inspSuccess = true;

                            try
                            {
                                if (Global.Mode.ReInspecUse == false || ManualInsp == ManualType.GRAB_INSP)
                                {
                                    _InspRetryIndex = Global.Mode.ReInspecCnt + 1;
                                }

                                results = CVisionTools.MainInsp(_tt_CycleTime, _InspRetryIndex, Global.ImagesGrab, out Global.ImageResults_array, false);

                                if (Global.System.Mode == CSystem.MODE.ALARM)
                                {
                                    return;
                                }

                                //어레이별 검사 결과를 가져오자.
                                _Array_Results = results.results.ToList();
                            }
                            catch (Exception ex)
                            {
                                inspSuccess = false;
                                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                            }

                            CLogger.Add(LOG.SEQ, $"#02. Insp [{_InspRetryIndex}] Cycle Time : {tt_Insp.ElapsedMilliseconds}ms");

                            //QR 실패 시 어떻게 처리할건지?
                            if (results.qrResult == false)
                            {
                                CAlarm.Add("QR CODE", "Can't Read the QR Code");
                                return;
                            }

                            //전체 검사 결과와, 어레이별 검사 결과를 비교하여 재검사 할지 선택
                            if (inspSuccess == false || _Array_Results.Contains(false))
                            {
                                if (Global.Mode.ReInspecUse)
                                {
                                    if (_InspRetryIndex < Global.Mode.ReInspecCnt)
                                    {
                                        CLogger.Add(LOG.SEQ, $"Inspection Result : Fail ==> Retry {_InspRetryIndex} Insp Start");
                                        SetStepEx("GRAB");
                                    }
                                    else
                                    {
                                        CLogger.Add(LOG.SEQ, $"Inspection Result : Fail ==> Retry Insp Over ==> Judge : NG");
                                        SetStepEx("RESULT_PROCESS");
                                    }
                                }
                                else
                                {
                                    CLogger.Add(LOG.SEQ, $"Inspection Result : Fail ==> Retry Insp Over ==> Judge : NG");
                                    SetStepEx("RESULT_PROCESS");
                                }

                                _InspRetryIndex++;

                                return;
                            }
                        }

                        _tt_CycleTime.Stop();
                        SetStepEx("RESULT_PROCESS");
                        break;
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
                                    Data.CountOK_M++;
                                }
                                else
                                {
                                    Data.CountNG_F++;
                                    Data.CountNG_M++;
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
                                        CLogger.Add(LOG.SEQ, $"INPUT BOARD ING BIT : ON");
                                        break;
                                    }
                                    else
                                    {
                                        CLogger.Add(LOG.SEQ, $"INPUT BOARD ING BIT : OFF");
                                    }
                                }
                                
                                NGBUFFER.CommandQueue.Enqueue(("D", "10000", typeof(string), qrDateToNgBuffer));
                                CLogger.Add(LOG.COMM, $"QR Send -> NG Buffer : {qrDateToNgBuffer}");
                            }
                            else
                            {
                                //LastCommInfo = qrDateToNgBuffer;

                                //NGBUFFER.CommandQueue.Enqueue(("D", "9800", typeof(string), qrDateToNgBuffer));
                                //CLogger.Add(LOG.COMM, $"QR Send -> NG Buffer : {qrDateToNgBuffer}");

                                //if(totalResult == false)
                                //{
                                //    Task.Run(() =>
                                //    {
                                //        Stopwatch timeout = Stopwatch.StartNew();
                                //        string qrData = qrDateToNgBuffer;
                                //        string qrCode = "";
                                //        if (Data.Array_QrCodes != null && Data.Array_QrCodes.Length > 1)
                                //        {
                                //            qrCode = $"{Data.Array_QrCodes[0].GetQR()}/{Data.Array_QrCodes[1].GetQR()}";                                            
                                //        }

                                //        lock (bufferLock)
                                //        {
                                //            NgBuffer.Add((DateTime.Now, qrCode));
                                //        }

                                //        bool success = false;
                                //        while (true)
                                //        {
                                //            Thread.Sleep(100);

                                //            if (timeout.ElapsedMilliseconds > 20000)
                                //            {
                                //                CLogger.Add(LOG.ABNORMAL, $"[FAILED] NG BUFFER ENTERING ==> {qrData}");
                                //                break;
                                //            }
                                //            else
                                //            {
                                //                if (NGBUFFER == null) break;

                                //                if (Global.Device.NGBUFFER.IN_BUFFER1_ID != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER1_EXISTS != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER1_RESULT != null

                                //                && Global.Device.NGBUFFER.IN_BUFFER3_ID != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER3_EXISTS != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER3_RESULT != null

                                //                && Global.Device.NGBUFFER.IN_BUFFER5_ID != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER5_EXISTS != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER5_RESULT != null

                                //                && Global.Device.NGBUFFER.IN_BUFFER6_ID != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER6_EXISTS != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER6_RESULT != null

                                //                && Global.Device.NGBUFFER.IN_BUFFER7_ID != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER7_EXISTS != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER7_RESULT != null

                                //                && Global.Device.NGBUFFER.IN_BUFFER9_ID != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER9_EXISTS != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER9_RESULT != null

                                //                && Global.Device.NGBUFFER.IN_BUFFER11_ID != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER11_EXISTS != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER11_RESULT != null

                                //                && Global.Device.NGBUFFER.IN_BUFFER12_ID != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER12_EXISTS != null
                                //                && Global.Device.NGBUFFER.IN_BUFFER12_RESULT != null)
                                //                {
                                //                    if (Global.Device.NGBUFFER.IN_BUFFER1_EXISTS.Value == 1
                                //                    && Global.Device.NGBUFFER.IN_BUFFER1_RESULT.Value == 0
                                //                    && string.Equals(Global.Device.NGBUFFER.IN_BUFFER1_ID.ID, qrData))
                                //                    {
                                //                        success = true;
                                //                    }

                                //                    if (Global.Device.NGBUFFER.IN_BUFFER3_EXISTS.Value == 1
                                //                    && Global.Device.NGBUFFER.IN_BUFFER3_RESULT.Value == 0
                                //                    && string.Equals(Global.Device.NGBUFFER.IN_BUFFER3_ID.ID, qrData))
                                //                    {
                                //                        success = true;
                                //                    }

                                //                    if (Global.Device.NGBUFFER.IN_BUFFER5_EXISTS.Value == 1
                                //                    && Global.Device.NGBUFFER.IN_BUFFER5_RESULT.Value == 0
                                //                    && string.Equals(Global.Device.NGBUFFER.IN_BUFFER5_ID.ID, qrData))
                                //                    {
                                //                        success = true;
                                //                    }

                                //                    if (Global.Device.NGBUFFER.IN_BUFFER6_EXISTS.Value == 1
                                //                    && Global.Device.NGBUFFER.IN_BUFFER6_RESULT.Value == 0
                                //                    && string.Equals(Global.Device.NGBUFFER.IN_BUFFER6_ID.ID, qrData))
                                //                    {
                                //                        success = true;
                                //                    }

                                //                    if (Global.Device.NGBUFFER.IN_BUFFER7_EXISTS.Value == 1
                                //                    && Global.Device.NGBUFFER.IN_BUFFER7_RESULT.Value == 0
                                //                    && string.Equals(Global.Device.NGBUFFER.IN_BUFFER7_ID.ID, qrData))
                                //                    {
                                //                        success = true;
                                //                    }

                                //                    if (Global.Device.NGBUFFER.IN_BUFFER9_EXISTS.Value == 1
                                //                    && Global.Device.NGBUFFER.IN_BUFFER9_RESULT.Value == 0
                                //                    && string.Equals(Global.Device.NGBUFFER.IN_BUFFER9_ID.ID, qrData))
                                //                    {
                                //                        success = true;
                                //                    }

                                //                    if (Global.Device.NGBUFFER.IN_BUFFER11_EXISTS.Value == 1
                                //                    && Global.Device.NGBUFFER.IN_BUFFER11_RESULT.Value == 0
                                //                    && string.Equals(Global.Device.NGBUFFER.IN_BUFFER11_ID.ID, qrData))
                                //                    {
                                //                        success = true;
                                //                    }

                                //                    if (Global.Device.NGBUFFER.IN_BUFFER12_EXISTS.Value == 1
                                //                    && Global.Device.NGBUFFER.IN_BUFFER12_RESULT.Value == 0
                                //                    && string.Equals(Global.Device.NGBUFFER.IN_BUFFER12_ID.ID, qrData))
                                //                    {
                                //                        success = true;
                                //                    }
                                //                }

                                //                if (success)
                                //                {
                                //                    CLogger.Add(LOG.SEQ, $"[SUCCESS] NG BUFFER ENTERING ==> {qrData}");

                                //                    for (int i = 0; i < NgBuffer.Count; i++)
                                //                    {
                                //                        if (NgBuffer[i].Item2 == qrCode)
                                //                        {
                                //                            lock (bufferLock)
                                //                            {
                                //                                NgBuffer.RemoveAt(i);
                                //                            }
                                //                        }
                                //                    }

                                //                    break;
                                //                }
                                //            }
                                //        }
                                //        if (Global.Mode.isJudgeScreenShot) IF_Util.SaveCaptureScreen($"{Application.StartupPath}\\CAPTURE\\{qrData.Replace("/", "_")}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_WaitEnd_{success}");


                                //});
                                //}
                                //Thread.Sleep(100);

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
                                    }
                                }
                                Stopwatch sw = Stopwatch.StartNew();
                                while (sw.ElapsedMilliseconds < 200000)
                                {
                                    Thread.Sleep(1);

                                    if (NGBUFFER.GetInPutBoard())
                                    {
                                        CLogger.Add(LOG.SEQ, $"INPUT BOARD ING BIT : ON");
                                        break;
                                    }
                                    else
                                    {
                                        CLogger.Add(LOG.SEQ, $"INPUT BOARD ING BIT : OFF");
                                    }
                                }

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
    }
}

