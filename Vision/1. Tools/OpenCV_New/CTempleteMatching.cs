using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace IntelligentFactory
{
    public partial class CTemplateMatching
    {
        #region PROPERTIES
        public List<CResultMatching> Results = new List<CResultMatching>();

        public string ToolName = "EMPTY";
        public Mat ImageSource { get; set; } = null;
        public Mat ImageTemplate { get; set; } = null;
        public Mat ImageResult { get; set; } = null;
        public Mat ImageFinal { get; set; } = null;
        public int Threshold { get; set; } = 100;
        public int TimeOut { get; set; } = 30000;

        public bool UseInv { get; set; } = false;
        public bool UseMultiMatching { get; set; } = false;
        public Rect MarkROI { get; set; } = new Rect();

        private Rect m_rt = new Rect();
        public Rect rt
        {
            get { return m_rt; }
            set { m_rt = value; }
        }

        public string Algorism { get; set; } = "";
        #endregion

        public Stopwatch sw_TactTime = new Stopwatch();

        // 매칭의 서치 ROI 영역
        // 매칭의 트레인 ROI 영역
        public Rectangle MatchingSearchRoi { get; set; } = new Rectangle(0, 0, 150, 150);
        public Rectangle MatchingTemplateRoi { get; set; } = new Rectangle(5, 5, 100, 100);
        public Bitmap m_MatchingTemplateImage { get; set; } = null;

        public double m_Score_Min { get; set; } = 60;

        public CTemplateMatching(string strAlgorism)
        {
            ToolName = strAlgorism;
        }

        public bool SetSourceImage(System.Drawing.Bitmap Image)
        {
            try
            {
                ImageSource = OpenCvSharp.Extensions.BitmapConverter.ToMat(Image).Clone();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[ERROR] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }

        public bool SetSourceImage(Mat Image)
        {
            try
            {
                ImageSource = Image.Clone();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[ERROR] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }

        public bool MultiRun(Bitmap imgMark, double minScore, int maxCount = 2, int mag_1st = 2, int mag_2nd = 1)
        {
            try
            {
                sw_TactTime.Restart();

                Results.Clear();

                Mat ImageMatching = new Mat();

                Debug.WriteLine($"1 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");
                ImageTemplate = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgMark).Clone();
                Debug.WriteLine($"2 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");

                if (CVision.IsMatEmpty(ImageSource))
                {
                    CLogger.Add(LOG.ABNORMAL, "Image is Empty");
                    return false;
                }

                if (ImageTemplate.Channels() == 4) Cv2.CvtColor(ImageTemplate, ImageTemplate, ColorConversionCodes.RGBA2GRAY);
                if (ImageTemplate.Channels() == 3) Cv2.CvtColor(ImageTemplate, ImageTemplate, ColorConversionCodes.RGB2GRAY);

                if (ImageSource.Channels() == 4) Cv2.CvtColor(ImageSource, ImageSource, ColorConversionCodes.RGBA2GRAY);
                if (ImageSource.Channels() == 3) Cv2.CvtColor(ImageSource, ImageSource, ColorConversionCodes.RGB2GRAY);

                Debug.WriteLine($"3 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");

                using (Mat ImageSubMat_1st = ImageSource.Clone()) // ImageSource.SubMat(CConverter.RectToCVRect(AlignRecipe.ROI)).Clone())
                using (Mat ImageSrc_1st = ImageSource.Resize(new OpenCvSharp.Size((int)(ImageSource.Width / mag_1st), (int)(ImageSource.Height / mag_1st))))
                using (Mat ImageTpl_1st = ImageTemplate.Resize(new OpenCvSharp.Size((int)(ImageTemplate.Width / mag_1st), (int)(ImageTemplate.Height / mag_1st))))
                {
                    Debug.WriteLine($"4 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");

                    ImageResult = ImageSrc_1st.Clone();

                    Debug.WriteLine($"5 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");

                    if (CVision.IsMatEmpty(ImageTemplate)
                           || CVision.IsMatEmpty(ImageSource)) return false;

                    double dScore = 0;

                    if (ImageResult.Channels() == 1) Cv2.CvtColor(ImageResult, ImageResult, ColorConversionCodes.GRAY2RGB);

                    Debug.WriteLine($"6 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");


                    OpenCvSharp.Point ptMax = new OpenCvSharp.Point();
                    double dMax = 0.0D;
                    //bool bFind = false;

                    int nTimeOutCheck = Environment.TickCount;

                    while (true)
                    {
                        //if ((Environment.TickCount - nTimeOutCheck) > TimeOut) return false;

                        Cv2.MatchTemplate(ImageSrc_1st, ImageTpl_1st, ImageMatching, TemplateMatchModes.CCoeffNormed, null);
                        Cv2.MinMaxLoc(ImageMatching, out double dMinScore, out double dMaxScore, out OpenCvSharp.Point ptMinLocation, out OpenCvSharp.Point ptMaxLocation);

                        Debug.WriteLine($"7 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");

                        if (dMaxScore > minScore / 100)
                        {
                            ptMax = (dMaxScore > dMax) ? ptMaxLocation : ptMax;
                            dMax = (dMaxScore > dMax) ? dMaxScore : dMax;

                            dScore = dMaxScore * 100.0D;

                            OpenCvSharp.Point ptStart = new OpenCvSharp.Point(ptMaxLocation.X, ptMaxLocation.Y);
                            OpenCvSharp.Point ptEnd = new OpenCvSharp.Point(ptMaxLocation.X + (ImageTpl_1st.Width), ptMaxLocation.Y + (ImageTpl_1st.Height));

                            ImageSrc_1st.Rectangle(new Rect(ptStart.X, ptStart.Y, ImageTpl_1st.Width, ImageTpl_1st.Height), Scalar.Black, -1);

                            Rect rtBounding = new Rect(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                            Point2d ptCenter = new Point2d(ptStart.X + rtBounding.Width / 2.0, ptStart.Y + rtBounding.Height / 2.0);

                            rtBounding = CConverter.ScreenCVRectToLogicalCVRect(rtBounding, (float)mag_1st, (float)mag_1st);
                            rtBounding.X -= (int)(rtBounding.Width * 0.5D);
                            rtBounding.Y -= (int)(rtBounding.Height * 0.5D);
                            rtBounding.Width += (int)(rtBounding.Width);
                            rtBounding.Height += (int)(rtBounding.Height);

                            if (rtBounding.Width > ImageSource.Width)
                            {
                                rtBounding.X = 0;
                                rtBounding.Width = ImageSource.Width;
                            }
                            if (rtBounding.Height > ImageSource.Height)
                            {
                                rtBounding.Y = 0;
                                rtBounding.Height = ImageSource.Height;
                            }

                            if (rtBounding.X < 0) rtBounding.X = 0;
                            if (rtBounding.Y < 0) rtBounding.Y = 0;

                            using (Mat ImageSubMat_2nd = ImageSource.SubMat(rtBounding).Clone())
                            {
                                Cv2.MatchTemplate(ImageSubMat_2nd, ImageTemplate, ImageMatching, TemplateMatchModes.CCoeffNormed, null);
                                Cv2.MinMaxLoc(ImageMatching, out dMinScore, out dMaxScore, out ptMinLocation, out ptMaxLocation);

                                Debug.WriteLine($"8 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");

                                if (dMaxScore > minScore / 100)
                                {
                                    ptMax = (dMaxScore > dMax) ? ptMaxLocation : ptMax;
                                    dMax = (dMaxScore > dMax) ? dMaxScore : dMax;

                                    dScore = dMaxScore * 100.0D;

                                    ptStart = new OpenCvSharp.Point(ptMaxLocation.X + rtBounding.X, ptMaxLocation.Y + rtBounding.Y);
                                    ptEnd = new OpenCvSharp.Point(ptMaxLocation.X + rtBounding.X + (ImageTemplate.Width), ptMaxLocation.Y + rtBounding.Y + (ImageTemplate.Height));
                                    rt = new Rect(ptStart, new OpenCvSharp.Size(ImageTemplate.Width, ImageTemplate.Height));

                                    //bFind = true;

                                    rtBounding = new Rect(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                                    ptCenter = new Point2d(ptStart.X + rtBounding.Width / 2.0, ptStart.Y + rtBounding.Height / 2.0);

                                    Results.Add(new CResultMatching(0, dScore, ptCenter, rtBounding));

                                    if (Results.Count >= maxCount)
                                    {
                                        break;
                                    }

                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    List<CResultMatching> orderdResults = new List<CResultMatching>();
                    foreach (CResultMatching result in Results)
                    {
                        if (orderdResults.Count == 0)
                        {
                            orderdResults.Add(result);
                        }
                        else
                        {
                            if (result.Score > orderdResults[0].Score) orderdResults.Insert(0, result);
                            else orderdResults.Add(result);
                        }
                    }

                    Results = orderdResults;
                }

                sw_TactTime.Stop();


                if (!ImageMatching.IsDisposed && ImageMatching.IsEnabledDispose) ImageMatching.Dispose();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[ERROR] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }

        public bool Run(Recipe_Matching recipe, Rect searchRoi = new Rect())
        {
            try
            {
                sw_TactTime.Restart();

                Results.Clear();

                Mat ImageMatching = new Mat();
                ImageTemplate = OpenCvSharp.Extensions.BitmapConverter.ToMat(recipe.ImageTemplate).Clone();

                if (CVision.IsMatEmpty(ImageSource))
                {
                    CLogger.Add(LOG.ABNORMAL, "Image is Empty");
                    return false;
                }

                if (ImageTemplate.Channels() == 4) Cv2.CvtColor(ImageTemplate, ImageTemplate, ColorConversionCodes.RGBA2GRAY);
                if (ImageTemplate.Channels() == 3) Cv2.CvtColor(ImageTemplate, ImageTemplate, ColorConversionCodes.RGB2GRAY);

                if (ImageSource.Channels() == 4) Cv2.CvtColor(ImageSource, ImageSource, ColorConversionCodes.RGBA2GRAY);
                if (ImageSource.Channels() == 3) Cv2.CvtColor(ImageSource, ImageSource, ColorConversionCodes.RGB2GRAY);

                Rect roi = new Rect(recipe.SearchRoi.X, recipe.SearchRoi.Y, recipe.SearchRoi.Width, recipe.SearchRoi.Height);

                if (searchRoi.Width != 0 && searchRoi.Height != 0) roi = searchRoi;

                if (roi.Width == 0) roi.Width = ImageSource.Width;
                if (roi.Height == 0) roi.Height = ImageSource.Height;

                if (roi.X < 0) roi.X = 0;
                if (roi.Y < 0) roi.Y = 0;
                using (Mat ImageSubMat_1st = ImageSource.SubMat(roi).Clone())
                using (Mat ImageSrc_1st = ImageSubMat_1st.Resize(new OpenCvSharp.Size((int)(ImageSubMat_1st.Width / recipe.Mag_1st), (int)(ImageSubMat_1st.Height / recipe.Mag_1st))))
                using (Mat ImageTpl_1st = ImageTemplate.Resize(new OpenCvSharp.Size((int)(ImageTemplate.Width / recipe.Mag_1st), (int)(ImageTemplate.Height / recipe.Mag_1st))))
                {
                    ImageResult = ImageSrc_1st.Clone();

                    if (CVision.IsMatEmpty(ImageTemplate)
                           || CVision.IsMatEmpty(ImageSubMat_1st)) return false;

                    double dScore = 0;

                    if (ImageResult.Channels() == 1) Cv2.CvtColor(ImageResult, ImageResult, ColorConversionCodes.GRAY2RGB);

                    OpenCvSharp.Point ptMax = new OpenCvSharp.Point();
                    double dMax = 0.0D;
                    //bool bFind = false;

                    int nTimeOutCheck = Environment.TickCount;

                    while (true)
                    {
                        if ((Environment.TickCount - nTimeOutCheck) > TimeOut) return false;

                        Cv2.MatchTemplate(ImageSrc_1st, ImageTpl_1st, ImageMatching, TemplateMatchModes.CCoeffNormed, null);
                        Cv2.MinMaxLoc(ImageMatching, out double dMinScore, out double dMaxScore, out OpenCvSharp.Point ptMinLocation, out OpenCvSharp.Point ptMaxLocation);

                        if (dMaxScore > recipe.ScoreMin / 100)
                        {
                            ptMax = (dMaxScore > dMax) ? ptMaxLocation : ptMax;
                            dMax = (dMaxScore > dMax) ? dMaxScore : dMax;

                            dScore = dMaxScore * 100.0D;

                            OpenCvSharp.Point ptStart = new OpenCvSharp.Point(ptMaxLocation.X, ptMaxLocation.Y);
                            OpenCvSharp.Point ptEnd = new OpenCvSharp.Point(ptMaxLocation.X + (ImageTpl_1st.Width), ptMaxLocation.Y + (ImageTpl_1st.Height));

                            Rect rtBounding = new Rect(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                            Point2d ptCenter = new Point2d(ptStart.X + rtBounding.Width / 2.0, ptStart.Y + rtBounding.Height / 2.0);

                            rtBounding = CConverter.ScreenCVRectToLogicalCVRect(rtBounding, (float)recipe.Mag_1st, (float)recipe.Mag_1st);
                            rtBounding.X -= (int)(rtBounding.Width * 0.2D);
                            rtBounding.Y -= (int)(rtBounding.Height * 0.2D);
                            rtBounding.Width += (int)(rtBounding.Width * 0.2D);
                            rtBounding.Height += (int)(rtBounding.Height * 0.2D);

                            if (rtBounding.Width > ImageSubMat_1st.Width)
                            {
                                rtBounding.X = 0;
                                rtBounding.Width = ImageSubMat_1st.Width;
                            }
                            if (rtBounding.Height > ImageSubMat_1st.Height)
                            {
                                rtBounding.Y = 0;
                                rtBounding.Height = ImageSubMat_1st.Height;
                            }

                            if (rtBounding.X < 0) rtBounding.X = 0;
                            if (rtBounding.Y < 0) rtBounding.Y = 0;

                            rtBounding.X += roi.X;
                            rtBounding.Y += roi.Y;

                            using (Mat ImageSubMat_2nd = ImageSource.SubMat(rtBounding).Clone())
                            {
                                roi.X = rtBounding.X;
                                roi.Y = rtBounding.Y;

                                Cv2.MatchTemplate(ImageSubMat_2nd, ImageTemplate, ImageMatching, TemplateMatchModes.CCoeffNormed, null);
                                Cv2.MinMaxLoc(ImageMatching, out dMinScore, out dMaxScore, out ptMinLocation, out ptMaxLocation);

                                Debug.WriteLine($"8 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");

                                if (dMaxScore > recipe.ScoreMin / 100)
                                {
                                    ptMax = (dMaxScore > dMax) ? ptMaxLocation : ptMax;
                                    dMax = (dMaxScore > dMax) ? dMaxScore : dMax;

                                    dScore = dMaxScore * 100.0D;

                                    ptStart = new OpenCvSharp.Point(ptMaxLocation.X + rtBounding.X, ptMaxLocation.Y + rtBounding.Y);
                                    ptEnd = new OpenCvSharp.Point(ptMaxLocation.X + rtBounding.X + (ImageTemplate.Width), ptMaxLocation.Y + rtBounding.Y + (ImageTemplate.Height));
                                    rt = new Rect(ptStart, new OpenCvSharp.Size(ImageTemplate.Width, ImageTemplate.Height));

                                    rtBounding = new Rect(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                                    ptCenter = new Point2d(ptStart.X + rtBounding.Width / 2.0, ptStart.Y + rtBounding.Height / 2.0);

                                    Results.Add(new CResultMatching(0, dScore, ptCenter, rtBounding));
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    List<CResultMatching> orderdResults = new List<CResultMatching>();
                    foreach (CResultMatching result in Results)
                    {
                        if (orderdResults.Count == 0)
                        {
                            orderdResults.Add(result);
                        }
                        else
                        {
                            if (result.Score > orderdResults[0].Score) orderdResults.Insert(0, result);
                            else orderdResults.Add(result);
                        }
                    }

                    Results = orderdResults;
                }

                sw_TactTime.Stop();


                if (!ImageMatching.IsDisposed && ImageMatching.IsEnabledDispose) ImageMatching.Dispose();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[ERROR] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }

        public bool Run(Recipe_FiducialMatching recipe, Rect searchRoi = new Rect())
        {
            try
            {
                sw_TactTime.Restart();

                Results.Clear();

                Mat ImageMatching = new Mat();
                ImageTemplate = OpenCvSharp.Extensions.BitmapConverter.ToMat(recipe.ImageTemplate).Clone();

                if (CVision.IsMatEmpty(ImageSource))
                {
                    CLogger.Add(LOG.ABNORMAL, "Image is Empty");
                    return false;
                }

                if (ImageTemplate.Channels() == 4) Cv2.CvtColor(ImageTemplate, ImageTemplate, ColorConversionCodes.RGBA2GRAY);
                if (ImageTemplate.Channels() == 3) Cv2.CvtColor(ImageTemplate, ImageTemplate, ColorConversionCodes.RGB2GRAY);

                if (ImageSource.Channels() == 4) Cv2.CvtColor(ImageSource, ImageSource, ColorConversionCodes.RGBA2GRAY);
                if (ImageSource.Channels() == 3) Cv2.CvtColor(ImageSource, ImageSource, ColorConversionCodes.RGB2GRAY);

                Rect roi = new Rect(recipe.SearchRoi.X, recipe.SearchRoi.Y, recipe.SearchRoi.Width, recipe.SearchRoi.Height);

                if (searchRoi.Width != 0 && searchRoi.Height != 0) roi = searchRoi;

                if (roi.Width == 0) roi.Width = ImageSource.Width;
                if (roi.Height == 0) roi.Height = ImageSource.Height;

                if (roi.X < 0) roi.X = 0;
                if (roi.Y < 0) roi.Y = 0;
                using (Mat ImageSubMat_1st = ImageSource.SubMat(roi).Clone())
                using (Mat ImageSrc_1st = ImageSubMat_1st.Resize(new OpenCvSharp.Size((int)(ImageSubMat_1st.Width / recipe.Mag_1st), (int)(ImageSubMat_1st.Height / recipe.Mag_1st))))
                using (Mat ImageTpl_1st = ImageTemplate.Resize(new OpenCvSharp.Size((int)(ImageTemplate.Width / recipe.Mag_1st), (int)(ImageTemplate.Height / recipe.Mag_1st))))
                {
                    ImageResult = ImageSrc_1st.Clone();

                    if (CVision.IsMatEmpty(ImageTemplate)
                           || CVision.IsMatEmpty(ImageSubMat_1st)) return false;

                    double dScore = 0;

                    if (ImageResult.Channels() == 1) Cv2.CvtColor(ImageResult, ImageResult, ColorConversionCodes.GRAY2RGB);

                    OpenCvSharp.Point ptMax = new OpenCvSharp.Point();
                    double dMax = 0.0D;
                    //bool bFind = false;

                    int nTimeOutCheck = Environment.TickCount;

                    while (true)
                    {
                        if ((Environment.TickCount - nTimeOutCheck) > TimeOut) return false;

                        Cv2.MatchTemplate(ImageSrc_1st, ImageTpl_1st, ImageMatching, TemplateMatchModes.CCoeffNormed, null);
                        Cv2.MinMaxLoc(ImageMatching, out double dMinScore, out double dMaxScore, out OpenCvSharp.Point ptMinLocation, out OpenCvSharp.Point ptMaxLocation);

                        if (dMaxScore > recipe.ScoreMin / 100)
                        {
                            ptMax = (dMaxScore > dMax) ? ptMaxLocation : ptMax;
                            dMax = (dMaxScore > dMax) ? dMaxScore : dMax;

                            dScore = dMaxScore * 100.0D;

                            OpenCvSharp.Point ptStart = new OpenCvSharp.Point(ptMaxLocation.X, ptMaxLocation.Y);
                            OpenCvSharp.Point ptEnd = new OpenCvSharp.Point(ptMaxLocation.X + (ImageTpl_1st.Width), ptMaxLocation.Y + (ImageTpl_1st.Height));

                            Rect rtBounding = new Rect(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                            Point2d ptCenter = new Point2d(ptStart.X + rtBounding.Width / 2.0, ptStart.Y + rtBounding.Height / 2.0);

                            rtBounding = CConverter.ScreenCVRectToLogicalCVRect(rtBounding, (float)recipe.Mag_1st, (float)recipe.Mag_1st);
                            rtBounding.X -= (int)(rtBounding.Width * 0.2D);
                            rtBounding.Y -= (int)(rtBounding.Height * 0.2D);
                            rtBounding.Width += (int)(rtBounding.Width * 0.2D);
                            rtBounding.Height += (int)(rtBounding.Height * 0.2D);

                            if (rtBounding.Width > ImageSubMat_1st.Width)
                            {
                                rtBounding.X = 0;
                                rtBounding.Width = ImageSubMat_1st.Width;
                            }
                            if (rtBounding.Height > ImageSubMat_1st.Height)
                            {
                                rtBounding.Y = 0;
                                rtBounding.Height = ImageSubMat_1st.Height;
                            }

                            if (rtBounding.X < 0) rtBounding.X = 0;
                            if (rtBounding.Y < 0) rtBounding.Y = 0;

                            rtBounding.X += roi.X;
                            rtBounding.Y += roi.Y;

                            using (Mat ImageSubMat_2nd = ImageSource.SubMat(rtBounding).Clone())
                            {
                                roi.X = rtBounding.X;
                                roi.Y = rtBounding.Y;

                                Cv2.MatchTemplate(ImageSubMat_2nd, ImageTemplate, ImageMatching, TemplateMatchModes.CCoeffNormed, null);
                                Cv2.MinMaxLoc(ImageMatching, out dMinScore, out dMaxScore, out ptMinLocation, out ptMaxLocation);

                                Debug.WriteLine($"8 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");

                                if (dMaxScore > recipe.ScoreMin / 100)
                                {
                                    ptMax = (dMaxScore > dMax) ? ptMaxLocation : ptMax;
                                    dMax = (dMaxScore > dMax) ? dMaxScore : dMax;

                                    dScore = dMaxScore * 100.0D;

                                    ptStart = new OpenCvSharp.Point(ptMaxLocation.X + rtBounding.X, ptMaxLocation.Y + rtBounding.Y);
                                    ptEnd = new OpenCvSharp.Point(ptMaxLocation.X + rtBounding.X + (ImageTemplate.Width), ptMaxLocation.Y + rtBounding.Y + (ImageTemplate.Height));
                                    rt = new Rect(ptStart, new OpenCvSharp.Size(ImageTemplate.Width, ImageTemplate.Height));

                                    rtBounding = new Rect(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                                    ptCenter = new Point2d(ptStart.X + rtBounding.Width / 2.0, ptStart.Y + rtBounding.Height / 2.0);

                                    Results.Add(new CResultMatching(0, dScore, ptCenter, rtBounding));
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    List<CResultMatching> orderdResults = new List<CResultMatching>();
                    foreach (CResultMatching result in Results)
                    {
                        if (orderdResults.Count == 0)
                        {
                            orderdResults.Add(result);
                        }
                        else
                        {
                            if (result.Score > orderdResults[0].Score) orderdResults.Insert(0, result);
                            else orderdResults.Add(result);
                        }
                    }

                    Results = orderdResults;
                }

                sw_TactTime.Stop();


                if (!ImageMatching.IsDisposed && ImageMatching.IsEnabledDispose) ImageMatching.Dispose();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[ERROR] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }

        public bool Run(Bitmap imgMark, Rectangle roi, double minScore, int mag_1st = 2, int mag_2nd = 1)
        {
            try
            {
                sw_TactTime.Restart();

                Results.Clear();

                Mat ImageMatching = new Mat();
                ImageTemplate = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgMark).Clone();

                if (CVision.IsMatEmpty(ImageSource))
                {
                    CLogger.Add(LOG.ABNORMAL, "Image is Empty");
                    return false;
                }

                if (ImageTemplate.Channels() == 4) Cv2.CvtColor(ImageTemplate, ImageTemplate, ColorConversionCodes.RGBA2GRAY);
                if (ImageTemplate.Channels() == 3) Cv2.CvtColor(ImageTemplate, ImageTemplate, ColorConversionCodes.RGB2GRAY);

                if (ImageSource.Channels() == 4) Cv2.CvtColor(ImageSource, ImageSource, ColorConversionCodes.RGBA2GRAY);
                if (ImageSource.Channels() == 3) Cv2.CvtColor(ImageSource, ImageSource, ColorConversionCodes.RGB2GRAY);

                if (roi.Width == 0) roi.Width = ImageSource.Width;
                if (roi.Height == 0) roi.Height = ImageSource.Height;
                if (roi.Right > ImageSource.Width) roi.Offset(new System.Drawing.Point(-(roi.Right - ImageSource.Width), 0));
                if (roi.Bottom > ImageSource.Height) roi.Offset(new System.Drawing.Point(0, -(roi.Bottom - ImageSource.Height)));
                if (roi.Left < 0) roi.Offset(new System.Drawing.Point(-roi.Left, 0));
                if (roi.Top < 0) roi.Offset(new System.Drawing.Point(0, -roi.Top));

                //using (Mat ImageSubMat_1st = ImageSource.Clone()) // ImageSource.SubMat(CConverter.RectToCVRect(AlignRecipe.ROI)).Clone())
                using (Mat ImageSubMat_1st = ImageSource.SubMat(CConverter.RectToCVRect(roi)).Clone())
                using (Mat ImageSrc_1st = ImageSubMat_1st.Resize(new OpenCvSharp.Size((int)(ImageSubMat_1st.Width / mag_1st), (int)(ImageSubMat_1st.Height / mag_1st))))
                using (Mat ImageTpl_1st = ImageTemplate.Resize(new OpenCvSharp.Size((int)(ImageTemplate.Width / mag_1st), (int)(ImageTemplate.Height / mag_1st))))
                {
                    ImageResult = ImageSrc_1st.Clone();

                    if (CVision.IsMatEmpty(ImageTemplate)
                           || CVision.IsMatEmpty(ImageSubMat_1st)) return false;

                    double dScore = 0;

                    if (ImageResult.Channels() == 1) Cv2.CvtColor(ImageResult, ImageResult, ColorConversionCodes.GRAY2RGB);

                    OpenCvSharp.Point ptMax = new OpenCvSharp.Point();
                    double dMax = 0.0D;
                    //bool bFind = false;

                    int nTimeOutCheck = Environment.TickCount;

                    while (true)
                    {
                        if ((Environment.TickCount - nTimeOutCheck) > TimeOut) return false;

                        Cv2.MatchTemplate(ImageSrc_1st, ImageTpl_1st, ImageMatching, TemplateMatchModes.CCoeffNormed, null);
                        Cv2.MinMaxLoc(ImageMatching, out double dMinScore, out double dMaxScore, out OpenCvSharp.Point ptMinLocation, out OpenCvSharp.Point ptMaxLocation);

                        if (dMaxScore > minScore / 100)
                        {
                            ptMax = (dMaxScore > dMax) ? ptMaxLocation : ptMax;
                            dMax = (dMaxScore > dMax) ? dMaxScore : dMax;

                            dScore = dMaxScore * 100.0D;

                            OpenCvSharp.Point ptStart = new OpenCvSharp.Point(ptMaxLocation.X, ptMaxLocation.Y);
                            OpenCvSharp.Point ptEnd = new OpenCvSharp.Point(ptMaxLocation.X + (ImageTpl_1st.Width), ptMaxLocation.Y + (ImageTpl_1st.Height));

                            Rect rtBounding = new Rect(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                            Point2d ptCenter = new Point2d(ptStart.X + rtBounding.Width / 2.0, ptStart.Y + rtBounding.Height / 2.0);

                            rtBounding = CConverter.ScreenCVRectToLogicalCVRect(rtBounding, (float)mag_1st, (float)mag_1st);
                            rtBounding.X -= (int)(rtBounding.Width * 0.2D);
                            rtBounding.Y -= (int)(rtBounding.Height * 0.2D);
                            rtBounding.Width += (int)(rtBounding.Width * 0.2D);
                            rtBounding.Height += (int)(rtBounding.Height * 0.2D);

                            if (rtBounding.Width > ImageSubMat_1st.Width)
                            {
                                rtBounding.X = 0;
                                rtBounding.Width = ImageSubMat_1st.Width;
                            }
                            if (rtBounding.Height > ImageSubMat_1st.Height)
                            {
                                rtBounding.Y = 0;
                                rtBounding.Height = ImageSubMat_1st.Height;
                            }

                            if (rtBounding.X < 0) rtBounding.X = 0;
                            if (rtBounding.Y < 0) rtBounding.Y = 0;

                            rtBounding.X += roi.X;
                            rtBounding.Y += roi.Y;

                            using (Mat ImageSubMat_2nd = ImageSource.SubMat(rtBounding).Clone())
                            {
                                roi.X = rtBounding.X;
                                roi.Y = rtBounding.Y;

                                Cv2.MatchTemplate(ImageSubMat_2nd, ImageTemplate, ImageMatching, TemplateMatchModes.CCoeffNormed, null);
                                Cv2.MinMaxLoc(ImageMatching, out dMinScore, out dMaxScore, out ptMinLocation, out ptMaxLocation);

                                Debug.WriteLine($"8 ==> {DateTime.Now.ToString("HH:mm:ss fff")}");

                                if (dMaxScore > minScore / 100)
                                {
                                    ptMax = (dMaxScore > dMax) ? ptMaxLocation : ptMax;
                                    dMax = (dMaxScore > dMax) ? dMaxScore : dMax;

                                    dScore = dMaxScore * 100.0D;

                                    ptStart = new OpenCvSharp.Point(ptMaxLocation.X + rtBounding.X, ptMaxLocation.Y + rtBounding.Y);
                                    ptEnd = new OpenCvSharp.Point(ptMaxLocation.X + rtBounding.X + (ImageTemplate.Width), ptMaxLocation.Y + rtBounding.Y + (ImageTemplate.Height));
                                    rt = new Rect(ptStart, new OpenCvSharp.Size(ImageTemplate.Width, ImageTemplate.Height));

                                    //bFind = true;

                                    rtBounding = new Rect(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                                    ptCenter = new Point2d(ptStart.X + rtBounding.Width / 2.0, ptStart.Y + rtBounding.Height / 2.0);

                                    //rtBounding.X += roi.X;
                                    //rtBounding.Y += roi.Y;

                                    //ptCenter.X += roi.X;
                                    //ptCenter.Y += roi.Y;

                                    Results.Add(new CResultMatching(0, dScore, ptCenter, rtBounding));
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    List<CResultMatching> orderdResults = new List<CResultMatching>();
                    foreach (CResultMatching result in Results)
                    {
                        if (orderdResults.Count == 0)
                        {
                            orderdResults.Add(result);
                        }
                        else
                        {
                            if (result.Score > orderdResults[0].Score) orderdResults.Insert(0, result);
                            else orderdResults.Add(result);
                        }
                    }

                    Results = orderdResults;
                }

                sw_TactTime.Stop();


                if (!ImageMatching.IsDisposed && ImageMatching.IsEnabledDispose) ImageMatching.Dispose();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[ERROR] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }
    }
}

