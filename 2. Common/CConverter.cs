﻿using Cognex.VisionPro;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace IntelligentFactory
{
    public static class CConverter
    {
        public static Rectangle CogRectToRect(CogRectangle rect_from)
        {
            Rectangle rect = new Rectangle((int)rect_from.X, (int)rect_from.Y, (int)rect_from.Width, (int)rect_from.Height);

            return rect;
        }
        public static Rect CogRectToCVRect(CogRectangle rect_from)
        {
            Rect rect = new Rect((int)rect_from.X, (int)rect_from.Y, (int)rect_from.Width, (int)rect_from.Height);

            return rect;
        }

        public static Bitmap ToBitmap(OpenCvSharp.Mat image)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
        }

        public static Bitmap ByteToBitmap(byte[] imgArr, int nW, int nH)
        {
            Bitmap bmp = new Bitmap(nW, 4000, PixelFormat.Format8bppIndexed);
            // IntPtr ptr = res.GetHbitmap();

            BitmapData data = bmp.LockBits(
                                    new Rectangle(0, 0, nW, nH),
                                    ImageLockMode.ReadWrite,
                                        PixelFormat.Format8bppIndexed);
            IntPtr ptr = data.Scan0;
            Marshal.Copy(imgArr, 0, ptr, nW * nH);
            bmp.UnlockBits(data);

            //모노이미지로 변환해준다 사용하지 않을경우 칼라이미지가 깨진채로 사용된다
            ColorPalette Gpal = bmp.Palette;
            for (int i = 0; i < 256; i++)
            {
                Gpal.Entries[i] = Color.FromArgb(i, i, i);
            }
            bmp.Palette = Gpal;

            return bmp;
        }

        public static CogRectangle RectToCogRect(Rectangle rect_from, CogColorConstants cogColor = CogColorConstants.Green)
        {
            CogRectangle rect = new CogRectangle();
            rect.Color = cogColor;

            rect.SetXYWidthHeight(rect_from.X, rect_from.Y, rect_from.Width, rect_from.Height);

            return rect;
        }

        public static CogRectangle CVRectToCogRect(Rect rect_from, CogColorConstants cogColor = CogColorConstants.Green)
        {
            CogRectangle rect = new CogRectangle();
            rect.Color = cogColor;

            rect.SetXYWidthHeight(rect_from.X, rect_from.Y, rect_from.Width, rect_from.Height);

            return rect;
        }

        public static Rectangle StringToRoi(string strROI)
        {
            Rectangle ROI = new Rectangle();
            string[] strSplit = strROI.Split(',');

            if (strSplit.Length == 4)
            {
                int nX = int.Parse(strSplit[0]);
                int nY = int.Parse(strSplit[1]);
                int nW = int.Parse(strSplit[2]);
                int nH = int.Parse(strSplit[3]);

                ROI = new Rectangle(nX, nY, nW, nH);
            }

            return ROI;
        }

        public static Rectangle StringToROI2(string strROI = "")
        {
            string[] strXYWH = strROI.Split('&');
            int nX = int.Parse(strXYWH[0]);
            int nY = int.Parse(strXYWH[1]);
            int nW = int.Parse(strXYWH[2]);
            int nH = int.Parse(strXYWH[3]);

            return new Rectangle(nX, nY, nW, nH);
        }

        public static string RoiToString(OpenCvSharp.Rect ROI)
        {
            return string.Format("{0},{1},{2},{3}", ROI.X, ROI.Y, ROI.Width, ROI.Height);
        }

        public static string RoiToString(Rectangle ROI)
        {
            return string.Format("{0},{1},{2},{3}", ROI.X, ROI.Y, ROI.Width, ROI.Height);
        }

        public static System.Drawing.Point CVPointToPoint(OpenCvSharp.Point pt)
        {
            return new System.Drawing.Point(pt.X, pt.Y);
        }

        public static OpenCvSharp.Point PointToCVPoint(System.Drawing.Point pt)
        {
            return new OpenCvSharp.Point(pt.X, pt.Y);
        }

        public static string ShortToBinaryString(short shValue)
        {
            string strBinary = Convert.ToString(shValue, 2).PadLeft(8, '0');
            return strBinary;
        }

        public static string IntToBinaryString(int nValue, int nZeroCount)
        {
            string strBinary = Convert.ToString(nValue, 2).PadLeft(nZeroCount, '0');
            return strBinary;
        }

        public static byte IntToByte(int nValue)
        {
            //string hexValue = nValue.ToString("X");
            return Convert.ToByte(nValue.ToString());
        }

        public static string PointToString(System.Drawing.Point pt)
        {
            return string.Format("{0},{1}", pt.X, pt.Y);
        }

        public static string PointFToString(PointF pt)
        {
            return string.Format("{0},{1}", pt.X, pt.Y);
        }

        public static string CVPointToString(OpenCvSharp.Point pt)
        {
            return string.Format("{0},{1}", pt.X, pt.Y);
        }

        public static System.Drawing.Point StringToPoint(string strPoint)
        {
            string[] strPointSplit = strPoint.Split(',');
            System.Drawing.Point pt = new System.Drawing.Point(0, 0);

            if (strPointSplit.Length == 2)
            {
                string strX = strPointSplit[0].Trim();
                string strY = strPointSplit[1].Trim();

                int nX = int.Parse(strX);
                int nY = int.Parse(strY);

                pt = new System.Drawing.Point(nX, nY);
            }

            return pt;
        }

        public static System.Drawing.PointF StringToPointF(string strPoint)
        {
            string[] strPointSplit = strPoint.Split(',');
            System.Drawing.PointF pt = new PointF(0, 0);

            if (strPointSplit.Length == 2)
            {
                string strX = strPointSplit[0].Trim();
                string strY = strPointSplit[1].Trim();

                float fX = float.Parse(strX);
                float fY = float.Parse(strY);

                pt = new PointF(fX, fY);
            }

            return pt;
        }

        public static OpenCvSharp.Point StringToCVPoint(string strPoint)
        {
            string[] strPointSplit = strPoint.Split(',');
            OpenCvSharp.Point pt = new OpenCvSharp.Point(0, 0);

            if (strPointSplit.Length == 2)
            {
                string strX = strPointSplit[0].Trim();
                string strY = strPointSplit[1].Trim();

                int nX = int.Parse(strX);
                int nY = int.Parse(strY);

                pt = new OpenCvSharp.Point(nX, nY);
            }

            return pt;
        }

        public static string RectToString(Rectangle rt)
        {
            return $"{rt.X},{rt.Y},{rt.Width},{rt.Height}";
        }

        public static Rectangle StringToRect(string strRect)
        {
            string[] sRT = strRect.Split(',');
            if (sRT.Length == 4)
            {
                int nX = int.Parse(sRT[0]);
                int nY = int.Parse(sRT[1]);
                int nW = int.Parse(sRT[2]);
                int nH = int.Parse(sRT[3]);

                return new Rectangle(nX, nY, nW, nH);
            }

            return new Rectangle();
        }

        public static OpenCvSharp.Rect StringToCVRect(string strRect)
        {
            string[] sRT = strRect.Split(',');
            if (sRT.Length == 4)
            {
                int nX = int.Parse(sRT[0]);
                int nY = int.Parse(sRT[1]);
                int nW = int.Parse(sRT[2]);
                int nH = int.Parse(sRT[3]);

                return new OpenCvSharp.Rect(nX, nY, nW, nH);
            }

            return new OpenCvSharp.Rect();
        }

        public static OpenCvSharp.Rect RectToCVRect(System.Drawing.Rectangle rt)
        {
            OpenCvSharp.Rect CvRt = new OpenCvSharp.Rect(rt.X, rt.Y, rt.Width, rt.Height);
            return CvRt;
        }

        public static System.Drawing.Rectangle CVRectToRect(OpenCvSharp.Rect rt)
        {
            System.Drawing.Rectangle dRt = new System.Drawing.Rectangle(rt.X, rt.Y, rt.Width, rt.Height);
            return dRt;
        }

        public static System.Drawing.Rectangle ScreenRectToLogicalRect(System.Drawing.Rectangle rt, float fScaleFactorX, float fScaleFactorY)
        {
            rt.X = (int)(rt.X / fScaleFactorX);
            rt.Y = (int)(rt.Y / fScaleFactorY);
            rt.Width = (int)(rt.Width / fScaleFactorX);
            rt.Height = (int)(rt.Height / fScaleFactorY);

            return rt;
        }

        public static System.Drawing.Rectangle LogicalRectToScreenRect(System.Drawing.Rectangle rt, float fScaleFactorX, float fScaleFactorY)
        {
            System.Drawing.Rectangle rtScreen = new System.Drawing.Rectangle();
            rtScreen.X = (int)(rt.X * fScaleFactorX);
            rtScreen.Y = (int)(rt.Y * fScaleFactorY);
            rtScreen.Width = (int)(rt.Width * fScaleFactorX);
            rtScreen.Height = (int)(rt.Height * fScaleFactorY);

            return rtScreen;
        }

        public static OpenCvSharp.Rect ScreenCVRectToLogicalCVRect(OpenCvSharp.Rect rt, float fScaleFactorX, float fScaleFactorY)
        {
            rt.X = (int)(rt.X * fScaleFactorX);
            rt.Y = (int)(rt.Y * fScaleFactorY);
            rt.Width = (int)(rt.Width * fScaleFactorX);
            rt.Height = (int)(rt.Height * fScaleFactorY);

            return rt;
        }

        public static OpenCvSharp.Point ScreenCVPointToLogicalCVPoint(OpenCvSharp.Point pt, float fScaleFactorX, float fScaleFactorY)
        {
            OpenCvSharp.Point ptScreen = new OpenCvSharp.Point();

            ptScreen.X = (int)(pt.X * fScaleFactorX);
            ptScreen.Y = (int)(pt.Y * fScaleFactorY);

            return ptScreen;
        }

        public static System.Drawing.Point ScreenPointToLogicalPoint(System.Drawing.Point pt, float fScaleFactorX, float fScaleFactorY)
        {
            System.Drawing.Point ptScreen = new System.Drawing.Point();

            ptScreen.X = (int)(pt.X * fScaleFactorX);
            ptScreen.Y = (int)(pt.Y * fScaleFactorY);

            return ptScreen;
        }
    }
}