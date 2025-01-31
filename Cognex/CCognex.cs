using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace IntelligentFactory
{
    public enum ENROI
    { ROI1, ROI2, ROI3, ROI4, MAX }

    public enum ENDIRECTION
    { X, Y }

    public static class CogUtil
    {
        // RGB COLOR
        public enum RGB_COLOR { R, G, B, O }

        public static CogImage8Grey LoadImage(string strPath)
        {
            CogImageFile ImageFile1 = new CogImageFile();

            ImageFile1.Open(strPath, CogImageFileModeConstants.Read);

            if (ImageFile1.Count > 0)
            {
                ICogImage image = ImageFile1[0];
                CogImageConvertTool cogImageConverter = new CogImageConvertTool();
                cogImageConverter.InputImage = image;
                cogImageConverter.Run();
                CogImage8Grey _monoimg = (CogImage8Grey)cogImageConverter.OutputImage;

                return _monoimg;
            }

            return null;
        }

        public static CogImage8Grey ColorToMono(CogImage24PlanarColor imgColor)
        {
            return CogImageConvert.GetIntensityImage(imgColor, 0, 0, imgColor.Width, imgColor.Height);
        }

        //public static CogImage8Grey GetGrayImage_Size_Convert(ICogImage img, int width, int height)
        //{
        //    return CogImageConvert.GetIntensityImage(img, 0, 0, width, height);
        //}

        //public static ICogImage GetColorImage_Size_Convert(ICogImage img, int width, int height)
        //{
        //    return CogImageConvert.GetRGBImage(img, 0, 0, width, height);
        //}

        public static CogImage24PlanarColor LoadImage_Color(string strPath)
        {
            CogImageFile ImageFile1 = new CogImageFile();
            CogImage24PlanarColor _ColorImg = new CogImage24PlanarColor();

            ImageFile1.Open(strPath, CogImageFileModeConstants.Read);
            try
            {
                if (ImageFile1.Count > 0)
                {
                    _ColorImg = (CogImage24PlanarColor)ImageFile1[0];
                    //CogImageConvertTool cogImageConverter = new CogImageConvertTool();
                    //cogImageConverter.InputImage = image;
                    //cogImageConverter.Run();
                    //_ColorImg = (CogImage24PlanarColor)cogImageConverter.OutputImage;

                    return _ColorImg;
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public static bool SaveImage(CogImage8Grey imgInput, string strPath)
        {
            if (!imgInput.Allocated) return false;

            CogImageFile lcogImage = new CogImageFile();
            lcogImage.Open(strPath, CogImageFileModeConstants.Write);
            lcogImage.Append(imgInput);
            lcogImage.Close();
            ((IDisposable)lcogImage).Dispose();

            return true;
        }

        public static bool SaveImage(CogImage24PlanarColor imgInput, string strPath)
        {
            if (!imgInput.Allocated) return false;

            CogImageFile lcogImage = new CogImageFile();
            lcogImage.Open(strPath, CogImageFileModeConstants.Write);
            lcogImage.Append(imgInput);
            lcogImage.Close();
            ((IDisposable)lcogImage).Dispose();

            return true;
        }

        public static bool RGB_SaveImage(CogImage24PlanarColor imgInput, RGB_COLOR rgbcolor, string _path)
        {
            if (imgInput == null) return false;
            if (!imgInput.Allocated) return false;

            // Color 이미지는 색깔별로 한색깔만 처리될수 있도록함
            CogImage8Grey nImg;
            CogImage24PlanarColor nimgcolor;
            CogImageConvertTool cogImageConvertTool = new CogImageConvertTool();
            cogImageConvertTool.InputImage = imgInput;

            if (rgbcolor == RGB_COLOR.R)
            {
                cogImageConvertTool.RunParams.RunMode = CogImageConvertRunModeConstants.Plane0;
                cogImageConvertTool.Run();

                nImg = (CogImage8Grey)cogImageConvertTool.OutputImage;
                SaveImage(nImg, _path);
            }
            else if (rgbcolor == RGB_COLOR.G)
            {
                cogImageConvertTool.RunParams.RunMode = CogImageConvertRunModeConstants.Plane1;
                cogImageConvertTool.Run();

                nImg = (CogImage8Grey)cogImageConvertTool.OutputImage;
                SaveImage(nImg, _path);
            }
            else if (rgbcolor == RGB_COLOR.B)
            {
                cogImageConvertTool.RunParams.RunMode = CogImageConvertRunModeConstants.Plane2;
                cogImageConvertTool.Run();

                nImg = (CogImage8Grey)cogImageConvertTool.OutputImage;
                SaveImage(nImg, _path);
            }
            else
            {
                cogImageConvertTool.RunParams.RunMode = CogImageConvertRunModeConstants.RGB;
                cogImageConvertTool.Run();

                nimgcolor = (CogImage24PlanarColor)cogImageConvertTool.OutputImage;
                SaveImage(nimgcolor, _path);
            }

            return true;
        }
    }

    public static class Common
    {
        /* 각도 변환
         */

        public static double rad2deg(double rad)
        {
            double deg = 0.0;
            deg = rad * (180 / Math.PI);
            return deg;
        }

        public static double deg2rad(double deg)
        {
            double rad = 0.0;
            rad = deg * (Math.PI / 180);
            return rad;
        }

        /* 점에서 좌표축방향으로 선까지의 "길이"와 "좌표값"
         * point : 점의 좌표값
         * StartP : 선의 시작 좌표값
         * EndP : 선의 끝 좌표값
         * enDirection : 좌표축방향
         * ptRet :  좌표
         * return : 길이
         */

        public static float GetDirectionPointToLine(PointF point, PointF StartP, PointF EndP, ENDIRECTION enDirection, ref PointF ptRet)
        {
            float fSlope = 0.0f, fIntercept = 0.0f;
            float fLength = 0.0f;
            try
            {
                // 기울기, Y 절편 계산 - Y=fSlope*X+fIntercept
                fSlope = (EndP.Y - StartP.Y) / (EndP.X - StartP.X);
                fIntercept = StartP.Y - (fSlope * StartP.X);

                switch (enDirection)
                {
                    case ENDIRECTION.X:
                        {//
                            ptRet.X = ((point.Y - fIntercept) / fSlope);
                            ptRet.Y = point.Y;
                            fLength = Math.Abs(point.X - ptRet.X);
                        }
                        break;

                    case ENDIRECTION.Y:
                        {//
                            ptRet.X = point.X;
                            ptRet.Y = ((fSlope * point.X) + fIntercept);
                            fLength = Math.Abs(point.Y - ptRet.Y);
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return fLength;
        }

        /* 수선의 "길이"와 "발의 좌표"
         * point : 점의 좌표값
         * StartP : 선의 시작 좌표값
         * EndP : 선의 끝 좌표값
         * ptRet : 수선의 발 좌표
         * return : 수선의 길이
         */

        public static float GetGetPerpendicularPointToLine(PointF point, PointF StartP, PointF EndP, ref PointF ptRet)
        {
            float fSlope = 0.0f, fIntercept = 0.0f;
            float fSlopeSu = 0.0f, fInterceptSu = 0.0f; // 수선의 기울기와 Y절편
            float fPerpendicular = 0.0f; // 수선의 길이

            try
            {
                // 시작점과 끝점을 이은 방정식
                // 기울기, Y 절편 계산 : Y=fSlope*X+fIntercept
                fSlope = (EndP.Y - StartP.Y) / (EndP.X - StartP.X);
                fIntercept = StartP.Y - (fSlope * StartP.X);

                // 수선의 방정식
                fSlopeSu = -(1 / fSlope);
                fInterceptSu = point.Y - (fSlopeSu * point.X);

                // 두 선의 교점(수선의 발)
                ptRet.X = (fInterceptSu - fIntercept) / (fSlope - fSlopeSu);
                ptRet.Y = ((fSlope * fInterceptSu) - (fSlopeSu * fIntercept)) / (fSlope - fSlopeSu);

                // 점에서 수선의 발까지의 길이
                fPerpendicular = (float)Math.Sqrt(Math.Pow((point.X - ptRet.X), 2.0) + Math.Pow((point.Y - ptRet.Y), 2.0));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return fPerpendicular;
        }

        public static ICogImage Convert8BitRawImageToCognexImage(IntPtr pImageData, int nWidth, int nHeight)
        {
            try
            {
                CogImage8Root cogImage8Root = new CogImage8Root();
                cogImage8Root.Initialize(nWidth, nHeight, pImageData, nWidth, null);

                CogImage8Grey CogImage8Grey = new CogImage8Grey();
                CogImage8Grey.SetRoot(cogImage8Root);

                return CogImage8Grey.ScaleImage(nWidth, nHeight);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return null;
        }

        public static ICogImage Convert8BitRawImageToCognexImage(byte[] buff, int nWidth, int nHeight)
        {
            int nRawSize = nWidth * nHeight;
            SafeMalloc buf = new SafeMalloc(nRawSize);

            Marshal.Copy(buff, 0, buf, nRawSize);

            CogImage8Root cogRoot = new CogImage8Root();

            cogRoot.Initialize(nWidth, nHeight, buf, nWidth, buf);

            CogImage8Grey cogImage = new CogImage8Grey();
            cogImage.SetRoot(cogRoot);

            return cogImage;
        }

        public static void SaveImageFileToJPEG(ICogImage cogImage, string sFilePath)
        {
            if (cogImage != null)
            {
                CogImageFileJPEG cogImageFileJPEG = new CogImageFileJPEG();
                cogImageFileJPEG.Open(sFilePath, CogImageFileModeConstants.Write);
                cogImageFileJPEG.Append(cogImage);
                cogImageFileJPEG.Close();
            }
        }

        public static void SaveImageFileToBMP(ICogImage cogImage, string sFilePath)
        {
            if (cogImage != null)
            {
                CogImageFileBMP cogImageFileBMP = new CogImageFileBMP();
                cogImageFileBMP.Open(sFilePath, CogImageFileModeConstants.Write);
                cogImageFileBMP.Append(cogImage);
                cogImageFileBMP.Close();
            }
        }

        public static void SaveImageFileToPNG(ICogImage cogImage, string sFilePath)
        {
            try
            {
                if (cogImage != null)
                {
                    //CogImageFileTool CogImageF = new CogImageFileTool();
                    //CogImageF.InputImage = cogImage;
                    //CogImageF.Operator.Open(sFilePath, CogImageFileModeConstants.Write);
                    //CogImageF.Run();
                    CogImageFilePNG cogImageFilePNG = new CogImageFilePNG();
                    cogImageFilePNG.Open(sFilePath, CogImageFileModeConstants.Write);
                    cogImageFilePNG.Append(cogImage);
                    cogImageFilePNG.Close();
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static IntPtr BitmapToPtr(System.Drawing.Bitmap bmp)
        {
            System.Drawing.Imaging.BitmapData bmpdata = null;

            try
            {
                bmpdata = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
                int numbytes = bmpdata.Stride * bmp.Height;
                byte[] bytedata = new byte[numbytes];
                return bmpdata.Scan0;
            }
            finally
            {
                if (bmpdata != null)
                    bmp.UnlockBits(bmpdata);
            }
        }
    }

    internal class SafeMalloc : SafeBuffer
    {
        /// <summary>
        /// Allocates memory and initialises the SaveBuffer
        /// </summary>
        /// <param name="size">The number of bytes to allocate</param>
        public SafeMalloc(int size) : base(true)
        {
            this.SetHandle(Marshal.AllocHGlobal(size));
            this.Initialize((ulong)size);
        }

        /// <summary>
        /// Called when the object is disposed, ferr the
        /// memory via FreeHGlobal().
        /// </summary>
        /// <returns></returns>
        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(this.handle);
            return true;
        }

        /// <summary>
        /// Cast to IntPtr
        /// </summary>
        public static implicit operator IntPtr(SafeMalloc h)
        {
            return h.handle;
        }
    }
}