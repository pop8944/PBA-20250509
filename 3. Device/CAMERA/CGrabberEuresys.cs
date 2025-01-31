//using Euresys;
//using Euresys.MultiCam;
//using OpenCvSharp;
//using OpenCvSharp.UserInterface;
//using System;
//using System.Reflection;
//using System.Threading;
//using System.Windows.Forms;

//namespace IntelligentFactory
//{
//    public class CGrabberEuresys
//    {
//        public CPropertyCamera Property = new CPropertyCamera("EGRABBER");
//        public MC.CALLBACK multiCamCallback;
//        public ManualResetEvent IsGrabDone = new ManualResetEvent(false);

//        public Mat ImageGrab = new Mat();

//        protected string m_strName;
//        private bool isOpen;
//        public bool IsOpen { get => isOpen; set => isOpen = value; }

//        public bool m_bRun;

//        public uint EuresysCh;
//        public bool VisibleCross { get; set; } = false;

//        public System.Drawing.Size m_ImageSize;
//        public int m_nBufferPitch = 0;
//        //internal int m_nImageCount;

//        //public EventHandler<GrabEventArgs> EventGrabEnd;

//        public CGrabberEuresys()
//        {
//            isOpen = false;
//            m_bRun = false;
//        }

//        public bool Init()
//        {
//            try
//            {
//                Property.LoadConfig();

//                string strFilePath = IGlobal.m_MainPJTRoot + "\\STC-SPB510PCL_2440x2048_10TAP_RG";
//                int nImgSizeX, nImgSizeY, nbufferPitch;

//                MC.OpenDriver();
//                MC.SetParam(MC.CONFIGURATION, "ErrorLog", "error.log");
//                MC.SetParam(MC.BOARD + 0, "BoardTopology", "MONO_DECA");

//                MC.Create("CHANNEL", out EuresysCh);
//                MC.SetParam(EuresysCh, "DriverIndex", 0);
//                MC.SetParam(EuresysCh, "Connector", "M");

//                MC.SetParam(EuresysCh, "CamFile", strFilePath);

//                MC.SetParam(EuresysCh, "Hactive_Px", 2448);
//                MC.SetParam(EuresysCh, "Vactive_Ln", 2048);

//                MC.SetParam(EuresysCh, "ImageFlipX", "OFF");
//                MC.SetParam(EuresysCh, "ImageFlipY", "OFF");

//                MC.SetParam(EuresysCh, "AcquisitionMode", "SNAPSHOT");
//                MC.SetParam(EuresysCh, "TrigMode", "SOFT");
//                MC.SetParam(EuresysCh, "NextTrigMode", "SAME");
//                MC.SetParam(EuresysCh, "SeqLength_Fr", MC.INDETERMINATE);

//                MC.SetParam(EuresysCh, "FrameRate_mHz", 100000);
//                MC.SetParam(EuresysCh, "ExposeOverlap", "ALLOW");

//                MC.SetParam(EuresysCh, "Expose_us", 3000);

//                MC.GetParam(EuresysCh, "ImageSizeX", out nImgSizeX);
//                MC.GetParam(EuresysCh, "ImageSizeY", out nImgSizeY);
//                MC.GetParam(EuresysCh, "BufferPitch", out nbufferPitch);

//                m_ImageSize.Width = nImgSizeX;
//                m_ImageSize.Height = nImgSizeY;
//                m_nBufferPitch = nbufferPitch;

//                int[] sizes = new int[2] { (int)m_ImageSize.Height, (int)m_ImageSize.Width };

//                // Register the callback function
//                multiCamCallback = new MC.CALLBACK(MultiCamCallback);
//                MC.RegisterCallback(EuresysCh, multiCamCallback, EuresysCh);

//                // Enable the signals corresponding to the callback functions
//                MC.SetParam(EuresysCh, MC.SignalEnable + MC.SIG_SURFACE_PROCESSING, "ON");
//                MC.SetParam(EuresysCh, MC.SignalEnable + MC.SIG_ACQUISITION_FAILURE, "ON");

//                Start();
//                SoftwareTrigger();

//                isOpen = true;
//            }
//            catch (MultiCamException exc)
//            {
//                MessageBox.Show(exc.Message, "MultiCam Exception");
//                return false;
//            }

//            return true;
//        }

//        public void Start()
//        {
//            HardwareTrigger("IIN1");
//            SetModeStrobe();

//            MC.SetParam(EuresysCh, "AcquisitionMode", "SNAPSHOT");
//            MC.SetParam(EuresysCh, "TrigMode", "COMBINED");
//            MC.SetParam(EuresysCh, "NextTrigMode", "SAME");
//            MC.SetParam(EuresysCh, "SeqLength_Fr", MC.INDETERMINATE);

//            string channelState;
//            MC.GetParam(EuresysCh, "ChannelState", out channelState);
//            if (channelState != "ACTIVE")
//                MC.SetParam(EuresysCh, "ChannelState", "ACTIVE");
//        }

//        public void SetModeStrobe()
//        {
//            MC.SetParam(EuresysCh, "StrobeDur", 100);
//            MC.SetParam(EuresysCh, "StrobePos", 0);
//            MC.SetParam(EuresysCh, "StrobeMode", "AUTO");
//            MC.SetParam(EuresysCh, "PreStrobe_us", 195);
//            //MC.SetParam(EuresysCh, "PreStrobe_us", 50);
//            //MC.SetParam(EuresysCh, "Expose_us", 100);
//        }

//        public void Resume()
//        {
//            MC.SetParam(EuresysCh, "ChannelState", "IDLE");
//            MC.SetParam(EuresysCh, "TrigMode", "IMMEDIATE");

//            string channelState;
//            MC.GetParam(EuresysCh, "ChannelState", out channelState);
//            if (channelState != "ACTIVE")
//                MC.SetParam(EuresysCh, "ChannelState", "ACTIVE");

//            // Generate a soft trigger event
//            MC.SetParam(EuresysCh, "ForceTrig", "TRIG");
//        }

//        public bool Grab()
//        {
//            try
//            {
//                IsGrabDone.Reset();

//                string channelState;
//                MC.GetParam(EuresysCh, "ChannelState", out channelState);
//                if (channelState != "ACTIVE") MC.SetParam(EuresysCh, "ChannelState", "ACTIVE");
//                MC.SetParam(EuresysCh, "ForceTrig", "TRIG");
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                return false;
//            }

//            return true;
//        }

//        public bool Live(bool bLive)
//        {
//            try
//            {
//                if (bLive)
//                {
//                    SoftwareTrigger();
//                    StartThreadLive();
//                }
//                else
//                {
//                    StopThreadLive();
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                return false;
//            }

//            return true;
//        }

//        public CThreadStatus ThreadStatusLive { get; set; } = new CThreadStatus();

//        private void StartThreadLive()
//        {
//            if (ThreadStatusLive.IsExit())
//            {
//                Thread t = new Thread(new ParameterizedThreadStart(ThreadLive));
//                t.Start(ThreadStatusLive);
//            }
//        }

//        public void StopThreadLive()
//        {
//            if (!ThreadStatusLive.IsExit())
//            {
//                ThreadStatusLive.Stop(100);
//            }

//            ThreadStatusLive.End();
//        }

//        private void ThreadLive(object ob)
//        {
//            CThreadStatus ThreadStatus = (CThreadStatus)ob;

//            ThreadStatus.Start("Start the Live");

//            try
//            {
//                while (!ThreadStatus.IsExit())
//                {
//                    Thread.Sleep(100);
//                    Grab();
//                }

//                ThreadStatus.End();
//                return;
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                ThreadStatus.End();
//            }
//        }

//        public void Pause()
//        {
//            MC.SetParam(EuresysCh, "ChannelState", "IDLE");
//            MC.SetParam(EuresysCh, "TrigMode", "SOFT");
//            MC.SetParam(EuresysCh, "NextTrigMode", "SAME");
//        }

//        public bool Close()
//        {
//            StopThreadLive();
//            Thread.Sleep(1000);

//            if (!isOpen)
//                return false;

//            Stop();

//            string channelState;
//            MC.GetParam(EuresysCh, "ChannelState", out channelState);

//            if (channelState != "IDLE") MC.SetParam(EuresysCh, "ChannelState", "IDLE");

//            isOpen = false;

//            MC.CloseDriver();

//            return true;
//        }

//        public void Stop()
//        {
//            m_bRun = false;

//            string channelState;
//            MC.GetParam(EuresysCh, "ChannelState", out channelState);
//            if (channelState != "IDLE") MC.SetParam(EuresysCh, "ChannelState", "IDLE");
//        }

//        public void HardwareTrigger(string sLineNo = "IIN1")
//        {
//            MC.SetParam(EuresysCh, "ChannelState", "IDLE");
//            //MC.SetParam(EuresysCh, "ChannelState", "ORPHAN");
//            MC.SetParam(EuresysCh, "TrigMode", "HARD");
//            MC.SetParam(EuresysCh, "NextTrigMode", "SAME");
//            MC.SetParam(EuresysCh, "TrigLine", sLineNo);
//            MC.SetParam(EuresysCh, "TrigEdge", "GOHIGH");
//            MC.SetParam(EuresysCh, "TrigFilter", "MEDIUM");
//            //MC.SetParam(EuresysCh, "TrigFilter", "ON");
//            MC.SetParam(EuresysCh, "TrigCtl", "ISO");
//            MC.SetParam(EuresysCh, "SeqLength_Fr", MC.INDETERMINATE);

//            string channelState;
//            MC.GetParam(EuresysCh, "ChannelState", out channelState);
//            if (channelState != "ACTIVE")
//                MC.SetParam(EuresysCh, "ChannelState", "ACTIVE");

//            CLogger.Add(LOG_TYPE.DEVICE, "UPDATED TRIGGER H/W");
//        }

//        public void SoftwareTrigger()
//        {
//            MC.SetParam(EuresysCh, "ChannelState", "IDLE");
//            MC.SetParam(EuresysCh, "TrigMode", "SOFT");
//            MC.SetParam(EuresysCh, "NextTrigMode", "SAME");

//            CLogger.Add(LOG_TYPE.DEVICE, "UPDATED TRIGGER S/W");
//        }

//        public void MultiCamCallback(ref MC.SIGNALINFO signalInfo)
//        {
//            switch (signalInfo.Signal)
//            {
//                case MC.SIG_SURFACE_PROCESSING:
//                    ProcessingCallback(signalInfo);
//                    break;
//            }
//        }

//        public int m_nRecvCount = 0;

//        private void ProcessingCallback(MC.SIGNALINFO signalInfo)
//        {
//            try
//            {
//                uint currentChannel = (uint)signalInfo.Context;
//                uint currentSurface = signalInfo.SignalInfo;

//                MC.GetParam(currentSurface, "SurfaceAddr", out IntPtr ptr);

//                int[] sizes = new int[2] { (int)m_ImageSize.Height, (int)m_ImageSize.Width };

//                using (Mat ImageRecv = new Mat(sizes, MatType.CV_8U, ptr))
//                {
//                    ImageGrab = ImageRecv.Clone();
//                    m_nRecvCount++;

//                    //if (EventGrabEnd != null)
//                    //{
//                    //    EventGrabEnd(this, new GrabEventArgs(ImageGrab, 0));
//                    //}
//                }

//                IsGrabDone.Set();
//            }
//            catch (MultiCamException exc)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, exc);
//            }
//            catch (Exception exc)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, exc);
//            }
//        }

//        public bool SetExpose(int iChannel, int iExpose_us)
//        {
//            bool bRet = false;
//            try
//            {
//                MC.SetParam(EuresysCh, "Expose_us", iExpose_us);
//            }
//            catch
//            {
//            }

//            return bRet;
//        }

//        private PictureBoxIpl m_pbl = new PictureBoxIpl();

//        public void SetDisplay(PictureBoxIpl pb)
//        {
//            m_pbl = pb;
//        }
//    }
//}