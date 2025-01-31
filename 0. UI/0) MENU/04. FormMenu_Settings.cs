using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormMenu_Settings : Form
    {
        private Global Global = Global.Instance;
        List<string> mStrComport = new List<string>();
        // 데이터를 변경한 상태 플러그...
        bool nDataChange = false;

        public FormMenu_Settings()
        {
            InitializeComponent();

        }

        private void FormMenuSettings_Load(object sender, EventArgs e)
        {
            FileDelData_Load();
            SerialConfig_Load();

            chkRmsMode.Checked = Global.Mode.UseRms;
            chkForceJudge.Checked = Global.Mode.isForceJudge;
            if (Global.Mode.AutoJudge)
                cboAutoJudge.SelectedIndex = 1;
            else
                cboAutoJudge.SelectedIndex = 0;

            chkQrPass.Checked = Global.Mode.QrPass;
            chkQRModelVerify.Checked = Global.Mode.QRModelVerify;
            chkDebugMode.Checked = Global.Mode.isDebugMode;
            txtInspDelay.Text = Global.Setting.Equipment.DelayTime_PrevInsp.ToString();
            chkResultVisibleMode.Checked = Global.Mode.ResultVisible;
            chkNGRecent.Checked = Global.Mode.NGisRecent;
            AvailHdd.Text = Global.Mode.availHdd.ToString();
            DeleteFileCnt.Text = Global.Mode.deleteFileN.ToString();
            tbRMSMargin.Text = Global.Mode.RMSMargin.ToString();
            //cboSite.SelectedIndex = Convert.ToInt32(Global.Mode.posSite);
            chkResultAlarm.Checked = Global.Mode.ResultAlarm;
            AlarmRatio.Text = Global.Mode.alarmRatio.ToString();
            chkJudgeEnd.Checked = Global.Mode.isJudgeScreenShot;
            chkAddEnablechk.Checked = Global.Mode.isAddEnable;
            if (chkNGRecent.Checked)
                this.chkNGRecent.Text = $"NG -> RecentImage(Save)";
            else
                this.chkNGRecent.Text = $"ALL -> RecentImage(Save)";
            chkQRText.Checked = Global.Mode.QRCheck;
            edtQRCheck.Text = Global.Mode.QRCheckText;
            chkSimulRMS.Checked = Global.Mode.isSimulRMS;
            //chkRMSPopUp.Checked = Global.Mode.isRMSAutoPopup;

            // 추가
            chb_ReInspec_Use.Checked = Global.Mode.ReInspecUse;
            txt_ReInspec_cnt.Text = Global.Mode.ReInspecCnt.ToString();
            lbl_ImageSavePath.Text = Global.m_ImageFileRoot;
            txtDailyReset.Text = Global.Mode.Count_Reset_D.ToString();
            txtMonthlyReset.Text = Global.Mode.Count_Reset_M.ToString();

            // RMS 체크박스 상태 디스플레이
            chb_RMS_CallStage_RetestUse.Checked = Global.Instance.Mode.IsRMS_CallStage_ReTest;
            chb_RMS_NGBuffer_RetestUse.Checked = Global.Instance.Mode.IsRMS_NGBUFFER_ReTest;
            chb_RMS_BoardOutUse.Checked = Global.Instance.Mode.IsRMS_BoardOut;
            chb_RMS_BoardPassUse.Checked = Global.Instance.Mode.IsRMS_BoardPass;
            chb_RMS_FinalOKUse.Checked = Global.Instance.Mode.IsRMS_FinalOk;

            chb_NGBuffer_Type.Checked = Global.Instance.Mode.NG_Buffer_Type;

            // TCP 추가
            txt_ARC_IP.Text = Global.m_ARC_IP;
            txt_ARC_Port.Text = Global.m_ARC_PORT;
            txt_EQPNAME.Text = Global.EQP_NAME;
            chb_ARC_Use.Checked = Global.m_ARC_USE;

            txtEyeD_IP.Text = Global.Setting.Enviroment.EyeD.ServerIP;
            txtEyeD_Port.Text = Global.Setting.Enviroment.EyeD.ServerPort.ToString();
        }

        // File Del에 관련된 내용 로드
        private void FileDelData_Load()
        {
            // 해당 드라이브가 있는지 체크..
            if (!Global.m_DriverC.DriverUse)
            {
                grb_FileDel_C.Enabled = false;
                lbl_FileDel_Path_C.Text = "-";
                txtFileDelStorageDay_C.Text = "0";
                txtFileDelTime_C.Text = "1";
                txtFileDelHDD_C.Text = "0";
                chbFileDelEnabled_C.Checked = false;
            }
            else
            {
                lbl_FileDel_Path_C.Text = Global.m_FileDel_C.FileDel_Path;
                txtFileDelStorageDay_C.Text = Global.m_FileDel_C.FileDel_Day.ToString();
                txtFileDelTime_C.Text = Global.m_FileDel_C.FileDel_Time.ToString();
                txtFileDelHDD_C.Text = Global.m_FileDel_C.HDD.ToString();
                chbFileDelEnabled_C.Checked = Global.m_FileDel_C.FileDel_Enabled;
            }

            if (!Global.m_DriverD.DriverUse)
            {
                grb_FileDel_D.Enabled = false;
                lbl_FileDel_Path_D.Text = "-";
                txtFileDelStorageDay_D.Text = "0";
                txtFileDelTime_D.Text = "1";
                txtFileDelHDD_D.Text = "0";
                chbFileDelEnabled_D.Checked = false;
            }
            else
            {
                lbl_FileDel_Path_D.Text = Global.m_FileDel_D.FileDel_Path;
                txtFileDelStorageDay_D.Text = Global.m_FileDel_D.FileDel_Day.ToString();
                txtFileDelTime_D.Text = Global.m_FileDel_D.FileDel_Time.ToString();
                txtFileDelHDD_D.Text = Global.m_FileDel_D.HDD.ToString();
                chbFileDelEnabled_D.Checked = Global.m_FileDel_D.FileDel_Enabled;
            }

            if (!Global.m_DriverE.DriverUse)
            {
                grb_FileDel_E.Enabled = false;
                lbl_FileDel_Path_E.Text = "-";
                txtFileDelStorageDay_E.Text = "0";
                txtFileDelTime_E.Text = "1";
                txtFileDelHDD_E.Text = "0";
                chbFileDelEnabled_E.Checked = false;
            }
            else
            {
                lbl_FileDel_Path_E.Text = Global.m_FileDel_E.FileDel_Path;
                txtFileDelStorageDay_E.Text = Global.m_FileDel_E.FileDel_Day.ToString();
                txtFileDelTime_E.Text = Global.m_FileDel_E.FileDel_Time.ToString();
                txtFileDelHDD_E.Text = Global.m_FileDel_E.HDD.ToString();
                chbFileDelEnabled_E.Checked = Global.m_FileDel_E.FileDel_Enabled;
            }
        }

        // 폴더 선택...
        private void btnFilePathSelect_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            string path = Util.Select_Path();

            if (path != "")
            {
                switch (btn.Name)
                {
                    case "btnFileDelPathSelect_C":
                        {
                            if (!path.Contains("C:\\"))
                            {
                                IF_Util.ShowMessageBox("File Delete Paht Select", "NO C Driver! C Driver Select!!");
                                return;
                            }

                            lbl_FileDel_Path_C.Text = path;
                        }
                        break;

                    case "btnFileDelPathSelect_D":
                        {
                            if (!path.Contains("D:\\"))
                            {
                                IF_Util.ShowMessageBox("File Delete Paht Select", "NO D Driver! D Driver Select!!");
                                return;
                            }

                            lbl_FileDel_Path_D.Text = path;
                        }
                        break;

                    case "btnFileDelPathSelect_E":
                        {
                            if (!path.Contains("E:\\"))
                            {
                                IF_Util.ShowMessageBox("File Delete Paht Select", "NO E Driver! E Driver Select!!");
                                return;
                            }

                            lbl_FileDel_Path_E.Text = path;
                        }
                        break;

                    case "btnImageDriverPath":
                        {
                            lbl_ImageSavePath.Text = path;
                        }
                        break;
                }
            }

        }

        // File Del값 셋팅..
        private void FileDel_Data_Set()
        {
            // 해당 드라이브가 있는지 체크..
            if (Global.m_DriverC.DriverUse)
            {
                Global.m_FileDel_C.FileDel_Path = lbl_FileDel_Path_C.Text;
                Global.m_FileDel_C.FileDel_Day = int.Parse(txtFileDelStorageDay_C.Text);
                Global.m_FileDel_C.FileDel_Time = int.Parse(txtFileDelTime_C.Text);
                Global.m_FileDel_C.HDD = int.Parse(txtFileDelHDD_C.Text);
                Global.m_FileDel_C.FileDel_Enabled = chbFileDelEnabled_C.Checked;
            }

            if (Global.m_DriverD.DriverUse)
            {
                Global.m_FileDel_D.FileDel_Path = lbl_FileDel_Path_D.Text;
                Global.m_FileDel_D.FileDel_Day = int.Parse(txtFileDelStorageDay_D.Text);
                Global.m_FileDel_D.FileDel_Time = int.Parse(txtFileDelTime_D.Text);
                Global.m_FileDel_D.HDD = int.Parse(txtFileDelHDD_D.Text);
                Global.m_FileDel_D.FileDel_Enabled = chbFileDelEnabled_D.Checked;
            }

            if (Global.m_DriverE.DriverUse)
            {
                Global.m_FileDel_E.FileDel_Path = lbl_FileDel_Path_E.Text;
                Global.m_FileDel_E.FileDel_Day = int.Parse(txtFileDelStorageDay_E.Text);
                Global.m_FileDel_E.FileDel_Time = int.Parse(txtFileDelTime_E.Text);
                Global.m_FileDel_E.HDD = int.Parse(txtFileDelHDD_E.Text);
                Global.m_FileDel_E.FileDel_Enabled = chbFileDelEnabled_E.Checked;
            }
        }

        // File Del값 저장
        private void FileDelData_Set()
        {
            // 데이터 셋...
            FileDel_Data_Set();

            CRegistry.Registry_Data_Write(Global.Registry_FileDel_C_Name, Global.Registry_FileDel_Path_Key, Global.m_FileDel_C.FileDel_Path);
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_D_Name, Global.Registry_FileDel_Path_Key, Global.m_FileDel_D.FileDel_Path);
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_E_Name, Global.Registry_FileDel_Path_Key, Global.m_FileDel_E.FileDel_Path);

            CRegistry.Registry_Data_Write(Global.Registry_FileDel_C_Name, Global.Registry_FileDel_Day_Key, Global.m_FileDel_C.FileDel_Day.ToString());
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_D_Name, Global.Registry_FileDel_Day_Key, Global.m_FileDel_D.FileDel_Day.ToString());
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_E_Name, Global.Registry_FileDel_Day_Key, Global.m_FileDel_E.FileDel_Day.ToString());

            CRegistry.Registry_Data_Write(Global.Registry_FileDel_C_Name, Global.Registry_FileDel_Time_Key, Global.m_FileDel_C.FileDel_Time.ToString());
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_D_Name, Global.Registry_FileDel_Time_Key, Global.m_FileDel_D.FileDel_Time.ToString());
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_E_Name, Global.Registry_FileDel_Time_Key, Global.m_FileDel_E.FileDel_Time.ToString());

            CRegistry.Registry_Data_Write(Global.Registry_FileDel_C_Name, Global.Registry_FileDel_HDD_Key, Global.m_FileDel_C.HDD.ToString());
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_D_Name, Global.Registry_FileDel_HDD_Key, Global.m_FileDel_D.HDD.ToString());
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_E_Name, Global.Registry_FileDel_HDD_Key, Global.m_FileDel_E.HDD.ToString());

            CRegistry.Registry_Data_Write(Global.Registry_FileDel_C_Name, Global.Registry_FileDel_Enabled_Key, Global.m_FileDel_C.FileDel_Enabled.ToString());
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_D_Name, Global.Registry_FileDel_Enabled_Key, Global.m_FileDel_D.FileDel_Enabled.ToString());
            CRegistry.Registry_Data_Write(Global.Registry_FileDel_E_Name, Global.Registry_FileDel_Enabled_Key, Global.m_FileDel_E.FileDel_Enabled.ToString());
        }

        private void FileImageSavePath_Set()
        {
            // 현재 써진 데이터 셋...
            Global.m_ImageFileRoot = lbl_ImageSavePath.Text;

            CRegistry.Registry_Data_Write(Global.Registry_ImageFileSave_Name, Global.Registry_ImageFileSave_Key, Global.m_ImageFileRoot);
        }

        // 시리얼 관련 로드...
        private void SerialConfig_Load()
        {
            // ComPort List Initialize ----------------------------------------
            combo_light_comport.Items.Clear();
            combo_NGBUFFER_comport.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                mStrComport.Add(s);
            }

            combo_light_comport.Items.AddRange(mStrComport.ToArray());
            combo_NGBUFFER_comport.Items.AddRange(mStrComport.ToArray());

            int value = (int)CSerial_Registry.COM_PORT_Name.LightController;
            combo_light_comport.Text = Global.Instance.Device.m_COM[value].m_com_port;
            combo_light_baudrate.Text = Global.Instance.Device.m_COM[value].m_com_baudrate.ToString();
            combo_light_Parity.Text = Global.Instance.Device.m_COM[value].m_com_parity.ToString();
            combo_light_StopBits.Text = Global.Instance.Device.m_COM[value].m_com_stopbits.ToString();
            txt_light_DataBits.Text = Global.Instance.Device.m_COM[value].m_com_databits.ToString();

            value = (int)CSerial_Registry.COM_PORT_Name.NG_Buffer;
            combo_NGBUFFER_comport.Text = Global.Instance.Device.m_COM[value].m_com_port;
            combo_NGBUFFER_baudrate.Text = Global.Instance.Device.m_COM[value].m_com_baudrate.ToString();
            combo_NGBUFFER_Parity.Text = Global.Instance.Device.m_COM[value].m_com_parity.ToString();
            combo_NGBUFFER_StopBits.Text = Global.Instance.Device.m_COM[value].m_com_stopbits.ToString();
            txt_NGBUFFER_DataBits.Text = Global.Instance.Device.m_COM[value].m_com_databits.ToString();
        }

        private void SetData()
        {
            int value = (int)CSerial_Registry.COM_PORT_Name.LightController;
            Global.Instance.Device.m_COM[value].m_com_port = combo_light_comport.Text;
            Global.Instance.Device.m_COM[value].m_com_baudrate = int.Parse(combo_light_baudrate.Text);
            Global.Instance.Device.m_COM[value].m_com_parity = (Parity)Enum.Parse(typeof(Parity), combo_light_Parity.Text);
            Global.Instance.Device.m_COM[value].m_com_stopbits = (StopBits)Enum.Parse(typeof(StopBits), combo_light_StopBits.Text);
            Global.Instance.Device.m_COM[value].m_com_databits = int.Parse(txt_light_DataBits.Text);

            value = (int)CSerial_Registry.COM_PORT_Name.NG_Buffer;
            Global.Instance.Device.m_COM[value].m_com_port = combo_NGBUFFER_comport.Text;
            Global.Instance.Device.m_COM[value].m_com_baudrate = int.Parse(combo_NGBUFFER_baudrate.Text);
            Global.Instance.Device.m_COM[value].m_com_parity = (Parity)Enum.Parse(typeof(Parity), combo_NGBUFFER_Parity.Text);
            Global.Instance.Device.m_COM[value].m_com_stopbits = (StopBits)Enum.Parse(typeof(StopBits), combo_NGBUFFER_StopBits.Text);
            Global.Instance.Device.m_COM[value].m_com_databits = int.Parse(txt_NGBUFFER_DataBits.Text);

            CSerial_Registry.m_Com = Global.Instance.Device.m_COM.ToArray();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FormPopUp_MessageBox FrmMessageBox = new FormPopUp_MessageBox("RECIPE", string.Format("Do you want to Save the Mode?"));
                if (FrmMessageBox.ShowDialog() == DialogResult.OK)
                {
                    Global.Mode.SaveConfig();

                    nDataChange = false;
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (nDataChange)
            {
                IF_Util.ShowMessageBox("CHECK", "Data Change..Setting Data Save Please!!");
                return;
            }

            Global.Instance.FrmSub.Init_CogDisplayVisible();

            Close();
        }

        private void chkRmsMode_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.UseRms = chkRmsMode.Checked;
        }

        private void chkQrPass_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.QrPass = chkQrPass.Checked;
        }

        private void chkResultVisibleMode_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.ResultVisible = chkResultVisibleMode.Checked;
        }

        private void chkDebugMode_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.isDebugMode = chkDebugMode.Checked;
        }

        private void txtAvail_TextChanged(object sender, EventArgs e)
        {
            Global.Mode.availHdd = double.Parse(AvailHdd.Text);
        }

        private void txtNDelete_TextChanged(object sender, EventArgs e)
        {
            Global.Mode.deleteFileN = int.Parse(DeleteFileCnt.Text);
        }

        private void chkResultAlarm_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.ResultAlarm = chkResultAlarm.Checked;
        }

        private void AlarmRatio_TextChanged(object sender, EventArgs e)
        {
            Global.Mode.alarmRatio = double.Parse(AlarmRatio.Text);
        }

        private void chkJudgeEnd_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.isJudgeScreenShot = chkJudgeEnd.Checked;
        }
        private void chkAddEnablechk_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.isAddEnable = chkAddEnablechk.Checked;
        }
        private void chkNGRecent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNGRecent.Checked)
                chkNGRecent.Text = $"NG -> RecentImage(Save)";
            else
                chkNGRecent.Text = $"ALL -> RecentImage(Save)";

            Global.Mode.NGisRecent = chkNGRecent.Checked;
        }

        private void chkQRText_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.QRCheck = chkQRText.Checked;
        }

        private void edtQRCheck_TextChanged(object sender, EventArgs e)
        {
            Global.Mode.QRCheckText = edtQRCheck.Text;
        }

        private void chkSimulRMS_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.isSimulRMS = chkSimulRMS.Checked;
        }

        private void tbRMSMargin_TextChanged(object sender, EventArgs e)
        {
            Global.Mode.RMSMargin = int.Parse(tbRMSMargin.Text);
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.Image = Properties.Resources.Save50_MouseHover;
            btnSave.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.Image = Properties.Resources.Save50_Normal;
            btnSave.ForeColor = Color.White;
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.Cancel50_MouseHover;
            btnClose.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.Cancel50_Normal;
            btnClose.ForeColor = Color.White;
        }

        private void cboAutoJudge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAutoJudge.SelectedIndex == 0)
                Global.Mode.AutoJudge = false;          // NG
            else
                Global.Mode.AutoJudge = true;           // OK
        }

        private void chkForceJudge_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.isForceJudge = chkForceJudge.Checked;
        }

        private void chkInspect_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkInspect.Checked)
                chkForceJudge.Checked = Global.Mode.isForceJudge = true;
        }


        private void chkQRModelVerify_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.QRModelVerify = chkQRModelVerify.Checked;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string _log = "-";

            if (!SerialValue_Check())
            {
                IF_Util.ShowMessageBox("Serial Value Check", "Serial Data Change!! Data Save Please!!");
                return;
            }

            switch (btn.Name)
            {
                case "btn_light_Connect":
                    {
                        if (Global.Instance.Device.LightController == null)
                        {
                            Global.Instance.Device.LightController = new ImageFocusLightController();            // 조명 컨트롤러 드라이버 클래스 다시 생성함
                            Global.Instance.Device.LightController.Connect();

                            if (Global.Instance.Device.LightController.SerialOpen)
                            {
                                _log = "[LIGHT] Light Contoler Connect!!";
                            }
                            else
                            {
                                _log = "[LIGHT] Light Contoler Not Connect!!!";
                            }
                        }
                        else
                        {
                            if (!Global.Instance.Device.LightController.SerialOpen)
                            {
                                Global.Instance.Device.LightController = null;       // 할당 해지
                                Global.Instance.Device.LightController = new ImageFocusLightController();            // 조명 컨트롤러 드라이버 클래스 다시 생성함
                                Global.Instance.Device.LightController.Connect();

                                if (Global.Instance.Device.LightController.SerialOpen)
                                {
                                    _log = "[LIGHT] Light Contoler Connect!!";
                                }
                                else
                                {
                                    _log = "[LIGHT] Light Contoler Not Connect!!!";
                                }
                            }
                        }

                        CLogger.Add(LOG.DEVICE, _log);
                    }
                    break;

                case "btn_NGBUFFER_Connect":
                    {
                        if (Global.Instance.Device.NGBUFFER == null)
                        {
                            Global.Instance.Device.NGBUFFER = new CMewtocol(Global.Instance.Mode.NG_Buffer_Type);            // 조명 컨트롤러 드라이버 클래스 다시 생성함
                            Global.Instance.Device.NGBUFFER.Connect();

                            if (Global.Instance.Device.NGBUFFER.IsOpen)
                            {
                                _log = "[NG BUFFER] NG BUFFER Connect!!";
                            }
                            else
                            {
                                _log = "[LIGHT] NG BUFFER Not Connect!!!";
                            }
                        }
                        else
                        {
                            if (!Global.Instance.Device.NGBUFFER.IsOpen)
                            {
                                Global.Instance.Device.NGBUFFER = null;       // 할당 해지
                                Global.Instance.Device.NGBUFFER = new CMewtocol(Global.Instance.Mode.NG_Buffer_Type);            // 조명 컨트롤러 드라이버 클래스 다시 생성함
                                Global.Instance.Device.NGBUFFER.Connect();

                                if (Global.Instance.Device.NGBUFFER.IsOpen)
                                {
                                    _log = "[NG BUFFER] NG BUFFER Connect!!";
                                }
                                else
                                {
                                    _log = "[NG BUFFER] NG BUFFER Not Connect!!!";
                                }
                            }
                        }

                        CLogger.Add(LOG.DEVICE, _log);

                    }
                    break;
            }
        }

        private void btn_DisConnect_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string _log = "-";

            switch (btn.Name)
            {
                case "btn_light_Disconnect":
                    {
                        if (Global.Instance.Device.LightController != null)
                        {
                            if (Global.Instance.Device.LightController.SerialOpen)
                            {
                                // 쓰레드 정지시킴
                                Global.Instance.Device.LightController.DisConnect();
                                Global.Instance.Device.LightController = null;            // 할당 해제함
                            }
                            else
                            {
                                Global.Instance.Device.LightController = null;            // 할당 해제함
                            }

                            _log = "[LIGHT] Light Contoler Disconnect!!!";
                        }
                        else
                        {
                            _log = "[LIGHT] Light Contoler No connect!! ReCheck Plese!";
                            IF_Util.ShowMessageBox("Serial Connect Check", _log);
                        }

                        CLogger.Add(LOG.DEVICE, _log);
                    }
                    break;

                case "btn_NGBUFFER_Disconnect":
                    {
                        if (Global.Instance.Device.NGBUFFER != null)
                        {
                            if (Global.Instance.Device.NGBUFFER.IsOpen)
                            {
                                // 쓰레드 정지시킴
                                Global.Instance.Device.NGBUFFER.DisConnect();
                                Global.Instance.Device.NGBUFFER = null;            // 할당 해제함
                            }
                            else
                            {
                                Global.Instance.Device.NGBUFFER = null;            // 할당 해제함
                            }

                            _log = "[NG BUFFER] NGBUFFER Disconnect!!!";
                        }
                        else
                        {
                            _log = "[LIGHT] NG BUFFER No connect!! ReCheck Plese!";
                            IF_Util.ShowMessageBox("NG BUFFER Serial Connect Check", _log);
                        }

                        CLogger.Add(LOG.DEVICE, _log);
                    }
                    break;
            }


        }

        private void tmr_DISP_Tick(object sender, EventArgs e)
        {
            if (Global.m_ARC_USE)
            {
                // TCP 연결상태이면 버튼 디세이블
                if (ARC_Control.IsRun)
                {
                    btn_TCP_Connect.Enabled = false;
                    btn_TCP_Disconnect.Enabled = true;
                }
                else
                {
                    btn_TCP_Connect.Enabled = true;
                    btn_TCP_Disconnect.Enabled = false;
                }
            }
            else
            {
                btn_TCP_Connect.Enabled = false;
                btn_TCP_Disconnect.Enabled = false;
            }

            // 연결된 상태이면...해당 Connect 버튼 디세이블..
            if (Global.Instance.Device.LightController != null)
            {
                if (Global.Instance.Device.LightController.IsOpen)
                {
                    btn_light_Connect.Enabled = false;
                    btn_light_Disconnect.Enabled = true;
                }
                else
                {
                    btn_light_Connect.Enabled = true;
                    btn_light_Disconnect.Enabled = false;
                }
            }
            else
            {
                btn_light_Connect.Enabled = true;
                btn_light_Disconnect.Enabled = false;
            }

            if (Global.Instance.Device.NGBUFFER != null)
            {
                if (Global.Instance.Device.NGBUFFER.IsOpen)
                {
                    btn_NGBUFFER_Connect.Enabled = false;
                    btn_NGBUFFER_Disconnect.Enabled = true;
                }
                else
                {
                    btn_NGBUFFER_Connect.Enabled = true;
                    btn_NGBUFFER_Disconnect.Enabled = false;
                }
            }
            else
            {
                btn_NGBUFFER_Connect.Enabled = true;
                btn_NGBUFFER_Disconnect.Enabled = false;
            }

            if (Global.m_FileDel_AutoRun)
            {
                btn_FileDel_Run.BackColor = Color.Lime;
                btn_FileDel_Run.Text = "Running..";
            }
            else
            {
                btn_FileDel_Run.BackColor = Color.FromArgb(60, 60, 60);
                btn_FileDel_Run.Text = "Run";
            }
        }

        private bool SerialValue_Check()
        {
            // 값이 정상이면 true, 값이 변경되어있으면 false
            bool ret = true;

            int value = (int)CSerial_Registry.COM_PORT_Name.LightController;
            if (Global.Instance.Device.m_COM[value].m_com_port != combo_light_comport.Text) ret = false;
            if (Global.Instance.Device.m_COM[value].m_com_baudrate != int.Parse(combo_light_baudrate.Text)) ret = false;
            if (Global.Instance.Device.m_COM[value].m_com_parity != (Parity)Enum.Parse(typeof(Parity), combo_light_Parity.Text)) ret = false;
            if (Global.Instance.Device.m_COM[value].m_com_stopbits != (StopBits)Enum.Parse(typeof(StopBits), combo_light_StopBits.Text)) ret = false;
            if (Global.Instance.Device.m_COM[value].m_com_databits != int.Parse(txt_light_DataBits.Text)) ret = false;

            value = (int)CSerial_Registry.COM_PORT_Name.NG_Buffer;
            if (Global.Instance.Device.m_COM[value].m_com_port != combo_NGBUFFER_comport.Text) ret = false;
            if (Global.Instance.Device.m_COM[value].m_com_baudrate != int.Parse(combo_NGBUFFER_baudrate.Text)) ret = false;
            if (Global.Instance.Device.m_COM[value].m_com_parity != (Parity)Enum.Parse(typeof(Parity), combo_NGBUFFER_Parity.Text)) ret = false;
            if (Global.Instance.Device.m_COM[value].m_com_stopbits != (StopBits)Enum.Parse(typeof(StopBits), combo_NGBUFFER_StopBits.Text)) ret = false;
            if (Global.Instance.Device.m_COM[value].m_com_databits != int.Parse(txt_NGBUFFER_DataBits.Text)) ret = false;

            return ret;
        }

        private void btn_ConfigSave_Click(object sender, EventArgs e)
        {
            if (IF_Util.ShowMessageBox("SAVE", "Do you want to save Option and Config Data?"))
            {
                Global.Setting.Equipment.DelayTime_PrevInsp = txtInspDelay.IntValue;

                Global.Setting.Enviroment.EyeD.ServerIP = txtEyeD_IP.Text;
                Global.Setting.Enviroment.EyeD.ServerPort = int.Parse(txtEyeD_Port.Text);
                Global.Mode.SaveConfig();
                SetData();
                CSerial_Registry.Serial_Comport_All_Write();
                // File Del관련 내용 저장
                FileDelData_Set();
                // 이미지 파일 저장 경로
                FileImageSavePath_Set();

                // EQP NAME 저장
                Global.EQP_NAME = txt_EQPNAME.Text;
                Global.EQPNAME_Registry_Write(Global.EQP_NAME);

                Global.m_ARC_IP = txt_ARC_IP.Text;
                Global.m_ARC_PORT = txt_ARC_Port.Text;
                Global.m_ARC_USE = chb_ARC_Use.Checked;
                // 자동 기종변경 IP, PORT 저장
                Global.ARC_Registry_Write(Global.m_ARC_IP, Global.m_ARC_PORT, Global.m_ARC_USE);

                nDataChange = false;
            }
        }

        // 해당 옵션 데이터가 변경되었는지 체크...
        private bool FileDelDataChange_Check()
        {
            bool ret = false;

            if (Global.m_FileDel_C.FileDel_Path != lbl_FileDel_Path_C.Text) return true;
            if (Global.m_FileDel_D.FileDel_Path != lbl_FileDel_Path_D.Text) return true;
            if (Global.m_FileDel_E.FileDel_Path != lbl_FileDel_Path_E.Text) return true;

            if (Global.m_FileDel_C.FileDel_Day != int.Parse(txtFileDelStorageDay_C.Text)) return true;
            if (Global.m_FileDel_D.FileDel_Day != int.Parse(txtFileDelStorageDay_D.Text)) return true;
            if (Global.m_FileDel_E.FileDel_Day != int.Parse(txtFileDelStorageDay_E.Text)) return true;

            if (Global.m_FileDel_C.FileDel_Time != int.Parse(txtFileDelTime_C.Text)) return true;
            if (Global.m_FileDel_D.FileDel_Time != int.Parse(txtFileDelTime_D.Text)) return true;
            if (Global.m_FileDel_E.FileDel_Time != int.Parse(txtFileDelTime_E.Text)) return true;

            if (Global.m_FileDel_C.FileDel_Enabled != chbFileDelEnabled_C.Checked) return true;
            if (Global.m_FileDel_D.FileDel_Enabled != chbFileDelEnabled_D.Checked) return true;
            if (Global.m_FileDel_E.FileDel_Enabled != chbFileDelEnabled_E.Checked) return true;

            return ret;
        }

        // 파일 옵션 데이터가 변경되었을 경우...파일 삭제 쓰레드 동작 안되도록함..
        private void btn_FileDel_Run_Click(object sender, EventArgs e)
        {
            // 데이터가 변경된 부분이 있을경우..
            if (FileDelDataChange_Check())
            {
                IF_Util.ShowMessageBox("File Del Run", "File Del Option Data Change!! Data Save Please!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                return;
            }

            // 아래 파일 삭제 쓰레드 동작..런...
            // 런 시작했는지 체크 자동 저장함...
            // 런동작 안시킴...
            if (Global.m_FileDel_AutoRun)
            {
                Global.m_FileDel_AutoRun = false;
                Global.Instance.FileDelete_Close();
            }
            else
            {
                Global.m_FileDel_AutoRun = true;
                Global.Instance.FileDelete_Thread();
            }

            CRegistry.Registry_Data_Write(Global.Registry_FileDel_Run_Name, Global.Registry_FileDel_Run_Key, Global.m_FileDel_AutoRun.ToString());
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자값만 입력되도록 인터락 추가(백스페이스는 입력되도록함)
            // 엔터키는 입력되도록함.
            if ((char.IsDigit(e.KeyChar) == false && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != Convert.ToChar(Keys.Enter) && e.KeyChar != Convert.ToChar('.')))
            {
                e.Handled = true;
                IF_Util.ShowMessageBox("Text KeyIn Check", "Only Number key-in Please!!");
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            string str = txt.Text;

            // 0또는 1일경우...리턴...
            if (str == "1" || str == "2") return;

            // 1 ~ 24까지의 값만 입력 가능하도록함...
            // Time 입력이므로...24시까지..입력..
            if (str != "1" && str != "2" && str != "3" && str != "4" && str != "5" && str != "6" && str != "7" && str != "8" &&
                str != "9" && str != "10" && str != "11" && str != "12" && str != "13" && str != "14" && str != "15" && str != "16" &&
                str != "17" && str != "18" && str != "19" && str != "20" && str != "21" && str != "22" && str != "23" && str != "24")
            {
                IF_Util.ShowMessageBox("Text KeyIn Check", "Number 1 ~ 24 Key In Please!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                txt.Text = "0";
            }
        }

        private void txt_HDD_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            int value = int.Parse(txt.Text);

            if (value > 100)
            {
                IF_Util.ShowMessageBox("Text KeyIn Check", "Number 0 ~ 100 Key In Please!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                txt.Text = "0";
            }
        }

        private void Tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            string str = lbl.Text;
            tooltip_Driverpath.SetToolTip(lbl, str);
        }

        private void btn_ConfigSave_MouseHover(object sender, EventArgs e)
        {
            btn_ConfigSave.Image = Properties.Resources.Save50_MouseHover;
            btn_ConfigSave.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btn_ConfigSave_MouseLeave(object sender, EventArgs e)
        {
            btn_ConfigSave.Image = Properties.Resources.Save50_Normal;
            btn_ConfigSave.ForeColor = Color.White;
        }

        private void chb_ReInspec_Use_CheckedChanged(object sender, EventArgs e)
        {
            Global.Mode.ReInspecUse = chb_ReInspec_Use.Checked;
        }

        private void txt_ReInspec_cnt_TextChanged(object sender, EventArgs e)
        {
            Global.Mode.ReInspecCnt = int.Parse(txt_ReInspec_cnt.Text);
        }


        private void chb_RMS_CallStage_RetestUse_Click(object sender, EventArgs e)
        {
            nDataChange = true;
            Global.Instance.Mode.IsRMS_CallStage_ReTest = chb_RMS_CallStage_RetestUse.Checked;
        }

        private void chb_RMS_NGBuffer_RetestUse_Click(object sender, EventArgs e)
        {
            nDataChange = true;
            Global.Instance.Mode.IsRMS_NGBUFFER_ReTest = chb_RMS_NGBuffer_RetestUse.Checked;
        }

        private void chb_RMS_BoardOutUse_Click(object sender, EventArgs e)
        {
            nDataChange = true;
            Global.Instance.Mode.IsRMS_BoardOut = chb_RMS_BoardOutUse.Checked;
        }

        private void chb_RMS_BoardPassUse_Click(object sender, EventArgs e)
        {
            nDataChange = true;
            Global.Instance.Mode.IsRMS_BoardPass = chb_RMS_BoardPassUse.Checked;
        }

        private void chb_RMS_FinalOKUse_Click(object sender, EventArgs e)
        {
            nDataChange = true;
            Global.Instance.Mode.IsRMS_FinalOk = chb_RMS_FinalOKUse.Checked;
        }

        private void chb_NGBuffer_Type_Click(object sender, EventArgs e)
        {
            Global.Instance.Mode.NG_Buffer_Type = chb_NGBuffer_Type.Checked;

            if (chb_NGBuffer_Type.Checked)
            {
                chb_NGBuffer_Type.Text = "NG BUFFER Type [ K ]";
            }
            else
            {
                chb_NGBuffer_Type.Text = "NG BUFFER Type [ P ]";
            }
        }

        private void btn_NGBuffer_Reflush_Click(object sender, EventArgs e)
        {
            string _log = "";
            // NG Buffer의값이 생성되어있는것을 다시 실행함...
            if (Global.Instance.Device.NGBUFFER == null)
            {
                Global.Instance.Device.NGBUFFER = new CMewtocol(Global.Instance.Mode.NG_Buffer_Type);            // 조명 컨트롤러 드라이버 클래스 다시 생성함
                Global.Instance.Device.NGBUFFER.Connect();

                if (Global.Instance.Device.NGBUFFER.IsOpen)
                {
                    _log = "[NG BUFFER] NG BUFFER Connect!!";
                }
                else
                {
                    _log = "[LIGHT] NG BUFFER Not Connect!!!";
                }
            }
            // 해당 NG Buffer가 Null이 아닐때..
            else
            {
                if (Global.Instance.Device.NGBUFFER.IsOpen)
                {
                    // 쓰레드 정지시킴
                    Global.Instance.Device.NGBUFFER.DisConnect();
                    Global.Instance.Device.NGBUFFER = null;            // 할당 해제함

                    // 다시 컨넥트 시켜줌....
                    Global.Instance.Device.NGBUFFER = new CMewtocol(Global.Instance.Mode.NG_Buffer_Type);
                    Global.Instance.Device.NGBUFFER.Connect();

                    if (Global.Instance.Device.NGBUFFER.IsOpen)
                    {
                        _log = "[NG BUFFER] NG BUFFER Connect!!";
                    }
                    else
                    {
                        _log = "[NG BUFFER] NG BUFFER Not Connect!!!";
                    }
                }
                // 시리얼 포트가 연결되어있지 않을시...
                // 연결...시도..
                else
                {
                    Global.Instance.Device.NGBUFFER = null;            // 할당 해제함

                    // 다시 바로 컨넥트 시켜줌...
                    Global.Instance.Device.NGBUFFER = new CMewtocol(Global.Instance.Mode.NG_Buffer_Type);
                    Global.Instance.Device.NGBUFFER.Connect();

                    if (Global.Instance.Device.NGBUFFER.IsOpen)
                    {
                        _log = "[NG BUFFER] NG BUFFER Connect!!";
                    }
                    else
                    {
                        _log = "[NG BUFFER] NG BUFFER Not Connect!!!";
                    }
                }
            }

            CLogger.Add(LOG.DEVICE, _log);
        }

        private void btn_TCP_Connect_Click(object sender, EventArgs e)
        {
            if (txt_ARC_IP.Text != Global.m_ARC_IP)
            {
                IF_Util.ShowMessageBox("ARC IP Check", "IP Change..IP Save Please!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                return;
            }
            if (txt_ARC_Port.Text != Global.m_ARC_PORT)
            {
                IF_Util.ShowMessageBox("ARC IP Check", "Port Change..Port Save Please!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                return;
            }

            ARC_Control.Open(Global.m_ARC_IP, int.Parse(Global.m_ARC_PORT), "ARC Control");
            string _log = "[ARC Control] ARC Control Attempt to Connect....";
            CLogger.Add(LOG.DEVICE, _log);

            if (ARC_Control.IsRun)
            {
                _log = "[ARC Control] ARC Control Connect Complete";
                CLogger.Add(LOG.DEVICE, _log);
            }
            else
            {
                _log = "[ARC Control] ARC Control Server is not open! Please check the board IP and board and reconnect it!!";
                CLogger.Add(LOG.DEVICE, _log);
                IF_Util.ShowMessageBox("ARC IP Check", _log, FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
            }
        }

        private void btn_TCP_Disconnect_Click(object sender, EventArgs e)
        {
            string _log = "";

            if (ARC_Control.IsRun)
            {
                if (IF_Util.ShowMessageBox("ARC Chnage TCP Check", "You are connected! Do you want to disconnect?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    // 쓰레드 정지시킴
                    ARC_Control.Close();
                    _log = "ARC Control It has been released normally!";
                }
            }
            else
            {
                _log = "ARC Control Unable to disconnect because it is not connected. Please check again!";
            }

            CLogger.Add(LOG.DEVICE, _log);
        }

        private void txtDailyReset_TextChanged(object sender, EventArgs e)
        {
            Global.Mode.Count_Reset_D = int.Parse(txtDailyReset.Text);
        }

        private void txtMonthlyReset_TextChanged(object sender, EventArgs e)
        {
            Global.Mode.Count_Reset_M = int.Parse(txtMonthlyReset.Text);
        }
    }
}