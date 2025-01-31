//IF 전용 Library
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_Settings_Illumination : MetroForm
    {
        private Global Global = Global.Instance;

        #region Event Register

        public EventHandler<EventArgs> EventUpdateUi;

        #endregion Event Register

        public FormPopUp_Settings_Illumination()
        {
            InitializeComponent();

            try
            {
                string[] ComportList = IF_Util.AvalibleComports();

                if (ComportList.Length > 0)
                {
                    cbPortName.Items.AddRange(ComportList);
                    cbPortName.SelectedIndex = 0;
                }

                if (cbBaudrate.Items.Count > 0) cbBaudrate.SelectedIndex = 0;
                else
                {
                    lbConnection.Text = "DISCONNECTED";
                    lbConnection.Style = MetroColorStyle.Silver;

                    btnConnect.Text = "CONNECT";
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void FormPopUp_Settings_Illumination_Load(object sender, EventArgs e)
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
            try
            {
                FormPopUp_MessageBox FrmMessageBox = new FormPopUp_MessageBox(string.Format("Save the Illumination Parameter"), string.Format("Do you want the save?"));

                if (FrmMessageBox.ShowDialog() == DialogResult.OK)
                {
                    //Global.LightController.Close();
                    //Global.LightController.PortName = cbPortName.Text;
                    //Global.LightController.BaudRate = int.Parse(cbBaudrate.Text);
                    //Global.LightController.SaveConfig();

                    //Global.LightController.Init();
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", ex.Message, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
            }
        }

        private void trbValue_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int nValue = trbValue.Value;
                lbValue.Text = nValue.ToString();

                //if (Global.LightController.IsOpen)
                //{
                //    int nLightIndex = cbChannel.SelectedIndex + 1;
                //    Global.LightController.SetValue(nLightIndex, nValue);
                //}
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", ex.Message, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
            }
        }

        private void btnON_Click(object sender, EventArgs e)
        {
            try
            {
                int nChannel = int.Parse(cbChannel.Text);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", ex.Message, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
            }
        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            try
            {
                int nChannel = int.Parse(cbChannel.Text);
                //Global.LightController.Off(nChannel);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", ex.Message, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                int nChannel = int.Parse(cbChannel.Text);
                //Global.LightController.On(nChannel);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", ex.Message, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
            }
        }
    }
}