using IF_UI.RJControls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormMenu_MainFrame : Form
    {
        private Global Global = Global.Instance;

        RJDragControl _dragTile = new RJDragControl();
        RJDragControl _dragLabel = new RJDragControl();

        private LogViewer logViewList = new LogViewer();

        public FormMenu_MainFrame()
        {
            InitializeComponent();

            _dragTile.DragControl = lblTitle;
            _dragLabel.DragControl = pnlTitle;

            logViewList.Dock = DockStyle.Fill;
            logViewList.Visible = true;

            pnlLog.Controls.Add(logViewList);
            logViewList.SetColumnImageWidth(pnlLog.Width);
        }

        private void FormMenu_MainFrame_Load(object sender, EventArgs e)
        {
            CLogger.Add(LOG.NORMAL, "Start S/W");
            Global.Instance.System.IF_Handle = this.Handle;

            Global.Instance.OnStart_Porgess();
            Global.SeqInitialize = new CSeqInitialize();
            Global.SeqInitialize.EventInitEnd += OnInitEnd;
            Global.SeqRecipeChage.EventRecipeChangeStart += OnRecipeChageStart;
            Global.SeqRecipeChage.EventRecipeChangeEnd += OnRecipeChageEnd;

            Global.System.EventChangedMode += OnChangedMode;

            //.//[2024-10-07 02] 초기상태 Ready 와 같은 색으로 변경함.
            btnAutoStart.Enabled = true;
            btnAutoStart.FillColor = Color.Orange;
            //Global.System.Mode = CSystem.MODE.READY;

            pnlTitle.BackColor = DEFINE.COLOR_ORANGE;
            lblTitle.BackColor = DEFINE.COLOR_ORANGE;
            lblMode.BackColor = DEFINE.COLOR_ORANGE;
            Global.Instance.SetRMS = new Setting_RMS();
            Global.Instance.SetRMS.dicBUFFER_ID_Done = new Dictionary<int, string>();

            lblVersion.Text = $"Build ({IF_Util.GetCompiledDateTime().ToString("yyyy.MM.dd HH:mm:ss")})   \n"
                    + $"Start ({DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")})  \n"
                    + $"V0.0.0 {((Debugger.IsAttached == true) ? "Debug" : "Release")}";
        }

        private void OnInitEnd(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
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
                    FrmSet(Global.Instance.FrmSub);
                    FrmSet(Global.Instance.FrmVision);

                    InitUI();
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }

        private void OnRecipeChageStart(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnRecipeChageStart(sender, e);
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
                    Global.Instance.OnStart_Porgess();
                    Global.Notice = "Model Loading..";
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }

        private void OnRecipeChageEnd(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnRecipeChageEnd(sender, e);
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
                    Global.Instance.OnEnd_Progress();
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
                    this.Invoke(new MethodInvoker(() =>
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
                try
                {
                    switch (Global.System.Mode)
                    {
                        case CSystem.MODE.READY:
                            {
                                Global.SeqVision.ManualInsp = CSeqVision.ManualType.AUTO;
                                Global.SeqVision.SetStepEx("IDLE");
                            }
                            break;
                        case CSystem.MODE.ALARM:
                            {
                                Global.SeqVision.ManualInsp = CSeqVision.ManualType.AUTO;
                                Global.SeqVision.SetStepEx("IDLE");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }

        private bool InitUI()
        {
            try
            {
                string strBuildMode = "";

                EnableMenu(true);

                this.Location = new System.Drawing.Point(0, 0);

                // comboCountry.DataSource = Enum.GetValues(typeof(Setting_Enviroment.COUNTRY));
                comboCountry.SelectedIndex = (int)Global.Setting.Enviroment.Country;


                statusVisionLicense.On = !Global.CognexLicense_Check();
                //lbTitle.Text = $"{Global.EQP_NAME} Ver (1.0.0.0)";
            }
            catch (Exception ex)
            {
                IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            return true;
        }
        // pnMDI에 폼 셋해줌...
        private void FrmSet(Form Frm)
        {
            // 크로스 쓰레드 대비 처리..
            Invoke_Util.Set_Invoke_Panel(pnMDI, Frm);
        }

        private void FormMenu_MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Global.Instance.System.Mode == CSystem.MODE.AUTO)
                {
                    MessageBox.Show("Please Change the Ready of Mode");
                    e.Cancel = true;
                }
                else
                {
                    if (IF_Util.ShowMessageBox("EXIT", "DO YOU WANT TO EXIT?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                    {
                        Global.Instance.Device.DIO_BD.Close();
                        Global.Instance.Device.NGBUFFER.DisConnect();
                        Global.Instance.System.Recipe.SaveConfig();
                        Global.Instance.Close();
                    }
                    else
                    {
                        e.Cancel = true;
                    }

                    this.DialogResult = DialogResult.Ignore;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void OnMenuClick(object sender, EventArgs e)
        {
            UISymbolButton btn = (sender as UISymbolButton);

            //btnMenuMain.BackColor = DEFINE.COLOR_NAVY;
            //btnMenuVisionTeaching.BackColor = DEFINE.COLOR_NAVY;

            Global.SelectedMenu = btn.Text;

            switch (btn.Text)
            {
                case "메인":
                case "MAIN":
                case "Main":
                    //btn.BackColor = DEFINE_COMMON.COLOR_SKY_BLUE;
                    Global.Device.Cameras[0].Live(false);

                    if (Global.Instance.FrmVision != null && Global.Instance.FrmVision.Visible) Global.Instance.FrmVision.Hide();
                    Global.Instance.FrmSub.Show();
                    break;
                case "MODEL":
                    {
                        if (Global.Instance.FrmRecipe == null || !Global.Instance.FrmRecipe.Created)
                        {
                            Global.Instance.FrmRecipe = new FormMenuRecipe();
                        }

                        Global.Instance.FrmRecipe.BringToFront();
                        Global.Instance.FrmRecipe.Owner = this;
                        Global.Instance.FrmRecipe.Show();
                    }
                    break;
                case "비전":
                case "VISION":
                    //btnMenuVisionTeaching.BackColor = DEFINE_COMMON.COLOR_SKY_BLUE;

                    Global.Instance.FrmSub.Hide();

                    if (Global.Instance.FrmVision == null || !Global.Instance.FrmVision.Created)
                    {
                        //Global.Instance.FrmVision = new FormMenu_Vision();
                        Global.Instance.FrmVision = new Form_MenuVision();
                        FrmSet(Global.Instance.FrmVision);
                    }
                    else
                    {
                        if (Global.Instance.FrmVision != null && !Global.Instance.FrmVision.Visible)
                        {
                            Global.Instance.FrmVision.Show();
                        }
                    }
                    break;
                case "RMS":
                    {
                        if (Global.Instance.FrmViewer.Visible)
                        {
                            Global.Instance.FrmViewer.Close();
                        }

                        if (Global.Instance.FrmViewer == null || !Global.Instance.FrmViewer.Created)
                        {
                            Global.Instance.FrmViewer = new FormMenu_Viewer();
                        }

                        Global.Instance.FrmViewer.BringToFront();
                        Global.Instance.FrmViewer.Owner = this;
                        Global.Instance.FrmViewer.Show();

                    }
                    break;
                case "모션":
                case "모터":
                case "MOTION":
                case "DI/DO":
                    {
                        if (Global.Instance.FrmIO == null || !Global.Instance.FrmIO.Created)
                        {
                            Global.Instance.FrmIO = new FormMenu_IO();
                        }

                        Global.Instance.FrmIO.BringToFront();
                        Global.Instance.FrmIO.Owner = this;
                        Global.Instance.FrmIO.Show();
                    }
                    break;
                case "TEACHING":
                case "Teaching":

                    lbRecipeName.Text = Global.Instance.System.Recipe.Name;
                    break;

                case "VIEWER":

                    FormMenu_Viewer FrmViewer = new FormMenu_Viewer();
                    if (FrmViewer != null && !FrmViewer.Visible) FrmViewer.Show();

                    break;
                case "CAMERA":
                    FormPopUp_Settings_Camera FrmCamera = new FormPopUp_Settings_Camera();
                    FrmCamera.ShowDialog();
                    break;

                case "설정":
                case "SETTINGS":
                    {
                        if (Global.Instance.FrmSetting == null || !Global.Instance.FrmSetting.Created)
                        {
                            Global.Instance.FrmSetting = new FormMenu_Settings();
                        }

                        Global.Instance.FrmSetting.BringToFront();
                        Global.Instance.FrmSetting.Owner = this;
                        Global.Instance.FrmSetting.Show();
                    }
                    break;
                case "EXIT":
                case "Exit":
                    if (Global.Instance.System.Mode == CSystem.MODE.AUTO)
                    {
                        Global.Instance.System.Notice = "Can't Close the Program, because Current Mode is Auto";
                        return;
                    }
                    else
                    {
                        this.Close();
                    }

                    break;
            }

        }

        #region TIMER / THREAD

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lbl_DateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string strPbaCode = Global.Instance.System.Recipe.CODE.Replace("\r", "").Replace("\n", "");
            lbRecipeName.Text = $"{Global.Instance.System.Recipe.Name} [{strPbaCode}]";

            try
            {
                if (Global.Instance.System.Authorization == DEFINE.AUTHORIZATION.OPERATOR)
                {
                    btnAuthorization.SymbolColor = btnAuthorization.ForeColor = DEFINE.COLOR_TEAL;
                    btnAuthorization.Text = "OPERATOR";
                }
                else if (Global.Instance.System.Authorization == DEFINE.AUTHORIZATION.ENGINEER)
                {
                    btnAuthorization.SymbolColor = btnAuthorization.ForeColor = DEFINE.COLOR_RED;
                    btnAuthorization.Text = "ENGINEER";
                }
                else if (Global.Instance.System.Authorization == DEFINE.AUTHORIZATION.MASTER)
                {
                    btnAuthorization.SymbolColor = btnAuthorization.ForeColor = DEFINE.COLOR_RED;
                    btnAuthorization.Text = "MASTER";
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }



        private void timerConnection_Tick(object sender, EventArgs e)
        {
            if (Global.System.Mode == CSystem.MODE.AUTO)
            {
                bool deviceCam_Success = true;
                if (Global.Device.Cameras.Count == 0) deviceCam_Success = false;
                if (Global.Device.Cameras[0].IsOpen == false) deviceCam_Success = false;

                if (deviceCam_Success == false)
                {
                    Global.InitCamera();
                    CAlarm.Add("CAMERA", "Camera Disconnected Reset->Auto Click");
                    return;
                }
            }

            //processBar_TrainImage.Maximum = Global.Instance.System.Recipe.TrainFullCount;
            if (Global.Instance.System.Recipe.Task_TrainImage != null)
            {
                if (Global.Instance.System.Recipe.Task_TrainImage.Status == TaskStatus.Running)
                {
                    Global.OnStart_Porgess("Setting Train Image...");
                    pnlMessage.Visible = true;

                    if (Global.Instance.System.Recipe.TrainCount > Global.Instance.System.Recipe.TrainFullCount)
                        Global.Instance.System.Recipe.TrainCount = Global.Instance.System.Recipe.TrainFullCount;

                    //processBar_TrainImage.Value = Global.Instance.System.Recipe.TrainCount;

                    lblMessage.Text = $"Array ({Global.Instance.System.Recipe.TrainArrayIndex + 1}/{Global.Instance.System.Recipe.ArrayCount}) Trainning";
                }
                else
                {
                    if (Global.Progress.desc == "Setting Train Image...")
                        Global.OnEnd_Progress();

                    pnlMessage.Visible = false;
                }
            }

            // License Key In 상태 체크
            // Cognex License가 없을때...인터락 메세지 표시..


            // ARC 연결 상태 표시

            statusMES.On = ARC_Control.IsRun;
            statusEyeD.On = (Global.Device.EyeD != null && Global.Device.EyeD.IsOpen);
            statusCamera.On = (Global.Instance.Device.Cameras != null && Global.Instance.Device.Cameras.Count > 0 && Global.Instance.Device.Cameras[0] != null && Global.Device.Cameras[0].IsOpen);
            statusLightController.On = (Global.Instance.Device.LightController != null && Global.Device.LightController.IsOpen);
            statusIO.On = (Global.Instance.Device.DIO_BD != null && Global.Device.DIO_BD.IsOpen);
            statusBuffer.On = (Global.Instance.Device.NGBUFFER != null && Global.Device.NGBUFFER.IsOpen);
        }

        #endregion TIMER / THREAD

        #region FUNCTION

        private bool EnableMenu(bool bEnable = true)
        {
            try
            {
                btnMenu_Main.Enabled = bEnable;
                btnMenu_Model.Enabled = bEnable;
                btnMenu_Device.Enabled = bEnable;
                btnMenu_Setting.Enabled = bEnable;
                //btnMenuVisionTeaching.Enabled = bEnable;
                //btnMenuClose.Enabled = bEnable;
                //btnViewer.Enabled = bEnable;

                btnAuthorization.Enabled = bEnable;

                //if (Global.System.Authorization == DEFINE.AUTHORIZATION.OPERATOR) btnMenuModel.Enabled = false;
                //if (Global.System.Authorization == DEFINE.AUTHORIZATION.OPERATOR) btnMenuModel.Enabled = false;
                //if (Global.System.Authorization == DEFINE.AUTHORIZATION.OPERATOR) btnMenuIO.Enabled = false;
                //if (Global.System.Authorization == DEFINE.AUTHORIZATION.OPERATOR) btnMenuSetting.Enabled = false;
                //if (Global.System.Authorization == DEFINE.AUTHORIZATION.OPERATOR) btnMenuVisionTeaching.Enabled = false;

                //IGlobal.Instance.FileManager.CountLoad();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

            return true;
        }

        #endregion FUNCTION

        private void timerAlarm_Tick(object sender, EventArgs e)
        {
            pnlMessage.Visible = CAlarm.Exists;

            if (CAlarm.Exists)
            {
                Global.Data.StopReason = "STOP BY ALARM";

                string strCode = CAlarm.GetLastAlarm().Item1;
                string strDesc = CAlarm.GetLastAlarm().Item2;

                btnOper_Reset.Visible = statusAlarm.Visible = true;
                lblMessage.Text = $"ALARM : {strDesc}";

                if (Global.System.Mode != CSystem.MODE.ALARM) Global.System.Mode = CSystem.MODE.ALARM;

                //[2024-10-07 01] Auto 의 경우 Green 상태임, 중지시 Orange 로 변경되었기에 둘다 적용하기 위해 Red 아닌것으로 판단함
                if (btnAutoStart.FillColor != Color.Red) //if (btnAutoStart.FillColor == Color.Green)
                {
                    btnAutoStart.Enabled = true;
                    btnAutoStart.FillColor = Color.Red;

                    pnlTitle.BackColor = DEFINE.COLOR_RED;
                    lblTitle.BackColor = DEFINE.COLOR_RED;
                }
            }
            else
            {
                btnOper_Reset.Visible = statusAlarm.Visible = false;
                lblMessage.Text = $"IDLE";
            }
        }

        private void btnCameraInit_Click(object sender, EventArgs e)
        {
            try
            {
                Global.Instance.InitCamera();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Global.m_MainPJTRoot);
        }

        private void btnMenuClose_Click(object sender, EventArgs e)
        {
            if (IF_Util.ShowMessageBox("Close", "Do you want to close?"))
            {
                Global.Setting.Enviroment.Save();

                if (Global.System.Mode == CSystem.MODE.AUTO)
                {
                    IF_Util.ShowMessageBox("Notice", "Can't Close the Program, because Current Mode is Auto");
                    return;
                }
                else
                {
                    CLogger.Add(LOG.NORMAL, "S/W Close");
                    Global.Instance.Data.SaveConfig();
                    Global.FileManager.CountSave(Global.Data);
                    Global.Close();
                    //Global.Instance.Data.SaveConfig();
                    this.Close();
                }
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void comboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Global.Setting.Enviroment.Country = (Setting_Enviroment.COUNTRY)Enum.Parse(typeof(Setting_Enviroment.COUNTRY), comboCountry.SelectedItem.ToString());
                Global.Setting.Enviroment.Save();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnAutoStart_Click(object sender, EventArgs e)
        {
            bool deviceCam_Success = true;
            if (Global.Device.Cameras.Count == 0)
            {
                deviceCam_Success = false;
            }
            else
            {
                if (Global.Device.Cameras[0].IsOpen == false) deviceCam_Success = false;
            }

            if (deviceCam_Success == false)
            {
                Global.InitCamera();
                IF_Util.ShowMessageBox("Device Init", "Please wait the connection of camera", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                return;
            }
#if !TEST
            if (Global.Instance.System.Recipe.Task_TrainImage != null)
            {
                if (Global.Instance.System.Recipe.Task_TrainImage.Status == TaskStatus.Running)
                {
                    IF_Util.ShowMessageBox("Auto Inspec", $"Setting the Train image.{Environment.NewLine}Please wait a moment!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                    return;
                }
            }


            if (!Global.Instance.Device.DIO_BD.IsOpen)
            {
                IF_Util.ShowMessageBox("Auto Inspec", "DIO Board Not Connect..DIO Board Check Please!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                return;
            }
#endif
            try
            {
                if (Global.Instance.SeqVision != null)
                {
                    Global.Instance.SeqVision.SetStepEx("IDLE");
                    Global.Instance.SeqVision.ManualInsp = CSeqVision.ManualType.AUTO;
                }

                CAlarm.Clear();

                if (Global.System.Recipe.FiducialLibrary.Fiducial1.ImageTemplate == null || Global.System.Recipe.FiducialLibrary.Fiducial1.ImageTemplate.Width == 0)
                {
                    IF_Util.ShowMessageBox("Error", "Have to set Fiducial (L) First");
                    return;
                }

                if (Global.System.Recipe.FiducialLibrary.Fiducial2.ImageTemplate == null || Global.System.Recipe.FiducialLibrary.Fiducial2.ImageTemplate.Width == 0)
                {
                    IF_Util.ShowMessageBox("Error", "Have to set Fiducial (R) First");
                    return;
                }
                if (Global.System.Mode != CSystem.MODE.AUTO)
                {
                    if (IF_Util.ShowMessageBox("Auto Run", "Auto Inspection Start?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                    {
                        Global.Data.StopReason = "NORMAL";
                        Global.Device.Cameras[0].Live(false);

                        btnAutoStart.Enabled = true;
                        btnAutoStart.FillColor = Color.Green;

                        Global.System.Mode = CSystem.MODE.AUTO;

                        pnlTitle.BackColor = Color.Green;
                        lblTitle.BackColor = Color.Green;
                    }
                }
                else
                {
                    if (IF_Util.ShowMessageBox("Mode Chnage", "Auto Inspection Stop?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                    {
                        Global.Data.StopReason = "STOP BY BUTTON";
                        btnAutoStart.Enabled = true;
                        btnAutoStart.FillColor = Color.Orange;
                        Global.System.Mode = CSystem.MODE.READY;

                        pnlTitle.BackColor = DEFINE.COLOR_ORANGE;
                        lblTitle.BackColor = DEFINE.COLOR_ORANGE;
                        lblMode.BackColor = DEFINE.COLOR_ORANGE;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

        }
        private void btnAutoStop_Click(object sender, EventArgs e)
        {
            if (IF_Util.ShowMessageBox("Mode Chnage", "Auto Inspection Stop?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
            {
                btnAutoStart.Enabled = true;
                //btnAutoStop.Enabled = false;

                Global.System.Mode = CSystem.MODE.READY;

                pnlTitle.BackColor = DEFINE.COLOR_RED;
                lblTitle.BackColor = DEFINE.COLOR_RED;
            }
        }

        private void btnCountReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("TOTAL COUNT RESET", "Reset the total count Daily?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    Global.FileManager.CountSave_Log(Global.Data);
                    Global.Instance.Data.ResetTotalCount();

                    lbCountTOTAL.Text = (Global.Instance.Data.CountOK + Global.Instance.Data.CountNG_F).ToString();
                    lbCountOK.Text = Global.Instance.Data.CountOK.ToString();
                    lbCountNG_F.Text = Global.Instance.Data.CountNG_F.ToString();

                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void OnChangeCount()
        {
            try
            {
                String daily_Reset = DateTime.Now.ToString("yyyyMMdd:HH");
                String daily_Time = DateTime.Now.Hour.ToString();
                String Monthly_Reset = DateTime.Now.ToString("yyyyMM");
                lbCountOK.Text = Global.Instance.Data.CountOK.ToString();
                lbCountNG_F.Text = Global.Instance.Data.CountNG_F.ToString();
                lbCountTOTAL.Text = (Global.Instance.Data.CountOK + Global.Instance.Data.CountNG_F).ToString();

                lbOK_M.Text = Global.Instance.Data.CountOK_M.ToString();
                lbNG_M.Text = Global.Instance.Data.CountNG_M.ToString();
                lbTotal_M.Text = (Global.Instance.Data.CountOK_M + Global.Instance.Data.CountNG_M).ToString(); 

                if (Global.Instance.Data.CountNG_F == 0)
                {
                    lbCountYield.Text = "100.00 %";
                    Global.Instance.Data.yield = "100";
                }
                else
                {
                    double dYield1 = ((double)(Global.Instance.Data.CountOK) / (double)(Global.Instance.Data.CountOK +  Global.Instance.Data.CountNG_F) * 100.0D);
                    lbCountYield.Text = dYield1.ToString("F2") + " %";
                    Global.Instance.Data.yield = dYield1.ToString("F2");
                }
                if (Global.Instance.Data.CountNG_M == 0)
                {
                    lbYield_M.Text = "100.00 %";
                    Global.Instance.Data.CountYield_M = "100";
                }
                else
                {
                    double dYield = ((double)(Global.Instance.Data.CountOK_M) / (double)(Global.Instance.Data.CountOK_M +  Global.Instance.Data.CountNG_M) * 100.0D);
                    lbYield_M.Text = dYield.ToString("F2") + " %";
                    Global.Instance.Data.CountYield_M = dYield.ToString("F2");
                }
                if (Global.Instance.Mode.Count_Reset_D == int.Parse(daily_Time) && Global.Instance.Data.Last_Reset_D != daily_Reset && Global.FileManager.bLoad == true)
                {
                    Global.FileManager.CountSave_Log(Global.Data);
                    Global.Instance.Data.Last_Reset_D = daily_Reset;
                    Global.Instance.Data.ResetTotalCount();

                    lbCountTOTAL.Text = (Global.Instance.Data.CountOK + Global.Instance.Data.CountNG_F).ToString();
                    lbCountOK.Text = Global.Instance.Data.CountOK.ToString();
                    lbCountNG_F.Text = Global.Instance.Data.CountNG_F.ToString();
                }
                if (Global.Instance.Mode.Count_Reset_M == int.Parse(daily_Time) && Global.Instance.Data.Last_Reset_M != Monthly_Reset && Global.FileManager.bLoad == true)
                {
                    Global.FileManager.CountSave_Log(Global.Data);

                    Global.Instance.Data.Last_Reset_M = Monthly_Reset;
                    Global.Instance.Data.ResetTotalCount_M();

                    lbTotal_M.Text = (Global.Instance.Data.CountOK_M + Global.Instance.Data.CountNG_M).ToString();
                    lbOK_M.Text = Global.Instance.Data.CountOK_M.ToString();
                    lbNG_M.Text = Global.Instance.Data.CountNG_M.ToString();
                }

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            OnChangeCount();

#if DEBUG
            string buildedMode = "DEBUG";
#else
            string buildedMode = "RELEASE";
#endif
            lblTitle.Text = $"[{Global.System.Mode.ToString()}] {Global.EQP_NAME} Ver ({IF_Util.GetCompiledDateTime().ToString("yyyy.MM.dd HH:mm")}) - {buildedMode}";
            lblStopReason.Text = $"STOP REASON : {Global.Data.StopReason}";

            if (Global.System.Mode == CSystem.MODE.AUTO)
            {
                if (lblMode.Text != "AUTO")
                {
                    lblStatusMode.Text = lblMode.Text = "AUTO";
                    lblMode.BackColor = Color.Green;
                }
            }
            else if (Global.System.Mode == CSystem.MODE.READY)
            {
                if (lblMode.Text != "READY")
                {
                    lblStatusMode.Text = lblMode.Text = "READY";
                    lblMode.BackColor = Color.DimGray;
                }
            }
            else if (Global.System.Mode == CSystem.MODE.ALARM)
            {
                if (lblMode.Text != "ALARM") lblStatusMode.Text = lblMode.Text = "ALARM";

                if (lblMode.BackColor == Color.Orange) lblMode.BackColor = Color.IndianRed;
                else lblMode.BackColor = Color.Orange;
            }

            //if (Global.System.Authorization == DEFINE.AUTHORIZATION.OPERATOR)
            //{
            //    btnLogin.ForeColor = lbAuthorization.ForeColor = Color.DimGray;
            //    lbAuthorization.RectColor = Color.DimGray;
            //    lbAuthorization.Text = "Operator";
            //}
            //else if (Global.System.Authorization == DEFINE.AUTHORIZATION.ENGINEER)
            //{
            //    btnLogin.ForeColor = lbAuthorization.ForeColor = Color.Yellow;
            //    lbAuthorization.RectColor = Color.Yellow;
            //    lbAuthorization.Text = "Enginner";
            //}
            //else if (Global.System.Authorization == DEFINE.AUTHORIZATION.MASTER)
            //{
            //    btnLogin.ForeColor = lbAuthorization.ForeColor = DEFINE.COLOR_RED;
            //    lbAuthorization.RectColor = DEFINE.COLOR_RED;
            //    lbAuthorization.Text = "Master";
            //}

            if (Global.SeqVision != null)
            {
                lblSeqStatus.Text = $"VISION SEQUENCE : {Global.SeqVision.SeqIndex}";
            }
        }

        private void btnScreenCapture_Click(object sender, EventArgs e)
        {
            IF_Util.SaveCaptureScreen($"{Application.StartupPath}\\CAPTURE\\ScreenCapture_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}");
            UINotifier.Show($"Complete Screen Capture");
        }

        private void lbl_ARC_Click(object sender, EventArgs e)
        {
            // ARC TESTER 화면을 연다...
            if (Global.Instance.Frm_ARC_Tester == null || !Global.Instance.Frm_ARC_Tester.Created)
            {
                Global.Instance.Frm_ARC_Tester = new FormMenu_ARC_Tester();
            }

            Global.Instance.Frm_ARC_Tester.BringToFront();
            Global.Instance.Frm_ARC_Tester.Owner = this;
            Global.Instance.Frm_ARC_Tester.Show();
        }

        private void btnCountrySave_Click(object sender, EventArgs e)
        {
            Global.Setting.Enviroment.Save();
        }

        private void lblMode_DoubleClick(object sender, EventArgs e)
        {
            if (Global.System.Mode == CSystem.MODE.ALARM && IF_Util.ShowMessageBox("ALARM", "Do you want reset alarm?"))
            {
                CAlarm.Clear();
                Global.System.Mode = CSystem.MODE.READY;
                btnAutoStart.FillColor = Color.Orange;
                pnlTitle.BackColor = DEFINE.COLOR_ORANGE;
                lblTitle.BackColor = DEFINE.COLOR_ORANGE;

            }

        }


        private void btnAlarmReset_Click(object sender, EventArgs e)
        {
            CAlarm.Clear();
            Global.System.Mode = CSystem.MODE.READY;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                Global.System.Authorization = DEFINE.AUTHORIZATION.MASTER;
                return;
            }

            if (Global.System.Mode == CSystem.MODE.AUTO)
                return;
        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            IF_Util.SaveCaptureScreen($"{Application.StartupPath}\\CAPTURE\\ScreenCapture_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}");
            UINotifier.Show($"Complete Screen Capture");
        }

        private void lblRecipeLoading_Click(object sender, EventArgs e)
        {

        }

        private void btnCountReset_M_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("TOTAL COUNT RESET", "Reset the total count Monthly?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    Global.FileManager.CountSave_Log(Global.Data);
                    Global.Instance.Data.ResetTotalCount_M();

                    lbTotal_M.Text = (Global.Instance.Data.CountOK_M + Global.Instance.Data.CountNG_M).ToString();
                    lbOK_M.Text = Global.Instance.Data.CountOK_M.ToString();
                    lbNG_M.Text = Global.Instance.Data.CountNG_M.ToString();
                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnLogView_Click(object sender, EventArgs e)
        {
            pnlLogViewer.Visible = !pnlLogViewer.Visible;
        }
    }
}