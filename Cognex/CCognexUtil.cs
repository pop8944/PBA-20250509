using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using OpenCvSharp;
using System;
using System.Reflection;

namespace IntelligentFactory
{
    public static class CCognexUtil
    {
        public static (bool, CogLine) FindLine(CogFindLineTool tool, CogImage8Grey img, out CogGraphicCollection g, bool isDebug = false)
        {
            g = new CogGraphicCollection();
            CogLine line = null;
            try
            {
                tool.InputImage = new CogImage8Grey(img);
                tool.Run();


                if (tool.Results != null && tool.Results.Count > 0)
                {
                    for (int i = 0; i < tool.Results.Count; i++) g.Add(tool.Results[i].CreateResultGraphics(CogFindLineResultGraphicConstants.All));

                    line = tool.Results.GetLine();

                    if (line != null)
                    {
                        if (isDebug)
                        {
                            g.Add(line);
                            g.Add(DrawText(new Point2d(line.X, line.Y), $"Degree : {IF_Util.rad2deg(line.Rotation)}º"));
                        }

                    }
                    else
                    {
                        if (isDebug) //IF_Util.ShowMessageBox("Error", "Find Line Results Empty");
                            return (false, line);
                    }
                }
                else
                {
                    if (isDebug) //IF_Util.ShowMessageBox("Error", "Find Line Results Empty");
                        return (false, line);
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");

                return (false, line);
            }

            return (false, line);
        }
        public static void LoadCogTool_FindLine(string strPath, Cognex.VisionPro.Implementation.CogToolBase tool)
        {
            try
            {
                if (tool is CogFindLineTool) (tool as CogFindLineTool).RunParams = CogSerializer.LoadObjectFromFile(strPath) as CogFindLine;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        public static void LoadCogTool_FindCircle(string strPath, Cognex.VisionPro.Implementation.CogToolBase tool)
        {
            try
            {
                if (tool is CogFindCircleTool) (tool as CogFindCircleTool).RunParams = CogSerializer.LoadObjectFromFile(strPath) as CogFindCircle;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        public static void LoadCogTool(string strPath, Cognex.VisionPro.Implementation.CogToolBase tool)
        {
            try
            {
                if (tool is CogFindLineTool)
                {
                    (tool as CogFindLineTool).RunParams = CogSerializer.LoadObjectFromFile(strPath) as CogFindLine;
                }

                if (tool is CogFindCircleTool)
                {
                    (tool as CogFindCircleTool).RunParams = CogSerializer.LoadObjectFromFile(strPath) as CogFindCircle;
                }
                if (tool is CogPMAlignTool)
                {
                   tool = CogSerializer.LoadObjectFromFile(strPath) as CogPMAlignTool;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        public static CogPMAlignTool LoadCogTool_PMAlign(string strPath)
        {
            try
            {
                return (CogSerializer.LoadObjectFromFile(strPath) as CogPMAlignTool);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");

                return new CogPMAlignTool();
            }
        }
        public static void SaveCogTool(string strPath, Cognex.VisionPro.Implementation.CogToolBase tool)
        {
            try
            {
                if (tool is CogFindLineTool) CogSerializer.SaveObjectToFile((tool as CogFindLineTool).RunParams, strPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
                if (tool is CogFindCircleTool) CogSerializer.SaveObjectToFile((tool as CogFindCircleTool).RunParams, strPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
                if (tool is CogPMAlignTool) CogSerializer.SaveObjectToFile(tool as CogPMAlignTool, strPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.All);

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        public enum FLIP_ROTATE_TYPE
        { ROT_CW_90, ROT_CCW90, ROT180, FLIP_X_ROT_CW_90, FLIP_X_ROT_CCW_90, FLIP_X_ROT180, FLIP_Y_ROT_CW_90, FLIP_Y_ROT_CCW_90, FLIP_Y_ROT180 }

        public static ICogImage FlipRotateEx(ICogImage imgSource, CogIPOneImageFlipRotateOperationConstants op, bool bColor = false, bool bFlipX = false, bool bFlipY = false)
        {
            using (OpenCvSharp.Mat imgSourceCv = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgSource.ToBitmap()))
            {
                if (bFlipX) OpenCvSharp.Cv2.Flip(imgSourceCv, imgSourceCv, OpenCvSharp.FlipMode.X);
                if (bFlipY) OpenCvSharp.Cv2.Flip(imgSourceCv, imgSourceCv, OpenCvSharp.FlipMode.Y);

                switch (op)
                {
                    case CogIPOneImageFlipRotateOperationConstants.None:
                        break;

                    case CogIPOneImageFlipRotateOperationConstants.Rotate90Deg:
                        OpenCvSharp.Cv2.Rotate(imgSourceCv, imgSourceCv, OpenCvSharp.RotateFlags.Rotate90Clockwise);
                        break;

                    case CogIPOneImageFlipRotateOperationConstants.Rotate180Deg:
                        OpenCvSharp.Cv2.Rotate(imgSourceCv, imgSourceCv, OpenCvSharp.RotateFlags.Rotate180);
                        break;

                    case CogIPOneImageFlipRotateOperationConstants.Rotate270Deg:
                        OpenCvSharp.Cv2.Rotate(imgSourceCv, imgSourceCv, OpenCvSharp.RotateFlags.Rotate90Counterclockwise);
                        break;

                    case CogIPOneImageFlipRotateOperationConstants.FlipAndRotate90Deg:
                        OpenCvSharp.Cv2.Rotate(imgSourceCv, imgSourceCv, OpenCvSharp.RotateFlags.Rotate90Clockwise);
                        break;
                }

                if (bColor) return new CogImage24PlanarColor(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgSourceCv));
                else return new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgSourceCv));
            }
        }

        public static System.Drawing.Rectangle CogRectangleToRectangle(CogRectangle rtIn)
        {
            CogRectangle cogRect = rtIn;
            System.Drawing.Rectangle rt = new System.Drawing.Rectangle();
            rt.X = (int)cogRect.X;
            rt.Y = (int)cogRect.Y;
            rt.Width = (int)cogRect.Width;
            rt.Height = (int)cogRect.Height;

            return rt;
        }

        public static CogRectangle RectangleToCogRectangle(System.Drawing.Rectangle rt)
        {
            CogRectangle cogRect = new CogRectangle();
            cogRect.Width = rt.Width;
            cogRect.Height = rt.Height;
            cogRect.X = rt.X;
            cogRect.Y = rt.Y;

            return cogRect;
        }

        public static void DrawPosMarker(Point2d point, int width, int height, CogDisplay display, CogColorConstants color = CogColorConstants.Green)
        {
            CogLineSegment line_LeftMaster1 = new CogLineSegment();
            line_LeftMaster1.StartX = point.X - width / 2;
            line_LeftMaster1.StartY = point.Y;
            line_LeftMaster1.EndX = point.X + width / 2;
            line_LeftMaster1.EndY = point.Y;

            CogLineSegment line_LeftMaster2 = new CogLineSegment();
            line_LeftMaster2.StartX = point.X;
            line_LeftMaster2.StartY = point.Y - height / 2;
            line_LeftMaster2.EndX = point.X;
            line_LeftMaster2.EndY = point.Y + height / 2;

            line_LeftMaster1.Color = color;
            line_LeftMaster2.Color = color;

            display.InteractiveGraphics.Add(line_LeftMaster1, "MAIN_CROSS", true);
            display.InteractiveGraphics.Add(line_LeftMaster2, "MAIN_CROSS", true);
        }

        public static void DrawString(CogDisplay display, string strText, Point2d pos, CogColorConstants color, int nFontSize = 32)
        {
            CogGraphicLabel lb = new CogGraphicLabel();
            lb.Color = color;
            lb.X = pos.X;
            lb.Y = pos.Y;
            lb.Text = strText;
            lb.Font = new System.Drawing.Font("arial", nFontSize, System.Drawing.FontStyle.Bold);
            lb.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;

            display.InteractiveGraphics.Add(lb, "T", false);
        }

        public static void DrawText(CogDisplay display, OpenCvSharp.Point2d pos, string strText, CogColorConstants color = CogColorConstants.Yellow, int nFontSize = 10)
        {
            CogGraphicLabel lb = new CogGraphicLabel();
            lb.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;
            lb.X = pos.X;
            lb.Y = pos.Y;
            lb.Text = strText;
            lb.Font = new System.Drawing.Font("arial", nFontSize);
            lb.Color = color;

            display?.StaticGraphics.Add(lb, "Text");
        }

        public static CogGraphicLabel DrawText(OpenCvSharp.Point2d pos, string text, CogColorConstants color = CogColorConstants.Yellow, int nFontSize = 10)
        {
            CogGraphicLabel lb = new CogGraphicLabel();
            lb.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;
            lb.X = pos.X;
            lb.Y = pos.Y;
            lb.Text = text;
            lb.Font = new System.Drawing.Font("arial", nFontSize);
            lb.Color = color;

            return lb;
        }

        public static bool Flip(CogImage8Grey imgInput, Cognex.VisionPro.ImageProcessing.CogIPOneImageFlipRotateOperationConstants flipType, out CogImage8Grey imgOutput)
        {
            imgOutput = new CogImage8Grey();

            try
            {
                Cognex.VisionPro.ImageProcessing.CogIPOneImageTool cogIPOneImageTool = new Cognex.VisionPro.ImageProcessing.CogIPOneImageTool();
                Cognex.VisionPro.ImageProcessing.CogIPOneImageFlipRotate cflip = new Cognex.VisionPro.ImageProcessing.CogIPOneImageFlipRotate();

                cflip.OperationInPixelSpace = flipType;
                cogIPOneImageTool.Operators.Add(cflip);
                cogIPOneImageTool.InputImage = imgInput;
                cogIPOneImageTool.Run();

                imgOutput = new CogImage8Grey((CogImage8Grey)cogIPOneImageTool.OutputImage);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }
    }
}