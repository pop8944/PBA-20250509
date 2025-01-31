using OpenCvSharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml;

namespace IntelligentFactory
{
    public class CPropertyMatching
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("NAME")]
        public string NAME { get; set; } = "";

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("NUM_MATCH")]
        public int NUM_MATCH { get; set; } = 1;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("SCORE_MIN")]
        public double SCORE_MIN { get; set; } = 0.6D;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("MAGNIFICATION")]
        public double MAGNIFIATION { get; set; } = 2.0D;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("ROI")]
        public string SROI
        { get { return InspectROI.ToString(); } }

        public Rectangle InspectROI = new Rectangle();

        public string STrainROI
        { get { return TrainROI.ToString(); } }

        public Rectangle TrainROI = new Rectangle();

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("EMPTY")]
        public string EMPTY { get; set; } = "EMPTY";

        public Mat ImageTemplate = new Mat();

        public CPropertyMatching(string strName)
        {
            NAME = strName;
        }

        #region CONFIG BY XML

        private string m_XMLName = "PROPERTY_MATCHING";

        public bool LoadConfig(string strRecipeName)
        {
            try
            {
                string strPath = Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName + "\\" + NAME + ".xml";

                try
                {
                    string strName = Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName + $"\\{NAME}.bmp";
                    ImageTemplate = Cv2.ImRead(Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName + $"\\{NAME}.bmp");
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }

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
                                    case "SCORE_MIN": if (xmlReader.Read()) SCORE_MIN = double.Parse(xmlReader.Value); break;
                                    case "MAGNIFIATION": if (xmlReader.Read()) MAGNIFIATION = double.Parse(xmlReader.Value); break;
                                    case "ROI": if (xmlReader.Read()) InspectROI = CConverter.StringToRoi(xmlReader.Value); break;
                                    case "NUM_MATCH": if (xmlReader.Read()) NUM_MATCH = int.Parse(xmlReader.Value); break;
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

            try
            {
                ImageTemplate.SaveImage(Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName + $"\\{NAME}.bmp");
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

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
                xmlWriter.WriteElementString("SCORE_MIN", SCORE_MIN.ToString());
                xmlWriter.WriteElementString("MAGNIFIATION", MAGNIFIATION.ToString());
                xmlWriter.WriteElementString("ROI", CConverter.RoiToString(InspectROI));
                xmlWriter.WriteElementString("NUM_MATCH", NUM_MATCH.ToString());

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