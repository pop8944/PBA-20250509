//using Cognex.VisionPro;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Reflection;
//using System.Threading;
//using System.Windows.Forms;

//namespace IntelligentFactory
//{
//    public class CSeqAutoInsp
//    {
//        private IGlobal Global = IGlobal.Instance;
//        public Bitmap[] ImageResults_array = new Bitmap[4];

//        public Cognex.VisionPro.Display.CogDisplay display;

//        public FlowLayoutPanel pn_Cam;

//        private STEP_SEQ SeqStep = STEP_SEQ.WAIT_INSP;

//        public int m_INS_Count = 0;

//        public FormMenu_Viewer frmViewer = new FormMenu_Viewer();

//        // 결과값 드로우를 위한 플래그
//        public bool ResultComplete = false;

//        public enum STEP_SEQ
//        {
//            IDLE,
//            CHECK_READY,
//            WAIT_INSP,
//            GRAB,
//            WAIT_GRAB,
//            RESULT,
//            DATASAVE,
//            MEWTOCOL_SEND,
//        }

//        #region Thread

//        public CThreadStatus ThreadStatus = new CThreadStatus();

//        public void StartGrabThread()
//        {
//            IGlobal.Notice = "Inspecting...";
//            IGlobal.Instance.Porgess_Display();

//            if (ThreadStatus.IsExit())
//            {
//                SetStep(STEP_SEQ.IDLE);
//                Thread t = new Thread(new ParameterizedThreadStart(ThreadGrab));
//                t.Start(ThreadStatus);
//            }
//        }

//        public void ResetGrabThread()
//        {
//            ThreadStatus.End();
//        }

//        public void StopGrabThread()
//        {
//            if (!ThreadStatus.IsExit())
//            {
//                ThreadStatus.Stop(100);
//            }

//            ResetGrabThread();
//        }

//        public void SetStep(STEP_SEQ step)
//        {
//            STEP_SEQ stepPrev = (STEP_SEQ)SeqStep;
//            SeqStep = step;

//            CLogger.Add(LOG_TYPE.SEQ, "SEQ {0} STEP {1} ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, stepPrev.ToString(), step.ToString());
//        }
//        public STEP_SEQ GetStep()
//        {
//            return SeqStep;
//        }


//        /// <summary>
//        /// 프로그램이 종료가 될때까지 실행되며, 큐에 있는 데이터를 비전검사합니다.
//        /// </summary>
//        /// <param name="ob"></param>
//        ///

//        private CogImage24PlanarColor[] _imagesGrab = new CogImage24PlanarColor[5]
//        {
//            new CogImage24PlanarColor(),
//            new CogImage24PlanarColor(),
//            new CogImage24PlanarColor(),
//            new CogImage24PlanarColor(),
//            new CogImage24PlanarColor()
//        };

//        public bool[] ArrayResults = new bool[4] { false, false, false, false };

//        private void ThreadGrab(object ob)
//        {
//            CThreadStatus ThreadStatus = (CThreadStatus)ob;

//            ThreadStatus.Start("Grab");

//            int nInspectCount = 0;

//            try
//            {
//                bool bRetry = false;
//                int tickGrabStart = 0;
//                int tickGrabEnd = 0;
//                int tickProcessStart = 0;
//                int tickProcessEnd = 0;
//                int tickPostProcessStart = 0;
//                int tickPostProcessEnd = 0;
//                String strMsg = "";

//                while (!ThreadStatus.IsExit())
//                {
//                    Thread.Sleep(1);

//                    if (Global.System.REQ_SYSTEM_CLOSE == true) return;

//                    switch (SeqStep)
//                    {
//                        case STEP_SEQ.IDLE:
//                            ResultComplete = false;
//                            bRetry = false;
//                            ArrayResults = new bool[4] { false, false, false, false };
//                            //DIO 초기화
//                            IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
//                            IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
//                            //Global.Device.DIO_BD.Off(false, 2);
//                            //Global.Device.DIO_BD.Off(false, 1);
//                            //Global.Device.DIO_BD.Off(Global.Device.DIO_BD.OUT_02_RESULT_OK);
//                            //Global.Device.DIO_BD.Off(Global.Device.DIO_BD.OUT_01_RESULT_NG);

//                            for (int i = 0; i < Global.Device.IMAGEFOCUS_LIGHT.ChannelCount; i++)
//                            {
//                                Global.Device.IMAGEFOCUS_LIGHT.SetValue(i + 1, 254);
//                            }

//                            Global.Device.IMAGEFOCUS_LIGHT.AllOn();

//                            Thread.Sleep(1000);

//                            SetStep(STEP_SEQ.GRAB);
//                            break;

//                        case STEP_SEQ.GRAB:
//                            tickGrabStart = Environment.TickCount;
//                            IGlobal.Notice = "Inspecting : Start Grab";
//                            //test
//                            if (Global.Device.bVirtualUse == false)
//                            {
//                                if (Global.Device.Cameras.Count == 0 || Global.Device.Cameras[0].IsOpen == false)
//                                {
//                                    CAlarm.Add(new CNodeAlarm("CAMERA", "Check the Connection of Camera"));
//                                    ThreadStatus.End();
//                                    continue;
//                                }

//                                // Grab
//                                Global.Device.Cameras[0].SetGrabMaxCount(Global.System.CommonCode.GrabManager.Nodes.Length);
//                                Global.Device.Cameras[0].m_GrabAll = true;

//                                int nGrabmaxcnt = Global.System.CommonCode.GrabManager.Nodes.Length;
//                                bool[] nEnabled = new bool[nGrabmaxcnt];
//                                int[] nExposureTime = new int[nGrabmaxcnt];

//                                for (int i = 0; i < nGrabmaxcnt; i++)
//                                {
//                                    nEnabled[i] = Global.System.CommonCode.GrabManager.Nodes[i].Enabled;
//                                    nExposureTime[i] = Global.System.CommonCode.GrabManager.Nodes[i].ExposureTime_us;
//                                }

//                                Global.Device.Cameras[0].Grab_All(nGrabmaxcnt, nEnabled, nExposureTime);

//                                for (int i = 0; i < Global.Device.Cameras[0].m_imageCogGrab.Length; i++)
//                                {
//                                    if (Global.Device.Cameras[0].m_imageCogGrab[i] != null)
//                                    {
//                                        // 20230111 Edit
//                                        _imagesGrab[i] = new CogImage24PlanarColor((CogImage24PlanarColor)IGlobal.Instance.Device.Cameras[DEFINE.CAM1].m_imageCogGrab[i]);
//                                    }
//                                }

//                            }
//                            else
//                            {
//                                Bitmap image = new Bitmap("C:\\Users\\IF\\Desktop\\Workspace\\IMAGE\\01.jpg");
//                                for (int i = 0; i < Global.System.CommonCode.GrabManager.Nodes.Length; i++)
//                                {
//                                    if (Global.System.CommonCode.GrabManager.Nodes[i].Enabled)
//                                    {
//                                        _imagesGrab[i] = new CogImage24PlanarColor(new CogImage24PlanarColor(image));
//                                    }
//                                }
//                            }

//                            tickGrabEnd = Environment.TickCount;
//                            strMsg = $"Grab Time = {tickGrabEnd - tickGrabStart} ms";
//                            CLogger.Add(LOG_TYPE.NORMAL, strMsg);
//                            SetStep(STEP_SEQ.WAIT_GRAB);
//                            break;

//                        case STEP_SEQ.WAIT_GRAB:
//                            {
//                                tickProcessStart = Environment.TickCount;
//                                IGlobal.Notice = "Inspecting : Wait Grab";
//                                List<bool> Results = CVisionTools.Run(null, _imagesGrab, display, out ImageResults_array, Global.Mode.InspectProcess, false);
//                                // Disk를 정리한다.
//                                Tuple<int, int> tRet = CUtil.CleanDrive(Global.Mode.availHdd, Global.Mode.deleteFileN);
//                                string strDisp = "DeleteFolder : " + tRet.Item1.ToString() + " , DeleteFile : " + tRet.Item2.ToString();
//                                CLogger.Add(LOG_TYPE.NORMAL, strDisp);

//                                int nCount_OK = 0;

//                                for (int i = 0; i < Results.Count; i++)
//                                {
//                                    if (Results[i]) nCount_OK++;
//                                    ArrayResults[i] = Results[i];
//                                }

//                                if (Global.System.Recipe.JobManager.ArrayCount == nCount_OK || bRetry)
//                                {
//                                    SetStep(STEP_SEQ.RESULT);
//                                }
//                                else
//                                {
//                                    //RETRY
//                                    bRetry = true;
//                                    SetStep(STEP_SEQ.GRAB);
//                                    continue;
//                                }
//                                tickProcessEnd = Environment.TickCount;
//                                strMsg = $"Process Time = {tickProcessEnd - tickProcessStart} ms";
//                                CLogger.Add(LOG_TYPE.NORMAL, strMsg);
//                            }

//                            break;

//                        case STEP_SEQ.RESULT:
//                            tickPostProcessStart = Environment.TickCount;
//                            {
//                                bool bTotalResult = RMS_PostProcessing();
//                                ResultComplete = true;
//                            }

//                            //EventRunResult?.Invoke(this, new SeqGrabResultArgs("", ""));

//                            if (ResultComplete)
//                            {
//                                IGlobal.Notice = "Inspecting : Result Complete";
//                                // 프로그레스 닫기
//                                IGlobal.Instance.OnEnd_Progress();
//                            }

//                            SetStep(STEP_SEQ.IDLE);
//                            ThreadStatus.End();
//                            tickPostProcessEnd = Environment.TickCount;
//                            strMsg = $"PostProcess Time = {tickPostProcessEnd - tickPostProcessStart} ms";
//                            CLogger.Add(LOG_TYPE.NORMAL, strMsg);

//                            if (Global.Mode.bReInspect)
//                            {
//                                if (nInspectCount++ < 1)
//                                    break;
//                                else
//                                    return;
//                            }
//                            else
//                                return;
//                    }
//                }

//                ThreadStatus.End();
//                SetStep(STEP_SEQ.IDLE);
//            }
//            catch (Exception Desc)
//            {
//                CLogger.Add(LOG_TYPE.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
//                ThreadStatus.End();
//                SetStep(STEP_SEQ.IDLE);
//            }
//        }

//        public bool RMS_PostProcessing()
//        {
//            IGlobal.Notice = "Inspecting : Judging";
//            bool bTotalResult = true;
//            string strData = "";
//            int nErrorQR = 0;

//            QRParser cStandardQR = Global.Data.GetStandardQR();

//            for (int i = 0; i < Global.System.Recipe.JobManager.ArrayCount; i++)
//            {
//                string strTitle = cStandardQR.GetQRTitle();
//                //QRParser qrID = new QRParser(strID);

//                //int nindex = strID.IndexOf("DT");
//                //if (nindex > 0 && strID.Length >= (nindex + 8))
//                //{
//                //    strID = strID.Substring(nindex, 8);
//                //}
//                if (Global.Data.Board_QrCode[i].IsError()) nErrorQR++;

//                // 여기 변경한다.
//                //if (i == 0)
//                //{
//                //    strData = cStandardQR.GetQRTitle() + Global.Data.Board_QrCode[i].GetSerialNo();
//                //}
//                //else
//                //{
//                //    strData = strData + "/" + Global.Data.Board_QrCode[i].GetSerialNo();
//                //}
//                if (i == 0)
//                {
//                    strData = Global.Data.Board_QrCode[i].GetQR();
//                }
//                else
//                {
//                    strData = strData + "/" + Global.Data.Board_QrCode[i].GetQR();
//                }

//                if (ArrayResults[i] == false)
//                {
//                    bTotalResult = false;
//                    Global.Data.CountNG_F++;
//                }
//                else
//                {
//                    Global.Data.CountOK++;
//                }

//                Global.FileManager.IdDataSave(Global.Data.Board_QrCode[i].GetQR(), ArrayResults[i]);
//            }
//            if (nErrorQR > 0)
//            {
//                CLogger.Add(LOG_TYPE.ABNORMAL, "[QR] ReadError");
//            }

//            bool tmp = Global.Device.MewtocolComm.Command_PCBID_INPUT(strData); //NG시 PCB 데이터 입력
//            Global.Device.strRMSQR = Global.Device.MewtocolComm.GetQR().GetQR();
//            Global.Device.SaveConfig();

//            Global.FileManager.CountSave(Global.Data.CountOK, Global.Data.CountNG_T, Global.Data.CountNG_F, double.Parse(Global.Data.yield));

//            bool bRecent = false;
//            if (!Global.Mode.NGisRecent)
//                bRecent = true;
//            else
//            {
//                if (!bTotalResult)
//                    bRecent = true;
//            }

//            if (bRecent)
//            {
//                CogRecentImage recent = new CogRecentImage();
//                recent.Name = strData;
//                recent.DateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

//                recent.recentImages = new CogImage24PlanarColor[5]
//                {
//                                            new CogImage24PlanarColor(),
//                                            new CogImage24PlanarColor(),
//                                            new CogImage24PlanarColor(),
//                                            new CogImage24PlanarColor(),
//                                            new CogImage24PlanarColor()
//                };

//                for (int i = 0; i < recent.recentImages.Length; i++)
//                {
//                    if (_imagesGrab[i] != null && _imagesGrab[i].Allocated)
//                    {
//                        recent.recentImages[i] = new CogImage24PlanarColor(_imagesGrab[i]);
//                    }
//                }
//                Global.Data.cogRecentImages.Add(recent);
//                if (Global.Data.cogRecentImages.Count > 20)
//                    Global.Data.cogRecentImages.RemoveAt(0);
//            }

//            if (!Global.Mode.isForceJudge) //정상 시퀀스
//            {
//                if (bTotalResult) //OK
//                {
//                    CLogger.Add(LOG_TYPE.SEQ, $"SEQ NORMAL JUDGE ==> OK");
//                    IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
//                    IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
//                    //Global.Device.DIO_BD.On("RESULT_OK");
//                    //Global.Device.DIO_BD.Off("RESULT_NG");

//                    Global.Device.MewtocolComm.Command_PCBID_END_JUDGE(true);
//                }
//                else//NG
//                {
//                    CLogger.Add(LOG_TYPE.SEQ, $"SEQ NORMAL JUDGE ==> NG");
//                    if (Global.Mode.isRMSAutoPopup) //RMS PopUp MODE
//                    {
//                        CUtil.ShowHideForm(frmViewer, true);
//                    }
//                    else if (Global.System.RMS_TIMER_MODE)
//                    {
//                        CUtil.ShowHideForm(frmViewer, true);
//                    }

//                    if (!Global.Mode.isDebugMode)
//                    {
//                        IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
//                        IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);
//                        //Global.Device.DIO_BD.Off("RESULT_OK");
//                        //Global.Device.DIO_BD.On("RESULT_NG");
//                        Global.Device.MewtocolComm.Command_PCBID_END_JUDGE(false);
//                    }
//                    else //디버그모드 ON이면 NG시 신호 안나가고 멈추고 수정후 재검사
//                    {
//                        CLogger.Add(LOG_TYPE.SEQ, $"SEQ NORMAL JUDGE ==> DEBUG");
//                        IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
//                        IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
//                        //Global.Device.DIO_BD.Off("RESULT_OK");
//                        //Global.Device.DIO_BD.Off("RESULT_NG");
//                    }
//                }
//            }
//            else
//            {
//                if (Global.Mode.AutoJudge)
//                {
//                    CLogger.Add(LOG_TYPE.SEQ, $"SEQ AUTO JUDGE ==> OK");
//                    IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
//                    IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
//                    //Global.Device.DIO_BD.On("RESULT_OK");
//                    //Global.Device.DIO_BD.Off("RESULT_NG");

//                    Global.Device.MewtocolComm.Command_PCBID_END_JUDGE(true);
//                }
//                else
//                {
//                    CLogger.Add(LOG_TYPE.SEQ, $"SEQ AUTO JUDGE ==> NG");
//                    IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
//                    IGlobal.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);
//                    //Global.Device.DIO_BD.Off("RESULT_OK");
//                    //Global.Device.DIO_BD.On("RESULT_NG");

//                    Global.Device.MewtocolComm.Command_PCBID_END_JUDGE(false);
//                }
//            }

//            for (int i = 0; i < Global.Device.IMAGEFOCUS_LIGHT.ChannelCount; i++)
//            {
//                Global.Device.IMAGEFOCUS_LIGHT.SetValue(i + 1, 0);
//            }

//            Global.Device.IMAGEFOCUS_LIGHT.AllOff();
//            return bTotalResult;
//        }

//        #endregion Thread
//    }
//}