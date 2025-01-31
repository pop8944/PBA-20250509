using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace IntelligentFactory
{
    public class CSystem
    {
        public bool USE_SAFETY_DOOR = false;
        public EventHandler<EventArgs> EventChangedMode;

        public enum MODE
        { NO_LICENSE, READY, AUTO, ALARM, SIMULATION };

        private MODE m_eModePrev = MODE.READY;
        private MODE m_eMode = MODE.READY;

        public MODE Mode
        {
            get { return m_eMode; }
            set
            {
                if (m_eModePrev != value)
                {
                    if (EventChangedMode != null)
                    {
                        EventChangedMode(this, new EventArgs());
                    }

                }
                m_eModePrev = m_eMode;
                m_eMode = value;
            }
        }

        #region RECIPE

        private CRecipe m_Recipe = new CRecipe();

        public CRecipe Recipe
        {
            get { return m_Recipe; }
            set { m_Recipe = value; }
        }

        //public CCommonCode CommonCode { get; set; } = null;

        #endregion RECIPE

        #region NOTICE

        private string m_strNotice = "-";

        public string Notice
        {
            get { return m_strNotice; }
            set
            {
                m_strNotice = value;
                CLogger.Add(LOG.NORMAL, Notice);
            }
        }
        #endregion NOTICE

        #region LICENSE

#if USE_LICENSE
        private bool m_bUseLicense = true;
#else
        private bool m_bUseLicense = false;
#endif
        private string m_strLicense = "";

        public string License
        {
            get { return m_strLicense; }
            set
            {
                m_strLicense = value;

                if (m_bUseLicense)
                {
                    bool bCertificated = false;
                    //License 확인 후

                    if (bCertificated) Mode = MODE.READY;
                    else Mode = MODE.NO_LICENSE;
                }
            }
        }

        #endregion LICENSE

        #region RESULT

        public enum RESULT
        { IDLE, OK, NG };

        private RESULT m_eResult = RESULT.IDLE;

        public RESULT Result
        {
            get { return m_eResult; }
            set { m_eResult = value; }
        }

        #endregion RESULT

        #region UI

        private string m_strProcdure = "READY";

        public string PROCDURE
        {
            get => m_strProcdure;
            set
            {
                m_strProcdure = value;
                CLogger.Add(LOG.SEQ, "PROCDURE : {0}", m_strProcdure);
            }
        }

        private int m_nStyleIndex = 6;

        public int StyleIndex
        {
            get => m_nStyleIndex;
            set
            {
                m_nStyleIndex = value;
            }
        }

        //public EventHandler<EventArgs> EventUpdateStyle;

        #endregion UI

        #region PLC IP

        private string m_strPlcIP = "192.168.100.101";

        public string PlcIp
        {
            get => m_strPlcIP;
            set => m_strPlcIP = value;
        }

        private int m_nPlcLogicalNo = 0;

        public int PlcLogicalNo
        {
            get => m_nPlcLogicalNo;
            set => m_nPlcLogicalNo = value;
        }

        #endregion PLC IP

        #region IPC

        public IntPtr IF_Handle { get; set; } = IntPtr.Zero;

        #endregion IPC

        #region Algorithm

        private string m_strAlgorithm = "Pattern Matching";

        public string Algorithm
        {
            get => m_strAlgorithm;
            set => m_strAlgorithm = value;
        }

        #endregion Algorithm

        #region Image Delete / Log

        private string m_strDrivePath = "C";

        public string DrivePath
        {
            get { return m_strDrivePath; }
            set { m_strDrivePath = value; }
        }

        private int m_nDriveVolum = 80;

        public int DriveVolum
        {
            get { return m_nDriveVolum; }
            set { m_nDriveVolum = value; }
        }

        private int m_nDeleteImageDay = 7;

        public int DeleteImageDay
        {
            get { return m_nDeleteImageDay; }
            set { m_nDeleteImageDay = value; }
        }

        private int m_nDeleteLogDay = 7;

        public int DeleteLogDay
        {
            get { return m_nDeleteLogDay; }
            set { m_nDeleteLogDay = value; }
        }

        #endregion Image Delete / Log

        #region PROPERTIES

        private DEFINE.AUTHORIZATION m_Authorization = DEFINE.AUTHORIZATION.OPERATOR;

        public DEFINE.AUTHORIZATION Authorization
        {
            get => m_Authorization;
            set
            {
                m_Authorization = value;

                //if (EventChangedAuthorization != null)
                //{
                //    EventChangedAuthorization(this, new EventArgs());
                //}
            }
        }

        public string Password_Engineer { get; set; } = "0000";
        public string Password_Administrator { get; set; } = "0000";

        #endregion PROPERTIES

        //#region PATH

        //public string startpath = IGlobal.m_MainPJTRoot;

        //#endregion PATH

        #region RMS MODE

        //public bool RMS_PASS_MODE = false;
        //public bool RMS_SELECT_MODE = false;
        public bool RMS_TIMER_MODE = false;

        public bool BufferClick = false;

        #endregion RMS MODE

        #region IMAGE SAVE

        public bool OK_IMAGE_SAVE = false;
        public bool NG_IMAGE_SAVE = false;

        #endregion IMAGE SAVE

        #region Form

        //public FormPBAviewer FrmViewer = new FormPBAviewer();

        #endregion Form

        [DllImport("gdi32.dll")] private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);

        [DllImport("user32.dll")] private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        public static Control[] GetControls(Control con)
        {
            var conList = new List<Control>();

            foreach (Control control in con.Controls)
            {
                //컨트롤 속성으로 찾는 방법
                if (control is Button)
                {
                    int nSize = 20;

                    //15 로 전달 되어 있는 인자 -> 실제 모서리 둥글게 표현 하는 인자
                    IntPtr ip = CreateRoundRectRgn(0, 0, control.Width, control.Height, nSize, nSize);
                    SetWindowRgn(control.Handle, ip, true);
                    conList.Add(control);
                }
                ////컨트롤 이름으로 찾는 방법
                //if (control.Name == "그리드뷰")
                //    conList.Add(control);

                //주석
                if (control.Controls.Count > 0)
                    conList.AddRange(GetControls(control));
            }

            return conList.ToArray();
        }

        public bool REQ_SYSTEM_CLOSE { get; set; } = false;

        private string m_strSendLicense = "";

        public string SendLicense
        {
            get { return m_strSendLicense; }
            set { m_strSendLicense = value; }
        }

        public CSystem()
        {
            Directory_Init();
            LoadConfig();
        }

        // 현재 디렉토리 초기화..
        private void Directory_Init()
        {
            string ConfigPath = $"{Global.m_MainPJTRoot}\\CONFIG";
            if (!Directory.Exists(ConfigPath)) Directory.CreateDirectory(ConfigPath);

            string RecipePath = $"{Global.m_MainPJTRoot}\\RECIPE";
            if (!Directory.Exists(RecipePath)) Directory.CreateDirectory(RecipePath);
        }

        //public void AddAlarm(string strCode, string strDesc)
        //{
        //    CAlarm.Add(new CNodeAlarm(strCode, strDesc));
        //    AlarmWait.Reset();
        //}

        public void Close()
        {

        }

        #region CONFIG BY XML

        private string m_XMLName = "SYSTEM";

        public bool LoadConfig()
        {
            try
            {
                string strPath = Global.m_MainPJTRoot + "\\" + m_XMLName + ".xml";

                if (File.Exists(strPath))
                {
                    XmlTextReader xmlReader = new XmlTextReader(strPath);

                    try
                    {
                        LoadConfigFromXML(xmlReader);
                    }
                    catch (Exception ex)
                    {
                        CLogger.Add(LOG.ABNORMAL, "SYSTEM Load Ex ==> {0}", ex.Message);
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
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            return true;
        }

        public bool LoadConfigFromXML(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    CLogger.Add(LOG.NORMAL, "CONFIG [{0}] ==> {1}", xmlReader.Name, xmlReader.Value);

                    switch (xmlReader.Name)
                    {
                        case "License":
                            if (!xmlReader.Read()) return false;
                            License = xmlReader.Value;
                            break;

                        case "Password_Engineer":
                            if (!xmlReader.Read()) return false;
                            Password_Engineer = xmlReader.Value;
                            break;

                        case "Password_Administrator":
                            if (!xmlReader.Read()) return false;
                            Password_Administrator = xmlReader.Value;
                            break;

                        case "Algorithm":
                            if (!xmlReader.Read()) return false;
                            Algorithm = xmlReader.Value;
                            break;

                        case "DeleteLogDay":
                            if (!xmlReader.Read()) return false;
                            DeleteLogDay = int.Parse(xmlReader.Value);
                            break;

                        case "DrivePath":
                            if (!xmlReader.Read()) return false;
                            DrivePath = xmlReader.Value;
                            break;

                        case "DriveVolum":
                            if (!xmlReader.Read()) return false;
                            DriveVolum = int.Parse(xmlReader.Value);
                            break;

                        case "DeleteImageDay":
                            if (!xmlReader.Read()) return false;
                            DeleteImageDay = int.Parse(xmlReader.Value);
                            break;

                        case "USE_SAFETY_DOOR":
                            if (!xmlReader.Read()) return false;
                            USE_SAFETY_DOOR = bool.Parse(xmlReader.Value);
                            break;
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

            CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public bool SaveConfig()
        {
            string strPath = Global.m_MainPJTRoot + "\\" + m_XMLName + ".xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();
                SaveConfigToXML(xmlWriter);
                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }

            CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public bool SaveConfigToXML(XmlWriter xmlWriter)
        {
            try
            {
                xmlWriter.WriteStartElement("SYSTEM");
                xmlWriter.WriteElementString("License", License);
                xmlWriter.WriteElementString("Password_Engineer", Password_Engineer);
                xmlWriter.WriteElementString("Password_Administrator", Password_Administrator);
                xmlWriter.WriteElementString("Algorithm", Algorithm.ToString());
                xmlWriter.WriteElementString("DeleteLogDay", DeleteLogDay.ToString());
                xmlWriter.WriteElementString("DrivePath", DrivePath);
                xmlWriter.WriteElementString("DrivePath", DrivePath);
                xmlWriter.WriteElementString("DriveVolum", DriveVolum.ToString());
                xmlWriter.WriteElementString("DeleteImageDay", DeleteImageDay.ToString());
                xmlWriter.WriteElementString("PlcLogicalNo", PlcLogicalNo.ToString());
                xmlWriter.WriteElementString("PlcIp", PlcIp.ToString());

                xmlWriter.WriteElementString("USE_SAFETY_DOOR", USE_SAFETY_DOOR.ToString());
                xmlWriter.WriteEndElement();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "SYSTEM Save Ex ==> {0}", ex.Message);
            }

            return true;
        }

        #endregion CONFIG BY XML
    }
}