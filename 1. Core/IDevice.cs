using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace IntelligentFactory
{
    public class IDevice
    {
        public int CAMERA_COUNT { get; set; } = 2;
        public string SerialNo1 { get; set; } = "";
        public string SerialNo2 { get; set; } = "";
        public string strRMSQR { get; set; } = "";

        public List<Camera> Cameras = new List<Camera>();
        public ImageFocusLightController LightController;
        public int m_nLightChanelCount = 4;

        public int LightChanelCount
        {
            get { return m_nLightChanelCount; }
        }

        #region Test Virtual Inspection

        public bool bVirtualUse = false;

        #endregion Test Virtual Inspection

        #region MEWTOCOL

        //public CMewtocol Mewtocol = new CMewtocol();
        public CMewtocol NGBUFFER = null;

        #endregion MEWTOCOL

        public TcpIp EyeD { get; set; }
        public CDIO_ADLINK7432 DIO_BD { get; set; }

        // 현재 사용하는 디바이스의 컴포트값 할당 처리
        public CSerial_Registry.COM_PORT_Value[] m_COM;

        public IDevice()
        {
            // 디바이스 컴포트 레지스트리 값 리드
            CSerial_Registry.COM_Port_Config_Read();
        }

        public bool Init()
        {
            try
            {
                // 폴더가 있는지 체크..
                string DevicePath = $"{Global.m_MainPJTRoot}\\CONFIG\\DEVICE";
                if (!Directory.Exists(DevicePath)) Directory.CreateDirectory(DevicePath);

                LoadConfig();

                // 조명 컨트롤러, NG BUFFER의 컴포트값 할당...
                m_COM = CSerial_Registry.m_Com.ToArray();
                DIO_BD = new CDIO_ADLINK7432();
                EyeD = new TcpIp("EYE-D");

                EyeD.Init(Global.Instance.Setting.Enviroment.EyeD);

                //2024.03.15 송현수->안춘길 : 임시 주석

                Light_Init();
                NGBUFFER_Init();
                // EQP NAME 값 가져오기..
                Global.Instance.EQPNAME_Registry_Load();
                // 현재 저장된 ARC TCP IP, PORT값 가져오기..
                Global.Instance.ARC_Registry_Load();

                // 사용일 경우에만...TCP 동작
                if (Global.m_ARC_USE)
                {
                    // ARC TCP 클라이언트 클래스 연결
                    ARC_Control.Open(Global.m_ARC_IP, int.Parse(Global.m_ARC_PORT), "ARC Control");
                }

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }
        }


        private void NGBUFFER_Init()
        {
            Global.Notice = "Init the NG BUFFER";
            int value = (int)CSerial_Registry.COM_PORT_Name.NG_Buffer;
            NGBUFFER = new CMewtocol(Global.Instance.Mode.NG_Buffer_Type);

            // 해당 디바이스의 레지스트리의 저장 초기값이 없을 경우..해당 xml형태값 로드하여 컨넥트 
            // 초기값일 경우 기존 값을 읽어온 후 자동으로 레지스트리에 기록..
            if (CSerial_Registry.m_Com[value].m_LoadInitValue)
            {
                // 해당값을 레지스트리에 자동 저장..
                CSerial_Registry.m_Com[value].m_com_port = NGBUFFER.PortName;
                CSerial_Registry.m_Com[value].m_com_baudrate = NGBUFFER.BaudRate;
                CSerial_Registry.m_Com[value].m_com_databits = NGBUFFER.DataBits;
                CSerial_Registry.m_Com[value].m_com_stopbits = NGBUFFER.nStopBits;
                CSerial_Registry.m_Com[value].m_com_parity = NGBUFFER.nParity;

                CSerial_Registry.Serial_ComPort_Write(CSerial_Registry.m_Registry_COM_name[value], CSerial_Registry.m_Com[value]);
            }
            else
            {
                // 해당값을 레지스트리에 자동 저장..
                NGBUFFER.PortName = CSerial_Registry.m_Com[value].m_com_port;
                NGBUFFER.BaudRate = CSerial_Registry.m_Com[value].m_com_baudrate;
                NGBUFFER.DataBits = CSerial_Registry.m_Com[value].m_com_databits;
                NGBUFFER.nStopBits = CSerial_Registry.m_Com[value].m_com_stopbits;
                NGBUFFER.nParity = CSerial_Registry.m_Com[value].m_com_parity;
            }

            //if (!MewtocolComm.connect())
            //{
            //    CLogger.Add(LOG_TYPE.DEVICE, "Failed the Init NG BUFFER");
            //}

            if (!NGBUFFER.Connect())
            {
                CLogger.Add(LOG.DEVICE, "Failed the Init NG BUFFER");
            }

            //if (IGlobal.Instance.Mode.isSimulRMS)
            //{
            //    if (!NGBUFFER.Connect())
            //    {
            //        CLogger.Add(LOG_TYPE.DEVICE, "Failed the Init NG BUFFER");
            //        //CUtil.ShowMessageBox("ALARM", "Failed the Init MEWTOCOL");
            //    }
            //}
            //else
            //{
            //    if (IGlobal.Instance.Mode.UseRms)
            //    {
            //        if (!NGBUFFER.Connect())
            //        {
            //            CUtil.ShowMessageBox("ALARM", "Failed the Init MEWTOCOL");
            //        }
            //    }
            //}

            //MewtocolComm.SetQRStr(strRMSQR);
        }

        private void Light_Init()
        {
            Global.Notice = "Init the Light";
            int value = (int)CSerial_Registry.COM_PORT_Name.LightController;

            LightController = new ImageFocusLightController();
            // 해당 디바이스의 레지스트리의 저장 초기값이 없을 경우..해당 xml형태값 로드하여 컨넥트 
            // 초기값일 경우 기존 값을 읽어온 후 자동으로 레지스트리에 기록..
            if (CSerial_Registry.m_Com[value].m_LoadInitValue)
            {
                LightController.ReadInitFile();
                // 해당값을 레지스트리에 자동 저장..
                CSerial_Registry.m_Com[value].m_com_port = LightController.PortName;
                CSerial_Registry.m_Com[value].m_com_baudrate = LightController.BaudRate;
                CSerial_Registry.m_Com[value].m_com_databits = LightController.DataBits;
                CSerial_Registry.m_Com[value].m_com_stopbits = LightController.nStopBits;
                CSerial_Registry.m_Com[value].m_com_parity = LightController.nParity;

                CSerial_Registry.Serial_ComPort_Write(CSerial_Registry.m_Registry_COM_name[value], CSerial_Registry.m_Com[value]);
            }
            // 해당 읽어오는 값이 초기값이 아닐경우..읽어온 값을 해당 값으로 할당 처리..
            else
            {
                // 해당값을 레지스트리에 자동 저장..
                LightController.PortName = CSerial_Registry.m_Com[value].m_com_port;
                LightController.BaudRate = CSerial_Registry.m_Com[value].m_com_baudrate;
                LightController.DataBits = CSerial_Registry.m_Com[value].m_com_databits;
                LightController.nStopBits = CSerial_Registry.m_Com[value].m_com_stopbits;
                LightController.nParity = CSerial_Registry.m_Com[value].m_com_parity;
            }

            if (!LightController.Connect())
            {
                CLogger.Add(LOG.DEVICE, "Failed the Init LIGHT");
                //CUtil.ShowMessageBox("ALARM", "Failed the Init LIGHT");
            }

            m_nLightChanelCount = LightController.ChannelCount;
        }

        public void Close()
        {
            if (Cameras != null)
            {
                for (int i = 0; i < Cameras.Count; i++)
                {
                    if (Cameras[i].IsOpen) Cameras[i].Close();
                }
            }

            if (ARC_Control.IsRun)
            {
                ARC_Control.Close();
            }
        }

        #region CONFIG BY XML

        private string m_XMLName = "PROPERTY_DEVOCE";

        public bool LoadConfig()
        {
            try
            {
                string strPath = $"{Global.m_MainPJTRoot}\\CONFIG\\DEVICE\\DEVICE.xml";

                if (File.Exists(strPath))
                {
                    XmlTextReader xmlReader = new XmlTextReader(strPath);

                    try
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                switch (xmlReader.Name)
                                {
                                    case "CAMERA_COUNT": if (xmlReader.Read()) CAMERA_COUNT = int.Parse(xmlReader.Value); break;
                                    case "SerialNo1": if (xmlReader.Read()) SerialNo1 = xmlReader.Value; break;
                                    case "SerialNo2": if (xmlReader.Read()) SerialNo2 = xmlReader.Value; break;
                                    case "RMS_QR_STRING": if (xmlReader.Read()) strRMSQR = xmlReader.Value; break;
                                    //test
                                    case "bVirtualUse": if (xmlReader.Read()) bVirtualUse = bool.Parse(xmlReader.Value); break;
                                }
                            }
                            else
                            {
                                if (xmlReader.NodeType == XmlNodeType.EndElement)
                                {
                                    if (xmlReader.Name == m_XMLName) break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                        xmlReader.Close();
                    }

                    xmlReader.Close();
                }
                else
                {
                    SaveConfig();
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }
            return true;
        }

        public bool SaveConfig()
        {
            string strPath = $"{Global.m_MainPJTRoot}\\CONFIG\\DEVICE\\DEVICE.xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("PROPERTY");
                xmlWriter.WriteElementString("CAMERA_COUNT", CAMERA_COUNT.ToString());
                xmlWriter.WriteElementString("RMS_QR_STRING", strRMSQR);
                //test
                xmlWriter.WriteElementString("bVirtualUse", bVirtualUse.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }

            return true;
        }

        #endregion CONFIG BY XML
    }
}