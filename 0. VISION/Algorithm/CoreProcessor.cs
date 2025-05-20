using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Caliper;
using System.Drawing;
using OpenCvSharp.Extensions;
using System.Reflection.PortableExecutable;
using System.Diagnostics;
using log4net.Core;
using IFOnnxRuntime.DTOs;
using IFOnnxRuntime;
using System.Windows.Markup;
using System.Reflection;
using System.Threading;
namespace IntelligentFactory
{
    public static class CoreProcessor
    {
        public static EventHandler<LogicResultData> resultEvent;

        public static void InsPattern(ref Mat matimage, IF_VisionParamObject logicinfo, string locationNo,int arrayIdx, int logicIdx, bool retry)
        {
            LogicResultData Result;
            try
            {
                IF_VisionParam_Matching matching = logicinfo as IF_VisionParam_Matching;
                double dRate = 0.0D;
                int find_PatternIdx = 0;
                CogPMAlignResult result_Pattern = null;
                CogImage8Grey cogImage8 = new CogImage8Grey(matimage.ToBitmap());
                //job.nPatternIndex = 0;
                bool logicResult = true;
                Rectangle detectedRect = new Rectangle();
                Rectangle searchRect = new Rectangle();
                bool bTrained = true;
                Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                for (int nPatternIndex = 0; nPatternIndex < 5; nPatternIndex++)
                {
                    double dToolValue = 0.0;

                    CogPMAlignTool PMAlign = matching.PMAlignTools[nPatternIndex];


                    // 여기 이미지 가공 추가
                    // 여기 이미지 전처리 추가

                    PMAlign.InputImage = cogImage8;

                    if (PMAlign.Pattern.Trained == false)
                    {
                        bTrained = false;
                        continue;
                    }

                    PMAlign.Run();
                    cogSearchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.SearchRegion;
                    searchRect = CVisionCognex.CogRectToRectangle(cogSearchRegion);
                    if (matching.JudgeType_Judge_NaisNg && (PMAlign.Results == null || PMAlign.Results.Count == 0))
                    {
                        //CLogger.Add(LOG_TYPE.ALARM, $"{job.Name} Pattern abNormal !!!!");
                        logicResult = false;
                        continue;
                    }
                    else
                    {
                        CogPMAlignResult result_Best = CVisionCognex.GetBestResult_PMAlign(PMAlign);

                        if (result_Best == null)
                            dToolValue = 0;
                        else
                            dToolValue = result_Best.Score;
                        if (dToolValue > dRate)
                        {
                            dRate = dToolValue;
                            //job.nPatternIndex = nPatternIndex;
                            result_Pattern = result_Best;
                            find_PatternIdx = nPatternIndex;
                        }

                        //NOT OK 는 패턴이 발견되면 NG
                        if (matching.JudgeType_Judge_NaisNg == false)
                        {
                            if (matching.MinimumScore_forJudge < dRate)
                            {
                                logicResult = false;
                            }
                       
                            find_PatternIdx = nPatternIndex;
                            break;
                        }
                        //NOT OK 가 아닐 때에는 패턴이 발견되고 Min Score 보다 높아야 OK
                        else
                        {
                            if (result_Best == null)
                            {
                                logicResult = false;
                            }
                            else
                            {
                                if (dRate > matching.MinimumScore_forJudge)
                                {
                                    logicResult = true;

                                    detectedRect = new Rectangle(
                                            (int)(result_Pattern.GetPose().TranslationX - PMAlign.Pattern.GetTrainedPatternImage().Width / 2)
                                        , (int)(result_Pattern.GetPose().TranslationY - PMAlign.Pattern.GetTrainedPatternImage().Height / 2)
                                        , PMAlign.Pattern.GetTrainedPatternImage().Width
                                        , PMAlign.Pattern.GetTrainedPatternImage().Height);

                                    find_PatternIdx = nPatternIndex;
                                    break;
                                }
                                else
                                {
                                    logicResult = false;

                                }

                            }
                        }
                    }
                }
                //if (!chkPattern(matching))
                //{
                //    //CUtil.ShowMessageBox("Pattenr is None", $"Board-{nArrayIndex} {job.Name} Pattern is None !!!!", FormPopup_MessageBox.MESSAGEBOX_TYPE.OK);
                //    CLogger.Add(LOG.ALARM, $"Board-{arrayIdx} {logicinfo.Name} Pattern is None !!!!");
                //    logicResult = false;
                //}
               
                Dictionary<string,object> data = new Dictionary<string,object>();
                data.Add("LocationNo", locationNo);
                data.Add("Type", logicinfo.Type);
                data.Add("Name", logicinfo.Name);
                data.Add("FindScore", dRate);
                data.Add("JudgeScore", matching.MinimumScore_forJudge);
                data.Add("Result", logicResult);
                data.Add("SearchROI", searchRect);
                data.Add("DetectROI", detectedRect);
                data.Add("PatternIndex", find_PatternIdx);
                data.Add("JudgeNaNG", matching.JudgeType_Judge_NaisNg);
                data.Add("GrabIndex", matching.GrabIndex);
                data.Add("RETRY", retry);
                data.Add("Trained", bTrained);
                Result = new LogicResultData(CoreKey.Pattern, data, arrayIdx);
                resultEvent?.Invoke(null,Result);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                Interlocked.Add(ref Global.logicCount, 1);
            }
        }
        
        public static void InsColorEx(ref Mat matimage, IF_VisionParamObject logicinfo, string locationNo, int arrayIdx, int logicIdx, bool retry)
        {
            bool logicResult = true;       // ok true, ng false
            string ngReason = "";
            LogicResultData Result;
            try
            {
                IF_VisionParam_ColorEx colorEx = logicinfo as IF_VisionParam_ColorEx;
                Scalar scalar = matimage.SubMat(CConverter.RectToCVRect(colorEx.SearchRegion)).Mean();
               
                // 평균 색상 값을 BGR 형식으로 각각 추출
                byte meanB = (byte)scalar.Val0;
                byte meanG = (byte)scalar.Val1;
                byte meanR = (byte)scalar.Val2;
                  
                Color extractColor = Color.FromArgb(meanR, meanG, meanB);
                string colorStr = $"{meanR},{meanG},{meanB}";
                if (colorEx.MasterR - colorEx.RangeMinR <= meanR && meanR <= colorEx.MasterR + colorEx.RangeMaxR
                    && colorEx.MasterG - colorEx.RangeMinG <= meanG && meanG <= colorEx.MasterG + colorEx.RangeMaxG
                    && colorEx.MasterB - colorEx.RangeMinB <= meanB && meanB <= colorEx.MasterB + colorEx.RangeMaxB)
                {
                    if (colorEx.JudgeType_Judge_NaisNg == false)
                    {
                        logicResult = false; 
                        ngReason = "N/A =OK";
                    }
                    else logicResult = true;

                }
                else
                {
                    if (colorEx.JudgeType_Judge_NaisNg == false)
                    {
                        logicResult = true;
                    }
                    else
                    {
                        logicResult = false;
                        if (meanR < colorEx.MasterR - colorEx.RangeMinR || meanR > colorEx.MasterR + colorEx.RangeMaxR) ngReason += "R";
                        if (meanG < colorEx.MasterG - colorEx.RangeMinG || meanR > colorEx.MasterG + colorEx.RangeMaxG) ngReason += "G";
                        if (meanB < colorEx.MasterB - colorEx.RangeMinB || meanR > colorEx.MasterB + colorEx.RangeMaxB) ngReason += "B";
                    } 
                }

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("LocationNo", locationNo);
                data.Add("Type", logicinfo.Type);
                data.Add("Name", logicinfo.Name);
                data.Add("StringColor", colorStr);
                data.Add("Result", logicResult);
                data.Add("SearchROI", colorEx.SearchRegion);
                data.Add("GrabIndex", colorEx.GrabIndex);
                data.Add("RETRY", retry);
                data.Add("NGREASON", ngReason);
                data.Add("meanR", meanR);
                data.Add("meanG", meanG);
                data.Add("meanB", meanB);
                Result = new LogicResultData(CoreKey.ColorEx, data, arrayIdx);
                resultEvent?.Invoke(null, Result);
            }
            
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                Interlocked.Add(ref Global.logicCount, 1);
            }
        }
        public static void InsCondensor(ref Mat matimage, IF_VisionParamObject logicinfo, string locationNo, int arrayIdx, int logicIdx, bool retry)
        {
            LogicResultData Result;
            try
            {
                IF_VisionParam_Condensor condensor = logicinfo as IF_VisionParam_Condensor;
                bool ret = false;       // ok true, ng false
                                        //string ResultTime;
                string log = "";
                Stopwatch tactTime = new Stopwatch();
                tactTime.Start();

                Mat imageSource = matimage.Clone();
                IF_Util.SetImageChannel1(imageSource);

                CogRectangle Find_rect = new CogRectangle();
                string str_value = "";
                double posX = 0;
                double posY = 0;

                condensor.Find_Circle.InputImage = new CogImage8Grey(IF_Util.MatToBmp(imageSource));
                condensor.Find_Circle.Run();

                if (condensor.Find_Circle.Results == null || condensor.Find_Circle.Results.NumPointsFound < condensor.MinFoundCount)
                {
                    CLogger.Add(LOG.ABNORMAL, "Find Circle Results Empty");
                }
                else if (condensor.Find_Circle.Results != null && condensor.Find_Circle.Results.Count > 0)
                {
                    CogCircle resultGraphic = condensor.Find_Circle.Results.GetCircle();

                    if (resultGraphic != null)
                    {
                        Rectangle boundingBox = IF_Util.BondingBox_Circle((int)resultGraphic.CenterX, (int)resultGraphic.CenterY, (int)resultGraphic.Radius, 50);

                        int offsetSize = boundingBox.Width / 2;
                        int offsetWidth = condensor.CondensorRectWidth;
                        int offsetHeight = condensor.CondensorRectHeight;


                        // top to bottom
                        if (condensor.CondensorTypeTB)
                        {
                            CogRectangle meanRectTop = new CogRectangle();
                            meanRectTop.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + offsetSize / 4 - condensor.CondensorRadiusOffset, offsetWidth, offsetHeight);

                            CogRectangle meanRectBtm = new CogRectangle();
                            meanRectBtm.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height - offsetSize / 4 + condensor.CondensorRadiusOffset, offsetWidth, offsetHeight);

                            using (Mat imgOrg = matimage.Clone())
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
                                   log = "Not Find Top";
                                }

                                int b_colstart = rect_bottom.X + rect_bottom.Width;
                                if (imgOrg.Width < b_colstart)
                                {
                                    log = "Not Find Bottom";
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

                                    // OK
                                    if (brightnestKey == condensor.CondensorPolarity)
                                    {
                                        ret = true;
                                    }
                                    // NG
                                    else
                                    {
                                        ret = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            CogRectangle meanRectLeft = new CogRectangle();
                            meanRectLeft.SetCenterWidthHeight(boundingBox.X + offsetSize / 4 - condensor.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                            CogRectangle meanRectRight = new CogRectangle();
                            meanRectRight.SetCenterWidthHeight(boundingBox.X + boundingBox.Width - offsetSize / 4 + condensor.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                            using (Mat imgOrg = matimage.Clone())
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
                                    log = "Not Find Left";
                                }

                                int r_colstart = rect_right.X + rect_right.Width;
                                if (imgOrg.Width < r_colstart)
                                {
                                    log = "Not Find Right";
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
                                    if (brightnestKey == condensor.CondensorPolarity)
                                    {
                                        ret = true;
                                    }
                                    // NG
                                    else
                                    {
                                        ret = false;
                                    }
                                }
                            }
                        }
                      

                    }
                    else
                    {
                        CLogger.Add(LOG.ABNORMAL, "Find Circle Results Empty");
                    }
                }
                else
                {
                    CLogger.Add(LOG.ABNORMAL, "Find Circle Results Empty");
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

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("LocationNo", locationNo);
                data.Add("Type", logicinfo.Type);
                data.Add("Name", logicinfo.Name);
                data.Add("Result", ret);
                data.Add("Point1", point_1);
                data.Add("Point2", point_2);
                data.Add("SearchROI", condensor.SearchRegion);
                data.Add("DetectROI", rect);
                data.Add("Log", log);
                data.Add("Value", str_value);
                data.Add("GrabIndex", condensor.GrabIndex);
                data.Add("RETRY", retry);
                Result = new LogicResultData(CoreKey.Condensor, data, arrayIdx);
                resultEvent?.Invoke(null, Result);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                Interlocked.Add(ref Global.logicCount, 1);
            }
        }
        public static void InsPin(ref Mat matimage, IF_VisionParamObject logicinfo, string locationNo, int arrayIdx, int logicIdx, bool retry)
        {
            List<(bool, Rectangle)> resultRects = new List<(bool, Rectangle)>();
            bool logicResult = false;
            LogicResultData Result;
            try
            {
                IF_VisionParam_Pin pin = logicinfo as IF_VisionParam_Pin;
                using (Mat imgRoi = matimage.SubMat(CConverter.RectToCVRect(pin.SearchRegion)).Clone())
                {
                    List<(Rectangle, int)> rects = CVision.Contour2(imgRoi, pin.Pin_Threshold, pin.Pin_AreaMin, pin.Pin_AreaMax, pin.Pin_BinaryInv);

                    int masterCnt = pin.Pin_Boundaries.Count;
                    int detectCnt = 0;


                    for (int i = 0; i < pin.Pin_Boundaries.Count; i++)
                    {
                        resultRects.Add((false, pin.Pin_Boundaries[i]));
                    }

                    if (rects.Count > 0)
                    {
                        for (int i = 0; i < rects.Count; i++)
                        {


                            for (int compareIdx = 0; compareIdx < resultRects.Count; compareIdx++)
                            {
                                if (resultRects[compareIdx].Item1 == true) continue;

                                if (rects[i].Item1.IntersectsWith(resultRects[compareIdx].Item2))
                                {
                                    resultRects[compareIdx] = (true, resultRects[compareIdx].Item2);
                                    break;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < resultRects.Count; i++)
                    {
                        if (resultRects[i].Item1 == false)
                        {
                            logicResult = false;
                            break;
                        }
                        else
                        {
                            logicResult = true;
                        }
                    }

                }

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("LocationNo", locationNo);
                data.Add("Type", logicinfo.Type);
                data.Add("Name", logicinfo.Name);
                data.Add("ListPin", resultRects);
                data.Add("Result", logicResult);
                data.Add("SearchROI", pin.SearchRegion);
                data.Add("GrabIndex", pin.GrabIndex);
                data.Add("RETRY", retry);
                Result = new LogicResultData(CoreKey.Pin, data, arrayIdx);
                resultEvent?.Invoke(null, Result);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                Interlocked.Add(ref Global.logicCount, 1);
            }
        }
        public static void InsEYED(ref Mat matimage, IF_VisionParamObject logicinfo, string locationNo, int arrayIdx, int logicIdx, bool retry)
        {
            try
            {
                LogicResultData Result;
                Dictionary<string, object> data = new Dictionary<string, object>();
                Dictionary<string, object> data_ColorEx = new Dictionary<string, object>();
                bool totalResult = false;
                bool bResult_Color = true;
                string str_Color_NGReason = "";
                byte nColor_MeanR = 0;
                byte nColor_MeanG = 0;
                byte nColor_MeanB = 0;
                DetectionResultDTO ngResult = new DetectionResultDTO();
                IF_VisionParam_EYED eyeD = logicinfo as IF_VisionParam_EYED;
                using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(matimage.ToBitmap(), eyeD.SearchRegion)).Clone())
                {



                    Mat rotateImage = CVisionTools.RotateImage(imgCrop, eyeD.RotateDgree);
                    List<BaseResultDTO> results = Global.Instance.eyeD.RunModel(eyeD.ModelName, rotateImage, 0.01F);
                    if (results.Count > 0)
                    {
                        if (results[0] is DetectionResultDTO detResult)
                        {
                            Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();
                            cogSearchRegion.LineWidthInScreenPixels = 2;
                            if (eyeD.RotateDgree == 0 || eyeD.RotateDgree == 180)
                            {
                                cogSearchRegion.X = eyeD.SearchRegion.X + detResult.Box.X;
                                cogSearchRegion.Y = eyeD.SearchRegion.Y + detResult.Box.Y;
                                cogSearchRegion.Width = detResult.Box.Width;
                                cogSearchRegion.Height = detResult.Box.Height;
                            }
                            else if (eyeD.RotateDgree == 90 || eyeD.RotateDgree == 270)
                            {
                                cogSearchRegion.X = eyeD.SearchRegion.X + detResult.Box.Y;
                                cogSearchRegion.Y = eyeD.SearchRegion.Y + detResult.Box.X;
                                cogSearchRegion.Width = detResult.Box.Height;
                                cogSearchRegion.Height = detResult.Box.Width;
                            }
                            if (eyeD.Score <= detResult.Score)
                            {
                                if (eyeD.UseSpecRegion)
                                {
                                    if (eyeD.SpecRegion.Contains(IF_Util.CeterFromRectangle(CConverter.CogRectToRect(cogSearchRegion))))
                                    {
                                        if (detResult.Class != "True" && detResult.Class != "False")
                                        {
                                            if (eyeD.UseColorExRegion == false)
                                            {
                                                totalResult = true;
                                            }
                                            else
                                            {
                                               

                                                data_ColorEx = InsEYED_ColorEx(ref rotateImage, eyeD, detResult);
                                                str_Color_NGReason = (string)data_ColorEx["NGREASON"];
                                                nColor_MeanR = (byte)data_ColorEx["meanR"];
                                                nColor_MeanG = (byte)data_ColorEx["meanG"];
                                                nColor_MeanB = (byte)data_ColorEx["meanB"];
                                                bResult_Color = (bool)data_ColorEx["Result"];
                                                
                                                if (bResult_Color == false)
                                                {
                                                    totalResult = false;
                                                }
                                                else
                                                {
                                                    totalResult = true;
                                                }
                                            }
                                           
                                        }
                                        else if (detResult.Class == "True")
                                        {
                                            totalResult = true;
                                        }
                                        else
                                        { 
                                            totalResult = false;
                                        }
                                    }
                                    else
                                    {
                                       totalResult = false;
                                    }
                                }
                                else
                                {
                                    if (detResult.Class == "False")
                                    {
                                        totalResult = false;
                                    }
                                    else
                                    {
                                        totalResult = true;
                                    }
                                }
                            }
                            else
                            {
                                totalResult = false;
                            }
                            data.Add("ResultData", detResult);
                            data.Add("Result", totalResult);
                        }
                    }
                    else
                    {
                        ngResult.Box = (0,0,1,1);
                        data.Add("ResultData", ngResult);
                        data.Add("Result", totalResult);
                    }
                    data.Add("Result_ColorEx", bResult_Color);
                    data.Add("NGReason_Color", str_Color_NGReason);
                    data.Add("meanR", nColor_MeanR);
                    data.Add("meanG", nColor_MeanG);
                    data.Add("meanB", nColor_MeanB);
                    data.Add("UseColorEX", eyeD.UseColorExRegion);
                    data.Add("LocationNo", locationNo);
                    data.Add("Type", logicinfo.Type);
                    data.Add("Name", logicinfo.Name);
                    data.Add("SearchROI", eyeD.SearchRegion);
                    data.Add("SpecROI", eyeD.SpecRegion);
                    data.Add("UseSpecROI", eyeD.UseSpecRegion);
                    data.Add("SpecScore", eyeD.Score);
                    data.Add("GrabIndex", eyeD.GrabIndex);
                    data.Add("RETRY", retry);
                    data.Add("Rotate", eyeD.RotateDgree);
                    Result = new LogicResultData(CoreKey.EYED, data, arrayIdx);
                    resultEvent?.Invoke(null, Result);
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                Interlocked.Add(ref Global.logicCount, 1);
            }
        }
        public static bool chkPattern(IF_VisionParam_Matching matching)
        {
            bool bOK = true;
            int nLastPtn = GetLastPattern(matching);

            for (int i = 0; i < nLastPtn; i++)
                bOK = bOK & isPatternImg(i, matching);

            return bOK;
        }

        public static int GetLastPattern(IF_VisionParam_Matching matching)
        {
            int nLastPattern = -1;

            if (matching.PMAlignTools[4].Pattern.Trained)
                nLastPattern = 4;
            else if (matching.PMAlignTools[3].Pattern.Trained)
                nLastPattern = 3;
            else if (matching.PMAlignTools[2].Pattern.Trained)
                nLastPattern = 2;
            else if (matching.PMAlignTools[1].Pattern.Trained)
                nLastPattern = 1;
            else if (matching.PMAlignTools[0].Pattern.Trained)
                nLastPattern = 0;

            return nLastPattern;
        }

        public static bool isPatternImg(int nToolNo, IF_VisionParam_Matching matching)
        {
            bool bRet = false;
            switch (nToolNo)
            {
                case 4:
                    if (matching.PMAlignTools[4].Pattern.Trained)
                        bRet = true;
                    break;

                case 3:
                    if (matching.PMAlignTools[3].Pattern.Trained)
                        bRet = true;
                    break;

                case 2:
                    if (matching.PMAlignTools[2].Pattern.Trained)
                        bRet = true;
                    break;

                case 1:
                    if (matching.PMAlignTools[1].Pattern.Trained)
                        bRet = true;
                    break;

                case 0:
                    if (matching.PMAlignTools[0].Pattern.Trained)
                        bRet = true;
                    break;
            }
            return bRet;
        }

        public static Dictionary<string, object> InsEYED_ColorEx(ref Mat matimage, IF_VisionParamObject logicinfo, DetectionResultDTO resultDTO)
        {
            bool logicResult = true;       // ok true, ng false
            string ngReason = "";
            Dictionary<string, object> data = new Dictionary<string, object>();

            try
            {
                IF_VisionParam_EYED eyeD_colorEx = logicinfo as IF_VisionParam_EYED;
                Scalar scalar = matimage.SubMat(CConverter.RectToCVRect(new Rectangle(eyeD_colorEx.SearchRegion.X + resultDTO.Box.X , eyeD_colorEx.SearchRegion.Y + resultDTO.Box.Y,
                    (resultDTO.Box.Width / 2), (resultDTO.Box.Height / 2)))).Mean(); // colorExRegion -> Result Box 가져오기

                // 평균 색상 값을 BGR 형식으로 각각 추출
                byte meanB = (byte)scalar.Val0;
                byte meanG = (byte)scalar.Val1;
                byte meanR = (byte)scalar.Val2;

                Color extractColor = Color.FromArgb(meanR, meanG, meanB);
                string colorStr = $"{meanR},{meanG},{meanB}";
                if (eyeD_colorEx.MasterR - eyeD_colorEx.Range <= meanR && meanR <= eyeD_colorEx.MasterR + eyeD_colorEx.Range
                    && eyeD_colorEx.MasterG - eyeD_colorEx.Range <= meanG && meanG <= eyeD_colorEx.MasterG + eyeD_colorEx.Range
                    && eyeD_colorEx.MasterB - eyeD_colorEx.Range <= meanB && meanB <= eyeD_colorEx.MasterB + eyeD_colorEx.Range)
                {
                   logicResult = true;

                }
                else
                {
                    logicResult = false;
                    if (meanR < eyeD_colorEx.MasterR - eyeD_colorEx.Range || meanR > eyeD_colorEx.MasterR + eyeD_colorEx.Range) ngReason += "R";
                    if (meanG < eyeD_colorEx.MasterG - eyeD_colorEx.Range || meanG > eyeD_colorEx.MasterG + eyeD_colorEx.Range) ngReason += "G";
                    if (meanB < eyeD_colorEx.MasterB - eyeD_colorEx.Range || meanB > eyeD_colorEx.MasterB + eyeD_colorEx.Range) ngReason += "B";
                }

                // 결과값 넘겨야함
                data.Add("Result", logicResult);
                data.Add("NGREASON", ngReason);
                data.Add("meanR", meanR);
                data.Add("meanG", meanG);
                data.Add("meanB", meanB);

                return data;
                //data.Add("LocationNo", locationNo);
                //data.Add("Type", logicinfo.Type);
                //data.Add("Name", logicinfo.Name);
                //data.Add("StringColor", colorStr);
                //data.Add("SearchROI", colorEx.SearchRegion);
                //data.Add("GrabIndex", colorEx.GrabIndex);
                //data.Add("RETRY", retry);
                //Result = new LogicResultData(CoreKey.ColorEx, data, arrayIdx);
                //resultEvent?.Invoke(null, Result);
            }

            catch (Exception ex)
            {
                data.Add("Result", false);
                data.Add("NGREASON", "Exception");
                return data;
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                Interlocked.Add(ref Global.logicCount, 1);
            }
        }
    }
}
