using MetroFramework.Forms;
using System;
using System.Reflection;

namespace IntelligentFactory
{
    public partial class FormPopUp_Viewer_Alarm : MetroForm
    {
        private Global Global = Global.Instance;

        public FormPopUp_Viewer_Alarm()
        {
            InitializeComponent();
        }

        private void FormPopUp_Viewer_Alarm_Load(object sender, EventArgs e)
        {
            try
            {
                dtpEnd.Value = DateTime.Now;

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}