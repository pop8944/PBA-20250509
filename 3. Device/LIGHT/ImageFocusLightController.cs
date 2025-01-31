using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IntelligentFactory
{
    public class ImageFocusLightController
    {
        private SerialPort m_Sp = new SerialPort();
        public string PortName { get; set; } = "COM1"; // 저장용 portname
        public int BaudRate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;
        public StopBits nStopBits { get; set; } = StopBits.One;
        public Parity nParity { get; set; } = Parity.None;

        public bool IsOpen
        { get { return m_Sp.IsOpen; } }

        public int ChannelCount { get; set; } = 4;
        public bool StartOn { get; set; } = true;
        public int[] Values { get; set; } = new int[33];
        public bool SerialOpen = false;

        //common
        private byte m_Stx { get; set; } = 0x02;

        private byte m_Etx { get; set; } = 0x03;

        // Chnel 정보 1~C 12Chanel
        private byte[] m_Chanel { get; set; } = { 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43 };

        // Command
        private byte m_O { get; set; } = 0x4F;

        private byte m_N { get; set; } = 0x4E;
        private byte m_F { get; set; } = 0x46;
        private byte m_R { get; set; } = 0x52;
        private byte m_E { get; set; } = 0x45;
        private byte m_T { get; set; } = 0x54;

        // 시리얼 통신 처리를 위한 큐 자료구조 처리..
        // 시리얼 통신 처리시...메세지 누락을 방지하기 위한 처리..
        Queue<byte[]> CmdQueue = new Queue<byte[]>();
        bool SendThreadRun = false;

        public ImageFocusLightController()
        {

        }

        //Serial 연결
        public bool Connect()
        {
            if (!SerialOpen)
            {
                m_Sp.PortName = PortName;
                m_Sp.BaudRate = BaudRate;
                m_Sp.DataBits = DataBits;
                m_Sp.StopBits = nStopBits;
                m_Sp.Parity = nParity;

                if (!Open())
                {
                    //CUtil.ShowMessageBox("Light Controller Check", "Light Controller Not Connect!!");
                    CLogger.Add(LOG.DEVICE, "Light Controller Not Connect!!");
                    return false;
                }

                //SetChannelCount();
                return true;
            }
            else
            {
                CLogger.Add(LOG.DEVICE, "Light Controller Not Connect!!");
                //CUtil.ShowMessageBox("Light Controller Check", "Light Controller Not Connect!!");
                return false;
            }
        }

        private bool Open()
        {
            SerialOpen = true;

            try
            {
                m_Sp.Open();
                m_Sp.WriteTimeout = 1000;
                SendThread();           // 메세지 처리동작 쓰레드 런...
                AllOn();
                CLogger.Add(LOG.DEVICE, "[OK] ==> Light Controller Connect!");
                return SerialOpen;
            }
            catch
            {
                SerialOpen = false;
                return SerialOpen;
            }
        }

        private void SendThread()
        {
            SendThreadRun = true;
            // Task 처리를 람다식으로 처리
            System.Threading.Tasks.Task.Run(async () =>
            {
                while (SendThreadRun)
                {
                    await Task.Delay(1);
                    // 정상적으로 시리얼 오픈이 되어있어야 메세지 동작..
                    if (IsOpen)
                    {
                        MSG_Send();
                    }
                }
            });
        }

        private void MSG_Send()
        {
            if (CmdQueue.Count > 0)
            {
                // 메세지 데이터 처리..
                byte[] _data = CmdQueue.Dequeue();
                m_Sp.Write(_data, 0, _data.Length);
            }
        }

        public bool DisConnect()
        {
            if (SerialOpen)
            {
                //m_Sp.DiscardInBuffer();
                //m_Sp.DiscardOutBuffer();

                AllOff();

                m_Sp.Close();
                m_Sp.Dispose();

                SerialOpen = false;

                return true;
            }
            return false;
        }

        public bool AllOn()
        {
            try
            {
                if (SerialOpen)
                {
                    byte[] Arr_On = new byte[6];

                    for (int i = 0; i < ChannelCount; i++)
                    {
                        Arr_On[0] = m_Stx;
                        Arr_On[1] = m_Chanel[i];
                        Arr_On[2] = m_Chanel[i];
                        Arr_On[3] = m_O;
                        Arr_On[4] = m_N;
                        Arr_On[5] = m_Etx;

                        CmdQueue.Enqueue(Arr_On);
                        //m_Sp.Write(Arr_On, 0, Arr_On.Length);
                    }

                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        public bool AllOff()
        {
            try
            {
                if (SerialOpen)
                {
                    byte[] Arr_Off = new byte[6];

                    for (int i = 0; i < ChannelCount; i++)
                    {
                        Arr_Off[0] = m_Stx;
                        Arr_Off[1] = m_Chanel[i];
                        Arr_Off[2] = m_O;
                        Arr_Off[3] = m_F;
                        Arr_Off[4] = m_F;
                        Arr_Off[5] = m_Etx;

                        CmdQueue.Enqueue(Arr_Off);
                        //m_Sp.Write(Arr_Off, 0, Arr_Off.Length);
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

        private string ByteToString(byte[] strByte)
        {
            string str = Encoding.ASCII.GetString(strByte);
            return str;
        }

        private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.ASCII.GetBytes(str);
            return StrByte;
        }

        public bool SetValue(int Channel, int Value)
        {
            try
            {
                //// 조명 byte 변형
                //string strVal = Value;
                //Values[(Channel - 1)].ToString();
                string strPad = "";

                if (Value.ToString().Length < 3) { strPad = Value.ToString().PadLeft(3, '0'); }
                else { strPad = Value.ToString(); }
                byte[] Stval = StringToByte(strPad);

                byte[] control = new byte[6];

                control[0] = m_Stx;
                control[1] = m_Chanel[Channel - 1];
                control[2] = Stval[0];
                control[3] = Stval[1];
                control[4] = Stval[2];
                control[5] = m_Etx;

                Values[(Channel - 1)] = Value;

                string str = ByteToString(control);

                CmdQueue.Enqueue(control);

                //m_Sp.Write(control, 0, control.Length);
                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        #region CONFIG BY XML

        //private string m_strPath = IGlobal.m_MainPJTRoot + "\\" + "LighControllerConfig" + ".xml";
        private string m_XMLName = "LIGHTCONTROLLER";

        public bool ReadInitFile()
        {
            try
            {
                string strPath = Global.m_MainPJTRoot + "\\CONFIG\\DEVICE\\" + m_XMLName + ".xml";
                //string strPath = IGlobal.m_MainPJTRoot + "\\" + m_XMLName + ".xml";

                if (File.Exists(strPath))
                {
                    XmlTextReader xmlReader = new XmlTextReader(strPath);

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
                return false;
            }
            return true;
        }

        public bool WriteInitFile()
        {
            string strPath = Global.m_MainPJTRoot + "\\CONFIG\\DEVICE\\" + m_XMLName + ".xml";
            //string strPath = IGlobal.m_MainPJTRoot + "\\" + m_XMLName + ".xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();

                WriteInitFileToXML(xmlWriter);

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
                            //PortNm[0] = xmlReader.Value;
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
            return true;
        }

        public bool WriteInitFileToXML(XmlWriter xmlWriter)
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
    }
}