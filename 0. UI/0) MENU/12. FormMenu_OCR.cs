using Cognex.VisionPro;
using Cognex.VisionPro.OCRMax;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormMenu_OCR : Form
    {
        private Global Global = Global.Instance;
        private CogOCRMaxTool CogOCRMaxTool;
        private CogImage8Grey CogImage8Grey;

        public FormMenu_OCR(CogOCRMaxTool cogOCRMaxTool, CogImage8Grey cogImage8Grey)
        {
            InitializeComponent();
            this.CogOCRMaxTool = cogOCRMaxTool;
            this.CogImage8Grey = cogImage8Grey;
        }

        private void FormMenu_OCR_Load(object sender, EventArgs e)
        {
            try
            {
                cogOCRMaxEditV21.Subject = this.CogOCRMaxTool;
                cogOCRMaxEditV21.Subject.InputImage = this.CogImage8Grey;
                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public CogOCRMaxTool GetOCRMaxTool()
        {
            return this.CogOCRMaxTool;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}