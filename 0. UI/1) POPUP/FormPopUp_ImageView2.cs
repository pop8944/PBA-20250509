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
                cogDisplay_Result.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.Instance.ResultImage[0].ToBitmap());
                cogDisplay_Result.Fit(true);
            }
            else
            {
                cogDisplay_Result.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.Instance.ResultImage[1].ToBitmap());
                cogDisplay_Result.Fit(true);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Global.m_BoardOut = false;
            Close();
        }
    }
}