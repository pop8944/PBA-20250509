using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_ProgressBar : Form
    {
        private System.Drawing.Graphics g;
        private List<System.Drawing.Image> images = new List<System.Drawing.Image>();
        private int nImgPos = 0;
        private System.Drawing.Rectangle clearRect = new System.Drawing.Rectangle();
        private System.Drawing.Rectangle drawRect = new System.Drawing.Rectangle();
        private System.Drawing.RectangleF sourceRect = new System.Drawing.Rectangle();
        private int xAdjust = 0;
        private int ySStart = 0;

        public FormPopUp_ProgressBar(string strHead, string strDesc, double dMax, List<System.Drawing.Image> imgs, int nYStart = 0, int nXAdjust = 120, double dOpacity = 0.9)
        {
            InitializeComponent();
            this.Text = strHead;
            lbDesc.Text = strDesc;
            mPrsBar.Maximum = (int)dMax;
            mPrsBar.Value = 0;
            xAdjust = nXAdjust;
            ySStart = nYStart;
            //lbPrs.Text = $"{0:0.##}%";
            this.Show();
            images = imgs;

            int xPos = (int)((double)mPrsBar.Value / (double)mPrsBar.Maximum * (double)mPrsBar.Width) - xAdjust;
            int yPos = mPrsBar.Location.Y - images[0].Height;
            drawRect = new System.Drawing.Rectangle(xPos, yPos, images[0].Width, images[0].Height);

            nImgPos = 0;

            // 불투명 정도, 0에 가까울수록 투명
            Opacity = dOpacity;
        }

        public int GetCurPos()
        {
            return mPrsBar.Value;
        }

        public void SetCurPos(object sender = null, int nCurPos = 0)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        SetCurPos(sender, nCurPos);
                    }));
                }
                catch (Exception Desc)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                }
            }
            else
            {
                // Form으로 부터 Graphic 객체를 생성한다.
                g = this.CreateGraphics();
                //Invalidate();
                SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.FromArgb(255, 64, 73, 108));
                g.FillRectangle(drawBrush, clearRect);
                // 여기 Image Size 조정
                float fCurPercent = (float)mPrsBar.Value / (float)mPrsBar.Maximum;
                int xPos = (int)((float)mPrsBar.Value / (float)mPrsBar.Maximum * (float)mPrsBar.Width) - xAdjust;
                int ySizeMain = images[nImgPos].Height - ySStart;
                int yPos = mPrsBar.Location.Y - (int)(ySizeMain * fCurPercent) - ySStart;
                int nDrawWidth = (int)(images[nImgPos].Width);
                int nDrawHeight = (int)(ySizeMain * fCurPercent) + ySStart;
                drawRect = new System.Drawing.Rectangle(xPos, yPos, nDrawWidth, nDrawHeight);
                sourceRect = new System.Drawing.RectangleF(0, images[nImgPos].Height - (int)(ySizeMain * fCurPercent) - ySStart, nDrawWidth, nDrawHeight);

                // 여기 원 이미지 출력
                g.DrawImage(images[nImgPos], drawRect, sourceRect, GraphicsUnit.Pixel);

                clearRect = new System.Drawing.Rectangle(xPos, mPrsBar.Location.Y - (int)(ySizeMain) - ySStart, nDrawWidth, images[nImgPos].Height);

                // 여기 StretchBlt 구현
                //double dCurPercent = (double)mPrsBar.Value / (double)mPrsBar.Maximum;
                //int nDrawWidth = (int)(images[nImgPos++].Width * dCurPercent);
                //int nDrawHeight = (int)(images[nImgPos++].Height * dCurPercent);
                //System.Drawing.Rectangle rctSource = new System.Drawing.Rectangle(0, 0, nDrawWidth, nDrawHeight);
                //System.Drawing.Rectangle rctTarget = new System.Drawing.Rectangle(xPos, yPos, nDrawWidth, nDrawHeight);
                //CUtil.DrawStretchBlt(g, images[nImgPos++], rctSource, rctTarget, TernaryRasterOperations.SRCCOPY);

                // Color Matrix를 이용한 투명화 처리
                int ySizeOvl = images[nImgPos].Height - ySStart;
                int yPosOvl = mPrsBar.Location.Y - images[nImgPos].Height;
                nDrawHeight = (int)(ySizeOvl * (1.0 - fCurPercent));
                drawRect = new System.Drawing.Rectangle(xPos, yPosOvl, nDrawWidth, nDrawHeight);
                sourceRect = new System.Drawing.RectangleF(0, 0, nDrawWidth, nDrawHeight);

                // Initialize the color matrix.
                // Note the value 0.8 in row 4, column 4.
                float[][] matrixItems ={ new float[] {1, 0, 0, 0, 0}, new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0}, new float[] {0, 0, 0, (float)0.1, 0}, new float[] {0, 0, 0, 0, 1}};
                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                // Create an ImageAttributes object and set its color matrix.
                ImageAttributes imageAtt = new ImageAttributes();
                imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                //             Graphics.DrawImage(images[nImgPos],
                //                 new System.Drawing.Rectangle(30, 0, 444, 444),  // destination rectangle
                //                 0.0f,                          // source rectangle x
                //                 0.0f,                          // source rectangle y
                //iWidth,                        // source rectangle width
                //iHeight,                       // source rectangle height
                //GraphicsUnit.Pixel,
                //imageAtt);

                g.DrawImage(images[nImgPos++], drawRect, sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height,
                    GraphicsUnit.Pixel, imageAtt);
                //g.DrawImage(images[nImgPos++], drawRect, sourceRect, GraphicsUnit.Pixel);
                if (nImgPos >= images.Count)
                    nImgPos = 0;

                mPrsBar.Value = nCurPos;
                this.Show();
                if (mPrsBar.Value >= mPrsBar.Maximum)
                {
                    OnEndProgress(this);
                }
            }
        }

        public void OnEndProgress(object sender = null, EventArgs e = null)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnEndProgress(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
            else
            {
                try
                {
                    mPrsBar.Value = 0;
                    this.Close();
                }
                catch
                {
                }
            }
        }
    }
}