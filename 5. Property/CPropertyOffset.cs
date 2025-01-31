using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;

namespace IntelligentFactory
{
    public class CPropertyOffset
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("NAME")]
        public string NAME { get; set; } = "";

        [CategoryAttribute("OFFSET"), DescriptionAttribute(""), DisplayNameAttribute("R_ALIGN")]
        public long R_ALIGN_OFFSET { get; set; } = 1000;

        [CategoryAttribute("OFFSET"), DescriptionAttribute(""), DisplayNameAttribute("INSP_START_OFFSET_X")]
        public long INSP_START_OFFSET_X { get; set; } = 100;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("EMPTY")]
        public string EMPTY { get; set; } = "EMPTY";

        public CPropertyOffset(string strName)
        {
            NAME = strName;
        }

        #region CONFIG BY XML

        private string m_XMLName = "PROPERTY_OFFSET";

        public bool LoadConfig(string strRecipeName)
        {
            try
            {
                string strPath = Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName + "\\" + NAME + ".xml";

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
                                    case "R_ALIGN_OFFSET": if (xmlReader.Read()) R_ALIGN_OFFSET = long.Parse(xmlReader.Value); break;
                                    case "INSP_START_OFFSET_X": if (xmlReader.Read()) INSP_START_OFFSET_X = long.Parse(xmlReader.Value); break;
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
                    SaveConfig(strRecipeName);
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

        public bool SaveConfig(string strRecipeName)
        {
            string strPath = Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName + "\\" + NAME + ".xml";

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
                xmlWriter.WriteElementString("R_ALIGN_OFFSET", R_ALIGN_OFFSET.ToString());
                xmlWriter.WriteElementString("INSP_START_OFFSET_X", INSP_START_OFFSET_X.ToString());

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