using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.PMAlign;
using OpenCvSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace IntelligentFactory
{
    [Serializable]
    public class CCogTool_PMAlign
    {
        public CCogTool_PMAlign()
        {
            NAME = "";
        }

        public string NAME { get; set; } = "";

        private CogPMAlignTool m_cogPMAlignTool = new CogPMAlignTool();

        public CogPMAlignTool Tool
        {
            get => m_cogPMAlignTool;
            set => m_cogPMAlignTool = value;
        }

        private CogPMAlignResult m_ResultPMAlign = new CogPMAlignResult();

        public CogPMAlignResult Result
        {
            get { return m_ResultPMAlign; }
            set { m_ResultPMAlign = value; }
        }

        private CogPMAlignResults m_ResultsPMAlign = new CogPMAlignResults();

        public CogPMAlignResults Results
        {
            get { return m_ResultsPMAlign; }
            set { m_ResultsPMAlign = value; }
        }

        private double m_dblX = 0.0;
        private double m_dblY = 0.0;
        private double m_dblAngle = 0.0;
        private double m_dblScore = 0.0;

        public ICogImage TrainedPatternImage
        {
            get
            {
                if (m_cogPMAlignTool == null) return null;
                if (m_cogPMAlignTool.Pattern == null) return null;
                if (m_cogPMAlignTool.Pattern.Trained == false) return null;

                try
                {
                    return m_cogPMAlignTool.Pattern.GetTrainedPatternImage();
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }

                return null;
            }
        }

        public CCogTool_PMAlign(string strName)
        {
            NAME = strName;
        }

        private string m_strPath = string.Empty;

        public bool LoadConfig(string strRecipe)
        {
            string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.vpp";

            if (File.Exists(strPath))
            {
                CLogger.Add(LOG.CONFIG, $"Tool Loading Start => [{strRecipe}] : {strPath}");
                //var temp = CogSerializer.LoadObjectFromFile(strPath);
                if (CogSerializer.LoadObjectFromFile(strPath) is CogPMAlignTool)
                {
                    m_strPath = strPath;
                    m_cogPMAlignTool = CogSerializer.LoadObjectFromFile(strPath) as CogPMAlignTool;
                }
                else
                {
                    CLogger.Add(LOG.CONFIG, $"Tool Loading Fail=> [{strRecipe}] : {strPath}");
                    return false;
                }
            }
            else
            {
                CLogger.Add(LOG.ABNORMAL, $"Can't Find the File ==> {strPath}");
            }

            CLogger.Add(LOG.CONFIG, $"Tool Loading Complete=> [{strRecipe}] : {strPath}");
            return true;
        }

        public bool LoadConfig_Manual(string strPath)
        {
            try
            {
                if (CogSerializer.LoadObjectFromFile(strPath) is CogPMAlignTool)
                {
                    m_strPath = strPath;
                    m_cogPMAlignTool = CogSerializer.LoadObjectFromFile(strPath) as CogPMAlignTool;
                    m_cogPMAlignTool.RunParams.ScoreUsingClutter = false;
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
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\Array\\{NAME}.vpp";
                CogSerializer.SaveObjectToFile(m_cogPMAlignTool, strPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
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
                CogSerializer.SaveObjectToFile(m_cogPMAlignTool, strPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void GetResult(out double dblX, out double dblY, out double dblAngle, out double dblScore)
        {
            dblX = m_dblX;
            dblY = m_dblY;
            dblAngle = m_dblAngle;
            dblScore = m_dblScore;
        }

        /* Pattern 설정
         * Image : source 이미지
         * cogROI : source 이미지에서 Pattern 영역
         * outImage : Train 된 Pattern 이미지
         */

        public bool Train(CogImage8Grey Image, CogRectangleAffine cogROI, out ICogImage outImage)
        {
            outImage = null;
            try
            {
                m_cogPMAlignTool.Pattern.TrainImage = Image;

                // ROI
                m_cogPMAlignTool.Pattern.TrainRegion = cogROI;
                m_cogPMAlignTool.Pattern.Origin.TranslationX = (m_cogPMAlignTool.Pattern.TrainRegion as CogRectangleAffine).CenterX;
                m_cogPMAlignTool.Pattern.Origin.TranslationY = (m_cogPMAlignTool.Pattern.TrainRegion as CogRectangleAffine).CenterY;

                m_cogPMAlignTool.Pattern.Train();

                outImage = m_cogPMAlignTool.Pattern.GetTrainedPatternImage();

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            return false;
        }

        public async Task<ICogImage> Train(CogImage8Grey Image)
        {
            try
            {
                await Task.Delay(1);
                m_cogPMAlignTool.Pattern.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatQuick;
                m_cogPMAlignTool.Pattern.TrainImage = Image;

                // ROI
                m_cogPMAlignTool.Pattern.Origin.TranslationX = (m_cogPMAlignTool.Pattern.TrainRegion as CogRectangleAffine).CenterX;
                m_cogPMAlignTool.Pattern.Origin.TranslationY = (m_cogPMAlignTool.Pattern.TrainRegion as CogRectangleAffine).CenterY;

                m_cogPMAlignTool.Pattern.Train();

                return m_cogPMAlignTool.Pattern.GetTrainedPatternImage();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            return Image;
        }

        public async Task<bool> Train()
        {
            try
            {
                await Task.Delay(1);
                //트레인 영역의 센터를 패턴 찾은 결과로 받기 위해 Translation X/Y 를 영역의 센터로 지정해준다.
                m_cogPMAlignTool.Pattern.Origin.TranslationX = (m_cogPMAlignTool.Pattern.TrainRegion as CogRectangleAffine).CenterX;
                m_cogPMAlignTool.Pattern.Origin.TranslationY = (m_cogPMAlignTool.Pattern.TrainRegion as CogRectangleAffine).CenterY;

                m_cogPMAlignTool.Pattern.Train();

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            return false;
        }

        /* Pattern 찾기
         * Image : source 이미지
         * dblX : x방향 Pixel 위치
         * dblY : y방향 Pixel 위치
         * dblAngle : 각도 deg
         * dblScore : 정확도
         */

        public bool Run(CogImage8Grey Image, out double dblX, out double dblY, out double dblAngle, out double dblScore)
        {
            dblX = 0.0;
            dblY = 0.0;
            dblAngle = 0.0;
            dblScore = 0.0;

            try
            {
                m_cogPMAlignTool.InputImage = Image;
                //m_cogPMAlignTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.BestTrained;
                //m_cogPMAlignTool.RunParams.ApproximateNumberToFind = 1;
                //m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                //m_cogPMAlignTool.RunParams.ZoneAngle.Low = -PI;
                //m_cogPMAlignTool.RunParams.ZoneAngle.High = PI;

                m_cogPMAlignTool.Run();

                if (m_cogPMAlignTool.Results == null)
                    return false;
                if (m_cogPMAlignTool.Results.Count > 0)
                {
                    CogPMAlignTool CurrentTool = (CogPMAlignTool)m_cogPMAlignTool;
                    if (CurrentTool.RunStatus.Result == CogToolResultConstants.Error)
                    {
                        Debug.WriteLine(CurrentTool.RunStatus.Message);
                        return false;
                    }
                    else
                    {
                        //m_ResultPMAlign = CurrentTool.Results[0];
                        //dblX = m_ResultPMAlign.GetPose().TranslationX;
                        //dblY = m_ResultPMAlign.GetPose().TranslationY;
                        //dblAngle = Common.rad2deg(m_ResultPMAlign.GetPose().Rotation);
                        //dblScore = m_ResultPMAlign.Score;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            return false;
        }

        public async Task<bool> Run(CogImage8Grey Image)
        {
            try
            {
                await Task.Delay(1);

                m_cogPMAlignTool.InputImage = Image;

                //m_cogPMAlignTool.RunParams.ApproximateNumberToFind = 1;
                //m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                //m_cogPMAlignTool.RunParams.ZoneAngle.Low = -PI;
                //m_cogPMAlignTool.RunParams.ZoneAngle.High = PI;

                m_cogPMAlignTool.Run();

                if (m_cogPMAlignTool.Results == null) return false;

                if (m_cogPMAlignTool.Results.Count > 0)
                {
                    CogPMAlignTool CurrentTool = (CogPMAlignTool)m_cogPMAlignTool;
                    if (CurrentTool.RunStatus.Result == CogToolResultConstants.Error)
                    {
                        Debug.WriteLine(CurrentTool.RunStatus.Message);
                        return false;
                    }
                    else
                    {
                        m_ResultsPMAlign = CurrentTool.Results;
                        //m_dblX = m_ResultPMAlign.GetPose().TranslationX;
                        //m_dblY = m_ResultPMAlign.GetPose().TranslationY;
                        //m_dblAngle = Common.rad2deg(m_ResultPMAlign.GetPose().Rotation);
                        //m_dblScore = m_ResultPMAlign.Score;
                    }
                }
                else
                {
                    m_ResultsPMAlign = null;
                }

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            return false;
        }

        public async Task<CogDisplay> Draw(CogDisplay cogDisplay, CogRectangleAffine cogROI)
        {
            try
            {
                await Task.Delay(1);

                if (Result == null) { return cogDisplay; }

                cogDisplay.StaticGraphics.Add((ICogGraphicInteractive)cogROI, "ROI");
                cogDisplay.InteractiveGraphics.Add(Result.CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                cogDisplay.InteractiveGraphics.Add(Result.CreateResultGraphics(CogPMAlignResultGraphicConstants.TipText), "main", false);
                cogDisplay.InteractiveGraphics.Add(Result.CreateResultGraphics(CogPMAlignResultGraphicConstants.All), "main", false);

                return cogDisplay;
            }
            catch (CogException Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                return cogDisplay;
            }
        }
    }

    public class CResultMatching
    {
        public int Index { get; set; } = 0;
        public double Score { get; set; } = 0.0D;
        public double Angle { get; set; } = 0.0D;
        public Point2d Center { get; set; } = new Point2d();
        public Rect Bounding { get; set; } = new Rect();

        public CResultMatching(int nIndex, double dScore, Point2d ptCenter, Rect rt, double dAngle = 0.0D)
        {
            Index = nIndex;
            Score = dScore;
            Center = ptCenter;
            Bounding = new Rect(rt.X, rt.Y, rt.Width, rt.Height);
            Angle = dAngle;
        }
    }
}