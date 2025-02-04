using System;
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

using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageProcessing;

using Microsoft.WindowsAPICodePack.Dialogs;

using OpenCvSharp;

using Sunny.UI;


namespace IntelligentFactory
{
    public partial class Form_MenuVision : Form
    {
        Global Global = Global.Instance;
        private string _thisName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

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

        private void BtnGerberLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Global.m_MainPJTRoot;
                ofd.Filter = "Gerber Files(*.xlsx)|*.xlsx";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    TbGerberPath.Text = ofd.FileName;
                    Global.System.Recipe.LoadedGerber = Global.System.Recipe.LibraryManager.LoadGerber(ofd.FileName);
                    DgvGerberInfo.Rows.Clear();
                    List<IF_VisionLogicInfo> library = Global.System.Recipe.LoadedGerber.Library[1];
                    foreach (IF_VisionLogicInfo info in library)
                    {
                        DgvGerberInfo.Rows.Add(new object[] { info.LocationNo, info.PartCode, info.Enabled, $"X: {info.PosX.ToString()}, Y: {info.PosY.ToString()}"});
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
            foreach(IF_VisionLogicInfo info in Global.System.Recipe.LibraryManager.Library[1])
            DgvJobList.Rows.Add(new object[] {info.LocationNo, info.Enabled, info.PartCode});
            //Global.System.Recipe.LibraryManager = Global.System.Recipe.LoadedGerber;
        }

        private void BtnRegionVisible_Click(object sender, EventArgs e)
        {
            DispMain.Image = new CogImage24PlanarColor(IF_Util.Crop(_imagesGrab[0].ToBitmap(), Global.System.Recipe.FiducialLibrary.RegionArray1));
            DispMain.InteractiveGraphics.Clear();
            CogGraphicInteractiveCollection cg = new CogGraphicInteractiveCollection();
            foreach (IF_VisionLogicInfo info in Global.System.Recipe.LoadedGerber.Library[1])
            {
                if (!info.Enabled) continue;
                Rectangle tempRect = new Rectangle(info.PosX - 100/2, info.PosY - 100 / 2, 100, 100);
                CogRectangle rect = CConverter.RectToCogRect(tempRect);
                cg.Add(rect);
            }
            DispMain.InteractiveGraphics.AddList(cg, "GerberROI", true);
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
