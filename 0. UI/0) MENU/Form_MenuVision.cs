using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Text.Json;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageProcessing;
using Microsoft.WindowsAPICodePack.Dialogs;

using OpenCvSharp;
using OpenCvSharp.Extensions;

using Sunny.UI;
using static IntelligentFactory.CJob;
using log4net.Core;
using Cognex.VisionPro.PMAlign;
using System.Windows.Navigation;
using static Sunny.UI.IdentityCard;
using IFOnnxRuntime;
using IFOnnxRuntime.Models;
using log4net.Util;
using IntelligentFactory._0._VISION.Parameter;


namespace IntelligentFactory
{
    public partial class Form_MenuVision : Form
    {
        Global Global = Global.Instance;
        private string _thisName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

        private int m_nSelectedArrayIndex = 1;
        private string m_nSelectedName = "";
        List<CogDisplay> dispIdxList;
        private Bitmap _image = null;

        private LogViewer logViewList = new LogViewer();

        public double Y1, Y2, CenterX, CenterY, OffsetX, OffsetY, ResX, ResY;
        private CogDisplayStatusBarV2 _CogDisplayStatus = new CogDisplayStatusBarV2();

        private int pixelFormatOfImageSource = 0;
        private System.Drawing.Point panStartPoint;
        private double distancePoints = 0;
        OpenCvSharp.Point2d beforePoint1 = new OpenCvSharp.Point2d(0, 0);
        OpenCvSharp.Point2d beforePoint2 = new OpenCvSharp.Point2d(0, 0);
        OpenCvSharp.Point2d currentPoint1 = new OpenCvSharp.Point2d(0, 0);
        OpenCvSharp.Point2d currentPoint2 = new OpenCvSharp.Point2d(0, 0);

        private Cognex.VisionPro.CogImage24PlanarColor[] _imagesGrab = new Cognex.VisionPro.CogImage24PlanarColor[5];

        public Cognex.VisionPro.CogImage8Grey m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey();
        public static Cognex.VisionPro.CogImage24PlanarColor m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor();
        public Cognex.VisionPro.CogImage24PlanarColor m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor();
        public Cognex.VisionPro.CogImage8Grey m_imgSource_Mono_FullBoard = new Cognex.VisionPro.CogImage8Grey();
        public LibraryManager m_Job = null;
        public IF_VisionLogicInfo m_LogicInfo = null;
        public IF_VisionParam_Matching m_Matching = null;
        
        public int m_SelectedLogics = 0;
        public string m_SelectedLocationNo = "";

        public int m_SelectedLogic = 0;
        public string m_SelectedLogicName = "";
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
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
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
            // 화면 디스플레이 처리..
            // 라이브일때만 화면 디스플레이...
            if (Global.Instance.Device.Cameras[0].ImageGrab != null && Global.Device.Cameras[0].IsLive)
            {
                m_imgSource_Color = new CogImage24PlanarColor(Global.Instance.Device.Cameras[0].ImageGrab); //new Cognex.VisionPro.CogImage24PlanarColor((Cognex.VisionPro.CogImage24PlanarColor)CCognexUtil.FlipRotateEx(Global.Instance.Device.Cameras[DEFINE.CAM1].ImageCogGrab, (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam1_ImageProcess.FlipRotate), true));
                m_imgSource_Mono = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor(m_imgSource_Color);
                m_imgSource_Mono_FullBoard = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);

                DispMain.Image = new CogImage24PlanarColor(Global.Instance.Device.Cameras[0].ImageGrab);//Global.Instance.Device.Cameras[0].ImageCogGrab;
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
                List<CheckBox> enableList = new List<CheckBox> { ChkEnable1, ChkEnable2, ChkEnable3, ChkEnable4, ChkEnable5};
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

        }

        Bitmap imageSource = null;

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

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                int imageWidth = 0;
                int imageHeight = 0;
                int imageChannel = 0;

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

                lblImageInfo.Visible = timerCalibration.Enabled;

                if (DispMain.Image != null)
                {
                    lblImageInfo.Text = $"Image Info : {DispMain.Image.Width} * {DispMain.Image.Height} * {pixelFormatOfImageSource} | Distance : {distancePoints.ToString("F2")}px | Zoom : {DispMain.Zoom.ToString("F2")}";
                }
                
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

                            btnViewGrabIndex1.Selected = true;
                            DispMain.Image = _imagesGrab[0];
                            DispMain.Fit();
                            RefreshDispGrabIdx();
                        }
                        break;
                    case "LIVE":
                        {
                            if (checkCameraStatus() == false) return;

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
                                        //if (chkAlignNoUse.Checked == false) _imagesGrab[imageIndex] = CVisionTools.RotateMarkedImage(new CogImage24PlanarColor(imgOrg_Index0), _imagesGrab[imageIndex], _selectedFiducialLibrary);

                                        imageIndex++;
                                    }
                                }
                                m_imgSource_Color = _imagesGrab[0];
                                btnViewGrabIndex1.Selected = true;
                                DispMain.Image = m_imgSource_Color;
                                
                                DispMain.Fit();
                                RefreshDispGrabIdx();

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
                    case "SAVE (1~5)":
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

        //private void OnClickAlgorithm_Pattern(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int idx;

        //        idx = DispMain.InteractiveGraphics.FindItem("Result", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);

        //        if (idx > 0)
        //        {
        //            DispMain.InteractiveGraphics.Remove(idx);
        //        }

        //        DisplayTrainCount();

        //        string strIndex = (sender as UIButton).Text;

        //        CogPMAlignTool PMAlign = null;

        //        if (comboJobPattern_PatternType.Text == "" && comboJobPattern_PatternType.Items.Count > 0) comboJobPattern_PatternType.SelectedIndex = 0;
        //        if (comboJobPattern_PatternType.Text == "Main") PMAlign = m_Matching.ToolMain;
        //        else if (comboJobPattern_PatternType.Text == "Sub1") PMAlign = m_Matching.ToolSub1;
        //        else if (comboJobPattern_PatternType.Text == "Sub2") PMAlign = m_Matching.ToolSub2;
        //        else if (comboJobPattern_PatternType.Text == "Sub3") PMAlign = m_Matching.ToolSub3;
        //        else if (comboJobPattern_PatternType.Text == "Sub4") PMAlign = m_Matching.ToolSub4;
        //        if (PMAlign == null) return;

        //        switch (strIndex)
        //        {
        //            case "ROI":
        //            case "Roi":
        //                {
        //                    DispMain.InteractiveGraphics.Clear();
        //                    DispMain.StaticGraphics.Clear();

        //                    Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();
        //                    if (PMAlign.SearchRegion == null)
        //                    {
        //                        PMAlign.SearchRegion = new Cognex.VisionPro.CogRectangle();
        //                        cogSearchRegion.X = 50;
        //                        cogSearchRegion.Y = 50;
        //                        cogSearchRegion.Width = 300;
        //                        cogSearchRegion.Height = 300;
        //                        PMAlign.SearchRegion.FitToImage(m_imgSource_Mono, 1.0D, 1.0D);
        //                    }
        //                    else
        //                    {
        //                        cogSearchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.SearchRegion;
        //                    }

        //                    //검사 영역
        //                    cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
        //                    cogSearchRegion.Interactive = true;
        //                    cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
        //                    cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
        //                    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
        //                    cogSearchRegion.LineWidthInScreenPixels = 2;

        //                    DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);

        //                    // Train 영역
        //                    Cognex.VisionPro.CogRectangle cogTrainRegion = new Cognex.VisionPro.CogRectangle();

        //                    if (PMAlign.Pattern.TrainRegion != null)
        //                    {
        //                        if (PMAlign.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
        //                        {
        //                            cogTrainRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Pattern.TrainRegion;
        //                        }
        //                        else
        //                        {
        //                            cogTrainRegion.X = 30;
        //                            cogTrainRegion.Y = 30;
        //                            cogTrainRegion.Width = 250;
        //                            cogTrainRegion.Height = 250;
        //                        }

        //                        cogTrainRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
        //                        cogTrainRegion.Interactive = true;
        //                        cogTrainRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Blue;
        //                        cogTrainRegion.DragColor = Cognex.VisionPro.CogColorConstants.Blue;
        //                        cogTrainRegion.Color = Cognex.VisionPro.CogColorConstants.Blue;
        //                        cogTrainRegion.LineWidthInScreenPixels = 2;
        //                    }

        //                    if (cogTrainRegion.Width == 0) cogTrainRegion.Width = 250;
        //                    if (cogTrainRegion.Height == 0) cogTrainRegion.Height = 250;

        //                    DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogTrainRegion, "Pattern", false);

        //                }
        //                break;

        //            case "TRAIN":
        //            case "Train":
        //                {
        //                    //if (m_selectedJob.Type.Contains("Library") == true)
        //                    //{
        //                    //    IF_Util.ShowMessageBox("ERROR", "Library Can't Train");
        //                    //    return;
        //                    //}

        //                    int SelectArrayIndex = m_nSelectedArrayIndex - 1;

        //                    CogRectangle Roi_Search = new CogRectangle();
        //                    CogRectangle Roi_Pattern = new CogRectangle();
        //                    CogRectangle Roi_DeepLearning = new CogRectangle();
        //                    CogRectangle Roi_PatternColor = new CogRectangle();

        //                    idx = DispMain.InteractiveGraphics.FindItem("Search", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
        //                    if (idx > -1)
        //                    {
        //                        Roi_Search = (DispMain.InteractiveGraphics[idx] as CogRectangle);
        //                    }
        //                    idx = DispMain.InteractiveGraphics.FindItem("Pattern", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
        //                    if (idx > -1)
        //                    {
        //                        Roi_Pattern = (DispMain.InteractiveGraphics[idx] as CogRectangle);
        //                    }
        //                    idx = DispMain.InteractiveGraphics.FindItem("DeepLearning", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
        //                    if (idx > -1)
        //                    {
        //                        Roi_DeepLearning = (DispMain.InteractiveGraphics[idx] as CogRectangle);
        //                    }
        //                    idx = DispMain.InteractiveGraphics.FindItem("PatternColor", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
        //                    if (idx > -1)
        //                    {
        //                        Roi_PatternColor = (DispMain.InteractiveGraphics[idx] as CogRectangle);
        //                    }

        //                    Global.System.Recipe.LibraryManager.Library[SelectArrayIndex, ]
        //                    Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SearchRegion = new Rectangle(Convert.ToInt32(Roi_Search.X), Convert.ToInt32(Roi_Search.Y), Convert.ToInt32(Roi_Search.Width), Convert.ToInt32(Roi_Search.Height));

        //                    if (m_selectedJob.CMethod.ToString() == ColorMethod.CA_ConvertGray.ToString() && m_selectedJob.CCoordinate.ToString() == ColorCoordinate.CC_GRAY.ToString())
        //                    {
        //                        PMAlign.Pattern.TrainImage = m_imgSource_Mono;
        //                    }
        //                    else
        //                    {
        //                        // 아래 이미지를 부품만 추릴수 있도록 가공 후 적용한다.
        //                        Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()).Clone();
        //                        Bitmap imgIn = CVisionTools.GetPatterernImage_Train(false, ref m_selectedJob, inImg, Roi_Search, Roi_Pattern, Roi_DeepLearning, Roi_PatternColor);
        //                        m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(imgIn);
        //                        PMAlign.Pattern.TrainImage = m_imgSource_Mono;
        //                    }

        //                    Cognex.VisionPro.CogRectangle CR = new CogRectangle();
        //                    CR.X = Roi_Pattern.X;
        //                    CR.Y = Roi_Pattern.Y;
        //                    CR.Width = Roi_Pattern.Width;
        //                    CR.Height = Roi_Pattern.Height;
        //                    if (comboJobPattern_PatternType.SelectedItem.ToString() == "Main")
        //                    {
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].Tool.Pattern.TrainRegion = CR;
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].Tool.Tool.SearchRegion = Roi_Search;
        //                    }
        //                    else if (comboJobPattern_PatternType.SelectedItem.ToString() == "Sub1")
        //                    {
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool1.Pattern.TrainRegion = CR;
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool1.SearchRegion = Roi_Search;
        //                    }
        //                    else if (comboJobPattern_PatternType.SelectedItem.ToString() == "Sub2")
        //                    {
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool2.Pattern.TrainRegion = CR;
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool2.SearchRegion = Roi_Search;
        //                    }
        //                    else if (comboJobPattern_PatternType.SelectedItem.ToString() == "Sub3")
        //                    {
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool3.Pattern.TrainRegion = CR;
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool3.SearchRegion = Roi_Search;
        //                    }
        //                    else if (comboJobPattern_PatternType.SelectedItem.ToString() == "Sub4")
        //                    {
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool4.Tool.Pattern.TrainRegion = CR;
        //                        Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool4.Tool.SearchRegion = Roi_Search;
        //                    }


        //                    CogRectangle Roi;

        //                    PMAlign.Pattern.Origin.TranslationX = (PMAlign.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterX;
        //                    PMAlign.Pattern.Origin.TranslationY = (PMAlign.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterY;

        //                    try
        //                    {
        //                        PMAlign.Tool.Pattern.Train();
        //                    }
        //                    catch
        //                    {
        //                        IF_Util.ShowMessageBox("Train Error", "Current Image Not Train!! Grab Image Index Change Please!!");
        //                        return;
        //                    }
        //                    if (tcAlgorithm.SelectedTab.Text == "Pattern")
        //                    {
        //                        cogDisplay_JobPattern.InteractiveGraphics.Clear();
        //                        cogDisplay_JobPattern.StaticGraphics.Clear();
        //                        cogDisplay_JobPattern.Image = PMAlign.Tool.Pattern.GetTrainedPatternImage();
        //                        CVisionCognex.TrainGraphic(PMAlign.Tool, cogDisplay_JobPattern);
        //                        cogDisplay_JobPattern.Fit(true);
        //                    }

        //                    DisplayTrainCount();
        //                }
        //                break;

        //            case "RUN":
        //            case "INSP":
        //            case "Find":
        //                {
        //                    Stopwatch tactTime = Stopwatch.StartNew();
        //                    Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();
        //                    bool bol_Result = true;

        //                    DispMain.InteractiveGraphics.Clear();
        //                    DispMain.StaticGraphics.Clear();
        //                    Rectangle PMAlignRect = new Rectangle();
        //                    CogRectangle cogRectangle = new CogRectangle();
        //                    if (tbJobPattern_AcceptScore.Text != "")
        //                        PMAlign.RunParams.AcceptThreshold = double.Parse(tbJobPattern_AcceptScore.Text.ToString());

        //                    // 여기 이미지 전처리 추가
        //                    if ((int)m_selectedJob.CMethod < 0)
        //                        m_selectedJob.CMethod = 0;
        //                    if ((int)m_selectedJob.CCoordinate < 0)
        //                        m_selectedJob.CCoordinate = 0;
        //                    if (m_selectedJob.CMethod.ToString() == ColorMethod.CA_ConvertGray.ToString() && m_selectedJob.CCoordinate.ToString() == ColorCoordinate.CC_GRAY.ToString())
        //                    {
        //                        PMAlign.InputImage = m_imgSource_Mono;
        //                    }
        //                    else
        //                    {
        //                        Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()).Clone();
        //                        Bitmap imgIn = CVisionTools.GetPatterernImage(false, ref m_selectedJob, inImg);
        //                        m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(imgIn);
        //                        Bitmap img = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(inImg);
        //                        DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(img);
        //                        PMAlign.InputImage = m_imgSource_Mono;
        //                    }

        //                    DispMain.StaticGraphics.Add((Cognex.VisionPro.CogRectangle)PMAlign.SearchRegion, "main");

        //                    PMAlign.Run();
        //                    label.Font = new Font("Arial", 14);
        //                    label.LineWidthInScreenPixels = 5;
        //                    for (int i = 0; i < PMAlign.Results.Count; i++)
        //                    {
        //                        label.X = PMAlign.Results[i].GetPose().TranslationX;
        //                        label.Y = PMAlign.Results[i].GetPose().TranslationY - 20;
        //                    }

        //                    string str_Result = "";
        //                    string[] strAry_InspResult;
        //                    string str_InspPartName;
        //                    float str_Score = 0;
        //                    int count = int.Parse(tbPatternMasterCount.Text);
        //                    List<CogPMAlignResult> pMAlignResult = new List<CogPMAlignResult>();

        //                    Inspection_PatternMatching(PMAlign, false, out pMAlignResult);

        //                    int MasterCount = int.Parse(tbPatternMasterCount.Text.ToString());

        //                    if (MasterCount == 1)
        //                    {
        //                        double ResultAcceptedScore = double.Parse(tbJobPattern_MinScore.Text.ToString());
        //                        CogRectangle Roi_Search1 = PMAlign.SearchRegion as CogRectangle;
        //                        label.X = Roi_Search1.X;
        //                        label.Y = Roi_Search1.Y;

        //                        if (pMAlignResult != null)
        //                        {

        //                            label.Text = $"Result Score:{pMAlignResult[0].Score.ToString("F3")} Min Score: {ResultAcceptedScore}";
        //                            lblDetectedPatternCount.Text = $"Count :1";
        //                            if (m_selectedJob.Judge_NaisNg == true)
        //                            {
        //                                if (pMAlignResult[0].Score < ResultAcceptedScore)
        //                                {
        //                                    bol_Result = false;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (pMAlignResult[0].Score > ResultAcceptedScore)
        //                                {
        //                                    bol_Result = false;
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {

        //                            label.Text = $"Count NG Not Find";
        //                            bol_Result = false;
        //                        }

        //                    }
        //                    else
        //                    {
        //                        int ResultAcceptedCount = 0;
        //                        CogRectangle Roi_Search = PMAlign.SearchRegion as CogRectangle;
        //                        label.X = Roi_Search.X;
        //                        label.Y = Roi_Search.Y;

        //                        if (pMAlignResult != null)
        //                        {
        //                            foreach (var item in pMAlignResult)
        //                            {
        //                                if (item.Accepted)
        //                                {
        //                                    ResultAcceptedCount++;
        //                                }
        //                            }
        //                            if (ResultAcceptedCount != MasterCount)
        //                            {
        //                                label.Text = $"Count NG Find:{ResultAcceptedCount}  Master:{MasterCount}";
        //                                bol_Result = false;
        //                            }
        //                            else
        //                            {
        //                                label.Text = $"Count OK Find:{ResultAcceptedCount}  Master:{MasterCount}";
        //                            }
        //                            lblDetectedPatternCount.Text = $"Count :{ResultAcceptedCount}";
        //                        }
        //                        else
        //                        {

        //                            label.Text = $"Count NG Find:{ResultAcceptedCount}  Master:{MasterCount}";
        //                            bol_Result = false;
        //                        }
        //                    }

        //                    if (bol_Result)
        //                    {
        //                        label.Color = CogColorConstants.Green;
        //                        cogRectangle.Color = CogColorConstants.Green;
        //                    }
        //                    else
        //                    {
        //                        label.Color = CogColorConstants.Red;
        //                        cogRectangle.Color = CogColorConstants.Red;
        //                    }

        //                    idx = DispMain.InteractiveGraphics.FindItem("Result", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);

        //                    if (idx > 0)
        //                    {
        //                        DispMain.InteractiveGraphics.Remove(idx);
        //                    }

        //                    DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)label, "Result", false);

        //                    tactTime.Stop();
        //                }
        //                break;

        //            case "CUT ROI":
        //                {
        //                    PMAlign.InputImage = m_imgSource_Mono;
        //                    PMAlign.Run();

        //                    CogPMAlignResult result = null;
        //                    double dMaxScore = 0.0D;
        //                    for (int i = 0; i < PMAlign.Results.Count; i++)
        //                    {
        //                        if (dMaxScore < PMAlign.Results[i].Score)
        //                        {
        //                            dMaxScore = PMAlign.Results[i].Score;
        //                            result = PMAlign.Results[i];
        //                        }
        //                    }

        //                    if (result == null)
        //                    {
        //                        IF_Util.ShowMessageBox("ERROR", "Can't Find the Board Pattern");
        //                        return;
        //                    }

        //                    m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(IF_Util.Crop(m_imgSource_Color.ToBitmap(), new Rectangle((int)result.GetPose().TranslationX, (int)result.GetPose().TranslationY, PMAlign.TrainedPatternImage.Width, PMAlign.TrainedPatternImage.Height)));
        //                    DispMain.Image = m_imgSource_Color;
        //                    DispMain.Fit(true);
        //                }
        //                break;

        //            case "MASK":
        //            case "Mask":
        //                {
        //                    FormPopUp_Settings_Masking Frm = new FormPopUp_Settings_Masking(m_selectedJob, m_imgSource_Mono);
        //                    Frm.ShowDialog();

        //                    cogDisplay_JobPattern.InteractiveGraphics.Clear();
        //                    cogDisplay_JobPattern.StaticGraphics.Clear();

        //                    CVisionCognex.TrainGraphic(m_selectedJob.Tool, cogDisplay_JobPattern);

        //                    cogDisplay_JobPattern.Image = m_selectedJob.Tool.Pattern.GetTrainedPatternImage();
        //                    cogDisplay_JobPattern.Fit(false);
        //                }
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
        //    }
        //}

        public void DisplayTrainCount()
        {
            // Train 숫자를 표시한다.
            int nTrain = 0;
            if (m_Matching.ToolMain.Pattern.Trained)
                nTrain++;
            if (m_Matching.ToolSub1.Pattern.Trained)
                nTrain++;
            if (m_Matching.ToolSub2.Pattern.Trained)
                nTrain++;
            if (m_Matching.ToolSub3.Pattern.Trained)
                nTrain++;
            if (m_Matching.ToolSub4.Pattern.Trained)
                nTrain++;
            label137.Text = $"({nTrain:D2}/05)";
        }

        #region [Calibration Part]
        private string iqResultRootPath = @"C:\Test"; // 폴더까지만
        private ConcurrentQueue<IQResultData> iqResultDatas = new ConcurrentQueue<IQResultData>();
        private bool IsLive = false;
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

        /// <summary>
        /// 캘리브레이션 시작
        /// </summary>
        /// <param name="IsContinuous"> 반복 유무 </param>
        private void IQStart(bool IsContinuous)
        {
            // 반복 캘리브레이션
            if (IsContinuous == true)
            {
                if (Global.Instance.Device.Cameras.Count > 0 && Global.Instance.Device.Cameras[0].ImageGrab != null && Global.Device.Cameras[0].IsLive)
                {
                    CogRectangle guideLine = GetCalibrationROI();
                    DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)guideLine, "Guide Line", false);
                    IsLive = true;

                    while (IsLive)
                    {
                        Calibration(true);

                        Task.Delay(200);
                    }
                }
                else
                {
                    MessageBox.Show($"카메라가 Live 상태가 아닙니다.", "카메라 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 1회 캘리브레이션
            else
            {
                Calibration(false);
                IQResultSave(iqResultDatas, iqResultRootPath);
            }
        }

        /// <summary>
        /// 캘리브레이션 반복 기능 종료
        /// </summary>
        private void IQStop()
        {
            DispMain.InteractiveGraphics.Clear();
            IsLive = false;
            IQResultSave(iqResultDatas, iqResultRootPath);
        }

        /// <summary>
        /// 캘리브레이션 데이터 저장
        /// </summary>
        private void IQResultSave(ConcurrentQueue<IQResultData> queue, string rootPath)
        {
            while (queue.TryDequeue(out IQResultData data))
            {
                string filePath = GetIQSavePath();

                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    string jsonLine = JsonSerializer.Serialize(data);
                    writer.WriteLine(jsonLine);
                }
            }

            // 저장 데이터 형태
            // {"Time":"2025-02-05T12:34:56","FocusValue":0.85,"UniformityValues":[{"X":10.5,"Y":20.3,"Value":0.75}]}
            // {"Time":"2025-02-05T13:00:12","FocusValue":0.90,"UniformityValues":[{ "X":7.2,"Y":12.9,"Value":0.89}]}
            // {"Time":"11:43:56","FocusValue":24.076000000000001,"UniformityValues":[{"X":0,"Y":0,"Value":81.790000000000006},{"X":1,"Y":0,"Value":83.409999999999997},{"X":2,"Y":0,"Value":77.739999999999995},{"X":0,"Y":1,"Value":91.280000000000001},{"X":1,"Y":1,"Value":93.200000000000003},{"X":2,"Y":1,"Value":88.569999999999993},{"X":0,"Y":2,"Value":84.260000000000005},{"X":1,"Y":2,"Value":87.680000000000007},{"X":2,"Y":2,"Value":80.930000000000007}]}
        }

        public string GetIQSavePath()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString("D2");
            string day = DateTime.Now.Day.ToString("D2");

            string directoryPath = Path.Combine(iqResultRootPath, "IQResultData");  // 기본 폴더
            Directory.CreateDirectory(directoryPath);  // 폴더가 없으면 자동 생성

            string fileName = $"{year}-{month}-{day}.jsonl";  // 파일 이름
            return Path.Combine(directoryPath, fileName);
        }

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

                if (Global.Instance.Device.Cameras[0].ImageGrab != null && Global.Device.Cameras[0].IsLive)
                {
                    //src = new CogImage24PlanarColor(Global.Instance.Device.Cameras[0].ImageGrab);

                    /*CogImage24PlanarColor cogImage = new CogImage24PlanarColor(Global.Instance.Device.Cameras[0].ImageGrab);
                    src = BitmapConverter.ToMat(cogImage.ToBitmap());*/

                    src = BitmapConverter.ToMat(Global.Instance.Device.Cameras[0].ImageGrab);
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
                src = BitmapConverter.ToMat(((CogImage24PlanarColor)DispMain.Image).ToBitmap());
            }

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
            lbCurrentFocusValue.Text = $"Current Focus Value : {currentFocusValue}";

            // - Best Focus 값 출력
            double bestFocusValue = double.Parse(lbBestFocusValue.Text.Replace("Best Focus Value : ", ""));
            if (currentFocusValue > bestFocusValue)
                lbBestFocusValue.Text = $"Best Focus Value : {currentFocusValue}";

            // 3. Uniformity 계산
            int divisions = 3; // 2로 변경하면 4등분, 3이면 9등분
            int width = src.Cols;
            int height = src.Rows;
            int cellWidth = width / divisions;
            int cellHeight = height / divisions;
            List<UniformityValue> uniformityValues = new List<UniformityValue>();


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
                    label.Color = CogColorConstants.White;
                    label.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    DispMain.InteractiveGraphics.Add(label, $"Label{col + row * divisions}", false);

                    UniformityValue uniformityValue = new UniformityValue(col, row, value);
                    uniformityValues.Add(uniformityValue);
                }
            }

            IQResultData resultData = new IQResultData(currentFocusValue, uniformityValues);
            iqResultDatas.Enqueue(resultData);
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
            public string Time { get; set; }
            public double FocusValue { get; set; }
            public List<UniformityValue> UniformityValues { get; set; }

            public IQResultData(double focusValue, List<UniformityValue> uniformityValues)
            {
                this.Time = DateTime.Now.ToString("hh:mm:ss");
                this.FocusValue = focusValue;
                this.UniformityValues = uniformityValues;
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
        #endregion

        private void BtnGerberLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Global.m_MainPJTRoot;
                ofd.Filter = "Gerber Files(*.xlsx)|*.xlsx";

                //if (ofd.ShowDialog() == DialogResult.OK)
                //{
                //    TbGerberPath.Text = ofd.FileName;
                //    Global.System.Recipe.LoadedGerber = Global.System.Recipe.LibraryManager.LoadGerber(ofd.FileName);
                //    DgvGerberInfo.Rows.Clear();
                //    Dictionary<string, IF_VisionLogicInfo> library = Global.System.Recipe.LoadedGerber.Library[1];
                //    foreach (KeyValuePair<string, IF_VisionLogicInfo> infoKvp in library)
                //    {
                //        string locationNo = infoKvp.Key;
                //        IF_VisionLogicInfo info = infoKvp.Value;
                //        DgvGerberInfo.Rows.Add(new object[] { locationNo, info.PartCode, info.Enabled, $"X: {info.PosX.ToString()}, Y: {info.PosY.ToString()}"});
                //    }
                //}
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    TbGerberPath.Text = ofd.FileName;
                    Global.System.Recipe.LoadedGerber = Global.System.Recipe.LibraryManager.LoadGerber(ofd.FileName);
                    DgvGerberInfo.Rows.Clear();
                    List<IF_VisionLogicInfo> library = Global.System.Recipe.LoadedGerber.Library[1];
                    foreach (IF_VisionLogicInfo info in library)
                    {
                        DgvGerberInfo.Rows.Add(new object[] { info.LocationNo, info.PartCode, info.Enabled, $"X: {info.PosX.ToString()}, Y: {info.PosY.ToString()}" });
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
            if (DispMain == null) return;
            Global.System.Recipe.LibraryManager.Library = new System.Collections.Concurrent.ConcurrentDictionary<int, List<IF_VisionLogicInfo>>();
            Global.System.Recipe.LibraryManager.Library[1] = Global.System.Recipe.LoadedGerber.Library[1];

            DgvJobList.Rows.Clear();
            foreach (IF_VisionLogicInfo info in Global.System.Recipe.LibraryManager.Library[1])
                DgvJobList.Rows.Add(new object[] { info.LocationNo, info.Enabled, info.PartCode });
            //if (DispMain == null) return;
            //Global.System.Recipe.LibraryManager.Library = new System.Collections.Concurrent.ConcurrentDictionary<int, Dictionary<string, IF_VisionLogicInfo>>();
            //Global.System.Recipe.LibraryManager.Library[1] = Global.System.Recipe.LoadedGerber.Library[1];

            //DgvJobList.Rows.Clear();
            //foreach(KeyValuePair<string, IF_VisionLogicInfo> infoKvp in Global.System.Recipe.LibraryManager.Library[1])
            //{
            //    string locationNo = infoKvp.Key;
            //    IF_VisionLogicInfo info = infoKvp.Value;
            //    DgvJobList.Rows.Add(new object[] {locationNo, info.Enabled, info.PartCode});
            //}
            //Global.System.Recipe.LibraryManager = Global.System.Recipe.LoadedGerber;
        }

        private void BtnRegionVisible_Click(object sender, EventArgs e)
        {
            DispMain.Image = new CogImage24PlanarColor(IF_Util.Crop(_imagesGrab[0].ToBitmap(), Global.System.Recipe.FiducialLibrary.RegionArray1));
            DispMain.InteractiveGraphics.Clear();
            CogGraphicInteractiveCollection cg = new CogGraphicInteractiveCollection();
            //foreach (KeyValuePair<string, IF_VisionLogicInfo> infoKvp in Global.System.Recipe.LoadedGerber.Library[1])
            //{
            //    IF_VisionLogicInfo info = infoKvp.Value;
            //    if (!info.Enabled) continue;
            //    Rectangle tempRect = new Rectangle(info.PosX - 100/2, info.PosY - 100 / 2, 100, 100);
            //    CogRectangle rect = CConverter.RectToCogRect(tempRect);
            //    cg.Add(rect);
            //}
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
                    m_SelectedLogics = DgvJobList.SelectedRows[0].Index;
                    m_SelectedLocationNo = DgvJobList[0, m_SelectedLogics].Value.ToString();

                    DgvLogicList.Rows.Clear();
                    int idx = 0;
                    foreach (IF_VisionLogicInfo info in Global.System.Recipe.LibraryManager.Library[m_nSelectedArrayIndex])
                    {
                        if (info.LocationNo == m_SelectedLocationNo)
                        {
                            if (info.Logics.Count > 0)
                            {
                                DgvLogicList.Rows.Add(new object[] { idx.ToString(), info.Logics[idx].Enabled, info.Logics[idx].Name, info.Logics[idx].Type });
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
                    string locationNo = m_SelectedLocationNo;

                    TrvLogic.Nodes.Clear();
                    int idx = 0;
                    foreach (IF_VisionLogicInfo info in Global.System.Recipe.LibraryManager.Library[m_nSelectedArrayIndex])
                    {
                        if (info.LocationNo == locationNo)
                        {
                            if (info.Logics.Count > 0)
                            {
                               
                                IF_VisionParamObject logic = info.Logics[m_SelectedLogic];

                                TreeNode prNode_PreImage = new TreeNode("PreImage");
                                TreeNode prNode_Core = new TreeNode("Core");

                                if (logic.UseImageProcessing)
                                {
                                    for (int i = 0; logic.ImgProcessingList.Count > 0; i++)
                                    {
                                        prNode_PreImage.Nodes.Add(new TreeNode($"Processing no.{logic.ImgProcessingList[i]}"));
                                    }
                                }
                                prNode_Core.Nodes.Add(new TreeNode($"{logic.Type}"));
                                TrvLogic.Nodes.Add(prNode_PreImage);
                                TrvLogic.Nodes.Add(prNode_Core);
                                
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

        private void btnJobPattern_Roi_Click(object sender, EventArgs e)
        {

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

        private void BtnSettingLogic_Click(object sender, EventArgs e)
        {
            try
            {
                int RowIndex = DgvLogicList.SelectedRows[0].Index;
                string LogicName = "";
                string LogicAlgorithm = "Pattern";
                int idx = 0;
                if (cbAlgorithm.SelectedIndex == 0) LogicAlgorithm = "Pattern";
                else if (cbAlgorithm.SelectedIndex == 1) LogicAlgorithm = "Blob";
                else if (cbAlgorithm.SelectedIndex == 2) { LogicAlgorithm = "Distance"; }
                else if (cbAlgorithm.SelectedIndex == 3) { LogicAlgorithm = "EYED"; }
                else if (cbAlgorithm.SelectedIndex == 4) { LogicAlgorithm = "Color"; }
                else if (cbAlgorithm.SelectedIndex == 5) { LogicAlgorithm = "ColorEx"; }
                else if (cbAlgorithm.SelectedIndex == 6) { LogicAlgorithm = "Condensor"; }
                else if (cbAlgorithm.SelectedIndex == 7) { LogicAlgorithm = "Connector"; }
                else if (cbAlgorithm.SelectedIndex == 8) { LogicAlgorithm = "Pin"; }
                LogicName = tbLogicName.Text;
                foreach (IF_VisionLogicInfo info in Global.System.Recipe.LibraryManager.Library[m_nSelectedArrayIndex])
                {
                    if (idx == m_SelectedLogics)
                    {
                        DgvLogicList.Rows[m_SelectedLogic].Cells[2].Value = LogicName;
                        DgvLogicList.Rows[m_SelectedLogic].Cells[3].Value = LogicAlgorithm;
                        info.Logics[m_SelectedLogic].Name = LogicName;
                        info.Logics[m_SelectedLogic].Type = LogicAlgorithm;
                    }
                    idx++;
                }
                UpdateVisionLogicInfo(m_nSelectedArrayIndex, m_SelectedLocationNo, logic =>
                {
                    logic.Logics[m_SelectedLogic].Name = LogicName;
                    logic.Logics[m_SelectedLogic].Type = LogicAlgorithm;
                });


            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        public bool UpdateVisionLogicInfo(int key, string locationNo, Action<IF_VisionLogicInfo> updateAction)
        {
            if (Global.System.Recipe.LibraryManager.Library.TryGetValue(key, out List<IF_VisionLogicInfo> logicList))
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
                string LogicName = "NewLogic";
                string LogicAlgorithm = "Pattern";
                bool LogicEnable = true;
                int idx = 0;
                IF_VisionParamObject Logic = new IF_VisionParam_Matching();
                foreach (IF_VisionLogicInfo info in Global.System.Recipe.LibraryManager.Library[m_nSelectedArrayIndex])
                {
                    if (idx == m_SelectedLogics)
                    {
                        int LastRawindex = info.Logics.Count;
                        Logic.Enabled = LogicEnable;
                        Logic.Name = LogicName;
                        Logic.Type = LogicAlgorithm;
                        info.Logics.Add(Logic);
                        DgvLogicList.Rows.Add(LastRawindex+1, info.Logics[LastRawindex].Enabled, info.Logics[LastRawindex].Name, info.Logics[LastRawindex].Type);
                    }
                    idx++;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);

                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void BtnOpenOnnx_Click(object sender, EventArgs e)
        {
            //string logicName = DgvLogicList.SelectedRows[0].Cells[2].Value.ToString();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Image Load";
            ofd.Filter = "Image File (*.png, *.jpg, *.gif, *.bmp) | *.png; *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TbOnnxPath.Text = ofd.FileName;
                //OnnxInfo onnxInfo = new OnnxInfo()
                //{
                //    Device = "CPU",
                //    NmsThreshold = 0.5F,
                //    OnnxName = logicName,
                //    OnnxPath = ofd.FileName
                //    // IF_VisionParam_EYED에 OnnxInfo를 넣을지 고민해야 됨.
                //};
                //Global.eyeD.AddModel(onnxInfo);
            }
        }

        private void BtnApplyCore_Click(object sender, EventArgs e)
        {
            string newLogic = TabMenuLogic.SelectedTab.Text;
            string logicName = DgvLogicList.SelectedRows[0].Cells[2].Value.ToString();
            string algorithm = DgvLogicList.SelectedRows[0].Cells[3].Value.ToString();

            //EYED에서 다른거로 바꿀 때 Global.eyeD.RemoveModel 메서드를 반드시 호출해야 함.
            if (algorithm == "EYED")
            {
                if (Global.eyeD.Models.ContainsKey(logicName)) Global.eyeD.RemoveModel(logicName);
            }
            IF_VisionLogicInfo logicInfo = Global.System.Recipe.LibraryManager.Library[m_nSelectedArrayIndex].Where(v => v.LocationNo == DgvJobList.SelectedRows[0].Cells[0].Value.ToString()).ToList()[0];
            int selectedLogicIndex = (int)DgvLogicList.SelectedRows[0].Cells[0].Value - 1;
            switch (newLogic)
            {
                case "EYE-D":
                    logicInfo.Logics[selectedLogicIndex] = null;
                    // TODO : new할 때 기존의 IF_VisionParam_Object의 값을 이어받을 수 있어야 함.
                    logicInfo.Logics[selectedLogicIndex] = new IF_VisionParam_EYED()
                    {
                        ModelPath = TbOnnxPath.Text,
                        Threshold = double.Parse(TbThresholdEYED.Text),
                        RotateDgree = (int)CbRotateImageEYED.SelectedItem,
                    };
                    break;
                default:
                    break;
            }
        }

        private void OnClickViewMode(object sender, EventArgs e)
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");
            if (DispMain.Image == null) return;

            try
            {
                UnselectViewMode();

                string viewType = "";
                string viewIndex = "";
                int selectedGrabIndex = GetSelectedGrabIndex();

                if (sender is UISymbolButton)
                {
                    viewType = (sender as UISymbolButton).Tag.ToString().ToUpper();
                    //viewIndex = (sender as UISymbolButton).Text.ToString().ToUpper();

                    (sender as UISymbolButton).Selected = true;
                }
                else if (sender is UIButton)
                {
                    viewType = (sender as UIButton).Tag.ToString().ToUpper();
                    viewIndex = (sender as UIButton).Text.ToString().ToUpper();

                    (sender as UIButton).Selected = true;
                }

                switch (viewType)
                {
                    case "SETTING":
                        {
                            DispMain.Image = new CogImage24PlanarColor(IF_Util.Crop(_imagesGrab[selectedGrabIndex - 1].ToBitmap(), Global.System.Recipe.FiducialLibrary.RegionArray1));
                        }
                        break;
                    case "RESULT":
                        {

                        }
                        break;
                    case "FULL":
                        {
                            DispMain.Image = _imagesGrab[selectedGrabIndex - 1];
                            DispMain.Fit();
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

        private int GetSelectedGrabIndex()
        {
            List<UIButton> tempList = new List<UIButton> { btnViewGrabIndex1, btnViewGrabIndex2, btnViewGrabIndex3, btnViewGrabIndex4, btnViewGrabIndex5 };
            for (int i = 0; i < tempList.Count; i++)
            {
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
            //Global.Setting.Save(Global.Setting.RecipeName);
            ApplyIQ_HW();
            Global.System.Recipe.GrabManager.SaveConfig();
            Global.System.Recipe.LibraryManager.Save("TEST");
            foreach (IF_VisionLogicInfo info in Global.System.Recipe.LibraryManager.Library[m_nSelectedArrayIndex])
            {
                if (info.Logics.Count > 0)
                {
                    for (int i = 0; i < info.Logics.Count; i++)
                    {
                        if (info.Logics[i].Name == Name)
                        {
                            switch (info.Logics[i].Type)
                            {
                                case "Pattern":
                                    {
                                        foreach (IF_VisionParam_Matching matchinginfo in info.Logics.OfType<IF_VisionParam_Matching>())
                                        {
                                             CCognexUtil.SaveCogTool(matchinginfo.ToolMain_Path, matchinginfo.ToolMain);
                                             CCognexUtil.SaveCogTool(matchinginfo.ToolSub1_Path, matchinginfo.ToolSub1);
                                             CCognexUtil.SaveCogTool(matchinginfo.ToolSub2_Path, matchinginfo.ToolSub2);
                                             CCognexUtil.SaveCogTool(matchinginfo.ToolSub3_Path, matchinginfo.ToolSub3);
                                             CCognexUtil.SaveCogTool(matchinginfo.ToolSub4_Path, matchinginfo.ToolSub4);
                                        }

                                        break;
                                    }

                            }

                        }
                    }
                }
            }
            InitUI();
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
        private List<string> CogToolPath(string locationNo, string Name)
        {
            List<string> Matching_path = new List<string>();
            string strType = "";
            foreach (IF_VisionLogicInfo info in Global.System.Recipe.LibraryManager.Library[m_nSelectedArrayIndex])
            {
                if (info.LocationNo == locationNo)
                {
                    if (info.Logics.Count > 0)
                    {
                        for (int i = 0; i < info.Logics.Count; i++)
                        {
                            if (info.Logics[i].Name == Name)
                            {
                                switch (info.Logics[i].Type)
                                {
                                    case "Pattern":
                                        {
                                            foreach (IF_VisionParam_Matching matchinginfo in info.Logics.OfType<IF_VisionParam_Matching>())
                                            {
                                                Matching_path.Add(matchinginfo.ToolMain_Path);
                                                Matching_path.Add(matchinginfo.ToolSub1_Path);
                                                Matching_path.Add(matchinginfo.ToolSub2_Path);
                                                Matching_path.Add(matchinginfo.ToolSub3_Path);
                                                Matching_path.Add(matchinginfo.ToolSub4_Path);
                                            }
                                             strType = info.Logics[i].Type;

                                            break;
                                        }

                                }

                            }
                        }

                    }
                }
            }
            if (strType == "Pattern")
            {
                return Matching_path;
            }
            else
            {
                return null;
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
