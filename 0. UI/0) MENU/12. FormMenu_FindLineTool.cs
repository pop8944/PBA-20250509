using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormMenu_FindLineTool : Form
    {
        private Global Global = Global.Instance;
        private CogFindLineTool _tool;
        private CogImage8Grey CogImage8Grey;

        public FormMenu_FindLineTool(CogFindLineTool tool, CogImage8Grey cogImage8Grey)
        {
            InitializeComponent();
            _tool = tool;
            this.CogImage8Grey = cogImage8Grey;
        }

        private void FormMenu_OCR_Load(object sender, EventArgs e)
        {
            try
            {
                cogFindLineEditV21.Subject = this._tool;
                cogFindLineEditV21.Subject.InputImage = this.CogImage8Grey;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}