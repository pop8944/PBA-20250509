using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.PMAlign;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace IntelligentFactory
{
    public class VisionTools
    {
        private const int maxBoard = 4;
        private const int maxSub = 3;

        public List<List<CCogTool_PMAlign>> PMSubAlignLT = new List<List<CCogTool_PMAlign>>();
        public List<List<CCogTool_PMAlign>> PMSubAlignRB = new List<List<CCogTool_PMAlign>>();
        public List<CogRectangle> PMSubAlign = new List<CogRectangle>();
        public List<string> PMSubAlignName = new List<string>();
        public List<List<AlignData>> alignDatas = new List<List<AlignData>>();

        public bool Init(string recipeName)
        {
            try
            {
                for (int i = 0; i < maxBoard; i++)
                {
                    PMSubAlignLT.Add(new List<CCogTool_PMAlign>());
                    PMSubAlignRB.Add(new List<CCogTool_PMAlign>());
                    PMSubAlign.Add(new CogRectangle());
                    PMSubAlignName.Add("PMSubAlign" + i.ToString());
                    alignDatas.Add(new List<AlignData>());
                    for (int j = 0; j < maxSub; j++)
                    {
                        PMSubAlignLT[i].Add(new CCogTool_PMAlign("PMSubAlignLT" + i.ToString() + "_" + j.ToString()));
                        PMSubAlignRB[i].Add(new CCogTool_PMAlign("PMSubAlignRB" + i.ToString() + "_" + j.ToString()));
                        alignDatas[i].Add(new AlignData());
                    }
                }
                Load(recipeName);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            return true;
        }

        public void SaveRect(string recipeName, CogRectangle rect, string NAME)
        {
            try
            {
                string excutePath = Util.GetExcutePath();
                string strPath = $"{excutePath}\\RECIPE\\{recipeName}\\{NAME}.vpp";
                CogSerializer.SaveObjectToFile(rect, strPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public CogRectangle LoadRect(string recipeName, string NAME)
        {
            try
            {
                string excutePath = Util.GetExcutePath();
                string strPath = $"{excutePath}\\RECIPE\\{recipeName}\\{NAME}.vpp";

                if (File.Exists(strPath))
                {
                    CLogger.Add(LOG.CONFIG, $"Tool Loading Start => [{recipeName}] : {strPath}");
                    var temp = CogSerializer.LoadObjectFromFile(strPath);
                    if (CogSerializer.LoadObjectFromFile(strPath) is CogRectangle)
                    {
                        //CLogger.Add(LOG_TYPE.CONFIG, $"Tool Loading Complete=> [{recipeName}] : {strPath}");
                        return CogSerializer.LoadObjectFromFile(strPath) as CogRectangle;
                    }
                    else
                    {
                        CLogger.Add(LOG.CONFIG, $"Tool Loading Fail=> [{recipeName}] : {strPath}");
                        return null;
                    }
                }
                else
                {
                    CLogger.Add(LOG.ABNORMAL, $"Can't Find the File ==> {strPath}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        public bool Save(string recipeName)
        {
            try
            {
                for (int i = 0; i < maxBoard; i++)
                {
                    SaveRect(recipeName, PMSubAlign[i], PMSubAlignName[i]);
                    for (int j = 0; j < maxSub; j++)
                    {
                        PMSubAlignLT[i][j].SaveConfig(recipeName);
                        PMSubAlignRB[i][j].SaveConfig(recipeName);
                        alignDatas[i][j].SaveConfig(recipeName, PMSubAlignName[i] + "_" + j.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        public bool Load(string recipeName)
        {
            try
            {
                for (int i = 0; i < maxBoard; i++)
                {
                    CogRectangle rect = LoadRect(recipeName, PMSubAlignName[i]);
                    if (rect != null)
                        PMSubAlign[i] = rect;
                    for (int j = 0; j < maxSub; j++)
                    {
                        PMSubAlignLT[i][j].LoadConfig(recipeName);
                        PMSubAlignRB[i][j].LoadConfig(recipeName);
                        alignDatas[i][j] = alignDatas[i][j].LoadConfig(recipeName, PMSubAlignName[i] + "_" + j.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        public void DrawAll(CogDisplay display, int boardNo, int subNo, CogImage8Grey image)
        {
            DrawBoardArea(PMSubAlign[boardNo], display, image);
            DrawRegions(true, PMSubAlignLT[boardNo][subNo], display, image);
            DrawRegions(false, PMSubAlignRB[boardNo][subNo], display, image);
        }

        public void DrawBoardArea(CogRectangle rect, CogDisplay display, CogImage8Grey greyImg, bool isClear = true)
        {
            if (isClear)
            {
                display.InteractiveGraphics.Clear();
                display.StaticGraphics.Clear();
            }
            Cognex.VisionPro.CogColorConstants drawAll = Cognex.VisionPro.CogColorConstants.Yellow;

            if (rect.X == 20 && rect.Y == 20 && rect.Width == 100 && rect.Height == 100)
            {
                rect.FitToImage(greyImg, 1.0D, 1.0D);
            }

            rect.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
            rect.Interactive = true;
            rect.SelectedColor = drawAll;
            rect.DragColor = drawAll;
            rect.Color = drawAll;
            rect.LineWidthInScreenPixels = 3;

            display.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)rect, "AllArea", false);
        }

        private void DrawRegions(bool isLT, CCogTool_PMAlign PMAlign, CogDisplay display, CogImage8Grey greyImg, bool isClear = false)
        {
            try
            {
                if (PMAlign == null) return;

                PMAlign.Tool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatMax;
                PMAlign.Tool.RunParams.AcceptThreshold = 0.4;
                PMAlign.Tool.RunParams.ScoreUsingClutter = false;

                if (isClear)
                {
                    display.InteractiveGraphics.Clear();
                    display.StaticGraphics.Clear();
                }

                Cognex.VisionPro.CogColorConstants drawSearch = Cognex.VisionPro.CogColorConstants.Orange;
                Cognex.VisionPro.CogColorConstants drawPattern = Cognex.VisionPro.CogColorConstants.Cyan;
                if (isLT)
                {
                    drawSearch = Cognex.VisionPro.CogColorConstants.Red;
                    drawPattern = Cognex.VisionPro.CogColorConstants.Blue;
                }

                if (PMAlign.Tool.SearchRegion == null)
                {
                    PMAlign.Tool.SearchRegion = new Cognex.VisionPro.CogRectangle();
                    PMAlign.Tool.SearchRegion.FitToImage(greyImg, 1.0D, 1.0D);
                }
                Cognex.VisionPro.CogRectangle cogSearchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion;

                cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                cogSearchRegion.Interactive = true;
                cogSearchRegion.SelectedColor = drawSearch;
                cogSearchRegion.DragColor = drawSearch;
                cogSearchRegion.Color = drawSearch;
                cogSearchRegion.LineWidthInScreenPixels = 3;

                display.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);

                //패턴 영역
                PMAlign.Tool.Pattern.TrainRegionMode = Cognex.VisionPro.CogRegionModeConstants.PixelAlignedBoundingBox;
                if (PMAlign.Tool.Pattern.TrainRegion == null) PMAlign.Tool.Pattern.TrainRegion = new Cognex.VisionPro.CogRectangle();
                if ((PMAlign.Tool.Pattern.TrainRegion is Cognex.VisionPro.CogRectangle) == false) PMAlign.Tool.Pattern.TrainRegion = new Cognex.VisionPro.CogRectangle();

                Cognex.VisionPro.CogRectangle cogTrainRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.Pattern.TrainRegion;

                cogTrainRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                cogTrainRegion.Interactive = true;
                cogTrainRegion.SelectedColor = drawPattern;
                cogTrainRegion.DragColor = drawPattern;
                cogTrainRegion.Color = drawPattern;
                cogTrainRegion.LineWidthInScreenPixels = 3;

                if (cogTrainRegion.Width == 0) cogTrainRegion.Width = 250;
                if (cogTrainRegion.Height == 0) cogTrainRegion.Height = 250;

                display.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogTrainRegion, "Pattern", false);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        // 필히 수정
        public void CutRoi(CogDisplay display, int boardNo, ref CogImage8Grey greyImg, ref CogImage24PlanarColor colorImg, string recipeName)
        {
            try
            {
                CCogTool_PMAlign PMAlign = null;

                if (PMAlign == null) return;

                PMAlign.Tool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatMax;
                PMAlign.Tool.RunParams.AcceptThreshold = 0.4;
                PMAlign.Tool.RunParams.ScoreUsingClutter = false;

                display.InteractiveGraphics.Clear();
                display.StaticGraphics.Clear();

                PMAlign.Tool.InputImage = greyImg;
                PMAlign.Tool.Run();

                CogPMAlignResult result = null;
                double dMaxScore = 0.0D;

                if (PMAlign.Tool.Results == null)
                {
                    CLogger.Add(LOG.ABNORMAL, "Check the Image or dongle Key, Can't cut Roi");
                    return;
                }
                for (int i = 0; i < PMAlign.Tool.Results.Count; i++)
                {
                    if (dMaxScore < PMAlign.Tool.Results[i].Score)
                    {
                        dMaxScore = PMAlign.Tool.Results[i].Score;
                        result = PMAlign.Tool.Results[i];
                    }
                }

                if (result == null)
                {
                    CLogger.Add(LOG.ABNORMAL, "Can't Find the Board Pattern");
                    return;
                }

                colorImg = new Cognex.VisionPro.CogImage24PlanarColor(cropImage(colorImg.ToBitmap(), new Rectangle((int)result.GetPose().TranslationX, (int)result.GetPose().TranslationY, PMAlign.TrainedPatternImage.Width, PMAlign.TrainedPatternImage.Height)));
                greyImg = new Cognex.VisionPro.CogImage8Grey(cropImage(greyImg.ToBitmap(), new Rectangle((int)result.GetPose().TranslationX, (int)result.GetPose().TranslationY, PMAlign.TrainedPatternImage.Width, PMAlign.TrainedPatternImage.Height)));

                display.Image = colorImg;
                display.Fit(true);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        //public void AlignProcess(CogPMAlignResult LT, Point2d originLT, Point2d inflateLT, CogPMAlignResult RB, Point2d originRB, Point2d inflateRB)
        //{
        //    try
        //    {
        //        CCogTool_PMAlign PMAlign = null;

        //        if (PMAlign == null) return;

        //        PMAlign.Tool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatMax;
        //        PMAlign.Tool.RunParams.AcceptThreshold = 0.4;
        //        PMAlign.Tool.RunParams.ScoreUsingClutter = false;

        //        display.InteractiveGraphics.Clear();
        //        display.StaticGraphics.Clear();

        //        PMAlign.Tool.InputImage = greyImg;
        //        PMAlign.Tool.Run();

        //        CogPMAlignResult result = null;
        //        double dMaxScore = 0.0D;

        //        if (PMAlign.Tool.Results == null)
        //        {
        //            CLogger.Add(LOG_TYPE.ABNORMAL, "Check the Image or dongle Key, Can't cut Roi");
        //            return;
        //        }
        //        for (int i = 0; i < PMAlign.Tool.Results.Count; i++)
        //        {
        //            if (dMaxScore < PMAlign.Tool.Results[i].Score)
        //            {
        //                dMaxScore = PMAlign.Tool.Results[i].Score;
        //                result = PMAlign.Tool.Results[i];
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //}

        public void TrainAll(int boardNo, int subNo, CogImage8Grey greyImg)
        {
            TrainAlign(true, boardNo, subNo, greyImg);
            TrainAlign(false, boardNo, subNo, greyImg);
            alignDatas[boardNo][subNo].SetAlign(PMSubAlign[boardNo], (CogRectangle)PMSubAlignLT[boardNo][subNo].Tool.Pattern.TrainRegion,
                (CogRectangle)PMSubAlignRB[boardNo][subNo].Tool.Pattern.TrainRegion);
        }

        public void TrainAlign(bool isLT, int boardNo, int subNo, CogImage8Grey greyImg)
        {
            CCogTool_PMAlign PMAlign = null;
            if (isLT)
                PMAlign = PMSubAlignLT[boardNo][subNo];
            else
                PMAlign = PMSubAlignRB[boardNo][subNo];

            PMAlign.Tool.Pattern.TrainImage = greyImg;
            PMAlign.Tool.Pattern.Origin.TranslationX = (PMAlign.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).X;
            PMAlign.Tool.Pattern.Origin.TranslationY = (PMAlign.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).Y;

            PMAlign.Tool.Pattern.Train();
        }

        public void FindAll(int boardNo, int subNo, CogDisplay display, CogImage8Grey greyImg)
        {
            CogPMAlignResults LTResults = FindAlign(true, boardNo, subNo, display, greyImg);
            CogPMAlignResult LTMaxResult = MaxResult(LTResults);
            CogPMAlignResults RBResults = FindAlign(false, boardNo, subNo, display, greyImg);
            CogPMAlignResult RBMaxResult = MaxResult(RBResults);

            if (LTMaxResult.Score > alignDatas[boardNo][subNo].allowScore && RBMaxResult.Score > alignDatas[boardNo][subNo].allowScore)
            {
                alignDatas[boardNo][subNo].SetResultLT(LTMaxResult);
                alignDatas[boardNo][subNo].SetResultRB(RBMaxResult);
                alignDatas[boardNo][subNo].isResultSucess = true;
                DisplayResult(LTMaxResult, display);
                DisplayResult(RBMaxResult, display);
            }
        }

        public bool AlignAll(int boardNo, int subNo, CogDisplay display, ref CogImage24PlanarColor colorImg, ref CogImage8Grey greyImg)
        {
            FindAll(boardNo, subNo, display, greyImg);

            if (alignDatas[boardNo][subNo].calcResultNPorcessImg(ref colorImg, ref greyImg))
                return true;
            CLogger.Add(LOG.ABNORMAL, "AlignFail !!!");
            return false;
        }

        public CogPMAlignResults FindAlign(bool isLT, int boardNo, int subNo, CogDisplay display, CogImage8Grey greyImg)
        {
            CCogTool_PMAlign PMAlign = null;
            if (isLT)
                PMAlign = PMSubAlignLT[boardNo][subNo];
            else
                PMAlign = PMSubAlignRB[boardNo][subNo];

            if (!PMAlign.Tool.Pattern.Trained)
                return null;

            PMAlign.Tool.InputImage = greyImg;
            PMAlign.Tool.Run();

            display.StaticGraphics.Add((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion, "main");

            if (PMAlign.Tool.Results == null)
            {
                CLogger.Add(LOG.ABNORMAL, "Can't Fine the Pattern of Array");
                return null;
            }
            return PMAlign.Tool.Results;
        }

        public CogPMAlignResult MaxResult(CogPMAlignResults results)
        {
            CogPMAlignResult result = null;
            double maxScore = 0;
            if (results == null)
                return result;
            for (int i = 0; i < results.Count; i++)
            {
                if (maxScore < results[i].Score)
                {
                    maxScore = results[i].Score;
                    result = results[i];
                }
            }
            return result;
        }

        public void DisplayResult(CogPMAlignResult result, CogDisplay display, int no = 0)
        {
            Cognex.VisionPro.CogRectangle Draw = new Cognex.VisionPro.CogRectangle();
            Cognex.VisionPro.CogCompositeShape resultDrawing = result.CreateResultGraphics(CogPMAlignResultGraphicConstants.All);

            Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();

            label.X = result.GetPose().TranslationX;
            label.Y = result.GetPose().TranslationY;

            display.InteractiveGraphics.Add(result.CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), $"result{no}", false);
            display.StaticGraphics.Add(resultDrawing, $"result{no}");
        }

        public void DisplayResults(CogPMAlignResults results, CogDisplay display)
        {
            for (int i = 0; i < results.Count; i++)
            {
                DisplayResult(results[i], display, i);
            }
        }

        public static System.Drawing.Bitmap cropImage(System.Drawing.Bitmap imgSrc, Rectangle roi)
        {
            try
            {
                if (imgSrc == null || imgSrc.Width == 0) return null;

                Rectangle destRect = new Rectangle(System.Drawing.Point.Empty, roi.Size);

                var cropImage = new Bitmap(destRect.Width, destRect.Height);
                using (var graphics = Graphics.FromImage(cropImage))
                {
                    graphics.DrawImage(imgSrc, destRect, roi, GraphicsUnit.Pixel);
                }

                return cropImage;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        public static CogImage24PlanarColor rotateImage(double cx, double cy, double angle, CogImage24PlanarColor colorImg)
        {
            Point2f pt = new Point2f(Convert.ToSingle(cx), Convert.ToSingle(cy));
            Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(colorImg.ToBitmap()).Clone();
            Mat refImg = Cv2.GetRotationMatrix2D(pt, angle, 1.0);
            Mat outImg = new Mat();
            OpenCvSharp.Size imgSize = new OpenCvSharp.Size(inImg.Width, inImg.Height);
            Cv2.WarpAffine(inImg, outImg, refImg, imgSize);
            Bitmap outBmp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(outImg);
            return new CogImage24PlanarColor(outBmp);
        }

        public static CogImage24PlanarColor rotateImage(Point2d centerPt, double angle, CogImage24PlanarColor colorImg)
        {
            return rotateImage(centerPt.X, centerPt.Y, angle, colorImg);
        }

        public static CogImage8Grey rotateImage(double cx, double cy, double angle, CogImage8Grey greyImg)
        {
            Point2f pt = new Point2f(Convert.ToSingle(cx), Convert.ToSingle(cy));
            Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(greyImg.ToBitmap()).Clone();
            Mat refImg = Cv2.GetRotationMatrix2D(pt, angle, 1.0);
            Mat outImg = new Mat();
            OpenCvSharp.Size imgSize = new OpenCvSharp.Size(inImg.Width, inImg.Height);
            Cv2.WarpAffine(inImg, outImg, refImg, imgSize);
            Bitmap outBmp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(outImg);
            return new CogImage8Grey(outBmp);
        }

        public static CogImage8Grey rotateImage(Point2d centerPt, double angle, CogImage8Grey colorImg)
        {
            return rotateImage(centerPt.X, centerPt.Y, angle, colorImg);
        }
    }

    public class AlignData
    {
        // 기준 및 Align 성공여부
        public double allowScore { get; set; } = 0.9;

        public bool isTrained { get; set; } = false;
        public bool isResultSucess { get; set; } = false;

        // 결과(이미지 가공) 값
        public Point2d shiftLT { get; set; } = new Point2d(0, 0);

        public double rotateResult { get; set; } = 0;

        // Align 측정 값
        public Point2d resultLT { get; set; } = new Point2d(0, 0);

        public Point2d resultRB { get; set; } = new Point2d(0, 0);

        // 초기 셋팅 값
        public Point2d LT { get; set; } = new Point2d(0, 0);

        public Point2d RB { get; set; } = new Point2d(0, 0);
        public Point2d inflateLT { get; set; } = new Point2d(0, 0);
        public Point2d inflateRB { get; set; } = new Point2d(0, 0);
        public double rotateBase { get; set; } = 0;

        public AlignData()
        {
        }

        public void SetAlign(CogRectangle AllArea, CogRectangle LTArea, CogRectangle RBArea)
        {
            LT = new Point2d(LTArea.CenterX, LTArea.CenterY);
            RB = new Point2d(RBArea.CenterX, RBArea.CenterY);
            inflateLT = new Point2d(AllArea.X - LT.X, AllArea.Y - LT.Y);
            inflateRB = new Point2d(AllArea.X + AllArea.Width - RB.X, AllArea.Y + AllArea.Height - RB.Y);
            rotateBase = (RB.Y - LT.Y) / (RB.X - LT.X);
            isTrained = true;
        }

        public void SetResultLT(CogPMAlignResult cogResult)
        {
            resultLT = new Point2d(cogResult.GetPose().TranslationX, cogResult.GetPose().TranslationY);
        }

        public void SetResultRB(CogPMAlignResult cogResult)
        {
            resultRB = new Point2d(cogResult.GetPose().TranslationX, cogResult.GetPose().TranslationY);
        }

        public bool calcResultNPorcessImg(ref CogImage24PlanarColor colorImg, ref CogImage8Grey greyImg)
        {
            if (isResultSucess)
            {
                shiftLT = new Point2d(LT.X - resultLT.X, LT.Y - resultLT.Y);
                rotateResult = (resultRB.Y - resultLT.Y) / (resultRB.X - resultLT.X);
                double rotateValue = rotateBase - rotateResult;

                colorImg = VisionTools.rotateImage(resultLT, rotateValue, colorImg);
                greyImg = VisionTools.rotateImage(resultLT, rotateValue, greyImg);

                return true;
            }
            return false;

            //Mat mt = Cv2.GetRotationMatrix2D(new Point2f(LT.X, LT.Y), rotate, 1.0);
            //Mat mt2 = Cv2.WarpAffine(inImg, outImg, mt, inImg.width, inImg.height);
        }

        public AlignData LoadConfig(string recipeName, string NAME)
        {
            string excutePath = Util.GetExcutePath();
            string strPath = $"{excutePath}\\RECIPE\\{recipeName}\\{NAME}.xml";
            AlignData newData = null;

            if (File.Exists(strPath))
            {
                newData = SerializeHelper.FromXmlFile<AlignData>(strPath);
                if (newData != null)
                    return newData;
            }

            newData = new AlignData();
            newData.SaveConfig(recipeName, NAME);
            return newData;
        }

        public void SaveConfig(string recipeName, string NAME)
        {
            string excutePath = Util.GetExcutePath();
            string strPath = $"{excutePath}\\RECIPE\\{recipeName}\\{NAME}.xml";

            SerializeHelper.ToXmlFile(strPath, this);
        }
    }
}