using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;
using OpenCvSharp;

namespace IntelligentFactory
{
    public class CSeqMain
    {
        private IGlobal Global = IGlobal.Instance;
        public EventHandler<InspResultArgs> EventInspResult;

        private int m_nCam1_GrabRetryCount = 0;
        private int m_nCam2_GrabRetryCount = 0;

        private STEP_SEQ SeqStep = STEP_SEQ.IDLE;
        public enum STEP_SEQ
        {
            IDLE,
            CHECK_READY,
            WAIT_REQ_INSP,
            SET_AUTO_FOCUS,
            GRAB,
            WAIT_GRAB,
            REPORT_FTP,
            WAIT_RESULT,
            JUDGE_FIANL,
            COMPLETE
        }
        #region Thread
        public CThreadStatus ThreadStatus = new CThreadStatus();

        public void StartThread()
        {
            if(ThreadStatus.IsExit())
            {
                SetStep(STEP_SEQ.IDLE);
                Thread t = new Thread(new ParameterizedThreadStart(ThreadMain));
                t.Start(ThreadStatus);
            }
        }

        public void ResetThread()
        {
            ThreadStatus.End();
        }

        public void StopThread()
        {
            if (!ThreadStatus.IsExit())
            {
                ThreadStatus.Stop(100);
            }

            ResetThread();
        }

        public void SetStep(STEP_SEQ step)
        {            
            STEP_SEQ stepPrev = (STEP_SEQ)SeqStep;
            SeqStep = step;

            CLogger.Add(LOG.SEQ, "SEQ {0} STEP {1} ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, stepPrev.ToString(), step.ToString());
        }

        /// <summary>
        /// 프로그램이 종료가 될때까지 실행되며, 큐에 있는 데이터를 비전검사합니다.
        /// </summary>
        /// <param name="ob"></param>
        private void ThreadMain(object ob)
        {
            CThreadStatus ThreadStatus = (CThreadStatus)ob;

            ThreadStatus.Start("MAIN");

            try
            {
                string strCam1ImagePath = "";
                string strCam2ImagePath = "";

                while (!ThreadStatus.IsExit())
                {
                    Thread.Sleep(1);

                    if (Global.System.Mode != CSystem.MODE.AUTO) continue;

                    switch (SeqStep)
                    {
                        case STEP_SEQ.IDLE:
                            m_nCam1_GrabRetryCount = 0;
                            m_nCam2_GrabRetryCount = 0;

                            Global.Device.DIO_PLC.Off(Global.Device.DIO_PLC.DO_INSPECTION_COMPLETE);
                            Global.Device.DIO_PLC.Off(Global.Device.DIO_PLC.DO_FINAL_CHECK_OK);
                            Global.Device.DIO_PLC.Off(Global.Device.DIO_PLC.DO_FINAL_CHECK_NG);                            
                            SetStep(STEP_SEQ.CHECK_READY);
                            break;
                        case STEP_SEQ.CHECK_READY:
                            if(Global.Device.Grabber.Cameras.Count != 2)
                            {
                                CAlarm.Add(new CNodeAlarm("CONNECTION", "CHECK THE CAM CONNECTION"));
                                return;
                            }

                            if (Global.System.Mode != CSystem.MODE.AUTO)
                            {
                                CAlarm.Add(new CNodeAlarm("MODE", "SET MODE THE AUTO"));
                                return;
                            }

                            Global.Device.DIO_PLC.On(Global.Device.DIO_PLC.DO_READY);
                            SetStep(STEP_SEQ.WAIT_REQ_INSP);
                            break;
                        case STEP_SEQ.WAIT_REQ_INSP:
                            if (!Global.Device.DIO_PLC.DI_INSPECTION_REQ.IsOn) continue;

                            if (!Global.Device.AF_CONTROL.IsOpen)
                            {
                                CAlarm.Add(new CNodeAlarm("CONNECTION", "CHECK THE AF CONNECTION"));
                                return;
                            }
                            else
                            {
                                Global.Device.AF_CONTROL.SetAFTargetPosition(Global.System.Recipe.AF_TARGET_POS);
                                Global.Device.AF_CONTROL.StartAFModeSequence();
                            }
                            
                            SetStep(STEP_SEQ.SET_AUTO_FOCUS);
                            break;
                        case STEP_SEQ.SET_AUTO_FOCUS:
                            //AF
                            Thread.Sleep(1000);
                            SetStep(STEP_SEQ.GRAB);
                            break;
                        case STEP_SEQ.GRAB:
                            if (Global.Device.Grabber.Cameras.Count != 2)
                            {
                                CAlarm.Add(new CNodeAlarm("CONNECTION", "CHECK THE CAM CONNECTION"));
                                return;
                            }

                            Global.Device.Grabber.Cameras[0].Grab(Matrox_Camera_Example.Device.ETriggerOption.Software);
                            Global.Device.Grabber.Cameras[1].Grab(Matrox_Camera_Example.Device.ETriggerOption.Software);
                            SetStep(STEP_SEQ.WAIT_GRAB);
                            break;
                        case STEP_SEQ.WAIT_GRAB:
                            if (m_nCam1_GrabRetryCount > 3)
                            {
                                CAlarm.Add(new CNodeAlarm("CAMERA1", "CAM #1 GRAB FAIL"));
                                return;
                            }

                            if (m_nCam2_GrabRetryCount > 3)
                            {
                                CAlarm.Add(new CNodeAlarm("CAMERA2", "CAM #2 GRAB FAIL"));
                                return;
                            }

                            if (!Global.Device.Grabber.Cameras[0].IsGrabDone.WaitOne(500))
                            {
                                Global.Device.Grabber.Cameras[0].Grab(Matrox_Camera_Example.Device.ETriggerOption.Software);
                                m_nCam1_GrabRetryCount++;

                                continue;
                            }

                            if (!Global.Device.Grabber.Cameras[1].IsGrabDone.WaitOne(500))
                            {
                                Global.Device.Grabber.Cameras[1].Grab(Matrox_Camera_Example.Device.ETriggerOption.Software);
                                m_nCam2_GrabRetryCount++;

                                continue;
                            }

                            if (!Global.Device.AF_CONTROL.IsOpen)
                            {
                                CAlarm.Add(new CNodeAlarm("CONNECTION", "CHECK THE AF CONNECTION"));
                                return;
                            }
                            else
                            {
                                Global.Device.AF_CONTROL.StopAFModeSeqeunce();
                            }
                            
                            SetStep(STEP_SEQ.REPORT_FTP);
                            break;
                        case STEP_SEQ.REPORT_FTP:
                            string strCam1Path = $"{Application.StartupPath}\\Cam1.jpg";
                            string strCam2Path = $"{Application.StartupPath}\\Cam2.jpg";

                            if(Global.Device.Grabber.Cameras[0].CrevisImage.BitmapImage == null)
                            {
                                CAlarm.Add(new CNodeAlarm("CAMERA1", "CAM #1 IMAGE EMPTY"));
                                return;
                            }

                            if (Global.Device.Grabber.Cameras[1].CrevisImage == null || Global.Device.Grabber.Cameras[1].CrevisImage.BitmapImage == null)
                            {
                                CAlarm.Add(new CNodeAlarm("CAMERA1", "CAM #2 IMAGE EMPTY"));
                                return;
                            }

                            
                            if(Global.System.Recipe.CAM1_CROP_RECT.Width == 0 || Global.System.Recipe.CAM1_CROP_RECT.Height == 0)
                            {
                                Global.System.Recipe.CAM1_CROP_RECT.Width = Global.Device.Grabber.Cameras[0].CrevisImage.BitmapImage.Width;
                                Global.System.Recipe.CAM1_CROP_RECT.Height= Global.Device.Grabber.Cameras[0].CrevisImage.BitmapImage.Height;
                            }

                            ImageHelper.SaveJPGImage(CUtil.Crop(Global.Device.Grabber.Cameras[0].CrevisImage.BitmapImage, Global.System.Recipe.CAM1_CROP_RECT), strCam1Path, Global.System.Recipe.COMPRESS_LEVEL);


                            ImageHelper.SaveJPGImage(CUtil.Crop(Global.Device.Grabber.Cameras[1].CrevisImage.BitmapImage, Global.System.Recipe.CAM2_CROP_RECT), strCam2Path, Global.System.Recipe.COMPRESS_LEVEL);
                            //경로를 지정할수있는 UI 작업
                            strCam1ImagePath = $"/home/CAM1_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.jpg";
                            strCam2ImagePath = $"/home/CAM1_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.jpg";

                            Global.Interface.FTPClient.UploadFile(strCam1Path, strCam1ImagePath);
                            Global.Interface.FTPClient.UploadFile(strCam2Path, strCam2ImagePath);

                            //SEND CJGR
                            //TIMEOUT START
                            //Global.Interface.TibRv64.SendMessage();

                            Global.Interface.ADJManager.CJDG.HasChanged = false;
                            SetStep(STEP_SEQ.WAIT_RESULT);
                            break;
                        case STEP_SEQ.WAIT_RESULT:
                            //WAIT CJDG
                            //REPLY CJDG_R
                            if (!Global.Interface.ADJManager.CJDG.HasChanged) continue;
                            SetStep(STEP_SEQ.JUDGE_FIANL);
                            break;
                        case STEP_SEQ.JUDGE_FIANL:
                            if(Global.Interface.ADJManager.CJDG.RESULT == "Y")
                            {
                                Global.Device.DIO_PLC.On(Global.Device.DIO_PLC.DO_FINAL_CHECK_OK);
                            }
                            else
                            {
                                Global.Device.DIO_PLC.On(Global.Device.DIO_PLC.DO_FINAL_CHECK_NG);
                            }

                            Global.Device.DIO_PLC.On(Global.Device.DIO_PLC.DO_INSPECTION_COMPLETE);
                            SetStep(STEP_SEQ.COMPLETE);
                            break;
                        case STEP_SEQ.COMPLETE:
                            SetStep(STEP_SEQ.IDLE);
                            ThreadStatus.End();
                            return;
                    }
                }

                ThreadStatus.End();
            }
            catch (Exception Desc)
            {
                Global.Device.AF_CONTROL.StartAFModeSequence();
                SetStep(STEP_SEQ.IDLE);
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                ThreadStatus.End();
            }
        }
        #endregion
    }
}
