using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;

using OpenCvSharp;
using OpenCvSharp.Blob;
using OpenCvSharp.Extensions;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Diagnostics;
using Cognex.VisionPro.Caliper;
using Sunny.UI;
using static IntelligentFactory.FormMenu_Vision;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static IntelligentFactory.TcpIp;
using Vila.Extensions;

namespace IntelligentFactory
{
    public static class CVisionTools
    {
        // 이미지 세이브 관련 처리 구조체..
        public struct IMG_SAVE
        {
            public Mat FullBoard_IMG;
            public Mat SAVE_IMG;
            public Mat SAVE_IMG_CAUL;
            public int ArrayIndex;
            public int GrabIndex;
            public bool Result;
            public QRParser QR_Code;
            public CJob Result_Job;
            public DateTime Result_Time;
            public JobRectOption part_type;
            public long InspecTackTime;
            public bool OnlyNG;

           // public Mat SAVE_NG_IMG;
        }
        public enum CV_FILTER : uint
        {
           Morp_Open
         , Morp_Close
         , Morp_Erode
         , Morp_Dilate
         , White_Top_Hat
         , Black_Top_Hat
         , EQUALIZE_HIST
         , EQUALIZE_CLAHE
         , Multply
         , Sharpen
         , Uniform
         , Median
         , Gaussian
         , LowPass
         , HighPass
         , Gradient
         , GradientX
         , GradientY
         , Sobel
         , SobelX
         , SobelY
         , Laplacian
         , LaplacianX
         , LaplacianY
         , Canny
         , None
        }

        public static Mat QR_DRAW(Mat ImageResult, QRParser QR_CODE, int Arrayindex, out Bitmap Resultimg)
        {
            Mat matResult = DrawQRCode(ImageResult, QR_CODE, Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs, Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs.Count);
            Resultimg = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matResult.Clone());
            return matResult;
        }

        // tryp : true [보드 원본이미지 관련], false [크롭이미지 관련]
        // 보드 원본이미지만 텍타임 쓰기..
        public static void DB_Write(bool type, bool isok, string imagePath_All, string imagePath_OnlyNG, int Grabindex, CJob job, QRParser qr, DateTime dt, long tacktime)
        {
            string strResult = isok ? "OK" : "NG";

            if (type)
            {
                if (isok)
                {
                    // DB 등록
                    Global.Instance.DB.Insert_Result("HISTORY",
                     new string[] { "time", "model", "qrcode", "insp_judge", "rms_judge", "master_img_path", "ng_img_path", "crop_img_path", "master_crop_img_path", "ng_part_code", "ng_reason", "ng_rect", "tacktime" },
                     new string[] {
                                                            $"'{dt.ToString("yyyyMMdd:HHmmss")}'",
                                                            $"'{Global.Instance.System.Recipe.Name}'",
                                                            $"'{qr.GetQR()}'",
                                                            $"'{strResult}'",
                                                            $"'OK'",
                                                            $"'{Global.m_MainPJTRoot}\\RECIPE\\{Global.Instance.System.Recipe.Name}\\MasterBoard_0.jpg'",
                                                            $"'{imagePath_All}/{imagePath_OnlyNG}'",
                                                            $"''",
                                                            $"''",
                                                            $"''",
                                                            $"''",
                                                            $"''",
                                                            $"'{tacktime} ms'",
                      });
                }
            }
            else
            {
                System.Drawing.Rectangle searchRect = GetSearchRect(job.nPatternIndex, job);
                List<string> saveCropNames = GetCropFileNames(isok, qr.GetQR(), job.Name);
                Global.Instance.DB.Insert_Result("HISTORY",
                       new string[] { "time", "model", "qrcode", "insp_judge", "rms_judge", "master_img_path", "ng_img_path", "crop_img_path", "master_crop_img_path", "ng_part_code", "ng_reason", "ng_rect", "tacktime" },
                       new string[] {
                                                            //$"'{DateTime.Now.ToString("yyyy-MM-dd")}T{DateTime.Now.ToString("HH:mm")}'",
                                                            $"'{dt.ToString("yyyyMMdd:HHmmss")}'",
                                                            $"'{Global.Instance.System.Recipe.Name}'",
                                                            $"'{qr.GetQR()}'",
                                                            $"'{strResult}'",
                                                            $"'IDLE'",
                                                            $"'{Global.m_MainPJTRoot}\\RECIPE\\{Global.Instance.System.Recipe.Name}\\MasterBoard_{Grabindex}.jpg'",
                                                            $"'{imagePath_All}/{imagePath_OnlyNG}'",
                                                            $"'{saveCropNames[0]}'",
                                                            $"'{saveCropNames[1]}'",
                                                            $"'{job.Name}/{job.Type}'",
                                                            $"'X'",
                                                            $"'{searchRect.X},{searchRect.Y},{searchRect.Width},{searchRect.Height}'",
                                                            $"'{job.Result_TackTime} ms'",
                          });
            }
        }

        static int origin_cnt = 0;
        static int overlay_cnt = 0;
        static int corp_cnt = 0;
        static int part_cnt = 0;

        // 실제 몇개 저장되었는지 카운터 체크
        public static int saveorigin_cnt = 0;
        public static int saveoverlay_cnt = 0;
        public static int savecorp_cnt = 0;
        public static int savepart_cnt = 0;

        // 이미지 저장 진행률 처리 변수
        public static double ImageSave_Per = 0;


        public static object syncGrab = new object();

        public static void DrawStingAdjust(string str, System.Drawing.Font font, System.Drawing.Brush brush, System.Drawing.Point ptIn, Graphics g, int Width)
        {
            // String 위치 조정
            int nLen = str.Length;
            SizeF szStr = g.MeasureString(str, font);
            if (ptIn.X + szStr.Width > Width)
                ptIn.X = Width - (int)szStr.Width;
            //Rectangle rctDraw = new Rectangle(ptIn.X, ptIn.Y, (int)szStr.Width, (int)szStr.Height);
            //ptIn.X = rctDraw.X + rctDraw.Width / 2;
            //ptIn.Y = rctDraw.Y + rctDraw.Height / 2;
            g.DrawString(str, font, brush, ptIn);
            //System.Drawing.Point ptStart = AdjustPoint(ptIn, Width, font.Size, nLen);
            //g.DrawString(str, font, brush, ptStart);
        }

        public static System.Drawing.Point DrawStingAdjustCheckJobs(string str, System.Drawing.Font font, System.Drawing.Brush brush, System.Drawing.Point ptIn, Graphics g, int Width, List<CJob> jobs, int nIndex)
        {
            // String 위치 조정
            int nLen = str.Length;
            SizeF szStr = g.MeasureString(str, font);
            if (ptIn.X + szStr.Width > Width)
                ptIn.X = Width - (int)szStr.Width;

            // 여기서 이전 Job의 Rect체크
            System.Drawing.Rectangle rctDraw = new System.Drawing.Rectangle(ptIn.X, ptIn.Y, (int)szStr.Width, (int)szStr.Height);
            System.Drawing.Rectangle rctInterSect = rctDraw;
            for (int i = 0; i < nIndex; i++)
            {
                rctInterSect.Intersect(jobs[i].drawStringRect);
                if (!rctInterSect.IsEmpty)
                {
                    if (rctDraw.Y < jobs[i].drawStringRect.Y)
                        rctDraw.Y += 50;
                    else
                        rctDraw.Y -= 50;
                    rctInterSect = rctDraw;
                }
                else
                    rctInterSect = rctDraw;
            }
            ptIn.X = rctDraw.X;
            ptIn.Y = rctDraw.Y;

            g.DrawString(str, font, brush, ptIn);
            jobs[nIndex].drawStringRect = rctDraw;
            //System.Drawing.Point ptStart = AdjustPoint(ptIn, Width, font.Size, nLen);
            //g.DrawString(str, font, brush, ptStart);

            return ptIn;
        }

        public static void DrawStingCenter(string str, System.Drawing.Font font, System.Drawing.Brush brush, System.Drawing.Point ptIn, Graphics g, int Width)
        {
            // String 위치 조정
            System.Drawing.Point ptRet = ptIn;
            int nLen = str.Length;
            SizeF szStr = g.MeasureString(str, font);
            ptRet.X = ptRet.X - (int)szStr.Width / 2;
            if (ptRet.X < 0)
                ptRet.X = 0;
            if (ptRet.X + szStr.Width > Width)
                ptRet.X = Width - (int)szStr.Width;
            g.DrawString(str, font, brush, ptRet);
        }

        public static System.Drawing.Rectangle GetSearchRect(int nSearchPos, CJob job)
        {
            System.Drawing.Rectangle retRect = new System.Drawing.Rectangle();
            //CogRectangle searchRegion = (CogRectangle)PMAlign.Tool.SearchRegion;
            if (nSearchPos == 0)
                retRect = job.SearchRegion;
            else if (nSearchPos == 1)
            {
                CogRectangle searchRegion = (CogRectangle)job.SubTool1.Tool.SearchRegion;
                retRect.X = Convert.ToInt32(searchRegion.X);
                retRect.Y = Convert.ToInt32(searchRegion.Y);
                retRect.Width = Convert.ToInt32(searchRegion.Width);
                retRect.Height = Convert.ToInt32(searchRegion.Height);
            }
            else if (nSearchPos == 2)
            {
                CogRectangle searchRegion = (CogRectangle)job.SubTool2.Tool.SearchRegion;
                retRect.X = Convert.ToInt32(searchRegion.X);
                retRect.Y = Convert.ToInt32(searchRegion.Y);
                retRect.Width = Convert.ToInt32(searchRegion.Width);
                retRect.Height = Convert.ToInt32(searchRegion.Height);
            }
            else if (nSearchPos == 3)
            {
                CogRectangle searchRegion = (CogRectangle)job.SubTool3.Tool.SearchRegion;
                retRect.X = Convert.ToInt32(searchRegion.X);
                retRect.Y = Convert.ToInt32(searchRegion.Y);
                retRect.Width = Convert.ToInt32(searchRegion.Width);
                retRect.Height = Convert.ToInt32(searchRegion.Height);
            }
            else if (nSearchPos == 4)
            {
                CogRectangle searchRegion = (CogRectangle)job.SubTool4.Tool.SearchRegion;
                retRect.X = Convert.ToInt32(searchRegion.X);
                retRect.Y = Convert.ToInt32(searchRegion.Y);
                retRect.Width = Convert.ToInt32(searchRegion.Width);
                retRect.Height = Convert.ToInt32(searchRegion.Height);
            }
            return retRect;
        }

        public static System.Drawing.Rectangle GetPatternRect(int nSearchPos, CJob job)
        {
            System.Drawing.Rectangle retRect = new System.Drawing.Rectangle();

            if (job.Type.Contains("Pattern"))
            {
                if (nSearchPos == 0)
                {
                    if (job.Tool.Tool.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
                    {
                        CogRectangle TrainRegion = (CogRectangle)job.Tool.Tool.Pattern.TrainRegion;
                        retRect.X = Convert.ToInt32(TrainRegion.X);
                        retRect.Y = Convert.ToInt32(TrainRegion.Y);
                        retRect.Width = Convert.ToInt32(TrainRegion.Width);
                        retRect.Height = Convert.ToInt32(TrainRegion.Height);
                    }
                }
                else if (nSearchPos == 1)
                {
                    CogRectangle TrainRegion = (CogRectangle)job.SubTool1.Tool.Pattern.TrainRegion;
                    retRect.X = Convert.ToInt32(TrainRegion.X);
                    retRect.Y = Convert.ToInt32(TrainRegion.Y);
                    retRect.Width = Convert.ToInt32(TrainRegion.Width);
                    retRect.Height = Convert.ToInt32(TrainRegion.Height);
                }
                else if (nSearchPos == 2)
                {
                    CogRectangle TrainRegion = (CogRectangle)job.SubTool2.Tool.Pattern.TrainRegion;
                    retRect.X = Convert.ToInt32(TrainRegion.X);
                    retRect.Y = Convert.ToInt32(TrainRegion.Y);
                    retRect.Width = Convert.ToInt32(TrainRegion.Width);
                    retRect.Height = Convert.ToInt32(TrainRegion.Height);
                }
                else if (nSearchPos == 3)
                {
                    CogRectangle TrainRegion = (CogRectangle)job.SubTool3.Tool.Pattern.TrainRegion;
                    retRect.X = Convert.ToInt32(TrainRegion.X);
                    retRect.Y = Convert.ToInt32(TrainRegion.Y);
                    retRect.Width = Convert.ToInt32(TrainRegion.Width);
                    retRect.Height = Convert.ToInt32(TrainRegion.Height);
                }
                else if (nSearchPos == 4)
                {
                    CogRectangle TrainRegion = (CogRectangle)job.SubTool4.Tool.Pattern.TrainRegion;
                    retRect.X = Convert.ToInt32(TrainRegion.X);
                    retRect.Y = Convert.ToInt32(TrainRegion.Y);
                    retRect.Width = Convert.ToInt32(TrainRegion.Width);
                    retRect.Height = Convert.ToInt32(TrainRegion.Height);
                }
            }
            else if (job.Type.Contains("Color"))
            {
                retRect = job.valueRect;
            }

            return retRect;
        }

        public static System.Drawing.Rectangle GetPatternRect(int nSearchPos, CJob job, CogPMAlignResult Result)
        {
            System.Drawing.Rectangle retRect = new System.Drawing.Rectangle();
            //CogRectangle searchRegion = (CogRectangle)PMAlign.Tool.SearchRegion;

            if (nSearchPos == 0)
                retRect = CVisionCognex.PatternToRect(job.Tool.Tool, Result);
            else if (nSearchPos == 1)
                retRect = CVisionCognex.PatternToRect(job.SubTool1.Tool, Result);
            else if (nSearchPos == 2)
                retRect = CVisionCognex.PatternToRect(job.SubTool2.Tool, Result);
            else if (nSearchPos == 3)
                retRect = CVisionCognex.PatternToRect(job.SubTool3.Tool, Result);
            else if (nSearchPos == 4)
                retRect = CVisionCognex.PatternToRect(job.SubTool4.Tool, Result);
            return retRect;
        }

        public static Mat GetThresholImage(Mat inImg, int nThreshold, int nCoordinate, int nMethod)
        {
            try
            {
                Mat imgReturn = new Mat();
                Mat imgMono = new Mat();
                if (nCoordinate == (int)CJob.ColorCoordinate.CC_GRAY && nMethod == (int)CJob.ColorMethod.CA_THRESHILD)
                {
                    if (inImg.Channels() == 3)
                        Cv2.CvtColor(inImg, imgMono, ColorConversionCodes.BGR2GRAY);
                    else
                        inImg.CopyTo(imgMono);
                    Cv2.Threshold(imgMono, imgReturn, nThreshold, 255, ThresholdTypes.Binary);
                }
                else if (inImg.Channels() == 3 && nMethod == (int)CJob.ColorMethod.CA_THRESHILD)
                {
                    //Mat[] imgColors = Cv2.Split(inImg);
                    Cv2.CvtColor(inImg, imgMono, ColorConversionCodes.BGR2GRAY);
                    Cv2.Threshold(imgMono, imgReturn, nThreshold, 255, ThresholdTypes.Binary);
                }
                else if (inImg.Channels() == 3 && nMethod == (int)CJob.ColorMethod.CA_ConvertGray)
                {
                    Cv2.CvtColor(inImg, imgReturn, ColorConversionCodes.BGR2GRAY);
                }

                return imgReturn;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return new Mat();
            }
        }
        public static Bitmap RunFilter(Bitmap imgSource, CV_FILTER filter, int nKernelW = 3, int nKernelH = 3, string strKernelShape = "Rectangle", int nParam1 = 0, int nParam2 = 0)
        {
            Bitmap imgResult;
            Mat ImageResult = new Mat();

            try
            {
                Mat Kernel = new Mat();

                if (strKernelShape == "Rectangle") Kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(nKernelW, nKernelH));
                else if (strKernelShape == "Elipse") Kernel = Cv2.GetStructuringElement(MorphShapes.Ellipse, new OpenCvSharp.Size(nKernelW, nKernelH));
                else if (strKernelShape == "Cross") Kernel = Cv2.GetStructuringElement(MorphShapes.Cross, new OpenCvSharp.Size(nKernelW, nKernelH));

                using (Mat ImageSrc = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgSource))
                {
                    if (ImageSrc.Channels() == 3) Cv2.CvtColor(ImageSrc, ImageSrc, ColorConversionCodes.RGB2GRAY);
                    if (ImageSrc.Channels() == 4) Cv2.CvtColor(ImageSrc, ImageSrc, ColorConversionCodes.RGBA2GRAY);

                    switch (filter)
                    {
                        case CV_FILTER.Morp_Open:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.Open, Kernel);
                            break;

                        case CV_FILTER.Morp_Close:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.Close, Kernel);
                            break;

                        case CV_FILTER.Morp_Dilate:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.Dilate, Kernel);
                            break;

                        case CV_FILTER.Morp_Erode:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.Erode, Kernel);
                            break;

                        case CV_FILTER.EQUALIZE_HIST:
                            Cv2.EqualizeHist(ImageSrc, ImageResult);
                            break;

                        case CV_FILTER.EQUALIZE_CLAHE:
                            CLAHE clahe = Cv2.CreateCLAHE(nParam1, new OpenCvSharp.Size(nParam2, nParam2));
                            clahe.Apply(ImageSrc, ImageResult);
                            break;

                        case CV_FILTER.Multply:
                            Cv2.Multiply(ImageSrc, nParam1, ImageResult);
                            //ImageResult = ImageSrc.Multiply(nParam1);
                            break;

                        case CV_FILTER.Gaussian:
                            Cv2.GaussianBlur(ImageSrc, ImageResult, new OpenCvSharp.Size(nKernelW, nKernelH), nParam1);
                            break;

                        case CV_FILTER.Median:
                            Cv2.MedianBlur(ImageSrc, ImageResult, nKernelW);
                            break;

                        case CV_FILTER.Sobel:
                            using (Mat imageSobelX = new Mat())
                            using (Mat imageSobelY = new Mat())
                            {
                                Cv2.Sobel(ImageSrc, imageSobelX, MatType.CV_32F, 2, 0);
                                imageSobelX.ConvertTo(imageSobelX, MatType.CV_8UC1);

                                Cv2.Sobel(ImageSrc, imageSobelY, MatType.CV_32F, 0, 2);
                                imageSobelY.ConvertTo(imageSobelY, MatType.CV_8UC1);

                                Cv2.BitwiseOr(imageSobelX, imageSobelY, ImageResult);
                            }

                            break;
                        case CV_FILTER.None:
                            //ImageResult = ImageSrc.Clone();
                            ImageResult = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgSource);

                            break;
                    }
                }

                imgResult = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(ImageResult);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return null;
            }

            return imgResult;
        }
        public static Mat RunFilter(Mat imgSource, CV_FILTER filter, int nKernelW = 3, int nKernelH = 3, string strKernelShape = "Rectangle", int nParam1 = 0, int nParam2 = 0)
        {
            Mat ImageResult = new Mat();

            try
            {
                Mat Kernel = new Mat();

                if (strKernelShape == "Rectangle") Kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(nKernelW, nKernelH));
                else if (strKernelShape == "Elipse") Kernel = Cv2.GetStructuringElement(MorphShapes.Ellipse, new OpenCvSharp.Size(nKernelW, nKernelH));
                else if (strKernelShape == "Cross") Kernel = Cv2.GetStructuringElement(MorphShapes.Cross, new OpenCvSharp.Size(nKernelW, nKernelH));

                using (Mat ImageSrc = imgSource.Clone())
                {
                    if (ImageSrc.Channels() == 3) Cv2.CvtColor(ImageSrc, ImageSrc, ColorConversionCodes.RGB2GRAY);
                    if (ImageSrc.Channels() == 4) Cv2.CvtColor(ImageSrc, ImageSrc, ColorConversionCodes.RGBA2GRAY);

                    switch (filter)
                    {
                        case CV_FILTER.Morp_Open:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.Open, Kernel);
                            break;
                        case CV_FILTER.Morp_Close:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.Close, Kernel);
                            break;
                        case CV_FILTER.Morp_Dilate:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.Dilate, Kernel);
                            break;
                        case CV_FILTER.Morp_Erode:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.Erode, Kernel);
                            break;
                        case CV_FILTER.EQUALIZE_HIST:
                            Cv2.EqualizeHist(ImageSrc, ImageResult);
                            break;
                        case CV_FILTER.EQUALIZE_CLAHE:
                            CLAHE clahe = Cv2.CreateCLAHE(nParam1, new OpenCvSharp.Size(nParam2, nParam2));
                            clahe.Apply(ImageSrc, ImageResult);
                            break;
                        case CV_FILTER.Gaussian:
                            Cv2.GaussianBlur(ImageSrc, ImageResult, new OpenCvSharp.Size(nKernelW, nKernelH), nParam1);
                            break;
                        case CV_FILTER.Median:
                            Cv2.MedianBlur(ImageSrc, ImageResult, nKernelW);
                            break;
                        case CV_FILTER.Sobel:
                            using (Mat imageSobelX = new Mat())
                            using (Mat imageSobelY = new Mat())
                            {
                                Cv2.Sobel(ImageSrc, imageSobelX, MatType.CV_32F, 2, 0);
                                imageSobelX.ConvertTo(imageSobelX, MatType.CV_8UC1);

                                Cv2.Sobel(ImageSrc, imageSobelY, MatType.CV_32F, 0, 2);
                                imageSobelY.ConvertTo(imageSobelY, MatType.CV_8UC1);

                                Cv2.BitwiseOr(imageSobelX, imageSobelY, ImageResult);
                            }

                            break;
                    }
                }

                return ImageResult;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        public static void DrawResultImage(bool bResult_Job, CJob job, ref Bitmap inImg)
        {
            Global Global = Global.Instance;

            Graphics g = Graphics.FromImage(inImg);

            // Overlay Draw
            System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5);
            System.Drawing.Pen penPatternRegion_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5);
            System.Drawing.Pen penPatternRegion_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 64, 32), 10);
            SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16));
            SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));
            SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(128, 168, 224, 168));
            System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 168, 224, 168), 5);
            System.Drawing.Font font = new System.Drawing.Font("Arial", 18, FontStyle.Bold);
            System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 18, FontStyle.Bold);

            System.Drawing.Rectangle searchRect = GetSearchRect(job.nPatternIndex, job);
            System.Drawing.Rectangle patternRect = GetPatternRect(job.nPatternIndex, job);

            System.Drawing.Point ptJudge = new System.Drawing.Point(job.SearchRegion.Location.X, job.SearchRegion.Location.Y);
            System.Drawing.Point ptRate = new System.Drawing.Point(job.SearchRegion.Location.X, job.SearchRegion.Location.Y + 30);
            if (bResult_Job)
            {
                double dAlarm = job.MinScore + (1.0 - job.MinScore) / (100 / Global.Mode.alarmRatio);
                if (Global.Mode.ResultVisible && job.dRate < dAlarm)
                {
                    DrawStingAdjust(GetJudgeStr(bResult_Job, job, "", "nofuse"), font, brush_ALARM, ptJudge, g, inImg.Width);
                    DrawStingAdjust(GetRateStr(bResult_Job, job, job.dRate), font, brush_ALARM, ptRate, g, inImg.Width);

                    g.DrawRectangle(penSearchRegion, searchRect);
                    g.DrawRectangle(penPatternRegion_ALARM, patternRect);
                }
                else
                {
                    DrawStingAdjust(GetJudgeStr(bResult_Job, job, "", "nofuse"), font, brush_OK, ptJudge, g, inImg.Width);

                    g.DrawRectangle(penSearchRegion, searchRect);
                    g.DrawRectangle(penPatternRegion_OK, patternRect);
                }
            }
            else
            {
                DrawStingAdjust(GetJudgeStr(bResult_Job, job, "", "nofuse"), font_NG, brush_NG, ptJudge, g, inImg.Width);

                if (Global.Mode.ResultVisible)
                    DrawStingAdjust(GetRateStr(bResult_Job, job, job.dRate), font_NG, brush_NG, ptRate, g, inImg.Width);

                g.DrawRectangle(penPatternRegion_NG, searchRect);
                g.DrawRectangle(penPatternRegion_NG, patternRect);
            }
        }

        public static void DrawResultImageAdjust(bool bResult_Job, List<CJob> jobs, int nJobIndex, string str_InspPartName, string str_Result_FuseColor, ref Bitmap inImg)
        {
            Global Global = Global.Instance;

            Graphics g = Graphics.FromImage(inImg);

            // Overlay Draw
            System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5);
            System.Drawing.Pen penPatternRegion_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5);
            System.Drawing.Pen penPatternRegion_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 255, 64, 32), 10);
            SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16));
            SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(180, 255, 64, 32));
            SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(180, 168, 224, 168));
            System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 168, 224, 168), 10);
            System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Regular);
            System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 24, FontStyle.Regular);

            System.Drawing.Rectangle searchRect = GetSearchRect(jobs[nJobIndex].nPatternIndex, jobs[nJobIndex]);
            System.Drawing.Rectangle patternRect = GetPatternRect(jobs[nJobIndex].nPatternIndex, jobs[nJobIndex]);

            System.Drawing.Point ptJudge = new System.Drawing.Point(searchRect.X, searchRect.Y);
            System.Drawing.Point ptRate = new System.Drawing.Point(searchRect.X, searchRect.Y + 30);
            ptJudge.Y += searchRect.Height / 4;
            //System.Drawing.Point ptJudge = new System.Drawing.Point(jobs[nJobIndex].SearchRegion.Location.X, jobs[nJobIndex].SearchRegion.Location.Y);
            //System.Drawing.Point ptRate = new System.Drawing.Point(jobs[nJobIndex].SearchRegion.Location.X, jobs[nJobIndex].SearchRegion.Location.Y + 30);
            if (bResult_Job)
            {
                double dAlarm = jobs[nJobIndex].MinScore + (1.0 - jobs[nJobIndex].MinScore) / (100 / Global.Mode.alarmRatio);
                if (Global.Mode.ResultVisible && jobs[nJobIndex].dRate < dAlarm)
                {
                    ptRate = DrawStingAdjustCheckJobs(GetJudgeStr(bResult_Job, jobs[nJobIndex], str_InspPartName, str_Result_FuseColor), font, brush_ALARM, ptJudge, g, inImg.Width, jobs, nJobIndex);
                    ptRate.Y += 25;
                    DrawStingAdjust(GetOptionStr(bResult_Job, jobs[nJobIndex]), font, brush_ALARM, ptRate, g, inImg.Width);
                    ptRate.Y += 25;
                    DrawStingAdjust(GetRateStr(bResult_Job, jobs[nJobIndex], jobs[nJobIndex].dRate), font, brush_ALARM, ptRate, g, inImg.Width);

                    g.DrawRectangle(penSearchRegion, searchRect);
                    //g.DrawRectangle(penPatternRegion_ALARM, patternRect);
                }
                else
                {
                    ptRate = DrawStingAdjustCheckJobs(GetJudgeStr(bResult_Job, jobs[nJobIndex], str_InspPartName, str_Result_FuseColor), font, brush_OK, ptJudge, g, inImg.Width, jobs, nJobIndex);
                    ptRate.Y += 25;
                    DrawStingAdjust(GetOptionStr(bResult_Job, jobs[nJobIndex]), font, brush_OK, ptRate, g, inImg.Width);

                    g.DrawRectangle(penSearchRegion, searchRect);
                    //g.DrawRectangle(penPatternRegion_OK, patternRect);
                }
            }
            else
            {
                ptRate = DrawStingAdjustCheckJobs(GetJudgeStr(bResult_Job, jobs[nJobIndex], str_InspPartName, str_Result_FuseColor), font_NG, brush_NG, ptJudge, g, inImg.Width, jobs, nJobIndex);

                if (Global.Mode.ResultVisible)
                {
                    ptRate.Y += 25;
                    DrawStingAdjust(GetOptionStr(bResult_Job, jobs[nJobIndex]), font_NG, brush_NG, ptRate, g, inImg.Width);
                    ptRate.Y += 25;
                    DrawStingAdjust(GetRateStr(bResult_Job, jobs[nJobIndex], jobs[nJobIndex].dRate), font_NG, brush_NG, ptRate, g, inImg.Width);
                }

                g.DrawRectangle(penPatternRegion_NG, searchRect);
                //g.DrawRectangle(penPatternRegion_NG, patternRect);
            }
        }

        //2024.03.24 송현수 추가
        public static void DrawResultImageAdjust_OnlyNG(Graphics g, CJob job, string str_InspPartName)
        {
            Global Global = Global.Instance;

            // Overlay Draw
            using(System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5))
            using(System.Drawing.Pen penPatternRegion_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5))
            using(System.Drawing.Pen penPatternRegion_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 255, 64, 32), 20))
            using(SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16)))
            using(SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(180, 255, 64, 32)))
            using(SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(180, 168, 224, 168)))
            using(System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 168, 224, 168), 10))
            using(System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
            using (System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
            {
                System.Drawing.Rectangle searchRect = GetSearchRect(job.nPatternIndex, job);
                System.Drawing.Rectangle patternRect = GetPatternRect(job.nPatternIndex, job);

                System.Drawing.Point ptJudge = new System.Drawing.Point(searchRect.X, searchRect.Y);
                System.Drawing.Point ptRate = new System.Drawing.Point(searchRect.X, searchRect.Y + 30);
                ptJudge.Y += searchRect.Height / 4;

                ptRate = ptJudge;

                if (Global.Mode.ResultVisible)
                {
                    g.DrawString(GetJudgeStr(false, job, str_InspPartName, ""), font_NG, brush_NG, ptRate);
                    ptRate.Y += 25;
                    g.DrawString(GetOptionStr(false, job), font_NG, brush_NG, ptRate);
                    ptRate.Y += 25;
                    g.DrawString(GetRateStr(false, job, job.dRate), font_NG, brush_NG, ptRate);
                }

                g.DrawRectangle(penPatternRegion_NG, searchRect);
            }

                
            //g.DrawRectangle(penPatternRegion_NG, patternRect);
        }

        public static int nQRError = 0;
        // 레시피에 설정되는 part name의 값이 오도록 해주는것이 좋음...
        public const string FUSE = "fuse";
        public const string FUSE_NOLINE = "fuse_noline";


        public static Point2d FindFiducialMark(Recipe_Matching recipe, Bitmap img)
        {
            Point2d pos = new Point2d();
            try
            {
                int mag_1st = 1;
                int mag_2st = 1;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                CTemplateMatching matching = new CTemplateMatching("Matching");
                matching.SetSourceImage(img);
                //img.Save("c:\\img.bmp");
                //recipe.ImageTemplate.Save("c:\\temp.bmp");
                recipe.ScoreMin = 0.5;
                matching.Run(recipe);

                double dMaxScore = double.MinValue;
                Rect rtMaxScore = new Rect();
                Point2d pointMaxScore = new Point2d();

                if (matching.Results.Count > 0)
                {
                    if (dMaxScore < matching.Results[0].Score)
                    {
                        dMaxScore = matching.Results[0].Score;
                        rtMaxScore = matching.Results[0].Bounding;
                        pos = pointMaxScore = matching.Results[0].Center;
                    }

                }

                sw.Stop();
            }
            catch (Exception ex)
            {
                return pos;
            }
            finally
            {

            }

            return pos;
        }
        // nmode = false [자동], true [메뉴얼]

        

        //Main Insp
        public static (bool totalResult, bool qrResult, List<bool> results) MainInsp(int retryCnt, CogImage24PlanarColor[] images, out Bitmap[] imgResults_array, bool bCalcCenter = false, bool manualMode = false, bool folderOpen = false)
        {
            (bool totalResult, bool qrResult, List<bool> results) results = (false, true, new List<bool>());
            Global Global = Global.Instance;

            while (Global.Device.EyeD.RecvResults.Count != 0) Global.Device.EyeD.RecvResults.TryRemove(Global.Device.EyeD.RecvResults.First().Key, out EyeD_Result result);

            // 알고리즘 텍타임용..
            Stopwatch _stopwatch = Stopwatch.StartNew();
            _stopwatch.Start();

            //CLogger.Add(LOG.SEQ, $"SEQ T/T : [{_stopwatch.ElapsedMilliseconds:D4} ms] ==> Start");
            Global.Data.Result_NG_Count = new int[4];

            // 보드 이미지의 카운터 수량에 따라 결과 이미지 생성...
            imgResults_array = new Bitmap[Global.System.Recipe.ArrayCount];
            QRParser cQrCode;
            string strJob = "";
            bool jobsReultTotal = true;

            // 결과 표시 해줄 이미지..
            CogImage24PlanarColor[] imgResultsDrawing = new CogImage24PlanarColor[Global.System.Recipe.ArrayCount];
            CogImage24PlanarColor[] imgResultsDrawingOnlyNG = new CogImage24PlanarColor[Global.System.Recipe.ArrayCount];

            Point2d posFiducial_Board = new Point2d();

            // 메뉴얼 검사 시.체크..
            // 메뉴얼 검사 모드일경우..이미지 세이브 안함...
            if (manualMode)
            {
                if (images == null)
                {
                    IF_Util.ShowMessageBox("EXCEPTION", "Image Buffer Empty");
                    return results;
                }
                else
                {
                    if (images[0] == null)
                    {
                        IF_Util.ShowMessageBox("EXCEPTION", $"Image Buffer[0] Empty. lease Grab or Load !!!");
                        return results;
                    }
                }
            }
            // 자동 검사...
            else
            {
                if (images == null)
                {
                    IF_Util.ShowMessageBox("EXCEPTION", "Image Buffer Empty");
                    return results;
                }
                else
                {
                    if (images.Length == 0)
                    {
                        IF_Util.ShowMessageBox("EXCEPTION", "Image Buffer Empty. Please Grab or Load !!!");
                        return results;
                    }
                    else
                    {
                        for (int i = 0; i < images.Length; i++)
                        {
                            if (images[i] == null)
                            {
                                IF_Util.ShowMessageBox("EXCEPTION", $"Image Buffer[{i}] Empty. lease Grab or Load !!!");
                                return results;
                            }
                        }
                    }
                }
            }

            // 검출 처리 시 사용..
            CogImage24PlanarColor[] images24_board = new CogImage24PlanarColor[images.Length];
            CogImage8Grey[] images8_board = new CogImage8Grey[images.Length];
            Bitmap[] images_bmp = new Bitmap[images.Length];
            Mat[] images_cv = new Mat[images.Length];
            //최대 4연배 바코드 초기화
            for (int i = 0; i < 4; i++) Global.Data.Array_QrCodes[i] = new QRParser();

            try
            {
                Stopwatch tactTime = new Stopwatch();
                tactTime.Start();

                CTemplateMatching matchingLT = new CTemplateMatching("LT");
                CTemplateMatching matchingRB = new CTemplateMatching("RB");

                using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[0].ToBitmap()).Clone())
                {
                    List<double> rotateCycle = new List<double>();

                    for (int rotIdx = 0; rotIdx < 3; rotIdx++)
                    {
                        matchingLT.SetSourceImage(imgOrg);
                        matchingRB.SetSourceImage(imgOrg);

                        matchingLT.Run(Global.System.Recipe.FiducialLibrary.Fiducial1);
                        matchingRB.Run(Global.System.Recipe.FiducialLibrary.Fiducial2);

                        Point2d posLT = new Point2d(0, 0);
                        Point2d posRB = new Point2d(0, 0);

                        Rect rectLT = new Rect();
                        Rect rectRB = new Rect();

                        bool isError = false;

                        if (matchingLT.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (LT)"); isError = true; }
                        if (matchingRB.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (RB)"); isError = true; }

                        if (isError == false)
                        {
                            posLT = matchingLT.Results[0].Center;
                            posRB = matchingRB.Results[0].Center;

                            rectLT = matchingLT.Results[0].Bounding;
                            rectRB = matchingRB.Results[0].Bounding;

                            double angle = IF_Util.GetAngle(posLT, posRB);
                            double angleDelta = angle - Global.System.Recipe.FiducialLibrary.MasterAngle;

                            Point2f posCenter = new Point2f(imgOrg.Width / 2, imgOrg.Height / 2);

                            if (Math.Abs(angleDelta) < 0.05)
                            {
                                matchingLT.Run(Global.System.Recipe.FiducialLibrary.Fiducial1);
                                posFiducial_Board = matchingLT.Results[0].Center;

                                break;
                            }
                            else
                            {
                                rotateCycle.Add(angleDelta);

                                Mat rotationMatrixOrg = Cv2.GetRotationMatrix2D(posCenter, angleDelta, 1.0);
                                Cv2.WarpAffine(imgOrg, imgOrg, rotationMatrixOrg, imgOrg.Size());
                            }
                        }

                    }

                    for (int rotIdx = 0; rotIdx < rotateCycle.Count; rotIdx++)
                    {
                        //2024.03.15 송현수 -> 안춘길 : 이미지 회전 추가
                        for (int i = 0; i < images.Length; i++)
                        {
                            if (images[i] != null && images[i].Allocated)
                            {
                                using (Mat imgSrcforRot = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[i].ToBitmap()))
                                using (Mat imgRot = new Mat())
                                {
                                    Point2f posCenter = new Point2f(imgOrg.Width / 2, imgOrg.Height / 2);

                                    Mat rotationMatrix = Cv2.GetRotationMatrix2D(posCenter, rotateCycle[rotIdx], 1.0);
                                    Cv2.WarpAffine(imgSrcforRot, imgRot, rotationMatrix, imgSrcforRot.Size());

                                    images[i] = new CogImage24PlanarColor(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgRot));
                                }
                            }
                        }
                    }
                }

                CLogger.Add(LOG.INSP, $"Image Align T/T : {tactTime.ElapsedMilliseconds}ms");
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }

            string jobDebug = "";

            using (Mat imgForFiducial = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[0].ToBitmap()))
            using (Pen penPatternRegion_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(175, 156, 255, 16), 5))
            using (Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(175, 255, 224, 16), 5))
            using (Pen pen_Green = new Pen(System.Drawing.Color.FromArgb(175, 156, 255, 16), 5))
            using (Pen pen_Red = new Pen(System.Drawing.Color.FromArgb(200, 255, 64, 32), 5))
            using (Pen pen_RedT = new Pen(System.Drawing.Color.FromArgb(200, 255, 64, 32), 10))
            using (SolidBrush brush_Green = new SolidBrush(System.Drawing.Color.FromArgb(175, 156, 255, 16)))
            using (SolidBrush brush_Red = new SolidBrush(System.Drawing.Color.FromArgb(200, 255, 64, 32)))
            using (SolidBrush brush_RedT = new SolidBrush(System.Drawing.Color.FromArgb(200, 255, 64, 32)))
            using (System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 36, FontStyle.Bold))
            using (System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Bold))
            {
                try
                {
                    for (int arrayIdx = 0; arrayIdx < Global.System.Recipe.ArrayCount; arrayIdx++)
                    {
                        Rectangle region = Global.System.Recipe.FiducialLibrary.GetArrayRegion(arrayIdx);
                        Rectangle cutRegion = new Rectangle();

                        if (arrayIdx == 0) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray1.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray1.Y), region.Width, region.Height);
                        if (arrayIdx == 1) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray2.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray2.Y), region.Width, region.Height);
                        if (arrayIdx == 2) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray3.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray3.Y), region.Width, region.Height);
                        if (arrayIdx == 3) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray4.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray4.Y), region.Width, region.Height);

                        if (cutRegion.Width == 0 || cutRegion.Height == 0) { CAlarm.Add("Error", $"Cut region Failed... Array [{arrayIdx}]"); }

                        #region 그랩인덱스 별 이미지 할당
                        CLogger.Add(LOG.SEQ, $"SEQ T/T : [{_stopwatch.ElapsedMilliseconds:D4} ms] ==> Allocated images Start");
                        for (int i = 0; i < images.Length; i++)
                        {
                            if (images[i] != null && images[i].Allocated)
                            {
                                using (Bitmap imgCrop = IF_Util.Crop(images[i].ToBitmap(), cutRegion))
                                {
                                    images8_board[i] = new CogImage8Grey(imgCrop);
                                    //images_bmp[i] = (Bitmap)imgCrop.Clone();
                                    images24_board[i] = new CogImage24PlanarColor(imgCrop);
                                    images_cv[i] = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgCrop).Clone();
                                }   
                            }
                        }                        

                        DateTime curTm = DateTime.Now;

                        CLogger.Add(LOG.SEQ, $"SEQ T/T : [{_stopwatch.ElapsedMilliseconds:D4} ms] ==> Allocated images Complete");

                        //결과 표시용은 0번 그랩 이미지로 사용
                        imgResultsDrawing[arrayIdx] = new CogImage24PlanarColor(images24_board[0]);
                        #endregion
                        #region 얼라인 후 이미지 크롭 및 연배 내 피듀셜 마크 측정
                        CTemplateMatching matchingArrayFiducial = new CTemplateMatching("LT");
                        matchingArrayFiducial.SetSourceImage(images_cv[0]);

                        if (arrayIdx == 0) matchingArrayFiducial.Run(Global.System.Recipe.FiducialLibrary.Fiducial1, new Rect((int)Global.System.Recipe.FiducialLibrary.OffsetArray1.X - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width / 2, (int)Global.System.Recipe.FiducialLibrary.OffsetArray1.Y - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height / 2, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height));
                        if (arrayIdx == 1) matchingArrayFiducial.Run(Global.System.Recipe.FiducialLibrary.Fiducial1, new Rect((int)Global.System.Recipe.FiducialLibrary.OffsetArray2.X - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width / 2, (int)Global.System.Recipe.FiducialLibrary.OffsetArray2.Y - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height / 2, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height));
                        if (arrayIdx == 2) matchingArrayFiducial.Run(Global.System.Recipe.FiducialLibrary.Fiducial1, new Rect((int)Global.System.Recipe.FiducialLibrary.OffsetArray3.X - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width / 2, (int)Global.System.Recipe.FiducialLibrary.OffsetArray3.Y - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height / 2, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height));
                        if (arrayIdx == 3) matchingArrayFiducial.Run(Global.System.Recipe.FiducialLibrary.Fiducial1, new Rect((int)Global.System.Recipe.FiducialLibrary.OffsetArray4.X - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width / 2, (int)Global.System.Recipe.FiducialLibrary.OffsetArray4.Y - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height / 2, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height));

                        if (matchingArrayFiducial.Results.Count == 0) { CAlarm.Add("Error", $"Can't Find the Mark of Fiducial Array [{arrayIdx}]"); }

                        //거리 측정은 해당 피듀셜을 기준으로
                        Point2d posFiducial_Array = matchingArrayFiducial.Results[0].Center;
                        #endregion

                        if (Global.Mode.QrPass)
                        {
                            cQrCode = new QRParser($"06{Global.Instance.System.Recipe.CODE.Substring(0, 4) + Global.Instance.System.Recipe.CODE.Substring(5, 6)}VENDYMSE{nQRError.ToString("D3")}", true);
                            Global.Instance.Data.Array_QrCodes[arrayIdx] = cQrCode;
                        }
                        else
                        {
                            string qrCode = "";
                            for (int i = 0; i < images8_board.Length; i++)
                            {
                                if (images8_board[i] != null & images8_board[i].Allocated)
                                {
                                    qrCode = IDTool.Read(images8_board[i], Global.Setting.Recipe.Insp.GetQrRegion(arrayIdx), out ICogGraphic resultGraphic);

                                    if (qrCode != "") break;
                                }
                            }
                            
                            if (qrCode == "")
                            {
                                CAlarm.Add("ALARM", $"Can't Read the QR Code ==> Array {arrayIdx}");

                                jobsReultTotal = false;

                                string tempQrCode = "00" + Global.Instance.System.Recipe.Name + DateTime.Now.ToString("MMdd_HHmmss");
                                cQrCode = new QRParser(tempQrCode, true);
                                Global.Instance.Data.Array_QrCodes[arrayIdx] = cQrCode;

                                results.qrResult = false;
                            }
                            else
                            {
                                cQrCode = new QRParser(qrCode, false);
                                Global.Instance.Data.Array_QrCodes[arrayIdx] = cQrCode;

                                // QR Recipe 검증기능이 선택되면
                                if (Global.Instance.Mode.QRModelVerify)
                                {
                                    if (cQrCode.GetQR().Contains(Global.Instance.System.Recipe.Name) == false)
                                    {
                                        CAlarm.Add("ALARM", $"QR Code Model Verify Fail ==> Array {arrayIdx}");
                                        CLogger.Add(LOG.EXCEPTION, $"NG ==> Qr[{cQrCode.GetQR()}] - Model[{Global.Instance.System.Recipe.Name}] Mapping NG ");
                                        jobsReultTotal = false;
                                        cQrCode.SetQRError(true);
                                        Global.Instance.Data.Array_QrCodes[arrayIdx].SetQRError(true);

                                        results.qrResult = false;
                                    }
                                }

                                if (Global.Instance.Mode.QRCheck == true)
                                {
                                    if (cQrCode.GetQR().Contains(Global.Instance.Mode.QRCheckText) == false)
                                    {
                                        CLogger.Add(LOG.EXCEPTION, $"NG ==> Qr[{cQrCode.GetQR()}] - Check[{Global.Instance.Mode.QRCheckText}] Mapping NG ");
                                        jobsReultTotal = false;
                                        cQrCode.SetQRError(true);
                                        Global.Instance.Data.Array_QrCodes[arrayIdx].SetQRError(true);

                                        results.qrResult = false;
                                    }
                                }
                            }

                            if (manualMode) results.qrResult = true;
                        }

                        Bitmap imgResult = imgResultsDrawing[arrayIdx].ToBitmap();
                        Bitmap imgResult_OnlyNG = new Bitmap(imgResult);

                        Graphics g = Graphics.FromImage(imgResult);
                        Graphics g_OnlyNG = Graphics.FromImage(imgResult_OnlyNG);

                        List<CJob> jobs_ng = new List<CJob>();

                        int eyeDCnt = 0;
                        List<(string id, CJob job)> eyeD_UniqueIDs = new List<(string, CJob)>();

                        // QR Reading Error이면 검사 안함...
                        if (results.qrResult)
                        {
                            try
                            {
                                for (int jobIdx = 0; jobIdx < Global.System.Recipe.JobManager[arrayIdx].Jobs.Count; jobIdx++)
                                {
                                    Stopwatch job_stopwatch = Stopwatch.StartNew();

                                    bool jobResult = true;
                                    CJob job = Global.System.Recipe.JobManager[arrayIdx].Jobs[jobIdx];
                                    jobDebug = $"{arrayIdx}_{job.Name}";

                                    //샘플링 검사 n회마다 검사하는 job
                                    if ((Global.Data.CountOK + Global.Data.CountNG_T + Global.Data.CountNG_F) % job.SamplingCount != 0) continue;

                                    //검사할 이미지 인덱스
                                    int grabIdx = job.GrabIndex;
                                    bool jobEnabled = job.Enabled;

                                    if (jobEnabled && !Global.GetPass())
                                    {
                                        if (images8_board[grabIdx] == null || !images8_board[grabIdx].Allocated)
                                        {
                                            jobResult = false;
                                            jobsReultTotal = false;

                                            IF_Util.ShowMessageBox("ERROR", $"Check the Grab Manager Index ==> [{job.Name}]");
                                        }
                                        else
                                        {
                                            strJob = $"ARRAY : {arrayIdx} JOB : {job.Name}";

                                            //Main Type
                                            switch (job.Type)
                                            {
                                                case JOB_TYPE.Pattern:
                                                    {
                                                        // Multi Pattern 검사 (IC Leads 등)
                                                        if (job.MasterCount != 1)
                                                        {
                                                            jobResult = Inspection_ICRead(g, g_OnlyNG, job, images8_board, grabIdx, penSearchRegion, penPatternRegion_OK, jobIdx, jobResult, font, font_NG, brush_Green, brush_Red, cutRegion, arrayIdx);
                                                        }
                                                        // Single Pattern 검사 (일반 검사)
                                                        else
                                                        {
                                                            jobResult = Inspection_PatternMatching(g, g_OnlyNG, job, images8_board, grabIdx, images24_board, jobResult, arrayIdx, jobIdx, jobEnabled, bCalcCenter, out Rectangle detectedRect);

                                                            if (job.Parameter.EyeD_UseColorInsp)
                                                            {
                                                                jobResult &= Algorithm_ColorEx(g, job, CConverter.RectToCVRect(detectedRect), images_cv[job.GrabIndex]);
                                                            }
                                                        }
                                                    }
                                                    break;

                                                case JOB_TYPE.Color: jobResult = Inspection_Color(g, job, images24_board, grabIdx, penPatternRegion_OK, jobResult, arrayIdx, imgResult, jobIdx); break;
                                                case JOB_TYPE.Condensor: jobResult = Algorithm_Condensor(g, job, images8_board, grabIdx, penPatternRegion_OK, arrayIdx, jobIdx); break;
                                                case JOB_TYPE.Distance: jobResult = Algorithm_Distance(posFiducial_Array, g, job, images8_board, grabIdx, penPatternRegion_OK); break;
                                                case JOB_TYPE.Blob: jobResult = Inspection_Fin_Brightness(g, job, images8_board, grabIdx, penPatternRegion_OK, arrayIdx, jobIdx); break;
                                                case JOB_TYPE.ColorEx: jobResult = Algorithm_ColorEx(g, job, images_cv[job.GrabIndex]); break;
                                                case JOB_TYPE.EYED:
                                                    {
                                                        try
                                                        {
                                                            Thread.Sleep(1);
                                                            CLogger.Add(LOG.INSP, $"JOB NAME : {job.Name} => EYE-D INSP START");
                                                            Algorithm_EYED(g, job, images_cv[grabIdx], out string uniqueID);

                                                            bool isRecv = false;
                                                            Stopwatch tt = Stopwatch.StartNew();

                                                            while (tt.ElapsedMilliseconds < 5000)
                                                            {
                                                                Thread.Sleep(10);

                                                                if (Global.Device.EyeD.RecvResults.ContainsKey(uniqueID))
                                                                {
                                                                    isRecv = true;
                                                                    break;
                                                                }
                                                            }

                                                            if (isRecv)
                                                            {
                                                                if (Global.Device.EyeD.RecvResults.ContainsKey(uniqueID))
                                                                {
                                                                    EyeD_Result eyeD_Result = Global.Device.EyeD.RecvResults[uniqueID];

                                                                    string inferType = job.Parameter.EyeD_InferType;

                                                                    List<string> resultList = new List<string>();
                                                                    MatchCollection matches = Regex.Matches(eyeD_Result.ResultString, @"\([^()]*\)");
                                                                    foreach (Match match in matches) resultList.Add(match.Value);

                                                                    if (resultList.Count > 0)
                                                                    {
                                                                        switch (inferType)
                                                                        {
                                                                            case "CLS":
                                                                                {
                                                                                    string bestTag = "";
                                                                                    double bestScore = 0.0D;

                                                                                    for (int i = 1; i < resultList.Count; i++)
                                                                                    {
                                                                                        double score = 0.0D;

                                                                                        string[] values = resultList[i].Replace("(", "").Replace(")", "").Split(";");

                                                                                        if (values.Length == 2)
                                                                                        {
                                                                                            double.TryParse(values[1], out score);

                                                                                            if (bestScore < score)
                                                                                            {
                                                                                                bestScore = score;
                                                                                                bestTag = values[0];
                                                                                            }
                                                                                        }
                                                                                    }

                                                                                    if (job.Parameter.EyeD_CorrectAnswer == bestTag
                                                                                        && job.Parameter.EyeD_MinScore <= bestScore)
                                                                                    {
                                                                                        g.DrawRectangle(pen_Green, job.SearchRegion);
                                                                                        g.DrawString($"OK-{job.Name}({bestTag}:{bestScore:F2})", font, brush_Green, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        g.DrawRectangle(pen_Red, job.SearchRegion);
                                                                                        g.DrawString($"NG-{job.Name}({bestTag}:{bestScore:F2})", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                                                                        g_OnlyNG.DrawRectangle(pen_RedT, job.SearchRegion);
                                                                                        g_OnlyNG.DrawString($"NG-{job.Name}({bestTag}:{bestScore:F2})", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                                                                        jobResult = false;
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case "DET":
                                                                                {
                                                                                    double score = 0.0D;
                                                                                    int sucessCnt = 0;

                                                                                    for (int i = 1; i < resultList.Count; i++)
                                                                                    {
                                                                                        string[] values = resultList[i].Replace("(", "").Replace(")", "").Split(";");

                                                                                        if (values.Length == 6)
                                                                                        {
                                                                                            string tag = values[0];
                                                                                            double.TryParse(values[1], out score);
                                                                                            bool tagOK = true;
                                                                                            bool success = true;
                                                                                            success &= int.TryParse(values[2], out int x);
                                                                                            success &= int.TryParse(values[3], out int y);
                                                                                            success &= int.TryParse(values[4], out int w);
                                                                                            success &= int.TryParse(values[5], out int h);

                                                                                            if (success)
                                                                                            {
                                                                                                Rectangle resultRect = new Rectangle();
                                                                                                resultRect.X = job.SearchRegion.X + x;
                                                                                                resultRect.Y = job.SearchRegion.Y + y;
                                                                                                resultRect.Width = w;
                                                                                                resultRect.Height = h;

                                                                                                bool inspSuccess = true;

                                                                                                if (job.Parameter.EyeD_CorrectAnswer == "")
                                                                                                {
                                                                                                    tagOK = true;
                                                                                                }
                                                                                                else if (job.Parameter.EyeD_CorrectAnswer != "" && job.Parameter.EyeD_CorrectAnswer != tag)
                                                                                                {
                                                                                                    tagOK = false;
                                                                                                }

                                                                                                if (job.Parameter.EyeD_UseColorInsp)
                                                                                                {
                                                                                                    if (job.Parameter.EyeD_MinScore <= score && tagOK)
                                                                                                    {
                                                                                                        using (Mat imgCrop = images_cv[job.GrabIndex].SubMat(CConverter.RectToCVRect(job.SearchRegion)).Clone())
                                                                                                        {
                                                                                                            Scalar scalar = imgCrop.SubMat(new Rect(x, y, w, h)).Mean();
                                                                                                            // 평균 색상 값을 BGR 형식으로 각각 추출
                                                                                                            byte meanB = (byte)scalar.Val0;
                                                                                                            byte meanG = (byte)scalar.Val1;
                                                                                                            byte meanR = (byte)scalar.Val2;

                                                                                                            string colorName = "";
                                                                                                            for (int colorIdx = 0; colorIdx < Global.Setting.Enviroment.ColorList.ColorNodes.Count; colorIdx++)
                                                                                                            {
                                                                                                                if (Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].InRange(meanR, meanG, meanB))
                                                                                                                {
                                                                                                                    colorName = Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].Name;
                                                                                                                    break;
                                                                                                                }
                                                                                                            }

                                                                                                            if (job.Parameter.EyeD_CorrectColor == colorName)
                                                                                                            {
                                                                                                                g.DrawRectangle(pen_Green, resultRect);
                                                                                                                g.DrawString($"OK-{job.Name}({tag}:{score:F2})({colorName})", font, brush_Green, resultRect.X + 5, resultRect.Y + 5);
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                inspSuccess = false;
                                                                                                                g.DrawRectangle(pen_Red, resultRect);
                                                                                                                g.DrawString($"NG-{job.Name}({tag}:{score:F2})({colorName})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                                                                                                g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                                                                                                g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})({colorName})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        inspSuccess = false;

                                                                                                        if (tagOK)
                                                                                                        {
                                                                                                            g.DrawRectangle(pen_Red, resultRect);
                                                                                                            g.DrawString($"NG-{job.Name}({tag}:{score:F2})(LOW SCORE)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                                                                                            g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                                                                                            g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(LOW SCORE)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            g.DrawRectangle(pen_Red, resultRect);
                                                                                                            g.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                                                                                            g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                                                                                            g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                                                                                        }
                                                                                                    }
                                                                                                }

                                                                                                if (job.Parameter.EyeD_UseDistance)
                                                                                                {
                                                                                                    if (job.Parameter.EyeD_MinScore <= score && tagOK)
                                                                                                    {
                                                                                                        Point2d pos = posFiducial_Array;

                                                                                                        Point2d lineCenter = new Point2d(resultRect.X, resultRect.Y);

                                                                                                        CogLineSegment lineX = new CogLineSegment();
                                                                                                        lineX.StartX = pos.X;
                                                                                                        lineX.StartY = pos.Y;
                                                                                                        lineX.EndX = lineCenter.X;
                                                                                                        lineX.EndY = pos.Y;
                                                                                                        lineX.Color = CogColorConstants.Red;

                                                                                                        CogLineSegment lineY = new CogLineSegment();
                                                                                                        lineY.StartX = pos.X;
                                                                                                        lineY.StartY = pos.Y;
                                                                                                        lineY.EndX = pos.X;
                                                                                                        lineY.EndY = lineCenter.Y;
                                                                                                        lineY.Color = CogColorConstants.Red;

                                                                                                        double distanceX = lineX.Length;
                                                                                                        double distanceY = lineY.Length;

                                                                                                        bool distResult = true;
                                                                                                        if (job.Parameter.UseDistanceX)
                                                                                                        {
                                                                                                            if (distanceX > job.Parameter.DistanceXMax) distResult = false;
                                                                                                            if (distanceX < job.Parameter.DistanceXMin) distResult = false;
                                                                                                        }

                                                                                                        if (job.Parameter.UseDistanceY)
                                                                                                        {
                                                                                                            if (distanceY > job.Parameter.DistanceYMax) distResult = false;
                                                                                                            if (distanceY < job.Parameter.DistanceYMin) distResult = false;
                                                                                                        }

                                                                                                        if (distResult)
                                                                                                        {
                                                                                                            g.DrawRectangle(pen_Green, resultRect);
                                                                                                            g.DrawString($"OK-{job.Name}({tag}:{score:F2})(DIST X : {distanceX} Y : {distanceY})", font, brush_Green, resultRect.X + 5, resultRect.Y + 5);
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (inspSuccess == true)
                                                                                                            {
                                                                                                                g.DrawRectangle(pen_Red, resultRect);
                                                                                                                g.DrawString($"NG-{job.Name}({tag}:{score:F2})(DIST X : {distanceX} Y : {distanceY})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                                                                                                g_OnlyNG.DrawRectangle(pen_Red, resultRect);
                                                                                                                g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(DIST X : {distanceX} Y : {distanceY})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                                                                                            }

                                                                                                            inspSuccess = false;
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {

                                                                                                        //if (inspSuccess == true)
                                                                                                        //{
                                                                                                        //    if (tagOK)
                                                                                                        //    {
                                                                                                        //        g.DrawRectangle(pen_Red, resultRect);
                                                                                                        //        g.DrawString($"NG-{job.Name}({tag}:{score:F2})(LOW SCORE)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                                                                                        //        g_OnlyNG.DrawRectangle(pen_Red, resultRect);
                                                                                                        //        g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(LOW SCORE)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                                                                                        //    }
                                                                                                        //    else
                                                                                                        //    {
                                                                                                        //        g.DrawRectangle(pen_Red, resultRect);
                                                                                                        //        g.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                                                                                        //        g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                                                                                        //        g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                                                                                        //    }

                                                                                                        //}

                                                                                                        inspSuccess = false;
                                                                                                    }
                                                                                                }

                                                                                                if (job.Parameter.EyeD_MinScore <= score && tagOK)
                                                                                                {
                                                                                                    g.DrawRectangle(pen_Green, resultRect);
                                                                                                    g.DrawString($"OK-{job.Name}({tag}:{score:F2})", font, brush_Green, resultRect.X + 5, resultRect.Y + 5);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (inspSuccess == true)
                                                                                                    {
                                                                                                        if (tagOK)
                                                                                                        {
                                                                                                            if (score >= 0.3)
                                                                                                            {
                                                                                                                //g.DrawRectangle(pen_Red, resultRect);
                                                                                                                //g.DrawString($"NG-{job.Name}({tag}:{score:F2})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                                                                                                //g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                                                                                                //g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (score >= 0.3)
                                                                                                            {
                                                                                                                //g.DrawRectangle(pen_Red, resultRect);
                                                                                                                //g.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                                                                                                //g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                                                                                                //g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                                                                                            }
                                                                                                        }

                                                                                                    }

                                                                                                    inspSuccess = false;
                                                                                                }

                                                                                                if (inspSuccess) sucessCnt++;
                                                                                            }
                                                                                        }
                                                                                    }

                                                                                    if (job.Parameter.EyeD_MasterCount == sucessCnt)
                                                                                    {
                                                                                        g.DrawRectangle(pen_Green, job.SearchRegion);
                                                                                        g.DrawString($"OK-{job.Name}", font, brush_Green, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        jobResult = false;
                                                                                        g.DrawRectangle(pen_Red, job.SearchRegion);
                                                                                        g.DrawString($"NG-{job.Name}({sucessCnt}/{job.Parameter.EyeD_MasterCount})", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                                                                        g_OnlyNG.DrawRectangle(pen_RedT, job.SearchRegion);
                                                                                        g_OnlyNG.DrawString($"NG-{job.Name}({sucessCnt}/{job.Parameter.EyeD_MasterCount})", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case "OBB":
                                                                                {

                                                                                }
                                                                                break;
                                                                            case "SEG":
                                                                                {

                                                                                }
                                                                                break;
                                                                            case "OCR":
                                                                                {

                                                                                }
                                                                                break;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        jobResult = false;
                                                                        g.DrawRectangle(pen_Red, job.SearchRegion);
                                                                        g.DrawString($"NG-{job.Name}(N/A)", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                                                        g_OnlyNG.DrawRectangle(pen_Red, job.SearchRegion);
                                                                        g_OnlyNG.DrawString($"NG-{job.Name}(N/A)", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    jobResult = false;
                                                                    g.DrawRectangle(pen_Red, job.SearchRegion);
                                                                    g.DrawString($"NG-{job.Name}(TIME OUT #1)", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                                                    g_OnlyNG.DrawRectangle(pen_Red, job.SearchRegion);
                                                                    g_OnlyNG.DrawString($"NG-{job.Name}(TIME OUT #1)", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                jobResult = false;
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2} ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message, jobDebug);
                                                        }
                                                        
                                                    }
                                                    break;
                                            }

                                            //결과 드로잉 : EYED 검사는 아래서 결과를 드로잉
                                            if (job.Type != JOB_TYPE.EYED)
                                            {
                                                DrawResultImageAdjust(jobResult, Global.Instance.System.Recipe.JobManager[arrayIdx].Jobs, jobIdx, "", "nofuse", ref imgResult);
                                            }
                                        }

                                        // NG일경우....
                                        if (jobResult == false)
                                        {
                                            DrawResultImageAdjust_OnlyNG(g_OnlyNG, job, "");

                                            // 부품별로의 검사 텍을 남겨야함..
                                            job.Result_TackTime = job_stopwatch.ElapsedMilliseconds;
                                            jobs_ng.Add(job);
                                        }
                                    }

                                    //CLogger.Add(LOG.SEQ, $"SEQ T/T : [{_stopwatch.ElapsedMilliseconds:D4} ms] ==> Job [{job.Name}] Time : {job_stopwatch.ElapsedMilliseconds}ms Complete");
                                }

                                //Task<bool> taskEyeD = Task.Run(() =>
                                //{
                                //    Stopwatch tt = Stopwatch.StartNew();

                                //    while (tt.ElapsedMilliseconds < 5000)
                                //    {
                                //        int totalCnt = eyeD_UniqueIDs.Count;
                                //        int recvCnt = 0;
                                //        for (int i = 0; i < eyeD_UniqueIDs.Count; i++)
                                //        {
                                //            if (Global.Device.EyeD.RecvResults.ContainsKey(eyeD_UniqueIDs[i].id))
                                //            {
                                //                recvCnt++;
                                //            }
                                //        }
                                        
                                //        if (totalCnt == recvCnt)
                                //        {
                                //            return true;
                                //        }
                                //        else
                                //        {
                                //            Thread.Sleep(100);
                                //        }

                                //        Thread.Sleep(10);
                                //    }

                                //    return false;
                                //});

                                //if(eyeDCnt > 0)
                                //{
                                //    taskEyeD.Wait(10000);
                                //    bool result_eyeD = taskEyeD.Result;

                                //    for (int idIdx = 0; idIdx < eyeD_UniqueIDs.Count; idIdx++)
                                //    {
                                //        CJob job = eyeD_UniqueIDs[idIdx].job;

                                //        if (Global.Device.EyeD.RecvResults.ContainsKey(eyeD_UniqueIDs[idIdx].id))
                                //        {
                                //            EyeD_Result eyeD_Result = Global.Device.EyeD.RecvResults[eyeD_UniqueIDs[idIdx].id];

                                //            string inferType = eyeD_UniqueIDs[idIdx].job.Parameter.EyeD_InferType;

                                //            List<string> resultList = new List<string>();
                                //            MatchCollection matches = Regex.Matches(eyeD_Result.ResultString, @"\([^()]*\)");
                                //            foreach (Match match in matches) resultList.Add(match.Value);                                            

                                //            if (resultList.Count > 0)
                                //            {
                                //                switch (inferType)
                                //                {
                                //                    case "CLS":
                                //                        {
                                //                            string bestTag = "";
                                //                            double bestScore = 0.0D;

                                //                            for (int i = 1; i < resultList.Count; i++)
                                //                            {
                                //                                double score = 0.0D;

                                //                                string[] values = resultList[i].Replace("(", "").Replace(")", "").Split(";");

                                //                                if (values.Length == 2)
                                //                                {
                                //                                    double.TryParse(values[1], out score);

                                //                                    if (bestScore < score)
                                //                                    {
                                //                                        bestScore = score;
                                //                                        bestTag = values[0];
                                //                                    }
                                //                                }
                                //                            }

                                //                            if ( job.Parameter.EyeD_CorrectAnswer == bestTag
                                //                                && job.Parameter.EyeD_MinScore <= bestScore)
                                //                            {
                                //                                g.DrawRectangle(pen_Green, job.SearchRegion);
                                //                                g.DrawString($"OK-{job.Name}({bestTag}:{bestScore:F2})", font, brush_Green, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);
                                //                            }
                                //                            else
                                //                            {
                                //                                g.DrawRectangle(pen_Red, job.SearchRegion);
                                //                                g.DrawString($"NG-{job.Name}({bestTag}:{bestScore:F2})", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                //                                g_OnlyNG.DrawRectangle(pen_RedT, job.SearchRegion);
                                //                                g_OnlyNG.DrawString($"NG-{job.Name}({bestTag}:{bestScore:F2})", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                //                                jobs_ng.Add(job);
                                //                            }
                                //                        }
                                //                        break;
                                //                    case "DET":
                                //                        {
                                //                            double score = 0.0D;
                                //                            int sucessCnt = 0;

                                //                            for (int i = 1; i < resultList.Count; i++)
                                //                            {
                                //                                string[] values = resultList[i].Replace("(", "").Replace(")", "").Split(";");

                                //                                if (values.Length == 6)
                                //                                {
                                //                                    string tag = values[0];
                                //                                    double.TryParse(values[1], out score);
                                //                                    bool tagOK = true;
                                //                                    bool success = true;
                                //                                    success &= int.TryParse(values[2], out int x);
                                //                                    success &= int.TryParse(values[3], out int y);
                                //                                    success &= int.TryParse(values[4], out int w);
                                //                                    success &= int.TryParse(values[5], out int h);

                                //                                    if (success)
                                //                                    {
                                //                                        Rectangle resultRect = new Rectangle();
                                //                                        resultRect.X = job.SearchRegion.X + x;
                                //                                        resultRect.Y = job.SearchRegion.Y + y;
                                //                                        resultRect.Width = w;
                                //                                        resultRect.Height = h;

                                //                                        bool inspSuccess = true;

                                //                                        if (job.Parameter.EyeD_CorrectAnswer == "")
                                //                                        {
                                //                                            tagOK = true;
                                //                                        }
                                //                                        else if (job.Parameter.EyeD_CorrectAnswer != "" && job.Parameter.EyeD_CorrectAnswer != tag)
                                //                                        {
                                //                                            tagOK = false;
                                //                                        }                                                                        
                                                                        
                                //                                        if (job.Parameter.EyeD_UseColorInsp)
                                //                                        {
                                //                                            if (job.Parameter.EyeD_MinScore <= score && tagOK)
                                //                                            {
                                //                                                using (Mat imgCrop = images_cv[job.GrabIndex].SubMat(CConverter.RectToCVRect(job.SearchRegion)).Clone())
                                //                                                {
                                //                                                    Scalar scalar = imgCrop.SubMat(new Rect(x, y, w, h)).Mean();
                                //                                                    // 평균 색상 값을 BGR 형식으로 각각 추출
                                //                                                    byte meanB = (byte)scalar.Val0;
                                //                                                    byte meanG = (byte)scalar.Val1;
                                //                                                    byte meanR = (byte)scalar.Val2;

                                //                                                    string colorName = "";
                                //                                                    for (int colorIdx = 0; colorIdx < Global.Setting.Enviroment.ColorList.ColorNodes.Count; colorIdx++)
                                //                                                    {
                                //                                                        if (Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].InRange(meanR, meanG, meanB))
                                //                                                        {
                                //                                                            colorName = Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].Name;
                                //                                                            break;
                                //                                                        }
                                //                                                    }

                                //                                                    if (job.Parameter.EyeD_CorrectColor == colorName)
                                //                                                    {
                                //                                                        g.DrawRectangle(pen_Green, resultRect);
                                //                                                        g.DrawString($"OK-{job.Name}({tag}:{score:F2})({colorName})", font, brush_Green, resultRect.X + 5, resultRect.Y + 5);
                                //                                                    }
                                //                                                    else
                                //                                                    {
                                //                                                        inspSuccess = false;
                                //                                                        g.DrawRectangle(pen_Red, resultRect);
                                //                                                        g.DrawString($"NG-{job.Name}({tag}:{score:F2})({colorName})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                //                                                        g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                //                                                        g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})({colorName})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                //                                                    }
                                //                                                }
                                //                                            }
                                //                                            else
                                //                                            {
                                //                                                inspSuccess = false;

                                //                                                if(tagOK)
                                //                                                {
                                //                                                    g.DrawRectangle(pen_Red, resultRect);
                                //                                                    g.DrawString($"NG-{job.Name}({tag}:{score:F2})(LOW SCORE)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                //                                                    g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                //                                                    g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(LOW SCORE)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                //                                                }
                                //                                                else
                                //                                                {
                                //                                                    g.DrawRectangle(pen_Red, resultRect);
                                //                                                    g.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                //                                                    g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                //                                                    g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                //                                                }
                                //                                            }   
                                //                                        }

                                //                                        if (job.Parameter.EyeD_UseDistance)
                                //                                        {
                                //                                            if (job.Parameter.EyeD_MinScore <= score && tagOK)
                                //                                            {
                                //                                                Point2d pos = posFiducial_Array;

                                //                                                Point2d lineCenter = new Point2d(resultRect.X, resultRect.Y);

                                //                                                CogLineSegment lineX = new CogLineSegment();
                                //                                                lineX.StartX = pos.X;
                                //                                                lineX.StartY = pos.Y;
                                //                                                lineX.EndX = lineCenter.X;
                                //                                                lineX.EndY = pos.Y;
                                //                                                lineX.Color = CogColorConstants.Red;

                                //                                                CogLineSegment lineY = new CogLineSegment();
                                //                                                lineY.StartX = pos.X;
                                //                                                lineY.StartY = pos.Y;
                                //                                                lineY.EndX = pos.X;
                                //                                                lineY.EndY = lineCenter.Y;
                                //                                                lineY.Color = CogColorConstants.Red;

                                //                                                double distanceX = lineX.Length;
                                //                                                double distanceY = lineY.Length;

                                //                                                bool distResult = true;
                                //                                                if (job.Parameter.UseDistanceX)
                                //                                                {
                                //                                                    if (distanceX > job.Parameter.DistanceXMax) distResult = false;
                                //                                                    if (distanceX < job.Parameter.DistanceXMin) distResult = false;
                                //                                                }

                                //                                                if (job.Parameter.UseDistanceY)
                                //                                                {
                                //                                                    if (distanceY > job.Parameter.DistanceYMax) distResult = false;
                                //                                                    if (distanceY < job.Parameter.DistanceYMin) distResult = false;
                                //                                                }

                                //                                                if (distResult)
                                //                                                {
                                //                                                    g.DrawRectangle(pen_Green, resultRect);
                                //                                                    g.DrawString($"OK-{job.Name}({tag}:{score:F2})(DIST X : {distanceX} Y : {distanceY})", font, brush_Green, resultRect.X + 5, resultRect.Y + 5);
                                //                                                }
                                //                                                else
                                //                                                {
                                //                                                    if (inspSuccess == true)
                                //                                                    {
                                //                                                        g.DrawRectangle(pen_Red, resultRect);
                                //                                                        g.DrawString($"NG-{job.Name}({tag}:{score:F2})(DIST X : {distanceX} Y : {distanceY})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                //                                                        g_OnlyNG.DrawRectangle(pen_Red, resultRect);
                                //                                                        g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(DIST X : {distanceX} Y : {distanceY})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                //                                                    }

                                //                                                    inspSuccess = false;
                                //                                                }                                                                                
                                //                                            }
                                //                                            else
                                //                                            {
                                                                                
                                //                                                if (inspSuccess == true)
                                //                                                {
                                //                                                    if (tagOK)
                                //                                                    {
                                //                                                        g.DrawRectangle(pen_Red, resultRect);
                                //                                                        g.DrawString($"NG-{job.Name}({tag}:{score:F2})(LOW SCORE)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                //                                                        g_OnlyNG.DrawRectangle(pen_Red, resultRect);
                                //                                                        g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(LOW SCORE)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                //                                                    }
                                //                                                    else
                                //                                                    {
                                //                                                        g.DrawRectangle(pen_Red, resultRect);
                                //                                                        g.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                //                                                        g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                //                                                        g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                //                                                    }
                                                                                    
                                //                                                }

                                //                                                inspSuccess = false;
                                //                                            }
                                //                                        }

                                //                                        if (job.Parameter.EyeD_MinScore <= score && tagOK)
                                //                                        {
                                //                                            g.DrawRectangle(pen_Green, resultRect);
                                //                                            g.DrawString($"OK-{job.Name}({tag}:{score:F2})", font, brush_Green, resultRect.X + 5, resultRect.Y + 5);
                                //                                        }
                                //                                        else
                                //                                        {
                                //                                            if (inspSuccess == true)
                                //                                            {
                                //                                                if (tagOK)
                                //                                                {
                                //                                                    if (score >= 0.3)
                                //                                                    {
                                //                                                        g.DrawRectangle(pen_Red, resultRect);
                                //                                                        g.DrawString($"NG-{job.Name}({tag}:{score:F2})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                //                                                        g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                //                                                        g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                //                                                    }
                                //                                                }
                                //                                                else
                                //                                                {
                                //                                                    if (score >= 0.3)
                                //                                                    {
                                //                                                        g.DrawRectangle(pen_Red, resultRect);
                                //                                                        g.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);

                                //                                                        g_OnlyNG.DrawRectangle(pen_RedT, resultRect);
                                //                                                        g_OnlyNG.DrawString($"NG-{job.Name}({tag}:{score:F2})(WRONG MATCH)", font, brush_Red, resultRect.X + 5, resultRect.Y + 5);
                                //                                                    }   
                                //                                                }
                                                                               
                                //                                            }

                                //                                            inspSuccess = false;
                                //                                        }

                                //                                        if (inspSuccess) sucessCnt++;
                                //                                    }
                                //                                }
                                //                            }

                                //                            if (job.Parameter.EyeD_MasterCount == sucessCnt)
                                //                            {
                                //                                g.DrawRectangle(pen_Green, job.SearchRegion);
                                //                                g.DrawString($"OK-{job.Name}", font, brush_Green, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);
                                //                            }
                                //                            else
                                //                            {
                                //                                g.DrawRectangle(pen_Red, job.SearchRegion);
                                //                                g.DrawString($"NG-{job.Name}({sucessCnt}/{job.Parameter.EyeD_MasterCount})", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                //                                g_OnlyNG.DrawRectangle(pen_RedT, job.SearchRegion);
                                //                                g_OnlyNG.DrawString($"NG-{job.Name}({sucessCnt}/{job.Parameter.EyeD_MasterCount})", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                //                                jobs_ng.Add(job);
                                //                            }
                                //                        }
                                //                        break;
                                //                    case "SEG":
                                //                        {

                                //                        }
                                //                        break;
                                //                    case "OCR":
                                //                        {

                                //                        }
                                //                        break;
                                //                }
                                //            }
                                //            else
                                //            {
                                //                g.DrawRectangle(pen_Red, job.SearchRegion);
                                //                g.DrawString($"NG-{job.Name}(COMM FAIL)", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                //                g_OnlyNG.DrawRectangle(pen_Red, job.SearchRegion);
                                //                g_OnlyNG.DrawString($"NG-{job.Name}(COMM FAIL)", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                //                jobs_ng.Add(job);
                                //            }
                                           
                                //        }
                                //        else
                                //        {
                                //            g.DrawRectangle(pen_Red, job.SearchRegion);
                                //            g.DrawString($"NG-{job.Name}(TIME OUT)", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                //            g_OnlyNG.DrawRectangle(pen_Red, job.SearchRegion);
                                //            g_OnlyNG.DrawString($"NG-{job.Name}(TIME OUT)", font, brush_Red, job.SearchRegion.X + 5, job.SearchRegion.Y + 5);

                                //            jobs_ng.Add(eyeD_UniqueIDs[idIdx].job);
                                //        }                   
                                //    }
                                //}
                            }
                            catch (Exception ex)
                            {
                                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2} ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message, jobDebug);
                            }

                            // NG가 있을경우..해당 보드 NG 판정..
                            if (jobs_ng.Count > 0)
                            {
                                jobsReultTotal = false;
                                Global.Data.Result_NG_Count[arrayIdx] = jobs_ng.Count;

                                for (int i = 0; i < jobs_ng.Count; i++)
                                {
                                    CLogger.Add(LOG.ABNORMAL, $"Array {arrayIdx} Job : {jobs_ng[i].Name} NG");
                                }
                            }
                            else jobsReultTotal = true;
                        }
                        else
                        {
                            jobsReultTotal = false;
                        }

                        System.Drawing.Point ptDraw = new System.Drawing.Point();

                        Cognex.VisionPro.CogRectangle rt = Global.Setting.Recipe.Insp.GetQrCogRegion(arrayIdx);

                        if (rt != null)
                        {
                            ptDraw.X = (int)Math.Round(rt.CenterX);
                            ptDraw.Y = (int)Math.Round(rt.CenterY);
                            cQrCode.SetPt(ptDraw);
                            Global.Instance.Data.Array_QrCodes[arrayIdx].SetPt(ptDraw);
                        }

                        // QR 그리기..
                        Bitmap QR_RESULT_TOTAL;
                        Bitmap QR_RESULT_ONLYNG;

                        Mat IMG_TOTAL = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgResult).Clone();
                        Mat QR_IMG_TOTAL = QR_DRAW(IMG_TOTAL, cQrCode, arrayIdx, out QR_RESULT_TOTAL);
                        imgResult = (Bitmap)QR_RESULT_TOTAL.Clone();

                        Mat IMG_ONLYNG = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgResult_OnlyNG).Clone();
                        Mat QR_IMG_ONLYNG = QR_DRAW(IMG_ONLYNG, cQrCode, arrayIdx, out QR_RESULT_ONLYNG);
                        imgResult_OnlyNG = (Bitmap)QR_RESULT_ONLYNG.Clone();

                        // QR CODE ERROR가 아닐때..
                        if (results.qrResult)
                        {
                            //2024.03.24 송현수 : 저장 누락 확인을 위한 시퀀스 개선

                            IMG_SAVE saveInfo = new IMG_SAVE();
                            saveInfo.GrabIndex = 1;
                            saveInfo.Result = jobsReultTotal;
                            saveInfo.QR_Code = cQrCode;
                            saveInfo.ArrayIndex = arrayIdx;
                            saveInfo.Result_Time = curTm;
                            saveInfo.InspecTackTime = _stopwatch.ElapsedMilliseconds;   // 검사 텍타임을 찍어줘야함...

                            if (jobsReultTotal)
                            {
                                g.DrawRectangle(new System.Drawing.Pen(brush_Green, 10), new System.Drawing.Rectangle(5, 5, imgResult.Width - 10, imgResult.Height - 10));
                            }
                            else
                            {
                                g.DrawRectangle(new System.Drawing.Pen(brush_Red, 10), new System.Drawing.Rectangle(5, 5, imgResult.Width - 10, imgResult.Height - 10));
                                g_OnlyNG.DrawRectangle(new System.Drawing.Pen(brush_Red, 10), new System.Drawing.Rectangle(5, 5, imgResult.Width - 10, imgResult.Height - 10));
                            }

                            Mat imgTotal = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgResult).Clone();
                            Mat imgOnlyNG = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgResult_OnlyNG).Clone();

                            (string pathOK, string pathNG ) path = InitDirectory_DateTime_ID(jobsReultTotal, Global.m_ImageFileRoot, saveInfo.QR_Code.GetQR());

                            if (folderOpen) Process.Start("explorer.exe", path.pathNG);

                            Stopwatch tt_imgSave = Stopwatch.StartNew();

                            string qrCode = saveInfo.QR_Code.GetQR();
                            string imgPath_Array = $"{path.pathOK}\\{qrCode}_{curTm.ToString("yyMMdd_HHmmss")}_BD{saveInfo.ArrayIndex}_ORI_GRABINDEX.jpg";
                            string imgPath_Ori = $"{path.pathOK}\\{qrCode}_{curTm.ToString("yyMMdd_HHmmss")}_ORI.jpg";
                            string imgPath_Ovl = $"{path.pathOK}\\{qrCode}_{curTm.ToString("yyMMdd_HHmmss")}_OVL.jpg";
                            string imgPath_OnlyNG = $"{path.pathOK}\\{qrCode}_{curTm.ToString("yyMMdd_HHmmss")}_NG.jpg";

                            if (jobsReultTotal == false)
                            {
                                if(retryCnt >= 2)
                                {
                                    imgPath_Array = $"{path.pathNG}\\{qrCode}_{curTm.ToString("yyMMdd_HHmmss")}_BD{saveInfo.ArrayIndex}_ORI_GRABINDEX.jpg";
                                    imgPath_Ori = $"{path.pathNG}\\{qrCode}_{curTm.ToString("yyMMdd_HHmmss")}_ORI.jpg";
                                    imgPath_Ovl = $"{path.pathNG}\\{qrCode}_{curTm.ToString("yyMMdd_HHmmss")}_OVL.jpg";
                                    imgPath_OnlyNG = $"{path.pathNG}\\{qrCode}_{curTm.ToString("yyMMdd_HHmmss")}_NG.jpg";

                                    // 자동일때 이미지 저장..
                                    StringBuilder imgSaveLog = new StringBuilder();

                                    imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] NG Image Save Start \n");
                                    imgTotal.SaveImage(imgPath_Ovl);
                                    imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] NG Image Save Total \n");
                                    imgOnlyNG.SaveImage(imgPath_OnlyNG);
                                    imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] NG Image Save Only NG \n");

                                    for (int i = 0; i < Global.Instance.System.Recipe.GrabManager.Nodes.Length; i++)
                                    {
                                        if (Global.Instance.System.Recipe.GrabManager.Nodes[i].Enabled && images[i].Allocated)
                                        {
                                            using (Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[i].ToBitmap()).Clone())
                                            {
                                                string imgPath = imgPath_Array.Replace("GRABINDEX", i.ToString());
                                                img.SaveImage(imgPath);
                                                imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] NG Image Save Grab Index : {i} \n");
                                            }
                                        }
                                    }

                                    CLogger.Add(LOG.NORMAL, $"Save Log : {imgSaveLog.ToString()}");

                                    using (Mat imgforCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgResultsDrawing[arrayIdx].ToBitmap()).Clone())
                                    {
                                        for (int nIndexNg = 0; nIndexNg < jobs_ng.Count; nIndexNg++)
                                        {
                                            CJob job = jobs_ng[nIndexNg];

                                            Bitmap bmpInfo = null;

                                            Rect cropRoi = new Rect();

                                            if (job.Type.Contains("Pattern"))
                                            {
                                                cropRoi = CConverter.RectToCVRect(job.SearchRegion);
                                            }
                                            else if (job.Type.Contains("Color"))
                                            {
                                                cropRoi = CConverter.RectToCVRect(job.SearchRegion);
                                            }
                                            else if (job.Type.Contains("Condensor"))
                                            {
                                                cropRoi = CConverter.RectToCVRect(job.SearchRegion);
                                            }
                                            else if (job.Type.Contains("Blob"))
                                            {
                                                cropRoi = CConverter.RectToCVRect(job.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi);
                                            }
                                            else if (job.Type.Contains("Distance"))
                                            {
                                                cropRoi = CConverter.RectToCVRect(job.SearchRegion);
                                            }
                                            else if (job.Type.Contains("Detection"))
                                            {
                                                cropRoi = CConverter.RectToCVRect(job.SearchRegion);
                                            }
                                            else if (job.Type.Contains("EYE-D"))
                                            {
                                                cropRoi = CConverter.RectToCVRect(job.SearchRegion);
                                            }

                                            if (cropRoi.Width != 0 && cropRoi.Height != 0)
                                            {
                                                List<string> saveCropNames = GetCropFileNames(jobsReultTotal, saveInfo.QR_Code.GetQR(), job.Name);

                                                int cutWdith = cropRoi.Width;
                                                int cutHeight = cropRoi.Height;

                                                if (cropRoi.X + cropRoi.Width > imgforCrop.Width)
                                                {
                                                    cropRoi.Width = cutWdith = imgforCrop.Width - cropRoi.X - 1;
                                                    CLogger.Add(LOG.ABNORMAL, $"JOB CROP [{job.Name}] OVERFLOW ");
                                                }

                                                if (job.SearchRegion.Y + job.SearchRegion.Height > imgforCrop.Height)
                                                {
                                                    cropRoi.Height = cutHeight = imgforCrop.Height - cropRoi.Y - 1;
                                                    CLogger.Add(LOG.ABNORMAL, $"JOB CROP [{job.Name}] OVERFLOW ");
                                                }

                                                imgforCrop.SubMat(cropRoi).SaveImage(saveCropNames[0]);

                                                DB_Write(false, saveInfo.Result, imgPath_Ovl, imgPath_OnlyNG, saveInfo.GrabIndex, job, saveInfo.QR_Code, saveInfo.Result_Time, saveInfo.InspecTackTime);
                                            }

                                        }
                                    }


                                    //CLogger.Add(LOG.SEQ, $"SEQ T/T : [{_stopwatch.ElapsedMilliseconds:D4} ms] ==> Results[NG] Process Complete");
                                }
                                else
                                {
                                    // 자동일때 이미지 저장..
                                    if (!manualMode)
                                    {
                                        imgTotal.SaveImage(path.pathOK + imgPath_Ovl);
                                    }
                                }

                                tt_imgSave.Stop();
                                CLogger.Add(LOG.NORMAL, $"Save Log : {tt_imgSave.ElapsedMilliseconds}ms");
                            }
                        }

                        results.results.Add(jobsReultTotal);
                        imgResults_array[arrayIdx] = (Bitmap)imgResult.Clone();

                        // NG 발생된 항목을 로그로 기록...
                        // 어레이 카운터 별로 로그 기록...
                        //==========================================
                        if (jobs_ng.Count > 0)
                        {
                            for (int i = 0; i < jobs_ng.Count; i++)
                            {
                                string strMsg = $"Board Array {arrayIdx + 1} => Inspec NG Name : {jobs_ng[i].Name}";
                                CLogger.Add(LOG.SEQ, strMsg);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2} ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message, jobDebug);
                }
            }   


            return results;
        }
        public static bool Algorithm_EYED(Graphics g, CJob job, Mat imageSource, out string uniqueID)
        {
            uniqueID = "";
            bool ret = false;       // ok true, ng false
            //string ResultTime;

            Stopwatch tactTime = new Stopwatch();
            tactTime.Start();

            int cutWdith = job.SearchRegion.Width;
            int cutHeight = job.SearchRegion.Height;

            if (job.SearchRegion.X + job.SearchRegion.Width > imageSource.Width)
            {
                cutWdith = imageSource.Width - job.SearchRegion.X - 1;
                CLogger.Add(LOG.ABNORMAL, $"JOB [{job.Name}] OVERFLOW : Image W/H : {imageSource.Width}/{imageSource.Height} Roi : {job.SearchRegion.ToString()}");
            }

            if (job.SearchRegion.Y + job.SearchRegion.Height> imageSource.Height)
            {
                cutHeight = imageSource.Height- job.SearchRegion.Y - 1;
                CLogger.Add(LOG.ABNORMAL, $"JOB [{job.Name}] OVERFLOW : Image W/H : {imageSource.Width}/{imageSource.Height} Roi : {job.SearchRegion.ToString()}");
            }
            using (Mat imgCrop = imageSource.SubMat(CConverter.RectToCVRect(job.SearchRegion)).Clone())
            {
                string modelName = job.Parameter.EyeD_ModelName;
                string inferType = job.Parameter.EyeD_InferType;

                uniqueID = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");

                string imageDir = $"{Application.StartupPath}\\EYED";
                if (Directory.Exists(imageDir) == false) Directory.CreateDirectory(imageDir);

                string imagePath = $"{imageDir}\\{modelName}_{inferType}_{DateTime.Now.ToString("yyyyMMdd_HHmmssfff")}.jpg";
                imgCrop.SaveImage(imagePath);

                Thread.Sleep(1);
                Global.Instance.Device.EyeD.Send($"[{modelName},{uniqueID},{inferType},{imagePath}]\r\n", "");

                if (modelName == "")
                {
                    CAlarm.Add("ERROR", $"JOB : {job.Name} ==> EYE-D's Model Name Empty");
                }
            }

            return ret;
        }

        public static bool Inspection_PatternMatching(Graphics g, Graphics g_OnlyNG, CJob job, CogImage8Grey[] images8_board, int nImageIndex, CogImage24PlanarColor[] images24_board, bool bResult_Job, int nArrayIndex, int nJobIndex, bool bEnabledJob, bool bCalcCenter, out Rectangle rect)
        {
            rect = new Rectangle();
            //// 임시로 패턴은 CA_ConvertGray, CC_GRAY로 Fix
            job.dRate = 0.0D;
            CogPMAlignResult resultBest = null;  
            job.nPatternIndex = 0;

            CCogTool_PMAlign bestTool = new CCogTool_PMAlign();
            for (int nPatternIndex = 0; nPatternIndex < 5; nPatternIndex++)
            {
                double dToolValue = 0.0;
                CCogTool_PMAlign PMAlign = job.GetTool(nPatternIndex);

                // 여기 이미지 가공 추가
                // 여기 이미지 전처리 추가
                if (job.ChkColor == true)
                {
                    if (job.CMethod == CJob.ColorMethod.CA_ConvertGray && job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
                    {
                        PMAlign.Tool.InputImage = images8_board[nImageIndex];
                    }
                    else
                    {
                        Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(images24_board[nImageIndex].ToBitmap()).Clone();
                        Bitmap imgIn = CVisionTools.GetPatterernImage(false, ref job, inImg);
                        CogImage8Grey cogInImg = new Cognex.VisionPro.CogImage8Grey(imgIn);
                        PMAlign.Tool.InputImage = cogInImg;
                    }
                }
                else
                {
                    PMAlign.Tool.InputImage = images8_board[nImageIndex];
                }

                if (PMAlign.Tool.Pattern.Trained == false)
                    continue;

                PMAlign.Tool.Run();

                if (job.Judge_NaisNg && (PMAlign.Tool.Results == null || PMAlign.Tool.Results.Count == 0))
                {
                    //CLogger.Add(LOG_TYPE.ALARM, $"{job.Name} Pattern abNormal !!!!");
                    bResult_Job = false;
                    continue;
                }
                else
                {
                    CogPMAlignResult result_Best = CVisionCognex.GetBestResult_PMAlign(PMAlign.Tool);

                    if (result_Best == null)
                        dToolValue = 0;
                    else
                        dToolValue = result_Best.Score;
                    if (dToolValue > job.dRate)
                    {
                        job.dRate = dToolValue;
                        job.nPatternIndex = nPatternIndex;
                        resultBest = result_Best;
                    }

                    //NOT OK 는 패턴이 발견되면 NG
                    if (job.Judge_NaisNg == false)
                    {
                        if (job.MinScore < job.dRate)
                        {
                            bResult_Job = false;
                        }
                        else
                        {
                            bResult_Job = true;
                        }

                        break;
                    }
                    //NOT OK 가 아닐 때에는 패턴이 발견되고 Min Score 보다 높아야 OK
                    else
                    {
                        if (result_Best == null)
                        {
                            bResult_Job = false;
                        }
                        else
                        {
                            if (job.dRate > job.MinScore)
                            {
                                if (bEnabledJob == false)
                                {
                                    bResult_Job = false;                                    
                                }
                                else
                                {
                                    bResult_Job = true;                                    
                                }

                                Rectangle detectedRect = new Rectangle(
                                      (int)(resultBest.GetPose().TranslationX - PMAlign.Tool.Pattern.GetTrainedPatternImage().Width / 2)
                                    , (int)(resultBest.GetPose().TranslationY - PMAlign.Tool.Pattern.GetTrainedPatternImage().Height / 2)
                                    , PMAlign.Tool.Pattern.GetTrainedPatternImage().Width
                                    , PMAlign.Tool.Pattern.GetTrainedPatternImage().Height);

                                rect = detectedRect;

                                //2024.03.24 : 송현수 ==> 주석 처리 아래 Cv2.ImWrrte
                                //Mat PatternResultRect = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(images8_board[nImageIndex].ToBitmap(), detectedRect));
                                //Cv2.ImWrite("C:\\PatternResultRect.bmp", PatternResultRect);

                                using (Pen pen_Green = new Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5))
                                using (Pen pen_Red = new Pen(System.Drawing.Color.FromArgb(128, 255, 64, 32), 5))
                                {
                                    if (bResult_Job) g.DrawRectangle(pen_Green, detectedRect);
                                    else
                                    {
                                        g.DrawRectangle(pen_Red, detectedRect);
                                        g_OnlyNG.DrawRectangle(pen_Red, detectedRect);
                                    }
                                }

                                break;
                            }
                        }
                    }
                }
            }

            if (!chkPattern(job))
            {
                //CUtil.ShowMessageBox("Pattenr is None", $"Board-{nArrayIndex} {job.Name} Pattern is None !!!!", FormPopup_MessageBox.MESSAGEBOX_TYPE.OK);
                CLogger.Add(LOG.ALARM, $"Board-{nArrayIndex} {job.Name} Pattern is None !!!!");
                job.isPatternNone = true;
                bResult_Job = false;
            }

            if (job.Judge_NaisNg)
            {
                if (bCalcCenter)
                {
                    job.MasterPosition[nArrayIndex] = new Point2d(resultBest.GetPose().TranslationX, resultBest.GetPose().TranslationY);
                }

                if (job.MinScore > job.dRate)
                {
                    if (bEnabledJob == false)
                    {
                        bResult_Job = true;
                    }
                    else
                    {
                        bResult_Job = false;
                    }
                }

                if (bCalcCenter == false)
                {
                    g.DrawLine(Pens.Yellow, (int)job.MasterPosition[nArrayIndex].X - 5, (int)job.MasterPosition[nArrayIndex].Y, (int)job.MasterPosition[nArrayIndex].X + 10, (int)job.MasterPosition[nArrayIndex].Y);
                    g.DrawLine(Pens.Yellow, (int)job.MasterPosition[nArrayIndex].X, (int)job.MasterPosition[nArrayIndex].Y - 5, (int)job.MasterPosition[nArrayIndex].X, (int)job.MasterPosition[nArrayIndex].Y + 10);
                }
            }

            if (bResult_Job)
                return true;
            else
                return false;
        }
        public static bool Inspection_PatternMatching(CJob job, CogImage8Grey images8_board, int nToolIndex, out Rectangle ResultRect)
        {
            
            CCogTool_PMAlign PMAlign = job.GetTool(nToolIndex);
            PMAlign.Tool.InputImage = images8_board;
            PMAlign.Tool.Run();
            CogPMAlignResult result = new CogPMAlignResult();
            if (PMAlign.Tool.Results == null || PMAlign.Tool.Results.Count == 0)
            {
                ResultRect = new Rectangle();
                return true;
            }
            result = CVisionCognex.GetBestResult_PMAlign(PMAlign.Tool);
            ResultRect  = new Rectangle((int)result.GetPose().TranslationX - (PMAlign.TrainedPatternImage.Width) / 2, (int)result.GetPose().TranslationY - (PMAlign.TrainedPatternImage.Height) / 2, PMAlign.TrainedPatternImage.Width, PMAlign.TrainedPatternImage.Height);
            return true;
        }

        // Fin의 극성 위치 찾기..
        public static bool Inspection_Fin_Brightness(Graphics g, CJob job, CogImage8Grey[] images8_board, int nImageIndex, Pen color, int nArrayIndex, int nJobIndex)
        {
            bool ret = false;       // ok true, ng false

            int mag_1st = 2;
            int mag_2st = 1;

            job.Fin_InspecTool.FINFIND_MatchingTool.SetSourceImage(images8_board[nImageIndex].ToBitmap());
            job.Fin_InspecTool.FINFIND_MatchingTool.Run(job.Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage, job.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi, 0.1D, mag_1st, mag_2st);

            double dMaxScore = double.MinValue;
            Rect rtMaxScore = new Rect();
            Point2d pointMaxScore = new Point2d();

            if (job.Fin_InspecTool.FINFIND_MatchingTool.Results.Count > 0)
            {
                System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 15, FontStyle.Bold);
                System.Drawing.Font font = new System.Drawing.Font("Arial", 15, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));

                if (dMaxScore < job.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Score)
                {
                    pointMaxScore = job.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Center;
                    rtMaxScore = job.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Bounding;
                }

                // 검출 영역 그리기..
                Rectangle retct = new Rectangle();
                retct.X = rtMaxScore.X;
                retct.Y = rtMaxScore.Y;
                retct.Width = rtMaxScore.Width;
                retct.Height = rtMaxScore.Height;

                g.DrawRectangle(color, retct);
                int ng_value;
                (bool, int) result = Blob_FindContour(g, job, images8_board, nImageIndex, color, out ng_value);

                string str;
                if (result.Item1)
                {
                    str = $"{job.Name} OK => Area : {result.Item2}";
                    brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16));
                    g.DrawString($"{str} ", font, brush, (float)rtMaxScore.Location.X, (float)rtMaxScore.Location.Y);
                    ret = true;
                }
                else
                {
                    str = $"{job.Name} NG => No Area Result, Area : {ng_value}";
                    brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));
                    g.DrawString($"{str} ", font_NG, brush, (float)rtMaxScore.Location.X, (float)rtMaxScore.Location.Y);
                    ret = false;
                }

                // 로그 찍기...
                CLogger.Add(LOG.NORMAL, str);
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
            }

            return ret;
        }

        private static (bool, int) Blob_FindContour(Graphics g, CJob job, CogImage8Grey[] images8_board, int nImageIndex, Pen color, out int ng_value)
        {
            (bool, int) result = (false, 0);

            Mat _imageSourceCV = OpenCvSharp.Extensions.BitmapConverter.ToMat(images8_board[nImageIndex].ToBitmap()).Clone();
            Rectangle roi = job.Fin_InspecTool.BlobSearchRoi;
            if (roi.Width == 0) roi.Width = _imageSourceCV.Width;
            if (roi.Height == 0) roi.Height = _imageSourceCV.Height;
            if (roi.Right > _imageSourceCV.Width) roi.Offset(new System.Drawing.Point(-(roi.Right - _imageSourceCV.Width + 1), 0));
            if (roi.Bottom > _imageSourceCV.Height) roi.Offset(new System.Drawing.Point(0, -(roi.Bottom - _imageSourceCV.Height + 1)));
            if (roi.Left < 0) roi.Offset(new System.Drawing.Point(-roi.Left, 0));
            if (roi.Top < 0) roi.Offset(new System.Drawing.Point(0, -roi.Top));
            //test
            using (Mat imgRoi = _imageSourceCV.SubMat(CConverter.RectToCVRect(roi)).Clone())
            {
                int ng_valuedata;
                List<(Rect, int)> rects = CVision.Contour(imgRoi, job.Fin_InspecTool.BlobThreshold, job.Fin_InspecTool.BlobAreaMin, job.Fin_InspecTool.BlobAreaMax, out ng_valuedata, job.Fin_InspecTool.BlobThresholdInv);

                ng_value = ng_valuedata;

                System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                //SolidBrush brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));
                SolidBrush brush = new SolidBrush(Color.Green);

                if (rects.Count > 0)
                {
                    for (int i = 0; i < rects.Count; i++)
                    {
                        CogRectangle cogRect = new CogRectangle();
                        cogRect.X = rects[i].Item1.X + job.Fin_InspecTool.BlobSearchRoi.X;
                        cogRect.Y = rects[i].Item1.Y + job.Fin_InspecTool.BlobSearchRoi.Y;

                        cogRect.Width = rects[i].Item1.Width;
                        cogRect.Height = rects[i].Item1.Height;
                        cogRect.Color = CogColorConstants.Green;

                        result.Item2 = rects[i].Item2;
                        string str = $"Area : {rects[i].Item2}";

                        // 검출 영역 그리기..
                        Rectangle retct = new Rectangle();
                        retct.X = int.Parse(cogRect.X.ToString());
                        retct.Y = int.Parse(cogRect.Y.ToString());
                        retct.Width = int.Parse(cogRect.Width.ToString());
                        retct.Height = int.Parse(cogRect.Height.ToString());

                        g.DrawRectangle(color, retct);
                        g.DrawString($"{str} ", font, brush, (float)cogRect.X, (float)cogRect.Y);
                    }
                    result.Item1 = true;
                }
            }

            return result;
        }


        public static bool Algorithm_Condensor(Graphics g, CJob job, CogImage8Grey[] images8_board, int nImageIndex, Pen color, int nArrayIndex, int nJobIndex)
        {
            bool ret = false;       // ok true, ng false
            //string ResultTime;

            Stopwatch tactTime = new Stopwatch();
            tactTime.Start();

            Mat imageSource = OpenCvSharp.Extensions.BitmapConverter.ToMat(images8_board[nImageIndex].ToBitmap()).Clone();
            IF_Util.SetImageChannel1(imageSource);

            if (job.Parameter.UseFilter1 == true) imageSource = CVisionTools.RunFilter(imageSource, job.Parameter.Filter1, job.Parameter.Filter1_Kernel_W, job.Parameter.Filter1_Kernel_H);
            if (job.Parameter.UseFilter2 == true) imageSource = CVisionTools.RunFilter(imageSource, job.Parameter.Filter2, job.Parameter.Filter2_Kernel_W, job.Parameter.Filter2_Kernel_H);

            job.Find_Circle.InputImage = new CogImage8Grey(IF_Util.MatToBmp(imageSource));
            job.Find_Circle.Run();

            if (job.Find_Circle.Results == null || job.Find_Circle.Results.NumPointsFound < job.MinFoundCount)
            {
                CLogger.Add(LOG.ABNORMAL, "Find Circle Results Empty");
            }
            else if (job.Find_Circle.Results != null && job.Find_Circle.Results.Count > 0)
            {
                CogCircle resultGraphic = job.Find_Circle.Results.GetCircle();

                if (resultGraphic != null)
                {
                    Rectangle boundingBox = IF_Util.BondingBox_Circle((int)resultGraphic.CenterX, (int)resultGraphic.CenterY, (int)resultGraphic.Radius, 50);

                    int offsetSize = boundingBox.Width / 2;
                    int offsetWidth = job.Parameter.CondensorRectWidth;
                    int offsetHeight = job.Parameter.CondensorRectHeight;

                    CogRectangle Find_rect = new CogRectangle();
                    string str_value = "";
                    double posX = 0;
                    double posY = 0;

                    // top to bottom
                    if (job.Parameter.CondensorTypeTB)
                    {
                        CogRectangle meanRectTop = new CogRectangle();
                        meanRectTop.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + offsetSize / 4 - job.Parameter.CondensorRadiusOffset, offsetWidth, offsetHeight);

                        CogRectangle meanRectBtm = new CogRectangle();
                        meanRectBtm.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height - offsetSize / 4 + job.Parameter.CondensorRadiusOffset, offsetWidth, offsetHeight);

                        using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(images8_board[nImageIndex].ToBitmap()))
                        {
                            System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 36, FontStyle.Bold);
                            System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Bold);
                            SolidBrush brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));

                            IF_Util.SetImageChannel1(imgOrg);

                            Rect rect_top = CConverter.CogRectToCVRect(meanRectTop);
                            Rect rect_bottom = CConverter.CogRectToCVRect(meanRectBtm);

                            // roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width
                            int t_colstart = rect_top.X + rect_top.Width;
                            if (imgOrg.Width < t_colstart)
                            {
                                string log = "Not Find Top";
                                // 검출 내용 스트링값 쓰기..
                                g.DrawString($"{log} ", font, brush, (float)meanRectTop.X, (float)meanRectTop.Y - 20);
                                CLogger.Add(LOG.ABNORMAL, log);
                                return ret;
                            }

                            int b_colstart = rect_bottom.X + rect_bottom.Width;
                            if (imgOrg.Width < b_colstart)
                            {
                                string log = "Not Find Bottom";
                                // 검출 내용 스트링값 쓰기..
                                g.DrawString($"{log} ", font, brush, (float)meanRectBtm.X, (float)meanRectBtm.Y - 20);
                                CLogger.Add(LOG.ABNORMAL, log);
                                return ret;
                            }

                            using (Mat imgSubMat_T = imgOrg.SubMat(rect_top))
                            using (Mat imgSubMat_B = imgOrg.SubMat(rect_bottom))
                            {
                                Dictionary<string, double> meanValues = new Dictionary<string, double>();
                                meanValues.Add("T", Cv2.Mean(imgSubMat_T).Val0);
                                meanValues.Add("B", Cv2.Mean(imgSubMat_B).Val0);

                                string brightnestKey = "";
                                double brightnestValue = 0;
                                foreach (var item in meanValues)
                                {
                                    if (brightnestValue < item.Value)
                                    {
                                        brightnestKey = item.Key;
                                        brightnestValue = item.Value;
                                    }
                                }

                                if (brightnestKey == "T")
                                {
                                    posX = meanRectTop.X;
                                    posY = meanRectTop.Y - 20;
                                    Find_rect = meanRectTop;
                                    //str_Group = "meanRectTop";
                                    str_value = $"Brightness : {meanValues["T"].ToString("F3")}";
                                }
                                else if (brightnestKey == "B")
                                {
                                    posX = meanRectBtm.X;
                                    posY = meanRectBtm.Y - 20;
                                    Find_rect = meanRectBtm;
                                    //str_Group = "meanRectBtm";
                                    str_value = $"Brightness : {meanValues["B"].ToString("F3")}";
                                }

                                string nResult;
                                // OK
                                if (brightnestKey == job.Parameter.CondensorPolarity)
                                {
                                    nResult = "OK";
                                    brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16));
                                    ret = true;
                                }
                                // NG
                                else
                                {
                                    Color _color = Color.Red;
                                    color = new Pen(_color);
                                    brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));
                                    nResult = "NG";
                                    ret = false;
                                }

                                Rectangle rect = new Rectangle();
                                rect.X = (int)Find_rect.X;
                                rect.Y = (int)Find_rect.Y;
                                rect.Width = (int)Find_rect.Width;
                                rect.Height = (int)Find_rect.Height;

                                System.Drawing.PointF point_1 = new PointF();
                                point_1.X = (float)posX;
                                point_1.Y = (float)posY;
                                System.Drawing.PointF point_2 = new PointF();
                                point_2.X = (float)posX;
                                point_2.Y = (float)posY - 20;

                                // 검출 영역 그리기..
                                g.DrawRectangle(color, rect);
                                g.DrawRectangle(color, job.SearchRegion);
                                // 검출 내용 스트링값 쓰기..
                                g.DrawString($"{str_value} ", font, brush, point_1);
                                g.DrawString($"[{nResult}] {Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs[nJobIndex].Name}", font, brush, point_2);
                            }
                        }
                    }
                    else
                    {
                        CogRectangle meanRectLeft = new CogRectangle();
                        meanRectLeft.SetCenterWidthHeight(boundingBox.X + offsetSize / 4 - job.Parameter.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                        CogRectangle meanRectRight = new CogRectangle();
                        meanRectRight.SetCenterWidthHeight(boundingBox.X + boundingBox.Width - offsetSize / 4 + job.Parameter.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                        using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(images8_board[nImageIndex].ToBitmap()))
                        {
                            System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 36, FontStyle.Bold);
                            System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Bold);
                            SolidBrush brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));

                            IF_Util.SetImageChannel1(imgOrg);

                            Rect rect_left = CConverter.CogRectToCVRect(meanRectLeft);
                            Rect rect_right = CConverter.CogRectToCVRect(meanRectRight);

                            // roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width

                            int l_colstart = rect_left.X + rect_left.Width;
                            if (imgOrg.Width < l_colstart)
                            {
                                string log = "Not Find Left";
                                // 검출 내용 스트링값 쓰기..
                                g.DrawString($"{log} ", font, brush, (float)meanRectLeft.X, (float)meanRectLeft.Y - 20);
                                CLogger.Add(LOG.ABNORMAL, log);
                                return ret;
                            }

                            int r_colstart = rect_right.X + rect_right.Width;
                            if (imgOrg.Width < r_colstart)
                            {
                                string log = "Not Find Right";
                                // 검출 내용 스트링값 쓰기..
                                g.DrawString($"{log} ", font, brush, (float)meanRectRight.X, (float)meanRectRight.Y - 20);
                                CLogger.Add(LOG.ABNORMAL, log);
                                return ret;
                            }

                            using (Mat imgSubMat_L = imgOrg.SubMat(rect_left))
                            using (Mat imgSubMat_R = imgOrg.SubMat(rect_right))
                            {
                                Dictionary<string, double> meanValues = new Dictionary<string, double>();
                                meanValues.Add("L", Cv2.Mean(imgSubMat_L).Val0);
                                meanValues.Add("R", Cv2.Mean(imgSubMat_R).Val0);

                                string brightnestKey = "";
                                double brightnestValue = 0;
                                foreach (var item in meanValues)
                                {
                                    if (brightnestValue < item.Value)
                                    {
                                        brightnestKey = item.Key;
                                        brightnestValue = item.Value;
                                    }
                                }

                                if (brightnestKey == "L")
                                {
                                    posX = meanRectLeft.X;
                                    posY = meanRectLeft.Y - 20;
                                    Find_rect = meanRectLeft;
                                    //str_Group = "meanRectLeft";
                                    str_value = $"Brightness : {meanValues["L"].ToString("F3")}";
                                }
                                else
                                {
                                    posX = meanRectRight.X;
                                    posY = meanRectRight.Y - 20;
                                    Find_rect = meanRectRight;
                                    //str_Group = "meanRectRight";
                                    str_value = $"Brightness : {meanValues["R"].ToString("F3")}";
                                }

                                string nResult;
                                // OK
                                if (brightnestKey == job.Parameter.CondensorPolarity)
                                {
                                    nResult = "OK";
                                    brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16));
                                    ret = true;
                                }
                                // NG
                                else
                                {
                                    Color _color = Color.Red;
                                    color = new Pen(_color);
                                    brush = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));
                                    nResult = "NG";
                                    ret = false;
                                }

                                Rectangle rect = new Rectangle();
                                rect.X = (int)Find_rect.X;
                                rect.Y = (int)Find_rect.Y;
                                rect.Width = (int)Find_rect.Width;
                                rect.Height = (int)Find_rect.Height;

                                System.Drawing.PointF point_1 = new PointF();
                                point_1.X = (float)posX;
                                point_1.Y = (float)posY;
                                System.Drawing.PointF point_2 = new PointF();
                                point_2.X = (float)posX;
                                point_2.Y = (float)posY - 20;

                                // 검출 영역 그리기..
                                g.DrawRectangle(color, job.SearchRegion);
                                g.DrawRectangle(color, rect);
                                // 검출 내용 스트링값 쓰기..
                                g.DrawString($"{str_value} ", font, brush, point_1);
                                g.DrawString($"[{nResult}] {Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs[nJobIndex].Name}", font, brush, point_2);
                            }
                        }
                    }

                }
                else
                {
                    CLogger.Add(LOG.ABNORMAL, "Find Circle Results Empty");
                    //CUtil.ShowMessageBox("Error", "Find Circle Results Empty");
                }
            }
            else
            {
                CLogger.Add(LOG.ABNORMAL, "Find Circle Results Empty");
                //CUtil.ShowMessageBox("Error", "Find Circle Results Empty");
            }
            return ret;
        }

        public static bool Algorithm_Distance(Point2d pos, Graphics g, CJob job, CogImage8Grey[] images8_board, int nImageIndex, Pen color)
        {
            bool jobResult = true;       // ok true, ng false

            Stopwatch tactTime = new Stopwatch();
            tactTime.Start();

            CogFindLineTool tool = job.Find_Line;

            (bool, CogLine) result = CCognexUtil.FindLine(tool, images8_board[nImageIndex], out CogGraphicCollection gCog, true);
            if (result.Item2 != null)
            {
                Point2d lineCenter = new Point2d(result.Item2.X, result.Item2.Y);

                CogLineSegment lineX = new CogLineSegment();
                lineX.StartX = pos.X;
                lineX.StartY = pos.Y;
                lineX.EndX = lineCenter.X;
                lineX.EndY = pos.Y;
                lineX.Color = CogColorConstants.Red;

                CogLineSegment lineY = new CogLineSegment();
                lineY.StartX = lineCenter.X;
                lineY.StartY = pos.Y;
                lineY.EndX = lineCenter.X;
                lineY.EndY = lineCenter.Y;
                lineY.Color = CogColorConstants.Red;

                //g.Add(lineX);
                //g.Add(lineY);

                double distanceX = lineX.Length;
                double distanceY = lineY.Length;
                double angle = 0.0D;

                if (job.Parameter.UseDistanceX)
                {
                    if (distanceX > job.Parameter.DistanceXMax) jobResult = false;
                    if (distanceX < job.Parameter.DistanceXMin) jobResult = false;
                }

                if (job.Parameter.UseDistanceY)
                {
                    if (distanceY > job.Parameter.DistanceYMax) jobResult = false;
                    if (distanceY < job.Parameter.DistanceYMin) jobResult = false;
                }

                if (job.Parameter.UseDistanceAngle)
                {
                    angle = IF_Util.rad2deg(result.Item2.Rotation);
                    if (angle > job.Parameter.DistanceAngleMax) jobResult = false;
                    if (angle < job.Parameter.DistanceAngleMin) jobResult = false;
                }

                if (jobResult == false)
                {
                    CLogger.Add(LOG.ABNORMAL, $"[NG] Algorithm Distance ==> ({job.Name}) Distance X : {distanceX:F1} Y : {distanceY:F1} Angle : {angle:F1}");
                }
                angle = Math.Round(angle, 2);
                distanceX = Math.Round(distanceX, 2);
                distanceY = Math.Round(distanceY, 2);
                string resultString = jobResult ? "OK" : "NG";
                System.Drawing.Font font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold);
                System.Drawing.Brush brush = jobResult ? Brushes.Green : Brushes.Red;
                g.DrawString($"[{resultString}] {job.Name}", font, brush, new PointF((float)job.Find_Line.RunParams.ExpectedLineSegment.StartX, (float)job.Find_Line.RunParams.ExpectedLineSegment.StartY));

                g.DrawRectangle(color, job.SearchRegion);

                if (job.Parameter.UseDistanceX)
                    g.DrawString($"Angle: {angle} Distance:{distanceX}", font, brush, new PointF((float)job.Find_Line.RunParams.ExpectedLineSegment.StartX, (float)job.Find_Line.RunParams.ExpectedLineSegment.StartY + 32));
                else if (job.Parameter.UseDistanceY)
                    g.DrawString($"Angle: {angle} Distance:{distanceY}", font, brush, new PointF((float)job.Find_Line.RunParams.ExpectedLineSegment.StartX, (float)job.Find_Line.RunParams.ExpectedLineSegment.StartY + 32));
                else
                    g.DrawString($"Angle: {angle}", font, brush, new PointF((float)job.Find_Line.RunParams.ExpectedLineSegment.StartX, (float)job.Find_Line.RunParams.ExpectedLineSegment.StartY + 32));

            }
            else
            {
                jobResult = false;
                System.Drawing.Font font1 = new System.Drawing.Font("Arial", 24);
                System.Drawing.Brush brush2 = jobResult ? Brushes.Green : Brushes.Red;
                g.DrawString($"", font1, brush2, new PointF((float)job.Find_Line.RunParams.ExpectedLineSegment.StartX, (float)job.Find_Line.RunParams.ExpectedLineSegment.StartY + 55));
            }
            return jobResult;
        }

        public static bool Algorithm_ColorEx(Graphics g, CJob job, Mat img)
        {
            bool jobResult = true;       // ok true, ng false

            try
            {
                Scalar scalar = img.SubMat(CConverter.RectToCVRect(job.SearchRegion)).Mean();

                // 평균 색상 값을 BGR 형식으로 각각 추출
                byte meanB = (byte)scalar.Val0;
                byte meanG = (byte)scalar.Val1;
                byte meanR = (byte)scalar.Val2;

                Color extractColor = Color.FromArgb(meanR, meanG, meanB);
                string colorStr = $"{meanR},{meanG},{meanB}";

                string colorName = "";
                for (int colorIdx = 0; colorIdx < Global.Instance.Setting.Enviroment.ColorList.ColorNodes.Count; colorIdx++)
                {
                    if (Global.Instance.Setting.Enviroment.ColorList.ColorNodes[colorIdx].InRange(meanR, meanG, meanB))
                    {
                        colorName = Global.Instance.Setting.Enviroment.ColorList.ColorNodes[colorIdx].Name;
                        break;
                    }
                }

                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Regular))
                {
                    if (colorName == job.Parameter.EyeD_CorrectColor)
                    {
                        g.DrawString($"OK - {colorStr} ({colorName})", font, Brushes.Green, job.SearchRegion.X + 5, job.SearchRegion.Y + 45);
                        jobResult = true;
                    }
                    else
                    {
                        g.DrawString($"NG - {colorStr} ({colorName})", font, Brushes.Green, job.SearchRegion.X + 5, job.SearchRegion.Y + 45);
                        jobResult = false;
                    }
                }
                    
            }
            catch(Exception e)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e);
                jobResult = false;
            }
            
            return jobResult;
        }

        public static bool Algorithm_ColorEx(Graphics g, CJob job, Rect roi, Mat img)
        {
            bool jobResult = true;       // ok true, ng false

            try
            {
                Scalar scalar = img.SubMat(roi).Mean();

                // 평균 색상 값을 BGR 형식으로 각각 추출
                byte meanB = (byte)scalar.Val0;
                byte meanG = (byte)scalar.Val1;
                byte meanR = (byte)scalar.Val2;

                Color extractColor = Color.FromArgb(meanR, meanG, meanB);
                string colorStr = $"{meanR},{meanG},{meanB}";

                string colorName = "";
                for (int colorIdx = 0; colorIdx < Global.Instance.Setting.Enviroment.ColorList.ColorNodes.Count; colorIdx++)
                {
                    if (Global.Instance.Setting.Enviroment.ColorList.ColorNodes[colorIdx].InRange(meanR, meanG, meanB))
                    {
                        colorName = Global.Instance.Setting.Enviroment.ColorList.ColorNodes[colorIdx].Name;
                        break;
                    }
                }

                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Regular))
                {
                    if (colorName == job.Parameter.EyeD_CorrectColor)
                    {
                        g.DrawString($"OK - {colorStr} ({colorName})", font, Brushes.Green, roi.X + 5, roi.Y + 45);
                        jobResult = true;
                    }
                    else
                    {
                        g.DrawString($"NG - {colorStr} ({colorName})", font, Brushes.Green, roi.X + 5, roi.Y + 45);
                        jobResult = false;
                    }
                }

            }
            catch (Exception e)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e);
                jobResult = false;
            }

            return jobResult;
        }

        public static bool Algorithm_Distance(Recipe_Matching matchingRecipe, Graphics g, CJob job, CogImage8Grey[] images8_board, int nImageIndex)
        {
            bool jobResult = true;       // ok true, ng false

            Stopwatch tactTime = new Stopwatch();
            tactTime.Start();

            CogFindLineTool tool = job.Find_Line;

            CTemplateMatching matching = new CTemplateMatching("Matching");
            matching.SetSourceImage(images8_board[nImageIndex].ToBitmap());
            matching.Run(matchingRecipe);

            double dMaxScore = double.MinValue;
            Rect rtMaxScore = new Rect();
            Point2d pos = new Point2d();

            if (matching.Results.Count > 0)
            {
                if (dMaxScore < matching.Results[0].Score)
                {
                    dMaxScore = matching.Results[0].Score;
                    rtMaxScore = matching.Results[0].Bounding;
                    pos = matching.Results[0].Center;
                }

                (bool, CogLine) result = CCognexUtil.FindLine(tool, images8_board[nImageIndex], out CogGraphicCollection gCog, true);
                Point2d lineCenter = new Point2d(result.Item2.X, result.Item2.Y);

                CogLineSegment lineX = new CogLineSegment();
                lineX.StartX = pos.X;
                lineX.StartY = pos.Y;
                lineX.EndX = lineCenter.X;
                lineX.EndY = pos.Y;
                lineX.Color = CogColorConstants.Red;

                CogLineSegment lineY = new CogLineSegment();
                lineY.StartX = lineCenter.X;
                lineY.StartY = pos.Y;
                lineY.EndX = lineCenter.X;
                lineY.EndY = lineCenter.Y;
                lineY.Color = CogColorConstants.Red;

                //g.Add(lineX);
                //g.Add(lineY);

                double distanceX = lineX.Length;
                double distanceY = lineY.Length;
                double angle = 0.0D;

                if (job.Parameter.UseDistanceX)
                {
                    if (distanceX > job.Parameter.DistanceXMax) jobResult = false;
                    if (distanceX < job.Parameter.DistanceXMin) jobResult = false;
                }

                if (job.Parameter.UseDistanceY)
                {
                    if (distanceY > job.Parameter.DistanceYMax) jobResult = false;
                    if (distanceY < job.Parameter.DistanceYMin) jobResult = false;
                }

                if (job.Parameter.UseDistanceAngle)
                {
                    angle = IF_Util.rad2deg(result.Item2.Rotation);
                    if (angle > job.Parameter.DistanceAngleMax) jobResult = false;
                    if (angle < job.Parameter.DistanceAngleMin) jobResult = false;
                }

                if (jobResult == false)
                {
                    CLogger.Add(LOG.ABNORMAL, $"[NG] Algorithm Distance ==> ({job.Name}) Distance X : {distanceX:F1} Y : {distanceY:F1} Angle : {angle:F1}");
                }

                string resultString = jobResult ? "OK" : "NG";
                System.Drawing.Font font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
                System.Drawing.Brush brush = jobResult ? Brushes.Green : Brushes.Red;
                g.DrawString($"[{resultString}] {job.Name}", font, brush, new PointF((float)job.Find_Line.RunParams.ExpectedLineSegment.StartX, (float)job.Find_Line.RunParams.ExpectedLineSegment.StartY));
            }
            else
            {
                CLogger.Add(LOG.ABNORMAL, $"[ERROR] Algorithm Distance ==> ({job.Name}) Can't find the Fiducial");
                jobResult = false;
            }

            return jobResult;
        }

        public static bool Algorithm_Distance(Recipe_Matching matchingRecipe, CogFindLineTool tool, CogImage8Grey img, Graphics g, CJob job, CogImage8Grey[] images8_board, int nImageIndex, Pen color, int nArrayIndex, int nJobIndex)
        {
            bool jobResult = true;       // ok true, ng false

            Stopwatch tactTime = new Stopwatch();
            tactTime.Start();

            CTemplateMatching matching = new CTemplateMatching("Matching");
            matching.SetSourceImage(img.ToBitmap());
            matching.Run(matchingRecipe);

            double dMaxScore = double.MinValue;
            Rect rtMaxScore = new Rect();
            Point2d pos = new Point2d();

            if (matching.Results.Count > 0)
            {
                if (dMaxScore < matching.Results[0].Score)
                {
                    dMaxScore = matching.Results[0].Score;
                    rtMaxScore = matching.Results[0].Bounding;
                    pos = matching.Results[0].Center;
                }

                (bool, CogLine) result = CCognexUtil.FindLine(tool, img, out CogGraphicCollection gCog, true);
                Point2d lineCenter = new Point2d(result.Item2.X, result.Item2.Y);

                CogLineSegment lineX = new CogLineSegment();
                lineX.StartX = pos.X;
                lineX.StartY = pos.Y;
                lineX.EndX = lineCenter.X;
                lineX.EndY = pos.Y;
                lineX.Color = CogColorConstants.Red;

                CogLineSegment lineY = new CogLineSegment();
                lineY.StartX = lineCenter.X;
                lineY.StartY = pos.Y;
                lineY.EndX = lineCenter.X;
                lineY.EndY = lineCenter.Y;
                lineY.Color = CogColorConstants.Red;

                //g.Add(lineX);
                //g.Add(lineY);

                double distanceX = lineX.Length;
                double distanceY = lineY.Length;
                double angle = 0.0D;

                if (job.Parameter.UseDistanceX)
                {
                    if (distanceX > job.Parameter.DistanceXMax) jobResult = false;
                    if (distanceX < job.Parameter.DistanceXMin) jobResult = false;
                }

                if (job.Parameter.UseDistanceY)
                {
                    if (distanceY > job.Parameter.DistanceYMax) jobResult = false;
                    if (distanceY < job.Parameter.DistanceYMin) jobResult = false;
                }

                if (job.Parameter.UseDistanceAngle)
                {
                    angle = IF_Util.rad2deg(result.Item2.Rotation);
                    if (angle > job.Parameter.DistanceAngleMax) jobResult = false;
                    if (angle < job.Parameter.DistanceAngleMin) jobResult = false;
                }

                if (jobResult == false)
                {
                    CLogger.Add(LOG.ABNORMAL, $"[NG] Algorithm Distance ==> ({job.Name}) Distance X : {distanceX:F1} Y : {distanceY:F1} Angle : {angle:F1}");
                }

                string resultString = jobResult ? "OK" : "NG";
                System.Drawing.Font font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
                System.Drawing.Brush brush = jobResult ? Brushes.Green : Brushes.Red;
                g.DrawString($"[{resultString}] {job.Name}", font, brush, new PointF((float)job.Find_Line.RunParams.ExpectedLineSegment.StartX, (float)job.Find_Line.RunParams.ExpectedLineSegment.StartY));
            }
            else
            {
                CLogger.Add(LOG.ABNORMAL, $"[ERROR] Algorithm Distance ==> ({job.Name}) Can't find the Fiducial");
                jobResult = false;
            }

            return jobResult;
        }


        public static bool Inspection_Color(Graphics g, CJob job, CogImage24PlanarColor[] images24_board, int nImageIndex, System.Drawing.Pen penPatternRegion_OK, bool bResult_Job, int nArrayIndex, Bitmap imgResult, int nJobIndex)
        {
            Rect Roi = CConverter.RectToCVRect(job.SearchRegion);
            Rect RoiValue = CConverter.RectToCVRect(job.valueRect);

            Mat imgGrab = OpenCvSharp.Extensions.BitmapConverter.ToMat(images24_board[nImageIndex].ToBitmap());

            Mat imgStart = new Mat();
            Mat imgBin = new Mat();
            if (job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
                Cv2.CvtColor(imgGrab, imgStart, ColorConversionCodes.BGR2GRAY);
            else if (job.CCoordinate == CJob.ColorCoordinate.CC_BGR)
                imgStart = imgGrab.Clone();
            else if (job.CCoordinate == CJob.ColorCoordinate.CC_HSV)
                Cv2.CvtColor(imgGrab, imgStart, ColorConversionCodes.BGR2HSV);
            else if (job.CCoordinate == CJob.ColorCoordinate.CC_XYZ)
                Cv2.CvtColor(imgGrab, imgStart, ColorConversionCodes.BGR2XYZ);
            else if (job.CCoordinate == CJob.ColorCoordinate.CC_YUV)
                Cv2.CvtColor(imgGrab, imgStart, ColorConversionCodes.BGR2YUV);
            else
            {
                return false;
            }

            Mat imgArea = imgStart.SubMat(Roi);
            Mat imgValue = imgStart.SubMat(RoiValue);

            if (job.CMethod == CJob.ColorMethod.CA_THRESHILD && job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
            {
                int nThreshold = job.Threshold;
                imgBin = CVisionTools.GetThresholImage(imgArea, nThreshold, (int)job.CCoordinate, (int)job.CMethod);
            }
            else if (job.CMethod == CJob.ColorMethod.CA_ConvertGray) return false;
            else
            {
                Scalar scrMin = new Scalar();
                Scalar scrMax = new Scalar();
                scrMin.Val0 = job.Min0;
                scrMin.Val1 = job.Min1;
                scrMin.Val2 = job.Min2;
                scrMax.Val0 = job.Max0;
                scrMax.Val1 = job.Max1;
                scrMax.Val2 = job.Max2;
                IF_Util.SetImageRange(imgArea, scrMin, scrMax, imgBin);
            }

            CvBlobs blobs = new CvBlobs();
            blobs.Label(imgBin);
            if (job != null) blobs.FilterByArea(100, 200000);
            int nCountIn = 0;
            int nFind = 0;
            int nMax = 0;
            int nMin = int.MaxValue;
            job.dRate = 0;
            foreach (var b in blobs)
            {
                CogRectangle boundingRect = new CogRectangle();
                boundingRect.X = Roi.X + b.Value.Rect.X;
                boundingRect.Y = Roi.Y + b.Value.Rect.Y;
                boundingRect.Width = b.Value.Rect.Width;
                boundingRect.Height = b.Value.Rect.Height;
                boundingRect.Color = CogColorConstants.Green;
                boundingRect.LineWidthInScreenPixels = 3;

                nFind++;
                if (b.Value.Area > job.RangeAreaMin && b.Value.Area < job.RangeAreaMax)
                {
                    g.DrawRectangle(penPatternRegion_OK, CVisionCognex.CogRectToRectangle(boundingRect));
                    nCountIn++;
                    job.dRate = b.Value.Area;
                }
                if (b.Value.Area > nMax) nMax = b.Value.Area;
                if (b.Value.Area < nMin) nMin = b.Value.Area;
            }

            if (nCountIn > 0) bResult_Job = true;
            else
            {
                if (nMin == int.MaxValue)
                    nMin = 0;
                job.dRate = job.RangeAreaMin - nMin > nMax - job.RangeAreaMax ? nMax : nMin;
                bResult_Job = false;
            }

            DrawResultImageAdjust(bResult_Job, Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs, nJobIndex, "", "nofuse", ref imgResult);

            return bResult_Job;
        }



        //public static bool Inspection_Condensor(Graphics g, CJob job, CogImage8Grey[] images8_board, int nImageIndex, System.Drawing.Pen penSearchRegion, bool nmode)
        //{
        //    string ResultTime = "";

        //    try
        //    {
        //        Stopwatch tactTime = new Stopwatch();
        //        tactTime.Start();

        //        job.Find_Circle.InputImage = images8_board[nImageIndex];
        //        job.Find_Circle.Run();

        //        Display_Main.InteractiveGraphics.Clear();
        //        Display_Main.StaticGraphics.Clear();

        //        if (job.Find_Circle.Results == null || job.Find_Circle.Results.NumPointsFound < job.MinFoundCount)
        //        {
        //            ResultTime = $"Result : N/A TactTime : {tactTime.ElapsedMilliseconds}ms";
        //        }
        //        else if (job.Find_Circle.Results != null && job.Find_Circle.Results.Count > 0)
        //        {
        //            //for (int i = 0; i < job.Find_Circle.Results.Count; i++)
        //            //{
        //            //    //cogDisplay_Camera.StaticGraphics.Add(_tool.Results[i].CreateResultGraphics(CogFindCircleResultGraphicConstants.All), "RESULT");
        //            //}

        //            CogCircle resultGraphic = job.Find_Circle.Results.GetCircle();
        //            Display_Main.StaticGraphics.Add(resultGraphic, "resultGraphic");

        //            if (resultGraphic != null)
        //            {
        //                Rectangle boundingBox = CUtil.BondingBox_Circle((int)resultGraphic.CenterX, (int)resultGraphic.CenterY, (int)resultGraphic.Radius, 50);

        //                int offsetSize = boundingBox.Width / 2;
        //                CogRectangle meanRectTop = new CogRectangle();
        //                meanRectTop.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + offsetSize / 4, offsetSize, offsetSize);

        //                CogRectangle meanRectBtm = new CogRectangle();
        //                meanRectBtm.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height - offsetSize / 4, offsetSize, offsetSize);

        //                CogRectangle meanRectLeft = new CogRectangle();
        //                meanRectLeft.SetCenterWidthHeight(boundingBox.X + offsetSize / 4, boundingBox.Y + boundingBox.Height / 2, offsetSize, offsetSize);

        //                CogRectangle meanRectRight = new CogRectangle();
        //                meanRectRight.SetCenterWidthHeight(boundingBox.X + boundingBox.Width - offsetSize / 4, boundingBox.Y + boundingBox.Height / 2, offsetSize, offsetSize);

        //                using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(images8_board[nImageIndex].ToBitmap()))
        //                {
        //                    CUtil.SetImageChannel1(imgOrg);

        //                    using (Mat imgSubMat_T = imgOrg.SubMat(CConverter.CogRectToCVRect(meanRectTop)))
        //                    using (Mat imgSubMat_B = imgOrg.SubMat(CConverter.CogRectToCVRect(meanRectBtm)))
        //                    using (Mat imgSubMat_L = imgOrg.SubMat(CConverter.CogRectToCVRect(meanRectLeft)))
        //                    using (Mat imgSubMat_R = imgOrg.SubMat(CConverter.CogRectToCVRect(meanRectRight)))
        //                    {
        //                        Dictionary<string, double> meanValues = new Dictionary<string, double>();
        //                        meanValues.Add("T", Cv2.Mean(imgSubMat_T).Val0);
        //                        meanValues.Add("B", Cv2.Mean(imgSubMat_B).Val0);
        //                        meanValues.Add("L", Cv2.Mean(imgSubMat_L).Val0);
        //                        meanValues.Add("R", Cv2.Mean(imgSubMat_R).Val0);

        //                        string brightnestKey = "";
        //                        double brightnestValue = 0;
        //                        foreach (var item in meanValues)
        //                        {
        //                            if (brightnestValue < item.Value)
        //                            {
        //                                brightnestKey = item.Key;
        //                                brightnestValue = item.Value;
        //                            }
        //                        }

        //                        if (brightnestKey == "T")
        //                        {
        //                            CCognexUtil.DrawText(Display_Main, new Point2d(meanRectTop.X, meanRectTop.Y - 20), $"Brightness : {meanValues["T"].ToString("F3")}", CogColorConstants.Blue);
        //                            Display_Main.StaticGraphics.Add(meanRectTop, "meanRectTop");
        //                        }
        //                        if (brightnestKey == "B")
        //                        {
        //                            CCognexUtil.DrawText(Display_Main, new Point2d(meanRectBtm.X, meanRectBtm.Y - 20), $"Brightness : {meanValues["B"].ToString("F3")}", CogColorConstants.Blue);
        //                            Display_Main.StaticGraphics.Add(meanRectBtm, "meanRectBtm");
        //                        }
        //                        if (brightnestKey == "L")
        //                        {
        //                            CCognexUtil.DrawText(Display_Main, new Point2d(meanRectLeft.X, meanRectLeft.Y - 20), $"Brightness : {meanValues["L"].ToString("F3")}", CogColorConstants.Blue);
        //                            Display_Main.StaticGraphics.Add(meanRectLeft, "meanRectLeft");
        //                        }
        //                        if (brightnestKey == "R")
        //                        {
        //                            CCognexUtil.DrawText(Display_Main, new Point2d(meanRectRight.X, meanRectRight.Y - 20), $"Brightness : {meanValues["R"].ToString("F3")}", CogColorConstants.Blue);
        //                            Display_Main.StaticGraphics.Add(meanRectRight, "meanRectRight");
        //                        }

        //                        ResultTime = $"Result : {brightnestKey} TactTime : {tactTime.ElapsedMilliseconds}ms";
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                CUtil.ShowMessageBox("Error", "Find Line Results Empty");
        //            }
        //        }
        //        else
        //        {
        //            CUtil.ShowMessageBox("Error", "Find Line Results Empty");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //        CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
        //    }
        //}


        public static bool Inspection_ICRead(Graphics g, Graphics g_OnlyNG, CJob job, CogImage8Grey[] images8_board, int nImageIndex, System.Drawing.Pen penSearchRegion, System.Drawing.Pen penPatternRegion_OK, int nJobIndex, bool bResult_Job, System.Drawing.Font font, System.Drawing.Font font_NG, SolidBrush brush_OK, SolidBrush brush_NG, System.Drawing.Rectangle rtArrayRoi, int nArrayIndex)
        {
            CCogTool_PMAlign PMAlign = job.Tool;
            PMAlign.Tool.InputImage = images8_board[nImageIndex];
            PMAlign.Tool.RunParams.ApproximateNumberToFind = job.MasterCount;
            PMAlign.Tool.Run();

            CogPMAlignResult result_JopIcLead = null;

            g.DrawRectangle(penSearchRegion, CVisionCognex.CogRectToRectangle((CogRectangle)PMAlign.Tool.SearchRegion));

            if (PMAlign.Tool.Results != null)
            {
                for (int j = 0; j < PMAlign.Tool.Results.Count; j++)
                {
                    result_JopIcLead = PMAlign.Tool.Results[j];
                    g.DrawRectangle(penPatternRegion_OK, CVisionCognex.PatternToRect(PMAlign.Tool, result_JopIcLead));
                }
            }

            if (PMAlign.Tool.Results.Count == job.MasterCount)
            {
                bResult_Job = true;
                DrawStingAdjust($"[OK] {Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs[nJobIndex].Name} ({PMAlign.Tool.Results.Count}/{job.MasterCount}) ", font, brush_OK, job.SearchRegion.Location, g, rtArrayRoi.Width);
            }
            else
            {
                bResult_Job = false;
                DrawStingAdjust($"[NG] {Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs[nJobIndex].Name} ({PMAlign.Tool.Results.Count}/{job.MasterCount}) ", font_NG, brush_NG, job.SearchRegion.Location, g, rtArrayRoi.Width);
                DrawStingAdjust($"[NG] {Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs[nJobIndex].Name} ({PMAlign.Tool.Results.Count}/{job.MasterCount}) ", font_NG, brush_NG, job.SearchRegion.Location, g_OnlyNG, rtArrayRoi.Width);

                g.DrawRectangle(penSearchRegion, CVisionCognex.CogRectToRectangle((CogRectangle)PMAlign.Tool.SearchRegion));
                g_OnlyNG.DrawRectangle(penSearchRegion, CVisionCognex.CogRectToRectangle((CogRectangle)PMAlign.Tool.SearchRegion));
            }
            return bResult_Job;
        }

        public static bool Inspection_OCR(CJob job, bool bResult_Job, int nArrayIndex, int nJobIndex, Bitmap imgResult)
        {
            CCogTool_OCR OCR_Tool = job.OCRTool;
            CogImage8Grey m_imgSource_Mono = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
            OCR_Tool.Run(m_imgSource_Mono);
            DrawResultImageAdjust(bResult_Job, Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs, nJobIndex, "", "nofuse", ref imgResult);
            return true;
        }
        //public static bool Inspeciont_OCR(Graphics g, CJob job, CogImage8Grey[] images8_board, int nImageIndex, CogRectangle Rect)
        //{
        //    CogOCRMaxTool OCRMaxTool = new CogOCRMaxTool();
        //    // Load an image containing the text to read.
        //    Bitmap bmp = new Bitmap(
        //      System.Environment.GetEnvironmentVariable("VPRO_ROOT") +
        //      @"\images\alphanumbers.bmp");

        //    CogImage8Grey image = new CogImage8Grey(bmp);

        //    // Create a rectangle that surrounds the text 
        //    // "ABCDEFGHIJKLMNOPQRSTUVWXYZ" in the image.
        //    CogRectangleAffine rect = new CogRectangleAffine();
        //    rect
        //    rect.SetOriginLengthsRotationSkew(340, 748, 1010, 93, 0, 0);

        //    // Set the image and search region of the tool.
        //    OCRMaxTool.InputImage = image;
        //    OCRMaxTool.Region = rect;
        //    job.OCRMaxTool.InputImage = images8_board[nImageIndex];

        //    // Segment the characters in the image.
        //    OCRMaxTool.Run();

        //    if (OCRMaxTool.RunStatus.Result != CogToolResultConstants.Accept ||
        //        OCRMaxTool.LineResult.Count != 26)
        //    {
        //        Console.WriteLine(
        //          "Initial segmentation failed. " + OCRMaxTool.RunStatus.Message);
        //        return false;
        //    }

        //    // Get an array of Unicode UTF-32 character codes
        //    // which represent a string of all the letters in the 
        //    // english alphabet.
        //    string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //    int[] alphabetCharCodes =
        //      CogOCRMaxChar.GetCharCodesFromString(alphabetString);

        //    // Label each segmented character with the correct
        //    // character code and add it to the classifier's font.
        //    for (int i = 0; i < OCRMaxTool.LineResult.Count; i++)
        //    {
        //        CogOCRMaxChar c = OCRMaxTool.LineResult[i].GetCharacter();
        //        c.CharacterCode = alphabetCharCodes[i];
        //        OCRMaxTool.Classifier.Font.Add(c);
        //    }

        //    try
        //    {
        //        // Train the classifier based on the font.
        //        OCRMaxTool.Classifier.Train();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(
        //          "Failed to train classifier characters: " + ex.Message);
        //    }

        //    // Run the (now trained) tool again.
        //    OCRMaxTool.Run();

        //    if (OCRMaxTool.RunStatus.Result != CogToolResultConstants.Accept)
        //    {
        //        Console.WriteLine("OCRMax tool failed: " + OCRMaxTool.RunStatus.Message);
        //        return false;
        //    }

        //    if (OCRMaxTool.LineResult.Status != CogOCRMaxLineResultStatusConstants.Read)
        //    {
        //        Console.WriteLine("OCRMax tool failed to read the line of text.");
        //        return false;
        //    }

        //    // Print out the read string.
        //    Console.WriteLine("OCRMax Tool read the string: " + OCRMaxTool.LineResult.ResultString);
        //    return false;
        //}
        public static bool Inspection_Classification(CJob job, bool bResult_Job, int nArrayIndex, int nJobIndex, Bitmap imgResult)
        {
            CCogTool_OCR OCR_Tool = job.OCRTool;

            CogImage8Grey m_imgSource_Mono = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
            OCR_Tool.Run(m_imgSource_Mono);

            DrawResultImageAdjust(bResult_Job, Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs, nJobIndex, "", "nofuse", ref imgResult);
            return true;
        }

        public enum JobRectOption
        {
            JRO_Origin = 0,
            JRO_OriginInfo,
            JRO_DrawInfo,
            JRO_CalcImg,
            JRO_BinImg,
            JRO_MaskImg,
            JRO_MaskGrayImg,
        }

        public static Mat BGR2Convert(Mat inImg, CJob.ColorCoordinate enCoord)
        {
            Mat imgReturn = new Mat();
            if (enCoord < 0) enCoord = 0;
            switch (enCoord)
            {
                case CJob.ColorCoordinate.CC_GRAY:
                    Cv2.CvtColor(inImg, imgReturn, ColorConversionCodes.BGR2GRAY);
                    break;

                case CJob.ColorCoordinate.CC_BGR:
                    imgReturn = inImg.Clone();
                    break;

                case CJob.ColorCoordinate.CC_HSV:
                    Cv2.CvtColor(inImg, imgReturn, ColorConversionCodes.BGR2HSV);
                    break;

                case CJob.ColorCoordinate.CC_XYZ:
                    Cv2.CvtColor(inImg, imgReturn, ColorConversionCodes.BGR2XYZ);
                    break;

                case CJob.ColorCoordinate.CC_YUV:
                    Cv2.CvtColor(inImg, imgReturn, ColorConversionCodes.BGR2YUV);
                    break;

                default:
                    imgReturn = null;
                    break;
            }

            return imgReturn;
        }

        public static List<Mat> GetColorImages(Mat inImg, CJob job, Rect Roi, Rect RoiValue)
        {
            List<Mat> resultImages = new List<Mat>();
            Mat imgBin = new Mat();
            if(job.CCoordinate < 0) job.CCoordinate = 0;
            Mat imgStart = CVisionTools.BGR2Convert(inImg, job.CCoordinate);               // 색좌표 변경
            if (imgStart == null)                                                       // 예외 처리
            {
                string strMsg = $"{job.Name} BGR2Convert Fail !!!";
                IF_Util.ShowMessageBox("EXCEPTION", strMsg, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
                return resultImages;
            }

            Mat imgArea = imgStart.SubMat(Roi);
            Mat imgValue = imgStart.SubMat(RoiValue);

            if (job.CMethod == CJob.ColorMethod.CA_THRESHILD && job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
            {
                int nThreshold = job.Threshold;
                imgBin = GetThresholImage(imgArea, nThreshold, (int)job.CCoordinate, (int)job.CMethod);

                InsertResultImg(imgBin, inImg, Roi);                                      // 결과 이미지 원본이미지 삽입
            }
            else
            {
                // JobFile의 설정값 가져 오기
                Scalar scrMin = new Scalar(job.Min0, job.Min1, job.Min2);
                Scalar scrMax = new Scalar(job.Max0, job.Max1, job.Max2);
                IF_Util.SetImageRange(imgArea, scrMin, scrMax, imgBin);

                InsertResultImg(imgBin, inImg, Roi);                                       // 결과 이미지 원본이미지 삽입
            }
            resultImages.Add(imgBin);
            resultImages.Add(inImg);
            return resultImages;
        }

        public static cColorResult AutoColorParam(Mat inImg, Rect rctArea, Rect rctValue, CJob.ColorCoordinate enCoord, CJob.ColorMethod enMethod, string jobName)
        {
            cColorResult resultInfo = new cColorResult();

            Mat imgStart = BGR2Convert(inImg, enCoord);                                 // 색좌표 변경
            if (imgStart == null)                                                       // 예외 처리
            {
                string strMsg = $"{jobName} BGR2Convert Fail !!!";
                IF_Util.ShowMessageBox("EXCEPTION", strMsg, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
                return resultInfo;
            }

            // Gray / Threshold시
            if (enMethod == CJob.ColorMethod.CA_THRESHILD && enCoord == CJob.ColorCoordinate.CC_GRAY)
            {
                Mat imgSub = imgStart.SubMat(rctArea);                                  // Image영역 자름
                Mat imgValue = imgStart.SubMat(rctValue);                               // Threshold 영역 자름
                Mat imgBin = new Mat();                                                 // 이진화 이미지

                Tuple<int, int> thresInfo = GetAutoThreshold(imgValue);                 // 자동 Threshold 처리
                if (thresInfo.Item1 < 0)                                                // 예외 처리
                {
                    IF_Util.ShowMessageBox("EXCEPTION", "Threshold Find Fail !!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
                    return resultInfo;
                }

                // Range, Threshold 입력
                resultInfo.InputAreaInfo((int)(thresInfo.Item2 * 0.5), (int)(thresInfo.Item2 * 1.5), thresInfo.Item1);

                // Threshold
                Cv2.Threshold(imgSub, imgBin, thresInfo.Item1, 255, ThresholdTypes.Binary);

                // 결과 이미지 생성 및 리턴
                InsertResultImg(imgBin, inImg, rctArea);

                // 이미지 입력
                resultInfo.InputImages(imgBin, inImg);
                return resultInfo;
            }
            else if (enMethod == CJob.ColorMethod.CA_ConvertGray)
            {
                return resultInfo;
            }
            else
            {
                Mat imgSub = imgStart.SubMat(rctArea);
                Mat imgValue = imgStart.SubMat(rctValue);
                Mat imgBin = new Mat();

                // Min/Max를 각 채널별로 얻는다.
                Tuple<Scalar, Scalar> minMaxVals = GetMinMaxAreaValues(imgValue, enMethod);

                // Color정보 입력
                resultInfo.InputColorInfo(minMaxVals.Item1, minMaxVals.Item2);

                IF_Util.SetImageRange(imgSub, minMaxVals.Item1, minMaxVals.Item2, imgBin);

                // 결과 이미지 생성 및 리턴
                InsertResultImg(imgBin, inImg, rctArea);

                // 이미지 입력
                resultInfo.InputImages(imgBin, inImg);
                return resultInfo;
            }
        }

        public static Bitmap GetPatterernImage(bool isCalculate, ref CJob job, Mat inImg)
        {
            Bitmap imgOrigin = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(inImg);

            Rect Roi = CConverter.RectToCVRect(job.SearchRegion);
            Rect RoiValue = CConverter.RectToCVRect(job.valueRect);
            if (isCalculate)
            {
                cColorResult resultColor = CVisionTools.AutoColorParam(inImg, Roi, RoiValue, job.CCoordinate, job.CMethod, job.Name);
                resultColor.SetJob(ref job);
            }
            else
            {
                List<Mat> images = CVisionTools.GetColorImages(inImg, job, Roi, RoiValue);
            }

            // Binary 일시
            if (job.useBinary)
            {
                Mat imgBin = GetRectImage(imgOrigin, job, CVisionTools.JobRectOption.JRO_BinImg, 0);
                InsertResultImg(imgBin, inImg, Roi);                                      // 결과 이미지 원본이미지 삽입
            }
            else
            {
                Mat imgMask = GetRectImage(imgOrigin, job, CVisionTools.JobRectOption.JRO_MaskGrayImg, 0);
                InsertResultImg(imgMask, inImg, Roi);
            }
            Bitmap imgOut = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(inImg);
            return imgOut;
        }

        public static Bitmap GetPatterernImage_Train(bool isCalculate, ref CJob job, Mat inImg, CogRectangle Roi_Search, CogRectangle Roi_Pattern, CogRectangle Roi_Crop, CogRectangle Roi_PatternColor)
        {
            Bitmap imgOrigin = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(inImg);

            Rect Roi = new Rect(Convert.ToInt32(Roi_Search.X), Convert.ToInt32(Roi_Search.Y), Convert.ToInt32(Roi_Search.Width), Convert.ToInt32(Roi_Search.Height));
            Rect RoiValue = new Rect((int)Roi_PatternColor.X, (int)Roi_PatternColor.Y, (int)Roi_PatternColor.Width, (int)Roi_PatternColor.Height);
            if (isCalculate)
            {
                if ((int)job.CCoordinate < 0)
                {
                    job.CCoordinate = (CJob.ColorCoordinate)0;
                }
                cColorResult resultColor = CVisionTools.AutoColorParam(inImg, Roi, RoiValue, job.CCoordinate, job.CMethod, job.Name);
                resultColor.SetJob(ref job);
            }
            else
            {
                List<Mat> images = CVisionTools.GetColorImages(inImg, job, Roi, RoiValue);
            }

            // Binary 일시
            if (job.useBinary)
            {
                Mat imgBin = GetRectImage(imgOrigin, job, CVisionTools.JobRectOption.JRO_BinImg, 0);
                InsertResultImg(imgBin, inImg, Roi);                                      // 결과 이미지 원본이미지 삽입
            }
            else
            {
                Mat imgMask = GetRectImage(imgOrigin, job, CVisionTools.JobRectOption.JRO_MaskGrayImg, 0);
                InsertResultImg(imgMask, inImg, Roi);
            }
            Bitmap imgOut = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(inImg);
            return imgOut;
        }
        
        public static Tuple<int, int> GetAutoThreshold(Mat inImg)
        {
            int nThres = 128;
            int nDivide = 128;
            int nMax = 0, nFinalThres = -1;
            int totalArea = inImg.Width * inImg.Height;
            while (true)
            {
                int nValue = GetThresholdSize(inImg, nThres);
                if (nDivide == 1)
                    break;
                nDivide /= 2;
                if (nValue >= totalArea)
                    nThres += nDivide;
                else
                {
                    if (nValue > nMax)
                    {
                        nMax = nValue;
                        nFinalThres = nThres;
                    }
                    nThres -= nDivide;
                }
            }
            return new Tuple<int, int>(nFinalThres, nMax);
        }

        public static int GetThresholdSize(Mat imgIn, int nThres)
        {
            Mat imgBin = new Mat();
            Cv2.Threshold(imgIn, imgBin, nThres, 255, ThresholdTypes.Binary);
            CvBlobs blobs = new CvBlobs();
            blobs.Label(imgBin);
            blobs.FilterByArea(100, 200000);

            int nMaxArea = -1;
            foreach (var b in blobs)
            {
                if (b.Value.Rect.Width == imgIn.Width || b.Value.Rect.Height == imgIn.Height)
                {
                    nMaxArea = imgIn.Width * imgIn.Height;
                }

                if (nMaxArea < b.Value.Area) nMaxArea = b.Value.Area;
            }
            return nMaxArea;
        }

        public static Tuple<Scalar, Scalar> GetMinMaxAreaValues(Mat inImg, CJob.ColorMethod enMethod)
        {
            Cv2.Split(inImg, out Mat[] imgAreas);

            Scalar scrMin = new Scalar();
            Scalar scrMax = new Scalar();
            for (int i = 0; i < imgAreas.Length; i++)        // Min/Max Algorithm
            {
                OpenCvSharp.Point minPt = new OpenCvSharp.Point();
                OpenCvSharp.Point maxPt = new OpenCvSharp.Point();
                Cv2.MinMaxLoc(imgAreas[i], out minPt, out maxPt);
                scrMin[i] = (Byte)imgAreas[i].At<int>(minPt.Y, minPt.X);
                if (enMethod == CJob.ColorMethod.CA_RANGE)
                    scrMax[i] = (Byte)imgAreas[i].At<int>(maxPt.Y, maxPt.X);
                else
                    scrMax[i] = 255;
            }

            return new Tuple<Scalar, Scalar>(scrMin, scrMax);
        }

        public static Mat GetRectImage(Bitmap OriginImg, CJob job, JobRectOption option, int nWide)
        {
            SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));
            System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 24, FontStyle.Bold);

            Mat img = new Mat();

            Bitmap bmpLast = OriginImg;
            Mat imgDraw = OpenCvSharp.Extensions.BitmapConverter.ToMat(OriginImg).Clone();
            Mat imgGray = new Mat();
            Mat imglast = new Mat();
            if ((job.Type.Contains("Pattern") && option == JobRectOption.JRO_CalcImg) ||
                (job.Type.Contains("Pattern") && option == JobRectOption.JRO_DrawInfo))
            {
                //if (job.CMethod == CJob.ColorMethod.CA_ConvertGray)
                //{
                Cv2.CvtColor(imgDraw, imgGray, ColorConversionCodes.BGR2GRAY);
                Cv2.CvtColor(imgGray, imglast, ColorConversionCodes.GRAY2BGR);
                //}
                //else
                //{
                //    // 여기는 이미지 변환을 하기 위하여 Gray가 아닌 Color를 이용한다.
                //    imgDraw.CopyTo(imglast);
                //}
            }
            else
            {
                imgDraw.CopyTo(imglast);
            }
            bmpLast = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imglast);

            Rect subRt = new Rect();

            System.Drawing.Rectangle searchRect = job.SearchRegion;
            System.Drawing.Rectangle patternRect = new System.Drawing.Rectangle();
            //int nWide = 50;

            subRt = CConverter.RectToCVRect(searchRect);
            subRt.Inflate(nWide, nWide);
            if (job.Type.Contains("Pattern"))
            {
                searchRect = GetSearchRect(job.nPatternIndex, job);
                patternRect = GetPatternRect(job.nPatternIndex, job);
            }
            else if (job.Type.Contains("Color"))
            {
                searchRect = job.SearchRegion;
                patternRect = job.valueRect;
            }

            if (subRt.X < 0) subRt.X = 0;
            if (subRt.Y < 0) subRt.Y = 0;
            if (subRt.X + subRt.Width > bmpLast.Width) subRt.Width = bmpLast.Width - subRt.X;
            if (subRt.Y + subRt.Height > bmpLast.Height) subRt.Height = bmpLast.Height - subRt.Y;

            if (option == JobRectOption.JRO_DrawInfo || option == JobRectOption.JRO_OriginInfo)
            {
                String strJudge = GetJudgeStr(false, job, "", "");
                String strOption = GetOptionStr(false, job);
                String strRate = GetRateStr(false, job, job.dRate);
                Graphics gCrop = Graphics.FromImage(bmpLast);
                System.Drawing.Pen penCrop_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 64, 32), 5);
                System.Drawing.Pen penCrop_Region = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 192, 192, 64), 5);
                System.Drawing.Point ptJudge = new System.Drawing.Point(job.SearchRegion.Location.X - nWide, job.SearchRegion.Location.Y - nWide);
                System.Drawing.Point ptOption = new System.Drawing.Point(job.SearchRegion.Location.X - nWide, job.SearchRegion.Location.Y);
                System.Drawing.Point ptRate = new System.Drawing.Point(job.SearchRegion.Location.X - nWide, job.SearchRegion.Location.Y + nWide);

                if (option == JobRectOption.JRO_DrawInfo)
                {
                    DrawCropString(strJudge, font_NG, brush_NG, ptJudge, gCrop, subRt.Width);
                    DrawCropString(strOption, font_NG, brush_NG, ptOption, gCrop, subRt.Width);
                    DrawCropString(strRate, font_NG, brush_NG, ptRate, gCrop, subRt.Width);
                }
                gCrop.DrawRectangle(penCrop_Region, searchRect);
                gCrop.DrawRectangle(penCrop_NG, patternRect);
            }

            Mat matImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmpLast);
            if (option == JobRectOption.JRO_Origin || option == JobRectOption.JRO_OriginInfo)
                return matImg.SubMat(subRt);
            else if (option == JobRectOption.JRO_DrawInfo)
            {
                // 여기서 분류를 한다.
                //if (job.CMethod == CJob.ColorMethod.CA_ConvertGray)
                return matImg.SubMat(subRt);
                //else
                //{
                //    List<Mat> Crops = DrawColorImage(imgDraw, job);
                //    return Crops[1];
                //}
            }
            else if (option == JobRectOption.JRO_CalcImg)
            {
                if (job.Type.Contains("Color"))
                {
                    List<Mat> Crops = DrawColorImage(imgDraw, job);
                    return Crops[1];
                    //Cv2.ImWrite("E:\\Roi.job", matCrop2);
                }
                else if (job.Type.Contains("Pattern"))
                {
                    Bitmap bmpCrop2 = job.Tool.Tool.Pattern.GetTrainedPatternImage().ToBitmap();
                    return OpenCvSharp.Extensions.BitmapConverter.ToMat(bmpCrop2);
                }
                else
                    return img;
            }
            else if (option == JobRectOption.JRO_BinImg)
            {
                List<Mat> Crops = DrawColorImage(imgDraw, job);
                return Crops[2];
            }
            else if (option == JobRectOption.JRO_MaskImg || option == JobRectOption.JRO_MaskGrayImg)
            {
                Rect maskRt = new Rect();
                maskRt.X = job.SearchRegion.X;
                maskRt.Y = job.SearchRegion.Y;
                maskRt.Width = job.SearchRegion.Width;
                maskRt.Height = job.SearchRegion.Height;
                List<Mat> Crops = DrawColorImage(imgDraw, job);
                Mat imgMasking = matImg.SubMat(maskRt);
                Cv2.BitwiseAnd(imgMasking, Crops[2], imgMasking);
                if (option == JobRectOption.JRO_MaskGrayImg)
                    Cv2.CvtColor(imgMasking, imgMasking, ColorConversionCodes.BGR2GRAY);
                //Cv2.CopyTo(imgMasking, imgMasking, Crops[2]);
                return imgMasking;
                //return Crops[2];
            }
            else
                return img;
        }

        public static List<Mat> DrawColorImage(Mat originImg, CJob job)
        {
            List<Mat> Results = new List<Mat>();
            Mat inImg = originImg.Clone();
            Mat imgBin = new Mat();
            Rect cutRect = new Rect();
            Mat imgCopy = new Mat();
            try
            {
                System.Drawing.Rectangle Roi_ColorSearchRegion = job.SearchRegion;
                System.Drawing.Rectangle Roi_ColorVAlues = job.valueRect;
                Rect Roi = new Rect((int)Roi_ColorSearchRegion.X, (int)Roi_ColorSearchRegion.Y, (int)Roi_ColorSearchRegion.Width, (int)Roi_ColorSearchRegion.Height);
                Rect RoiValue = new Rect((int)Roi_ColorVAlues.X, (int)Roi_ColorVAlues.Y, (int)Roi_ColorVAlues.Width, (int)Roi_ColorVAlues.Height);
                cutRect = Roi;
                //cutRect.Inflate(nWide, nWide);
                //if (cutRect.X + cutRect.Width > inImg.Width)
                //    cutRect.Width = inImg.Width - cutRect.X;
                //if (cutRect.Y + cutRect.Height > inImg.Height)
                //    cutRect.Height = inImg.Height - cutRect.Y;

                Mat imgStart = new Mat();
                if (job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
                    Cv2.CvtColor(inImg, imgStart, ColorConversionCodes.BGR2GRAY);
                else if (job.CCoordinate == CJob.ColorCoordinate.CC_BGR)
                    imgStart = inImg.Clone();
                else if (job.CCoordinate == CJob.ColorCoordinate.CC_HSV)
                    Cv2.CvtColor(inImg, imgStart, ColorConversionCodes.BGR2HSV);
                else if (job.CCoordinate == CJob.ColorCoordinate.CC_XYZ)
                    Cv2.CvtColor(inImg, imgStart, ColorConversionCodes.BGR2XYZ);
                else if (job.CCoordinate == CJob.ColorCoordinate.CC_YUV)
                    Cv2.CvtColor(inImg, imgStart, ColorConversionCodes.BGR2YUV);
                else
                {
                    CLogger.Add(LOG.ABNORMAL, $"Error - Coordinate[{job.CCoordinate.ToString()}] !!!");
                    return Results;
                }
                Mat imgArea = imgStart.SubMat(Roi);
                Mat imgValue = imgStart.SubMat(RoiValue);

                if (job.CMethod == CJob.ColorMethod.CA_THRESHILD && job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
                {
                    int nThreshold = job.Threshold;
                    imgBin = CVisionTools.GetThresholImage(imgArea, nThreshold, (int)job.CCoordinate, (int)job.CMethod);
                    Cv2.CvtColor(imgBin, imgCopy, ColorConversionCodes.GRAY2BGR);
                    InsertResultImg(imgBin, inImg, Roi);
                    blopProcessTool2(ref imgBin, Roi, ref inImg, job);
                }
                else
                {
                    Scalar scrMin = new Scalar();
                    Scalar scrMax = new Scalar();
                    scrMin.Val0 = job.Min0;
                    scrMin.Val1 = job.Min1;
                    scrMin.Val2 = job.Min2;
                    scrMax.Val0 = job.Max0;
                    scrMax.Val1 = job.Max1;
                    scrMax.Val2 = job.Max2;
                    IF_Util.SetImageRange(imgArea, scrMin, scrMax, imgBin);
                    Cv2.CvtColor(imgBin, imgCopy, ColorConversionCodes.GRAY2BGR);
                    InsertResultImg(imgBin, inImg, Roi);
                    blopProcessTool2(ref imgBin, Roi, ref inImg, job);
                }
                Results.Add(inImg);
                Results.Add(inImg.SubMat(cutRect));
                Results.Add(imgCopy);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
            return Results;
        }

        public static Mat InsertResultImg(Mat resultImg, Mat targetImg, Rect Roi)
        {
            Mat convertImg = new Mat();
            if (resultImg.Channels() == 1)
            {
                if (targetImg.Channels() == 1)
                    convertImg = resultImg.Clone();
                else
                    Cv2.CvtColor(resultImg, convertImg, ColorConversionCodes.GRAY2BGR);
            }
            else
            {
                if (targetImg.Channels() == 1)
                    Cv2.CvtColor(resultImg, convertImg, ColorConversionCodes.BGR2GRAY);
                else
                    convertImg = resultImg.Clone();
            }

            Mat retImg = targetImg.SubMat(Roi);
            convertImg.CopyTo(retImg);
            return targetImg;
        }

        public static int blopProcessTool(ref Mat imgIn, Rect Roi, ref Mat imgAll, Cognex.VisionPro.Display.CogDisplay display, CJob job)
        {
            //display.InteractiveGraphics.Clear();
            //display.StaticGraphics.Clear();

            CvBlobs blobs = new CvBlobs();
            blobs.Label(imgIn);
            if (job != null) blobs.FilterByArea(100, 200000);

            int nMaxArea = 0;
            Bitmap img = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgAll);
            display.Image = new Cognex.VisionPro.CogImage24PlanarColor(img);
            foreach (var b in blobs)
            {
                Cognex.VisionPro.CogRectangle boundingRect = new Cognex.VisionPro.CogRectangle();
                boundingRect.X = Roi.X + b.Value.Rect.X;
                boundingRect.Y = Roi.Y + b.Value.Rect.Y;
                boundingRect.Width = b.Value.Rect.Width;
                boundingRect.Height = b.Value.Rect.Height;
                if (b.Value.Area > job.RangeAreaMin && b.Value.Area < job.RangeAreaMax)
                    boundingRect.Color = Cognex.VisionPro.CogColorConstants.Green;
                else
                    boundingRect.Color = Cognex.VisionPro.CogColorConstants.Red;
                boundingRect.LineWidthInScreenPixels = 3;

                Cognex.VisionPro.CogGraphicLabel lb = new Cognex.VisionPro.CogGraphicLabel();
                if (b.Value.Area > job.RangeAreaMin && b.Value.Area < job.RangeAreaMax)
                    lb.Color = Cognex.VisionPro.CogColorConstants.Green;
                else
                    lb.Color = Cognex.VisionPro.CogColorConstants.Red;
                lb.Text = $"Area : {b.Value.Area}";
                lb.Font = new System.Drawing.Font("Arial", 12);
                lb.X = boundingRect.CenterX;
                lb.Y = boundingRect.CenterY;

                if (nMaxArea < b.Value.Area) nMaxArea = b.Value.Area;

                display.StaticGraphics.Add(boundingRect, "Rect");
                display.StaticGraphics.Add(lb, "Rect");
                //cogDisplay_Source.GetImage
            }
            Image imgLast = display.CreateContentBitmap(Cognex.VisionPro.Display.CogDisplayContentBitmapConstants.Image);
            Bitmap bmpLast = (Bitmap)imgLast.Clone();
            imgAll = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmpLast).Clone();
            imgIn = imgAll.SubMat(Roi);
            //Cv2.ImWrite("E:\\Roi.jpg", imgIn);
            //Cv2.ImWrite("E:\\All.jpg", imgIn);

            //job.AreaMin = (int)(nMaxArea * 0.5);
            //job.AreaMax = (int)(nMaxArea * 1.5);

            //display.InteractiveGraphics.Clear();
            //display.StaticGraphics.Clear();

            return nMaxArea;
        }

        public static int blopProcessTool2(ref Mat imgIn, Rect Roi, ref Mat imgAll, CJob job)
        {
            //display.InteractiveGraphics.Clear();
            //display.StaticGraphics.Clear();

            Mat imgResult = imgAll.Clone();
            Bitmap bmp = imgResult.ToBitmap();
            Graphics g = Graphics.FromImage(bmp);

            //// Overlay Draw
            System.Drawing.Pen pen_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5);
            System.Drawing.Pen pen_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 64, 32), 15);
            SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16));
            SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

            CvBlobs blobs = new CvBlobs();
            blobs.Label(imgIn);
            if (job != null) blobs.FilterByArea(100, 200000);

            int nMaxArea = 0;
            Bitmap img = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgAll);
            string strDisp = "";
            foreach (var b in blobs)
            {
                System.Drawing.Rectangle boundingRect = new System.Drawing.Rectangle();
                boundingRect.X = Roi.X + b.Value.Rect.X;
                boundingRect.Y = Roi.Y + b.Value.Rect.Y;
                boundingRect.Width = b.Value.Rect.Width;
                boundingRect.Height = b.Value.Rect.Height;

                if (nMaxArea < b.Value.Area) nMaxArea = b.Value.Area;

                System.Drawing.Point ptDisp =
                    new System.Drawing.Point((int)(boundingRect.X + boundingRect.Width) / 2, (int)(boundingRect.Y + boundingRect.Height) / 2);
                if (b.Value.Area > job.RangeAreaMin && b.Value.Area < job.RangeAreaMax)
                {
                    g.DrawString(strDisp, font, brush_OK, ptDisp);
                    g.DrawRectangle(pen_OK, boundingRect);
                }
                else
                {
                    g.DrawString(strDisp, font, brush_NG, ptDisp);
                    g.DrawRectangle(pen_NG, boundingRect);
                }
            }
            imgAll = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp).Clone();
            imgIn = imgAll.SubMat(Roi);

            return nMaxArea;
        }

        public static Mat DrawQRCode(Mat inImg, QRParser qrData, List<CJob> jobs, int nJobIndex)
        {
            Mat imgResult = inImg.Clone();
            Bitmap bmp = imgResult.ToBitmap();
            Graphics g = Graphics.FromImage(bmp);

            // Overlay Draw
            //System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5);
            System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(Color.Lime, 5);
            System.Drawing.Pen penPatternRegion_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5);
            System.Drawing.Pen penPatternRegion_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 64, 32), 15);
            SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16));
            SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));
            //SolidBrush brush_QR = new SolidBrush(System.Drawing.Color.FromArgb(128, 96, 64, 192));
            System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 168, 224, 168), 5);
            System.Drawing.Font font_Big = new System.Drawing.Font("Arial", 36, FontStyle.Bold);

            System.Drawing.Point pt1 = qrData.GetPt();
            pt1.Y -= 25;
            System.Drawing.Point pt2 = qrData.GetPt();

            string string1 = $"{qrData.GetPBA()}{qrData.GetModel()}";
            string string2 = $"{qrData.GetVendor()}{qrData.GetYMS()}{qrData.GetSerialNo()}";

            // 여기서 이전 Job의 Rect체크
            SizeF szStr = g.MeasureString(string1, font_Big);
            System.Drawing.Rectangle rctDraw = new System.Drawing.Rectangle(pt1.X, pt1.Y, (int)szStr.Width, (int)szStr.Height + 30);
            System.Drawing.Rectangle rctInterSect = rctDraw;
            for (int i = 0; i < nJobIndex; i++)
            {
                rctInterSect.Intersect(jobs[i].drawStringRect);
                if (!rctInterSect.IsEmpty)
                {
                    //if (rctDraw.Y < jobs[i].drawStringRect.Y)
                    rctDraw.Y = jobs[i].drawStringRect.Y + jobs[i].drawStringRect.Height + 1;
                    //else
                    //    rctDraw.Y = jobs[i].drawStringRect.Y - jobs[i].drawStringRect.Height - 1;
                    rctInterSect = rctDraw;
                }
                else
                    rctInterSect = rctDraw;
            }
            pt1.X = rctDraw.X;
            pt1.Y = rctDraw.Y;
            pt2.Y = pt1.Y + 75;
            SolidBrush brushDraw = brush_OK;
            if (qrData.IsError())
                brushDraw = brush_NG;
            // QR 검색 크기..
            System.Drawing.Point QR_PT = qrData.GetPt();
            System.Drawing.Rectangle QRDRAW = new System.Drawing.Rectangle(QR_PT.X - 170, QR_PT.Y - 150, (int)szStr.Width, (int)szStr.Height + 250);
            g.DrawRectangle(penSearchRegion, QRDRAW);
            DrawStingCenter($"{string1}", font_Big, brushDraw, pt1, g, imgResult.Width);
            DrawStingCenter($"{string2}", font_Big, brushDraw, pt2, g, imgResult.Width);

            imgResult = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp);

            return imgResult;
        }

        public static string GetOptionStr(bool bOk, CJob job)
        {
            string strPattern = "";
            String strReturn = "";

            string strMethod = "";
            switch (job.CMethod)
            {
                case CJob.ColorMethod.CA_THRESHILD:
                    strMethod = "AT";
                    break;

                case CJob.ColorMethod.CA_RANGE:
                    strMethod = "AR";
                    break;

                case CJob.ColorMethod.CA_ConvertGray:
                    strMethod = "AC";
                    break;
            }

            string strCoord = "";
            switch (job.CCoordinate)
            {
                case CJob.ColorCoordinate.CC_GRAY:
                    strCoord = "CG";
                    break;

                case CJob.ColorCoordinate.CC_BGR:
                    strCoord = "CB";
                    break;

                case CJob.ColorCoordinate.CC_HSV:
                    strCoord = "CH";
                    break;

                case CJob.ColorCoordinate.CC_XYZ:
                    strCoord = "CX";
                    break;

                case CJob.ColorCoordinate.CC_YUV:
                    strCoord = "CY";
                    break;
            }

            if (job.Type.Contains("Pattern"))
            {
                if (job.Judge_NaisNg)
                {
                    switch (job.nPatternIndex)
                    {
                        case 0:
                            //strPattern = "Main";
                            strPattern = "M";
                            break;

                        default:
                            //strPattern = $"Sub{job.nPatternIndex}";
                            strPattern = $"S{job.nPatternIndex}";
                            break;
                    }
                    strReturn = $"{strCoord}/{strMethod}/{strPattern}";
                }
                else
                {
                    strReturn = $"{strCoord}/{strMethod}/NOK";
                }
            }
            else if (job.Type.Contains("Color"))
            {
                strReturn = $"{strCoord}/{strMethod}/CR";
            }

            return strReturn;
        }

        /// <summary>
        /// 딥러닝 결과 표시
        /// </summary>
        /// <param name="bOk"></param>
        /// <param name="job"></param>
        /// <returns></returns>
        public static string GetJudgeStr(bool bOk, CJob job, string str_InspPartName, string str_Result_FuseColor)
        {
            String strReturn = "";

            if (str_Result_FuseColor == "nofuse")
            {
                if (bOk)
                    strReturn = $"OK-{job.Name}-{str_InspPartName}";
                else
                    strReturn = $"NG-{job.Name}-{str_InspPartName}";
            }
            else //fuse
            {
                // fuse의 값이 없을경우...
                if (str_Result_FuseColor != "")
                {
                    string str_JobName = "";

                    if (str_InspPartName == "fuse_noline")
                    {
                        //str_JobName = $"{strAry_JobPartName_split[0]}_noline";

                        if (bOk)
                            strReturn = $"OK-{str_JobName}";
                        else
                            strReturn = $"NG-{str_JobName}";
                    }
                    else
                    {
                        //str_JobName = $"{strAry_JobPartName_split[0]}_{strAry_JobPartName_split[1]}-{str_Result_FuseColor}";

                        if (bOk)
                            strReturn = $"OK-{str_JobName}";
                        else
                            strReturn = $"NG-{str_JobName}";
                    }
                }
                else
                {
                    if (bOk)
                        strReturn = $"OK-{job.Name}";
                    else
                        strReturn = $"NG-{job.Name}";
                }
            }


            return strReturn;
        }

        public static string GetRateStr(bool bOk, CJob job, double dScore)
        {
            String strReturn = "";

            if (job.Type.Contains("Pattern"))
            {
                if ((job.Judge_NaisNg && !bOk) || (!job.Judge_NaisNg && bOk))
                    strReturn = $"[{job.MinScore.ToString("F2")}]>{dScore.ToString("F2")}%";
                else
                    strReturn = $"[{job.MinScore.ToString("F2")}]<{dScore.ToString("F2")}%";
            }
            else if (job.Type.Contains("Color"))
            {
                if (job.RangeAreaMax < dScore)
                    strReturn = $"[{job.RangeAreaMax.ToString()}]<{dScore.ToString("F0")} px";
                else
                    strReturn = $"[{job.RangeAreaMin.ToString()}]>{dScore.ToString("F0")} px";
            }

            return strReturn;
        }

        public static float AdjustSize(System.Drawing.Point inPoint, int nImageWidth, float fontSize, int nStrLen)
        {
            float nSize = fontSize;
            int nWidth = nStrLen * Convert.ToInt32(nSize * 0.78);
            while (nWidth > nImageWidth)
            {
                nSize--;
                nWidth = nStrLen * Convert.ToInt32(nSize * 0.78);
                if (nSize < 0)
                {
                    nSize = 0;
                    break;
                }
            }
            return nSize;
        }

        public static void DrawCropString(string str, System.Drawing.Font font, System.Drawing.Brush brush, System.Drawing.Point ptIn, Graphics g, int Width)
        {
            // String 위치 조정
            int nLen = str.Length;
            float szSize = AdjustSize(ptIn, Width, font.Size, nLen);
            System.Drawing.Font fontDraw = new System.Drawing.Font("Arial", szSize, font.Style);
            g.DrawString(str, fontDraw, brush, ptIn);
        }

        // 저장 경로 스택 변수로 할당..
        public static string OK_Path;
        public static string OK_Part_Path;
        //public static string OK_Corp_Path;
        public static string NG_Path;
        public static string NG_Part_Path;
        public static string NG_Corp_Path;

        // 기본 오토로 처리..
        public static (string, string) InitDirectory_DateTime_ID(bool jude,string strDirPath, string strID, bool bAuto = true)
        {
            string path_OK = "";
            string path_NG = "";
            // 폴더 생성...처리 다시진행..
            string str_path = $"{strDirPath}\\{DateTime.Now.Year}\\{DateTime.Now.Month.ToString("D2")}";
            string path;

            if (bAuto)
            {
                path = $"{str_path}\\{DateTime.Now.Day.ToString("D2")}_Auto";
            }
            else
            {
                path = $"{str_path}\\{DateTime.Now.Day.ToString("D2")}_User";
            }

            path_OK = OK_Path = $"{path}\\OK\\{strID}";
            OK_Part_Path = $"{OK_Path}\\Part";
            //OK_Corp_Path = $"{OK_Path}\\Crop";
            path_NG = NG_Path = $"{path}\\NG\\{strID}";
            NG_Part_Path = $"{NG_Path}\\Part";
            NG_Corp_Path = $"{NG_Path}\\Crop";
            if (jude)
            {
                // 해당 폴더가 없을 경우 폴더 생성...
                if (!Directory.Exists(OK_Part_Path)) Directory.CreateDirectory(OK_Part_Path);
            }
            else
            {
                // 해당 폴더가 없을 경우 폴더 생성...
                if (!Directory.Exists(NG_Part_Path)) Directory.CreateDirectory(NG_Part_Path);
                // 해당 폴더가 없을 경우 폴더 생성...
                if (!Directory.Exists(NG_Corp_Path)) Directory.CreateDirectory(NG_Corp_Path);
            }

            return (path_OK, path_NG);
        }

        public static List<string> GetCropFileNames(bool bOk, string strQrCode, string strJobName, bool bAuto = true)
        {
            List<string> lstReturn = new List<string>();
            string strPath;
            if (bOk) strPath = OK_Path;
            else strPath = NG_Path;

            //string strPath = GetSavePath(bOk, strQrCode);

            lstReturn.Add($"{strPath}\\Crop\\OrigImg_{strQrCode}_{strJobName}.jpg");
            lstReturn.Add($"{strPath}\\Crop\\CalcImg_{strQrCode}_{strJobName}.jpg");

            return lstReturn;
        }

        public static List<string> GetPartFileNames(bool bOk, string strQrCode, string strJobName, bool bAuto = true)
        {
            List<string> lstReturn = new List<string>();
            //string strOk = CUtil.GetJudgeString(bOk);
            string strPath;
            if (bOk) strPath = OK_Path;
            else strPath = NG_Path;

            //string strPath = GetSavePath(bOk, strQrCode);

            lstReturn.Add($"{strPath}\\Part\\OriginImg_{strQrCode}_{strJobName}.jpg");
            lstReturn.Add($"{strPath}\\Part\\InfoImg_{strQrCode}_{strJobName}.jpg");
            //lstReturn.Add($"{strPath}\\Part\\Binary_{strQrCode}_{strJobName}.jpg");
            lstReturn.Add($"{strPath}\\Part\\PartImg_{strQrCode}_{strJobName}.jpg");
            return lstReturn;
        }


        public static bool chkPattern(CJob job)
        {
            bool bOK = true;
            int nLastPtn = GetLastPattern(job);

            for (int i = 0; i < nLastPtn; i++)
                bOK = bOK & isPatternImg(i, job);

            return bOK;
        }

        public static int GetLastPattern(CJob job)
        {
            int nLastPattern = -1;
            CCogTool_PMAlign PMAlign = null;

            PMAlign = job.Tool;
            if (job.SubTool4.Tool.Pattern.Trained)
                nLastPattern = 4;
            else if (job.SubTool3.Tool.Pattern.Trained)
                nLastPattern = 3;
            else if (job.SubTool2.Tool.Pattern.Trained)
                nLastPattern = 2;
            else if (job.SubTool1.Tool.Pattern.Trained)
                nLastPattern = 1;
            else if (job.Tool.Tool.Pattern.Trained)
                nLastPattern = 0;

            return nLastPattern;
        }

        public static bool isPatternImg(int nToolNo, CJob job)
        {
            bool bRet = false;
            switch (nToolNo)
            {
                case 4:
                    if (job.SubTool4.Tool.Pattern.Trained)
                        bRet = true;
                    break;

                case 3:
                    if (job.SubTool3.Tool.Pattern.Trained)
                        bRet = true;
                    break;

                case 2:
                    if (job.SubTool2.Tool.Pattern.Trained)
                        bRet = true;
                    break;

                case 1:
                    if (job.SubTool1.Tool.Pattern.Trained)
                        bRet = true;
                    break;

                case 0:
                    if (job.Tool.Tool.Pattern.Trained)
                        bRet = true;
                    break;
            }
            return bRet;
        }
        public static CogImage24PlanarColor RotateMarkedImage(CogImage24PlanarColor imageFiducialSrc, CogImage24PlanarColor imgRotateSrc, Library_Fiducial Recipe)
        {
            Point2d posFiducialMark = new Point2d();
            try
            {
                int mag_1st = 1;
                int mag_2st = 1;

                Stopwatch tactTime = new Stopwatch();
                tactTime.Start();

                CTemplateMatching matchingLT = new CTemplateMatching("LT");
                CTemplateMatching matchingRB = new CTemplateMatching("RB");
                int tactTime_1st = 0;

                using (Mat imgSrc_Grab0 = OpenCvSharp.Extensions.BitmapConverter.ToMat(imageFiducialSrc.ToBitmap()))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matchingLT.SetSourceImage(imgSrc_Grab0.ToBitmap());
                        matchingRB.SetSourceImage(imgSrc_Grab0.ToBitmap());

                        matchingLT.Run(Recipe.Fiducial1);
                        matchingRB.Run(Recipe.Fiducial2);

                        Point2d posLT = new Point2d(0, 0);
                        Point2d posRB = new Point2d(0, 0);

                        Rect rectLT = new Rect();
                        Rect rectRB = new Rect();

                        bool isError = false;

                        if (matchingLT.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (LT)"); isError = true; }
                        if (matchingRB.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (RB)"); isError = true; }

                        if (isError == false)
                        {
                            posLT = matchingLT.Results[0].Center;
                            posRB = matchingRB.Results[0].Center;

                            rectLT = matchingLT.Results[0].Bounding;
                            rectRB = matchingRB.Results[0].Bounding;

                            double angle = IF_Util.GetAngle(posLT, posRB);
                            double angleDelta = angle - Recipe.MasterAngle;

                            if (Math.Abs(angleDelta) < 0.05)
                            {
                                matchingLT.Run(Recipe.Fiducial1);
                                posFiducialMark = matchingLT.Results[0].Center;

                                return imgRotateSrc;
                            }
                            else
                            {
                                Point2f posCenter = new Point2f(imgSrc_Grab0.Width / 2, imgSrc_Grab0.Height / 2);

                                if (imgRotateSrc != null)
                                {
                                    using (Mat imgSrcforRot = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgRotateSrc.ToBitmap()))
                                    using (Mat imgRot = new Mat())
                                    {
                                        // 회전을 위한 변환 행렬을 얻습니다.
                                        Mat rotationMatrix = Cv2.GetRotationMatrix2D(posCenter, angleDelta, 1.0);
                                        Cv2.WarpAffine(imgSrcforRot, imgRot, rotationMatrix, imgSrcforRot.Size());
                                        Cv2.WarpAffine(imgSrc_Grab0, imgSrc_Grab0, rotationMatrix, imgSrc_Grab0.Size());

                                        imgRotateSrc = new CogImage24PlanarColor(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgRot.Clone()));
                                    }
                                }
                            }
                        }
                    }
                }
                

                
                
                CLogger.Add(LOG.INSP, $"Image Align T/T : {tactTime.ElapsedMilliseconds}ms");
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
            return imgRotateSrc;
        }
    }

    public class Fiducial
    {
        public string Name { get; set; } = "";
        public double LTScoreMin { get; set; } = 60.0D;
        public double RBScoreMin { get; set; } = 60.0D;
        public Rectangle LT_SerchRoi { get; set; } = new Rectangle(0, 0, 150, 150);
        public Rectangle LT_TrainRoi { get; set; } = new Rectangle(5, 5, 100, 100);
        public double ImageAlignMasterAngle { get; set; } = 0.0D;
        public Rectangle RB_SerchRoi { get; set; } = new Rectangle(0, 0, 300, 300);
        public Rectangle RB_TrainRoi { get; set; } = new Rectangle(0, 0, 100, 100);
        public enum BAREBOARD_JUDGE_TYPE { NO_USE, UNCONDITIONALLY_NG };
        public BAREBOARD_JUDGE_TYPE BareBoardJudgeType { get; set; } = BAREBOARD_JUDGE_TYPE.NO_USE;
        public Bitmap Image_LT_Template;
        public Bitmap Image_RB_Template;

        public CTemplateMatching m_Matching = new CTemplateMatching("Fiducial_Matching");

        public Fiducial(string name)
        {
            Name = name;
        }

        // json 데이터 저장...
        public void Fiducial_Json_Save(string Model_Name)
        {
            // 모델 이름에 맞는 피듀셜 마크 저장...
            string _Path = $"{Global.m_MainPJTRoot}\\RECIPE\\{Model_Name}\\Fiducial";

            if (!Directory.Exists(_Path)) Directory.CreateDirectory(_Path);

            //Fiducial_Json_DataSet(_Path);
        }

        //private void Fiducial_Json_DataSet(string path)
        //{
        //    string FileName = "Fiducial.json";
        //    // 트레인 이미지 저장 필요...폴더에 저장..
        //    string strTrainImagPath = $"{path}\\TrainImage";
        //    if (!Directory.Exists(strTrainImagPath)) Directory.CreateDirectory(strTrainImagPath);

        //    List<Json_Fiducial> json_Fiducials = new List<Json_Fiducial>();

        //    double LT_SearchRegion_X = FIDUCIAL.LT_SerchRoi.X;
        //    double LT_SearchRegion_Y = FIDUCIAL.LT_SerchRoi.Y;
        //    double LT_SearchRegion_W = FIDUCIAL.LT_SerchRoi.Width;
        //    double LT_SearchRegion_H = FIDUCIAL.LT_SerchRoi.Height;

        //    double RB_SearchRegion_X = FIDUCIAL.RB_SerchRoi.X;
        //    double RB_SearchRegion_Y = FIDUCIAL.RB_SerchRoi.Y;
        //    double RB_SearchRegion_W = FIDUCIAL.RB_SerchRoi.Width;
        //    double RB_SearchRegion_H = FIDUCIAL.RB_SerchRoi.Height;

        //    double LT_TrainRegion_X = FIDUCIAL.LT_TrainRoi.X;
        //    double LT_TrainRegion_Y = FIDUCIAL.LT_TrainRoi.Y;
        //    double LT_TrainRegion_W = FIDUCIAL.LT_TrainRoi.Width;
        //    double LT_TrainRegion_H = FIDUCIAL.LT_TrainRoi.Height;

        //    double RB_TrainRegion_X = FIDUCIAL.RB_TrainRoi.X;
        //    double RB_TrainRegion_Y = FIDUCIAL.RB_TrainRoi.Y;
        //    double RB_TrainRegion_W = FIDUCIAL.RB_TrainRoi.Width;
        //    double RB_TrainRegion_H = FIDUCIAL.RB_TrainRoi.Height;

        //    json_Fiducials.Add(new Json_Fiducial()
        //    {
        //        Name = FIDUCIAL.Name,
        //        LTScoreMin = FIDUCIAL.LTScoreMin.ToString(),
        //        LT_SearchRoi_X = LT_SearchRegion_X.ToString(),
        //        LT_SearchRoi_Y = LT_SearchRegion_Y.ToString(),
        //        LT_SearchRoi_H = LT_SearchRegion_H.ToString(),
        //        LT_SearchRoi_W = LT_SearchRegion_W.ToString(),
        //        LT_TrainRoi_X = LT_TrainRegion_X.ToString(),
        //        LT_TrainRoi_Y = LT_TrainRegion_Y.ToString(),
        //        LT_TrainRoi_H = LT_TrainRegion_H.ToString(),
        //        LT_TrainRoi_W = LT_TrainRegion_W.ToString(),
        //        RBScoreMin = RBScoreMin.ToString(),
        //        RB_SearchRoi_X = RB_SearchRegion_X.ToString(),
        //        RB_SearchRoi_Y = RB_SearchRegion_Y.ToString(),
        //        RB_SearchRoi_H = RB_SearchRegion_H.ToString(),
        //        RB_SearchRoi_W = RB_SearchRegion_W.ToString(),
        //        RB_TrainRoi_X = RB_TrainRegion_X.ToString(),
        //        RB_TrainRoi_Y = RB_TrainRegion_Y.ToString(),
        //        RB_TrainRoi_H = RB_TrainRegion_H.ToString(),
        //        RB_TrainRoi_W = RB_TrainRegion_W.ToString(),
        //        ImageAlignMasterAngle = ImageAlignMasterAngle.ToString(),
        //    });

        //    string strFiducialJsonFileName = $"{path}\\{FileName}";
        //    string str_Fiducial = Newtonsoft.Json.JsonConvert.SerializeObject(json_Fiducials, Newtonsoft.Json.Formatting.Indented);
        //    System.IO.File.WriteAllText(strFiducialJsonFileName, str_Fiducial);

        //    // 트레인 이미지 저장..
        //    if (FIDUCIAL.Image_LT_Template != null)
        //    {
        //        using (Mat _mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(FIDUCIAL.Image_LT_Template).Clone())
        //        {
        //            string filepath = $"{strTrainImagPath}\\{FIDUCIAL.Name}_Fiducial_LT.jpg";
        //            bool ret = Cv2.ImWrite(filepath, _mat);
        //            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
        //            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Fiducial Train Image Not Save : Train Image Name => {FIDUCIAL.Name}_Fiducial_LT");
        //        }
        //    }

        //    if (FIDUCIAL.Image_RB_Template != null)
        //    {
        //        using (Mat _mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(FIDUCIAL.Image_RB_Template).Clone())
        //        {
        //            string filepath = $"{strTrainImagPath}\\{FIDUCIAL.Name}_Fiducial_RB.jpg";
        //            bool ret = Cv2.ImWrite(filepath, _mat);
        //            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
        //            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Fiducial Train Image Not Save : Train Image Name => {FIDUCIAL.Name}_Fiducial_RB");
        //        }
        //    }
        //}

        // json 데이터 로드..
        //public void Fiducial_Json_Load()
        //{
        //    string FileName = "Fiducial.json";
        //    string strFolderPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Name}\\Fiducial";

        //    // 정상적으로 폴더 파일이 있을 경우 로드..
        //    if (Directory.Exists(strFolderPath))
        //    {
        //        string filepath = $"{strFolderPath}\\{FileName}";
        //        // 해당 파일 로드..
        //        if (File.Exists(filepath))
        //        {
        //            // Json의 데이터 읽기..
        //            string jsonContent = System.IO.File.ReadAllText(filepath);
        //            List<Json_Fiducial> Fiducialdata = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Json_Fiducial>>(jsonContent);

        //            foreach (var fiducial in Fiducialdata)
        //            {
        //                if (Name == fiducial.Name)
        //                {
        //                    Rectangle _rectangle = new Rectangle();
        //                    _rectangle.X = int.Parse(fiducial.LT_SearchRoi_X);
        //                    _rectangle.Y = int.Parse(fiducial.LT_SearchRoi_Y);
        //                    _rectangle.Height = int.Parse(fiducial.LT_SearchRoi_H);
        //                    _rectangle.Width = int.Parse(fiducial.LT_SearchRoi_W);
        //                    LT_SerchRoi = _rectangle;

        //                    _rectangle.X = int.Parse(fiducial.RB_SearchRoi_X);
        //                    _rectangle.Y = int.Parse(fiducial.RB_SearchRoi_Y);
        //                    _rectangle.Height = int.Parse(fiducial.RB_SearchRoi_H);
        //                    _rectangle.Width = int.Parse(fiducial.RB_SearchRoi_W);
        //                    RB_SerchRoi = _rectangle;

        //                    _rectangle.X = int.Parse(fiducial.LT_TrainRoi_X);
        //                    _rectangle.Y = int.Parse(fiducial.LT_TrainRoi_Y);
        //                    _rectangle.Height = int.Parse(fiducial.LT_TrainRoi_H);
        //                    _rectangle.Width = int.Parse(fiducial.LT_TrainRoi_W);
        //                    LT_TrainRoi = _rectangle;

        //                    _rectangle.X = int.Parse(fiducial.RB_TrainRoi_X);
        //                    _rectangle.Y = int.Parse(fiducial.RB_TrainRoi_Y);
        //                    _rectangle.Height = int.Parse(fiducial.RB_TrainRoi_H);
        //                    _rectangle.Width = int.Parse(fiducial.RB_TrainRoi_W);
        //                    RB_TrainRoi = _rectangle;

        //                    LTScoreMin = double.Parse(fiducial.LTScoreMin);
        //                    RBScoreMin = double.Parse(fiducial.RBScoreMin);
        //                    ImageAlignMasterAngle = double.Parse(fiducial.ImageAlignMasterAngle);
        //                }
        //            }
        //        }

        //        string strTrainImagPath = $"{strFolderPath}\\TrainImage\\{FIDUCIAL.Name}_Fiducial_LT.jpg";

        //        // 해당 파일이 있을경우...읽기..
        //        if (File.Exists(strTrainImagPath))
        //        {
        //            Mat ret = Cv2.ImRead(strTrainImagPath);
        //            Image_LT_Template = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(ret);
        //        }

        //        strTrainImagPath = $"{strFolderPath}\\TrainImage\\{FIDUCIAL.Name}_Fiducial_RB.jpg";

        //        // 해당 파일이 있을경우...읽기..
        //        if (File.Exists(strTrainImagPath))
        //        {
        //            Mat ret = Cv2.ImRead(strTrainImagPath);
        //            Image_RB_Template = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(ret);
        //        }
        //    }
        //}
    }

    //public struct JOB_PART_LEAD
    //{
    //    public int AreaMin;
    //    public int AreaMax;
    //    public int LeadCount;
    //    public System.Drawing.Rectangle[] ROIs;
    //    public bool IsWhite;
    //}

    //public struct GRAB_SEQ
    //{
    //    //public string Name;
    //    //public int Index;
    //    public int LightValue;

    //    public int Exposure;
    //    public int Gain;
    //    public bool USE;
    //    public CogImage24PlanarColor m_imgSource_Color;
    //}
}