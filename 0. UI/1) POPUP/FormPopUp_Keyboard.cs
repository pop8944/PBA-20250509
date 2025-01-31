using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_Keyboard : MetroForm
    {
        public string ReturnString = "";

        public FormPopUp_Keyboard()
        {
            InitializeComponent();
        }

        private void FormPopUp_Keyboard_Load(object sender, EventArgs e)
        {
            try
            {
                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbPassword.Text = "";
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            try
            {
                tbPassword.Text = tbPassword.Text.Remove(tbPassword.Text.Length - 1);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                ReturnString = tbPassword.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void OnClickKeyboard(object sender, MouseEventArgs e)
        {
            try
            {
                if (sender is MetroTile)
                {
                    string strKey = (sender as MetroTile).Text;
                    tbPassword.Text = tbPassword.Text + strKey;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}