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
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.Display;

using IntelligentFactory;
using OpenCvSharp;

using Sunny.UI;


namespace IF
{
    public partial class Form_MenuVision : Form
    {
        Global Global = Global.Instance;
        private string _thisName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

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

        public Form_MenuVision()
        {
            InitializeComponent();

            logViewList.Dock = DockStyle.Fill;
            logViewList.Visible = true;

            _CogDisplayStatus.Display = DisplayMain;
            _CogDisplayStatus.CoordinateSpaceName = "*\\#";
            _CogDisplayStatus.Dock = DockStyle.Fill;
            _CogDisplayStatus.ForeColor = Color.White;
            pnlDisplayStatus.Controls.Add(_CogDisplayStatus);


            Global.SeqInitialize.EventInitEnd += OnInitEnd;
        }
        private void Form_MenuVision_Load(object sender, EventArgs e)
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            try
            {
                InitEvent();
                InitComponents();
                InitUI();
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
            if (DisplayMain.Image != null)
            {
                DisplayMain.InteractiveGraphics.Clear();
                DisplayMain.StaticGraphics.Clear();
                DisplayMain.Refresh();
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
                            if (IF_System.Mode != IF_System.MODE.AUTO)
                            {
                            }
                        }
                        break;
                    case "OVERLAY CLEAR":
                        {
                            OverlayClear();
                        }
                        break;
                    case "LOAD":
                        {
                            if (DisplayMain.Image == null)
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

                                if (DisplayMain.Image != null)
                                {
                                    (DisplayMain.Image as CogImage8Grey)?.Dispose();
                                    (DisplayMain.Image as CogImage24PlanarColor)?.Dispose();
                                    DisplayMain.Image = null;
                                    GC.Collect();
                                }

                                imageSource = new Bitmap(ofd.FileName);

                                if (imageSource.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                                {
                                    DisplayMain.Image = new CogImage8Grey(imageSource);
                                    pixelFormatOfImageSource = 8;
                                }
                                else
                                {
                                    DisplayMain.Image = new CogImage24PlanarColor(imageSource);
                                    pixelFormatOfImageSource = 24;
                                }
                                DisplayMain.Fit(true);
                            }
                        }
                        break;
                    case "SAVE":
                        {
                            if (DisplayMain.Image != null)
                            {
                                SaveFileDialog sfd = new SaveFileDialog();
                                sfd.Title = "Image Save";
                                sfd.Filter = "Image File (*.png, *.jpg, *.gif, *.bmp) | *.png; *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    DisplayMain.Image.ToBitmap().Save(sfd.FileName);
                                }
                            }
                        }
                        break;
                    case "SEARCH ROI":
                        {
                            if (DisplayMain.Image != null)
                            {
                                DisplayMain.InteractiveGraphics.Clear();
                                DisplayMain.StaticGraphics.Clear();

                                DisplayMain.Fit();

                                CogRectangle cogSearchRegion = new CogRectangle();

                                cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                                cogSearchRegion.Interactive = true;
                                cogSearchRegion.Color = CogColorConstants.Red;
                                cogSearchRegion.SelectedColor = CogColorConstants.Red;

                                DisplayMain.InteractiveGraphics.Add(cogSearchRegion, "SearchROI", false);
                            }
                        }
                        break;
                    case "MEASURE":
                        {
                            if (DisplayMain.Image != null)
                            {
                                CogPointMarker pos1 = new CogPointMarker();
                                pos1.Color = CogColorConstants.Red;
                                pos1.Interactive = true;
                                pos1.GraphicDOFEnable = CogPointMarkerDOFConstants.All;

                                CogPointMarker pos2 = new CogPointMarker();
                                pos2.Color = CogColorConstants.Orange;
                                pos2.Interactive = true;
                                pos2.GraphicDOFEnable = CogPointMarkerDOFConstants.All;

                                DisplayMain.InteractiveGraphics.Add(pos1, "Point1", false);
                                DisplayMain.InteractiveGraphics.Add(pos2, "Point2", false);

                                timerCalibration.Enabled = true;
                            }
                        }
                        break;
                    case "POINT":
                        {
                            btn_CogDisplay_Pan.Selected = false;
                            btn_CogDisplay_Point.Selected = true;
                            var v = DisplayMain.ContextMenuStrip.Items[0];
                            v.PerformClick();
                        }
                        break;
                    case "PAN":
                        {
                            btn_CogDisplay_Point.Selected = false;
                            btn_CogDisplay_Pan.Selected = true;
                            var v = DisplayMain.ContextMenuStrip.Items[1];
                            v.PerformClick();
                        }
                        break;
                    case "ZOOMIN":
                        {
                            if (DisplayMain.Image != null)
                                DisplayMain.Zoom *= 1.2;
                        }
                        break;
                    case "ZOOMOUT":
                        {
                            if (DisplayMain.Image != null)
                                DisplayMain.Zoom /= 1.2;
                        }
                        break;
                    case "ZOOMFIT":
                        {
                            if (DisplayMain.Image != null)
                                DisplayMain.Fit(true);
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

                if (DisplayMain.Image != null)
                {
                    lblImageInfo.Text = $"Image Info : {DisplayMain.Image.Width} * {DisplayMain.Image.Height} * {pixelFormatOfImageSource} | Distance : {distancePoints.ToString("F2")}px | Zoom : {DisplayMain.Zoom.ToString("F2")}";
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

        private void timerCalibration_Tick(object sender, EventArgs e)
        {
            try
            {
                if (DisplayMain.Image != null)
                {
                    if (DisplayMain.InteractiveGraphics.Count > 0)
                    {
                        int pos1Idx = DisplayMain.InteractiveGraphics.FindItem("Point1", CogDisplayZOrderConstants.Back);
                        int pos2Idx = DisplayMain.InteractiveGraphics.FindItem("Point2", CogDisplayZOrderConstants.Back);

                        if (pos1Idx >= 0 && pos2Idx >= 0)
                        {
                            CogPointMarker POS1 = (DisplayMain.InteractiveGraphics[pos1Idx] as CogPointMarker);
                            CogPointMarker POS2 = (DisplayMain.InteractiveGraphics[pos2Idx] as CogPointMarker);

                            currentPoint1 = new OpenCvSharp.Point2d(POS1.X, POS1.Y);
                            currentPoint2 = new OpenCvSharp.Point2d(POS2.X, POS2.Y);

                            distancePoints = currentPoint1.DistanceTo(currentPoint2);

                            CogLineSegment measuredLine = new CogLineSegment();
                            measuredLine.StartX = currentPoint1.X;
                            measuredLine.StartY = currentPoint1.Y;
                            measuredLine.EndX = currentPoint2.X;
                            measuredLine.EndY = currentPoint2.Y;

                            DisplayMain.StaticGraphics.Add(measuredLine, "MeasLine");

                            if (beforePoint1.X != currentPoint1.X
                               || beforePoint1.Y != currentPoint1.Y
                               || beforePoint2.X != currentPoint2.X
                               || beforePoint2.Y != currentPoint2.Y
                               )
                            {
                                DisplayMain.StaticGraphics.Remove("MeasLine");
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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void OnClickViewMode(object sender, EventArgs e)
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            try
            {
                UnselectViewMode();

                string viewType = "";
                string viewIndex = "";

                
                if (sender is UISymbolButton)
                {   
                    viewIndex = (sender as UISymbolButton).Text.ToString().ToUpper();

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

                        }
                        break;
                    case "RESULT":
                        {

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

        private void OnClickGrabIndex(object sender, EventArgs e)            
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            try
            {
                UnselectGrabIndex();

                string viewIndex = "";

                if (sender is UIButton)
                {   
                    viewIndex = (sender as UIButton).Text.ToString().ToUpper();

                    (sender as UIButton).Selected = true;
                }

                switch (viewIndex)
                {
                    case "SETTING":
                        {

                        }
                        break;
                    case "RESULT":
                        {

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


        private void btnSave_Click(object sender, EventArgs e)
        {
            Global.Setting.Save(Global.Setting.RecipeName);
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
}
