using Cognex.VisionPro;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.ImageProcessing;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace IntelligentFactory
{
    public class CCogTool_MorphologyNxM
    {
        public string NAME { get; set; } = "";
        private CogIPOneImageGreyMorphologyNxM m_cogTool = new CogIPOneImageGreyMorphologyNxM();

        public CogIPOneImageGreyMorphologyNxM Tool
        {
            get => m_cogTool;
            set => m_cogTool = value;
        }

        public CCogTool_MorphologyNxM() : this("CCogTool_MorphologyNxM")
        {
        }

        public CCogTool_MorphologyNxM(string strName)
        {
            NAME = strName;
            Tool = new CogIPOneImageGreyMorphologyNxM();
        }

        public async Task<ICogImage> Run(CogImage8Grey cogImage, CogRectangle cogROI, int nKernelWidth, int nKernelHeight, CogIPOneImageMorphologyOperationConstants Operator)
        {
            ICogImage Image = cogImage;

            try
            {
                await Task.Delay(1);

                Tool.KernelWidth = nKernelWidth;
                Tool.KernelHeight = nKernelHeight;
                Tool.Operation = Operator;

                return Tool.Execute(cogImage, CogRegionModeConstants.PixelAlignedBoundingBox, cogROI); ;
            }
            catch (CogException Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return Image;
            }
        }

        #region CONFIG BY XML

        public bool LoadConfig(string strRecipe)
        {
            try
            {
                LoadConfigXML(strRecipe);
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.vpp";
                if (CogSerializer.LoadObjectFromFile(strPath) is CogIPOneImageGreyMorphologyNxM)
                {
                    Tool = CogSerializer.LoadObjectFromFile(strPath) as CogIPOneImageGreyMorphologyNxM;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            return true;
        }

        public void SaveConfig(string strRecipe)
        {
            try
            {
                SaveConfigXML(strRecipe);
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.vpp";
                CogSerializer.SaveObjectToFile(Tool, strPath);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private string m_XMLName = "PROPERTY_LINEGUAGE";

        public bool LoadConfigXML(string strRecipe)
        {
            try
            {
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.xml";

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
                                    case "MinArea":
                                        if (!xmlReader.Read()) return false;
                                        // MinArea = int.Parse(xmlReader.Value);
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
                    catch (Exception Desc)
                    {
                        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                        xmlReader.Close();
                    }

                    xmlReader.Close();
                }
                else
                {
                    SaveConfigXML(strRecipe);
                    return false;
                }
            }
            catch (Exception Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return false;
            }
            return true;
        }

        public bool SaveConfigXML(string strRecipe)
        {
            string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.xml";

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
                //xmlWriter.WriteElementString("MinArea", MinArea.ToString());

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
            catch (Exception Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
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