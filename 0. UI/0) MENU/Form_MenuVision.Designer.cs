using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IntelligentFactory
{
    partial class Form_MenuVision
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MenuVision));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle66 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle73 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle74 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle75 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle76 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.pnlCogDisplay = new System.Windows.Forms.Panel();
            this.DispMain = new Cognex.VisionPro.Display.CogDisplay();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.uiButton12 = new Sunny.UI.UIButton();
            this.uiButton7 = new Sunny.UI.UIButton();
            this.pnlDisplayStatus = new System.Windows.Forms.Panel();
            this.uiButton8 = new Sunny.UI.UIButton();
            this.btnLive = new Sunny.UI.UIButton();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiButton6 = new Sunny.UI.UIButton();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.pnl_CogDisplay_Operation = new Sunny.UI.UIPanel();
            this.uiSymbolButton6 = new Sunny.UI.UISymbolButton();
            this.uiLine4 = new Sunny.UI.UILine();
            this.btn_CogDisplay_OverlayClear = new Sunny.UI.UISymbolButton();
            this.uiLine2 = new Sunny.UI.UILine();
            this.btn_CogDisplay_SearchROI = new Sunny.UI.UISymbolButton();
            this.uiLine1 = new Sunny.UI.UILine();
            this.btn_CogDisplay_ImageLoad = new Sunny.UI.UISymbolButton();
            this.btn_CogDisplay_ImageSave = new Sunny.UI.UISymbolButton();
            this.line1 = new Sunny.UI.UILine();
            this.btn_CogDisplay_Measure = new Sunny.UI.UISymbolButton();
            this.line2 = new Sunny.UI.UILine();
            this.btn_CogDisplay_Point = new Sunny.UI.UISymbolButton();
            this.btn_CogDisplay_Pan = new Sunny.UI.UISymbolButton();
            this.line3 = new Sunny.UI.UILine();
            this.btn_CogDisplay_ZoomIn = new Sunny.UI.UISymbolButton();
            this.btn_CogDisplay_ZoomOut = new Sunny.UI.UISymbolButton();
            this.btn_CogDisplay_ZoomFit = new Sunny.UI.UISymbolButton();
            this.label1 = new System.Windows.Forms.Label();
            this.uiLine6 = new Sunny.UI.UILine();
            this.btnView_Setting1 = new Sunny.UI.UIButton();
            this.btnView_Setting2 = new Sunny.UI.UIButton();
            this.btnView_Setting4 = new Sunny.UI.UIButton();
            this.btnView_Setting3 = new Sunny.UI.UIButton();
            this.btnView_Result4 = new Sunny.UI.UIButton();
            this.btnView_Result3 = new Sunny.UI.UIButton();
            this.btnView_Result2 = new Sunny.UI.UIButton();
            this.btnView_Result1 = new Sunny.UI.UIButton();
            this.uiLine5 = new Sunny.UI.UILine();
            this.label5 = new System.Windows.Forms.Label();
            this.uiLine7 = new Sunny.UI.UILine();
            this.label33 = new System.Windows.Forms.Label();
            this.btnViewGrabIndex4 = new Sunny.UI.UIButton();
            this.btnViewGrabIndex3 = new Sunny.UI.UIButton();
            this.btnViewGrabIndex2 = new Sunny.UI.UIButton();
            this.btnViewGrabIndex1 = new Sunny.UI.UIButton();
            this.btnViewGrabIndex5 = new Sunny.UI.UIButton();
            this.DisplayGrabIdx1 = new Cognex.VisionPro.Display.CogDisplay();
            this.DisplayGrabIdx2 = new Cognex.VisionPro.Display.CogDisplay();
            this.DisplayGrabIdx4 = new Cognex.VisionPro.Display.CogDisplay();
            this.DisplayGrabIdx3 = new Cognex.VisionPro.Display.CogDisplay();
            this.DisplayGrabIdx5 = new Cognex.VisionPro.Display.CogDisplay();
            this.timerCalibration = new System.Windows.Forms.Timer(this.components);
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.btnView_Full = new Sunny.UI.UISymbolButton();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uiTabControl2 = new Sunny.UI.UITabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uiGroupBox14 = new Sunny.UI.UIGroupBox();
            this.label89 = new System.Windows.Forms.Label();
            this.CbTriggerMode = new Sunny.UI.UIComboBox();
            this.uiSymbolButton28 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton44 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton43 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton42 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton41 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton35 = new Sunny.UI.UISymbolButton();
            this.label52 = new System.Windows.Forms.Label();
            this.TbLight5 = new Sunny.UI.UITextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.TbGain5 = new Sunny.UI.UITextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.TbExposure5 = new Sunny.UI.UITextBox();
            this.uiLine12 = new Sunny.UI.UILine();
            this.label46 = new System.Windows.Forms.Label();
            this.TbLight4 = new Sunny.UI.UITextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.TbGain4 = new Sunny.UI.UITextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.TbExposure4 = new Sunny.UI.UITextBox();
            this.uiLine10 = new Sunny.UI.UILine();
            this.label49 = new System.Windows.Forms.Label();
            this.TbLight3 = new Sunny.UI.UITextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.TbGain3 = new Sunny.UI.UITextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.TbExposure3 = new Sunny.UI.UITextBox();
            this.uiLine11 = new Sunny.UI.UILine();
            this.label40 = new System.Windows.Forms.Label();
            this.TbLight2 = new Sunny.UI.UITextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.TbGain2 = new Sunny.UI.UITextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.TbExposure2 = new Sunny.UI.UITextBox();
            this.uiLine9 = new Sunny.UI.UILine();
            this.label44 = new System.Windows.Forms.Label();
            this.TbLight1 = new Sunny.UI.UITextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.TbGain1 = new Sunny.UI.UITextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.BtnIQHWApply = new Sunny.UI.UISymbolButton();
            this.TbExposure1 = new Sunny.UI.UITextBox();
            this.uiLine8 = new Sunny.UI.UILine();
            this.uiGroupBox13 = new Sunny.UI.UIGroupBox();
            this.uiSymbolButton10 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton18 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton19 = new Sunny.UI.UISymbolButton();
            this.label37 = new System.Windows.Forms.Label();
            this.uiTextBox13 = new Sunny.UI.UITextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.uiLine14 = new Sunny.UI.UILine();
            this.uiSymbolButton20 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton21 = new Sunny.UI.UISymbolButton();
            this.label57 = new System.Windows.Forms.Label();
            this.uiTextBox30 = new Sunny.UI.UITextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.uiLine15 = new Sunny.UI.UILine();
            this.uiSymbolButton14 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton17 = new Sunny.UI.UISymbolButton();
            this.label2 = new System.Windows.Forms.Label();
            this.uiTextBox9 = new Sunny.UI.UITextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.uiLine13 = new Sunny.UI.UILine();
            this.uiSymbolButton13 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton11 = new Sunny.UI.UISymbolButton();
            this.label66 = new System.Windows.Forms.Label();
            this.uiTextBox41 = new Sunny.UI.UITextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.uiLine17 = new Sunny.UI.UILine();
            this.uiGroupBox12 = new Sunny.UI.UIGroupBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.uiSymbolButton15 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton16 = new Sunny.UI.UISymbolButton();
            this.uiTextBox14 = new Sunny.UI.UITextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.uiSymbolButton9 = new Sunny.UI.UISymbolButton();
            this.uiTextBox7 = new Sunny.UI.UITextBox();
            this.uiTextBox8 = new Sunny.UI.UITextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.uiTabControl6 = new Sunny.UI.UITabControl();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.uiSymbolButton54 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton55 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton53 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton50 = new Sunny.UI.UISymbolButton();
            this.uiGroupBox18 = new Sunny.UI.UIGroupBox();
            this.uiSymbolButton56 = new Sunny.UI.UISymbolButton();
            this.uiTextBox34 = new Sunny.UI.UITextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.uiTextBox32 = new Sunny.UI.UITextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.uiSymbolButton49 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton48 = new Sunny.UI.UISymbolButton();
            this.uiDataGridView4 = new Sunny.UI.UIDataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiSymbolButton47 = new Sunny.UI.UISymbolButton();
            this.uiTextBox31 = new Sunny.UI.UITextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.uiGroupBox15 = new Sunny.UI.UIGroupBox();
            this.uiTextBox33 = new Sunny.UI.UITextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.uiGroupBox17 = new Sunny.UI.UIGroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiSymbolButton3 = new Sunny.UI.UISymbolButton();
            this.uiLine20 = new Sunny.UI.UILine();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.label3 = new System.Windows.Forms.Label();
            this.uiLine18 = new Sunny.UI.UILine();
            this.uiComboBox5 = new Sunny.UI.UIComboBox();
            this.uiSymbolButton46 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton51 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton52 = new Sunny.UI.UISymbolButton();
            this.label60 = new System.Windows.Forms.Label();
            this.uiGroupBox16 = new Sunny.UI.UIGroupBox();
            this.uiSymbolButton45 = new Sunny.UI.UISymbolButton();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.uiSymbolButton25 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton26 = new Sunny.UI.UISymbolButton();
            this.cogDisplay6 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay5 = new Cognex.VisionPro.Display.CogDisplay();
            this.uiSymbolButton23 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton24 = new Sunny.UI.UISymbolButton();
            this.uiLine16 = new Sunny.UI.UILine();
            this.label61 = new System.Windows.Forms.Label();
            this.uiSymbolButton27 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton34 = new Sunny.UI.UISymbolButton();
            this.uiLine19 = new Sunny.UI.UILine();
            this.label68 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.uiTabControl3 = new Sunny.UI.UITabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label90 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.cogDisplay7 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay8 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay9 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay10 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay11 = new Cognex.VisionPro.Display.CogDisplay();
            this.uiButton10 = new Sunny.UI.UIButton();
            this.uiButton11 = new Sunny.UI.UIButton();
            this.uiButton13 = new Sunny.UI.UIButton();
            this.uiButton14 = new Sunny.UI.UIButton();
            this.uiButton15 = new Sunny.UI.UIButton();
            this.label32 = new System.Windows.Forms.Label();
            this.uiLine23 = new Sunny.UI.UILine();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.trackbarThresholdMax = new Sunny.UI.UITrackBar();
            this.label31 = new System.Windows.Forms.Label();
            this.lblThresholdMin = new System.Windows.Forms.Label();
            this.uiCheckBox4 = new Sunny.UI.UICheckBox();
            this.trackbarThresholdMin = new Sunny.UI.UITrackBar();
            this.uiRadioButton1 = new Sunny.UI.UIRadioButton();
            this.uiRadioButton2 = new Sunny.UI.UIRadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.uiGroupBox10 = new Sunny.UI.UIGroupBox();
            this.btnChannelSplit = new Sunny.UI.UISymbolButton();
            this.label9 = new System.Windows.Forms.Label();
            this.comboChannelSplit = new Sunny.UI.UIComboBox();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.uiSymbolButton30 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton31 = new Sunny.UI.UISymbolButton();
            this.label10 = new System.Windows.Forms.Label();
            this.uiTextBox2 = new Sunny.UI.UITextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.uiTextBox3 = new Sunny.UI.UITextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtEyeD_Port = new Sunny.UI.UITextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboThresholdType = new Sunny.UI.UIComboBox();
            this.btnPreProcessRun_One = new Sunny.UI.UISymbolButton();
            this.btnPreProcessDel = new Sunny.UI.UISymbolButton();
            this.btnPreProcessAdd = new Sunny.UI.UISymbolButton();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.label77 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label83 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label82 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label75 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.label80 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label81 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.label84 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.tabPage19 = new System.Windows.Forms.TabPage();
            this.label86 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.tabPage20 = new System.Windows.Forms.TabPage();
            this.label88 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.uiSymbolButton63 = new Sunny.UI.UISymbolButton();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.uiSymbolButton60 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton61 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton62 = new Sunny.UI.UISymbolButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiLine25 = new Sunny.UI.UILine();
            this.uiSymbolButton59 = new Sunny.UI.UISymbolButton();
            this.uiLine22 = new Sunny.UI.UILine();
            this.uiSymbolButton40 = new Sunny.UI.UISymbolButton();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.uiTextBox6 = new Sunny.UI.UITextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.label23 = new System.Windows.Forms.Label();
            this.uiSymbolButton57 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton58 = new Sunny.UI.UISymbolButton();
            this.uiButton9 = new Sunny.UI.UIButton();
            this.uiComboBox2 = new Sunny.UI.UIComboBox();
            this.uiSymbolButton39 = new Sunny.UI.UISymbolButton();
            this.label18 = new System.Windows.Forms.Label();
            this.uiTextBox10 = new Sunny.UI.UITextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.uiSymbolButton38 = new Sunny.UI.UISymbolButton();
            this.uiLine21 = new Sunny.UI.UILine();
            this.uiTextBox4 = new Sunny.UI.UITextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.uiTextBox11 = new Sunny.UI.UITextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.uiSymbolButton36 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton22 = new Sunny.UI.UISymbolButton();
            this.gridLibrary = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLibraryEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridLibraryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLibraryPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiSymbolButton37 = new Sunny.UI.UISymbolButton();
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.uiTabControl7 = new Sunny.UI.UITabControl();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.uiDataGridView5 = new Sunny.UI.UIDataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton5 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton7 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton8 = new Sunny.UI.UISymbolButton();
            this.pnlCogDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DispMain)).BeginInit();
            this.uiPanel3.SuspendLayout();
            this.pnl_CogDisplay_Operation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx5)).BeginInit();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.uiTabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.uiGroupBox14.SuspendLayout();
            this.uiGroupBox13.SuspendLayout();
            this.uiGroupBox12.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.uiTabControl6.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.uiGroupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView4)).BeginInit();
            this.uiGroupBox15.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.uiGroupBox17.SuspendLayout();
            this.uiGroupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay5)).BeginInit();
            this.tabPage14.SuspendLayout();
            this.uiTabControl3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay11)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            this.uiGroupBox10.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.tabPage18.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage19.SuspendLayout();
            this.tabPage20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLibrary)).BeginInit();
            this.tabPage15.SuspendLayout();
            this.uiTabControl7.SuspendLayout();
            this.tabPage16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 500;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // pnlCogDisplay
            // 
            this.pnlCogDisplay.Controls.Add(this.DispMain);
            this.pnlCogDisplay.Controls.Add(this.uiPanel3);
            this.pnlCogDisplay.Controls.Add(this.pnl_CogDisplay_Operation);
            this.pnlCogDisplay.Location = new System.Drawing.Point(2, 67);
            this.pnlCogDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlCogDisplay.Name = "pnlCogDisplay";
            this.pnlCogDisplay.Size = new System.Drawing.Size(700, 792);
            this.pnlCogDisplay.TabIndex = 3541;
            // 
            // DispMain
            // 
            this.DispMain.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.DispMain.ColorMapLowerRoiLimit = 0D;
            this.DispMain.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.DispMain.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.DispMain.ColorMapUpperRoiLimit = 1D;
            this.DispMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DispMain.DoubleTapZoomCycleLength = 2;
            this.DispMain.DoubleTapZoomSensitivity = 2.5D;
            this.DispMain.Location = new System.Drawing.Point(0, 25);
            this.DispMain.Margin = new System.Windows.Forms.Padding(4);
            this.DispMain.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DispMain.MouseWheelSensitivity = 1D;
            this.DispMain.Name = "DispMain";
            this.DispMain.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DispMain.OcxState")));
            this.DispMain.Size = new System.Drawing.Size(700, 726);
            this.DispMain.TabIndex = 3255;
            // 
            // uiPanel3
            // 
            this.uiPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiPanel3.Controls.Add(this.uiButton12);
            this.uiPanel3.Controls.Add(this.uiButton7);
            this.uiPanel3.Controls.Add(this.pnlDisplayStatus);
            this.uiPanel3.Controls.Add(this.uiButton8);
            this.uiPanel3.Controls.Add(this.btnLive);
            this.uiPanel3.Controls.Add(this.uiButton4);
            this.uiPanel3.Controls.Add(this.uiButton2);
            this.uiPanel3.Controls.Add(this.uiButton6);
            this.uiPanel3.Controls.Add(this.uiButton3);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPanel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiPanel3.FillColor2 = System.Drawing.Color.SlateGray;
            this.uiPanel3.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.uiPanel3.ForeColor = System.Drawing.Color.White;
            this.uiPanel3.Location = new System.Drawing.Point(0, 751);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Radius = 0;
            this.uiPanel3.RectColor = System.Drawing.Color.Transparent;
            this.uiPanel3.Size = new System.Drawing.Size(700, 41);
            this.uiPanel3.TabIndex = 3253;
            this.uiPanel3.Text = null;
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton12
            // 
            this.uiButton12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton12.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton12.Location = new System.Drawing.Point(76, 21);
            this.uiButton12.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton12.Name = "uiButton12";
            this.uiButton12.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton12.Size = new System.Drawing.Size(75, 20);
            this.uiButton12.TabIndex = 3551;
            this.uiButton12.Text = "ORIGINAL";
            this.uiButton12.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiButton12.Click += new System.EventHandler(this.OnClickCameraOperation);
            // 
            // uiButton7
            // 
            this.uiButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton7.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton7.Location = new System.Drawing.Point(228, 21);
            this.uiButton7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton7.Name = "uiButton7";
            this.uiButton7.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton7.Size = new System.Drawing.Size(75, 20);
            this.uiButton7.TabIndex = 3550;
            this.uiButton7.Text = "SAVE (5)";
            this.uiButton7.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiButton7.Click += new System.EventHandler(this.OnClickCameraOperation);
            // 
            // pnlDisplayStatus
            // 
            this.pnlDisplayStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDisplayStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDisplayStatus.Location = new System.Drawing.Point(305, 0);
            this.pnlDisplayStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlDisplayStatus.Name = "pnlDisplayStatus";
            this.pnlDisplayStatus.Size = new System.Drawing.Size(395, 41);
            this.pnlDisplayStatus.TabIndex = 3061;
            // 
            // uiButton8
            // 
            this.uiButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton8.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton8.Location = new System.Drawing.Point(228, 0);
            this.uiButton8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton8.Name = "uiButton8";
            this.uiButton8.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton8.Size = new System.Drawing.Size(75, 20);
            this.uiButton8.TabIndex = 3549;
            this.uiButton8.Text = "SAVE (1)";
            this.uiButton8.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiButton8.Click += new System.EventHandler(this.OnClickCameraOperation);
            // 
            // btnLive
            // 
            this.btnLive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLive.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLive.Font = new System.Drawing.Font("Arial", 8F);
            this.btnLive.Location = new System.Drawing.Point(76, 0);
            this.btnLive.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLive.Name = "btnLive";
            this.btnLive.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLive.Size = new System.Drawing.Size(75, 20);
            this.btnLive.TabIndex = 3546;
            this.btnLive.Text = "LIVE";
            this.btnLive.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLive.Click += new System.EventHandler(this.OnClickCameraOperation);
            // 
            // uiButton4
            // 
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton4.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton4.Location = new System.Drawing.Point(152, 21);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton4.Size = new System.Drawing.Size(75, 20);
            this.uiButton4.TabIndex = 3548;
            this.uiButton4.Text = "LOAD (5)";
            this.uiButton4.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiButton4.Click += new System.EventHandler(this.OnClickCameraOperation);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton2.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton2.Location = new System.Drawing.Point(0, 0);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton2.Size = new System.Drawing.Size(75, 20);
            this.uiButton2.TabIndex = 3544;
            this.uiButton2.Text = "GRAB (1)";
            this.uiButton2.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiButton2.Click += new System.EventHandler(this.OnClickCameraOperation);
            // 
            // uiButton6
            // 
            this.uiButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton6.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton6.Location = new System.Drawing.Point(152, 0);
            this.uiButton6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton6.Name = "uiButton6";
            this.uiButton6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton6.Size = new System.Drawing.Size(75, 20);
            this.uiButton6.TabIndex = 3547;
            this.uiButton6.Text = "LOAD (1)";
            this.uiButton6.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiButton6.Click += new System.EventHandler(this.OnClickCameraOperation);
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton3.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton3.Location = new System.Drawing.Point(0, 21);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton3.Size = new System.Drawing.Size(75, 20);
            this.uiButton3.TabIndex = 3545;
            this.uiButton3.Text = "GRAB (5)";
            this.uiButton3.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiButton3.Click += new System.EventHandler(this.OnClickCameraOperation);
            // 
            // pnl_CogDisplay_Operation
            // 
            this.pnl_CogDisplay_Operation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnl_CogDisplay_Operation.Controls.Add(this.uiSymbolButton6);
            this.pnl_CogDisplay_Operation.Controls.Add(this.uiLine4);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_OverlayClear);
            this.pnl_CogDisplay_Operation.Controls.Add(this.uiLine2);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_SearchROI);
            this.pnl_CogDisplay_Operation.Controls.Add(this.uiLine1);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_ImageLoad);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_ImageSave);
            this.pnl_CogDisplay_Operation.Controls.Add(this.line1);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_Measure);
            this.pnl_CogDisplay_Operation.Controls.Add(this.line2);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_Point);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_Pan);
            this.pnl_CogDisplay_Operation.Controls.Add(this.line3);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_ZoomIn);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_ZoomOut);
            this.pnl_CogDisplay_Operation.Controls.Add(this.btn_CogDisplay_ZoomFit);
            this.pnl_CogDisplay_Operation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_CogDisplay_Operation.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnl_CogDisplay_Operation.FillColor2 = System.Drawing.Color.SlateGray;
            this.pnl_CogDisplay_Operation.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.pnl_CogDisplay_Operation.ForeColor = System.Drawing.Color.White;
            this.pnl_CogDisplay_Operation.Location = new System.Drawing.Point(0, 0);
            this.pnl_CogDisplay_Operation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_CogDisplay_Operation.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl_CogDisplay_Operation.Name = "pnl_CogDisplay_Operation";
            this.pnl_CogDisplay_Operation.Radius = 0;
            this.pnl_CogDisplay_Operation.RectColor = System.Drawing.Color.Transparent;
            this.pnl_CogDisplay_Operation.Size = new System.Drawing.Size(700, 25);
            this.pnl_CogDisplay_Operation.TabIndex = 3252;
            this.pnl_CogDisplay_Operation.Text = null;
            this.pnl_CogDisplay_Operation.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton6
            // 
            this.uiSymbolButton6.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.CircleRectWidth = 0;
            this.uiSymbolButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton6.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiSymbolButton6.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiSymbolButton6.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.Location = new System.Drawing.Point(175, 0);
            this.uiSymbolButton6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton6.Name = "uiSymbolButton6";
            this.uiSymbolButton6.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.Size = new System.Drawing.Size(30, 25);
            this.uiSymbolButton6.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton6.StyleCustomMode = true;
            this.uiSymbolButton6.Symbol = 61511;
            this.uiSymbolButton6.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton6.SymbolSize = 28;
            this.uiSymbolButton6.TabIndex = 3468;
            this.uiSymbolButton6.Tag = "CROSS";
            this.uiSymbolButton6.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton6.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // uiLine4
            // 
            this.uiLine4.BackColor = System.Drawing.Color.Transparent;
            this.uiLine4.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine4.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiLine4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine4.LineColor = System.Drawing.Color.White;
            this.uiLine4.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.uiLine4.Location = new System.Drawing.Point(205, 0);
            this.uiLine4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Padding = new System.Windows.Forms.Padding(5, 8, 5, 0);
            this.uiLine4.Size = new System.Drawing.Size(25, 25);
            this.uiLine4.TabIndex = 3467;
            this.uiLine4.Text = "uiLine4";
            // 
            // btn_CogDisplay_OverlayClear
            // 
            this.btn_CogDisplay_OverlayClear.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.CircleRectWidth = 0;
            this.btn_CogDisplay_OverlayClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_OverlayClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_OverlayClear.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.btn_CogDisplay_OverlayClear.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.Location = new System.Drawing.Point(230, 0);
            this.btn_CogDisplay_OverlayClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_OverlayClear.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_OverlayClear.Name = "btn_CogDisplay_OverlayClear";
            this.btn_CogDisplay_OverlayClear.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_OverlayClear.Size = new System.Drawing.Size(100, 25);
            this.btn_CogDisplay_OverlayClear.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_OverlayClear.StyleCustomMode = true;
            this.btn_CogDisplay_OverlayClear.Symbol = 361552;
            this.btn_CogDisplay_OverlayClear.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_OverlayClear.TabIndex = 3461;
            this.btn_CogDisplay_OverlayClear.Tag = "OVERLAY CLEAR";
            this.btn_CogDisplay_OverlayClear.Text = "Overlay Clear";
            this.btn_CogDisplay_OverlayClear.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_OverlayClear.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine2.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiLine2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine2.LineColor = System.Drawing.Color.White;
            this.uiLine2.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.uiLine2.Location = new System.Drawing.Point(330, 0);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Padding = new System.Windows.Forms.Padding(5, 8, 5, 0);
            this.uiLine2.Size = new System.Drawing.Size(25, 25);
            this.uiLine2.TabIndex = 3464;
            this.uiLine2.Text = "uiLine3";
            // 
            // btn_CogDisplay_SearchROI
            // 
            this.btn_CogDisplay_SearchROI.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.CircleRectWidth = 0;
            this.btn_CogDisplay_SearchROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_SearchROI.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_SearchROI.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_CogDisplay_SearchROI.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.Location = new System.Drawing.Point(355, 0);
            this.btn_CogDisplay_SearchROI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_SearchROI.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_SearchROI.Name = "btn_CogDisplay_SearchROI";
            this.btn_CogDisplay_SearchROI.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_SearchROI.Size = new System.Drawing.Size(30, 25);
            this.btn_CogDisplay_SearchROI.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_SearchROI.StyleCustomMode = true;
            this.btn_CogDisplay_SearchROI.Symbol = 62024;
            this.btn_CogDisplay_SearchROI.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_SearchROI.TabIndex = 3463;
            this.btn_CogDisplay_SearchROI.Tag = "SEARCH ROI";
            this.btn_CogDisplay_SearchROI.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_SearchROI.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiLine1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.LineColor = System.Drawing.Color.White;
            this.uiLine1.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.uiLine1.Location = new System.Drawing.Point(385, 0);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Padding = new System.Windows.Forms.Padding(5, 8, 5, 0);
            this.uiLine1.Size = new System.Drawing.Size(25, 25);
            this.uiLine1.TabIndex = 3462;
            this.uiLine1.Text = "uiLine3";
            // 
            // btn_CogDisplay_ImageLoad
            // 
            this.btn_CogDisplay_ImageLoad.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.CircleRectWidth = 0;
            this.btn_CogDisplay_ImageLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_ImageLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_ImageLoad.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_CogDisplay_ImageLoad.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.Location = new System.Drawing.Point(410, 0);
            this.btn_CogDisplay_ImageLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_ImageLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_ImageLoad.Name = "btn_CogDisplay_ImageLoad";
            this.btn_CogDisplay_ImageLoad.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageLoad.Size = new System.Drawing.Size(30, 25);
            this.btn_CogDisplay_ImageLoad.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_ImageLoad.StyleCustomMode = true;
            this.btn_CogDisplay_ImageLoad.Symbol = 61717;
            this.btn_CogDisplay_ImageLoad.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_ImageLoad.TabIndex = 3457;
            this.btn_CogDisplay_ImageLoad.Tag = "LOAD";
            this.btn_CogDisplay_ImageLoad.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_ImageLoad.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // btn_CogDisplay_ImageSave
            // 
            this.btn_CogDisplay_ImageSave.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.CircleRectWidth = 0;
            this.btn_CogDisplay_ImageSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_ImageSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_ImageSave.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_CogDisplay_ImageSave.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.Location = new System.Drawing.Point(440, 0);
            this.btn_CogDisplay_ImageSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_ImageSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_ImageSave.Name = "btn_CogDisplay_ImageSave";
            this.btn_CogDisplay_ImageSave.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ImageSave.Size = new System.Drawing.Size(30, 25);
            this.btn_CogDisplay_ImageSave.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_ImageSave.StyleCustomMode = true;
            this.btn_CogDisplay_ImageSave.Symbol = 61639;
            this.btn_CogDisplay_ImageSave.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_ImageSave.TabIndex = 3456;
            this.btn_CogDisplay_ImageSave.Tag = "SAVE";
            this.btn_CogDisplay_ImageSave.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_ImageSave.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.Transparent;
            this.line1.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.line1.Dock = System.Windows.Forms.DockStyle.Right;
            this.line1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.line1.LineColor = System.Drawing.Color.White;
            this.line1.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.line1.Location = new System.Drawing.Point(470, 0);
            this.line1.MinimumSize = new System.Drawing.Size(1, 1);
            this.line1.Name = "line1";
            this.line1.Padding = new System.Windows.Forms.Padding(5, 8, 5, 0);
            this.line1.Size = new System.Drawing.Size(25, 25);
            this.line1.TabIndex = 3453;
            this.line1.Text = "uiLine3";
            // 
            // btn_CogDisplay_Measure
            // 
            this.btn_CogDisplay_Measure.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.CircleRectWidth = 0;
            this.btn_CogDisplay_Measure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_Measure.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_Measure.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_CogDisplay_Measure.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.Location = new System.Drawing.Point(495, 0);
            this.btn_CogDisplay_Measure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_Measure.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_Measure.Name = "btn_CogDisplay_Measure";
            this.btn_CogDisplay_Measure.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Measure.Size = new System.Drawing.Size(30, 25);
            this.btn_CogDisplay_Measure.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_Measure.StyleCustomMode = true;
            this.btn_CogDisplay_Measure.Symbol = 558396;
            this.btn_CogDisplay_Measure.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_Measure.TabIndex = 3454;
            this.btn_CogDisplay_Measure.Tag = "MEASURE";
            this.btn_CogDisplay_Measure.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_Measure.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.Transparent;
            this.line2.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.line2.Dock = System.Windows.Forms.DockStyle.Right;
            this.line2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.line2.LineColor = System.Drawing.Color.White;
            this.line2.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.line2.Location = new System.Drawing.Point(525, 0);
            this.line2.MinimumSize = new System.Drawing.Size(1, 1);
            this.line2.Name = "line2";
            this.line2.Padding = new System.Windows.Forms.Padding(5, 8, 5, 0);
            this.line2.Size = new System.Drawing.Size(25, 25);
            this.line2.TabIndex = 3452;
            this.line2.Text = "uiLine2";
            // 
            // btn_CogDisplay_Point
            // 
            this.btn_CogDisplay_Point.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.CircleRectWidth = 0;
            this.btn_CogDisplay_Point.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_Point.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_Point.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_CogDisplay_Point.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.Location = new System.Drawing.Point(550, 0);
            this.btn_CogDisplay_Point.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_Point.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_Point.Name = "btn_CogDisplay_Point";
            this.btn_CogDisplay_Point.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Point.Selected = true;
            this.btn_CogDisplay_Point.Size = new System.Drawing.Size(25, 25);
            this.btn_CogDisplay_Point.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_Point.StyleCustomMode = true;
            this.btn_CogDisplay_Point.Symbol = 62021;
            this.btn_CogDisplay_Point.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_Point.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_CogDisplay_Point.SymbolSize = 16;
            this.btn_CogDisplay_Point.TabIndex = 3256;
            this.btn_CogDisplay_Point.Tag = "POINT";
            this.btn_CogDisplay_Point.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_Point.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // btn_CogDisplay_Pan
            // 
            this.btn_CogDisplay_Pan.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.CircleRectWidth = 0;
            this.btn_CogDisplay_Pan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_Pan.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_Pan.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_CogDisplay_Pan.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.Location = new System.Drawing.Point(575, 0);
            this.btn_CogDisplay_Pan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_Pan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_Pan.Name = "btn_CogDisplay_Pan";
            this.btn_CogDisplay_Pan.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_Pan.Size = new System.Drawing.Size(25, 25);
            this.btn_CogDisplay_Pan.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_Pan.StyleCustomMode = true;
            this.btn_CogDisplay_Pan.Symbol = 559685;
            this.btn_CogDisplay_Pan.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_Pan.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_CogDisplay_Pan.SymbolSize = 16;
            this.btn_CogDisplay_Pan.TabIndex = 3261;
            this.btn_CogDisplay_Pan.Tag = "PAN";
            this.btn_CogDisplay_Pan.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_Pan.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // line3
            // 
            this.line3.BackColor = System.Drawing.Color.Transparent;
            this.line3.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.line3.Dock = System.Windows.Forms.DockStyle.Right;
            this.line3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.line3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.line3.LineColor = System.Drawing.Color.White;
            this.line3.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.line3.Location = new System.Drawing.Point(600, 0);
            this.line3.MinimumSize = new System.Drawing.Size(1, 1);
            this.line3.Name = "line3";
            this.line3.Padding = new System.Windows.Forms.Padding(5, 8, 5, 0);
            this.line3.Size = new System.Drawing.Size(25, 25);
            this.line3.TabIndex = 3451;
            this.line3.Text = "uiLine1";
            // 
            // btn_CogDisplay_ZoomIn
            // 
            this.btn_CogDisplay_ZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.CircleRectWidth = 0;
            this.btn_CogDisplay_ZoomIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_ZoomIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_ZoomIn.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_CogDisplay_ZoomIn.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.Location = new System.Drawing.Point(625, 0);
            this.btn_CogDisplay_ZoomIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_ZoomIn.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_ZoomIn.Name = "btn_CogDisplay_ZoomIn";
            this.btn_CogDisplay_ZoomIn.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomIn.Size = new System.Drawing.Size(25, 25);
            this.btn_CogDisplay_ZoomIn.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_ZoomIn.StyleCustomMode = true;
            this.btn_CogDisplay_ZoomIn.Symbol = 84;
            this.btn_CogDisplay_ZoomIn.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_ZoomIn.TabIndex = 3252;
            this.btn_CogDisplay_ZoomIn.Tag = "ZoomIn";
            this.btn_CogDisplay_ZoomIn.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_ZoomIn.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // btn_CogDisplay_ZoomOut
            // 
            this.btn_CogDisplay_ZoomOut.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.CircleRectWidth = 0;
            this.btn_CogDisplay_ZoomOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_ZoomOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_ZoomOut.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_CogDisplay_ZoomOut.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.Location = new System.Drawing.Point(650, 0);
            this.btn_CogDisplay_ZoomOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_ZoomOut.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_ZoomOut.Name = "btn_CogDisplay_ZoomOut";
            this.btn_CogDisplay_ZoomOut.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomOut.Size = new System.Drawing.Size(25, 25);
            this.btn_CogDisplay_ZoomOut.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_ZoomOut.StyleCustomMode = true;
            this.btn_CogDisplay_ZoomOut.Symbol = 83;
            this.btn_CogDisplay_ZoomOut.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_ZoomOut.TabIndex = 3253;
            this.btn_CogDisplay_ZoomOut.Tag = "ZoomOut";
            this.btn_CogDisplay_ZoomOut.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_ZoomOut.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // btn_CogDisplay_ZoomFit
            // 
            this.btn_CogDisplay_ZoomFit.BackColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.CircleRectWidth = 0;
            this.btn_CogDisplay_ZoomFit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CogDisplay_ZoomFit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CogDisplay_ZoomFit.FillColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.FillDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.FillHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.FillPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btn_CogDisplay_ZoomFit.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.ForePressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.Location = new System.Drawing.Point(675, 0);
            this.btn_CogDisplay_ZoomFit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CogDisplay_ZoomFit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CogDisplay_ZoomFit.Name = "btn_CogDisplay_ZoomFit";
            this.btn_CogDisplay_ZoomFit.RectColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.RectDisableColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CogDisplay_ZoomFit.Size = new System.Drawing.Size(25, 25);
            this.btn_CogDisplay_ZoomFit.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CogDisplay_ZoomFit.StyleCustomMode = true;
            this.btn_CogDisplay_ZoomFit.Symbol = 85;
            this.btn_CogDisplay_ZoomFit.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btn_CogDisplay_ZoomFit.TabIndex = 3260;
            this.btn_CogDisplay_ZoomFit.Tag = "ZoomFit";
            this.btn_CogDisplay_ZoomFit.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CogDisplay_ZoomFit.Click += new System.EventHandler(this.OnClickCogDisplayOperation);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 3542;
            this.label1.Text = "Setting";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine6
            // 
            this.uiLine6.BackColor = System.Drawing.Color.Transparent;
            this.uiLine6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine6.LineColor = System.Drawing.Color.Black;
            this.uiLine6.Location = new System.Drawing.Point(12, 24);
            this.uiLine6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine6.Name = "uiLine6";
            this.uiLine6.Size = new System.Drawing.Size(283, 10);
            this.uiLine6.TabIndex = 3549;
            // 
            // btnView_Setting1
            // 
            this.btnView_Setting1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting1.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting1.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting1.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting1.Location = new System.Drawing.Point(71, 6);
            this.btnView_Setting1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting1.Name = "btnView_Setting1";
            this.btnView_Setting1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting1.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting1.TabIndex = 3550;
            this.btnView_Setting1.Tag = "Setting";
            this.btnView_Setting1.Text = "1";
            this.btnView_Setting1.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting1.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting2
            // 
            this.btnView_Setting2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting2.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting2.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting2.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting2.Location = new System.Drawing.Point(127, 6);
            this.btnView_Setting2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting2.Name = "btnView_Setting2";
            this.btnView_Setting2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting2.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting2.TabIndex = 3551;
            this.btnView_Setting2.Tag = "Setting";
            this.btnView_Setting2.Text = "2";
            this.btnView_Setting2.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting2.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting4
            // 
            this.btnView_Setting4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting4.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting4.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting4.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting4.Location = new System.Drawing.Point(239, 6);
            this.btnView_Setting4.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting4.Name = "btnView_Setting4";
            this.btnView_Setting4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting4.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting4.TabIndex = 3553;
            this.btnView_Setting4.Tag = "Setting";
            this.btnView_Setting4.Text = "4";
            this.btnView_Setting4.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting4.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting3
            // 
            this.btnView_Setting3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting3.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting3.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting3.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting3.Location = new System.Drawing.Point(183, 6);
            this.btnView_Setting3.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting3.Name = "btnView_Setting3";
            this.btnView_Setting3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting3.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting3.TabIndex = 3552;
            this.btnView_Setting3.Tag = "Setting";
            this.btnView_Setting3.Text = "3";
            this.btnView_Setting3.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting3.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Result4
            // 
            this.btnView_Result4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Result4.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Result4.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Result4.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Result4.Location = new System.Drawing.Point(240, 37);
            this.btnView_Result4.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Result4.Name = "btnView_Result4";
            this.btnView_Result4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Result4.Size = new System.Drawing.Size(50, 20);
            this.btnView_Result4.TabIndex = 3560;
            this.btnView_Result4.Tag = "Result";
            this.btnView_Result4.Text = "4";
            this.btnView_Result4.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Result4.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Result3
            // 
            this.btnView_Result3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Result3.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Result3.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Result3.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Result3.Location = new System.Drawing.Point(184, 37);
            this.btnView_Result3.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Result3.Name = "btnView_Result3";
            this.btnView_Result3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Result3.Size = new System.Drawing.Size(50, 20);
            this.btnView_Result3.TabIndex = 3559;
            this.btnView_Result3.Tag = "Result";
            this.btnView_Result3.Text = "3";
            this.btnView_Result3.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Result3.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Result2
            // 
            this.btnView_Result2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Result2.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Result2.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Result2.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Result2.Location = new System.Drawing.Point(128, 37);
            this.btnView_Result2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Result2.Name = "btnView_Result2";
            this.btnView_Result2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Result2.Size = new System.Drawing.Size(50, 20);
            this.btnView_Result2.TabIndex = 3558;
            this.btnView_Result2.Tag = "Result";
            this.btnView_Result2.Text = "2";
            this.btnView_Result2.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Result2.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Result1
            // 
            this.btnView_Result1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Result1.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Result1.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Result1.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Result1.Location = new System.Drawing.Point(72, 37);
            this.btnView_Result1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Result1.Name = "btnView_Result1";
            this.btnView_Result1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Result1.Size = new System.Drawing.Size(50, 20);
            this.btnView_Result1.TabIndex = 3557;
            this.btnView_Result1.Tag = "Result";
            this.btnView_Result1.Text = "1";
            this.btnView_Result1.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Result1.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // uiLine5
            // 
            this.uiLine5.BackColor = System.Drawing.Color.Transparent;
            this.uiLine5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine5.LineColor = System.Drawing.Color.Black;
            this.uiLine5.Location = new System.Drawing.Point(11, 56);
            this.uiLine5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(283, 10);
            this.uiLine5.TabIndex = 3556;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 3555;
            this.label5.Text = "Result";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine7
            // 
            this.uiLine7.BackColor = System.Drawing.Color.Transparent;
            this.uiLine7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine7.LineColor = System.Drawing.Color.Black;
            this.uiLine7.Location = new System.Drawing.Point(363, 56);
            this.uiLine7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine7.Name = "uiLine7";
            this.uiLine7.Size = new System.Drawing.Size(336, 10);
            this.uiLine7.TabIndex = 3562;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Arial", 10F);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(368, 2);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(44, 51);
            this.label33.TabIndex = 3561;
            this.label33.Text = "Grab Index";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnViewGrabIndex4
            // 
            this.btnViewGrabIndex4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewGrabIndex4.FillColor = System.Drawing.Color.DimGray;
            this.btnViewGrabIndex4.FillSelectedColor = System.Drawing.Color.Green;
            this.btnViewGrabIndex4.Font = new System.Drawing.Font("Arial", 8F);
            this.btnViewGrabIndex4.Location = new System.Drawing.Point(588, 37);
            this.btnViewGrabIndex4.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnViewGrabIndex4.Name = "btnViewGrabIndex4";
            this.btnViewGrabIndex4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnViewGrabIndex4.Size = new System.Drawing.Size(50, 20);
            this.btnViewGrabIndex4.TabIndex = 3566;
            this.btnViewGrabIndex4.Text = "4";
            this.btnViewGrabIndex4.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGrabIndex4.Click += new System.EventHandler(this.OnClickGrabIndex);
            // 
            // btnViewGrabIndex3
            // 
            this.btnViewGrabIndex3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewGrabIndex3.FillColor = System.Drawing.Color.DimGray;
            this.btnViewGrabIndex3.FillSelectedColor = System.Drawing.Color.Green;
            this.btnViewGrabIndex3.Font = new System.Drawing.Font("Arial", 8F);
            this.btnViewGrabIndex3.Location = new System.Drawing.Point(532, 37);
            this.btnViewGrabIndex3.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnViewGrabIndex3.Name = "btnViewGrabIndex3";
            this.btnViewGrabIndex3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnViewGrabIndex3.Size = new System.Drawing.Size(50, 20);
            this.btnViewGrabIndex3.TabIndex = 3565;
            this.btnViewGrabIndex3.Text = "3";
            this.btnViewGrabIndex3.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGrabIndex3.Click += new System.EventHandler(this.OnClickGrabIndex);
            // 
            // btnViewGrabIndex2
            // 
            this.btnViewGrabIndex2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewGrabIndex2.FillColor = System.Drawing.Color.DimGray;
            this.btnViewGrabIndex2.FillSelectedColor = System.Drawing.Color.Green;
            this.btnViewGrabIndex2.Font = new System.Drawing.Font("Arial", 8F);
            this.btnViewGrabIndex2.Location = new System.Drawing.Point(476, 37);
            this.btnViewGrabIndex2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnViewGrabIndex2.Name = "btnViewGrabIndex2";
            this.btnViewGrabIndex2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnViewGrabIndex2.Size = new System.Drawing.Size(50, 20);
            this.btnViewGrabIndex2.TabIndex = 3564;
            this.btnViewGrabIndex2.Text = "2";
            this.btnViewGrabIndex2.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGrabIndex2.Click += new System.EventHandler(this.OnClickGrabIndex);
            // 
            // btnViewGrabIndex1
            // 
            this.btnViewGrabIndex1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewGrabIndex1.FillColor = System.Drawing.Color.DimGray;
            this.btnViewGrabIndex1.FillSelectedColor = System.Drawing.Color.Green;
            this.btnViewGrabIndex1.Font = new System.Drawing.Font("Arial", 8F);
            this.btnViewGrabIndex1.Location = new System.Drawing.Point(420, 37);
            this.btnViewGrabIndex1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnViewGrabIndex1.Name = "btnViewGrabIndex1";
            this.btnViewGrabIndex1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnViewGrabIndex1.Size = new System.Drawing.Size(50, 20);
            this.btnViewGrabIndex1.TabIndex = 3563;
            this.btnViewGrabIndex1.Text = "1";
            this.btnViewGrabIndex1.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGrabIndex1.Click += new System.EventHandler(this.OnClickGrabIndex);
            // 
            // btnViewGrabIndex5
            // 
            this.btnViewGrabIndex5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewGrabIndex5.FillColor = System.Drawing.Color.DimGray;
            this.btnViewGrabIndex5.FillSelectedColor = System.Drawing.Color.Green;
            this.btnViewGrabIndex5.Font = new System.Drawing.Font("Arial", 8F);
            this.btnViewGrabIndex5.Location = new System.Drawing.Point(644, 37);
            this.btnViewGrabIndex5.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnViewGrabIndex5.Name = "btnViewGrabIndex5";
            this.btnViewGrabIndex5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnViewGrabIndex5.Size = new System.Drawing.Size(50, 20);
            this.btnViewGrabIndex5.TabIndex = 3567;
            this.btnViewGrabIndex5.Text = "5";
            this.btnViewGrabIndex5.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGrabIndex5.Click += new System.EventHandler(this.OnClickGrabIndex);
            // 
            // DisplayGrabIdx1
            // 
            this.DisplayGrabIdx1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx1.ColorMapLowerRoiLimit = 0D;
            this.DisplayGrabIdx1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.DisplayGrabIdx1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx1.ColorMapUpperRoiLimit = 1D;
            this.DisplayGrabIdx1.DoubleTapZoomCycleLength = 2;
            this.DisplayGrabIdx1.DoubleTapZoomSensitivity = 2.5D;
            this.DisplayGrabIdx1.Location = new System.Drawing.Point(420, 3);
            this.DisplayGrabIdx1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayGrabIdx1.MouseWheelSensitivity = 1D;
            this.DisplayGrabIdx1.Name = "DisplayGrabIdx1";
            this.DisplayGrabIdx1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayGrabIdx1.OcxState")));
            this.DisplayGrabIdx1.Size = new System.Drawing.Size(50, 33);
            this.DisplayGrabIdx1.TabIndex = 3568;
            this.DisplayGrabIdx1.TabStop = false;
            this.DisplayGrabIdx1.Tag = "2";
            // 
            // DisplayGrabIdx2
            // 
            this.DisplayGrabIdx2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx2.ColorMapLowerRoiLimit = 0D;
            this.DisplayGrabIdx2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.DisplayGrabIdx2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx2.ColorMapUpperRoiLimit = 1D;
            this.DisplayGrabIdx2.DoubleTapZoomCycleLength = 2;
            this.DisplayGrabIdx2.DoubleTapZoomSensitivity = 2.5D;
            this.DisplayGrabIdx2.Location = new System.Drawing.Point(476, 3);
            this.DisplayGrabIdx2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayGrabIdx2.MouseWheelSensitivity = 1D;
            this.DisplayGrabIdx2.Name = "DisplayGrabIdx2";
            this.DisplayGrabIdx2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayGrabIdx2.OcxState")));
            this.DisplayGrabIdx2.Size = new System.Drawing.Size(50, 33);
            this.DisplayGrabIdx2.TabIndex = 3569;
            this.DisplayGrabIdx2.TabStop = false;
            this.DisplayGrabIdx2.Tag = "2";
            // 
            // DisplayGrabIdx4
            // 
            this.DisplayGrabIdx4.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx4.ColorMapLowerRoiLimit = 0D;
            this.DisplayGrabIdx4.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.DisplayGrabIdx4.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx4.ColorMapUpperRoiLimit = 1D;
            this.DisplayGrabIdx4.DoubleTapZoomCycleLength = 2;
            this.DisplayGrabIdx4.DoubleTapZoomSensitivity = 2.5D;
            this.DisplayGrabIdx4.Location = new System.Drawing.Point(588, 3);
            this.DisplayGrabIdx4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayGrabIdx4.MouseWheelSensitivity = 1D;
            this.DisplayGrabIdx4.Name = "DisplayGrabIdx4";
            this.DisplayGrabIdx4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayGrabIdx4.OcxState")));
            this.DisplayGrabIdx4.Size = new System.Drawing.Size(50, 33);
            this.DisplayGrabIdx4.TabIndex = 3571;
            this.DisplayGrabIdx4.TabStop = false;
            this.DisplayGrabIdx4.Tag = "2";
            // 
            // DisplayGrabIdx3
            // 
            this.DisplayGrabIdx3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx3.ColorMapLowerRoiLimit = 0D;
            this.DisplayGrabIdx3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.DisplayGrabIdx3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx3.ColorMapUpperRoiLimit = 1D;
            this.DisplayGrabIdx3.DoubleTapZoomCycleLength = 2;
            this.DisplayGrabIdx3.DoubleTapZoomSensitivity = 2.5D;
            this.DisplayGrabIdx3.Location = new System.Drawing.Point(532, 3);
            this.DisplayGrabIdx3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayGrabIdx3.MouseWheelSensitivity = 1D;
            this.DisplayGrabIdx3.Name = "DisplayGrabIdx3";
            this.DisplayGrabIdx3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayGrabIdx3.OcxState")));
            this.DisplayGrabIdx3.Size = new System.Drawing.Size(50, 33);
            this.DisplayGrabIdx3.TabIndex = 3570;
            this.DisplayGrabIdx3.TabStop = false;
            this.DisplayGrabIdx3.Tag = "2";
            // 
            // DisplayGrabIdx5
            // 
            this.DisplayGrabIdx5.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx5.ColorMapLowerRoiLimit = 0D;
            this.DisplayGrabIdx5.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.DisplayGrabIdx5.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.DisplayGrabIdx5.ColorMapUpperRoiLimit = 1D;
            this.DisplayGrabIdx5.DoubleTapZoomCycleLength = 2;
            this.DisplayGrabIdx5.DoubleTapZoomSensitivity = 2.5D;
            this.DisplayGrabIdx5.Location = new System.Drawing.Point(644, 3);
            this.DisplayGrabIdx5.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayGrabIdx5.MouseWheelSensitivity = 1D;
            this.DisplayGrabIdx5.Name = "DisplayGrabIdx5";
            this.DisplayGrabIdx5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayGrabIdx5.OcxState")));
            this.DisplayGrabIdx5.Size = new System.Drawing.Size(50, 33);
            this.DisplayGrabIdx5.TabIndex = 3572;
            this.DisplayGrabIdx5.TabStop = false;
            this.DisplayGrabIdx5.Tag = "2";
            // 
            // timerCalibration
            // 
            this.timerCalibration.Tick += new System.EventHandler(this.timerCalibration_Tick);
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblImageInfo.ForeColor = System.Drawing.Color.Black;
            this.lblImageInfo.Location = new System.Drawing.Point(5, 796);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(689, 16);
            this.lblImageInfo.TabIndex = 3573;
            this.lblImageInfo.Text = "Image Info";
            this.lblImageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnView_Full
            // 
            this.btnView_Full.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Full.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Full.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnView_Full.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Full.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnView_Full.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Full.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Full.Location = new System.Drawing.Point(296, 6);
            this.btnView_Full.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Full.Name = "btnView_Full";
            this.btnView_Full.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Full.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Full.RectPressColor = System.Drawing.Color.White;
            this.btnView_Full.RectSelectedColor = System.Drawing.Color.White;
            this.btnView_Full.Selected = true;
            this.btnView_Full.Size = new System.Drawing.Size(55, 55);
            this.btnView_Full.Style = Sunny.UI.UIStyle.Custom;
            this.btnView_Full.StyleCustomMode = true;
            this.btnView_Full.Symbol = 361449;
            this.btnView_Full.SymbolOffset = new System.Drawing.Point(-2, -5);
            this.btnView_Full.SymbolSize = 36;
            this.btnView_Full.TabIndex = 3574;
            this.btnView_Full.Tag = "FULL";
            this.btnView_Full.Text = "FULL";
            this.btnView_Full.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView_Full.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnView_Full.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Controls.Add(this.tabPage14);
            this.uiTabControl1.Controls.Add(this.tabPage15);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(100, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(705, -2);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(1214, 824);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabBackColor = System.Drawing.SystemColors.Control;
            this.uiTabControl1.TabIndex = 3575;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.Transparent;
            this.uiTabControl1.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl1.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.DimGray;
            this.uiTabControl1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uiTabControl2);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1214, 784);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "01. SET-UP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uiTabControl2
            // 
            this.uiTabControl2.Controls.Add(this.tabPage3);
            this.uiTabControl2.Controls.Add(this.tabPage10);
            this.uiTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiTabControl2.ItemSize = new System.Drawing.Size(100, 40);
            this.uiTabControl2.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl2.MainPage = "";
            this.uiTabControl2.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl2.Name = "uiTabControl2";
            this.uiTabControl2.SelectedIndex = 0;
            this.uiTabControl2.Size = new System.Drawing.Size(1214, 784);
            this.uiTabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl2.TabBackColor = System.Drawing.SystemColors.Control;
            this.uiTabControl2.TabIndex = 3466;
            this.uiTabControl2.TabSelectedColor = System.Drawing.Color.Transparent;
            this.uiTabControl2.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl2.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl2.TabUnSelectedForeColor = System.Drawing.Color.DimGray;
            this.uiTabControl2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTabControl2.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uiGroupBox14);
            this.tabPage3.Controls.Add(this.uiGroupBox13);
            this.tabPage3.Controls.Add(this.uiGroupBox12);
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1214, 744);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "01) Equipment";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox14
            // 
            this.uiGroupBox14.Controls.Add(this.label89);
            this.uiGroupBox14.Controls.Add(this.CbTriggerMode);
            this.uiGroupBox14.Controls.Add(this.uiSymbolButton28);
            this.uiGroupBox14.Controls.Add(this.uiSymbolButton44);
            this.uiGroupBox14.Controls.Add(this.uiSymbolButton43);
            this.uiGroupBox14.Controls.Add(this.uiSymbolButton42);
            this.uiGroupBox14.Controls.Add(this.uiSymbolButton41);
            this.uiGroupBox14.Controls.Add(this.uiSymbolButton35);
            this.uiGroupBox14.Controls.Add(this.label52);
            this.uiGroupBox14.Controls.Add(this.TbLight5);
            this.uiGroupBox14.Controls.Add(this.label53);
            this.uiGroupBox14.Controls.Add(this.TbGain5);
            this.uiGroupBox14.Controls.Add(this.label54);
            this.uiGroupBox14.Controls.Add(this.checkBox5);
            this.uiGroupBox14.Controls.Add(this.TbExposure5);
            this.uiGroupBox14.Controls.Add(this.uiLine12);
            this.uiGroupBox14.Controls.Add(this.label46);
            this.uiGroupBox14.Controls.Add(this.TbLight4);
            this.uiGroupBox14.Controls.Add(this.label47);
            this.uiGroupBox14.Controls.Add(this.TbGain4);
            this.uiGroupBox14.Controls.Add(this.label48);
            this.uiGroupBox14.Controls.Add(this.checkBox3);
            this.uiGroupBox14.Controls.Add(this.TbExposure4);
            this.uiGroupBox14.Controls.Add(this.uiLine10);
            this.uiGroupBox14.Controls.Add(this.label49);
            this.uiGroupBox14.Controls.Add(this.TbLight3);
            this.uiGroupBox14.Controls.Add(this.label50);
            this.uiGroupBox14.Controls.Add(this.TbGain3);
            this.uiGroupBox14.Controls.Add(this.label51);
            this.uiGroupBox14.Controls.Add(this.checkBox4);
            this.uiGroupBox14.Controls.Add(this.TbExposure3);
            this.uiGroupBox14.Controls.Add(this.uiLine11);
            this.uiGroupBox14.Controls.Add(this.label40);
            this.uiGroupBox14.Controls.Add(this.TbLight2);
            this.uiGroupBox14.Controls.Add(this.label41);
            this.uiGroupBox14.Controls.Add(this.TbGain2);
            this.uiGroupBox14.Controls.Add(this.label45);
            this.uiGroupBox14.Controls.Add(this.checkBox2);
            this.uiGroupBox14.Controls.Add(this.TbExposure2);
            this.uiGroupBox14.Controls.Add(this.uiLine9);
            this.uiGroupBox14.Controls.Add(this.label44);
            this.uiGroupBox14.Controls.Add(this.TbLight1);
            this.uiGroupBox14.Controls.Add(this.label43);
            this.uiGroupBox14.Controls.Add(this.TbGain1);
            this.uiGroupBox14.Controls.Add(this.label42);
            this.uiGroupBox14.Controls.Add(this.checkBox1);
            this.uiGroupBox14.Controls.Add(this.BtnIQHWApply);
            this.uiGroupBox14.Controls.Add(this.TbExposure1);
            this.uiGroupBox14.Controls.Add(this.uiLine8);
            this.uiGroupBox14.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox14.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox14.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox14.Location = new System.Drawing.Point(5, 0);
            this.uiGroupBox14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox14.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox14.Name = "uiGroupBox14";
            this.uiGroupBox14.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox14.Radius = 10;
            this.uiGroupBox14.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox14.Size = new System.Drawing.Size(628, 264);
            this.uiGroupBox14.TabIndex = 3541;
            this.uiGroupBox14.Text = "I.Q ( Exposure, Gain, Light )";
            this.uiGroupBox14.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label89
            // 
            this.label89.Font = new System.Drawing.Font("Arial", 8F);
            this.label89.ForeColor = System.Drawing.Color.Black;
            this.label89.Location = new System.Drawing.Point(17, 220);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(73, 20);
            this.label89.TabIndex = 3620;
            this.label89.Text = "Trigger Mode";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbTriggerMode
            // 
            this.CbTriggerMode.DataSource = null;
            this.CbTriggerMode.FillColor = System.Drawing.SystemColors.Control;
            this.CbTriggerMode.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.CbTriggerMode.ForeColor = System.Drawing.Color.Black;
            this.CbTriggerMode.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CbTriggerMode.ItemForeColor = System.Drawing.Color.White;
            this.CbTriggerMode.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.CbTriggerMode.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.CbTriggerMode.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CbTriggerMode.Location = new System.Drawing.Point(95, 217);
            this.CbTriggerMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbTriggerMode.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbTriggerMode.Name = "CbTriggerMode";
            this.CbTriggerMode.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbTriggerMode.RectColor = System.Drawing.Color.DimGray;
            this.CbTriggerMode.Size = new System.Drawing.Size(154, 26);
            this.CbTriggerMode.SymbolSize = 24;
            this.CbTriggerMode.TabIndex = 3619;
            this.CbTriggerMode.Text = "SofrwareTrigger";
            this.CbTriggerMode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbTriggerMode.Watermark = "";
            // 
            // uiSymbolButton28
            // 
            this.uiSymbolButton28.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.CircleRectWidth = 0;
            this.uiSymbolButton28.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton28.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton28.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton28.Location = new System.Drawing.Point(260, 217);
            this.uiSymbolButton28.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton28.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton28.Name = "uiSymbolButton28";
            this.uiSymbolButton28.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton28.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton28.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.Size = new System.Drawing.Size(223, 33);
            this.uiSymbolButton28.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton28.StyleCustomMode = true;
            this.uiSymbolButton28.Symbol = 61671;
            this.uiSymbolButton28.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton28.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton28.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton28.SymbolSize = 20;
            this.uiSymbolButton28.TabIndex = 3597;
            this.uiSymbolButton28.Tag = "";
            this.uiSymbolButton28.Text = "Light Command Setting";
            this.uiSymbolButton28.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton44
            // 
            this.uiSymbolButton44.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.CircleRectWidth = 0;
            this.uiSymbolButton44.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton44.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton44.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton44.Location = new System.Drawing.Point(514, 173);
            this.uiSymbolButton44.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton44.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton44.Name = "uiSymbolButton44";
            this.uiSymbolButton44.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton44.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton44.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton44.Size = new System.Drawing.Size(100, 23);
            this.uiSymbolButton44.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton44.StyleCustomMode = true;
            this.uiSymbolButton44.Symbol = 57359;
            this.uiSymbolButton44.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton44.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton44.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton44.SymbolSize = 18;
            this.uiSymbolButton44.TabIndex = 3596;
            this.uiSymbolButton44.Tag = "ZoomIn";
            this.uiSymbolButton44.Text = "Grab";
            this.uiSymbolButton44.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton43
            // 
            this.uiSymbolButton43.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.CircleRectWidth = 0;
            this.uiSymbolButton43.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton43.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton43.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton43.Location = new System.Drawing.Point(514, 137);
            this.uiSymbolButton43.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton43.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton43.Name = "uiSymbolButton43";
            this.uiSymbolButton43.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton43.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton43.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton43.Size = new System.Drawing.Size(100, 23);
            this.uiSymbolButton43.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton43.StyleCustomMode = true;
            this.uiSymbolButton43.Symbol = 57359;
            this.uiSymbolButton43.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton43.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton43.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton43.SymbolSize = 18;
            this.uiSymbolButton43.TabIndex = 3595;
            this.uiSymbolButton43.Tag = "ZoomIn";
            this.uiSymbolButton43.Text = "Grab";
            this.uiSymbolButton43.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton42
            // 
            this.uiSymbolButton42.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.CircleRectWidth = 0;
            this.uiSymbolButton42.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton42.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton42.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton42.Location = new System.Drawing.Point(514, 101);
            this.uiSymbolButton42.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton42.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton42.Name = "uiSymbolButton42";
            this.uiSymbolButton42.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton42.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton42.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton42.Size = new System.Drawing.Size(100, 23);
            this.uiSymbolButton42.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton42.StyleCustomMode = true;
            this.uiSymbolButton42.Symbol = 57359;
            this.uiSymbolButton42.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton42.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton42.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton42.SymbolSize = 18;
            this.uiSymbolButton42.TabIndex = 3594;
            this.uiSymbolButton42.Tag = "ZoomIn";
            this.uiSymbolButton42.Text = "Grab";
            this.uiSymbolButton42.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton41
            // 
            this.uiSymbolButton41.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.CircleRectWidth = 0;
            this.uiSymbolButton41.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton41.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton41.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton41.Location = new System.Drawing.Point(514, 67);
            this.uiSymbolButton41.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton41.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton41.Name = "uiSymbolButton41";
            this.uiSymbolButton41.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton41.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton41.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton41.Size = new System.Drawing.Size(100, 23);
            this.uiSymbolButton41.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton41.StyleCustomMode = true;
            this.uiSymbolButton41.Symbol = 57359;
            this.uiSymbolButton41.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton41.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton41.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton41.SymbolSize = 18;
            this.uiSymbolButton41.TabIndex = 3593;
            this.uiSymbolButton41.Tag = "ZoomIn";
            this.uiSymbolButton41.Text = "Grab";
            this.uiSymbolButton41.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton35
            // 
            this.uiSymbolButton35.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.CircleRectWidth = 0;
            this.uiSymbolButton35.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton35.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton35.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton35.Location = new System.Drawing.Point(514, 31);
            this.uiSymbolButton35.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton35.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton35.Name = "uiSymbolButton35";
            this.uiSymbolButton35.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton35.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton35.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton35.Size = new System.Drawing.Size(100, 23);
            this.uiSymbolButton35.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton35.StyleCustomMode = true;
            this.uiSymbolButton35.Symbol = 57359;
            this.uiSymbolButton35.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton35.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton35.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton35.SymbolSize = 18;
            this.uiSymbolButton35.TabIndex = 3592;
            this.uiSymbolButton35.Tag = "ZoomIn";
            this.uiSymbolButton35.Text = "Grab";
            this.uiSymbolButton35.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Arial", 8F);
            this.label52.ForeColor = System.Drawing.Color.Black;
            this.label52.Location = new System.Drawing.Point(379, 175);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(41, 20);
            this.label52.TabIndex = 3589;
            this.label52.Text = "Light";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbLight5
            // 
            this.TbLight5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbLight5.FillColor = System.Drawing.SystemColors.Control;
            this.TbLight5.Font = new System.Drawing.Font("Arial", 8F);
            this.TbLight5.ForeColor = System.Drawing.Color.Black;
            this.TbLight5.Location = new System.Drawing.Point(420, 173);
            this.TbLight5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbLight5.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbLight5.Name = "TbLight5";
            this.TbLight5.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbLight5.RectColor = System.Drawing.Color.DimGray;
            this.TbLight5.ShowText = false;
            this.TbLight5.Size = new System.Drawing.Size(75, 23);
            this.TbLight5.TabIndex = 3588;
            this.TbLight5.Text = "0";
            this.TbLight5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbLight5.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbLight5.Watermark = "";
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Arial", 8F);
            this.label53.ForeColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(257, 175);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(41, 20);
            this.label53.TabIndex = 3587;
            this.label53.Text = "Gain";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbGain5
            // 
            this.TbGain5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbGain5.FillColor = System.Drawing.SystemColors.Control;
            this.TbGain5.Font = new System.Drawing.Font("Arial", 8F);
            this.TbGain5.ForeColor = System.Drawing.Color.Black;
            this.TbGain5.Location = new System.Drawing.Point(298, 173);
            this.TbGain5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbGain5.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbGain5.Name = "TbGain5";
            this.TbGain5.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbGain5.RectColor = System.Drawing.Color.DimGray;
            this.TbGain5.ShowText = false;
            this.TbGain5.Size = new System.Drawing.Size(75, 23);
            this.TbGain5.TabIndex = 3586;
            this.TbGain5.Text = "0";
            this.TbGain5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain5.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbGain5.Watermark = "";
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Arial", 8F);
            this.label54.ForeColor = System.Drawing.Color.Black;
            this.label54.Location = new System.Drawing.Point(92, 175);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(81, 20);
            this.label54.TabIndex = 3585;
            this.label54.Text = "Exposure Time";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.Color.Transparent;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox5.ForeColor = System.Drawing.Color.Black;
            this.checkBox5.Location = new System.Drawing.Point(20, 177);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(65, 18);
            this.checkBox5.TabIndex = 3584;
            this.checkBox5.Text = "Grab #5";
            this.checkBox5.UseVisualStyleBackColor = false;
            // 
            // TbExposure5
            // 
            this.TbExposure5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbExposure5.FillColor = System.Drawing.SystemColors.Control;
            this.TbExposure5.Font = new System.Drawing.Font("Arial", 8F);
            this.TbExposure5.ForeColor = System.Drawing.Color.Black;
            this.TbExposure5.Location = new System.Drawing.Point(174, 173);
            this.TbExposure5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbExposure5.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbExposure5.Name = "TbExposure5";
            this.TbExposure5.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbExposure5.RectColor = System.Drawing.Color.DimGray;
            this.TbExposure5.ShowText = false;
            this.TbExposure5.Size = new System.Drawing.Size(75, 23);
            this.TbExposure5.TabIndex = 3582;
            this.TbExposure5.Text = "0";
            this.TbExposure5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbExposure5.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbExposure5.Watermark = "";
            // 
            // uiLine12
            // 
            this.uiLine12.BackColor = System.Drawing.Color.Transparent;
            this.uiLine12.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine12.LineColor = System.Drawing.Color.Black;
            this.uiLine12.Location = new System.Drawing.Point(15, 197);
            this.uiLine12.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine12.Name = "uiLine12";
            this.uiLine12.Size = new System.Drawing.Size(607, 10);
            this.uiLine12.TabIndex = 3583;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Arial", 8F);
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(379, 139);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(41, 20);
            this.label46.TabIndex = 3581;
            this.label46.Text = "Light";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbLight4
            // 
            this.TbLight4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbLight4.FillColor = System.Drawing.SystemColors.Control;
            this.TbLight4.Font = new System.Drawing.Font("Arial", 8F);
            this.TbLight4.ForeColor = System.Drawing.Color.Black;
            this.TbLight4.Location = new System.Drawing.Point(420, 137);
            this.TbLight4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbLight4.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbLight4.Name = "TbLight4";
            this.TbLight4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbLight4.RectColor = System.Drawing.Color.DimGray;
            this.TbLight4.ShowText = false;
            this.TbLight4.Size = new System.Drawing.Size(75, 23);
            this.TbLight4.TabIndex = 3580;
            this.TbLight4.Text = "0";
            this.TbLight4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbLight4.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbLight4.Watermark = "";
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Arial", 8F);
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(257, 139);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(41, 20);
            this.label47.TabIndex = 3579;
            this.label47.Text = "Gain";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbGain4
            // 
            this.TbGain4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbGain4.FillColor = System.Drawing.SystemColors.Control;
            this.TbGain4.Font = new System.Drawing.Font("Arial", 8F);
            this.TbGain4.ForeColor = System.Drawing.Color.Black;
            this.TbGain4.Location = new System.Drawing.Point(298, 137);
            this.TbGain4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbGain4.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbGain4.Name = "TbGain4";
            this.TbGain4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbGain4.RectColor = System.Drawing.Color.DimGray;
            this.TbGain4.ShowText = false;
            this.TbGain4.Size = new System.Drawing.Size(75, 23);
            this.TbGain4.TabIndex = 3578;
            this.TbGain4.Text = "0";
            this.TbGain4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain4.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbGain4.Watermark = "";
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Arial", 8F);
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(92, 139);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(81, 20);
            this.label48.TabIndex = 3577;
            this.label48.Text = "Exposure Time";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox3.ForeColor = System.Drawing.Color.Black;
            this.checkBox3.Location = new System.Drawing.Point(20, 141);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(65, 18);
            this.checkBox3.TabIndex = 3576;
            this.checkBox3.Text = "Grab #4";
            this.checkBox3.UseVisualStyleBackColor = false;
            // 
            // TbExposure4
            // 
            this.TbExposure4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbExposure4.FillColor = System.Drawing.SystemColors.Control;
            this.TbExposure4.Font = new System.Drawing.Font("Arial", 8F);
            this.TbExposure4.ForeColor = System.Drawing.Color.Black;
            this.TbExposure4.Location = new System.Drawing.Point(174, 137);
            this.TbExposure4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbExposure4.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbExposure4.Name = "TbExposure4";
            this.TbExposure4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbExposure4.RectColor = System.Drawing.Color.DimGray;
            this.TbExposure4.ShowText = false;
            this.TbExposure4.Size = new System.Drawing.Size(75, 23);
            this.TbExposure4.TabIndex = 3574;
            this.TbExposure4.Text = "0";
            this.TbExposure4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbExposure4.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbExposure4.Watermark = "";
            // 
            // uiLine10
            // 
            this.uiLine10.BackColor = System.Drawing.Color.Transparent;
            this.uiLine10.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine10.LineColor = System.Drawing.Color.Black;
            this.uiLine10.Location = new System.Drawing.Point(15, 161);
            this.uiLine10.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine10.Name = "uiLine10";
            this.uiLine10.Size = new System.Drawing.Size(607, 10);
            this.uiLine10.TabIndex = 3575;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Arial", 8F);
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(379, 103);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(41, 20);
            this.label49.TabIndex = 3573;
            this.label49.Text = "Light";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbLight3
            // 
            this.TbLight3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbLight3.FillColor = System.Drawing.SystemColors.Control;
            this.TbLight3.Font = new System.Drawing.Font("Arial", 8F);
            this.TbLight3.ForeColor = System.Drawing.Color.Black;
            this.TbLight3.Location = new System.Drawing.Point(420, 101);
            this.TbLight3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbLight3.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbLight3.Name = "TbLight3";
            this.TbLight3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbLight3.RectColor = System.Drawing.Color.DimGray;
            this.TbLight3.ShowText = false;
            this.TbLight3.Size = new System.Drawing.Size(75, 23);
            this.TbLight3.TabIndex = 3572;
            this.TbLight3.Text = "0";
            this.TbLight3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbLight3.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbLight3.Watermark = "";
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Arial", 8F);
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(257, 103);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(41, 20);
            this.label50.TabIndex = 3571;
            this.label50.Text = "Gain";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbGain3
            // 
            this.TbGain3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbGain3.FillColor = System.Drawing.SystemColors.Control;
            this.TbGain3.Font = new System.Drawing.Font("Arial", 8F);
            this.TbGain3.ForeColor = System.Drawing.Color.Black;
            this.TbGain3.Location = new System.Drawing.Point(298, 101);
            this.TbGain3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbGain3.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbGain3.Name = "TbGain3";
            this.TbGain3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbGain3.RectColor = System.Drawing.Color.DimGray;
            this.TbGain3.ShowText = false;
            this.TbGain3.Size = new System.Drawing.Size(75, 23);
            this.TbGain3.TabIndex = 3570;
            this.TbGain3.Text = "0";
            this.TbGain3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain3.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbGain3.Watermark = "";
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Arial", 8F);
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(92, 103);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(81, 20);
            this.label51.TabIndex = 3569;
            this.label51.Text = "Exposure Time";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.Transparent;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox4.ForeColor = System.Drawing.Color.Black;
            this.checkBox4.Location = new System.Drawing.Point(20, 105);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(65, 18);
            this.checkBox4.TabIndex = 3568;
            this.checkBox4.Text = "Grab #3";
            this.checkBox4.UseVisualStyleBackColor = false;
            // 
            // TbExposure3
            // 
            this.TbExposure3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbExposure3.FillColor = System.Drawing.SystemColors.Control;
            this.TbExposure3.Font = new System.Drawing.Font("Arial", 8F);
            this.TbExposure3.ForeColor = System.Drawing.Color.Black;
            this.TbExposure3.Location = new System.Drawing.Point(174, 101);
            this.TbExposure3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbExposure3.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbExposure3.Name = "TbExposure3";
            this.TbExposure3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbExposure3.RectColor = System.Drawing.Color.DimGray;
            this.TbExposure3.ShowText = false;
            this.TbExposure3.Size = new System.Drawing.Size(75, 23);
            this.TbExposure3.TabIndex = 3566;
            this.TbExposure3.Text = "0";
            this.TbExposure3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbExposure3.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbExposure3.Watermark = "";
            // 
            // uiLine11
            // 
            this.uiLine11.BackColor = System.Drawing.Color.Transparent;
            this.uiLine11.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine11.LineColor = System.Drawing.Color.Black;
            this.uiLine11.Location = new System.Drawing.Point(15, 125);
            this.uiLine11.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine11.Name = "uiLine11";
            this.uiLine11.Size = new System.Drawing.Size(607, 10);
            this.uiLine11.TabIndex = 3567;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Arial", 8F);
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(379, 69);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(41, 20);
            this.label40.TabIndex = 3565;
            this.label40.Text = "Light";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbLight2
            // 
            this.TbLight2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbLight2.FillColor = System.Drawing.SystemColors.Control;
            this.TbLight2.Font = new System.Drawing.Font("Arial", 8F);
            this.TbLight2.ForeColor = System.Drawing.Color.Black;
            this.TbLight2.Location = new System.Drawing.Point(420, 67);
            this.TbLight2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbLight2.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbLight2.Name = "TbLight2";
            this.TbLight2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbLight2.RectColor = System.Drawing.Color.DimGray;
            this.TbLight2.ShowText = false;
            this.TbLight2.Size = new System.Drawing.Size(75, 23);
            this.TbLight2.TabIndex = 3564;
            this.TbLight2.Text = "0";
            this.TbLight2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbLight2.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbLight2.Watermark = "";
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Arial", 8F);
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(257, 69);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 20);
            this.label41.TabIndex = 3563;
            this.label41.Text = "Gain";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbGain2
            // 
            this.TbGain2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbGain2.FillColor = System.Drawing.SystemColors.Control;
            this.TbGain2.Font = new System.Drawing.Font("Arial", 8F);
            this.TbGain2.ForeColor = System.Drawing.Color.Black;
            this.TbGain2.Location = new System.Drawing.Point(298, 67);
            this.TbGain2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbGain2.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbGain2.Name = "TbGain2";
            this.TbGain2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbGain2.RectColor = System.Drawing.Color.DimGray;
            this.TbGain2.ShowText = false;
            this.TbGain2.Size = new System.Drawing.Size(75, 23);
            this.TbGain2.TabIndex = 3562;
            this.TbGain2.Text = "0";
            this.TbGain2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain2.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbGain2.Watermark = "";
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Arial", 8F);
            this.label45.ForeColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(92, 69);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(81, 20);
            this.label45.TabIndex = 3561;
            this.label45.Text = "Exposure Time";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox2.ForeColor = System.Drawing.Color.Black;
            this.checkBox2.Location = new System.Drawing.Point(20, 71);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(65, 18);
            this.checkBox2.TabIndex = 3560;
            this.checkBox2.Text = "Grab #2";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // TbExposure2
            // 
            this.TbExposure2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbExposure2.FillColor = System.Drawing.SystemColors.Control;
            this.TbExposure2.Font = new System.Drawing.Font("Arial", 8F);
            this.TbExposure2.ForeColor = System.Drawing.Color.Black;
            this.TbExposure2.Location = new System.Drawing.Point(174, 67);
            this.TbExposure2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbExposure2.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbExposure2.Name = "TbExposure2";
            this.TbExposure2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbExposure2.RectColor = System.Drawing.Color.DimGray;
            this.TbExposure2.ShowText = false;
            this.TbExposure2.Size = new System.Drawing.Size(75, 23);
            this.TbExposure2.TabIndex = 3558;
            this.TbExposure2.Text = "0";
            this.TbExposure2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbExposure2.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbExposure2.Watermark = "";
            // 
            // uiLine9
            // 
            this.uiLine9.BackColor = System.Drawing.Color.Transparent;
            this.uiLine9.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine9.LineColor = System.Drawing.Color.Black;
            this.uiLine9.Location = new System.Drawing.Point(15, 91);
            this.uiLine9.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine9.Name = "uiLine9";
            this.uiLine9.Size = new System.Drawing.Size(607, 10);
            this.uiLine9.TabIndex = 3559;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Arial", 8F);
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(379, 33);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(41, 20);
            this.label44.TabIndex = 3557;
            this.label44.Text = "Light";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbLight1
            // 
            this.TbLight1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbLight1.FillColor = System.Drawing.SystemColors.Control;
            this.TbLight1.Font = new System.Drawing.Font("Arial", 8F);
            this.TbLight1.ForeColor = System.Drawing.Color.Black;
            this.TbLight1.Location = new System.Drawing.Point(420, 31);
            this.TbLight1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbLight1.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbLight1.Name = "TbLight1";
            this.TbLight1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbLight1.RectColor = System.Drawing.Color.DimGray;
            this.TbLight1.ShowText = false;
            this.TbLight1.Size = new System.Drawing.Size(75, 23);
            this.TbLight1.TabIndex = 3556;
            this.TbLight1.Text = "0";
            this.TbLight1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbLight1.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbLight1.Watermark = "";
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Arial", 8F);
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(257, 33);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(41, 20);
            this.label43.TabIndex = 3555;
            this.label43.Text = "Gain";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbGain1
            // 
            this.TbGain1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbGain1.FillColor = System.Drawing.SystemColors.Control;
            this.TbGain1.Font = new System.Drawing.Font("Arial", 8F);
            this.TbGain1.ForeColor = System.Drawing.Color.Black;
            this.TbGain1.Location = new System.Drawing.Point(298, 31);
            this.TbGain1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbGain1.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbGain1.Name = "TbGain1";
            this.TbGain1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbGain1.RectColor = System.Drawing.Color.DimGray;
            this.TbGain1.ShowText = false;
            this.TbGain1.Size = new System.Drawing.Size(75, 23);
            this.TbGain1.TabIndex = 3554;
            this.TbGain1.Text = "0";
            this.TbGain1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain1.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbGain1.Watermark = "";
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Arial", 8F);
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(92, 33);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(81, 20);
            this.label42.TabIndex = 3553;
            this.label42.Text = "Exposure Time";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(20, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 18);
            this.checkBox1.TabIndex = 3552;
            this.checkBox1.Text = "Grab #1";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // BtnIQHWApply
            // 
            this.BtnIQHWApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIQHWApply.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQHWApply.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnIQHWApply.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQHWApply.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnIQHWApply.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnIQHWApply.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIQHWApply.Location = new System.Drawing.Point(489, 217);
            this.BtnIQHWApply.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnIQHWApply.Name = "BtnIQHWApply";
            this.BtnIQHWApply.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQHWApply.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQHWApply.RectPressColor = System.Drawing.Color.White;
            this.BtnIQHWApply.RectSelectedColor = System.Drawing.Color.White;
            this.BtnIQHWApply.Size = new System.Drawing.Size(133, 33);
            this.BtnIQHWApply.Style = Sunny.UI.UIStyle.Custom;
            this.BtnIQHWApply.StyleCustomMode = true;
            this.BtnIQHWApply.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnIQHWApply.SymbolSize = 20;
            this.BtnIQHWApply.TabIndex = 3524;
            this.BtnIQHWApply.Text = "Apply";
            this.BtnIQHWApply.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnIQHWApply.Click += new System.EventHandler(this.BtnIQHWApply_Click);
            // 
            // TbExposure1
            // 
            this.TbExposure1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbExposure1.FillColor = System.Drawing.SystemColors.Control;
            this.TbExposure1.Font = new System.Drawing.Font("Arial", 8F);
            this.TbExposure1.ForeColor = System.Drawing.Color.Black;
            this.TbExposure1.Location = new System.Drawing.Point(174, 31);
            this.TbExposure1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbExposure1.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbExposure1.Name = "TbExposure1";
            this.TbExposure1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbExposure1.RectColor = System.Drawing.Color.DimGray;
            this.TbExposure1.ShowText = false;
            this.TbExposure1.Size = new System.Drawing.Size(75, 23);
            this.TbExposure1.TabIndex = 3520;
            this.TbExposure1.Text = "0";
            this.TbExposure1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbExposure1.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbExposure1.Watermark = "";
            // 
            // uiLine8
            // 
            this.uiLine8.BackColor = System.Drawing.Color.Transparent;
            this.uiLine8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine8.LineColor = System.Drawing.Color.Black;
            this.uiLine8.Location = new System.Drawing.Point(15, 55);
            this.uiLine8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine8.Name = "uiLine8";
            this.uiLine8.Size = new System.Drawing.Size(607, 10);
            this.uiLine8.TabIndex = 3551;
            // 
            // uiGroupBox13
            // 
            this.uiGroupBox13.Controls.Add(this.uiSymbolButton10);
            this.uiGroupBox13.Controls.Add(this.uiSymbolButton18);
            this.uiGroupBox13.Controls.Add(this.uiSymbolButton19);
            this.uiGroupBox13.Controls.Add(this.label37);
            this.uiGroupBox13.Controls.Add(this.uiTextBox13);
            this.uiGroupBox13.Controls.Add(this.label56);
            this.uiGroupBox13.Controls.Add(this.uiLine14);
            this.uiGroupBox13.Controls.Add(this.uiSymbolButton20);
            this.uiGroupBox13.Controls.Add(this.uiSymbolButton21);
            this.uiGroupBox13.Controls.Add(this.label57);
            this.uiGroupBox13.Controls.Add(this.uiTextBox30);
            this.uiGroupBox13.Controls.Add(this.label58);
            this.uiGroupBox13.Controls.Add(this.uiLine15);
            this.uiGroupBox13.Controls.Add(this.uiSymbolButton14);
            this.uiGroupBox13.Controls.Add(this.uiSymbolButton17);
            this.uiGroupBox13.Controls.Add(this.label2);
            this.uiGroupBox13.Controls.Add(this.uiTextBox9);
            this.uiGroupBox13.Controls.Add(this.label36);
            this.uiGroupBox13.Controls.Add(this.uiLine13);
            this.uiGroupBox13.Controls.Add(this.uiSymbolButton13);
            this.uiGroupBox13.Controls.Add(this.uiSymbolButton11);
            this.uiGroupBox13.Controls.Add(this.label66);
            this.uiGroupBox13.Controls.Add(this.uiTextBox41);
            this.uiGroupBox13.Controls.Add(this.label67);
            this.uiGroupBox13.Controls.Add(this.uiLine17);
            this.uiGroupBox13.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox13.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox13.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox13.Location = new System.Drawing.Point(228, 265);
            this.uiGroupBox13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox13.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox13.Name = "uiGroupBox13";
            this.uiGroupBox13.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox13.Radius = 10;
            this.uiGroupBox13.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox13.Size = new System.Drawing.Size(405, 300);
            this.uiGroupBox13.TabIndex = 3469;
            this.uiGroupBox13.Text = "I.Q ( Uniformity)";
            this.uiGroupBox13.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton10
            // 
            this.uiSymbolButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton10.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton10.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton10.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton10.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton10.Location = new System.Drawing.Point(265, 251);
            this.uiSymbolButton10.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton10.Name = "uiSymbolButton10";
            this.uiSymbolButton10.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton10.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton10.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton10.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton10.Size = new System.Drawing.Size(133, 33);
            this.uiSymbolButton10.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton10.StyleCustomMode = true;
            this.uiSymbolButton10.Symbol = 61639;
            this.uiSymbolButton10.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton10.SymbolSize = 20;
            this.uiSymbolButton10.TabIndex = 3611;
            this.uiSymbolButton10.Text = "Save As";
            this.uiSymbolButton10.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton18
            // 
            this.uiSymbolButton18.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.CircleRectWidth = 0;
            this.uiSymbolButton18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton18.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton18.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton18.Location = new System.Drawing.Point(332, 136);
            this.uiSymbolButton18.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton18.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton18.Name = "uiSymbolButton18";
            this.uiSymbolButton18.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton18.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton18.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton18.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton18.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton18.StyleCustomMode = true;
            this.uiSymbolButton18.Symbol = 361773;
            this.uiSymbolButton18.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton18.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton18.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton18.SymbolSize = 18;
            this.uiSymbolButton18.TabIndex = 3610;
            this.uiSymbolButton18.Tag = "ZoomIn";
            this.uiSymbolButton18.Text = "Get";
            this.uiSymbolButton18.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton19
            // 
            this.uiSymbolButton19.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.CircleRectWidth = 0;
            this.uiSymbolButton19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton19.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton19.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton19.Location = new System.Drawing.Point(265, 136);
            this.uiSymbolButton19.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton19.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton19.Name = "uiSymbolButton19";
            this.uiSymbolButton19.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton19.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton19.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton19.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton19.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton19.StyleCustomMode = true;
            this.uiSymbolButton19.Symbol = 361541;
            this.uiSymbolButton19.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton19.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton19.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton19.SymbolSize = 18;
            this.uiSymbolButton19.TabIndex = 3609;
            this.uiSymbolButton19.Tag = "ZoomIn";
            this.uiSymbolButton19.Text = "Set";
            this.uiSymbolButton19.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(17, 138);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(72, 20);
            this.label37.TabIndex = 3608;
            this.label37.Text = "Position #4";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox13
            // 
            this.uiTextBox13.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox13.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox13.Font = new System.Drawing.Font("Arial", 8F);
            this.uiTextBox13.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox13.Location = new System.Drawing.Point(195, 136);
            this.uiTextBox13.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox13.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox13.Name = "uiTextBox13";
            this.uiTextBox13.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox13.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox13.ShowText = false;
            this.uiTextBox13.Size = new System.Drawing.Size(65, 23);
            this.uiTextBox13.TabIndex = 3607;
            this.uiTextBox13.Text = "0";
            this.uiTextBox13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox13.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBox13.Watermark = "";
            // 
            // label56
            // 
            this.label56.Font = new System.Drawing.Font("Arial", 8F);
            this.label56.ForeColor = System.Drawing.Color.Black;
            this.label56.Location = new System.Drawing.Point(92, 138);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(107, 20);
            this.label56.TabIndex = 3606;
            this.label56.Text = "Brightness (Mean)";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine14
            // 
            this.uiLine14.BackColor = System.Drawing.Color.Transparent;
            this.uiLine14.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine14.LineColor = System.Drawing.Color.Black;
            this.uiLine14.Location = new System.Drawing.Point(15, 160);
            this.uiLine14.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine14.Name = "uiLine14";
            this.uiLine14.Size = new System.Drawing.Size(386, 10);
            this.uiLine14.TabIndex = 3605;
            // 
            // uiSymbolButton20
            // 
            this.uiSymbolButton20.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.CircleRectWidth = 0;
            this.uiSymbolButton20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton20.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton20.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton20.Location = new System.Drawing.Point(332, 101);
            this.uiSymbolButton20.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton20.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton20.Name = "uiSymbolButton20";
            this.uiSymbolButton20.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton20.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton20.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton20.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton20.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton20.StyleCustomMode = true;
            this.uiSymbolButton20.Symbol = 361773;
            this.uiSymbolButton20.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton20.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton20.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton20.SymbolSize = 18;
            this.uiSymbolButton20.TabIndex = 3604;
            this.uiSymbolButton20.Tag = "ZoomIn";
            this.uiSymbolButton20.Text = "Get";
            this.uiSymbolButton20.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton21
            // 
            this.uiSymbolButton21.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.CircleRectWidth = 0;
            this.uiSymbolButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton21.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton21.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton21.Location = new System.Drawing.Point(265, 101);
            this.uiSymbolButton21.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton21.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton21.Name = "uiSymbolButton21";
            this.uiSymbolButton21.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton21.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton21.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton21.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton21.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton21.StyleCustomMode = true;
            this.uiSymbolButton21.Symbol = 361541;
            this.uiSymbolButton21.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton21.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton21.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton21.SymbolSize = 18;
            this.uiSymbolButton21.TabIndex = 3603;
            this.uiSymbolButton21.Tag = "ZoomIn";
            this.uiSymbolButton21.Text = "Set";
            this.uiSymbolButton21.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.Black;
            this.label57.Location = new System.Drawing.Point(17, 103);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(72, 20);
            this.label57.TabIndex = 3602;
            this.label57.Text = "Position #3";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox30
            // 
            this.uiTextBox30.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox30.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox30.Font = new System.Drawing.Font("Arial", 8F);
            this.uiTextBox30.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox30.Location = new System.Drawing.Point(195, 101);
            this.uiTextBox30.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox30.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox30.Name = "uiTextBox30";
            this.uiTextBox30.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox30.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox30.ShowText = false;
            this.uiTextBox30.Size = new System.Drawing.Size(65, 23);
            this.uiTextBox30.TabIndex = 3601;
            this.uiTextBox30.Text = "0";
            this.uiTextBox30.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox30.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBox30.Watermark = "";
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Arial", 8F);
            this.label58.ForeColor = System.Drawing.Color.Black;
            this.label58.Location = new System.Drawing.Point(92, 103);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(107, 20);
            this.label58.TabIndex = 3600;
            this.label58.Text = "Brightness (Mean)";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine15
            // 
            this.uiLine15.BackColor = System.Drawing.Color.Transparent;
            this.uiLine15.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine15.LineColor = System.Drawing.Color.Black;
            this.uiLine15.Location = new System.Drawing.Point(15, 125);
            this.uiLine15.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine15.Name = "uiLine15";
            this.uiLine15.Size = new System.Drawing.Size(386, 10);
            this.uiLine15.TabIndex = 3599;
            // 
            // uiSymbolButton14
            // 
            this.uiSymbolButton14.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.CircleRectWidth = 0;
            this.uiSymbolButton14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton14.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton14.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton14.Location = new System.Drawing.Point(332, 66);
            this.uiSymbolButton14.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton14.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton14.Name = "uiSymbolButton14";
            this.uiSymbolButton14.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton14.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton14.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton14.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton14.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton14.StyleCustomMode = true;
            this.uiSymbolButton14.Symbol = 361773;
            this.uiSymbolButton14.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton14.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton14.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton14.SymbolSize = 18;
            this.uiSymbolButton14.TabIndex = 3598;
            this.uiSymbolButton14.Tag = "ZoomIn";
            this.uiSymbolButton14.Text = "Get";
            this.uiSymbolButton14.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton17
            // 
            this.uiSymbolButton17.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.CircleRectWidth = 0;
            this.uiSymbolButton17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton17.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton17.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton17.Location = new System.Drawing.Point(265, 66);
            this.uiSymbolButton17.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton17.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton17.Name = "uiSymbolButton17";
            this.uiSymbolButton17.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton17.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton17.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton17.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton17.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton17.StyleCustomMode = true;
            this.uiSymbolButton17.Symbol = 361541;
            this.uiSymbolButton17.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton17.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton17.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton17.SymbolSize = 18;
            this.uiSymbolButton17.TabIndex = 3597;
            this.uiSymbolButton17.Tag = "ZoomIn";
            this.uiSymbolButton17.Text = "Set";
            this.uiSymbolButton17.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 3596;
            this.label2.Text = "Position #2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox9
            // 
            this.uiTextBox9.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox9.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox9.Font = new System.Drawing.Font("Arial", 8F);
            this.uiTextBox9.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox9.Location = new System.Drawing.Point(195, 66);
            this.uiTextBox9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox9.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox9.Name = "uiTextBox9";
            this.uiTextBox9.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox9.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox9.ShowText = false;
            this.uiTextBox9.Size = new System.Drawing.Size(65, 23);
            this.uiTextBox9.TabIndex = 3595;
            this.uiTextBox9.Text = "0";
            this.uiTextBox9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox9.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBox9.Watermark = "";
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Arial", 8F);
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(92, 68);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(107, 20);
            this.label36.TabIndex = 3594;
            this.label36.Text = "Brightness (Mean)";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine13
            // 
            this.uiLine13.BackColor = System.Drawing.Color.Transparent;
            this.uiLine13.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine13.LineColor = System.Drawing.Color.Black;
            this.uiLine13.Location = new System.Drawing.Point(15, 90);
            this.uiLine13.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine13.Name = "uiLine13";
            this.uiLine13.Size = new System.Drawing.Size(386, 10);
            this.uiLine13.TabIndex = 3593;
            // 
            // uiSymbolButton13
            // 
            this.uiSymbolButton13.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.CircleRectWidth = 0;
            this.uiSymbolButton13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton13.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton13.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton13.Location = new System.Drawing.Point(332, 31);
            this.uiSymbolButton13.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton13.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton13.Name = "uiSymbolButton13";
            this.uiSymbolButton13.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton13.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton13.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton13.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton13.StyleCustomMode = true;
            this.uiSymbolButton13.Symbol = 361773;
            this.uiSymbolButton13.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton13.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton13.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton13.SymbolSize = 18;
            this.uiSymbolButton13.TabIndex = 3592;
            this.uiSymbolButton13.Tag = "ZoomIn";
            this.uiSymbolButton13.Text = "Get";
            this.uiSymbolButton13.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton11
            // 
            this.uiSymbolButton11.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.CircleRectWidth = 0;
            this.uiSymbolButton11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton11.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton11.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton11.Location = new System.Drawing.Point(265, 31);
            this.uiSymbolButton11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton11.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton11.Name = "uiSymbolButton11";
            this.uiSymbolButton11.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton11.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton11.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton11.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton11.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton11.StyleCustomMode = true;
            this.uiSymbolButton11.Symbol = 361541;
            this.uiSymbolButton11.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton11.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton11.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton11.SymbolSize = 18;
            this.uiSymbolButton11.TabIndex = 3591;
            this.uiSymbolButton11.Tag = "ZoomIn";
            this.uiSymbolButton11.Text = "Set";
            this.uiSymbolButton11.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(17, 33);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(72, 20);
            this.label66.TabIndex = 3590;
            this.label66.Text = "Position #1";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox41
            // 
            this.uiTextBox41.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox41.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox41.Font = new System.Drawing.Font("Arial", 8F);
            this.uiTextBox41.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox41.Location = new System.Drawing.Point(195, 31);
            this.uiTextBox41.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox41.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox41.Name = "uiTextBox41";
            this.uiTextBox41.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox41.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox41.ShowText = false;
            this.uiTextBox41.Size = new System.Drawing.Size(65, 23);
            this.uiTextBox41.TabIndex = 3554;
            this.uiTextBox41.Text = "0";
            this.uiTextBox41.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox41.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBox41.Watermark = "";
            // 
            // label67
            // 
            this.label67.Font = new System.Drawing.Font("Arial", 8F);
            this.label67.ForeColor = System.Drawing.Color.Black;
            this.label67.Location = new System.Drawing.Point(92, 33);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(107, 20);
            this.label67.TabIndex = 3553;
            this.label67.Text = "Brightness (Mean)";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine17
            // 
            this.uiLine17.BackColor = System.Drawing.Color.Transparent;
            this.uiLine17.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine17.LineColor = System.Drawing.Color.Black;
            this.uiLine17.Location = new System.Drawing.Point(15, 55);
            this.uiLine17.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine17.Name = "uiLine17";
            this.uiLine17.Size = new System.Drawing.Size(386, 10);
            this.uiLine17.TabIndex = 3551;
            // 
            // uiGroupBox12
            // 
            this.uiGroupBox12.Controls.Add(this.label55);
            this.uiGroupBox12.Controls.Add(this.label39);
            this.uiGroupBox12.Controls.Add(this.uiSymbolButton15);
            this.uiGroupBox12.Controls.Add(this.uiSymbolButton16);
            this.uiGroupBox12.Controls.Add(this.uiTextBox14);
            this.uiGroupBox12.Controls.Add(this.label38);
            this.uiGroupBox12.Controls.Add(this.uiSymbolButton9);
            this.uiGroupBox12.Controls.Add(this.uiTextBox7);
            this.uiGroupBox12.Controls.Add(this.uiTextBox8);
            this.uiGroupBox12.Controls.Add(this.label34);
            this.uiGroupBox12.Controls.Add(this.label35);
            this.uiGroupBox12.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox12.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox12.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox12.Location = new System.Drawing.Point(5, 265);
            this.uiGroupBox12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox12.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox12.Name = "uiGroupBox12";
            this.uiGroupBox12.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox12.Radius = 10;
            this.uiGroupBox12.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox12.Size = new System.Drawing.Size(220, 300);
            this.uiGroupBox12.TabIndex = 3467;
            this.uiGroupBox12.Text = "I.Q ( Pixel Size, Focus )";
            this.uiGroupBox12.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Arial", 8F);
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(8, 210);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(203, 25);
            this.label55.TabIndex = 3537;
            this.label55.Text = "Current Focus Value : 0000";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Arial", 8F);
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(7, 185);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(203, 25);
            this.label39.TabIndex = 3536;
            this.label39.Text = "Best Focus Value : 0000";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton15
            // 
            this.uiSymbolButton15.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.CircleRectWidth = 0;
            this.uiSymbolButton15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton15.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton15.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton15.Location = new System.Drawing.Point(118, 137);
            this.uiSymbolButton15.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton15.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton15.Name = "uiSymbolButton15";
            this.uiSymbolButton15.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiSymbolButton15.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton15.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton15.Size = new System.Drawing.Size(85, 30);
            this.uiSymbolButton15.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton15.StyleCustomMode = true;
            this.uiSymbolButton15.Symbol = 61517;
            this.uiSymbolButton15.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton15.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton15.SymbolSize = 18;
            this.uiSymbolButton15.TabIndex = 3535;
            this.uiSymbolButton15.Tag = "ZoomIn";
            this.uiSymbolButton15.Text = "Stop";
            this.uiSymbolButton15.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton16
            // 
            this.uiSymbolButton16.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.CircleRectWidth = 0;
            this.uiSymbolButton16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton16.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton16.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton16.Location = new System.Drawing.Point(27, 137);
            this.uiSymbolButton16.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton16.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton16.Name = "uiSymbolButton16";
            this.uiSymbolButton16.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiSymbolButton16.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton16.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton16.Size = new System.Drawing.Size(85, 30);
            this.uiSymbolButton16.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton16.StyleCustomMode = true;
            this.uiSymbolButton16.Symbol = 61515;
            this.uiSymbolButton16.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton16.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton16.SymbolSize = 18;
            this.uiSymbolButton16.TabIndex = 3534;
            this.uiSymbolButton16.Tag = "ZoomIn";
            this.uiSymbolButton16.Text = "Start";
            this.uiSymbolButton16.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiTextBox14
            // 
            this.uiTextBox14.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox14.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox14.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox14.Location = new System.Drawing.Point(109, 63);
            this.uiTextBox14.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox14.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox14.Name = "uiTextBox14";
            this.uiTextBox14.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox14.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox14.ShowText = false;
            this.uiTextBox14.Size = new System.Drawing.Size(100, 26);
            this.uiTextBox14.TabIndex = 3525;
            this.uiTextBox14.Text = "0.00";
            this.uiTextBox14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox14.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.uiTextBox14.Watermark = "";
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Arial", 8F);
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(7, 63);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(100, 25);
            this.label38.TabIndex = 3526;
            this.label38.Text = "Master Height (mm)";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton9
            // 
            this.uiSymbolButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton9.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton9.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton9.Location = new System.Drawing.Point(18, 251);
            this.uiSymbolButton9.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton9.Name = "uiSymbolButton9";
            this.uiSymbolButton9.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton9.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton9.Size = new System.Drawing.Size(190, 33);
            this.uiSymbolButton9.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton9.StyleCustomMode = true;
            this.uiSymbolButton9.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton9.SymbolSize = 20;
            this.uiSymbolButton9.TabIndex = 3524;
            this.uiSymbolButton9.Text = "Calculate";
            this.uiSymbolButton9.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiTextBox7
            // 
            this.uiTextBox7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox7.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox7.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox7.Location = new System.Drawing.Point(109, 94);
            this.uiTextBox7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox7.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox7.Name = "uiTextBox7";
            this.uiTextBox7.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox7.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox7.ShowText = false;
            this.uiTextBox7.Size = new System.Drawing.Size(100, 26);
            this.uiTextBox7.TabIndex = 3522;
            this.uiTextBox7.Text = "0.00";
            this.uiTextBox7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox7.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.uiTextBox7.Watermark = "";
            // 
            // uiTextBox8
            // 
            this.uiTextBox8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox8.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox8.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox8.Location = new System.Drawing.Point(109, 32);
            this.uiTextBox8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox8.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox8.Name = "uiTextBox8";
            this.uiTextBox8.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox8.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox8.ShowText = false;
            this.uiTextBox8.Size = new System.Drawing.Size(100, 26);
            this.uiTextBox8.TabIndex = 3520;
            this.uiTextBox8.Text = "0.00";
            this.uiTextBox8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox8.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.uiTextBox8.Watermark = "";
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Arial", 8F);
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(7, 94);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(109, 25);
            this.label34.TabIndex = 3523;
            this.label34.Text = "Pixel Size (mm)";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Arial", 8F);
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(7, 32);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(100, 25);
            this.label35.TabIndex = 3521;
            this.label35.Text = "Master Width (mm)";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.uiTabControl6);
            this.tabPage10.Location = new System.Drawing.Point(0, 40);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(200, 60);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "02) Model";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // uiTabControl6
            // 
            this.uiTabControl6.Controls.Add(this.tabPage12);
            this.uiTabControl6.Controls.Add(this.tabPage13);
            this.uiTabControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl6.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl6.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiTabControl6.ItemSize = new System.Drawing.Size(100, 40);
            this.uiTabControl6.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl6.MainPage = "";
            this.uiTabControl6.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl6.Name = "uiTabControl6";
            this.uiTabControl6.SelectedIndex = 0;
            this.uiTabControl6.Size = new System.Drawing.Size(200, 60);
            this.uiTabControl6.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl6.TabBackColor = System.Drawing.SystemColors.Control;
            this.uiTabControl6.TabIndex = 3469;
            this.uiTabControl6.TabSelectedColor = System.Drawing.Color.Transparent;
            this.uiTabControl6.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl6.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl6.TabUnSelectedForeColor = System.Drawing.Color.DimGray;
            this.uiTabControl6.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTabControl6.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.uiSymbolButton54);
            this.tabPage12.Controls.Add(this.uiSymbolButton55);
            this.tabPage12.Controls.Add(this.uiSymbolButton53);
            this.tabPage12.Controls.Add(this.uiSymbolButton50);
            this.tabPage12.Controls.Add(this.uiGroupBox18);
            this.tabPage12.Controls.Add(this.uiGroupBox15);
            this.tabPage12.Location = new System.Drawing.Point(0, 40);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(200, 20);
            this.tabPage12.TabIndex = 2;
            this.tabPage12.Text = "Board";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // uiSymbolButton54
            // 
            this.uiSymbolButton54.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.CircleRectWidth = 0;
            this.uiSymbolButton54.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton54.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton54.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton54.Location = new System.Drawing.Point(410, 51);
            this.uiSymbolButton54.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton54.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton54.Name = "uiSymbolButton54";
            this.uiSymbolButton54.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton54.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton54.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton54.Size = new System.Drawing.Size(174, 32);
            this.uiSymbolButton54.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton54.StyleCustomMode = true;
            this.uiSymbolButton54.Symbol = 361773;
            this.uiSymbolButton54.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton54.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton54.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton54.SymbolSize = 18;
            this.uiSymbolButton54.TabIndex = 3618;
            this.uiSymbolButton54.Tag = "ZoomIn";
            this.uiSymbolButton54.Text = "Load Bare Board";
            this.uiSymbolButton54.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton55
            // 
            this.uiSymbolButton55.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.CircleRectWidth = 0;
            this.uiSymbolButton55.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton55.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton55.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton55.Location = new System.Drawing.Point(410, 16);
            this.uiSymbolButton55.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton55.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton55.Name = "uiSymbolButton55";
            this.uiSymbolButton55.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton55.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton55.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton55.Size = new System.Drawing.Size(174, 32);
            this.uiSymbolButton55.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton55.StyleCustomMode = true;
            this.uiSymbolButton55.Symbol = 361773;
            this.uiSymbolButton55.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton55.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton55.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton55.SymbolSize = 18;
            this.uiSymbolButton55.TabIndex = 3617;
            this.uiSymbolButton55.Tag = "ZoomIn";
            this.uiSymbolButton55.Text = "Save Bare Board";
            this.uiSymbolButton55.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton53
            // 
            this.uiSymbolButton53.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.CircleRectWidth = 0;
            this.uiSymbolButton53.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton53.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton53.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton53.Location = new System.Drawing.Point(233, 51);
            this.uiSymbolButton53.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton53.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton53.Name = "uiSymbolButton53";
            this.uiSymbolButton53.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton53.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton53.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton53.Size = new System.Drawing.Size(174, 32);
            this.uiSymbolButton53.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton53.StyleCustomMode = true;
            this.uiSymbolButton53.Symbol = 361773;
            this.uiSymbolButton53.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton53.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton53.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton53.SymbolSize = 18;
            this.uiSymbolButton53.TabIndex = 3616;
            this.uiSymbolButton53.Tag = "ZoomIn";
            this.uiSymbolButton53.Text = "Load Master Board";
            this.uiSymbolButton53.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton50
            // 
            this.uiSymbolButton50.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.CircleRectWidth = 0;
            this.uiSymbolButton50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton50.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton50.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton50.Location = new System.Drawing.Point(233, 16);
            this.uiSymbolButton50.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton50.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton50.Name = "uiSymbolButton50";
            this.uiSymbolButton50.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton50.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton50.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton50.Size = new System.Drawing.Size(174, 32);
            this.uiSymbolButton50.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton50.StyleCustomMode = true;
            this.uiSymbolButton50.Symbol = 361773;
            this.uiSymbolButton50.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton50.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton50.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton50.SymbolSize = 18;
            this.uiSymbolButton50.TabIndex = 3615;
            this.uiSymbolButton50.Tag = "ZoomIn";
            this.uiSymbolButton50.Text = "Save Master Board";
            this.uiSymbolButton50.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiGroupBox18
            // 
            this.uiGroupBox18.Controls.Add(this.uiSymbolButton56);
            this.uiGroupBox18.Controls.Add(this.uiTextBox34);
            this.uiGroupBox18.Controls.Add(this.label64);
            this.uiGroupBox18.Controls.Add(this.uiTextBox32);
            this.uiGroupBox18.Controls.Add(this.label62);
            this.uiGroupBox18.Controls.Add(this.uiSymbolButton49);
            this.uiGroupBox18.Controls.Add(this.uiSymbolButton48);
            this.uiGroupBox18.Controls.Add(this.uiDataGridView4);
            this.uiGroupBox18.Controls.Add(this.uiSymbolButton47);
            this.uiGroupBox18.Controls.Add(this.uiTextBox31);
            this.uiGroupBox18.Controls.Add(this.label59);
            this.uiGroupBox18.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox18.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox18.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox18.Location = new System.Drawing.Point(5, 73);
            this.uiGroupBox18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox18.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox18.Name = "uiGroupBox18";
            this.uiGroupBox18.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox18.Radius = 10;
            this.uiGroupBox18.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox18.Size = new System.Drawing.Size(1205, 619);
            this.uiGroupBox18.TabIndex = 3614;
            this.uiGroupBox18.Text = "Gerber";
            this.uiGroupBox18.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton56
            // 
            this.uiSymbolButton56.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton56.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton56.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton56.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton56.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton56.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton56.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton56.Location = new System.Drawing.Point(1050, 577);
            this.uiSymbolButton56.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton56.Name = "uiSymbolButton56";
            this.uiSymbolButton56.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton56.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton56.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton56.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton56.Size = new System.Drawing.Size(148, 33);
            this.uiSymbolButton56.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton56.StyleCustomMode = true;
            this.uiSymbolButton56.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton56.SymbolSize = 20;
            this.uiSymbolButton56.TabIndex = 3618;
            this.uiSymbolButton56.Text = "Apply";
            this.uiSymbolButton56.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiTextBox34
            // 
            this.uiTextBox34.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox34.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox34.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox34.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox34.Location = new System.Drawing.Point(708, 526);
            this.uiTextBox34.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox34.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox34.Name = "uiTextBox34";
            this.uiTextBox34.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox34.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox34.ShowText = false;
            this.uiTextBox34.Size = new System.Drawing.Size(100, 26);
            this.uiTextBox34.TabIndex = 3538;
            this.uiTextBox34.Text = "0.00";
            this.uiTextBox34.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox34.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.uiTextBox34.Watermark = "";
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Arial", 8F);
            this.label64.ForeColor = System.Drawing.Color.Black;
            this.label64.Location = new System.Drawing.Point(618, 526);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(100, 25);
            this.label64.TabIndex = 3539;
            this.label64.Text = "Offset Y (mm)";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox32
            // 
            this.uiTextBox32.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox32.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox32.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox32.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox32.Location = new System.Drawing.Point(708, 499);
            this.uiTextBox32.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox32.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox32.Name = "uiTextBox32";
            this.uiTextBox32.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox32.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox32.ShowText = false;
            this.uiTextBox32.Size = new System.Drawing.Size(100, 26);
            this.uiTextBox32.TabIndex = 3536;
            this.uiTextBox32.Text = "0.00";
            this.uiTextBox32.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox32.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.uiTextBox32.Watermark = "";
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("Arial", 8F);
            this.label62.ForeColor = System.Drawing.Color.Black;
            this.label62.Location = new System.Drawing.Point(618, 499);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(100, 25);
            this.label62.TabIndex = 3537;
            this.label62.Text = "Offset X (mm)";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton49
            // 
            this.uiSymbolButton49.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.CircleRectWidth = 0;
            this.uiSymbolButton49.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton49.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton49.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton49.Location = new System.Drawing.Point(617, 464);
            this.uiSymbolButton49.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton49.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton49.Name = "uiSymbolButton49";
            this.uiSymbolButton49.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiSymbolButton49.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton49.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton49.Size = new System.Drawing.Size(148, 26);
            this.uiSymbolButton49.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton49.StyleCustomMode = true;
            this.uiSymbolButton49.Symbol = 362023;
            this.uiSymbolButton49.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton49.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton49.SymbolSize = 18;
            this.uiSymbolButton49.TabIndex = 3535;
            this.uiSymbolButton49.Tag = "ZoomIn";
            this.uiSymbolButton49.Text = "Auto Replace";
            this.uiSymbolButton49.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton48
            // 
            this.uiSymbolButton48.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.CircleRectWidth = 0;
            this.uiSymbolButton48.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton48.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton48.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton48.Location = new System.Drawing.Point(617, 437);
            this.uiSymbolButton48.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton48.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton48.Name = "uiSymbolButton48";
            this.uiSymbolButton48.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiSymbolButton48.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton48.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton48.Size = new System.Drawing.Size(148, 26);
            this.uiSymbolButton48.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton48.StyleCustomMode = true;
            this.uiSymbolButton48.Symbol = 61717;
            this.uiSymbolButton48.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton48.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton48.SymbolSize = 18;
            this.uiSymbolButton48.TabIndex = 3534;
            this.uiSymbolButton48.Tag = "ZoomIn";
            this.uiSymbolButton48.Text = "Region Visible";
            this.uiSymbolButton48.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiDataGridView4
            // 
            this.uiDataGridView4.AllowUserToAddRows = false;
            this.uiDataGridView4.AllowUserToDeleteRows = false;
            this.uiDataGridView4.AllowUserToResizeColumns = false;
            this.uiDataGridView4.AllowUserToResizeRows = false;
            dataGridViewCellStyle58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle58.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle58.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle58;
            this.uiDataGridView4.BackgroundColor = System.Drawing.Color.Silver;
            this.uiDataGridView4.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle59.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle59;
            this.uiDataGridView4.ColumnHeadersHeight = 20;
            this.uiDataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.Column1,
            this.Column2,
            this.dataGridViewTextBoxColumn12});
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle60.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView4.DefaultCellStyle = dataGridViewCellStyle60;
            this.uiDataGridView4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uiDataGridView4.EnableHeadersVisualStyles = false;
            this.uiDataGridView4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiDataGridView4.GridColor = System.Drawing.Color.Silver;
            this.uiDataGridView4.Location = new System.Drawing.Point(10, 65);
            this.uiDataGridView4.MultiSelect = false;
            this.uiDataGridView4.Name = "uiDataGridView4";
            this.uiDataGridView4.ReadOnly = true;
            this.uiDataGridView4.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle61.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle61.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle61.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle61.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView4.RowHeadersDefaultCellStyle = dataGridViewCellStyle61;
            this.uiDataGridView4.RowHeadersVisible = false;
            this.uiDataGridView4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle62.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle62.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle62.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle62.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView4.RowsDefaultCellStyle = dataGridViewCellStyle62;
            this.uiDataGridView4.RowTemplate.Height = 25;
            this.uiDataGridView4.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView4.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView4.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView4.ScrollBarStyleInherited = false;
            this.uiDataGridView4.SelectedIndex = -1;
            this.uiDataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridView4.Size = new System.Drawing.Size(600, 491);
            this.uiDataGridView4.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView4.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView4.TabIndex = 3533;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Location No";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Part Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Enabled";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 75;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Position";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // uiSymbolButton47
            // 
            this.uiSymbolButton47.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.CircleRectWidth = 0;
            this.uiSymbolButton47.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton47.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton47.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton47.Location = new System.Drawing.Point(510, 32);
            this.uiSymbolButton47.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton47.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton47.Name = "uiSymbolButton47";
            this.uiSymbolButton47.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiSymbolButton47.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton47.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton47.Size = new System.Drawing.Size(100, 26);
            this.uiSymbolButton47.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton47.StyleCustomMode = true;
            this.uiSymbolButton47.Symbol = 61717;
            this.uiSymbolButton47.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton47.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton47.SymbolSize = 18;
            this.uiSymbolButton47.TabIndex = 3532;
            this.uiSymbolButton47.Tag = "ZoomIn";
            this.uiSymbolButton47.Text = "Load";
            this.uiSymbolButton47.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiTextBox31
            // 
            this.uiTextBox31.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox31.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox31.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox31.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox31.Location = new System.Drawing.Point(85, 32);
            this.uiTextBox31.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox31.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox31.Name = "uiTextBox31";
            this.uiTextBox31.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox31.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox31.ShowText = false;
            this.uiTextBox31.Size = new System.Drawing.Size(422, 26);
            this.uiTextBox31.TabIndex = 3520;
            this.uiTextBox31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox31.Watermark = "";
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Arial", 8F);
            this.label59.ForeColor = System.Drawing.Color.Black;
            this.label59.Location = new System.Drawing.Point(7, 32);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(71, 25);
            this.label59.TabIndex = 3521;
            this.label59.Text = "Path";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox15
            // 
            this.uiGroupBox15.Controls.Add(this.uiTextBox33);
            this.uiGroupBox15.Controls.Add(this.label63);
            this.uiGroupBox15.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox15.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox15.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox15.Location = new System.Drawing.Point(5, 0);
            this.uiGroupBox15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox15.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox15.Name = "uiGroupBox15";
            this.uiGroupBox15.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox15.Radius = 10;
            this.uiGroupBox15.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox15.Size = new System.Drawing.Size(220, 72);
            this.uiGroupBox15.TabIndex = 3613;
            this.uiGroupBox15.Text = "Board Info";
            this.uiGroupBox15.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox33
            // 
            this.uiTextBox33.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox33.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox33.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox33.Location = new System.Drawing.Point(109, 32);
            this.uiTextBox33.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox33.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox33.Name = "uiTextBox33";
            this.uiTextBox33.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox33.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox33.ShowText = false;
            this.uiTextBox33.Size = new System.Drawing.Size(100, 26);
            this.uiTextBox33.TabIndex = 3520;
            this.uiTextBox33.Text = "0";
            this.uiTextBox33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox33.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBox33.Watermark = "";
            // 
            // label63
            // 
            this.label63.Font = new System.Drawing.Font("Arial", 8F);
            this.label63.ForeColor = System.Drawing.Color.Black;
            this.label63.Location = new System.Drawing.Point(7, 32);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(100, 25);
            this.label63.TabIndex = 3521;
            this.label63.Text = "Array Count";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.uiGroupBox17);
            this.tabPage13.Controls.Add(this.uiGroupBox16);
            this.tabPage13.Location = new System.Drawing.Point(0, 40);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(200, 60);
            this.tabPage13.TabIndex = 3;
            this.tabPage13.Text = "Fiducial";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox17
            // 
            this.uiGroupBox17.Controls.Add(this.label4);
            this.uiGroupBox17.Controls.Add(this.uiSymbolButton3);
            this.uiGroupBox17.Controls.Add(this.uiLine20);
            this.uiGroupBox17.Controls.Add(this.uiSymbolButton1);
            this.uiGroupBox17.Controls.Add(this.uiSymbolButton2);
            this.uiGroupBox17.Controls.Add(this.label3);
            this.uiGroupBox17.Controls.Add(this.uiLine18);
            this.uiGroupBox17.Controls.Add(this.uiComboBox5);
            this.uiGroupBox17.Controls.Add(this.uiSymbolButton46);
            this.uiGroupBox17.Controls.Add(this.uiSymbolButton51);
            this.uiGroupBox17.Controls.Add(this.uiSymbolButton52);
            this.uiGroupBox17.Controls.Add(this.label60);
            this.uiGroupBox17.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox17.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox17.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox17.Location = new System.Drawing.Point(5, 272);
            this.uiGroupBox17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox17.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox17.Name = "uiGroupBox17";
            this.uiGroupBox17.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox17.Radius = 10;
            this.uiGroupBox17.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox17.Size = new System.Drawing.Size(323, 262);
            this.uiGroupBox17.TabIndex = 3613;
            this.uiGroupBox17.Text = "Array Region";
            this.uiGroupBox17.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 3626;
            this.label4.Text = "Data :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton3
            // 
            this.uiSymbolButton3.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.CircleRectWidth = 0;
            this.uiSymbolButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton3.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton3.Location = new System.Drawing.Point(95, 74);
            this.uiSymbolButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton3.Name = "uiSymbolButton3";
            this.uiSymbolButton3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.Size = new System.Drawing.Size(74, 23);
            this.uiSymbolButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton3.StyleCustomMode = true;
            this.uiSymbolButton3.Symbol = 61442;
            this.uiSymbolButton3.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton3.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton3.SymbolSize = 18;
            this.uiSymbolButton3.TabIndex = 3625;
            this.uiSymbolButton3.Tag = "ZoomIn";
            this.uiSymbolButton3.Text = "Find";
            this.uiSymbolButton3.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiLine20
            // 
            this.uiLine20.BackColor = System.Drawing.Color.Transparent;
            this.uiLine20.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine20.LineColor = System.Drawing.Color.Black;
            this.uiLine20.Location = new System.Drawing.Point(15, 126);
            this.uiLine20.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine20.Name = "uiLine20";
            this.uiLine20.Size = new System.Drawing.Size(296, 10);
            this.uiLine20.TabIndex = 3624;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.CircleRectWidth = 0;
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton1.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton1.Location = new System.Drawing.Point(240, 74);
            this.uiSymbolButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton1.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.StyleCustomMode = true;
            this.uiSymbolButton1.Symbol = 361773;
            this.uiSymbolButton1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton1.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton1.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton1.SymbolSize = 18;
            this.uiSymbolButton1.TabIndex = 3622;
            this.uiSymbolButton1.Tag = "ZoomIn";
            this.uiSymbolButton1.Text = "SET";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.CircleRectWidth = 0;
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton2.Location = new System.Drawing.Point(173, 74);
            this.uiSymbolButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton2.StyleCustomMode = true;
            this.uiSymbolButton2.Symbol = 62024;
            this.uiSymbolButton2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton2.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton2.SymbolSize = 18;
            this.uiSymbolButton2.TabIndex = 3621;
            this.uiSymbolButton2.Tag = "ZoomIn";
            this.uiSymbolButton2.Text = "ROI";
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 3620;
            this.label3.Text = "QR Code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine18
            // 
            this.uiLine18.BackColor = System.Drawing.Color.Transparent;
            this.uiLine18.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine18.LineColor = System.Drawing.Color.Black;
            this.uiLine18.Location = new System.Drawing.Point(15, 60);
            this.uiLine18.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine18.Name = "uiLine18";
            this.uiLine18.Size = new System.Drawing.Size(296, 10);
            this.uiLine18.TabIndex = 3619;
            // 
            // uiComboBox5
            // 
            this.uiComboBox5.DataSource = null;
            this.uiComboBox5.FillColor = System.Drawing.SystemColors.Control;
            this.uiComboBox5.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiComboBox5.ForeColor = System.Drawing.Color.Black;
            this.uiComboBox5.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiComboBox5.ItemForeColor = System.Drawing.Color.White;
            this.uiComboBox5.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiComboBox5.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiComboBox5.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox5.Location = new System.Drawing.Point(95, 33);
            this.uiComboBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox5.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox5.Name = "uiComboBox5";
            this.uiComboBox5.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox5.RectColor = System.Drawing.Color.DimGray;
            this.uiComboBox5.Size = new System.Drawing.Size(74, 26);
            this.uiComboBox5.SymbolSize = 24;
            this.uiComboBox5.TabIndex = 3618;
            this.uiComboBox5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox5.Watermark = "";
            // 
            // uiSymbolButton46
            // 
            this.uiSymbolButton46.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton46.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton46.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton46.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton46.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton46.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton46.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton46.Location = new System.Drawing.Point(173, 215);
            this.uiSymbolButton46.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton46.Name = "uiSymbolButton46";
            this.uiSymbolButton46.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton46.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton46.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton46.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton46.Size = new System.Drawing.Size(133, 33);
            this.uiSymbolButton46.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton46.StyleCustomMode = true;
            this.uiSymbolButton46.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton46.SymbolSize = 20;
            this.uiSymbolButton46.TabIndex = 3617;
            this.uiSymbolButton46.Text = "Apply";
            this.uiSymbolButton46.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton51
            // 
            this.uiSymbolButton51.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.CircleRectWidth = 0;
            this.uiSymbolButton51.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton51.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton51.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton51.Location = new System.Drawing.Point(240, 34);
            this.uiSymbolButton51.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton51.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton51.Name = "uiSymbolButton51";
            this.uiSymbolButton51.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton51.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton51.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton51.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton51.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton51.StyleCustomMode = true;
            this.uiSymbolButton51.Symbol = 361773;
            this.uiSymbolButton51.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton51.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton51.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton51.SymbolSize = 18;
            this.uiSymbolButton51.TabIndex = 3598;
            this.uiSymbolButton51.Tag = "ZoomIn";
            this.uiSymbolButton51.Text = "SET";
            this.uiSymbolButton51.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton52
            // 
            this.uiSymbolButton52.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.CircleRectWidth = 0;
            this.uiSymbolButton52.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton52.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton52.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton52.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton52.Location = new System.Drawing.Point(173, 34);
            this.uiSymbolButton52.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton52.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton52.Name = "uiSymbolButton52";
            this.uiSymbolButton52.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton52.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton52.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton52.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton52.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton52.StyleCustomMode = true;
            this.uiSymbolButton52.Symbol = 62024;
            this.uiSymbolButton52.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton52.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton52.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton52.SymbolSize = 18;
            this.uiSymbolButton52.TabIndex = 3597;
            this.uiSymbolButton52.Tag = "ZoomIn";
            this.uiSymbolButton52.Text = "ROI";
            this.uiSymbolButton52.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label60
            // 
            this.label60.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(17, 33);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(72, 20);
            this.label60.TabIndex = 3590;
            this.label60.Text = "Array Index";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox16
            // 
            this.uiGroupBox16.Controls.Add(this.uiSymbolButton45);
            this.uiGroupBox16.Controls.Add(this.checkBox6);
            this.uiGroupBox16.Controls.Add(this.uiSymbolButton25);
            this.uiGroupBox16.Controls.Add(this.uiSymbolButton26);
            this.uiGroupBox16.Controls.Add(this.cogDisplay6);
            this.uiGroupBox16.Controls.Add(this.cogDisplay5);
            this.uiGroupBox16.Controls.Add(this.uiSymbolButton23);
            this.uiGroupBox16.Controls.Add(this.uiSymbolButton24);
            this.uiGroupBox16.Controls.Add(this.uiLine16);
            this.uiGroupBox16.Controls.Add(this.label61);
            this.uiGroupBox16.Controls.Add(this.uiSymbolButton27);
            this.uiGroupBox16.Controls.Add(this.uiSymbolButton34);
            this.uiGroupBox16.Controls.Add(this.uiLine19);
            this.uiGroupBox16.Controls.Add(this.label68);
            this.uiGroupBox16.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox16.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox16.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox16.Location = new System.Drawing.Point(5, 0);
            this.uiGroupBox16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox16.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox16.Name = "uiGroupBox16";
            this.uiGroupBox16.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox16.Radius = 10;
            this.uiGroupBox16.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox16.Size = new System.Drawing.Size(323, 262);
            this.uiGroupBox16.TabIndex = 3470;
            this.uiGroupBox16.Text = "Fiducial Mark";
            this.uiGroupBox16.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton45
            // 
            this.uiSymbolButton45.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton45.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton45.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton45.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton45.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton45.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton45.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton45.Location = new System.Drawing.Point(173, 215);
            this.uiSymbolButton45.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton45.Name = "uiSymbolButton45";
            this.uiSymbolButton45.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton45.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton45.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton45.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton45.Size = new System.Drawing.Size(133, 33);
            this.uiSymbolButton45.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton45.StyleCustomMode = true;
            this.uiSymbolButton45.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton45.SymbolSize = 20;
            this.uiSymbolButton45.TabIndex = 3617;
            this.uiSymbolButton45.Text = "Apply";
            this.uiSymbolButton45.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.Color.Transparent;
            this.checkBox6.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox6.ForeColor = System.Drawing.Color.Black;
            this.checkBox6.Location = new System.Drawing.Point(15, 181);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(187, 18);
            this.checkBox6.TabIndex = 3616;
            this.checkBox6.Text = "No Align (When you set first time)";
            this.checkBox6.UseVisualStyleBackColor = false;
            // 
            // uiSymbolButton25
            // 
            this.uiSymbolButton25.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.CircleRectWidth = 0;
            this.uiSymbolButton25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton25.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton25.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton25.Location = new System.Drawing.Point(173, 107);
            this.uiSymbolButton25.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton25.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton25.Name = "uiSymbolButton25";
            this.uiSymbolButton25.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton25.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton25.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton25.Size = new System.Drawing.Size(133, 23);
            this.uiSymbolButton25.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton25.StyleCustomMode = true;
            this.uiSymbolButton25.Symbol = 61442;
            this.uiSymbolButton25.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton25.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton25.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton25.SymbolSize = 18;
            this.uiSymbolButton25.TabIndex = 3615;
            this.uiSymbolButton25.Tag = "ZoomIn";
            this.uiSymbolButton25.Text = "Find";
            this.uiSymbolButton25.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton26
            // 
            this.uiSymbolButton26.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.CircleRectWidth = 0;
            this.uiSymbolButton26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton26.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton26.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton26.Location = new System.Drawing.Point(173, 37);
            this.uiSymbolButton26.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton26.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton26.Name = "uiSymbolButton26";
            this.uiSymbolButton26.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton26.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton26.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton26.Size = new System.Drawing.Size(133, 23);
            this.uiSymbolButton26.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton26.StyleCustomMode = true;
            this.uiSymbolButton26.Symbol = 61442;
            this.uiSymbolButton26.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton26.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton26.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton26.SymbolSize = 18;
            this.uiSymbolButton26.TabIndex = 3614;
            this.uiSymbolButton26.Tag = "ZoomIn";
            this.uiSymbolButton26.Text = "Find";
            this.uiSymbolButton26.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // cogDisplay6
            // 
            this.cogDisplay6.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay6.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay6.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay6.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay6.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay6.DoubleTapZoomCycleLength = 2;
            this.cogDisplay6.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay6.Location = new System.Drawing.Point(95, 103);
            this.cogDisplay6.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay6.MouseWheelSensitivity = 1D;
            this.cogDisplay6.Name = "cogDisplay6";
            this.cogDisplay6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay6.OcxState")));
            this.cogDisplay6.Size = new System.Drawing.Size(71, 56);
            this.cogDisplay6.TabIndex = 3613;
            this.cogDisplay6.TabStop = false;
            this.cogDisplay6.Tag = "2";
            // 
            // cogDisplay5
            // 
            this.cogDisplay5.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay5.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay5.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay5.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay5.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay5.DoubleTapZoomCycleLength = 2;
            this.cogDisplay5.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay5.Location = new System.Drawing.Point(95, 33);
            this.cogDisplay5.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay5.MouseWheelSensitivity = 1D;
            this.cogDisplay5.Name = "cogDisplay5";
            this.cogDisplay5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay5.OcxState")));
            this.cogDisplay5.Size = new System.Drawing.Size(71, 56);
            this.cogDisplay5.TabIndex = 3612;
            this.cogDisplay5.TabStop = false;
            this.cogDisplay5.Tag = "2";
            // 
            // uiSymbolButton23
            // 
            this.uiSymbolButton23.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.CircleRectWidth = 0;
            this.uiSymbolButton23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton23.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton23.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton23.Location = new System.Drawing.Point(240, 136);
            this.uiSymbolButton23.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton23.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton23.Name = "uiSymbolButton23";
            this.uiSymbolButton23.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton23.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton23.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton23.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton23.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton23.StyleCustomMode = true;
            this.uiSymbolButton23.Symbol = 361773;
            this.uiSymbolButton23.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton23.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton23.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton23.SymbolSize = 18;
            this.uiSymbolButton23.TabIndex = 3610;
            this.uiSymbolButton23.Tag = "ZoomIn";
            this.uiSymbolButton23.Text = "Train";
            this.uiSymbolButton23.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton24
            // 
            this.uiSymbolButton24.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.CircleRectWidth = 0;
            this.uiSymbolButton24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton24.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton24.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton24.Location = new System.Drawing.Point(173, 136);
            this.uiSymbolButton24.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton24.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton24.Name = "uiSymbolButton24";
            this.uiSymbolButton24.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton24.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton24.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton24.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton24.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton24.StyleCustomMode = true;
            this.uiSymbolButton24.Symbol = 62024;
            this.uiSymbolButton24.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton24.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton24.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton24.SymbolSize = 18;
            this.uiSymbolButton24.TabIndex = 3609;
            this.uiSymbolButton24.Tag = "ZoomIn";
            this.uiSymbolButton24.Text = "ROI";
            this.uiSymbolButton24.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiLine16
            // 
            this.uiLine16.BackColor = System.Drawing.Color.Transparent;
            this.uiLine16.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine16.LineColor = System.Drawing.Color.Black;
            this.uiLine16.Location = new System.Drawing.Point(15, 160);
            this.uiLine16.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine16.Name = "uiLine16";
            this.uiLine16.Size = new System.Drawing.Size(296, 10);
            this.uiLine16.TabIndex = 3605;
            // 
            // label61
            // 
            this.label61.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.Black;
            this.label61.Location = new System.Drawing.Point(17, 103);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(72, 20);
            this.label61.TabIndex = 3602;
            this.label61.Text = "Position #2";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton27
            // 
            this.uiSymbolButton27.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.CircleRectWidth = 0;
            this.uiSymbolButton27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton27.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton27.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton27.Location = new System.Drawing.Point(240, 66);
            this.uiSymbolButton27.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton27.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton27.Name = "uiSymbolButton27";
            this.uiSymbolButton27.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton27.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton27.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton27.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton27.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton27.StyleCustomMode = true;
            this.uiSymbolButton27.Symbol = 361773;
            this.uiSymbolButton27.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton27.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton27.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton27.SymbolSize = 18;
            this.uiSymbolButton27.TabIndex = 3598;
            this.uiSymbolButton27.Tag = "ZoomIn";
            this.uiSymbolButton27.Text = "Train";
            this.uiSymbolButton27.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton34
            // 
            this.uiSymbolButton34.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.CircleRectWidth = 0;
            this.uiSymbolButton34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton34.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton34.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton34.Location = new System.Drawing.Point(173, 66);
            this.uiSymbolButton34.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton34.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton34.Name = "uiSymbolButton34";
            this.uiSymbolButton34.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton34.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton34.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton34.Size = new System.Drawing.Size(66, 23);
            this.uiSymbolButton34.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton34.StyleCustomMode = true;
            this.uiSymbolButton34.Symbol = 62024;
            this.uiSymbolButton34.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton34.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton34.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton34.SymbolSize = 18;
            this.uiSymbolButton34.TabIndex = 3597;
            this.uiSymbolButton34.Tag = "ZoomIn";
            this.uiSymbolButton34.Text = "ROI";
            this.uiSymbolButton34.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiLine19
            // 
            this.uiLine19.BackColor = System.Drawing.Color.Transparent;
            this.uiLine19.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine19.LineColor = System.Drawing.Color.Black;
            this.uiLine19.Location = new System.Drawing.Point(15, 90);
            this.uiLine19.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine19.Name = "uiLine19";
            this.uiLine19.Size = new System.Drawing.Size(296, 10);
            this.uiLine19.TabIndex = 3593;
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.Color.Black;
            this.label68.Location = new System.Drawing.Point(17, 33);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(72, 20);
            this.label68.TabIndex = 3590;
            this.label68.Text = "Position #1";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 60);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "02. LIBRARY";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.label7);
            this.tabPage14.Controls.Add(this.uiTabControl3);
            this.tabPage14.Controls.Add(this.uiSymbolButton63);
            this.tabPage14.Controls.Add(this.label25);
            this.tabPage14.Controls.Add(this.label24);
            this.tabPage14.Controls.Add(this.checkBox8);
            this.tabPage14.Controls.Add(this.uiSymbolButton60);
            this.tabPage14.Controls.Add(this.uiSymbolButton61);
            this.tabPage14.Controls.Add(this.uiSymbolButton62);
            this.tabPage14.Controls.Add(this.dataGridView1);
            this.tabPage14.Controls.Add(this.uiLine25);
            this.tabPage14.Controls.Add(this.uiSymbolButton59);
            this.tabPage14.Controls.Add(this.uiLine22);
            this.tabPage14.Controls.Add(this.uiSymbolButton40);
            this.tabPage14.Controls.Add(this.label20);
            this.tabPage14.Controls.Add(this.label21);
            this.tabPage14.Controls.Add(this.uiTextBox6);
            this.tabPage14.Controls.Add(this.label22);
            this.tabPage14.Controls.Add(this.uiButton1);
            this.tabPage14.Controls.Add(this.label23);
            this.tabPage14.Controls.Add(this.uiSymbolButton57);
            this.tabPage14.Controls.Add(this.uiSymbolButton58);
            this.tabPage14.Controls.Add(this.uiButton9);
            this.tabPage14.Controls.Add(this.uiComboBox2);
            this.tabPage14.Controls.Add(this.uiSymbolButton39);
            this.tabPage14.Controls.Add(this.label18);
            this.tabPage14.Controls.Add(this.uiTextBox10);
            this.tabPage14.Controls.Add(this.label19);
            this.tabPage14.Controls.Add(this.label16);
            this.tabPage14.Controls.Add(this.label15);
            this.tabPage14.Controls.Add(this.uiSymbolButton38);
            this.tabPage14.Controls.Add(this.uiLine21);
            this.tabPage14.Controls.Add(this.uiTextBox4);
            this.tabPage14.Controls.Add(this.label14);
            this.tabPage14.Controls.Add(this.uiTextBox11);
            this.tabPage14.Controls.Add(this.label17);
            this.tabPage14.Controls.Add(this.label6);
            this.tabPage14.Controls.Add(this.checkBox7);
            this.tabPage14.Controls.Add(this.uiSymbolButton36);
            this.tabPage14.Controls.Add(this.uiSymbolButton22);
            this.tabPage14.Controls.Add(this.gridLibrary);
            this.tabPage14.Controls.Add(this.uiSymbolButton37);
            this.tabPage14.Controls.Add(this.uiComboBox1);
            this.tabPage14.Location = new System.Drawing.Point(0, 40);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Size = new System.Drawing.Size(200, 60);
            this.tabPage14.TabIndex = 2;
            this.tabPage14.Text = "03. JOB";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(544, 530);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 75);
            this.label7.TabIndex = 3681;
            this.label7.Text = "→";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTabControl3
            // 
            this.uiTabControl3.Controls.Add(this.tabPage4);
            this.uiTabControl3.Controls.Add(this.tabPage18);
            this.uiTabControl3.Controls.Add(this.tabPage5);
            this.uiTabControl3.Controls.Add(this.tabPage6);
            this.uiTabControl3.Controls.Add(this.tabPage7);
            this.uiTabControl3.Controls.Add(this.tabPage8);
            this.uiTabControl3.Controls.Add(this.tabPage9);
            this.uiTabControl3.Controls.Add(this.tabPage11);
            this.uiTabControl3.Controls.Add(this.tabPage19);
            this.uiTabControl3.Controls.Add(this.tabPage20);
            this.uiTabControl3.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl3.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiTabControl3.ItemSize = new System.Drawing.Size(50, 40);
            this.uiTabControl3.Location = new System.Drawing.Point(558, -30);
            this.uiTabControl3.MainPage = "";
            this.uiTabControl3.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl3.Name = "uiTabControl3";
            this.uiTabControl3.SelectedIndex = 0;
            this.uiTabControl3.Size = new System.Drawing.Size(658, 814);
            this.uiTabControl3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl3.TabBackColor = System.Drawing.SystemColors.Control;
            this.uiTabControl3.TabIndex = 3470;
            this.uiTabControl3.TabSelectedColor = System.Drawing.Color.Transparent;
            this.uiTabControl3.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl3.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl3.TabUnSelectedForeColor = System.Drawing.Color.DimGray;
            this.uiTabControl3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTabControl3.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label90);
            this.tabPage4.Controls.Add(this.label76);
            this.tabPage4.Controls.Add(this.cogDisplay7);
            this.tabPage4.Controls.Add(this.cogDisplay8);
            this.tabPage4.Controls.Add(this.cogDisplay9);
            this.tabPage4.Controls.Add(this.cogDisplay10);
            this.tabPage4.Controls.Add(this.cogDisplay11);
            this.tabPage4.Controls.Add(this.uiButton10);
            this.tabPage4.Controls.Add(this.uiButton11);
            this.tabPage4.Controls.Add(this.uiButton13);
            this.tabPage4.Controls.Add(this.uiButton14);
            this.tabPage4.Controls.Add(this.uiButton15);
            this.tabPage4.Controls.Add(this.label32);
            this.tabPage4.Controls.Add(this.uiLine23);
            this.tabPage4.Controls.Add(this.uiGroupBox2);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.uiGroupBox10);
            this.tabPage4.Controls.Add(this.uiGroupBox3);
            this.tabPage4.Location = new System.Drawing.Point(0, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(658, 774);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Board";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.ForeColor = System.Drawing.Color.Black;
            this.label90.Location = new System.Drawing.Point(29, 687);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(427, 20);
            this.label90.TabIndex = 3669;
            this.label90.Text = "알고리즘 디버깅을 위한 이미지 풀";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label76
            // 
            this.label76.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.Color.Black;
            this.label76.Location = new System.Drawing.Point(173, 8);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(427, 20);
            this.label76.TabIndex = 3658;
            this.label76.Text = "알고리즘 적용 전 전처리";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cogDisplay7
            // 
            this.cogDisplay7.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay7.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay7.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay7.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay7.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay7.DoubleTapZoomCycleLength = 2;
            this.cogDisplay7.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay7.Location = new System.Drawing.Point(305, 621);
            this.cogDisplay7.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay7.MouseWheelSensitivity = 1D;
            this.cogDisplay7.Name = "cogDisplay7";
            this.cogDisplay7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay7.OcxState")));
            this.cogDisplay7.Size = new System.Drawing.Size(50, 33);
            this.cogDisplay7.TabIndex = 3668;
            this.cogDisplay7.TabStop = false;
            this.cogDisplay7.Tag = "2";
            // 
            // cogDisplay8
            // 
            this.cogDisplay8.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay8.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay8.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay8.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay8.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay8.DoubleTapZoomCycleLength = 2;
            this.cogDisplay8.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay8.Location = new System.Drawing.Point(249, 621);
            this.cogDisplay8.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay8.MouseWheelSensitivity = 1D;
            this.cogDisplay8.Name = "cogDisplay8";
            this.cogDisplay8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay8.OcxState")));
            this.cogDisplay8.Size = new System.Drawing.Size(50, 33);
            this.cogDisplay8.TabIndex = 3667;
            this.cogDisplay8.TabStop = false;
            this.cogDisplay8.Tag = "2";
            // 
            // cogDisplay9
            // 
            this.cogDisplay9.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay9.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay9.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay9.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay9.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay9.DoubleTapZoomCycleLength = 2;
            this.cogDisplay9.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay9.Location = new System.Drawing.Point(193, 621);
            this.cogDisplay9.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay9.MouseWheelSensitivity = 1D;
            this.cogDisplay9.Name = "cogDisplay9";
            this.cogDisplay9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay9.OcxState")));
            this.cogDisplay9.Size = new System.Drawing.Size(50, 33);
            this.cogDisplay9.TabIndex = 3666;
            this.cogDisplay9.TabStop = false;
            this.cogDisplay9.Tag = "2";
            // 
            // cogDisplay10
            // 
            this.cogDisplay10.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay10.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay10.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay10.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay10.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay10.DoubleTapZoomCycleLength = 2;
            this.cogDisplay10.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay10.Location = new System.Drawing.Point(137, 621);
            this.cogDisplay10.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay10.MouseWheelSensitivity = 1D;
            this.cogDisplay10.Name = "cogDisplay10";
            this.cogDisplay10.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay10.OcxState")));
            this.cogDisplay10.Size = new System.Drawing.Size(50, 33);
            this.cogDisplay10.TabIndex = 3665;
            this.cogDisplay10.TabStop = false;
            this.cogDisplay10.Tag = "2";
            // 
            // cogDisplay11
            // 
            this.cogDisplay11.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay11.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay11.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay11.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay11.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay11.DoubleTapZoomCycleLength = 2;
            this.cogDisplay11.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay11.Location = new System.Drawing.Point(81, 621);
            this.cogDisplay11.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay11.MouseWheelSensitivity = 1D;
            this.cogDisplay11.Name = "cogDisplay11";
            this.cogDisplay11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay11.OcxState")));
            this.cogDisplay11.Size = new System.Drawing.Size(50, 33);
            this.cogDisplay11.TabIndex = 3664;
            this.cogDisplay11.TabStop = false;
            this.cogDisplay11.Tag = "2";
            // 
            // uiButton10
            // 
            this.uiButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton10.FillColor = System.Drawing.Color.DimGray;
            this.uiButton10.FillSelectedColor = System.Drawing.Color.Green;
            this.uiButton10.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton10.Location = new System.Drawing.Point(305, 655);
            this.uiButton10.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton10.Name = "uiButton10";
            this.uiButton10.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton10.Size = new System.Drawing.Size(50, 20);
            this.uiButton10.TabIndex = 3663;
            this.uiButton10.Text = "5";
            this.uiButton10.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // uiButton11
            // 
            this.uiButton11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton11.FillColor = System.Drawing.Color.DimGray;
            this.uiButton11.FillSelectedColor = System.Drawing.Color.Green;
            this.uiButton11.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton11.Location = new System.Drawing.Point(249, 655);
            this.uiButton11.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton11.Name = "uiButton11";
            this.uiButton11.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton11.Size = new System.Drawing.Size(50, 20);
            this.uiButton11.TabIndex = 3662;
            this.uiButton11.Text = "4";
            this.uiButton11.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // uiButton13
            // 
            this.uiButton13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton13.FillColor = System.Drawing.Color.DimGray;
            this.uiButton13.FillSelectedColor = System.Drawing.Color.Green;
            this.uiButton13.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton13.Location = new System.Drawing.Point(193, 655);
            this.uiButton13.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton13.Name = "uiButton13";
            this.uiButton13.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton13.Size = new System.Drawing.Size(50, 20);
            this.uiButton13.TabIndex = 3661;
            this.uiButton13.Text = "3";
            this.uiButton13.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // uiButton14
            // 
            this.uiButton14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton14.FillColor = System.Drawing.Color.DimGray;
            this.uiButton14.FillSelectedColor = System.Drawing.Color.Green;
            this.uiButton14.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton14.Location = new System.Drawing.Point(137, 655);
            this.uiButton14.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton14.Name = "uiButton14";
            this.uiButton14.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton14.Size = new System.Drawing.Size(50, 20);
            this.uiButton14.TabIndex = 3660;
            this.uiButton14.Text = "2";
            this.uiButton14.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // uiButton15
            // 
            this.uiButton15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton15.FillColor = System.Drawing.Color.DimGray;
            this.uiButton15.FillSelectedColor = System.Drawing.Color.Green;
            this.uiButton15.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton15.Location = new System.Drawing.Point(81, 655);
            this.uiButton15.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton15.Name = "uiButton15";
            this.uiButton15.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton15.Size = new System.Drawing.Size(50, 20);
            this.uiButton15.TabIndex = 3659;
            this.uiButton15.Text = "1";
            this.uiButton15.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Arial", 10F);
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(28, 620);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 51);
            this.label32.TabIndex = 3657;
            this.label32.Text = "Image Pool";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine23
            // 
            this.uiLine23.BackColor = System.Drawing.Color.Transparent;
            this.uiLine23.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine23.LineColor = System.Drawing.Color.Black;
            this.uiLine23.Location = new System.Drawing.Point(24, 674);
            this.uiLine23.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine23.Name = "uiLine23";
            this.uiLine23.Size = new System.Drawing.Size(336, 10);
            this.uiLine23.TabIndex = 3658;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.label29);
            this.uiGroupBox2.Controls.Add(this.label30);
            this.uiGroupBox2.Controls.Add(this.trackbarThresholdMax);
            this.uiGroupBox2.Controls.Add(this.label31);
            this.uiGroupBox2.Controls.Add(this.lblThresholdMin);
            this.uiGroupBox2.Controls.Add(this.uiCheckBox4);
            this.uiGroupBox2.Controls.Add(this.trackbarThresholdMin);
            this.uiGroupBox2.Controls.Add(this.uiRadioButton1);
            this.uiGroupBox2.Controls.Add(this.uiRadioButton2);
            this.uiGroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox2.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox2.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox2.Location = new System.Drawing.Point(11, 30);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Radius = 10;
            this.uiGroupBox2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox2.Size = new System.Drawing.Size(633, 99);
            this.uiGroupBox2.TabIndex = 3654;
            this.uiGroupBox2.Text = "Type";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(147, 58);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(34, 25);
            this.label29.TabIndex = 3525;
            this.label29.Text = "Max";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(595, 58);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(27, 25);
            this.label30.TabIndex = 3524;
            this.label30.Text = "000";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackbarThresholdMax
            // 
            this.trackbarThresholdMax.FillColor = System.Drawing.SystemColors.Control;
            this.trackbarThresholdMax.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.trackbarThresholdMax.ForeColor = System.Drawing.Color.White;
            this.trackbarThresholdMax.Location = new System.Drawing.Point(189, 55);
            this.trackbarThresholdMax.Maximum = 255;
            this.trackbarThresholdMax.MinimumSize = new System.Drawing.Size(1, 1);
            this.trackbarThresholdMax.Name = "trackbarThresholdMax";
            this.trackbarThresholdMax.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.trackbarThresholdMax.Size = new System.Drawing.Size(400, 32);
            this.trackbarThresholdMax.TabIndex = 3523;
            this.trackbarThresholdMax.Text = "uiTrackBar1";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(147, 29);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(34, 25);
            this.label31.TabIndex = 3522;
            this.label31.Text = "Min";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThresholdMin
            // 
            this.lblThresholdMin.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblThresholdMin.ForeColor = System.Drawing.Color.Black;
            this.lblThresholdMin.Location = new System.Drawing.Point(595, 29);
            this.lblThresholdMin.Name = "lblThresholdMin";
            this.lblThresholdMin.Size = new System.Drawing.Size(27, 25);
            this.lblThresholdMin.TabIndex = 3521;
            this.lblThresholdMin.Text = "000";
            this.lblThresholdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiCheckBox4
            // 
            this.uiCheckBox4.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiCheckBox4.CheckBoxSize = 12;
            this.uiCheckBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox4.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiCheckBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBox4.Location = new System.Drawing.Point(10, 58);
            this.uiCheckBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox4.Name = "uiCheckBox4";
            this.uiCheckBox4.Size = new System.Drawing.Size(89, 29);
            this.uiCheckBox4.TabIndex = 3520;
            this.uiCheckBox4.Text = "Invert";
            // 
            // trackbarThresholdMin
            // 
            this.trackbarThresholdMin.FillColor = System.Drawing.SystemColors.Control;
            this.trackbarThresholdMin.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.trackbarThresholdMin.ForeColor = System.Drawing.Color.White;
            this.trackbarThresholdMin.Location = new System.Drawing.Point(189, 26);
            this.trackbarThresholdMin.Maximum = 255;
            this.trackbarThresholdMin.MinimumSize = new System.Drawing.Size(1, 1);
            this.trackbarThresholdMin.Name = "trackbarThresholdMin";
            this.trackbarThresholdMin.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.trackbarThresholdMin.Size = new System.Drawing.Size(400, 32);
            this.trackbarThresholdMin.TabIndex = 3446;
            this.trackbarThresholdMin.Text = "uiTrackBar1";
            // 
            // uiRadioButton1
            // 
            this.uiRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton1.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiRadioButton1.Location = new System.Drawing.Point(66, 35);
            this.uiRadioButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton1.Name = "uiRadioButton1";
            this.uiRadioButton1.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiRadioButton1.RadioButtonSize = 12;
            this.uiRadioButton1.Size = new System.Drawing.Size(89, 20);
            this.uiRadioButton1.TabIndex = 3516;
            this.uiRadioButton1.Text = "Inrange";
            // 
            // uiRadioButton2
            // 
            this.uiRadioButton2.Checked = true;
            this.uiRadioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiRadioButton2.Location = new System.Drawing.Point(10, 35);
            this.uiRadioButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton2.Name = "uiRadioButton2";
            this.uiRadioButton2.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiRadioButton2.RadioButtonSize = 12;
            this.uiRadioButton2.Size = new System.Drawing.Size(89, 20);
            this.uiRadioButton2.TabIndex = 3515;
            this.uiRadioButton2.Text = "Over";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(640, 20);
            this.label8.TabIndex = 3653;
            this.label8.Text = "Filter (Image Processing)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox10
            // 
            this.uiGroupBox10.Controls.Add(this.btnChannelSplit);
            this.uiGroupBox10.Controls.Add(this.label9);
            this.uiGroupBox10.Controls.Add(this.comboChannelSplit);
            this.uiGroupBox10.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox10.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox10.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox10.Location = new System.Drawing.Point(11, 130);
            this.uiGroupBox10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox10.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox10.Name = "uiGroupBox10";
            this.uiGroupBox10.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox10.Radius = 10;
            this.uiGroupBox10.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox10.Size = new System.Drawing.Size(633, 74);
            this.uiGroupBox10.TabIndex = 3656;
            this.uiGroupBox10.Text = "Channel Split";
            this.uiGroupBox10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChannelSplit
            // 
            this.btnChannelSplit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChannelSplit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnChannelSplit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnChannelSplit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnChannelSplit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnChannelSplit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnChannelSplit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChannelSplit.Location = new System.Drawing.Point(294, 28);
            this.btnChannelSplit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnChannelSplit.Name = "btnChannelSplit";
            this.btnChannelSplit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnChannelSplit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnChannelSplit.RectPressColor = System.Drawing.Color.White;
            this.btnChannelSplit.RectSelectedColor = System.Drawing.Color.White;
            this.btnChannelSplit.Size = new System.Drawing.Size(148, 33);
            this.btnChannelSplit.Style = Sunny.UI.UIStyle.Custom;
            this.btnChannelSplit.StyleCustomMode = true;
            this.btnChannelSplit.Symbol = 61515;
            this.btnChannelSplit.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnChannelSplit.SymbolSize = 20;
            this.btnChannelSplit.TabIndex = 3521;
            this.btnChannelSplit.Text = "Split";
            this.btnChannelSplit.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(18, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 25);
            this.label9.TabIndex = 3518;
            this.label9.Text = "Channel";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboChannelSplit
            // 
            this.comboChannelSplit.DataSource = null;
            this.comboChannelSplit.FillColor = System.Drawing.SystemColors.Control;
            this.comboChannelSplit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboChannelSplit.ForeColor = System.Drawing.Color.Black;
            this.comboChannelSplit.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboChannelSplit.ItemForeColor = System.Drawing.Color.White;
            this.comboChannelSplit.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboChannelSplit.Items.AddRange(new object[] {
            "None",
            "Red",
            "Green",
            "Blue",
            "Mono"});
            this.comboChannelSplit.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboChannelSplit.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboChannelSplit.Location = new System.Drawing.Point(72, 28);
            this.comboChannelSplit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboChannelSplit.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboChannelSplit.Name = "comboChannelSplit";
            this.comboChannelSplit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboChannelSplit.RectColor = System.Drawing.Color.DimGray;
            this.comboChannelSplit.Size = new System.Drawing.Size(214, 33);
            this.comboChannelSplit.SymbolSize = 24;
            this.comboChannelSplit.TabIndex = 3517;
            this.comboChannelSplit.Text = "None";
            this.comboChannelSplit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboChannelSplit.Watermark = "";
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.uiSymbolButton30);
            this.uiGroupBox3.Controls.Add(this.uiSymbolButton31);
            this.uiGroupBox3.Controls.Add(this.label10);
            this.uiGroupBox3.Controls.Add(this.uiTextBox2);
            this.uiGroupBox3.Controls.Add(this.label11);
            this.uiGroupBox3.Controls.Add(this.label12);
            this.uiGroupBox3.Controls.Add(this.uiTextBox3);
            this.uiGroupBox3.Controls.Add(this.label13);
            this.uiGroupBox3.Controls.Add(this.uiTextBox1);
            this.uiGroupBox3.Controls.Add(this.label26);
            this.uiGroupBox3.Controls.Add(this.label27);
            this.uiGroupBox3.Controls.Add(this.txtEyeD_Port);
            this.uiGroupBox3.Controls.Add(this.label28);
            this.uiGroupBox3.Controls.Add(this.uiDataGridView1);
            this.uiGroupBox3.Controls.Add(this.comboThresholdType);
            this.uiGroupBox3.Controls.Add(this.btnPreProcessRun_One);
            this.uiGroupBox3.Controls.Add(this.btnPreProcessDel);
            this.uiGroupBox3.Controls.Add(this.btnPreProcessAdd);
            this.uiGroupBox3.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox3.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox3.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox3.Location = new System.Drawing.Point(11, 205);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Radius = 10;
            this.uiGroupBox3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox3.Size = new System.Drawing.Size(633, 346);
            this.uiGroupBox3.TabIndex = 3655;
            this.uiGroupBox3.Text = "Filter";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton30
            // 
            this.uiSymbolButton30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton30.FillColor = System.Drawing.SystemColors.Control;
            this.uiSymbolButton30.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton30.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton30.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton30.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton30.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton30.Location = new System.Drawing.Point(590, 119);
            this.uiSymbolButton30.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton30.Name = "uiSymbolButton30";
            this.uiSymbolButton30.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton30.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton30.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton30.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton30.Size = new System.Drawing.Size(38, 47);
            this.uiSymbolButton30.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton30.StyleCustomMode = true;
            this.uiSymbolButton30.Symbol = 61702;
            this.uiSymbolButton30.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton30.SymbolSize = 20;
            this.uiSymbolButton30.TabIndex = 3527;
            this.uiSymbolButton30.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton31
            // 
            this.uiSymbolButton31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton31.FillColor = System.Drawing.SystemColors.Control;
            this.uiSymbolButton31.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton31.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton31.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton31.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton31.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton31.Location = new System.Drawing.Point(590, 166);
            this.uiSymbolButton31.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton31.Name = "uiSymbolButton31";
            this.uiSymbolButton31.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton31.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton31.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton31.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton31.Size = new System.Drawing.Size(38, 47);
            this.uiSymbolButton31.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton31.StyleCustomMode = true;
            this.uiSymbolButton31.Symbol = 61703;
            this.uiSymbolButton31.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton31.SymbolSize = 20;
            this.uiSymbolButton31.TabIndex = 3528;
            this.uiSymbolButton31.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(477, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 25);
            this.label10.TabIndex = 3526;
            this.label10.Text = "2 : ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox2
            // 
            this.uiTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox2.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox2.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox2.Location = new System.Drawing.Point(506, 84);
            this.uiTextBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox2.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox2.Name = "uiTextBox2";
            this.uiTextBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox2.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox2.ShowText = false;
            this.uiTextBox2.Size = new System.Drawing.Size(75, 26);
            this.uiTextBox2.TabIndex = 3525;
            this.uiTextBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox2.Watermark = "";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(366, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 25);
            this.label11.TabIndex = 3524;
            this.label11.Text = "1 : ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(303, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 25);
            this.label12.TabIndex = 3523;
            this.label12.Text = "Parameter";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox3
            // 
            this.uiTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox3.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox3.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox3.Location = new System.Drawing.Point(395, 83);
            this.uiTextBox3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox3.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox3.Name = "uiTextBox3";
            this.uiTextBox3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox3.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox3.ShowText = false;
            this.uiTextBox3.Size = new System.Drawing.Size(75, 26);
            this.uiTextBox3.TabIndex = 3522;
            this.uiTextBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox3.Watermark = "";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(182, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 25);
            this.label13.TabIndex = 3521;
            this.label13.Text = "H : ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox1.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox1.Location = new System.Drawing.Point(211, 84);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox1.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(75, 26);
            this.uiTextBox1.TabIndex = 3520;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox1.Watermark = "";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(71, 83);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(26, 25);
            this.label26.TabIndex = 3519;
            this.label26.Text = "W : ";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(18, 83);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(51, 25);
            this.label27.TabIndex = 3518;
            this.label27.Text = "Kernel";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEyeD_Port
            // 
            this.txtEyeD_Port.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEyeD_Port.FillColor = System.Drawing.SystemColors.Control;
            this.txtEyeD_Port.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEyeD_Port.ForeColor = System.Drawing.Color.Black;
            this.txtEyeD_Port.Location = new System.Drawing.Point(100, 83);
            this.txtEyeD_Port.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtEyeD_Port.MinimumSize = new System.Drawing.Size(1, 20);
            this.txtEyeD_Port.Name = "txtEyeD_Port";
            this.txtEyeD_Port.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtEyeD_Port.RectColor = System.Drawing.Color.DimGray;
            this.txtEyeD_Port.ShowText = false;
            this.txtEyeD_Port.Size = new System.Drawing.Size(75, 26);
            this.txtEyeD_Port.TabIndex = 3517;
            this.txtEyeD_Port.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtEyeD_Port.Watermark = "";
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(18, 43);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(51, 25);
            this.label28.TabIndex = 3516;
            this.label28.Text = "Name";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiDataGridView1
            // 
            this.uiDataGridView1.AllowUserToAddRows = false;
            this.uiDataGridView1.AllowUserToDeleteRows = false;
            this.uiDataGridView1.AllowUserToResizeColumns = false;
            this.uiDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle63.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle63.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle63.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle63.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle63;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle64.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle64.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle64.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle64.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle64.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle64.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle64;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle65.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle65.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle65.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle65.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle65.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle65.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle65;
            this.uiDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.Silver;
            this.uiDataGridView1.Location = new System.Drawing.Point(21, 119);
            this.uiDataGridView1.MultiSelect = false;
            this.uiDataGridView1.Name = "uiDataGridView1";
            this.uiDataGridView1.ReadOnly = true;
            this.uiDataGridView1.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle66.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle66.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle66.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle66.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle66.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle66;
            this.uiDataGridView1.RowHeadersVisible = false;
            this.uiDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle67.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle67.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle67.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle67.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle67;
            this.uiDataGridView1.RowTemplate.Height = 25;
            this.uiDataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView1.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView1.ScrollBarStyleInherited = false;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridView1.Size = new System.Drawing.Size(568, 213);
            this.uiDataGridView1.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView1.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView1.TabIndex = 3515;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Feature";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "Use";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Width = 45;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Min";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Current";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Max";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 75;
            // 
            // comboThresholdType
            // 
            this.comboThresholdType.DataSource = null;
            this.comboThresholdType.FillColor = System.Drawing.SystemColors.Control;
            this.comboThresholdType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboThresholdType.ForeColor = System.Drawing.Color.Black;
            this.comboThresholdType.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboThresholdType.ItemForeColor = System.Drawing.Color.White;
            this.comboThresholdType.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboThresholdType.Items.AddRange(new object[] {
            "Binary",
            "BinaryInv",
            "Otsu"});
            this.comboThresholdType.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboThresholdType.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboThresholdType.Location = new System.Drawing.Point(72, 39);
            this.comboThresholdType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboThresholdType.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboThresholdType.Name = "comboThresholdType";
            this.comboThresholdType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboThresholdType.RectColor = System.Drawing.Color.DimGray;
            this.comboThresholdType.Size = new System.Drawing.Size(214, 33);
            this.comboThresholdType.SymbolSize = 24;
            this.comboThresholdType.TabIndex = 3445;
            this.comboThresholdType.Text = "Binary";
            this.comboThresholdType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboThresholdType.Watermark = "";
            // 
            // btnPreProcessRun_One
            // 
            this.btnPreProcessRun_One.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreProcessRun_One.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessRun_One.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPreProcessRun_One.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessRun_One.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPreProcessRun_One.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPreProcessRun_One.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreProcessRun_One.Location = new System.Drawing.Point(480, 39);
            this.btnPreProcessRun_One.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPreProcessRun_One.Name = "btnPreProcessRun_One";
            this.btnPreProcessRun_One.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessRun_One.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessRun_One.RectPressColor = System.Drawing.Color.White;
            this.btnPreProcessRun_One.RectSelectedColor = System.Drawing.Color.White;
            this.btnPreProcessRun_One.Size = new System.Drawing.Size(148, 33);
            this.btnPreProcessRun_One.Style = Sunny.UI.UIStyle.Custom;
            this.btnPreProcessRun_One.StyleCustomMode = true;
            this.btnPreProcessRun_One.Symbol = 61515;
            this.btnPreProcessRun_One.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnPreProcessRun_One.SymbolSize = 20;
            this.btnPreProcessRun_One.TabIndex = 3520;
            this.btnPreProcessRun_One.Text = "Run (One)";
            this.btnPreProcessRun_One.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnPreProcessDel
            // 
            this.btnPreProcessDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreProcessDel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessDel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPreProcessDel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessDel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPreProcessDel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPreProcessDel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreProcessDel.Location = new System.Drawing.Point(387, 39);
            this.btnPreProcessDel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPreProcessDel.Name = "btnPreProcessDel";
            this.btnPreProcessDel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessDel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessDel.RectPressColor = System.Drawing.Color.White;
            this.btnPreProcessDel.RectSelectedColor = System.Drawing.Color.White;
            this.btnPreProcessDel.Size = new System.Drawing.Size(87, 33);
            this.btnPreProcessDel.Style = Sunny.UI.UIStyle.Custom;
            this.btnPreProcessDel.StyleCustomMode = true;
            this.btnPreProcessDel.Symbol = 61544;
            this.btnPreProcessDel.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnPreProcessDel.SymbolSize = 20;
            this.btnPreProcessDel.TabIndex = 3523;
            this.btnPreProcessDel.Text = "Delete";
            this.btnPreProcessDel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnPreProcessAdd
            // 
            this.btnPreProcessAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreProcessAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessAdd.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPreProcessAdd.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessAdd.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPreProcessAdd.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPreProcessAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreProcessAdd.Location = new System.Drawing.Point(294, 39);
            this.btnPreProcessAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPreProcessAdd.Name = "btnPreProcessAdd";
            this.btnPreProcessAdd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessAdd.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPreProcessAdd.RectPressColor = System.Drawing.Color.White;
            this.btnPreProcessAdd.RectSelectedColor = System.Drawing.Color.White;
            this.btnPreProcessAdd.Size = new System.Drawing.Size(87, 33);
            this.btnPreProcessAdd.Style = Sunny.UI.UIStyle.Custom;
            this.btnPreProcessAdd.StyleCustomMode = true;
            this.btnPreProcessAdd.Symbol = 61543;
            this.btnPreProcessAdd.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnPreProcessAdd.SymbolSize = 20;
            this.btnPreProcessAdd.TabIndex = 3522;
            this.btnPreProcessAdd.Text = "Add";
            this.btnPreProcessAdd.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPage18
            // 
            this.tabPage18.Controls.Add(this.label77);
            this.tabPage18.Controls.Add(this.label74);
            this.tabPage18.Location = new System.Drawing.Point(0, 40);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Size = new System.Drawing.Size(200, 60);
            this.tabPage18.TabIndex = 9;
            this.tabPage18.Text = "tabPage18";
            this.tabPage18.UseVisualStyleBackColor = true;
            // 
            // label77
            // 
            this.label77.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.Black;
            this.label77.Location = new System.Drawing.Point(25, 50);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(427, 20);
            this.label77.TabIndex = 3659;
            this.label77.Text = "사용 시 모든 툴의 영역을 Fixture 기준 상대 좌표로 변경";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.Black;
            this.label74.Location = new System.Drawing.Point(5, 5);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(640, 20);
            this.label74.TabIndex = 3658;
            this.label74.Text = "Fixturing";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label83);
            this.tabPage5.Controls.Add(this.label78);
            this.tabPage5.Controls.Add(this.label65);
            this.tabPage5.Location = new System.Drawing.Point(0, 40);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(200, 60);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label83
            // 
            this.label83.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.Black;
            this.label83.Location = new System.Drawing.Point(25, 92);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(640, 20);
            this.label83.TabIndex = 3659;
            this.label83.Text = "알고리즘은 Pattern Matching, Template Matching, ShapeMatching, Object Detection (AI) 중" +
    " 선택 가능하도록";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.Black;
            this.label78.Location = new System.Drawing.Point(25, 50);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(427, 20);
            this.label78.TabIndex = 3658;
            this.label78.Text = "Geometry 기반, Template 기반 선택 가능하도록 (Mask 기능 필요)";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.Color.Black;
            this.label65.Location = new System.Drawing.Point(5, 5);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(640, 20);
            this.label65.TabIndex = 3654;
            this.label65.Text = "Pattern Matching";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label82);
            this.tabPage6.Controls.Add(this.label79);
            this.tabPage6.Controls.Add(this.label69);
            this.tabPage6.Location = new System.Drawing.Point(0, 40);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(200, 60);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label82
            // 
            this.label82.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.Black;
            this.label82.Location = new System.Drawing.Point(25, 76);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(640, 20);
            this.label82.TabIndex = 3657;
            this.label82.Text = "알고리즘은 SimpleBlobDetector, FindContour, Segmentation(AI) 중 선택 가능하도록";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label79
            // 
            this.label79.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.Color.Black;
            this.label79.Location = new System.Drawing.Point(25, 50);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(640, 20);
            this.label79.TabIndex = 3656;
            this.label79.Text = "Blob or Contour 에서 나온 피쳐들에 기준 값으로 판정 가능하도록";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.Black;
            this.label69.Location = new System.Drawing.Point(5, 5);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(640, 20);
            this.label69.TabIndex = 3655;
            this.label69.Text = "Blob (Contour)";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label75);
            this.tabPage7.Controls.Add(this.label70);
            this.tabPage7.Location = new System.Drawing.Point(0, 40);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(200, 60);
            this.tabPage7.TabIndex = 5;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label75
            // 
            this.label75.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.Black;
            this.label75.Location = new System.Drawing.Point(25, 50);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(427, 20);
            this.label75.TabIndex = 3657;
            this.label75.Text = "두 개의 에지 사이의 Min, Max, Avg 거리 산출";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label70
            // 
            this.label70.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(5, 5);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(640, 20);
            this.label70.TabIndex = 3656;
            this.label70.Text = "Measure";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.label80);
            this.tabPage8.Controls.Add(this.label71);
            this.tabPage8.Location = new System.Drawing.Point(0, 40);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(200, 60);
            this.tabPage8.TabIndex = 6;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // label80
            // 
            this.label80.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.Black;
            this.label80.Location = new System.Drawing.Point(25, 50);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(595, 20);
            this.label80.TabIndex = 3658;
            this.label80.Text = "Datum (매칭, 써클피팅, 교점 등의 포인트) 를 기준으로 측정된 거리 산촐 꼭 유연하게 작업 가능하도록";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.Black;
            this.label71.Location = new System.Drawing.Point(5, 5);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(640, 20);
            this.label71.TabIndex = 3657;
            this.label71.Text = "Distance";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.label81);
            this.tabPage9.Controls.Add(this.label72);
            this.tabPage9.Location = new System.Drawing.Point(0, 40);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(200, 60);
            this.tabPage9.TabIndex = 7;
            this.tabPage9.Text = "tabPage9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label81
            // 
            this.label81.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.Color.Black;
            this.label81.Location = new System.Drawing.Point(25, 50);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(595, 20);
            this.label81.TabIndex = 3659;
            this.label81.Text = "R,G,B 혹은 H.S.V, Y.U.V 모드를 선택하고 체크박스를 통해 각 값에 대한 상하한 비교 가능하도록";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.Black;
            this.label72.Location = new System.Drawing.Point(5, 5);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(640, 20);
            this.label72.TabIndex = 3657;
            this.label72.Text = "Color Extract";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.label84);
            this.tabPage11.Controls.Add(this.label73);
            this.tabPage11.Location = new System.Drawing.Point(0, 40);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(200, 60);
            this.tabPage11.TabIndex = 8;
            this.tabPage11.Text = "tabPage11";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // label84
            // 
            this.label84.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.Color.Black;
            this.label84.Location = new System.Drawing.Point(25, 50);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(633, 33);
            this.label84.TabIndex = 3660;
            this.label84.Text = "Pattern, Shape Fitting 후 CenteXY 를 기준으로 n 개의 상대영역을 지정해서 \r\n해당 영역 내 밝기 평균이 최대 or 최소" +
    " 인 곳을 찾을 수 있도록";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.Black;
            this.label73.Location = new System.Drawing.Point(5, 5);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(640, 20);
            this.label73.TabIndex = 3658;
            this.label73.Text = "Polarity";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage19
            // 
            this.tabPage19.Controls.Add(this.label86);
            this.tabPage19.Controls.Add(this.label85);
            this.tabPage19.Location = new System.Drawing.Point(0, 40);
            this.tabPage19.Name = "tabPage19";
            this.tabPage19.Size = new System.Drawing.Size(200, 60);
            this.tabPage19.TabIndex = 10;
            this.tabPage19.Text = "tabPage19";
            this.tabPage19.UseVisualStyleBackColor = true;
            // 
            // label86
            // 
            this.label86.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.Color.Black;
            this.label86.Location = new System.Drawing.Point(25, 50);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(526, 84);
            this.label86.TabIndex = 3660;
            this.label86.Text = "Arithmetic 을 List 형식으로 유연하게 사용 가능하도록\r\n - Add, Substract\r\n - Compare, Multiply, De" +
    "vide\r\n - Bitwise AND,OR,XOR\r\n";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label85
            // 
            this.label85.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.ForeColor = System.Drawing.Color.Black;
            this.label85.Location = new System.Drawing.Point(5, 5);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(640, 20);
            this.label85.TabIndex = 3659;
            this.label85.Text = "Defects Extract";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage20
            // 
            this.tabPage20.Controls.Add(this.label88);
            this.tabPage20.Controls.Add(this.label87);
            this.tabPage20.Location = new System.Drawing.Point(0, 40);
            this.tabPage20.Name = "tabPage20";
            this.tabPage20.Size = new System.Drawing.Size(200, 60);
            this.tabPage20.TabIndex = 11;
            this.tabPage20.Text = "tabPage20";
            this.tabPage20.UseVisualStyleBackColor = true;
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.Color.Black;
            this.label88.Location = new System.Drawing.Point(25, 50);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(640, 42);
            this.label88.TabIndex = 3661;
            this.label88.Text = "앞서 설명된 로직으로 검출된 MBR (BoundingRect) 를 Crop 하거나 고정 영역을 Crop 하여 \r\nClassification 하고 " +
    "정답과 비교할 수 있도록";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.Black;
            this.label87.Location = new System.Drawing.Point(5, 5);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(640, 20);
            this.label87.TabIndex = 3660;
            this.label87.Text = "Classification (AI)";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton63
            // 
            this.uiSymbolButton63.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.CircleRectWidth = 0;
            this.uiSymbolButton63.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton63.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton63.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton63.Location = new System.Drawing.Point(389, 757);
            this.uiSymbolButton63.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton63.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton63.Name = "uiSymbolButton63";
            this.uiSymbolButton63.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton63.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton63.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton63.Size = new System.Drawing.Size(162, 25);
            this.uiSymbolButton63.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton63.StyleCustomMode = true;
            this.uiSymbolButton63.Symbol = 61717;
            this.uiSymbolButton63.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton63.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton63.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton63.SymbolSize = 18;
            this.uiSymbolButton63.TabIndex = 3680;
            this.uiSymbolButton63.Tag = "ZoomIn";
            this.uiSymbolButton63.Text = "Load from Library";
            this.uiSymbolButton63.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Font = new System.Drawing.Font("Arial", 12F);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(271, 530);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(20, 75);
            this.label25.TabIndex = 3679;
            this.label25.Text = "→";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(286, 334);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 20);
            this.label24.TabIndex = 3678;
            this.label24.Text = "Logics";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.BackColor = System.Drawing.Color.Transparent;
            this.checkBox8.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox8.ForeColor = System.Drawing.Color.Black;
            this.checkBox8.Location = new System.Drawing.Point(453, 335);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(38, 18);
            this.checkBox8.TabIndex = 3677;
            this.checkBox8.Text = "All";
            this.checkBox8.UseVisualStyleBackColor = false;
            // 
            // uiSymbolButton60
            // 
            this.uiSymbolButton60.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.CircleRectWidth = 0;
            this.uiSymbolButton60.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton60.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton60.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton60.Location = new System.Drawing.Point(491, 332);
            this.uiSymbolButton60.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton60.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton60.Name = "uiSymbolButton60";
            this.uiSymbolButton60.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton60.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton60.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton60.Size = new System.Drawing.Size(55, 24);
            this.uiSymbolButton60.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton60.StyleCustomMode = true;
            this.uiSymbolButton60.Symbol = 62029;
            this.uiSymbolButton60.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton60.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton60.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton60.SymbolSize = 16;
            this.uiSymbolButton60.TabIndex = 3676;
            this.uiSymbolButton60.Tag = "ZoomIn";
            this.uiSymbolButton60.Text = "Copy";
            this.uiSymbolButton60.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton61
            // 
            this.uiSymbolButton61.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.CircleRectWidth = 0;
            this.uiSymbolButton61.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton61.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton61.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton61.Location = new System.Drawing.Point(394, 332);
            this.uiSymbolButton61.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton61.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton61.Name = "uiSymbolButton61";
            this.uiSymbolButton61.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton61.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton61.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton61.Size = new System.Drawing.Size(55, 24);
            this.uiSymbolButton61.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton61.StyleCustomMode = true;
            this.uiSymbolButton61.Symbol = 61453;
            this.uiSymbolButton61.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton61.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton61.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton61.SymbolSize = 16;
            this.uiSymbolButton61.TabIndex = 3675;
            this.uiSymbolButton61.Tag = "ZoomIn";
            this.uiSymbolButton61.Text = "Del";
            this.uiSymbolButton61.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton62
            // 
            this.uiSymbolButton62.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.CircleRectWidth = 0;
            this.uiSymbolButton62.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton62.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton62.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton62.Location = new System.Drawing.Point(338, 332);
            this.uiSymbolButton62.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton62.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton62.Name = "uiSymbolButton62";
            this.uiSymbolButton62.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton62.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton62.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton62.Size = new System.Drawing.Size(55, 24);
            this.uiSymbolButton62.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton62.StyleCustomMode = true;
            this.uiSymbolButton62.Symbol = 61543;
            this.uiSymbolButton62.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton62.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton62.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton62.SymbolSize = 16;
            this.uiSymbolButton62.TabIndex = 3674;
            this.uiSymbolButton62.Tag = "ZoomIn";
            this.uiSymbolButton62.Text = "Add";
            this.uiSymbolButton62.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle68.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle68.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle68.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle68.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle68.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle68;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1,
            this.Column3,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle69.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle69.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle69.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle69.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle69.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle69;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(285, 362);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(266, 392);
            this.dataGridView1.TabIndex = 3640;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 25;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Use";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Logic Name";
            this.Column3.Name = "Column3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Algorithm";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // uiLine25
            // 
            this.uiLine25.BackColor = System.Drawing.Color.Transparent;
            this.uiLine25.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine25.LineColor = System.Drawing.Color.Black;
            this.uiLine25.Location = new System.Drawing.Point(285, 321);
            this.uiLine25.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine25.Name = "uiLine25";
            this.uiLine25.Size = new System.Drawing.Size(266, 10);
            this.uiLine25.TabIndex = 3673;
            // 
            // uiSymbolButton59
            // 
            this.uiSymbolButton59.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton59.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton59.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton59.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton59.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton59.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton59.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton59.Location = new System.Drawing.Point(414, 290);
            this.uiSymbolButton59.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton59.Name = "uiSymbolButton59";
            this.uiSymbolButton59.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton59.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton59.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton59.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton59.Size = new System.Drawing.Size(132, 25);
            this.uiSymbolButton59.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton59.StyleCustomMode = true;
            this.uiSymbolButton59.SymbolSize = 16;
            this.uiSymbolButton59.TabIndex = 3672;
            this.uiSymbolButton59.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiLine22
            // 
            this.uiLine22.BackColor = System.Drawing.Color.Transparent;
            this.uiLine22.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine22.LineColor = System.Drawing.Color.Black;
            this.uiLine22.Location = new System.Drawing.Point(374, 193);
            this.uiLine22.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine22.Name = "uiLine22";
            this.uiLine22.Size = new System.Drawing.Size(177, 10);
            this.uiLine22.TabIndex = 3671;
            // 
            // uiSymbolButton40
            // 
            this.uiSymbolButton40.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton40.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton40.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton40.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton40.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton40.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton40.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton40.Location = new System.Drawing.Point(502, 206);
            this.uiSymbolButton40.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton40.Name = "uiSymbolButton40";
            this.uiSymbolButton40.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton40.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton40.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton40.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton40.Size = new System.Drawing.Size(44, 25);
            this.uiSymbolButton40.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton40.StyleCustomMode = true;
            this.uiSymbolButton40.Symbol = 61473;
            this.uiSymbolButton40.SymbolSize = 16;
            this.uiSymbolButton40.TabIndex = 3670;
            this.uiSymbolButton40.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Arial", 8F);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(291, 206);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 25);
            this.label20.TabIndex = 3668;
            this.label20.Text = "Grab Index";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Arial", 8F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(291, 262);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(81, 25);
            this.label21.TabIndex = 3667;
            this.label21.Text = "Filter";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox6
            // 
            this.uiTextBox6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox6.DoubleValue = 1D;
            this.uiTextBox6.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox6.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox6.IntValue = 1;
            this.uiTextBox6.Location = new System.Drawing.Point(374, 290);
            this.uiTextBox6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox6.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox6.Name = "uiTextBox6";
            this.uiTextBox6.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox6.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox6.ShowText = false;
            this.uiTextBox6.Size = new System.Drawing.Size(38, 25);
            this.uiTextBox6.TabIndex = 3666;
            this.uiTextBox6.Text = "1";
            this.uiTextBox6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox6.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBox6.Watermark = "";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Arial", 8F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(291, 290);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 25);
            this.label22.TabIndex = 3665;
            this.label22.Text = "Sampling";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.DimGray;
            this.uiButton1.FillSelectedColor = System.Drawing.Color.Green;
            this.uiButton1.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton1.Location = new System.Drawing.Point(374, 234);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton1.Selected = true;
            this.uiButton1.Size = new System.Drawing.Size(84, 25);
            this.uiButton1.TabIndex = 3663;
            this.uiButton1.Tag = "Setting";
            this.uiButton1.Text = "N/A = NG";
            this.uiButton1.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Arial", 8F);
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(291, 234);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 25);
            this.label23.TabIndex = 3662;
            this.label23.Text = "Judge Type";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton57
            // 
            this.uiSymbolButton57.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.CircleRectWidth = 0;
            this.uiSymbolButton57.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton57.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton57.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton57.Location = new System.Drawing.Point(462, 262);
            this.uiSymbolButton57.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton57.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton57.Name = "uiSymbolButton57";
            this.uiSymbolButton57.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton57.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton57.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton57.Size = new System.Drawing.Size(84, 25);
            this.uiSymbolButton57.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton57.StyleCustomMode = true;
            this.uiSymbolButton57.Symbol = 61459;
            this.uiSymbolButton57.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton57.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton57.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton57.SymbolSize = 18;
            this.uiSymbolButton57.TabIndex = 3661;
            this.uiSymbolButton57.Tag = "ZoomIn";
            this.uiSymbolButton57.Text = "Setting";
            this.uiSymbolButton57.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton58
            // 
            this.uiSymbolButton58.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.CircleRectWidth = 0;
            this.uiSymbolButton58.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton58.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton58.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton58.Location = new System.Drawing.Point(374, 262);
            this.uiSymbolButton58.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton58.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton58.Name = "uiSymbolButton58";
            this.uiSymbolButton58.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton58.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton58.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton58.Size = new System.Drawing.Size(84, 25);
            this.uiSymbolButton58.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton58.StyleCustomMode = true;
            this.uiSymbolButton58.Symbol = 61515;
            this.uiSymbolButton58.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton58.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton58.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton58.SymbolSize = 18;
            this.uiSymbolButton58.TabIndex = 3660;
            this.uiSymbolButton58.Tag = "ZoomIn";
            this.uiSymbolButton58.Text = "Run";
            this.uiSymbolButton58.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiButton9
            // 
            this.uiButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton9.FillColor = System.Drawing.Color.DimGray;
            this.uiButton9.FillSelectedColor = System.Drawing.Color.Green;
            this.uiButton9.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton9.Location = new System.Drawing.Point(462, 234);
            this.uiButton9.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton9.Name = "uiButton9";
            this.uiButton9.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton9.Size = new System.Drawing.Size(84, 25);
            this.uiButton9.TabIndex = 3664;
            this.uiButton9.Tag = "Setting";
            this.uiButton9.Text = "N/A = OK";
            this.uiButton9.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // uiComboBox2
            // 
            this.uiComboBox2.DataSource = null;
            this.uiComboBox2.FillColor = System.Drawing.SystemColors.Control;
            this.uiComboBox2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiComboBox2.ForeColor = System.Drawing.Color.Black;
            this.uiComboBox2.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiComboBox2.ItemForeColor = System.Drawing.Color.White;
            this.uiComboBox2.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiComboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.uiComboBox2.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiComboBox2.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox2.Location = new System.Drawing.Point(374, 206);
            this.uiComboBox2.Margin = new System.Windows.Forms.Padding(0);
            this.uiComboBox2.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox2.Name = "uiComboBox2";
            this.uiComboBox2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox2.RectColor = System.Drawing.Color.DimGray;
            this.uiComboBox2.Size = new System.Drawing.Size(125, 25);
            this.uiComboBox2.SymbolSize = 24;
            this.uiComboBox2.TabIndex = 3669;
            this.uiComboBox2.Text = "1";
            this.uiComboBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiComboBox2.Watermark = "";
            // 
            // uiSymbolButton39
            // 
            this.uiSymbolButton39.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton39.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton39.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton39.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton39.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton39.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton39.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton39.Location = new System.Drawing.Point(501, 135);
            this.uiSymbolButton39.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton39.Name = "uiSymbolButton39";
            this.uiSymbolButton39.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton39.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton39.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton39.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton39.Size = new System.Drawing.Size(45, 53);
            this.uiSymbolButton39.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton39.StyleCustomMode = true;
            this.uiSymbolButton39.SymbolSize = 16;
            this.uiSymbolButton39.TabIndex = 3658;
            this.uiSymbolButton39.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Arial", 8F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(291, 163);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 25);
            this.label18.TabIndex = 3656;
            this.label18.Text = "Algorithm";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox10
            // 
            this.uiTextBox10.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox10.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox10.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox10.Location = new System.Drawing.Point(374, 135);
            this.uiTextBox10.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox10.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox10.Name = "uiTextBox10";
            this.uiTextBox10.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox10.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox10.ShowText = false;
            this.uiTextBox10.Size = new System.Drawing.Size(125, 25);
            this.uiTextBox10.TabIndex = 3655;
            this.uiTextBox10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox10.Watermark = "";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Arial", 8F);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(291, 135);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 25);
            this.label19.TabIndex = 3654;
            this.label19.Text = "Logic Name";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(286, 115);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(260, 20);
            this.label16.TabIndex = 3653;
            this.label16.Text = "Selected Logic : ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(286, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(260, 20);
            this.label15.TabIndex = 3652;
            this.label15.Text = "Selected Job : ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton38
            // 
            this.uiSymbolButton38.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton38.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton38.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton38.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton38.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton38.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton38.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton38.Location = new System.Drawing.Point(501, 49);
            this.uiSymbolButton38.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton38.Name = "uiSymbolButton38";
            this.uiSymbolButton38.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton38.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton38.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton38.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton38.Size = new System.Drawing.Size(45, 53);
            this.uiSymbolButton38.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton38.StyleCustomMode = true;
            this.uiSymbolButton38.SymbolSize = 16;
            this.uiSymbolButton38.TabIndex = 3651;
            this.uiSymbolButton38.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiLine21
            // 
            this.uiLine21.BackColor = System.Drawing.Color.Transparent;
            this.uiLine21.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine21.LineColor = System.Drawing.Color.Black;
            this.uiLine21.Location = new System.Drawing.Point(285, 108);
            this.uiLine21.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine21.Name = "uiLine21";
            this.uiLine21.Size = new System.Drawing.Size(266, 10);
            this.uiLine21.TabIndex = 3650;
            // 
            // uiTextBox4
            // 
            this.uiTextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox4.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox4.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox4.Location = new System.Drawing.Point(374, 77);
            this.uiTextBox4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox4.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox4.Name = "uiTextBox4";
            this.uiTextBox4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox4.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox4.ShowText = false;
            this.uiTextBox4.Size = new System.Drawing.Size(125, 25);
            this.uiTextBox4.TabIndex = 3649;
            this.uiTextBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox4.Watermark = "";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Arial", 8F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(291, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 25);
            this.label14.TabIndex = 3648;
            this.label14.Text = "Part Name";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox11
            // 
            this.uiTextBox11.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox11.FillColor = System.Drawing.SystemColors.Control;
            this.uiTextBox11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBox11.ForeColor = System.Drawing.Color.Black;
            this.uiTextBox11.Location = new System.Drawing.Point(374, 49);
            this.uiTextBox11.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiTextBox11.MinimumSize = new System.Drawing.Size(1, 20);
            this.uiTextBox11.Name = "uiTextBox11";
            this.uiTextBox11.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.uiTextBox11.RectColor = System.Drawing.Color.DimGray;
            this.uiTextBox11.ShowText = false;
            this.uiTextBox11.Size = new System.Drawing.Size(125, 25);
            this.uiTextBox11.TabIndex = 3647;
            this.uiTextBox11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox11.Watermark = "";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Arial", 8F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(291, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 25);
            this.label17.TabIndex = 3646;
            this.label17.Text = "Location No";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(4, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 3645;
            this.label6.Text = "Job List";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.BackColor = System.Drawing.Color.Transparent;
            this.checkBox7.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox7.ForeColor = System.Drawing.Color.Black;
            this.checkBox7.Location = new System.Drawing.Point(186, 6);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(38, 18);
            this.checkBox7.TabIndex = 3643;
            this.checkBox7.Text = "All";
            this.checkBox7.UseVisualStyleBackColor = false;
            // 
            // uiSymbolButton36
            // 
            this.uiSymbolButton36.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.CircleRectWidth = 0;
            this.uiSymbolButton36.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton36.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton36.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton36.Location = new System.Drawing.Point(224, 3);
            this.uiSymbolButton36.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton36.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton36.Name = "uiSymbolButton36";
            this.uiSymbolButton36.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton36.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton36.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton36.Size = new System.Drawing.Size(55, 24);
            this.uiSymbolButton36.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton36.StyleCustomMode = true;
            this.uiSymbolButton36.Symbol = 62029;
            this.uiSymbolButton36.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton36.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton36.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton36.SymbolSize = 16;
            this.uiSymbolButton36.TabIndex = 3642;
            this.uiSymbolButton36.Tag = "ZoomIn";
            this.uiSymbolButton36.Text = "Copy";
            this.uiSymbolButton36.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton22
            // 
            this.uiSymbolButton22.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.CircleRectWidth = 0;
            this.uiSymbolButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton22.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton22.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton22.Location = new System.Drawing.Point(127, 3);
            this.uiSymbolButton22.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton22.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton22.Name = "uiSymbolButton22";
            this.uiSymbolButton22.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton22.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton22.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton22.Size = new System.Drawing.Size(55, 24);
            this.uiSymbolButton22.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton22.StyleCustomMode = true;
            this.uiSymbolButton22.Symbol = 61453;
            this.uiSymbolButton22.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton22.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton22.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton22.SymbolSize = 16;
            this.uiSymbolButton22.TabIndex = 3641;
            this.uiSymbolButton22.Tag = "ZoomIn";
            this.uiSymbolButton22.Text = "Del";
            this.uiSymbolButton22.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // gridLibrary
            // 
            this.gridLibrary.AllowUserToAddRows = false;
            this.gridLibrary.AllowUserToDeleteRows = false;
            this.gridLibrary.AllowUserToResizeColumns = false;
            this.gridLibrary.AllowUserToResizeRows = false;
            this.gridLibrary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gridLibrary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridLibrary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridLibrary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle70.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle70.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle70.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle70.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle70.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLibrary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle70;
            this.gridLibrary.ColumnHeadersHeight = 25;
            this.gridLibrary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridLibrary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.gridLibraryEnabled,
            this.gridLibraryName,
            this.gridLibraryPart,
            this.Column4});
            dataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle71.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle71.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle71.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle71.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLibrary.DefaultCellStyle = dataGridViewCellStyle71;
            this.gridLibrary.EnableHeadersVisualStyles = false;
            this.gridLibrary.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridLibrary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridLibrary.Location = new System.Drawing.Point(1, 29);
            this.gridLibrary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridLibrary.MultiSelect = false;
            this.gridLibrary.Name = "gridLibrary";
            this.gridLibrary.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridLibrary.RowHeadersVisible = false;
            this.gridLibrary.RowHeadersWidth = 51;
            this.gridLibrary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridLibrary.RowTemplate.Height = 23;
            this.gridLibrary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLibrary.Size = new System.Drawing.Size(278, 751);
            this.gridLibrary.TabIndex = 3639;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.Width = 25;
            // 
            // gridLibraryEnabled
            // 
            this.gridLibraryEnabled.HeaderText = "Use";
            this.gridLibraryEnabled.MinimumWidth = 6;
            this.gridLibraryEnabled.Name = "gridLibraryEnabled";
            this.gridLibraryEnabled.Width = 30;
            // 
            // gridLibraryName
            // 
            this.gridLibraryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridLibraryName.HeaderText = "Location";
            this.gridLibraryName.MinimumWidth = 6;
            this.gridLibraryName.Name = "gridLibraryName";
            this.gridLibraryName.ReadOnly = true;
            this.gridLibraryName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLibraryName.Width = 71;
            // 
            // gridLibraryPart
            // 
            this.gridLibraryPart.HeaderText = "Job Name";
            this.gridLibraryPart.MinimumWidth = 6;
            this.gridLibraryPart.Name = "gridLibraryPart";
            this.gridLibraryPart.ReadOnly = true;
            this.gridLibraryPart.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLibraryPart.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Virtual";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Width = 50;
            // 
            // uiSymbolButton37
            // 
            this.uiSymbolButton37.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.CircleRectWidth = 0;
            this.uiSymbolButton37.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton37.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton37.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton37.Location = new System.Drawing.Point(71, 3);
            this.uiSymbolButton37.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton37.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton37.Name = "uiSymbolButton37";
            this.uiSymbolButton37.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton37.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton37.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton37.Size = new System.Drawing.Size(55, 24);
            this.uiSymbolButton37.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton37.StyleCustomMode = true;
            this.uiSymbolButton37.Symbol = 61543;
            this.uiSymbolButton37.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton37.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton37.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton37.SymbolSize = 16;
            this.uiSymbolButton37.TabIndex = 3626;
            this.uiSymbolButton37.Tag = "ZoomIn";
            this.uiSymbolButton37.Text = "Add";
            this.uiSymbolButton37.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.DataSource = null;
            this.uiComboBox1.FillColor = System.Drawing.SystemColors.Control;
            this.uiComboBox1.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiComboBox1.ForeColor = System.Drawing.Color.Black;
            this.uiComboBox1.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiComboBox1.ItemForeColor = System.Drawing.Color.White;
            this.uiComboBox1.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiComboBox1.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiComboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox1.Location = new System.Drawing.Point(374, 163);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox1.RectColor = System.Drawing.Color.DimGray;
            this.uiComboBox1.Size = new System.Drawing.Size(125, 25);
            this.uiComboBox1.SymbolSize = 24;
            this.uiComboBox1.TabIndex = 3659;
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox1.Watermark = "";
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.uiTabControl7);
            this.tabPage15.Location = new System.Drawing.Point(0, 40);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Size = new System.Drawing.Size(200, 60);
            this.tabPage15.TabIndex = 3;
            this.tabPage15.Text = "04. DEBUG";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // uiTabControl7
            // 
            this.uiTabControl7.Controls.Add(this.tabPage16);
            this.uiTabControl7.Controls.Add(this.tabPage17);
            this.uiTabControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl7.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl7.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiTabControl7.ItemSize = new System.Drawing.Size(100, 40);
            this.uiTabControl7.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl7.MainPage = "";
            this.uiTabControl7.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl7.Name = "uiTabControl7";
            this.uiTabControl7.SelectedIndex = 0;
            this.uiTabControl7.Size = new System.Drawing.Size(200, 60);
            this.uiTabControl7.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl7.TabBackColor = System.Drawing.SystemColors.Control;
            this.uiTabControl7.TabIndex = 3470;
            this.uiTabControl7.TabSelectedColor = System.Drawing.Color.Transparent;
            this.uiTabControl7.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl7.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl7.TabUnSelectedForeColor = System.Drawing.Color.DimGray;
            this.uiTabControl7.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTabControl7.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.uiDataGridView5);
            this.tabPage16.Location = new System.Drawing.Point(0, 40);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Size = new System.Drawing.Size(200, 20);
            this.tabPage16.TabIndex = 2;
            this.tabPage16.Text = "01) Recent Image";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // uiDataGridView5
            // 
            this.uiDataGridView5.AllowUserToAddRows = false;
            this.uiDataGridView5.AllowUserToDeleteRows = false;
            this.uiDataGridView5.AllowUserToResizeColumns = false;
            this.uiDataGridView5.AllowUserToResizeRows = false;
            dataGridViewCellStyle72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle72.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle72.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle72.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle72.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView5.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle72;
            this.uiDataGridView5.BackgroundColor = System.Drawing.Color.Silver;
            this.uiDataGridView5.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle73.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle73.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle73.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle73.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle73.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle73.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle73.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle73;
            this.uiDataGridView5.ColumnHeadersHeight = 20;
            this.uiDataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            dataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle74.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle74.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle74.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle74.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle74.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle74.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView5.DefaultCellStyle = dataGridViewCellStyle74;
            this.uiDataGridView5.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uiDataGridView5.EnableHeadersVisualStyles = false;
            this.uiDataGridView5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiDataGridView5.GridColor = System.Drawing.Color.Silver;
            this.uiDataGridView5.Location = new System.Drawing.Point(4, 4);
            this.uiDataGridView5.MultiSelect = false;
            this.uiDataGridView5.Name = "uiDataGridView5";
            this.uiDataGridView5.ReadOnly = true;
            this.uiDataGridView5.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle75.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle75.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle75.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle75.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView5.RowHeadersDefaultCellStyle = dataGridViewCellStyle75;
            this.uiDataGridView5.RowHeadersVisible = false;
            this.uiDataGridView5.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle76.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle76.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle76.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle76.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView5.RowsDefaultCellStyle = dataGridViewCellStyle76;
            this.uiDataGridView5.RowTemplate.Height = 25;
            this.uiDataGridView5.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView5.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView5.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView5.ScrollBarStyleInherited = false;
            this.uiDataGridView5.SelectedIndex = -1;
            this.uiDataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridView5.Size = new System.Drawing.Size(631, 772);
            this.uiDataGridView5.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView5.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView5.TabIndex = 3534;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "DateTime";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 150;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "QR";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // tabPage17
            // 
            this.tabPage17.Location = new System.Drawing.Point(0, 40);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Size = new System.Drawing.Size(200, 60);
            this.tabPage17.TabIndex = 3;
            this.tabPage17.Text = "02) Option";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnSave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSave.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnSave.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSave.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1760, 824);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnSave.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnSave.RectPressColor = System.Drawing.Color.White;
            this.btnSave.RectSelectedColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(148, 33);
            this.btnSave.Style = Sunny.UI.UIStyle.Custom;
            this.btnSave.StyleCustomMode = true;
            this.btnSave.Symbol = 61639;
            this.btnSave.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnSave.SymbolSize = 20;
            this.btnSave.TabIndex = 3576;
            this.btnSave.Text = "Save";
            this.btnSave.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton5
            // 
            this.uiSymbolButton5.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.CircleRectWidth = 0;
            this.uiSymbolButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton5.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton5.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton5.Location = new System.Drawing.Point(1217, 825);
            this.uiSymbolButton5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton5.Name = "uiSymbolButton5";
            this.uiSymbolButton5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton5.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton5.Size = new System.Drawing.Size(174, 32);
            this.uiSymbolButton5.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton5.StyleCustomMode = true;
            this.uiSymbolButton5.Symbol = 361773;
            this.uiSymbolButton5.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton5.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton5.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton5.SymbolSize = 18;
            this.uiSymbolButton5.TabIndex = 3618;
            this.uiSymbolButton5.Tag = "ZoomIn";
            this.uiSymbolButton5.Text = "View Jobs";
            this.uiSymbolButton5.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton7
            // 
            this.uiSymbolButton7.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.CircleRectWidth = 0;
            this.uiSymbolButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton7.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton7.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton7.Location = new System.Drawing.Point(1399, 825);
            this.uiSymbolButton7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton7.Name = "uiSymbolButton7";
            this.uiSymbolButton7.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton7.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton7.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.Size = new System.Drawing.Size(174, 32);
            this.uiSymbolButton7.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton7.StyleCustomMode = true;
            this.uiSymbolButton7.Symbol = 361773;
            this.uiSymbolButton7.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton7.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton7.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton7.SymbolSize = 18;
            this.uiSymbolButton7.TabIndex = 3619;
            this.uiSymbolButton7.Tag = "ZoomIn";
            this.uiSymbolButton7.Text = "Inspection (Auto)";
            this.uiSymbolButton7.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton8
            // 
            this.uiSymbolButton8.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.CircleRectWidth = 0;
            this.uiSymbolButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton8.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.Font = new System.Drawing.Font("Arial", 10F);
            this.uiSymbolButton8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton8.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton8.Location = new System.Drawing.Point(1581, 824);
            this.uiSymbolButton8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton8.Name = "uiSymbolButton8";
            this.uiSymbolButton8.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.uiSymbolButton8.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton8.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.Size = new System.Drawing.Size(174, 32);
            this.uiSymbolButton8.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton8.StyleCustomMode = true;
            this.uiSymbolButton8.Symbol = 361773;
            this.uiSymbolButton8.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton8.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.uiSymbolButton8.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton8.SymbolSize = 18;
            this.uiSymbolButton8.TabIndex = 3620;
            this.uiSymbolButton8.Tag = "ZoomIn";
            this.uiSymbolButton8.Text = "Inspection (Manual)";
            this.uiSymbolButton8.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // Form_MenuVision
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 860);
            this.Controls.Add(this.uiSymbolButton8);
            this.Controls.Add(this.uiSymbolButton7);
            this.Controls.Add(this.uiSymbolButton5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.uiTabControl1);
            this.Controls.Add(this.btnView_Full);
            this.Controls.Add(this.lblImageInfo);
            this.Controls.Add(this.DisplayGrabIdx5);
            this.Controls.Add(this.DisplayGrabIdx4);
            this.Controls.Add(this.DisplayGrabIdx3);
            this.Controls.Add(this.DisplayGrabIdx2);
            this.Controls.Add(this.DisplayGrabIdx1);
            this.Controls.Add(this.btnViewGrabIndex5);
            this.Controls.Add(this.btnViewGrabIndex4);
            this.Controls.Add(this.btnViewGrabIndex3);
            this.Controls.Add(this.btnViewGrabIndex2);
            this.Controls.Add(this.btnViewGrabIndex1);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.btnView_Result4);
            this.Controls.Add(this.btnView_Result3);
            this.Controls.Add(this.btnView_Result2);
            this.Controls.Add(this.btnView_Result1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnView_Setting4);
            this.Controls.Add(this.btnView_Setting3);
            this.Controls.Add(this.btnView_Setting2);
            this.Controls.Add(this.btnView_Setting1);
            this.Controls.Add(this.uiLine6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlCogDisplay);
            this.Controls.Add(this.uiLine7);
            this.Controls.Add(this.uiLine5);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 860);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "Form_MenuVision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form_MenuVision_Load);
            this.pnlCogDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DispMain)).EndInit();
            this.uiPanel3.ResumeLayout(false);
            this.pnl_CogDisplay_Operation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayGrabIdx5)).EndInit();
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.uiTabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.uiGroupBox14.ResumeLayout(false);
            this.uiGroupBox14.PerformLayout();
            this.uiGroupBox13.ResumeLayout(false);
            this.uiGroupBox12.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.uiTabControl6.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.uiGroupBox18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView4)).EndInit();
            this.uiGroupBox15.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.uiGroupBox17.ResumeLayout(false);
            this.uiGroupBox16.ResumeLayout(false);
            this.uiGroupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay5)).EndInit();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.uiTabControl3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay11)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox10.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.tabPage18.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage19.ResumeLayout(false);
            this.tabPage20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLibrary)).EndInit();
            this.tabPage15.ResumeLayout(false);
            this.uiTabControl7.ResumeLayout(false);
            this.tabPage16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerStatus;
        private Sunny.UI.UIPanel pnlRegist;
        private Sunny.UI.UITextBox uiTextBox5;
        private Sunny.UI.UISymbolButton uiSymbolButton4;
        private PropertyGrid propertyGrid1;
        private Panel pnlCogDisplay;
        public Cognex.VisionPro.Display.CogDisplay DispMain;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIPanel pnl_CogDisplay_Operation;
        private Sunny.UI.UISymbolButton btn_CogDisplay_OverlayClear;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UISymbolButton btn_CogDisplay_SearchROI;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UISymbolButton btn_CogDisplay_ImageLoad;
        private Sunny.UI.UISymbolButton btn_CogDisplay_ImageSave;
        private Sunny.UI.UILine line1;
        private Sunny.UI.UISymbolButton btn_CogDisplay_Measure;
        private Sunny.UI.UILine line2;
        private Sunny.UI.UISymbolButton btn_CogDisplay_Point;
        private Sunny.UI.UISymbolButton btn_CogDisplay_Pan;
        private Sunny.UI.UILine line3;
        private Sunny.UI.UISymbolButton btn_CogDisplay_ZoomIn;
        private Sunny.UI.UISymbolButton btn_CogDisplay_ZoomOut;
        private Sunny.UI.UISymbolButton btn_CogDisplay_ZoomFit;
        private Sunny.UI.UIButton uiButton7;
        private Panel pnlDisplayStatus;
        private Sunny.UI.UIButton uiButton8;
        private Sunny.UI.UIButton btnLive;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UISymbolButton uiSymbolButton6;
        private Sunny.UI.UILine uiLine4;
        private Label label1;
        private Sunny.UI.UILine uiLine6;
        private Sunny.UI.UIButton btnView_Setting1;
        private Sunny.UI.UIButton btnView_Setting2;
        private Sunny.UI.UIButton btnView_Setting4;
        private Sunny.UI.UIButton btnView_Setting3;
        private Sunny.UI.UIButton btnView_Result4;
        private Sunny.UI.UIButton btnView_Result3;
        private Sunny.UI.UIButton btnView_Result2;
        private Sunny.UI.UIButton btnView_Result1;
        private Sunny.UI.UILine uiLine5;
        private Label label5;
        private Sunny.UI.UIButton uiButton12;
        private Sunny.UI.UILine uiLine7;
        private Label label33;
        private Sunny.UI.UIButton btnViewGrabIndex4;
        private Sunny.UI.UIButton btnViewGrabIndex3;
        private Sunny.UI.UIButton btnViewGrabIndex2;
        private Sunny.UI.UIButton btnViewGrabIndex1;
        private Sunny.UI.UIButton btnViewGrabIndex5;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx1;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx2;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx4;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx3;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx5;
        private Timer timerCalibration;
        private Label lblImageInfo;
        private Sunny.UI.UISymbolButton btnView_Full;
        private Sunny.UI.UITabControl uiTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Sunny.UI.UITabControl uiTabControl2;
        private TabPage tabPage3;
        private Sunny.UI.UIGroupBox uiGroupBox12;
        private Sunny.UI.UISymbolButton uiSymbolButton9;
        private Sunny.UI.UITextBox uiTextBox7;
        private Sunny.UI.UITextBox uiTextBox8;
        private Label label34;
        private Label label35;
        private TabPage tabPage10;
        private Sunny.UI.UIGroupBox uiGroupBox13;
        private Sunny.UI.UITextBox uiTextBox41;
        private Label label67;
        private Sunny.UI.UILine uiLine17;
        private Label label55;
        private Label label39;
        private Sunny.UI.UISymbolButton uiSymbolButton15;
        private Sunny.UI.UISymbolButton uiSymbolButton16;
        private Sunny.UI.UITextBox uiTextBox14;
        private Label label38;
        private Sunny.UI.UISymbolButton uiSymbolButton18;
        private Sunny.UI.UISymbolButton uiSymbolButton19;
        private Label label37;
        private Sunny.UI.UITextBox uiTextBox13;
        private Label label56;
        private Sunny.UI.UILine uiLine14;
        private Sunny.UI.UISymbolButton uiSymbolButton20;
        private Sunny.UI.UISymbolButton uiSymbolButton21;
        private Label label57;
        private Sunny.UI.UITextBox uiTextBox30;
        private Label label58;
        private Sunny.UI.UILine uiLine15;
        private Sunny.UI.UISymbolButton uiSymbolButton14;
        private Sunny.UI.UISymbolButton uiSymbolButton17;
        private Label label2;
        private Sunny.UI.UITextBox uiTextBox9;
        private Label label36;
        private Sunny.UI.UILine uiLine13;
        private Sunny.UI.UISymbolButton uiSymbolButton13;
        private Sunny.UI.UISymbolButton uiSymbolButton11;
        private Label label66;
        private Sunny.UI.UISymbolButton uiSymbolButton10;
        private Sunny.UI.UITabControl uiTabControl6;
        private TabPage tabPage12;
        private TabPage tabPage13;
        private Sunny.UI.UIGroupBox uiGroupBox16;
        private Sunny.UI.UISymbolButton uiSymbolButton23;
        private Sunny.UI.UISymbolButton uiSymbolButton24;
        private Sunny.UI.UILine uiLine16;
        private Label label61;
        private Sunny.UI.UISymbolButton uiSymbolButton27;
        private Sunny.UI.UISymbolButton uiSymbolButton34;
        private Sunny.UI.UILine uiLine19;
        private Label label68;
        private Sunny.UI.UISymbolButton uiSymbolButton25;
        private Sunny.UI.UISymbolButton uiSymbolButton26;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay6;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay5;
        private CheckBox checkBox6;
        private Sunny.UI.UIGroupBox uiGroupBox14;
        private Sunny.UI.UISymbolButton uiSymbolButton44;
        private Sunny.UI.UISymbolButton uiSymbolButton43;
        private Sunny.UI.UISymbolButton uiSymbolButton42;
        private Sunny.UI.UISymbolButton uiSymbolButton41;
        private Sunny.UI.UISymbolButton uiSymbolButton35;
        private Label label52;
        private Sunny.UI.UITextBox TbLight5;
        private Label label53;
        private Sunny.UI.UITextBox TbGain5;
        private Label label54;
        private CheckBox checkBox5;
        private Sunny.UI.UITextBox TbExposure5;
        private Sunny.UI.UILine uiLine12;
        private Label label46;
        private Sunny.UI.UITextBox TbLight4;
        private Label label47;
        private Sunny.UI.UITextBox TbGain4;
        private Label label48;
        private CheckBox checkBox3;
        private Sunny.UI.UITextBox TbExposure4;
        private Sunny.UI.UILine uiLine10;
        private Label label49;
        private Sunny.UI.UITextBox TbLight3;
        private Label label50;
        private Sunny.UI.UITextBox TbGain3;
        private Label label51;
        private CheckBox checkBox4;
        private Sunny.UI.UITextBox TbExposure3;
        private Sunny.UI.UILine uiLine11;
        private Label label40;
        private Sunny.UI.UITextBox TbLight2;
        private Label label41;
        private Sunny.UI.UITextBox TbGain2;
        private Label label45;
        private CheckBox checkBox2;
        private Sunny.UI.UITextBox TbExposure2;
        private Sunny.UI.UILine uiLine9;
        private Label label44;
        private Sunny.UI.UITextBox TbLight1;
        private Label label43;
        private Sunny.UI.UITextBox TbGain1;
        private Label label42;
        private CheckBox checkBox1;
        private Sunny.UI.UISymbolButton BtnIQHWApply;
        private Sunny.UI.UITextBox TbExposure1;
        private Sunny.UI.UILine uiLine8;
        private Sunny.UI.UIGroupBox uiGroupBox18;
        private Sunny.UI.UITextBox uiTextBox31;
        private Label label59;
        private Sunny.UI.UIGroupBox uiGroupBox15;
        private Sunny.UI.UITextBox uiTextBox33;
        private Label label63;
        private Sunny.UI.UIGroupBox uiGroupBox17;
        private Sunny.UI.UIComboBox uiComboBox5;
        private Sunny.UI.UISymbolButton uiSymbolButton51;
        private Sunny.UI.UISymbolButton uiSymbolButton52;
        private Label label60;
        private Sunny.UI.UISymbolButton uiSymbolButton48;
        private Sunny.UI.UIDataGridView uiDataGridView4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private Sunny.UI.UISymbolButton uiSymbolButton47;
        private Sunny.UI.UISymbolButton uiSymbolButton54;
        private Sunny.UI.UISymbolButton uiSymbolButton55;
        private Sunny.UI.UISymbolButton uiSymbolButton53;
        private Sunny.UI.UISymbolButton uiSymbolButton50;
        private Sunny.UI.UISymbolButton uiSymbolButton49;
        private TabPage tabPage14;
        private TabPage tabPage15;
        private Sunny.UI.UITabControl uiTabControl7;
        private TabPage tabPage16;
        private Sunny.UI.UIDataGridView uiDataGridView5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private TabPage tabPage17;
        private Sunny.UI.UITextBox uiTextBox34;
        private Label label64;
        private Sunny.UI.UITextBox uiTextBox32;
        private Label label62;
        private Label label4;
        private Sunny.UI.UISymbolButton uiSymbolButton3;
        private Sunny.UI.UILine uiLine20;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Label label3;
        private Sunny.UI.UILine uiLine18;
        private Sunny.UI.UISymbolButton btnSave;
        private Sunny.UI.UISymbolButton uiSymbolButton5;
        private Sunny.UI.UISymbolButton uiSymbolButton7;
        private Sunny.UI.UISymbolButton uiSymbolButton8;
        private Sunny.UI.UITabControl uiTabControl3;
        private TabPage tabPage4;
        private Sunny.UI.UISymbolButton uiSymbolButton56;
        private Sunny.UI.UISymbolButton uiSymbolButton46;
        private Sunny.UI.UISymbolButton uiSymbolButton45;
        public DataGridView gridLibrary;
        private Sunny.UI.UISymbolButton uiSymbolButton36;
        private Sunny.UI.UISymbolButton uiSymbolButton22;
        private Sunny.UI.UISymbolButton uiSymbolButton37;
        private CheckBox checkBox7;
        public DataGridView dataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Sunny.UI.UILine uiLine21;
        private Sunny.UI.UITextBox uiTextBox4;
        private Label label14;
        private Sunny.UI.UITextBox uiTextBox11;
        private Label label17;
        private Label label6;
        private Label label16;
        private Label label15;
        private Sunny.UI.UISymbolButton uiSymbolButton38;
        private Sunny.UI.UILine uiLine22;
        private Sunny.UI.UISymbolButton uiSymbolButton40;
        private Label label20;
        private Label label21;
        private Sunny.UI.UITextBox uiTextBox6;
        private Label label22;
        private Sunny.UI.UIButton uiButton1;
        private Label label23;
        private Sunny.UI.UISymbolButton uiSymbolButton57;
        private Sunny.UI.UISymbolButton uiSymbolButton58;
        private Sunny.UI.UIButton uiButton9;
        private Sunny.UI.UIComboBox uiComboBox2;
        private Sunny.UI.UISymbolButton uiSymbolButton39;
        private Label label18;
        private Sunny.UI.UITextBox uiTextBox10;
        private Label label19;
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UILine uiLine25;
        private Sunny.UI.UISymbolButton uiSymbolButton59;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Sunny.UI.UISymbolButton uiSymbolButton63;
        private Label label25;
        private Label label24;
        private CheckBox checkBox8;
        private Sunny.UI.UISymbolButton uiSymbolButton60;
        private Sunny.UI.UISymbolButton uiSymbolButton61;
        private Sunny.UI.UISymbolButton uiSymbolButton62;
        private Label label7;
        private Label label8;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Label label29;
        private Label label30;
        private Sunny.UI.UITrackBar trackbarThresholdMax;
        private Label label31;
        private Label lblThresholdMin;
        private Sunny.UI.UICheckBox uiCheckBox4;
        private Sunny.UI.UITrackBar trackbarThresholdMin;
        private Sunny.UI.UIRadioButton uiRadioButton1;
        private Sunny.UI.UIRadioButton uiRadioButton2;
        private Sunny.UI.UIGroupBox uiGroupBox10;
        private Sunny.UI.UISymbolButton btnChannelSplit;
        private Label label9;
        private Sunny.UI.UIComboBox comboChannelSplit;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UISymbolButton uiSymbolButton30;
        private Sunny.UI.UISymbolButton uiSymbolButton31;
        private Label label10;
        private Sunny.UI.UITextBox uiTextBox2;
        private Label label11;
        private Label label12;
        private Sunny.UI.UITextBox uiTextBox3;
        private Label label13;
        private Sunny.UI.UITextBox uiTextBox1;
        private Label label26;
        private Label label27;
        private Sunny.UI.UITextBox txtEyeD_Port;
        private Label label28;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Sunny.UI.UIComboBox comboThresholdType;
        private Sunny.UI.UISymbolButton btnPreProcessRun_One;
        private Sunny.UI.UISymbolButton btnPreProcessDel;
        private Sunny.UI.UISymbolButton btnPreProcessAdd;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay7;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay8;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay9;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay10;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay11;
        private Sunny.UI.UIButton uiButton10;
        private Sunny.UI.UIButton uiButton11;
        private Sunny.UI.UIButton uiButton13;
        private Sunny.UI.UIButton uiButton14;
        private Sunny.UI.UIButton uiButton15;
        private Label label32;
        private Sunny.UI.UILine uiLine23;
        private Label label65;
        private Label label69;
        private TabPage tabPage7;
        private Label label70;
        private TabPage tabPage8;
        private Label label71;
        private TabPage tabPage9;
        private Label label72;
        private TabPage tabPage11;
        private Label label73;
        private Label label76;
        private TabPage tabPage18;
        private Label label77;
        private Label label74;
        private Label label78;
        private Label label79;
        private Label label75;
        private Label label83;
        private Label label82;
        private Label label80;
        private Label label81;
        private Label label84;
        private TabPage tabPage19;
        private Label label86;
        private Label label85;
        private TabPage tabPage20;
        private Label label88;
        private Label label87;
        private Label label89;
        private Sunny.UI.UIComboBox CbTriggerMode;
        private Sunny.UI.UISymbolButton uiSymbolButton28;
        private Label label90;
        private DataGridViewTextBoxColumn No;
        private DataGridViewCheckBoxColumn gridLibraryEnabled;
        private DataGridViewTextBoxColumn gridLibraryName;
        private DataGridViewTextBoxColumn gridLibraryPart;
        private DataGridViewTextBoxColumn Column4;
    }
}