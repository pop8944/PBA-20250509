﻿//using Matrox.MatroxImagingLibrary;
//using System;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.IO;
//using System.Reflection;
//using System.Runtime.InteropServices;
//using System.Threading;
//using System.Windows.Forms;
//using System.Xml;

//namespace IntelligentFactory
//{
//    public class CGrabberMatroxSolios
//    {
//        public int Index { get; set; } = 0;
//        public int ImageHeight { get; set; } = 4000;
//        public int ImageWidth { get; set; } = 4096;
//        public int Threshold { get; set; } = 125;
//        public double ExposureTime { get; set; } = 10000.0D;
//        public double Gain { get; set; } = 1.0D;
//        public double PixelPermm { get; set; } = 0.05D;
//        public string Name { get; set; } = "";
//        public bool ViewModeCrss { get; set; } = false;

//        public ManualResetEvent IsGrabDone = new ManualResetEvent(false);

//        public bool IsOpen { get; set; } = false;

//        public Size GrabSize, DispSize = new Size(100, 100);
//        //private float m_fScaleFactorX, m_fScaleFactorY = 1.0F;

//        public MIL_ID MIL_System;
//        public MIL_ID MIL_App;

//        public MIL_ID MIL_Digitizer;
//        public MIL_ID MIL_Display;
//        public MIL_ID MIL_ImageBuffer;

//        public MIL_ID MIL_GrabBuffer;
//        public MIL_ID MIL_ProcBuffer;
//        public MIL_ID MIL_DispBuffer;

//        public MIL_ID MIL_LastBuffer;

//        public MIL_INT MIL_DispAttribute = MIL.M_IMAGE + MIL.M_DISP + MIL.M_PROC;
//        public MIL_INT MIL_GrabAttribute = MIL.M_IMAGE + MIL.M_DISP + MIL.M_PROC + MIL.M_GRAB;

//        public MIL_INT MIL_Channel;
//        public MIL_INT MIL_Width;
//        public MIL_INT MIL_Height;

//        public MIL_INT MIL_Type = 8 + MIL.M_UNSIGNED;

//        public MIL_INT MIL_RowBuffer = 450;   //그랩할 로우
//        public MIL_INT MIL_BufferCount = 25;  //로우 몇 세트 그랩하는지

//        //public MIL_DIG_HOOK_FUNCTION_PTR GrabProcessDelegate_GrabEnd;

//        public class HookDataObject // User's archive function hook data structure.
//        {
//            public MIL_ID MilSystem;
//            public MIL_ID MilDisplay;
//            public MIL_ID MilImageDisp;
//            public MIL_ID MilCompressedImage;
//            public int NbGrabbedFrames;
//            public int NbArchivedFrames;
//            public bool SaveSequenceToDisk;
//        };

//        public HookDataObject UserHookData = new HookDataObject();

//        public IntPtr Handle;

//        public int Channel = 0;
//        public string FILE_PATH_DCF = "basler 4k_base(2tap)_Freerun_v10.dcf";

//        public event EventHandler<GrabEventArgs> EventGrabEnd;

//        public CGrabberMatroxSolios(int nIndex, string strName)
//        {
//            Index = nIndex;
//            Name = strName;

//            MIL_Digitizer = MIL.M_NULL;
//            MIL_Display = MIL.M_NULL;

//            MIL_ImageBuffer = MIL.M_NULL;
//            MIL_GrabBuffer = MIL.M_NULL;
//            MIL_ProcBuffer = MIL.M_NULL;
//            MIL_DispBuffer = MIL.M_NULL;
//        }

//        public bool Init()
//        {
//            try
//            {
//                FILE_PATH_DCF = IGlobal.m_MainPJTRoot + "\\" + "Solios eV-CL Full _Continous.dcf";

//                //ALLOC 설정
//                MIL.MappAlloc(MIL.M_DEFAULT, ref MIL_App);

//                MIL.MsysAlloc(MIL.M_SYSTEM_SOLIOS, MIL.M_DEV0, MIL.M_DEFAULT, ref MIL_System);

//                if (MIL_System == 0)
//                    MIL.MsysAlloc(MIL.M_SYSTEM_HOST, MIL.M_DEV0, MIL.M_DEFAULT, ref MIL_System);

//                MIL.MdigAlloc(MIL_System, Channel, FILE_PATH_DCF, MIL.M_DEFAULT, ref MIL_Digitizer);
//                MIL.MdispAlloc(MIL_System, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_DEFAULT, ref MIL_Display);
//                MIL.MdigControl(MIL_Digitizer, MIL.M_CAMERALINK_CC3_SOURCE, MIL.M_GRAB_EXPOSURE);

//                //MIL.MdigControl(MIL_Digitizer, MIL.M_GRAB_MODE, MIL.M_ASYNC);

//                MIL_Width = MIL.MdigInquire(MIL_Digitizer, MIL.M_SIZE_X, MIL.M_NULL);
//                MIL_Height = MIL.MdigInquire(MIL_Digitizer, MIL.M_SIZE_Y, MIL.M_NULL);
//                MIL_Channel = MIL.MdigInquire(MIL_Digitizer, MIL.M_SIZE_BAND, MIL.M_NULL);

//                // 임시로 주석
//#if !Dbug
//                MIL.MdigInquire(MIL_Digitizer, MIL.M_SIZE_Y, MIL.M_NULL);

//                MIL.MbufAllocColor(MIL_System, MIL_Channel, MIL_Width, MIL_Height, 8 + MIL.M_UNSIGNED, MIL_GrabAttribute, ref MIL_GrabBuffer);
//                MIL.MbufClear(MIL_GrabBuffer, 0);

//                MIL.MbufAllocColor(MIL_System, MIL_Channel, MIL_Width, MIL_Height, 8 + MIL.M_UNSIGNED, MIL_GrabAttribute, ref MIL_LastBuffer);
//                MIL.MbufClear(MIL_LastBuffer, 0);

//                MIL.MbufAllocColor(MIL_System, MIL_Channel, MIL_Width, MIL_Height, 8 + MIL.M_UNSIGNED, MIL_GrabAttribute, ref MIL_ProcBuffer);
//                MIL.MbufClear(MIL_ProcBuffer, 0);

//                MIL.MbufAllocColor(MIL_System, MIL_Channel, MIL_Width, MIL_Height, 8 + MIL.M_UNSIGNED, MIL_GrabAttribute, ref MIL_DispBuffer);
//                MIL.MbufClear(MIL_DispBuffer, 0);
//#endif
//                if ((int)MIL_Width == 0 || (int)MIL_Height == 0)
//                {
//                    IsOpen = false;
//                    return false;
//                }

//                ImageWidth = (int)MIL_Width;
//                ImageHeight = (int)MIL_Height;

//                IsOpen = true;
//            }
//            catch (Exception Desc)
//            {
//                CLogger.Add(LOG_TYPE.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
//                return false;
//            }

//            return true;
//        }

//        public void GrabStart()
//        {
//            try
//            {
//                if (IsOpen)
//                {
//                    //Thread 로 구성해야될 필요가 있습니다.
//                    IsGrabDone.Reset();

//                    MIL.MdigGrab(MIL_Digitizer, MIL_GrabBuffer);
//                    MIL.MbufCopy(MIL_GrabBuffer, MIL_LastBuffer);

//                    IsGrabDone.Set();

//                    if (EventGrabEnd != null)
//                    {
//                        EventGrabEnd(null, null);
//                    }
//                }
//            }
//            catch (Exception Desc)
//            {
//                CLogger.Add(LOG_TYPE.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
//            }
//        }

//        public Bitmap LoadImage(string strImagePath, ref MIL_ID image)
//        {
//            Bitmap bmp = new Bitmap(4096, 4000, PixelFormat.Format24bppRgb);

//            try
//            {
//                int nSTART = Environment.TickCount;
//                byte[] buff = new byte[4096 * 4000 * 3];

//                if (image != MIL.M_NULL)
//                    MIL.MbufFree(image);

//                MIL.MbufRestore(strImagePath, MIL_System, ref image);
//                MIL.MbufGet(image, buff); // MilImage-> MIL 이미지 ,  UserBuffer -> Array 버퍼
//                bmp = ByteToBitmap(buff, 4096, 4000);

//                int nEnd = Environment.TickCount - nSTART;
//            }
//            catch (Exception Desc)
//            {
//                CLogger.Add(LOG_TYPE.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
//                return bmp;
//            }

//            return bmp;
//        }

//        public Bitmap ByteToBitmap(byte[] imgArr, int nW, int nH)
//        {
//            Bitmap bmp = new Bitmap(nW, 4000, PixelFormat.Format8bppIndexed);
//            // IntPtr ptr = res.GetHbitmap();

//            BitmapData data = bmp.LockBits(
//                                    new Rectangle(0, 0, nW, nH),
//                                    ImageLockMode.ReadWrite,
//                                        PixelFormat.Format8bppIndexed);
//            IntPtr ptr = data.Scan0;
//            Marshal.Copy(imgArr, 0, ptr, nW * nH);
//            bmp.UnlockBits(data);

//            //모노이미지로 변환해준다 사용하지 않을경우 칼라이미지가 깨진채로 사용된다
//            ColorPalette Gpal = bmp.Palette;
//            for (int i = 0; i < 256; i++)
//            {
//                Gpal.Entries[i] = Color.FromArgb(i, i, i);
//            }
//            bmp.Palette = Gpal;

//            return bmp;
//        }

//        public void Close()
//        {
//            try
//            {
//                Live(false);
//            }
//            catch (Exception Desc)
//            {
//                CLogger.Add(LOG_TYPE.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
//            }
//        }

//        public void Live(bool bEnable)
//        {
//            if (!IsOpen) return;

//            if (bEnable)
//            {
//                StartThreadLive();
//            }
//            else
//            {
//                StopThreadLive();
//                ResetThreadLive();
//            }
//        }

//        #region Thread

//        private CThreadStatus m_ThreadStatusLive = new CThreadStatus();

//        public CThreadStatus ThreadStatusLive
//        {
//            get { return m_ThreadStatusLive; }
//        }

//        private void StartThreadLive()
//        {
//            Thread t = new Thread(new ParameterizedThreadStart(ThreadLive));
//            t.Start(m_ThreadStatusLive);
//        }

//        public void StopThreadLive()
//        {
//            if (!ThreadStatusLive.IsExit())
//            {
//                ThreadStatusLive.Stop(100);
//            }
//        }

//        private void ResetThreadLive()
//        {
//            m_ThreadStatusLive.End();
//        }

//        private void ThreadLive(object ob)
//        {
//            CThreadStatus ThreadStatus = (CThreadStatus)ob;

//            ThreadStatus.Start("Live Thread");
//            CLogger.Add(LOG_TYPE.NORMAL, "Live Thread");
//            try
//            {
//                while (!ThreadStatus.IsExit())
//                {
//                    Thread.Sleep(100);

//                    GrabStart();

//                    IsGrabDone.WaitOne();
//                }
//            }
//            catch (Exception Desc)
//            {
//                CLogger.Add(LOG_TYPE.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
//            }
//        }

//        #endregion Thread

//        #region File Manager

//        private string m_XMLName = "CameraSetting";

//        public bool LoadConfig(string strRecipe)
//        {
//            try
//            {
//                string strPath = IGlobal.m_MainPJTRoot + "\\" + strRecipe + "\\" + m_XMLName + Index.ToString() + ".xml";

//                if (File.Exists(strPath))
//                {
//                    XmlTextReader xmlReader = new XmlTextReader(strPath);

//                    try
//                    {
//                        LoadConfigByXML(xmlReader);
//                    }
//                    catch (Exception ex)
//                    {
//                        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                        xmlReader.Close();
//                    }

//                    xmlReader.Close();
//                }
//                else
//                {
//                    SaveConfig(strRecipe);
//                    return false;
//                }
//            }
//            catch (Exception Desc)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
//                return false;
//            }
//            return true;
//        }

//        public bool SaveConfig(string strRecipe)
//        {
//            string strPath = IGlobal.m_MainPJTRoot + "\\" + "\\" + strRecipe + "\\" + m_XMLName + Index.ToString() + ".xml";
//            //IData.InitRecipeDirectory(strRecipe);

//            XmlWriterSettings settings = new XmlWriterSettings();
//            settings.Indent = true;
//            settings.NewLineOnAttributes = true;
//            settings.IndentChars = "\t";
//            settings.NewLineChars = "\r\n";
//            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
//            try
//            {
//                xmlWriter.WriteStartDocument();

//                SaveConfigByXML(xmlWriter);
//                xmlWriter.WriteEndDocument();
//            }
//            catch (Exception Desc)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
//            }
//            finally
//            {
//                xmlWriter.Flush();
//                xmlWriter.Close();
//            }
//            return true;
//        }

//        public bool LoadConfigByXML(XmlReader xmlReader)
//        {
//            try
//            {
//                while (xmlReader.Read())
//                {
//                    if (xmlReader.NodeType == XmlNodeType.Element)
//                    {
//                        switch (xmlReader.Name)
//                        {
//                            case "ExposureTime":
//                                if (!xmlReader.Read()) return false;
//                                ExposureTime = double.Parse(xmlReader.Value);
//                                break;

//                            case "Gain":
//                                if (!xmlReader.Read()) return false;
//                                Gain = double.Parse(xmlReader.Value);
//                                break;

//                            case "Threshold":
//                                if (!xmlReader.Read()) return false;
//                                Threshold = int.Parse(xmlReader.Value);
//                                break;

//                            case "ROI":
//                                if (!xmlReader.Read()) return false;
//                                string[] strROI = xmlReader.Value.Split(',');

//                                if (strROI.Length == 4)
//                                {
//                                    int nX = int.Parse(strROI[0]);
//                                    int nY = int.Parse(strROI[1]);
//                                    int nWidth = int.Parse(strROI[2]);
//                                    int nHeight = int.Parse(strROI[3]);

//                                    //ROI = new Rect(nX, nY, nWidth, nHeight);
//                                }
//                                break;

//                            case "PixelPermm":
//                                if (!xmlReader.Read()) return false;
//                                PixelPermm = double.Parse(xmlReader.Value);
//                                break;
//                        }
//                    }
//                    else
//                    {
//                        if (xmlReader.NodeType == XmlNodeType.EndElement)
//                        {
//                            if (xmlReader.Name == m_XMLName) break;
//                        }
//                    }
//                }

//                //Logger.WriteLog(LOG.SYS, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
//                return true;
//            }
//            catch (Exception Desc)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
//                //Logger.WriteLog(LOG.ERR, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
//                return false;
//            }
//        }

//        public bool SaveConfigByXML(XmlWriter xmlWriter)
//        {
//            xmlWriter.WriteStartElement("Parameter");
//            xmlWriter.WriteElementString("ExposureTime", ExposureTime.ToString());
//            xmlWriter.WriteElementString("Gain", Gain.ToString());
//            xmlWriter.WriteElementString("Threshold", Threshold.ToString());
//            //xmlWriter.WriteElementString("ROI", string.Format("{0},{1},{2},{3}", ROI.X, ROI.Y, ROI.Width, ROI.Height));
//            xmlWriter.WriteElementString("PixelPermm", PixelPermm.ToString());
//            xmlWriter.WriteEndElement();
//            return true;
//        }

//        #endregion File Manager
//    }
//}