﻿using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;

namespace IntelligentFactory
{
    public class CPropertyCamera
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("NAME")]
        public string NAME { get; set; } = "";

        public enum CAM_TYPE : int
        { GIGE = 0, USB = 1, CAMERA_LINK = 2, CXP = 3 };

        [CategoryAttribute("INFORMATION"), DescriptionAttribute(""), DisplayNameAttribute("TYPE")]
        public CAM_TYPE TYPE { get; set; } = CAM_TYPE.CAMERA_LINK;

        [CategoryAttribute("INFORMATION"), DescriptionAttribute(""), DisplayNameAttribute("IP")]
        public string IP { get; set; } = "192.168.100.101";

        [CategoryAttribute("INFORMATION"), DescriptionAttribute(""), DisplayNameAttribute("SERIAL_NUMBER")]
        public string SERIAL_NUMBER { get; set; } = "";

        [CategoryAttribute("INFORMATION"), DescriptionAttribute(""), DisplayNameAttribute("INDEX")]
        public int INDEX { get; set; } = 0;

        public enum TRIGGER_MODE_TYPE : int
        { OFF = 0, ON_SW = 1, ON_HW = 2 };

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("TRIGGER_MODE")]
        public TRIGGER_MODE_TYPE TRIGGER_MODE { get; set; } = TRIGGER_MODE_TYPE.OFF;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("EXPOSURETIME_US")]
        public int EXPOSURETIME_US { get; set; } = 10000;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("GAIN")]
        public int GAIN { get; set; } = 15;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("FlipRotate")]
        public string FLIPROTATE { get; set; } = "";

        [CategoryAttribute("SIZE"), DescriptionAttribute(""), DisplayNameAttribute("WIDTH")]
        public int WIDTH { get; set; } = 4024;

        [CategoryAttribute("SIZE"), DescriptionAttribute(""), DisplayNameAttribute("HEIGHT")]
        public int HEIGHT { get; set; } = 3036;

        [CategoryAttribute("SIZE"), DescriptionAttribute(""), DisplayNameAttribute("PIXEL/MM")]
        public double PIXELPERMM { get; set; } = 0.006D;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("EMPTY")]
        public string EMPTY { get; set; } = "EMPTY";

        public CPropertyCamera(string strName)
        {
            NAME = strName;
        }

        #region CONFIG BY XML

        private string m_XMLName = "PROPERTY_CAMERA";

        public bool LoadConfig()
        {
            try
            {
                string strPath = Global.m_MainPJTRoot + "\\CONFIG\\DEVICE\\" + NAME + INDEX.ToString() + ".xml";

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
                                    case "TYPE": if (xmlReader.Read()) TYPE = (CAM_TYPE)Enum.Parse(typeof(CAM_TYPE), xmlReader.Value); break;
                                    case "IP": if (xmlReader.Read()) IP = xmlReader.Value; break;

                                    case "INDEX": if (xmlReader.Read()) INDEX = int.Parse(xmlReader.Value); break;
                                    case "EXPOSURETIME_US": if (xmlReader.Read()) EXPOSURETIME_US = int.Parse(xmlReader.Value); break;
                                    case "GAIN": if (xmlReader.Read()) GAIN = int.Parse(xmlReader.Value); break;
                                    case "PIXELPERMM": if (xmlReader.Read()) PIXELPERMM = double.Parse(xmlReader.Value); break;
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
            string strPath = Global.m_MainPJTRoot + "\\CONFIG\\DEVICE\\" + NAME + INDEX.ToString() + ".xml";

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
                xmlWriter.WriteElementString("TYPE", TYPE.ToString());
                xmlWriter.WriteElementString("INDEX", INDEX.ToString());
                xmlWriter.WriteElementString("IP", IP.ToString());
                xmlWriter.WriteElementString("EXPOSURETIME_US", EXPOSURETIME_US.ToString());
                xmlWriter.WriteElementString("GAIN", GAIN.ToString());
                xmlWriter.WriteElementString("PIXELPERMM", PIXELPERMM.ToString());

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