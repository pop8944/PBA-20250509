using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro;
using System.Drawing;
using OpenCvSharp;
using System.Reflection;
using Sunny.UI;
using System.Data.SqlClient;
using Vila.Extensions;
using IntelligentFactory._0._VISION.Algorithm;
using static Sunny.UI.Net;
using OpenCvSharp.Extensions;
using System.Windows.Markup;
using System.IO;
using Vila.Threading.Performance;
using OfficeOpenXml.FormulaParsing.Ranges;
using System.Threading;
using static IntelligentFactory.Global;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI.WebControls.WebParts;
using log4net.Core;
using System.Web.UI.WebControls;
namespace IntelligentFactory
{
    public class CInspector
    {

        public Global Global = Global.Instance;
        public bool isError_Fiducial = false;
        public Point2d posFiducial_Board = new Point2d();
        public bool jobsReultTotal = true;
        public QRParser cQrCode;
        public bool ResultAll = false;
        public string OK_Path = "";
        public string NG_Path = "";
        public string imgPath_Ovl = "";
        public string imgPath_Array = "";
        public string imgPath_Ori = "";
        public string imgPath_OnlyNG = "";
        public DateTime curTm;

        public bool Execute(Stopwatch cycleTime, bool retry, CogImage24PlanarColor[] images)
        {

            bool qrResult = true;
            bool totalresult = false;
            CogImage24PlanarColor[][] result_crop = new CogImage24PlanarColor[Global.System.Recipe.ArrayCount][];
            Stopwatch _stopwatch = new Stopwatch();

            CogImage24PlanarColor[] imgResultsDrawing = new CogImage24PlanarColor[images.Length];
            CogImage24PlanarColor[][] imgResult = new CogImage24PlanarColor[Global.System.Recipe.ArrayCount][];

            if (images == null)
            {
                IF_Util.ShowMessageBox("EXCEPTION", "Image Buffer Empty");
                return totalresult;
            }
            else
            {
                if (images[0] == null)
                {
                    IF_Util.ShowMessageBox("EXCEPTION", $"Image Buffer[0] Empty. lease Grab or Load !!!");
                    return totalresult;
                }
            }
            for (int i = 0; i < Global.System.Recipe.ArrayCount; i++)
            {
                FiducialRun(images, i, out result_crop[i]); // 피듀셜 배열 자르기
                imgResult[i] = result_crop[i];
            }
            curTm = DateTime.Now;

            if (retry == false)
            {
                for (int i = 0; i < Global.System.Recipe.ArrayCount; i++)
                {
                    Global.Data.Array_QrCodes[i] = new QRParser();
                    QRFind(result_crop[i], i, out qrResult);  // 배열 자른 이미지로 QR 검사
                    Global.Crop_Images[i] = result_crop[i];
                    imgResultsDrawing[i] = new CogImage24PlanarColor(result_crop[i][0]); // 결과 처리용 뒤에 배열 Setting 으로 뺄것 (0~4) 사용자 선택가능
                    Global.ImageResults_array[i] = imgResultsDrawing[i].ToBitmap();
                    Global.ImageNG_array[i] = imgResultsDrawing[i].ToBitmap();
                    for (int j = 0; j < 3; j++)
                    {
                        Global.ImageOrigin_array[i][j] = result_crop[i][j].ToBitmap();
                    }
                    if (qrResult == false)
                    {
                        return totalresult;
                    }
                    else
                    {

                        LogicResultDraw.DrawQRCode(Global.Data.Array_QrCodes[i], i);
                    }
                }
            }

            _stopwatch.Start();

            for (int i = 0; i < Global.System.Recipe.ArrayCount; i++)
            {
                int index = i;
                Task.Run(() => Inspect(Global.System.Recipe.LibraryManager, imgResult[index], index, retry));
                //Inspect(Global.System.Recipe.LibraryManager, imgResult[index], index, retry);
            }

            CLogger.Add(LOG.SEQ, $"SEQ T/T : [{_stopwatch.ElapsedMilliseconds:D4} ms] ==> Core Inspection Start");
            totalresult = true;



            // NG 발생된 제품 리트라이 검사 만들어 줘야함!
            //if (Global.Mode.ReInspecUse)
            //{
            //    if (retry == true && retryIndex < Global.Mode.ReInspecCnt)
            //    {
            //        return totalResults;
            //    }
            //}
            // 이미지 저장 및 DBWrite Retry 끝나고 처리할 것

            return totalresult;

        }
        private void FiducialRun(CogImage24PlanarColor[] fiducial_images, int arrayIndex, out CogImage24PlanarColor[] crop_images)
        {
            try
            {

                crop_images = new CogImage24PlanarColor[fiducial_images.Length];
                Stopwatch tactTime = new Stopwatch();
                tactTime.Start();
                CTemplateMatching matchingLT = new CTemplateMatching("LT");
                CTemplateMatching matchingRB = new CTemplateMatching("RB");

                using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(fiducial_images[0].ToBitmap()).Clone())
                {
                    List<double> rotateCycle = new List<double>();

                    for (int rotIdx = 0; rotIdx < 3; rotIdx++)
                    {
                        matchingLT.SetSourceImage(imgOrg);
                        matchingRB.SetSourceImage(imgOrg);

                        matchingLT.Run(Global.System.Recipe.FiducialLibrary.Fiducial1);

                        Point2d posLT = new Point2d(0, 0);
                        Point2d posRB = new Point2d(0, 0);

                        Rect rectLT = new Rect();
                        Rect rectRB = new Rect();


                        if (matchingLT.Results.Count == 0)
                        {
                            CLogger.Add(LOG.ABNORMAL, $"Can't Find the Mark of Fiducial ==> LT");
                            isError_Fiducial = true;
                            break;
                        }
                        if (matchingRB.Results.Count == 0)
                        {
                            CLogger.Add(LOG.ABNORMAL, $"Can't Find the Mark of Fiducial ==> RB");

                            isError_Fiducial = true;
                            break;
                        }

                        if (isError_Fiducial == false)
                        {
                            posLT = matchingLT.Results[0].Center;
                            posRB = matchingRB.Results[0].Center;

                            rectLT = matchingLT.Results[0].Bounding;
                            rectRB = matchingRB.Results[0].Bounding;

                            double angle = IF_Util.GetAngle(posLT, posRB);
                            double angleDelta = angle - Global.System.Recipe.FiducialLibrary.MasterAngle;

                            Point2f posCenter = new Point2f(imgOrg.Width / 2, imgOrg.Height / 2);

                            if (Math.Abs(angleDelta) < 0.03)
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
                                if (rotateCycle.Count == 3)
                                {
                                    matchingLT.Run(Global.System.Recipe.FiducialLibrary.Fiducial1);
                                    posFiducial_Board = matchingLT.Results[0].Center;
                                }
                            }
                        }

                    }

                    for (int rotIdx = 0; rotIdx < rotateCycle.Count; rotIdx++)
                    {
                        for (int i = 0; i < fiducial_images.Length; i++)
                        {
                            if (fiducial_images[i] != null && fiducial_images[i].Allocated)
                            {
                                using (Mat imgSrcforRot = OpenCvSharp.Extensions.BitmapConverter.ToMat(fiducial_images[i].ToBitmap()))
                                using (Mat imgRot = new Mat())
                                {
                                    Point2f posCenter = new Point2f(imgOrg.Width / 2, imgOrg.Height / 2);

                                    Mat rotationMatrix = Cv2.GetRotationMatrix2D(posCenter, rotateCycle[rotIdx], 1.0);
                                    Cv2.WarpAffine(imgSrcforRot, imgRot, rotationMatrix, imgSrcforRot.Size());

                                    fiducial_images[i] = new CogImage24PlanarColor(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgRot));
                                }
                            }
                        }
                    }
                }

                Rectangle region = Global.System.Recipe.FiducialLibrary.GetArrayRegion(arrayIndex);
                Rectangle cutRegion = new Rectangle();
                Rectangle orgRegion = new Rectangle();

                if (arrayIndex == 0) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray1.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray1.Y), region.Width, region.Height);
                if (arrayIndex == 1) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray2.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray2.Y), region.Width, region.Height);
                if (arrayIndex == 2) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray3.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray3.Y), region.Width, region.Height);
                if (arrayIndex == 3) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray4.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray4.Y), region.Width, region.Height);
                if (arrayIndex == 4) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray5.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray5.Y), region.Width, region.Height);
                if (arrayIndex == 5) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray6.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray6.Y), region.Width, region.Height);
                if (arrayIndex == 6) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray7.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray7.Y), region.Width, region.Height);
                if (arrayIndex == 7) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray8.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray8.Y), region.Width, region.Height);
                if (arrayIndex == 8) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray9.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray9.Y), region.Width, region.Height);
                if (arrayIndex == 9) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray10.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray10.Y), region.Width, region.Height);
                if (arrayIndex == 10) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray11.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray11.Y), region.Width, region.Height);
                if (arrayIndex == 11) cutRegion = new Rectangle((int)(posFiducial_Board.X - Global.System.Recipe.FiducialLibrary.OffsetArray12.X), (int)(posFiducial_Board.Y - Global.System.Recipe.FiducialLibrary.OffsetArray12.Y), region.Width, region.Height);

                if (arrayIndex == 0) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray1;
                if (arrayIndex == 1) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray2;
                if (arrayIndex == 2) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray3;
                if (arrayIndex == 3) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray4;
                if (arrayIndex == 4) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray5;
                if (arrayIndex == 5) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray6;
                if (arrayIndex == 6) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray7;
                if (arrayIndex == 7) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray8;
                if (arrayIndex == 8) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray9;
                if (arrayIndex == 9) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray10;
                if (arrayIndex == 10) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray11;
                if (arrayIndex == 11) orgRegion = Global.System.Recipe.FiducialLibrary.RegionArray12;

                if (cutRegion.Width == 0 || cutRegion.Height == 0) { CAlarm.Add("Error", $"Cut region Failed... Array [{arrayIndex}]"); }

                #region 그랩인덱스 별 이미지 할당
                CLogger.Add(LOG.SEQ, $"SEQ T/T : [{tactTime.ElapsedMilliseconds:D4} ms] ==> Allocated images Start");
                for (int i = 0; i < fiducial_images.Length; i++)
                {
                    if (fiducial_images[i] != null && fiducial_images[i].Allocated)
                    {
                        if (isError_Fiducial)
                        {
                            using (Bitmap imgCrop = IF_Util.Crop(fiducial_images[i].ToBitmap(), orgRegion))
                            {
                                crop_images[i] = new CogImage24PlanarColor(imgCrop);

                            }
                        }
                        else
                        {
                            using (Bitmap imgCrop = IF_Util.Crop(fiducial_images[i].ToBitmap(), cutRegion))
                            {
                                crop_images[i] = new CogImage24PlanarColor(imgCrop);

                            }
                        }
                    }
                }

                DateTime curTm = DateTime.Now;

                CLogger.Add(LOG.SEQ, $"SEQ T/T : [{tactTime.ElapsedMilliseconds:D4} ms] ==> Allocated images Complete");

                //결과 표시용은 0번 그랩 이미지로 사용
                //imgResultsDrawing[arrayIdx] = new CogImage24PlanarColor(images24_board[0]);
                #endregion
                //EYE-D OBB, Distance 용
                //#region 얼라인 후 이미지 크롭 및 연배 내 피듀셜 마크 측정
                // Mat images_cv = new Mat();
                //CTemplateMatching matchingArrayFiducial = new CTemplateMatching("LT");
                //images_cv = OpenCvSharp.Extensions.BitmapConverter.ToMat((crop_images[0]).ToBitmap()).Clone();

                //matchingArrayFiducial.SetSourceImage(images_cv);

                //    if (arrayIndex == 0) matchingArrayFiducial.Run(Global.System.Recipe.FiducialLibrary.Fiducial1, new Rect((int)Global.System.Recipe.FiducialLibrary.OffsetArray1.X - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width / 2, (int)Global.System.Recipe.FiducialLibrary.OffsetArray1.Y - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height / 2, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height));
                //    if (arrayIndex == 1) matchingArrayFiducial.Run(Global.System.Recipe.FiducialLibrary.Fiducial1, new Rect((int)Global.System.Recipe.FiducialLibrary.OffsetArray2.X - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width / 2, (int)Global.System.Recipe.FiducialLibrary.OffsetArray2.Y - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height / 2, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height));
                //    if (arrayIndex == 2) matchingArrayFiducial.Run(Global.System.Recipe.FiducialLibrary.Fiducial1, new Rect((int)Global.System.Recipe.FiducialLibrary.OffsetArray3.X - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width / 2, (int)Global.System.Recipe.FiducialLibrary.OffsetArray3.Y - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height / 2, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height));
                //    if (arrayIndex == 3) matchingArrayFiducial.Run(Global.System.Recipe.FiducialLibrary.Fiducial1, new Rect((int)Global.System.Recipe.FiducialLibrary.OffsetArray4.X - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width / 2, (int)Global.System.Recipe.FiducialLibrary.OffsetArray4.Y - Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height / 2, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Width, Global.System.Recipe.FiducialLibrary.Fiducial1.SearchRoi.Height));

                //    Point2d posFiducial_Array = new Point2d();

                //    if (matchingArrayFiducial.Results.Count == 0)
                //    {
                //        //2024.07.24 : 송현수 : 피듀셜 못찾았을 경우 디펄트 영역으로 검출
                //        CLogger.Add(LOG.ABNORMAL, $"Can't Find the Mark of Fiducial, then Applied the Region of Default");
                //        //CAlarm.Add("Error", $"Can't Find the Mark of Fiducial Array [{arrayIdx}]"); 
                //    }
                //    else
                //    {
                //        posFiducial_Array = matchingArrayFiducial.Results[0].Center;
                //    }
                //    #endregion
                //CLogger.Add(LOG.INSP, $"Image Align T/T : {tactTime.ElapsedMilliseconds}ms");

            }
            catch (Exception ex)
            {
                crop_images = new CogImage24PlanarColor[fiducial_images.Length];
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        private void QRFind(CogImage24PlanarColor[] images, int arrayIdx, out bool qrResult)
        {
            qrResult = true;
            QRParser cQrCode = new QRParser();
            CogImage8Grey[] images8_board = new CogImage8Grey[images.Length];
            try
            {
                for (int i = 0; i < images8_board.Length; i++)
                {
                    images8_board[i] = new CogImage8Grey(images[i].ToBitmap());
                }
                if (Global.Mode.QrPass)
                {
                    //cQrCode = new QRParser($"06{Global.Instance.System.Recipe.CODE.Substring(0, 4) + Global.Instance.System.Recipe.CODE.Substring(5, 6)}VENDYMSE{nQRError.ToString("D3")}", true);
                    cQrCode = new QRParser($"06{Global.Instance.System.Recipe.CODE.Substring(0, 4) + Global.Instance.System.Recipe.CODE.Substring(5, 6)}VENDYMSE0", true);
                    Global.Instance.Data.Array_QrCodes[arrayIdx] = cQrCode;
                }
                else
                {
                    string qrCode = "";
                    for (int i = 0; i < images8_board.Length; i++)
                    {
                        if (images8_board[i] == null) continue;

                        if (images8_board[i] != null & images8_board[i].Allocated)
                        {
                            cQrCode = new QRParser($"06{Global.Instance.System.Recipe.CODE.Substring(0, 4) + Global.Instance.System.Recipe.CODE.Substring(5, 6)}VENDYMSE0", true);
                            Global.Instance.Data.Array_QrCodes[arrayIdx] = cQrCode;

                            if (qrCode != "")
                            {
                                qrResult = true; 
                                break;
                            } 
                        }
                    }
                    if (qrCode == "")
                    {
                        if (isError_Fiducial)
                        {
                            CAlarm.Add("ALARM", $"Can't Find the Fiducial Mark ==> Array {arrayIdx + 1}");
                        }
                        else
                        {
                            CAlarm.Add("ALARM", $"Can't Read the QR Code ==> Array {arrayIdx + 1}");
                        }


                        jobsReultTotal = false;

                        string tempQrCode = "00" + Global.Instance.System.Recipe.Name + DateTime.Now.ToString("MMdd_HHmmss");
                        cQrCode = new QRParser(tempQrCode, true);
                        Global.Instance.Data.Array_QrCodes[arrayIdx] = cQrCode;

                        qrResult = false;
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
                                CAlarm.Add("ALARM", $"QR Code Model Verify Fail ==> Array {arrayIdx + 1}");
                                CLogger.Add(LOG.EXCEPTION, $"NG ==> Qr[{cQrCode.GetQR()}] - Model[{Global.Instance.System.Recipe.Name}] Mapping NG ");
                                jobsReultTotal = false;
                                cQrCode.SetQRError(true);
                                Global.Instance.Data.Array_QrCodes[arrayIdx].SetQRError(true);

                                qrResult = false;
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

                                qrResult = false;
                            }
                        }
                    }

                    //if (manualMode) qrResult = true;
                }
            }
            catch
            {
                qrResult = false;
            }
        }

        private void Inspect(LibraryManager library, CogImage24PlanarColor[] images, int arrayIdx, bool retry)
        {
            try
            {
                if (library.Library.TryGetValue(arrayIdx + 1, out var partList) && partList.Count > 0)
                {
                    if (retry == false)
                    {
                        foreach (var part in partList)
                        {
                            if(part.Enabled) LogicsRun(part, images, arrayIdx, retry);
                        }
                    }
                    else
                    {
                        foreach (var part in partList)
                        {
                            var logicNGList = Global.Retry_ArrayList[arrayIdx];

                            foreach (var logicNGData in logicNGList)
                            {
                                var dataDictionary = logicNGData.NG_data;

                                if (dataDictionary.TryGetValue("LocationNo", out var locationNoObj))
                                {
                                    string ngLocationNo = locationNoObj?.ToString();

                                    if (part.LocationNo == ngLocationNo)
                                    {
                                        if (part.Enabled) LogicsRun(part, images, arrayIdx, retry);
                                    }
                                }
                                
                            }
                        }
                    }
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Inspect 예외 발생: {ex.Message}");
            }
        }
        private void LogicsRun(IF_VisionLogicInfo logics, CogImage24PlanarColor[] images, int arrayIdx, bool retry)
        {
            try
            {
                Mat[] images_cv = new Mat[images.Length];
                int LoigcCount = logics.Logics.Count;
                for (int i = 0; i < images.Length; i++)
                {
                    images_cv[i] = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[i].ToBitmap());
                }

                //if (retry == false)
                //{
                for (int i = 0; i < logics.Logics.Count; i++)
                {
                    if (logics.Logics[i].Enabled) LogicRun(logics.Logics[i], images_cv, logics.LocationNo, arrayIdx, i, retry);

                }
                 
                //}
                //else
                //{
                //    // LogicRun 도 Retry 확인해서 나눠줄지 고민 해봐야할듯 (Logics 안에 여러개가 NG 발생될 수도 있기때문)
                //}
                //Dispose
                for (int i = 0; i < images.Length; i++)
                {
                    images_cv[i].Dispose();
                }
            }
            catch
            {
            }

        }
        private void LogicRun(IF_VisionParamObject logic, Mat[] images, string locationNo, int arrayIdx, int logicIdx, bool retry)
        {
            try
            {

                if (logic.ImgProcessingList.Count > 0)
                {
                    images[logic.GrabIndex] = PreProcessor.ExecutePreProcessing(images[logic.GrabIndex], logic);
                }

                switch (logic.Type)
                {
                    case "Pattern":
                        CoreProcessor.InsPattern(ref images[logic.GrabIndex], logic, locationNo, arrayIdx, logicIdx, retry);
                        break;
                    case "EYE-D":
                        CoreProcessor.InsEYED(ref images[logic.GrabIndex], logic, locationNo, arrayIdx, logicIdx, retry);
                        break;
                    case "ColorEx":
                        CoreProcessor.InsColorEx(ref images[logic.GrabIndex], logic, locationNo, arrayIdx, logicIdx, retry);
                        break;
                    case "Condensor":
                        CoreProcessor.InsCondensor(ref images[logic.GrabIndex], logic, locationNo, arrayIdx, logicIdx, retry);
                        break;
                    case "Pin":
                        CoreProcessor.InsPin(ref images[logic.GrabIndex], logic, locationNo, arrayIdx, logicIdx, retry);
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                Interlocked.Add(ref Global.logicCount, 1);
            }
        }

        private (string, string) InitDirectory_DateTime_ID(bool jude, string strDirPath, int arrayIdx, bool bAuto = true)
        {

            string path_OK = "";
            string path_NG = "";
            // 폴더 생성 처리 다시진행
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


            path_OK = OK_Path = $"{path}\\OK\\{Global.Instance.Data.Array_QrCodes[arrayIdx].GetQR()}";
            path_NG = NG_Path = $"{path}\\NG\\{Global.Instance.Data.Array_QrCodes[arrayIdx].GetQR()}";

            path_OK = $"{path}\\OK\\{Global.Instance.Data.Array_QrCodes[arrayIdx].GetQR()}";
            path_NG = $"{path}\\NG\\{Global.Instance.Data.Array_QrCodes[arrayIdx].GetQR()}";

            if (jude)
            {
                // 해당 폴더가 없을 경우 폴더 생성
                if (!Directory.Exists($"{path_OK}\\Part")) Directory.CreateDirectory($"{path_OK}\\Part");
            }
            else
            {
                // 해당 폴더가 없을 경우 폴더 생성
                if (!Directory.Exists($"{path_NG}\\Part")) Directory.CreateDirectory($"{path_NG}\\Part");
                // 해당 폴더가 없을 경우 폴더 생성
                if (!Directory.Exists($"{path_NG}\\Crop")) Directory.CreateDirectory($"{path_NG}\\Crop");
            }

            return (path_OK, path_NG);
        }
        private void ImageSaveAll((string, string) path, int arrayIdx, bool result,CogImage24PlanarColor[] images,out StringBuilder imgSaveLog)
        {
            imgSaveLog = new StringBuilder();
            Stopwatch tt_imgSave = Stopwatch.StartNew();
            Mat imgTotal = OpenCvSharp.Extensions.BitmapConverter.ToMat(Global.ImageResults_array[arrayIdx]);
            Mat imgOnlyNG = OpenCvSharp.Extensions.BitmapConverter.ToMat(Global.ImageNG_array[arrayIdx]);
            Mat[] imgOri =
                {
                BitmapConverter.ToMat(Global.ImageOrigin_array[arrayIdx][0]),
                BitmapConverter.ToMat(Global.ImageOrigin_array[arrayIdx][1]),
                BitmapConverter.ToMat(Global.ImageOrigin_array[arrayIdx][2]),
                };

            string sCurTm = curTm.ToString("yyMMdd_HHmmss");
            imgPath_OnlyNG = $"{path.Item2}\\{Global.Data.Array_QrCodes[arrayIdx].GetQR()}_{sCurTm}_NG.jpg";
            if (result)
            {
                imgPath_Ovl = $"{path.Item1}\\{Global.Data.Array_QrCodes[arrayIdx].GetQR()}_{sCurTm}_OVL.jpg";
                imgPath_Array = $"{path.Item1}\\{Global.Data.Array_QrCodes[arrayIdx].GetQR()}_{sCurTm}_BD{arrayIdx}_ORI_GRABINDEX.jpg";
                imgPath_Ori = $"{path.Item1}\\{Global.Data.Array_QrCodes[arrayIdx].GetQR()}_{sCurTm}_ORI.jpg";
                imgOri[0].SaveImage(imgPath_Ori); //해당 이미지 아닌것 같음. origin img 맞춰 넣어야함.
                imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] OK Image Save Origin \n");
            }
            else
            {
                imgPath_Ovl = $"{path.Item2}\\{Global.Data.Array_QrCodes[arrayIdx].GetQR()}_{sCurTm}_OVL.jpg";
                imgPath_Array = $"{path.Item2}\\{Global.Data.Array_QrCodes[arrayIdx].GetQR()}_{sCurTm}_BD{arrayIdx}_ORI_GRABINDEX.jpg";
                for (int i = 0; i < 3; i++)
                {
                    imgPath_Ori = $"{path.Item2}\\{Global.Data.Array_QrCodes[arrayIdx].GetQR()}_{sCurTm}_{i}_ORI.jpg";
                    imgOri[i].SaveImage(imgPath_Ori);
                    imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] NG Image Save Origin{i} \n");
                }
            }
            imgTotal.SaveImage(imgPath_Ovl);
            imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] OK Image Save Start \n");
            imgOnlyNG.SaveImage(imgPath_OnlyNG);
            imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] OK Image Save Total \n");
            tt_imgSave.Stop();
            if (!Global.Mode.NGisRecent)
            {
                for (int i = 0; i < Global.Instance.System.Recipe.GrabManager.Nodes.Length; i++)
                {
                    if (images[i] != null && images[i].Allocated)
                    {
                        using (Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[i].ToBitmap()).Clone())
                        {
                            string imgPath = imgPath_Array.Replace("GRABINDEX", i.ToString());
                            img.SaveImage(imgPath);
                            imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] NG Image Save Grab Index : {i} \n");
                        }
                    }
                }
            }

        }
        public void ImageSaveGrab(CogImage24PlanarColor[] images, out StringBuilder imgSaveLog)
        {
            imgSaveLog = new StringBuilder();
            Stopwatch tt_imgSave = Stopwatch.StartNew();

            //if (!Global.Mode.NGisRecent)
            //{
            for (int i = 0; i < Global.Instance.System.Recipe.GrabManager.Nodes.Length; i++)
            {
                if (images[i] != null && images[i].Allocated)
                {
                    using (Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[i].ToBitmap()).Clone())
                    {
                        string imgPath = imgPath_Array.Replace("GRABINDEX", i.ToString());
                        img.SaveImage(imgPath);
                        imgSaveLog.Append($"[{tt_imgSave.ElapsedMilliseconds}ms] NG Image Save Grab Index : {i} \n");
                    }
                }
            }
            //}
            tt_imgSave.Stop();
        }
        // tryp : true [보드 원본이미지 관련], false [크롭이미지 관련]
        // 보드 원본이미지만 텍타임 쓰기..
        public void DB_Write(bool type, bool isok, string imagePath_All, string imagePath_OnlyNG, int Grabindex, Global.LogicNGData logic, QRParser qr, DateTime dt, long tacktime)
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
                                        /*time*/$"'{dt.ToString("yyyyMMdd:HHmmss")}'",
                                        /*model*/$"'{Global.Instance.System.Recipe.Name}'",
                                        /*qrcode*/$"'{qr.GetQR()}'",
                                        /*insp_judge*/$"'{strResult}'",
                                        /*rms_judge*/$"'OK'",
                                        /*master_img_path*/$"'{Global.m_MainPJTRoot}\\RECIPE\\{Global.Instance.System.Recipe.Name}\\MasterBoard_0.jpg'",
                                        /*ng_img_path*/$"'{imagePath_All}/{imagePath_OnlyNG}'",
                                        /*crop_img_path*/$"''",
                                        /*master_crop_img_path*/$"''",
                                        /*ng_part_code*/$"''",
                                        /*ng_reason*/$"''",
                                        /**/$"''",
                                        /**/$"'{tacktime} ms'",
                        });

                }
            }
            else
            {
                string ngType = (string)logic.NG_data["Type"];
                string locationNo = (string)logic.NG_data["LocationNo"];
                string name = (string)logic.NG_data["Name"];
                Rectangle searchROI = (Rectangle)logic.NG_data["SearchROI"];
                System.Drawing.Rectangle searchRect = searchROI;
                List<string> saveCropNames = GetCropFileNames(isok, qr.GetQR(), locationNo, name);
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
                                                            $"'{name}/{ngType}'",
                                                            $"'X'",
                                                            $"'{searchRect.X},{searchRect.Y},{searchRect.Width},{searchRect.Height}'",
                                                            $"'{tacktime} ms'",
                          });
            }
        }
        public List<string> GetCropFileNames(bool bOk, string strQrCode, string strLocation, string strLogicName, bool bAuto = true)
        {
            List<string> lstReturn = new List<string>();
            string strPath;
            if (bOk) strPath = OK_Path;
            else strPath = NG_Path;

            //string strPath = GetSavePath(bOk, strQrCode);

            lstReturn.Add($"{strPath}\\Crop\\OrigImg_{strLocation}_{strLogicName}.jpg");
            lstReturn.Add($"{strPath}\\Crop\\CalcImg_{strLocation}_{strLogicName}.jpg");

            return lstReturn;
        }
        public void SaveCropImage(CogImage24PlanarColor[] images, Global.LogicNGData logic, QRParser qr, bool result)
        {

            string locationNo = (string)logic.NG_data["LocationNo"];
            string type = (string)logic.NG_data["Type"];
            string name = (string)logic.NG_data["Name"];
            Rectangle searchROI = (Rectangle)logic.NG_data["SearchROI"];
            int grabindex = (int)logic.NG_data["GrabIndex"];
            using (Mat imgforCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(images[grabindex].ToBitmap()).Clone())
            {
                Rect cropRoi = new Rect();

                cropRoi = CConverter.RectToCVRect(searchROI);


                if (cropRoi.Width != 0 && cropRoi.Height != 0)
                {
                    List<string> saveCropNames = GetCropFileNames(result, qr.GetQR(), locationNo, name);

                    int cutWdith = cropRoi.Width;
                    int cutHeight = cropRoi.Height;

                    if (cropRoi.X + cropRoi.Width > imgforCrop.Width)
                    {
                        cropRoi.Width = cutWdith = imgforCrop.Width - cropRoi.X - 1;
                        CLogger.Add(LOG.ABNORMAL, $"JOB CROP [{name}] OVERFLOW ");
                    }

                    if (searchROI.Y + searchROI.Height > imgforCrop.Height)
                    {
                        cropRoi.Height = cutHeight = imgforCrop.Height - cropRoi.Y - 1;
                        CLogger.Add(LOG.ABNORMAL, $"JOB CROP [{name}] OVERFLOW ");
                    }

                    imgforCrop.SubMat(cropRoi).SaveImage(saveCropNames[0]);
                }


            }
        }

        public (bool[], List<Global.LogicNGData>[]) ArrayJudge()
        {
            (bool[], List<Global.LogicNGData>[]) Result = (new bool[Global.System.Recipe.ArrayCount], new List<Global.LogicNGData>[Global.System.Recipe.ArrayCount]);
            bool[] results = new bool[Global.System.Recipe.ArrayCount];
            Dictionary<int, List<Global.LogicNGData>> ngLists = Global.NGDataList.GroupBy(a => a.ArrayIdx).ToList().ToDictionary(g => g.Key, g => g.ToList());
            List<Global.LogicNGData>[] ArrayNG_list = new List<Global.LogicNGData>[Global.System.Recipe.ArrayCount];

            for (int i = 0; i < ArrayNG_list.Length; i++)
            {
                ArrayNG_list[i] = new List<Global.LogicNGData>(); // 각 배열 요소에 List<> 초기화
            }

            for (int i = 0; i < Global.System.Recipe.ArrayCount; i++)
            {
                if (ngLists.ContainsKey(i)) // key가 0인 경우 확인
                {
                    ArrayNG_list[i] = ngLists[i]; // 해당 key의 리스트 가져오기
                    if (ArrayNG_list[i].Count != 0)
                    {
                        results[i] = false;
                    }
                    else
                    {
                        results[i] = true;
                    }
                }
                else
                {
                    results[i] = true;
                }


            }
            Result.Item1 = results;
            Result.Item2 = ArrayNG_list;


            return Result;
        }
        public void SaveImageAndWriteDB(bool[] results, CogImage24PlanarColor[] images, List<Global.LogicNGData>[] ArrayNG_list)
        {
            StringBuilder imgSaveLog = new StringBuilder();

            (string pathOK, string pathNG)[] path = new (string, string)[Global.System.Recipe.ArrayCount];

            for (int i = 0; i < Global.System.Recipe.ArrayCount; i++)
            {
                path[i] = InitDirectory_DateTime_ID(results[i], Global.m_ImageFileRoot, i);
                int idx = i;
                ImageSaveAll(path[idx], idx, results[idx],images, out imgSaveLog); // 이미지 저장
               
                if (results[i])
                {
                    Global.LogicNGData logicNGData = new LogicNGData(i, new Dictionary<string, object>());
                    DB_Write(true, true, imgPath_Ovl, imgPath_OnlyNG, 0, logicNGData, Global.Data.Array_QrCodes[i], curTm, 0);
                }
                else
                { 
                    for (int j = 0; j < ArrayNG_list[i].Count; j++)
                    {
                            Global.LogicNGData logicNGData = ArrayNG_list[i][j];
                            SaveCropImage(Global.Crop_Images[i], logicNGData, Global.Data.Array_QrCodes[i], results[i]);
                            DB_Write(false,results[i], imgPath_Ovl, imgPath_OnlyNG, 0, logicNGData, Global.Data.Array_QrCodes[i], curTm, 0);
                    }
                }
            }

            CLogger.Add(LOG.NORMAL, $"Save Log : {imgSaveLog.ToString()}");

        }
      
        public int TotalCount()
        {
            int Totalcount = 0;
            for (int i = 0; i < Global.System.Recipe.ArrayCount; i++)
            {
                if (Global.System.Recipe.LibraryManager.Library.TryGetValue(i + 1, out var logicList) && logicList.Count > 0)
                {
                    IF_VisionParam_Matching matching = new IF_VisionParam_Matching();
                    foreach (IF_VisionLogicInfo info in logicList)
                    {
                        if (info.Enabled == true)
                        {
                            for (int j = 0; j < info.Logics.Count; j++)
                            {
                                if (info.Logics[j].Enabled == true)
                                {
                                    if (info.Logics[j].Type == "Pattern")
                                    {
                                        matching = info.Logics[j] as IF_VisionParam_Matching;
                                        //if (matching.PMAlignTools[0].Pattern.Trained == false) continue;
                                    }
                                    Console.WriteLine($"{info.LocationNo}-{info.Logics[j].Name}");
                                    Totalcount++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"total -> {Totalcount}");
            return Totalcount;
        }
    }

}
