using Cognex.VisionPro;
using Cognex.VisionPro.ColorExtractor;
using Cognex.VisionPro.ColorMatch;
using Cognex.VisionPro.Display;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace IntelligentFactory
{
    public class CCogTool_ColorMatch
    {
        public string NAME { get; set; } = "";
        private CogColorMatchTool m_cogTool = new CogColorMatchTool();

        public CogColorPicker m_CogColorPicker;

        private CogColorExtractorTool m_CogColorExtractorTool = new CogColorExtractorTool();

        public CogColorMatchTool Tool
        {
            get => m_cogTool;
            set => m_cogTool = value;
        }

        public static CogRectangle Rect_Roi { get; set; } = null;

        public CogRectangle Rect_Extrac_Roi { get; set; } = null;

        //private CogColorMatchResult m_cogResult = new CogColorMatchResult();
        //public CogColorMatchResult Result
        //{
        //    get => m_cogResult;
        //    set => m_cogResult = value;
        //}

        public CogColorMatchResult Result;

        public CCogTool_ColorMatch() : this("CCogTool_ColorMatch")
        {
        }

        public CCogTool_ColorMatch(string strName)
        {
            NAME = strName;
            //CenterXs = new List<double>();
            //CenterYs = new List<double>();
            //Areas = new List<double>();
            CogRectangleList = new List<CogRectangleAffine>();
            //MinArea = 20;

            COLOR = new List<Color>();
            RGB_R = new List<double>();
            RGB_G = new List<double>();
            RGB_B = new List<double>();
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

        private List<Color> m_COLOR = new List<Color>();

        public List<Color> COLOR
        {
            get => m_COLOR;
            set => m_COLOR = value;
        }

        private List<double> m_RGB_R = new List<double>();

        public List<double> RGB_R
        {
            get => m_RGB_R;
            set => m_RGB_R = value;
        }

        private List<double> m_RGB_G = new List<double>();

        public List<double> RGB_G
        {
            get => m_RGB_G;
            set => m_RGB_G = value;
        }

        private List<double> m_RGB_B = new List<double>();

        public List<double> RGB_B
        {
            get => m_RGB_B;
            set => m_RGB_B = value;
        }

        public Rectangle ROI = new Rectangle();
        public Rectangle Extract_ROI = new Rectangle();

        public bool LoadConfig(string strRecipe)
        {
            try
            {
                if (CogSerializer.LoadObjectFromFile(strRecipe) is CogColorMatchTool)
                {
                    Tool = CogSerializer.LoadObjectFromFile(strRecipe) as CogColorMatchTool;
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

        public void New_RectangleROI(CogDisplay Cogdisp, CogImage24PlanarColor ImageSource)
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

        public void New_ExtractROI(CogDisplay Cogdisp, CogImage24PlanarColor ImageSource)
        {
            Cogdisp.InteractiveGraphics.Clear();
            Cogdisp.StaticGraphics.Clear();

            CogRectangle roi = new CogRectangle();

            Rect_Extrac_Roi = roi;

            Rect_Extrac_Roi.GraphicDOFEnable = CogRectangleDOFConstants.All;
            Rect_Extrac_Roi.Interactive = true;

            Cogdisp.InteractiveGraphics.Add(Rect_Extrac_Roi, "Roi", false);
        }

        public Color Color_Extract(Bitmap bitmap, CogRectangle Rect)
        {
            Color tmpColor = new Color();

            tmpColor = bitmap.GetPixel(Convert.ToInt32(Rect.CenterX), Convert.ToInt32(Rect.CenterY));

            return tmpColor;
        }

        public CogSimpleColorCollection Color_Collection(List<Color> color)
        {
            CogSimpleColorCollection collection = new CogSimpleColorCollection();
            CogSimpleColorItem cogSimpleColor = new CogSimpleColorItem(CogImageColorSpaceConstants.RGB);

            for (int i = 0; i < color.Count; i++)
            {
                cogSimpleColor.Plane0 = color[i].R;
                cogSimpleColor.Plane1 = color[i].G;
                cogSimpleColor.Plane2 = color[i].B;
                collection.Add(cogSimpleColor);
            }

            return collection;
        }

        //public bool Run(CogImage24PlanarColor img, ICogRegion cogRegion, CogSimpleColorCollection collection)
        //{
        //    Tool.Region = cogRegion;
        //    Tool.RunParams.ColorCollection = collection;
        //    Tool.RunParams.MatchScoreMetricType = CogColorMatchScoreMetricTypeConstants.WeightedEuclideanDistanceInRGBColorSpace;
        //    Tool.InputImage = img;
        //    Tool.Run();
        //    //Tool.RunParams.Execute()
        //    return true;
        //}
        public CogColorMatchResultSet Run(CogImage24PlanarColor img, ICogRegion cogRegion, CogSimpleColorCollection collection)
        {
            Tool.Region = cogRegion;
            Tool.RunParams.ColorCollection = collection;
            Tool.RunParams.MatchScoreMetricType = CogColorMatchScoreMetricTypeConstants.WeightedEuclideanDistanceInRGBColorSpace;
            Tool.InputImage = img;
            CogColorMatchResultSet resultset = Tool.RunParams.Execute(img, cogRegion);

            return resultset;
        }
    }
}