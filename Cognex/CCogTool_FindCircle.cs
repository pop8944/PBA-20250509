using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Display;

namespace IntelligentFactory
{
    public class CCogTool_FindCircle
    {
        const string Recipe_Name = "Find_Circle";

        public const string EdgeScorer_Contrast = "Contrast";
        public const string EdgeScorer_Position_End = "Position (From End)";
        public const string EdgeScorer_Position_Begin = "Position (From Begin)";

        public CogGraphicCollection cogRegions;
        public ICogRecord cogRecord;

        public CogCircularArc Circul;
        public double CaliperProjectionLength;
        public double CaliperSearchLength;

        // 극성 방향 설정
        public bool Condensor_Type = true;         // true : T to B, FALSE : L to R

        public string NAME { get; set; } = "";
        private CogFindCircleTool m_cogTool = new CogFindCircleTool();
        public CogFindCircleTool Circle_Tool
        {
            get { return m_cogTool; }
            set { m_cogTool = value; }
        }

        private CogFindCircleResults m_cogResult = new CogFindCircleResults();
        public CogFindCircleResults Result
        {
            get { return m_cogResult; }
            set { m_cogResult = value; }
        }

        private string m_EdgeScorer = "";
        public string EdgeScorer
        {
            get { return m_EdgeScorer; }
            set { m_EdgeScorer = value; }
        }

        // 캘리퍼 갯수..
        private int m_EdgeSamplingCount = 0;
        public int EdgeSamplingCount
        {
            get { return m_EdgeSamplingCount; }
            set { m_EdgeSamplingCount = value; }
        }
        // 굵기...
        private int m_EdgeThickness = 0;
        public int EdgeThickness
        {
            get { return m_EdgeThickness; }
            set { m_EdgeThickness = value; }
        }

        private int m_IgnoreCount = 0;
        public int EdgelgnoreCount
        {
            get { return m_IgnoreCount; }
            set { m_IgnoreCount = value; }
        }

        // 쓰레쉬 홀드...
        private double m_EdgeContrast = 0.0D;
        public double ContrastThreshold
        {
            get { return m_EdgeContrast; }
            set { m_EdgeContrast = value; }
        }

        private string m_EdgePolarity = "";
        public string EdgePolarity
        {
            get { return m_EdgePolarity; }
            set { m_EdgePolarity = value; }
        }
        private int m_RectWidth = 0;
        public int RectWidth
        {
            get { return m_RectWidth; }
            set { m_RectWidth = value; }
        }
        private int m_RectHeight = 0;
        public int RectHeight
        {
            get { return m_RectHeight; }
            set { m_RectHeight = value; }
        }
        public CCogTool_FindCircle(string name)
        {
            NAME = name;
        }

        public void Load_Tool(string _path)
        {

        }

        public void Save_Tool(string _path)
        {

        }

        // Circle에 대한 ROI 설정
        public void ROI(CogImage8Grey img, CogDisplay cog_disp)
        {
            Circle_Tool.InputImage = img;
            Circle_Tool.CurrentRecordEnable = CogFindCircleCurrentRecordConstants.All;

            CogCircularArc cogSegment;
            cogRecord = Circle_Tool.CreateCurrentRecord();
            cogSegment = (CogCircularArc)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
            cogRegions = (CogGraphicCollection)cogRecord.SubRecords["InputImage"].SubRecords["CaliperRegions"].Content;

            cog_disp.InteractiveGraphics.Add(cogSegment, "ExpectedShapeSegment", false);

            if (cogRegions == null) return;

            foreach (ICogGraphic g in cogRegions)
            {
                cog_disp.InteractiveGraphics.Add((ICogGraphicInteractive)g, "CaliperRegions", false);
            }
        }

        public void Data_Apply()
        {
            if (EdgePolarity == "Dark → Light") Circle_Tool.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
            else Circle_Tool.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;

            Circle_Tool.RunParams.CaliperRunParams.SingleEdgeScorers.Clear();

            if (EdgeScorer == EdgeScorer_Contrast)
            {
                CogCaliperScorerContrast scorer = new CogCaliperScorerContrast();
                scorer.Enabled = true;
                Circle_Tool.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
            }
            else if (EdgeScorer == EdgeScorer_Position_End)
            {
                CogCaliperScorerPosition scorer = new CogCaliperScorerPosition();
                scorer.Enabled = true;
                Circle_Tool.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
            }
            else if (EdgeScorer == EdgeScorer_Position_Begin)
            {
                CogCaliperScorerPositionNeg scorer = new CogCaliperScorerPositionNeg();
                scorer.Enabled = true;
                Circle_Tool.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
            }

            Circle_Tool.RunParams.NumToIgnore = EdgelgnoreCount;
            Circle_Tool.RunParams.NumCalipers = EdgeSamplingCount;
            Circle_Tool.RunParams.CaliperRunParams.ContrastThreshold = ContrastThreshold;
            Circle_Tool.RunParams.CaliperRunParams.FilterHalfSizeInPixels = EdgeThickness;
        }

        // 레시피 저장을 위한 데이터값 가져오기...
        // Json으로 데이터 값을 저장하기 위해 그려지는 드로우 위치값 뽑기..
        public void Find_DataSet(CogDisplay cogdisp)
        {
            // 데이터값을 가져오기...
            Circul = null;

            int idx = cogdisp.InteractiveGraphics.FindItem("ExpectedShapeSegment", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
            if (idx > -1)
            {
                Circul = (cogdisp.InteractiveGraphics[idx] as CogCircularArc);
            }

            // 캘리퍼 크기 및 서치 위치 값 처리..
            CaliperProjectionLength = Circle_Tool.RunParams.CaliperProjectionLength;
            CaliperSearchLength = Circle_Tool.RunParams.CaliperSearchLength;
        }

        // Circle을 찾기..
        public bool Find_Run(CogImage8Grey img, CogDisplay cogdisp)
        {
            bool ret = false;

            Circle_Tool.InputImage = new CogImage8Grey(img);
            Circle_Tool.Run();

            if (Circle_Tool.Results != null && Circle_Tool.Results.Count > 0)
            {
                for (int i = 0; i < Circle_Tool.Results.Count; i++)
                {
                    cogdisp.StaticGraphics.Add(Circle_Tool.Results[i].CreateResultGraphics(CogFindCircleResultGraphicConstants.All), "RESULT");
                }

                CogCircle resultGraphic = Circle_Tool.Results.GetCircle();

                if (resultGraphic == null)
                {
                    CLogger.Add(LOG.INSP, "Find Circle Results CogCircle Error!");
                }
                else
                {
                    cogdisp.StaticGraphics.Add(resultGraphic, "resultGraphic");
                    ret = true;
                }
            }
            else
            {
                CLogger.Add(LOG.INSP, "Find Circle Results Empty");
            }

            return ret;
        }

    }
}
