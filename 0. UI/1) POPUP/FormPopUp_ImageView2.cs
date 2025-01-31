using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_ImageView2 : Form
    {
        public FormPopUp_ImageView2()
        {
            InitializeComponent();
        }

        private void FormPopUp_ImageView2_Load(object sender, EventArgs e)
        {
            cogDisplay_Master.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.Instance.MasterImage[0].ToBitmap());
            cogDisplay_Master.Fit(true);
            cogDisplay_Result.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.Instance.ResultImage[0].ToBitmap());
            cogDisplay_Result.Fit(true);

            lbSelectArray1.BackColor = Color.Green;
            lbSelectArray2.BackColor = Color.Transparent;
        }

        private void OnClick(object sender, EventArgs e)
        {
            lbSelectArray1.BackColor = Color.Transparent;
            lbSelectArray2.BackColor = Color.Transparent;

            Label lbl = sender as Label;
            lbl.BackColor = DEFINE_COMMON.COLOR_GREEN;

            if (lbl.Name == "lbSelectArray1")
            {
                //IGlobal.Instance.MasterImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(IGlobal.Instance.m_imagesGrab[0].ToBitmap());
                //IGlobal.Instance.ResultImage[0] = OpenCvSharp.Extensions.BitmapConverter.ToMat(IGlobal.Instance.ImageResults_array[0]);
                cogDisplay_Result.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.Instance.ResultImage[0].ToBitmap());
                cogDisplay_Result.Fit(true);
            }
            else
            {
                //IGlobal.Instance.ResultImage[1] = OpenCvSharp.Extensions.BitmapConverter.ToMat(IGlobal.Instance.ImageResults_array[1]);
                cogDisplay_Result.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.Instance.ResultImage[1].ToBitmap());
                cogDisplay_Result.Fit(true);
            }
        }

        // 보드 수량은 최대 4개...
        //private void Init_CogDisplayVisible()
        //{
        //    // 보드 카운트 수량에 따라...표시..
        //    if (IGlobal.Instance.System.Recipe.JobManager.ArrayCount == 1)
        //    {
        //        cogDisplay_Array1.Visible = true;
        //        cogDisplay_Array1.Size = new Size(1246, 693);
        //        cogDisplay_Array2.Visible = false;
        //        cogDisplay_Array3.Visible = false;
        //        cogDisplay_Array4.Visible = false;
        //    }
        //    else if (IGlobal.Instance.System.Recipe.JobManager.ArrayCount == 2)
        //    {
        //        cogDisplay_Array1.Visible = true;
        //        cogDisplay_Array1.Size = new Size(612, 693);
        //        cogDisplay_Array2.Visible = true;
        //        cogDisplay_Array2.Size = new Size(612, 693);
        //        cogDisplay_Array3.Visible = false;
        //        cogDisplay_Array4.Visible = false;
        //    }
        //    else if (IGlobal.Instance.System.Recipe.JobManager.ArrayCount == 3)
        //    {
        //        cogDisplay_Array1.Visible = true;
        //        cogDisplay_Array1.Size = new Size(612, 340);
        //        cogDisplay_Array2.Visible = true;
        //        cogDisplay_Array2.Size = new Size(612, 340);
        //        cogDisplay_Array3.Visible = true;
        //        cogDisplay_Array4.Visible = false;
        //    }
        //    else
        //    {
        //        cogDisplay_Array1.Visible = true;
        //        cogDisplay_Array2.Visible = true;
        //        cogDisplay_Array3.Visible = true;
        //        cogDisplay_Array4.Visible = true;
        //    }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            Global.m_BoardOut = false;
            Close();
        }
    }
}