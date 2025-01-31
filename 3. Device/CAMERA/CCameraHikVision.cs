////#if HIKVISION
//using Cognex.VisionPro;
//using Cognex.VisionPro.ImageProcessing;
//using Microsoft.Office.Interop.Excel;
//using MvCamCtrl.NET;
//using OpenCvSharp.Dnn;
//using System;
//using System.Collections.Concurrent;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.IO.Packaging;
//using System.Net;
//using System.Reflection;
//using System.Runtime.InteropServices;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Media;

////using IntelligentFactory.Library;

//namespace IntelligentFactory
//{
//    public class CCameraHikVision
//    {
//        public CPropertyCamera Property { get; set; } = new CPropertyCamera("CAMERA");
//        private MyCamera m_MyCamera = null;
//        public MyCamera.MV_FRAME_OUT_INFO_EX m_stFrameInfo;
//        private MyCamera.MV_CC_DEVICE_INFO_LIST m_stDeviceList;
//        //private Thread m_hReceiveThread = null;
//        // grab img index
//        public int m_Grabindex = 0;
//        // Grab img max count
//        public int m_GrabimgMaxcnt = 0;
//        // grab img
//        public Cognex.VisionPro.ICogImage[] m_imageCogGrab;
//        // grab all flg
//        public bool m_GrabAll = false;

//        public static bool m_CAMType_Check = false;

//        public CCameraHikVision(int nIndex)
//        {
//            Property.NAME = $"CAMERA_{nIndex}";
//            Property.INDEX = nIndex;
//            DeviceListAcq();

//            // 정상적으로 연결되지 않을시...재연결 시도 부분 추가.
//            if (Open())
//            {
//                CLogger.Add(LOG.DEVICE, "Camera Connected");

//                SetExposure(Property.EXPOSURETIME_US);
//                SetGain(Property.GAIN);
//                //Thread.Sleep(200);
//                StartAcquisition();
//                // 그랩 맥스 카운트를 한번만 생서되도록함...

//                CLogger.Add(LOG.DEVICE, $"CAMERA_{nIndex} CONNECTED");
//            }
//            // 재연결 시도...
//            else
//            {
//                //10회 시도..
//                for (int i = 0; i < 10; i++)
//                {
//                    Open();

//                    if (IsOpen)
//                    {
//                        break;
//                    }
//                }
//            }
//        }

//        public bool m_bGrabbing = false;
//        private static Object BufForDriverLock = new Object();
//        private UInt32 m_nBufSizeForSaveImage = 0;
//        private IntPtr m_BufForSaveImage;
//        private UInt32 m_nBufSizeForDriver = 0;
//        private IntPtr m_BufForDriver;

//        public Bitmap ImageGrab;

//        public bool ViewModeCross
//        {
//            get;
//            set;
//        }

//        public Cognex.VisionPro.Display.CogDisplay Display
//        {
//            get;
//            set;
//        }

//        private object lockObject = new object();

//        private bool m_bIsOpen = false;

//        public bool IsOpen
//        {
//            get
//            {
//                return m_bIsOpen;
//            }
//            set { m_bIsOpen = value; }
//        }

//        public bool IsLive { get; set; } = false;
//        private string m_strGateWay = "1";

//        public string GateWay
//        {
//            get { return m_strGateWay; }
//            set { m_strGateWay = value; }
//        }

//        private uint m_uTriggerMode = (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON;

//        public uint TriggerMode
//        {
//            get { return m_uTriggerMode; }
//            set { m_uTriggerMode = value; }
//        }

//        private float m_fLightBalance = 0.0f;

//        public float LightBalance
//        {
//            get { return m_fLightBalance; }
//            set { m_fLightBalance = value; }
//        }

//        public void Close()
//        {
//            try
//            {
//                if (m_bGrabbing)
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

//        // 카메라 연결..
//        public bool Open()
//        {
//            Property.LoadConfig();

//            if (!Connect())
//            {
//                return false;
//            }

//            return true;
//        }

//        public void DeviceListAcq()
//        {
//            try
//            {
//                m_stDeviceList.nDeviceNum = 7;
//                int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_stDeviceList);
//                if ((int)MyCamera.MV_OK != nRet)
//                {
//                    return;
//                }

//                return;
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        public bool Connect()
//        {
//            try
//            {
//                IsOpen = false;
//                m_MyCamera = new MyCamera();
//                m_stDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();

//                int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_stDeviceList);
//                if (nRet != 0 || m_stDeviceList.nDeviceNum == 0)
//                {
//                    IsOpen = false;
//                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, "CAMERA DEVICE ERROR");
//                    return false;
//                }
//                MyCamera.MV_CC_DEVICE_INFO device = new MyCamera.MV_CC_DEVICE_INFO();
//                device.nTLayerType = MyCamera.MV_GIGE_DEVICE;

//                if (m_stDeviceList.pDeviceInfo[Property.INDEX] == IntPtr.Zero)
//                {
//                    return false;
//                }

//                device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[Property.INDEX], typeof(MyCamera.MV_CC_DEVICE_INFO));
//                MyCamera.MV_GIGE_DEVICE_INFO Info = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
//                for (int i = 0; i < Global.Instance.Device.CAMERA_COUNT; i++)
//                {
//                    device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
//                    Info = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

//                    Property.SERIAL_NUMBER = Info.chSerialNumber;
//                    string DefinedName = Info.chUserDefinedName;

//                    //bool FindCam = false;

//                    int CAM_INDEX = 0;
//                    switch (DefinedName)
//                    {
//                        case "CAM1":
//                            CAM_INDEX = 0;
//                            break;

//                        case "CAM2":
//                            CAM_INDEX = 1;
//                            break;

//                        case "CAM3":
//                            CAM_INDEX = 2;
//                            break;

//                        case "CAM4":
//                            CAM_INDEX = 3;
//                            break;

//                        case "CAM5":
//                            CAM_INDEX = 4;
//                            break;

//                        case "CAM6":
//                            CAM_INDEX = 5;
//                            break;

//                        case "CAM7":
//                            CAM_INDEX = 6;
//                            break;
//                    }

//                    if (CAM_INDEX == Property.INDEX)
//                    {
//                        break;
//                    }
//                }

//                //if (EventLicense != null)
//                //{
//                //    string strSpecinfo = Info.chManufacturerSpecificInfo.Substring(8, Info.chManufacturerSpecificInfo.Length - 9);
//                //    strSpecinfo = strSpecinfo.Replace(" ", "");
//                //    EventLicense(null, new StringEventArgs(strSpecinfo));
//                //}
//                nRet = m_MyCamera.MV_CC_CreateDevice_NET(ref device);
//                if (MyCamera.MV_OK != nRet)
//                {
//                    return false;
//                }
//                nRet = m_MyCamera.MV_CC_OpenDevice_NET();
//                if (MyCamera.MV_OK != nRet)
//                {
//                    m_MyCamera.MV_CC_DestroyDevice_NET();
//                    return false;
//                }

//                //2022-06-07 BGR8변환 소스적용
//                //uint enValue = (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed;
//                //nRet = m_MyCamera.MV_CC_SetEnumValue_NET("PixelFormat", enValue);
//                //여기까지
//                ////2022-06-07 BGR8변환 소스적용
//                // 칼라 이미지 인지 모노 이미지 인지 확인..
//                // 모노이미지 인지 체크...
//                //===============================================================
//                MyCamera.MVCC_ENUMVALUE _value = new MyCamera.MVCC_ENUMVALUE();
//                nRet = m_MyCamera.MV_CC_GetPixelFormat_NET(ref _value);

//                // 모노 카메라일경우...
//                if (IsMonoPixelFormat(_value.nCurValue))
//                {
//                    IF_Util.ShowMessageBox("CAM Check", "Not Color Camera!! Color Camera Change!!");
//                    m_CAMType_Check = false;
//                }
//                // 칼라 이미지 인지 체크..
//                else
//                {
//                    uint enValue = (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8;
//                    nRet = m_MyCamera.MV_CC_SetPixelFormat_NET(enValue);

//                    m_CAMType_Check = true;
//                }
//                //=================================================================
//                //uint enValue = (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8;
//                //nRet = m_MyCamera.MV_CC_SetEnumValue_NET("PixelFormat", enValue);
//                //여기까지

//                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
//                {
//                    int nPacketSize = m_MyCamera.MV_CC_GetOptimalPacketSize_NET();
//                    if (nPacketSize > 0)
//                    {
//                        nRet = m_MyCamera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
//                        if (nRet != MyCamera.MV_OK)
//                        {
//                        }
//                    }
//                }
//                SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);
//                //SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.OFF);
//                //SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);

//                IsOpen = true;
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                Disconnect();

//                return false;
//            }

//            return true;
//        }

//        public bool ConnectionCheck()
//        {
//            try
//            {
//                int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_stDeviceList);
//                if (nRet != 0 || m_stDeviceList.nDeviceNum == 0)
//                {
//                    //Logger.WriteLog(LOG.AbNormal, "[FAILED] {0}/{1}   Can't Find the Camrea", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
//                    return false;
//                }
//                return true;
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                return false;
//            }
//        }

//        public bool Disconnect()
//        {
//            try
//            {
//                if (m_MyCamera != null)
//                {
//                    m_MyCamera.MV_CC_StopGrabbing_NET();
//                    m_MyCamera.MV_CC_CloseDevice_NET();
//                    m_MyCamera.MV_CC_DestroyDevice_NET();
//                }

//                //m_stDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
//                //m_stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
//                //m_MyCamera = null;

//                if (m_bGrabbing == true)
//                {
//                    m_bGrabbing = false;
//                    //m_hReceiveThread = null;
//                }

//                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

//                return true;
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                return false;
//            }
//        }

//        private CPropertyCamera.TRIGGER_MODE_TYPE m_MODE = CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW;
//        public bool nTotalGrab = false;

//        public bool Grab(bool bHw = true)
//        {
//            try
//            {
//                nTotalGrab = true;

//                if (bHw)
//                {
//                    if (m_MODE != CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW) SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW);
//                }
//                else
//                {
//                    if (m_MODE != CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW) SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);
//                }

//                int nRet = m_MyCamera.MV_CC_SetCommandValue_NET("TriggerSoftware");
//                // 그랩 쓰레드 동작...
//                ThreadReceiveBuffer();          //  이미지 그랩 쓰레드 동작.

//                //CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
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
//                nTotalGrab = false;
//                IsLive = bEnable;

//                // 그랩 쓰레드 호출..
//                ThreadReceiveBuffer();          //  이미지 그랩 쓰레드 동작.

//                if (IsLive == true)
//                    SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.OFF);
//                else
//                    SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);

//                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//                Disconnect();
//                return false;
//            }

//            return true;
//        }

//        public void SetExposure(float fValue)
//        {
//            try
//            {
//                m_MyCamera.MV_CC_SetEnumValue_NET("ExposureAuto", (uint)fValue);
//                int nRet = m_MyCamera.MV_CC_SetFloatValue_NET("ExposureTime", fValue);
//                if (nRet != MyCamera.MV_OK)
//                {
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        public void SetGain(float fValue)
//        {
//            try
//            {
//                //m_MyCamera.MV_CC_SetEnumValue_NET("GainAuto", (uint)Gain);
//                int nRet = m_MyCamera.MV_CC_SetFloatValue_NET("Gain", fValue);
//                if (nRet != MyCamera.MV_OK)
//                {
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        public MyCamera.MVCC_FLOATVALUE GetGainValues()
//        {
//            MyCamera.MVCC_FLOATVALUE fValues = new MyCamera.MVCC_FLOATVALUE();
//            try
//            {
//                int nRet = m_MyCamera.MV_CC_GetFloatValue_NET("Gain", ref fValues);
//                if (nRet != MyCamera.MV_OK)
//                {
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//            return fValues;
//        }

//        public float GetGainMax()
//        {
//            float fGainMax = 0.0f;
//            try
//            {
//                MyCamera.MVCC_FLOATVALUE fValues = GetGainValues();
//                fGainMax = fValues.fMax;
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//            return fGainMax;
//        }

//        public void StartAcquisition()
//        {
//            try
//            {
//                //ThreadReceiveBuffer();          //  이미지 그랩 쓰레드 동작.
//                //m_hReceiveThread = new Thread(ThreadReceiveBuffer);
//                //m_hReceiveThread.Start();
//                m_stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
//                m_stFrameInfo.nFrameLen = 0;
//                m_stFrameInfo.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;
//                int nRet = m_MyCamera.MV_CC_StartGrabbing_NET();

//                if (MyCamera.MV_OK != nRet)
//                {
//                    m_bGrabbing = false;
//                    //m_hReceiveThread.Join();
//                    return;
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        public void StopAcquisition()
//        {
//            try
//            {
//                m_bGrabbing = false;
//                //bool bRet = m_hReceiveThread.Join(1000);
//                //if (bRet == true)
//                //{
//                //    string str = string.Empty;
//                //}
//                //else
//                //{
//                //    string str = string.Empty;
//                //}
//                int nRet = m_MyCamera.MV_CC_StopGrabbing_NET();
//                if (nRet != MyCamera.MV_OK)
//                {
//                    //Logger.WriteLog(LOG.ERR, "[FAILED] {0}/{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        public void SetGrabMaxCount(int maxcnt)
//        {
//            m_imageCogGrab = null;
//            m_GrabimgMaxcnt = maxcnt;
//            m_imageCogGrab = new ICogImage[m_GrabimgMaxcnt];
//        }

//        // Grab All
//        public void Grab_All(int _Grabmaxcnt, bool[] _Enable, int[] _ExposureTime)
//        {
//            for (int i = 0; i < _Grabmaxcnt; i++)
//            {
//                if (_Enable[i])
//                {
//                    m_Grabindex = i;
//                    int nExposureTime = _ExposureTime[i];

//                    SetExposure(nExposureTime);
//                    Grab(false);

//                    // Grab wait
//                    // Grab이 완료될때까지 대기...
//                    while (true)
//                    {
//                        // 해당 그랩이 끝나면 빠져나감..
//                        if (!m_bGrabbing)
//                        {
//                            break;
//                        }
//                    }
//                }
//            }
//        }

//        private UInt32 nSaveImageNeedSize = 0;
//        public Cognex.VisionPro.ICogImage ImageCogGrab;
//        private object syncGrab = new object();


//        public void ThreadReceiveBuffer()
//        {
//            m_bGrabbing = true;
//            Task.Run(async () =>
//            {
//                while (m_bGrabbing)
//                {
//                    await Task.Delay(1);
//                    ImageProcess();
//                }
//            });
//        }

//        public void GrabEnd()
//        {
//            m_bGrabbing = false;
//        }

//        public void ImageProcess()
//        {
//            if (Global.Instance.System.REQ_SYSTEM_CLOSE) return;

//            MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
//            int nRet = m_MyCamera.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
//            if (MyCamera.MV_OK != nRet) return;

//            UInt32 nPayloadSize = stParam.nCurValue;
//            if (nPayloadSize > m_nBufSizeForDriver)
//            {
//                if (m_BufForDriver != IntPtr.Zero)
//                {
//                    Marshal.Release(m_BufForDriver);
//                }
//                m_nBufSizeForDriver = nPayloadSize;
//                m_BufForDriver = Marshal.AllocHGlobal((Int32)m_nBufSizeForDriver);
//            }

//            if (m_BufForDriver == IntPtr.Zero) { return; }
//            MyCamera.MV_FRAME_OUT_INFO_EX stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();

//            nRet = m_MyCamera.MV_CC_GetOneFrameTimeout_NET(m_BufForDriver, nPayloadSize, ref stFrameInfo, 1000);

//            if (nRet == MyCamera.MV_OK)
//            {
//                m_stFrameInfo = stFrameInfo;

//                if (RemoveCustomPixelFormats(stFrameInfo.enPixelType)) { return; }

//                MyCamera.MvGvspPixelType enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;
//                if (IsColorData(m_stFrameInfo.enPixelType))
//                {
//                    enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed;
//                    nSaveImageNeedSize = (uint)m_stFrameInfo.nWidth * m_stFrameInfo.nHeight * 3;
//                }

//                if (m_BufForSaveImage != IntPtr.Zero)
//                {
//                    Marshal.Release(m_BufForSaveImage);
//                }

//                IntPtr pTemp = IntPtr.Zero;

//                m_nBufSizeForSaveImage = nSaveImageNeedSize;
//                m_BufForSaveImage = Marshal.AllocHGlobal((Int32)m_nBufSizeForSaveImage);

//                MyCamera.MV_PIXEL_CONVERT_PARAM stConverPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
//                stConverPixelParam.nWidth = m_stFrameInfo.nWidth;
//                stConverPixelParam.nHeight = m_stFrameInfo.nHeight;
//                stConverPixelParam.pSrcData = m_BufForDriver;
//                stConverPixelParam.nSrcDataLen = m_stFrameInfo.nFrameLen;
//                stConverPixelParam.enSrcPixelType = m_stFrameInfo.enPixelType;
//                stConverPixelParam.enDstPixelType = enDstPixelType;
//                stConverPixelParam.pDstBuffer = m_BufForSaveImage;
//                stConverPixelParam.nDstBufferSize = m_nBufSizeForSaveImage;

//                uint nWidth = m_stFrameInfo.nWidth;
//                uint nHeight = m_stFrameInfo.nHeight;
//                uint nRowStep = nWidth * nHeight;

//                //Auto Run 시 문제 생김
//                nRet = m_MyCamera.MV_CC_ConvertPixelType_NET(ref stConverPixelParam);

//                pTemp = m_BufForSaveImage;

//                Property.WIDTH = m_stFrameInfo.nWidth;
//                Property.HEIGHT = m_stFrameInfo.nHeight;

//                using (Bitmap _bitmap = new Bitmap((int)nWidth, (int)nHeight, (int)nWidth * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, pTemp))
//                {
//                    //Bitmap img = (Bitmap)_bitmap.Clone();
//                    ImageCogGrab = new CogImage24PlanarColor(_bitmap);
//                    if (m_GrabAll) m_imageCogGrab[m_Grabindex] = new CogImage24PlanarColor(_bitmap);
//                }

//                // Graball
//                if (m_GrabAll)
//                {
//                    if (m_imageCogGrab != null)
//                    {
//                        // Grab all end
//                        if (m_Grabindex == (m_GrabimgMaxcnt - 1))
//                        {
//                            m_GrabAll = false;
//                        }
//                    }
//                }

//                if (m_BufForSaveImage != IntPtr.Zero)
//                {
//                    Marshal.FreeHGlobal(m_BufForSaveImage);
//                }

//                // 라이브가 아닐때 해당 그랩 쓰레드 종료..
//                if (!IsLive) GrabEnd();
//            }
//        }

//        public Int32 ConvertToRGB(object obj, IntPtr pSrc, ushort nHeight, ushort nWidth, MyCamera.MvGvspPixelType nPixelType, IntPtr pDst)
//        {
//            if (IntPtr.Zero == pSrc || IntPtr.Zero == pDst)
//            {
//                return MyCamera.MV_E_PARAMETER;
//            }

//            int nRet = MyCamera.MV_OK;
//            MyCamera device = obj as MyCamera;
//            MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

//            stPixelConvertParam.pSrcData = pSrc;//源数据
//            if (IntPtr.Zero == stPixelConvertParam.pSrcData)
//            {
//                return -1;
//            }

//            stPixelConvertParam.nWidth = nWidth;//图像宽度
//            stPixelConvertParam.nHeight = nHeight;//图像高度
//            stPixelConvertParam.enSrcPixelType = nPixelType;//源数据的格式
//            stPixelConvertParam.nSrcDataLen = (uint)(nWidth * nHeight * ((((uint)nPixelType) >> 16) & 0x00ff) >> 3);

//            stPixelConvertParam.nDstBufferSize = (uint)(nWidth * nHeight * ((((uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed) >> 16) & 0x00ff) >> 3);
//            stPixelConvertParam.pDstBuffer = pDst;//转换后的数据
//            stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
//            stPixelConvertParam.nDstBufferSize = (uint)nWidth * nHeight * 3;

//            nRet = device.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
//            if (MyCamera.MV_OK != nRet)
//            {
//                return -1;
//            }

//            return MyCamera.MV_OK;
//        }

//        private bool IsMonoPixelFormat(uint enType)
//        {
//            switch (enType)
//            {
//                case (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
//                case (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
//                case (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
//                case (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
//                case (uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
//                    return true;

//                default:
//                    return false;
//            }
//        }

//        private bool IsColorPixelFormat(MyCamera.MvGvspPixelType enType)
//        {
//            switch (enType)
//            {
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGBA8_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGRA8_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
//                    return true;

//                default:
//                    return false;
//            }
//        }

//        //public void CycleGrab()
//        //{
//        //    Grab(false);
//        //    IsGrabDone.WaitOne();
//        //}

//        private Boolean IsColorData(MyCamera.MvGvspPixelType enGvspPixelType)
//        {
//            switch (enGvspPixelType)
//            {
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
//                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YCBCR411_8_CBYYCRYY:
//                    return true;

//                default:
//                    return false;
//            }
//        }

//        public bool SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE type)
//        {
//            try
//            {
//                m_MODE = type;
//                int nRet = -1;

//                //MyCamera.MVCC_ENUMVALUE enValue = new MyCamera.MVCC_ENUMVALUE();
//                //m_MyCamera.MV_CC_GetEnumValue_NET("TriggerMode", ref enValue);

//                switch (type)
//                {
//                    case CPropertyCamera.TRIGGER_MODE_TYPE.OFF: // LIVE
//                        nRet = m_MyCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
//                        nRet = m_MyCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
//                        break;

//                    case CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW: // SOFTWARE Trigger
//                        nRet = m_MyCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
//                        nRet = m_MyCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
//                        nRet = m_MyCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
//                        break;

//                    case CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW:// HARDWARE Trigger
//                        nRet = m_MyCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
//                        //nRet = m_MyCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
//                        nRet = m_MyCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
//                        break;
//                }

//                if (nRet != 0)
//                {
//                    CLogger.Add(LOG.DEVICE, $"CAMERA_{Property.INDEX} TRIGGER MODE SET ERROR");
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//            }

//            return true;
//        }

//        private bool RemoveCustomPixelFormats(MyCamera.MvGvspPixelType enPixelFormat)
//        {
//            UInt32 nInt = 0x80000000U;
//            UInt32 nResult = ((UInt32)enPixelFormat) & nInt;
//            if (nInt == nResult)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }

//            //Int32 nResult = ((int)enPixelFormat) & (unchecked((Int32)0x80000000));
//            //if (0x80000000 == nResult)
//            //{
//            //    return true;
//            //}
//            //else
//            //{
//            //    return false;
//            //}
//        }

//        //private void OnDisconnected()
//        //{
//        //    try
//        //    {
//        //        if (EventChangedConnection != null)
//        //        {
//        //            EventChangedConnection(this, null);
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
//        //        return;
//        //    }
//        //}

//        public void SaveConfig()
//        {
//            Property.SaveConfig();
//            //ImageLast.Save(IGlobal.m_MainPJTRoot + "\\Cam" + Index.ToString() + ".bmp", EImageFileType.Bmp);
//        }
//    }
//}

////#endif