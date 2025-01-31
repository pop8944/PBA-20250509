//#if HIKVISION

using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Camera
    {
        List<CCameraInfo> m_ltDeviceList = new List<CCameraInfo>();

        public bool IsOpen;
        public string Name { get; set; }
        public int CamIndex { get; set; }

        private CCamera m_MyCamera = null;
        public bool ViewModeCross = false;
        Thread m_hReceiveThread = null;

        private static Object BufForDriverLock = new Object();
        private CImage m_pcImgForDriver;
        private CFrameSpecInfo m_pcImgSpecInfo;
        private Bitmap m_pcBitmap = null;
        private PixelFormat m_enBitmapPixelFormat = PixelFormat.DontCare;

        //public Bitmap[] GrabBuffer { get; set; } = new Bitmap[5] { null, null, null, null, null };
        public Camera(int idx)
        {
            this.Name = $"CAMERA_{idx}";
            this.CamIndex = idx;
        }



        private UInt32 m_nBufSizeForSaveImage = 0;
        private IntPtr m_BufForSaveImage;
        private UInt32 m_nBufSizeForDriver = 0;
        private IntPtr m_BufForDriver;

        public Bitmap ImageGrab;

        #region Event Register        

        public CogDisplay Display_Main = null;
        public CogDisplay Display_Teaching = null;

        public event EventHandler<EventArgs> EventChangedConnection;

        public ManualResetEvent IsGrabDone = new ManualResetEvent(false);

        #endregion


        public bool IsLive { get; set; } = false;

        public void Close()
        {
            try
            {
                if (m_bGrabbing)
                {
                    StopAcquisition();
                }

                if (IsOpen)
                {
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public bool Init(int idx, DeviceInfo_Camera deviceInfo)
        {
            try
            {
                this.CamIndex = idx;

                m_ltDeviceList.Clear();
                int nRet = MvCamCtrl.NET.CSystem.EnumDevices(MvCamCtrl.NET.CSystem.MV_GIGE_DEVICE | MvCamCtrl.NET.CSystem.MV_USB_DEVICE, ref m_ltDeviceList);

                // ch:获取选择的设备信息 | en:Get selected device information
                CCameraInfo device = null;

                for (int i = 0; i < m_ltDeviceList.Count; i++)
                {
                    device = m_ltDeviceList[i];

                    m_MyCamera = new CCamera();

                    if (m_MyCamera == null) return false;

                    nRet = m_MyCamera.CreateHandle(ref device);
                    if (CErrorDefine.MV_OK != nRet)
                    {
                        continue;
                    }

                    nRet = m_MyCamera.OpenDevice();
                    if (CErrorDefine.MV_OK != nRet)
                    {
                        m_MyCamera.DestroyHandle();
                        continue;
                    }

                    // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
                    if (device.nTLayerType == MvCamCtrl.NET.CSystem.MV_GIGE_DEVICE)
                    {
                        int nPacketSize = m_MyCamera.GIGE_GetOptimalPacketSize();
                        if (nPacketSize > 0)
                        {
                            nRet = m_MyCamera.SetIntValue("GevSCPSPacketSize", (uint)nPacketSize);
                            if (nRet != CErrorDefine.MV_OK)
                            {

                            }
                        }

                        CGigECameraInfo gigeInfo = (CGigECameraInfo)device;
                        if (deviceInfo.SerialNumber == gigeInfo.chSerialNumber)
                        {
                            IsOpen = true;
                            break;
                        }
                    }
                }

                Thread.Sleep(100);

                if (IsOpen)
                {
                    SetGain(deviceInfo.DefaultGain);
                    SetExposure((float)deviceInfo.DefaultExposureTime);
                    SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);
                    StartAcquisition();
                }

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        public bool Connect(string serialNumber)
        {
            try
            {
                IsOpen = false;

                List<CCameraInfo> devices = new List<CCameraInfo>();
                int ret = MvCamCtrl.NET.CSystem.EnumDevices(MvCamCtrl.NET.CSystem.MV_GIGE_DEVICE | MvCamCtrl.NET.CSystem.MV_USB_DEVICE, ref devices);

                if (0 != ret)
                {
                    CLogger.Add(LOG.ABNORMAL, "Can't find the Camera");
                    return false;
                }

                for (int i = 0; i < devices.Count; i++)
                {
                    if (devices[i].nTLayerType == MvCamCtrl.NET.CSystem.MV_GIGE_DEVICE)
                    {
                        CGigECameraInfo gigeInfo = (CGigECameraInfo)devices[i];
                        CCameraInfo cameraInfo = devices[i];

                        if (serialNumber == gigeInfo.chSerialNumber)
                        {
                            m_MyCamera = new CCamera();

                            ret = m_MyCamera.CreateHandle(ref cameraInfo);
                            ret = m_MyCamera.OpenDevice();

                            if (ret != CErrorDefine.MV_OK)
                            {
                                CLogger.Add(LOG.ABNORMAL, $"Camera OpenDevice Failed");
                                m_MyCamera.DestroyHandle();
                                return false;
                            }
                            else
                            {
                                int nPacketSize = m_MyCamera.GIGE_GetOptimalPacketSize();

                                if (nPacketSize > 0)
                                {
                                    ret = m_MyCamera.SetIntValue("GevSCPSPacketSize", (uint)nPacketSize);
                                    if (ret != CErrorDefine.MV_OK)
                                    {
                                        CLogger.Add(LOG.ABNORMAL, $"Camera PakcetSize Set Failed");
                                        return false;
                                    }

                                    SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);

                                    IsOpen = true;
                                    break;
                                }
                                else
                                {
                                    CLogger.Add(LOG.ABNORMAL, $"Camera PakcetSize == 0");
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                Disconnect();

                return false;
            }

            return true;
        }

        public bool Disconnect()
        {
            try
            {
                if (m_MyCamera != null)
                {
                    m_MyCamera.StopGrabbing();
                    m_MyCamera.CloseDevice();
                    m_MyCamera.DestroyHandle();
                    m_MyCamera = null;

                    GC.Collect();
                }

                if (m_bGrabbing == true)
                {
                    m_bGrabbing = false;
                    m_hReceiveThread = null;
                }

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        private CPropertyCamera.TRIGGER_MODE_TYPE m_MODE = CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW;

        private bool IsNoDisplay = false;
        public bool Grab(bool bHw = false, bool isNoDisplay = false)
        {
            try
            {
                IsNoDisplay = isNoDisplay;
                IsGrabDone.Reset();
                ImageGrab = null;

                if (bHw)
                {
                    if (m_MODE != CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW) SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW);
                }
                else
                {
                    if (m_MODE != CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW) SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);
                }

                int nRet = m_MyCamera.SetCommandValue("TriggerSoftware");
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                Disconnect();
                return false;
            }
            return true;
        }


        public bool Live(bool bEnable)
        {
            try
            {
                IsLive = bEnable;

                if (IsLive == true)
                    SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.OFF);
                else
                    SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                Disconnect();
                return false;
            }

            return true;
        }
        public void SetExposure(float value)
        {
            try
            {
                if (m_MyCamera == null) return;
                int nRet = m_MyCamera.SetFloatValue("ExposureTime", value);
                CLogger.Add(LOG.DEVICE, $"Camera #{CamIndex} Exposure Set ==> {value}");
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        public void SetGain(float value)
        {
            try
            {
                if (m_MyCamera == null) return;
                int nRet = m_MyCamera.SetFloatValue("Gain", value);
                CLogger.Add(LOG.DEVICE, $"Camera #{CamIndex} Gain Set ==> {value}");
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        bool m_bGrabbing = false;
        public void StartAcquisition()
        {
            try
            {
                // ch:前置配置 | en:pre-operation
                int nRet = NecessaryOperBeforeGrab();
                if (CErrorDefine.MV_OK != nRet)
                {
                    return;
                }

                // ch:标志位置位true | en:Set position bit true
                m_bGrabbing = true;
                //m_bRenderByBitmap = true;
                m_hReceiveThread = new Thread(ReceiveThreadProcess);
                m_hReceiveThread.Start();

                // ch:开始采集 | en:Start Grabbing
                nRet = m_MyCamera.StartGrabbing();
                if (CErrorDefine.MV_OK != nRet)
                {
                    m_bGrabbing = false;
                    m_hReceiveThread.Join();
                    return;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private Int32 NecessaryOperBeforeGrab()
        {
            try
            {
                CIntValue pcWidth = new CIntValue();
                int nRet = m_MyCamera.GetIntValue("Width", ref pcWidth);
                if (CErrorDefine.MV_OK != nRet)
                {
                    MessageBox.Show("Get Width Info Fail!");
                    return nRet;
                }

                CIntValue pcHeight = new CIntValue();
                nRet = m_MyCamera.GetIntValue("Height", ref pcHeight);
                if (CErrorDefine.MV_OK != nRet)
                {
                    MessageBox.Show("Get Height Info Fail!");
                    return nRet;
                }

                CEnumValue pcPixelFormat = new CEnumValue();
                nRet = m_MyCamera.GetEnumValue("PixelFormat", ref pcPixelFormat);
                if (CErrorDefine.MV_OK != nRet)
                {
                    MessageBox.Show("Get Pixel Format Fail!");
                    return nRet;
                }

                if ((Int32)MvGvspPixelType.PixelType_Gvsp_Undefined == (Int32)pcPixelFormat.CurValue)
                {
                    MessageBox.Show("Unknown Pixel Format!");
                    return CErrorDefine.MV_E_UNKNOW;
                }
                else if (IsMono((MvGvspPixelType)pcPixelFormat.CurValue))
                {
                    m_enBitmapPixelFormat = PixelFormat.Format8bppIndexed;
                }
                else
                {
                    m_enBitmapPixelFormat = PixelFormat.Format24bppRgb;
                }

                if (null != m_pcBitmap)
                {
                    m_pcBitmap.Dispose();
                    m_pcBitmap = null;
                }

                m_pcBitmap = new Bitmap((Int32)pcWidth.CurValue, (Int32)pcHeight.CurValue, m_enBitmapPixelFormat);

                if (PixelFormat.Format8bppIndexed == m_enBitmapPixelFormat)
                {
                    ColorPalette palette = m_pcBitmap.Palette;
                    for (int i = 0; i < palette.Entries.Length; i++)
                    {
                        palette.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    m_pcBitmap.Palette = palette;
                }

                return CErrorDefine.MV_OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -2147483644;
            }
        }

        private Boolean IsMono(MvGvspPixelType enPixelType)
        {
            try
            {
                switch (enPixelType)
                {
                    case MvGvspPixelType.PixelType_Gvsp_Mono1p:
                    case MvGvspPixelType.PixelType_Gvsp_Mono2p:
                    case MvGvspPixelType.PixelType_Gvsp_Mono4p:
                    case MvGvspPixelType.PixelType_Gvsp_Mono8:
                    case MvGvspPixelType.PixelType_Gvsp_Mono8_Signed:
                    case MvGvspPixelType.PixelType_Gvsp_Mono10:
                    case MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                    case MvGvspPixelType.PixelType_Gvsp_Mono12:
                    case MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    case MvGvspPixelType.PixelType_Gvsp_Mono14:
                    case MvGvspPixelType.PixelType_Gvsp_Mono16:
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }


        public void StopAcquisition()
        {
            try
            {
                m_bGrabbing = false;
                if (m_hReceiveThread == null) return;
                bool bRet = m_hReceiveThread.Join(1000);

                int ret = m_MyCamera.StopGrabbing();
                if (CErrorDefine.MV_OK == ret)
                {
                    if (m_hReceiveThread != null && m_hReceiveThread.IsAlive == true)
                    {
                        m_hReceiveThread.Join(1000);
                    }

                    return;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        UInt32 nSaveImageNeedSize = 0;
        public Cognex.VisionPro.ICogImage ImageCogGrab;
        public void ReceiveThreadProcess()
        {
            try
            {
                //CFrameout pcFrameInfo = new CFrameout();
                //CDisplayFrameInfo pcDisplayInfo = new CDisplayFrameInfo();
                //CPixelConvertParam pcConvertParam = new CPixelConvertParam();
                int ret = CErrorDefine.MV_OK;

                while (Global.Instance.System.REQ_SYSTEM_CLOSE == false)
                {
                    CFrameout pcFrameInfo = new CFrameout();
                    CDisplayFrameInfo pcDisplayInfo = new CDisplayFrameInfo();
                    CPixelConvertParam pcConvertParam = new CPixelConvertParam();

                    ret = m_MyCamera.GetImageBuffer(ref pcFrameInfo, 1000);
                    if (ret == CErrorDefine.MV_OK)
                    {
                        lock (BufForDriverLock)
                        {
                            m_pcImgForDriver = pcFrameInfo.Image.Clone() as CImage;
                            m_pcImgSpecInfo = pcFrameInfo.FrameSpec;
                        }

                        using (Bitmap pcBitmap = m_MyCamera.ImageToBitmap(ref pcFrameInfo))
                        {
                            ImageGrab = (Bitmap)pcBitmap.Clone();

                            if (Global.Instance.System.Mode != CSystem.MODE.AUTO)
                            {
                                if (Display_Teaching != null) Display_Teaching.Image = new CogImage24PlanarColor(ImageGrab);
                                //EventGrabEnd?.Invoke(this, new ImageGrabEventArgs(ImageGrab, CamIndex));                           
                            }

                        }

                        Stopwatch freeCheck = Stopwatch.StartNew();
                        m_MyCamera.FreeImageBuffer(ref pcFrameInfo);
                        freeCheck.Stop();
                        IsGrabDone.Set();
                    }
                    else
                    {
                        Thread.Sleep(5);
                    }

                    //ret = m_MyCamera.GetImageBuffer(ref pcFrameInfo, 1000);

                    //if (ret == CErrorDefine.MV_OK)
                    //{
                    //    lock (BufForDriverLock)
                    //    {
                    //        m_pcImgForDriver = pcFrameInfo.Image.Clone() as CImage;
                    //        m_pcImgSpecInfo = pcFrameInfo.FrameSpec;

                    //        pcConvertParam.InImage = pcFrameInfo.Image;
                    //        if (PixelFormat.Format8bppIndexed == m_pcBitmap.PixelFormat)
                    //        {
                    //            pcConvertParam.OutImage.PixelType = MvGvspPixelType.PixelType_Gvsp_Mono8;
                    //            m_MyCamera.ConvertPixelType(ref pcConvertParam);
                    //        }
                    //        else
                    //        {
                    //            pcConvertParam.OutImage.PixelType = MvGvspPixelType.PixelType_Gvsp_BGR8_Packed;
                    //            m_MyCamera.ConvertPixelType(ref pcConvertParam);
                    //        }

                    //        //Save Bitmap Data
                    //        BitmapData m_pcBitmapData = m_pcBitmap.LockBits(new Rectangle(0, 0, pcConvertParam.InImage.Width, pcConvertParam.InImage.Height), ImageLockMode.ReadWrite, m_pcBitmap.PixelFormat);
                    //        Marshal.Copy(pcConvertParam.OutImage.ImageData, 0, m_pcBitmapData.Scan0, (Int32)pcConvertParam.OutImage.ImageData.Length);
                    //        m_pcBitmap.UnlockBits(m_pcBitmapData);
                    //    }

                    //    ImageGrab = (Bitmap)m_pcBitmap.Clone();
                    //    //EventGrabEnd?.Invoke(this, new ImageGrabEventArgs(ImageGrab, CamIndex));

                    //    m_MyCamera.FreeImageBuffer(ref pcFrameInfo);
                    //    IsGrabDone.Set();
                    //}
                    //else
                    //{
                    //    Thread.Sleep(5);
                    //}
                }

                return;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }


        public bool SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE type)
        {
            try
            {
                if (m_MyCamera == null) return false;

                m_MODE = type;
                int nRet = -1;

                //StopAcquisition();

                switch (type)
                {
                    case CPropertyCamera.TRIGGER_MODE_TYPE.OFF: // LIVE
                        nRet = m_MyCamera.SetEnumValueByString("TriggerMode", "Off");
                        nRet = m_MyCamera.SetEnumValueByString("AcquisitionMode", "Continuous");
                        break;
                    case CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW: // SOFTWARE Trigger
                        nRet = m_MyCamera.SetEnumValueByString("TriggerMode", "On");
                        nRet = m_MyCamera.SetEnumValueByString("AcquisitionMode", "Continuous");
                        nRet = m_MyCamera.SetEnumValueByString("TriggerSource", "Software");
                        break;
                    case CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW:// HARDWARE Trigger
                        nRet = m_MyCamera.SetEnumValueByString("TriggerMode", "On");
                        nRet = m_MyCamera.SetEnumValueByString("AcquisitionMode", "Continuous");
                        nRet = m_MyCamera.SetEnumValueByString("TriggerSource", "Line0");
                        break;
                }

                if (nRet != 0)
                {
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

            return true;
        }

        private void OnDisconnected()
        {
            try
            {
                if (EventChangedConnection != null)
                {
                    EventChangedConnection(this, null);
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return;
            }
        }
    }
}

//#endif
////#if HIKVISION

//using System;
//using System.Net;
//using System.Reflection;
//using System.Runtime.InteropServices;
//using System.Threading;
//using System.Drawing;
//using System.Drawing.Imaging;
//using Cognex.VisionPro;
//using ADOX;
//using CodeMeter;
//using System.Diagnostics;

//using MvCamCtrl.NET;
//using MvCamCtrl.NET.CameraParams;

//using CSystem = MvCamCtrl.NET.CSystem;
//using System.Collections.Generic;
//using System.Windows.Media.Media3D;
//using System.Windows.Forms;
//namespace IntelligentFactory
//{
//    public class Camera
//    {
//        public bool IsOpen;
//        public string Name { get; set; }
//        public int CamIndex { get; set; }

//        private CCamera m_MyCamera = null;
//        public bool ViewModeCross = false;
//        Thread m_hReceiveThread = null;

//        private static Object BufForDriverLock = new Object();
//        private CImage m_pcImgForDriver;
//        private CFrameSpecInfo m_pcImgSpecInfo;
//        private Bitmap m_pcBitmap = null;
//        private PixelFormat m_enBitmapPixelFormat = PixelFormat.DontCare;

//        public Bitmap[] GrabBuffer { get; set; } = new Bitmap[5] { null, null, null, null, null };
//        public Camera(int idx)
//        {
//            this.Name = $"CAMERA_{idx}";
//            this.CamIndex = idx;
//        }

//        bool _isStart = false;

//        private UInt32 m_nBufSizeForSaveImage = 0;
//        private IntPtr m_BufForSaveImage;
//        private UInt32 m_nBufSizeForDriver = 0;
//        private IntPtr m_BufForDriver;

//        public Bitmap ImageGrab;

//        #region Event Register        
//        //public event EventHandler<ImageGrabEventArgs> EventGrabEnd;
//        public event EventHandler<EventArgs> EventChangedConnection;

//        public ManualResetEvent IsGrabDone = new ManualResetEvent(false);

//        #endregion


//        public bool IsLive { get; set; } = false;

//        public void Close()
//        {
//            try
//            {
//                if (_isStart)
//                {
//                    StopAcquisition();
//                }

//                if (IsOpen)
//                {
//                    Disconnect();
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        public bool Init(int idx, DeviceInfo_Camera deviceInfo)
//        {
//            try
//            {
//                this.CamIndex = idx;

//                Close();
//                Connect(deviceInfo.SerialNumber);

//                GC.Collect();
//                Thread.Sleep(1);

//                if (IsOpen == false)
//                {
//                    for (int i = 0; i < 10; i++)
//                    {
//                        Connect(deviceInfo.SerialNumber);
//                        Thread.Sleep(10);
//                        if (IsOpen)
//                        {
//                            break;
//                        }
//                    }

//                    if (!IsOpen)
//                    {
//                        return false;
//                    }
//                }
//                else
//                {
//                    SetGain(deviceInfo.DefaultGain);
//                    SetExposure((float)deviceInfo.DefaultExposureTime);
//                    StartAcquisition();
//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                return false;
//            }
//        }

//        public bool Connect(string serialNumber)
//        {
//            try
//            {
//                IsOpen = false;

//                List<CCameraInfo> devices = new List<CCameraInfo>();
//                int ret = MvCamCtrl.NET.CSystem.EnumDevices(MvCamCtrl.NET.CSystem.MV_GIGE_DEVICE | MvCamCtrl.NET.CSystem.MV_USB_DEVICE, ref devices);

//                if (0 != ret)
//                {
//                    CLogger.Add(LOG.ABNORMAL, "Can't find the Camera");
//                    return false;
//                }

//                for (int i = 0; i < devices.Count; i++)
//                {
//                    if (devices[i].nTLayerType == MvCamCtrl.NET.CSystem.MV_GIGE_DEVICE)
//                    {
//                        CGigECameraInfo gigeInfo = (CGigECameraInfo)devices[i];
//                        CCameraInfo cameraInfo = devices[i];

//                        if (serialNumber == gigeInfo.chSerialNumber)
//                        {
//                            m_MyCamera = new CCamera();

//                            ret = m_MyCamera.CreateHandle(ref cameraInfo);
//                            ret = m_MyCamera.OpenDevice();

//                            if (ret != CErrorDefine.MV_OK)
//                            {
//                                CLogger.Add(LOG.ABNORMAL, $"Camera OpenDevice Failed");
//                                m_MyCamera.DestroyHandle();
//                                return false;
//                            }
//                            else
//                            {
//                                int nPacketSize = m_MyCamera.GIGE_GetOptimalPacketSize();

//                                if (nPacketSize > 0)
//                                {
//                                    ret = m_MyCamera.SetIntValue("GevSCPSPacketSize", (uint)nPacketSize);
//                                    if (ret != CErrorDefine.MV_OK)
//                                    {
//                                        CLogger.Add(LOG.ABNORMAL, $"Camera PakcetSize Set Failed");
//                                        return false;
//                                    }

//                                    SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);

//                                    IsOpen = true;
//                                    break;
//                                }
//                                else
//                                {
//                                    CLogger.Add(LOG.ABNORMAL, $"Camera PakcetSize == 0");
//                                    return false;
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                Disconnect();

//                return false;
//            }

//            return true;
//        }

//        public bool Disconnect()
//        {
//            try
//            {
//                if (m_MyCamera != null)
//                {
//                    m_MyCamera.StopGrabbing();
//                    m_MyCamera.CloseDevice();
//                    m_MyCamera.DestroyHandle();
//                    m_MyCamera = null;

//                    GC.Collect();
//                }

//                if (_isStart == true)
//                {
//                    _isStart = false;
//                    m_hReceiveThread = null;
//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                return false;
//            }
//        }

//        private CPropertyCamera.TRIGGER_MODE_TYPE m_MODE = CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW;

//        private bool IsNoDisplay = false;
//        public bool Grab(bool bHw = false, bool isNoDisplay = false)
//        {
//            try
//            {
//                IsNoDisplay = isNoDisplay;
//                IsGrabDone.Reset();
//                ImageGrab = null;

//                if (bHw)
//                {
//                    if (m_MODE != CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW) SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW);
//                }
//                else
//                {
//                    if (m_MODE != CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW) SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);
//                }

//                int nRet = m_MyCamera.SetCommandValue("TriggerSoftware");
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                Disconnect();
//                return false;
//            }
//            return true;
//        }


//        public bool Live(bool bEnable)
//        {
//            try
//            {
//                IsLive = bEnable;

//                if (IsLive == true)
//                    SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.OFF);
//                else
//                    SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);

//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                Disconnect();
//                return false;
//            }

//            return true;
//        }
//        public void SetExposure(float value)
//        {
//            try
//            {
//                if (m_MyCamera == null) return;
//                int nRet = m_MyCamera.SetFloatValue("ExposureTime", value);
//                CLogger.Add(LOG.DEVICE, $"Camera #{CamIndex} Exposure Set ==> {value}");
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }
//        public void SetGain(float value)
//        {
//            try
//            {
//                if (m_MyCamera == null) return;
//                int nRet = m_MyCamera.SetFloatValue("Gain", value);
//                CLogger.Add(LOG.DEVICE, $"Camera #{CamIndex} Gain Set ==> {value}");
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        public void StartAcquisition()
//        {
//            try
//            {
//                _isStart = true;

//                NecessaryOperBeforeGrab();

//                m_hReceiveThread = new Thread(ThreadReceiveBuffer);
//                //m_hReceiveThread.IsBackground = true;
//                m_hReceiveThread.Start();

//                // [2024-01-04] StartGrabbing 중복 제거
//                //m_MyCamera.StartGrabbing();

//                int ret = m_MyCamera.StartGrabbing();
//                if (CErrorDefine.MV_OK != ret)
//                {
//                    if (m_hReceiveThread != null && m_hReceiveThread.IsAlive == true)
//                    {
//                        m_hReceiveThread.Join(1000);
//                    }

//                    CLogger.Add(LOG.ABNORMAL, $"StartGrabbing Failed");
//                    return;
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        private Int32 NecessaryOperBeforeGrab()
//        {
//            try
//            {
//                CIntValue pcWidth = new CIntValue();
//                int nRet = m_MyCamera.GetIntValue("Width", ref pcWidth);
//                if (CErrorDefine.MV_OK != nRet)
//                {
//                    MessageBox.Show("Get Width Info Fail!");
//                    return nRet;
//                }

//                CIntValue pcHeight = new CIntValue();
//                nRet = m_MyCamera.GetIntValue("Height", ref pcHeight);
//                if (CErrorDefine.MV_OK != nRet)
//                {
//                    MessageBox.Show("Get Height Info Fail!");
//                    return nRet;
//                }

//                CEnumValue pcPixelFormat = new CEnumValue();
//                nRet = m_MyCamera.GetEnumValue("PixelFormat", ref pcPixelFormat);
//                if (CErrorDefine.MV_OK != nRet)
//                {
//                    MessageBox.Show("Get Pixel Format Fail!");
//                    return nRet;
//                }

//                if ((Int32)MvGvspPixelType.PixelType_Gvsp_Undefined == (Int32)pcPixelFormat.CurValue)
//                {
//                    MessageBox.Show("Unknown Pixel Format!");
//                    return CErrorDefine.MV_E_UNKNOW;
//                }
//                else if (IsMono((MvGvspPixelType)pcPixelFormat.CurValue))
//                {
//                    m_enBitmapPixelFormat = PixelFormat.Format8bppIndexed;
//                }
//                else
//                {
//                    m_enBitmapPixelFormat = PixelFormat.Format24bppRgb;
//                }

//                if (null != m_pcBitmap)
//                {
//                    m_pcBitmap.Dispose();
//                    m_pcBitmap = null;
//                }

//                m_pcBitmap = new Bitmap((Int32)pcWidth.CurValue, (Int32)pcHeight.CurValue, m_enBitmapPixelFormat);

//                if (PixelFormat.Format8bppIndexed == m_enBitmapPixelFormat)
//                {
//                    ColorPalette palette = m_pcBitmap.Palette;
//                    for (int i = 0; i < palette.Entries.Length; i++)
//                    {
//                        palette.Entries[i] = Color.FromArgb(i, i, i);
//                    }
//                    m_pcBitmap.Palette = palette;
//                }

//                return CErrorDefine.MV_OK;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.ToString());
//                return -2147483644;
//            }
//        }

//        private Boolean IsMono(MvGvspPixelType enPixelType)
//        {
//            try
//            {
//                switch (enPixelType)
//                {
//                    case MvGvspPixelType.PixelType_Gvsp_Mono1p:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono2p:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono4p:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono8:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono8_Signed:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono10:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono12:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono14:
//                    case MvGvspPixelType.PixelType_Gvsp_Mono16:
//                        return true;
//                    default:
//                        return false;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.ToString());
//                return false;
//            }
//        }


//        public void StopAcquisition()
//        {
//            try
//            {
//                _isStart = false;
//                if (m_hReceiveThread == null) return;
//                bool bRet = m_hReceiveThread.Join(1000);

//                int ret = m_MyCamera.StopGrabbing();
//                if (CErrorDefine.MV_OK == ret)
//                {
//                    if (m_hReceiveThread != null && m_hReceiveThread.IsAlive == true)
//                    {
//                        m_hReceiveThread.Join(1000);
//                    }

//                    return;
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        UInt32 nSaveImageNeedSize = 0;
//        public Cognex.VisionPro.ICogImage ImageCogGrab;
//        public void ThreadReceiveBuffer()
//        {
//            try
//            {
//                //CFrameout pcFrameInfo = new CFrameout();
//                //CDisplayFrameInfo pcDisplayInfo = new CDisplayFrameInfo();
//                //CPixelConvertParam pcConvertParam = new CPixelConvertParam();
//                int ret = CErrorDefine.MV_OK;

//                while (Global.Instance.System.REQ_SYSTEM_CLOSE == false)
//                {
//                    CFrameout pcFrameInfo = new CFrameout();
//                    CDisplayFrameInfo pcDisplayInfo = new CDisplayFrameInfo();
//                    CPixelConvertParam pcConvertParam = new CPixelConvertParam();

//                    ret = m_MyCamera.GetImageBuffer(ref pcFrameInfo, 1000);
//                    if (ret == CErrorDefine.MV_OK)
//                    {
//                        lock (BufForDriverLock)
//                        {
//                            m_pcImgForDriver = pcFrameInfo.Image.Clone() as CImage;
//                            m_pcImgSpecInfo = pcFrameInfo.FrameSpec;
//                        }

//                        using (Bitmap pcBitmap = m_MyCamera.ImageToBitmap(ref pcFrameInfo))
//                        {
//                            ImageGrab = (Bitmap)pcBitmap.Clone();
//                            //EventGrabEnd?.Invoke(this, new ImageGrabEventArgs(ImageGrab, CamIndex));                           
//                        }

//                        Stopwatch freeCheck = Stopwatch.StartNew();
//                        m_MyCamera.FreeImageBuffer(ref pcFrameInfo);
//                        freeCheck.Stop();
//                        IsGrabDone.Set();
//                    }
//                    else
//                    {
//                        Thread.Sleep(5);
//                    }

//                    //ret = m_MyCamera.GetImageBuffer(ref pcFrameInfo, 1000);

//                    //if (ret == CErrorDefine.MV_OK)
//                    //{
//                    //    lock (BufForDriverLock)
//                    //    {
//                    //        m_pcImgForDriver = pcFrameInfo.Image.Clone() as CImage;
//                    //        m_pcImgSpecInfo = pcFrameInfo.FrameSpec;

//                    //        pcConvertParam.InImage = pcFrameInfo.Image;
//                    //        if (PixelFormat.Format8bppIndexed == m_pcBitmap.PixelFormat)
//                    //        {
//                    //            pcConvertParam.OutImage.PixelType = MvGvspPixelType.PixelType_Gvsp_Mono8;
//                    //            m_MyCamera.ConvertPixelType(ref pcConvertParam);
//                    //        }
//                    //        else
//                    //        {
//                    //            pcConvertParam.OutImage.PixelType = MvGvspPixelType.PixelType_Gvsp_BGR8_Packed;
//                    //            m_MyCamera.ConvertPixelType(ref pcConvertParam);
//                    //        }

//                    //        //Save Bitmap Data
//                    //        BitmapData m_pcBitmapData = m_pcBitmap.LockBits(new Rectangle(0, 0, pcConvertParam.InImage.Width, pcConvertParam.InImage.Height), ImageLockMode.ReadWrite, m_pcBitmap.PixelFormat);
//                    //        Marshal.Copy(pcConvertParam.OutImage.ImageData, 0, m_pcBitmapData.Scan0, (Int32)pcConvertParam.OutImage.ImageData.Length);
//                    //        m_pcBitmap.UnlockBits(m_pcBitmapData);
//                    //    }

//                    //    ImageGrab = (Bitmap)m_pcBitmap.Clone();
//                    //    //EventGrabEnd?.Invoke(this, new ImageGrabEventArgs(ImageGrab, CamIndex));

//                    //    m_MyCamera.FreeImageBuffer(ref pcFrameInfo);
//                    //    IsGrabDone.Set();
//                    //}
//                    //else
//                    //{
//                    //    Thread.Sleep(5);
//                    //}
//                }

//                return;
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }


//        public bool SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE type)
//        {
//            try
//            {
//                if (m_MyCamera == null) return false;

//                m_MODE = type;
//                int nRet = -1;

//                StopAcquisition();

//                switch (type)
//                {
//                    case CPropertyCamera.TRIGGER_MODE_TYPE.OFF: // LIVE
//                        nRet = m_MyCamera.SetEnumValueByString("TriggerMode", "Off");
//                        nRet = m_MyCamera.SetEnumValueByString("AcquisitionMode", "Continuous");
//                        break;
//                    case CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW: // SOFTWARE Trigger
//                        nRet = m_MyCamera.SetEnumValueByString("TriggerMode", "On");
//                        nRet = m_MyCamera.SetEnumValueByString("AcquisitionMode", "Continuous");
//                        nRet = m_MyCamera.SetEnumValueByString("TriggerSource", "Software");
//                        break;
//                    case CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW:// HARDWARE Trigger
//                        nRet = m_MyCamera.SetEnumValueByString("TriggerMode", "On");
//                        nRet = m_MyCamera.SetEnumValueByString("AcquisitionMode", "Continuous");
//                        nRet = m_MyCamera.SetEnumValueByString("TriggerSource", "Line0");
//                        break;
//                }

//                StartAcquisition();

//                if (nRet != 0)
//                {
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }

//            return true;
//        }

//        private void OnDisconnected()
//        {
//            try
//            {
//                if (EventChangedConnection != null)
//                {
//                    EventChangedConnection(this, null);
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                return;
//            }
//        }
//    }
//}

////#endif