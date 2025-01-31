using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using log4net.Repository.Hierarchy;
using Sunny.UI;
using AsyncSocket;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Threading;
using System.Management;
using System.IO;

namespace IF
{
    public partial class Form_MainFrame : Form
    {
        private Global Global = Global.Instance;
        private string _thisName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
        private Dictionary<string, UISymbolButton> _menuButtons = new Dictionary<string, UISymbolButton>();
        private Dictionary<string, Form> _menuForms = new Dictionary<string, Form>();
        
        private Form_MenuMain _formMenuMain = null;
        private FormSetting_Loading _formSubLoading = null;

        private LogViewer logViewList = new LogViewer();
        //private AsyncSocketServer server;
        //private List<AsyncSocketClient> clientList;
        //private int id;

        public Form_MainFrame()
        {
            InitializeComponent();

            logViewList.Dock = DockStyle.Fill;
            logViewList.Visible = true;

            pnlLog.Controls.Add(logViewList);
            logViewList.SetColumnImageWidth(pnlLog.Width);
        }

        private PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes");

        private int value_Cpu = 0;
        private int value_Ram = 0;
        private int value_CDrive = 0;
        private int value_DDrive = 0;

        private void Form_MainFrame_Load(object sender, EventArgs e)
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            try
            {
                _formSubLoading = new FormSetting_Loading();
                _formSubLoading.Show();

                InitTasks();
                InitComponents();

                pnlTitle.Text = $"          {Global.COMPANY_NAME}";

                lblVersion.Text = $"Build ({IF_Util.GetCompiledDateTime().ToString("yyyy.MM.dd HH:mm:ss")})   \n"
                    + $"Start ({DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")})  \n"
                    + $"V0.0.0 {((Debugger.IsAttached == true) ? "Debug" : "Release")}";
                
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[[{_thisName}.{MethodName} :: Error]] {ex}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void InitComponents()
        {
            _menuButtons.Clear();

            _menuButtons.Add(btnMenu_Main.Text, btnMenu_Main);
            _menuButtons.Add(btnMenu_Model.Text, btnMenu_Model);
            _menuButtons.Add(btnMenu_Vision.Text, btnMenu_Vision);
            //_menuButtons.Add(btnMenu_Motor.Text, btnMenu_Motor);
            _menuButtons.Add(btnMenu_Device.Text, btnMenu_Device);
            //_menuButtons.Add(btnMenu_DataBase.Text, btnMenu_DataBase);
            _menuButtons.Add(btnMenu_Setting.Text, btnMenu_Setting);

            pnlMDI.Controls.Clear();

            AddMenuForm("MAIN", new Form_MenuMain());
            AddMenuForm("VISION", new Form_MenuVision());
            ShowMenuForm("MAIN");
        }

        private void InitTasks()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            Task.Run(() =>
            {
                Global.Init();                              // Global.Init 순서 변경 금지 ( 프로그램 오작동 )
                InitEvent();
            });

            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        Thread.Sleep(100);

                        if (IF_System.REQ_SYSTEM_CLOSE) return;

                        value_Cpu = (int)cpu.NextValue();

                        //유틸
                        ManagementClass cls = new ManagementClass("Win32_OperatingSystem");
                        ManagementObjectCollection instances = cls.GetInstances();

                        foreach (ManagementObject mo in instances)
                        {
                            int total_mem = int.Parse(mo["TotalVisibleMemorySize"].ToString());
                            int free_mem = int.Parse(mo["FreePhysicalMemory"].ToString());
                            int remain_mem = total_mem - free_mem;

                            value_Ram = (int)((double)remain_mem / (double)total_mem * 100); // (int)ram.NextValue();
                        }

                        DriveInfo[] drives = DriveInfo.GetDrives();

                        foreach (var drive in drives)
                        {
                            switch (drive.DriveType)
                            {
                                case DriveType.Fixed:
                                    {
                                        if (drive.Name == "C:\\")
                                        {
                                            value_CDrive = (int)(100 - (double)drive.AvailableFreeSpace / (double)drive.TotalSize * 100); // (int)ram.NextValue();
                                        }

                                        if (drive.Name == "D:\\")
                                        {
                                            value_DDrive = (int)(100 - (double)drive.AvailableFreeSpace / (double)drive.TotalSize * 100); // (int)ram.NextValue();
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"[[{_thisName}.{MethodName} :: Error]] {ex}");
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }

            });
        }

        private void AddMenuForm(string menuName, Form form)
        {
            if (_menuForms.ContainsKey(menuName) == false)
            {
                _menuForms.Add(menuName, form);
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                pnlMDI.Controls.Add(form);
            }
        }

        private void ShowMenuForm(string menuName)
        {
            foreach (var menu in _menuForms) menu.Value.Hide();
            foreach (var menu in _menuButtons) menu.Value.Selected = false;

            if (_menuForms.ContainsKey(menuName) == true)
            {
                _menuForms[menuName].Show();
            }

            if (_menuButtons.ContainsKey(menuName) == true)
            {
                _menuButtons[menuName].Selected = true;
            }
        }

        private void InitEvent()
        {
            Global.SeqInitialize.EventInitEnd += OnInitEnd;
            //IF_System.EventChangedMode += OnChangedMode;
            //IF_System.EventChangedAuthorization += OnChangedAuthorization;

        }

        private void OnInitEnd(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new System.Windows.Forms.MethodInvoker(() =>
                    {
                        OnInitEnd(sender, e);
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
                    pnlLogViewer.Visible = false;
                    pnlMessage.Visible = false;

                    _formSubLoading.Close();

                    //_formSubLoading.Close();
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }
        private void OnChangedMode(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new System.Windows.Forms.MethodInvoker(() =>
                    {
                        OnChangedMode(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
            else
            {
                btnOper_Start.Enabled = false;
                btnOper_Stop.Enabled = false;
                btnOper_Pause.Enabled = false;
                btnOper_Reset.Enabled = false;

                btnOper_Start.Selected = false;
                btnOper_Stop.Selected = false;
                btnOper_Pause.Selected = false;
                btnOper_Reset.Selected = false;



                switch (IF_System.Mode) //상태 변화
                {
                    case IF_System.MODE.AUTO:
                        {
                            btnOper_Stop.Enabled = true;
                            btnOper_Pause.Enabled = true;
                        }
                        break;

                    case IF_System.MODE.STOP:
                        {
                            btnOper_Start.Enabled = true;
                        }
                        break;

                    case IF_System.MODE.PAUSE:
                        {
                            btnOper_Start.Enabled = true;
                        }
                        break;

                    case IF_System.MODE.ALARM:
                        {
                            btnOper_Reset.Enabled = true;
                        }
                        break;
                }
            }
        }

        private void OnChangedAuthorization(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new System.Windows.Forms.MethodInvoker(() =>
                    {
                        OnChangedAuthorization(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
            else
            {
                btnAuthorization.Text = $"LOGIN [{IF_System.Authorization} / ID : 0000]";
            }
        }

        private void OnClickMenu(object sender, EventArgs e)
        {
            try
            {
                string menuName = (sender as UISymbolButton).Text.ToString().ToUpper();
                //SystemNotice = $"Click the Menu : {menuName}";

                switch (menuName)
                {
                    case "MAIN":
                    case "Main":
                    case "main":
                    case "메인":
                        {
                            ShowMenuForm("MAIN");
                        }
                        break;

                    case "EYE-D":
                    case "DeepLearning":
                    case "Annotate":
                        {
                        }
                        break;
                    case "Teaching":
                    case "teaching":
                    case "VISION":
                    case "티칭":
                    case "비전":
                        {
                            ShowMenuForm("VISION");
                        }
                        break;
                    case "CALIBRATION":
                    case "CALI":
                        {
                            ShowMenuForm("Calibration");
                        }
                        break;
                    case "History":
                    case "이력 조회":
                        {
                        }
                        break;

                    case "Setting":
                    case "Settings":
                    case "SETTING":
                    case "환경 설정":
                    case "설정":
                        {
                        }
                        break;

                    case "CROP":
                        {
                        }
                        break;
                    case "Classification":
                    case "디펙 분류":
                        {
                            //_formMenu_Classification.Show();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        #region FORM MOVING BY LABEL
        private bool _isDragForm = false;
        private System.Drawing.Point _posForm = new System.Drawing.Point();
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            _isDragForm = true;
            this._posForm = new System.Drawing.Point(e.X, e.Y);
        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragForm = false;
        }

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragForm) return;

            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            Location = new System.Drawing.Point(this.Left - (_posForm.X - e.X), this.Top - (_posForm.Y - e.Y));
        }
        #endregion

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (IF_Util.ShowMessageBox("Close", "Do you want to close?"))
            {
                if (IF_System.Mode == IF_System.MODE.AUTO)
                {                    
                    IF_Util.ShowMessageBox("Notice", "Can't Close the Program, because Current Mode is Auto");
                    return;
                }
                else
                {
                    Global.Setting.Option.Save();           //240626 mwpark 추가
                    CLogger.Add(LOG.SYSTEM, "S/W Close");
                    Global.Close();
                    this.Close();
                }
            }

            //server.Stop();
        }

        private string getProductName()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            Trace.WriteLine($"[[{_thisName}.{MethodName} :: Start]]");

            try
            {
                var cn = Application.CompanyName;
                var ns = Application.ProductName;
                var vr = Application.ProductVersion;
                return $"{ns} v{vr} ({cn} Optical Inspection System)  {getBuildDateTimeFromAssembly().ToString("yyyy - MM - dd HH: mm:ss")}";
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[[{_thisName}.{MethodName} :: Error]] {ex}");
                return null;
            }
        }
        private DateTime getBuildDateTimeFromAssembly()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return System.IO.File.GetLastWriteTime(assembly.Location);
        }

        private void OnClickOperation(object sender, EventArgs e)
        {
            try
            {
                string operationName = (sender as UISymbolButton).Text;

                switch (operationName)
                {
                    case "START":
                        {
                            IF_System.Mode = IF_System.MODE.AUTO;
                        }
                        break;

                    case "PAUSE":
                        {
                            IF_System.Mode = IF_System.MODE.PAUSE;
                        }
                        break;

                    case "STOP":
                        {
                            IF_System.Mode = IF_System.MODE.STOP;
                        }
                        break;

                    case "RESET":
                        {
                            //IF_System.Mode = IF_System.MODE.RESET;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            //Trace.WriteLine($"[[{ClassName}.{MethodName} :: Start]]");

            try
            {
                if (Global.Setting != null)
                {
                    lblModelName.Text = $"Model : {Global.Setting.RecipeName}";
                }


                statusCamera.On = true;

                lbl_DateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //lbl_CurrentModeEx.Text = $"ACTION / Current : {IF_System.Mode}";
                if (lbl_Mode.Text != $"{IF_System.Mode}")
                {
                    lbl_Mode.Text = $"{IF_System.Mode}";
                    lblRunState.Text = $"Run State : {IF_System.Mode}";
                }

                if (IF_System.Mode == IF_System.MODE.PAUSE)
                {
                    btnOper_Pause.Enabled = !btnOper_Pause.Enabled;

                    btnOper_Start.Enabled = true;
                    btnOper_Stop.Enabled = true;
                    btnOper_Reset.Enabled = true;

                    lbl_Mode.ForeColor = Color.White;
                }
                else
                {
                    if (IF_System.Mode == IF_System.MODE.AUTO)
                    {
                        btnOper_Pause.Enabled = true;
                        btnOper_Start.Enabled = false;
                        btnOper_Stop.Enabled = true;
                        btnOper_Reset.Enabled = false;
                        pnlTitle.FillColor = pnlTitle.BackColor = Color.Green;

                        lbl_Mode.ForeColor = Color.Lime;
                    }
                    else
                    {
                        btnOper_Pause.Enabled = false;
                        btnOper_Start.Enabled = true;                        
                        btnOper_Stop.Enabled = false;
                        btnOper_Reset.Enabled = true;
                        pnlTitle.FillColor = pnlTitle.BackColor = Color.FromArgb(30, 30, 30);

                        lbl_Mode.ForeColor = Color.White;
                    }
                }

                lblStatus.Text = IF_System.Mode.ToString();
                statusBar.Text = IF_System.Notice;

                if (string.Equals(lblStatus.Text, IF_System.MODE.AUTO.ToString())) lblStatus.ForeColor = Color.Green;
                else if (string.Equals(lblStatus.Text, IF_System.MODE.PAUSE.ToString())) lblStatus.ForeColor = Color.SlateGray;
                else if (string.Equals(lblStatus.Text, IF_System.MODE.STOP.ToString())) lblStatus.ForeColor = Color.DimGray;
                else if (string.Equals(lblStatus.Text, IF_System.MODE.ALARM.ToString())) lblStatus.ForeColor = Color.SlateGray;

                if (IF_System.Mode == IF_System.MODE.AUTO)
                {
                    foreach (var menu in _menuButtons) if (menu.Value.Enabled == true) menu.Value.Enabled = false;
                }
                else
                {
                    foreach (var menu in _menuButtons) if (menu.Value.Enabled == false) menu.Value.Enabled = true;
                }

                processBar_CPU.Value = value_Cpu;
                processBar_RAM.Value = value_Ram;
                processBar_DiskC.Value = value_CDrive;
                processBar_DiskD.Value = value_DDrive;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[[{_thisName}.{MethodName} :: Error]] {ex}");
            }
        }

        private void btnStatusVisible_Click(object sender, EventArgs e)
        {
            //pnlStatus.Visible = !pnlStatus.Visible;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormSub_Login formSub_Login = new FormSub_Login();
            formSub_Login.Show();
        }

        private void uiGroupBox5_Click(object sender, EventArgs e)
        {

        }

        private void btnLogView_Click(object sender, EventArgs e)
        {
            pnlLogViewer.Visible = !pnlLogViewer.Visible;            
        }

        private void pnlMainFrame_Click(object sender, EventArgs e)
        {

        }

        private void timerInit_Tick(object sender, EventArgs e)
        {
            timerInit.Enabled = false;
            
          
        }
    }
}
