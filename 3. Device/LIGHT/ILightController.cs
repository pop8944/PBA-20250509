using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Threading;
using System.Xml;

namespace IntelligentFactory
{
    public partial class ILightController_DPS : Component
    {
        private const string CMD_LIGHT_ON = ":O0\r\n";
        private const string CMD_LIGHT_OFF = ":F0\r\n";

        public ILightController_DPS()
        {
            InitializeComponent();
        }

        public string PortName { get; set; } = "COM1";
        public int BaudRate { get; set; } = 19200;

        public bool IsOpen
        { get { return m_SerialPort.IsOpen; } }

        public int ChannelCount { get; set; } = 2;
        public bool StartOn { get; set; } = true;
        public int[] Values { get; set; } = new int[2];

        public bool Init()
        {
            try
            {
                LoadConfig();

                m_SerialPort = new SerialPort();
                m_SerialPort.PortName = "COM6";
                m_SerialPort.BaudRate = BaudRate;
                m_SerialPort.DataBits = 8;
                m_SerialPort.Parity = Parity.None;

                m_SerialPort.Open();

                if (m_SerialPort.IsOpen)
                {
                    for (int i = 0; i < ChannelCount; i++)
                    {
                        if (i < Values.Length)
                        {
                            SetValue(i + 1, 100);
                            if (StartOn) On(i);
                        }
                    }

                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                if (m_SerialPort.IsOpen)
                {
                    for (int i = 0; i < Values.Length; i++) Off(i);

                    m_SerialPort.DiscardInBuffer();
                    m_SerialPort.DiscardOutBuffer();

                    m_SerialPort.Close();
                    m_SerialPort.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        public bool On(int nChannel = 0)
        {
            try
            {
                if (m_SerialPort.IsOpen) m_SerialPort.Write(CMD_LIGHT_ON);
                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        public bool Off(int nChannel = 0)
        {
            try
            {
                if (m_SerialPort.IsOpen) m_SerialPort.Write(CMD_LIGHT_OFF);
                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        public bool SetValue(int nChannel = 0, int nValue = 255)
        {
            try
            {
                Thread.Sleep(1);

                string strCommand = $":L{nChannel}{nValue.ToString().PadLeft(3, '0')}\r\n";
                m_SerialPort.Write(strCommand);

                if (Values.Length >= nChannel) Values[nChannel - 1] = nValue;

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        #region CONFIG BY XML

        private string m_XMLName = "LIGHTCONTROLLER";

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
                        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
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
                    switch (xmlReader.Name)
                    {
                        case "PortName":
                            if (!xmlReader.Read()) return false;
                            PortName = xmlReader.Value;
                            break;

                        case "BaudRate":
                            if (!xmlReader.Read()) return false;
                            BaudRate = int.Parse(xmlReader.Value);
                            break;

                        case "ChannelCount":
                            if (!xmlReader.Read()) return false;
                            ChannelCount = int.Parse(xmlReader.Value);
                            break;

                        case "StartOn":
                            if (!xmlReader.Read()) return false;
                            StartOn = bool.Parse(xmlReader.Value);
                            break;

                        case "Values":
                            if (!xmlReader.Read()) return false;
                            string strValue = xmlReader.Value;
                            string[] strValues = strValue.Split(',');

                            for (int i = 0; i < strValues.Length; i++)
                            {
                                if (i < Values.Length) Values[i] = int.Parse(strValues[i]);
                            }

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
                xmlWriter.WriteStartElement("LIGHTCONTROLLER");
                xmlWriter.WriteElementString("PortName", PortName);
                xmlWriter.WriteElementString("BaudRate", BaudRate.ToString());
                xmlWriter.WriteElementString("ChannelCount", ChannelCount.ToString());
                xmlWriter.WriteElementString("StartOn", StartOn.ToString());
                xmlWriter.WriteElementString("Values", ValuesToString(Values));
                xmlWriter.WriteEndElement();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

            return true;
        }

        public string ValuesToString(int[] list)
        {
            string strValues = "";

            try
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list.Length - 1 != i)
                    {
                        strValues += list[i].ToString() + ",";
                    }
                    else
                    {
                        strValues += list[i].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return strValues;
            }

            return strValues;
        }

        #endregion CONFIG BY XML

        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        }
    }
}