using MetroFramework.Forms;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_ImageView : MetroForm
    {
        private Mat ImageSource = new Mat();
        //private Mat ImageDisplay = new Mat();

        //private Rectangle m_ROI;

        //private System.Drawing.Point m_ptStart = new System.Drawing.Point(0, 0);
        //private System.Drawing.Point m_ptEnd = new System.Drawing.Point(0, 0);

        //private bool m_bIsMouseJob = false;
        //private bool m_bIsToUpDown = true;

        public float m_fImageScale { get; set; } = 1;
        public float m_fImgW { get; set; } = 0;
        public float m_fImgH { get; set; } = 0;

        public float m_dPenX { get; set; } = 0;
        public float m_dPenY { get; set; } = 0;

        public float m_fMinX { get; private set; } = 1;
        public float m_fMinY { get; private set; } = 1;

        public float m_fMaxX { get; private set; } = 0;
        public float m_fMaxY { get; private set; } = 0;

        public FormPopUp_ImageView(Mat image)
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(MouseWheelEvent);

            ibSource.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);

            m_fMaxX = m_fImgW = ImageSource.Width;
            m_fMaxY = m_fImgH = ImageSource.Height;
        }

        public FormPopUp_ImageView(Bitmap image)
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(MouseWheelEvent);

            ibSource.Image = image;

            m_fMaxX = m_fImgW = ImageSource.Width;
            m_fMaxY = m_fImgH = ImageSource.Height;
        }

        /// <summary>
        /// EventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if ((e.Delta / 120) > 0) ibSource.ZoomIn();
            else ibSource.ZoomOut();
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

        private void FormPopUp_ImageView_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}