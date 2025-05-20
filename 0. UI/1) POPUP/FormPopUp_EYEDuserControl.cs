using FrameworkOnnxTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using IFOnnxRuntime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.IO;
using System.Numerics;

namespace IntelligentFactory
{
    public partial class FormPopUp_EYEDuserControl : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        IFOnnxRuntimeControl ifOnnxRuntimeControl = new IFOnnxRuntimeControl();
        public event Action ClosedPopup;
        public IFOnnxRuntimeControl IfOnnxRuntimeControl { get => ifOnnxRuntimeControl; private set => ifOnnxRuntimeControl = value; }

        public FormPopUp_EYEDuserControl()
        {
            InitializeComponent();
            ifOnnxRuntimeControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(ifOnnxRuntimeControl);
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ClosedPopup?.Invoke();
            this.Close();
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
 
        private void BtnEyeDSave_Click(object sender, EventArgs e)
        {
            Global.Instance.eyeD.Models = ifOnnxRuntimeControl.EyeD.Models;
            Global.Instance.System.Recipe.Save_EYEDRecipe();
            IF_Util.ShowMessageBox("Complete", "EYE-D Recipe Save Complete");
        }
        

        private void FormPopUp_EYEDuserControl_Load(object sender, EventArgs e)
        {
        }
    }
}
