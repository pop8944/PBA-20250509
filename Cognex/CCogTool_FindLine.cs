using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Display;
using System.Drawing;

namespace IntelligentFactory
{
    public class CCogTool_FindLine
    {
        const string RECIPE_Name = "Find_Line";

        public const string LineScorer_Contrast = "Contrast";
        public const string LineScorer_Position_End = "Position (From End)";
        public const string LineScorer_Position_Begin = "Position (From Begin)";

        //CogLineSegment cogSegment;
        CogGraphicCollection cogRegions;
        ICogRecord cogRecord;

        public CogLineSegment LineCul;
        public Bitmap Image_Template;
        public double CaliperProjectionLength;
        public double CaliperSearchLength;
        public string NAME { get; set; } = "";
        private CogFindLineTool m_cogTool = new CogFindLineTool();
        public CogFindLineTool Line_Tool
        {
            get { return m_cogTool; }
            set { m_cogTool = value; }
        }

        private CogFindLineResults m_cogResult = new CogFindLineResults();
        public CogFindLineResults Result
        {
            get { return m_cogResult; }
            set { m_cogResult = value; }
        }

        private CogLine m_ResultLine = new CogLine();
        public CogLine ResultLine
        {
            get { return m_ResultLine; }
        }
        //private string m_strPath = string.Empty;
        //private PointF m_ptStart = new PointF();
        //private PointF m_ptEnd = new PointF();

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

        private double m_AngleMinValue = 0.0D;
        public double AngleMinValue
        {
            get { return m_AngleMinValue; }
            set { m_AngleMinValue = value; }
        }
        private double m_AngleMaxValue = 0.0D;
        public double AngleMaxValue
        {
            get { return m_AngleMaxValue; }
            set { m_AngleMaxValue = value; }
        }
        private double m_XMinValue = 0.0D;
        public double XMinValue
        {
            get { return m_XMinValue; }
            set { m_XMinValue = value; }
        }
        private double m_XMaxValue = 0.0D;
        public double XMaxValue
        {
            get { return m_XMaxValue; }
            set { m_XMaxValue = value; }
        }
        private double m_YMinValue = 0.0D;
        public double YMinValue
        {
            get { return m_YMinValue; }
            set { m_YMinValue = value; }
        }
        private double m_YMaxValue = 0.0D;
        public double YMaxValue
        {
            get { return m_YMaxValue; }
            set { m_YMaxValue = value; }
        }
        public bool m_bUseAngle = false;
        public bool m_bUseXValue = false;
        public bool m_bUseYValue = false;
        public bool bUseAngle
        {
            get { return m_bUseAngle; }
            set { m_bUseAngle = value; }
        }
        public bool bUseXValue
        {
            get { return m_bUseXValue; }
            set { m_bUseXValue = value; }
        }
        public bool bUseYValue
        {
            get { return m_bUseYValue; }
            set { m_bUseYValue = value; }
        }

        // Find_Line 피듀셜마크 Roi
        public Rectangle Roi_Line_Search { get; set; } = new Rectangle();
        public Rectangle Roi_Line_Train { get; set; } = new Rectangle();

        public CCogTool_FindLine(string strName)
        {
            NAME = strName;
        }

        // Find Line 레시피 세이브, 로드 새로 구현..
        public void Load_Tool()
        {

        }

        public void Save_Tool()
        {

        }

        // Find Line 대한 ROI 설정
        public void ROI(CogImage8Grey img, CogDisplay cog_disp)
        {
            Line_Tool.InputImage = img;
            Line_Tool.CurrentRecordEnable = CogFindLineCurrentRecordConstants.All;

            CogLineSegment cogSegment;
            cogRecord = Line_Tool.CreateCurrentRecord();
            cogSegment = (CogLineSegment)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
            if (LineCul != null)
            {
                cogSegment.StartX = LineCul.StartX;
                cogSegment.StartY = LineCul.StartY;
                cogSegment.EndX = LineCul.EndX;
                cogSegment.EndY = LineCul.EndY;
            }
            cogRegions = (CogGraphicCollection)cogRecord.SubRecords["InputImage"].SubRecords["CaliperRegions"].Content;
            cog_disp.InteractiveGraphics.Add(cogSegment, "ExpectedShapeSegment", false);

            if (cogRegions == null) return;
            foreach (ICogGraphic g in cogRegions) cog_disp.InteractiveGraphics.Add((ICogGraphicInteractive)g, "CaliperRegions", false);
        }

        public void Data_Apply()
        {
            if (EdgePolarity == "Dark → Light") Line_Tool.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
            else Line_Tool.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;

            Line_Tool.RunParams.CaliperRunParams.SingleEdgeScorers.Clear();

            if (EdgeScorer == LineScorer_Contrast)
            {
                CogCaliperScorerContrast scorer = new CogCaliperScorerContrast();
                scorer.Enabled = true;
                Line_Tool.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
            }
            else if (EdgeScorer == LineScorer_Position_End)
            {
                CogCaliperScorerPosition scorer = new CogCaliperScorerPosition();
                scorer.Enabled = true;
                Line_Tool.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
            }
            else if (EdgeScorer == LineScorer_Position_Begin)
            {
                CogCaliperScorerPositionNeg scorer = new CogCaliperScorerPositionNeg();
                scorer.Enabled = true;
                Line_Tool.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
            }

            Line_Tool.RunParams.NumToIgnore = EdgelgnoreCount;
            Line_Tool.RunParams.NumCalipers = EdgeSamplingCount;
            Line_Tool.RunParams.CaliperRunParams.ContrastThreshold = ContrastThreshold;
            Line_Tool.RunParams.CaliperRunParams.FilterHalfSizeInPixels = EdgeThickness;
        }

        // 레시피 저장을 위한 데이터값 가져오기...
        // Json으로 데이터 값을 저장하기 위해 그려지는 드로우 위치값 뽑기..
        public void Find_DataSet(CogDisplay cogdisp)
        {
            // 데이터값을 가져오기...
            LineCul = null;

            int idx = cogdisp.InteractiveGraphics.FindItem("ExpectedShapeSegment", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
            if (idx > -1)
            {
                LineCul = (cogdisp.InteractiveGraphics[idx] as CogLineSegment);
            }

            // 캘리퍼 크기 및 서치 위치 값 처리..
            CaliperProjectionLength = Line_Tool.RunParams.CaliperProjectionLength;
            CaliperSearchLength = Line_Tool.RunParams.CaliperSearchLength;
        }

        // Line을 찾기..
        public bool Find_Run(CogImage8Grey img, CogDisplay cogdisp)
        {
            bool ret = false;

            Line_Tool.InputImage = new CogImage8Grey(img);
            Line_Tool.Run();

            if (Line_Tool.Results != null && Line_Tool.Results.Count > 0)
            {
                for (int i = 0; i < Line_Tool.Results.Count; i++)
                {
                    cogdisp.StaticGraphics.Add(Line_Tool.Results[i].CreateResultGraphics(CogFindLineResultGraphicConstants.All), "RESULT");
                }

                CogLine resultGraphic = Line_Tool.Results.GetLine();

                if (resultGraphic == null)
                {
                    CLogger.Add(LOG.INSP, "Find Line Results CogLine Error!");
                }
                else
                {
                    cogdisp.StaticGraphics.Add(resultGraphic, "resultGraphic");
                    ret = true;
                }
            }
            else
            {
                CLogger.Add(LOG.INSP, "Find Line Results Empty");
            }

            return ret;
        }

        //// Find line 레시피로드
        ////public bool LoadConfig(string modeltype, string camname)
        ////{
        ////    try
        ////    {
        ////        string _path = $"{RECIPE_PATH}\\{modeltype}\\{camname}";
        ////        string _filepath = $"{_path}\\{NAME}.vpp";
        ////        // 파일 유무 체크
        ////        Util.ConfigFile_Check(_path, _filepath);
        ////        Tool = (CogFindLineTool)CogSerializer.LoadObjectFromFile(_filepath);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Util.LogData_Q_Save($"[FAIL EX] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}  Execption => {ex.Message}", "COGNEX VISION");
        ////        return false;
        ////    }
        ////    return true;
        ////}

        ////public void SaveConfig(string modeltype, string camname)
        ////{
        ////    string _path = $"{RECIPE_PATH}\\{modeltype}\\{camname}";
        ////    string _filepath = $"{_path}\\{NAME}.vpp";

        ////    // 파일 유무 체크
        ////    // 파일 없으면 생성후 저장
        ////    Util.ConfigFile_Check(_path, _filepath);
        ////    CogSerializer.SaveObjectToFile(Tool, _filepath);
        ////}

        //public void SetInfo(CogFindLineTool Info)
        //{
        //    m_cogTool = Info;
        //}
        ///* LINE 검색 영역 설정
        // * cogROI : Line 검색 할 영역
        // * enSearchDir : 검색 방향
        // */
        //public void SetInfo(CogRectangle cogROI, ENDIRECTION enSearchDir)
        //{
        //    // ROI 영역 변경
        //    switch (enSearchDir)
        //    {
        //        case ENDIRECTION.X:
        //            {
        //                m_cogTool.RunParams.ExpectedLineSegment.StartX = cogROI.X;
        //                m_cogTool.RunParams.ExpectedLineSegment.StartY = cogROI.Y + (cogROI.Height / 2);
        //                m_cogTool.RunParams.ExpectedLineSegment.EndX = cogROI.X + cogROI.Width;
        //                m_cogTool.RunParams.ExpectedLineSegment.EndY = cogROI.Y + (cogROI.Height / 2);
        //            }
        //            break;
        //        case ENDIRECTION.Y:
        //            {
        //                m_cogTool.RunParams.ExpectedLineSegment.StartX = cogROI.X + (cogROI.Width / 2);
        //                m_cogTool.RunParams.ExpectedLineSegment.StartY = cogROI.Y;
        //                m_cogTool.RunParams.ExpectedLineSegment.EndX = cogROI.X + (cogROI.Width / 2);
        //                m_cogTool.RunParams.ExpectedLineSegment.EndY = cogROI.Y + cogROI.Height;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}
        ///* LINE 찾기 결과
        // * outLine : 찾은 선의 정보
        // * outResults : 선을 찾는데 사용한 Caliper의 정보
        // * return : 정공율
        // */
        //public float GetResult(out CogLine outLine, out CogFindLineResults outResults)
        //{
        //    outLine = m_ResultLine;
        //    outResults = m_cogResult;

        //    if (m_ResultLine == null || m_cogResult == null || m_cogTool.Results == null)
        //        return 0;

        //    int nFound = m_cogTool.Results.NumPointsFound; // 찾은 점의 개수
        //    int nNumCalipers = m_cogTool.RunParams.NumCalipers; // 찾을 점의 개수
        //    if (nNumCalipers == 0)
        //        return 0;
        //    return (float)(nFound / nNumCalipers);
        //}
        ///* 선의 시작점, 끝점 만 반환
        // */
        //public void GetResultLine(out PointF ptLineStart, out PointF ptLineEnd)
        //{
        //    ptLineStart = m_ptStart;
        //    ptLineEnd = m_ptEnd;
        //}

        //// Tool Disp 시키기
        //public void Tool_Disp(CogImage8Grey ImageSource, CogDisplay cogDisplay)
        //{
        //    cogDisplay.StaticGraphics.Clear();
        //    cogDisplay.InteractiveGraphics.Clear();

        //    if (Line_Tool.RunParams.ExpectedLineSegment.StartX > ImageSource.Width
        //        || Line_Tool.RunParams.ExpectedLineSegment.StartX < 0)
        //    {

        //    }

        //    if (Line_Tool.RunParams.ExpectedLineSegment.StartY > ImageSource.Height
        //        || Line_Tool.RunParams.ExpectedLineSegment.StartY < 0
        //        || Line_Tool.RunParams.ExpectedLineSegment.EndY > ImageSource.Height)
        //    {

        //    }

        //    if (Math.Abs(Line_Tool.RunParams.ExpectedLineSegment.StartY - Line_Tool.RunParams.ExpectedLineSegment.EndY) < 10)
        //    {
        //        //Tool.RunParams.ExpectedLineSegment.StartY = 10;
        //        //Tool.RunParams.ExpectedLineSegment.EndY = 100;
        //    }

        //    Line_Tool.InputImage = ImageSource;
        //    Line_Tool.CurrentRecordEnable = CogFindLineCurrentRecordConstants.All;

        //    cogRecord = Line_Tool.CreateCurrentRecord();
        //    cogSegment = (CogLineSegment)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
        //    cogRegions = (CogGraphicCollection)cogRecord.SubRecords["InputImage"].SubRecords["CaliperRegions"].Content;

        //    foreach (ICogGraphic g in cogRegions)
        //    {
        //        cogDisplay.InteractiveGraphics.Add((ICogGraphicInteractive)g, "CaliperRegions", false);
        //    }

        //    cogDisplay.InteractiveGraphics.Add(cogSegment, "ExpectedShapeSegment", false);
        //}

        ///* LINE 찾기 - .vpp에서 RunParam 변경없이 검색
        // * Image : 이미지
        // * fScore : 성공율
        // */
        //public bool Run(CogImage8Grey Image, float fScore)
        //{
        //    m_cogTool.InputImage = Image;
        //    // 설정값 입력은 없다.
        //    // .vpp에서 읽은 정보를 그대로 사용
        //    m_cogTool.Run();

        //    if (null != m_cogTool.Results && m_cogTool.Results.Count > 0)
        //    {
        //        if (m_cogTool.Results.GetLine() != null)
        //        {
        //            m_ResultLine = m_cogTool.Results.GetLine();

        //            // Line 정보 읽기
        //            double dblX0 = 0.0, dblY0 = 0.0, dblRotate = 0.0;
        //            m_ResultLine.GetXYRotation(out dblX0, out dblY0, out dblRotate);
        //            double dblAngle = CCogUtil.rad2deg(dblRotate);

        //            // 위에서 찾은 Line에서 임의의 X좌표에 대한 Y좌표 찾기
        //            double dblX1 = dblX0 + 1;
        //            double dblY1 = (Math.Tan(dblRotate) * (dblX1 - dblX0)) + dblY0;

        //            m_ptStart.X = (float)dblX0;
        //            m_ptStart.Y = (float)dblY0;
        //            m_ptEnd.X = (float)dblX1;
        //            m_ptEnd.Y = (float)dblY1;
        //        }
        //    }
        //    if (m_cogTool.Results == null) return false;

        //    m_cogResult = m_cogTool.Results;
        //    int nFound = m_cogTool.Results.NumPointsFound;
        //    int nNumCalipers = m_cogTool.RunParams.NumCalipers;
        //    float fRet = (float)nFound / (float)nNumCalipers;
        //    if (fRet < fScore) return false; // 설정한 정확도 보다 낮으면 실패

        //    return true;
        //}
        ///* LINE 찾기 - .vpp에서 RunParam 변경없이 검색
        // * Image : 이미지
        // * fScore : 성공율
        // * pt0, pt1 : 선의 시작점과 끝점
        // */
        //public bool FindLineProcess(CogImage8Grey Image, float fScore, out PointF ptLineStart, out PointF ptLineEnd)
        //{
        //    ptLineStart = new PointF();
        //    ptLineEnd = new PointF();
        //    m_cogTool.InputImage = Image;
        //    // 설정값 입력은 없다.
        //    // .vpp에서 읽은 정보를 그대로 사용
        //    m_cogTool.Run();

        //    if (null != m_cogTool.Results && m_cogTool.Results.Count > 0)
        //    {
        //        if (m_cogTool.Results.GetLine() != null)
        //        {
        //            m_ResultLine = m_cogTool.Results.GetLine();

        //            // Line 정보 읽기
        //            double dblX0 = 0.0, dblY0 = 0.0, dblRotate = 0.0;
        //            m_ResultLine.GetXYRotation(out dblX0, out dblY0, out dblRotate);
        //            double dblAngle = CCogUtil.rad2deg(dblRotate);

        //            // 위에서 찾은 Line에서 임의의 X좌표에 대한 Y좌표 찾기
        //            double dblX1 = dblX0 + 1;
        //            double dblY1 = (Math.Tan(dblRotate) * (dblX1 - dblX0)) + dblY0;

        //            // 결과 저장
        //            ptLineStart.X = (float)dblX0;
        //            ptLineStart.Y = (float)dblY0;
        //            ptLineEnd.X = (float)dblX1;
        //            ptLineEnd.Y = (float)dblY1;

        //            m_ptStart.X = (float)dblX0;
        //            m_ptStart.Y = (float)dblY0;
        //            m_ptEnd.X = (float)dblX1;
        //            m_ptEnd.Y = (float)dblY1;
        //        }
        //    }
        //    if (m_cogTool.Results == null) return false;

        //    m_cogResult = m_cogTool.Results;
        //    int nFound = m_cogTool.Results.NumPointsFound;
        //    int nNumCalipers = m_cogTool.RunParams.NumCalipers;
        //    if ((float)(nFound / nNumCalipers) < fScore) return false;// 설정한 정확도 보다 낮으면 실패

        //    return true;
        //}
        ///* LINE 찾기 - .vpp에서 ROI 영역만 변경하여 검색
        // * Image : 이미지
        // * fScore : 성공율
        // * cogROI : Line을 찾을 영역
        // * enSearchDir : Line찾을 방향, X방향, Y방향
        // * pt0, pt1 : 선의 시작점과 끝점
        // */
        //public bool FindLineProcess(CogImage8Grey Image, float fScore, CogRectangle cogROI, ENDIRECTION enSearchDir, out PointF ptLineStart, out PointF ptLineEnd)
        //{
        //    ptLineStart = new PointF();
        //    ptLineEnd = new PointF();
        //    // LINE 검색 영역 설정
        //    SetInfo(cogROI, enSearchDir);
        //    if (FindLineProcess(Image, fScore, out ptLineStart, out ptLineEnd) == true) return true;

        //    return false;
        //}
    }
}