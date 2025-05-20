using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using IFOnnxRuntime.DTOs;
using IntelligentFactory._0._VISION.Algorithm;
using IntelligentFactory._0._VISION.Parameter;
using IntelligentFactory._0._VISION.Parameter.CoreProcessing;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Sunny.UI;
using System.Drawing.Imaging;
using log4net.Core;
using OpenCvSharp.Features2D;
using IFOnnxRuntime;
using System.Reflection.PortableExecutable;
using Cognex.VisionPro.QuickBuild;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

namespace IntelligentFactory
{
    public partial class Form_MenuVision : Form
    {
        public static EventHandler<Bitmap> iqResultEvent;

        Global Global = Global.Instance;
        private string _thisName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

        private int m_nSelectedArrayIndex = 1;
        private string m_nSelectedName = "";
        List<CogDisplay> dispIdxList;
        private Bitmap _image = null;

        private LogViewer logViewList = new LogViewer();

        public double Y1, Y2, CenterX, CenterY, OffsetX, OffsetY, ResX, ResY;
        private CogDisplayStatusBarV2 _CogDisplayStatus = new CogDisplayStatusBarV2();
        public Queue<LogicResultData> logicResultDatas = new Queue<LogicResultData>();
        private int pixelFormatOfImageSource = 0;
        private System.Drawing.Point panStartPoint;
        private double distancePoints = 0;
        OpenCvSharp.Point2d beforePoint1 = new OpenCvSharp.Point2d(0, 0);
        OpenCvSharp.Point2d beforePoint2 = new OpenCvSharp.Point2d(0, 0);
        OpenCvSharp.Point2d currentPoint1 = new OpenCvSharp.Point2d(0, 0);
        OpenCvSharp.Point2d currentPoint2 = new OpenCvSharp.Point2d(0, 0);

        CInspector inspector = new CInspector();
        Stopwatch inspectorWatch = new Stopwatch();
        private Cognex.VisionPro.CogImage24PlanarColor[] _imagesGrab = new Cognex.VisionPro.CogImage24PlanarColor[5];
        public Cognex.VisionPro.CogImage24PlanarColor[] MenualInsImgArray = new Cognex.VisionPro.CogImage24PlanarColor[5];
        private Bitmap IQ_Image = null;
        public Cognex.VisionPro.CogImage8Grey m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey();
        public static Cognex.VisionPro.CogImage24PlanarColor m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor();
        public Cognex.VisionPro.CogImage24PlanarColor m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor();
        public Cognex.VisionPro.CogImage8Grey m_imgSource_Mono_FullBoard = new Cognex.VisionPro.CogImage8Grey();
        public LibraryManager m_Job = null;
        public IF_VisionLogicInfo m_LogicInfo = null;
        public IF_VisionParamObject m_Logic = null;
        public IF_VisionParam_Condensor m_Condensor = null;
        public IF_VisionParam_ColorEx m_ColorEx = null;
        public IF_VisionParam_Pin m_Pin = null;
        public IF_VisionParam_Matching m_Matching = null;
        public IF_VisionParam_EYED m_EYED = null;
        public IF_VisionParam_CColor m_Color = null;
        public int m_SelectedJob = 0;
        public string m_SelectedLocationNo = "";
        public string m_SelectedPartCode = "";
        public int m_SelectedLogic = 0;
        public string m_SelectedLogicName = "";
        public int m_SelectedProcessing = 0;
        public bool m_Fiducial_PreView = false;
        public IF_ImageProcessing m_Processing = null;
        public bool bmanualMode = false;
        public int nFiducialSelectedIdx = 0;
        public int m_nSelectedGrabindex = 0;
        private bool _bResult_Action = true;
        private CCogTool_OCR m_OCRTool = new CCogTool_OCR("DataMatrix");
        private CogImage8Grey _croppedDMImage = null;


        public Form_MenuVision()
        {
            InitializeComponent();

            logViewList.Dock = DockStyle.Fill;
            logViewList.Visible = true;

            _CogDisplayStatus.Display = DispMain;
            _CogDisplayStatus.CoordinateSpaceName = "*\\#";
            _CogDisplayStatus.Dock = DockStyle.Fill;
            _CogDisplayStatus.ForeColor = Color.White;
            pnlDisplayStatus.Controls.Add(_CogDisplayStatus);

            //Global.SeqInitialize.EventInitEnd += OnInitEnd;
        }
        private void Form_MenuVision_Load(object sender, EventArgs e)
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");
            dispIdxList = new List<CogDisplay> { DisplayGrabIdx1, DisplayGrabIdx2, DisplayGrabIdx3, DisplayGrabIdx4, DisplayGrabIdx5 };
            try
            {
                InitEvent();
                InitComponents();
                InitUI();
                GrabDisp_TaskRun();
                Init_Controls();
                CoreProcessor.resultEvent += VisionResultHandler;
                Global.resultdrawVisionEvent += VisionResultDrawHandler;
                iqResultEvent += OnPaint;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[[{_thisName}.{MethodName} :: Error]] {ex}");
            }
        }

        public void InitUI()
        {
            try
            {
                SetRecipeInfo();
                Set_Library(false);
                UpdateComboBox();
                if (IF_Util.SafetyImageLoad($"{iqResultRootPath}\\IQ_Preview.bmp") != null)
                {
                    IQ_Image = IF_Util.SafetyImageLoad($"{iqResultRootPath}\\IQ_Preview.bmp");
                    cogdis_IQPreView.Image = new CogImage24PlanarColor((Bitmap)IQ_Image);
                    cogdis_IQPreView.Fit(false);
                }
                txtArrayCount.Text = Global.Instance.System.Recipe.ArrayCount.ToString();
                SetFiducialInfo();

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }

        }

        private void UpdateComboBox()
        {
            CbbModelList.DataSource = null; // 기존 데이터 소스를 제거
            CbbModelList.DataSource = Global.Instance.eyeD.Models.Select(model => model.OnnxName).ToArray(); // 새로운 데이터 소스를 설정
        }
        private void VisionDraw(LogicResultData logicResultData)
        {
            Dictionary<string, object> dataDictionary = logicResultData.Data;
            if (dataDictionary.TryGetValue("Result", out object result) && result is bool bResult && !bResult)
            {
                Global.NGDataList.Add(new Global.LogicNGData(logicResultData.ArrayIdx, logicResultData.Data));
            }

            switch (logicResultData.Key)
            {
                case CoreKey.Pattern:
                    LogicResultDraw.DrawPattern(logicResultData.Data, logicResultData.ArrayIdx);
                    break;
                case CoreKey.Blob:
                    break;
                case CoreKey.Distance:
                    break;
                case CoreKey.Color:
                    break;
                case CoreKey.ColorEx:
                    LogicResultDraw.DrawColorEx(logicResultData.Data, logicResultData.ArrayIdx);
                    break;
                case CoreKey.EYED:
                    LogicResultDraw.DrawEYED(logicResultData.Data, logicResultData.ArrayIdx);
                    break;
                case CoreKey.Condensor:
                    LogicResultDraw.DrawCondensor(logicResultData.Data, logicResultData.ArrayIdx);
                    break;
                case CoreKey.Connector:
                    break;
                case CoreKey.Pin:
                    LogicResultDraw.DrawPin(logicResultData.Data, logicResultData.ArrayIdx);
                    break;
            }

        }
        private void VisionResultHandler(object sender, LogicResultData logicResultData)
        {
            try
            {
                VisionDraw(logicResultData);
                string locationNo = (string)logicResultData.Data["LocationNo"];
                string logicName = (string)logicResultData.Data["Name"];
                Interlocked.Add(ref Global.logicCount, 1);
                Global.LogicCount = Global.logicCount;
                //Console.WriteLine($"{locationNo}-{logicName}");
                Console.WriteLine($"{Global.LogicCount}");

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        private void VisionResultDrawHandler(object sender, bool drawDone)
        {
            try
            {
                CLogger.Add(LOG.SEQ, $"SEQ T/T : [{inspectorWatch.ElapsedMilliseconds:D4} ms] ==> inspect Complete");
                if (Global.ImageResults_array[0] != null)
                {
                    DispMain.StaticGraphics.Clear();
                    DispMain.InteractiveGraphics.Clear();

                    // 첫번째 이미지에 비트맵 이미지로 결과 표시처리 해줌...
                    DispMain.Image = new CogImage24PlanarColor(Global.ImageResults_array[0]);
                    DispMain.Fit();
                }

                OnClickViewMode(btnView_Result1, new EventArgs());

                if (Global.bSimulation)
                {
                    Global.Instance.OnEnd_Progress();
                    Global.totalCount = 0;
                    bmanualMode = false;
                    Global.bSimulation = false;
                    inspectorWatch.Stop();
                }

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

        }
        bool GrabDisp = false;
        private void GrabDisp_TaskRun()
        {
            GrabDisp = true;
            Task.Run(async () =>
            {
                while (GrabDisp)
                {
                    await Task.Delay(1);
                    Grab_Recive();
                }
            });
        }
        private void Grab_Recive()
        {
            try
            {
                // 화면 디스플레이 처리..
                // 라이브일때만 화면 디스플레이...
                Bitmap image = Global.Instance.Device.Cameras[0].ImageGrab;
                if (image != null && Global.Device.Cameras[0].IsLive)
                {
                    m_imgSource_Color = new CogImage24PlanarColor(image); //new Cognex.VisionPro.CogImage24PlanarColor((Cognex.VisionPro.CogImage24PlanarColor)CCognexUtil.FlipRotateEx(Global.Instance.Device.Cameras[DEFINE.CAM1].ImageCogGrab, (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam1_ImageProcess.FlipRotate), true));
                    m_imgSource_Mono = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                    m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor(m_imgSource_Color);
                    m_imgSource_Mono_FullBoard = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                    if (chkAlphaImg.Checked) iqResultEvent?.Invoke(this, image);
                    DispMain.Image = new CogImage24PlanarColor(image);//Global.Instance.Device.Cameras[0].ImageCogGrab;
                }
            }
            catch
            {
            }
        }

        private void OnInitEnd(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnInitEnd(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
            else
            {
                try
                {
                    InitUI();
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }
        private void InitComponents()
        {
            try
            {
                List<CheckBox> enableList = new List<CheckBox> { ChkEnable1, ChkEnable2, ChkEnable3, ChkEnable4, ChkEnable5 };
                List<UITextBox> exposureList = new List<UITextBox> { TbExposure1, TbExposure2, TbExposure3, TbExposure4, TbExposure5 };
                List<UITextBox> gainList = new List<UITextBox> { TbGain1, TbGain2, TbGain3, TbGain4, TbGain5 };
                for (int i = 0; i < enableList.Count; i++)
                {
                    enableList[i].Checked = Global.System.Recipe.GrabManager.Nodes[i].Enabled;
                }

                for (int i = 0; i < exposureList.Count; i++)
                {
                    exposureList[i].Text = Global.System.Recipe.GrabManager.Nodes[i].ExposureTime_us.ToString();
                }

                for (int i = 0; i < gainList.Count; i++)
                {
                    gainList[i].Text = Global.System.Recipe.GrabManager.Nodes[i].Gain.ToString();
                }

                CbRotateImageEYED.DataSource = new List<int> { 0, 90, 180, 270 };
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void InitEvent()
        {
            Global.Instance.FrmPopup_EYED.ClosedPopup += UpdateComboBox;
            Global.SeqVision.EventInspEnd += OnInspEnd;
        }

        Bitmap imageSource = null;
        public void OnInspEnd(object sender, EventArgs e)
        {
            try
            {

                if (_bResult_Action == true)
                {
                    OnClickSelectResult(0, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }
        private void OverlayClear()
        {
            if (DispMain.Image != null)
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();
                DispMain.Refresh();
            }
        }
        private void OnClickCogDisplayOperation(object sender, EventArgs e)
        {
            try
            {
                string operationName = (sender as UISymbolButton).Tag.ToString().ToUpper();

                timerCalibration.Enabled = false;

                switch (operationName)
                {
                    case "GRAB":
                        {

                        }
                        break;
                    case "CROSS":
                        {
                            if (DispMain.Image == null) return;
                            Cognex.VisionPro.CogLineSegment Hori = new Cognex.VisionPro.CogLineSegment();
                            Hori.Color = Cognex.VisionPro.CogColorConstants.Yellow;
                            Hori.StartX = 0;
                            Hori.StartY = DispMain.Image.Height / 2;
                            Hori.EndX = DispMain.Image.Width;
                            Hori.EndY = DispMain.Image.Height / 2;

                            Cognex.VisionPro.CogLineSegment Verti = new Cognex.VisionPro.CogLineSegment();
                            Verti.Color = Cognex.VisionPro.CogColorConstants.Yellow;
                            Verti.StartX = DispMain.Image.Width / 2;
                            Verti.StartY = 0;
                            Verti.EndX = DispMain.Image.Width / 2;
                            Verti.EndY = DispMain.Image.Height;

                            DispMain.InteractiveGraphics.Add(Hori, "Hori", true);
                            DispMain.InteractiveGraphics.Add(Verti, "Vert", true);
                        }
                        break;
                    case "OVERLAY CLEAR":
                        {
                            OverlayClear();
                        }
                        break;
                    case "LOAD":
                        {
                            if (DispMain.Image == null)
                            {
                                //timerCalibration.Enabled = true;
                            }

                            OpenFileDialog ofd = new OpenFileDialog();
                            ofd.Title = "Image Load";
                            ofd.Filter = "Image File (*.png, *.jpg, *.gif, *.bmp) | *.png; *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";

                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                OverlayClear();

                                if (imageSource != null)
                                {
                                    imageSource.Dispose();
                                    imageSource = null;
                                }

                                if (DispMain.Image != null)
                                {
                                    (DispMain.Image as CogImage8Grey)?.Dispose();
                                    (DispMain.Image as CogImage24PlanarColor)?.Dispose();
                                    DispMain.Image = null;
                                    GC.Collect();
                                }

                                imageSource = new Bitmap(ofd.FileName);

                                if (imageSource.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                                {
                                    DispMain.Image = new CogImage8Grey(imageSource);
                                    pixelFormatOfImageSource = 8;
                                }
                                else
                                {
                                    DispMain.Image = new CogImage24PlanarColor(imageSource);
                                    pixelFormatOfImageSource = 24;
                                }
                                DispMain.Fit(true);
                            }
                        }
                        break;
                    case "SAVE":
                        {
                            if (DispMain.Image != null)
                            {
                                SaveFileDialog sfd = new SaveFileDialog();
                                sfd.Title = "Image Save";
                                sfd.Filter = "Image File (*.png, *.jpg, *.gif, *.bmp) | *.png; *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    DispMain.Image.ToBitmap().Save(sfd.FileName);
                                }
                            }
                        }
                        break;
                    case "SEARCH ROI":
                        {
                            if (DispMain.Image != null)
                            {
                                DispMain.InteractiveGraphics.Clear();
                                DispMain.StaticGraphics.Clear();

                                DispMain.Fit();

                                CogRectangle cogSearchRegion = new CogRectangle();

                                cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                                cogSearchRegion.Interactive = true;
                                cogSearchRegion.Color = CogColorConstants.Red;
                                cogSearchRegion.SelectedColor = CogColorConstants.Red;

                                DispMain.InteractiveGraphics.Add(cogSearchRegion, "SearchROI", false);
                            }
                        }
                        break;
                    case "MEASURE":
                        {
                            if (DispMain.Image != null)
                            {
                                CogPointMarker pos1 = new CogPointMarker();
                                pos1.Color = CogColorConstants.Red;
                                pos1.Interactive = true;
                                pos1.GraphicDOFEnable = CogPointMarkerDOFConstants.All;

                                CogPointMarker pos2 = new CogPointMarker();
                                pos2.Color = CogColorConstants.Orange;
                                pos2.Interactive = true;
                                pos2.GraphicDOFEnable = CogPointMarkerDOFConstants.All;

                                DispMain.InteractiveGraphics.Add(pos1, "Point1", false);
                                DispMain.InteractiveGraphics.Add(pos2, "Point2", false);

                                timerCalibration.Enabled = true;
                            }
                        }
                        break;
                    case "POINT":
                        {
                            btn_CogDisplay_Pan.Selected = false;
                            btn_CogDisplay_Point.Selected = true;
                            var v = DispMain.ContextMenuStrip.Items[0];
                            v.PerformClick();
                        }
                        break;
                    case "PAN":
                        {
                            btn_CogDisplay_Point.Selected = false;
                            btn_CogDisplay_Pan.Selected = true;
                            var v = DispMain.ContextMenuStrip.Items[1];
                            v.PerformClick();
                        }
                        break;
                    case "ZOOMIN":
                        {
                            if (DispMain.Image != null)
                                DispMain.Zoom *= 1.2;
                        }
                        break;
                    case "ZOOMOUT":
                        {
                            if (DispMain.Image != null)
                                DispMain.Zoom /= 1.2;
                        }
                        break;
                    case "ZOOMFIT":
                        {
                            if (DispMain.Image != null)
                                DispMain.Fit(true);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name} Execption ==> {ex.Message}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private string lastRecentImageName = "";

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                int imageWidth = 0;
                int imageHeight = 0;
                int imageChannel = 0;
                TbLibraryName.Text = Global.Instance.System.Recipe.CODE;
                label25.Text = $"T/T : [{inspectorWatch.ElapsedMilliseconds:D4} ms]";

                if (_image != null)
                {
                    imageWidth = _image.Width;
                    imageHeight = _image.Height;

                    if (_image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                    {
                        imageChannel = 8;
                    }
                    else if (_image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                    {
                        imageChannel = 24;
                    }
                    //imageChannel = _image.
                }
                //string strText = string.Format("DiskSpace : {0:0.#0}%", IF_Util.GetAvailDrive());
                //lblProcess.Text = $"{_ProcessMode}";
                int recentImageCount = Global.Data.cogRecentImages.Count;

                if (recentImageCount > 0)
                {
                    if (Global.Data.cogRecentImages[recentImageCount - 1].Name != lastRecentImageName)
                    {
                        DgvRecentImages.Rows.Clear();

                        for (int i = 0; i < recentImageCount; i++)
                        {
                            DgvRecentImages.Rows.Add(Global.Data.cogRecentImages[i].DateTime, Global.Data.cogRecentImages[i].Name);
                        }
                        lastRecentImageName = Global.Data.cogRecentImages[recentImageCount - 1].Name;
                    }
                }

                foreach (DataGridViewColumn dgvc in DgvRecentImages.Columns)
                {
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                btnViewGrabIndex1.BackColor = (_imagesGrab[0] == null || _imagesGrab[0].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;
                btnViewGrabIndex2.BackColor = (_imagesGrab[1] == null || _imagesGrab[1].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;
                btnViewGrabIndex3.BackColor = (_imagesGrab[2] == null || _imagesGrab[2].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;
                btnViewGrabIndex4.BackColor = (_imagesGrab[3] == null || _imagesGrab[3].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;
                btnViewGrabIndex5.BackColor = (_imagesGrab[4] == null || _imagesGrab[4].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;

                DisplayGrabIdx1.Image = (_imagesGrab[0] == null || _imagesGrab[0].Allocated == false) ? null : _imagesGrab[0];
                DisplayGrabIdx2.Image = (_imagesGrab[1] == null || _imagesGrab[1].Allocated == false) ? null : _imagesGrab[1];
                DisplayGrabIdx3.Image = (_imagesGrab[2] == null || _imagesGrab[2].Allocated == false) ? null : _imagesGrab[2];
                DisplayGrabIdx4.Image = (_imagesGrab[3] == null || _imagesGrab[3].Allocated == false) ? null : _imagesGrab[3];
                DisplayGrabIdx5.Image = (_imagesGrab[4] == null || _imagesGrab[4].Allocated == false) ? null : _imagesGrab[4];
                //lblImageInfo.Visible = timerCalibration.Enabled;

                //if (DispMain.Image != null)
                //{
                //    lblImageInfo.Text = $"Image Info : {DispMain.Image.Width} * {DispMain.Image.Height} * {pixelFormatOfImageSource} | Distance : {distancePoints.ToString("F2")}px | Zoom : {DispMain.Zoom.ToString("F2")}";
                //}

                //lbl_Display_ImageInfo.Text = imageInfo;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnChannelSplit_Click(object sender, EventArgs e)
        {

        }

        private void trackbarThresholdMin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void OnClickCameraOperation(object sender, EventArgs e)
        {
            try
            {
                string operIndex = "";
                if (sender is Button)
                    operIndex = (sender as Button).Text;
                else if (sender is CheckBox)
                    operIndex = (sender as CheckBox).Text;
                else if (sender is UIButton)
                    operIndex = (sender as UIButton).Text;
                else
                    return;

                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                Camera camera = Global.Device.Cameras.Count > 0 ? Global.Device.Cameras[0] : null;
                CRecipe recipe = Global.System.Recipe;

                switch (operIndex)
                {
                    case "GRAB (1)":
                        {
                            if (checkCameraStatus() == false) return;

                            DispMain.Image = null;

                            btnLive.Text = "LIVE";
                            camera.SetExposure(recipe.GrabManager.Nodes[0].ExposureTime_us);
                            camera.SetGain(recipe.GrabManager.Nodes[0].Gain);
                            camera.Live(false);
                            camera.Grab(false);

                            bool success = camera.IsGrabDone.WaitOne(1000);

                            using (CogImage24PlanarColor img = new CogImage24PlanarColor(camera.ImageGrab))
                            {
                                _imagesGrab = new CogImage24PlanarColor[5];
                                Global.ImagesGrab = new CogImage24PlanarColor[5];
                                _imagesGrab[0] = img;
                                Global.ImagesGrab[0] = img;
                                RefreshDispGrabIdx();
                                DispMain.Image = new CogImage24PlanarColor(img);
                                DispMain.Fit();
                                //m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)CCognexUtil.FlipRotateEx(img, (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam1_ImageProcess.FlipRotate), true));
                                //m_imgSource_Mono = CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                                //m_imgSource_Color_FullBoard = new CogImage24PlanarColor(m_imgSource_Color);
                                //m_imgSource_Mono_FullBoard = CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                            }
                        }

                        break;
                    case "GRAB (5)":
                        {
                            if (checkCameraStatus() == false) return;

                            DispMain.Image = null;

                            btnLive.Text = "LIVE";

                            camera.Live(false);

                            for (int i = 0; i < 5; i++)
                            {
                                camera.SetExposure(recipe.GrabManager.Nodes[i].ExposureTime_us);
                                camera.SetGain(recipe.GrabManager.Nodes[i].Gain);

                                Thread.Sleep(10);

                                camera.Grab(false);

                                bool success = camera.IsGrabDone.WaitOne(1000);
                                _imagesGrab[i] = null;
                                Global.ImagesGrab[i] = null;

                                if (success)
                                {
                                    _imagesGrab[i] = new CogImage24PlanarColor((Bitmap)camera.ImageGrab);
                                    Global.ImagesGrab[i] = new CogImage24PlanarColor((Bitmap)camera.ImageGrab);
                                }

                                Thread.Sleep(10);
                            }
                            if (Global.ImagesGrab[0] != null && Global.ImagesGrab[0].Allocated)
                            {
                                CogImage24PlanarColor imgOrg_Index0 = new CogImage24PlanarColor();
                                if (_imagesGrab[0] != null)
                                {
                                    imgOrg_Index0 = new CogImage24PlanarColor(Global.ImagesGrab[0]);
                                }

                                for (int i = 0; i < Global.ImagesGrab.Length; i++)
                                {
                                    if (imgOrg_Index0.Width == 0) imgOrg_Index0 = new CogImage24PlanarColor(Global.ImagesGrab[0]);
                                    if (Global.ImagesGrab[i] != null)
                                    {
                                        _imagesGrab[i] = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImagesGrab[i]);
                                        if (chkAlignNoUse.Checked == false && _selectedFiducialLibrary.Fiducial1.ImageTemplate != null) _imagesGrab[i] = CVisionTools.RotateMarkedImage(new CogImage24PlanarColor(imgOrg_Index0), _imagesGrab[i], _selectedFiducialLibrary);
                                        string GRAB_str_ImageName = $"CDImage{i + 1}";

                                        Control GRAB_foundControl = Controls.Find(GRAB_str_ImageName, true).FirstOrDefault();

                                        if (GRAB_foundControl is CogDisplay GRAB_CD)
                                        {
                                            if (GRAB_CD.InvokeRequired)
                                            {
                                                GRAB_CD.Invoke((MethodInvoker)delegate
                                                {
                                                    GRAB_CD.Image = _imagesGrab[i];
                                                });
                                            }
                                            else
                                            {
                                                GRAB_CD.Image = _imagesGrab[i];
                                            }
                                        }
                                    }
                                }
                            }
                            btnViewGrabIndex1.Selected = true;
                            DispMain.Image = _imagesGrab[0];
                            DispMain.Fit();
                            RefreshDispGrabIdx();
                            SelectGrabImage(0, true);

                        }
                        break;
                    case "LIVE":
                        {
                            if (checkCameraStatus() == false) return;
                            camera.SetExposure(recipe.GrabManager.Nodes[0].ExposureTime_us);
                            camera.SetGain(recipe.GrabManager.Nodes[0].Gain);
                            (sender as UIButton).Text = "LIVE STOP";
                            Global.Device.Cameras[0].Live(true);
                        }
                        break;
                    case "LIVE STOP":
                        {
                            if (checkCameraStatus() == false) return;

                            (sender as UIButton).Text = "LIVE";
                            Global.Device.Cameras[0].Live(false);
                        }
                        break;
                    case DEFINE.Cross:
                        DispMain.InteractiveGraphics.Clear();
                        break;

                    case "LOAD (1)":
                        {
                            try
                            {
                                OpenFileDialog ofd = new OpenFileDialog();
                                ofd.InitialDirectory = Global.m_MainPJTRoot;
                                ofd.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";

                                if (ofd.ShowDialog() == DialogResult.OK)
                                {

                                    _imagesGrab = new CogImage24PlanarColor[5];
                                    Global.ImagesGrab = new CogImage24PlanarColor[5];
                                    _imagesGrab[0] = new CogImage24PlanarColor(new Bitmap(ofd.FileName));
                                    Global.ImagesGrab[0] = new CogImage24PlanarColor(new Bitmap(ofd.FileName));
                                    RefreshDispGrabIdx();

                                    // m_imgSource_Color, Mono, Fullboard 대체 어따쓰는거임 ?
                                    m_imgSource_Color = new CogImage24PlanarColor(new Bitmap(ofd.FileName));
                                    m_imgSource_Mono = new CogImage8Grey(new Bitmap(ofd.FileName));
                                    m_imgSource_Color_FullBoard = new CogImage24PlanarColor(new Bitmap(ofd.FileName));
                                    m_imgSource_Mono_FullBoard = new CogImage8Grey(new Bitmap(ofd.FileName));

                                    DispMain.Image = m_imgSource_Color;
                                    DispMain.Fit(true);

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        break;
                    case DEFINE.Image_Load:
                    case "LOAD (5)":
                        try
                        {
                            CommonOpenFileDialog FBD = new CommonOpenFileDialog();

                            FBD.IsFolderPicker = true;
                            if (FBD.ShowDialog() == CommonFileDialogResult.Ok)
                            {
                                string selectedFolderPath = FBD.FileName;

                                string[] fileEntries = Directory.GetFiles(selectedFolderPath);
                                Array.Sort(fileEntries);

                                int fileCount = Math.Min(fileEntries.Length, 5);
                                _imagesGrab = new CogImage24PlanarColor[5];
                                CogImage24PlanarColor imgOrg_Index0 = new CogImage24PlanarColor();
                                for (int i = 0, imageIndex = 0; i < fileEntries.Length && imageIndex < 5; i++)
                                {
                                    string filePath = fileEntries[i];
                                    string extension = Path.GetExtension(filePath).ToLower();

                                    if (extension == ".jpg" || extension == ".bmp" || extension == ".png")
                                    {
                                        _imagesGrab[imageIndex] = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(filePath));
                                        Global.ImagesGrab[imageIndex] = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(filePath));

                                        if (imageIndex == 0 && _imagesGrab[0] != null)
                                        {
                                            imgOrg_Index0 = new CogImage24PlanarColor(_imagesGrab[0]);
                                        }
                                        if (chkAlignNoUse.Checked == false && _selectedFiducialLibrary != null) _imagesGrab[imageIndex] = CVisionTools.RotateMarkedImage(new CogImage24PlanarColor(imgOrg_Index0), _imagesGrab[imageIndex], _selectedFiducialLibrary);

                                        imageIndex++;
                                    }
                                }
                                m_imgSource_Color = _imagesGrab[0];
                                btnViewGrabIndex1.Selected = true;
                                DispMain.Image = m_imgSource_Color;

                                DispMain.Fit();
                                RefreshDispGrabIdx();
                                SelectGrabImage(0, false);

                                m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor(m_imgSource_Color);
                                m_imgSource_Mono_FullBoard = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                    case DEFINE.Image_Save:
                    case "SAVE (5)":
                        // 세이브하는것을 묻기전에 이미지가 있는지 확인
                        if (!m_imgSource_Color.Allocated)
                        {
                            IF_Util.ShowMessageBox("NO IMAGE", "Please proceed with Grab");
                            return;
                        }

                        //string strPath = CUtil.SaveImage();
                        string _filesave_name = "";
                        SaveFileDialog _savefiledialog = new SaveFileDialog();
                        bool _ret = false;

                        _savefiledialog.Title = "IMAGE SAVE";
                        _savefiledialog.OverwritePrompt = true;
                        _savefiledialog.Filter = "JPEG File(*.jpg)|*.jpg|Bitmap File(*.bmp)|*.bmp";

                        if (_savefiledialog.ShowDialog() == DialogResult.OK)
                        {
                            _filesave_name = _savefiledialog.FileName;

                            if (IF_Util.ShowMessageBox("SAVE", "Do you want to save it as that path?\nPath : " + _filesave_name, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                            {
                                for (int i = 0; i < _imagesGrab.Count(); i++)
                                {
                                    int lastDotIndex = _filesave_name.LastIndexOf('.');
                                    string filename = "";
                                    if (lastDotIndex != -1)
                                    {
                                        filename = _filesave_name.Insert(lastDotIndex, $"{i}");
                                    }
                                    CogImage24PlanarColor ImageSource_Color = (CogImage24PlanarColor)_imagesGrab[i];
                                    _ret = CogUtil.RGB_SaveImage(ImageSource_Color, CogUtil.RGB_COLOR.O, $"{filename}");

                                }
                            }
                        }
                        break;
                    case "SAVE (1)":
                        // 세이브하는것을 묻기전에 이미지가 있는지 확인
                        //if (!m_imgSource_Color.Allocated)
                        if (DispMain.Image == null)
                        {
                            IF_Util.ShowMessageBox("NO IMAGE", "Please proceed with Grab");
                            return;
                        }

                        //string strPath = CUtil.SaveImage();
                        string savename = "";
                        SaveFileDialog _savefiled = new SaveFileDialog();

                        _savefiled.Title = "IMAGE SAVE";
                        _savefiled.OverwritePrompt = true;
                        _savefiled.Filter = "JPEG File(*.jpg)|*.jpg|Bitmap File(*.bmp)|*.bmp";

                        if (_savefiled.ShowDialog() == DialogResult.OK)
                        {
                            savename = _savefiled.FileName;

                            if (IF_Util.ShowMessageBox("SAVE", "Do you want to save it as that path?\nPath : " + savename, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                            {
                                CogImage24PlanarColor ImageSource_Color = (CogImage24PlanarColor)DispMain.Image;
                                CogUtil.RGB_SaveImage(ImageSource_Color, CogUtil.RGB_COLOR.O, $"{savename}");
                            }
                        }
                        break;

                    case "ORIGINAL":
                        {
                            if (DispMain.Image == null) return;
                            DispMain.Image = _imagesGrab[0].ScaleImage(DispMain.Image.Width, DispMain.Image.Height);
                            btnViewGrabIndex1.Selected = true;
                            DispMain.Fit();
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                        }
                        break;
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        private void OnClickGrabImages(object sender, EventArgs e)
        {
            string operationName = (sender as UISymbolButton).Tag.ToString().ToUpper();
            Camera camera = Global.Device.Cameras.Count > 0 ? Global.Device.Cameras[0] : null;

            if (checkCameraStatus() == false) return;

            switch (operationName)
            {
                case "GRAB1":
                    {
                        camera.SetExposure(float.Parse(TbExposure1.Text));
                        camera.SetGain(float.Parse(TbGain1.Text));
                        break;
                    }
                case "GRAB2":
                    {
                        camera.SetExposure(float.Parse(TbExposure2.Text));
                        camera.SetGain(float.Parse(TbGain2.Text));
                        break;
                    }
                case "GRAB3":
                    {
                        camera.SetExposure(float.Parse(TbExposure3.Text));
                        camera.SetGain(float.Parse(TbGain3.Text));
                        break;
                    }
                case "GRAB4":
                    {
                        camera.SetExposure(float.Parse(TbExposure4.Text));
                        camera.SetGain(float.Parse(TbGain4.Text));
                        break;
                    }
                case "GRAB5":
                    {
                        camera.SetExposure(float.Parse(TbExposure5.Text));
                        camera.SetGain(float.Parse(TbGain5.Text));
                        break;
                    }
            }

            DispMain.Image = null;


            camera.Live(false);
            camera.Grab(false);

            bool success = camera.IsGrabDone.WaitOne(1000);

            using (CogImage24PlanarColor img = new CogImage24PlanarColor(camera.ImageGrab))
            {
                _imagesGrab = new CogImage24PlanarColor[5];
                Global.ImagesGrab = new CogImage24PlanarColor[5];
                _imagesGrab[0] = img;
                Global.ImagesGrab[0] = img;
                RefreshDispGrabIdx();
                DispMain.Image = new CogImage24PlanarColor(img);
                DispMain.Fit();
                //m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)CCognexUtil.FlipRotateEx(img, (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam1_ImageProcess.FlipRotate), true));
                //m_imgSource_Mono = CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                //m_imgSource_Color_FullBoard = new CogImage24PlanarColor(m_imgSource_Color);
                //m_imgSource_Mono_FullBoard = CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
            }
        }
        private void RefreshDispGrabIdx()
        {
            for (int i = 0; i < _imagesGrab.Count(); i++)
            {
                dispIdxList[i].Image = _imagesGrab[i];
            }
        }

        private bool checkCameraStatus()
        {
            try
            {
                Camera Camera = Global.Device.Cameras.Count > 0 ? Global.Device.Cameras[0] : null;

                if (Camera == null || Camera.IsOpen == false)
                {
                    CLogger.Add(LOG.ABNORMAL, $"Camera Disconnected");
                    Thread.Sleep(1000);

                    return false;
                }

                if (Global.SeqVision.SeqIndex != "IDLE")
                {
                    CLogger.Add(LOG.ABNORMAL, "Can't Grab during the Inspection");
                    return false;
                }

                DispMain.Image = null;
                if (!Global.Device.Cameras[0].IsOpen)
                {
                    IF_Util.ShowMessageBox("Error", "Check the Connection of Camera");
                    return false;
                }
            }
            catch (Exception ex)
            {
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

            return true;
        }

        private void BtnIQHWApply_Click(object sender, EventArgs e)
        {
            ApplyIQ_HW();
            Global.System.Recipe.GrabManager.SaveConfig();
        }

        private void ApplyIQ_HW()
        {
            Global.System.Recipe.GrabManager.Nodes[0] = new CNodeGrab()
            {
                ExposureTime_us = int.Parse(TbExposure1.Text),
                Enabled = ChkEnable1.Checked,
                Gain = float.Parse(TbGain1.Text),
                Light = int.Parse(TbLight1.Text),
            };

            Global.System.Recipe.GrabManager.Nodes[1] = new CNodeGrab()
            {
                ExposureTime_us = int.Parse(TbExposure2.Text),
                Enabled = ChkEnable2.Checked,
                Gain = float.Parse(TbGain2.Text),
                Light = int.Parse(TbLight2.Text),
            };

            Global.System.Recipe.GrabManager.Nodes[2] = new CNodeGrab()
            {
                ExposureTime_us = int.Parse(TbExposure3.Text),
                Enabled = ChkEnable3.Checked,
                Gain = float.Parse(TbGain3.Text),
                Light = int.Parse(TbLight3.Text),
            };

            Global.System.Recipe.GrabManager.Nodes[3] = new CNodeGrab()
            {
                ExposureTime_us = int.Parse(TbExposure4.Text),
                Enabled = ChkEnable4.Checked,
                Gain = float.Parse(TbGain4.Text),
                Light = int.Parse(TbLight4.Text),
            };

            Global.System.Recipe.GrabManager.Nodes[4] = new CNodeGrab()
            {
                ExposureTime_us = int.Parse(TbExposure5.Text),
                Enabled = ChkEnable5.Checked,
                Gain = float.Parse(TbGain5.Text),
                Light = int.Parse(TbLight5.Text),
            };
        }
        public void SetRecipeInfo()
        {
            try
            {
                m_Job = Global.System.Recipe.LibraryManager;
                Set_Library(false);
            }
            catch
            {
            }

        }
        public void SetFiducialInfo()
        {
            _selectedFiducialLibrary = Global.System.Recipe.FiducialLibrary;
            if (Global.System.Recipe.FiducialLibrary != null)
            {
                Invoke_Util.Set_Invoke_Label(lblDegreeMaster, $"{_selectedFiducialLibrary.MasterAngle:F5}");

                if (_selectedFiducialLibrary.Fiducial1.ImageTemplate != null)
                {
                    cogDisplay_Fiducial_Pattern1.Image = new CogImage8Grey(_selectedFiducialLibrary.Fiducial1.ImageTemplate);
                    cogDisplay_Fiducial_Pattern1.Fit(false);
                }
                if (_selectedFiducialLibrary.ImagePreview != null)
                {
                    Cogdis_FiducialPreView.Image = new CogImage24PlanarColor(_selectedFiducialLibrary.ImagePreview);
                    Cogdis_FiducialPreView.Fit(false);
                }
                else Cogdis_FiducialPreView.Image = null;
            }
        }
        public void ClearCogDisp()
        {
            Global.ImagesGrab = new CogImage24PlanarColor[5];
            for (int i = 0; i < Global.ImagesGrab.Count(); i++)
            {
                dispIdxList[i].Image = null;
                _imagesGrab[i] = null;
            }
            DispMain.Image = null;

        }
        private void OnClickAlgorithm_Pattern(object sender, EventArgs e)
        {
            try
            {
                int idx;

                idx = DispMain.InteractiveGraphics.FindItem("Result", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);

                if (idx > 0)
                {
                    DispMain.InteractiveGraphics.Remove(idx);
                }

                string strIndex = (sender as UIButton).Text;

                int nSelectedPM = 0;
                m_Matching = (m_Logic as IF_VisionParam_Matching);

                if (comboJobPattern_PatternType.Text == "" && comboJobPattern_PatternType.Items.Count > 0) comboJobPattern_PatternType.SelectedIndex = 0;
                if (comboJobPattern_PatternType.Text == "1") nSelectedPM = 0;
                else if (comboJobPattern_PatternType.Text == "2") nSelectedPM = 1;
                else if (comboJobPattern_PatternType.Text == "3") nSelectedPM = 2;
                else if (comboJobPattern_PatternType.Text == "4") nSelectedPM = 3;
                else if (comboJobPattern_PatternType.Text == "5") nSelectedPM = 4;
                CogPMAlignTool PMAlign = null;
                PMAlign = m_Matching.PMAlignTools[nSelectedPM];
                if (PMAlign == null) return;
                DisplayTrainCount(m_Matching);

                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();
                            if (PMAlign.SearchRegion == null)
                            {
                                PMAlign.SearchRegion = new Cognex.VisionPro.CogRectangle();
                                cogSearchRegion.X = 50;
                                cogSearchRegion.Y = 50;
                                cogSearchRegion.Width = 300;
                                cogSearchRegion.Height = 300;
                                PMAlign.SearchRegion.FitToImage(m_imgSource_Mono, 1.0D, 1.0D);
                            }
                            else
                            {
                                cogSearchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.SearchRegion;
                            }

                            //검사 영역
                            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.LineWidthInScreenPixels = 2;

                            Cognex.VisionPro.CogRectangle input_cogSearchRegion = new CogRectangle();
                            input_cogSearchRegion = cogSearchRegion.Copy(CogCopyShapeConstants.All);
                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)input_cogSearchRegion, "Search", false);

                            // Train 영역
                            Cognex.VisionPro.CogRectangle cogTrainRegion = new Cognex.VisionPro.CogRectangle();

                            if (PMAlign.Pattern.TrainRegion != null)
                            {
                                if (PMAlign.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
                                {
                                    cogTrainRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Pattern.TrainRegion;
                                }
                                else
                                {
                                    cogTrainRegion.X = 30;
                                    cogTrainRegion.Y = 30;
                                    cogTrainRegion.Width = 250;
                                    cogTrainRegion.Height = 250;
                                }

                                cogTrainRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                                cogTrainRegion.Interactive = true;
                                cogTrainRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Blue;
                                cogTrainRegion.DragColor = Cognex.VisionPro.CogColorConstants.Blue;
                                cogTrainRegion.Color = Cognex.VisionPro.CogColorConstants.Blue;
                                cogTrainRegion.LineWidthInScreenPixels = 2;
                            }

                            if (cogTrainRegion.Width == 0) cogTrainRegion.Width = 250;
                            if (cogTrainRegion.Height == 0) cogTrainRegion.Height = 250;
                            Cognex.VisionPro.CogRectangle input_cogTrainRegion = new CogRectangle();
                            input_cogTrainRegion = cogTrainRegion.Copy(CogCopyShapeConstants.All);
                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)input_cogTrainRegion, "Pattern", false);

                        }
                        break;

                    case "TRAIN":
                    case "Train":
                        {

                            int SelectArrayIndex = m_nSelectedArrayIndex - 1;

                            CogRectangle Roi_Search = new CogRectangle();
                            CogRectangle Roi_Pattern = new CogRectangle();
                            CogRectangle Roi_DeepLearning = new CogRectangle();
                            CogRectangle Roi_PatternColor = new CogRectangle();

                            idx = DispMain.InteractiveGraphics.FindItem("Search", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_Search = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }
                            else
                            {
                                MessageBox.Show($"Roi 설정해주세요!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            idx = DispMain.InteractiveGraphics.FindItem("Pattern", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_Pattern = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }
                            else
                            {
                                MessageBox.Show($"Roi 설정해주세요!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            idx = DispMain.InteractiveGraphics.FindItem("DeepLearning", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_DeepLearning = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }
                            idx = DispMain.InteractiveGraphics.FindItem("PatternColor", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_PatternColor = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }


                            //PMAlign.Pattern.TrainImage = DispMain.Image;
                            //PMAlign.InputImage = DispMain.Image;
                            PMAlign.Pattern.TrainImage = m_imgSource_Mono;
                            PMAlign.InputImage = m_imgSource_Mono;
                            Cognex.VisionPro.CogRectangle CR = new CogRectangle();
                            CR.X = Roi_Pattern.X;
                            CR.Y = Roi_Pattern.Y;
                            CR.Width = Roi_Pattern.Width;
                            CR.Height = Roi_Pattern.Height;

                            PMAlign.Pattern.TrainRegion = CR;
                            PMAlign.SearchRegion = Roi_Search;

                            PMAlign.Pattern.Origin.TranslationX = (PMAlign.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterX;
                            PMAlign.Pattern.Origin.TranslationY = (PMAlign.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterY;

                            try
                            {
                                PMAlign.Pattern.Train();
                            }
                            catch
                            {
                                IF_Util.ShowMessageBox("Train Error", "Current Image Not Train!! Grab Image Index Change Please!!");
                                return;
                            }

                            m_Matching.PMAlignTools[nSelectedPM] = PMAlign;
                            InputLogic();

                            cogDisplay_JobPattern.InteractiveGraphics.Clear();
                            cogDisplay_JobPattern.StaticGraphics.Clear();
                            cogDisplay_JobPattern.Image = PMAlign.Pattern.GetTrainedPatternImage();
                            CVisionCognex.TrainGraphic(PMAlign, cogDisplay_JobPattern);
                            cogDisplay_JobPattern.Fit(true);
                            DisplayTrainCount(m_Matching);
                        }
                        break;

                    case "RUN":
                    case "INSP":
                    case "Find":
                        {
                            Stopwatch tactTime = Stopwatch.StartNew();
                            Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();
                            bool bol_Result = true;

                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            CogRectangle cogRectangle = new CogRectangle();
                            if (PMAlign.Pattern.Trained == false)
                            {
                                IF_Util.ShowMessageBox("Error", "Check to Pattern Trained");
                                return;
                            }
                            if (tbJobPattern_AcceptScore.Text != "")
                                PMAlign.RunParams.AcceptThreshold = double.Parse(tbJobPattern_AcceptScore.Text.ToString());

                            PMAlign.InputImage = m_imgSource_Mono;

                            DispMain.StaticGraphics.Add((Cognex.VisionPro.CogRectangle)PMAlign.SearchRegion, "main");

                            PMAlign.Run();
                            label.Font = new Font("Arial", 14);
                            label.LineWidthInScreenPixels = 5;
                            for (int i = 0; i < PMAlign.Results.Count; i++)
                            {
                                label.X = PMAlign.Results[i].GetPose().TranslationX;
                                label.Y = PMAlign.Results[i].GetPose().TranslationY - 20;
                            }

                            int count = int.Parse(tbPatternMasterCount.Text);
                            List<CogPMAlignResult> pMAlignResult = new List<CogPMAlignResult>();

                            Inspection_PatternMatching(PMAlign, false, out pMAlignResult);

                            int MasterCount = int.Parse(tbPatternMasterCount.Text.ToString());

                            if (MasterCount == 1)
                            {
                                double ResultAcceptedScore = double.Parse(tbJobPattern_MinScore.Text.ToString());
                                CogRectangle Roi_Search1 = PMAlign.SearchRegion as CogRectangle;
                                label.X = Roi_Search1.X;
                                label.Y = Roi_Search1.Y;

                                if (pMAlignResult != null)
                                {

                                    label.Text = $"Result Score:{pMAlignResult[0].Score.ToString("F3")} Min Score: {ResultAcceptedScore}";

                                    richtxtPatternResult.Text = $"Count : {pMAlignResult.Count} Score : {pMAlignResult[0].Score:F3} > (spec){ResultAcceptedScore:F3}";

                                    if (m_Matching.JudgeType_Judge_NaisNg == true)
                                    {
                                        if (pMAlignResult[0].Score < ResultAcceptedScore)
                                        {
                                            bol_Result = false;
                                        }
                                    }
                                    else
                                    {
                                        if (pMAlignResult[0].Score > ResultAcceptedScore)
                                        {
                                            bol_Result = false;
                                        }
                                    }
                                }
                                else
                                {

                                    label.Text = $"Count NG Not Find";
                                    bol_Result = false;
                                }

                            }
                            else
                            {
                                int ResultAcceptedCount = 0;
                                CogRectangle Roi_Search = PMAlign.SearchRegion as CogRectangle;
                                label.X = Roi_Search.X;
                                label.Y = Roi_Search.Y;

                                if (pMAlignResult != null)
                                {
                                    foreach (var item in pMAlignResult)
                                    {
                                        if (item.Accepted)
                                        {
                                            ResultAcceptedCount++;
                                        }
                                    }
                                    if (ResultAcceptedCount != MasterCount)
                                    {
                                        label.Text = $"Count NG Find:{ResultAcceptedCount}  Master:{MasterCount}";
                                        bol_Result = false;
                                    }
                                    else
                                    {
                                        label.Text = $"Count OK Find:{ResultAcceptedCount}  Master:{MasterCount}";
                                    }

                                    richtxtPatternResult.Text = $"Count : {pMAlignResult.Count} Score : {pMAlignResult[0].Score:F3}";
                                }
                                else
                                {

                                    label.Text = $"Count NG Find:{ResultAcceptedCount}  Master:{MasterCount}";
                                    bol_Result = false;
                                }
                            }

                            if (bol_Result)
                            {
                                label.Color = CogColorConstants.Green;
                                cogRectangle.Color = CogColorConstants.Green;
                            }
                            else
                            {
                                label.Color = CogColorConstants.Red;
                                cogRectangle.Color = CogColorConstants.Red;
                            }

                            idx = DispMain.InteractiveGraphics.FindItem("Result", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);

                            if (idx > 0)
                            {
                                DispMain.InteractiveGraphics.Remove(idx);
                            }

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)label, "Result", false);

                            tactTime.Stop();
                        }
                        break;

                    case "CUT ROI":
                        {
                            PMAlign.InputImage = m_imgSource_Mono;
                            PMAlign.Run();

                            CogPMAlignResult result = null;
                            double dMaxScore = 0.0D;
                            for (int i = 0; i < PMAlign.Results.Count; i++)
                            {
                                if (dMaxScore < PMAlign.Results[i].Score)
                                {
                                    dMaxScore = PMAlign.Results[i].Score;
                                    result = PMAlign.Results[i];
                                }
                            }

                            if (result == null)
                            {
                                IF_Util.ShowMessageBox("ERROR", "Can't Find the Board Pattern");
                                return;
                            }

                            m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(IF_Util.Crop(m_imgSource_Color.ToBitmap(), new Rectangle((int)result.GetPose().TranslationX, (int)result.GetPose().TranslationY, PMAlign.Pattern.TrainImage.Width, PMAlign.Pattern.TrainImage.Height)));
                            DispMain.Image = m_imgSource_Color;
                            DispMain.Fit(true);
                        }
                        break;

                    case "MASK":
                    case "Mask":
                        {
                            //FormPopUp_Settings_Masking Frm = new FormPopUp_Settings_Masking(m_selectedJob, m_imgSource_Mono);
                            //Frm.ShowDialog();

                            //cogDisplay_JobPattern.InteractiveGraphics.Clear();
                            //cogDisplay_JobPattern.StaticGraphics.Clear();

                            //CVisionCognex.TrainGraphic(m_selectedJob.Tool, cogDisplay_JobPattern);

                            //cogDisplay_JobPattern.Image = m_selectedJob.Tool.Pattern.GetTrainedPatternImage();
                            //cogDisplay_JobPattern.Fit(false);
                        }
                        break;
                    case "Delete":
                        {
                            m_Matching.PMAlignTools[nSelectedPM] = new CogPMAlignTool();
                            m_Matching.PMAlignTools[nSelectedPM].SearchRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(m_LogicInfo.PosX - 150, m_LogicInfo.PosY - 150, 200, 200));
                            m_Matching.PMAlignTools[nSelectedPM].Pattern.TrainRegion = CCognexUtil.RectangleToCogRectangle(m_Logic.SearchRegion);
                            DisplayTrainCount(m_Matching);
                            DispPattern(m_Matching, true);
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }
        public bool Inspection_PatternMatching(CogPMAlignTool PMAlign, bool useResultGrapic, out List<CogPMAlignResult> resultList)
        {
            resultList = new List<CogPMAlignResult>();
            if (PMAlign.Results == null || PMAlign.Results.Count == 0)
            {
                resultList = null;
                return false;
            }
            if (!useResultGrapic)
            {
                resultList.Add(CVisionCognex.GetBestResult_PMAlign(PMAlign));
            }
            else
            {
                for (int i = 0; i < PMAlign.Results.Count; i++)
                {
                    Cognex.VisionPro.CogCompositeShape resultDrawing = PMAlign.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion);
                    //cogDisplay_Source.InteractiveGraphics.Add(PMAlign.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                    DispMain.StaticGraphics.Add(resultDrawing, "main");
                    resultList.Add(PMAlign.Results[i]);
                }
            }
            return true;
        }
        private void OnClickAlgorithm_Condensor(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as UIButton).Text;

                if (strIndex != "Complete")
                {
                    DispMain.InteractiveGraphics.Clear();
                    DispMain.StaticGraphics.Clear();
                }
                IF_VisionParam_Condensor m_Condensor = (m_Logic as IF_VisionParam_Condensor);

                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            CogRectangle cogSearchRegion = new CogRectangle();
                            if (m_Condensor.SearchRegion.Width != 0 && m_Condensor.SearchRegion.Height != 0)
                                cogSearchRegion = CConverter.RectToCogRect(m_Condensor.SearchRegion);
                            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 100;
                            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 100;

                            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.Color = CogColorConstants.Red;
                            cogSearchRegion.SelectedColor = CogColorConstants.Red;

                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);

                            m_Condensor.Find_Circle.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                            m_Condensor.Find_Circle.RunParams.NumCalipers = 8;
                            //m_selectedJob.Find_Circle.RunParams.NumToIgnore = 2;
                            //m_selectedJob.Find_Circle.RunParams.CaliperRunParams.ContrastThreshold = 5;
                            //m_selectedJob.Find_Circle.RunParams.CaliperRunParams.FilterHalfSizeInPixels = 5;

                            CogGraphicCollection cogRegions;
                            ICogRecord cogRecord;

                            m_Condensor.Find_Circle.InputImage = new CogImage8Grey(m_imgSource_Mono);
                            m_Condensor.Find_Circle.CurrentRecordEnable = CogFindCircleCurrentRecordConstants.All;

                            cogRecord = m_Condensor.Find_Circle.CreateCurrentRecord();
                            CogCircularArc cogSegment = (CogCircularArc)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
                            cogRegions = (CogGraphicCollection)cogRecord.SubRecords["InputImage"].SubRecords["CaliperRegions"].Content;
                            DispMain.InteractiveGraphics.Add(cogSegment, "ExpectedShapeSegment", false);

                            if (cogRegions == null) return;
                            foreach (ICogGraphic g in cogRegions) DispMain.InteractiveGraphics.Add((ICogGraphicInteractive)g, "CaliperRegions", false);
                            (sender as UIButton).Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            if (idx < 0)
                            {
                                if ((sender as UIButton).Text != "Find")
                                {
                                    (sender as UIButton).Text = "Roi";
                                    return;
                                }
                            }

                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_Condensor.SearchRegion = CConverter.CogRectToRect(roi);
                            (sender as UIButton).Text = "Roi";
                            InputLogic();
                        }
                        break;
                    case "FIND":
                    case "Find":
                        {
                            using (Bitmap bitmap = m_imgSource_Color.ToBitmap())
                            {
                                Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
                                IF_Util.SetImageChannel1(img);

                                Bitmap imgResult = m_imgSource_Color.ToBitmap();
                                if (m_Condensor.ImgProcessingList.Count != 0)
                                {
                                    img = PreProcessor.ExecutePreProcessing(img, m_Condensor);
                                }

                                //if (chkUseFilter1.Checked)
                                //{
                                //    int kernelW = int.Parse(txtFilter1_KernelW.Text);
                                //    int kernelH = int.Parse(txtFilter1_KernelH.Text);

                                //    img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter1Type.SelectedIndex, kernelW, kernelH);
                                //}

                                //if (chkUseFilter2.Checked)
                                //{
                                //    int kernelW = int.Parse(txtFilter2_KernelW.Text);
                                //    int kernelH = int.Parse(txtFilter2_KernelH.Text);

                                //    img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter2Type.SelectedIndex, kernelW, kernelH);
                                //}

                                m_Condensor.CondensorRectWidth = int.Parse(tbCircleRectW.Text);
                                m_Condensor.CondensorRectHeight = int.Parse(tbCircleRectH.Text);
                                m_Condensor.CondensorRadiusOffset = int.Parse(tbCondensorRectRadio.Text);
                                m_Condensor.CondensorTypeTB = radioCondensorTB.Checked;

                                Inspection_Circle(new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img)), comboCondensorPolarity.Text);
                                //InputLogic();
                            }
                        }
                        break;
                    case "INSP":
                    case "Inspection":
                        {
                            using (Bitmap bitmap = m_imgSource_Color.ToBitmap())
                            {
                                Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
                                IF_Util.SetImageChannel1(img);

                                Bitmap imgResult = m_imgSource_Color.ToBitmap();
                                if (m_Condensor.ImgProcessingList.Count != 0)
                                {
                                    img = PreProcessor.ExecutePreProcessing(img, m_Condensor);
                                }

                                m_Condensor.CondensorRectWidth = int.Parse(tbCircleRectW.Text);
                                m_Condensor.CondensorRectHeight = int.Parse(tbCircleRectH.Text);
                                m_Condensor.CondensorTypeTB = radioCondensorTB.Checked;
                                m_Condensor.CondensorRadiusOffset = int.Parse(tbCondensorRectRadio.Text);
                                Inspection_Circle(new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img)), comboCondensorPolarity.Text);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        public void Inspection_Circle(CogImage8Grey img = null, string resultDir = "B")
        {
            string ResultTime;

            Stopwatch tactTime = new Stopwatch();
            tactTime.Start();
            if (m_Condensor == null) m_Condensor = (m_Logic as IF_VisionParam_Condensor);

            if (img == null) m_Condensor.Find_Circle.InputImage = m_imgSource_Mono;
            else m_Condensor.Find_Circle.InputImage = img;

            m_Condensor.Find_Circle.Run();

            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            try
            {
                if (m_Condensor.Find_Circle.Results == null || m_Condensor.Find_Circle.Results.NumPointsFound < m_Condensor.MinFoundCount)
                {
                    ResultTime = $"Result : N/A TactTime : {tactTime.ElapsedMilliseconds}ms";
                    CCognexUtil.DrawText(DispMain, new Point2d(100, 100), ResultTime, CogColorConstants.Red);
                }
                else if (m_Condensor.Find_Circle.Results != null && m_Condensor.Find_Circle.Results.Count > 0)
                {
                    for (int i = 0; i < m_Condensor.Find_Circle.Results.Count; i++)
                    {
                        DispMain.StaticGraphics.Add(m_Condensor.Find_Circle.Results[i].CreateResultGraphics(CogFindCircleResultGraphicConstants.All), "RESULT");
                    }

                    CogCircle resultGraphic = m_Condensor.Find_Circle.Results.GetCircle();

                    if (resultGraphic != null)
                    {
                        DispMain.StaticGraphics.Add(resultGraphic, "resultGraphic");

                        Rectangle boundingBox = IF_Util.BondingBox_Circle((int)resultGraphic.CenterX, (int)resultGraphic.CenterY, (int)resultGraphic.Radius, 50);

                        int offsetSize = boundingBox.Width / 2;
                        int offsetWidth = m_Condensor.CondensorRectWidth;
                        int offsetHeight = m_Condensor.CondensorRectHeight;

                        using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()).Clone())
                        {
                            IF_Util.SetImageChannel1(imgOrg);

                            CogRectangle Find_rect = new CogRectangle();
                            string str_value = "";
                            string str_Group = "";
                            double posX = 0;
                            double posY = 0;

                            // top to bottom
                            if (m_Condensor.CondensorTypeTB)
                            {
                                CogRectangle meanRectTop = new CogRectangle();
                                meanRectTop.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + offsetSize / 4 - m_Condensor.CondensorRadiusOffset, offsetWidth, offsetHeight);

                                CogRectangle meanRectBtm = new CogRectangle();
                                meanRectBtm.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height - offsetSize / 4 + m_Condensor.CondensorRadiusOffset, offsetWidth, offsetHeight);

                                Rect rect_top = CConverter.CogRectToCVRect(meanRectTop);
                                Rect rect_bottom = CConverter.CogRectToCVRect(meanRectBtm);

                                // roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width
                                int t_colstart = rect_top.X + rect_top.Width;
                                if (imgOrg.Width < t_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Top Position Rectgle!!");
                                    return;
                                }

                                int b_colstart = rect_bottom.X + rect_bottom.Width;
                                if (imgOrg.Width < b_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Bottom Position Rectgle!!");
                                    return;
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

                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectTop.X, meanRectTop.Y - 20), $"Brightness : {meanValues["T"].ToString("F3")}", CogColorConstants.Blue);
                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectBtm.X, meanRectBtm.Y - 20), $"Brightness : {meanValues["B"].ToString("F3")}", CogColorConstants.Blue);

                                    if (brightnestKey == "T")
                                    {
                                        posX = meanRectTop.X;
                                        posY = meanRectTop.Y - 20;
                                        Find_rect = meanRectTop;
                                        str_Group = "meanRectTop";
                                        str_value = $"Brightness : {meanValues["T"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectTop.X, meanRectTop.Y - 20), $"Brightness : {meanValues["T"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectTop, "meanRectTop");
                                    }
                                    else if (brightnestKey == "B")
                                    {
                                        posX = meanRectBtm.X;
                                        posY = meanRectBtm.Y - 20;
                                        Find_rect = meanRectBtm;
                                        str_Group = "meanRectBtm";
                                        str_value = $"Brightness : {meanValues["B"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectBtm.X, meanRectBtm.Y - 20), $"Brightness : {meanValues["B"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectBtm, "meanRectBtm");
                                    }

                                    CogColorConstants RESULT_COLOR;

                                    string nResult;
                                    // OK
                                    if (brightnestKey == resultDir)
                                    {
                                        Find_rect.Color = CogColorConstants.Green;
                                        RESULT_COLOR = CogColorConstants.Green;
                                        nResult = "OK";
                                    }
                                    // NG
                                    else
                                    {
                                        Find_rect.Color = CogColorConstants.Red;
                                        RESULT_COLOR = CogColorConstants.Red;
                                        nResult = "NG";
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY), str_value, CogColorConstants.Blue);
                                    DispMain.StaticGraphics.Add(Find_rect, str_Group);

                                    ResultTime = $"Result : {nResult}, Brightness : {brightnestKey} TactTime : {tactTime.ElapsedMilliseconds}ms";
                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY - 20), ResultTime, RESULT_COLOR);


                                }
                            }
                            else
                            {
                                CogRectangle meanRectLeft = new CogRectangle();
                                meanRectLeft.SetCenterWidthHeight(boundingBox.X + offsetSize / 4 - m_Condensor.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                                CogRectangle meanRectRight = new CogRectangle();
                                meanRectRight.SetCenterWidthHeight(boundingBox.X + boundingBox.Width - offsetSize / 4 + m_Condensor.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                                Rect rect_left = CConverter.CogRectToCVRect(meanRectLeft);
                                Rect rect_right = CConverter.CogRectToCVRect(meanRectRight);

                                int l_colstart = rect_left.X + rect_left.Width;
                                if (imgOrg.Width < l_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Left Position Rectgle!!");
                                    return;
                                }

                                int r_colstart = rect_right.X + rect_right.Width;
                                if (imgOrg.Width < r_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Right Position Rectgle!!");
                                    return;
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

                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectLeft.X, meanRectLeft.Y - 20), $"Brightness : {meanValues["L"].ToString("F3")}", CogColorConstants.Blue);
                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectRight.X, meanRectRight.Y - 20), $"Brightness : {meanValues["R"].ToString("F3")}", CogColorConstants.Blue);

                                    if (brightnestKey == "L")
                                    {
                                        posX = meanRectLeft.X;
                                        posY = meanRectLeft.Y - 20;
                                        Find_rect = meanRectLeft;
                                        str_Group = "meanRectLeft";
                                        str_value = $"Brightness : {meanValues["L"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectLeft.X, meanRectLeft.Y - 20), $"Brightness : {meanValues["L"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectLeft, "meanRectLeft");
                                    }
                                    else
                                    {
                                        posX = meanRectRight.X;
                                        posY = meanRectRight.Y - 20;
                                        Find_rect = meanRectRight;
                                        str_Group = "meanRectRight";
                                        str_value = $"Brightness : {meanValues["R"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectRight.X, meanRectRight.Y - 20), $"Brightness : {meanValues["R"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectRight, "meanRectRight");

                                    }

                                    CogColorConstants RESULT_COLOR;

                                    string nResult;
                                    // OK
                                    if (brightnestKey == resultDir)
                                    {
                                        Find_rect.Color = CogColorConstants.Green;
                                        RESULT_COLOR = CogColorConstants.Green;
                                        nResult = "OK";
                                    }
                                    // NG
                                    else
                                    {
                                        Find_rect.Color = CogColorConstants.Red;
                                        RESULT_COLOR = CogColorConstants.Red;
                                        nResult = "NG";
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY), str_value, CogColorConstants.Blue);
                                    DispMain.StaticGraphics.Add(Find_rect, str_Group);

                                    ResultTime = $"Result : {nResult}, Brightness : {brightnestKey} TactTime : {tactTime.ElapsedMilliseconds}ms";
                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY - 20), ResultTime, RESULT_COLOR);

                                }
                            }
                        }
                    }
                    else
                    {
                        IF_Util.ShowMessageBox("Error", "Find Circle Results Empty");
                    }
                }
                else
                {
                    IF_Util.ShowMessageBox("Error", "Find Circle Results Empty");
                }
            }
            catch
            {
                IF_Util.ShowMessageBox("Error", "Find Circle And No Rectgle Results Not Brightness Empty");
            }
        }



        private void OnClickAlgorithm_ColorEx(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as UIButton).Text;

                m_ColorEx = (m_Logic as IF_VisionParam_ColorEx);

                if (DispMain.Image == null || DispMain.Image.Allocated == false)
                {
                    IF_Util.ShowMessageBox("Error", "Check the Image");
                    return;
                }
                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            if (m_ColorEx.SearchRegion.Width == 0 || m_ColorEx.SearchRegion.Height == 0)
                            {
                                m_ColorEx.SearchRegion = new Rectangle(0, 0, 100, 100);
                            }
                            //검사 영역
                            Cognex.VisionPro.CogRectangle cogSearchRegion = CConverter.RectToCogRect(m_ColorEx.SearchRegion);
                            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.LineWidthInScreenPixels = 2;
                            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 250;
                            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 250;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);
                            (sender as UIButton).Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            if (idx < 0)
                            {
                                if ((sender as UIButton).Text != "Find")
                                {
                                    (sender as UIButton).Text = "Roi";
                                    return;
                                }
                            }
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_ColorEx.SearchRegion = CConverter.CogRectToRect(roi);
                            (sender as UIButton).Text = "Roi";
                            InputLogic();
                        }
                        break;
                    case "RUN":
                    case "INSP":
                    case "Find":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            Stopwatch tt = Stopwatch.StartNew();

                            using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), m_ColorEx.SearchRegion)).Clone())
                            {

                            }

                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                (sender as UIButton).Text = "Roi";
            }
        }
        private void OnClickAlgorithm_EYED_ColorEx(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as UIButton).Text;

                m_EYED = (m_Logic as IF_VisionParam_EYED);

                if (DispMain.Image == null || DispMain.Image.Allocated == false)
                {
                    IF_Util.ShowMessageBox("Error", "Check the Image");
                    return;
                }
                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            if (m_EYED.ColorExRegion.Width == 0 || m_EYED.ColorExRegion.Height == 0)
                            {
                                m_EYED.SearchRegion = new Rectangle(0, 0, 100, 100);
                            }
                            //검사 영역
                            Cognex.VisionPro.CogRectangle cogSearchRegion = CConverter.RectToCogRect(m_EYED.ColorExRegion);
                            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.LineWidthInScreenPixels = 2;
                            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 250;
                            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 250;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);
                            (sender as UIButton).Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            if (idx < 0)
                            {
                                if ((sender as UIButton).Text != "Find")
                                {
                                    (sender as UIButton).Text = "Roi";
                                    return;
                                }
                            }
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_EYED.ColorExRegion = CConverter.CogRectToRect(roi);
                            (sender as UIButton).Text = "Roi";
                            InputLogic();
                        }
                        break;
                    case "RUN":
                    case "INSP":
                    case "Find":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            Stopwatch tt = Stopwatch.StartNew();

                            using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), m_ColorEx.SearchRegion)).Clone())
                            {

                            }

                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                (sender as UIButton).Text = "Roi";
            }
        }
        Mat _imageSourceCV = null;

        private void OnClickAlgorithm_Pin(object sender, EventArgs e)
        {
            try
            {
                m_Pin = (m_Logic as IF_VisionParam_Pin);

                string action = (sender as UIButton).Text;

                if (DispMain.Image == null || DispMain.Image.Allocated == false)
                {
                    IF_Util.ShowMessageBox("Error", "Check the Image");
                    return;
                }

                switch (action)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            DispMain.Fit();

                            // Search 영역
                            CogRectangle cogSearchRegion = CCognexUtil.RectangleToCogRectangle(m_Pin.SearchRegion);
                            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.Color = CogColorConstants.Red;
                            cogSearchRegion.SelectedColor = CogColorConstants.Red;


                            if (cogSearchRegion.Width == 0 || cogSearchRegion.Height == 0)
                            {
                                cogSearchRegion.Width = 100;
                                cogSearchRegion.Height = 100;
                            }

                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);
                            (sender as UIButton).Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            if (idx < 0)
                            {
                                if ((sender as UIButton).Text != "Find" && (sender as UIButton).Text != "Master")
                                {
                                    (sender as UIButton).Text = "Roi";
                                    return;
                                }
                            }
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_Pin.SearchRegion = CConverter.CogRectToRect(roi);
                            (sender as UIButton).Text = "Roi";
                        }
                        break;
                    case "FIND":
                    case "Find":
                        {
                            DispMain.InteractiveGraphics.Clear();

                            _imageSourceCV = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()).Clone();

                            using (Mat imgRoi = _imageSourceCV.SubMat(CConverter.RectToCVRect(m_Pin.SearchRegion)).Clone())
                            {

                                Scalar scalar = imgRoi.Mean();

                                // 평균 색상 값을 BGR 형식으로 각각 추출
                                byte meanB = (byte)scalar.Val0;
                                byte meanG = (byte)scalar.Val1;
                                byte meanR = (byte)scalar.Val2;

                                Color extractColor = Color.FromArgb(meanR, meanG, meanB);
                                string colorStr = $"R:{meanR},G:{meanG},B:{meanB}";

                                List<(Rectangle, int)> rects = CVision.Contour2(imgRoi, m_Pin.Pin_Threshold, m_Pin.Pin_AreaMin, m_Pin.Pin_AreaMax, m_Pin.Pin_BinaryInv);

                                DispMain.Image = m_imgSource_Color;

                                int masterCnt = m_Pin.Pin_Boundaries.Count;

                                List<(bool, Rectangle)> masterRects = new List<(bool, Rectangle)>();
                                for (int i = 0; i < m_Pin.Pin_Boundaries.Count; i++)
                                {
                                    masterRects.Add((false, m_Pin.Pin_Boundaries[i]));
                                }

                                if (rects.Count > 0)
                                {
                                    for (int i = 0; i < rects.Count; i++)
                                    {
                                        for (int compareIdx = 0; compareIdx < masterRects.Count; compareIdx++)
                                        {
                                            if (masterRects[compareIdx].Item1 == true) continue;

                                            if (rects[i].Item1.IntersectsWith(masterRects[compareIdx].Item2))
                                            {
                                                masterRects[compareIdx] = (true, masterRects[compareIdx].Item2);

                                                CogRectangle cogRect = new CogRectangle();
                                                cogRect.X = rects[i].Item1.X + m_Pin.SearchRegion.X;
                                                cogRect.Y = rects[i].Item1.Y + m_Pin.SearchRegion.Y;
                                                cogRect.Width = rects[i].Item1.Width;
                                                cogRect.Height = rects[i].Item1.Height;
                                                cogRect.Color = CogColorConstants.Green;

                                                CCognexUtil.DrawString(DispMain, $"Area : {rects[i].Item2}", new Point2d(cogRect.X, cogRect.Y), cogRect.Color, 10);
                                                DispMain.StaticGraphics.Add(cogRect, "RT");

                                                break;
                                            }
                                        }
                                    }
                                }

                                for (int i = 0; i < masterRects.Count; i++)
                                {
                                    CogRectangle cogRect = new CogRectangle();
                                    cogRect.X = masterRects[i].Item2.X + m_Pin.SearchRegion.X;
                                    cogRect.Y = masterRects[i].Item2.Y + m_Pin.SearchRegion.Y;
                                    cogRect.Width = masterRects[i].Item2.Width;
                                    cogRect.Height = masterRects[i].Item2.Height;

                                    if (masterRects[i].Item1 == true)
                                    {
                                        cogRect.Color = CogColorConstants.Green;
                                    }
                                    else
                                    {
                                        cogRect.Color = CogColorConstants.Red;
                                    }

                                    DispMain.StaticGraphics.Add(cogRect, "RT");
                                }
                            }
                        }
                        break;
                    case "Master":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            Mat _imageSourceCV = null;
                            _imageSourceCV = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()).Clone();


                            using (Mat imgRoi = _imageSourceCV.SubMat(CConverter.RectToCVRect(m_Pin.SearchRegion)).Clone())
                            {
                                List<(Rectangle, int)> rects = CVision.Contour2(imgRoi, m_Pin.Pin_Threshold, m_Pin.Pin_AreaMin, m_Pin.Pin_AreaMax, m_Pin.Pin_BinaryInv);

                                DispMain.Image = m_imgSource_Color;

                                if (rects.Count > 0)
                                {
                                    m_Pin.Pin_Boundaries.Clear();

                                    for (int i = 0; i < rects.Count; i++)
                                    {
                                        Rectangle specRect = rects[i].Item1;
                                        specRect.X = specRect.X + specRect.Width / 2 - m_Pin.Pin_SpecRoiWidth / 2;
                                        specRect.Y = specRect.Y + specRect.Height / 2 - m_Pin.Pin_SpecRoiHeight / 2;
                                        specRect.Width = m_Pin.Pin_SpecRoiWidth;
                                        specRect.Height = m_Pin.Pin_SpecRoiHeight;

                                        m_Pin.Pin_Boundaries.Add(specRect);

                                        OpenCvSharp.Rect masterRect = new Rect();

                                        masterRect.X = m_Pin.SearchRegion.X + specRect.X;
                                        masterRect.Y = m_Pin.SearchRegion.Y + specRect.Y;
                                        masterRect.Width = m_Pin.Pin_SpecRoiWidth;
                                        masterRect.Height = m_Pin.Pin_SpecRoiHeight;

                                        CogRectangle cogMasterRect = CConverter.CVRectToCogRect(masterRect);
                                        cogMasterRect.Color = CogColorConstants.Green;

                                        CCognexUtil.DrawString(DispMain, $"Area : {rects[i].Item2}", new Point2d(cogMasterRect.X, cogMasterRect.Y), CogColorConstants.Red, 10);
                                        DispMain.StaticGraphics.Add(cogMasterRect, "RT");
                                    }
                                }
                            }
                            InputLogic();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        public void InputLogic()
        {
            try
            {

                if (m_Job.Library.TryGetValue(m_nSelectedArrayIndex, out var logicList))
                {
                    var updatedList = new List<IF_VisionLogicInfo>(logicList); // 기존 리스트 복사
                    int targetIndex = updatedList.FindIndex(l => l.LocationNo == m_LogicInfo.LocationNo);

                    if (targetIndex != -1)
                    {
                        updatedList[targetIndex] = m_LogicInfo; // 기존 값 업데이트
                        m_Job.Library.TryUpdate(m_nSelectedArrayIndex, updatedList, logicList); // 원본 리스트와 비교 후 업데이트
                    }
                }
            }
            catch
            {
            }
        }
        public void DisplayTrainCount(IF_VisionParam_Matching matchingCount)
        {
            // Train 숫자를 표시한다.
            int nTrain = 0;
            for (int i = 0; i < matchingCount.PMAlignTools.Length; i++)
            {
                if (matchingCount.PMAlignTools[i].Pattern.Trained) nTrain++;
            }

            lblSubPatternInfo.Text = $"Index ({nTrain:D2}/05)";
        }
        public void Set_Library(bool addLogic)
        {
            try
            {
                if (m_Job.Library.Count < m_nSelectedArrayIndex) return;
                if (addLogic == false)
                {
                    List<object[]> rowDataList = new List<object[]>();
                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {
                        rowDataList.Add(new object[] { info.LocationNo, info.Enabled, info.PartCode, info.Logics.Count, info.PosAngle });
                    }
                    Invoke_Util.Set_Invoke_DataGridView(DgvJobList, rowDataList);
                    //DgvJobList.Rows.Add(new object[] { info.LocationNo, info.Enabled, info.PartCode, info.PosAngle, info.Logics.Count });
                }
                if (DgvJobList.Rows.Count > 0)
                {

                    DgvJobList.Rows[m_SelectedJob].Selected = true; // 첫 번째 행 선택
                    m_SelectedLocationNo = DgvJobList[0, m_SelectedJob].Value.ToString();

                }
                if (addLogic)
                {
                    int LogicCount = 0;
                    DgvLogicList.Rows[m_SelectedLogic].Selected = true;
                    LogicCount = (int)DgvJobList.Rows[m_SelectedJob].Cells[3].Value;
                    LogicCount++;
                    DgvJobList.Rows[m_SelectedJob].Cells[3].Value = LogicCount.ToString();
                }

            }
            catch
            {
            }

        }
        #region [Calibration Part]

        // 폴더까지만
        private string iqResultRootPath = $"{Application.StartupPath}\\LIBRARY\\IMAGE_QUALITY";
        private IQResultData iqResultDatas = new IQResultData();
        private Bitmap iqResultImage = null;
        private bool IsLive = false;
        Bitmap iqImage = null;
        Bitmap iqAlphaImage = null;
        Graphics g = null;

        private void btnIQCalibration_Click(object sender, EventArgs e)
        {
            UISymbolButton btn = (UISymbolButton)sender;

            switch (btn.Tag)
            {
                case "IQStart":
                    bool IsContinuous = cbIQContinuous.Checked;
                    IQStart(IsContinuous);
                    break;

                case "IQStop":
                    IQStop();
                    break;
            }
        }

        public static DateTime Delay(int ms)
        {
            DateTime now = DateTime.Now;
            DateTime after = now.Add(new TimeSpan(0, 0, 0, 0, ms));

            while (now < after)
            {
                System.Windows.Forms.Application.DoEvents();
                now = DateTime.Now;
            }
            return DateTime.Now;
        }

        /// <summary>
        /// 캘리브레이션 시작
        /// </summary>
        /// <param name="IsContinuous"> 반복 유무 </param>
        private void IQStart(bool IsContinuous)
        {
            // 반복 캘리브레이션

            if (IsContinuous == true)
            {
                if (Global.Instance.Device.Cameras.Count > 0)
                {
                    CogRectangle guideLine = GetCalibrationROI();

                    if (guideLine == null) return;
                    DispMain.StaticGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)guideLine, "Guide Line");
                    if (Global.Device.Cameras[0].IsLive) IsLive = true;
                    else IsLive = false;
                    if (IsLive == false)
                    {
                        DispMain.InteractiveGraphics.Clear();
                        DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)guideLine, "Guide Line", false);
                        Calibration(false);
                        MessageBox.Show($"카메라가 Live 상태가 아닙니다.", "카메라 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    while (IsLive)
                    {
                        Calibration(true);
                        //Thread.Sleep(1000);
                        Delay(1000);
                        DispMain.InteractiveGraphics.Clear();

                        //Task.Delay(1000);
                    }
                }
                else
                {
                    MessageBox.Show($"카메라가 연결중인 상태가 아닙니다.", "카메라 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 1회 캘리브레이션
            else
            {
                DispMain.InteractiveGraphics.Clear();
                CogRectangle guideLine = GetCalibrationROI();

                if (guideLine == null) return;

                DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)guideLine, "Guide Line", false);
                Calibration(false);
                //IQResultSave(iqResultDatas, guideLine);
            }
        }


        /// <summary>
        /// 캘리브레이션 반복 기능 종료
        /// </summary>
        private void IQStop()
        {
            IsLive = false;
            DispMain.InteractiveGraphics.Clear();
        }

        /// <summary>
        /// 캘리브레이션 데이터 저장
        /// </summary>
        private void IQResultSave(CogRectangle guideLine)
        {
            //string filePath = GetIQSavePath();

            //    using (StreamWriter writer = new StreamWriter(filePath, append: false))
            //    {
            //        string jsonLine = System.Text.Json.JsonSerializer.Serialize(data);
            //        writer.WriteLine(jsonLine);
            //    }
            using (System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.SkyBlue, 20))
            {
                g.DrawRectangle(pen, CCognexUtil.CogRectangleToRectangle(guideLine));
            }
            try { IF_Util.SafetyImageSave($"{iqResultRootPath}\\IQ_Preview.bmp", iqImage); } catch (Exception ex) { }
            cogdis_IQPreView.Image = new CogImage24PlanarColor(iqImage);
            cogdis_IQPreView.Fit(false);
            Bitmap transparentimg = iqAlphaImage.Clone(new Rectangle(0, 0, iqAlphaImage.Width, iqAlphaImage.Height), PixelFormat.Format32bppArgb);
            //transparentimg = AdjustTransparencyPixel(transparentimg, 0.4f);
            //using (Graphics g_Alpha = Graphics.FromImage(transparentimg))
            //{
            //    ImageAttributes imgAttr = new ImageAttributes();

            //    ColorMatrix matrix = new ColorMatrix
            //    {
            //        Matrix33 = 0.0f
            //    };
            //    imgAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //    imgAttr.ClearColorKey();
            //    g_Alpha.DrawImage(transparentimg, new Rectangle(0, 0, transparentimg.Width, transparentimg.Height),
            //        0, 0, transparentimg.Width, transparentimg.Height, GraphicsUnit.Pixel, imgAttr);
            //}
            try { IF_Util.SafetyImageSave($"{iqResultRootPath}\\IQ_AlphaImage.png", transparentimg); } catch (Exception ex) { }
            // 저장 데이터 형태
            // {"Time":"2025-02-05T12:34:56","FocusValue":0.85,"UniformityValues":[{"X":10.5,"Y":20.3,"Value":0.75}]}
            // {"Time":"2025-02-05T13:00:12","FocusValue":0.90,"UniformityValues":[{ "X":7.2,"Y":12.9,"Value":0.89}]}
            // {"Time":"11:43:56","FocusValue":24.076000000000001,"UniformityValues":[{"X":0,"Y":0,"Value":81.790000000000006},{"X":1,"Y":0,"Value":83.409999999999997},{"X":2,"Y":0,"Value":77.739999999999995},{"X":0,"Y":1,"Value":91.280000000000001},{"X":1,"Y":1,"Value":93.200000000000003},{"X":2,"Y":1,"Value":88.569999999999993},{"X":0,"Y":2,"Value":84.260000000000005},{"X":1,"Y":2,"Value":87.680000000000007},{"X":2,"Y":2,"Value":80.930000000000007}]}
        }
        public static Bitmap AdjustTransparencyPixel(Bitmap image, float alpha)
        {
            Bitmap newBitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    Color newColor = Color.FromArgb((int)(originalColor.A * alpha), (int)(originalColor.R * alpha), (int)(originalColor.B * alpha));
                    newBitmap.SetPixel(x, y, newColor);
                }


            }
            return newBitmap;
        }




        object objLock = new object();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="useCamera"></param>
        private void Calibration(bool useCamera)
        {

            // 1. 이미지 가져오기
            Mat src = null;

            // - 카메라를 사용하는 경우
            if (useCamera)
            {

                if (Global.Device.Cameras[0].ImageGrab != null)
                {
                    Global.Device.Cameras[0].Live(false);
                    Global.Device.Cameras[0].Grab(false);
                    bool successGrab = Global.Device.Cameras[0].IsGrabDone.WaitOne(1000);

                    if (successGrab)
                    {
                        src = BitmapConverter.ToMat(Global.Device.Cameras[0].ImageGrab).Clone();
                        iqImage = (Bitmap)Global.Device.Cameras[0].ImageGrab.Clone();
                        iqAlphaImage = (Bitmap)Global.Device.Cameras[0].ImageGrab.Clone();

                    }
                    Global.Device.Cameras[0].Live(true);
                }
                else
                {
                    MessageBox.Show($"카메라가 Live 상태가 아닙니다.", "카메라 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // - 이미지를 직접 로드하는 경우
            else
            {
                //CogImage24PlanarColor
                src = BitmapConverter.ToMat(((CogImage24PlanarColor)DispMain.Image).ToBitmap()).Clone();
                iqImage = (Bitmap)DispMain.Image.ToBitmap().Clone();
                iqAlphaImage = (Bitmap)DispMain.Image.ToBitmap().Clone();
            }


            //DispMain.InteractiveGraphics.Clear();
            // 2. Focus 계산
            // - 라플라시안 적용
            Mat laplacian = new Mat();
            Cv2.Laplacian(src, laplacian, MatType.CV_64F);

            // - 분산(Variance) 계산
            Mat mean = new Mat();
            Mat stddev = new Mat();
            Cv2.MeanStdDev(laplacian, mean, stddev);
            double variance = Math.Pow(stddev.At<double>(0), 2);

            // - Current Focus 값 출력
            double currentFocusValue = Math.Round(variance, 3);
            if (lbCurrentFocusValue.InvokeRequired)
            {
                lbCurrentFocusValue.Invoke(new MethodInvoker(() =>
                {
                    lbCurrentFocusValue.Text = $"Current Focus Value : {currentFocusValue}";
                }));
            }
            else
            {
                lbCurrentFocusValue.Text = $"Current Focus Value : {currentFocusValue}";
            }


            // - Best Focus 값 출력
            double bestFocusValue = double.Parse(lbBestFocusValue.Text.Replace("Best Focus Value : ", ""));
            if (currentFocusValue > bestFocusValue)
            {
                if (lbBestFocusValue.InvokeRequired)
                {
                    lbBestFocusValue.Invoke(new MethodInvoker(() =>
                    {
                        lbBestFocusValue.Text = $"Best Focus Value : {currentFocusValue}";
                    }));
                }
                else
                {
                    lbBestFocusValue.Text = $"Best Focus Value : {currentFocusValue}";
                }
            }


            // 3. Uniformity 계산
            int divisions = 3; // 2로 변경하면 4등분, 3이면 9등분
            int width = src.Cols;
            int height = src.Rows;
            int cellWidth = width / divisions;
            int cellHeight = height / divisions;
            List<UniformityValue> uniformityValues = new List<UniformityValue>();
            if (iqImage != null)
            {
                g = Graphics.FromImage(iqImage);
            }

            for (int row = 0; row < divisions; row++)
            {
                for (int col = 0; col < divisions; col++)
                {
                    // - 각 구역의 ROI 설정
                    Rect roi = new Rect(col * cellWidth, row * cellHeight, cellWidth, cellHeight);
                    Mat cell = new Mat(src, roi);

                    // - 평균 밝기 계산
                    Scalar meanBrightness = Cv2.Mean(cell);

                    // - 화면 출력
                    CogGraphicLabel label = new CogGraphicLabel();

                    // R, G, B 중에 최대/최소값 2개를 더하고 2로 나눈값이 밝기 값이다.
                    // 위 로직으로 바꿀것
                    double value = Math.Round(meanBrightness.Val0, 2);
                    label.Text = value.ToString();
                    label.X = cellWidth / 2 + (col * cellWidth);
                    label.Y = cellHeight / 2 + (row * cellHeight);
                    label.Color = CogColorConstants.Yellow;
                    label.Font = new Font("Tahoma", 13, FontStyle.Bold);
                    DispMain.InteractiveGraphics.Add(label, $"Label{col + row * divisions}", false);
                    using (System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow))
                    using (System.Drawing.Font font = new System.Drawing.Font("Tahoma", 150, FontStyle.Bold))
                    {
                        g.DrawString(value.ToString(), font, brush, (float)label.X - 300, (float)label.Y);
                    }
                    UniformityValue uniformityValue = new UniformityValue(col, row, Math.Round(value, 3));
                    uniformityValues.Add(uniformityValue);
                }
            }
            double masterWidth = double.Parse(tbMasterWidth.Text);
            double masterHeight = double.Parse(tbMasterHeight.Text);
            double pixelSize = double.Parse(tbPixelSize.Text);
            IQResultData resultData = new IQResultData();
            resultData.WidthValue = masterWidth;
            resultData.HeightValue = masterHeight;
            resultData.PixelValue = pixelSize;
            resultData.FocusValue = currentFocusValue;
            resultData.UniformityValues = uniformityValues;
            iqResultDatas = resultData;
        }

        /// <summary>
        /// 캘리브레이션에서 사용하는 ROI 영역 가져오기
        /// </summary>
        /// <returns> ROI </returns>
        private CogRectangle GetCalibrationROI()
        {
            // 1. 이미지 가져오기
            ICogImage src;
#if Samsung
            if (Global.Instance.Device.Cameras.Count > 0 && Global.Instance.Device.Cameras[0].ImageGrab != null && Global.Device.Cameras[0].IsLive)
            {
                src = (ICogImage)new CogImage24PlanarColor(Global.Instance.Device.Cameras[0].ImageGrab);

                /*CogImage24PlanarColor cogImage = new CogImage24PlanarColor(Global.Instance.Device.Cameras[0].ImageGrab);
                src = BitmapConverter.ToMat(cogImage.ToBitmap());*/
            }
#else
            // 이미지 변경
            src = (ICogImage)DispMain.Image;
#endif

            if (src == null) return null;

            // 2. 유효값 체크
            if (double.TryParse(tbMasterWidth.Text, out double width) == false)
            {
                MessageBox.Show($"'{tbMasterWidth.Text}' 유효한 값이 아닙니다.", "'MasterWidth' 입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (double.TryParse(tbMasterHeight.Text, out double height) == false)
            {
                MessageBox.Show($"'{tbMasterHeight.Text}' 유효한 값이 아닙니다.", "'MasterHeight' 입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (double.TryParse(tbPixelSize.Text, out double pixelSize) == false)
            {
                MessageBox.Show($"'{tbMasterHeight.Text}' 유효한 값이 아닙니다.", "'MasterHeight' 입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }

            // 3. 가이드라인 계산
            int widthPixel = (int)Math.Round(width / pixelSize, 0);
            int heightPixel = (int)Math.Round(height / pixelSize, 0);

            // 4. 이미지 크기 가져오기 
            int imageWidth = src.Width;
            int imageHeight = src.Height;

            // 5. 가이드라인 크기 체크
            if (widthPixel <= 0 || widthPixel > imageWidth)
            {
                MessageBox.Show($"'{widthPixel}' 유효한 값이 아닙니다.", "'Width Size' 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }

            if (heightPixel <= 0 || heightPixel > imageHeight)
            {
                MessageBox.Show($"'{heightPixel}' 유효한 값이 아닙니다.", "'Height Size' 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // 6. ROI 계산 및 반환
            double imageHalfWidth = imageWidth / 2;
            double imageHalfHeight = imageHeight / 2;
            double masterHalfWidth = (widthPixel / 2);
            double masterHalfHeight = (heightPixel / 2);

            int startX = (int)(imageHalfWidth - masterHalfWidth);
            int startY = (int)(imageHalfHeight - masterHalfHeight);
            //int endX = (int)(imageHalfWidth + masterHalfWidth);
            //int endY = (int)(imageHalfHeight + masterHalfHeight);

            CogRectangle guideLine = new CogRectangle();
            guideLine.X = startX;
            guideLine.Y = startY;
            guideLine.Width = widthPixel;
            guideLine.Height = heightPixel;

            return guideLine;
        }

        /// <summary>
        /// ICogImage를 roi 크기로 크롭
        /// </summary>
        /// <param name="image"> 대상 이미지 </param>
        /// <param name="roi"> 크롭 영역 </param>
        /// <returns> 크롭된 ICogImage </returns>
        private ICogImage cogImageCrop(ICogImage image, CogRectangle roi)
        {
            /*CogRectangle roi = new CogRectangle();
            roi.SetXYWidthHeight(200, 200, 1000, 1000);*/

            CogCopyRegionTool cogCopyRegionTool = new CogCopyRegionTool();
            cogCopyRegionTool.InputImage = image;
            cogCopyRegionTool.Region = roi;
            cogCopyRegionTool.Run();

            /*CogImage24PlanarColor outputImage = (CogImage24PlanarColor)cogCopyRegionTool.OutputImage;
            DispMain.Image = outputImage;*/

            return cogCopyRegionTool.OutputImage;
        }

        [Serializable]
        private class IQResultData
        {
            public double WidthValue { get; set; }
            public double HeightValue { get; set; }
            public double PixelValue { get; set; }
            public double FocusValue { get; set; }
            public List<UniformityValue> UniformityValues { get; set; }

            public IQResultData()
            {
            }

            public void Save()
            {
                string path = $"{Application.StartupPath}\\LIBRARY\\IMAGE_QUALITY\\Quality.json";
                string forderpath = $"{Application.StartupPath}\\LIBRARY\\IMAGE_QUALITY";
                string currRecipe;

                try
                {
                    currRecipe = JsonConvert.SerializeObject(this, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Newtonsoft.Json.Formatting.Indented
                    });

                    if (!Directory.Exists(forderpath)) Directory.CreateDirectory(forderpath);

                    if (File.Exists(path))
                    {
                        //이전값과 비교하여 바뀐 부분 로깅
                        string prevRecipe = File.ReadAllText(path);

                        JObject previousObject = JObject.Parse(prevRecipe);
                        JObject currentObject = JObject.Parse(currRecipe);

                        var result = JToken.DeepEquals(previousObject, currentObject);

                    }

                    File.WriteAllText(path, currRecipe);
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
            public IQResultData Load()
            {
                string path = $"{Application.StartupPath}\\LIBRARY\\IMAGE_QUALITY\\Quality.json";

                IQResultData newData = null;

                if (File.Exists(path))
                {
                    newData = JsonConvert.DeserializeObject<IQResultData>(File.ReadAllText(path), new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Newtonsoft.Json.Formatting.Indented
                    });

                    if (newData != null)
                        return newData;
                }

                newData = new IQResultData();
                newData.Save();


                return newData;
            }
        }

        [Serializable]
        private class UniformityValue
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Value { get; set; }

            public UniformityValue(double x, double y, double value)
            {
                this.X = x;
                this.Y = y;
                this.Value = value;
            }
        }

        private void Init_Controls()
        {
            cbbMethod.Items.Clear();

            Array enumArr = Enum.GetValues(typeof(ImageProcessingMethod));

            foreach (ImageProcessingMethod enumName in enumArr)
            {
                cbbMethod.Items.Add(enumName);
            }


            DataGridViewColumn dataGridViewColumn1 = new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvParameter.Columns.Add(dataGridViewColumn1);

            DataGridViewColumn dataGridViewColumn2 = new DataGridViewTextBoxColumn
            {
                Name = "Value",
                HeaderText = "Value",
                DataPropertyName = "Value",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgvParameter.Columns.Add(dataGridViewColumn2);
            cbbMethod.SelectedIndex = 0;
        }

        public TEnum ParseEnum<TEnum>(string value, TEnum defaultValue = default) where TEnum : struct, Enum
        {
            if (Enum.TryParse<TEnum>(value, true, out TEnum result) && Enum.IsDefined(typeof(TEnum), result))
            {
                return result;
            }
            return defaultValue;  // 기본값 반환
        }
        public float ParseFloat(string value, float defaultValue = 0)
        {
            return float.TryParse(value, out float result) ? result : defaultValue;
        }

        public double ParseDouble(string value, double defaultValue = 0)
        {
            return double.TryParse(value, out double result) ? result : defaultValue;
        }

        public int ParseInt(string value, int defaultValue = 0)
        {
            return int.TryParse(value, out int result) ? result : defaultValue;
        }

        public bool ParseBool(string value, bool defaultValue = false)
        {
            return bool.TryParse(value, out bool result) ? result : defaultValue;
        }

        public enum EqualizationType
        {
            EqualizeHist, CLAHE
        }
        #endregion
        #region [Library Part]
        private void btnSelectServerFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string masterPath = folderDialog.SelectedPath;
                    TvServer.Nodes.Clear();
                    LoadServerFolder(masterPath);
                    lb_Library_ServerName.Text = masterPath;
                }
            }
        }
        private void btnSelectLocalFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string localPath = folderDialog.SelectedPath;
                    TvLocal.Nodes.Clear();
                    LoadLocalFolder(localPath);
                    lb_Library_LocalName.Text = localPath;
                }
            }
        }
        private void LoadServerFolder(string masterPath)
        {
            foreach (var pcbCodeDir in Directory.GetDirectories(masterPath))
            {
                var pcbNode = TvServer.Nodes.Add(Path.GetFileName(pcbCodeDir));

                string libraryPath = Path.Combine(pcbCodeDir, "Library");
                if (Directory.Exists(libraryPath))
                {
                    var libNode = pcbNode.Nodes.Add("LocationNo + PartCode");
                    LoadRecipeJson(libNode, libraryPath);
                }

                string partPath = Path.Combine(pcbCodeDir, "Part");
                if (Directory.Exists(partPath))
                {
                    var partNode = pcbNode.Nodes.Add("PartCode");
                    LoadRecipeJson(partNode, partPath);
                }
            }
        }
        private void LoadLocalFolder(string localPath)
        {
            foreach (var modelDir in Directory.GetDirectories(localPath))
            {
                var modelNode = TvLocal.Nodes.Add(Path.GetFileName(modelDir));
                if (Directory.Exists(modelDir))
                {
                    //var libNode = pcbNode.Nodes.Add("Library");
                    LoadRecipeJson(modelNode, modelDir);
                }

            }
        }
        private void LoadRecipeJson(TreeNode parentNode, string path)
        {
            string recipePath = Path.Combine(path, "Recipe.Json");

            if (!File.Exists(recipePath))
            {
                parentNode.Nodes.Add("[Recipe.Json 없음]");
                return;
            }

            var recipeNode = parentNode.Nodes.Add("Recipe.Json");

            try
            {
                string jsonText = File.ReadAllText(recipePath);
                JObject recipe = JObject.Parse(jsonText);

                JObject library = recipe["Library"] as JObject;
                if (library == null)
                {
                    recipeNode.Nodes.Add("[Library 항목 없음]");
                    return;
                }

                foreach (var group in library)
                {
                    if (!int.TryParse(group.Key, out int groupIndex))
                        continue; // "1", "2" 가 아닌 $type 등은 무시

                    var groupNode = recipeNode.Nodes.Add($"Array : {groupIndex}");

                    var groupValues = group.Value["$values"] as JArray;
                    if (groupValues == null) continue;

                    int jobIndex = 1;
                    foreach (var job in groupValues)
                    {
                        string partCode = job["PartCode"]?.ToString() ?? "N/A";
                        string locationNo = job["LocationNo"]?.ToString() ?? "N/A";
                        string logicCount = job["LogicCount"]?.ToString() ?? "N/A";
                        var jobNode = groupNode.Nodes.Add($"{jobIndex++} : {locationNo}, {partCode} ({logicCount})");

                        var logicArray = job["Logics"]?["$values"] as JArray;
                        if (logicArray != null)
                        {
                            foreach (var logic in logicArray)
                            {
                                string logicName = logic["Name"]?.ToString() ?? "(Unnamed Logic)";
                                jobNode.Nodes.Add($"Logic: {logicName}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                recipeNode.Nodes.Add($"[오류] {ex.Message}");
            }
        }
        //private void btnLibraryClick(object sender, EventArgs e)
        //{
        //    UISymbolButton btn = (UISymbolButton)sender;

        //    switch (btn.Tag)
        //    {
        //        case "Server": // 서버 공유 폴더 경로 설정
        //            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        //            {
        //                folderDialog.Description = "폴더를 선택하세요.";
        //                folderDialog.RootFolder = Environment.SpecialFolder.Desktop;

        //                if (folderDialog.ShowDialog() == DialogResult.OK)
        //                {
        //                    lb_Library_ServerName.Text = folderDialog.SelectedPath;
        //                }
        //            }
        //            break;
        //        case "Local": // 로컬 폴더 경로 설정
        //            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        //            {
        //                folderDialog.Description = "폴더를 선택하세요.";
        //                folderDialog.RootFolder = Environment.SpecialFolder.Desktop;

        //                if (folderDialog.ShowDialog() == DialogResult.OK)
        //                {
        //                    lb_Library_LocalName.Text = folderDialog.SelectedPath;
        //                }
        //            }
        //            break;
        //        case "Refresh": // 리스트 다시 로드
        //            dgv_Library_ServerList.Rows.Clear();
        //            dgv_Library_LocalList.Rows.Clear();
        //            LoadJobList(lb_Library_ServerName.Text, dgv_Library_ServerList);
        //            LoadJobList(lb_Library_LocalName.Text, dgv_Library_LocalList);
        //            break;
        //        case "Clear": // 리스트 클리어
        //            dgv_Library_ServerList.Rows.Clear();
        //            dgv_Library_LocalList.Rows.Clear();
        //            break;
        //        case "Update": // 로컬 폴더 파일을 서버 공유 폴더로 업데이트
        //            // 0. 데이터 가져오기
        //            // - 서버 공유 폴더에서 잡리스트 객체 가져오기
        //            List<LibraryManager> serverList = new List<LibraryManager>();
        //            // - 로컬 폴더에서 잡리스트 객체 가져오기
        //            List<LibraryManager> localList = new List<LibraryManager>();
        //            // - 저장할 잡리스트
        //            List<LibraryManager> updateList = new List<LibraryManager>();

        //            // 1. 업데이트할 잡 리스트 선별
        //            foreach (LibraryManager localRecipe in localList)
        //            {
        //                // 1-1. 서버 폴더에 누락된 잡 리스트 체크해서 업데이트 큐에 등록
        //                bool IsPass = true;

        //                foreach (LibraryManager serverRecipe in serverList)
        //                {
        //                    if (localRecipe.Name == serverRecipe.Name)
        //                    {
        //                        // 1-2. 서버 폴더에 있는 경우 서버 폴더 객체의 해쉬값과 비교해서 다르면 업데이트 큐에 등록
        //                        if (localRecipe.GetHash() != serverRecipe.GetHash())
        //                        {
        //                            IsPass = false;
        //                            break;
        //                        }
        //                    }
        //                }

        //                if (IsPass == false)
        //                {
        //                    // 업데이트 큐에 현재 localRecipe 넣기
        //                    updateList.Add(localRecipe);
        //                }
        //            }

        //            // 2. 업데이트 큐가 1개 이상인 경우 큐에 있는 객체를 서버 폴더에 덮어쓰기 저장
        //            foreach (LibraryManager recipe in updateList)
        //            {
        //                string path = ""; // $@"{jobRecipeFolderPath}\{recipe.Name}.json";

        //                using (Stream savestream = new FileStream(path, FileMode.Create))
        //                {
        //                    // JSON 문자열로 변환
        //                    string jsonString = System.Text.Json.JsonSerializer.Serialize(recipe, new JsonSerializerOptions { WriteIndented = true });

        //                    // JSON 파일로 저장
        //                    File.WriteAllText(path, jsonString);
        //                }
        //            }
        //            break;
        //    }
        //}

        ///// <summary>
        ///// 경로에 있는 LibraryManager(Job Recipe) 리스트를 DataGridView에 로드 한다.
        ///// </summary>
        ///// <param name="folderPath"> 경로 </param>
        ///// <param name="dgv"> 뷰어 </param>
        //private void LoadJobList(string folderPath, DataGridView dgv)
        //{
        //    string[] jobRecipes = Directory.GetFiles(folderPath);

        //    // jobRecipe 데이터 하나씩 가져와서 이름, 설명, 업데이트날짜 데이터를 DateGridView에 추가한다.

        //    foreach (string name in jobRecipes)
        //    {
        //        string filePath = Path.Combine(folderPath, name);
        //        MasterLibraryManager recipe = Json.Deserialize<MasterLibraryManager>(filePath);
        //        recipe.GetHashCode();
        //    }

        //}

        ///// <summary>
        ///// DataGridView에 LibraryManager(Job Recipe) 데이터를 추가 한다.
        ///// </summary>
        ///// <param name="dgv"> 뷰어 </param>
        ///// <param name="obj"> 레시피 객체 </param>
        ///// <param name="color"> 
        ///// 색상 
        ///// - 검정색 : 일반
        ///// - 주황색 : 업데이트 필요
        ///// </param>
        //public void AddRow(DataGridView dgv, LibraryManager jobRecipe, Color color)
        //{
        //    if (dgv.InvokeRequired)
        //    {
        //        try
        //        {
        //            this.Invoke(new MethodInvoker(() =>
        //            {
        //                AddRow(dgv, jobRecipe, color);
        //            }));
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //    else
        //    {
        //        //일정 숫자 이상 삭제
        //        if (dgv.Rows.Count > 1000) dgv.Rows.Clear();

        //        int newIndex = dgv.Rows.Add();

        //        dgv.FirstDisplayedScrollingRowIndex = newIndex;

        //        dgv.Rows[newIndex].DefaultCellStyle.ForeColor = color;
        //    }
        //}

        ///// <summary>
        ///// Library 리스트를 출력할 DataGridView 초기화
        ///// </summary>
        //private void InitLibraryUI()
        //{
        //    dgv_Library_ServerList.Font = new Font("Arial", 12, FontStyle.Regular);
        //    dgv_Library_LocalList.Font = new Font("Arial", 12, FontStyle.Regular);



        //}
        #endregion

        private void BtnGerberLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Global.m_MainPJTRoot;
                ofd.Filter = "Gerber Files(*.xlsx)|*.xlsx";
                int iCount = 0;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    TbGerberPath.Text = ofd.FileName;
                    Global.System.Recipe.LoadedGerber = Global.System.Recipe.LibraryManager.LoadGerber(ofd.FileName);
                    DgvGerberInfo.Rows.Clear();
                    List<IF_VisionLogicInfo> library = Global.System.Recipe.LoadedGerber.Library[1];
                    foreach (IF_VisionLogicInfo info in library)
                    {
                        DgvGerberInfo.Rows.Add(new object[] { info.LocationNo, info.PartCode, info.Enabled, $"X: {info.PosX.ToString()}, Y: {info.PosY.ToString()}", info.PosAngle });
                        iCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReplaceLibrary_Click(object sender, EventArgs e)
        {
            if (Global.System.Recipe.LoadedGerber != null)
            {
                LibraryManager newLibrary = new LibraryManager();
                //Global.System.Recipe.LibraryManager.Library = new System.Collections.Concurrent.ConcurrentDictionary<int, List<IF_VisionLogicInfo>>();
                IF_VisionLogicInfo newPart = new IF_VisionLogicInfo();
                DgvJobList.Rows.Clear();
                DgvLogicList.Rows.Clear();
                m_Job = new LibraryManager();

                for (int i = 0; i < Global.System.Recipe.LoadedGerber.Library.Count; i++)
                {
                    //if (Global.System.Recipe.LibraryManager.Library.ContainsKey(i + 1)) Global.System.Recipe.LibraryManager.Library[i + 1].Clear();
                    newLibrary.Library[i + 1] = Global.System.Recipe.LoadedGerber.Library[1]
                        .Select(item => (IF_VisionLogicInfo)item.Clone()).ToList();

                    List<IF_VisionLogicInfo> copyLibrary = new List<IF_VisionLogicInfo>();

                    foreach (IF_VisionLogicInfo info in newLibrary.Library[i + 1])
                    {

                        if (Global.System.Recipe.MasterPartLibrary.Library.ContainsKey(i + 1))
                        {
                            if (Global.System.Recipe.MasterPartLibrary.Library.TryGetValue(i + 1, out var List))
                            {
                                var partLibraryList = new List<IF_VisionLogicInfo>(List); // 마스터 파트라이브러리 복사
                                int logicsIndex = partLibraryList.FindIndex(l => l.PartCode == info.PartCode);

                                if (logicsIndex != -1)
                                {
                                    IF_VisionLogicInfo copyPart = partLibraryList[logicsIndex];
                                    if (info.LocationNo == partLibraryList[logicsIndex].LocationNo)
                                    {
                                        copyLibrary.Add(CopyJob(copyPart, 0, 0));// LocationNo 가 같으면 마스터 info 그대로 가져오고
                                    }
                                    else
                                    {
                                        int shiftX = info.PosX - copyPart.PosX;
                                        int shiftY = info.PosY - copyPart.PosY;

                                        IF_VisionLogicInfo copyinfo = new IF_VisionLogicInfo();
                                        List<IF_VisionParamObject> copylogics = new List<IF_VisionParamObject>();
                                        copyinfo.LocationNo = info.LocationNo;
                                        copyinfo.PartCode = copyPart.PartCode;
                                        copyinfo.PosX = info.PosX;
                                        copyinfo.PosY = info.PosY;
                                        copyinfo.PosAngle = info.PosAngle;
                                        copyinfo.Description = info.Description;
                                        copyinfo.Enabled = info.Enabled;
                                        if (chkEnalbenouse.Checked == false) copyinfo.Enabled = true;
                                        copylogics = new List<IF_VisionParamObject>();
                                        foreach (IF_VisionParamObject logic in copyPart.Logics)
                                        {
                                            copylogics.Add(CopyLogic(logic, copyPart.PosX, copyPart.PosY, shiftX, shiftY));

                                        }
                                        copyinfo.Logics = copylogics;
                                        copyLibrary.Add(copyinfo);
                                    }
                                }
                                else
                                {
                                    copyLibrary.Add(DefaultJobImport(info));
                                }
                            }
                        }
                        else
                        {
                            copyLibrary.Add(DefaultJobImport(info));
                        }
                    }

                    m_Job.Library.TryAdd(i + 1, copyLibrary);
                    //Global.System.Recipe.LibraryManager.Library[i + 1] = newLibrary.Library[i + 1]
                    //    .Select(item => (IF_VisionLogicInfo)item.Clone()).ToList();
                }
                //SetRecipeInfo();
                IF_Util.ShowMessageBox("Complete", "Auto Gerber Import Complete");
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Should to Load the Gerber File first");
            }
        }
        //private List<IF_VisionParamObject> LogicInfoClone(IF_VisionLogicInfo partInfo, int shiftX, int shiftY)
        //{
        //    List<IF_VisionParamObject> newLogics = new List<IF_VisionParamObject>();

        //    for (int i = 0; i < partInfo.Logics.Count; i++)
        //    {
        //        switch (partInfo.Logics[i].Type)
        //        {
        //            case "Pattern":
        //                IF_VisionParam_Matching newMatching = new IF_VisionParam_Matching();
        //                IF_VisionParam_Matching partMatching = new IF_VisionParam_Matching();
        //                partMatching = partInfo.Logics[i] as IF_VisionParam_Matching;
        //                newMatching = (IF_VisionParam_Matching)partMatching.Clone();
        //                for (int k = 0; k < partMatching.PMAlignTools.Length; k++)
        //                {
        //                    Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();
        //                    Cognex.VisionPro.CogRectangle cogTrainRegion = new CogRectangle();
        //                    // 먼저 part에 있는 패턴툴 자체 가져오기
        //                    newMatching.PMAlignTools[k] = new CogPMAlignTool(partMatching.PMAlignTools[k]);
        //                    //처음에 배열 5개 초기화하기때문에 Pattern 등록을 안해놨을 수도 있음.
        //                    if (newMatching.PMAlignTools[k].SearchRegion != null)
        //                    {
        //                        // 모든 Pattern SearchRegion X,Y 위치 Shift
        //                        cogSearchRegion = (Cognex.VisionPro.CogRectangle)newMatching.PMAlignTools[k].SearchRegion;
        //                        cogSearchRegion.X = cogSearchRegion.X + shiftX;
        //                        cogSearchRegion.Y = cogSearchRegion.Y + shiftY;
        //                        // Shift 후 newMatching 에 다시 넣어줌
        //                        newMatching.PMAlignTools[k].SearchRegion = cogSearchRegion;

        //                        // 모든 Pattern TrainRegion Shift X,Y 위치 Shift
        //                        cogTrainRegion = (Cognex.VisionPro.CogRectangle)newMatching.PMAlignTools[k].Pattern.TrainRegion;
        //                        cogTrainRegion.X = cogTrainRegion.X + shiftX;
        //                        cogTrainRegion.Y = cogTrainRegion.Y + shiftY;
        //                        // Shift 후 newMatching 에 다시 넣어줌
        //                        newMatching.PMAlignTools[k].Pattern.TrainRegion = cogTrainRegion;
        //                    }
        //                    else
        //                    {
        //                        newMatching.PMAlignTools[k].SearchRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(partInfo.PosX - 150, partInfo.PosY - 150, 200, 200));
        //                        newMatching.PMAlignTools[k].Pattern.TrainRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(partInfo.PosX - 100, partInfo.PosY - 100, 100, 100));
        //                    }

        //                }
        //                newLogics.Add(newMatching);
        //                break;
        //            case "EYE-D":
        //                IF_VisionParam_EYED newEyeD = new IF_VisionParam_EYED();
        //                IF_VisionParam_EYED partEyeD = new IF_VisionParam_EYED();
        //                partEyeD = partInfo.Logics[i] as IF_VisionParam_EYED;
        //                newEyeD = (IF_VisionParam_EYED)partEyeD.Clone();
        //                newEyeD.SearchRegion = new Rectangle(partEyeD.SearchRegion.X + shiftX, partEyeD.SearchRegion.Y + shiftY,
        //                partEyeD.SearchRegion.Width, partEyeD.SearchRegion.Height);
        //                newEyeD.SpecRegion = new Rectangle(partEyeD.SpecRegion.X + shiftX, partEyeD.SpecRegion.Y + shiftY,
        //                partEyeD.SpecRegion.Width, partEyeD.SpecRegion.Height);
        //                newLogics.Add(newEyeD);
        //                break;
        //            case "Condensor":
        //                IF_VisionParam_Condensor newCondensor = new IF_VisionParam_Condensor();
        //                IF_VisionParam_Condensor partCondensor = new IF_VisionParam_Condensor();
        //                partCondensor = partInfo.Logics[i] as IF_VisionParam_Condensor;
        //                newCondensor = (IF_VisionParam_Condensor)partCondensor.Clone();
        //                // CogCircularArc CenterX,Y 위치 Shift
        //                newCondensor.Find_Circle = new CogFindCircleTool(partCondensor.Find_Circle);

        //                ICogRecord cogRecord;
        //                cogRecord = newCondensor.Find_Circle.CreateCurrentRecord();
        //                CogCircularArc cogSegment = (CogCircularArc)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
        //                cogSegment.CenterX = cogSegment.CenterX + shiftX;
        //                cogSegment.CenterY = cogSegment.CenterY + shiftY;

        //                // SearchRoi X,Y 위치 Shift
        //                newCondensor.SearchRegion = new Rectangle(partCondensor.SearchRegion.X + shiftX, partCondensor.SearchRegion.Y + shiftY,
        //                    partCondensor.SearchRegion.Width, partCondensor.SearchRegion.Height);

        //                newLogics.Add(newCondensor);
        //                break;
        //            case "ColorEx":
        //                IF_VisionParam_ColorEx newColorEx = new IF_VisionParam_ColorEx();
        //                IF_VisionParam_ColorEx partColorEx = new IF_VisionParam_ColorEx();
        //                partColorEx = partInfo.Logics[i] as IF_VisionParam_ColorEx;
        //                newColorEx = (IF_VisionParam_ColorEx)partColorEx.Clone();
        //                newColorEx.SearchRegion = new Rectangle(partColorEx.SearchRegion.X + shiftX, partColorEx.SearchRegion.Y + shiftY,
        //                    partColorEx.SearchRegion.Width, partColorEx.SearchRegion.Height);
        //                newLogics.Add(newColorEx);
        //                break;
        //            case "Pin":
        //                IF_VisionParam_Pin newPin = new IF_VisionParam_Pin();
        //                IF_VisionParam_Pin partPin = new IF_VisionParam_Pin();
        //                partPin = partInfo.Logics[i] as IF_VisionParam_Pin;
        //                newPin = (IF_VisionParam_Pin)partPin.Clone();
        //                newPin.SearchRegion = new Rectangle(partPin.SearchRegion.X + shiftX, partPin.SearchRegion.Y + shiftY,
        //                partPin.SearchRegion.Width, partPin.SearchRegion.Height);
        //                newLogics.Add(newPin);
        //                break;

        //        }
        //    }
        //    return newLogics;
        //}
        private IF_VisionLogicInfo DefaultJobImport(IF_VisionLogicInfo partInfo)
        {
            IF_VisionLogicInfo defaultJob = partInfo;
            IF_VisionParamObject Logic = new IF_VisionParam_Matching();
            List<IF_VisionParamObject> Logics = new List<IF_VisionParamObject>();
            IF_VisionParam_Matching matching = new IF_VisionParam_Matching();
            IF_VisionParam_Condensor condensor = new IF_VisionParam_Condensor();
            IF_VisionParam_EYED eyeD = new IF_VisionParam_EYED();
            if (Logic is IF_VisionParam_Matching)
            {
                matching = Logic as IF_VisionParam_Matching;
                for (int j = 0; j < matching.PMAlignTools.Length; j++)
                {
                    matching.PMAlignTools[j].SearchRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(partInfo.PosX - 150, partInfo.PosY - 150, 200, 200));
                    matching.PMAlignTools[j].Pattern.TrainRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(partInfo.PosX - 100, partInfo.PosY - 100, 100, 100));
                }
                Logics.Add(matching);
            }
            else if (Logic is IF_VisionParam_Condensor)
            {
                ICogRecord cogRecord;
                cogRecord = condensor.Find_Circle.CreateCurrentRecord();
                CogCircularArc cogSegment = (CogCircularArc)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
                cogSegment.CenterX = partInfo.PosX - 150;
                cogSegment.CenterY = partInfo.PosY - 150;
                Logics.Add(condensor);
            }
            else if (Logic is IF_VisionParam_EYED)
            {
                eyeD = Logic as IF_VisionParam_EYED;
                eyeD.SpecRegion = new Rectangle(partInfo.PosX - 100, partInfo.PosY - 100, 50, 50);
                Logics.Add(eyeD);
            }
            if (partInfo.LocationNo == "RY7D") partInfo.Enabled = true;
            if (chkEnalbenouse.Checked == false) partInfo.Enabled = true;
            if (partInfo.Enabled) Logic.JudgeType_Judge_NaisNg = false;
            else Logic.JudgeType_Judge_NaisNg = true;

            Logic.Enabled = true;
            Logic.GrabIndex = 0;
            Logic.Name = "Via";
            Logic.Type = "Pattern";
            Logic.SearchRegion = new Rectangle(partInfo.PosX - 100, partInfo.PosY - 100, 100, 100);

            defaultJob.Logics = Logics;
            return defaultJob;
        }
        private void BtnRegionVisible_Click(object sender, EventArgs e)
        {
            if (DispMain == null || Global.System.Recipe.LoadedGerber == null)
            {
                IF_Util.ShowMessageBox("Error", "Should to Load the Gerber File first");
                return;
            }

            DispMain.Image = new CogImage24PlanarColor(IF_Util.Crop(_imagesGrab[0].ToBitmap(), Global.System.Recipe.FiducialLibrary.RegionArray1));
            DispMain.InteractiveGraphics.Clear();
            CogGraphicInteractiveCollection cg = new CogGraphicInteractiveCollection();

            foreach (IF_VisionLogicInfo info in Global.System.Recipe.LoadedGerber.Library[1])
            {
                if (!info.Enabled) continue;
                Rectangle tempRect = new Rectangle(info.PosX - 100 / 2, info.PosY - 100 / 2, 100, 100);
                CogRectangle rect = CConverter.RectToCogRect(tempRect);
                cg.Add(rect);
            }
            DispMain.InteractiveGraphics.AddList(cg, "GerberROI", true);
        }

        private void DgvJobList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DgvJobList.SelectedRows.Count > 0)
                {
                    m_SelectedJob = DgvJobList.SelectedRows[0].Index;
                    m_SelectedLogic = DgvJobList.SelectedRows[0].Index;
                    m_SelectedLocationNo = DgvJobList[0, m_SelectedJob].Value.ToString();
                    m_SelectedPartCode = DgvJobList[2, m_SelectedJob].Value.ToString();
                    TbLocationNo.Text = m_SelectedLocationNo.ToString();
                    TbPartName.Text = m_SelectedPartCode.ToString();
                    DispMain.InteractiveGraphics.Clear();
                    DispMain.StaticGraphics.Clear();
                    DgvLogicList.Rows.Clear();
                    int idx = 0;

                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {
                        if (info.LocationNo == m_SelectedLocationNo)
                        {
                            m_LogicInfo = info;
                            if (info.Logics.Count > 0)
                            {
                                for (int i = 0; i < info.Logics.Count; i++)
                                {
                                    DgvLogicList.Rows.Add(new object[] { i + 1, info.Logics[i].Enabled, info.Logics[i].Name, info.Logics[i].GrabIndex,
                                        info.Logics[i].Type, info.Logics[i].JudgeType_Judge_NaisNg });
                                }
                                //m_Logic = null;
                                m_Logic = info.Logics[m_SelectedLogic];
                                //Selected_Logic(m_Logic, false);

                            }

                        }
                        idx++;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void DgvLogicList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DgvLogicList.SelectedRows.Count > 0)
                {
                    m_SelectedLogic = DgvLogicList.SelectedRows[0].Index;
                    bool enable = (bool)DgvLogicList[1, m_SelectedLogic].Value;
                    m_SelectedLogicName = DgvLogicList[2, m_SelectedLogic].Value.ToString();
                    string grabindex = DgvLogicList[3, m_SelectedLogic].Value.ToString();
                    string algorithm = DgvLogicList[4, m_SelectedLogic].Value.ToString();
                    string locationNo = m_SelectedLocationNo;
                    tbLogicName.Text = m_SelectedLogicName;
                    cbGrabIndex.SelectedItem = grabindex;
                    cbAlgorithm.SelectedItem = algorithm;
                    DispMain.InteractiveGraphics.Clear();
                    DispMain.StaticGraphics.Clear();
                    DgvProcessingList.Rows.Clear();
                    int idx = 0;
                    IF_ImageProcessing processing = null;
                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {
                        if (info.LocationNo == locationNo)
                        {
                            if (info.Logics.Count > 0)
                            {
                                m_Logic = info.Logics[m_SelectedLogic];
                                Selected_Logic(m_Logic, true);

                                for (int i = 0; i < m_Logic.ImgProcessingList.Count; i++)
                                {
                                    processing = m_Logic.ImgProcessingList[i.ToString()];
                                    DgvProcessingList.Rows.Add(new object[] { i + 1, processing.Type });
                                }

                            }
                        }
                        idx++;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        private void Selected_Logic(IF_VisionParamObject logic, bool bUpdateImage)
        {
            try
            {
                tpPattern.Disabled();
                tpEYED.Disabled();
                tpColorEx.Disabled();
                tpCondensor.Disabled();
                tpPin.Disabled();
                if (logic.JudgeType_Judge_NaisNg)
                {
                    BtnNA_ng.Selected = true;
                    BtnNA_ok.Selected = false;
                }
                else
                {
                    BtnNA_ng.Selected = false;
                    BtnNA_ok.Selected = true;
                }
                if (bUpdateImage)
                {
                    if (m_imgSource_Mono_FullBoard != null && m_imgSource_Mono_FullBoard.Allocated)
                    {
                        SelectGrabImage(logic.GrabIndex, false);
                        CropArray(m_nSelectedArrayIndex - 1);
                    }
                }

                switch (logic.Type)
                {
                    case "Pattern":
                        m_Matching = (logic as IF_VisionParam_Matching);
                        tbPatternMasterCount.Text = "1";
                        tbJobPattern_MinScore.Text = m_Matching.MinimumScore_forJudge.ToString();
                        tbJobPattern_AcceptScore.Text = m_Matching.MinimumScore_forFind.ToString();
                        DispPattern(m_Matching, true);
                        TabMenuLogic.SelectedIndex = 0;
                        tpPattern.SetEnabled();
                        if (btnJobPattern_Roi.Text != "ROI") btnJobPattern_Roi.Text = "ROI";
                        OnClickAlgorithm_Pattern(btnJobPattern_Roi, new EventArgs());
                        break;
                    case "EYE-D":
                        m_EYED = (logic as IF_VisionParam_EYED);
                        CbbModelList.SelectedItem = m_EYED.ModelName;
                        TbThresholdEYED.Text = m_EYED.Score.ToString();
                        switch (m_EYED.RotateDgree)
                        {
                            case 0:
                                CbRotateImageEYED.SelectedIndex = 0;
                                break;
                            case 90:
                                CbRotateImageEYED.SelectedIndex = 1;
                                break;
                            case 180:
                                CbRotateImageEYED.SelectedIndex = 2;
                                break;
                            case 270:
                                CbRotateImageEYED.SelectedIndex = 3;
                                break;
                        }
                        ChkSpecRegionEYED.Checked = m_EYED.UseSpecRegion;
                        chkEyeD_UseColor.Checked = m_EYED.UseColorExRegion;
                        txtEyeD_ColorEx_R.IntValue = m_EYED.MasterR;
                        txtEyeD_ColorEx_G.IntValue = m_EYED.MasterG;
                        txtEyeD_ColorEx_B.IntValue = m_EYED.MasterB;
                        if (m_EYED.Range == 15) radioColorEx_Range15.Checked = true;
                        if (m_EYED.Range == 30) radioColorEx_Range30.Checked = true;
                        if (m_EYED.Range == 45) radioColorEx_Range45.Checked = true;
                        TabMenuLogic.SelectedIndex = 1;
                        tpEYED.SetEnabled();
                        if (BtnRoiEYED.Text != "ROI") BtnRoiEYED.Text = "ROI";
                        OnClickAlgorithm_EyeD(BtnRoiEYED, new EventArgs());

                        break;
                    case "Condensor":
                        m_Condensor = (logic as IF_VisionParam_Condensor);
                        if (m_Condensor.CondensorTypeTB == false) { radioCondensorLR.Checked = true; radioCondensorTB.Checked = false; }
                        else { radioCondensorLR.Checked = false; radioCondensorTB.Checked = true; }
                        comboCondensorPolarity.Text = m_Condensor.CondensorPolarity;
                        tbCircleRectW.Text = m_Condensor.CondensorRectWidth.ToString();
                        tbCircleRectH.Text = m_Condensor.CondensorRectHeight.ToString();
                        tbCondensorRectRadio.Text = m_Condensor.CondensorRadiusOffset.ToString();
                        tbCircleContrast.Text = m_Condensor.Find_Circle.RunParams.CaliperRunParams.ContrastThreshold.ToString();
                        tbCircleThickness.Text = m_Condensor.Find_Circle.RunParams.CaliperRunParams.FilterHalfSizeInPixels.ToString();
                        tbIgnoreCount.Text = m_Condensor.Find_Circle.RunParams.NumToIgnore.ToString();
                        TabMenuLogic.SelectedIndex = 2;
                        tpCondensor.SetEnabled();
                        if (btnJobCondensor_Roi.Text != "ROI") btnJobCondensor_Roi.Text = "ROI";
                        OnClickAlgorithm_Condensor(btnJobCondensor_Roi, new EventArgs());
                        break;
                    case "ColorEx":
                        m_ColorEx = (logic as IF_VisionParam_ColorEx);
                        txtColorEx_R.IntValue = m_ColorEx.MasterR;
                        txtColorEx_G.IntValue = m_ColorEx.MasterG;
                        txtColorEx_B.IntValue = m_ColorEx.MasterB;
                        TbColorEXRangeMin_R.Text = m_ColorEx.RangeMinR.ToString();
                        TbColorEXRangeMax_R.Text = m_ColorEx.RangeMaxR.ToString();
                        TbColorEXRangeMin_G.Text = m_ColorEx.RangeMinG.ToString();
                        TbColorEXRangeMax_G.Text = m_ColorEx.RangeMaxG.ToString();
                        TbColorEXRangeMin_B.Text = m_ColorEx.RangeMinB.ToString();
                        TbColorEXRangeMax_B.Text = m_ColorEx.RangeMaxB.ToString();
                        Color MasterColor = Color.FromArgb(m_ColorEx.MasterR, m_ColorEx.MasterG, m_ColorEx.MasterB);
                        string colorStr = $"{m_ColorEx.MasterR},{m_ColorEx.MasterG},{m_ColorEx.MasterB}";
                        IF_Util.setLabel(lblJobColorEx_ResultColor, colorStr.ToString(), MasterColor);

                        TabMenuLogic.SelectedIndex = 3;
                        tpColorEx.SetEnabled();
                        if (btnJobColorEx_Roi.Text != "ROI") btnJobColorEx_Roi.Text = "ROI";
                        OnClickAlgorithm_ColorEx(btnJobColorEx_Roi, new EventArgs());
                        break;
                    case "Pin":
                        m_Pin = (logic as IF_VisionParam_Pin);
                        nb_Pin_OkCount.Value = m_Pin.Pin_OkCount;
                        nb_Pin_AreaMax.Value = m_Pin.Pin_AreaMax;
                        nb_Pin_AreaMin.Value = m_Pin.Pin_AreaMin;
                        nb_Pin_SpecRoi_Width.Value = m_Pin.Pin_SpecRoiWidth;
                        nb_Pin_SpecRoi_Height.Value = m_Pin.Pin_SpecRoiHeight;
                        nb_Pin_Threshold.Value = m_Pin.Pin_Threshold;
                        chk_Pin_BinaryInv.Checked = m_Pin.Pin_BinaryInv;
                        TabMenuLogic.SelectedIndex = 4;
                        tpPin.SetEnabled();
                        if (btnJobPin_Roi.Text != "ROI") btnJobPin_Roi.Text = "ROI";
                        OnClickAlgorithm_Pin(btnJobPin_Roi, new EventArgs());
                        break;
                }
            }
            catch
            {
            }
        }
        private void Selected_PreProcessing(IF_ImageProcessing imgPro)
        {
            try
            {
                switch (imgPro.Type)
                {
                    case ImageProcessingMethod.None:
                        break;
                    case ImageProcessingMethod.Equalization:
                        IF_VisionParam_Equalization equlization = (imgPro as IF_VisionParam_Equalization);
                        LoadParametersToDataGridView(equlization, dgvParameter);
                        break;
                    case ImageProcessingMethod.GammaCorrection:
                        IF_VisionParam_GammaCorrection gammacorrection = (imgPro as IF_VisionParam_GammaCorrection);
                        LoadParametersToDataGridView(gammacorrection, dgvParameter);

                        break;
                    case ImageProcessingMethod.Binarization:
                        IF_VisionParam_Binarization binarization = (imgPro as IF_VisionParam_Binarization);
                        LoadParametersToDataGridView(binarization, dgvParameter);

                        break;
                    case ImageProcessingMethod.Morphology:
                        IF_VisionParam_Morphology morphology = (imgPro as IF_VisionParam_Morphology);
                        LoadParametersToDataGridView(morphology, dgvParameter);
                        break;
                    case ImageProcessingMethod.MedianFilter:
                        IF_VisionParam_MedianBlur medianfilter = (imgPro as IF_VisionParam_MedianBlur);
                        LoadParametersToDataGridView(medianfilter, dgvParameter);
                        break;
                    case ImageProcessingMethod.SobelFilter:
                        IF_VisionParam_SobelFilter sobelfilter = (imgPro as IF_VisionParam_SobelFilter);
                        LoadParametersToDataGridView(sobelfilter, dgvParameter);
                        break;
                    case ImageProcessingMethod.CannyFilter:
                        IF_VisionParam_CannyFilter cannyfilter = (imgPro as IF_VisionParam_CannyFilter);
                        LoadParametersToDataGridView(cannyfilter, dgvParameter);
                        break;
                    case ImageProcessingMethod.GaussianBlur:
                        IF_VisionParam_GaussianBlur gaussianblur = (imgPro as IF_VisionParam_GaussianBlur);
                        LoadParametersToDataGridView(gaussianblur, dgvParameter);
                        break;
                    case ImageProcessingMethod.Laplacian:
                        IF_VisionParam_LaplacialFilter laplacian = (imgPro as IF_VisionParam_LaplacialFilter);
                        LoadParametersToDataGridView(laplacian, dgvParameter);
                        break;
                    case ImageProcessingMethod.PerspectiveTransform:
                        IF_VisionParam_Perspective perspective = (imgPro as IF_VisionParam_Perspective);
                        LoadParametersToDataGridView(perspective, dgvParameter);
                        break;
                    case ImageProcessingMethod.Affine:
                        IF_VisionParam_Affine affine = (imgPro as IF_VisionParam_Affine);
                        LoadParametersToDataGridView(affine, dgvParameter);
                        break;

                    case ImageProcessingMethod.DFT:
                        IF_VisionParam_DFT dft = (imgPro as IF_VisionParam_DFT);
                        LoadParametersToDataGridView(dft, dgvParameter);
                        break;

                    case ImageProcessingMethod.ExtractColorChannel:
                        IF_VisionParam_ExtractColorChannel extractcolorchannel = (imgPro as IF_VisionParam_ExtractColorChannel);
                        LoadParametersToDataGridView(extractcolorchannel, dgvParameter);
                        break;
                    case ImageProcessingMethod.ColorConversion:
                        IF_VisionParam_Color color = (imgPro as IF_VisionParam_Color);
                        LoadParametersToDataGridView(color, dgvParameter);
                        break;

                }
            }
            catch
            {
            }
        }
        private void DispPattern(IF_VisionParam_Matching dispattern, bool bFirst = false)
        {
            try
            {
                int Selectedidx = 0;
                if (bFirst == false) Selectedidx = comboJobPattern_PatternType.SelectedIndex;
                else comboJobPattern_PatternType.SelectedIndex = 0;
                cogDisplay_JobPattern.InteractiveGraphics.Clear();
                cogDisplay_JobPattern.StaticGraphics.Clear();
                if (dispattern.PMAlignTools[Selectedidx].Pattern.Trained == true)
                {
                    cogDisplay_JobPattern.Image = dispattern.PMAlignTools[Selectedidx].Pattern.GetTrainedPatternImage();
                    cogDisplay_JobPattern.Fit(false);
                }
                else
                {
                    cogDisplay_JobPattern.Image = null;
                }
                //else { IF_Util.ShowMessageBox("Error", $"Have to Set Pattern{Selectedidx + 1}", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK); }
            }
            catch
            {
            }
        }
        private void timerCalibration_Tick(object sender, EventArgs e)
        {
            try
            {
                if (DispMain.Image != null)
                {
                    if (DispMain.InteractiveGraphics.Count > 0)
                    {
                        int pos1Idx = DispMain.InteractiveGraphics.FindItem("Point1", CogDisplayZOrderConstants.Back);
                        int pos2Idx = DispMain.InteractiveGraphics.FindItem("Point2", CogDisplayZOrderConstants.Back);

                        if (pos1Idx >= 0 && pos2Idx >= 0)
                        {
                            CogPointMarker POS1 = (DispMain.InteractiveGraphics[pos1Idx] as CogPointMarker);
                            CogPointMarker POS2 = (DispMain.InteractiveGraphics[pos2Idx] as CogPointMarker);

                            currentPoint1 = new OpenCvSharp.Point2d(POS1.X, POS1.Y);
                            currentPoint2 = new OpenCvSharp.Point2d(POS2.X, POS2.Y);

                            distancePoints = currentPoint1.DistanceTo(currentPoint2);

                            CogLineSegment measuredLine = new CogLineSegment();
                            measuredLine.StartX = currentPoint1.X;
                            measuredLine.StartY = currentPoint1.Y;
                            measuredLine.EndX = currentPoint2.X;
                            measuredLine.EndY = currentPoint2.Y;

                            DispMain.StaticGraphics.Add(measuredLine, "MeasLine");

                            if (beforePoint1.X != currentPoint1.X
                               || beforePoint1.Y != currentPoint1.Y
                               || beforePoint2.X != currentPoint2.X
                               || beforePoint2.Y != currentPoint2.Y
                               )
                            {
                                DispMain.StaticGraphics.Remove("MeasLine");
                            }

                            beforePoint1.X = currentPoint1.X;
                            beforePoint1.Y = currentPoint1.Y;
                            beforePoint2.X = currentPoint2.X;
                            beforePoint2.Y = currentPoint2.Y;
                        }
                    }
                    //lblImageInfo.Text = $"Image Info : {DisplayMain.Image.Width} * {DisplayMain.Image.Height} * {pixelFormatOfImageSource} | Distance : {distancePoints.ToString("F2")}px | Zoom : {DisplayMain.Zoom.ToString("F2")}";
                }
            }
            catch (Exception ex)
            {
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        private void OnclickSelectJudge(object sender, EventArgs e)
        {
            string operIdx = "";
            operIdx = (sender as UIButton).Text;
            switch (operIdx)
            {
                case "N/A = NG":
                    if (BtnNA_ng.Selected) return;
                    BtnNA_ng.Selected = true;
                    BtnNA_ok.Selected = false;
                    break;
                case "N/A = OK":
                    if (BtnNA_ok.Selected) return;
                    BtnNA_ng.Selected = false;
                    BtnNA_ok.Selected = true;
                    break;
            }
        }
        private void BtnSettingLogic_Click(object sender, EventArgs e)
        {
            try
            {
                int RowIndex = 0;
                bool LogicEnalbe = true;
                if (DgvLogicList.Rows.Count > 0)
                {
                    RowIndex = DgvLogicList.SelectedRows[0].Index;
                    LogicEnalbe = (bool)DgvLogicList[1, RowIndex].Value;
                }
                string LogicName = "";
                string LogicGrab = cbGrabIndex.SelectedIndex.ToString();
                string LogicAlgorithm = cbAlgorithm.SelectedItem.ToString();
                bool LogicJudge = true;
                if (BtnNA_ok.Selected) LogicJudge = false;

                LogicName = tbLogicName.Text;
                IF_VisionParam_Matching matching = new IF_VisionParam_Matching();
                IF_VisionParam_EYED eyeD = new IF_VisionParam_EYED();
                IF_VisionParam_Condensor condensor = new IF_VisionParam_Condensor();
                IF_VisionParam_ColorEx colorEx = new IF_VisionParam_ColorEx();
                IF_VisionParam_Pin pin = new IF_VisionParam_Pin();
                if (IF_Util.ShowMessageBox("Check", $"Do you want to Change Logic Value?"))
                {
                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {
                        if (info.LocationNo == m_SelectedLocationNo)
                        {
                            for (int i = 0; i < info.Logics.Count; i++)
                            {
                                if (m_SelectedLogicName != LogicName)
                                {
                                    if (info.Logics[i].Name == LogicName)
                                    {
                                        MessageBox.Show($"{LogicName} - 똑같은 Name을 가진 Job이 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                            DgvLogicList.Rows[m_SelectedLogic].Cells[1].Value = LogicEnalbe;
                            DgvLogicList.Rows[m_SelectedLogic].Cells[2].Value = LogicName;
                            DgvLogicList.Rows[m_SelectedLogic].Cells[3].Value = LogicGrab;
                            DgvLogicList.Rows[m_SelectedLogic].Cells[4].Value = LogicAlgorithm;
                            DgvLogicList.Rows[m_SelectedLogic].Cells[5].Value = LogicJudge;

                            if (info.Logics[m_SelectedLogic].Type != LogicAlgorithm)
                            {
                                switch (LogicAlgorithm)
                                {
                                    case "Pattern":
                                        info.Logics[m_SelectedLogic] = new IF_VisionParam_Matching();

                                        //matching = m_Logic as IF_VisionParam_Matching;
                                        for (int i = 0; i < matching.PMAlignTools.Length; i++)
                                        {
                                            matching.PMAlignTools[i].SearchRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(info.PosX - 150, info.PosY - 150, 200, 200));
                                            matching.PMAlignTools[i].Pattern.TrainRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(info.PosX - 100, info.PosY - 100, 100, 100));
                                        }
                                        info.Logics[m_SelectedLogic] = matching;

                                        break;
                                    case "EYE-D":
                                        eyeD.SearchRegion = new Rectangle(info.PosX - 150, info.PosY - 150, 200, 200);
                                        eyeD.SpecRegion = new Rectangle(info.PosX - 150, info.PosY - 150, 100, 100);
                                        info.Logics[m_SelectedLogic] = eyeD;
                                        break;
                                    case "Condensor":
                                        condensor.SearchRegion = new Rectangle(info.PosX - 150, info.PosY - 150, 200, 200);
                                        ICogRecord cogRecord;
                                        cogRecord = condensor.Find_Circle.CreateCurrentRecord();
                                        CogCircularArc cogSegment = (CogCircularArc)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
                                        cogSegment.CenterX = info.PosX - 100;
                                        cogSegment.CenterY = info.PosY - 100;
                                        info.Logics[m_SelectedLogic] = condensor;
                                        break;
                                    case "ColorEx":
                                        colorEx.SearchRegion = new Rectangle(info.PosX - 150, info.PosY - 150, 200, 200);
                                        info.Logics[m_SelectedLogic] = colorEx;
                                        break;
                                    case "Pin":
                                        pin.SearchRegion = new Rectangle(info.PosX - 150, info.PosY - 150, 200, 200);
                                        info.Logics[m_SelectedLogic] = pin;
                                        break;
                                }
                            }
                            m_Logic = info.Logics[m_SelectedLogic];
                            m_Logic.Type = LogicAlgorithm;
                            m_Logic.JudgeType_Judge_NaisNg = LogicJudge;

                            break;
                        }
                    }
                    Selected_Logic(m_Logic, false);
                    UpdateVisionLogicInfo(m_nSelectedArrayIndex, m_SelectedLocationNo, logic =>
                    {
                        logic.Logics[m_SelectedLogic].Enabled = LogicEnalbe;
                        logic.Logics[m_SelectedLogic].Name = LogicName;
                        logic.Logics[m_SelectedLogic].GrabIndex = int.Parse(LogicGrab);
                        logic.Logics[m_SelectedLogic].Type = LogicAlgorithm;
                        logic.Logics[m_SelectedLogic].JudgeType_Judge_NaisNg = LogicJudge;
                    });
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        public bool UpdateVisionLogicInfo(int key, string locationNo, Action<IF_VisionLogicInfo> updateAction)
        {
            if (m_Job.Library.TryGetValue(key, out List<IF_VisionLogicInfo> logicList))
            {
                foreach (var logic in logicList)
                {
                    if (logic.LocationNo == locationNo)
                    {
                        updateAction(logic); // 변경 적용
                        return true; // 업데이트 성공
                    }
                }
            }
            return false; // 해당 키/LocationNo를 찾지 못함
        }
        private void BtnLogicAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.SeqVision.SeqIndex == "IDLE")
                {

                    bool LogicEnable = true;
                    string LogicName = tbLogicName.Text;
                    int LogicGrabIndex = cbGrabIndex.SelectedIndex;
                    string LogicAlgorithmIndex = cbAlgorithm.SelectedItem.ToString();
                    string LogicAlgorithm = "";
                    bool LogicNA_NG = BtnNA_ng.Selected;
                    IF_VisionParamObject Logic = null;
                    IF_VisionParam_Matching matching = new IF_VisionParam_Matching();
                    IF_VisionParam_Condensor condensor = new IF_VisionParam_Condensor();
                    IF_VisionParam_EYED eyeD = new IF_VisionParam_EYED();
                    switch (LogicAlgorithmIndex)
                    {
                        case "Pattern":
                            LogicAlgorithm = "Pattern";
                            Logic = new IF_VisionParam_Matching();
                            break;
                        case "EYE-D":
                            LogicAlgorithm = "EYE-D";
                            Logic = new IF_VisionParam_EYED();
                            break;
                        case "ColorEx":
                            LogicAlgorithm = "ColorEx";
                            Logic = new IF_VisionParam_ColorEx();
                            break;
                        case "Condensor":
                            LogicAlgorithm = "Condensor";
                            Logic = new IF_VisionParam_Condensor();
                            break;
                        case "Pin":
                            LogicAlgorithm = "Pin";
                            Logic = new IF_VisionParam_Pin();
                            break;
                    }

                    if (Logic == null)
                    {
                        IF_Util.ShowMessageBox("Notice", "Please select the type of logic");
                        return;
                    }

                    if (m_Job.Library[m_nSelectedArrayIndex] != null)
                    {
                        foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                        {
                            if (m_SelectedLocationNo == info.LocationNo)
                            {
                                for (int i = 0; i < info.Logics.Count; i++)
                                {
                                    if (info.Logics[i].Name == LogicName)
                                    {
                                        MessageBox.Show($"{LogicName} - 똑같은 Name을 가진 Job이 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {
                        if (info.LocationNo == m_SelectedLocationNo)
                        {

                            int LastRawindex = info.Logics.Count;
                            info.LogicCount = LastRawindex + 1;
                            Logic.Enabled = LogicEnable;
                            Logic.GrabIndex = LogicGrabIndex;
                            Logic.Name = LogicName;
                            Logic.Type = LogicAlgorithm;
                            Logic.JudgeType_Judge_NaisNg = LogicNA_NG;
                            Logic.SearchRegion = new Rectangle(info.PosX - 100, info.PosY - 100, 100, 100);
                            if (Logic is IF_VisionParam_Matching)
                            {
                                matching = Logic as IF_VisionParam_Matching;
                                for (int i = 0; i < matching.PMAlignTools.Length; i++)
                                {
                                    matching.PMAlignTools[i].SearchRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(info.PosX - 150, info.PosY - 150, 200, 200));
                                    matching.PMAlignTools[i].Pattern.TrainRegion = CCognexUtil.RectangleToCogRectangle(Logic.SearchRegion);
                                }
                            }
                            else if (Logic is IF_VisionParam_Condensor)
                            {
                                condensor = Logic as IF_VisionParam_Condensor;

                                ICogRecord cogRecord;
                                cogRecord = condensor.Find_Circle.CreateCurrentRecord();
                                CogCircularArc cogSegment = (CogCircularArc)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
                                cogSegment.CenterX = info.PosX - 100;
                                cogSegment.CenterY = info.PosY - 100;
                            }
                            else if (Logic is IF_VisionParam_EYED)
                            {
                                eyeD = Logic as IF_VisionParam_EYED;
                                eyeD.SpecRegion = Logic.SearchRegion;
                                eyeD.Score = 0.3;
                            }

                            info.Logics.Add(Logic);
                            DgvLogicList.Rows.Add(LastRawindex + 1, info.Logics[LastRawindex].Enabled, info.Logics[LastRawindex].Name, info.Logics[LastRawindex].GrabIndex,
                                info.Logics[LastRawindex].Type, info.Logics[LastRawindex].JudgeType_Judge_NaisNg);

                        }
                    }
                    Set_Library(true);
                }
                else
                {
                    IF_Util.ShowMessageBox("SAVE", $"[FAILED] Inspection Process : {Global.SeqVision.SeqIndex}, Please save again after the Inspection is Complete");
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void BtnApplyCore_Click(object sender, EventArgs e)
        {
            if (DgvLogicList.SelectedRows.Count == 0) return;
            string newLogic = TabMenuLogic.SelectedTab.Text;
            string logicName = DgvLogicList.SelectedRows[0].Cells[2].Value.ToString();
            string algorithm = DgvLogicList.SelectedRows[0].Cells[3].Value.ToString();

            //EYED에서 다른거로 바꿀 때 Global.eyeD.RemoveModel 메서드를 반드시 호출해야 함.
            if (algorithm == "EYE-D")
            {
                //V8Base foundModel = Models.FirstOrDefault(m => m.OnnxName == onnxName);

                //if (Global.eyeD.Models.(logicName)) Global.eyeD.RemoveModel(logicName);
            }
            IF_VisionLogicInfo logicInfo = m_Job.Library[m_nSelectedArrayIndex].Where(v => v.LocationNo == DgvJobList.SelectedRows[0].Cells[0].Value.ToString()).ToList()[0];
            int selectedLogicIndex = (int)DgvLogicList.SelectedRows[0].Cells[0].Value - 1;

            // "새 logic에 deserialize해서 넣어줘야 부모클래스의 Property를 받아올 수 있음."
            string json = System.Text.Json.JsonSerializer.Serialize(logicInfo.Logics[selectedLogicIndex]);
            logicInfo.Logics[selectedLogicIndex] = null;
            switch (newLogic)
            {
                case "EYE-D":
                    {
                        IF_VisionParam_EYED newAlgoEYED = System.Text.Json.JsonSerializer.Deserialize<IF_VisionParam_EYED>(json);
                        newAlgoEYED.ModelName = CbbModelList.SelectedItem.ToString();
                        newAlgoEYED.Score = double.Parse(TbThresholdEYED.Text);
                        newAlgoEYED.RotateDgree = (int)CbRotateImageEYED.SelectedItem;
                        newAlgoEYED.UseSpecRegion = ChkSpecRegionEYED.Checked;
                        newAlgoEYED.UseColorExRegion = chkEyeD_UseColor.Checked;
                        newAlgoEYED.Type = "EYE-D";
                        newAlgoEYED.SpecRegion = m_EYED.SpecRegion;
                        newAlgoEYED.MasterR = txtEyeD_ColorEx_R.IntValue;
                        newAlgoEYED.MasterG = txtEyeD_ColorEx_G.IntValue;
                        newAlgoEYED.MasterB = txtEyeD_ColorEx_B.IntValue;
                        if (radioColorEx_Range15.Checked) newAlgoEYED.Range = 15;
                        if (radioColorEx_Range30.Checked) newAlgoEYED.Range = 30;
                        if (radioColorEx_Range45.Checked) newAlgoEYED.Range = 45;
                        logicInfo.Logics[selectedLogicIndex] = newAlgoEYED;
                        m_Logic = logicInfo.Logics[selectedLogicIndex];
                    }
                    break;

                case "Pattern":
                    {
                        IF_VisionParam_Matching newAlgoPattern = System.Text.Json.JsonSerializer.Deserialize<IF_VisionParam_Matching>(json);
                        IF_VisionParam_Matching crtPattern = m_Logic as IF_VisionParam_Matching;
                        // TODO : UI의 값과 property가 어떻게 연결되는지 몰라서 아직 작성 안 함.(다른 알고리즘도 마찬가지)
                        newAlgoPattern = crtPattern;
                        newAlgoPattern.MinimumScore_forFind = double.Parse(tbJobPattern_AcceptScore.Text);
                        newAlgoPattern.MinimumScore_forJudge = double.Parse(tbJobPattern_MinScore.Text);
                        newAlgoPattern.Type = "Pattern";

                        logicInfo.Logics[selectedLogicIndex] = newAlgoPattern;
                        m_Logic = logicInfo.Logics[selectedLogicIndex];
                    }
                    break;
                case "Condensor":
                    {
                        IF_VisionParam_Condensor newAlgoCondensor = System.Text.Json.JsonSerializer.Deserialize<IF_VisionParam_Condensor>(json);
                        IF_VisionParam_Condensor crtCondensor = m_Logic as IF_VisionParam_Condensor;
                        newAlgoCondensor = crtCondensor;
                        CogCaliperScorerPositionNeg scorer = new CogCaliperScorerPositionNeg();
                        m_Condensor.Find_Circle.RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                        scorer.Enabled = true;
                        m_Condensor.Find_Circle.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                        m_Condensor.Find_Circle.RunParams.NumToIgnore = int.Parse(tbIgnoreCount.Text);
                        m_Condensor.Find_Circle.RunParams.DecrementNumToIgnore = true;
                        m_Condensor.Find_Circle.RunParams.CaliperRunParams.ContrastThreshold = int.Parse(tbCircleContrast.Text);
                        m_Condensor.Find_Circle.RunParams.CaliperRunParams.FilterHalfSizeInPixels = int.Parse(tbCircleThickness.Text);
                        m_Condensor.Find_Circle.RunParams.CaliperRunParams.FilterHalfSizeInPixels = int.Parse(tbCircleThickness.Text);
                        newAlgoCondensor = m_Condensor;
                        newAlgoCondensor.CondensorPolarity = comboCondensorPolarity.Text;
                        newAlgoCondensor.CondensorTypeTB = radioCondensorTB.Checked;
                        newAlgoCondensor.CondensorRectWidth = int.Parse(tbCircleRectW.Text);
                        newAlgoCondensor.CondensorRectHeight = int.Parse(tbCircleRectH.Text);
                        newAlgoCondensor.CondensorRadiusOffset = int.Parse(tbCondensorRectRadio.Text);
                        newAlgoCondensor.Type = "Condensor";
                        logicInfo.Logics[selectedLogicIndex] = newAlgoCondensor;
                        m_Logic = logicInfo.Logics[selectedLogicIndex];
                    }
                    break;
                case "ColorEx":
                    {
                        IF_VisionParam_ColorEx newAlgoColorEx = System.Text.Json.JsonSerializer.Deserialize<IF_VisionParam_ColorEx>(json);
                        newAlgoColorEx.MasterR = txtColorEx_R.IntValue;
                        newAlgoColorEx.MasterG = txtColorEx_G.IntValue;
                        newAlgoColorEx.MasterB = txtColorEx_B.IntValue;
                        newAlgoColorEx.RangeMinR = int.Parse(TbColorEXRangeMin_R.Text);
                        newAlgoColorEx.RangeMaxR = int.Parse(TbColorEXRangeMax_R.Text);
                        newAlgoColorEx.RangeMinG = int.Parse(TbColorEXRangeMin_G.Text);
                        newAlgoColorEx.RangeMaxG = int.Parse(TbColorEXRangeMax_G.Text);
                        newAlgoColorEx.RangeMinB = int.Parse(TbColorEXRangeMin_B.Text);
                        newAlgoColorEx.RangeMaxB = int.Parse(TbColorEXRangeMax_B.Text);
                        logicInfo.Logics[selectedLogicIndex] = newAlgoColorEx;
                        m_Logic = logicInfo.Logics[selectedLogicIndex];
                    }
                    break;
                case "Pin":
                    {
                        IF_VisionParam_Pin newAlgoPin = System.Text.Json.JsonSerializer.Deserialize<IF_VisionParam_Pin>(json);
                        newAlgoPin.Pin_OkCount = (int)nb_Pin_OkCount.Value;
                        newAlgoPin.Pin_AreaMin = (int)nb_Pin_AreaMin.Value;
                        newAlgoPin.Pin_AreaMax = (int)nb_Pin_AreaMax.Value;
                        newAlgoPin.Pin_SpecRoiWidth = (int)nb_Pin_SpecRoi_Width.Value;
                        newAlgoPin.Pin_SpecRoiHeight = (int)nb_Pin_SpecRoi_Height.Value;
                        newAlgoPin.Pin_Threshold = (int)nb_Pin_Threshold.Value;
                        newAlgoPin.Pin_BinaryInv = chk_Pin_BinaryInv.Checked;
                        newAlgoPin.Pin_Boundaries = m_Pin.Pin_Boundaries;
                        logicInfo.Logics[selectedLogicIndex] = newAlgoPin;
                        m_Logic = logicInfo.Logics[selectedLogicIndex];
                    }
                    break;
            }
        }
        private Library_Fiducial _selectedFiducialLibrary = null;
        private void OnClickViewMode(object sender, EventArgs e)
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            try
            {
                UnselectViewMode();

                string viewType = "";
                string viewIndex = "";
                m_nSelectedGrabindex = GetSelectedGrabIndex();

                if (sender is UIButton)
                {
                    viewType = (sender as UIButton).Tag.ToString().ToUpper();
                    viewIndex = (sender as UIButton).Text.ToString().ToUpper();

                    (sender as UIButton).Selected = true;
                    if ((sender as UIButton).Text != "FULL")
                        m_nSelectedArrayIndex = int.Parse((sender as UIButton).Text);

                }

                switch (viewType)
                {
                    case "SETTING":
                        {
                            Set_Library(false);
                            if (DispMain.Image == null) return;

                            SelectGrabImage(m_nSelectedGrabindex - 1, false);
                            CropArray(m_nSelectedArrayIndex - 1);
                            //DispMain.Image = new CogImage24PlanarColor(IF_Util.Crop(_imagesGrab[selectedGrabIndex - 1].ToBitmap(), Global.System.Recipe.FiducialLibrary.RegionArray1));
                        }
                        break;
                    case "RESULT":
                        {
                            OnClickSelectResult(m_nSelectedArrayIndex - 1, new EventArgs());
                        }
                        break;
                    case "FULL":
                        {
                            SelectGrabImage(m_nSelectedGrabindex - 1, false);
                            DispMain.Image = _imagesGrab[m_nSelectedGrabindex - 1];
                            DispMain.Fit();
                        }
                        break;
                    case "RESULTNG":
                        {
                            OnClickSelectResultNG(m_nSelectedArrayIndex - 1, new EventArgs());

                            //DispMain.Image = new CogImage24PlanarColor(IF_Util.Crop(_imagesGrab[selectedGrabIndex - 1].ToBitmap(), Global.System.Recipe.FiducialLibrary.RegionArray1));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[[{_thisName}.{MethodName} :: Error]] {ex}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void OnClickSelectResult(object sender, EventArgs e)
        {
            try
            {
                // 현재 자동상태에서도 결과이미지 뿌려줌...

                //_ProcessMode = "RESULT VIEW MODE";

                //string strArrayIdx = (sender as Label).Text;
                int strArrayIdx = (int)sender;

                //ClearSelectArrays();
                //ClearResultArrays();

                if (strArrayIdx == 0) if (Global.ImageResults_array[0] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageResults_array[0]);
                if (strArrayIdx == 1) if (Global.ImageResults_array[1] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageResults_array[1]);
                if (strArrayIdx == 2) if (Global.ImageResults_array[2] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageResults_array[2]);
                if (strArrayIdx == 3) if (Global.ImageResults_array[3] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageResults_array[3]);

                //(sender as Label).BackColor = DEFINE_COMMON.COLOR_GREEN;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }
        private void OnClickSelectResultNG(object sender, EventArgs e)
        {
            try
            {
                // 현재 자동상태에서도 결과이미지 뿌려줌...

                //_ProcessMode = "RESULT VIEW MODE";

                //string strArrayIdx = (sender as Label).Text;
                int strArrayIdx = (int)sender;

                //ClearSelectArrays();
                //ClearResultArrays();

                if (strArrayIdx == 0) if (Global.ImageNG_array[0] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageNG_array[0]);
                if (strArrayIdx == 1) if (Global.ImageNG_array[1] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageNG_array[1]);
                if (strArrayIdx == 2) if (Global.ImageNG_array[2] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageNG_array[2]);
                if (strArrayIdx == 3) if (Global.ImageNG_array[3] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageNG_array[3]);

                //(sender as Label).BackColor = DEFINE_COMMON.COLOR_GREEN;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        public void SelectGrabImage(int nImage, bool isImageUpdate = true)
        {
            try
            {
                //m_nSelectGrabIndex = nImage;
                if (_imagesGrab[nImage] != null && _imagesGrab[nImage].Allocated)
                {
                    if (Global.Parameter.Cam1_ImageProcess.FlipRotate == "None")
                    {
                        m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(_imagesGrab[nImage]);
                    }
                    else
                    {
                        m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor((Cognex.VisionPro.CogImage24PlanarColor)CCognexUtil.FlipRotateEx(_imagesGrab[nImage], (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam1_ImageProcess.FlipRotate), true));
                    }

                    m_imgSource_Mono = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                    m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor(m_imgSource_Color);
                    m_imgSource_Mono_FullBoard = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);

                    switch (nImage)
                    {
                        case 0:
                            DisplayGrabIdx1.Image = m_imgSource_Color;
                            break;

                        case 1:
                            DisplayGrabIdx2.Image = m_imgSource_Color;
                            break;

                        case 2:
                            DisplayGrabIdx3.Image = m_imgSource_Color;
                            break;

                        case 3:
                            DisplayGrabIdx4.Image = m_imgSource_Color;
                            break;

                        case 4:
                            DisplayGrabIdx5.Image = m_imgSource_Color;
                            break;
                    }

                    if (isImageUpdate) DispMain.Image = m_imgSource_Color;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }
        private Rectangle CropArray(int idx, bool getOnlyRegion = false, bool isImageUpdate = true)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;
            string currentClassName = MethodBase.GetCurrentMethod().ReflectedType.Name;

            try
            {
                if (_selectedFiducialLibrary == null)
                {
                    IF_Util.ShowMessageBox("Error", "Should to select the library of fiducial first");
                    return new Rectangle();
                }

                Point2d pos = FindFiducialMark(false);

                if (pos.X == 0 && pos.Y == 0)
                {
                    IF_Util.ShowMessageBox("Error", "Can't Find the Fiducial Mark");
                    return new Rectangle();
                }

                System.Drawing.Rectangle regionToProcess;

                if (idx >= 0 && idx < _selectedFiducialLibrary.RegionArrayList.Count)
                {
                    regionToProcess = _selectedFiducialLibrary.GetArrayRegion(idx);
                    if (regionToProcess.IsEmpty || (regionToProcess.Width == 0 || regionToProcess.Height == 0))
                    {
                        IF_Util.ShowMessageBox("Error", $"Array index {idx + 1}: Region is not set or invalid.");
                    }
                }
                else
                {
                    IF_Util.ShowMessageBox("Error", $"Array index {idx}: Out of range.");
                    return new Rectangle();
                }

                System.Drawing.Rectangle cutRegion = regionToProcess;

                if (chkChangeFiducialMark != null && chkChangeFiducialMark.Checked == false)
                {
                    if (idx >= 0 && idx < _selectedFiducialLibrary.OffsetArrayList.Count)
                    {
                        PointF offset = _selectedFiducialLibrary.GetArrayOffset(idx);
                        if (!offset.IsEmpty)
                        {
                            cutRegion = new Rectangle((int)(pos.X - offset.X), (int)(pos.Y - offset.Y), regionToProcess.Width, regionToProcess.Height);
                        }
                    }
                }

                if (getOnlyRegion == false)
                {
                    if (m_imgSource_Color_FullBoard != null && m_imgSource_Color_FullBoard.Allocated)
                    {
                        Bitmap tempCroppedColor = null;
                        Bitmap tempCroppedMono = null;

                        try
                        {
                            using (Bitmap fullColorBitmap = m_imgSource_Color_FullBoard.ToBitmap())
                            {
                                if (fullColorBitmap != null)
                                {
                                    tempCroppedColor = IF_Util.Crop(fullColorBitmap, cutRegion);
                                }
                            }

                            if (tempCroppedColor != null)
                            {
                                if (m_imgSource_Color != null) m_imgSource_Color.Dispose();
                                m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(tempCroppedColor);

                                if (m_imgSource_Mono != null) m_imgSource_Mono.Dispose();
                                using (Bitmap forMonoConversion = tempCroppedColor.Clone(new Rectangle(0, 0, tempCroppedColor.Width, tempCroppedColor.Height), tempCroppedColor.PixelFormat))
                                {
                                    m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(forMonoConversion);
                                }
                                tempCroppedColor.Dispose();
                            }
                            else
                            {
                                if (m_imgSource_Color != null) { m_imgSource_Color.Dispose(); m_imgSource_Color = null; }
                                if (m_imgSource_Mono != null) { m_imgSource_Mono.Dispose(); m_imgSource_Mono = null; }
                            }
                        }
                        catch (Exception ex_crop)
                        {
                            tempCroppedColor?.Dispose();
                            tempCroppedMono?.Dispose();
                            if (m_imgSource_Color != null) { m_imgSource_Color.Dispose(); m_imgSource_Color = null; }
                            if (m_imgSource_Mono != null) { m_imgSource_Mono.Dispose(); m_imgSource_Mono = null; }

                            CLogger.Exception(currentClassName, $"{currentMethodName} (Image Cropping)", ex_crop);
                            IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {currentClassName}==>{currentMethodName} (Image Cropping)   Execption ==> {ex_crop.Message}");
                        }
                    }
                    else
                    {
                        if (m_imgSource_Color != null) { m_imgSource_Color.Dispose(); m_imgSource_Color = null; }
                        if (m_imgSource_Mono != null) { m_imgSource_Mono.Dispose(); m_imgSource_Mono = null; }
                        IF_Util.ShowMessageBox("Error", "Source image (FullBoard) for cropping is not available."); 
                    }

                    if (isImageUpdate)
                    {
                        if (m_imgSource_Color != null && m_imgSource_Color.Allocated)
                        {
                            DispMain.Image = m_imgSource_Color;
                            DispMain.Fit(true);
                        }
                        else if (m_imgSource_Mono != null && m_imgSource_Mono.Allocated)
                        {
                            DispMain.Image = m_imgSource_Mono;
                            DispMain.Fit(true);
                        }
                        else
                        {
                            DispMain.Image = null;
                            IF_Util.ShowMessageBox("Error", "Failed to display cropped image."); 
                        }
                    }
                }
                return cutRegion;
            }
        
            catch (Exception ex)
            {
                //btnArrayCrop_Roi.Text = "Roi";
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");

                return new Rectangle();
            }
        }
        public static CogImage24PlanarColor RotateMarkedImage(CogImage24PlanarColor imageFiducialSrc, CogImage24PlanarColor imgRotateSrc, Library_Fiducial Recipe)
        {
            Point2d posFiducialMark = new Point2d();
            try
            {

                Stopwatch tactTime = new Stopwatch();
                tactTime.Start();

                CTemplateMatching matchingLT = new CTemplateMatching("LT");
                CTemplateMatching matchingRB = new CTemplateMatching("RB");

                using (Mat imgSrc_Grab0 = OpenCvSharp.Extensions.BitmapConverter.ToMat(imageFiducialSrc.ToBitmap()))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matchingLT.SetSourceImage(imgSrc_Grab0.ToBitmap());
                        matchingRB.SetSourceImage(imgSrc_Grab0.ToBitmap());

                        matchingLT.Run(Recipe.Fiducial1);

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
        private void OnClick_Fiducial(object sender, EventArgs e)
        {
            try
            {
                string index = "";

                //if (sender is Button) index = (sender as Button).Text;
                if (sender is UISymbolButton btn && btn.Tag is string tag)
                {
                    index = tag;
                }
                if (_selectedFiducialLibrary == null)
                {
                    IF_Util.ShowMessageBox("Error", "Should to select the library of fiducial first");
                    return;
                }

                switch (index)
                {
                    case "ROI1":
                    case "ROI2":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            CogRectangle cogSearchRegion = new CogRectangle();

                            if (index == "ROI1") cogSearchRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.Fiducial1.SearchRoi);

                            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.Color = CogColorConstants.Red;
                            cogSearchRegion.SelectedColor = CogColorConstants.Red;

                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);

                            CogRectangle cogTrainRegion = new CogRectangle();

                            if (index == "ROI1") cogTrainRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.Fiducial1.TemplateRoi);

                            cogTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogTrainRegion.Interactive = true;
                            cogTrainRegion.Color = CogColorConstants.Blue;

                            if (cogTrainRegion.Width == 0 || cogTrainRegion.Height == 0)
                            {
                                cogTrainRegion.Width = 100;
                                cogTrainRegion.Height = 100;
                            }

                            DispMain.InteractiveGraphics.Add(cogTrainRegion, "Pattern", false);
                        }
                        break;

                    case "TRAIN":
                    case "Train1":
                    case "Train2":
                    case "Train":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);

                            if (idx == -1)
                            {
                                IF_Util.ShowMessageBox("Error", "Can't Roi Serch");
                                return;
                            }

                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            if (index == "Train1") _selectedFiducialLibrary.Fiducial1.SearchRoi = CCognexUtil.CogRectangleToRectangle(roi);

                            idx = DispMain.InteractiveGraphics.FindItem("Pattern", CogDisplayZOrderConstants.Back);
                            roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            using (Bitmap imgPattern = IF_Util.Crop(m_imgSource_Mono.ToBitmap(), new Rectangle((int)roi.X, (int)roi.Y, (int)roi.Width, (int)roi.Height)))
                            {
                                CogRectangle cogTrainRegion = new CogRectangle();
                                CogRectangle cogSearchRegion = new CogRectangle();

                                if (index == "Train1")
                                {
                                    cogDisplay_Fiducial_Pattern1.Image = new CogImage8Grey(imgPattern);
                                    cogDisplay_Fiducial_Pattern1.Fit(true);

                                    _selectedFiducialLibrary.Fiducial1.TemplateRoi = CCognexUtil.CogRectangleToRectangle(roi);
                                    _selectedFiducialLibrary.Fiducial1.ImageTemplate = (Bitmap)imgPattern.Clone();
                                }
                            }
                        }
                        break;

                    case "FIND":
                    case "Find1":
                    case "Find2":
                    case "Find":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            Stopwatch sw = new Stopwatch();
                            sw.Start();

                            CTemplateMatching matching = new CTemplateMatching("Matching");
                            matching.SetSourceImage(m_imgSource_Mono.ToBitmap());

                            if (index == "Find1") matching.Run(_selectedFiducialLibrary.Fiducial1);

                            double dMaxScore = double.MinValue;
                            Rect rtMaxScore = new Rect();
                            Point2d pointMaxScore = new Point2d();

                            if (matching.Results.Count > 0)
                            {
                                if (dMaxScore < matching.Results[0].Score)
                                {
                                    dMaxScore = matching.Results[0].Score;
                                    rtMaxScore = matching.Results[0].Bounding;
                                    pointMaxScore = matching.Results[0].Center;
                                }

                                DispMain.StaticGraphics.Clear();

                                CogRectangle cogRectDetected = new CogRectangle();
                                cogRectDetected.X = rtMaxScore.X;
                                cogRectDetected.Y = rtMaxScore.Y;
                                cogRectDetected.Width = rtMaxScore.Width;
                                cogRectDetected.Height = rtMaxScore.Height;
                                cogRectDetected.Color = CogColorConstants.Green;

                                CCognexUtil.DrawString(DispMain, $"Score : {dMaxScore:0.00} %  ({pointMaxScore.X},{pointMaxScore.Y})", rtMaxScore.Location, CogColorConstants.Green, 10);
                                CCognexUtil.DrawPosMarker(pointMaxScore, rtMaxScore.Width, rtMaxScore.Height, DispMain, CogColorConstants.Green);
                                DispMain.StaticGraphics.Add(cogRectDetected, "RT");
                            }
                            else
                            {
                                IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
                            }

                            sw.Stop();
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        private void btnArrayCrop_Roi_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedFiducialLibrary == null)
                {
                    IF_Util.ShowMessageBox("Error", "Should to select the library of fiducial first");
                    return;
                }

                Point2d pos = FindFiducialMark(false);

                if (pos.X == 0 && pos.Y == 0)
                {
                    IF_Util.ShowMessageBox("Error", "Can't Find the Fiducial Mark");
                    return;
                }

                int selectedArrayIndex = comboArray.SelectedIndex;

                if (string.Equals(btnArrayCrop_Roi.Text, "Complete", StringComparison.OrdinalIgnoreCase))
                {
                    int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                    if (idx < 0)
                    {

                        return;
                    }

                    CogRectangle roiFromDisplay = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                    if (roiFromDisplay == null)
                    {

                        return;
                    }

                    System.Drawing.Rectangle rectToSave = CCognexUtil.CogRectangleToRectangle(roiFromDisplay);

                    if (selectedArrayIndex >= 0 && selectedArrayIndex < _selectedFiducialLibrary.RegionArrayList.Count)
                    {
                        _selectedFiducialLibrary.SetArrayRegion(selectedArrayIndex, rectToSave);

                        PointF newOffset = new PointF((float)pos.X - rectToSave.X, (float)pos.Y - rectToSave.Y);
                        _selectedFiducialLibrary.SetArrayOffset(selectedArrayIndex, newOffset);
                    }
                    else
                    {
                        return;
                    }

                    btnArrayCrop_Roi.Text = "Roi";
                }
                else
                {
                    DispMain.InteractiveGraphics.Clear();
                    DispMain.StaticGraphics.Clear();

                    CogRectangle cogSearchRegionToShow;

                    if (selectedArrayIndex >= 0 && selectedArrayIndex < _selectedFiducialLibrary.RegionArrayList.Count)
                    {
                        System.Drawing.Rectangle existingRegion = _selectedFiducialLibrary.GetArrayRegion(selectedArrayIndex);
                        PointF existingOffset = _selectedFiducialLibrary.GetArrayOffset(selectedArrayIndex); 

                        if (existingRegion.IsEmpty || (existingRegion.Width == 0 && existingRegion.Height == 0))
                        {
                            cogSearchRegionToShow = new CogRectangle();
                            if (DispMain.Image != null && DispMain.Image.Allocated)
                            {
                                cogSearchRegionToShow.SetCenterWidthHeight(DispMain.Image.Width / 2.0, DispMain.Image.Height / 2.0, 150, 150);
                            }
                            else
                            {
                                cogSearchRegionToShow.SetCenterWidthHeight(300, 300, 150, 150);
                            }
                        }
                        else
                        {
                            cogSearchRegionToShow = CCognexUtil.RectangleToCogRectangle(existingRegion);
                            if (chkChangeFiducialMark != null && chkChangeFiducialMark.Checked == false)
                            {
                               
                                if (!existingOffset.IsEmpty || (existingOffset.X != 0 || existingOffset.Y != 0))
                                {
                                    cogSearchRegionToShow.X = pos.X - existingOffset.X;
                                    cogSearchRegionToShow.Y = pos.Y - existingOffset.Y;
                                    cogSearchRegionToShow.Width = existingRegion.Width;
                                    cogSearchRegionToShow.Height = existingRegion.Height;
                                }
                            }
                        }
                    }
                    else
                    {
                        return;
                    }

                    cogSearchRegionToShow.GraphicDOFEnable = CogRectangleDOFConstants.All;
                    cogSearchRegionToShow.Interactive = true;
                    cogSearchRegionToShow.Color = CogColorConstants.Red;
                    cogSearchRegionToShow.SelectedColor = CogColorConstants.Red;
                    cogSearchRegionToShow.LineWidthInScreenPixels = 2;

                    DispMain.InteractiveGraphics.Add(cogSearchRegionToShow, "Search", false);
                    btnArrayCrop_Roi.Text = "Complete";
                }
            }
            catch (Exception ex)
            {
                btnArrayCrop_Roi.Text = "Roi"; 
                                              
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnArrayCrop_Set_Click(object sender, EventArgs e)
        {
            try
            {
                Point2d pos = FindFiducialMark(false);

                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                if (pos.X == 0 && pos.Y == 0)
                {
                    IF_Util.ShowMessageBox("Error", "Can't Find the Fiducial Mark");
                    return;
                }

                Rectangle region = new Rectangle();

                if (comboArray.SelectedIndex == 0) region = _selectedFiducialLibrary.RegionArray1;
                if (comboArray.SelectedIndex == 1) region = _selectedFiducialLibrary.RegionArray2;
                if (comboArray.SelectedIndex == 2) region = _selectedFiducialLibrary.RegionArray3;
                if (comboArray.SelectedIndex == 3) region = _selectedFiducialLibrary.RegionArray4;
                if (comboArray.SelectedIndex == 4) region = _selectedFiducialLibrary.RegionArray5;


                Rectangle cutRegion = new Rectangle();
                if (chkChangeFiducialMark.Checked == false)
                {
                    cutRegion = new Rectangle(region.X + (int)pos.X, region.Y + (int)pos.Y, region.Width, region.Height);
                    if (comboArray.SelectedIndex == 0) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray1.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray1.Y), region.Width, region.Height);
                    if (comboArray.SelectedIndex == 1) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray2.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray2.Y), region.Width, region.Height);
                    if (comboArray.SelectedIndex == 2) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray3.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray3.Y), region.Width, region.Height);
                    if (comboArray.SelectedIndex == 3) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray4.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray4.Y), region.Width, region.Height);
                    if (comboArray.SelectedIndex == 4) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray5.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray5.Y), region.Width, region.Height);
                }
                else
                {
                    cutRegion = new Rectangle(region.X, region.Y, region.Width, region.Height);
                    if (comboArray.SelectedIndex == 0) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray1.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray1.Y), region.Width, region.Height);
                    if (comboArray.SelectedIndex == 1) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray2.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray2.Y), region.Width, region.Height);
                    if (comboArray.SelectedIndex == 2) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray3.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray3.Y), region.Width, region.Height);
                    if (comboArray.SelectedIndex == 3) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray4.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray4.Y), region.Width, region.Height);
                    if (comboArray.SelectedIndex == 4) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray5.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray5.Y), region.Width, region.Height);
                }
                m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(IF_Util.Crop(m_imgSource_Color.ToBitmap(), cutRegion));
                m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(IF_Util.Crop(m_imgSource_Color.ToBitmap(), cutRegion));


                DispMain.Image = m_imgSource_Color;
                DispMain.Fit(true);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private Point2d FindFiducialMark(bool isDraw = true)
        {
            Point2d pos = new Point2d();
            try
            {
                if (isDraw) DispMain.StaticGraphics.Clear();

                Stopwatch sw = new Stopwatch();
                sw.Start();

                CTemplateMatching matching = new CTemplateMatching("Matching");
                matching.SetSourceImage(_imagesGrab[0].ToBitmap());

                matching.Run(_selectedFiducialLibrary.Fiducial1);

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

                    if (isDraw)
                    {
                        CogRectangle cogRectDetected = new CogRectangle();
                        cogRectDetected.X = rtMaxScore.X;
                        cogRectDetected.Y = rtMaxScore.Y;
                        cogRectDetected.Width = rtMaxScore.Width;
                        cogRectDetected.Height = rtMaxScore.Height;
                        cogRectDetected.Color = CogColorConstants.Green;

                        CCognexUtil.DrawString(DispMain, $"Score : {dMaxScore:0.00} %  ({pointMaxScore.X},{pointMaxScore.Y})", rtMaxScore.Location, CogColorConstants.Green, 10);
                        CCognexUtil.DrawPosMarker(pointMaxScore, rtMaxScore.Width, rtMaxScore.Height, DispMain, CogColorConstants.Green);
                        DispMain.StaticGraphics.Add(cogRectDetected, "RT");
                    }
                }
                else
                {
                    IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
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

        private void btnSave_QR_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Fiducial, QR", "Would you like to save the Fiducial and QR Region ?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    m_Fiducial_PreView = true;
                    OnClickViewMode(btnView_Full, new EventArgs());
                    btnFiducial_Measure_Click(this, new EventArgs());
                    Global.System.Recipe.FiducialLibrary = _selectedFiducialLibrary;
                    Global.System.Recipe.FiducialLibrary.Save(Global.Instance.System.Recipe.CODE);
                    Global.Setting.Recipe.Save(Global.Instance.System.Recipe.CODE);
                    chkAlignNoUse.Checked = false;
                    chkChangeFiducialMark.Checked = false;
                    Cogdis_FiducialPreView.Image = new CogImage24PlanarColor(Global.System.Recipe.FiducialLibrary.ImagePreview);
                    Cogdis_FiducialPreView.Fit(false);
                    Global.System.Recipe.ArrayCount = int.Parse(txtArrayCount.Text);
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void comboArray_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();
                btnArrayCrop_Roi.Text = "Roi";
                int selectedGrabIndex = GetSelectedGrabIndex();
                SelectGrabImage(selectedGrabIndex - 1, false);
                DispMain.Image = _imagesGrab[selectedGrabIndex - 1];
                DispMain.Fit();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void DgvLogicList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Global.SeqVision.SeqIndex == "IDLE")
            {
                Enabled_Check();
            }
            else
            {
                IF_Util.ShowMessageBox("SAVE", $"[FAILED] Inspection Process : {Global.SeqVision.SeqIndex}, Please save again after the Inspection is Complete");
            }
        }
        private void Enabled_Check()
        {
            for (int i = 0; i < DgvLogicList.Rows.Count; i++)
            {
                string name = DgvLogicList[2, i].Value.ToString();
                bool enabled = bool.Parse(DgvLogicList[1, i].Value.ToString());

                for (int j = 0; j < m_LogicInfo.Logics.Count; j++)
                {
                    if (m_LogicInfo.Logics[j].Name == name)
                    {
                        m_LogicInfo.Logics[j].Enabled = enabled;
                        break;
                    }
                }
            }
        }

        private void DgvLogicList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Global.SeqVision.SeqIndex == "IDLE")
            {
                if (DgvLogicList.CommitEdit(DataGridViewDataErrorContexts.Commit))
                {
                }
                else
                {
                    IF_Util.ShowMessageBox("Error", "Fail CommitEdit");
                }
            }
            else
            {
                IF_Util.ShowMessageBox("SAVE", $"[FAILED] Inspection Process : {Global.SeqVision.SeqIndex}, Please save again after the Inspection is Complete");
            }

        }

        private void DgvJobList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Global.SeqVision.SeqIndex == "IDLE")
            {
                if (DgvJobList.CommitEdit(DataGridViewDataErrorContexts.Commit))
                {
                }
                else
                {
                    IF_Util.ShowMessageBox("Error", "Fail CommitEdit");
                }
            }
            else
            {
                IF_Util.ShowMessageBox("SAVE", $"[FAILED] Inspection Process : {Global.SeqVision.SeqIndex}, Please save again after the Inspection is Complete");
            }

        }

        // 확인 필요 0213 
        private void DgvJobList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Global.SeqVision.SeqIndex == "IDLE")
            {
                for (int i = 0; i < DgvJobList.Rows.Count; i++)
                {
                    string name = DgvJobList[0, i].Value.ToString();
                    bool enabled = bool.Parse(DgvJobList[1, i].Value.ToString());

                    if (m_Job.Library.TryGetValue(m_nSelectedArrayIndex, out List<IF_VisionLogicInfo> PartinfoList))
                    {
                        foreach (var info in PartinfoList)
                        {
                            if (info.LocationNo == name)
                            {
                                info.Enabled = enabled;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                IF_Util.ShowMessageBox("SAVE", $"[FAILED] Inspection Process : {Global.SeqVision.SeqIndex}, Please save again after the Inspection is Complete");
            }

        }

        private void BtnLogicDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (IF_Util.ShowMessageBox("Check", $"Do you want to delete {m_SelectedLogicName}?"))
                {
                    if (Global.SeqVision.SeqIndex == "IDLE")
                    {
                        if (m_Logic == null) return;

                        int nIndex = -1;

                        foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                        {
                            if (m_SelectedLocationNo == info.LocationNo)
                            {
                                for (int i = 0; i < info.Logics.Count; i++)
                                {
                                    if (info.Logics[i].Name == m_SelectedLogicName)
                                    {
                                        nIndex = i;
                                        if (nIndex != -1)
                                        {
                                            DeleteCogTools(Global.Instance.System.Recipe.Name, m_nSelectedArrayIndex, m_SelectedLocationNo, true);
                                            info.Logics.RemoveAt(nIndex);
                                        }
                                        break;
                                    }
                                }
                                DgvJobList.Rows[m_SelectedJob].Cells[4].Value = info.Logics.Count;
                                break;
                            }
                        }
                        DgvLogicList.Rows.RemoveAt(nIndex); //삭제 후 UI 업데이트 확인 필요
                        Global.System.Recipe.LibraryManager = m_Job;
                        Global.System.Recipe.Save_LibraryManager(Global.Instance.System.Recipe.Name);
                        //Global.System.Recipe.SaveCogTools(Global.Instance.System.Recipe.Name);
                        Set_Library(false);
                    }
                    else
                    {
                        IF_Util.ShowMessageBox("SAVE", $"[FAILED] Inspection Process : {Global.SeqVision.SeqIndex}, Please save again after the Inspection is Complete");
                    }
                }
            }

            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

            }
        }
        private void DeleteCogTools(string libraryName, int arrayIdx, string LocationNo, bool delLogic)
        {
            string basePath = $"{Application.StartupPath}\\RECIPE\\{libraryName}\\CogTools\\";

            string library_Path = Path.Combine(basePath, arrayIdx.ToString());
            foreach (IF_VisionLogicInfo part in Global.System.Recipe.LibraryManager.Library[arrayIdx])
            {
                if (m_SelectedLocationNo == part.LocationNo)
                {
                    string LocationNo_Path = Path.Combine(library_Path, part.LocationNo);
                    if (delLogic)
                    {
                        if (part.Logics.Count > 0)
                        {
                            string Logic_Path = Path.Combine(LocationNo_Path, part.Logics[m_SelectedLogic].Name);
                            if (Directory.Exists(Logic_Path)) Directory.Delete(Logic_Path, true);
                            break;
                        }
                    }
                    else
                    {
                        if (Directory.Exists(LocationNo_Path)) Directory.Delete(LocationNo_Path, true);
                    }
                }
            }

        }
        private void BtnJobAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string locationNo = TbLocationNo.Text;
                string partcode = TbPartName.Text;
                bool jobEnable = false;

                if (m_Job.Library[m_nSelectedArrayIndex] != null)
                {
                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {

                        if (info.LocationNo == locationNo)
                        {
                            MessageBox.Show($"{locationNo} - 똑같은 Name을 가진 Job이 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
                List<IF_VisionLogicInfo> jobList = new List<IF_VisionLogicInfo>();
                IF_VisionLogicInfo addjob = new IF_VisionLogicInfo();
                jobList = m_Job.Library[m_nSelectedArrayIndex];

                int LastRawindex = jobList.Count;
                addjob.LocationNo = locationNo;
                addjob.Enabled = jobEnable;
                addjob.PartCode = partcode;
                jobList.Add(addjob);
                m_Job.Library[m_nSelectedArrayIndex] = jobList;
                DgvJobList.Rows.Add(jobList[LastRawindex].LocationNo, jobList[LastRawindex].Enabled, jobList[LastRawindex].PartCode, jobList[LastRawindex].PosAngle, 0);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnJobColorEx_Get_Click(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                Color color = GetColor_fromRoi(m_ColorEx.SearchRegion, true);

                txtColorEx_R.Text = color.R.ToString();
                txtColorEx_G.Text = color.G.ToString();
                txtColorEx_B.Text = color.B.ToString();
                InputLogic();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        public Color GetColor_fromRoi(Rectangle colorEXRegion, bool bColorEx)
        {
            Color extractColor;
            using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), colorEXRegion)).Clone())
            {
                Scalar scalar = imgCrop.Mean();

                // 평균 색상 값을 BGR 형식으로 각각 추출
                byte meanB = (byte)scalar.Val0;
                byte meanG = (byte)scalar.Val1;
                byte meanR = (byte)scalar.Val2;

                extractColor = Color.FromArgb(meanR, meanG, meanB);
                string colorStr = $"{meanR},{meanG},{meanB}";
                if (bColorEx) IF_Util.setLabel(lblJobColorEx_ResultColor, colorStr.ToString(), extractColor);
                else IF_Util.setLabel(lblEyeD_ColorEx_Result, colorStr.ToString(), extractColor);

                Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                cogSearchRegion.LineWidthInScreenPixels = 2;
                cogSearchRegion.X = colorEXRegion.X;
                cogSearchRegion.Y = colorEXRegion.Y;
                cogSearchRegion.Width = colorEXRegion.Width;
                cogSearchRegion.Height = colorEXRegion.Height;

                string colorName = "";
                for (int colorIdx = 0; colorIdx < Global.Setting.Enviroment.ColorList.ColorNodes.Count; colorIdx++)
                {
                    if (Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].InRange(meanR, meanG, meanB))
                    {
                        colorName = Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].Name;
                        break;
                    }
                }

                //if (colorName == m_ColorEx.Parameter.EyeD_CorrectColor)
                //{
                //    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                //    CCognexUtil.DrawString(cogDisplay_Source, $"Color : {colorStr.ToString()}({colorName})", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                //}
                //else
                //{
                cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                CCognexUtil.DrawString(DispMain, $"Color : {colorStr.ToString()}({colorName})", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                //}

                DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);
            }

            return extractColor;
        }

        private void trackbarThreshold_Scroll(object sender, EventArgs e)
        {
            if (DispMain.Image == null) return;

            using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()).Clone())
            using (Mat imgBin = new Mat())
            {
                IF_Util.SetImageChannel1(imgOrg);

                if (chkThresholdInv.Checked) Cv2.Threshold(imgOrg, imgBin, trackbarThreshold.Value, 255, ThresholdTypes.BinaryInv);
                else Cv2.Threshold(imgOrg, imgBin, trackbarThreshold.Value, 255, ThresholdTypes.Binary);

                DispMain.Image = new CogImage24PlanarColor(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgBin));
            }
        }

        private void comboJobPattern_PatternType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();
                IF_VisionParam_Matching selectedPattern = (m_Logic as IF_VisionParam_Matching);
                DispPattern(selectedPattern, false);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void BtnDeletePattern_Click(object sender, EventArgs e)
        {
            try
            {

                IF_VisionParam_Matching selectedPattern = (m_Logic as IF_VisionParam_Matching);

                int nSelectedPM = 0;
                cogDisplay_JobPattern.InteractiveGraphics.Clear();
                cogDisplay_JobPattern.StaticGraphics.Clear();


                if (comboJobPattern_PatternType.Text == "Main") nSelectedPM = 0;
                else
                {
                    if (comboJobPattern_PatternType.Text == "Sub1") nSelectedPM = 1;
                    if (comboJobPattern_PatternType.Text == "Sub2") nSelectedPM = 2;
                    if (comboJobPattern_PatternType.Text == "Sub3") nSelectedPM = 3;
                    if (comboJobPattern_PatternType.Text == "Sub4") nSelectedPM = 4;
                }

                CogPMAlignTool PMAlign = new CogPMAlignTool();
                selectedPattern.PMAlignTools[nSelectedPM] = PMAlign;

                //if (PMAlign != null)
                //{
                //    if (PMAlign.Pattern.Trained)
                //    {
                //        cogDisplay_JobPattern.Image = PMAlign.Pattern.GetTrainedPatternImage();
                //        cogDisplay_JobPattern.Fit(false);
                //    }
                //    else
                //    {
                //        cogDisplay_JobPattern.Image = null;
                //    }
                //}
                DisplayTrainCount(selectedPattern);

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void OnClickAlgorithm_EyeD(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as UIButton).Text;
                m_EYED = (m_Logic as IF_VisionParam_EYED);

                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            //m_selectedJob = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library];
                            if (m_EYED.SearchRegion.Width == 0 || m_EYED.SearchRegion.Height == 0)
                            {
                                m_EYED.SearchRegion = new Rectangle(0, 0, 100, 100);
                            }
                            //검사 영역
                            Cognex.VisionPro.CogRectangle cogSearchRegion = CConverter.RectToCogRect(m_EYED.SearchRegion);
                            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.LineWidthInScreenPixels = 2;
                            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 250;
                            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 250;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);

                            //스펙 영역
                            Cognex.VisionPro.CogRectangle cogSpecRegion = CConverter.RectToCogRect(m_EYED.SpecRegion);
                            cogSpecRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSpecRegion.Interactive = true;
                            cogSpecRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Orange;
                            cogSpecRegion.DragColor = Cognex.VisionPro.CogColorConstants.Orange;
                            cogSpecRegion.Color = Cognex.VisionPro.CogColorConstants.Orange;
                            cogSpecRegion.LineWidthInScreenPixels = 2;
                            if (cogSpecRegion.Width == 0) cogSpecRegion.Width = 100;
                            if (cogSpecRegion.Height == 0) cogSpecRegion.Height = 100;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSpecRegion, "SpecRegion", false);
                            (sender as UIButton).Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            if (idx < 0)
                            {
                                if ((sender as UIButton).Text != "Find")
                                {
                                    (sender as UIButton).Text = "Roi";
                                    return;
                                }
                            }
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_EYED.SearchRegion = CConverter.CogRectToRect(roi);

                            idx = DispMain.InteractiveGraphics.FindItem("SpecRegion", CogDisplayZOrderConstants.Back);
                            CogRectangle specRegion = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_EYED.SpecRegion = CConverter.CogRectToRect(specRegion);

                            (sender as UIButton).Text = "Roi";
                            InputLogic();
                        }
                        break;
                    case "RUN":
                    case "INSP":
                    case "Find":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            string findResult = "";
                            if (m_EYED.ModelName == null)
                            {
                                IF_Util.ShowMessageBox("Error", "Check to Apply");
                                return;
                            }

                            Stopwatch tt = Stopwatch.StartNew();

                            using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), m_EYED.SearchRegion)).Clone())
                            {


                                string uniqueID = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                                string imageDir = $"{Application.StartupPath}\\EYED";
                                if (Directory.Exists(imageDir) == false) Directory.CreateDirectory(imageDir);
                                string imagePath = $"{imageDir}\\_{DateTime.Now.ToString("yyyyMMdd_HHmmssfff")}.jpg";
                                Mat rotateImage = CVisionTools.RotateImage(imgCrop, m_EYED.RotateDgree);
                                rotateImage.SaveImage(imagePath);
                                List<BaseResultDTO> results = Global.eyeD.RunModel(m_EYED.ModelName, rotateImage, 0.01F);
                                Bitmap resultImage = DispMain.Image.ToBitmap();
                                foreach (BaseResultDTO result in results)
                                {
                                    if (result is DetectionResultDTO detResult)
                                    {
                                        DispMain.Image = new CogImage24PlanarColor(resultImage);
                                        Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                                        cogSearchRegion.LineWidthInScreenPixels = 2;

                                        if (m_EYED.RotateDgree == 0 || m_EYED.RotateDgree == 180)
                                        {
                                            cogSearchRegion.X = m_EYED.SearchRegion.X + detResult.Box.X;
                                            cogSearchRegion.Y = m_EYED.SearchRegion.Y + detResult.Box.Y;
                                            cogSearchRegion.Width = detResult.Box.Width;
                                            cogSearchRegion.Height = detResult.Box.Height;
                                        }
                                        else if (m_EYED.RotateDgree == 90 || m_EYED.RotateDgree == 270)
                                        {
                                            cogSearchRegion.X = m_EYED.SearchRegion.X + detResult.Box.Y;
                                            cogSearchRegion.Y = m_EYED.SearchRegion.Y + detResult.Box.X;
                                            cogSearchRegion.Width = detResult.Box.Height;
                                            cogSearchRegion.Height = detResult.Box.Width;
                                        }
                                        Cognex.VisionPro.CogCircle cogCircleCenter = new CogCircle();
                                        cogCircleCenter.CenterX = cogSearchRegion.X + cogSearchRegion.Width / 2;
                                        cogCircleCenter.CenterY = cogSearchRegion.Y + cogSearchRegion.Height / 2;
                                        cogCircleCenter.Radius = 5;
                                        cogCircleCenter.Color = CogColorConstants.Orange;
                                        DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);
                                        DispMain.InteractiveGraphics.Add(cogCircleCenter, "", false);
                                        if (m_EYED.Score <= detResult.Score)
                                        {
                                            if (m_EYED.UseSpecRegion)
                                            {
                                                if (m_EYED.SpecRegion.Contains(IF_Util.CeterFromRectangle(CConverter.CogRectToRect(cogSearchRegion))))
                                                {
                                                    if (detResult.Class != "True" && detResult.Class != "False")
                                                    {
                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                        CCognexUtil.DrawString(DispMain, $"Model : {detResult.Class} Score : {detResult.Score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                                                    }
                                                    else if (detResult.Class == "True")
                                                    {
                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                        CCognexUtil.DrawString(DispMain, $"Component : {detResult.Class} Score : {detResult.Score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                                                    }
                                                    else
                                                    {
                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                        CCognexUtil.DrawString(DispMain, $"Component : {detResult.Class} Score : {detResult.Score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                                                    }
                                                }
                                                else
                                                {
                                                    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                    CCognexUtil.DrawString(DispMain, $"SpecRegion : Out Model : {detResult.Class} Score : {detResult.Score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                                                }
                                            }
                                            else
                                            {
                                                cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                CCognexUtil.DrawString(DispMain, $"Model : {detResult.Class} Score : {detResult.Score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                                            }
                                        }
                                        else
                                        {
                                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                            CCognexUtil.DrawString(DispMain, $"Model : {detResult.Class} Score : {detResult.Score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                                        }
                                        findResult = $"Score : {detResult.Score} \n Rect : {detResult.Box.X}, {detResult.Box.Y}, {detResult.Box.Width}, {detResult.Box.Height}";
                                        break;
                                    }
                                }

                            }

                            LblResultEYED.Text = findResult;

                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                (sender as UIButton).Text = "Roi";
            }
        }

        private void Btn_Inspect_Click(object sender, EventArgs e)
        {

            Stopwatch inspectwatch = new Stopwatch();
            Global.RunView = true;
            Global.NGDataList.Clear();
            Global.Instance.OnStart_Porgess();
            bmanualMode = true;
            Global.logicCount = 0;
            Global.Retry_Count = Global.Mode.ReInspecCnt + 1;
            Global.totalCount = inspector.TotalCount();
            Global.bSimulation = true;
            inspector.Execute(new Stopwatch(), false, Global.ImagesGrab);

            inspectorWatch = inspectwatch;
            inspectorWatch.Restart();

            // 결과값 드로우..처리..

            //if (results.results.Count == 0)
            //{
            //    // 프로그레스 동작 종료
            //    return;
            //}

            //// 여기 임시로 처리
            //if (Global.Mode.isSimulRMS)
            //{
            //    Global.RMS_PostProcessing();
            //}

            //// 프로그레스 동작 종료
            //Global.Instance.OnEnd_Progress();

            //});


        }

        private void cbbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageProcessingMethod selectedItem = (ImageProcessingMethod)cbbMethod.SelectedItem;

            dgvParameter.Rows.Clear();

            switch (selectedItem)
            {
                case ImageProcessingMethod.None:
                    break;
                case ImageProcessingMethod.Binarization:
                    IF_VisionParam_Binarization pre_Binarize = new IF_VisionParam_Binarization();
                    pre_Binarize.Type = ImageProcessingMethod.Binarization;
                    LoadParametersToDataGridView(pre_Binarize, dgvParameter);
                    break;
                case ImageProcessingMethod.Morphology:
                    IF_VisionParam_Morphology pre_morphology = new IF_VisionParam_Morphology();
                    pre_morphology.Type = ImageProcessingMethod.Morphology;
                    LoadParametersToDataGridView(pre_morphology, dgvParameter);
                    break;
                case ImageProcessingMethod.MedianFilter:
                    IF_VisionParam_MedianBlur pre_medianFilter = new IF_VisionParam_MedianBlur();
                    pre_medianFilter.Type = ImageProcessingMethod.MedianFilter;
                    LoadParametersToDataGridView(pre_medianFilter, dgvParameter);
                    //dgvParameter.Rows.Add("Kernel", 3);
                    break;
                case ImageProcessingMethod.SobelFilter:
                    IF_VisionParam_SobelFilter pre_sobelFilter = new IF_VisionParam_SobelFilter();
                    pre_sobelFilter.Type = ImageProcessingMethod.SobelFilter;
                    LoadParametersToDataGridView(pre_sobelFilter, dgvParameter);
                    break;
                case ImageProcessingMethod.CannyFilter:
                    IF_VisionParam_CannyFilter pre_cannyFilter = new IF_VisionParam_CannyFilter();
                    pre_cannyFilter.Type = ImageProcessingMethod.CannyFilter;
                    LoadParametersToDataGridView(pre_cannyFilter, dgvParameter);
                    break;
                case ImageProcessingMethod.GaussianBlur:
                    IF_VisionParam_GaussianBlur pre_gaussianBlur = new IF_VisionParam_GaussianBlur();
                    pre_gaussianBlur.Type = ImageProcessingMethod.GaussianBlur;
                    LoadParametersToDataGridView(pre_gaussianBlur, dgvParameter);
                    break;
                case ImageProcessingMethod.Laplacian:
                    IF_VisionParam_LaplacialFilter pre_laplacian = new IF_VisionParam_LaplacialFilter();
                    pre_laplacian.Type = ImageProcessingMethod.Laplacian;
                    LoadParametersToDataGridView(pre_laplacian, dgvParameter);
                    break;
                case ImageProcessingMethod.GammaCorrection:
                    IF_VisionParam_GammaCorrection pre_gammaCorrection = new IF_VisionParam_GammaCorrection();
                    pre_gammaCorrection.Type = ImageProcessingMethod.GammaCorrection;
                    LoadParametersToDataGridView(pre_gammaCorrection, dgvParameter);
                    break;
                case ImageProcessingMethod.Equalization:
                    IF_VisionParam_Equalization pre_equalization = new IF_VisionParam_Equalization();
                    pre_equalization.Type = ImageProcessingMethod.Equalization;
                    LoadParametersToDataGridView(pre_equalization, dgvParameter);
                    break;

                case ImageProcessingMethod.PerspectiveTransform:
                    IF_VisionParam_Perspective pre_perspectiveTransform = new IF_VisionParam_Perspective();
                    pre_perspectiveTransform.Type = ImageProcessingMethod.PerspectiveTransform;
                    LoadParametersToDataGridView(pre_perspectiveTransform, dgvParameter);
                    break;
                case ImageProcessingMethod.Affine:
                    IF_VisionParam_Affine pre_affine = new IF_VisionParam_Affine();
                    pre_affine.Type = ImageProcessingMethod.Affine;
                    LoadParametersToDataGridView(pre_affine, dgvParameter);
                    break;

                case ImageProcessingMethod.DFT:
                    IF_VisionParam_DFT pre_dft = new IF_VisionParam_DFT();
                    pre_dft.Type = ImageProcessingMethod.DFT;
                    LoadParametersToDataGridView(pre_dft, dgvParameter);
                    break;

                case ImageProcessingMethod.ExtractColorChannel:
                    IF_VisionParam_ExtractColorChannel pre_extractColorChannel = new IF_VisionParam_ExtractColorChannel();
                    pre_extractColorChannel.Type = ImageProcessingMethod.ExtractColorChannel;
                    LoadParametersToDataGridView(pre_extractColorChannel, dgvParameter);
                    //dgvParameter.Rows.Add("Channel", 0);
                    break;
                case ImageProcessingMethod.ColorConversion:
                    IF_VisionParam_Color pre_colorConversion = new IF_VisionParam_Color();
                    pre_colorConversion.Type = ImageProcessingMethod.ColorConversion;
                    LoadParametersToDataGridView(pre_colorConversion, dgvParameter);
                    break;

            }
        }
        private void LoadParametersToDataGridView(object parameterObject, DataGridView dgv)
        {
            if (parameterObject == null || dgv == null)
                return;

            // DataGridView 초기화
            dgv.Rows.Clear();

            // 대상 객체의 타입 가져오기
            Type type = parameterObject.GetType();

            // 리플렉션을 사용하여 속성 읽기
            foreach (var prop in type.GetProperties())
            {
                object value = prop.GetValue(parameterObject);

                // Enum 타입이면 ComboBoxCell로 설정
                if (prop.PropertyType.IsEnum)
                {
                    if (prop.Name == "Type") continue;

                    DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();

                    foreach (var enumValue in Enum.GetValues(prop.PropertyType))
                    {
                        if (comboBoxCell.Items.Contains(enumValue.ToString())) continue;
                        comboBoxCell.Items.Add(enumValue.ToString());
                    }
                    comboBoxCell.Value = value.ToString(); // 현재 값 설정

                    int rowIndex = dgv.Rows.Add(prop.Name, ""); // 빈 값 추가
                    dgv.Rows[rowIndex].Cells[1] = comboBoxCell; // 콤보 박스 적용
                }
                else if (prop.PropertyType == typeof(MatType))
                {
                    DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                    // MatType의 모든 static readonly 필드 가져오기
                    FieldInfo[] fields = typeof(MatType).GetFields(BindingFlags.Public | BindingFlags.Static);

                    foreach (var field in fields)
                    {
                        object fieldValue = field.GetValue(null); // static이므로 인스턴스 필요 없음
                        if (fieldValue != null)
                        {
                            comboBoxCell.Items.Add(fieldValue.ToString());
                        }
                    }

                    comboBoxCell.Value = value.ToString(); // 현재 값 설정

                    int rowIndex = dgv.Rows.Add(prop.Name, ""); // 빈 값 추가
                    dgv.Rows[rowIndex].Cells[1] = comboBoxCell; // 콤보 박스 적용
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell
                    {
                        Items = { "True", "False" },
                        Value = value.ToString()
                    };
                    int rowIndex = dgv.Rows.Add(prop.Name, "");
                    dgv.Rows[rowIndex].Cells[1] = comboBoxCell;
                }
                else
                {
                    dgv.Rows.Add(prop.Name, value);
                }
            }
        }

        private void OnClickPreProcessing(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as UIButton).Text;
                ImageProcessingMethod selectedItem = (ImageProcessingMethod)cbbMethod.SelectedItem;
                IF_ImageProcessing imageprocessing = null;
                MatType matType = MatType.CV_8UC1;

                switch (strIndex)
                {
                    case "Add":
                    case "Apply":

                        switch (selectedItem)
                        {
                            case ImageProcessingMethod.None:
                                IF_Util.ShowMessageBox("Empty", "Please register ImageProcessing");
                                break;
                            case ImageProcessingMethod.Binarization:
                                IF_VisionParam_Binarization binarization = new IF_VisionParam_Binarization();
                                binarization.ThresholdType = Convert.ToBoolean(dgvParameter.Rows[0].Cells[1].Value);
                                binarization.ThresholdValue = Convert.ToDouble(dgvParameter.Rows[1].Cells[1].Value);
                                binarization.MaxValue = Convert.ToDouble(dgvParameter.Rows[2].Cells[1].Value);
                                imageprocessing = binarization;
                                imageprocessing.Type = ImageProcessingMethod.Binarization;
                                imageprocessing.ImageType = Convert.ToBoolean(dgvParameter.Rows[3].Cells[1].Value);
                                break;
                            case ImageProcessingMethod.Morphology:
                                IF_VisionParam_Morphology morphology = new IF_VisionParam_Morphology();
                                if (Enum.TryParse(dgvParameter.Rows[0].Cells[1].Value.ToString(), out MorphTypes morphType)) morphology.MorphType = morphType;
                                morphology.KernerSize = Convert.ToInt32(dgvParameter.Rows[1].Cells[1].Value);
                                morphology.PointX = Convert.ToInt32(dgvParameter.Rows[2].Cells[1].Value);
                                morphology.PointY = Convert.ToInt32(dgvParameter.Rows[3].Cells[1].Value);
                                morphology.Iterations = Convert.ToInt32(dgvParameter.Rows[4].Cells[1].Value);
                                imageprocessing = morphology;
                                imageprocessing.Type = ImageProcessingMethod.Morphology;
                                break;
                            case ImageProcessingMethod.MedianFilter:
                                IF_VisionParam_MedianBlur medianfilter = new IF_VisionParam_MedianBlur();
                                medianfilter.KernerSize = Convert.ToInt32(dgvParameter.Rows[0].Cells[1].Value);
                                imageprocessing = medianfilter;
                                imageprocessing.Type = ImageProcessingMethod.MedianFilter;
                                break;
                            case ImageProcessingMethod.SobelFilter:
                                IF_VisionParam_SobelFilter sobelfilter = new IF_VisionParam_SobelFilter();
                                string sobelValue = dgvParameter.Rows[0].Cells[1].Value.ToString();

                                switch (sobelValue.ToUpper())
                                {
                                    case "CV_8UC1": matType = MatType.CV_8UC1; break;
                                    case "CV_8UC2": matType = MatType.CV_8UC2; break;
                                    case "CV_8UC3": matType = MatType.CV_8UC3; break;
                                    case "CV_8UC4": matType = MatType.CV_8UC4; break;
                                    case "CV_8SC1": matType = MatType.CV_8SC1; break;
                                    case "CV_8SC2": matType = MatType.CV_8SC2; break;
                                    case "CV_8SC3": matType = MatType.CV_8SC3; break;
                                    case "CV_8SC4": matType = MatType.CV_8SC4; break;
                                    case "CV_16UC1": matType = MatType.CV_16UC1; break;
                                    case "CV_16UC2": matType = MatType.CV_16UC2; break;
                                    case "CV_16UC3": matType = MatType.CV_16UC3; break;
                                    case "CV_16UC4": matType = MatType.CV_16UC4; break;
                                    case "CV_16SC1": matType = MatType.CV_16SC1; break;
                                    case "CV_16SC2": matType = MatType.CV_16SC2; break;
                                    case "CV_16SC3": matType = MatType.CV_16SC3; break;
                                    case "CV_16SC4": matType = MatType.CV_16SC4; break;
                                    case "CV_32SC1": matType = MatType.CV_32SC1; break;
                                    case "CV_32SC2": matType = MatType.CV_32SC2; break;
                                    case "CV_32SC3": matType = MatType.CV_32SC3; break;
                                    case "CV_32SC4": matType = MatType.CV_32SC4; break;
                                    case "CV_32FC1": matType = MatType.CV_32FC1; break;
                                    case "CV_32FC2": matType = MatType.CV_32FC2; break;
                                    case "CV_32FC3": matType = MatType.CV_32FC3; break;
                                    case "CV_32FC4": matType = MatType.CV_32FC4; break;
                                    case "CV_64FC1": matType = MatType.CV_64FC1; break;
                                    case "CV_64FC2": matType = MatType.CV_64FC2; break;
                                    case "CV_64FC3": matType = MatType.CV_64FC3; break;
                                    case "CV_64FC4": matType = MatType.CV_64FC4; break;
                                    case "0": matType = MatType.CV_8U; break;
                                    case "1": matType = MatType.CV_8S; break;
                                    case "2": matType = MatType.CV_16U; break;
                                    case "3": matType = MatType.CV_16S; break;
                                    case "4": matType = MatType.CV_32S; break;
                                    case "5": matType = MatType.CV_32F; break;
                                    case "6": matType = MatType.CV_64F; break;
                                    case "7": matType = MatType.CV_USRTYPE1; break;
                                }

                                sobelfilter.MatType = matType;



                                sobelfilter.OrderX = Convert.ToInt32(dgvParameter.Rows[1].Cells[1].Value);
                                sobelfilter.OrderY = Convert.ToInt32(dgvParameter.Rows[2].Cells[1].Value);
                                sobelfilter.KernerSize = Convert.ToInt32(dgvParameter.Rows[3].Cells[1].Value);
                                sobelfilter.Scale = Convert.ToDouble(dgvParameter.Rows[4].Cells[1].Value);
                                sobelfilter.Delta = Convert.ToDouble(dgvParameter.Rows[5].Cells[1].Value);
                                if (Enum.TryParse(dgvParameter.Rows[6].Cells[1].Value.ToString(), out BorderTypes sobelBorderType)) sobelfilter.BorderType = sobelBorderType;
                                imageprocessing = sobelfilter;
                                imageprocessing.Type = ImageProcessingMethod.SobelFilter;
                                break;
                            case ImageProcessingMethod.CannyFilter:
                                IF_VisionParam_CannyFilter cannyfilter = new IF_VisionParam_CannyFilter();
                                cannyfilter.LowThreshold = Convert.ToDouble(dgvParameter.Rows[0].Cells[1].Value);
                                cannyfilter.HighThreshold = Convert.ToDouble(dgvParameter.Rows[1].Cells[1].Value);
                                cannyfilter.ApertureSize = Convert.ToInt32(dgvParameter.Rows[2].Cells[1].Value);
                                cannyfilter.L2Gradient = Convert.ToBoolean(dgvParameter.Rows[3].Cells[1].Value);
                                imageprocessing = cannyfilter;
                                imageprocessing.Type = ImageProcessingMethod.CannyFilter;
                                break;
                            case ImageProcessingMethod.GaussianBlur:
                                IF_VisionParam_GaussianBlur gaussianblur = new IF_VisionParam_GaussianBlur();
                                gaussianblur.KernerSizeX = Convert.ToInt32(dgvParameter.Rows[0].Cells[1].Value);
                                gaussianblur.KernerSizeY = Convert.ToInt32(dgvParameter.Rows[1].Cells[1].Value);
                                gaussianblur.SigmaX = Convert.ToDouble(dgvParameter.Rows[2].Cells[1].Value);
                                gaussianblur.SigmaY = Convert.ToDouble(dgvParameter.Rows[3].Cells[1].Value);
                                if (Enum.TryParse(dgvParameter.Rows[4].Cells[1].Value.ToString(), out BorderTypes gausBorderType)) gaussianblur.BorderType = gausBorderType;
                                imageprocessing = gaussianblur;
                                imageprocessing.Type = ImageProcessingMethod.GaussianBlur;
                                break;
                            case ImageProcessingMethod.Laplacian:
                                IF_VisionParam_LaplacialFilter laplacian = new IF_VisionParam_LaplacialFilter();
                                string laplacianValue = dgvParameter.Rows[0].Cells[1].Value.ToString();
                                switch (laplacianValue.ToUpper())
                                {
                                    case "CV_8UC1": matType = MatType.CV_8UC1; break;
                                    case "CV_8UC2": matType = MatType.CV_8UC2; break;
                                    case "CV_8UC3": matType = MatType.CV_8UC3; break;
                                    case "CV_8UC4": matType = MatType.CV_8UC4; break;
                                    case "CV_8SC1": matType = MatType.CV_8SC1; break;
                                    case "CV_8SC2": matType = MatType.CV_8SC2; break;
                                    case "CV_8SC3": matType = MatType.CV_8SC3; break;
                                    case "CV_8SC4": matType = MatType.CV_8SC4; break;
                                    case "CV_16UC1": matType = MatType.CV_16UC1; break;
                                    case "CV_16UC2": matType = MatType.CV_16UC2; break;
                                    case "CV_16UC3": matType = MatType.CV_16UC3; break;
                                    case "CV_16UC4": matType = MatType.CV_16UC4; break;
                                    case "CV_16SC1": matType = MatType.CV_16SC1; break;
                                    case "CV_16SC2": matType = MatType.CV_16SC2; break;
                                    case "CV_16SC3": matType = MatType.CV_16SC3; break;
                                    case "CV_16SC4": matType = MatType.CV_16SC4; break;
                                    case "CV_32SC1": matType = MatType.CV_32SC1; break;
                                    case "CV_32SC2": matType = MatType.CV_32SC2; break;
                                    case "CV_32SC3": matType = MatType.CV_32SC3; break;
                                    case "CV_32SC4": matType = MatType.CV_32SC4; break;
                                    case "CV_32FC1": matType = MatType.CV_32FC1; break;
                                    case "CV_32FC2": matType = MatType.CV_32FC2; break;
                                    case "CV_32FC3": matType = MatType.CV_32FC3; break;
                                    case "CV_32FC4": matType = MatType.CV_32FC4; break;
                                    case "CV_64FC1": matType = MatType.CV_64FC1; break;
                                    case "CV_64FC2": matType = MatType.CV_64FC2; break;
                                    case "CV_64FC3": matType = MatType.CV_64FC3; break;
                                    case "CV_64FC4": matType = MatType.CV_64FC4; break;
                                    case "0": matType = MatType.CV_8U; break;
                                    case "1": matType = MatType.CV_8S; break;
                                    case "2": matType = MatType.CV_16U; break;
                                    case "3": matType = MatType.CV_16S; break;
                                    case "4": matType = MatType.CV_32S; break;
                                    case "5": matType = MatType.CV_32F; break;
                                    case "6": matType = MatType.CV_64F; break;
                                    case "7": matType = MatType.CV_USRTYPE1; break;
                                }

                                laplacian.DDepth = matType;

                                laplacian.KernerSize = Convert.ToInt32(dgvParameter.Rows[1].Cells[1].Value);
                                laplacian.Scale = Convert.ToDouble(dgvParameter.Rows[2].Cells[1].Value);
                                laplacian.Delta = Convert.ToDouble(dgvParameter.Rows[3].Cells[1].Value);
                                if (Enum.TryParse(dgvParameter.Rows[4].Cells[1].Value.ToString(), out BorderTypes laplaBorderType)) laplacian.BorderType = laplaBorderType;
                                imageprocessing = laplacian;
                                imageprocessing.Type = ImageProcessingMethod.Laplacian;
                                break;
                            case ImageProcessingMethod.GammaCorrection:
                                IF_VisionParam_GammaCorrection gammacorrection = new IF_VisionParam_GammaCorrection();
                                string gammaValue = dgvParameter.Rows[0].Cells[1].Value.ToString();
                                switch (gammaValue.ToUpper())
                                {
                                    case "CV_8UC1": matType = MatType.CV_8UC1; break;
                                    case "CV_8UC2": matType = MatType.CV_8UC2; break;
                                    case "CV_8UC3": matType = MatType.CV_8UC3; break;
                                    case "CV_8UC4": matType = MatType.CV_8UC4; break;
                                    case "CV_8SC1": matType = MatType.CV_8SC1; break;
                                    case "CV_8SC2": matType = MatType.CV_8SC2; break;
                                    case "CV_8SC3": matType = MatType.CV_8SC3; break;
                                    case "CV_8SC4": matType = MatType.CV_8SC4; break;
                                    case "CV_16UC1": matType = MatType.CV_16UC1; break;
                                    case "CV_16UC2": matType = MatType.CV_16UC2; break;
                                    case "CV_16UC3": matType = MatType.CV_16UC3; break;
                                    case "CV_16UC4": matType = MatType.CV_16UC4; break;
                                    case "CV_16SC1": matType = MatType.CV_16SC1; break;
                                    case "CV_16SC2": matType = MatType.CV_16SC2; break;
                                    case "CV_16SC3": matType = MatType.CV_16SC3; break;
                                    case "CV_16SC4": matType = MatType.CV_16SC4; break;
                                    case "CV_32SC1": matType = MatType.CV_32SC1; break;
                                    case "CV_32SC2": matType = MatType.CV_32SC2; break;
                                    case "CV_32SC3": matType = MatType.CV_32SC3; break;
                                    case "CV_32SC4": matType = MatType.CV_32SC4; break;
                                    case "CV_32FC1": matType = MatType.CV_32FC1; break;
                                    case "CV_32FC2": matType = MatType.CV_32FC2; break;
                                    case "CV_32FC3": matType = MatType.CV_32FC3; break;
                                    case "CV_32FC4": matType = MatType.CV_32FC4; break;
                                    case "CV_64FC1": matType = MatType.CV_64FC1; break;
                                    case "CV_64FC2": matType = MatType.CV_64FC2; break;
                                    case "CV_64FC3": matType = MatType.CV_64FC3; break;
                                    case "CV_64FC4": matType = MatType.CV_64FC4; break;
                                    case "0": matType = MatType.CV_8U; break;
                                    case "1": matType = MatType.CV_8S; break;
                                    case "2": matType = MatType.CV_16U; break;
                                    case "3": matType = MatType.CV_16S; break;
                                    case "4": matType = MatType.CV_32S; break;
                                    case "5": matType = MatType.CV_32F; break;
                                    case "6": matType = MatType.CV_64F; break;
                                    case "7": matType = MatType.CV_USRTYPE1; break;
                                }

                                gammacorrection.MatType = matType;
                                gammacorrection.Alpha = Convert.ToDouble(dgvParameter.Rows[1].Cells[1].Value);
                                gammacorrection.Beta = Convert.ToDouble(dgvParameter.Rows[2].Cells[1].Value);
                                imageprocessing = gammacorrection;
                                imageprocessing.Type = ImageProcessingMethod.GammaCorrection;
                                break;

                            case ImageProcessingMethod.Equalization:
                                IF_VisionParam_Equalization equlization = new IF_VisionParam_Equalization();
                                if (Enum.TryParse(dgvParameter.Rows[0].Cells[1].Value.ToString(), out EqualizationType equlizationType)) equlization.EqualizationType = equlizationType;
                                equlization.TileGridSizeX = Convert.ToInt32(dgvParameter.Rows[1].Cells[1].Value);
                                equlization.TileGridSizeY = Convert.ToInt32(dgvParameter.Rows[2].Cells[1].Value);
                                equlization.ClipLimit = Convert.ToDouble(dgvParameter.Rows[3].Cells[1].Value);
                                imageprocessing = equlization;
                                imageprocessing.Type = ImageProcessingMethod.Equalization;
                                break;

                            case ImageProcessingMethod.PerspectiveTransform:
                                IF_VisionParam_Perspective perspective = new IF_VisionParam_Perspective();
                                perspective.SrcPointLT = Convert.ToSingle(dgvParameter.Rows[0].Cells[1].Value);
                                perspective.SrcPointRT = Convert.ToSingle(dgvParameter.Rows[1].Cells[1].Value);
                                perspective.SrcPointLB = Convert.ToSingle(dgvParameter.Rows[2].Cells[1].Value);
                                perspective.SrcPointRB = Convert.ToSingle(dgvParameter.Rows[3].Cells[1].Value);
                                perspective.DstPointLT = Convert.ToSingle(dgvParameter.Rows[4].Cells[1].Value);
                                perspective.DstPointRT = Convert.ToSingle(dgvParameter.Rows[5].Cells[1].Value);
                                perspective.DstPointLB = Convert.ToSingle(dgvParameter.Rows[6].Cells[1].Value);
                                perspective.DstPointRB = Convert.ToSingle(dgvParameter.Rows[7].Cells[1].Value);
                                perspective.DstSizeX = Convert.ToInt32(dgvParameter.Rows[8].Cells[1].Value);
                                perspective.DstSizeY = Convert.ToInt32(dgvParameter.Rows[9].Cells[1].Value);
                                imageprocessing = perspective;
                                imageprocessing.Type = ImageProcessingMethod.PerspectiveTransform;
                                break;
                            case ImageProcessingMethod.Affine:
                                IF_VisionParam_Affine affine = new IF_VisionParam_Affine();
                                affine.ScaleX = Convert.ToDouble(dgvParameter.Rows[0].Cells[1].Value);
                                affine.ShearingX = Convert.ToDouble(dgvParameter.Rows[1].Cells[1].Value);
                                affine.TranslationX = Convert.ToDouble(dgvParameter.Rows[2].Cells[1].Value);
                                affine.ScaleY = Convert.ToDouble(dgvParameter.Rows[3].Cells[1].Value);
                                affine.ShearingY = Convert.ToDouble(dgvParameter.Rows[4].Cells[1].Value);
                                affine.TranslationY = Convert.ToDouble(dgvParameter.Rows[5].Cells[1].Value);
                                imageprocessing = affine;
                                imageprocessing.Type = ImageProcessingMethod.Affine;
                                break;

                            case ImageProcessingMethod.DFT:
                                IF_VisionParam_DFT dft = new IF_VisionParam_DFT();
                                if (Enum.TryParse(dgvParameter.Rows[0].Cells[1].Value.ToString(), out DftFlags DftFlag)) dft.Flag = DftFlag;
                                dft.NonzeroRows = Convert.ToInt32(dgvParameter.Rows[1].Cells[1].Value);
                                imageprocessing = dft;
                                imageprocessing.Type = ImageProcessingMethod.DFT;
                                break;

                            case ImageProcessingMethod.ExtractColorChannel:
                                IF_VisionParam_ExtractColorChannel extractcolorchannel = new IF_VisionParam_ExtractColorChannel();
                                extractcolorchannel.Number = Convert.ToInt32(dgvParameter.Rows[0].Cells[1].Value);
                                imageprocessing = extractcolorchannel;
                                imageprocessing.Type = ImageProcessingMethod.ExtractColorChannel;
                                break;
                            case ImageProcessingMethod.ColorConversion:
                                IF_VisionParam_Color color = new IF_VisionParam_Color();
                                if (Enum.TryParse(dgvParameter.Rows[0].Cells[1].Value.ToString(), out ColorConversionCodes CCCType)) color.CCC = CCCType;
                                color.DstCn = Convert.ToInt32(dgvParameter.Rows[1].Cells[1].Value);
                                imageprocessing = color;
                                imageprocessing.Type = ImageProcessingMethod.ColorConversion;
                                break;

                        }

                        if (strIndex == "Add" && imageprocessing != null)
                        {
                            DgvProcessingList.Rows.Clear();
                            int lastKey = 0;
                            lastKey = m_Logic.ImgProcessingList.Count;
                            m_Logic.ImgProcessingList[lastKey.ToString()] = imageprocessing;
                            for (int i = 0; i < m_Logic.ImgProcessingList.Count; i++)
                            {
                                imageprocessing = m_Logic.ImgProcessingList[i.ToString()];
                                DgvProcessingList.Rows.Add(new object[] { i + 1, imageprocessing.Type });
                            }
                        }
                        else if (strIndex == "Apply")
                        {
                            int lastRowIndex = dgvParameter.Rows.Count - 1;
                            DgvProcessingList.Rows[m_SelectedProcessing].Cells[1].Value = imageprocessing.Type;
                            m_Logic.ImgProcessingList[m_SelectedProcessing.ToString()] = imageprocessing;
                            if (lastRowIndex >= 0) m_Logic.ImgProcessingList[m_SelectedProcessing.ToString()].ImageType = Convert.ToBoolean(dgvParameter.Rows[lastRowIndex].Cells[1].Value);
                        }
                        break;
                    case "Del":
                        DgvProcessingList.Rows.Clear();
                        m_Logic.ImgProcessingList.Remove(m_SelectedProcessing.ToString());
                        // Dictionary 변경해야됨.
                        Dictionary<string, IF_ImageProcessing> newData = new Dictionary<string, IF_ImageProcessing>();
                        int index = 0;
                        foreach (var kvp in m_Logic.ImgProcessingList)
                        {
                            newData[index.ToString()] = kvp.Value;
                            index++;
                        }
                        m_Logic.ImgProcessingList = newData;
                        for (int i = 0; i < m_Logic.ImgProcessingList.Count; i++)
                        {
                            imageprocessing = m_Logic.ImgProcessingList[i.ToString()];
                            DgvProcessingList.Rows.Add(new object[] { i + 1, imageprocessing.Type });
                        }
                        break;
                    case "Run":
                        Mat mat_image = new Mat();
                        if (m_Logic.ImgProcessingList[m_SelectedProcessing.ToString()].ImageType)
                        {
                            Bitmap bitmap = new Bitmap(m_imgSource_Mono.ToBitmap());
                            mat_image = BitmapConverter.ToMat(bitmap).Clone();
                        }
                        else
                        {
                            Bitmap bitmap = new Bitmap(m_imgSource_Color.ToBitmap());
                            mat_image = BitmapConverter.ToMat(bitmap).Clone();
                        }

                        Mat mat_resultImage = new Mat();
                        if (m_Logic.ImgProcessingList.Count > 0)
                        {
                            mat_resultImage = PreProcessor.ExecutePreProcessing(mat_image, m_Logic);
                            DispMain.Image = new CogImage8Grey(new Bitmap(mat_resultImage.ToBitmap()));
                        }
                        else
                        {
                            IF_Util.ShowMessageBox("Error", "Please register ImageProcessing");
                        }
                        break;
                    case "Clear":
                        SelectGrabImage(m_Logic.GrabIndex, false);
                        CropArray(m_nSelectedArrayIndex - 1);
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }


        }

        private void DgvProcessingList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DgvProcessingList.SelectedRows.Count > 0)
                {
                    m_SelectedProcessing = DgvProcessingList.SelectedRows[0].Index;
                    m_Processing = m_Logic.ImgProcessingList[m_SelectedProcessing.ToString()];
                    cbbMethod.SelectedItem = m_Processing.Type;
                    Selected_PreProcessing(m_Logic.ImgProcessingList[m_SelectedProcessing.ToString()]);
                }
            }
            catch
            {
            }
        }

        private void BtnJobListCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Clone", $"Do you want to Clone \nArray 1 To Array 2?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    if (CbJobAll.Checked)
                    {

                        List<IF_VisionLogicInfo> copyLibrary = new List<IF_VisionLogicInfo>();
                        List<IF_VisionLogicInfo> removeLibrary = new List<IF_VisionLogicInfo>();
                        if (m_Job.Library.ContainsKey(2)) m_Job.Library.TryRemove(2, out removeLibrary);
                        foreach (IF_VisionLogicInfo info in m_Job.Library[1])
                        {
                            //copyinfo = new IF_VisionLogicInfo();
                            //copyinfo.LocationNo = info.LocationNo;
                            //copyinfo.PartCode = info.PartCode;
                            //copyinfo.PosX = info.PosX;
                            //copyinfo.PosY = info.PosY;
                            //copyinfo.PosAngle = info.PosAngle;
                            //copyinfo.Description = info.Description;
                            //copyinfo.Enabled = info.Enabled;
                            //copylogics = new List<IF_VisionParamObject>();
                            //foreach (IF_VisionParamObject logic in info.Logics)
                            //{
                            //    copylogics.Add(CopyLogic(logic,0,0,0,0));

                            //}
                            //copyinfo.Logics = copylogics;
                            copyLibrary.Add(CopyJob(info, 0, 0));
                        }

                        m_Job.Library.TryAdd(2, new List<IF_VisionLogicInfo>(copyLibrary));

                    }
                    else
                    {
                    }
                }
                IF_Util.ShowMessageBox("Clone Complete", $"Complete Clone \nArray 1 To Array 2!!");

            }
            catch
            {
            }
        }

        private void btnFiducial_Measure_Click(object sender, EventArgs e)
        {
            try
            {

                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                Stopwatch sw = new Stopwatch();
                sw.Start();

                CTemplateMatching matchingLT = new CTemplateMatching("LT");
                CTemplateMatching matchingRB = new CTemplateMatching("RB");

                matchingLT.SetSourceImage(m_imgSource_Color.ToBitmap());
                matchingRB.SetSourceImage(m_imgSource_Color.ToBitmap());

                matchingLT.Run(_selectedFiducialLibrary.Fiducial1);

                Point2d posLT = new Point2d(0, 0);
                Point2d posRB = new Point2d(0, 0);

                Rect rectLT = new Rect();
                Rect rectRB = new Rect();

                if (matchingLT.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (LT)"); return; }
                if (matchingRB.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (RB)"); return; }

                posLT = matchingLT.Results[0].Center;
                posRB = matchingRB.Results[0].Center;

                rectLT = matchingLT.Results[0].Bounding;
                rectRB = matchingRB.Results[0].Bounding;

                CogLineSegment line = new CogLineSegment();
                line.SetStartEnd(posLT.X, posLT.Y, posRB.X, posRB.Y);
                line.Color = CogColorConstants.Red;


                DispMain.StaticGraphics.Add(line, "LINE");
                DispMain.StaticGraphics.Add(CConverter.CVRectToCogRect(rectLT), "LT");
                DispMain.StaticGraphics.Add(CConverter.CVRectToCogRect(rectRB), "RB");
                if (m_Fiducial_PreView)
                {
                    Pen redPen = new Pen(System.Drawing.Color.Red, 30.0f);
                    Pen bluePen = new Pen(System.Drawing.Color.Blue, 30.0f);
                    _selectedFiducialLibrary.ImagePreview = DispMain.Image.ToBitmap().DeepClone();
                    Graphics g = Graphics.FromImage(_selectedFiducialLibrary.ImagePreview);
                    g.DrawLine(redPen, (float)posLT.X, (float)posLT.Y, (float)posRB.X, (float)posRB.Y);
                    g.DrawRectangle(bluePen, new System.Drawing.Rectangle(rectLT.X, rectLT.Y, rectLT.Width, rectLT.Height));
                    g.DrawRectangle(bluePen, new System.Drawing.Rectangle(rectRB.X, rectRB.Y, rectRB.Width, rectRB.Height));
                }
                double angle = IF_Util.GetAngle(posLT, posRB);
                lblDegreeMeasure.Text = $"{angle:F5}";

                double angleDelta = angle - _selectedFiducialLibrary.MasterAngle;
                lblDegreeDelta.Text = $"{angleDelta:F5}";
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnFiducial_MeasureToMaster_Click(object sender, EventArgs e)
        {
            try
            {
                // 현재 마스터 데이터 변경 메세지 박스...
                if (IF_Util.ShowMessageBox("Fiducial", "Would you like to change the current Fiducial master value settings?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    _selectedFiducialLibrary.MasterAngle = double.Parse(lblDegreeMeasure.Text);
                    lblDegreeMaster.Text = $"{_selectedFiducialLibrary.MasterAngle:F5}";
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnResetMaster_Click(object sender, EventArgs e)
        {
            try
            {
                // 현재 마스터 데이터 변경 메세지 박스...
                if (IF_Util.ShowMessageBox("Master", "Would you RESET Master Degree?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    _selectedFiducialLibrary.MasterAngle = 0;
                    lblDegreeMaster.Text = $"{_selectedFiducialLibrary.MasterAngle:F5}";
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnImageAlign_Rotate_Click(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                Stopwatch tactTime = new Stopwatch();
                tactTime.Start();

                CTemplateMatching matchingLT = new CTemplateMatching("LT");
                CTemplateMatching matchingRB = new CTemplateMatching("RB");
                int tactTime_1st = 0;

                //2024.03.15 송현수 -> 안춘길 : 이미지 회전이 1회 완료가 X, 3번 반복
                for (int i = 0; i < 3; i++)
                {
                    using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()))
                    using (Mat imgRot = new Mat())
                    {
                        matchingLT.SetSourceImage(m_imgSource_Color.ToBitmap());
                        matchingRB.SetSourceImage(m_imgSource_Color.ToBitmap());

                        matchingLT.Run(_selectedFiducialLibrary.Fiducial1);

                        Point2d posLT = new Point2d(0, 0);
                        Point2d posRB = new Point2d(0, 0);

                        Rect rectLT = new Rect();
                        Rect rectRB = new Rect();

                        if (matchingLT.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (LT)"); return; }
                        if (matchingRB.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (RB)"); return; }

                        posLT = matchingLT.Results[0].Center;
                        posRB = matchingRB.Results[0].Center;

                        rectLT = matchingLT.Results[0].Bounding;
                        rectRB = matchingRB.Results[0].Bounding;

                        CogLineSegment line = new CogLineSegment();
                        line.SetStartEnd(posLT.X, posLT.Y, posRB.X, posRB.Y);
                        line.Color = CogColorConstants.Red;

                        DispMain.StaticGraphics.Add(line, "LINE");
                        DispMain.StaticGraphics.Add(CConverter.CVRectToCogRect(rectLT), "LT");
                        DispMain.StaticGraphics.Add(CConverter.CVRectToCogRect(rectRB), "RB");

                        double angle = IF_Util.GetAngle(posLT, posRB);
                        lblDegreeMeasure.Text = $"{angle:F5}";

                        double angleDelta = angle - _selectedFiducialLibrary.MasterAngle;

                        if (Math.Abs(angleDelta) < 0.005)
                        {
                            break;
                        }
                        else
                        {
                            lblDegreeDelta.Text = $"{angleDelta:F5}";

                            Point2f posCenter = new Point2f(imgOrg.Width / 2, imgOrg.Height / 2);
                            // 회전을 위한 변환 행렬을 얻습니다.
                            Mat rotationMatrix = Cv2.GetRotationMatrix2D(posCenter, angleDelta, 1.0);

                            // 이미지를 변환 행렬을 사용하여 회전시킵니다.
                            Cv2.WarpAffine(imgOrg, imgRot, rotationMatrix, imgOrg.Size());

                            tactTime_1st = (int)tactTime.ElapsedMilliseconds;
                            _imageSourceCV = imgRot.Clone();
                            m_imgSource_Color = new CogImage24PlanarColor(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgRot));
                        }
                    }
                }

                DispMain.Image = m_imgSource_Color;
                //lblTactTime.Text = $"T/T : {tactTime_1st}/{tactTime.ElapsedMilliseconds} ms";
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnCondensorAutoRegion_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnJobCondensor_Roi.Text == "Roi")
                {
                    IF_Util.ShowMessageBox("Error", "Click first Roi Button (Condensor)");
                    return;
                }

                int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.CenterX = roi.CenterX;
                m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.CenterY = roi.CenterY;
                m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.Radius = roi.Width / 4;

                string polarity = comboCondensorPolarity.Text;

                if (polarity == "T")
                {
                    m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.AngleStart = (Math.PI * -65.0D / 180.0D);
                    m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.AngleSpan = (Math.PI * 305.0D / 180.0D);
                }
                else if (polarity == "B")
                {
                    m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.AngleStart = (Math.PI * 100.0D / 180.0D);
                    m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.AngleSpan = (Math.PI * 305.0D / 180.0D);
                }
                else if (polarity == "L")
                {
                    m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.AngleStart = (Math.PI * -150.0D / 180.0D);
                    m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.AngleSpan = (Math.PI * 305.0D / 180.0D);
                }
                else if (polarity == "R")
                {
                    m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.AngleStart = (Math.PI * 30.0D / 180.0D);
                    m_Condensor.Find_Circle.RunParams.ExpectedCircularArc.AngleSpan = (Math.PI * 305.0D / 180.0D);
                }

                m_Condensor.Find_Circle.RunParams.CaliperSearchLength = roi.Width * 2;
                m_Condensor.Find_Circle.RunParams.CaliperProjectionLength = 30;
                m_Condensor.SearchRegion = CConverter.CogRectToRect(roi);
                btnJobCondensor_Roi.Text = "Roi";
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void BtnOpenOnnx_Click_1(object sender, EventArgs e)
        {
            Global.FrmPopup_EYED.ShowDialog();
        }

        private void btnLibrarySelect_Click(object sender, EventArgs e)
        {
            if (Global.Instance.Frm_PBA_Library == null || !Global.Instance.Frm_PBA_Library.Created)

            {
                Global.Instance.Frm_PBA_Library = new FormMenu_PbaLibrary();
            }

            Global.Instance.Frm_PBA_Library.BringToFront();
            Global.Instance.Frm_PBA_Library.Owner = this;
            Global.Instance.Frm_PBA_Library.Show();
        }

        private void BtnInspectAuto_Click(object sender, EventArgs e)
        {
            Global.NGDataList.Clear();
            Global.logicCount = 0;
            Global.totalCount = inspector.TotalCount();
            Global.Notice = "Auto Inspection SEQ Run";
            Global.SeqVision.ManualInsp = CSeqVision.ManualType.GRAB_INSP;
        }

        private void btnUpLoadPartLibrary_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Check", $"Do you want to UpLoad Master {m_SelectedLogicName}?"))
                {
                    //if(m_SelectedPartCode.Contains("NO-CODE"))
                    //{
                    //    IF_Util.ShowMessageBox("Error", $"Please Check PartCode {m_SelectedPartCode}");
                    //    return;
                    //}
                    IF_VisionLogicInfo libraryinfo = new IF_VisionLogicInfo();
                    List<IF_VisionLogicInfo> master_library = new List<IF_VisionLogicInfo>();
                    if (!Global.System.Recipe.MasterPartLibrary.Library.ContainsKey(m_nSelectedArrayIndex))
                    {
                        Global.System.Recipe.MasterPartLibrary.Library.TryAdd(m_nSelectedArrayIndex, new List<IF_VisionLogicInfo>());
                    }
                    else
                    {
                        master_library = Global.System.Recipe.MasterPartLibrary.Library[m_nSelectedArrayIndex];
                    }

                    if (!Global.System.Recipe.MasterLibrary.Library.ContainsKey(m_nSelectedArrayIndex))
                    {
                        Global.System.Recipe.MasterLibrary.Library.TryAdd(m_nSelectedArrayIndex, new List<IF_VisionLogicInfo>());
                    }

                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {
                        if (info.LocationNo == m_SelectedLocationNo)
                        {
                            libraryinfo = info;
                            break;
                        }
                    }


                    if (Global.System.Recipe.MasterPartLibrary.Library.TryGetValue(m_nSelectedArrayIndex, out var partList))
                    {
                        var updatedList = new List<IF_VisionLogicInfo>(partList); // 기존 리스트 복사
                        int targetIndex = updatedList.FindIndex(l => l.PartCode == libraryinfo.PartCode);
                        IF_VisionLogicInfo newinfo = new IF_VisionLogicInfo();
                        IF_VisionLogicInfo updateinfo = new IF_VisionLogicInfo();

                        if (targetIndex != -1)
                        {
                            updatedList[targetIndex] = CopyJob(libraryinfo, 0, 0);
                            Global.System.Recipe.MasterPartLibrary.Library.TryUpdate(m_nSelectedArrayIndex, updatedList, partList); // 원본 리스트와 비교 후 업데이트
                            updateinfo = updatedList[targetIndex];
                        }
                        else
                        {
                            newinfo = CopyJob(libraryinfo, 0, 0);
                            Global.System.Recipe.MasterPartLibrary.Library[m_nSelectedArrayIndex].Add(newinfo);
                            updateinfo = newinfo;
                        }
                        Global.System.Recipe.MasterPartLibrary.Save("Part", Global.System.Recipe.CODE);
                        Global.System.Recipe.SaveMasterCogTools("Part", Global.System.Recipe.MasterPartLibrary, m_nSelectedArrayIndex, updateinfo);
                    }


                    if (Global.System.Recipe.MasterLibrary.Library.TryGetValue(m_nSelectedArrayIndex, out var libraryList))
                    {
                        var updatedList = new List<IF_VisionLogicInfo>(libraryList); // 기존 리스트 복사
                        IF_VisionLogicInfo newinfo = new IF_VisionLogicInfo();
                        IF_VisionLogicInfo updateinfo = new IF_VisionLogicInfo();
                        //int targetIndex = updatedList.FindIndex(l => l.LocationNo == libraryinfo.LocationNo);
                        //int targetLastIndex = updatedList.FindLastIndex(l => l.LocationNo == libraryinfo.LocationNo);
                        //int targetPartIndex = updatedList.FindIndex(l => l.PartCode == libraryinfo.PartCode);
                        int inputIndex = 0;

                        var findLocationNo = updatedList.FindAll(l => l.LocationNo == libraryinfo.LocationNo);
                        if (findLocationNo.Count != 0)
                        {
                            var findPartCode = findLocationNo.Find(l => l.PartCode == libraryinfo.PartCode);
                            if (findPartCode != null)
                            {
                                inputIndex = updatedList.IndexOf(findPartCode);
                                updatedList[inputIndex] = CopyJob(libraryinfo, 0, 0);
                                Global.System.Recipe.MasterLibrary.Library.TryUpdate(m_nSelectedArrayIndex, updatedList, libraryList); // 원본 리스트와 비교 후 업데이트
                                updateinfo = updatedList[inputIndex];
                            }
                            else
                            {
                                newinfo = CopyJob(libraryinfo, 0, 0);
                                Global.System.Recipe.MasterLibrary.Library[m_nSelectedArrayIndex].Add(newinfo);
                                updateinfo = newinfo;
                            }
                        }
                        else
                        {
                            newinfo = CopyJob(libraryinfo, 0, 0);
                            Global.System.Recipe.MasterLibrary.Library[m_nSelectedArrayIndex].Add(newinfo);
                            updateinfo = newinfo;
                        }
                        //if (targetIndex != -1 && targetLastIndex != -1  && targetPartIndex != -1)
                        //{
                        //    if (targetIndex == targetPartIndex) inputIndex = targetIndex;
                        //    else if (targetLastIndex == targetPartIndex) inputIndex = targetLastIndex;
                        //    if (inputIndex != 0)
                        //    {
                        //        updatedList[inputIndex] = CopyJob(libraryinfo, 0, 0);
                        //        Global.System.Recipe.MasterLibrary.Library.TryUpdate(m_nSelectedArrayIndex, updatedList, libraryList); // 원본 리스트와 비교 후 업데이트
                        //        updateinfo = updatedList[inputIndex];
                        //    }
                        //    else
                        //    {
                        //        newinfo = CopyJob(libraryinfo, 0, 0);
                        //        Global.System.Recipe.MasterLibrary.Library[m_nSelectedArrayIndex].Add(newinfo);
                        //        updateinfo = newinfo;
                        //    }
                        //}

                        Global.System.Recipe.MasterLibrary.Save("Library", Global.System.Recipe.CODE);
                        Global.System.Recipe.SaveMasterCogTools("Library", Global.System.Recipe.MasterLibrary, m_nSelectedArrayIndex, updateinfo);
                    }
                    IF_Util.ShowMessageBox("Finish", $"Master UpLoad Complete {m_SelectedLocationNo}");
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnDownLoadPartLibrary_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Check", "Should to DownLoad the MasterPart?") == false)
                {
                    return;
                }
                //if (m_SelectedPartCode.Contains("NO-CODE"))
                //{
                //    IF_Util.ShowMessageBox("Error", $"Please Check PartCode {m_SelectedPartCode}");
                //    return;
                //}
                //IF_VisionLogicInfo partinfo = new IF_VisionLogicInfo();
                //IF_VisionLogicInfo jobinfo = new IF_VisionLogicInfo();
                //foreach (IF_VisionLogicInfo codeinfo in m_Job.Library[m_nSelectedArrayIndex])
                //{
                //    if (codeinfo.LocationNo == m_SelectedLocationNo)
                //    {
                //        partinfo = codeinfo;
                //        break;
                //    }
                //}

                if (m_Job.Library.TryGetValue(m_nSelectedArrayIndex, out var jobList))
                {
                    var updateList = new List<IF_VisionLogicInfo>(jobList); // 기존 라이브러리 복사
                    int targetIndex = updateList.FindIndex(l => l.LocationNo == m_SelectedLocationNo);
                    if (Global.System.Recipe.MasterLibrary.Library.TryGetValue(m_nSelectedArrayIndex, out var partList))
                    {
                        var masterList = new List<IF_VisionLogicInfo>(partList); // 마스터 파트라이브러리 복사
                        var findLocationNo = masterList.FindAll(l => l.LocationNo == m_SelectedLocationNo);
                        if (findLocationNo.Count != 0)
                        {
                            var findPartCode = findLocationNo.Find(l => l.PartCode == m_SelectedPartCode);
                            if (findPartCode != null)
                            {
                                updateList[targetIndex].Logics.Clear();

                                updateList[targetIndex] = CopyJob(findPartCode, 0, 0);
                                m_Job.Library.TryUpdate(m_nSelectedArrayIndex, updateList, jobList); // 원본 리스트와 비교 후 업데이트

                                DgvLogicList.Rows.Clear();

                                foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                                {
                                    if (info.LocationNo == m_SelectedLocationNo)
                                    {

                                        m_LogicInfo = info;
                                        if (info.Logics.Count > 0)
                                        {
                                            for (int i = 0; i < info.Logics.Count; i++)
                                            {
                                                DgvLogicList.Rows.Add(new object[] { i + 1, info.Logics[i].Enabled, info.Logics[i].Name, info.Logics[i].GrabIndex,
                                                    info.Logics[i].Type, info.Logics[i].JudgeType_Judge_NaisNg});
                                            }
                                            //m_Logic = null;
                                            m_Logic = info.Logics[0];
                                            Selected_Logic(m_Logic, false);
                                        }
                                        DgvJobList.Rows[m_SelectedJob].Cells[4].Value = info.Logics.Count;
                                        IF_Util.ShowMessageBox("Finish", $"Master DownLoad Complete {m_SelectedLocationNo}");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                IF_Util.ShowMessageBox("Check", $"There is no Master {m_SelectedLocationNo} Currently Registered");
                            }
                        }
                        else
                        {
                            IF_Util.ShowMessageBox("Check", $"There is no Master {m_SelectedLocationNo} Currently Registered");
                        }
                    }
                    else
                    {
                        IF_Util.ShowMessageBox("Error", "Should to UpLoaded the MasterPart first");

                    }


                }
            }
            catch
            {
            }
        }

        private void BtnGrabMove_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabIndex = cbGrabIndex.SelectedIndex;
                SelectGrabImage(nGrabIndex, true);
                CropArray(m_nSelectedArrayIndex - 1);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void BtnViewJobs_Click(object sender, EventArgs e)
        {
            if (m_imgSource_Color == null || m_imgSource_Color.Width == 0 || m_imgSource_Color.Height == 0)
            {
                MessageBox.Show("Have no Orignal Image");
                return;
            }
            string logicName = "";
            Rectangle rtSearch = new Rectangle();
            IF_VisionParam_Matching matching = new IF_VisionParam_Matching();
            using (Bitmap imgResult = m_imgSource_Color.ToBitmap())
            using (Graphics g = Graphics.FromImage(imgResult))
            using (Pen penSearchRegion = new Pen(Color.Yellow, 10))
            using (Pen penSearchRegion2 = new Pen(Color.Orange, 10))
            using (SolidBrush brush_OK = new SolidBrush(Color.Lime))
            using (Font font = new Font("Arial", 36, FontStyle.Bold))
            {
                foreach (IF_VisionLogicInfo info in Global.Instance.System.Recipe.LibraryManager.Library[m_nSelectedArrayIndex])
                {
                    for (int i = 0; i < info.Logics.Count; i++)
                    {
                        if (info.Logics[i].Type == "Pattern")
                        {
                            matching = info.Logics[i] as IF_VisionParam_Matching;
                            rtSearch = CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)matching.PMAlignTools[0].SearchRegion);
                        }
                        else
                        {
                            rtSearch = info.Logics[i].SearchRegion;
                        }
                        logicName = info.Logics[i].Name;

                        g.DrawString($"{info.LocationNo}-{logicName}", font, brush_OK, rtSearch.Location);

                        if (info.Logics[i].Enabled) g.DrawRectangle(penSearchRegion, rtSearch);
                        else g.DrawRectangle(penSearchRegion2, rtSearch);
                    }
                }
                DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(imgResult);
            }
        }

        private void BtnIQDataSave_Click(object sender, EventArgs e)
        {
            try
            {
                CogRectangle guideLine = GetCalibrationROI();
                Task.Run(() => IQResultSave(guideLine));
                iqResultDatas.Save();
            }
            catch
            {
            }
        }

        private void BtnIQLoad_Click(object sender, EventArgs e)
        {
            iqResultDatas = iqResultDatas.Load();
            lblMasterWidth.Text = iqResultDatas.WidthValue.ToString();
            lblMasterHeight.Text = iqResultDatas.HeightValue.ToString();
            lblMasterPixel.Text = iqResultDatas.PixelValue.ToString();
            lblMasterFocus.Text = iqResultDatas.FocusValue.ToString();
            try { iqResultImage = IF_Util.SafetyImageLoad($"{iqResultRootPath}\\IQ_AlphaImage.png"); } catch { }
        }
        private void OnPaint(object sender, Bitmap img)
        {
            try
            {
                Graphics g = Graphics.FromImage(img);

                if (iqResultImage != null)
                {
                    g.DrawTransparentImage(float.Parse(TbTransparent.Text), iqResultImage, new Rectangle(0, 0, iqResultImage.Width, iqResultImage.Height));
                    g.DrawImage(img, 0, 0, img.Width, img.Height);
                }
            }
            catch
            {
            }

        }

        private void BtnMasterBoardSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.System.Recipe.Name == "")
                {
                    MessageBox.Show($"Model 이름이 없습니다.", "Model Recipe 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string path = $"{iqResultRootPath}\\MASTER\\{Global.System.Recipe.Name}";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                try { IF_Util.SafetyImageSave($"{path}\\MasterImage.bmp", DispMain.Image.ToBitmap()); } catch (Exception ex) { }
            }
            catch
            {
            }
        }

        private void BtnMasterBoardLoad_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap masterImage = null;
                try { masterImage = IF_Util.SafetyImageLoad($"{iqResultRootPath}\\MASTER\\{Global.System.Recipe.Name}\\MasterImage.bmp"); } catch (Exception ex) { }
                if (masterImage == null)
                {
                    MessageBox.Show($"현재 MasterImage 가 없습니다.", "MasterImage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Cogdis_Master.Image = new CogImage24PlanarColor(masterImage);
                Cogdis_Master.Fit(false);
            }
            catch
            {
            }
        }

        private void BtnBareBoardLoad_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap BareBoardImage = null;
                try { BareBoardImage = IF_Util.SafetyImageLoad($"{iqResultRootPath}\\BareBoard\\{Global.System.Recipe.CODE}\\BareBoardImage.bmp"); } catch (Exception ex) { }
                if (BareBoardImage == null)
                {
                    MessageBox.Show($"현재 BareBoard Image 가 없습니다.", "BareBoard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Cogdis_Bare.Image = new CogImage24PlanarColor(BareBoardImage);
                Cogdis_Bare.Fit(false);
            }
            catch
            {
            }
        }

        private void BtnBareBoardSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.System.Recipe.CODE == "")
                {
                    MessageBox.Show($"Library 이름이 없습니다.", "Library Recipe 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string path = $"{iqResultRootPath}\\BareBoard\\{Global.System.Recipe.CODE}";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                try { IF_Util.SafetyImageSave($"{path}\\BareBoardImage.bmp", DispMain.Image.ToBitmap()); } catch (Exception ex) { }
            }
            catch
            {
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            int nWild = 0;
            try
            {
                Keys key = keyData & ~(Keys.Shift | Keys.Control);

                switch (key)
                {

                    case Keys.F1:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                BtnViewJobs_Click(null, null);
                            }
                            else
                            {
                                pnlHelp.Visible = !pnlHelp.Visible;
                            }
                        }
                        break;
                    //case Keys.Delete:
                    //    {
                    //        BtnLogicDelete_Click(BtnLogicDelete, new EventArgs());
                    //    }
                    //    break;

                    case Keys.Space:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                //OnClickJob_Pattern(btnJobPattern_Insp, new EventArgs());
                            }
                        }
                        break;



                    case Keys.Left:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control
                                && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {

                                MoveRegion(m_Logic, -1, 0);

                                CLogger.Add(LOG.NORMAL, $"Recipe Job's Search Roi Left");
                            }
                        }
                        break;

                    case Keys.Right:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control
                                && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                MoveRegion(m_Logic, 1, 0);

                                CLogger.Add(LOG.NORMAL, $"Recipe Job's Search Roi Right");
                            }


                        }
                        break;
                    case Keys.Up:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control
                                && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {

                                MoveRegion(m_Logic, 0, -1);

                                CLogger.Add(LOG.NORMAL, $"Recipe Job's Search Roi Up");
                            }
                        }
                        break;
                    case Keys.Down:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control
                                && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                MoveRegion(m_Logic, 0, 1);

                                CLogger.Add(LOG.NORMAL, $"Recipe Job's Search Roi Down");
                            }
                        }
                        break;
                    case Keys.A:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                if (m_Logic != null)
                                {
                                    IF_VisionParam_Matching matching = m_Logic as IF_VisionParam_Matching;
                                    if (m_Logic.Type == "Pattern")
                                    {
                                        int nSelectedPM = 0;
                                        if (comboJobPattern_PatternType.Text == "1") nSelectedPM = 0;
                                        else if (comboJobPattern_PatternType.Text == "2") nSelectedPM = 1;
                                        else if (comboJobPattern_PatternType.Text == "3") nSelectedPM = 2;
                                        else if (comboJobPattern_PatternType.Text == "4") nSelectedPM = 3;
                                        else if (comboJobPattern_PatternType.Text == "5") nSelectedPM = 4;
                                        CogPMAlignTool PMAlign = null;
                                        PMAlign = m_Matching.PMAlignTools[nSelectedPM];
                                        if (PMAlign.Pattern.Trained)
                                        {
                                            Cognex.VisionPro.CogRectangle searchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.SearchRegion;
                                            Cognex.VisionPro.CogRectangle patternRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Pattern.TrainRegion;

                                            nWild = 50;
                                            searchRegion.X = patternRegion.X - nWild;
                                            searchRegion.Y = patternRegion.Y - nWild;
                                            searchRegion.Width = patternRegion.Width + nWild * 2;
                                            searchRegion.Height = patternRegion.Height + nWild * 2;

                                            OnClickAlgorithm_Pattern(btnJobPattern_Roi, new EventArgs());
                                        }
                                        else
                                        {
                                            IF_Util.ShowMessageBox("Error", "First Pattern Train");
                                        }
                                    }
                                    //else if (comboAlgorithm.Text.Contains("Color"))
                                    //{
                                    //    nWild = 50;
                                    //    Roi_ColorSearchRegion.X = Roi_ColorVAlues.X - nWild;
                                    //    Roi_ColorSearchRegion.Y = Roi_ColorVAlues.Y - nWild;
                                    //    Roi_ColorSearchRegion.Width = Roi_ColorVAlues.Width + nWild * 2;
                                    //    Roi_ColorSearchRegion.Height = Roi_ColorVAlues.Height + nWild * 2;
                                    //    //btnJobColor_Apply_Click(null, null);
                                    //    btnJobAllApply_Click(null, null);
                                    //    OnClickAlgorithm_Color(btnJobColor_Roi, null);
                                    //}
                                }
                            }
                        }
                        break;

                    case Keys.W:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                if (m_Logic != null)
                                {
                                    IF_VisionParam_Matching matching = m_Logic as IF_VisionParam_Matching;
                                    if (m_Logic.Type == "Pattern")
                                    {
                                        int nSelectedPM = 0;
                                        if (comboJobPattern_PatternType.Text == "1") nSelectedPM = 0;
                                        else if (comboJobPattern_PatternType.Text == "2") nSelectedPM = 1;
                                        else if (comboJobPattern_PatternType.Text == "3") nSelectedPM = 2;
                                        else if (comboJobPattern_PatternType.Text == "4") nSelectedPM = 3;
                                        else if (comboJobPattern_PatternType.Text == "5") nSelectedPM = 4;
                                        CogPMAlignTool PMAlign = null;
                                        PMAlign = m_Matching.PMAlignTools[nSelectedPM];

                                        Cognex.VisionPro.CogRectangle searchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.SearchRegion;
                                        Cognex.VisionPro.CogRectangle patternRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Pattern.TrainRegion;

                                        nWild = 10;
                                        searchRegion.X = searchRegion.X - nWild;
                                        searchRegion.Y = searchRegion.Y - nWild;
                                        searchRegion.Width = searchRegion.Width + nWild * 2;
                                        searchRegion.Height = searchRegion.Height + nWild * 2;

                                        OnClickAlgorithm_Pattern(btnJobPattern_Roi, new EventArgs());
                                    }
                                }
                            }
                        }
                        break;

                    case Keys.Q:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                if (m_Logic != null)
                                {
                                    IF_VisionParam_Matching matching = m_Logic as IF_VisionParam_Matching;
                                    if (m_Logic.Type == "Pattern")
                                    {
                                        int nSelectedPM = 0;
                                        if (comboJobPattern_PatternType.Text == "1") nSelectedPM = 0;
                                        else if (comboJobPattern_PatternType.Text == "2") nSelectedPM = 1;
                                        else if (comboJobPattern_PatternType.Text == "3") nSelectedPM = 2;
                                        else if (comboJobPattern_PatternType.Text == "4") nSelectedPM = 3;
                                        else if (comboJobPattern_PatternType.Text == "5") nSelectedPM = 4;
                                        CogPMAlignTool PMAlign = null;
                                        PMAlign = m_Matching.PMAlignTools[nSelectedPM];

                                        Cognex.VisionPro.CogRectangle searchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.SearchRegion;
                                        Cognex.VisionPro.CogRectangle patternRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Pattern.TrainRegion;

                                        nWild = 10;
                                        searchRegion.X = searchRegion.X + nWild;
                                        searchRegion.Y = searchRegion.Y + nWild;
                                        searchRegion.Width = searchRegion.Width - nWild * 2;
                                        searchRegion.Height = searchRegion.Height - nWild * 2;

                                        OnClickAlgorithm_Pattern(btnJobPattern_Roi, new EventArgs());
                                    }
                                }
                            }
                        }
                        break;

                    case Keys.T:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                OnClickAlgorithm_Pattern(btnJobPattern_Train, new EventArgs());
                                OnClickAlgorithm_Pattern(btnJobPattern_Roi, new EventArgs());
                            }
                        }
                        break;
                    case Keys.F:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                Shorcut_Find();
                            }
                        }
                        break;

                    case Keys.R:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                Shorcut_Roi();
                            }
                        }
                        break;

                    case Keys.S:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                                {
                                    btnSave_Click(null, null);
                                }
                                else
                                {
                                    if (IF_Util.ShowMessageBox("Apply", "Do you want to Apply"))
                                    {
                                        BtnApplyCore_Click(this, new EventArgs());
                                    }
                                }
                            }
                        }
                        break;
                    case Keys.D0:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(m_imgSource_Color_FullBoard);
                                m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(m_imgSource_Mono_FullBoard);

                                DispMain.Image = m_imgSource_Color_FullBoard;
                                DispMain.Fit(true);
                            }
                        }
                        break;

                    case Keys.D1:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                OnClickViewMode(btnView_Setting1, null);
                            }
                        }
                        break;

                    case Keys.D2:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                OnClickViewMode(btnView_Setting2, null);
                            }
                        }
                        break;

                    case Keys.D3:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                OnClickViewMode(btnView_Setting3, null);
                            }
                        }
                        break;

                    case Keys.V:
                        {
                            //if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            //{
                            //    Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Add(m_selectedJob.Clone());
                            //    Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count - 1].Name += "-COPY";

                            //    string strCode = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count - 1].Name;

                            //    CJob job = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count - 1];

                            //    string str_ColorMethod = "-";
                            //    if (job.Name.ToLower() == "pattern")
                            //    {
                            //        if (job.ChkColor)
                            //        {
                            //            str_ColorMethod = $"{job.CCoordinate.ToString()}/{job.CMethod.ToString()}";
                            //        }
                            //    }
                            //    gridLibrary.Rows[m_nSelectedIndex_Library].Cells[0].Value = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count - 1;
                            //    gridLibrary.Rows[m_nSelectedIndex_Library].Cells[1].Value = job.Enabled;                        //Enabled
                            //    gridLibrary.Rows[m_nSelectedIndex_Library].Cells[2].Value = job.Name;                           //Name
                            //    gridLibrary.Rows[m_nSelectedIndex_Library].Cells[3].Value = job.GrabIndex;                      //GrabIndex
                            //    gridLibrary.Rows[m_nSelectedIndex_Library].Cells[4].Value = job.Type;                           //Type
                            //    gridLibrary.Rows[m_nSelectedIndex_Library].Cells[5].Value = job.Judge_NaisNg;                   //Mode
                            //    gridLibrary.Rows[m_nSelectedIndex_Library].Cells[7].Value = str_ColorMethod;                    //ColorMethod
                            //    //gridLibrary.Rows[m_nSelectedIndex_Library].Cells[8].Value = job.Parameter.UseEyeD;                //DL Check
                            //    //gridLibrary.Rows[gridLibrary.Rows.Count - 1].Selected = true;
                            //    //gridLibrary.FirstDisplayedScrollingRowIndex = gridLibrary.Rows.Count - 1;
                            //    InitJobs();
                            //}
                        }
                        break;

                    case Keys.Escape:
                        return true;

                    //case Keys.F2:
                    //    btnGetDefaultParam_Click(null, null);
                    //    return true;

                    case Keys.F3:
                        {
                            if (!Global.Device.Cameras[0].IsOpen) return false;
                            btnLive.Text = "LIVE";
                            Global.Device.Cameras[0].Live(false);
                            Global.Device.Cameras[0].Grab(false);
                        }
                        return true;

                    case Keys.F5:
                        Btn_Inspect_Click(null, null);
                        return true;

                    case Keys.F10:
                        //for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                        //    Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Tool.Tool.RunParams.AcceptThreshold = 0.01;

                        return true;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Shorcut_Find()
        {
            try
            {
                switch (m_Logic.Type)
                {
                    case "Pattern":
                        OnClickAlgorithm_Pattern(btnJobPattern_Find, null);
                        break;
                    case "EYE-D":
                        OnClickAlgorithm_EyeD(BtnFindEYED, null);
                        break;
                    case "ColorEx":
                        OnClickAlgorithm_ColorEx(btnJobColorEx_Roi, null);
                        break;
                    case "Condensor":
                        OnClickAlgorithm_Condensor(btnJobCondensor_Inspection, null);
                        break;
                    case "Pin":
                        OnClickAlgorithm_EyeD(btnJobPin_Find, null);
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void Shorcut_Roi()
        {
            try
            {
                switch (m_Logic.Type)
                {
                    case "Pattern":
                        OnClickAlgorithm_Pattern(btnJobPattern_Roi, null);
                        break;
                    case "EYE-D":
                        OnClickAlgorithm_EyeD(BtnRoiEYED, null);
                        break;
                    case "ColorEx":
                        OnClickAlgorithm_ColorEx(btnJobColorEx_Roi, null);
                        break;
                    case "Condensor":
                        OnClickAlgorithm_Condensor(btnJobCondensor_Roi, null);
                        break;
                    case "Pin":
                        OnClickAlgorithm_EyeD(btnJobPin_Roi, null);
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        private void MoveRegion(IF_VisionParamObject logic, int offsetX, int offsetY)
        {
            IF_VisionParam_Matching matching = new IF_VisionParam_Matching();
            switch (logic.Type)
            {
                case "Pattern":
                    {
                        matching = logic as IF_VisionParam_Matching;
                        if (matching.PMAlignTools[0].Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)matching.PMAlignTools[0].SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            matching.PMAlignTools[0].SearchRegion = rect;
                        }
                        if (matching.PMAlignTools[1].Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)matching.PMAlignTools[1].SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            matching.PMAlignTools[1].SearchRegion = rect;
                        }
                        if (matching.PMAlignTools[2].Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)matching.PMAlignTools[2].SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            matching.PMAlignTools[2].SearchRegion = rect;
                        }
                        if (matching.PMAlignTools[3].Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)matching.PMAlignTools[3].SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            matching.PMAlignTools[3].SearchRegion = rect;
                        }
                        if (matching.PMAlignTools[4].Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)matching.PMAlignTools[4].SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            matching.PMAlignTools[4].SearchRegion = rect;
                        }
                    }
                    break;
            }
        }
        private void Form_MenuVision_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                BtnViewJobs_Click(null, null);
                            }
                            else
                            {
                                pnlHelp.Visible = !pnlHelp.Visible;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void DispMain_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DispMain.StaticGraphics.Clear();

                Cognex.VisionPro.CogTransform2DLinear xForm;
                xForm = DispMain.GetTransform("*\\#", "*") as Cognex.VisionPro.CogTransform2DLinear;
                xForm.MapPoint(e.X, e.Y, out double dPosX, out double dPosY);
                IF_VisionParam_Matching matching = new IF_VisionParam_Matching();
                IF_VisionParam_EYED eyeD = new IF_VisionParam_EYED();
                IF_VisionParam_ColorEx colorEx = new IF_VisionParam_ColorEx();
                IF_VisionParam_Condensor condensor = new IF_VisionParam_Condensor();
                IF_VisionParam_Pin pin = new IF_VisionParam_Pin();

                if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    bool isContain = false;
                    int idx = 0;
                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {
                        for (int i = 0; i < info.Logics.Count; i++)
                        {
                            switch (info.Logics[i].Type)
                            {
                                case "Pattern":
                                    matching = info.Logics[i] as IF_VisionParam_Matching;
                                    for (int j = 0; j < matching.PMAlignTools.Length; j++)
                                    {
                                        if (matching.PMAlignTools[j].SearchRegion != null)
                                        {
                                            isContain |= CConverter.CogRectToRect((CogRectangle)matching.PMAlignTools[j].SearchRegion).Contains((int)dPosX, (int)dPosY);
                                            if (isContain) break;

                                        }
                                    }
                                    break;
                                case "EYE-D":
                                    eyeD = info.Logics[i] as IF_VisionParam_EYED;
                                    isContain |= eyeD.SearchRegion.Contains((int)dPosX, (int)dPosY);
                                    break;
                                case "ColorEx":
                                    colorEx = info.Logics[i] as IF_VisionParam_ColorEx;
                                    isContain |= colorEx.SearchRegion.Contains((int)dPosX, (int)dPosY);
                                    break;
                                case "Condensor":
                                    condensor = info.Logics[i] as IF_VisionParam_Condensor;
                                    isContain |= condensor.SearchRegion.Contains((int)dPosX, (int)dPosY);
                                    break;
                                case "Pin":
                                    pin = info.Logics[i] as IF_VisionParam_Pin;
                                    isContain |= pin.SearchRegion.Contains((int)dPosX, (int)dPosY);
                                    break;
                            }
                            if (isContain)
                            {
                                m_SelectedLogic = i;
                                break;
                            }
                        }
                        if (isContain)
                        {
                            m_SelectedJob = idx;
                            break;
                        }
                        idx++;
                    }
                    if (isContain)
                    {
                        SelectRow(m_SelectedJob, m_SelectedLogic);
                    }
                }
                //if (isContain)
                //{

                //    string strCode = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Name;

                //    m_selectedJob = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i];

                //    for (int rowIdx = 0; rowIdx < gridLibrary.Rows.Count; rowIdx++)
                //    {
                //        string name = gridLibrary[2, rowIdx].Value.ToString();

                //        if (m_selectedJob.Name == name)
                //        {
                //            gridLibrary.ClearSelection(); // 선택 해제
                //            gridLibrary.Rows[rowIdx].Selected = true; // 원하는 행 선택
                //            gridLibrary.FirstDisplayedScrollingRowIndex = rowIdx;

                //            break;
                //        }
                //    }
                //}

                if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    if (m_Logic.Type.Contains("Pattern"))
                    {
                        matching = m_Logic as IF_VisionParam_Matching;
                        if (matching.PMAlignTools[0].Pattern.TrainRegion is CogRectangleAffine) matching.PMAlignTools[0].Pattern.TrainRegion = new CogRectangle();
                        if (matching.PMAlignTools[1].Pattern.TrainRegion is CogRectangleAffine) matching.PMAlignTools[1].Pattern.TrainRegion = new CogRectangle();
                        if (matching.PMAlignTools[2].Pattern.TrainRegion is CogRectangleAffine) matching.PMAlignTools[2].Pattern.TrainRegion = new CogRectangle();
                        if (matching.PMAlignTools[3].Pattern.TrainRegion is CogRectangleAffine) matching.PMAlignTools[3].Pattern.TrainRegion = new CogRectangle();
                        if (matching.PMAlignTools[4].Pattern.TrainRegion is CogRectangleAffine) matching.PMAlignTools[4].Pattern.TrainRegion = new CogRectangle();

                        if (comboJobPattern_PatternType.Text == "Main")
                        {
                            if (matching.PMAlignTools[0].SearchRegion == null)
                            {
                                matching.PMAlignTools[0].SearchRegion = new Cognex.VisionPro.CogRectangle();
                            }
                            (matching.PMAlignTools[0].SearchRegion as Cognex.VisionPro.CogRectangle).X = dPosX;
                            (matching.PMAlignTools[0].SearchRegion as Cognex.VisionPro.CogRectangle).Y = dPosY;

                            (matching.PMAlignTools[0].SearchRegion as Cognex.VisionPro.CogRectangle).Height = 200;
                            (matching.PMAlignTools[0].SearchRegion as Cognex.VisionPro.CogRectangle).Width = 200;

                            if (matching.PMAlignTools[0].Pattern.TrainRegion == null)
                            {
                                matching.PMAlignTools[0].Pattern.TrainRegion = new Cognex.VisionPro.CogRectangle();
                                (matching.PMAlignTools[0].Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).Width = 200;
                                (matching.PMAlignTools[0].Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).Height = 200;
                            }


                            (matching.PMAlignTools[0].Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).X = dPosX + 10;
                            (matching.PMAlignTools[0].Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).Y = dPosY + 10;
                        }

                        OnClickAlgorithm_Pattern(btnJobPattern_Roi, null);
                    }
                }
            }
            catch
            {
            }
        }
        private void SelectRow(int jobRowIndex, int logicRowIndex)
        {
            if (jobRowIndex >= 0 && jobRowIndex < DgvJobList.Rows.Count)
            {
                DgvJobList.ClearSelection();
                DgvJobList.Rows[jobRowIndex].Selected = true;
                DgvJobList.FirstDisplayedScrollingRowIndex = jobRowIndex;
            }
            if (logicRowIndex >= 0 && logicRowIndex < DgvLogicList.Rows.Count)
            {
                DgvLogicList.ClearSelection();
                DgvLogicList.Rows[logicRowIndex].Selected = true;
                DgvLogicList.FirstDisplayedScrollingRowIndex = logicRowIndex;
            }
        }

        private void BtnSettingJob_Click(object sender, EventArgs e)
        {
            try
            {
                string locationNo = TbLocationNo.Text;
                string partcode = TbPartName.Text;
                int idx = 0;
                if (m_Job.Library[m_nSelectedArrayIndex] != null)
                {
                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {

                        if (info.LocationNo == locationNo)
                        {
                            MessageBox.Show($"{locationNo} - 똑같은 Name을 가진 Job이 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                    {

                        if (m_SelectedJob == idx)
                        {
                            info.LocationNo = locationNo;
                            info.PartCode = partcode;
                        }
                        idx++;
                    }
                    Set_Library(false);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void BtnJobDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Check", $"Do you want to delete {m_SelectedLocationNo}?"))
                {
                    if (CbJobAll.Checked == false)
                    {
                        if (m_LogicInfo == null) return;

                        int nIndex = 0;

                        foreach (IF_VisionLogicInfo info in m_Job.Library[m_nSelectedArrayIndex])
                        {
                            if (m_SelectedLocationNo == info.LocationNo)
                            {
                                m_Job.Library[m_nSelectedArrayIndex].RemoveAt(nIndex);
                                break;
                            }
                            nIndex++;
                        }
                        Global.System.Recipe.Save_LibraryManager(Global.Instance.System.Recipe.Name);
                        Set_Library(false);
                        DeleteCogTools(Global.Instance.System.Recipe.Name, m_nSelectedArrayIndex, m_SelectedLocationNo, false);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void BtnJobDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Check", "Should to DownLoad the MasterJob?") == false)
                {
                    return;
                }
                bool bDownLoadFail = true;
                string strDownLoadFail = "";
                foreach (IF_VisionLogicInfo JobInfo in m_Job.Library[m_nSelectedArrayIndex])
                {
                    if (m_Job.Library.TryGetValue(m_nSelectedArrayIndex, out var jobList))
                    {
                        var updatejobList = new List<IF_VisionLogicInfo>(jobList); // 잡 파트라이브러리 복사

                        if (Global.System.Recipe.MasterLibrary.Library.TryGetValue(m_nSelectedArrayIndex, out var partList))
                        {
                            var masterList = new List<IF_VisionLogicInfo>(partList); // 마스터 파트라이브러리 복사

                            int jobIndex = updatejobList.FindIndex(l => l.LocationNo == JobInfo.LocationNo);
                            var findLocationNo = masterList.FindAll(l => l.LocationNo == JobInfo.LocationNo);
                            if (findLocationNo.Count != 0)
                            {
                                var findPartCode = findLocationNo.Find(l => l.PartCode == JobInfo.PartCode);
                                if (findPartCode != null)
                                {
                                    updatejobList[jobIndex].Logics.Clear();
                                    updatejobList[jobIndex] = CopyJob(findPartCode, 0, 0);
                                    m_Job.Library.TryUpdate(m_nSelectedArrayIndex, updatejobList, jobList); // 원본 리스트와 비교 후 업데이트
                                }
                                else
                                {
                                    //strDownLoadFail += JobInfo.LocationNo;
                                    bDownLoadFail = false;
                                }
                            }
                            else
                            {
                                //strDownLoadFail += JobInfo.LocationNo;
                                bDownLoadFail = false;
                            }
                        }
                        else
                        {
                            IF_Util.ShowMessageBox("Error", "Should to UpLoaded the MasterPart first");
                        }
                    }
                }
                if (bDownLoadFail == false) IF_Util.ShowMessageBox("Check", $"Should to Check LogicsCount 1");

                Set_Library(false);
                //SetRecipeInfo();
                IF_Util.ShowMessageBox("Finish", $"Master DownLoad Complete {m_nSelectedArrayIndex}");
            }
            catch
            {
            }
        }
        private IF_VisionLogicInfo CopyJob(IF_VisionLogicInfo jobInfo, int shiftX, int shiftY)
        {
            try
            {
                IF_VisionLogicInfo copyinfo = new IF_VisionLogicInfo();
                List<IF_VisionParamObject> copylogics = new List<IF_VisionParamObject>();
                copyinfo.LocationNo = jobInfo.LocationNo;
                copyinfo.PartCode = jobInfo.PartCode;
                copyinfo.PosX = jobInfo.PosX;
                copyinfo.PosY = jobInfo.PosY;
                copyinfo.PosAngle = jobInfo.PosAngle;
                copyinfo.Description = jobInfo.Description;
                copyinfo.Enabled = jobInfo.Enabled;
                copylogics = new List<IF_VisionParamObject>();
                foreach (IF_VisionParamObject logic in jobInfo.Logics)
                {
                    copylogics.Add(CopyLogic(logic, jobInfo.PosX, jobInfo.PosY, shiftX, shiftY));

                }
                copyinfo.Logics = copylogics;
                return copyinfo;
            }
            catch
            {
                return null;
            }
        }

        private void btnEyeD_ColorEx_Get_Click(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                Color color = GetColor_fromRoi(m_EYED.ColorExRegion, false);

                txtEyeD_ColorEx_R.Text = color.R.ToString();
                txtEyeD_ColorEx_G.Text = color.G.ToString();
                txtEyeD_ColorEx_B.Text = color.B.ToString();
                InputLogic();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnOriginal_Click(object sender, EventArgs e)
        {
            try
            {
                if (DispMain.Image == null) return;
                DispMain.Image = m_imgSource_Color.ScaleImage(DispMain.Image.Width, DispMain.Image.Height);
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bResult_Action)
                {
                    _bResult_Action = false;
                    btnAction.BackColor = DEFINE_COMMON.COLOR_GREEN;
                    btnAction.Refresh();
                }
                else
                {
                    _bResult_Action = true;
                    btnAction.BackColor = Color.Transparent;
                    btnAction.Refresh();
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        private void BtnModelDownAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Check", "Should to DownLoad All the MasterPart?") == false)
                {
                    return;
                }
                //if (m_SelectedPartCode.Contains("NO-CODE"))
                //{
                //    IF_Util.ShowMessageBox("Error", $"Please Check PartCode {m_SelectedPartCode}");
                //    return;
                //}
                List<string> listRecipe = new List<string>();

                string strpath = $"{Global.m_MainPJTRoot}\\RECIPE";
                DirectoryInfo di = new DirectoryInfo(strpath);
                if (di.Exists)
                {
                    DirectoryInfo[] diRecipies = di.GetDirectories();

                    for (int i = 0; i < diRecipies.Length; i++)
                    {
                        string strRecipe = diRecipies[i].Name;
                        listRecipe.Add(strRecipe);
                    }
                }

                for (int i = 0; i < listRecipe.Count; i++)
                {
                    string strName = listRecipe[i];

                    string strParameterPath = $"{strpath}\\{strName}\\JOBS\\Parameter.xml";
                    string strCode = "";
                    if (File.Exists(strParameterPath))
                    {
                        XmlTextReader xmlReader = new XmlTextReader(strParameterPath);

                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                switch (xmlReader.Name)
                                {
                                    case "PbaCode": if (xmlReader.Read()) strCode = xmlReader.Value; break;
                                }
                            }
                        }

                        xmlReader.Close();
                    }
                    else
                    {
                        strParameterPath = $"{strpath}\\{strName}\\Parameter.xml";

                        XmlTextReader xmlReader = new XmlTextReader(strParameterPath);

                        if (File.Exists(strParameterPath) == false) continue;

                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                switch (xmlReader.Name)
                                {
                                    case "PbaCode": if (xmlReader.Read()) strCode = xmlReader.Value; break;
                                }
                            }
                        }

                        xmlReader.Close();
                    }
                    if (Global.Instance.System.Recipe.CODE == strCode)
                    {
                        LibraryManager updateLibrary = new LibraryManager();
                        updateLibrary = updateLibrary.Load(strName);
                        if (updateLibrary.Library.TryGetValue(m_nSelectedArrayIndex, out var jobList))
                        {
                            var updateList = new List<IF_VisionLogicInfo>(jobList); // 기존 라이브러리 복사
                            int targetIndex = updateList.FindIndex(l => l.LocationNo == m_SelectedLocationNo);

                            if (Global.System.Recipe.MasterLibrary.Library.TryGetValue(m_nSelectedArrayIndex, out var partList))
                            {
                                var masterList = new List<IF_VisionLogicInfo>(partList); // 마스터 파트라이브러리 복사
                                int partIndex = masterList.FindIndex(l => l.LocationNo == m_SelectedLocationNo);

                                var findLocationNo = masterList.FindAll(l => l.LocationNo == m_SelectedLocationNo);
                                if (findLocationNo.Count != 0)
                                {
                                    var findPartCode = findLocationNo.Find(l => l.PartCode == m_SelectedPartCode);
                                    if (findPartCode != null)
                                    {
                                        updateList[targetIndex].Logics.Clear();

                                        updateList[targetIndex] = CopyJob(findPartCode, 0, 0);
                                        updateLibrary.Library.TryUpdate(m_nSelectedArrayIndex, updateList, jobList); // 원본 리스트와 비교 후 업데이트
                                        updateLibrary.Save(strName);
                                        Global.Instance.System.Recipe.SaveCogTool(strName, m_nSelectedArrayIndex, m_SelectedLocationNo);
                                        if (Global.Instance.System.Recipe.Name == strName)
                                        {
                                            DgvLogicList.Rows.Clear();
                                            foreach (IF_VisionLogicInfo info in updateLibrary.Library[m_nSelectedArrayIndex])
                                            {
                                                if (info.LocationNo == m_SelectedLocationNo)
                                                {
                                                    m_LogicInfo = info;
                                                    if (info.Logics.Count > 0)
                                                    {
                                                        for (int j = 0; j < info.Logics.Count; j++)
                                                        {
                                                            DgvLogicList.Rows.Add(new object[] { j + 1, info.Logics[j].Enabled, info.Logics[j].Name, info.Logics[j].GrabIndex,
                                                    info.Logics[j].Type, info.Logics[j].JudgeType_Judge_NaisNg});
                                                        }
                                                        //m_Logic = null;
                                                        m_Logic = info.Logics[0];
                                                        Selected_Logic(m_Logic, false);
                                                    }
                                                    DgvJobList.Rows[m_SelectedJob].Cells[4].Value = info.Logics.Count;
                                                    IF_Util.ShowMessageBox("Finish", $"Master DownLoad Complete {m_SelectedLocationNo}");
                                                    break;
                                                }
                                            }
                                        }
                                        //else
                                        //{
                                        //    Global.Instance.System.Recipe.SaveCogTool(strName, m_nSelectedArrayIndex, m_SelectedLocationNo);
                                        //}
                                    }
                                    else
                                    {
                                        IF_Util.ShowMessageBox("Check", $"There is no Master {m_SelectedLocationNo} Currently Registered");
                                    }
                                }
                                else
                                {
                                    IF_Util.ShowMessageBox("Check", $"There is no Master {m_SelectedLocationNo} Currently Registered");
                                }
                            }
                            else
                            {
                                IF_Util.ShowMessageBox("Error", "Should to UpLoaded the MasterPart first");

                            }


                        }
                    }
                }

            }
            catch
            {
            }

        }

        private void tabPage14_DoubleClick(object sender, EventArgs e)
        {
            if (btnUpLoadAll.Visible == true) btnUpLoadAll.Visible = false;
            else btnUpLoadAll.Visible = true;
        }

        private void btnUpLoadAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Check", $"Do you want to UpLoad Master {m_SelectedLogicName}?"))
                {

                    IF_VisionLogicInfo libraryinfo = new IF_VisionLogicInfo();
                    List<IF_VisionLogicInfo> master_library = new List<IF_VisionLogicInfo>();
                    if (!Global.System.Recipe.MasterPartLibrary.Library.ContainsKey(m_nSelectedArrayIndex))
                    {
                        Global.System.Recipe.MasterPartLibrary.Library.TryAdd(m_nSelectedArrayIndex, new List<IF_VisionLogicInfo>());
                    }
                    else
                    {
                        master_library = Global.System.Recipe.MasterPartLibrary.Library[m_nSelectedArrayIndex];
                    }

                    if (!Global.System.Recipe.MasterLibrary.Library.ContainsKey(m_nSelectedArrayIndex))
                    {
                        Global.System.Recipe.MasterLibrary.Library.TryAdd(m_nSelectedArrayIndex, new List<IF_VisionLogicInfo>());
                    }

                    List<IF_VisionLogicInfo> inputPartJobs = new List<IF_VisionLogicInfo>();
                    List<IF_VisionLogicInfo> inputJobs = new List<IF_VisionLogicInfo>();
                    foreach (IF_VisionLogicInfo JobInfo in m_Job.Library[m_nSelectedArrayIndex])
                    {
                        IF_VisionLogicInfo newinfo = new IF_VisionLogicInfo();

                        newinfo = CopyJob(JobInfo, 0, 0);
                        inputPartJobs.Add(newinfo);
                        inputJobs.Add(newinfo);

                    }
                    Global.System.Recipe.MasterPartLibrary.Library[m_nSelectedArrayIndex] = inputPartJobs;
                    Global.System.Recipe.MasterPartLibrary.Save("Part", Global.System.Recipe.CODE);
                    Global.System.Recipe.MasterLibrary.Library[m_nSelectedArrayIndex] = inputJobs;
                    Global.System.Recipe.MasterLibrary.Save("Library", Global.System.Recipe.CODE);

                    foreach (IF_VisionLogicInfo JobInfo in Global.System.Recipe.MasterPartLibrary.Library[m_nSelectedArrayIndex])
                    {
                        IF_VisionLogicInfo newinfo = new IF_VisionLogicInfo();

                        newinfo = CopyJob(JobInfo, 0, 0);
                        Global.System.Recipe.SaveMasterCogTools("Part", Global.System.Recipe.MasterPartLibrary, m_nSelectedArrayIndex, newinfo);
                    }

                    foreach (IF_VisionLogicInfo JobInfo in Global.System.Recipe.MasterLibrary.Library[m_nSelectedArrayIndex])
                    {
                        IF_VisionLogicInfo newinfo = new IF_VisionLogicInfo();
                        newinfo = CopyJob(JobInfo, 0, 0);
                        Global.System.Recipe.SaveMasterCogTools("Library", Global.System.Recipe.MasterLibrary, m_nSelectedArrayIndex, newinfo);
                    }

                }



                IF_Util.ShowMessageBox("Finish", $"Master UpLoad Complete {m_SelectedLocationNo}");


            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void DgvRecentImages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int nIdx = e.RowIndex;
                CogImage24PlanarColor imgOrg_Index0 = new CogImage24PlanarColor();

                if (Global.Data.cogRecentImages[nIdx].recentImages[0] != null && Global.Data.cogRecentImages[nIdx].recentImages[0].Allocated != null)
                {
                    imgOrg_Index0 = new CogImage24PlanarColor((CogImage24PlanarColor)Global.Data.cogRecentImages[nIdx].recentImages[0]);
                }
                for (int i = 0; i < Global.Data.cogRecentImages[nIdx].recentImages.Length; i++)
                {
                    if (Global.Data.cogRecentImages[nIdx].recentImages[i] != null && Global.Data.cogRecentImages[nIdx].recentImages[i].Allocated)
                    {
                        _imagesGrab[i] = new Cognex.VisionPro.CogImage24PlanarColor(Global.Data.cogRecentImages[nIdx].recentImages[i]);
                        if (chkAlignNoUse.Checked == false) _imagesGrab[i] = CVisionTools.RotateMarkedImage(new CogImage24PlanarColor(imgOrg_Index0), _imagesGrab[i], _selectedFiducialLibrary);
                        MenualInsImgArray[i] = new CogImage24PlanarColor(_imagesGrab[i]);
                    }
                }
                btnViewGrabIndex1.Selected = true;
                RefreshDispGrabIdx();
                SelectGrabImage(0, true);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }
        private void OnClickArrayDMCode(object sender, EventArgs e)
        {
            string strActionText = "";
            if (sender is UIButton uiBtn)
            {
                strActionText = uiBtn.Text;
            }
            else
            {
                return;
            }

            int selectedArrayIndex = comboArray.SelectedIndex;

            try
            {
                if (Global.Setting == null || Global.Setting.Recipe == null || Global.Setting.Recipe.Insp == null)
                {
                    return;
                }
                Recipe_Insp currentInspRecipe = Global.Setting.Recipe.Insp;

                switch (strActionText.ToUpper())
                {
                    case "ROI":
                        {
                            int selectedGrabIndex = GetSelectedGrabIndex();
                            if (selectedGrabIndex < 0) { return; }

                            if (_imagesGrab != null && selectedGrabIndex - 1 >= 0 && selectedGrabIndex - 1 < _imagesGrab.Length &&
                                _imagesGrab[selectedGrabIndex - 1] != null && _imagesGrab[selectedGrabIndex - 1].Allocated)
                            {
                                SelectGrabImage(selectedGrabIndex - 1, true);
                            }
                            else { return; }

                            if (DispMain.Image == null || !DispMain.Image.Allocated) { return; }

                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            CogRectangle cogRegionToShow;

                            if (selectedArrayIndex >= 0 && selectedArrayIndex < currentInspRecipe.QrRegionList.Count)
                            {
                                System.Drawing.Rectangle existingRoi = currentInspRecipe.GetQrRegion(selectedArrayIndex);

                                if (existingRoi.IsEmpty || (existingRoi.Width == 0 && existingRoi.Height == 0))
                                {
                                    cogRegionToShow = new CogRectangle();
                                    cogRegionToShow.X = 50;
                                    cogRegionToShow.Y = 50;
                                    cogRegionToShow.Width = 1000;
                                    cogRegionToShow.Height = 1000;
                                }
                                else
                                {
                                    cogRegionToShow = CCognexUtil.RectangleToCogRectangle(existingRoi);
                                }
                            }
                            else
                            {
                                return;
                            }

                            cogRegionToShow.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogRegionToShow.Interactive = true;
                            cogRegionToShow.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogRegionToShow.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogRegionToShow.Color = Cognex.VisionPro.CogColorConstants.Red;
                            cogRegionToShow.LineWidthInScreenPixels = 2;

                            DispMain.InteractiveGraphics.Add(cogRegionToShow, "Search_QR", false);

                            if (sender is UIButton uiButtonSender) uiButtonSender.Text = "SET";
                        }
                        break;

                    case "SET":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search_QR", CogDisplayZOrderConstants.Back);
                            if (idx == -1)
                            {
                                return;
                            }
                            CogRectangle currentRoiFromDisplay = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            if (currentRoiFromDisplay == null) { return; }

                            System.Drawing.Rectangle rectToSave = CCognexUtil.CogRectangleToRectangle(currentRoiFromDisplay);

                            if (selectedArrayIndex >= 0 && selectedArrayIndex < currentInspRecipe.QrRegionList.Count)
                            {
                                currentInspRecipe.SetQrRegion(selectedArrayIndex, rectToSave);
                            }
                            else { return; }

                            if (m_imgSource_Mono != null && m_imgSource_Mono.Allocated)
                            {
                                using (Bitmap monoBitmap = m_imgSource_Mono.ToBitmap())
                                {
                                    if (monoBitmap != null)
                                    {
                                        using (Bitmap croppedBitmap = IF_Util.Crop(monoBitmap, rectToSave))
                                        {
                                            if (croppedBitmap != null)
                                            {
                                                if (_croppedDMImage != null) _croppedDMImage.Dispose();
                                                _croppedDMImage = new CogImage8Grey(croppedBitmap);
                                            }
                                        }
                                    }
                                }
                            }
                            if (sender is UIButton uiButtonSender) uiButtonSender.Text = "ROI";
                        }
                        break;

                    case "READ":
                        {
                            string DMCode = "";
                            ICogGraphic resultGraphic = null;

                            if (selectedArrayIndex >= 0 && selectedArrayIndex < currentInspRecipe.QrRegionList.Count)
                            {
                                System.Drawing.Rectangle currentDmRegionToRead = currentInspRecipe.GetQrRegion(selectedArrayIndex);

                                if (!currentDmRegionToRead.IsEmpty && m_imgSource_Mono != null && m_imgSource_Mono.Allocated)
                                {
                                    DMCode = CCogTool_DataMatrix.DMRead(DispMain, m_imgSource_Mono, currentDmRegionToRead, out resultGraphic);
                                }
                                else if (m_imgSource_Mono == null || !m_imgSource_Mono.Allocated)
                                {
                                    LblDataMatrixData.Text = "Error: Mono image not ready for read.";
                                }
                                else
                                {
                                    LblDataMatrixData.Text = $"Error: ROI for array {selectedArrayIndex + 1} not set.";
                                }
                            }
                            else
                            {
                                LblDataMatrixData.Text = "Warning: Invalid combo box selection.";
                            }

                            if (_croppedDMImage != null && _croppedDMImage.Allocated)
                            {
                                if (DisplayDataMatrix != null)
                                {
                                    DisplayDataMatrix.Image = _croppedDMImage;
                                }
                            }

                            LblDataMatrixData.Text = "Data : " + DMCode;

                            if (resultGraphic != null)
                            {
                                DispMain.StaticGraphics.Add(resultGraphic, "RESULT_DM");
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(DMCode) && (selectedArrayIndex >= 0 && selectedArrayIndex < currentInspRecipe.QrRegionList.Count))
                                {
                                    LblDataMatrixData.Text = "Can't Find the Code of DataMatirx";
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        private void comboArrayNumberSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                int selectedGrabIndex = GetSelectedGrabIndex();
                SelectGrabImage(selectedGrabIndex - 1, false);
                BtnArrayRoi.Text = "Roi";
                DisplayArray.Image = null;
                DispMain.Image = _imagesGrab[selectedGrabIndex - 1];
                DispMain.Fit();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        private void BtnArrayRoi_Click(object sender, EventArgs e)
        {
            string strActionText = "";
            if (sender is UIButton uiBtn)
            {
                strActionText = uiBtn.Text;
            }
            else
            {
                return;
            }

            int selectedArrayIndex = comboArray.SelectedIndex;

            try
            {
                if (Global.Setting == null || Global.Setting.Recipe == null || Global.Setting.Recipe.Insp == null)
                {
                    return;
                }
                Recipe_Insp currentInspRecipe = Global.Setting.Recipe.Insp;

                switch (strActionText.ToUpper())
                {
                    case "ROI":
                        {
                            int selectedGrabIndex = GetSelectedGrabIndex();

                            if (selectedGrabIndex < 0)
                            {
                                return;
                            }

                            if (_imagesGrab != null && selectedGrabIndex - 1 >= 0 && selectedGrabIndex - 1 < _imagesGrab.Length &&
                                _imagesGrab[selectedGrabIndex - 1] != null && _imagesGrab[selectedGrabIndex - 1].Allocated)
                            {
                                SelectGrabImage(selectedGrabIndex - 1, true);
                            }
                            else
                            {
                                return;
                            }

                            if (DispMain.Image == null || !DispMain.Image.Allocated)
                            {
                                return;
                            }

                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            CogRectangle cogSearchRegionToShow;

                            if (selectedArrayIndex >= 0 && selectedArrayIndex < 12)
                            {
                                System.Drawing.Rectangle existingRoi = currentInspRecipe.GetQrRegion(selectedArrayIndex);

                                if (existingRoi.IsEmpty || (existingRoi.Width == 0 && existingRoi.Height == 0))
                                {
                                    cogSearchRegionToShow = new CogRectangle();
                                    cogSearchRegionToShow.SetCenterWidthHeight(DispMain.Image.Width / 2.0, DispMain.Image.Height / 2.0, 150, 150);
                                }
                                else
                                {
                                    cogSearchRegionToShow = CCognexUtil.RectangleToCogRectangle(existingRoi);
                                }
                            }
                            else
                            {
                                return;
                            }

                            cogSearchRegionToShow.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegionToShow.Interactive = true;
                            cogSearchRegionToShow.Color = CogColorConstants.Red;
                            cogSearchRegionToShow.SelectedColor = CogColorConstants.Red;
                            cogSearchRegionToShow.LineWidthInScreenPixels = 2;

                            DispMain.InteractiveGraphics.Add(cogSearchRegionToShow, "Search", false);

                            if (sender is UIButton uiButton) uiButton.Text = "Complete";
                        }
                        break;

                    case "COMPLETE":
                    case "SET":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            if (idx < 0)
                            {
                                return;
                            }
                            CogRectangle currentRoiFromDisplay = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            if (currentRoiFromDisplay == null)
                            {
                                return;
                            }

                            DispMain.InteractiveGraphics.Clear();

                            System.Drawing.Rectangle newRoiToSave = CCognexUtil.CogRectangleToRectangle(currentRoiFromDisplay);

                            if (selectedArrayIndex >= 0 && selectedArrayIndex < 12)
                            {
                                currentInspRecipe.SetQrRegion(selectedArrayIndex, newRoiToSave);

                                System.Drawing.Rectangle regionToCut = currentInspRecipe.GetQrRegion(selectedArrayIndex);

                                if (regionToCut.IsEmpty || (regionToCut.Width == 0 || regionToCut.Height == 0))
                                {

                                }
                                else if (m_imgSource_Color_FullBoard != null && m_imgSource_Color_FullBoard.Allocated &&
                                         m_imgSource_Mono_FullBoard != null && m_imgSource_Mono_FullBoard.Allocated)
                                {
                                    Bitmap tempCroppedColor = null;
                                    Bitmap tempCroppedMono = null;
                                    try
                                    {
                                        using (Bitmap fullColorBmp = m_imgSource_Color_FullBoard.ToBitmap())
                                        {
                                            if (fullColorBmp != null) tempCroppedColor = IF_Util.Crop(fullColorBmp, regionToCut);
                                        }
                                        using (Bitmap fullMonoBmp = m_imgSource_Mono_FullBoard.ToBitmap())
                                        {
                                            if (fullMonoBmp != null) tempCroppedMono = IF_Util.Crop(fullMonoBmp, regionToCut);
                                        }

                                        if (tempCroppedColor != null)
                                        {
                                            if (m_imgSource_Color != null) m_imgSource_Color.Dispose();
                                            m_imgSource_Color = new CogImage24PlanarColor(tempCroppedColor);
                                        }
                                        else { tempCroppedColor?.Dispose(); }

                                        if (tempCroppedMono != null)
                                        {
                                            if (m_imgSource_Mono != null) m_imgSource_Mono.Dispose();
                                            m_imgSource_Mono = new CogImage8Grey(tempCroppedMono);
                                        }
                                        else { tempCroppedMono?.Dispose(); }
                                    }
                                    catch (Exception)
                                    {
                                        tempCroppedColor?.Dispose();
                                        tempCroppedMono?.Dispose();

                                    }

                                    if (m_imgSource_Color != null && m_imgSource_Color.Allocated)
                                    {
                                        DispMain.Image = m_imgSource_Color;
                                        DispMain.Fit(true);
                                        if (dispIdxList != null && selectedArrayIndex >= 0 && selectedArrayIndex < dispIdxList.Count && dispIdxList[selectedArrayIndex] != null)
                                        {
                                            dispIdxList[selectedArrayIndex].Image = m_imgSource_Color;
                                            dispIdxList[selectedArrayIndex].Fit(true);
                                        }
                                    }
                                    else if (m_imgSource_Mono != null && m_imgSource_Mono.Allocated)
                                    {
                                        DispMain.Image = m_imgSource_Mono;
                                        DispMain.Fit(true);
                                        if (dispIdxList != null && selectedArrayIndex >= 0 && selectedArrayIndex < dispIdxList.Count && dispIdxList[selectedArrayIndex] != null)
                                        {
                                            dispIdxList[selectedArrayIndex].Image = m_imgSource_Mono;
                                            dispIdxList[selectedArrayIndex].Fit(true);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                return;
                            }

                            if (sender is UIButton uiButton) uiButton.Text = "Roi";
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                if (sender is UIButton uiButton) uiButton.Text = "Roi";
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[BtnArrayRoi_Click] {ex.Message}");
            }
        }

        private void BtnArraySetClick(object sender, EventArgs e)
        {
            try
            {
                if (Global.Setting == null || Global.Setting.Recipe == null || Global.Setting.Recipe.Insp == null)
                {
                    return;
                }
                Recipe_Insp currentInspRecipe = Global.Setting.Recipe.Insp;
                int selectedArrayIndex = comboArray.SelectedIndex;

                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                System.Drawing.Rectangle regionToProcess;

                if (selectedArrayIndex >= 0 && selectedArrayIndex < 12)
                {
                    regionToProcess = currentInspRecipe.GetQrRegion(selectedArrayIndex);

                    if (regionToProcess.IsEmpty || (regionToProcess.Width == 0 || regionToProcess.Height == 0))
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                System.Drawing.Rectangle cutRegion = regionToProcess;

                if (m_imgSource_Color_FullBoard != null && m_imgSource_Color_FullBoard.Allocated &&
                    m_imgSource_Mono_FullBoard != null && m_imgSource_Mono_FullBoard.Allocated)
                {
                    Bitmap tempCroppedColorBitmap = null;
                    Bitmap tempCroppedMonoBitmap = null;

                    try
                    {
                        using (Bitmap fullColorBitmap = m_imgSource_Color_FullBoard.ToBitmap())
                        {
                            if (fullColorBitmap != null)
                            {
                                tempCroppedColorBitmap = IF_Util.Crop(fullColorBitmap, cutRegion);
                            }
                        }

                        using (Bitmap fullMonoBitmap = m_imgSource_Mono_FullBoard.ToBitmap())
                        {
                            if (fullMonoBitmap != null)
                            {
                                tempCroppedMonoBitmap = IF_Util.Crop(fullMonoBitmap, cutRegion);
                            }
                        }

                        if (tempCroppedColorBitmap != null)
                        {
                            if (m_imgSource_Color != null) m_imgSource_Color.Dispose();
                            m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(tempCroppedColorBitmap);
                        }
                        else
                        {
                            tempCroppedColorBitmap?.Dispose();
                        }

                        if (tempCroppedMonoBitmap != null)
                        {
                            if (m_imgSource_Mono != null) m_imgSource_Mono.Dispose();
                            m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(tempCroppedMonoBitmap);
                        }
                        else
                        {
                            tempCroppedMonoBitmap?.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, "Image Cropping", ex);
                        tempCroppedColorBitmap?.Dispose();
                        tempCroppedMonoBitmap?.Dispose();
                        return;
                    }
                    if (m_imgSource_Color != null && m_imgSource_Color.Allocated)
                    {
                        DispMain.Image = m_imgSource_Color;
                        DispMain.Fit(true);

                        if (DisplayArray != null)
                        {
                            DisplayArray.Image = m_imgSource_Color;
                            DisplayArray.Fit(true);                 // 화면에 꽉 차게
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (m_imgSource_Mono != null && m_imgSource_Mono.Allocated)
                        {
                            DispMain.Image = m_imgSource_Mono;
                            DispMain.Fit(true);

                            if (DisplayArray != null)
                            {
                                DisplayArray.Image = m_imgSource_Mono; // DispMain과 동일한 이미지 설정
                                DisplayArray.Fit(true);
                            }
                            else
                            {

                            }
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }


        private IF_VisionParamObject CopyLogic(IF_VisionParamObject logic, int PosX, int PosY, int shiftX, int shiftY)
        {
            try
            {
                switch (logic.Type)
                {
                    case "Pattern":
                        IF_VisionParam_Matching copymatching = new IF_VisionParam_Matching();
                        IF_VisionParam_Matching matching = (logic as IF_VisionParam_Matching);
                        copymatching = (IF_VisionParam_Matching)matching.Clone();
                        for (int i = 0; i < copymatching.PMAlignTools.Length; i++)
                        {

                            Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();
                            Cognex.VisionPro.CogRectangle cogTrainRegion = new CogRectangle();
                            copymatching.PMAlignTools[i] = new CogPMAlignTool(matching.PMAlignTools[i]);

                            if ((shiftX == 0 && shiftY == 0) == false)
                            {
                                if (copymatching.PMAlignTools[i].SearchRegion != null)
                                {
                                    // 모든 Pattern SearchRegion X,Y 위치 Shift
                                    cogSearchRegion = (Cognex.VisionPro.CogRectangle)copymatching.PMAlignTools[i].SearchRegion;
                                    cogSearchRegion.X = cogSearchRegion.X + shiftX;
                                    cogSearchRegion.Y = cogSearchRegion.Y + shiftY;
                                    // Shift 후 newMatching 에 다시 넣어줌
                                    copymatching.PMAlignTools[i].SearchRegion = cogSearchRegion;

                                    // 모든 Pattern TrainRegion Shift X,Y 위치 Shift
                                    cogTrainRegion = (Cognex.VisionPro.CogRectangle)copymatching.PMAlignTools[i].Pattern.TrainRegion;
                                    cogTrainRegion.X = cogTrainRegion.X + shiftX;
                                    cogTrainRegion.Y = cogTrainRegion.Y + shiftY;
                                    // Shift 후 newMatching 에 다시 넣어줌
                                    copymatching.PMAlignTools[i].Pattern.TrainRegion = cogTrainRegion;
                                }
                                else
                                {
                                    copymatching.PMAlignTools[i].SearchRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(PosX - 150, PosY - 150, 200, 200));
                                    copymatching.PMAlignTools[i].Pattern.TrainRegion = CCognexUtil.RectangleToCogRectangle(new Rectangle(PosX - 100, PosY - 100, 100, 100));
                                }
                            }
                        }
                        logic = copymatching;
                        break;
                    case "EYE-D":
                        IF_VisionParam_EYED copyeyeD = new IF_VisionParam_EYED();
                        IF_VisionParam_EYED eyeD = logic as IF_VisionParam_EYED;
                        copyeyeD = (IF_VisionParam_EYED)eyeD.Clone();
                        if ((shiftX == 0 && shiftY == 0) == false)
                        {
                            copyeyeD.SearchRegion = new Rectangle(copyeyeD.SearchRegion.X + shiftX, copyeyeD.SearchRegion.Y + shiftY,
                                copyeyeD.SearchRegion.Width, copyeyeD.SearchRegion.Height);
                            copyeyeD.SpecRegion = new Rectangle(copyeyeD.SpecRegion.X + shiftX, copyeyeD.SpecRegion.Y + shiftY,
                                copyeyeD.SpecRegion.Width, copyeyeD.SpecRegion.Height);
                        }
                        logic = copyeyeD;
                        break;
                    case "Condensor":
                        IF_VisionParam_Condensor copycondensor = new IF_VisionParam_Condensor();
                        IF_VisionParam_Condensor condensor = (logic as IF_VisionParam_Condensor);
                        copycondensor = (IF_VisionParam_Condensor)condensor.Clone();
                        copycondensor.Find_Circle = new CogFindCircleTool(condensor.Find_Circle);
                        if ((shiftX == 0 && shiftY == 0) == false)
                        {
                            ICogRecord cogRecord;
                            cogRecord = copycondensor.Find_Circle.CreateCurrentRecord();
                            CogCircularArc cogSegment = (CogCircularArc)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
                            cogSegment.CenterX = cogSegment.CenterX + shiftX;
                            cogSegment.CenterY = cogSegment.CenterY + shiftY;
                            copycondensor.SearchRegion = new Rectangle(copycondensor.SearchRegion.X + shiftX, copycondensor.SearchRegion.Y + shiftY,
                                copycondensor.SearchRegion.Width, copycondensor.SearchRegion.Height);
                        }
                        logic = copycondensor;
                        break;
                    case "ColorEx":
                        IF_VisionParam_ColorEx copycolorEx = new IF_VisionParam_ColorEx();
                        IF_VisionParam_ColorEx colorEx = (logic as IF_VisionParam_ColorEx);
                        copycolorEx = (IF_VisionParam_ColorEx)colorEx.Clone();
                        if ((shiftX == 0 && shiftY == 0) == false)
                        {
                            copycolorEx.SearchRegion = new Rectangle(copycolorEx.SearchRegion.X + shiftX, copycolorEx.SearchRegion.Y + shiftY,
                                copycolorEx.SearchRegion.Width, copycolorEx.SearchRegion.Height);
                        }
                        logic = copycolorEx;
                        break;
                    case "Pin":
                        IF_VisionParam_Pin copypin = new IF_VisionParam_Pin();
                        IF_VisionParam_Pin pin = (logic as IF_VisionParam_Pin);
                        copypin = (IF_VisionParam_Pin)pin.Clone();
                        if ((shiftX == 0 && shiftY == 0) == false)
                        {
                            copypin.SearchRegion = new Rectangle(copypin.SearchRegion.X + shiftX, copypin.SearchRegion.Y + shiftY,
                                copypin.SearchRegion.Width, copypin.SearchRegion.Height);

                        }
                        logic = copypin;
                        break;
                }
                return logic;
            }
            catch
            {
                return logic;
            }
        }
        private void OnClickArrayQrCode(object sender, EventArgs e)
        {
            string strActionText = "";
            if (sender is UIButton uiBtn)
            {
                strActionText = uiBtn.Text;
            }
            else
            {
                return;
            }

            int selectedArrayIndex = comboArray.SelectedIndex;

            try
            {
                if (Global.Setting == null || Global.Setting.Recipe == null || Global.Setting.Recipe.Insp == null)
                {
                    return;
                }
                Recipe_Insp currentInspRecipe = Global.Setting.Recipe.Insp;

                switch (strActionText.ToUpper())
                {
                    case "ROI":
                        {
                            int selectedGrabIndex = GetSelectedGrabIndex();
                            if (selectedGrabIndex < 0) { return; }

                            if (_imagesGrab != null && selectedGrabIndex - 1 >= 0 && selectedGrabIndex - 1 < _imagesGrab.Length &&
                                _imagesGrab[selectedGrabIndex - 1] != null && _imagesGrab[selectedGrabIndex - 1].Allocated)
                            {
                                SelectGrabImage(selectedGrabIndex - 1, true);
                            }
                            else { return; }

                            if (DispMain.Image == null || !DispMain.Image.Allocated) { return; }

                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            CogRectangle cogSearchRegionToShow;

                            if (selectedArrayIndex >= 0 && selectedArrayIndex < currentInspRecipe.QrRegionList.Count)
                            {
                                System.Drawing.Rectangle existingRoi = currentInspRecipe.GetQrRegion(selectedArrayIndex);

                                if (existingRoi.IsEmpty || (existingRoi.Width == 0 && existingRoi.Height == 0))
                                {
                                    cogSearchRegionToShow = new CogRectangle();
                                    cogSearchRegionToShow.SetCenterWidthHeight(DispMain.Image.Width / 2.0, DispMain.Image.Height / 2.0, 150, 150);
                                }
                                else
                                {
                                    cogSearchRegionToShow = CCognexUtil.RectangleToCogRectangle(existingRoi);
                                }
                            }
                            else
                            {
                                return;
                            }

                            cogSearchRegionToShow.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegionToShow.Interactive = true;
                            cogSearchRegionToShow.Color = CogColorConstants.Red;
                            cogSearchRegionToShow.SelectedColor = CogColorConstants.Red;
                            cogSearchRegionToShow.LineWidthInScreenPixels = 2;

                            DispMain.InteractiveGraphics.Add(cogSearchRegionToShow, "Search_QR", false);

                            if (sender is UIButton uiButtonSender) uiButtonSender.Text = "Complete";
                        }
                        break;

                    case "SET":
                    case "COMPLETE":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search_QR", CogDisplayZOrderConstants.Back);
                            if (idx < 0) { return; }
                            CogRectangle currentRoiFromDisplay = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            if (currentRoiFromDisplay == null) { return; }

                            System.Drawing.Rectangle newRoiToSave = CCognexUtil.CogRectangleToRectangle(currentRoiFromDisplay);

                            if (selectedArrayIndex >= 0 && selectedArrayIndex < currentInspRecipe.QrRegionList.Count)
                            {
                                currentInspRecipe.SetQrRegion(selectedArrayIndex, newRoiToSave);

                                System.Drawing.Rectangle regionToCut = currentInspRecipe.GetQrRegion(selectedArrayIndex);

                                if (regionToCut.IsEmpty || (regionToCut.Width == 0 || regionToCut.Height == 0))
                                {
                                    // 영역 정보 없으면 아무것도 안 함
                                }
                                else if (m_imgSource_Color_FullBoard != null && m_imgSource_Color_FullBoard.Allocated &&
                                         m_imgSource_Mono_FullBoard != null && m_imgSource_Mono_FullBoard.Allocated)
                                {
                                    Bitmap tempCroppedColor = null;
                                    Bitmap tempCroppedMono = null;
                                    try
                                    {
                                        using (Bitmap fullColorBmp = m_imgSource_Color_FullBoard.ToBitmap())
                                        {
                                            if (fullColorBmp != null) tempCroppedColor = IF_Util.Crop(fullColorBmp, regionToCut);
                                        }
                                        using (Bitmap fullMonoBmp = m_imgSource_Mono_FullBoard.ToBitmap())
                                        {
                                            if (fullMonoBmp != null) tempCroppedMono = IF_Util.Crop(fullMonoBmp, regionToCut);
                                        }

                                        if (tempCroppedColor != null)
                                        {
                                            if (m_imgSource_Color != null) m_imgSource_Color.Dispose();
                                            m_imgSource_Color = new CogImage24PlanarColor(tempCroppedColor);
                                        }
                                        else { tempCroppedColor?.Dispose(); }

                                        if (tempCroppedMono != null)
                                        {
                                            if (m_imgSource_Mono != null) m_imgSource_Mono.Dispose();
                                            m_imgSource_Mono = new CogImage8Grey(tempCroppedMono);
                                        }
                                        else { tempCroppedMono?.Dispose(); }
                                    }
                                    catch (Exception)
                                    {
                                        tempCroppedColor?.Dispose();
                                        tempCroppedMono?.Dispose();
                                    }

                                    if (m_imgSource_Color != null && m_imgSource_Color.Allocated)
                                    {
                                        DispMain.Image = m_imgSource_Color;
                                        DispMain.Fit(true);
                                        if (dispIdxList != null && selectedArrayIndex >= 0 && selectedArrayIndex < dispIdxList.Count && dispIdxList[selectedArrayIndex] != null)
                                        {
                                            dispIdxList[selectedArrayIndex].Image = m_imgSource_Color;
                                            dispIdxList[selectedArrayIndex].Fit(true);
                                        }
                                    }
                                    else if (m_imgSource_Mono != null && m_imgSource_Mono.Allocated)
                                    {
                                        DispMain.Image = m_imgSource_Mono;
                                        DispMain.Fit(true);
                                        if (dispIdxList != null && selectedArrayIndex >= 0 && selectedArrayIndex < dispIdxList.Count && dispIdxList[selectedArrayIndex] != null)
                                        {
                                            dispIdxList[selectedArrayIndex].Image = m_imgSource_Mono;
                                            dispIdxList[selectedArrayIndex].Fit(true);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                return;
                            }

                            if (sender is UIButton uiButtonSender) uiButtonSender.Text = "Roi";
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        private int GetSelectedGrabIndex()
        {
            List<UIButton> tempList = new List<UIButton> { btnViewGrabIndex1, btnViewGrabIndex2, btnViewGrabIndex3, btnViewGrabIndex4, btnViewGrabIndex5, btnViewGrabIndex6, btnViewGrabIndex7, btnViewGrabIndex8, btnViewGrabIndex9, btnViewGrabIndex10, btnViewGrabIndex11, btnViewGrabIndex12 };
            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i] == null)
                    continue;

                if (tempList[i].Selected) return i + 1;
            }
            return -1;
        }

        private void OnClickGrabIndex(object sender, EventArgs e)
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            try
            {
                UnselectGrabIndex();
                UnselectViewMode();
                btnView_Full.Selected = true;

                int grabIndex = 0;

                if (sender is UIButton)
                {
                    grabIndex = (sender as UIButton).Text.ToInt();
                    if (_imagesGrab[grabIndex - 1] != null)
                    {
                        (sender as UIButton).Selected = true;
                        DispMain.Image = _imagesGrab[grabIndex - 1];
                        DispMain.Fit(false);
                        DispMain.InteractiveGraphics.Clear();
                        DispMain.StaticGraphics.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[[{_thisName}.{MethodName} :: Error]] {ex}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IF_Util.ShowMessageBox("SAVE", $"Do you want to Save?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
            {

                Global.System.Recipe.LibraryManager = m_Job;
                //Equipment Save
                ApplyIQ_HW();
                Global.System.Recipe.GrabManager.SaveConfig();

                Global.System.Recipe.Save_LibraryManager(Global.Instance.System.Recipe.Name);
                Task.Run(() => Global.System.Recipe.SaveCogTools(Global.Instance.System.Recipe.Name));
                InitUI();

                IF_Util.ShowMessageBox("SAVE", $"Finished", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL);

            }
        }

        private void UnselectViewMode()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            try
            {
                btnView_Full.Selected = false;

                btnView_Setting1.Selected = false;
                btnView_Setting2.Selected = false;
                btnView_Setting3.Selected = false;
                btnView_Setting4.Selected = false;

                btnView_Result1.Selected = false;
                btnView_Result2.Selected = false;
                btnView_Result3.Selected = false;
                btnView_Result4.Selected = false;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[[{_thisName}.{MethodName} :: Error]] {ex}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void UnselectGrabIndex()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            try
            {
                btnViewGrabIndex1.Selected = false;
                btnViewGrabIndex2.Selected = false;
                btnViewGrabIndex3.Selected = false;
                btnViewGrabIndex4.Selected = false;
                btnViewGrabIndex5.Selected = false;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[[{_thisName}.{MethodName} :: Error]] {ex}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

    }

    public class cColorResult
    {
        // Image Data
        public Mat imgAll { get; set; } = new Mat();

        public Mat imgBin { get; set; } = new Mat();

        // Recipe Data
        public Scalar scrMin { get; set; } = new Scalar();

        public Scalar scrMax { get; set; } = new Scalar();

        //int nThreshold = 0;
        public int nRangeAreaMax { get; set; } = 0;

        public int nRangeAreaMin { get; set; } = 0;
        public int nThreshold { get; set; } = 0;

        public void InputAreaInfo(int min, int max)
        {
            nRangeAreaMax = max; nRangeAreaMin = min;
        }

        public void InputAreaInfo(int min, int max, int thres)
        {
            nRangeAreaMax = max; nRangeAreaMin = min; nThreshold = thres;
        }

        public void InputColorInfo(Scalar min, Scalar max)
        {
            scrMax = max; scrMin = min;
        }

        public void InputImages(Mat bin, Mat all)
        {
            imgAll = all.Clone(); imgBin = bin.Clone();
        }

        public void SetJob(ref CJob job)
        {
            job.Min2 = (int)scrMin.Val2;
            job.Max2 = (int)scrMax.Val2;
            job.Min1 = (int)scrMin.Val1;
            job.Max1 = (int)scrMax.Val1;
            job.Min0 = (int)scrMin.Val0;
            job.Max0 = (int)scrMax.Val0;
            job.RangeAreaMax = nRangeAreaMax;
            job.RangeAreaMin = nRangeAreaMin;
            job.Threshold = nThreshold;
            job.UseColorRange = true;
        }

        public Mat GetImgFull()
        {
            return imgAll.Clone();
        }

        public Mat GetImgBin()
        {
            return imgBin.Clone();
        }
    }
}
