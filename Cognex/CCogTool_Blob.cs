using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace IntelligentFactory
{
    public class CCogTool_Blob
    {
        public string NAME { get; set; } = "";
        private CogBlobTool m_cogTool = new CogBlobTool();

        public CogBlobTool Tool
        {
            get => m_cogTool;
            set => m_cogTool = value;
        }

        public static CogRectangle Rect_Roi { get; set; } = null;

        private CogBlobResults m_cogResult = new CogBlobResults();

        public CogBlobResults Result
        {
            get => m_cogResult;
            set => m_cogResult = value;
        }

        public CCogTool_Blob() : this("CCogTool_Blob")
        {
        }

        public CCogTool_Blob(string strName)
        {
            NAME = strName;
            CenterXs = new List<double>();
            CenterYs = new List<double>();
            Areas = new List<double>();
            CogRectangleList = new List<CogRectangleAffine>();
            MinArea = 20;
        }

        private List<double> m_CenterXs = new List<double>();

        public List<double> CenterXs
        {
            get;
            set;
        }

        private List<double> m_CenterYs = new List<double>();

        public List<double> CenterYs
        {
            get;
            set;
        }

        private List<double> m_Areas = new List<double>();

        public List<double> Areas
        {
            get;
            set;
        }

        private List<CogRectangleAffine> m_CogRt = new List<CogRectangleAffine>();

        public List<CogRectangleAffine> CogRectangleList
        {
            get;
            set;
        }

        private int m_nMinArea = 20;

        public int MinArea
        {
            get => m_nMinArea;
            set => m_nMinArea = value;
        }

        public Rectangle ROI = new Rectangle();

        public bool LoadConfig(string strRecipe)
        {
            try
            {
                if (CogSerializer.LoadObjectFromFile(strRecipe) is CogBlobTool)
                {
                    Tool = CogSerializer.LoadObjectFromFile(strRecipe) as CogBlobTool;
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
                //CogSerializer.SaveObjectToFile(Tool, strRecipe);
                CogSerializer.SaveObjectToFile(Tool, strRecipe, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        #region CONFIG BY XML

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
                                        MinArea = int.Parse(xmlReader.Value);
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
                xmlWriter.WriteElementString("MinArea", MinArea.ToString());

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

        public bool SetParameter()
        {
            try
            {
                return true;
            }
            catch (CogException Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return false;
            }
        }

        public void New_RectangleROI(CogDisplay Cogdisp, CogImage8Grey ImageSource)
        {
            Cogdisp.InteractiveGraphics.Clear();
            Cogdisp.StaticGraphics.Clear();

            if (Tool.Region == null)
            {
                CogRectangle roi = new CogRectangle();
                Tool.Region = roi;
            }

            if (Tool.Region is CogRectangle)
            {
                var rectangle = Tool.Region as CogRectangle;
                Rect_Roi = rectangle;        // 현재 ROI 기억
            }

            (Tool.Region as CogRectangle).GraphicDOFEnable = CogRectangleDOFConstants.All;
            (Tool.Region as CogRectangle).Interactive = true;

            Cogdisp.InteractiveGraphics.Add((CogRectangle)Tool.Region, "Roi", false);
        }

        public bool Run(CogImage8Grey imgSource, int threshold, int Range_min, int Range_max)
        {
            if (Tool == null)
            {
                return false;
            }

            if (imgSource == null || !imgSource.Allocated)
            {
                return false;
            }

            // 퀵빌더에 있는 블랍 화면의 측정탭에 있는 내용부분 추가
            // 영역의 측정 : 필터
            // 범위 : 포함
            // 하위값, 상위값 설정
            CogBlobMeasure cogBlobMeasure = new CogBlobMeasure(CogBlobMeasureConstants.Area, CogBlobMeasureModeConstants.Filter,
                                                                CogBlobFilterModeConstants.IncludeBlobsInRange, Range_min, Range_max);
            if (Tool.RunParams.RunTimeMeasures.Count > 0)
            {
                Tool.RunParams.RunTimeMeasures[0] = cogBlobMeasure;
            }

            Tool.InputImage = imgSource;
            Tool.RunParams.ConnectivityMinPixels = Range_min;
            Tool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
            Tool.RunParams.SegmentationParams.HardFixedThreshold = threshold;
            Tool.Run();

            cogBlobMeasure.Dispose();
            return true;
        }

        public async Task<bool> Run(CogImage8Grey cogImage, CogRectangle cogROI)
        {
            try
            {
                await Task.Delay(1);

                if (cogImage == null)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1} // Input Image is Empty", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    return false;
                }

                ClearData();

                Tool.Region = cogROI;
                Tool.InputImage = cogImage;

                if (Tool.InputImage == null)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1} // Input Image is Empty", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    return false;
                }

                if (Tool.Region == null)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1} // ROI is Empty", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    return false;
                }

                Tool.Run();

                Result = Tool.Results;

                (CenterXs, CenterYs, Areas, CogRectangleList) = GetBlob();

                return true;
            }
            catch (CogException Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return false;
            }
        }

        public async Task<CogDisplay> Draw(CogDisplay cogDisplay)
        {
            try
            {
                await Task.Delay(1);

                if (Result == null) { return cogDisplay; }

                CogGraphicInteractiveCollection cogList = new CogGraphicInteractiveCollection();

                for (int i = 0; i < Result.GetBlobs().Count; i++)
                {
                    cogDisplay.StaticGraphics.Add(Result.GetBlobs()[i].GetBoundingBox(CogBlobAxisConstants.PixelAligned), "11");
                    cogDisplay.StaticGraphics.Add(Result.GetBlobs()[i].CreateResultGraphics(CogBlobResultGraphicConstants.Boundary), "test");

                    CogGraphicLabel lbBlob = new CogGraphicLabel();
                    lbBlob.Color = CogColorConstants.Green;

                    //Set X-position to 100
                    lbBlob.X = Result.GetBlobs()[i].CenterOfMassX;
                    lbBlob.Y = Result.GetBlobs()[i].CenterOfMassY;

                    double dDiameter = Result.GetBlobs()[i].Area * DEFINE.PIXEL_RESOLUTION_MM;
                    string strText = string.Format("No : {0}, Diameter : {1}", (i + 1), dDiameter.ToString("F2") + "mm");

                    lbBlob.Text = strText;
                    lbBlob.Font = new Font("arial", 11);
                    cogList.Add(lbBlob);
                }

                cogDisplay.InteractiveGraphics.AddList(cogList, "RESULT", false);

                return cogDisplay;
            }
            catch (CogException Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return cogDisplay;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public (List<double>, List<double>, List<double>, List<CogRectangleAffine>) GetBlob()
        {
            try
            {
                List<double> CenterXs = new List<double>();
                List<double> CenterYs = new List<double>();
                List<double> Areas = new List<double>();
                List<CogRectangleAffine> CogRt = new List<CogRectangleAffine>();
                if (Result == null) { return (new List<double>(), new List<double>(), new List<double>(), new List<CogRectangleAffine>()); }

                for (int i = 0; i < Result.GetBlobs().Count; i++)
                {
                    CenterXs.Add(Math.Round(Result.GetBlobs()[i].CenterOfMassX, 1));
                    CenterYs.Add(Math.Round(Result.GetBlobs()[i].CenterOfMassY, 1));
                    Areas.Add(Result.GetBlobs()[i].Area);
                    CogRt.Add(Result.GetBlobs()[i].GetBoundingBox(CogBlobAxisConstants.PixelAligned));
                }
                return (CenterXs, CenterYs, Areas, CogRt);
            }
            catch (CogException Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return (new List<double>(), new List<double>(), new List<double>(), new List<CogRectangleAffine>());
            }
        }

        private bool ClearData()
        {
            try
            {
                CenterXs.Clear();
                CenterYs.Clear();
                Areas.Clear();
                CogRectangleList.Clear();
                return true;
            }
            catch (CogException Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return false;
            }
        }

        public CogImage8Grey RunThreshold(CogImage8Grey imgSource, bool viewable, int nThreshold)
        {
            CogImage8Grey _ret_ThresholdIMG = new CogImage8Grey();

            Tool.InputImage = imgSource;
            Tool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
            Tool.RunParams.SegmentationParams.HardFixedThreshold = nThreshold;
            BlobRun();

            _ret_ThresholdIMG = Tool.Results.CreateBlobImage(viewable, viewable, 255);
            return _ret_ThresholdIMG;
        }

        public bool BlobRun()
        {
            if (Tool == null)
            {
                IF_Util.ShowMessageBox("Notice", "Blob Tool is Empty");
                return false;
            }

            if (Tool.InputImage == null)
            {
                IF_Util.ShowMessageBox("Notice", "Blob Tool Source Image is Empty");
                return false;
            }

            Tool.Run();

            return true;
        }
    }
}