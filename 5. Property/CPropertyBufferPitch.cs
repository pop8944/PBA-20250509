using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;

namespace IntelligentFactory
{
    public class CPropertyBufferPitch
    {
        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("NAME")]
        public string NAME { get; set; } = "";

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("JIG_ELEVATOR_PITCH")]
        public double ZIG_ELEVATOR_PITCH { get; set; } = 6.0D;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("JIG_ELEVATOR_BUFFER_COUNT")]
        public int ZIG_ELEVATOR_BUFFER_COUNT { get; set; } = 39;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("LOADING_BUFFER_PITCH")]
        public double LOADING_BUFFER_PITCH { get; set; } = 6.0D;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("WORK_DONE_BUFFER_PITCH")]
        public double WORK_DONE_BUFFER_PITCH { get; set; } = 6.0D;

        public CPropertyBufferPitch(string strName)
        {
            NAME = strName;
        }

        #region CONFIG BY XML

        private string m_XMLName = "PROPERTY_BUFFER_PITCH";

        public bool LoadConfig(string strRecipe)
        {
            try
            {
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\MOTION\\" + NAME + ".xml";

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
                                    case "NAME": if (xmlReader.Read()) NAME = xmlReader.Value; break;
                                    case "LOADING_BUFFER_PITCH": if (xmlReader.Read()) LOADING_BUFFER_PITCH = double.Parse(xmlReader.Value); break;
                                    case "ZIG_ELEVATOR_BUFFER_COUNT": if (xmlReader.Read()) ZIG_ELEVATOR_BUFFER_COUNT = int.Parse(xmlReader.Value); break;
                                    case "ZIG_ELEVATOR_PITCH": if (xmlReader.Read()) ZIG_ELEVATOR_PITCH = double.Parse(xmlReader.Value); break;
                                    case "WORK_DONE_BUFFER_PITCH": if (xmlReader.Read()) WORK_DONE_BUFFER_PITCH = double.Parse(xmlReader.Value); break;
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
                    SaveConfig(strRecipe);
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

        public bool ManualLoadConfig(string strPath)
        {
            try
            {
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
                                    case "NAME": if (xmlReader.Read()) NAME = xmlReader.Value; break;
                                    case "AXIS_NO": if (xmlReader.Read()) LOADING_BUFFER_PITCH = double.Parse(xmlReader.Value); break;
                                    case "WORK_DONE_BUFFER_PITCH": if (xmlReader.Read()) WORK_DONE_BUFFER_PITCH = double.Parse(xmlReader.Value); break;
                                    case "ZIG_ELEVATOR_BUFFER_COUNT":
                                        if (xmlReader.Read())
                                        {
                                            ZIG_ELEVATOR_BUFFER_COUNT = int.Parse(xmlReader.Value);
                                            //IGlobal.Instance.iData.SEQ_DATA.BUFFER_METAL_TRAY_ID = new string[ZIG_ELEVATOR_BUFFER_COUNT];
                                            //IGlobal.Instance.iData.SEQ_DATA.BUFFER_TOP_COVER_ID = new string[ZIG_ELEVATOR_BUFFER_COUNT];
                                        }
                                        break;

                                    case "ZIG_ELEVATOR_PITCH": if (xmlReader.Read()) ZIG_ELEVATOR_PITCH = double.Parse(xmlReader.Value); break;
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
                    ManualSaveConfig(strPath);
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

        public bool SaveConfig(string strRecipe)
        {
            string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\MOTION\\" + NAME + ".xml";

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
                xmlWriter.WriteElementString("LOADING_BUFFER_PITCH", LOADING_BUFFER_PITCH.ToString());
                xmlWriter.WriteElementString("ZIG_ELEVATOR_PITCH", ZIG_ELEVATOR_PITCH.ToString());
                xmlWriter.WriteElementString("WORK_DONE_BUFFER_PITCH", WORK_DONE_BUFFER_PITCH.ToString());

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

        public bool ManualSaveConfig(string strPath)
        {
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
                xmlWriter.WriteElementString("LOADING_BUFFER_PITCH", LOADING_BUFFER_PITCH.ToString());
                xmlWriter.WriteElementString("ZIG_ELEVATOR_PITCH", ZIG_ELEVATOR_PITCH.ToString());
                xmlWriter.WriteElementString("WORK_DONE_BUFFER_PITCH", WORK_DONE_BUFFER_PITCH.ToString());

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