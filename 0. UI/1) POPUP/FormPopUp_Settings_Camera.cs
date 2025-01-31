//IF 전용 Library
using MetroFramework.Forms;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_Settings_Camera : MetroForm
    {
        private Global Global = Global.Instance;
        //private int m_nCameraIndex = 0;

        #region Event Register

        public EventHandler<EventArgs> EventUpdateUi;

        #endregion Event Register

        public FormPopUp_Settings_Camera()
        {
            InitializeComponent();
            cbIndex.SelectedIndex = 0;
            cbTriggerMode.SelectedIndex = 0;
        }

        private void FormPopUp_Settings_Camera_Load(object sender, EventArgs e)
        {
            InitEvent();
        }

        private bool InitEvent()
        {
            try
            {
                if (EventUpdateUi != null)
                {
                    EventUpdateUi(null, null);
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        private void OnChangedRecipe(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnChangedRecipe(sender, e);
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
                    string[] strRecipeArr = Global.System.Recipe.Name.Split('.');
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nIndex = cbIndex.SelectedIndex;
            FormPopUp_MessageBox FrmMessageBox = new FormPopUp_MessageBox(string.Format("Save the Camera #{0} Parameter", (nIndex).ToString()), string.Format("Do you want the save?"));
            if (FrmMessageBox.ShowDialog() == DialogResult.OK)
            {
                //Global.CamManager.Cameras[nIndex].IP = tbIP.Text;
                //Global.CamManager.Cameras[nIndex].ExposureTime = double.Parse(tbExposure.Text);
                //Global.CamManager.Cameras[nIndex].Gain = double.Parse(tbGain.Text);

                //Global.CamManager.Cameras[nIndex].SetExposure(Global.CamManager.Cameras[nIndex].ExposureTime);
                //Global.CamManager.Cameras[nIndex].SetGain(Global.CamManager.Cameras[nIndex].Gain);

                //Global.CamManager.Cameras[nIndex].SaveConfig(Global.iSystem.Recipe.Name);
            }
        }
    }
}