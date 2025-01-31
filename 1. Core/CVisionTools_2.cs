using IntelligentFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Concurrent;
using System.Drawing;
using System.Diagnostics;

using MetroFramework.Controls;

using OpenCvSharp;
using System.ComponentModel;

using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.ColorMatch;
using Cognex.VisionPro.ID;
using Cognex.VisionPro.OCRMax;
using Cognex.VisionPro.OCVMax;
using OpenCvSharp.Blob;
using static PACNET.Sys;
using Vila.Extensions;
using stdole;
using Cognex.VisionPro.QuickBuild;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using static System.Windows.Forms.AxHost;
using System.Windows.Media;
using System.Data.SqlClient;
using PACNET;
using OpenCvSharp.Extensions;
using static IntelligentFactory.CVisionTools;
using Vila.Win32;
using Microsoft.Extensions.Options;
using static IntelligentFactory.FormMenu_Vision;
using IntelligentFactory._0._UI._2__POPUP;
using AlgorithmLib;
using SequenceHistoryLib;

namespace IntelligentFactory
{
    public static class CVisionTools
    {
        public static CCogTool_PMAlign PMALIGN_ARRAY1 = new CCogTool_PMAlign("PMALIGN_ARRAY1");
        public static CCogTool_PMAlign PMALIGN_ARRAY2 = new CCogTool_PMAlign("PMALIGN_ARRAY2");
        public static CCogTool_PMAlign PMALIGN_ARRAY3 = new CCogTool_PMAlign("PMALIGN_ARRAY3");
        public static CCogTool_PMAlign PMALIGN_ARRAY4 = new CCogTool_PMAlign("PMALIGN_ARRAY4");

        public static CCogTool_ID ID_ARRAY = new CCogTool_ID("ID_ARRAY");
        //카메라1
        public static List<JOB_TEMP> Jobs = new List<JOB_TEMP>(); //패턴
        public static List<JOB_BLOB> Blobs = new List<JOB_BLOB>();
        public static List<JOB_COLORMATCH> ColorMatch = new List<JOB_COLORMATCH>(); // 컬러 매칭툴
        public static List<JOB_OCR> OCR = new List<JOB_OCR>();
        public static List<JOB_MUTIPMALIGN> MultiPMAlign = new List<JOB_MUTIPMALIGN>();


        //카메라2
        public static List<JOB_TEMP> Jobs2 = new List<JOB_TEMP>(); //패턴
        public static List<JOB_BLOB> Blobs2 = new List<JOB_BLOB>();
        public static List<JOB_COLORMATCH> ColorMatch2 = new List<JOB_COLORMATCH>();
        public static List<JOB_OCR> OCR2 = new List<JOB_OCR>();
        public static List<JOB_MUTIPMALIGN> MultiPMAlign2 = new List<JOB_MUTIPMALIGN>();

        public static List<JOB_TEMP> tmpJobs = new List<JOB_TEMP>();
        public static List<JOB_BLOB> tmpblob = new List<JOB_BLOB>();
        public static List<JOB_COLORMATCH> tmpColorMatch = new List<JOB_COLORMATCH>();
        public static List<JOB_OCR> tmpOCR = new List<JOB_OCR>();
        public static List<JOB_MUTIPMALIGN> tmpMultiPMAlign = new List<JOB_MUTIPMALIGN>();

        public static List<ICogRegion> NGJobsRegion = new List<ICogRegion>();
        public static List<int> NGJobsIndex = new List<int>();
        public static List<string> NGJobsName = new List<string>();

        public static List<ICogRegion> NGMultiPMAlignRegion = new List<ICogRegion>();
        public static List<int> NGMultiPMAlignIndex = new List<int>();
        public static List<string> NGMultiPMAlignName = new List<string>();

        public static List<ICogRegion> NGBlobRegion = new List<ICogRegion>();
        public static List<int> NGBlobIndex = new List<int>();
        public static List<string> NGBlobName = new List<string>();

        public static List<ICogRegion> NGColorMatchRegion = new List<ICogRegion>();
        public static List<int> NGColorMatchIndex = new List<int>();
        public static List<string> NGColorMatchName = new List<string>();

        public static List<ICogRegion> NGOCRRegion = new List<ICogRegion>();
        public static List<int> NGOCRIndex = new List<int>();
        public static List<string> NGOCRName = new List<string>();

        //public static List<GRAB_SEQ> Grab_seq = new List<GRAB_SEQ>();
        //public static List<GRAB_SEQ> Grab_seq2 = new List<GRAB_SEQ>();
        //public static List<GRAB_SEQ> tmp_seq = new List<GRAB_SEQ>();

        public static List<JOB_SEQ> Grab_seq = new List<JOB_SEQ>();
        public static List<JOB_SEQ> Grab_seq2 = new List<JOB_SEQ>();
        public static List<JOB_SEQ> tmp_seq = new List<JOB_SEQ>();

        public static bool JOB_SEQ_USE_CAM1 = false;
        public static bool JOB_SEQ_USE_CAM2 = false;


        public static CCogTool_ID ID_CAM2 = new CCogTool_ID("ID_CAM2");

        public static CCogTool_Equalize Equalize = new CCogTool_Equalize("Equqlize");
        public static CCogTool_Quantize Quantize = new CCogTool_Quantize("Quantize");

        public static CCogTool_CopyRegion CopyRegion = new CCogTool_CopyRegion("CopyRegion");

        public static CCogTool_ColorMatch ColorMatch_CAM1 = new CCogTool_ColorMatch("COLORMATCH_CAM1");
        public static CCogTool_ColorMatch ColorMatch_CAM2 = new CCogTool_ColorMatch("COLORMATCH_CAM2");

        public static CCogTool_OCR OCR_CAM1 = new CCogTool_OCR("OCR_CAM1");
        public static CCogTool_OCR OCR_CAM2 = new CCogTool_OCR("OCR_CAM2");

        public static Cognex.VisionPro.Display.CogDisplay cogDisplay_Source = new Cognex.VisionPro.Display.CogDisplay();


        public static bool Init()
        {
            try
            {
                PMALIGN_ARRAY1.LoadConfig(IGlobal.Instance.System.Recipe.Name);
                PMALIGN_ARRAY2.LoadConfig(IGlobal.Instance.System.Recipe.Name);
                PMALIGN_ARRAY3.LoadConfig(IGlobal.Instance.System.Recipe.Name);
                PMALIGN_ARRAY4.LoadConfig(IGlobal.Instance.System.Recipe.Name);

                ID_ARRAY.LoadConfig(IGlobal.Instance.System.Recipe.Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

            try
            {
                //for (int i = 0; i < IGlobal.Instance.Device.CAMERA_COUNT; i++)
                //{
                //    LoadGrabSEQ(i + 1);
                //    LoadFixture(i + 1);
                //    //LoadJobs(i+1);
                //    LoadBlobs(i+1);
                //    LoadBlobs_USE(i + 1);
                //    LoadColorMatch(i + 1);
                //    LoadColorMatch_USE(i + 1);
                //    LoadOCR(i + 1);
                //    LoadOCR_USE(i + 1);
                //    LoadMULTIPMALIGN(i + 1);
                //    LoadMULTIPMALIGN_USE(i + 1);
                //}


                //PMALIGN_CAM1.LoadConfig(IGlobal.Instance.System.Recipe.Name);
                //PMALIGN_CAM2.LoadConfig(IGlobal.Instance.System.Recipe.Name);

                //ID_CAM1.LoadConfig(IGlobal.Instance.System.Recipe.Name);
                //ID_CAM2.LoadConfig(IGlobal.Instance.System.Recipe.Name);
                //Load_ModelCode(IGlobal.Instance.System.Recipe.Name);
                ////Load_ModelCode(IGlobal.Instance.System.Recipe.Name, IGlobal.Instance.System.Recipe.ModelCode);
                //CVisionTools.Load_ModelCode(IGlobal.Instance.System.Recipe.Name, IGlobal.Instance.System.Recipe.SubName, IGlobal.Instance.System.Recipe.ModelCode);

                //FIXTURE_CAM1.LoadConfig(IGlobal.Instance.System.Recipe.Name);
                //FIXTURE_CAM2.LoadConfig(IGlobal.Instance.System.Recipe.Name);

                //Equalize.LoadConfig(IGlobal.Instance.System.Recipe.Name);
                //Quantize.LoadConfig(IGlobal.Instance.System.Recipe.Name);

                //IGlobal.Instance.FileManager.IMAGESAVETYPE_LOAD();


            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        public static bool Save()
        {
            try
            {
                PMALIGN_ARRAY1.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                PMALIGN_ARRAY2.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                PMALIGN_ARRAY3.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                PMALIGN_ARRAY4.SaveConfig(IGlobal.Instance.System.Recipe.Name);

                ID_ARRAY.SaveConfig(IGlobal.Instance.System.Recipe.Name);

                //SaveJobs(); //패턴
                //SaveBlobs(); //블랍

                //PMALIGN_CAM1.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                //PMALIGN_CAM2.SaveConfig(IGlobal.Instance.System.Recipe.Name);

                //FIXTURE_CAM1.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                //FIXTURE_CAM2.SaveConfig(IGlobal.Instance.System.Recipe.Name);

                //ID_CAM1.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                //ID_CAM2.SaveConfig(IGlobal.Instance.System.Recipe.Name);

                //Save_ModelCode(IGlobal.Instance.System.Recipe.Name);

                //Equalize.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                //Quantize.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                //Equalize.SaveConfigXML(IGlobal.Instance.System.Recipe.Name);
                //Quantize.SaveConfigXML(IGlobal.Instance.System.Recipe.Name);



            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        public static bool Save(int camindex)
        {
            try
            {
                SaveGrabSEQ(camindex);


            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            return true;
        }

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
            Rectangle rctDraw = new Rectangle(ptIn.X, ptIn.Y, (int)szStr.Width, (int)szStr.Height);
            Rectangle rctInterSect = rctDraw;
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
            ptRet.X = ptRet.X  - (int)szStr.Width / 2;
            if (ptRet.X < 0)
                ptRet.X = 0;
            if (ptRet.X + szStr.Width > Width)
                ptRet.X = Width - (int)szStr.Width;
            g.DrawString(str, font, brush, ptRet);
        }

        public static Rectangle GetSearchRect(int nSearchPos, CJob job)
        {
            Rectangle retRect = new Rectangle();
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

        public static Rectangle GetPatternRect(int nSearchPos, CJob job)
        {
            Rectangle retRect = new Rectangle();

            if (job.Type.Contains("Pattern"))
            {
                if (nSearchPos == 0)
                {
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
        public static Rectangle GetPatternRect(int nSearchPos, CJob job, CogPMAlignResult Result)
        {
            Rectangle retRect = new Rectangle();
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

        public static void DrawResultImage(bool bResult_Job, CJob job, ref Bitmap inImg)
        {
            IGlobal Global = IGlobal.Instance;

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

            Rectangle searchRect = GetSearchRect(job.nPatternIndex, job);
            Rectangle patternRect = GetPatternRect(job.nPatternIndex, job);

            System.Drawing.Point ptJudge = new System.Drawing.Point(job.SearchRegion.Location.X, job.SearchRegion.Location.Y);
            System.Drawing.Point ptRate = new System.Drawing.Point(job.SearchRegion.Location.X, job.SearchRegion.Location.Y + 30);
            if (bResult_Job)
            {
                double dAlarm = job.MinScore + (1.0 - job.MinScore) / (100 / Global.Mode.alarmRatio);
                if (Global.Mode.ResultVisible && job.dRate < dAlarm)
                {
                    DrawStingAdjust(GetJudgeStr(bResult_Job, job), font, brush_ALARM, ptJudge, g, inImg.Width);
                    DrawStingAdjust(GetRateStr(bResult_Job, job, job.dRate), font, brush_ALARM, ptRate, g, inImg.Width);

                    g.DrawRectangle(penSearchRegion, searchRect);
                    g.DrawRectangle(penPatternRegion_ALARM, patternRect);

                }
                else
                {
                    DrawStingAdjust(GetJudgeStr(bResult_Job, job), font, brush_OK, ptJudge, g, inImg.Width);

                    g.DrawRectangle(penSearchRegion, searchRect);
                    g.DrawRectangle(penPatternRegion_OK, patternRect);

                }
            }
            else
            {
                DrawStingAdjust(GetJudgeStr(bResult_Job, job), font_NG, brush_NG, ptJudge, g, inImg.Width);

                if (Global.Mode.ResultVisible)
                    DrawStingAdjust(GetRateStr(bResult_Job, job, job.dRate), font_NG, brush_NG, ptRate, g, inImg.Width);

                g.DrawRectangle(penPatternRegion_NG, searchRect);
                g.DrawRectangle(penPatternRegion_NG, patternRect);

            }
        }

        public static void DrawResultImageAdjust(bool bResult_Job, List<CJob> jobs, int nJobIndex, ref Bitmap inImg)
        {
            IGlobal Global = IGlobal.Instance;

            Graphics g = Graphics.FromImage(inImg);

            // Overlay Draw
            System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5);
            System.Drawing.Pen penPatternRegion_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5);
            System.Drawing.Pen penPatternRegion_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 64, 32), 5);
            SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16));
            SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32));
            SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(128, 168, 224, 168));
            System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 168, 224, 168), 5);
            System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Regular);
            System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 24, FontStyle.Regular);

            Rectangle searchRect = GetSearchRect(jobs[nJobIndex].nPatternIndex, jobs[nJobIndex]);
            Rectangle patternRect = GetPatternRect(jobs[nJobIndex].nPatternIndex, jobs[nJobIndex]);

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
                    ptRate = DrawStingAdjustCheckJobs(GetJudgeStr(bResult_Job, jobs[nJobIndex]), font, brush_ALARM, ptJudge, g, inImg.Width, jobs, nJobIndex);
                    ptRate.Y += 25;
                    DrawStingAdjust(GetOptionStr(bResult_Job, jobs[nJobIndex]), font, brush_ALARM, ptRate, g, inImg.Width);
                    ptRate.Y += 25;
                    DrawStingAdjust(GetRateStr(bResult_Job, jobs[nJobIndex], jobs[nJobIndex].dRate), font, brush_ALARM, ptRate, g, inImg.Width);

                    g.DrawRectangle(penSearchRegion, searchRect);
                    g.DrawRectangle(penPatternRegion_ALARM, patternRect);

                }
                else
                {
                    ptRate = DrawStingAdjustCheckJobs(GetJudgeStr(bResult_Job, jobs[nJobIndex]), font, brush_OK, ptJudge, g, inImg.Width, jobs, nJobIndex);
                    ptRate.Y += 25;
                    DrawStingAdjust(GetOptionStr(bResult_Job, jobs[nJobIndex]), font, brush_OK, ptRate, g, inImg.Width);

                    g.DrawRectangle(penSearchRegion, searchRect);
                    g.DrawRectangle(penPatternRegion_OK, patternRect);

                }
            }
            else
            {
                ptRate = DrawStingAdjustCheckJobs(GetJudgeStr(bResult_Job, jobs[nJobIndex]), font_NG, brush_NG, ptJudge, g, inImg.Width, jobs, nJobIndex);

                if (Global.Mode.ResultVisible)
                {
                    ptRate.Y += 25;
                    DrawStingAdjust(GetOptionStr(bResult_Job, jobs[nJobIndex]), font_NG, brush_NG, ptRate, g, inImg.Width);
                    ptRate.Y += 25;
                    DrawStingAdjust(GetRateStr(bResult_Job, jobs[nJobIndex], jobs[nJobIndex].dRate), font_NG, brush_NG, ptRate, g, inImg.Width);
                }

                g.DrawRectangle(penPatternRegion_NG, searchRect);
                g.DrawRectangle(penPatternRegion_NG, patternRect);

            }
        }

        public static int nQRError = 0;

         public static List<bool> Run(FormProgressBar bar, CogImage24PlanarColor[] images, CogDisplay display, out Bitmap[] imgResults_array, bool isInspectProdess = false, bool bCalcCenter = false, FlowLayoutPanel fpn = null)
        {
            int nCurprs = 0;
            if (bar != null)
                nCurprs = bar.GetCurPos();
            List<bool> Results = new List<bool>();
            imgResults_array = new Bitmap[4];
            if (images.Length == 0)
            {
                CUtil.ShowMessageBox("EXCEPTION", "Image Buffer Empty. Please Grab or Load !!!");
                return Results;
            }

            for (int i = 0; i < images.Length; i++)
            {
                if (images[i] == null)
                {
                    CUtil.ShowMessageBox("EXCEPTION", $"Image Buffer[{i}] Empty. lease Grab or Load !!!");
                    return Results;
                }
            }

            OpenCvSharp.Size imgSize = new OpenCvSharp.Size();
            imgSize.Width = images[0].Width;
            imgSize.Height = images[0].Height;

            IGlobal Global = IGlobal.Instance;

            QRParser cQrCode = new QRParser();
            string strJob = "";

            if (display != null)
            {
                display.StaticGraphics.Clear();
                display.InteractiveGraphics.Clear();
            }

            //if (File.Exists($"{Application.StartupPath}\\RECIPE\\{Global.System.Recipe.Name}\\MasterBoard.jpg") == false)
            //{
            //    CUtil.ShowMessageBox("ALARM", "have to save master image(cutted)");
            //    return Results;
            //}

            try
            {
                int nArrayCount = Global.System.Recipe.JobManager.ArrayCount;
                CCogTool_PMAlign[] PMALIGN_ARRAY = new CCogTool_PMAlign[4] { CVisionTools.PMALIGN_ARRAY1, CVisionTools.PMALIGN_ARRAY2, CVisionTools.PMALIGN_ARRAY3, CVisionTools.PMALIGN_ARRAY4 };

                //최대 4연배 바코드 초기화
                for (int i = 0; i < 4; i++) Global.Data.Board_QrCode[i] = new QRParser();

                // 파일이름에 대한 관리 Class
                SaveInform cSaveInfor = new SaveInform();

                // Dark : 어두운 환경 그랩
                // Light : 밝은 환경 그랩
                using (CogImage8Grey imgOriginal_FullBoard = CogImageConvert.GetIntensityImage(images[0], 0, 0, images[0].Width, images[0].Height))
                {
                    List<Mat> mats = new List<Mat>();
                    Mat inMat= new Mat();
                    for (int nArrayIndex = 0; nArrayIndex < nArrayCount; nArrayIndex++)
                    {
                        bool bResult_Total = true;

                        #region 연배 별 이미지 크롭
                        PMALIGN_ARRAY[nArrayIndex].Tool.InputImage = imgOriginal_FullBoard;
                        PMALIGN_ARRAY[nArrayIndex].Tool.Run();

                        CogPMAlignResult result = null;

                        if (PMALIGN_ARRAY[nArrayIndex].Tool.Results != null)
                        {
                            double dAlignMax = 0.0D;
                            for (int j = 0; j < PMALIGN_ARRAY[nArrayIndex].Tool.Results.Count; j++)
                            {
                                if (dAlignMax < PMALIGN_ARRAY[nArrayIndex].Tool.Results[j].Score)
                                {
                                    dAlignMax = PMALIGN_ARRAY[nArrayIndex].Tool.Results[j].Score;
                                    result = PMALIGN_ARRAY[nArrayIndex].Tool.Results[j];
                                }
                            }

                            if (result == null)
                            {
                                bResult_Total = false;
                                CLogger.Add(LOG_TYPE.SEQ, $"Can't Find the Pattern of Array #{nArrayIndex}");
                                return Results;
                            }
                        }
                        else
                        {
                            if (result == null)
                            {
                                bResult_Total = false;
                                CLogger.Add(LOG_TYPE.SEQ, $"Can't Find the Pattern of Array #{nArrayIndex}");
                                return Results;
                            }
                        }
                        #endregion

                        //PBA 패턴 영역 ROI
                        Rectangle rtArrayRoi = new Rectangle((int)result.GetPose().TranslationX, (int)result.GetPose().TranslationY, PMALIGN_ARRAY[nArrayIndex].TrainedPatternImage.Width, PMALIGN_ARRAY[nArrayIndex].TrainedPatternImage.Height);

                        //결과 표시용은 0번 그랩 이미지로 사용
                        using (CogImage24PlanarColor imgResultsDrawing = new CogImage24PlanarColor(VisionTools.cropImage(images[0].ToBitmap(), rtArrayRoi)))
                        using (Mat imgOriginal = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[0].ToBitmap()).Clone())
                        {
                            CogImage24PlanarColor[] images24_board = new CogImage24PlanarColor[5];
                            CogImage8Grey[] images8_board = new CogImage8Grey[5];

                            DateTime curTm = DateTime.Now;

                            for (int i = 0; i < images.Length; i++)
                            {
                                if (images[i] != null && images[i].Allocated)
                                {
                                    using (CogImage8Grey imgMono = CogImageConvert.GetIntensityImage(images[i], 0, 0, images[0].Width, images[0].Height))
                                    {
                                        images24_board[i] = new CogImage24PlanarColor(VisionTools.cropImage(images[i].ToBitmap(), rtArrayRoi));
                                        images8_board[i] = new CogImage8Grey(VisionTools.cropImage(imgMono.ToBitmap(), rtArrayRoi));
                                    }
                                }
                            }

                            if (Global.Mode.QrPass)
                            {
                                cQrCode = new QRParser($"06{Global.System.Recipe.PbaCode.Substring(0, 4) + Global.System.Recipe.PbaCode.Substring(5, 6)}VENDYMSE{nQRError.ToString("D3")}", true);
                                nQRError++;
                                Global.Data.Board_QrCode[nArrayIndex] = cQrCode;
                            }
                            else
                            {

                                ID_ARRAY.Tool.InputImage = images8_board[Global.System.Recipe.QRBufferNo];
                                ID_ARRAY.Tool.Run();

                                if (ID_ARRAY.Tool.Results == null)
                                {
                                    CLogger.Add(LOG_TYPE.SEQ, $"NG ==> Failed Detection Qr Code");
                                    bResult_Total = false;
                                    cQrCode = new QRParser($"06{Global.System.Recipe.PbaCode.Substring(0, 4) + Global.System.Recipe.PbaCode.Substring(5, 6)}VENDYMSE{nQRError.ToString("D3")}", true);
                                    Global.Data.Board_QrCode[nArrayIndex] = cQrCode;
                                }

                                if (ID_ARRAY.Tool.Results.Count > 0)
                                {
                                    cQrCode = new QRParser(ID_ARRAY.Tool.Results[0].DecodedData.DecodedString, false);
                                    Global.Data.Board_QrCode[nArrayIndex] = cQrCode;

                                    // QR Recipe 검증기능이 선택되면
                                    if (Global.Mode.QRModelVerify)
                                    {
                                        if (cQrCode.GetQR().Contains(Global.System.Recipe.Name) == false)
                                        {
                                            CLogger.Add(LOG_TYPE.SEQ, $"NG ==> Qr[{cQrCode.GetQR()}] - Model[{Global.System.Recipe.Name}] Mapping NG ");
                                            bResult_Total = false;
                                            cQrCode.SetQRError(true);
                                            Global.Data.Board_QrCode[nArrayIndex].SetQRError(true);
                                        }
                                    }
                                    if (Global.Mode.QRCheck == true)
                                    {
                                        if (cQrCode.GetQR().Contains(Global.Mode.QRCheckText) == false)
                                        {
                                            CLogger.Add(LOG_TYPE.SEQ, $"NG ==> Qr[{cQrCode.GetQR()}] - Check[{Global.Mode.QRCheckText}] Mapping NG ");
                                            bResult_Total = false;
                                            cQrCode.SetQRError(true);
                                            Global.Data.Board_QrCode[nArrayIndex].SetQRError(true);
                                        }
                                    }
                                }
                                else
                                {
                                    cQrCode = new QRParser($"06{Global.System.Recipe.PbaCode.Substring(0, 4) + Global.System.Recipe.PbaCode.Substring(5, 6)}VENDYMSE{nQRError.ToString("D3")}", true);
                                    Global.Data.Board_QrCode[nArrayIndex] = cQrCode;
                                    nQRError++;
                                    bResult_Total = false;
                                }
                            }


                            //Cv2.Split(imgOriginal, out Mat[] imgChannels);

                            //using (Mat imgB = imgChannels[0])
                            //using (Mat imgG = imgChannels[1])
                            //using (Mat imgR = imgChannels[2])

                            Bitmap imgResult = imgResultsDrawing.ToBitmap();

                            using (Bitmap imgResult_OnlyNg = imgResultsDrawing.ToBitmap())
                            using (Graphics g = Graphics.FromImage(imgResult))
                            using (Graphics g_OnlyNg = Graphics.FromImage(imgResult))

                            // OverWrite Draw
                            //using (System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.Yellow, 5))
                            //using (Pen penPatternRegion_OK = new Pen(Color.Lime, 3))
                            //using (Pen penPatternRegion_NG = new Pen(Color.Red, 3))
                            //using (SolidBrush brush_OK = new SolidBrush(Color.Lime))
                            //using (SolidBrush brush_NG = new SolidBrush(Color.Red))

                            // Overlay Draw
                            using (System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5))
                            using (System.Drawing.Pen penPatternRegion_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5))
                            using (System.Drawing.Pen penPatternRegion_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 64, 32), 15))
                            using (SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16)))
                            using (SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32)))

                            using (SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(128, 168, 224, 168)))
                            using (SolidBrush brush_QR = new SolidBrush(System.Drawing.Color.FromArgb(128, 96, 64, 192)))
                            using (System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 168, 224, 168), 5))
                            using (System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Bold))
                            using (System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 36, FontStyle.Bold))
                            using (System.Drawing.Font font_Big = new System.Drawing.Font("Arial", 36, FontStyle.Bold))
                            using (System.Drawing.Font font_Small = new System.Drawing.Font("Arial", 12, FontStyle.Bold))
                            {

                                List<CJob> jobs_ng = new List<CJob>();

                                for (int nJobIndex = 0; nJobIndex < Global.System.CommonCode.JobManager[nArrayIndex].Jobs.Count; nJobIndex++)
                                {
                                    if (bar != null)
                                        bar.SetCurPos(null, nCurprs++);
                                    string strPattern = "M";
                                    bool bResult_Job = true;
                                    CJob job = null;

                                    job = Global.System.CommonCode.JobManager[nArrayIndex].Jobs[nJobIndex];

                                    //샘플링 검사 n회마다 검사하는 job
                                    if ((Global.Data.CountOK + Global.Data.CountNG_T + Global.Data.CountNG_F) % job.SamplingCount != 0) continue;

                                    //검사할 이미지 인덱스
                                    int nImageIndex = job.GrabIndex;

                                    bool bEnabledJob = true;

                                    //라이브러리에서 Enabled 가 켜져있지 않으면 검사하지 않음
                                    if (Global.System.Recipe.JobManager.EnabledJobs_Library.Contains(job.Name) == false)
                                        bEnabledJob = false;

                                    if (isInspectProdess && bEnabledJob && !Global.GetPass())
                                    {
                                        try
                                        {
                                            if (images8_board[job.GrabIndex] == null || !images8_board[job.GrabIndex].Allocated)
                                            {
                                                bResult_Job = false;
                                                bResult_Total = false;

                                                CUtil.ShowMessageBox("ERROR", $"Check the Grab Manager Index ==> [{job.Name}]");
                                            }
                                            else
                                            {
                                                strJob = $"ARRAY : {nArrayIndex} JOB : {job.Name}";
                                                // point - Get
                                                System.Drawing.Point ptJudge = new System.Drawing.Point(job.SearchRegion.Location.X, job.SearchRegion.Location.Y);
                                                System.Drawing.Point ptRate = new System.Drawing.Point(job.SearchRegion.Location.X, job.SearchRegion.Location.Y + 50);
                                                switch (job.Type)
                                                {
                                                    case "00) Pattern":
                                                        {
                                                            //// 임시로 패턴은 CA_ConvertGray, CC_GRAY로 Fix
                                                            //if (job.CMethod != CJob.ColorMethod.CA_ConvertGray || job.CCoordinate != CJob.ColorCoordinate.CC_GRAY)
                                                            //{
                                                            //    job.CCoordinate = CJob.ColorCoordinate.CC_GRAY;
                                                            //    job.CMethod = CJob.ColorMethod.CA_ConvertGray;
                                                            //}
                                                            job.dRate = 0.0D;
                                                            CogPMAlignResult result_Pattern = null;
                                                            job.nPatternIndex = 0;
                                                            //int nSearchIndex = 0;

                                                            for (int nPatternIndex = 0; nPatternIndex < 5; nPatternIndex++)
                                                            {
                                                                double dToolValue = 0.0;
                                                                CCogTool_PMAlign PMAlign = job.GetTool(nPatternIndex);

                                                                // 여기 이미지 가공 추가
                                                                // 여기 이미지 전처리 추가
                                                                if (job.CMethod == CJob.ColorMethod.CA_ConvertGray && job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
                                                                {
                                                                    PMAlign.Tool.InputImage = images8_board[nImageIndex];
                                                                }
                                                                else
                                                                {
                                                                    Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(images24_board[nImageIndex].ToBitmap()).Clone();
                                                                    Bitmap imgIn = CVisionTools.GetPatterernImage(false, ref job, inImg);
                                                                    //Mat outImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgIn).Clone();
                                                                    //Cv2.ImWrite("E:\\outImg.jpg", outImg);
                                                                    CogImage8Grey cogInImg = new Cognex.VisionPro.CogImage8Grey(imgIn);
                                                                    PMAlign.Tool.InputImage = cogInImg;
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
                                                                        if (nPatternIndex == 0)
                                                                            strPattern = "M";
                                                                        else
                                                                            strPattern = $"S{nPatternIndex}";
                                                                        result_Pattern = result_Best;
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

                                                                        DrawResultImageAdjust(bResult_Job, Global.System.CommonCode.JobManager[nArrayIndex].Jobs, nJobIndex, ref imgResult);

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
                                                                                    break;
                                                                                }
                                                                                else
                                                                                {
                                                                                    bResult_Job = true;
                                                                                    break;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            if (!chkPattern(job))
                                                            {
                                                                //CUtil.ShowMessageBox("Pattenr is None", $"Board-{nArrayIndex} {job.Name} Pattern is None !!!!", FormPopup_MessageBox.MESSAGEBOX_TYPE.OK);
                                                                CLogger.Add(LOG_TYPE.ALARM, $"Board-{nArrayIndex} {job.Name} Pattern is None !!!!");
                                                                job.isPatternNone = true;
                                                                bResult_Job = false;
                                                            }

                                                            if (job.Judge_NaisNg)
                                                            {
                                                                if (bCalcCenter)
                                                                {
                                                                    job.MasterPosition[nArrayIndex] = new Point2d(result_Pattern.GetPose().TranslationX, result_Pattern.GetPose().TranslationY);
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

                                                                DrawResultImageAdjust(bResult_Job, Global.System.CommonCode.JobManager[nArrayIndex].Jobs, nJobIndex, ref imgResult);
                                                            }
                                                            //else // NA ok시
                                                            //{

                                                            //}

                                                        }
                                                        break;
                                                    case "01) Color":
                                                        {
                                                            // 임시로 패턴은 CA_ConvertGray, CC_GRAY로 Fix
                                                            //if (job.CMethod == CJob.ColorMethod.CA_ConvertGray)
                                                            //    job.CMethod = CJob.ColorMethod.CA_THRESHILD;
                                                            Rect Roi = CConverter.RectToCVRect(job.SearchRegion);
                                                            Rect RoiValue = CConverter.RectToCVRect(job.valueRect);

                                                            //if (RoiValue.X == 0 && RoiValue.Y == 0 && RoiValue.Width == 100 && RoiValue.Height == 100)
                                                            //{
                                                            //    RoiValue = Roi;
                                                            //    int xAdjust = Roi.Width / 3; 
                                                            //    int yAdjust = Roi.Height / 3;
                                                            //    RoiValue.Inflate(-xAdjust, -yAdjust);
                                                            //    if (RoiValue.Width <= 0)
                                                            //        RoiValue.Width = 5;
                                                            //    if (RoiValue.Height <= 0)
                                                            //        RoiValue.Height = 5;
                                                            //    job.valueRect = CConverter.CVRectToRect(RoiValue);
                                                            //}
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
                                                                continue;
                                                            }

                                                            Mat imgArea = imgStart.SubMat(Roi);
                                                            Mat imgValue = imgStart.SubMat(RoiValue);

                                                            if (job.CMethod == CJob.ColorMethod.CA_THRESHILD && job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
                                                            {
                                                                int nThreshold = job.Threshold;
                                                                imgBin = CVisionTools.GetThresholImage(imgArea, nThreshold, (int)job.CCoordinate, (int)job.CMethod);
                                                            }
                                                            else if (job.CMethod == CJob.ColorMethod.CA_ConvertGray) continue;
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
                                                                CUtil.SetImageRange(imgArea, scrMin, scrMax, imgBin);
                                                                //Mat imgCopy = new Mat();
                                                                //Cv2.CvtColor(imgBin, imgCopy, ColorConversionCodes.GRAY2BGR);
                                                                //Mat imgInsert = inImg.SubMat(Roi);
                                                                //imgCopy.CopyTo(imgInsert);
                                                                //blobProcess(imgBin, Roi, inImg);
                                                            }

                                                            CvBlobs blobs = new CvBlobs();
                                                            blobs.Label(imgBin);
                                                            //if (job != null) blobs.FilterByArea(job.RangeAreaMin, job.RangeAreaMax);
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

                                                            DrawResultImageAdjust(bResult_Job, Global.System.CommonCode.JobManager[nArrayIndex].Jobs, nJobIndex, ref imgResult);
                                                        }
                                                        break;
                                                    case "02) IC Lead":
                                                        {
                                                            CCogTool_PMAlign PMAlign = job.Tool;
                                                            PMAlign.Tool.InputImage = images8_board[nImageIndex];
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
                                                                DrawStingAdjust($"[OK] {Global.System.Recipe.JobManager.Jobs[nJobIndex].Name} ({PMAlign.Tool.Results.Count}/{job.MasterCount}) ", font, brush_OK, job.SearchRegion.Location, g, rtArrayRoi.Width);
                                                                //g.DrawString($"[OK] {Global.System.Recipe.JobManager.Jobs[nJobIndex].Name} ({PMAlign.Tool.Results.Count}/{job.MasterCount}) ", font, brush_OK, job.SearchRegion.Location);
                                                            }
                                                            else
                                                            {
                                                                bResult_Job = false;
                                                                DrawStingAdjust($"[NG] {Global.System.Recipe.JobManager.Jobs[nJobIndex].Name} ({PMAlign.Tool.Results.Count}/{job.MasterCount}) ", font_NG, brush_NG, job.SearchRegion.Location, g, rtArrayRoi.Width);
                                                                //g.DrawString($"[NG] {Global.System.Recipe.JobManager.Jobs[nJobIndex].Name} ({PMAlign.Tool.Results.Count}/{job.MasterCount}) ", font, brush_NG, job.SearchRegion.Location);
                                                            }
                                                        }
                                                        break;
                                                    case "03) DeepLearning":
                                                        {
                                                            //deeplearning
                                                            Mat InputImage;

                                                            if (job.CMethod == CJob.ColorMethod.CA_ConvertGray && job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
                                                            {
                                                                InputImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(images8_board[nImageIndex].ToBitmap()).Clone();

                                                            }
                                                            else
                                                            {
                                                                InputImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(images24_board[nImageIndex].ToBitmap()).Clone();
                                                            }
                                                            Bitmap inputimg = CVisionTools.GetPatterernImage(false, ref job, InputImage);
                                                            CogImage24PlanarColor cogInImg = new Cognex.VisionPro.CogImage24PlanarColor(inputimg);
                                                            bResult_Job = DeepLearningInspection(cogInImg);
                                                            imgResult = cogDisplay_Source.Image.ToBitmap();
                                                            DrawResultImageAdjust(bResult_Job, Global.System.CommonCode.JobManager[nArrayIndex].Jobs, nJobIndex, ref imgResult);
                                                        }
                                                        break;
                                                }

                                            }


                                            if (bResult_Job == false)
                                            {
                                                jobs_ng.Add(job);
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }

                                    }

                                    // 이미지 저장 루틴
                                    if (job.isSavePart)
                                    {
                                        mats.Clear();
                                        Mat infoImg = GetRectImage(imgResultsDrawing.ToBitmap(), job, JobRectOption.JRO_Origin, Global.Mode.RMSMargin);
                                        mats.Add(infoImg.Clone());
                                        infoImg = GetRectImage(imgResultsDrawing.ToBitmap(), job, JobRectOption.JRO_OriginInfo, Global.Mode.RMSMargin);
                                        mats.Add(infoImg.Clone());
                                        //infoImg = GetRectImage(imgResultsDrawing.ToBitmap(), job, JobRectOption.JRO_BinImg);
                                        //mats.Add(infoImg.Clone());
                                        infoImg = GetRectImage(imgResultsDrawing.ToBitmap(), job, JobRectOption.JRO_MaskImg, 0);
                                        mats.Add(infoImg.Clone());
                                        cSaveInfor.InputPart(mats, kindOfImage.PartImg, bResult_Total, cQrCode, job, nArrayIndex, curTm);
                                        
                                    }




                                }

                                if (jobs_ng.Count > 0) bResult_Total = false;

                                string strResult = bResult_Total ? "OK" : "NG";

                                System.Drawing.Point ptDraw = new System.Drawing.Point();
                                Cognex.VisionPro.CogRectangle rt = (Cognex.VisionPro.CogRectangle)ID_ARRAY.Tool.Region;
                                ptDraw.X = (int)Math.Round(rt.CenterX);
                                ptDraw.Y = (int)Math.Round(rt.CenterY);
                                cQrCode.SetPt(ptDraw);
                                Global.Data.Board_QrCode[nArrayIndex].SetPt(ptDraw);

                                cSaveInfor.AdjustJudge(cQrCode, bResult_Total);
                                if (bResult_Total)
                                {

                                    g.DrawRectangle(new System.Drawing.Pen(brush_OK, 10), new Rectangle(5, 5, imgResult.Width - 10, imgResult.Height - 10));

                                    //CUtil.InitDirectory_DateTime_ID(CUtil.g_SaveRoot, cQrCode.GetQR(), 1);

                                    mats.Clear();
                                    inMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgResult).Clone();
                                    mats.Add(inMat);
                                    cSaveInfor.InputImg(mats, kindOfImage.OverlayImg, bResult_Total, cQrCode, nArrayIndex, 1, curTm);
                                    if (!Global.Mode.NGisRecent)
                                    {
                                        //// 5개 버퍼의 이미지를 저장한다. - 20221222
                                        for (int i = 0; i < Global.System.CommonCode.GrabManager.Nodes.Length; i++)
                                        {
                                            if (Global.System.CommonCode.GrabManager.Nodes[i].Enabled && images[i].Allocated)
                                            {
                                                mats.Clear();
                                                inMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[i].ToBitmap()).Clone();
                                                mats.Add(inMat);
                                                cSaveInfor.InputImg(mats, kindOfImage.OriginImg, bResult_Total, cQrCode, nArrayIndex, i, curTm);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    g.DrawRectangle(new System.Drawing.Pen(brush_NG, 10), new Rectangle(5, 5, imgResult.Width - 10, imgResult.Height - 10));

                                    //CUtil.InitDirectory_DateTime_ID(CUtil.g_SaveRoot, cQrCode.GetQR(), 2);

                                    mats.Clear();
                                    inMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgResult).Clone();
                                    mats.Add(inMat);
                                    cSaveInfor.InputImg(mats, kindOfImage.OverlayImg, bResult_Total, cQrCode, nArrayIndex, 1, curTm);

                                    //// 5개 버퍼의 이미지를 저장한다. - 20221222
                                    for (int i = 0; i < Global.System.CommonCode.GrabManager.Nodes.Length; i++)
                                    {
                                        if (Global.System.CommonCode.GrabManager.Nodes[i].Enabled && images[i].Allocated)
                                        {
                                            mats.Clear();
                                            inMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[i].ToBitmap()).Clone();
                                            mats.Add(inMat);
                                            cSaveInfor.InputImg(mats, kindOfImage.OriginImg, bResult_Total, cQrCode, nArrayIndex, i, curTm);
                                        }
                                    }

                                    //string strMasterBoard = $"{Application.StartupPath}\\RECIPE\\{Global.System.Recipe.Name}\\MasterBoard.jpg";

                                    //Mat imgMaster = new Mat();
                                    //if (File.Exists(strMasterBoard) == false)
                                    //{
                                    //    CUtil.ShowMessageBox("Error", "Master Image is Empty");
                                    //}
                                    //else
                                    //{
                                    //    imgMaster = Cv2.ImRead(strMasterBoard);
                                    //}

                                    for (int nIndexNg = 0; nIndexNg < jobs_ng.Count; nIndexNg++)
                                    {
                                        mats.Clear();
                                        //Mat infoImg = new Mat();
                                        Bitmap bmpInfo = null;

                                        if (jobs_ng[nIndexNg].Type.Contains("Pattern") && jobs_ng[nIndexNg].CMethod != CJob.ColorMethod.CA_ConvertGray)
                                        {
                                            CJob job = jobs_ng[nIndexNg];
                                            Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(imgResultsDrawing.ToBitmap()).Clone();
                                            bmpInfo = GetPatterernImage(false, ref job, inImg);
                                        }
                                        else
                                            bmpInfo = imgResultsDrawing.ToBitmap();
                                        Mat infoImg = GetRectImage(bmpInfo, jobs_ng[nIndexNg], JobRectOption.JRO_DrawInfo, Global.Mode.RMSMargin);
                                        Mat calcImg = GetRectImage(imgResultsDrawing.ToBitmap(), jobs_ng[nIndexNg], JobRectOption.JRO_CalcImg, Global.Mode.RMSMargin);
                                        mats.Add(infoImg);
                                        mats.Add(calcImg);
                                        cSaveInfor.InputPart(mats, kindOfImage.CropImg, bResult_Total, cQrCode, jobs_ng[nIndexNg], nArrayIndex, curTm);
                                    }
                                }
                                Results.Add(bResult_Total);
                                imgResults_array[nArrayIndex] = (Bitmap)imgResult.Clone();

                                if (display != null) display.Image = new CogImage24PlanarColor(imgResult);
                            }


                        }
                    }
                    // 여기서 연배별 QR이름을 재정비 한다.

                    // 표준 QR-Title을 얻는다.
                    QRParser cStandardQR = Global.Data.GetStandardQR();
                    cSaveInfor.SetQRTitel(cStandardQR);
                    // QR을 이미지에 그린다.
                    cSaveInfor.StartPostProcessing(imgResults_array, display);
                    // Pass를 원복 한다.
                    Global.SetPass(false);
                    if (bar != null)
                        bar.SetCurPos(null, nCurprs);
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] [{strJob}] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");

                return Results;
            }

            return Results;
        }
        public static bool DeepLearningInspection(CogImage24PlanarColor inputImage)
        {
            IGlobal Global = IGlobal.Instance;
            TCP Tcp = Global.System.Recipe.Tcp;
            bool bResult = true;
            if (Global.System.Recipe.InsType == CRecipe.InspectionType.Object)
            {
                Bitmap image = m_imgSource_Color.ToBitmap();
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                string savePath = "IMAGE\\" + "TaskID" + timestamp + ".jpg";
                image.Save(savePath);
                string ImagePath = Application.StartupPath + "\\" + savePath;
                string message = "objectdetection," + ImagePath;
                Tcp.SendMessage(message);
                string szResult = Tcp.readStringMessage();
                if (szResult != null)
                {
                    string[] ResultArray = szResult.Split(",");
                    string resultImgPath = ResultArray[1] + "_result.jpg";
                    Bitmap resultImg = new Bitmap(resultImgPath);
                    cogDisplay_Source.Image = new Cognex.VisionPro.CogImage24PlanarColor(resultImg);
                    cogDisplay_Source.Fit(true);
                    bResult = true;
                }
            }
            else if (Global.System.Recipe.InsType == CRecipe.InspectionType.Class)
            {
                Bitmap image = m_imgSource_Color.ToBitmap();
                List<(int classID, bool result)> resultlist = new List<(int classID, bool result)>();
                foreach (var item in Global.System.Recipe.GraphicObjects.GraphtcRectList)
                {
                    Rectangle rect = new Rectangle((int)item.Rect.X, (int)item.Rect.Y, (int)item.Rect.Width, (int)item.Rect.Height);
                    Bitmap croppedBitmap = image.Clone(rect, image.PixelFormat);
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                    string classID = item.ClassID.ToString();
                    string savePath = "IMAGE\\" + "TaskID_" + timestamp + "_ClassID_" + classID + ".jpg";
                    croppedBitmap.Save(savePath);
                    string message = Application.StartupPath + "\\" + savePath;
                    message = "classification," + message;
                    Tcp.SendMessage(message);
                    string szResult = Tcp.readStringMessage();
                    if (szResult != null)
                    {
                        string[] ResultArray = szResult.Split(",");
                        string resultImgPath = ResultArray[1] + ".txt";
                        string fileContent = File.ReadAllText(resultImgPath);
                        ResultArray = fileContent.Split(",");
                        string result = ResultArray[0];
                        (int classID, bool result) resultElement;
                        resultElement.classID = item.ClassID;
                        if (result == item.expectResult)
                            resultElement.result = true;
                        else
                            resultElement.result = false;
                        resultlist.Add(resultElement);
                    }
                }
                cogDisplay_Source.Image = new Cognex.VisionPro.CogImage24PlanarColor(inputImage);
                cogDisplay_Source.Fit(true);
                int pos_x, pos_y;
                foreach (var item in Global.System.Recipe.GraphicObjects.GraphtcRectList)
                {
                    if (item is GraphicRectangle)
                    {
                        CogRectangle temp = new CogRectangle();
                        Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();
                        label.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
                        temp.SetCenterWidthHeight(item.Rect.X + item.Rect.Width / 2, item.Rect.Y + item.Rect.Height / 2, item.Rect.Width, item.Rect.Height);
                        temp.LineWidthInScreenPixels = 2;
                        for (int i = 0; i < resultlist.Count; i++)
                        {
                            if (item.ClassID == resultlist[i].classID)
                            {
                                pos_x = item.Rect.X + item.Rect.Width;
                                pos_y = item.Rect.Y - 20;

                                if (resultlist[i].result)
                                {
                                    label.Color = CogColorConstants.Green;
                                    label.SetXYText(pos_x, pos_y, "Pass");
                                    temp.Color = CogColorConstants.Green;
                                }
                                else
                                {
                                    label.Color = CogColorConstants.Red;
                                    label.SetXYText(pos_x, pos_y, "NG");
                                    temp.Color = CogColorConstants.Red;
                                    bResult = false;
                                }
                                break;
                            }
                        }
                        cogDisplay_Source.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)label, "Pattern", false);
                        cogDisplay_Source.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)temp, "Pattern", false);
                    }
                }
            }
            return bResult;
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

            Mat imgStart = CVisionTools.BGR2Convert(inImg, job.CCoordinate);               // 색좌표 변경
            if (imgStart == null)                                                       // 예외 처리
            {
                string strMsg = $"{job.Name} BGR2Convert Fail !!!";
                CUtil.ShowMessageBox("EXCEPTION", strMsg, FormPopup_MessageBox.MESSAGEBOX_TYPE.OK);
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
                CUtil.SetImageRange(imgArea, scrMin, scrMax, imgBin);

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
                CUtil.ShowMessageBox("EXCEPTION", strMsg, FormPopup_MessageBox.MESSAGEBOX_TYPE.OK);
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
                    CUtil.ShowMessageBox("EXCEPTION", "Threshold Find Fail !!!", FormPopup_MessageBox.MESSAGEBOX_TYPE.OK);
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


                CUtil.SetImageRange(imgSub, minMaxVals.Item1, minMaxVals.Item2, imgBin);

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
                (job.Type.Contains("Pattern") && option == JobRectOption.JRO_DrawInfo) )
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

            try
            {
                Rectangle searchRect = job.SearchRegion;
                Rectangle patternRect = new Rectangle();
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
                    String strJudge = GetJudgeStr(false, job);
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
            catch (Exception ex)
            {
                return img;
            }
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
                Rectangle Roi_ColorSearchRegion = job.SearchRegion;
                Rectangle Roi_ColorVAlues = job.valueRect;
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
                    CLogger.Add(LOG_TYPE.ABNORMAL, $"Error - Coordinate[{job.CCoordinate.ToString()}] !!!");
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
                    CUtil.SetImageRange(imgArea, scrMin, scrMax, imgBin);
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
                CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
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
                lb.Font = new System.Drawing.Font("arial", 12);
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
                Rectangle boundingRect = new Rectangle();
                boundingRect.X = Roi.X + b.Value.Rect.X;
                boundingRect.Y = Roi.Y + b.Value.Rect.Y;
                boundingRect.Width = b.Value.Rect.Width;
                boundingRect.Height = b.Value.Rect.Height;

                if (nMaxArea < b.Value.Area) nMaxArea = b.Value.Area;

                System.Drawing.Point ptDisp =
                    new System.Drawing.Point ((int)(boundingRect.X+boundingRect.Width)/2, (int)(boundingRect.Y+boundingRect.Height)/2);
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
            IGlobal Global = IGlobal.Instance;

            Mat imgResult = inImg.Clone();
            Bitmap bmp = imgResult.ToBitmap();
            Graphics g = Graphics.FromImage(bmp);

            // Overlay Draw
            System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5);
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

            string string1 = qrData.GetPBA() + qrData.GetModel();
            string string2 = qrData.GetVendor() + qrData.GetYMS() + qrData.GetSerialNo();

            // 여기서 이전 Job의 Rect체크
            SizeF szStr = g.MeasureString(string1, font_Big);
            Rectangle rctDraw = new Rectangle(pt1.X, pt1.Y, (int)szStr.Width, (int)szStr.Height + 30);
            Rectangle rctInterSect = rctDraw;
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
            DrawStingCenter($"{string1}", font_Big, brushDraw, pt1, g, imgResult.Width);
            DrawStingCenter($"{string2}", font_Big, brushDraw, pt2, g, imgResult.Width);

            imgResult = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp);

            return imgResult;
        }

        public enum kindOfImage
        {
            OverlayImg = 0,
            OriginImg,
            CropImg,
            PartImg
        }
        public class ResultInform
        {
            public kindOfImage Method;
            public bool isOk;
            public QRParser QrCode;
            public int ArrayIndex;
            public int GrabIndex;
            public DateTime insTm;
            public bool isAuto;
            public CJob job;

            public ResultInform(bool bOk, QRParser inQrCode, int nArrayIndex, int nGrabIndex, DateTime tmTime, bool bAuto, kindOfImage nMethod)
            {
                isOk = bOk;
                QrCode = inQrCode;
                ArrayIndex = nArrayIndex;
                GrabIndex = nGrabIndex;
                insTm= tmTime;
                isAuto = bAuto;
                Method = nMethod;
            }

            public ResultInform(bool bOk, QRParser inQrCode, CJob jobIn, bool bAuto, kindOfImage nMethod, DateTime curTm, int nArrayIndex)
            {
                isOk = bOk;
                QrCode = inQrCode;
                isAuto = bAuto;
                job = jobIn;
                Method = nMethod;
                insTm = curTm;
                ArrayIndex = nArrayIndex;
            }
            public void SetQR(QRParser inQrcode)
            {
                QrCode = inQrcode;
            }
            public void SetQRTitle(QRParser inQRCode)
            {
                QrCode.SetQRTitle(inQRCode);
            }
        }

        public class SaveInform
        {
            IGlobal Global = IGlobal.Instance;
            List<List<Mat>> matGroup = new List<List<Mat>>();
            List<ResultInform> Results = new List<ResultInform>();

            public void AdjustJudge(QRParser qr, bool bOK)
            {
                for (int i = 0; i < Results.Count(); i++)
                {
                    if (Results[i].QrCode.GetQR().CompareTo(qr.GetQR()) == 0)
                    {
                        Results[i].isOk = bOK;
                    }
                }
            }

            public void ClearAll()
            {
                Results.Clear();
                for (int i = 0; i < matGroup.Count; i++)
                    matGroup[i].Clear();
                matGroup.Clear();
            }

            public void InputImg(List<Mat> images, kindOfImage nMethod, bool bOk, QRParser inQrCode, int nArrayIndex, int nGrabIndex, DateTime curTm, bool bAuto = true)
            {
                matGroup.Add(images.ToList());
                Results.Add(new ResultInform(bOk, inQrCode, nArrayIndex, nGrabIndex, curTm, bAuto, nMethod));
            }

            public void InputPart(List<Mat> images, kindOfImage nMethod, bool bOk, QRParser inQrCode, CJob jobIn, int nArrayIndex, DateTime curTm, bool bAuto = true)
            {
                matGroup.Add(images.ToList());
                Results.Add(new ResultInform(bOk, inQrCode, jobIn, bAuto, nMethod, curTm, nArrayIndex));
            }

            public void SetQRTitel(QRParser inQR)
            {
                for (int i = 0; i < Results.Count(); i++)
                {
                    Results[i].SetQRTitle(inQR);
                }
            }

            public void StartPostProcessing(Bitmap[] ImgResultArray, CogDisplay display)       // DB등록부분 수정 필요
            {
                string strJob = "";
                try
                {
                    for (int i = 0; i < Results.Count(); i++)
                    {
                        //strJob = $"{Results[i].job.Name}";
                        if (Results[i].job == null)
                            strJob = $"Array_{Results[i].ArrayIndex}_Image";
                        else
                        {
                            strJob = $"Job_{Results[i].job.Name}_Image";
                            if (Results[i].job.isPatternNone)
                                continue;
                        }

                        List<string> saveNames = new List<string>();
                        string saveName;
                        saveNames = GetSaveFileNames(Results[i].isOk, Results[i].QrCode.GetQR(), Results[i].ArrayIndex,
                            Results[i].GrabIndex, Results[i].insTm, Results[i].isAuto);
                        string strResult = Results[i].isOk ? "OK" : "NG";

                        if (Results[i].Method == kindOfImage.OverlayImg)
                        {
                            saveName = saveNames[2];
                            Mat matResult = DrawQRCode(matGroup[i][0], Results[i].QrCode,
                                Global.System.CommonCode.JobManager[Results[i].ArrayIndex].Jobs, Global.System.CommonCode.JobManager[Results[i].ArrayIndex].Jobs.Count);
                            ImgResultArray[Results[i].ArrayIndex] = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matResult.Clone());
                            if (display != null) display.Image = new CogImage24PlanarColor(ImgResultArray[Results[i].ArrayIndex]);

                            if (Results[i].isOk)
                            {
                                CUtil.InitDirectory_DateTime_ID(CUtil.g_SaveRoot, Results[i].QrCode.GetQR(), 1);
                                // DB 등록
                                Global.DB.Insert_Result("HISTORY",
                                 new string[] { "time", "model", "qrcode", "insp_judge", "rms_judge", "master_img_path", "ng_img_path", "crop_img_path", "master_crop_img_path", "ng_part_code", "ng_reason", "ng_rect" },
                                 new string[] {
                                                            $"'{Results[i].insTm.ToString("yyyyMMdd:HHmmss")}'",
                                                            $"'{Global.System.Recipe.Name}'",
                                                            $"'{Results[i].QrCode.GetQR()}'",
                                                            $"'{strResult}'",
                                                            $"'OK'",
                                                            $"'{System.Windows.Forms.Application.StartupPath}\\RECIPE\\{Global.System.Recipe.Name}\\MasterBoard_0.jpg'",
                                                            $"'{saveName}'",
                                                            $"''",
                                                            $"''",
                                                            $"''",
                                                            $"''",
                                                            $"''",
                                  });
                            }
                            else
                            {
                                CUtil.InitDirectory_DateTime_ID(CUtil.g_SaveRoot, Results[i].QrCode.GetQR(), 2);
                            }
                            Cv2.ImWrite(saveName, matResult);
                        }
                        else if (Results[i].Method == kindOfImage.OriginImg)
                        {
                            saveName = saveNames[0];
                            Cv2.ImWrite(saveName, matGroup[i][0]);
                        }
                        else if (Results[i].Method == kindOfImage.CropImg)
                        {
                            saveName = saveNames[2];
                            List<string> saveCropNames = GetCropFileNames(Results[i].isOk, Results[i].QrCode.GetQR(), Results[i].job.Name, Results[i].isAuto);
                            int nGrabIndex = Results[i].job.GrabIndex;
                            for (int j = 0; j < saveCropNames.Count; j++)
                                Cv2.ImWrite(saveCropNames[j], matGroup[i][j]);
                            Rectangle searchRect = GetSearchRect(Results[i].job.nPatternIndex, Results[i].job);
                            Global.DB.Insert_Result("HISTORY",
                           new string[] { "time", "model", "qrcode", "insp_judge", "rms_judge", "master_img_path", "ng_img_path", "crop_img_path", "master_crop_img_path", "ng_part_code", "ng_reason", "ng_rect" },
                           new string[] {
                                                            //$"'{DateTime.Now.ToString("yyyy-MM-dd")}T{DateTime.Now.ToString("HH:mm")}'",
                                                            $"'{Results[i].insTm.ToString("yyyyMMdd:HHmmss")}'",
                                                            $"'{Global.System.Recipe.Name}'",
                                                            $"'{Results[i].QrCode.GetQR()}'",
                                                            $"'{strResult}'",
                                                            $"'IDLE'",
                                                            $"'{System.Windows.Forms.Application.StartupPath}\\RECIPE\\{Global.System.Recipe.Name}\\MasterBoard_{nGrabIndex}.jpg'",
                                                            $"'{saveName}'",
                                                            $"'{saveCropNames[0]}'",
                                                            $"'{saveCropNames[1]}'",
                                                            $"'{Results[i].job.Name}/{Results[i].job.Type}'",
                                                            $"'X'",
                                                            $"'{searchRect.X},{searchRect.Y},{searchRect.Width},{searchRect.Height}'",
                              });
                        }
                        else if (Results[i].Method == kindOfImage.PartImg)
                        {
                            int nAdd = Results[i].isOk ? 1 : 2;
                            CUtil.InitDirectory_DateTime_ID(CUtil.g_SaveRoot, Results[i].QrCode.GetQR(), 2 + nAdd);
                            List<string> savePartNames = GetPartFileNames(Results[i].isOk, Results[i].QrCode.GetQR(), Results[i].job.Name, Results[i].isAuto);
                            for (int j = 0; j < savePartNames.Count; j++)
                                Cv2.ImWrite(savePartNames[j], matGroup[i][j]);
                        }
                    }
                    ClearAll();
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                    CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] [{strJob} Check!!!] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");

                    return;
                }
            }
        }

        // DateTime.ParseExact("19891221210411", "yyyyMMddHHmmss",  문자열 -> 날짜
        // DateTime.Now.ToString(Format); ->{DateTime.Now.ToString("yyyyMMdd:HHmmss")}

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

        public static string GetJudgeStr(bool bOk, CJob job)
        {
            String strReturn = "";

            if (bOk)
                strReturn = $"OK-{job.Name}";
            else
                strReturn = $"NG-{job.Name}";

            return strReturn;
        }

        public static string GetRateStr(bool bOk, CJob job, double dScore)
        {
            string strPattern = "";
            String strReturn = "";

            if (job.Type.Contains("Pattern"))
            {
                if ( (job.Judge_NaisNg && !bOk) || (!job.Judge_NaisNg && bOk) )
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

        public static string GetSavePath(bool bOk, string strQrCode, bool bAuto = true)
        {
            string strOk, strAuto;
            if (bOk)
                strOk = "OK";
            else
                strOk = "NG";

            if (bAuto)
            {
                strAuto = "Auto";
                return $"{CUtil.g_SaveRoot}\\{DateTime.Now.Year}\\{DateTime.Now.Month.ToString("D2")}\\{DateTime.Now.Day.ToString("D2")}_{strAuto}\\{strOk}\\{strQrCode}";
            }
            else
            {
                strAuto = "User";
                return $"{CUtil.g_SaveRoot}\\{DateTime.Now.Year}\\{DateTime.Now.Month.ToString("D2")}\\{DateTime.Now.Day.ToString("D2")}_{strAuto}";
            }



        }

        public static List<string> GetSaveFileNames(bool bOk, string strQrCode, int nArrayIndex, int nGrabIndex, DateTime curTm, bool bAuto = true)
        {
            List<string> lstReturn = new List<string>();
            string strOk;
            if (bOk)
                strOk = "OK";
            else
                strOk = "NG";

            string strPath = GetSavePath(bOk, strQrCode);

            lstReturn.Add($"{strPath}\\{strOk}_{strQrCode}_{curTm.ToString("yyMMdd_HHmmss")}_BD{nArrayIndex}_ORI_{nGrabIndex}.jpg");
            lstReturn.Add($"{strPath}\\{strOk}_{strQrCode}_{curTm.ToString("yyMMdd_HHmmss")}_ORI.jpg");
            lstReturn.Add($"{strPath}\\{strOk}_{strQrCode}_{curTm.ToString("yyMMdd_HHmmss")}_OVL.jpg");

            return lstReturn;
        }

        public static List<string> GetCropFileNames(bool bOk, string strQrCode, string strJobName, bool bAuto = true)
        {
            List<string> lstReturn = new List<string>();
            string strOk = CUtil.GetJudgeString(bOk);
            string strPath = GetSavePath(bOk, strQrCode);

            lstReturn.Add($"{strPath}\\Crop\\OrigImg_{strQrCode}_{strJobName}.jpg");
            lstReturn.Add($"{strPath}\\Crop\\CalcImg_{strQrCode}_{strJobName}.jpg");

            return lstReturn;
        }

        public static List<string> GetPartFileNames(bool bOk, string strQrCode, string strJobName, bool bAuto = true)
        {
            List<string> lstReturn = new List<string>();
            string strOk = CUtil.GetJudgeString(bOk);
            string strPath = GetSavePath(bOk, strQrCode);

            lstReturn.Add($"{strPath}\\Part\\OriginImg_{strQrCode}_{strJobName}.jpg");
            lstReturn.Add($"{strPath}\\Part\\InfoImg_{strQrCode}_{strJobName}.jpg");
            //lstReturn.Add($"{strPath}\\Part\\Binary_{strQrCode}_{strJobName}.jpg");
            lstReturn.Add($"{strPath}\\Part\\PartImg_{strQrCode}_{strJobName}.jpg");
            return lstReturn;
        }

        private static string m_XMLNameGrabSEQ = "GrabSEQ";

        public static bool SaveGrabSEQ(int Camindex)
        {
            string strRecipeName = IGlobal.Instance.System.Recipe.Name;
            string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipeName}\\GrabSEQ" + Camindex + ".xml";
            CUtil.InitDirectory($"RECIPE\\{strRecipeName}");
            //string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipeName}\\{strSubRecipeName}\\GrabSEQ" + Camindex + ".xml";
            //CUtil.InitDirectory($"RECIPE\\{strRecipeName}\\{strSubRecipeName}\\");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("PROPERTY");


                string strSaveData = "";
                string strSeqData = "";


                string strLightValue = "";
                string strExposure = "";
                string strGain = "";
                string strUSE = "";

               

                if (Camindex == 1)
                {
                    strUSE = CVisionTools.JOB_SEQ_USE_CAM1.ToString();

                    string USE = $"{strUSE};";

                    strSaveData += USE;

                    for (int i = 0; i < Grab_seq.Count; i++)
                    {
                        strLightValue = Grab_seq[i].LightValue.ToString();
                        strExposure = Grab_seq[i].Exposure.ToString();
                        strGain = Grab_seq[i].Gain.ToString();
                        //strUSE = Grab_seq[i].USE.ToString();

                        string strSave = $"{strLightValue}#{strExposure}#{strGain};";

                        strSaveData += strSave;
                    }
                }
                else
                {
                    strUSE = CVisionTools.JOB_SEQ_USE_CAM2.ToString();

                    string USE = $"{strUSE};";

                    strSaveData += USE;


                    for (int i = 0; i < Grab_seq2.Count; i++)
                    {
                        strLightValue = Grab_seq2[i].LightValue.ToString();
                        strExposure = Grab_seq2[i].Exposure.ToString();
                        strGain = Grab_seq2[i].Gain.ToString();
                        //strUSE = Grab_seq2[i].USE.ToString();

                        string strSave = $"{strLightValue}#{strExposure}#{strGain};";

                        strSaveData += strSave;
                    }
                }


                
                xmlWriter.WriteElementString("DATA", strSaveData);

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }

            return true;
        }

        public static bool LoadGrabSEQ(int camindex)
        {
            string strRecipeName = IGlobal.Instance.System.Recipe.Name;
            string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipeName}\\GrabSEQ" + camindex + ".xml";
            CUtil.InitDirectory($"RECIPE\\{strRecipeName}\\GrabSEQ\\CAMERA" + camindex);
            //string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipeName}\\{strSubRecipeName}\\GrabSEQ" + camindex + ".xml";
            //CUtil.InitDirectory($"{Application.StartupPath}\\RECIPE\\{strRecipeName}\\{strSubRecipeName}\\GrabSEQ\\CAMERA" + camindex);

            try
            {
                if (File.Exists(strPath))
                {
                    XmlTextReader xmlReader = new XmlTextReader(strPath);

                    try
                    {
                        string strLoadData = "";
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                switch (xmlReader.Name)
                                {
                                    case "DATA": if (xmlReader.Read()) strLoadData = xmlReader.Value; break;
                                }
                            }
                            else
                            {
                                if (xmlReader.NodeType == XmlNodeType.EndElement)
                                {
                                    if (xmlReader.Name == m_XMLNameGrabSEQ) break;
                                }
                            }
                        }

                        if (camindex == 1)
                        {
                            Grab_seq.Clear();

                            if (strLoadData != "")
                            {
                                string[] strSeqSplit1 = strLoadData.Split(';');

                                CVisionTools.JOB_SEQ_USE_CAM1 = bool.Parse(strSeqSplit1[0]);

                                for (int i = 0; i < strSeqSplit1.Length; i++)
                                {
                                    string[] strSeqSplit2 = strSeqSplit1[i].Split('#');

                                    if (strSeqSplit2.Length == 3)
                                    {
                                        //GRAB_SEQ grab = new GRAB_SEQ();
                                        JOB_SEQ grab = new JOB_SEQ();

                                        grab.LightValue = int.Parse(strSeqSplit2[0]);
                                        grab.Exposure = int.Parse(strSeqSplit2[1]);
                                        grab.Gain = int.Parse(strSeqSplit2[2]);
                                        //grab.USE = bool.Parse(strSeqSplit2[3]);

                                        Grab_seq.Add(grab);
                                    }


                                }
                            }
                            
                        }
                        else
                        {
                            Grab_seq2.Clear();

                            if (strLoadData != "")
                            {
                                string[] strSeqSplit1 = strLoadData.Split(';');

                                CVisionTools.JOB_SEQ_USE_CAM2 = bool.Parse(strSeqSplit1[0]);

                                for (int i = 0; i < strSeqSplit1.Length; i++)
                                {
                                    string[] strSeqSplit2 = strSeqSplit1[i].Split('#');

                                    if (strSeqSplit2.Length == 3)
                                    {
                                        //GRAB_SEQ grab = new GRAB_SEQ();
                                        JOB_SEQ grab = new JOB_SEQ();

                                        grab.LightValue = int.Parse(strSeqSplit2[0]);
                                        grab.Exposure = int.Parse(strSeqSplit2[1]);
                                        grab.Gain = int.Parse(strSeqSplit2[2]);
                                        //grab.USE = bool.Parse(strSeqSplit2[3]);

                                        Grab_seq2.Add(grab);
                                    }


                                }
                            }
                        }

                       

                    }
                    catch (Exception ex)
                    {
                        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                        xmlReader.Close();
                    }

                    xmlReader.Close();
                }
                else
                {
                    for (int i = 0; i < IGlobal.Instance.Device.CAMERA_COUNT; i++)
                    {
                        SaveGrabSEQ(i + 1);
                    }

                    return false;
                }

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }


            return true;
        }

        private static string m_XMLNameJobs = "JOBS";
        public static bool SaveJobs()
        {
            string strRecipeName = IGlobal.Instance.System.Recipe.Name;
            string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipeName}\\JOBS\\Jobs.xml";
            CUtil.InitDirectory($"RECIPE\\{strRecipeName}\\JOBS");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("PROPERTY");
                xmlWriter.WriteStartElement("GRABSEQ");

                string strSaveData = "";
                string strSeqData = "";
                for (int i = 0; i < Jobs.Count; i++)
                {
                    string strJobName = Jobs[i].NAME;
                    string strMatchingPath = $"{Application.StartupPath}\\RECIPE\\{strRecipeName}\\JOBS\\{strJobName}.vpp";
                    string strMasterCount = Jobs[i].MASTER_COUNT.ToString();
                    string strType = Jobs[i].INSP_TYPE;
                    string strAngle = Jobs[i].ANGLE.ToString();
                    string strNotOption = Jobs[i].NotOption.ToString();
                    string strQuantizeUse = Jobs[i].QuantizeUse.ToString();
                    string strQuantizeLevel = Jobs[i].QuantizeLevel.ToString();
                    string strEqualizeUse = Jobs[i].EqualizeUse.ToString();

                    Jobs[i].Matching.SaveConfig_Manual(strMatchingPath);

                    string strSubRoi = "";
                    for (int j = 0; j < Jobs[i].SubJobs.Count; j++)
                    {
                        strSubRoi += $"{Jobs[i].SubJobs[j].Index}|{CConverter.RectToString(Jobs[i].SubJobs[j].ROI)}|{Jobs[i].SubJobs[j].MasterAngle}|{Jobs[i].SubJobs[j].IsLeadExist.ToString()}-";
                    }

                    string strSave = $"{strJobName}#{strMatchingPath}#{strType}#{strMasterCount}#{strAngle}#{strSubRoi}#{strNotOption}#{strQuantizeUse}#{strQuantizeLevel}#{strEqualizeUse};";

                    strSaveData += strSave;
                }

                for (int i = 0; i < Grab_seq.Count; i++)
                {
                    
                    string strGSeqLightValue = Grab_seq[i].LightValue.ToString();

                    string strGSeqSave = $"{strGSeqLightValue};";

                    strSeqData += strGSeqSave;
                }

                xmlWriter.WriteElementString("DATA", strSaveData);
                xmlWriter.WriteElementString("SEQDATA", strSeqData);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }

            return true;
        }

        public static List<DEFINE.TYPE_NG> OCR_Run_All(int nIndex, CogImage24PlanarColor imgColor, CogImage8Grey imgOriginal, CogDisplay cogDisplay)
        {
            List<DEFINE.TYPE_NG> type = new List<DEFINE.TYPE_NG>();

            CogRectangleAffine OriginRectangle = new CogRectangleAffine();
            CogRectangleAffine MoveRectangle = new CogRectangleAffine();
            double tmpX = new double();
            double tmpY = new double();

            try
            {

                CogOCRMaxTool cogOCR = new CogOCRMaxTool();
                CogGraphicCollection cogList = new CogGraphicCollection();
                CogGraphicLabel label = new CogGraphicLabel();

                cogDisplay.Image = imgColor;
                cogDisplay.Fit(true);

                if (nIndex == 0)
                {

                    tmpOCR = OCR;
                }
                else
                {
                    tmpOCR = OCR2;
                }

                using (CogImage8Grey imgSource = new CogImage8Grey(imgOriginal))
                {
                    for (int i = 0; i < tmpOCR.Count; i++)
                    {


                        cogOCR = tmpOCR[i].OCR.Tool;
                        

                        if (tmpColorMatch[i].InspectionUse)
                        {

                            //Region Offset
                            (tmpX, tmpY) = CVisionTools.RegionOffSet(nIndex, cogDisplay, imgSource);
                            (OriginRectangle, MoveRectangle) = CVisionTools.AffineRegionRect(CVisionTools.tmpOCR[i].OCR.Tool.Region, tmpX, tmpY);
                            CVisionTools.tmpOCR[i].OCR.Tool.Region = MoveRectangle;


                            if (tmpOCR[i].OCR.Tool.Classifier.Font.Count > 0)
                            {

                                string result = tmpOCR[i].OCR.Run(imgSource);
                                string ReverseCompare = CUtil.String_Reverse(tmpOCR[i].COMPARE_STRING);

                                if (result.Contains(tmpOCR[i].COMPARE_STRING) || result.Contains(ReverseCompare)) //OK
                                {
                                    label.Color = CogColorConstants.Green;
                                    label.Text = "OCR OK";
                                    label.Font = new System.Drawing.Font("arial", 10);
                                    label.X = tmpOCR[i].OCR.Tool.Region.CenterX;
                                    label.Y = tmpOCR[i].OCR.Tool.Region.CenterY;


                                    cogList.Add(tmpOCR[i].OCR.Tool.Region);
                                    cogList.Add(label);
                                    
                                }// NG
                                else
                                {
                                    label.Color = CogColorConstants.Red;
                                    label.Text = "OCR NG";
                                    label.Font = new System.Drawing.Font("arial", 10);
                                    label.X = tmpOCR[i].OCR.Tool.Region.CenterX;
                                    label.Y = tmpOCR[i].OCR.Tool.Region.CenterY;


                                    cogList.Add(tmpOCR[i].OCR.Tool.Region);
                                    cogList.Add(label);

                                    type.Add(DEFINE.TYPE_NG.NA);

                                    NGOCRRegion.Add(tmpOCR[i].OCR.Tool.Region);
                                    NGOCRIndex.Add(i);
                                    NGOCRName.Add(tmpOCR[i].Defect_Name);
                                }

                            }
                            else
                            {
                                //ng Font nothing
                                label.Color = CogColorConstants.Red;
                                label.Text = "FONT NOTHING";
                                label.Font = new System.Drawing.Font("arial", 10);
                                label.X = tmpOCR[i].OCR.Tool.Region.CenterX;
                                label.Y = tmpOCR[i].OCR.Tool.Region.CenterY;

                                cogList.Add(tmpOCR[i].OCR.Tool.Region);
                                cogList.Add(label);

                                type.Add(DEFINE.TYPE_NG.NA);

                                NGOCRRegion.Add(tmpOCR[i].OCR.Tool.Region);
                                NGOCRIndex.Add(i);
                                NGOCRName.Add(tmpOCR[i].Defect_Name);
                            }

                            cogDisplay.StaticGraphics.AddList(cogList, "");
                        }
                        else
                        {
                            //pass
                        }


                        CVisionTools.tmpOCR[i].OCR.Tool.Region = OriginRectangle;


                    }

                }
            }
            catch (Exception ex)
            {
                type.Add(DEFINE.TYPE_NG.IDLE);
                CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

            GC.Collect();
            return type;

        }

        public static ICogImage Run_Equalize(ICogImage cogImage, CogRectangle ROI)
        {
            try
            {
                return Equalize.Run(cogImage as CogImage8Grey, ROI);
            }
            catch (Exception)
            {

                return cogImage;
            }
        }

        public static ICogImage Run_CopyRegion(ICogImage cogImage, CogRectangle ROI)
        {

            try
            {
                return CopyRegion.Run(cogImage, ROI);
            }
            catch (Exception)
            {

                return cogImage;
            }

        }

        public static ICogImage Run_CopyRegion(ICogImage cogImage, CogRectangleAffine ROI)
        {

            try
            {
                return CopyRegion.Run(cogImage, ROI);
            }
            catch (Exception)
            {

                return cogImage;
            }

        }

        public static (double,double) RegionOffSet(int camindex, CogDisplay display, CogImage8Grey image)
        {
            double MoveX = 0.0;
            double MoveY = 0.0;

            CCogTool_PMAlign tmpPMAlign = null;
            CCogTool_Fixture tmpFixture = null;

            try
            {
                //if (camindex == 0)
                //{
                //    tmpPMAlign = CVisionTools.PMALIGN_CAM1;
                //    tmpFixture = CVisionTools.FIXTURE_CAM1;
                //}
                //else
                //{
                //    tmpPMAlign = CVisionTools.PMALIGN_CAM2;
                //    tmpFixture = CVisionTools.FIXTURE_CAM2;
                //}

                if (tmpFixture.FixtureUSE)
                {

                    tmpPMAlign.Tool.InputImage = image;
                    tmpPMAlign.Tool.Run();

                    for (int i = 0; i < tmpPMAlign.Tool.Results.Count; i++)

                    {
                        CogRectangle Draw = new CogRectangle();
                        CogCompositeShape resultDrawing = tmpPMAlign.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.All);

                        CogGraphicLabel label = new CogGraphicLabel();

                        label.X = tmpPMAlign.Tool.Results[i].GetPose().TranslationX;
                        label.Y = tmpPMAlign.Tool.Results[i].GetPose().TranslationY;

                        display.InteractiveGraphics.Add(tmpPMAlign.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                        display.StaticGraphics.Add(resultDrawing, "main");

                        MoveX = tmpPMAlign.Tool.Results[i].GetPose().TranslationX - tmpFixture.Origin_Translation_X;
                        MoveY = tmpPMAlign.Tool.Results[i].GetPose().TranslationY - tmpFixture.Origin_Translation_Y;

                        //OriginRectangle = m_SelectedMultiPMAlign.Matching.Tool.SearchRegion as CogRectangle;
                        //double CX = OriginRectangle.CenterX;
                        //double CY = OriginRectangle.CenterY;
                        //double Width = OriginRectangle.Width;
                        //double Height = OriginRectangle.Height;

                        //MoveRectangle.SetCenterWidthHeight(CX + tmpTranslationX, CY + tmpTranslationY, Width, Height);

                        //m_SelectedMultiPMAlign.Matching.Tool.SearchRegion = MoveRectangle;

                    }
                }



            }
            catch (Exception ex)
            {
                MoveX = 0.0;
                MoveY = 0.0;
                CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

            return (MoveX, MoveY);
        }

        public static (CogRectangle, CogRectangle) RegionRect(ICogRegion region, double x, double y)
        {
            CogRectangle OriginRect = new CogRectangle();
            CogRectangle MoveRect = new CogRectangle();

            try
            {
                OriginRect = region as CogRectangle;
                MoveRect.SetCenterWidthHeight(OriginRect.CenterX + x, OriginRect.CenterY + y, OriginRect.Width, OriginRect.Height);


            }
            catch (Exception ex)
            {

                CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

            return (OriginRect, MoveRect);
        }

        public static (CogRectangleAffine, CogRectangleAffine) AffineRegionRect(ICogRegion region, double x, double y)
        {
            CogRectangleAffine OriginRect = new CogRectangleAffine();
            CogRectangleAffine MoveRect = new CogRectangleAffine();

            try
            {
                OriginRect = region as CogRectangleAffine;
                MoveRect.SetCenterLengthsRotationSkew(OriginRect.CenterX + x, OriginRect.CenterY + y, OriginRect.SideXLength, OriginRect.SideYLength, OriginRect.Rotation, OriginRect.Skew);
                

            }
            catch (Exception ex)
            {

                CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

            return (OriginRect, MoveRect);
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
    }

    public class JOB_MUTIPMALIGN
    {
        public List<JOB_PART_MASTER_POSITION> SubJobs = new List<JOB_PART_MASTER_POSITION>();
        public CCogTool_MultiPMAlign Matching = null;
        public List<CCogTool_PMAlign> SubPattern = null;
        //
        public string NAME = "JOB";
        public int MASTER_COUNT = 1;
        public string INSP_TYPE = "EXISTS/REVERSE";
        public double ANGLE = 0;
        public bool NotOption = false;
        public bool QuantizeUse = false;
        public int QuantizeLevel = 0;
        public bool EqualizeUse = false;
        public bool InspectionUse = false;
        public bool MaskingUse = false;
        public bool ThresholdUse = false;
        public int ThresholdValue = 0;

        public JOB_MUTIPMALIGN(string strName = "")
        {
            Matching = new CCogTool_MultiPMAlign(strName);
        }
    }


    public class JOB_OCR
    {
        public string Defect_Name = "DEFECT";
        public bool InspectionUse = false;
        
        public double SCORE = 0.0;
        public string COMPARE_STRING;
        //public string TRAIN_OCR;
        public int TRAIN_COUNT;

        public CCogTool_OCR OCR = null;

        public JOB_OCR(string strName = "")
        {
            OCR = new CCogTool_OCR(strName);
        }
    }


    public class JOB_COLORMATCH
    {
        public string Defect_Name = "DEFECT";
        public bool InspectionUse = false;
        public int ColorCount = 0;
        public double SCORE = 0.0;

        public CCogTool_ColorMatch COLORMATCH = null;

        public JOB_COLORMATCH(string strName = "")
        {
            COLORMATCH = new CCogTool_ColorMatch(strName);
        }
    }

    public class JOB_BLOB
    {
        public string Defect_Name = "DEFECT";   
        public int Defect_MasterCount = 0;
        public int Defect_Threshold = 0;        
        public int Defect_Max = 0; 
        public int Defect_Min = 0;

        public bool InspectionUse = false;

        public CCogTool_Blob BLOB = null;
        
        public JOB_BLOB(string strName = "")
        {
            BLOB = new CCogTool_Blob(strName);
        }
    }

    public class VISION_INSP_PARAM
    {
        public List<JOB_BLOB> Defect_Param_List = null;
        public JOB_BLOB m_Defect_Param = null;
    }

    public class JOB_TEMP
    {
        public List<JOB_PART_MASTER_POSITION> SubJobs = new List<JOB_PART_MASTER_POSITION>();
        public CCogTool_PMAlign Matching = null;
        public List<CCogTool_PMAlign> SubPattern = null;
        //
        public string NAME = "JOB";
        public int MASTER_COUNT = 1;
        public string INSP_TYPE = "EXISTS/REVERSE";
        public double ANGLE = 0;
        public bool NotOption = false;
        public bool QuantizeUse = false;
        public int QuantizeLevel = 0;
        public bool EqualizeUse = false;
        public bool InspectionUse = false;
        public bool MaskingUse = false;

        public JOB_TEMP(string strName = "")
        {
            Matching = new CCogTool_PMAlign(strName);
        }
    }

    

    public class JOB_SEQ
    {
        //public string Name;
        //public int Index;
        public int LightValue;
        public int Exposure;
        public int Gain;
        //public bool USE;
        public CogImage24PlanarColor m_imgSource_Color;
    }

    public struct JOB_PART_MASTER_POSITION
    {
        public Rectangle ROI;

        public int Index;
        public double MasterAngle;

        public bool IsLeadExist;
    }

    public struct JOB_PART_LEAD
    {
        public int AreaMin;
        public int AreaMax;
        public int LeadCount;
        public Rectangle[] ROIs;
        public bool IsWhite;
    }

    public struct GRAB_SEQ
    {
        //public string Name;
        //public int Index;
        public int LightValue;
        public int Exposure;
        public int Gain;
        public bool USE;
        public CogImage24PlanarColor m_imgSource_Color;
    }
}
