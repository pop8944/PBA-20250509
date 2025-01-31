using Cognex.VisionPro;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_Settings_Masking : Form
    {
        public CogImage8Grey MaskImage = new CogImage8Grey();
        private CJob m_job = null;
        private CogImage8Grey m_img = null;

        public FormPopUp_Settings_Masking()
        {
            InitializeComponent();
        }

        public FormPopUp_Settings_Masking(CJob job, CogImage8Grey img)
        {
            InitializeComponent();

            m_job = job;
            m_img = img;

            cogImageMaskEditDisplay.Image = m_img;
        }

        private void FormPopUp_Settings_Masking_Load(object sender, EventArgs e)
        {
            //CVisionCognex.TrainGraphic(m_job.Tool.Tool, cogDisplay_MASK);
            cogDisplay_MASK.Image = m_img;
            cogDisplay_MASK.Fit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MaskImage = cogImageMaskEditDisplay.MaskImage.Copy(CogImageCopyModeConstants.CopyPixels);
                cogDisplay_MaskingImage.Image = MaskImage;

                m_job.Tool.Tool.Pattern.TrainImageMask = MaskImage;
                m_job.Tool.Tool.Pattern.TrainImage = m_img;
                m_job.Tool.Tool.Pattern.Train();

                CVisionCognex.TrainGraphic(m_job.Tool.Tool, cogDisplay_AfterMaskPattern);
                cogDisplay_AfterMaskPattern.Image = m_job.Tool.Tool.Pattern.GetTrainedPatternImage();
                cogDisplay_AfterMaskPattern.Fit(true);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}