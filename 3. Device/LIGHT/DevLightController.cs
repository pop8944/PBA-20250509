﻿using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;

namespace IntelligentFactory.Device
{
    public partial class DevLightController : Component
    {
        public IData iData
        {
            get;
            set;
        }

        public DevLightController()
        {
            InitializeComponent();
        }

        public DevLightController(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private int m_nChannel1Last = 0;

        public int Channel1Last
        {
            get { return m_nChannel1Last; }
            set { m_nChannel1Last = value; }
        }

        private int m_nChannel2Last = 0;

        public int Channel2Last
        {
            get { return m_nChannel2Last; }
            set { m_nChannel2Last = value; }
        }

        private string m_strPortName = "COM7";

        public string PortName
        {
            get { return m_strPortName; }
            set { m_strPortName = value; }
        }

        private int m_nBaudRate = 19200;

        public int BaudRate
        {
            get { return m_nBaudRate; }
            set { m_nBaudRate = value; }
        }

        public bool IsOpen
        {
            get { return m_SerialPort.IsOpen; }
        }

        public void Close()
        {
            if (m_SerialPort.IsOpen)
            {
                m_SerialPort.Close();
            }
        }

        public bool Init()
        {
            try
            {
                ReadInitFile();

                if (!m_SerialPort.IsOpen)
                {
                    m_SerialPort.PortName = m_strPortName;
                    m_SerialPort.BaudRate = m_nBaudRate;
                    m_SerialPort.Open();
                }
                else if (m_SerialPort.IsOpen)
                {
                    m_SerialPort.Close();
                }

                if (m_SerialPort.IsOpen)
                {
                    m_SerialPort.Write(":B200\r\n");
                    System.Threading.Thread.Sleep(100);
                    GC.Collect();
                }
                else
                {
                    //Logger.WriteLog(LOG.ERR, "[Failed] Light Controller Init");
                    return false;
                }

                //Logger.WriteLog(LOG.SYS, "[SUCCESS] Light Controller Init Class ==> {0}   Func ==> {1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                return true;
            }
            catch (Exception Desc)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
                //Logger.WriteLog(LOG.ERR, "[FAILED] Light Controller Init Class ==> {0}   Func ==> {1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return false;
            }
        }

        public bool SetLightOnOff(bool bOnOff /*On = True*/)
        {
            try
            {
                if (m_SerialPort.IsOpen)
                {
                    string strWriteData = "";
                    string strOnOff = bOnOff ? "O" : "F";
                    strWriteData = ":" + strOnOff + "0\r\n";

                    m_SerialPort.Write(strWriteData);

                    System.Threading.Thread.Sleep(1);
                }
                else
                {
                    //Logger.WriteLog(LOG.SYS, "[FAILED] Light Controller isn't Open ==> {0}   Func ==> {1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                }

                //Logger.WriteLog(LOG.SYS, "[SUCCESS] Light Controller {0} Class ==> {1}   Func ==> {2}", bOnOff? "On":"Off", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                return true;
            }
            catch (Exception Desc)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
                //Logger.WriteLog(LOG.ERR, "[FAILED] Lignt Control Class ==> {0}   Func ==> {1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                if (m_SerialPort.IsOpen)
                {
                    string strWriteData = "";
                    strWriteData = ":R12\r\n";

                    m_SerialPort.Write(strWriteData);

                    System.Threading.Thread.Sleep(1);
                }
                else
                {
                    //Logger.WriteLog(LOG.SYS, "[FAILED] Light Controller isn't Open ==> {0}   Func ==> {1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                }

                //Logger.WriteLog(LOG.Normal, "[SUCCESS] Light Controller {0} Class ==> {1}   Func ==> {2}", bOnOff ? "On" : "Off", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                return true;
            }
            catch (Exception Desc)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
                //Logger.WriteLog(LOG.ERR, "[FAILED] Class ==> {0}   Func ==> {1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return false;
            }
        }

        public bool SetLightControl(int nChannel, int nLightValue)
        {
            try
            {
                if (m_SerialPort.IsOpen)
                {
                    System.Threading.Thread.Sleep(10);
                    string strWriteData = "";
                    strWriteData = ":L" + nChannel.ToString() + nLightValue.ToString().PadLeft(3, '0') + "\r\n";

                    if (nChannel == 1)
                    {
                        m_nChannel1Last = nLightValue;
                    }
                    else if (nChannel == 2)
                    {
                        m_nChannel2Last = nLightValue;
                    }

                    //byte[] bWriteData = IConverter.StringToByte(strWriteData);
                    m_SerialPort.Write(strWriteData);

                    //Logger.WriteLog(LOG.SYS, "[SEND] {1}}", strWriteData);
                    //Logger.WriteLog(LOG.SYS, "[SUCCESS] Set Light ==> {0}   Func ==> {1} ==>{2}/{3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, nChannel.ToString(), nLightValue.ToString());
                }
                else
                {
                    //Logger.WriteLog(LOG.SYS, "[FAILED] Light Controller isn't Open ==> {0}   Func ==> {1} ==>{2}/{3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, nChannel.ToString(), nLightValue.ToString());
                }

                //Logger.WriteLog(LOG.SYS, "[SUCCESS] LightController Set Light Class ==> {0}   Func ==> {1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                return true;
            }
            catch (Exception Desc)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
                //Logger.WriteLog(LOG.ERR, "[FAILED] LightController Init Class ==> {0}   Func ==> {1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return false;
            }
        }

        #region File Manager

        private string m_strPath = Global.m_MainPJTRoot + "\\" + "LightControllerConfig" + ".xml";
        private string m_XMLName = "LightControllerConfig";

        public bool ReadInitFile()
        {
            try
            {
                //m_strPath = IGlobal.m_MainPJTRoot + "\\" + "Recipe\\" + iData.Recipe.Name + "\\" + "LightControllerConfig" + ".xml";
                if (File.Exists(m_strPath))   //  xml 파일 존재 유무 검사
                {
                    XmlTextReader xmlReader = new XmlTextReader(m_strPath);    //  xml 파일 열기

                    try
                    {
                        ReadInitFileFromXML(xmlReader);
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
                    WriteInitFile();
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //Logger.WriteLog(ex.Message);
                return false;
            }
            return true;
        }

        public bool WriteInitFile()
        {
            //m_strPath = IGlobal.m_MainPJTRoot + "\\" + "Recipe\\" + iData.Recipe.Name + "\\" + "LightControllerConfig" + ".xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(m_strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();

                WriteInitFileToXML(xmlWriter);

                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //Logger.WriteLog(LOG.ERR, "[FAILED] LightController Config Save");
                //Logger.WriteLog(ex.Message);
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }

            //Logger.WriteLog(LOG.SYS, "[SUCCESS] LightController Config Save ==> {0}", m_strPath);
            return true;
        }

        public bool ReadInitFileFromXML(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (xmlReader.Name)
                    {
                        case "PortName":
                            if (!xmlReader.Read()) return false;
                            m_strPortName = xmlReader.Value;
                            break;

                        case "BaudRate":
                            if (!xmlReader.Read()) return false;
                            m_nBaudRate = int.Parse(xmlReader.Value);
                            break;

                        case "Channel1Last":
                            if (!xmlReader.Read()) return false;
                            m_nChannel1Last = int.Parse(xmlReader.Value);
                            break;

                        case "Channel2Last":
                            if (!xmlReader.Read()) return false;
                            m_nChannel2Last = int.Parse(xmlReader.Value);
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

            //Logger.WriteLog(LOG.SYS, "[SUCCESS] LightController Config Load");
            return true;
        }

        public bool WriteInitFileToXML(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Parameter");

            xmlWriter.WriteElementString("PortName", m_strPortName);
            xmlWriter.WriteElementString("BaudRate", m_nBaudRate.ToString());
            xmlWriter.WriteElementString("Channel1Last", m_nChannel1Last.ToString());
            xmlWriter.WriteElementString("Channel2Last", m_nChannel2Last.ToString());

            xmlWriter.WriteEndElement();

            return true;
        }

        #endregion File Manager

        private void m_SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string strRx = m_SerialPort.ReadExisting();

                if (strRx.Length > 3)
                {
                    if (strRx[0] == ':' && (strRx[1] == 'R' || strRx[1] == 'r') && strRx.Contains("\r"))
                    {
                        //Logger.WriteLog(LOG.COM, "Recv Data ==> : " + strRx);

                        if (strRx.Length >= strRx.IndexOf("\r") && (strRx.IndexOf("\r") - 3) > 0)
                        {
                            string strValue = strRx.Substring(3, strRx.IndexOf("\r") - 3);
                            string[] strLightValue = strValue.Split(',');

                            if (strLightValue.Length == 2)
                            {
                                m_nChannel1Last = int.Parse(strLightValue[0]);
                                m_nChannel2Last = int.Parse(strLightValue[1]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //Logger.WriteLog(LOG.ERR, "[FAILED] Class ==> {0}   Func ==> {1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}