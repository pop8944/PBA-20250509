using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.OCRMax;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace IntelligentFactory
{
    public class CCogTool_OCR
    {
        public string NAME { get; set; } = "";
        public string ModelCode { get; set; } = "";

        private CogOCRMaxTool m_cogOCRTool = new CogOCRMaxTool();

        public CogOCRMaxTool Tool
        {
            get => m_cogOCRTool;
            set => m_cogOCRTool = value;
        }

        //private CogOCRMaxResult m_ResultOCR = null;
        //public CogOCRMaxResult Result
        //{
        //    get => m_ResultOCR;
        //    set => m_ResultOCR = value;
        //}
        public static CogRectangleAffine Rect_Roi { get; set; } = null;

        public static CogRectangleAffine[] Train_Roi = null;

        public CogRectangleAffine Rect_Train_Region { get; set; } = null;

        public CCogTool_OCR(string strName)
        {
            NAME = strName;
            CogRectangleList = new List<CogRectangleAffine>();
        }

        public CCogTool_OCR() : this("CCogTool_OCR")
        {
        }

        public List<CogRectangleAffine> CogRectangleList
        {
            get;
            set;
        }

        public Rectangle ROI = new Rectangle();
        private string m_strPath = string.Empty;

        public bool LoadConfig(string strRecipe)
        {
            try
            {
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.vpp";
                if (CogSerializer.LoadObjectFromFile(strRecipe) is CogOCRMaxTool)
                {
                    //m_strPath = strPath;
                    Tool = CogSerializer.LoadObjectFromFile(strRecipe) as CogOCRMaxTool;
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

        public bool LoadConfig_Manual(string strPath)
        {
            try
            {
                if (CogSerializer.LoadObjectFromFile(strPath) is CogOCRMaxTool)
                {
                    m_strPath = strPath;
                    m_cogOCRTool = CogSerializer.LoadObjectFromFile(strPath) as CogOCRMaxTool;
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
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.vpp";
                CogSerializer.SaveObjectToFile(Tool, strRecipe, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void SaveConfig_Manual(string strPath)
        {
            try
            {
                CogSerializer.SaveObjectToFile(m_cogOCRTool, strPath);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void New_RectangleROI(CogDisplay Cogdisp, CogImage8Grey ImageSource)
        {
            Cogdisp.InteractiveGraphics.Clear();
            Cogdisp.StaticGraphics.Clear();

            if (Tool.Region == null)
            {
                //CogRectangleAffine roi = new CogRectangleAffine();
                //Tool.Region = roi;
                Tool.Region = new CogRectangleAffine();
            }

            if (Tool.Region is CogRectangleAffine == false)
            {
                Tool.Region = new CogRectangleAffine();
                var rectangle = Tool.Region;

                Rect_Roi = rectangle;        // 현재 ROI 기억
            }

            CogRectangleAffine cogRegion = (CogRectangleAffine)Tool.Region;
            cogRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
            cogRegion.Interactive = true;
            cogRegion.Color = CogColorConstants.Green;
            if (cogRegion.CenterX == 0 || cogRegion.CenterY == 0)
            {
                cogRegion.CenterX = 100;
                cogRegion.CenterY = 100;
            }

            Cogdisp.InteractiveGraphics.Add(cogRegion, "Roi", false);
        }

        public void New_TrainRegion(CogDisplay Cogdisp, CogImage8Grey ImageSource)
        {
            Cogdisp.InteractiveGraphics.Clear();
            Cogdisp.StaticGraphics.Clear();

            CogOCRMaxTool tmpOCR = new CogOCRMaxTool();

            if (Tool.Region != null)
            {
                Train_Roi = new CogRectangleAffine[2];
                tmpOCR.Region = new CogRectangleAffine();

                for (int i = 0; i < Train_Roi.Length; i++)
                {
                    Train_Roi[i] = tmpOCR.Region;
                    Train_Roi[i].Interactive = true;
                    Train_Roi[i].GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
                }

                Rect_Train_Region = new CogRectangleAffine();
                Rect_Train_Region = Train_Roi[0];
            }

            Cogdisp.InteractiveGraphics.Add(Train_Roi[0], "Roi", false);
        }

        public bool Font_Train(CogImage8Grey image8Grey, string TrainOCR)
        {
            try
            {
                if (Train_Roi != null)
                {
                    //Train_Roi = new CogRectangleAffine[2];

                    //for(int i = 0; i < Train_Roi.Length; i++)
                    //{
                    //    Train_Roi[i] = Tool.Region;
                    //}

                    //CogOCRMaxSegmenterPositionResult cogOCRMaxSegmenterPositionResult = segmenterPositionResult_;
                    //if (cogOCRMaxSegmenterPositionResult == null)
                    //{
                    //    throw new InvalidOperationException(CogLocalizer.GetString(typeof(CogOCRMaxResourceKeys), CogOCRMaxResourceKeys.RkGetCharacterFieldingInserted));
                    //}

                    //CogOCRMaxChar cogOCRMaxChar = new CogOCRMaxChar(cogOCRMaxSegmenterPositionResult.Character);
                    //cogOCRMaxChar.CharacterCode = CharacterCode;
                    //return cogOCRMaxChar;

                    Tool.InputImage = image8Grey;
                    CogOCRMaxSegmenterResult SegmenterResult = null;
                    try
                    {
                        SegmenterResult = Tool.Segmenter.Execute(image8Grey, Train_Roi);
                    }
                    catch (Exception ax)
                    {
                        CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ax.Message);
                        return false;
                    }

                    CogOCRMaxSegmenterLineResult SegmenterLineResult = SegmenterResult[0][0];

                    string str = TrainOCR;
                    int ic = 0;

                    foreach (CogOCRMaxSegmenterPositionResult SegmenterPositionResult in SegmenterLineResult)
                    {
                        CogOCRMaxChar aC = SegmenterPositionResult.Character;
                        aC.CharacterCode = (int)str[ic];
                        Tool.Classifier.Font.Add(aC);
                        ic++;
                    }

                    //TrainOCR.Classifier.TrainParams.Algorithm = CogOCRMaxClassifierAlgorithmConstants.Basic;
                    //TrainOCR.Classifier.TrainParams.AspectMode = CogOCRMaxClassifierAspectModeConstants.Ignore;
                    //TrainOCR.Classifier.TrainParams.ImagePreprocessing = CogOCRMaxClassifierImagePreprocessingConstants.None;

                    Tool.Classifier.Train();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ax)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ax.Message);
                return false;
            }
        }

        public bool AutoSeqment(CogImage8Grey image8Grey, string TrainOCR)
        {
            try
            {
                if (Tool.Region != null)
                {
                    Tool.InputImage = image8Grey;

                    Tool.Run();

                    string alphabetString = TrainOCR;
                    int[] alphabetCharCodes =
                      CogOCRMaxChar.GetCharCodesFromString(alphabetString);

                    //Tool.Classifier.Font.Clear();

                    //foreach (var charCode in alphabetCharCodes)
                    //{
                    //    CogOCRMaxChar c = new CogOCRMaxChar();
                    //    c.CharacterCode = charCode;
                    //    Tool.Classifier.Font.Add(c);
                    //}

                    //Tool.Classifier.Font.Clear();

                    for (int i = 0; i < Tool.LineResult.Count; i++)
                    {
                        CogOCRMaxChar c = Tool.LineResult[i].GetCharacter();
                        c.CharacterCode = alphabetCharCodes[i];
                        Tool.Classifier.Font.Add(c);
                    }

                    Tool.Classifier.Train();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ax)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ax.Message);
                return false;
            }
        }

        public (List<CogImage8Grey>, int) Font_Train(CogImage8Grey image8Grey, string TrainOCR, bool dasd)
        {
            List<CogImage8Grey> cogImage8Greys = new List<CogImage8Grey>();
            int i = 0;

            return (cogImage8Greys, i);
        }

        public void Run()
        {
        }

        public string Run(CogImage8Grey image)
        {
            CogOCRMaxLineResult cogOCRMaxPositionResults = new CogOCRMaxLineResult();
            string resultOCR = null;

            // Set the image and search region of the tool.
            Tool.InputImage = image;
            Tool.Run();
            cogOCRMaxPositionResults = Tool.LineResult;

            if (cogOCRMaxPositionResults == null)
            {
                resultOCR = " ";
            }
            else
            {
                resultOCR = cogOCRMaxPositionResults.ResultString;
            }

            return resultOCR;
        }
    }
}