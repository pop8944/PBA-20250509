using System;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormSettings_GrabManager : Form
    {
        private CGrabManager _manager = null;
        private Camera _cam = null;

        public FormSettings_GrabManager(CGrabManager manager, Camera cam)
        {
            InitializeComponent();
            _manager = manager;
            _cam = cam;
            float fGainMax = 16;// _cam.GetGainMax();
            int nGainMax = (int)Math.Ceiling((double)fGainMax);
            nbCamGain.Maximum = new decimal(new int[] {
            (int)nGainMax,
            0,
            0,
            0});
        }
        private void FormSettings_Grab_Load(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.OpenCheckForm(this)) this.Close();

                chkGrab1_Enabled.Checked = _manager.Nodes[0].Enabled;
                nbGrab1_ExposureTime.Value = _manager.Nodes[0].ExposureTime_us;

                chkGrab2_Enabled.Checked = _manager.Nodes[1].Enabled;
                nbGrab2_ExposureTime.Value = _manager.Nodes[1].ExposureTime_us;

                chkGrab3_Enabled.Checked = _manager.Nodes[2].Enabled;
                nbGrab3_ExposureTime.Value = _manager.Nodes[2].ExposureTime_us;

                chkGrab4_Enabled.Checked = _manager.Nodes[3].Enabled;
                nbGrab4_ExposureTime.Value = _manager.Nodes[3].ExposureTime_us;

                chkGrab5_Enabled.Checked = _manager.Nodes[4].Enabled;
                nbGrab5_ExposureTime.Value = _manager.Nodes[4].ExposureTime_us;

                nbCamExposure.Value = (int)Global.Instance.Setting.Enviroment.Camera1.DefaultExposureTime;
                nbCamGain.Value = (int)Global.Instance.Setting.Enviroment.Camera1.DefaultGain;

                if (Global.Instance.Setting.Enviroment.Camera1.FLIPROTATE == "") Global.Instance.Setting.Enviroment.Camera1.FLIPROTATE = "NONE";
                cbCamFlipRotate.Text = Global.Instance.Setting.Enviroment.Camera1.FLIPROTATE;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void OnClickGrab(object sender, EventArgs e)
        {
            try
            {
                int nIndex = int.Parse((sender as Button).Tag.ToString());

                if (_cam.IsOpen)
                {
                    _cam.SetExposure(_manager.Nodes[nIndex].ExposureTime_us);
                    _cam.Live(false);
                    _cam.Grab(false);
                }
                else
                {
                    IF_Util.ShowMessageBox("CAMERA", "Check the Connection of Camera");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("SAVE", "Do you want to save the Grab Manager?") == true)
                {
                    _manager.Nodes[0].Enabled = chkGrab1_Enabled.Checked;
                    _manager.Nodes[0].ExposureTime_us = (int)nbGrab1_ExposureTime.Value;

                    _manager.Nodes[1].Enabled = chkGrab2_Enabled.Checked;
                    _manager.Nodes[1].ExposureTime_us = (int)nbGrab2_ExposureTime.Value;

                    _manager.Nodes[2].Enabled = chkGrab3_Enabled.Checked;
                    _manager.Nodes[2].ExposureTime_us = (int)nbGrab3_ExposureTime.Value;

                    _manager.Nodes[3].Enabled = chkGrab4_Enabled.Checked;
                    _manager.Nodes[3].ExposureTime_us = (int)nbGrab4_ExposureTime.Value;

                    _manager.Nodes[4].Enabled = chkGrab5_Enabled.Checked;
                    _manager.Nodes[4].ExposureTime_us = (int)nbGrab5_ExposureTime.Value;

                    _manager.SaveConfig();

                    IF_Util.ShowMessageBox("SAVE", "Completed the Save");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        #region FORM MOVING BY LABEL

        private bool m_bIsDrag_Form = false;
        private System.Drawing.Point m_ptForm = new System.Drawing.Point();

        private void lbMenu_MouseDown(object sender, MouseEventArgs e)
        {
            m_bIsDrag_Form = true;
            this.m_ptForm = new System.Drawing.Point(e.X, e.Y);
        }

        private void lbMenu_MouseUp(object sender, MouseEventArgs e)
        {
            m_bIsDrag_Form = false;
        }

        private void lbMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_bIsDrag_Form) return;

            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            Location = new System.Drawing.Point(this.Left - (m_ptForm.X - e.X), this.Top - (m_ptForm.Y - e.Y));
        }

        #endregion FORM MOVING BY LABEL

        private void btnCameraParameterApply_Click(object sender, EventArgs e)
        {
            try
            {
                Global.Instance.Setting.Enviroment.Camera1.DefaultExposureTime = (int)nbCamExposure.Value;
                Global.Instance.Setting.Enviroment.Camera1.DefaultGain = (int)nbCamGain.Value;
                if (cbCamFlipRotate.SelectedItem != null)
                    Global.Instance.Setting.Enviroment.Camera1.FLIPROTATE = cbCamFlipRotate.SelectedItem.ToString();

                _cam.SetExposure(Global.Instance.Setting.Enviroment.Camera1.DefaultExposureTime);
                _cam.SetGain(Global.Instance.Setting.Enviroment.Camera1.DefaultGain);

                Global.Instance.Setting.Enviroment.Save();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}