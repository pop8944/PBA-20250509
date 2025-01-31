using OpenCvSharp;
using System;
using System.Drawing;
using System.Reflection;

namespace IntelligentFactory
{
    public static class CVisionCommon
    {
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
                    if (ImageSrc.Channels() == 3) Cv2.CvtColor(ImageSrc, ImageSrc, ColorConversionCodes.BGR2GRAY);
                    if (ImageSrc.Channels() == 4) Cv2.CvtColor(ImageSrc, ImageSrc, ColorConversionCodes.BGR2GRAY);

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

                        case CV_FILTER.White_Top_Hat:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.TopHat, Kernel);
                            break;

                        case CV_FILTER.Black_Top_Hat:
                            Cv2.MorphologyEx(ImageSrc, ImageResult, MorphTypes.BlackHat, Kernel);
                            break;

                        case CV_FILTER.EQUALIZE_HIST:
                            Cv2.EqualizeHist(ImageSrc, ImageResult);
                            break;

                        case CV_FILTER.EQUALIZE_CLAHE:
                            CLAHE clahe = Cv2.CreateCLAHE(nParam1, new OpenCvSharp.Size(nParam2, nParam2));
                            clahe.Apply(ImageSrc, ImageResult);
                            break;

                        case CV_FILTER.Sharpen:
                            float[] kernelData = new float[9]
                            { 0F, -1F, 0F,
                             -1F, 5F, -1F,
                              0F,-1F,  0F };

                            Kernel = new Mat(3, 3, MatType.CV_32F, kernelData);
                            Cv2.Filter2D(ImageSrc, ImageResult, ImageSrc.Type(), Kernel, new OpenCvSharp.Point());
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

                        case CV_FILTER.Sharpen:
                            float[] kernelData = new float[9]
                            { 0F, -1F, 0F,
                             -1F, 5F, -1F,
                              0F,-1F,  0F };

                            Kernel = new Mat(3, 3, MatType.CV_32F, kernelData);
                            Cv2.Filter2D(ImageSrc, ImageResult, ImageSrc.Type(), Kernel, new OpenCvSharp.Point());
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

                imgResult = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(ImageResult);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }

            return imgResult;
        }

        public static System.Drawing.Bitmap FlipRotateEX(System.Drawing.Bitmap imgSrc, System.Drawing.RotateFlipType op)
        {
            try
            {
                if (imgSrc != null || imgSrc.Width != 0) imgSrc.RotateFlip(op);
                return (System.Drawing.Bitmap)imgSrc.Clone();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        //public static System.Drawing.Bitmap Crop(System.Drawing.Bitmap imgSrc, Rectangle roi)
        //{
        //    try
        //    {
        //        if (imgSrc == null || imgSrc.Width == 0) return null;

        //        Rectangle destRect = new Rectangle(System.Drawing.Point.Empty, roi.Size);

        //        var cropImage = new Bitmap(destRect.Width, destRect.Height);
        //        using (var graphics = Graphics.FromImage(cropImage))
        //        {
        //            graphics.DrawImage(imgSrc, destRect, roi, GraphicsUnit.Pixel);
        //        }

        //        return cropImage;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
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
    }
}