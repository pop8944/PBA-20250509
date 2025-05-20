using Cognex.VisionPro.QuickBuild.IO;
using IFOnnxRuntime;
using IFOnnxRuntime.DTOs;
using OpenCvSharp;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using log4net.Core;
using System.Web.UI.WebControls;

namespace IntelligentFactory
{
    public static class LogicResultDraw
    {
        public static void DrawPattern(Dictionary<string, object> patternData, int arrayNum)
        {
            try
            {
                Global Global = Global.Instance;
                Graphics g = Graphics.FromImage(Global.ImageResults_array[arrayNum]);
                Graphics g_NG = Graphics.FromImage(Global.ImageNG_array[arrayNum]);

                string locationNo = (string)patternData["LocationNo"];
                string type = (string)patternData["Type"];
                string logicName = (string)patternData["Name"];
                double findScore = (double)patternData["FindScore"];
                double judgeScore = (double)patternData["JudgeScore"];
                bool bResult = (bool)patternData["Result"];
                Rectangle searchROI = (Rectangle)patternData["SearchROI"];
                Rectangle detectROI = (Rectangle)patternData["DetectROI"];
                int patternIdx = (int)patternData["PatternIndex"];
                bool judgeNaNG = (bool)patternData["JudgeNaNG"];
                bool bretry = (bool)patternData["RETRY"];
                bool bTrained = (bool)patternData["Trained"];
                // Overlay Draw
                using (System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5))
                using (System.Drawing.Pen penPatternRegion_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5))
                using (System.Drawing.Pen penPatternRegion_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 255, 64, 32), 5))
                using (SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16)))
                using (SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(180, 255, 64, 32)))
                using (SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(180, 168, 224, 168)))
                using (System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 168, 224, 168), 10))
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                using (System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                {
                    //searchRect = GetSearchRect(job.nPatternIndex, job);
                    //System.Drawing.Rectangle patternRect = GetPatternRect(job.nPatternIndex, job);

                    System.Drawing.Point ptJudge = new System.Drawing.Point(searchROI.X, searchROI.Y);
                    System.Drawing.Point ptRate = new System.Drawing.Point(searchROI.X, searchROI.Y + 30);
                    ptJudge.Y += searchROI.Height / 4;

                    ptRate = ptJudge;
                   
                    //if (bTrained)
                    //{
                    if (bResult)
                    {
                        g.DrawRectangle(penSearchRegion, searchROI);
                        g.DrawRectangle(penPatternRegion_OK, detectROI);
                        g.DrawString(GetOptionStr(bResult, "Pattern", judgeNaNG, patternIdx, locationNo, logicName), font, brush_OK, ptRate);
                        ptRate.Y += 25;
                        g.DrawString(GetRateStr(bResult, "Pattern", judgeNaNG, judgeScore, findScore), font, brush_OK, ptRate);
                    }
                    else
                    {
                        if (
                            (bretry == true
                            && Global.Mode.ReInspecUse
                            && Global.Retry_Count >= Global.Mode.ReInspecCnt
                            )
                            || Global.Mode.ReInspecUse == false
                            || Global.bSimulation == true
                            )
                        {
                            if (findScore == 0)
                            {
                                g.DrawRectangle(penSearchRegion, searchROI);
                                g.DrawString(GetOptionStr(bResult, "Pattern", judgeNaNG, patternIdx, locationNo, logicName), font_NG, brush_NG, ptRate);
                                ptRate.Y += 25;
                                g.DrawString(GetRateStr(bResult, "Pattern", judgeNaNG, judgeScore, findScore), font_NG, brush_NG, ptRate);

                                g_NG.DrawRectangle(penSearchRegion, searchROI);
                                g_NG.DrawString(GetOptionStr(bResult, "Pattern", judgeNaNG, patternIdx, locationNo, logicName), font_NG, brush_NG, ptRate);
                                ptRate.Y += 25;
                                g_NG.DrawString(GetRateStr(bResult, "Pattern", judgeNaNG, judgeScore, findScore), font_NG, brush_NG, ptRate);
                            }
                            else
                            {
                                g.DrawRectangle(penSearchRegion, searchROI);
                                g.DrawRectangle(penPatternRegion_NG, detectROI);
                                g.DrawString(GetOptionStr(bResult, "Pattern", judgeNaNG, patternIdx, locationNo, logicName), font_NG, brush_NG, ptRate);
                                ptRate.Y += 25;
                                g.DrawString(GetRateStr(bResult, "Pattern", judgeNaNG, judgeScore, findScore), font_NG, brush_NG, ptRate);

                                g_NG.DrawRectangle(penSearchRegion, searchROI);
                                g_NG.DrawRectangle(penPatternRegion_NG, detectROI);
                                g_NG.DrawString(GetOptionStr(bResult, "Pattern", judgeNaNG, patternIdx, locationNo, logicName), font_NG, brush_NG, ptRate);
                                ptRate.Y += 25;
                                g_NG.DrawString(GetRateStr(bResult, "Pattern", judgeNaNG, judgeScore, findScore), font_NG, brush_NG, ptRate);
                                LogicNGCount(arrayNum, locationNo, logicName);
                            }
                        }
                    }
                    //}
                    //else
                    //{
                    //    g.DrawRectangle(penSearchRegion, searchROI);
                    //    g_NG.DrawRectangle(penSearchRegion, searchROI);
                    //    g.DrawString($"{locationNo}-{name}-{patternIdx+1} NotTrain!!!", font_NG, brush_NG, ptRate);
                    //    g_NG.DrawString($"{locationNo}-{name}-{patternIdx+1} NotTrain!!!", font_NG, brush_NG, ptRate);
                    //}

                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        public static void DrawColorEx(Dictionary<string, object> colorExData, int arrayNum)
        {
            try
            {
                Global Global = Global.Instance;
                Graphics g = Graphics.FromImage(Global.ImageResults_array[arrayNum]);
                Graphics g_NG = Graphics.FromImage(Global.ImageNG_array[arrayNum]);
                string locationNo = (string)colorExData["LocationNo"];
                string strColorResult = (string)colorExData["StringColor"];
                bool bResult = (bool)colorExData["Result"];
                Rectangle searchROI = (Rectangle)colorExData["SearchROI"];
                bool bretry = (bool)colorExData["RETRY"];
                string ngReason = (string)colorExData["NGREASON"];
                byte meanR = (byte)colorExData["meanR"];
                byte meanG = (byte)colorExData["meanG"];
                byte meanB = (byte)colorExData["meanB"];
                string logicName = (string)colorExData["Name"];
                // Overlay Draw
                using (System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5))
                using (System.Drawing.Pen pen_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5))
                using (System.Drawing.Pen pen_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 255, 64, 32), 5))
                using (SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16)))
                using (SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(180, 255, 64, 32)))
                using (SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(180, 168, 224, 168)))
                using (System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 168, 224, 168), 10))
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                using (System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                {
                    //searchRect = GetSearchRect(job.nPatternIndex, job);
                    //System.Drawing.Rectangle patternRect = GetPatternRect(job.nPatternIndex, job);

                    System.Drawing.Point ptJudge = new System.Drawing.Point(searchROI.X, searchROI.Y);
                    System.Drawing.Point ptRate = new System.Drawing.Point(searchROI.X, searchROI.Y + 30);
                    ptJudge.Y += searchROI.Height / 4;

                    ptRate = ptJudge;

                    if (Global.Mode.ResultVisible)
                    {
                        //g.DrawString(GetJudgeStr(false, job, str_InspPartName, ""), font_NG, brush_NG, ptRate);
                        //ptRate.Y += 25;
                        //g.DrawString(GetOptionStr(false, job), font_NG, brush_NG, ptRate);
                        //ptRate.Y += 25;
                        //g.DrawString(GetRateStr(false, job, job.dRate), font_NG, brush_NG, ptRate);
                    }
                    if (bResult)
                    {
                        g.DrawRectangle(pen_OK, searchROI);
                        g.DrawString($"OK - {locationNo}", font, brush_OK, searchROI.X + 5, searchROI.Y + 25);
                        g.DrawString($"R:{meanR}, G:{meanG}, B:{meanB}", font, brush_OK, searchROI.X - 10, searchROI.Y + 50);

                    }
                    else
                    {
                        if (
                           (bretry == true
                           && Global.Mode.ReInspecUse
                           && Global.Retry_Count >= Global.Mode.ReInspecCnt
                           )
                           || Global.Mode.ReInspecUse == false
                           || Global.bSimulation == true
                           )
                        {

                            g.DrawString($"NG  - {locationNo}", font, brush_NG, searchROI.X - 10, searchROI.Y + 25);
                            g.DrawString($"R:{meanR}, G:{meanG}, B:{meanB}", font, brush_NG, searchROI.X - 10, searchROI.Y + 50);
                            g.DrawString($"Reason - {ngReason}", font, brush_NG, searchROI.X - 10, searchROI.Y + 75);
                            g.DrawRectangle(pen_NG, searchROI);
                            g_NG.DrawString($"NG  - {locationNo}", font, brush_NG, searchROI.X - 10, searchROI.Y + 25);
                            g_NG.DrawString($"R:{meanR}, G:{meanG}, B:{meanB}", font, brush_NG, searchROI.X - 10, searchROI.Y + 50);
                            g_NG.DrawString($"Reason - {ngReason}", font, brush_NG, searchROI.X - 10, searchROI.Y + 75);
                            g_NG.DrawRectangle(pen_NG, searchROI);
                            LogicNGCount(arrayNum, locationNo, logicName);
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        public static void DrawCondensor(Dictionary<string, object> condensorData, int arrayNum)
        {
            try
            {
                Global Global = Global.Instance;
                Graphics g = Graphics.FromImage(Global.ImageResults_array[arrayNum]);
                Graphics g_NG = Graphics.FromImage(Global.ImageNG_array[arrayNum]);
                string locationNo = (string)condensorData["LocationNo"];
                bool bResult = (bool)condensorData["Result"];
                PointF point1 = (PointF)condensorData["Point1"];
                PointF point2 = (PointF)condensorData["Point2"];
                Rectangle searchROI = (Rectangle)condensorData["SearchROI"];
                Rectangle detectROI = (Rectangle)condensorData["DetectROI"];
                string result_log = (string)condensorData["Log"];
                string result_Value = (string)condensorData["Value"];
                bool bretry = (bool)condensorData["RETRY"];
                string logicName = (string)condensorData["Name"];

                // Overlay Draw
                using (System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5))
                using (System.Drawing.Pen pen_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5))
                using (System.Drawing.Pen pen_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 255, 64, 32), 5))
                using (SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16)))
                using (SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(180, 255, 64, 32)))
                using (SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(180, 168, 224, 168)))
                using (System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 168, 224, 168), 10))
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                using (System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                {
                    //searchRect = GetSearchRect(job.nPatternIndex, job);
                    //System.Drawing.Rectangle patternRect = GetPatternRect(job.nPatternIndex, job);

                    System.Drawing.Point ptJudge = new System.Drawing.Point(searchROI.X, searchROI.Y);
                    System.Drawing.Point ptRate = new System.Drawing.Point(searchROI.X, searchROI.Y + 30);
                    ptJudge.Y += searchROI.Height / 4;

                    ptRate = ptJudge;

                    if (Global.Mode.ResultVisible)
                    {
                        //g.DrawString(GetJudgeStr(false, job, str_InspPartName, ""), font_NG, brush_NG, ptRate);
                        //ptRate.Y += 25;
                        //g.DrawString(GetOptionStr(false, job), font_NG, brush_NG, ptRate);
                        //ptRate.Y += 25;
                        //g.DrawString(GetRateStr(false, job, job.dRate), font_NG, brush_NG, ptRate);
                    }
                    if (bResult)
                    {
                        g.DrawString($"OK - {locationNo}/{logicName}", font, brush_OK, searchROI.X + 5, searchROI.Y + 25);
                        g.DrawString($"{result_Value}", font, brush_OK, searchROI.X - 10, searchROI.Y + 50);
                        g.DrawRectangle(penSearchRegion, searchROI);
                        g.DrawRectangle(pen_OK, detectROI);

                    }
                    else
                    {
                        if (
                           (bretry == true
                           && Global.Mode.ReInspecUse
                           && Global.Retry_Count >= Global.Mode.ReInspecCnt
                           )
                           || Global.Mode.ReInspecUse == false
                           || Global.bSimulation == true
                           )
                        {
                            g.DrawString($"NG - {locationNo}/{logicName}", font, brush_NG, searchROI.X + 5, searchROI.Y + 25);
                            g.DrawString($"{result_log}", font, brush_NG, searchROI.X - 10, searchROI.Y + 50);
                            g.DrawRectangle(penSearchRegion, searchROI);
                            g.DrawRectangle(pen_NG, detectROI);
                            g_NG.DrawString($"NG - {locationNo}/{logicName}", font, brush_NG, searchROI.X + 5, searchROI.Y + 25);
                            g_NG.DrawString($"{result_log}", font, brush_NG, searchROI.X - 10, searchROI.Y + 50);
                            g_NG.DrawRectangle(penSearchRegion, searchROI);
                            g_NG.DrawRectangle(pen_NG, detectROI);
                            LogicNGCount(arrayNum, locationNo, logicName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        public static void DrawPin(Dictionary<string, object> pinData, int arrayNum)
        {
            try
            {
                Global Global = Global.Instance;
                Graphics g = Graphics.FromImage(Global.ImageResults_array[arrayNum]);
                Graphics g_NG = Graphics.FromImage(Global.ImageNG_array[arrayNum]);
                string locationNo = (string)pinData["LocationNo"];
                List<(bool, Rectangle)> result_Rects = (List<(bool, Rectangle)>)pinData["ListPin"];
                bool bResult = (bool)pinData["Result"];
                Rectangle searchROI = (Rectangle)pinData["SearchROI"];
                bool bretry = (bool)pinData["RETRY"];
                string logicName = (string)pinData["Name"];


                // Overlay Draw
                using (System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5))
                using (System.Drawing.Pen pen_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5))
                using (System.Drawing.Pen pen_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 255, 64, 32), 5))
                using (SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16)))
                using (SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(180, 255, 64, 32)))
                using (SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(180, 168, 224, 168)))
                using (System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 168, 224, 168), 10))
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                using (System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                {
                    //searchRect = GetSearchRect(job.nPatternIndex, job);
                    //System.Drawing.Rectangle patternRect = GetPatternRect(job.nPatternIndex, job);

                    System.Drawing.Point ptJudge = new System.Drawing.Point(searchROI.X, searchROI.Y);
                    System.Drawing.Point ptRate = new System.Drawing.Point(searchROI.X, searchROI.Y + 30);
                    ptJudge.Y += searchROI.Height / 4;

                    ptRate = ptJudge;

                    if (Global.Mode.ResultVisible)
                    {
                        //g.DrawString(GetJudgeStr(false, job, str_InspPartName, ""), font_NG, brush_NG, ptRate);
                        //ptRate.Y += 25;
                        //g.DrawString(GetOptionStr(false, job), font_NG, brush_NG, ptRate);
                        //ptRate.Y += 25;
                        //g.DrawString(GetRateStr(false, job, job.dRate), font_NG, brush_NG, ptRate);
                    }
                    if (bResult)
                    {
                        g.DrawString($"OK - {locationNo}/{logicName}", font, brush_OK, ptRate);
                        g.DrawRectangle(pen_OK, searchROI);

                    }
                    else
                    {
                        if (
                           (bretry == true
                           && Global.Mode.ReInspecUse
                           && Global.Retry_Count >= Global.Mode.ReInspecCnt
                           )
                           || Global.Mode.ReInspecUse == false
                           || Global.bSimulation == true
                           )
                        {
                            g.DrawString($"NG - {locationNo}/{logicName}", font_NG, brush_NG, ptRate);
                            g.DrawRectangle(pen_NG, searchROI);
                            g_NG.DrawString($"NG - {locationNo}/{logicName}", font_NG, brush_NG, ptRate);
                            g_NG.DrawRectangle(pen_NG, searchROI);
                            LogicNGCount(arrayNum, locationNo, logicName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        public static void DrawEYED(Dictionary<string, object> eyeDdata, int arrayNum)
        {
            try
            {
                Global Global = Global.Instance;
                Graphics g = Graphics.FromImage(Global.ImageResults_array[arrayNum]);
                Graphics g_NG = Graphics.FromImage(Global.ImageNG_array[arrayNum]);
                string locationNo = (string)eyeDdata["LocationNo"];
                DetectionResultDTO result = (DetectionResultDTO)eyeDdata["ResultData"];
                bool bResult = (bool)eyeDdata["Result"];
                Rectangle searchROI = (Rectangle)eyeDdata["SearchROI"];
                Rectangle specROI = (Rectangle)eyeDdata["SpecROI"];
                bool useSpec = (bool)eyeDdata["UseSpecROI"];
                double specScore = (double)eyeDdata["SpecScore"];
                bool bretry = (bool)eyeDdata["RETRY"];
                int rotateRoi = (int)eyeDdata["Rotate"];
                string logicName = (string)eyeDdata["Name"];
                bool useColorEx = (bool)eyeDdata["UseColorEX"];
                bool Result_ColorEx = (bool)eyeDdata["Result_ColorEx"];
                string NGReason_ColorEx = (string)eyeDdata["NGReason_Color"];
                byte meanR = (byte)eyeDdata["meanR"];
                byte meanG = (byte)eyeDdata["meanG"];
                byte meanB = (byte)eyeDdata["meanB"];

                // Overlay Draw
                using (System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 224, 16), 5))
                using (System.Drawing.Pen pen_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5))
                using (System.Drawing.Pen pen_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 255, 64, 32), 5))
                using (Pen pen_Orange = new Pen(System.Drawing.Color.FromArgb(200, 255, 165, 32), 5))
                using (SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16)))
                using (SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(180, 255, 64, 32)))
                using (SolidBrush brush_ALARM = new SolidBrush(System.Drawing.Color.FromArgb(180, 168, 224, 168)))
                using (System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 168, 224, 168), 10))
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                using (System.Drawing.Font font_NG = new System.Drawing.Font("Arial", 24, FontStyle.Regular))
                {
                    System.Drawing.Point ptJudge = new System.Drawing.Point(searchROI.X, searchROI.Y);
                    System.Drawing.Point ptRate = new System.Drawing.Point(searchROI.X, searchROI.Y + 30);
                    ptJudge.Y += searchROI.Height / 4;

                    ptRate = ptJudge;

                    Cognex.VisionPro.CogRectangle cogSearchRegion = new Cognex.VisionPro.CogRectangle();
                    cogSearchRegion.LineWidthInScreenPixels = 2;
                    if (rotateRoi == 0 || rotateRoi == 180)
                    {
                        cogSearchRegion.X = searchROI.X + result.Box.X;
                        cogSearchRegion.Y = searchROI.Y + result.Box.Y;
                        cogSearchRegion.Width = result.Box.Width;
                        cogSearchRegion.Height = result.Box.Height;
                    }
                    else if (rotateRoi == 90 || rotateRoi == 270)
                    {
                        cogSearchRegion.X = searchROI.X + result.Box.Y;
                        cogSearchRegion.Y = searchROI.Y + result.Box.X;
                        cogSearchRegion.Width = result.Box.Height;
                        cogSearchRegion.Height = result.Box.Width;
                    }
                    Rectangle resultBox = new Rectangle(result.Box.X, result.Box.Y, result.Box.Width, result.Box.Height);
                    Rectangle resultColorBox = new Rectangle(searchROI.X +result.Box.X , searchROI.Y+ result.Box.Y , result.Box.Width/2, result.Box.Height/2);
                    if (specScore <= result.Score)
                    {
                        if (useSpec)
                        {
                            if (specROI.Contains(IF_Util.CeterFromRectangle(CConverter.CogRectToRect(cogSearchRegion))))
                            {
                                if (result.Class != "True" && result.Class != "False")
                                {
                                    g.DrawRectangle(pen_OK, searchROI);
                                    g.DrawPoint(Color.Orange, IF_Util.CeterFromRectangle(specROI).X, IF_Util.CeterFromRectangle(specROI).Y, 5);
                                    g.DrawRectangle(pen_Orange, specROI);
                                    g.DrawString($"OK Model : {result.Class} Score :{result.Score.ToString("F2")}%", font, brush_OK, ptRate);
                                    if (useColorEx)
                                    {
                                        if (Result_ColorEx)
                                        {
                                            g.DrawRectangle(pen_OK, resultColorBox);
                                            ptRate.Y += 25;
                                            g.DrawString($"R:{meanR}, G:{meanG}, B:{meanB}", font, brush_OK, ptRate);

                                        }
                                        else
                                        {
                                            if (
                                               (bretry == true
                                               && Global.Mode.ReInspecUse
                                               && Global.Retry_Count >= Global.Mode.ReInspecCnt
                                               )
                                               || Global.Mode.ReInspecUse == false
                                               || Global.bSimulation == true
                                               )
                                            {
                                                g.DrawRectangle(pen_NG, resultColorBox);
                                                ptRate.Y += 25;
                                                g.DrawString($"R:{meanR}, G:{meanG}, B:{meanB}", font, brush_NG, ptRate);
                                                ptRate.Y += 25;
                                                g.DrawString($"Reason - {NGReason_ColorEx}", font_NG, brush_NG, ptRate);
                                                g_NG.DrawRectangle(pen_NG, resultColorBox);
                                                ptRate.Y += 25;
                                                g_NG.DrawString($"R:{meanR}, G:{meanG}, B:{meanB}", font, brush_NG, ptRate);
                                                ptRate.Y += 25;
                                                g_NG.DrawString($"Reason - {NGReason_ColorEx}", font_NG, brush_NG, ptRate);
                                            }
                                        }
                                    }
                                }
                                else if (result.Class == "True")
                                {
                                    g.DrawRectangle(pen_OK, searchROI);
                                    g.DrawPoint(Color.Orange, IF_Util.CeterFromRectangle(specROI).X, IF_Util.CeterFromRectangle(specROI).Y, 5);
                                    g.DrawRectangle(pen_Orange, specROI);
                                    g.DrawString($"OK Component : {result.Class} Score :{result.Score.ToString("F2")}%", font, brush_OK, ptRate);
                                }
                                else 
                                {
                                   if (
                                   (bretry == true
                                   && Global.Mode.ReInspecUse
                                   && Global.Retry_Count >= Global.Mode.ReInspecCnt
                                   )
                                   || Global.Mode.ReInspecUse == false
                                   || Global.bSimulation == true
                                   )
                                    {
                                        g.DrawRectangle(pen_NG, searchROI);
                                        g.DrawString($"No Component : {result.Class} Score :{result.Score.ToString("F2")}%", font_NG, brush_NG, ptRate);
                                        g_NG.DrawRectangle(pen_NG, searchROI);
                                        g_NG.DrawString($"No Component : {result.Class} Score :{result.Score.ToString("F2")}%", font_NG, brush_NG, ptRate);
                                    }
                                }
                            }
                            else
                            {
                                if (
                                   (bretry == true
                                   && Global.Mode.ReInspecUse
                                   && Global.Retry_Count >= Global.Mode.ReInspecCnt
                                   )
                                   || Global.Mode.ReInspecUse == false
                                   || Global.bSimulation == true
                                   )
                                {
                                    g.DrawPoint(Color.Orange, IF_Util.CeterFromRectangle(specROI).X, IF_Util.CeterFromRectangle(specROI).Y, 5);

                                    g.DrawRectangle(pen_NG, searchROI);
                                    g.DrawRectangle(pen_Orange, specROI);
                                    //g.DrawEllipse(pen_NG, resultBox);
                                    g.DrawString($"NG Model : {result.Class} Score :{result.Score.ToString("F2")}% - (REGION OUT)", font, brush_NG, ptRate);

                                    g_NG.DrawPoint(Color.Orange, IF_Util.CeterFromRectangle(specROI).X, IF_Util.CeterFromRectangle(specROI).Y, 5);
                                    g_NG.DrawRectangle(pen_NG, searchROI);
                                    g_NG.DrawRectangle(pen_Orange, specROI);
                                    //g.DrawEllipse(pen_NG, resultBox);
                                    g_NG.DrawString($"NG Model : {result.Class} Score :{result.Score.ToString("F2")}% - (REGION OUT)", font, brush_NG, ptRate);
                                    LogicNGCount(arrayNum, locationNo, logicName);
                                }
                            }
                        }
                        else
                        {
                            if (result.Class != "True" && result.Class != "False")
                            {
                                g.DrawRectangle(pen_OK, searchROI);
                                g.DrawString($"OK Model : {result.Class} Score :{result.Score.ToString("F2")}%", font, brush_OK, ptRate);
                            }
                            else if (result.Class == "True")
                            {
                                g.DrawRectangle(pen_OK, searchROI);
                                g.DrawPoint(Color.Orange, IF_Util.CeterFromRectangle(specROI).X, IF_Util.CeterFromRectangle(specROI).Y, 5);
                                g.DrawRectangle(pen_Orange, specROI);
                                g.DrawString($"OK Component : {result.Class} Score :{result.Score.ToString("F2")}%", font, brush_OK, ptRate);
                            }
                            else
                            {
                                if (
                                (bretry == true
                                && Global.Mode.ReInspecUse
                                && Global.Retry_Count >= Global.Mode.ReInspecCnt
                                )
                                || Global.Mode.ReInspecUse == false
                                || Global.bSimulation == true
                                )
                                {
                                    g.DrawRectangle(pen_NG, searchROI);
                                    g.DrawString($"No Component : {result.Class} Score :{result.Score.ToString("F2")}%", font_NG, brush_NG, ptRate);
                                    g_NG.DrawRectangle(pen_NG, searchROI);
                                    g_NG.DrawString($"No Component : {result.Class} Score :{result.Score.ToString("F2")}%", font_NG, brush_NG, ptRate);
                                }
                            }
                          
                        }
                    }
                    else
                    {
                        if (
                            (bretry == true
                            && Global.Mode.ReInspecUse
                            && Global.Retry_Count >= Global.Mode.ReInspecCnt
                            )
                            || Global.Mode.ReInspecUse == false
                            || Global.bSimulation == true
                            )
                        {
                            if (useSpec)
                            {
                                g.DrawRectangle(pen_NG, searchROI);
                                g.DrawRectangle(pen_Orange, specROI);
                                g.DrawString($"NG Model : {result.Class} Score :{result.Score.ToString("F2")}% - (LOW Score)", font, brush_NG, ptRate);
                                g_NG.DrawRectangle(pen_NG, searchROI);
                                g_NG.DrawRectangle(pen_Orange, specROI);
                                g_NG.DrawString($"NG Model : {result.Class} Score :{result.Score.ToString("F2")}% - (LOW Score)", font, brush_NG, ptRate);
                                LogicNGCount(arrayNum, locationNo, logicName);
                            }
                            else
                            { 
                                g.DrawRectangle(pen_NG, searchROI);
                                g.DrawString($"NG Model : {result.Class} Score :{result.Score.ToString("F2")}% - (LOW Score)", font, brush_NG, ptRate);
                                g_NG.DrawRectangle(pen_NG, searchROI);
                                g_NG.DrawString($"NG Model : {result.Class} Score :{result.Score.ToString("F2")}% - (LOW Score)", font, brush_NG, ptRate);
                                LogicNGCount(arrayNum, locationNo, logicName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        public static void DrawQRCode(QRParser qrData, int arrayNum)
        {
            try
            { 
            Global Global = Global.Instance;
            Graphics g = Graphics.FromImage(Global.ImageResults_array[arrayNum]);
            Graphics g_NG = Graphics.FromImage(Global.ImageNG_array[arrayNum]);

            // Overlay Draw
            using(System.Drawing.Pen penSearchRegion = new System.Drawing.Pen(Color.Lime, 5))
            using(System.Drawing.Pen pen_OK = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 156, 255, 16), 5))
            using(System.Drawing.Pen pen_NG = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 255, 64, 32), 15))
            using(SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16)))
            using(SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32)))
            using(System.Drawing.Pen penPatternRegion_ALARM = new System.Drawing.Pen(System.Drawing.Color.FromArgb(128, 168, 224, 168), 5))
            using (System.Drawing.Font font_Big = new System.Drawing.Font("Arial", 36, FontStyle.Bold))
            {
                    System.Drawing.Point ptDraw = new System.Drawing.Point();

                    Cognex.VisionPro.CogRectangle rt = Global.Setting.Recipe.Insp.GetQrCogRegion(arrayNum);

                    if (rt != null)
                    {
                        ptDraw.X = (int)Math.Round(rt.CenterX);
                        ptDraw.Y = (int)Math.Round(rt.CenterY);
                        Global.Data.Array_QrCodes[arrayNum].SetPt(ptDraw);
                    }
                    System.Drawing.Point pt1 = qrData.GetPt();
                pt1.Y -= 25;
                System.Drawing.Point pt2 = qrData.GetPt();

                string string1 = $"{qrData.GetPBA()}{qrData.GetModel()}";
                string string2 = $"{qrData.GetVendor()}{qrData.GetYMS()}{qrData.GetSerialNo()}";

                // 여기서 이전 Job의 Rect체크
                SizeF szStr = g.MeasureString(string1, font_Big);
                System.Drawing.Rectangle rctDraw = new System.Drawing.Rectangle(pt1.X, pt1.Y, (int)szStr.Width, (int)szStr.Height + 30);
              
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
                g_NG.DrawRectangle(penSearchRegion, QRDRAW);
                DrawStingCenter($"{string1}", font_Big, brushDraw, pt1, g, g_NG, Global.ImageResults_array[arrayNum].Width);
                DrawStingCenter($"{string2}", font_Big, brushDraw, pt2, g, g_NG, Global.ImageResults_array[arrayNum].Width);

            }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

        }
        public static void DrawStingCenter(string str, System.Drawing.Font font, System.Drawing.Brush brush, System.Drawing.Point ptIn, Graphics g, Graphics g_NG, int Width)
        {
            try
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
                g_NG.DrawString(str, font, brush, ptRet);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        public static void DrawJudge(bool ReultTotal, int arrayNum)
        {
            try
            {
                Global Global = Global.Instance;
                Graphics g = Graphics.FromImage(Global.ImageResults_array[arrayNum]);
                Graphics g_NG = Graphics.FromImage(Global.ImageNG_array[arrayNum]);
                using (SolidBrush brush_OK = new SolidBrush(System.Drawing.Color.FromArgb(128, 156, 255, 16)))
                using (SolidBrush brush_NG = new SolidBrush(System.Drawing.Color.FromArgb(128, 255, 64, 32)))
                {
                    if (ReultTotal)
                    {
                        g.DrawRectangle(new System.Drawing.Pen(brush_OK, 10), new System.Drawing.Rectangle(5, 5, Global.ImageResults_array[arrayNum].Width - 10, Global.ImageResults_array[arrayNum].Height - 10));
                    }
                    else
                    {
                        g.DrawRectangle(new System.Drawing.Pen(brush_NG, 10), new System.Drawing.Rectangle(5, 5, Global.ImageResults_array[arrayNum].Width - 10, Global.ImageResults_array[arrayNum].Height - 10));
                        g_NG.DrawRectangle(new System.Drawing.Pen(brush_NG, 10), new System.Drawing.Rectangle(5, 5, Global.ImageResults_array[arrayNum].Width - 10, Global.ImageResults_array[arrayNum].Height - 10));
                    }
                }
            }
            catch
            { 
            }
        }
        public static string GetOptionStr(bool bOk,string type, bool jugeNaNG,int nPatternIndex,string locationNo,string logicName)
        {
            string strPattern = "";
            String strReturn = "";

            if (type.Contains("Pattern"))
            {
                
                switch (nPatternIndex)
                {
                    case 0:
                        strPattern = "Main";
                        break;

                    default:
                        strPattern = $"Sub{nPatternIndex}";
                        break;
                }
                if (jugeNaNG)
                {
                    strReturn = $"{locationNo}/{logicName}/{strPattern}";
                }
                else
                {
                    strReturn = $"{locationNo}/{logicName}/{strPattern}/NOK";
                }
            }

            return strReturn;
        }

        public static string GetRateStr(bool bOk,string type,bool judgeNaNG,double judgeScore, double dScore)
        {
            String strReturn = "";

            if (type.Contains("Pattern"))
            {
                if ((judgeNaNG && !bOk) || (!judgeNaNG && bOk))
                    strReturn = $"[{judgeScore.ToString("F2")}]>{dScore.ToString("F2")}%";
                else
                    strReturn = $"[{judgeScore.ToString("F2")}]<{dScore.ToString("F2")}%";
            }

            return strReturn;
        }
        public static void LogicNGCount(int arrayNum, string locationNo, string logicName)
        {
            try
            {
                List<NGInfo> list = Global.Instance.System.Recipe.LibraryNGCount.NGCount;
                foreach (NGInfo info in list)
                {
                    if (info.ArrayNum == arrayNum && 
                        info.LocationNo == locationNo &&
                        info.LogicName == logicName)
                    {
                        info.NGCount++;
                        break;
                    }
                    else
                    {
                        NGInfo newInfo = new NGInfo();
                        newInfo.ArrayNum = arrayNum;
                        newInfo.LocationNo = locationNo;
                        newInfo.LogicName = logicName;
                        newInfo.NGCount = 1;
                        list.Add(newInfo);
                    }
                }
                Global.Instance.System.Recipe.LibraryNGCount.NGCount = list;
                IData.bNGCount = true;
            }
            catch (Exception ex)
            {
            }
           
        }
    }
}
