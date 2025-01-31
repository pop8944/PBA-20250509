using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;

namespace IntelligentFactory
{
    public class CPropertyCellArray
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("NAME")]
        public string NAME { get; set; } = "";

        [CategoryAttribute("Format"), DescriptionAttribute(""), DisplayNameAttribute("COLUMNS")]
        public int COLUMNS { get; set; } = 10;

        [CategoryAttribute("Format"), DescriptionAttribute(""), DisplayNameAttribute("ROWS")]
        public int ROWS { get; set; } = 10;

        [CategoryAttribute("Format"), DescriptionAttribute(""), DisplayNameAttribute("COUNT_P/P")]
        public int COUNT_PP { get; set; } = 87;

        [CategoryAttribute("Format"), DescriptionAttribute(""), DisplayNameAttribute("COUNT_N/P")]
        public int COUNT_NP { get; set; } = 58;

        [CategoryAttribute("Format"), DescriptionAttribute(""), DisplayNameAttribute("COUNT_N/A")]
        public int COUNT_NA { get; set; } = 17;

        [CategoryAttribute("Image Process"), DescriptionAttribute(""), DisplayNameAttribute("USE_EQULIZE_HIST")]
        public bool USE_EQUALIZE_HIST { get; set; } = false;

        [CategoryAttribute("Image Process"), DescriptionAttribute(""), DisplayNameAttribute("USE_CLAHE_HIST")]
        public bool USE_CLAHE_HIST { get; set; } = false;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("IMAGE_ALIGN")]
        public Mat ImageAlign { get; set; } = new Mat();

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("IMAGE_ALIGN_PATH")]
        public string IMAGE_ALIGN_PATH { get; set; } = "";

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("THRESHOLD_WEIGHT")]
        public int THRESHOLD_WEIGHT { get; set; } = 20;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("AREA_MIN")]
        public int AREA_MIN { get; set; } = 5;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("P/P_MEAN_MIN")]
        public int PP_MEAN_MIN { get; set; } = 0;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("P/P_MEAN_MAX")]
        public int PP_MEAN_MAX { get; set; } = 100;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("N/P_MEAN_MIN")]
        public int NP_MEAN_MIN { get; set; } = 0;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("N/P_MEAN_MAX")]
        public int NP_MEAN_MAX { get; set; } = 100;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("N/A_MEAN_MIN")]
        public int NA_MEAN_MIN { get; set; } = 0;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("N/A_MEAN_MAX")]
        public int NA_MEAN_MAX { get; set; } = 100;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("EMPTY")]
        public string EMPTY { get; set; } = "EMPTY";

        public List<CFormatCellBoundary> CellBoundaries = new List<CFormatCellBoundary>();

        public CPropertyCellArray(string strName)
        {
            NAME = strName;
        }

        #region CONFIG BY XML

        private string m_XMLName = "PROPERTY_CELL_ARRAY";

        public bool LoadConfig(string strRecipeName)
        {
            try
            {
                string strPath = Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName + "\\" + NAME + ".xml";

                try
                {
                }
                catch (Exception Desc)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
                    CLogger.Add(LOG.NORMAL, "Can't Load the Image of Align");
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
                                    case "USE_EQUALIZE_HIST": if (xmlReader.Read()) USE_EQUALIZE_HIST = bool.Parse(xmlReader.Value); break;
                                    case "USE_CLAHE_HIST": if (xmlReader.Read()) USE_CLAHE_HIST = bool.Parse(xmlReader.Value); break;
                                    case "COLUMNS": if (xmlReader.Read()) COLUMNS = int.Parse(xmlReader.Value); break;
                                    case "ROWS": if (xmlReader.Read()) ROWS = int.Parse(xmlReader.Value); break;

                                    case "PP_MEAN_MIN": if (xmlReader.Read()) PP_MEAN_MIN = int.Parse(xmlReader.Value); break;
                                    case "PP_MEAN_MAX": if (xmlReader.Read()) PP_MEAN_MAX = int.Parse(xmlReader.Value); break;
                                    case "NP_MEAN_MIN": if (xmlReader.Read()) NP_MEAN_MIN = int.Parse(xmlReader.Value); break;
                                    case "NP_MEAN_MAX": if (xmlReader.Read()) NP_MEAN_MAX = int.Parse(xmlReader.Value); break;
                                    case "NA_MEAN_MIN": if (xmlReader.Read()) NA_MEAN_MIN = int.Parse(xmlReader.Value); break;
                                    case "NA_MEAN_MAX": if (xmlReader.Read()) NA_MEAN_MAX = int.Parse(xmlReader.Value); break;

                                    case "AREA_MIN": if (xmlReader.Read()) AREA_MIN = int.Parse(xmlReader.Value); break;
                                    case "THRESHOLD_WEIGHT": if (xmlReader.Read()) THRESHOLD_WEIGHT = int.Parse(xmlReader.Value); break;

                                    case "IMAGE_ALIGN_PATH":
                                        if (xmlReader.Read()) IMAGE_ALIGN_PATH = xmlReader.Value;
                                        if (!string.IsNullOrEmpty(IMAGE_ALIGN_PATH)) ImageAlign = Cv2.ImRead(IMAGE_ALIGN_PATH); break;

                                    case "BOUNDARIES":
                                        if (xmlReader.Read())
                                        {
                                            string[] strData = xmlReader.Value.Split(':');

                                            CellBoundaries.Clear();

                                            for (int i = 0; i < strData.Length; i++)
                                            {
                                                CellBoundaries.Add(new CFormatCellBoundary(strData[i]));
                                            }
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
                IMAGE_ALIGN_PATH = Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName + "\\IMAGE_ALIGN.bmp";
                if (!IF_Util.IsImageEmpty(ImageAlign)) Cv2.ImWrite(IMAGE_ALIGN_PATH, ImageAlign);
            }
            catch (Exception Desc)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
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
                xmlWriter.WriteElementString("USE_EQUALIZE_HIST", USE_EQUALIZE_HIST.ToString());
                xmlWriter.WriteElementString("USE_CLAHE_HIST", USE_CLAHE_HIST.ToString());
                xmlWriter.WriteElementString("ROWS", ROWS.ToString());
                xmlWriter.WriteElementString("COLUMNS", COLUMNS.ToString());
                xmlWriter.WriteElementString("IMAGE_ALIGN_PATH", IMAGE_ALIGN_PATH.ToString());

                xmlWriter.WriteElementString("AREA_MIN", AREA_MIN.ToString());
                xmlWriter.WriteElementString("THRESHOLD_WEIGHT", THRESHOLD_WEIGHT.ToString());

                xmlWriter.WriteElementString("PP_MEAN_MIN", PP_MEAN_MIN.ToString());
                xmlWriter.WriteElementString("PP_MEAN_MAX", PP_MEAN_MAX.ToString());
                xmlWriter.WriteElementString("NP_MEAN_MIN", NP_MEAN_MIN.ToString());
                xmlWriter.WriteElementString("NP_MEAN_MAX", NP_MEAN_MAX.ToString());
                xmlWriter.WriteElementString("NA_MEAN_MIN", NA_MEAN_MIN.ToString());
                xmlWriter.WriteElementString("NA_MEAN_MAX", NA_MEAN_MAX.ToString());

                string strSumData = "";
                for (int i = 0; i < CellBoundaries.Count; i++)
                {
                    if (i != CellBoundaries.Count - 1)
                    {
                        strSumData += CellBoundaries[i].GetStringData() + ":";
                    }
                    else
                    {
                        strSumData += CellBoundaries[i].GetStringData();
                    }
                }

                xmlWriter.WriteElementString("BOUNDARIES", strSumData);

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

    public class CFormatCellBoundary
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("INDEX")]
        public int Index { get; set; } = 0;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("BOUNDARY")]
        public Rect Boundary { get; set; } = new Rect();

        public enum ITEM : int
        { PP, NP, NA };

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("ITEM")]
        public ITEM m_eItem { get; set; } = ITEM.PP;

        public bool Seleted { get; set; } = false;

        public CFormatCellBoundary(int nIndex, Rect rtBoundary, ITEM item)
        {
            Index = nIndex;
            Boundary = rtBoundary;
            m_eItem = item;
        }

        public CFormatCellBoundary(string strData)
        {
            SetStringData(strData);
        }

        public string GetStringData()
        {
            return $"{Index};{Boundary.X},{Boundary.Y},{Boundary.Width},{Boundary.Height};{(int)m_eItem}";
        }

        public void SetStringData(string strData)
        {
            try
            {
                string[] strItems = strData.Split(';');

                if (strItems.Length == 3)
                {
                    Index = int.Parse(strItems[0]);
                    Boundary = CConverter.StringToCVRect(strItems[1]);
                    m_eItem = (ITEM)int.Parse(strItems[2]);
                }
            }
            catch
            {
            }
        }
    }
}