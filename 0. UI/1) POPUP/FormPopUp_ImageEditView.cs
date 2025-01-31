﻿using MetroFramework.Forms;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_ImageEditView : MetroForm
    {
        private CPropertyImageView PropertyImageView = new CPropertyImageView("IMAGE_VIEW");

        private Mat ImageSource = new Mat();
        //private Mat ImageDisplay = new Mat();

        public Mat ImageProcess = new Mat();

        private Bitmap ImageGrey = new Bitmap(10, 10);

        //private Rectangle m_ROI;

        //private System.Drawing.Point m_ptStart = new System.Drawing.Point(0, 0);
        //private System.Drawing.Point m_ptEnd = new System.Drawing.Point(0, 0);

        //private EventHandler<EventArgs> EventSetRoi;
        //private EventHandler<EventArgs> EventSetCut;

        //private bool m_bIsAutoUpdate = false;

        public float m_fImageScale { get; set; } = 1;
        public float m_fImgW { get; set; } = 0;
        public float m_fImgH { get; set; } = 0;

        public float m_dPenX { get; set; } = 0;
        public float m_dPenY { get; set; } = 0;

        public float m_fMinX { get; private set; } = 1;
        public float m_fMinY { get; private set; } = 1;

        public float m_fMaxX { get; private set; } = 0;
        public float m_fMaxY { get; private set; } = 0;

        public Rect SelectedRegion = new Rect();

        public FormPopUp_ImageEditView(Mat image, string strMode = "")
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(MouseWheelEvent);

            ibSource.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);

            m_fMaxX = m_fImgW = ImageSource.Width;
            m_fMaxY = m_fImgH = ImageSource.Height;

            ImageSource = image.Clone();

            if (strMode != "") btnOK.Text = strMode;
        }

        public FormPopUp_ImageEditView(Bitmap image, string strMode = "")
        {
            InitializeComponent();

            try
            {
                this.MouseWheel += new MouseEventHandler(MouseWheelEvent);

                ImageGrey = (Bitmap)image.Clone();

                ibSource.Image = image;

                m_fMaxX = m_fImgW = ImageSource.Width;
                m_fMaxY = m_fImgH = ImageSource.Height;

                this.KeyPreview = true;

                propertygrid_Parameter.SelectedObject = PropertyImageView;

                if (strMode != "") btnOK.Text = strMode;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                this.Close();
            }
        }

        public FormPopUp_ImageEditView(Bitmap image, Double dDistance)
        {
            InitializeComponent();

            try
            {
                this.MouseWheel += new MouseEventHandler(MouseWheelEvent);

                ImageGrey = (Bitmap)image.Clone();

                ibSource.Image = image;

                m_fMaxX = m_fImgW = ImageSource.Width;
                m_fMaxY = m_fImgH = ImageSource.Height;

                this.KeyPreview = true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                this.Close();
            }
        }

        /// <summary>
        /// EventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if ((e.Delta / 120) > 0)
            {
                // up
                if (m_fImageScale > 1)
                    m_fImageScale--;

                ZoomInImage();
            }
            else
            {
                // down
                m_fImageScale++;

                ZoomOutImage();
            }
        }

        private void pblSource_DragDrop(object sender, DragEventArgs e)
        {
            //m_OriginalImg =

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        }

        private void pblSource_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        #region Display

        private void ZoomInImage()
        {
            ibSource.ZoomIn();
        }

        private void ZoomOutImage()
        {
            ibSource.ZoomOut();
        }

        private void ZoomFitImage()
        {
            ibSource.ZoomToFit();
        }

        private void FormImageView_FormClosing(object sender, FormClosingEventArgs e)
        {
            ImageSource.Dispose();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOutImage();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomInImage();
        }

        private void btnFit_Click(object sender, EventArgs e)
        {
            ZoomFitImage();
        }

        #endregion Display

        private System.Drawing.Point GreyPoint = new System.Drawing.Point();

        private void ibSource_MouseMove(object sender, MouseEventArgs e)
        {
            GreyPoint = UpdateCursorPosition(e.Location);
            lbPosition.Text = $"{GreyPoint.X},{GreyPoint.Y}";

            int nGreyValue = 0;

            if (GreyPoint.X + 10 < ImageGrey.Width && GreyPoint.Y + 10 < ImageGrey.Height)
            {
                if (GreyPoint.X > 0 && GreyPoint.Y > 0)
                {
                    Color color = ImageGrey.GetPixel(GreyPoint.X, GreyPoint.Y);
                    nGreyValue = (color.R + color.G + color.B) / 3;
                    lbGV.Text = string.Format("{0}", nGreyValue.ToString());
                }
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Escape)
            {
                // CLogger.WriteLog(LOG.NORMAL, "[OK] {0}==>{1}   Action ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private System.Drawing.Point UpdateCursorPosition(System.Drawing.Point location)
        {
            return ibSource.PointToImage(location);
        }

        private void btnSelectionMode_Click(object sender, EventArgs e)
        {
            ibSource.SelectionMode = ImageGlass.ImageBoxSelectionMode.Rectangle;
            ibSource.SelectionRegion = new RectangleF(ibSource.Image.Width / 2, ibSource.Image.Height / 2, ibSource.Image.Width / 4, ibSource.Image.Height / 4);
            ibSource.SelectionMode = ImageGlass.ImageBoxSelectionMode.None;
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            using (Mat ImageSrc = ImageSource.Clone())
            {
                SelectedRegion = new Rect(
                    (int)ibSource.SelectionRegion.X,
                    (int)ibSource.SelectionRegion.Y,
                    (int)ibSource.SelectionRegion.Width,
                    (int)ibSource.SelectionRegion.Height);

                ImageProcess = ImageSrc.SubMat(SelectedRegion).Clone();
                ibSource.SelectionMode = ImageGlass.ImageBoxSelectionMode.None;
                ibSource.SelectionRegion = new RectangleF();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ibSource.SelectionMode = ImageGlass.ImageBoxSelectionMode.None;
        }

        private void btnMean_Click(object sender, EventArgs e)
        {
            using (Mat ImageSrc = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)ibSource.Image).Clone())
            {
                Rect rtSubmat = new Rect(
                    (int)ibSource.SelectionRegion.X,
                    (int)ibSource.SelectionRegion.Y,
                    (int)ibSource.SelectionRegion.Width,
                    (int)ibSource.SelectionRegion.Height);

                double dMean = Cv2.Mean(ImageSrc.SubMat(rtSubmat)).Val0;
                btnMean.Text = $"Mean : {dMean.ToString("F2")}";
                ibSource.SelectionMode = ImageGlass.ImageBoxSelectionMode.None;
            }
        }

        private void btnMatrixView_Click(object sender, EventArgs e)
        {
            Rect rtSubmatOrg = new Rect(
                    (int)ibSource.SelectionRegion.X,
                    (int)ibSource.SelectionRegion.Y,
                    (int)ibSource.SelectionRegion.Width,
                    (int)ibSource.SelectionRegion.Height);

            using (Mat ImageSrc = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)ibSource.Image).Clone())
            using (Mat ImageSub = ImageSrc.SubMat(rtSubmatOrg).Clone())
            {
                Bitmap imageDisplay = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(ImageSub);

                double dMean = Cv2.Mean(ImageSub).Val0 - 10;

                using (Graphics g = Graphics.FromImage(imageDisplay))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    int nRow = 12;
                    int nCol = 12;

                    int nW = imageDisplay.Width;
                    int nH = imageDisplay.Height;

                    int nSW = nW / nCol;
                    int nSH = nH / nRow;

                    for (int nx = 0; nx < nCol; nx++)
                    {
                        for (int ny = 0; ny < nRow; ny++)
                        {
                            Rect rtSubmat = new Rect((nSW * nx), (nSH * ny), nSW, nSH);

                            double dPartialMean = Cv2.Mean(ImageSub.SubMat(rtSubmat)).Val0;

                            Rectangle rtDrawing = new Rectangle((nSW * nx), (nSH * ny), nSW, nSH);
                            g.DrawRectangle(new Pen(Color.Silver, 1), rtDrawing);

                            if (dPartialMean < dMean)
                            {
                                g.DrawString(((int)(dPartialMean)).ToString(), new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Red), new PointF((nSW * nx), (nSH * ny)));
                            }
                            else
                            {
                                g.DrawString(((int)(dPartialMean)).ToString(), new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Lime), new PointF((nSW * nx), (nSH * ny)));
                            }
                        }
                    }
                    ibSource.SelectionMode = ImageGlass.ImageBoxSelectionMode.None;
                }

                ibSource.Image = imageDisplay;
            }

            ibSource.SelectionMode = ImageGlass.ImageBoxSelectionMode.None;
            ibSource.SelectionRegion = new RectangleF();
        }
    }
}