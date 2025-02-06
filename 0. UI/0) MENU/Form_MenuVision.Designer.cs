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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("asdf");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("ImageProcessing", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Algorithm");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.ChkEnable5 = new System.Windows.Forms.CheckBox();
            this.TbExposure5 = new Sunny.UI.UITextBox();
            this.uiLine12 = new Sunny.UI.UILine();
            this.label46 = new System.Windows.Forms.Label();
            this.TbLight4 = new Sunny.UI.UITextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.TbGain4 = new Sunny.UI.UITextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.ChkEnable4 = new System.Windows.Forms.CheckBox();
            this.TbExposure4 = new Sunny.UI.UITextBox();
            this.uiLine10 = new Sunny.UI.UILine();
            this.label49 = new System.Windows.Forms.Label();
            this.TbLight3 = new Sunny.UI.UITextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.TbGain3 = new Sunny.UI.UITextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.ChkEnable3 = new System.Windows.Forms.CheckBox();
            this.TbExposure3 = new Sunny.UI.UITextBox();
            this.uiLine11 = new Sunny.UI.UILine();
            this.label40 = new System.Windows.Forms.Label();
            this.TbLight2 = new Sunny.UI.UITextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.TbGain2 = new Sunny.UI.UITextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.ChkEnable2 = new System.Windows.Forms.CheckBox();
            this.TbExposure2 = new Sunny.UI.UITextBox();
            this.uiLine9 = new Sunny.UI.UILine();
            this.label44 = new System.Windows.Forms.Label();
            this.TbLight1 = new Sunny.UI.UITextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.TbGain1 = new Sunny.UI.UITextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.ChkEnable1 = new System.Windows.Forms.CheckBox();
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
            this.cbIQContinuous = new System.Windows.Forms.CheckBox();
            this.lbCurrentFocusValue = new System.Windows.Forms.Label();
            this.lbBestFocusValue = new System.Windows.Forms.Label();
            this.btnIQStop = new Sunny.UI.UISymbolButton();
            this.btnIQStart = new Sunny.UI.UISymbolButton();
            this.tbMasterHeight = new Sunny.UI.UITextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tbPixelSize = new Sunny.UI.UITextBox();
            this.tbMasterWidth = new Sunny.UI.UITextBox();
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
            this.BtnReplaceLibrary = new Sunny.UI.UISymbolButton();
            this.BtnRegionVisible = new Sunny.UI.UISymbolButton();
            this.DgvGerberInfo = new Sunny.UI.UIDataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnGerberLoad = new Sunny.UI.UISymbolButton();
            this.TbGerberPath = new Sunny.UI.UITextBox();
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
            this.TrvLogic = new Sunny.UI.UITreeView();
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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.uiTabControl4 = new Sunny.UI.UITabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.uiTabControlMenu1 = new Sunny.UI.UITabControlMenu();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tbJobPattern_AcceptScore = new Sunny.UI.UITextBox();
            this.tbJobPattern_MinScore = new Sunny.UI.UITextBox();
            this.tbPatternMasterCount = new Sunny.UI.UITextBox();
            this.label137 = new System.Windows.Forms.Label();
            this.lblDetectedPatternCount = new System.Windows.Forms.Label();
            this.btnJobPatternDelete = new Sunny.UI.UISymbolButton();
            this.comboJobPattern_PatternType = new MetroFramework.Controls.MetroComboBox();
            this.lblTrained = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.uiSymbolButton12 = new Sunny.UI.UISymbolButton();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.btnJobPattern_Roi = new Sunny.UI.UISymbolButton();
            this.btnJobPattern_Train = new Sunny.UI.UISymbolButton();
            this.btnJobPattern_Find = new Sunny.UI.UISymbolButton();
            this.label110 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.cogDisplay_JobPattern = new Cognex.VisionPro.Display.CogDisplay();
            this.label65 = new System.Windows.Forms.Label();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.txt_PinMatchingScoreMin = new Sunny.UI.UITextBox();
            this.txtBlobThreshold = new Sunny.UI.UITextBox();
            this.tbAreaMax = new Sunny.UI.UITextBox();
            this.tbAreaMin = new Sunny.UI.UITextBox();
            this.btnGetBlobPos = new System.Windows.Forms.Button();
            this.btnJobBlob_Roi = new Sunny.UI.UISymbolButton();
            this.CogDisplay_FinMatchingTemplateImg = new Cognex.VisionPro.Display.CogDisplay();
            this.uiSymbolButton29 = new Sunny.UI.UISymbolButton();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.uiSymbolButton32 = new Sunny.UI.UISymbolButton();
            this.label88 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label118 = new System.Windows.Forms.Label();
            this.uiSymbolButton33 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton64 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton65 = new Sunny.UI.UISymbolButton();
            this.btnJobBlobInsp = new System.Windows.Forms.Button();
            this.tabPage19 = new System.Windows.Forms.TabPage();
            this.tbYMaxValue = new Sunny.UI.UITextBox();
            this.tbYMinValue = new Sunny.UI.UITextBox();
            this.tbXMaxValue = new Sunny.UI.UITextBox();
            this.tbXMinValue = new Sunny.UI.UITextBox();
            this.tbAngleMaxValue = new Sunny.UI.UITextBox();
            this.tbAngleMinValue = new Sunny.UI.UITextBox();
            this.tbLineEdgeContrast = new Sunny.UI.UITextBox();
            this.btnDistanceDetail = new Sunny.UI.UISymbolButton();
            this.numericDistanceSamplingCount = new System.Windows.Forms.NumericUpDown();
            this.numericDistanceThickness = new System.Windows.Forms.NumericUpDown();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.cbYValue = new System.Windows.Forms.CheckBox();
            this.cbXValue = new System.Windows.Forms.CheckBox();
            this.cbAngle = new System.Windows.Forms.CheckBox();
            this.label117 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.btnJobDistanceInsp = new Sunny.UI.UISymbolButton();
            this.btnJobDistance_Roi = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton66 = new Sunny.UI.UISymbolButton();
            this.comboLineEdgePolarity = new MetroFramework.Controls.MetroComboBox();
            this.label80 = new System.Windows.Forms.Label();
            this.comboLineEdgeScorer = new MetroFramework.Controls.MetroComboBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.tabPage26 = new System.Windows.Forms.TabPage();
            this.tabPage27 = new System.Windows.Forms.TabPage();
            this.lbColorMaxArea = new Sunny.UI.UITextBox();
            this.lbColorMinArea = new Sunny.UI.UITextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.panel43 = new System.Windows.Forms.Panel();
            this.lbThreshold_Color = new System.Windows.Forms.Label();
            this.trbThreshold_Color = new MetroFramework.Controls.MetroTrackBar();
            this.label97 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label98 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label99 = new System.Windows.Forms.Label();
            this.lbJobColor_Area = new System.Windows.Forms.Label();
            this.btnJobColor_Insp = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label101 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnJobColor_Roi = new System.Windows.Forms.Button();
            this.btnJobColor_AutoColor = new System.Windows.Forms.Button();
            this.lbExtractedColor2 = new System.Windows.Forms.Label();
            this.lbExtractedColor = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.cboColorAlg = new MetroFramework.Controls.MetroComboBox();
            this.label102 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.cboColorCoordinate = new MetroFramework.Controls.MetroComboBox();
            this.label103 = new System.Windows.Forms.Label();
            this.tabPage28 = new System.Windows.Forms.TabPage();
            this.panel64 = new System.Windows.Forms.Panel();
            this.txtColorEx_B = new Sunny.UI.UITextBox();
            this.txtColorEx_G = new Sunny.UI.UITextBox();
            this.txtColorEx_R = new Sunny.UI.UITextBox();
            this.label168 = new System.Windows.Forms.Label();
            this.radioColorEx_Range45 = new System.Windows.Forms.RadioButton();
            this.radioColorEx_Range30 = new System.Windows.Forms.RadioButton();
            this.radioColorEx_Range15 = new System.Windows.Forms.RadioButton();
            this.label171 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.chkColorEx_SimpleMode = new System.Windows.Forms.CheckBox();
            this.label167 = new System.Windows.Forms.Label();
            this.btnJobColorEx_Roi = new Sunny.UI.UISymbolButton();
            this.lblJobColorEx_ResultColor = new System.Windows.Forms.Label();
            this.btnJobColorEx_Get = new System.Windows.Forms.Button();
            this.label130 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.comboCorrectColorEx = new MetroFramework.Controls.MetroComboBox();
            this.label132 = new System.Windows.Forms.Label();
            this.uiSymbolButton67 = new Sunny.UI.UISymbolButton();
            this.label133 = new System.Windows.Forms.Label();
            this.tabPage29 = new System.Windows.Forms.TabPage();
            this.tbIgnoreCount = new Sunny.UI.UITextBox();
            this.tbCircleThickness = new Sunny.UI.UITextBox();
            this.tbCircleContrast = new Sunny.UI.UITextBox();
            this.tbCondensorRectRadio = new Sunny.UI.UITextBox();
            this.tbCircleRectH = new Sunny.UI.UITextBox();
            this.tbCircleRectW = new Sunny.UI.UITextBox();
            this.btnJobCondensor_DistSetting = new Sunny.UI.UISymbolButton();
            this.btnJobCondensor_DistInsp = new Sunny.UI.UISymbolButton();
            this.chkCondensor_UseDist = new System.Windows.Forms.CheckBox();
            this.label149 = new System.Windows.Forms.Label();
            this.btnCondensorAutoRegion = new Sunny.UI.UISymbolButton();
            this.label104 = new System.Windows.Forms.Label();
            this.comboCondensorPolarity = new MetroFramework.Controls.MetroComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.btnJobCondensor_Inspection = new Sunny.UI.UISymbolButton();
            this.label116 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.radioCondensorTB = new Sunny.UI.UIRadioButton();
            this.radioCondensorLR = new Sunny.UI.UIRadioButton();
            this.label119 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.btnJobCondensor_Roi = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton68 = new Sunny.UI.UISymbolButton();
            this.tabPage30 = new System.Windows.Forms.TabPage();
            this.txtJobConnector_OKArea = new Sunny.UI.UITextBox();
            this.label163 = new System.Windows.Forms.Label();
            this.panel62 = new System.Windows.Forms.Panel();
            this.radioJobConnector_AreaRB = new Sunny.UI.UIRadioButton();
            this.radioJobConnector_AreaLT = new Sunny.UI.UIRadioButton();
            this.uiSymbolButton69 = new Sunny.UI.UISymbolButton();
            this.btnJobConnector_Projection = new Sunny.UI.UISymbolButton();
            this.label162 = new System.Windows.Forms.Label();
            this.txtJobConnector_AreaMax = new Sunny.UI.UITextBox();
            this.txtJobConnector_AreaMin = new Sunny.UI.UITextBox();
            this.label161 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.txtJobConnector_BoxHeight = new Sunny.UI.UITextBox();
            this.label160 = new System.Windows.Forms.Label();
            this.txtJobConnector_BoxWidth = new Sunny.UI.UITextBox();
            this.chkJobConnector_BinInv = new System.Windows.Forms.CheckBox();
            this.label157 = new System.Windows.Forms.Label();
            this.txtJobConnector_Threshold = new Sunny.UI.UITextBox();
            this.label159 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.checkBox60 = new System.Windows.Forms.CheckBox();
            this.uiSymbolButton70 = new Sunny.UI.UISymbolButton();
            this.label154 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.metroComboBox3 = new MetroFramework.Controls.MetroComboBox();
            this.label152 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.txtJobConnector_Score = new Sunny.UI.UITextBox();
            this.label151 = new System.Windows.Forms.Label();
            this.panel61 = new System.Windows.Forms.Panel();
            this.radioJobConnector_TB = new Sunny.UI.UIRadioButton();
            this.radioJobConnector_LR = new Sunny.UI.UIRadioButton();
            this.label153 = new System.Windows.Forms.Label();
            this.panel58 = new System.Windows.Forms.Panel();
            this.cogDisplay_Connector = new Cognex.VisionPro.Display.CogDisplay();
            this.label165 = new System.Windows.Forms.Label();
            this.btnJobConnector_Roi = new Sunny.UI.UISymbolButton();
            this.btnJobConnector_Train = new Sunny.UI.UISymbolButton();
            this.btnJobConnector_Find = new Sunny.UI.UISymbolButton();
            this.label164 = new System.Windows.Forms.Label();
            this.tabPage31 = new System.Windows.Forms.TabPage();
            this.panel63 = new System.Windows.Forms.Panel();
            this.lblJobPin_MeasColor = new System.Windows.Forms.Label();
            this.lblJobPin_ShapeColor = new System.Windows.Forms.Label();
            this.chkJobPin_UseColorMatching = new System.Windows.Forms.CheckBox();
            this.label166 = new System.Windows.Forms.Label();
            this.chk_BlobPos_UseAlign = new System.Windows.Forms.CheckBox();
            this.panel55 = new System.Windows.Forms.Panel();
            this.label145 = new System.Windows.Forms.Label();
            this.btnJobPin_Master = new Sunny.UI.UISymbolButton();
            this.panel53 = new System.Windows.Forms.Panel();
            this.label144 = new System.Windows.Forms.Label();
            this.panel54 = new System.Windows.Forms.Panel();
            this.chk_Pin_BinaryInv = new System.Windows.Forms.CheckBox();
            this.nb_Pin_Threshold = new System.Windows.Forms.NumericUpDown();
            this.checkBox53 = new System.Windows.Forms.CheckBox();
            this.checkBox54 = new System.Windows.Forms.CheckBox();
            this.panel47 = new System.Windows.Forms.Panel();
            this.label142 = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.nb_Pin_SpecRoi_Height = new System.Windows.Forms.NumericUpDown();
            this.label143 = new System.Windows.Forms.Label();
            this.nb_Pin_SpecRoi_Width = new System.Windows.Forms.NumericUpDown();
            this.checkBox51 = new System.Windows.Forms.CheckBox();
            this.checkBox52 = new System.Windows.Forms.CheckBox();
            this.panel42 = new System.Windows.Forms.Panel();
            this.label139 = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
            this.nb_Pin_AreaMax = new System.Windows.Forms.NumericUpDown();
            this.label141 = new System.Windows.Forms.Label();
            this.nb_Pin_AreaMin = new System.Windows.Forms.NumericUpDown();
            this.checkBox49 = new System.Windows.Forms.CheckBox();
            this.checkBox50 = new System.Windows.Forms.CheckBox();
            this.btnJobPin_Roi = new Sunny.UI.UISymbolButton();
            this.btnJobPin_Find = new Sunny.UI.UISymbolButton();
            this.panel59 = new System.Windows.Forms.Panel();
            this.label146 = new System.Windows.Forms.Label();
            this.panel60 = new System.Windows.Forms.Panel();
            this.nb_Pin_OkCount = new System.Windows.Forms.NumericUpDown();
            this.checkBox71 = new System.Windows.Forms.CheckBox();
            this.checkBox72 = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.DgvLogicList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiSymbolButton63 = new Sunny.UI.UISymbolButton();
            this.label24 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.uiSymbolButton60 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton61 = new Sunny.UI.UISymbolButton();
            this.BtnLogicAdd = new Sunny.UI.UISymbolButton();
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
            this.BtnSettingLogic = new Sunny.UI.UISymbolButton();
            this.label18 = new System.Windows.Forms.Label();
            this.tbLogicName = new Sunny.UI.UITextBox();
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
            this.DgvJobList = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLibraryName = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridLibraryEnabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiSymbolButton37 = new Sunny.UI.UISymbolButton();
            this.cbAlgorithm = new Sunny.UI.UIComboBox();
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
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label39 = new System.Windows.Forms.Label();
            this.TbOnnxPath = new Sunny.UI.UITextBox();
            this.BtnOpenOnnx = new Sunny.UI.UISymbolButton();
            this.label55 = new System.Windows.Forms.Label();
            this.TbThresholdEYED = new Sunny.UI.UITextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.CbRotateImageEYED = new Sunny.UI.UIComboBox();
            this.BtnRoiEYED = new Sunny.UI.UISymbolButton();
            this.BtnFindEYED = new Sunny.UI.UISymbolButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChkSpecRegionEYED = new System.Windows.Forms.CheckBox();
            this.label87 = new System.Windows.Forms.Label();
            this.LblResultEYED = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.DgvGerberInfo)).BeginInit();
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
            this.tabPage5.SuspendLayout();
            this.uiTabControl4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.uiTabControlMenu1.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_JobPattern)).BeginInit();
            this.tabPage18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CogDisplay_FinMatchingTemplateImg)).BeginInit();
            this.panel15.SuspendLayout();
            this.tabPage19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDistanceSamplingCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDistanceThickness)).BeginInit();
            this.tabPage26.SuspendLayout();
            this.tabPage27.SuspendLayout();
            this.panel43.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel19.SuspendLayout();
            this.tabPage28.SuspendLayout();
            this.panel64.SuspendLayout();
            this.tabPage29.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tabPage30.SuspendLayout();
            this.panel62.SuspendLayout();
            this.panel61.SuspendLayout();
            this.panel58.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Connector)).BeginInit();
            this.tabPage31.SuspendLayout();
            this.panel63.SuspendLayout();
            this.panel55.SuspendLayout();
            this.panel53.SuspendLayout();
            this.panel54.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_Threshold)).BeginInit();
            this.panel47.SuspendLayout();
            this.panel48.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_SpecRoi_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_SpecRoi_Width)).BeginInit();
            this.panel42.SuspendLayout();
            this.panel44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_AreaMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_AreaMin)).BeginInit();
            this.panel59.SuspendLayout();
            this.panel60.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_OkCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLogicList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvJobList)).BeginInit();
            this.tabPage15.SuspendLayout();
            this.uiTabControl7.SuspendLayout();
            this.tabPage16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView5)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.btnView_Setting1.GroupIndex = 1;
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
            this.btnView_Setting2.GroupIndex = 1;
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
            this.btnView_Setting4.GroupIndex = 1;
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
            this.btnView_Setting3.GroupIndex = 1;
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
            this.btnView_Result4.GroupIndex = 1;
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
            this.btnView_Result3.GroupIndex = 1;
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
            this.btnView_Result2.GroupIndex = 1;
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
            this.btnView_Result1.GroupIndex = 1;
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
            this.btnViewGrabIndex4.GroupIndex = 2;
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
            this.btnViewGrabIndex3.GroupIndex = 2;
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
            this.btnViewGrabIndex2.GroupIndex = 2;
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
            this.btnViewGrabIndex1.GroupIndex = 2;
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
            this.btnViewGrabIndex5.GroupIndex = 2;
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
            this.btnView_Full.GroupIndex = 1;
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
            this.uiGroupBox14.Controls.Add(this.ChkEnable5);
            this.uiGroupBox14.Controls.Add(this.TbExposure5);
            this.uiGroupBox14.Controls.Add(this.uiLine12);
            this.uiGroupBox14.Controls.Add(this.label46);
            this.uiGroupBox14.Controls.Add(this.TbLight4);
            this.uiGroupBox14.Controls.Add(this.label47);
            this.uiGroupBox14.Controls.Add(this.TbGain4);
            this.uiGroupBox14.Controls.Add(this.label48);
            this.uiGroupBox14.Controls.Add(this.ChkEnable4);
            this.uiGroupBox14.Controls.Add(this.TbExposure4);
            this.uiGroupBox14.Controls.Add(this.uiLine10);
            this.uiGroupBox14.Controls.Add(this.label49);
            this.uiGroupBox14.Controls.Add(this.TbLight3);
            this.uiGroupBox14.Controls.Add(this.label50);
            this.uiGroupBox14.Controls.Add(this.TbGain3);
            this.uiGroupBox14.Controls.Add(this.label51);
            this.uiGroupBox14.Controls.Add(this.ChkEnable3);
            this.uiGroupBox14.Controls.Add(this.TbExposure3);
            this.uiGroupBox14.Controls.Add(this.uiLine11);
            this.uiGroupBox14.Controls.Add(this.label40);
            this.uiGroupBox14.Controls.Add(this.TbLight2);
            this.uiGroupBox14.Controls.Add(this.label41);
            this.uiGroupBox14.Controls.Add(this.TbGain2);
            this.uiGroupBox14.Controls.Add(this.label45);
            this.uiGroupBox14.Controls.Add(this.ChkEnable2);
            this.uiGroupBox14.Controls.Add(this.TbExposure2);
            this.uiGroupBox14.Controls.Add(this.uiLine9);
            this.uiGroupBox14.Controls.Add(this.label44);
            this.uiGroupBox14.Controls.Add(this.TbLight1);
            this.uiGroupBox14.Controls.Add(this.label43);
            this.uiGroupBox14.Controls.Add(this.TbGain1);
            this.uiGroupBox14.Controls.Add(this.label42);
            this.uiGroupBox14.Controls.Add(this.ChkEnable1);
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
            this.TbGain5.Text = "0.00";
            this.TbGain5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain5.Type = Sunny.UI.UITextBox.UIEditType.Double;
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
            // ChkEnable5
            // 
            this.ChkEnable5.AutoSize = true;
            this.ChkEnable5.BackColor = System.Drawing.Color.Transparent;
            this.ChkEnable5.Checked = true;
            this.ChkEnable5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEnable5.Font = new System.Drawing.Font("Arial", 8F);
            this.ChkEnable5.ForeColor = System.Drawing.Color.Black;
            this.ChkEnable5.Location = new System.Drawing.Point(20, 177);
            this.ChkEnable5.Name = "ChkEnable5";
            this.ChkEnable5.Size = new System.Drawing.Size(65, 18);
            this.ChkEnable5.TabIndex = 3584;
            this.ChkEnable5.Text = "Grab #5";
            this.ChkEnable5.UseVisualStyleBackColor = false;
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
            this.TbGain4.Text = "0.00";
            this.TbGain4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain4.Type = Sunny.UI.UITextBox.UIEditType.Double;
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
            // ChkEnable4
            // 
            this.ChkEnable4.AutoSize = true;
            this.ChkEnable4.BackColor = System.Drawing.Color.Transparent;
            this.ChkEnable4.Checked = true;
            this.ChkEnable4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEnable4.Font = new System.Drawing.Font("Arial", 8F);
            this.ChkEnable4.ForeColor = System.Drawing.Color.Black;
            this.ChkEnable4.Location = new System.Drawing.Point(20, 141);
            this.ChkEnable4.Name = "ChkEnable4";
            this.ChkEnable4.Size = new System.Drawing.Size(65, 18);
            this.ChkEnable4.TabIndex = 3576;
            this.ChkEnable4.Text = "Grab #4";
            this.ChkEnable4.UseVisualStyleBackColor = false;
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
            this.TbGain3.Text = "0.00";
            this.TbGain3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain3.Type = Sunny.UI.UITextBox.UIEditType.Double;
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
            // ChkEnable3
            // 
            this.ChkEnable3.AutoSize = true;
            this.ChkEnable3.BackColor = System.Drawing.Color.Transparent;
            this.ChkEnable3.Checked = true;
            this.ChkEnable3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEnable3.Font = new System.Drawing.Font("Arial", 8F);
            this.ChkEnable3.ForeColor = System.Drawing.Color.Black;
            this.ChkEnable3.Location = new System.Drawing.Point(20, 105);
            this.ChkEnable3.Name = "ChkEnable3";
            this.ChkEnable3.Size = new System.Drawing.Size(65, 18);
            this.ChkEnable3.TabIndex = 3568;
            this.ChkEnable3.Text = "Grab #3";
            this.ChkEnable3.UseVisualStyleBackColor = false;
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
            this.TbGain2.Text = "0.00";
            this.TbGain2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain2.Type = Sunny.UI.UITextBox.UIEditType.Double;
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
            // ChkEnable2
            // 
            this.ChkEnable2.AutoSize = true;
            this.ChkEnable2.BackColor = System.Drawing.Color.Transparent;
            this.ChkEnable2.Checked = true;
            this.ChkEnable2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEnable2.Font = new System.Drawing.Font("Arial", 8F);
            this.ChkEnable2.ForeColor = System.Drawing.Color.Black;
            this.ChkEnable2.Location = new System.Drawing.Point(20, 71);
            this.ChkEnable2.Name = "ChkEnable2";
            this.ChkEnable2.Size = new System.Drawing.Size(65, 18);
            this.ChkEnable2.TabIndex = 3560;
            this.ChkEnable2.Text = "Grab #2";
            this.ChkEnable2.UseVisualStyleBackColor = false;
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
            this.TbGain1.Text = "0.00";
            this.TbGain1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGain1.Type = Sunny.UI.UITextBox.UIEditType.Double;
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
            // ChkEnable1
            // 
            this.ChkEnable1.AutoSize = true;
            this.ChkEnable1.BackColor = System.Drawing.Color.Transparent;
            this.ChkEnable1.Checked = true;
            this.ChkEnable1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEnable1.Font = new System.Drawing.Font("Arial", 8F);
            this.ChkEnable1.ForeColor = System.Drawing.Color.Black;
            this.ChkEnable1.Location = new System.Drawing.Point(20, 35);
            this.ChkEnable1.Name = "ChkEnable1";
            this.ChkEnable1.Size = new System.Drawing.Size(65, 18);
            this.ChkEnable1.TabIndex = 3552;
            this.ChkEnable1.Text = "Grab #1";
            this.ChkEnable1.UseVisualStyleBackColor = false;
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
            this.uiGroupBox13.Visible = false;
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
            this.uiGroupBox12.Controls.Add(this.cbIQContinuous);
            this.uiGroupBox12.Controls.Add(this.lbCurrentFocusValue);
            this.uiGroupBox12.Controls.Add(this.lbBestFocusValue);
            this.uiGroupBox12.Controls.Add(this.btnIQStop);
            this.uiGroupBox12.Controls.Add(this.btnIQStart);
            this.uiGroupBox12.Controls.Add(this.tbMasterHeight);
            this.uiGroupBox12.Controls.Add(this.label38);
            this.uiGroupBox12.Controls.Add(this.tbPixelSize);
            this.uiGroupBox12.Controls.Add(this.tbMasterWidth);
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
            this.uiGroupBox12.Size = new System.Drawing.Size(220, 261);
            this.uiGroupBox12.TabIndex = 3467;
            this.uiGroupBox12.Text = "I.Q ( Pixel Size, Focus )";
            this.uiGroupBox12.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIQContinuous
            // 
            this.cbIQContinuous.AutoSize = true;
            this.cbIQContinuous.Location = new System.Drawing.Point(10, 193);
            this.cbIQContinuous.Name = "cbIQContinuous";
            this.cbIQContinuous.Size = new System.Drawing.Size(83, 17);
            this.cbIQContinuous.TabIndex = 3539;
            this.cbIQContinuous.Text = "Continuous";
            this.cbIQContinuous.UseVisualStyleBackColor = true;
            // 
            // lbCurrentFocusValue
            // 
            this.lbCurrentFocusValue.Font = new System.Drawing.Font("Arial", 8F);
            this.lbCurrentFocusValue.ForeColor = System.Drawing.Color.Black;
            this.lbCurrentFocusValue.Location = new System.Drawing.Point(8, 157);
            this.lbCurrentFocusValue.Name = "lbCurrentFocusValue";
            this.lbCurrentFocusValue.Size = new System.Drawing.Size(203, 25);
            this.lbCurrentFocusValue.TabIndex = 3537;
            this.lbCurrentFocusValue.Text = "Current Focus Value : 0000";
            this.lbCurrentFocusValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBestFocusValue
            // 
            this.lbBestFocusValue.Font = new System.Drawing.Font("Arial", 8F);
            this.lbBestFocusValue.ForeColor = System.Drawing.Color.Black;
            this.lbBestFocusValue.Location = new System.Drawing.Point(7, 132);
            this.lbBestFocusValue.Name = "lbBestFocusValue";
            this.lbBestFocusValue.Size = new System.Drawing.Size(203, 25);
            this.lbBestFocusValue.TabIndex = 3536;
            this.lbBestFocusValue.Text = "Best Focus Value : 0000";
            this.lbBestFocusValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIQStop
            // 
            this.btnIQStop.BackColor = System.Drawing.Color.Transparent;
            this.btnIQStop.CircleRectWidth = 0;
            this.btnIQStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIQStop.FillColor = System.Drawing.Color.Transparent;
            this.btnIQStop.FillColor2 = System.Drawing.Color.Transparent;
            this.btnIQStop.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnIQStop.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnIQStop.FillPressColor = System.Drawing.Color.Transparent;
            this.btnIQStop.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStop.Font = new System.Drawing.Font("Arial", 10F);
            this.btnIQStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStop.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnIQStop.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btnIQStop.ForePressColor = System.Drawing.Color.Transparent;
            this.btnIQStop.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIQStop.Location = new System.Drawing.Point(101, 216);
            this.btnIQStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIQStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnIQStop.Name = "btnIQStop";
            this.btnIQStop.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnIQStop.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStop.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnIQStop.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnIQStop.RectPressColor = System.Drawing.Color.Transparent;
            this.btnIQStop.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStop.Size = new System.Drawing.Size(85, 30);
            this.btnIQStop.Style = Sunny.UI.UIStyle.Custom;
            this.btnIQStop.StyleCustomMode = true;
            this.btnIQStop.Symbol = 61517;
            this.btnIQStop.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStop.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btnIQStop.SymbolSize = 18;
            this.btnIQStop.TabIndex = 3535;
            this.btnIQStop.Tag = "IQStop";
            this.btnIQStop.Text = "Stop";
            this.btnIQStop.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIQStop.Click += new System.EventHandler(this.btnIQCalibration_Click);
            // 
            // btnIQStart
            // 
            this.btnIQStart.BackColor = System.Drawing.Color.Transparent;
            this.btnIQStart.CircleRectWidth = 0;
            this.btnIQStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIQStart.FillColor = System.Drawing.Color.Transparent;
            this.btnIQStart.FillColor2 = System.Drawing.Color.Transparent;
            this.btnIQStart.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnIQStart.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnIQStart.FillPressColor = System.Drawing.Color.Transparent;
            this.btnIQStart.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStart.Font = new System.Drawing.Font("Arial", 10F);
            this.btnIQStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStart.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnIQStart.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btnIQStart.ForePressColor = System.Drawing.Color.Transparent;
            this.btnIQStart.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIQStart.Location = new System.Drawing.Point(10, 216);
            this.btnIQStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIQStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnIQStart.Name = "btnIQStart";
            this.btnIQStart.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnIQStart.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStart.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnIQStart.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnIQStart.RectPressColor = System.Drawing.Color.Transparent;
            this.btnIQStart.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStart.Size = new System.Drawing.Size(85, 30);
            this.btnIQStart.Style = Sunny.UI.UIStyle.Custom;
            this.btnIQStart.StyleCustomMode = true;
            this.btnIQStart.Symbol = 61515;
            this.btnIQStart.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStart.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btnIQStart.SymbolSize = 18;
            this.btnIQStart.TabIndex = 3534;
            this.btnIQStart.Tag = "IQStart";
            this.btnIQStart.Text = "Start";
            this.btnIQStart.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIQStart.Click += new System.EventHandler(this.btnIQCalibration_Click);
            // 
            // tbMasterHeight
            // 
            this.tbMasterHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMasterHeight.FillColor = System.Drawing.SystemColors.Control;
            this.tbMasterHeight.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMasterHeight.ForeColor = System.Drawing.Color.Black;
            this.tbMasterHeight.Location = new System.Drawing.Point(109, 63);
            this.tbMasterHeight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbMasterHeight.MinimumSize = new System.Drawing.Size(1, 20);
            this.tbMasterHeight.Name = "tbMasterHeight";
            this.tbMasterHeight.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbMasterHeight.RectColor = System.Drawing.Color.DimGray;
            this.tbMasterHeight.ShowText = false;
            this.tbMasterHeight.Size = new System.Drawing.Size(100, 26);
            this.tbMasterHeight.TabIndex = 3525;
            this.tbMasterHeight.Text = "0.00";
            this.tbMasterHeight.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbMasterHeight.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.tbMasterHeight.Watermark = "";
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
            // tbPixelSize
            // 
            this.tbPixelSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPixelSize.FillColor = System.Drawing.SystemColors.Control;
            this.tbPixelSize.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPixelSize.ForeColor = System.Drawing.Color.Black;
            this.tbPixelSize.Location = new System.Drawing.Point(109, 94);
            this.tbPixelSize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbPixelSize.MinimumSize = new System.Drawing.Size(1, 20);
            this.tbPixelSize.Name = "tbPixelSize";
            this.tbPixelSize.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbPixelSize.RectColor = System.Drawing.Color.DimGray;
            this.tbPixelSize.ShowText = false;
            this.tbPixelSize.Size = new System.Drawing.Size(100, 26);
            this.tbPixelSize.TabIndex = 3522;
            this.tbPixelSize.Text = "0.00";
            this.tbPixelSize.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbPixelSize.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.tbPixelSize.Watermark = "";
            // 
            // tbMasterWidth
            // 
            this.tbMasterWidth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMasterWidth.FillColor = System.Drawing.SystemColors.Control;
            this.tbMasterWidth.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMasterWidth.ForeColor = System.Drawing.Color.Black;
            this.tbMasterWidth.Location = new System.Drawing.Point(109, 32);
            this.tbMasterWidth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbMasterWidth.MinimumSize = new System.Drawing.Size(1, 20);
            this.tbMasterWidth.Name = "tbMasterWidth";
            this.tbMasterWidth.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbMasterWidth.RectColor = System.Drawing.Color.DimGray;
            this.tbMasterWidth.ShowText = false;
            this.tbMasterWidth.Size = new System.Drawing.Size(100, 26);
            this.tbMasterWidth.TabIndex = 3520;
            this.tbMasterWidth.Text = "0.00";
            this.tbMasterWidth.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbMasterWidth.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.tbMasterWidth.Watermark = "";
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
            this.uiGroupBox18.Controls.Add(this.BtnReplaceLibrary);
            this.uiGroupBox18.Controls.Add(this.BtnRegionVisible);
            this.uiGroupBox18.Controls.Add(this.DgvGerberInfo);
            this.uiGroupBox18.Controls.Add(this.BtnGerberLoad);
            this.uiGroupBox18.Controls.Add(this.TbGerberPath);
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
            // BtnReplaceLibrary
            // 
            this.BtnReplaceLibrary.BackColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.CircleRectWidth = 0;
            this.BtnReplaceLibrary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReplaceLibrary.FillColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnReplaceLibrary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnReplaceLibrary.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.ForeHoverColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReplaceLibrary.Location = new System.Drawing.Point(617, 464);
            this.BtnReplaceLibrary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnReplaceLibrary.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnReplaceLibrary.Name = "BtnReplaceLibrary";
            this.BtnReplaceLibrary.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BtnReplaceLibrary.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnReplaceLibrary.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.RectHoverColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.Size = new System.Drawing.Size(148, 26);
            this.BtnReplaceLibrary.Style = Sunny.UI.UIStyle.Custom;
            this.BtnReplaceLibrary.StyleCustomMode = true;
            this.BtnReplaceLibrary.Symbol = 362023;
            this.BtnReplaceLibrary.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnReplaceLibrary.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.BtnReplaceLibrary.SymbolSize = 18;
            this.BtnReplaceLibrary.TabIndex = 3535;
            this.BtnReplaceLibrary.Tag = "ZoomIn";
            this.BtnReplaceLibrary.Text = "Auto Replace";
            this.BtnReplaceLibrary.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReplaceLibrary.Click += new System.EventHandler(this.BtnReplaceLibrary_Click);
            // 
            // BtnRegionVisible
            // 
            this.BtnRegionVisible.BackColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.CircleRectWidth = 0;
            this.BtnRegionVisible.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRegionVisible.FillColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnRegionVisible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRegionVisible.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.ForeHoverColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegionVisible.Location = new System.Drawing.Point(617, 437);
            this.BtnRegionVisible.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnRegionVisible.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnRegionVisible.Name = "BtnRegionVisible";
            this.BtnRegionVisible.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BtnRegionVisible.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRegionVisible.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.RectHoverColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.Size = new System.Drawing.Size(148, 26);
            this.BtnRegionVisible.Style = Sunny.UI.UIStyle.Custom;
            this.BtnRegionVisible.StyleCustomMode = true;
            this.BtnRegionVisible.Symbol = 61717;
            this.BtnRegionVisible.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRegionVisible.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.BtnRegionVisible.SymbolSize = 18;
            this.BtnRegionVisible.TabIndex = 3534;
            this.BtnRegionVisible.Tag = "ZoomIn";
            this.BtnRegionVisible.Text = "Region Visible";
            this.BtnRegionVisible.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRegionVisible.Click += new System.EventHandler(this.BtnRegionVisible_Click);
            // 
            // DgvGerberInfo
            // 
            this.DgvGerberInfo.AllowUserToAddRows = false;
            this.DgvGerberInfo.AllowUserToDeleteRows = false;
            this.DgvGerberInfo.AllowUserToResizeColumns = false;
            this.DgvGerberInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.White;
            this.DgvGerberInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle30;
            this.DgvGerberInfo.BackgroundColor = System.Drawing.Color.Silver;
            this.DgvGerberInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGerberInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.DgvGerberInfo.ColumnHeadersHeight = 20;
            this.DgvGerberInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvGerberInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.Column1,
            this.Column2,
            this.dataGridViewTextBoxColumn12});
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvGerberInfo.DefaultCellStyle = dataGridViewCellStyle32;
            this.DgvGerberInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvGerberInfo.EnableHeadersVisualStyles = false;
            this.DgvGerberInfo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DgvGerberInfo.GridColor = System.Drawing.Color.Silver;
            this.DgvGerberInfo.Location = new System.Drawing.Point(10, 65);
            this.DgvGerberInfo.MultiSelect = false;
            this.DgvGerberInfo.Name = "DgvGerberInfo";
            this.DgvGerberInfo.ReadOnly = true;
            this.DgvGerberInfo.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle33.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGerberInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.DgvGerberInfo.RowHeadersVisible = false;
            this.DgvGerberInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.White;
            this.DgvGerberInfo.RowsDefaultCellStyle = dataGridViewCellStyle34;
            this.DgvGerberInfo.RowTemplate.Height = 25;
            this.DgvGerberInfo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvGerberInfo.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.DgvGerberInfo.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.DgvGerberInfo.ScrollBarStyleInherited = false;
            this.DgvGerberInfo.SelectedIndex = -1;
            this.DgvGerberInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvGerberInfo.Size = new System.Drawing.Size(600, 491);
            this.DgvGerberInfo.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DgvGerberInfo.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DgvGerberInfo.TabIndex = 3533;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Location No";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn11.Width = 125;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Part Code";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Enabled";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 75;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Position";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // BtnGerberLoad
            // 
            this.BtnGerberLoad.BackColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.CircleRectWidth = 0;
            this.BtnGerberLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGerberLoad.FillColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnGerberLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGerberLoad.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.ForeHoverColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGerberLoad.Location = new System.Drawing.Point(510, 32);
            this.BtnGerberLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGerberLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnGerberLoad.Name = "BtnGerberLoad";
            this.BtnGerberLoad.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BtnGerberLoad.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGerberLoad.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.RectHoverColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.Size = new System.Drawing.Size(100, 26);
            this.BtnGerberLoad.Style = Sunny.UI.UIStyle.Custom;
            this.BtnGerberLoad.StyleCustomMode = true;
            this.BtnGerberLoad.Symbol = 61717;
            this.BtnGerberLoad.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGerberLoad.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.BtnGerberLoad.SymbolSize = 18;
            this.BtnGerberLoad.TabIndex = 3532;
            this.BtnGerberLoad.Tag = "ZoomIn";
            this.BtnGerberLoad.Text = "Load";
            this.BtnGerberLoad.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGerberLoad.Click += new System.EventHandler(this.BtnGerberLoad_Click);
            // 
            // TbGerberPath
            // 
            this.TbGerberPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbGerberPath.FillColor = System.Drawing.SystemColors.Control;
            this.TbGerberPath.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbGerberPath.ForeColor = System.Drawing.Color.Black;
            this.TbGerberPath.Location = new System.Drawing.Point(85, 32);
            this.TbGerberPath.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbGerberPath.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbGerberPath.Name = "TbGerberPath";
            this.TbGerberPath.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbGerberPath.RectColor = System.Drawing.Color.DimGray;
            this.TbGerberPath.ShowText = false;
            this.TbGerberPath.Size = new System.Drawing.Size(422, 26);
            this.TbGerberPath.TabIndex = 3520;
            this.TbGerberPath.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbGerberPath.Watermark = "";
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
            this.tabPage14.Controls.Add(this.TrvLogic);
            this.tabPage14.Controls.Add(this.label7);
            this.tabPage14.Controls.Add(this.uiTabControl3);
            this.tabPage14.Controls.Add(this.label25);
            this.tabPage14.Controls.Add(this.DgvLogicList);
            this.tabPage14.Controls.Add(this.uiSymbolButton63);
            this.tabPage14.Controls.Add(this.label24);
            this.tabPage14.Controls.Add(this.checkBox8);
            this.tabPage14.Controls.Add(this.uiSymbolButton60);
            this.tabPage14.Controls.Add(this.uiSymbolButton61);
            this.tabPage14.Controls.Add(this.BtnLogicAdd);
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
            this.tabPage14.Controls.Add(this.BtnSettingLogic);
            this.tabPage14.Controls.Add(this.label18);
            this.tabPage14.Controls.Add(this.tbLogicName);
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
            this.tabPage14.Controls.Add(this.DgvJobList);
            this.tabPage14.Controls.Add(this.uiSymbolButton37);
            this.tabPage14.Controls.Add(this.cbAlgorithm);
            this.tabPage14.Location = new System.Drawing.Point(0, 40);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Size = new System.Drawing.Size(1214, 784);
            this.tabPage14.TabIndex = 2;
            this.tabPage14.Text = "03. JOB";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // TrvLogic
            // 
            this.TrvLogic.BackColor = System.Drawing.Color.DimGray;
            this.TrvLogic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TrvLogic.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TrvLogic.ForeColor = System.Drawing.Color.White;
            this.TrvLogic.Location = new System.Drawing.Point(552, 8);
            this.TrvLogic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TrvLogic.MinimumSize = new System.Drawing.Size(1, 1);
            this.TrvLogic.Name = "TrvLogic";
            treeNode4.Name = "노드0";
            treeNode4.Text = "asdf";
            treeNode5.Checked = true;
            treeNode5.Name = "PreImage";
            treeNode5.Text = "ImageProcessing";
            treeNode6.Name = "Core";
            treeNode6.Text = "Algorithm";
            this.TrvLogic.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.TrvLogic.ScrollBarStyleInherited = false;
            this.TrvLogic.ShowText = false;
            this.TrvLogic.Size = new System.Drawing.Size(655, 214);
            this.TrvLogic.TabIndex = 3684;
            this.TrvLogic.Text = "uiTreeView1";
            this.TrvLogic.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.uiTabControl3.Controls.Add(this.tabPage5);
            this.uiTabControl3.Controls.Add(this.tabPage6);
            this.uiTabControl3.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl3.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiTabControl3.ItemSize = new System.Drawing.Size(50, 40);
            this.uiTabControl3.Location = new System.Drawing.Point(552, 230);
            this.uiTabControl3.MainPage = "";
            this.uiTabControl3.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl3.Name = "uiTabControl3";
            this.uiTabControl3.SelectedIndex = 0;
            this.uiTabControl3.Size = new System.Drawing.Size(658, 550);
            this.uiTabControl3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl3.TabBackColor = System.Drawing.Color.White;
            this.uiTabControl3.TabIndex = 3683;
            this.uiTabControl3.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.uiTabControl3.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl3.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl3.TabUnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
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
            this.tabPage4.Size = new System.Drawing.Size(658, 510);
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
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle35;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle37;
            this.uiDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.Silver;
            this.uiDataGridView1.Location = new System.Drawing.Point(21, 119);
            this.uiDataGridView1.MultiSelect = false;
            this.uiDataGridView1.Name = "uiDataGridView1";
            this.uiDataGridView1.ReadOnly = true;
            this.uiDataGridView1.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle38.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle38;
            this.uiDataGridView1.RowHeadersVisible = false;
            this.uiDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle39;
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
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.uiTabControl4);
            this.tabPage5.Location = new System.Drawing.Point(0, 40);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(200, 60);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "Pre";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // uiTabControl4
            // 
            this.uiTabControl4.Controls.Add(this.tabPage7);
            this.uiTabControl4.Controls.Add(this.tabPage8);
            this.uiTabControl4.Controls.Add(this.tabPage9);
            this.uiTabControl4.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiTabControl4.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl4.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl4.MainPage = "";
            this.uiTabControl4.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl4.Name = "uiTabControl4";
            this.uiTabControl4.SelectedIndex = 0;
            this.uiTabControl4.Size = new System.Drawing.Size(656, 491);
            this.uiTabControl4.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl4.TabBackColor = System.Drawing.Color.White;
            this.uiTabControl4.TabIndex = 0;
            this.uiTabControl4.TabSelectedColor = System.Drawing.Color.DimGray;
            this.uiTabControl4.TabSelectedForeColor = System.Drawing.Color.Black;
            this.uiTabControl4.TabSelectedHighColor = System.Drawing.Color.Black;
            this.uiTabControl4.TabUnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiTabControl4.TabUnSelectedForeColor = System.Drawing.Color.Black;
            this.uiTabControl4.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(0, 40);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(656, 451);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Binalize";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(0, 40);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(200, 60);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Morphology";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(0, 40);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(200, 60);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "Convolution";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.uiTabControlMenu1);
            this.tabPage6.Location = new System.Drawing.Point(0, 40);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(658, 510);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "Core";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // uiTabControlMenu1
            // 
            this.uiTabControlMenu1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.uiTabControlMenu1.Controls.Add(this.tabPage11);
            this.uiTabControlMenu1.Controls.Add(this.tabPage18);
            this.uiTabControlMenu1.Controls.Add(this.tabPage19);
            this.uiTabControlMenu1.Controls.Add(this.tabPage26);
            this.uiTabControlMenu1.Controls.Add(this.tabPage27);
            this.uiTabControlMenu1.Controls.Add(this.tabPage28);
            this.uiTabControlMenu1.Controls.Add(this.tabPage29);
            this.uiTabControlMenu1.Controls.Add(this.tabPage30);
            this.uiTabControlMenu1.Controls.Add(this.tabPage31);
            this.uiTabControlMenu1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControlMenu1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.uiTabControlMenu1.ItemSize = new System.Drawing.Size(90, 30);
            this.uiTabControlMenu1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControlMenu1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControlMenu1.Multiline = true;
            this.uiTabControlMenu1.Name = "uiTabControlMenu1";
            this.uiTabControlMenu1.SelectedIndex = 0;
            this.uiTabControlMenu1.Size = new System.Drawing.Size(655, 512);
            this.uiTabControlMenu1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControlMenu1.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.uiTabControlMenu1.TabIndex = 0;
            this.uiTabControlMenu1.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiTabControlMenu1.TabSelectedForeColor = System.Drawing.Color.White;
            this.uiTabControlMenu1.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControlMenu1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage11.Controls.Add(this.tbJobPattern_AcceptScore);
            this.tabPage11.Controls.Add(this.tbJobPattern_MinScore);
            this.tabPage11.Controls.Add(this.tbPatternMasterCount);
            this.tabPage11.Controls.Add(this.label137);
            this.tabPage11.Controls.Add(this.lblDetectedPatternCount);
            this.tabPage11.Controls.Add(this.btnJobPatternDelete);
            this.tabPage11.Controls.Add(this.comboJobPattern_PatternType);
            this.tabPage11.Controls.Add(this.lblTrained);
            this.tabPage11.Controls.Add(this.label100);
            this.tabPage11.Controls.Add(this.label69);
            this.tabPage11.Controls.Add(this.uiSymbolButton12);
            this.tabPage11.Controls.Add(this.label70);
            this.tabPage11.Controls.Add(this.label71);
            this.tabPage11.Controls.Add(this.btnJobPattern_Roi);
            this.tabPage11.Controls.Add(this.btnJobPattern_Train);
            this.tabPage11.Controls.Add(this.btnJobPattern_Find);
            this.tabPage11.Controls.Add(this.label110);
            this.tabPage11.Controls.Add(this.panel14);
            this.tabPage11.Location = new System.Drawing.Point(91, 0);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(564, 512);
            this.tabPage11.TabIndex = 0;
            this.tabPage11.Text = "Pattern";
            // 
            // tbJobPattern_AcceptScore
            // 
            this.tbJobPattern_AcceptScore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbJobPattern_AcceptScore.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbJobPattern_AcceptScore.Font = new System.Drawing.Font("Arial", 9F);
            this.tbJobPattern_AcceptScore.ForeColor = System.Drawing.Color.DimGray;
            this.tbJobPattern_AcceptScore.Location = new System.Drawing.Point(164, 311);
            this.tbJobPattern_AcceptScore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbJobPattern_AcceptScore.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbJobPattern_AcceptScore.Name = "tbJobPattern_AcceptScore";
            this.tbJobPattern_AcceptScore.Padding = new System.Windows.Forms.Padding(5);
            this.tbJobPattern_AcceptScore.RectColor = System.Drawing.Color.White;
            this.tbJobPattern_AcceptScore.ShowText = false;
            this.tbJobPattern_AcceptScore.Size = new System.Drawing.Size(110, 30);
            this.tbJobPattern_AcceptScore.Style = Sunny.UI.UIStyle.Custom;
            this.tbJobPattern_AcceptScore.TabIndex = 3555;
            this.tbJobPattern_AcceptScore.Text = "( 0.0 ~ 1.0 )";
            this.tbJobPattern_AcceptScore.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbJobPattern_AcceptScore.Watermark = "";
            // 
            // tbJobPattern_MinScore
            // 
            this.tbJobPattern_MinScore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbJobPattern_MinScore.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbJobPattern_MinScore.Font = new System.Drawing.Font("Arial", 9F);
            this.tbJobPattern_MinScore.ForeColor = System.Drawing.Color.DimGray;
            this.tbJobPattern_MinScore.Location = new System.Drawing.Point(164, 275);
            this.tbJobPattern_MinScore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbJobPattern_MinScore.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbJobPattern_MinScore.Name = "tbJobPattern_MinScore";
            this.tbJobPattern_MinScore.Padding = new System.Windows.Forms.Padding(5);
            this.tbJobPattern_MinScore.RectColor = System.Drawing.Color.White;
            this.tbJobPattern_MinScore.ShowText = false;
            this.tbJobPattern_MinScore.Size = new System.Drawing.Size(110, 30);
            this.tbJobPattern_MinScore.Style = Sunny.UI.UIStyle.Custom;
            this.tbJobPattern_MinScore.TabIndex = 3554;
            this.tbJobPattern_MinScore.Text = "( 0.0 ~ 1.0 )";
            this.tbJobPattern_MinScore.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbJobPattern_MinScore.Watermark = "";
            // 
            // tbPatternMasterCount
            // 
            this.tbPatternMasterCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPatternMasterCount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbPatternMasterCount.Font = new System.Drawing.Font("Arial", 9F);
            this.tbPatternMasterCount.ForeColor = System.Drawing.Color.DimGray;
            this.tbPatternMasterCount.Location = new System.Drawing.Point(164, 239);
            this.tbPatternMasterCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPatternMasterCount.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbPatternMasterCount.Name = "tbPatternMasterCount";
            this.tbPatternMasterCount.Padding = new System.Windows.Forms.Padding(5);
            this.tbPatternMasterCount.RectColor = System.Drawing.Color.White;
            this.tbPatternMasterCount.ShowText = false;
            this.tbPatternMasterCount.Size = new System.Drawing.Size(110, 30);
            this.tbPatternMasterCount.Style = Sunny.UI.UIStyle.Custom;
            this.tbPatternMasterCount.TabIndex = 3553;
            this.tbPatternMasterCount.Text = "( 0.0 ~ 1.0 )";
            this.tbPatternMasterCount.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbPatternMasterCount.Watermark = "";
            // 
            // label137
            // 
            this.label137.BackColor = System.Drawing.Color.Transparent;
            this.label137.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label137.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label137.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label137.ForeColor = System.Drawing.Color.Yellow;
            this.label137.Location = new System.Drawing.Point(26, 203);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(56, 29);
            this.label137.TabIndex = 3552;
            this.label137.Text = "(00/05)";
            this.label137.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetectedPatternCount
            // 
            this.lblDetectedPatternCount.BackColor = System.Drawing.Color.Transparent;
            this.lblDetectedPatternCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetectedPatternCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDetectedPatternCount.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDetectedPatternCount.ForeColor = System.Drawing.Color.White;
            this.lblDetectedPatternCount.Location = new System.Drawing.Point(2, 315);
            this.lblDetectedPatternCount.Name = "lblDetectedPatternCount";
            this.lblDetectedPatternCount.Size = new System.Drawing.Size(80, 26);
            this.lblDetectedPatternCount.TabIndex = 3551;
            this.lblDetectedPatternCount.Text = "Count : 0";
            this.lblDetectedPatternCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobPatternDelete
            // 
            this.btnJobPatternDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPatternDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPatternDelete.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPatternDelete.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPatternDelete.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPatternDelete.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPatternDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPatternDelete.Location = new System.Drawing.Point(212, 202);
            this.btnJobPatternDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPatternDelete.Name = "btnJobPatternDelete";
            this.btnJobPatternDelete.RectColor = System.Drawing.Color.White;
            this.btnJobPatternDelete.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPatternDelete.RectPressColor = System.Drawing.Color.White;
            this.btnJobPatternDelete.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPatternDelete.Size = new System.Drawing.Size(91, 30);
            this.btnJobPatternDelete.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPatternDelete.StyleCustomMode = true;
            this.btnJobPatternDelete.Symbol = 61544;
            this.btnJobPatternDelete.SymbolOffset = new System.Drawing.Point(-5, 2);
            this.btnJobPatternDelete.SymbolSize = 10;
            this.btnJobPatternDelete.TabIndex = 3550;
            this.btnJobPatternDelete.Text = "Delete";
            this.btnJobPatternDelete.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // comboJobPattern_PatternType
            // 
            this.comboJobPattern_PatternType.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
            this.comboJobPattern_PatternType.ForeColor = System.Drawing.Color.White;
            this.comboJobPattern_PatternType.FormattingEnabled = true;
            this.comboJobPattern_PatternType.ItemHeight = 23;
            this.comboJobPattern_PatternType.Items.AddRange(new object[] {
            "Main",
            "Sub1",
            "Sub2",
            "Sub3",
            "Sub4"});
            this.comboJobPattern_PatternType.Location = new System.Drawing.Point(83, 203);
            this.comboJobPattern_PatternType.Name = "comboJobPattern_PatternType";
            this.comboJobPattern_PatternType.Size = new System.Drawing.Size(127, 29);
            this.comboJobPattern_PatternType.Style = MetroFramework.MetroColorStyle.Orange;
            this.comboJobPattern_PatternType.TabIndex = 3540;
            this.comboJobPattern_PatternType.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboJobPattern_PatternType.UseCustomForeColor = true;
            this.comboJobPattern_PatternType.UseSelectable = true;
            // 
            // lblTrained
            // 
            this.lblTrained.BackColor = System.Drawing.Color.Transparent;
            this.lblTrained.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrained.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTrained.Font = new System.Drawing.Font("Arial", 8F);
            this.lblTrained.ForeColor = System.Drawing.Color.White;
            this.lblTrained.Location = new System.Drawing.Point(2, 203);
            this.lblTrained.Name = "lblTrained";
            this.lblTrained.Size = new System.Drawing.Size(23, 29);
            this.lblTrained.TabIndex = 3549;
            this.lblTrained.Text = "No";
            this.lblTrained.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label100
            // 
            this.label100.BackColor = System.Drawing.Color.Transparent;
            this.label100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label100.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.ForeColor = System.Drawing.Color.White;
            this.label100.Location = new System.Drawing.Point(83, 233);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(80, 36);
            this.label100.TabIndex = 3548;
            this.label100.Text = "Master Count";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Transparent;
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label69.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label69.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.White;
            this.label69.Location = new System.Drawing.Point(2, 233);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(80, 81);
            this.label69.TabIndex = 3547;
            this.label69.Text = "Parameter";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiSymbolButton12
            // 
            this.uiSymbolButton12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton12.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton12.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton12.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton12.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton12.Location = new System.Drawing.Point(212, 116);
            this.uiSymbolButton12.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton12.Name = "uiSymbolButton12";
            this.uiSymbolButton12.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton12.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton12.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton12.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton12.Size = new System.Drawing.Size(91, 42);
            this.uiSymbolButton12.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton12.StyleCustomMode = true;
            this.uiSymbolButton12.Symbol = 361508;
            this.uiSymbolButton12.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton12.SymbolSize = 20;
            this.uiSymbolButton12.TabIndex = 3546;
            this.uiSymbolButton12.Text = "Mask";
            this.uiSymbolButton12.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.Transparent;
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label70.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.White;
            this.label70.Location = new System.Drawing.Point(83, 306);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(80, 35);
            this.label70.TabIndex = 3545;
            this.label70.Text = "Detect Minimum";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label71.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label71.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.White;
            this.label71.Location = new System.Drawing.Point(83, 270);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(80, 35);
            this.label71.TabIndex = 3544;
            this.label71.Text = "Score (OK) Minimum";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobPattern_Roi
            // 
            this.btnJobPattern_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPattern_Roi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPattern_Roi.Location = new System.Drawing.Point(212, 30);
            this.btnJobPattern_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPattern_Roi.Name = "btnJobPattern_Roi";
            this.btnJobPattern_Roi.RectColor = System.Drawing.Color.White;
            this.btnJobPattern_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobPattern_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPattern_Roi.Size = new System.Drawing.Size(91, 42);
            this.btnJobPattern_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPattern_Roi.StyleCustomMode = true;
            this.btnJobPattern_Roi.Symbol = 362923;
            this.btnJobPattern_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPattern_Roi.SymbolSize = 20;
            this.btnJobPattern_Roi.TabIndex = 3541;
            this.btnJobPattern_Roi.Text = "Roi";
            this.btnJobPattern_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobPattern_Roi.Click += new System.EventHandler(this.btnJobPattern_Roi_Click);
            // 
            // btnJobPattern_Train
            // 
            this.btnJobPattern_Train.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPattern_Train.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Train.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Train.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Train.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Train.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Train.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPattern_Train.Location = new System.Drawing.Point(212, 73);
            this.btnJobPattern_Train.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPattern_Train.Name = "btnJobPattern_Train";
            this.btnJobPattern_Train.RectColor = System.Drawing.Color.White;
            this.btnJobPattern_Train.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Train.RectPressColor = System.Drawing.Color.White;
            this.btnJobPattern_Train.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPattern_Train.Size = new System.Drawing.Size(91, 42);
            this.btnJobPattern_Train.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPattern_Train.StyleCustomMode = true;
            this.btnJobPattern_Train.Symbol = 108;
            this.btnJobPattern_Train.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPattern_Train.SymbolSize = 20;
            this.btnJobPattern_Train.TabIndex = 3542;
            this.btnJobPattern_Train.Text = "Train";
            this.btnJobPattern_Train.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnJobPattern_Find
            // 
            this.btnJobPattern_Find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPattern_Find.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Find.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Find.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Find.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Find.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Find.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPattern_Find.Location = new System.Drawing.Point(212, 159);
            this.btnJobPattern_Find.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPattern_Find.Name = "btnJobPattern_Find";
            this.btnJobPattern_Find.RectColor = System.Drawing.Color.White;
            this.btnJobPattern_Find.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Find.RectPressColor = System.Drawing.Color.White;
            this.btnJobPattern_Find.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPattern_Find.Size = new System.Drawing.Size(91, 42);
            this.btnJobPattern_Find.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPattern_Find.StyleCustomMode = true;
            this.btnJobPattern_Find.Symbol = 61442;
            this.btnJobPattern_Find.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPattern_Find.SymbolSize = 20;
            this.btnJobPattern_Find.TabIndex = 3543;
            this.btnJobPattern_Find.Text = "Find";
            this.btnJobPattern_Find.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label110
            // 
            this.label110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label110.Dock = System.Windows.Forms.DockStyle.Top;
            this.label110.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label110.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label110.ForeColor = System.Drawing.Color.White;
            this.label110.Location = new System.Drawing.Point(0, 0);
            this.label110.Name = "label110";
            this.label110.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label110.Size = new System.Drawing.Size(564, 27);
            this.label110.TabIndex = 3428;
            this.label110.Text = "ex) Matching, Reverce, IC Leads ...";
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.cogDisplay_JobPattern);
            this.panel14.Controls.Add(this.label65);
            this.panel14.Location = new System.Drawing.Point(2, 30);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(208, 171);
            this.panel14.TabIndex = 3405;
            // 
            // cogDisplay_JobPattern
            // 
            this.cogDisplay_JobPattern.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_JobPattern.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_JobPattern.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_JobPattern.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_JobPattern.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_JobPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay_JobPattern.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_JobPattern.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_JobPattern.Location = new System.Drawing.Point(0, 25);
            this.cogDisplay_JobPattern.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay_JobPattern.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_JobPattern.MouseWheelSensitivity = 1D;
            this.cogDisplay_JobPattern.Name = "cogDisplay_JobPattern";
            this.cogDisplay_JobPattern.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_JobPattern.OcxState")));
            this.cogDisplay_JobPattern.Size = new System.Drawing.Size(208, 146);
            this.cogDisplay_JobPattern.TabIndex = 3301;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(77)))), ((int)(((byte)(86)))));
            this.label65.Dock = System.Windows.Forms.DockStyle.Top;
            this.label65.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label65.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label65.ForeColor = System.Drawing.Color.White;
            this.label65.Location = new System.Drawing.Point(0, 0);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(208, 25);
            this.label65.TabIndex = 3300;
            this.label65.Text = "Pattern";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage18
            // 
            this.tabPage18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage18.Controls.Add(this.txt_PinMatchingScoreMin);
            this.tabPage18.Controls.Add(this.txtBlobThreshold);
            this.tabPage18.Controls.Add(this.tbAreaMax);
            this.tabPage18.Controls.Add(this.tbAreaMin);
            this.tabPage18.Controls.Add(this.btnGetBlobPos);
            this.tabPage18.Controls.Add(this.btnJobBlob_Roi);
            this.tabPage18.Controls.Add(this.CogDisplay_FinMatchingTemplateImg);
            this.tabPage18.Controls.Add(this.uiSymbolButton29);
            this.tabPage18.Controls.Add(this.label83);
            this.tabPage18.Controls.Add(this.label82);
            this.tabPage18.Controls.Add(this.label72);
            this.tabPage18.Controls.Add(this.label73);
            this.tabPage18.Controls.Add(this.label86);
            this.tabPage18.Controls.Add(this.uiSymbolButton32);
            this.tabPage18.Controls.Add(this.label88);
            this.tabPage18.Controls.Add(this.panel15);
            this.tabPage18.Controls.Add(this.uiSymbolButton33);
            this.tabPage18.Controls.Add(this.uiSymbolButton64);
            this.tabPage18.Controls.Add(this.uiSymbolButton65);
            this.tabPage18.Controls.Add(this.btnJobBlobInsp);
            this.tabPage18.Location = new System.Drawing.Point(91, 0);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Size = new System.Drawing.Size(564, 512);
            this.tabPage18.TabIndex = 1;
            this.tabPage18.Text = "Blob";
            // 
            // txt_PinMatchingScoreMin
            // 
            this.txt_PinMatchingScoreMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PinMatchingScoreMin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txt_PinMatchingScoreMin.Font = new System.Drawing.Font("Arial", 9F);
            this.txt_PinMatchingScoreMin.ForeColor = System.Drawing.Color.DimGray;
            this.txt_PinMatchingScoreMin.Location = new System.Drawing.Point(162, 206);
            this.txt_PinMatchingScoreMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PinMatchingScoreMin.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_PinMatchingScoreMin.Name = "txt_PinMatchingScoreMin";
            this.txt_PinMatchingScoreMin.Padding = new System.Windows.Forms.Padding(5);
            this.txt_PinMatchingScoreMin.RectColor = System.Drawing.Color.White;
            this.txt_PinMatchingScoreMin.ShowText = false;
            this.txt_PinMatchingScoreMin.Size = new System.Drawing.Size(140, 30);
            this.txt_PinMatchingScoreMin.Style = Sunny.UI.UIStyle.Custom;
            this.txt_PinMatchingScoreMin.TabIndex = 3560;
            this.txt_PinMatchingScoreMin.Text = "( 0.0 ~ 1.0 )";
            this.txt_PinMatchingScoreMin.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txt_PinMatchingScoreMin.Watermark = "";
            // 
            // txtBlobThreshold
            // 
            this.txtBlobThreshold.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBlobThreshold.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtBlobThreshold.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBlobThreshold.ForeColor = System.Drawing.Color.DimGray;
            this.txtBlobThreshold.Location = new System.Drawing.Point(79, 341);
            this.txtBlobThreshold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBlobThreshold.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtBlobThreshold.Name = "txtBlobThreshold";
            this.txtBlobThreshold.Padding = new System.Windows.Forms.Padding(5);
            this.txtBlobThreshold.RectColor = System.Drawing.Color.White;
            this.txtBlobThreshold.ShowText = false;
            this.txtBlobThreshold.Size = new System.Drawing.Size(220, 30);
            this.txtBlobThreshold.Style = Sunny.UI.UIStyle.Custom;
            this.txtBlobThreshold.TabIndex = 3559;
            this.txtBlobThreshold.Text = "( 1 ~ 255 )";
            this.txtBlobThreshold.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtBlobThreshold.Watermark = "";
            // 
            // tbAreaMax
            // 
            this.tbAreaMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAreaMax.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbAreaMax.Font = new System.Drawing.Font("Arial", 9F);
            this.tbAreaMax.ForeColor = System.Drawing.Color.DimGray;
            this.tbAreaMax.Location = new System.Drawing.Point(79, 305);
            this.tbAreaMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAreaMax.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbAreaMax.Name = "tbAreaMax";
            this.tbAreaMax.Padding = new System.Windows.Forms.Padding(5);
            this.tbAreaMax.RectColor = System.Drawing.Color.White;
            this.tbAreaMax.ShowText = false;
            this.tbAreaMax.Size = new System.Drawing.Size(220, 30);
            this.tbAreaMax.Style = Sunny.UI.UIStyle.Custom;
            this.tbAreaMax.TabIndex = 3558;
            this.tbAreaMax.Text = "( 10 ~ 20000 )";
            this.tbAreaMax.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbAreaMax.Watermark = "";
            // 
            // tbAreaMin
            // 
            this.tbAreaMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAreaMin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbAreaMin.Font = new System.Drawing.Font("Arial", 9F);
            this.tbAreaMin.ForeColor = System.Drawing.Color.DimGray;
            this.tbAreaMin.Location = new System.Drawing.Point(78, 269);
            this.tbAreaMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAreaMin.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbAreaMin.Name = "tbAreaMin";
            this.tbAreaMin.Padding = new System.Windows.Forms.Padding(5);
            this.tbAreaMin.RectColor = System.Drawing.Color.White;
            this.tbAreaMin.ShowText = false;
            this.tbAreaMin.Size = new System.Drawing.Size(220, 30);
            this.tbAreaMin.Style = Sunny.UI.UIStyle.Custom;
            this.tbAreaMin.TabIndex = 3557;
            this.tbAreaMin.Text = "( 10 ~ 200 )";
            this.tbAreaMin.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbAreaMin.Watermark = "";
            // 
            // btnGetBlobPos
            // 
            this.btnGetBlobPos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGetBlobPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetBlobPos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetBlobPos.ForeColor = System.Drawing.Color.White;
            this.btnGetBlobPos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetBlobPos.Location = new System.Drawing.Point(3, 378);
            this.btnGetBlobPos.Name = "btnGetBlobPos";
            this.btnGetBlobPos.Size = new System.Drawing.Size(75, 42);
            this.btnGetBlobPos.TabIndex = 3556;
            this.btnGetBlobPos.Text = "GetPos";
            this.btnGetBlobPos.UseVisualStyleBackColor = true;
            // 
            // btnJobBlob_Roi
            // 
            this.btnJobBlob_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobBlob_Roi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobBlob_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobBlob_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobBlob_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobBlob_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobBlob_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobBlob_Roi.Location = new System.Drawing.Point(80, 378);
            this.btnJobBlob_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobBlob_Roi.Name = "btnJobBlob_Roi";
            this.btnJobBlob_Roi.RectColor = System.Drawing.Color.White;
            this.btnJobBlob_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobBlob_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobBlob_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobBlob_Roi.Size = new System.Drawing.Size(70, 42);
            this.btnJobBlob_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobBlob_Roi.StyleCustomMode = true;
            this.btnJobBlob_Roi.Symbol = 362923;
            this.btnJobBlob_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobBlob_Roi.SymbolSize = 16;
            this.btnJobBlob_Roi.TabIndex = 3555;
            this.btnJobBlob_Roi.Text = "Roi";
            this.btnJobBlob_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // CogDisplay_FinMatchingTemplateImg
            // 
            this.CogDisplay_FinMatchingTemplateImg.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.CogDisplay_FinMatchingTemplateImg.ColorMapLowerRoiLimit = 0D;
            this.CogDisplay_FinMatchingTemplateImg.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.CogDisplay_FinMatchingTemplateImg.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.CogDisplay_FinMatchingTemplateImg.ColorMapUpperRoiLimit = 1D;
            this.CogDisplay_FinMatchingTemplateImg.DoubleTapZoomCycleLength = 2;
            this.CogDisplay_FinMatchingTemplateImg.DoubleTapZoomSensitivity = 2.5D;
            this.CogDisplay_FinMatchingTemplateImg.Location = new System.Drawing.Point(2, 55);
            this.CogDisplay_FinMatchingTemplateImg.Margin = new System.Windows.Forms.Padding(4);
            this.CogDisplay_FinMatchingTemplateImg.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CogDisplay_FinMatchingTemplateImg.MouseWheelSensitivity = 1D;
            this.CogDisplay_FinMatchingTemplateImg.Name = "CogDisplay_FinMatchingTemplateImg";
            this.CogDisplay_FinMatchingTemplateImg.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CogDisplay_FinMatchingTemplateImg.OcxState")));
            this.CogDisplay_FinMatchingTemplateImg.Size = new System.Drawing.Size(208, 146);
            this.CogDisplay_FinMatchingTemplateImg.TabIndex = 3541;
            // 
            // uiSymbolButton29
            // 
            this.uiSymbolButton29.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton29.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton29.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton29.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton29.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton29.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton29.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton29.Location = new System.Drawing.Point(152, 378);
            this.uiSymbolButton29.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton29.Name = "uiSymbolButton29";
            this.uiSymbolButton29.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton29.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton29.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton29.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton29.Size = new System.Drawing.Size(71, 42);
            this.uiSymbolButton29.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton29.StyleCustomMode = true;
            this.uiSymbolButton29.Symbol = 61442;
            this.uiSymbolButton29.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton29.SymbolSize = 20;
            this.uiSymbolButton29.TabIndex = 3554;
            this.uiSymbolButton29.Text = "Find";
            this.uiSymbolButton29.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label83.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label83.Font = new System.Drawing.Font("Arial", 8F);
            this.label83.ForeColor = System.Drawing.Color.White;
            this.label83.Location = new System.Drawing.Point(0, 337);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(80, 35);
            this.label83.TabIndex = 3553;
            this.label83.Text = "Threshold";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label82.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label82.Font = new System.Drawing.Font("Arial", 8F);
            this.label82.ForeColor = System.Drawing.Color.White;
            this.label82.Location = new System.Drawing.Point(0, 301);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(80, 35);
            this.label82.TabIndex = 3552;
            this.label82.Text = "Area (Max)";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.Transparent;
            this.label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label72.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label72.Font = new System.Drawing.Font("Arial", 8F);
            this.label72.ForeColor = System.Drawing.Color.White;
            this.label72.Location = new System.Drawing.Point(-1, 265);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(80, 35);
            this.label72.TabIndex = 3551;
            this.label72.Text = "Area (Min)";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label73.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label73.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.White;
            this.label73.Location = new System.Drawing.Point(-2, 237);
            this.label73.Name = "label73";
            this.label73.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label73.Size = new System.Drawing.Size(307, 27);
            this.label73.TabIndex = 3550;
            this.label73.Text = "ex) Blob";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label86
            // 
            this.label86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label86.Dock = System.Windows.Forms.DockStyle.Top;
            this.label86.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label86.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.Color.White;
            this.label86.Location = new System.Drawing.Point(0, 0);
            this.label86.Name = "label86";
            this.label86.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label86.Size = new System.Drawing.Size(564, 27);
            this.label86.TabIndex = 3549;
            this.label86.Text = "ex) 12 Pin";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton32
            // 
            this.uiSymbolButton32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton32.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton32.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton32.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton32.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton32.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton32.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton32.Location = new System.Drawing.Point(212, 116);
            this.uiSymbolButton32.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton32.Name = "uiSymbolButton32";
            this.uiSymbolButton32.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton32.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton32.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton32.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton32.Size = new System.Drawing.Size(91, 42);
            this.uiSymbolButton32.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton32.StyleCustomMode = true;
            this.uiSymbolButton32.Symbol = 361508;
            this.uiSymbolButton32.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton32.SymbolSize = 20;
            this.uiSymbolButton32.TabIndex = 3548;
            this.uiSymbolButton32.Text = "Mask";
            this.uiSymbolButton32.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.Color.Transparent;
            this.label88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label88.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label88.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.Color.White;
            this.label88.Location = new System.Drawing.Point(0, 201);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(161, 35);
            this.label88.TabIndex = 3547;
            this.label88.Text = "Score (OK) Minimum";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label118);
            this.panel15.Location = new System.Drawing.Point(2, 30);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(208, 171);
            this.panel15.TabIndex = 3543;
            // 
            // label118
            // 
            this.label118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(77)))), ((int)(((byte)(86)))));
            this.label118.Dock = System.Windows.Forms.DockStyle.Top;
            this.label118.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label118.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label118.ForeColor = System.Drawing.Color.White;
            this.label118.Location = new System.Drawing.Point(0, 0);
            this.label118.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(208, 25);
            this.label118.TabIndex = 3300;
            this.label118.Text = "Pattern";
            this.label118.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiSymbolButton33
            // 
            this.uiSymbolButton33.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton33.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton33.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton33.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton33.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton33.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton33.Location = new System.Drawing.Point(212, 30);
            this.uiSymbolButton33.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton33.Name = "uiSymbolButton33";
            this.uiSymbolButton33.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton33.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton33.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton33.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton33.Size = new System.Drawing.Size(91, 42);
            this.uiSymbolButton33.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton33.StyleCustomMode = true;
            this.uiSymbolButton33.Symbol = 362923;
            this.uiSymbolButton33.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton33.SymbolSize = 20;
            this.uiSymbolButton33.TabIndex = 3544;
            this.uiSymbolButton33.Text = "Roi";
            this.uiSymbolButton33.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton64
            // 
            this.uiSymbolButton64.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton64.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton64.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton64.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton64.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton64.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton64.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton64.Location = new System.Drawing.Point(212, 73);
            this.uiSymbolButton64.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton64.Name = "uiSymbolButton64";
            this.uiSymbolButton64.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton64.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton64.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton64.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton64.Size = new System.Drawing.Size(91, 42);
            this.uiSymbolButton64.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton64.StyleCustomMode = true;
            this.uiSymbolButton64.Symbol = 108;
            this.uiSymbolButton64.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton64.SymbolSize = 20;
            this.uiSymbolButton64.TabIndex = 3545;
            this.uiSymbolButton64.Text = "Train";
            this.uiSymbolButton64.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton65
            // 
            this.uiSymbolButton65.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton65.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton65.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton65.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton65.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton65.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton65.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton65.Location = new System.Drawing.Point(212, 159);
            this.uiSymbolButton65.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton65.Name = "uiSymbolButton65";
            this.uiSymbolButton65.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton65.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton65.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton65.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton65.Size = new System.Drawing.Size(91, 42);
            this.uiSymbolButton65.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton65.StyleCustomMode = true;
            this.uiSymbolButton65.Symbol = 61442;
            this.uiSymbolButton65.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton65.SymbolSize = 20;
            this.uiSymbolButton65.TabIndex = 3546;
            this.uiSymbolButton65.Text = "Find";
            this.uiSymbolButton65.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnJobBlobInsp
            // 
            this.btnJobBlobInsp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnJobBlobInsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobBlobInsp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobBlobInsp.ForeColor = System.Drawing.Color.White;
            this.btnJobBlobInsp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobBlobInsp.Location = new System.Drawing.Point(227, 378);
            this.btnJobBlobInsp.Name = "btnJobBlobInsp";
            this.btnJobBlobInsp.Size = new System.Drawing.Size(75, 42);
            this.btnJobBlobInsp.TabIndex = 3542;
            this.btnJobBlobInsp.Text = "Insp";
            this.btnJobBlobInsp.UseVisualStyleBackColor = true;
            // 
            // tabPage19
            // 
            this.tabPage19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage19.Controls.Add(this.tbYMaxValue);
            this.tabPage19.Controls.Add(this.tbYMinValue);
            this.tabPage19.Controls.Add(this.tbXMaxValue);
            this.tabPage19.Controls.Add(this.tbXMinValue);
            this.tabPage19.Controls.Add(this.tbAngleMaxValue);
            this.tabPage19.Controls.Add(this.tbAngleMinValue);
            this.tabPage19.Controls.Add(this.tbLineEdgeContrast);
            this.tabPage19.Controls.Add(this.btnDistanceDetail);
            this.tabPage19.Controls.Add(this.numericDistanceSamplingCount);
            this.tabPage19.Controls.Add(this.numericDistanceThickness);
            this.tabPage19.Controls.Add(this.label74);
            this.tabPage19.Controls.Add(this.label75);
            this.tabPage19.Controls.Add(this.cbYValue);
            this.tabPage19.Controls.Add(this.cbXValue);
            this.tabPage19.Controls.Add(this.cbAngle);
            this.tabPage19.Controls.Add(this.label117);
            this.tabPage19.Controls.Add(this.label111);
            this.tabPage19.Controls.Add(this.label112);
            this.tabPage19.Controls.Add(this.label113);
            this.tabPage19.Controls.Add(this.label106);
            this.tabPage19.Controls.Add(this.label107);
            this.tabPage19.Controls.Add(this.label109);
            this.tabPage19.Controls.Add(this.label77);
            this.tabPage19.Controls.Add(this.label78);
            this.tabPage19.Controls.Add(this.label79);
            this.tabPage19.Controls.Add(this.btnJobDistanceInsp);
            this.tabPage19.Controls.Add(this.btnJobDistance_Roi);
            this.tabPage19.Controls.Add(this.uiSymbolButton66);
            this.tabPage19.Controls.Add(this.comboLineEdgePolarity);
            this.tabPage19.Controls.Add(this.label80);
            this.tabPage19.Controls.Add(this.comboLineEdgeScorer);
            this.tabPage19.Controls.Add(this.label81);
            this.tabPage19.Controls.Add(this.label84);
            this.tabPage19.Location = new System.Drawing.Point(91, 0);
            this.tabPage19.Name = "tabPage19";
            this.tabPage19.Size = new System.Drawing.Size(564, 512);
            this.tabPage19.TabIndex = 2;
            this.tabPage19.Text = "Distance";
            // 
            // tbYMaxValue
            // 
            this.tbYMaxValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbYMaxValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbYMaxValue.Font = new System.Drawing.Font("Arial", 9F);
            this.tbYMaxValue.ForeColor = System.Drawing.Color.DimGray;
            this.tbYMaxValue.Location = new System.Drawing.Point(120, 345);
            this.tbYMaxValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbYMaxValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbYMaxValue.Name = "tbYMaxValue";
            this.tbYMaxValue.Padding = new System.Windows.Forms.Padding(5);
            this.tbYMaxValue.RectColor = System.Drawing.Color.White;
            this.tbYMaxValue.ShowText = false;
            this.tbYMaxValue.Size = new System.Drawing.Size(184, 30);
            this.tbYMaxValue.Style = Sunny.UI.UIStyle.Custom;
            this.tbYMaxValue.TabIndex = 3579;
            this.tbYMaxValue.Text = "-";
            this.tbYMaxValue.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbYMaxValue.Watermark = "";
            // 
            // tbYMinValue
            // 
            this.tbYMinValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbYMinValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbYMinValue.Font = new System.Drawing.Font("Arial", 9F);
            this.tbYMinValue.ForeColor = System.Drawing.Color.DimGray;
            this.tbYMinValue.Location = new System.Drawing.Point(120, 314);
            this.tbYMinValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbYMinValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbYMinValue.Name = "tbYMinValue";
            this.tbYMinValue.Padding = new System.Windows.Forms.Padding(5);
            this.tbYMinValue.RectColor = System.Drawing.Color.White;
            this.tbYMinValue.ShowText = false;
            this.tbYMinValue.Size = new System.Drawing.Size(184, 30);
            this.tbYMinValue.Style = Sunny.UI.UIStyle.Custom;
            this.tbYMinValue.TabIndex = 3578;
            this.tbYMinValue.Text = "-";
            this.tbYMinValue.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbYMinValue.Watermark = "";
            // 
            // tbXMaxValue
            // 
            this.tbXMaxValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbXMaxValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbXMaxValue.Font = new System.Drawing.Font("Arial", 9F);
            this.tbXMaxValue.ForeColor = System.Drawing.Color.DimGray;
            this.tbXMaxValue.Location = new System.Drawing.Point(120, 283);
            this.tbXMaxValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbXMaxValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbXMaxValue.Name = "tbXMaxValue";
            this.tbXMaxValue.Padding = new System.Windows.Forms.Padding(5);
            this.tbXMaxValue.RectColor = System.Drawing.Color.White;
            this.tbXMaxValue.ShowText = false;
            this.tbXMaxValue.Size = new System.Drawing.Size(184, 30);
            this.tbXMaxValue.Style = Sunny.UI.UIStyle.Custom;
            this.tbXMaxValue.TabIndex = 3577;
            this.tbXMaxValue.Text = "-";
            this.tbXMaxValue.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbXMaxValue.Watermark = "";
            // 
            // tbXMinValue
            // 
            this.tbXMinValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbXMinValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbXMinValue.Font = new System.Drawing.Font("Arial", 9F);
            this.tbXMinValue.ForeColor = System.Drawing.Color.DimGray;
            this.tbXMinValue.Location = new System.Drawing.Point(120, 252);
            this.tbXMinValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbXMinValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbXMinValue.Name = "tbXMinValue";
            this.tbXMinValue.Padding = new System.Windows.Forms.Padding(5);
            this.tbXMinValue.RectColor = System.Drawing.Color.White;
            this.tbXMinValue.ShowText = false;
            this.tbXMinValue.Size = new System.Drawing.Size(184, 30);
            this.tbXMinValue.Style = Sunny.UI.UIStyle.Custom;
            this.tbXMinValue.TabIndex = 3576;
            this.tbXMinValue.Text = "-";
            this.tbXMinValue.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbXMinValue.Watermark = "";
            // 
            // tbAngleMaxValue
            // 
            this.tbAngleMaxValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAngleMaxValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbAngleMaxValue.Font = new System.Drawing.Font("Arial", 9F);
            this.tbAngleMaxValue.ForeColor = System.Drawing.Color.DimGray;
            this.tbAngleMaxValue.Location = new System.Drawing.Point(120, 221);
            this.tbAngleMaxValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAngleMaxValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbAngleMaxValue.Name = "tbAngleMaxValue";
            this.tbAngleMaxValue.Padding = new System.Windows.Forms.Padding(5);
            this.tbAngleMaxValue.RectColor = System.Drawing.Color.White;
            this.tbAngleMaxValue.ShowText = false;
            this.tbAngleMaxValue.Size = new System.Drawing.Size(184, 30);
            this.tbAngleMaxValue.Style = Sunny.UI.UIStyle.Custom;
            this.tbAngleMaxValue.TabIndex = 3575;
            this.tbAngleMaxValue.Text = "-";
            this.tbAngleMaxValue.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbAngleMaxValue.Watermark = "";
            // 
            // tbAngleMinValue
            // 
            this.tbAngleMinValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAngleMinValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbAngleMinValue.Font = new System.Drawing.Font("Arial", 9F);
            this.tbAngleMinValue.ForeColor = System.Drawing.Color.DimGray;
            this.tbAngleMinValue.Location = new System.Drawing.Point(120, 190);
            this.tbAngleMinValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAngleMinValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbAngleMinValue.Name = "tbAngleMinValue";
            this.tbAngleMinValue.Padding = new System.Windows.Forms.Padding(5);
            this.tbAngleMinValue.RectColor = System.Drawing.Color.White;
            this.tbAngleMinValue.ShowText = false;
            this.tbAngleMinValue.Size = new System.Drawing.Size(184, 30);
            this.tbAngleMinValue.Style = Sunny.UI.UIStyle.Custom;
            this.tbAngleMinValue.TabIndex = 3574;
            this.tbAngleMinValue.Text = "-";
            this.tbAngleMinValue.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbAngleMinValue.Watermark = "";
            // 
            // tbLineEdgeContrast
            // 
            this.tbLineEdgeContrast.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbLineEdgeContrast.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbLineEdgeContrast.Font = new System.Drawing.Font("Arial", 9F);
            this.tbLineEdgeContrast.ForeColor = System.Drawing.Color.DimGray;
            this.tbLineEdgeContrast.Location = new System.Drawing.Point(120, 98);
            this.tbLineEdgeContrast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLineEdgeContrast.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbLineEdgeContrast.Name = "tbLineEdgeContrast";
            this.tbLineEdgeContrast.Padding = new System.Windows.Forms.Padding(5);
            this.tbLineEdgeContrast.RectColor = System.Drawing.Color.White;
            this.tbLineEdgeContrast.ShowText = false;
            this.tbLineEdgeContrast.Size = new System.Drawing.Size(184, 30);
            this.tbLineEdgeContrast.Style = Sunny.UI.UIStyle.Custom;
            this.tbLineEdgeContrast.TabIndex = 3573;
            this.tbLineEdgeContrast.Text = "-";
            this.tbLineEdgeContrast.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbLineEdgeContrast.Watermark = "";
            // 
            // btnDistanceDetail
            // 
            this.btnDistanceDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDistanceDetail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDistanceDetail.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDistanceDetail.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnDistanceDetail.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDistanceDetail.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDistanceDetail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistanceDetail.Location = new System.Drawing.Point(15, 424);
            this.btnDistanceDetail.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDistanceDetail.Name = "btnDistanceDetail";
            this.btnDistanceDetail.RectColor = System.Drawing.Color.White;
            this.btnDistanceDetail.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnDistanceDetail.RectPressColor = System.Drawing.Color.White;
            this.btnDistanceDetail.RectSelectedColor = System.Drawing.Color.White;
            this.btnDistanceDetail.Size = new System.Drawing.Size(278, 42);
            this.btnDistanceDetail.Style = Sunny.UI.UIStyle.Custom;
            this.btnDistanceDetail.StyleCustomMode = true;
            this.btnDistanceDetail.Symbol = 61442;
            this.btnDistanceDetail.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnDistanceDetail.SymbolSize = 20;
            this.btnDistanceDetail.TabIndex = 3572;
            this.btnDistanceDetail.Text = "Detail";
            this.btnDistanceDetail.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // numericDistanceSamplingCount
            // 
            this.numericDistanceSamplingCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericDistanceSamplingCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericDistanceSamplingCount.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.numericDistanceSamplingCount.ForeColor = System.Drawing.Color.White;
            this.numericDistanceSamplingCount.Location = new System.Drawing.Point(119, 161);
            this.numericDistanceSamplingCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericDistanceSamplingCount.Name = "numericDistanceSamplingCount";
            this.numericDistanceSamplingCount.Size = new System.Drawing.Size(184, 27);
            this.numericDistanceSamplingCount.TabIndex = 3571;
            this.numericDistanceSamplingCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericDistanceSamplingCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericDistanceThickness
            // 
            this.numericDistanceThickness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericDistanceThickness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericDistanceThickness.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.numericDistanceThickness.ForeColor = System.Drawing.Color.White;
            this.numericDistanceThickness.Location = new System.Drawing.Point(120, 130);
            this.numericDistanceThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDistanceThickness.Name = "numericDistanceThickness";
            this.numericDistanceThickness.Size = new System.Drawing.Size(184, 27);
            this.numericDistanceThickness.TabIndex = 3570;
            this.numericDistanceThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericDistanceThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label74.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label74.Font = new System.Drawing.Font("Arial", 8F);
            this.label74.ForeColor = System.Drawing.Color.White;
            this.label74.Location = new System.Drawing.Point(0, 128);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(119, 30);
            this.label74.TabIndex = 3569;
            this.label74.Text = "Filter Half Size Pixels";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.Transparent;
            this.label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label75.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label75.Font = new System.Drawing.Font("Arial", 8F);
            this.label75.ForeColor = System.Drawing.Color.White;
            this.label75.Location = new System.Drawing.Point(0, 159);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(119, 30);
            this.label75.TabIndex = 3568;
            this.label75.Text = "Number of Caliper";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbYValue
            // 
            this.cbYValue.AutoSize = true;
            this.cbYValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYValue.ForeColor = System.Drawing.Color.White;
            this.cbYValue.Location = new System.Drawing.Point(3, 318);
            this.cbYValue.Name = "cbYValue";
            this.cbYValue.Size = new System.Drawing.Size(15, 14);
            this.cbYValue.TabIndex = 3567;
            this.cbYValue.UseVisualStyleBackColor = true;
            // 
            // cbXValue
            // 
            this.cbXValue.AutoSize = true;
            this.cbXValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbXValue.ForeColor = System.Drawing.Color.White;
            this.cbXValue.Location = new System.Drawing.Point(3, 256);
            this.cbXValue.Name = "cbXValue";
            this.cbXValue.Size = new System.Drawing.Size(15, 14);
            this.cbXValue.TabIndex = 3566;
            this.cbXValue.UseVisualStyleBackColor = true;
            // 
            // cbAngle
            // 
            this.cbAngle.AutoSize = true;
            this.cbAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAngle.ForeColor = System.Drawing.Color.White;
            this.cbAngle.Location = new System.Drawing.Point(3, 194);
            this.cbAngle.Name = "cbAngle";
            this.cbAngle.Size = new System.Drawing.Size(15, 14);
            this.cbAngle.TabIndex = 3565;
            this.cbAngle.UseVisualStyleBackColor = true;
            // 
            // label117
            // 
            this.label117.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label117.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label117.Dock = System.Windows.Forms.DockStyle.Top;
            this.label117.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label117.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.ForeColor = System.Drawing.Color.White;
            this.label117.Location = new System.Drawing.Point(0, 0);
            this.label117.Name = "label117";
            this.label117.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label117.Size = new System.Drawing.Size(564, 27);
            this.label117.TabIndex = 3564;
            this.label117.Text = "ex) Fiducial - Edge, Fuse Angle ...";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label111
            // 
            this.label111.BackColor = System.Drawing.Color.Transparent;
            this.label111.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label111.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label111.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.ForeColor = System.Drawing.Color.White;
            this.label111.Location = new System.Drawing.Point(67, 345);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(52, 30);
            this.label111.TabIndex = 3563;
            this.label111.Text = "Max";
            this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label112
            // 
            this.label112.BackColor = System.Drawing.Color.Transparent;
            this.label112.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label112.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label112.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label112.ForeColor = System.Drawing.Color.White;
            this.label112.Location = new System.Drawing.Point(67, 314);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(52, 30);
            this.label112.TabIndex = 3562;
            this.label112.Text = "Min";
            this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label113
            // 
            this.label113.BackColor = System.Drawing.Color.Transparent;
            this.label113.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label113.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label113.Font = new System.Drawing.Font("Arial", 8F);
            this.label113.ForeColor = System.Drawing.Color.White;
            this.label113.Location = new System.Drawing.Point(0, 314);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(66, 61);
            this.label113.TabIndex = 3561;
            this.label113.Text = "\r\nDistance\r\n(Y)";
            this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label106
            // 
            this.label106.BackColor = System.Drawing.Color.Transparent;
            this.label106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label106.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label106.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.ForeColor = System.Drawing.Color.White;
            this.label106.Location = new System.Drawing.Point(67, 283);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(52, 30);
            this.label106.TabIndex = 3560;
            this.label106.Text = "Max";
            this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label107
            // 
            this.label107.BackColor = System.Drawing.Color.Transparent;
            this.label107.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label107.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label107.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label107.ForeColor = System.Drawing.Color.White;
            this.label107.Location = new System.Drawing.Point(67, 252);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(52, 30);
            this.label107.TabIndex = 3559;
            this.label107.Text = "Min";
            this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label109
            // 
            this.label109.BackColor = System.Drawing.Color.Transparent;
            this.label109.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label109.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label109.Font = new System.Drawing.Font("Arial", 8F);
            this.label109.ForeColor = System.Drawing.Color.White;
            this.label109.Location = new System.Drawing.Point(0, 252);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(66, 61);
            this.label109.TabIndex = 3558;
            this.label109.Text = "\r\nDistance\r\n(X)";
            this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.Transparent;
            this.label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label77.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label77.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.White;
            this.label77.Location = new System.Drawing.Point(67, 221);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(52, 30);
            this.label77.TabIndex = 3557;
            this.label77.Text = "Max";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label78.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label78.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.White;
            this.label78.Location = new System.Drawing.Point(67, 190);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(52, 30);
            this.label78.TabIndex = 3556;
            this.label78.Text = "Min";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label79.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label79.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.Color.White;
            this.label79.Location = new System.Drawing.Point(0, 190);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(66, 61);
            this.label79.TabIndex = 3555;
            this.label79.Text = "Degree";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobDistanceInsp
            // 
            this.btnJobDistanceInsp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobDistanceInsp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobDistanceInsp.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobDistanceInsp.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobDistanceInsp.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobDistanceInsp.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobDistanceInsp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobDistanceInsp.Location = new System.Drawing.Point(185, 376);
            this.btnJobDistanceInsp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobDistanceInsp.Name = "btnJobDistanceInsp";
            this.btnJobDistanceInsp.RectColor = System.Drawing.Color.White;
            this.btnJobDistanceInsp.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobDistanceInsp.RectPressColor = System.Drawing.Color.White;
            this.btnJobDistanceInsp.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobDistanceInsp.Size = new System.Drawing.Size(116, 42);
            this.btnJobDistanceInsp.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobDistanceInsp.StyleCustomMode = true;
            this.btnJobDistanceInsp.Symbol = 61515;
            this.btnJobDistanceInsp.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobDistanceInsp.SymbolSize = 20;
            this.btnJobDistanceInsp.TabIndex = 3554;
            this.btnJobDistanceInsp.Text = "Inspection";
            this.btnJobDistanceInsp.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnJobDistance_Roi
            // 
            this.btnJobDistance_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobDistance_Roi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobDistance_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobDistance_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobDistance_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobDistance_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobDistance_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobDistance_Roi.Location = new System.Drawing.Point(0, 376);
            this.btnJobDistance_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobDistance_Roi.Name = "btnJobDistance_Roi";
            this.btnJobDistance_Roi.RectColor = System.Drawing.Color.White;
            this.btnJobDistance_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobDistance_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobDistance_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobDistance_Roi.Size = new System.Drawing.Size(91, 42);
            this.btnJobDistance_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobDistance_Roi.StyleCustomMode = true;
            this.btnJobDistance_Roi.Symbol = 362923;
            this.btnJobDistance_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobDistance_Roi.SymbolSize = 20;
            this.btnJobDistance_Roi.TabIndex = 3552;
            this.btnJobDistance_Roi.Text = "Roi";
            this.btnJobDistance_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton66
            // 
            this.uiSymbolButton66.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton66.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton66.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton66.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton66.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton66.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton66.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton66.Location = new System.Drawing.Point(93, 376);
            this.uiSymbolButton66.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton66.Name = "uiSymbolButton66";
            this.uiSymbolButton66.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton66.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton66.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton66.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton66.Size = new System.Drawing.Size(91, 42);
            this.uiSymbolButton66.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton66.StyleCustomMode = true;
            this.uiSymbolButton66.Symbol = 61442;
            this.uiSymbolButton66.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton66.SymbolSize = 20;
            this.uiSymbolButton66.TabIndex = 3553;
            this.uiSymbolButton66.Text = "Find";
            this.uiSymbolButton66.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // comboLineEdgePolarity
            // 
            this.comboLineEdgePolarity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboLineEdgePolarity.ForeColor = System.Drawing.Color.White;
            this.comboLineEdgePolarity.FormattingEnabled = true;
            this.comboLineEdgePolarity.ItemHeight = 23;
            this.comboLineEdgePolarity.Items.AddRange(new object[] {
            "Dark → Light",
            "Light → Dark"});
            this.comboLineEdgePolarity.Location = new System.Drawing.Point(120, 37);
            this.comboLineEdgePolarity.Name = "comboLineEdgePolarity";
            this.comboLineEdgePolarity.Size = new System.Drawing.Size(184, 29);
            this.comboLineEdgePolarity.Style = MetroFramework.MetroColorStyle.Orange;
            this.comboLineEdgePolarity.TabIndex = 3549;
            this.comboLineEdgePolarity.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboLineEdgePolarity.UseCustomBackColor = true;
            this.comboLineEdgePolarity.UseCustomForeColor = true;
            this.comboLineEdgePolarity.UseSelectable = true;
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label80.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label80.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.White;
            this.label80.Location = new System.Drawing.Point(0, 36);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(119, 30);
            this.label80.TabIndex = 3547;
            this.label80.Text = "Polarity";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboLineEdgeScorer
            // 
            this.comboLineEdgeScorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboLineEdgeScorer.ForeColor = System.Drawing.Color.White;
            this.comboLineEdgeScorer.FormattingEnabled = true;
            this.comboLineEdgeScorer.ItemHeight = 23;
            this.comboLineEdgeScorer.Items.AddRange(new object[] {
            "Contrast",
            "Position (From End)",
            "Position (From Begin)"});
            this.comboLineEdgeScorer.Location = new System.Drawing.Point(120, 68);
            this.comboLineEdgeScorer.Name = "comboLineEdgeScorer";
            this.comboLineEdgeScorer.Size = new System.Drawing.Size(184, 29);
            this.comboLineEdgeScorer.Style = MetroFramework.MetroColorStyle.Orange;
            this.comboLineEdgeScorer.TabIndex = 3551;
            this.comboLineEdgeScorer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboLineEdgeScorer.UseCustomBackColor = true;
            this.comboLineEdgeScorer.UseCustomForeColor = true;
            this.comboLineEdgeScorer.UseSelectable = true;
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label81.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label81.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.Color.White;
            this.label81.Location = new System.Drawing.Point(0, 67);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(119, 30);
            this.label81.TabIndex = 3550;
            this.label81.Text = "Order";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label84.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label84.Font = new System.Drawing.Font("Arial", 8F);
            this.label84.ForeColor = System.Drawing.Color.White;
            this.label84.Location = new System.Drawing.Point(0, 98);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(119, 30);
            this.label84.TabIndex = 3548;
            this.label84.Text = "Contrast Threshold";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage26
            // 
            this.tabPage26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage26.Controls.Add(this.panel2);
            this.tabPage26.Location = new System.Drawing.Point(91, 0);
            this.tabPage26.Name = "tabPage26";
            this.tabPage26.Size = new System.Drawing.Size(564, 512);
            this.tabPage26.TabIndex = 3;
            this.tabPage26.Text = "EYE-D";
            // 
            // tabPage27
            // 
            this.tabPage27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage27.Controls.Add(this.lbColorMaxArea);
            this.tabPage27.Controls.Add(this.lbColorMinArea);
            this.tabPage27.Controls.Add(this.label94);
            this.tabPage27.Controls.Add(this.label95);
            this.tabPage27.Controls.Add(this.label96);
            this.tabPage27.Controls.Add(this.panel43);
            this.tabPage27.Controls.Add(this.tableLayoutPanel5);
            this.tabPage27.Controls.Add(this.panel23);
            this.tabPage27.Controls.Add(this.panel19);
            this.tabPage27.Location = new System.Drawing.Point(91, 0);
            this.tabPage27.Name = "tabPage27";
            this.tabPage27.Size = new System.Drawing.Size(564, 512);
            this.tabPage27.TabIndex = 4;
            this.tabPage27.Text = "Color";
            // 
            // lbColorMaxArea
            // 
            this.lbColorMaxArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbColorMaxArea.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbColorMaxArea.Font = new System.Drawing.Font("Arial", 9F);
            this.lbColorMaxArea.ForeColor = System.Drawing.Color.DimGray;
            this.lbColorMaxArea.Location = new System.Drawing.Point(163, 319);
            this.lbColorMaxArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbColorMaxArea.MinimumSize = new System.Drawing.Size(1, 16);
            this.lbColorMaxArea.Name = "lbColorMaxArea";
            this.lbColorMaxArea.Padding = new System.Windows.Forms.Padding(5);
            this.lbColorMaxArea.RectColor = System.Drawing.Color.White;
            this.lbColorMaxArea.ShowText = false;
            this.lbColorMaxArea.Size = new System.Drawing.Size(110, 30);
            this.lbColorMaxArea.Style = Sunny.UI.UIStyle.Custom;
            this.lbColorMaxArea.TabIndex = 3552;
            this.lbColorMaxArea.Text = "( 0.0 ~ 1.0 )";
            this.lbColorMaxArea.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbColorMaxArea.Watermark = "";
            // 
            // lbColorMinArea
            // 
            this.lbColorMinArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbColorMinArea.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbColorMinArea.Font = new System.Drawing.Font("Arial", 9F);
            this.lbColorMinArea.ForeColor = System.Drawing.Color.DimGray;
            this.lbColorMinArea.Location = new System.Drawing.Point(163, 283);
            this.lbColorMinArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbColorMinArea.MinimumSize = new System.Drawing.Size(1, 16);
            this.lbColorMinArea.Name = "lbColorMinArea";
            this.lbColorMinArea.Padding = new System.Windows.Forms.Padding(5);
            this.lbColorMinArea.RectColor = System.Drawing.Color.White;
            this.lbColorMinArea.ShowText = false;
            this.lbColorMinArea.Size = new System.Drawing.Size(110, 30);
            this.lbColorMinArea.Style = Sunny.UI.UIStyle.Custom;
            this.lbColorMinArea.TabIndex = 3551;
            this.lbColorMinArea.Text = "( 0.0 ~ 1.0 )";
            this.lbColorMinArea.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbColorMinArea.Watermark = "";
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.Color.Transparent;
            this.label94.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label94.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label94.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.ForeColor = System.Drawing.Color.White;
            this.label94.Location = new System.Drawing.Point(82, 281);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(80, 35);
            this.label94.TabIndex = 3549;
            this.label94.Text = "Min";
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.Color.Transparent;
            this.label95.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label95.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label95.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.Color.White;
            this.label95.Location = new System.Drawing.Point(1, 281);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(80, 72);
            this.label95.TabIndex = 3548;
            this.label95.Text = "AreaSize";
            this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Transparent;
            this.label96.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label96.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label96.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.Color.White;
            this.label96.Location = new System.Drawing.Point(82, 318);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(80, 35);
            this.label96.TabIndex = 3547;
            this.label96.Text = "Max";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.lbThreshold_Color);
            this.panel43.Controls.Add(this.trbThreshold_Color);
            this.panel43.Controls.Add(this.label97);
            this.panel43.Location = new System.Drawing.Point(0, 247);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(307, 35);
            this.panel43.TabIndex = 3546;
            // 
            // lbThreshold_Color
            // 
            this.lbThreshold_Color.BackColor = System.Drawing.Color.Transparent;
            this.lbThreshold_Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbThreshold_Color.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbThreshold_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbThreshold_Color.Font = new System.Drawing.Font("Arial", 10F);
            this.lbThreshold_Color.ForeColor = System.Drawing.Color.White;
            this.lbThreshold_Color.Location = new System.Drawing.Point(247, 0);
            this.lbThreshold_Color.Name = "lbThreshold_Color";
            this.lbThreshold_Color.Size = new System.Drawing.Size(60, 35);
            this.lbThreshold_Color.TabIndex = 2723;
            this.lbThreshold_Color.Text = "000";
            this.lbThreshold_Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trbThreshold_Color
            // 
            this.trbThreshold_Color.BackColor = System.Drawing.Color.Transparent;
            this.trbThreshold_Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trbThreshold_Color.Location = new System.Drawing.Point(75, 0);
            this.trbThreshold_Color.Maximum = 254;
            this.trbThreshold_Color.Minimum = 1;
            this.trbThreshold_Color.Name = "trbThreshold_Color";
            this.trbThreshold_Color.Size = new System.Drawing.Size(232, 35);
            this.trbThreshold_Color.TabIndex = 2721;
            this.trbThreshold_Color.Tag = "CAM1";
            this.trbThreshold_Color.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.Color.Transparent;
            this.label97.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label97.Dock = System.Windows.Forms.DockStyle.Left;
            this.label97.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label97.Font = new System.Drawing.Font("Arial", 9F);
            this.label97.ForeColor = System.Drawing.Color.White;
            this.label97.Location = new System.Drawing.Point(0, 0);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(75, 35);
            this.label97.TabIndex = 2722;
            this.label97.Text = "Threshold";
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.11475F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.88525F));
            this.tableLayoutPanel5.Controls.Add(this.label98, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 73);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(307, 174);
            this.tableLayoutPanel5.TabIndex = 3543;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.Transparent;
            this.label98.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label98.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label98.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label98.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.ForeColor = System.Drawing.Color.White;
            this.label98.Location = new System.Drawing.Point(3, 0);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(34, 174);
            this.label98.TabIndex = 2691;
            this.label98.Text = "Color";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel8);
            this.panel1.Controls.Add(this.tableLayoutPanel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(43, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 168);
            this.panel1.TabIndex = 2692;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.60209F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.3979F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel8.Controls.Add(this.label99, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.lbJobColor_Area, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnJobColor_Insp, 2, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 101);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(261, 67);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.Transparent;
            this.label99.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label99.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label99.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label99.Font = new System.Drawing.Font("Arial", 9F);
            this.label99.ForeColor = System.Drawing.Color.White;
            this.label99.Location = new System.Drawing.Point(3, 0);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(43, 67);
            this.label99.TabIndex = 2717;
            this.label99.Text = "Boundary";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbJobColor_Area
            // 
            this.lbJobColor_Area.BackColor = System.Drawing.Color.Transparent;
            this.lbJobColor_Area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbJobColor_Area.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbJobColor_Area.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbJobColor_Area.Font = new System.Drawing.Font("Arial", 9F);
            this.lbJobColor_Area.ForeColor = System.Drawing.Color.White;
            this.lbJobColor_Area.Location = new System.Drawing.Point(52, 0);
            this.lbJobColor_Area.Name = "lbJobColor_Area";
            this.lbJobColor_Area.Size = new System.Drawing.Size(82, 67);
            this.lbJobColor_Area.TabIndex = 2719;
            this.lbJobColor_Area.Text = "Area : 0 px";
            this.lbJobColor_Area.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobColor_Insp
            // 
            this.btnJobColor_Insp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJobColor_Insp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnJobColor_Insp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobColor_Insp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobColor_Insp.ForeColor = System.Drawing.Color.White;
            this.btnJobColor_Insp.Image = global::IntelligentFactory.Properties.Resources.InspectManual50_Normal;
            this.btnJobColor_Insp.Location = new System.Drawing.Point(140, 3);
            this.btnJobColor_Insp.Name = "btnJobColor_Insp";
            this.btnJobColor_Insp.Size = new System.Drawing.Size(118, 61);
            this.btnJobColor_Insp.TabIndex = 2718;
            this.btnJobColor_Insp.Tag = "Bottom";
            this.btnJobColor_Insp.Text = "INSP";
            this.btnJobColor_Insp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobColor_Insp.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.5873F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.4127F));
            this.tableLayoutPanel6.Controls.Add(this.label101, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(261, 101);
            this.tableLayoutPanel6.TabIndex = 2692;
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.Color.Transparent;
            this.label101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label101.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label101.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label101.Font = new System.Drawing.Font("Arial", 9F);
            this.label101.ForeColor = System.Drawing.Color.White;
            this.label101.Location = new System.Drawing.Point(3, 0);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(50, 101);
            this.label101.TabIndex = 2693;
            this.label101.Text = "Extract";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.btnJobColor_Roi, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnJobColor_AutoColor, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.lbExtractedColor2, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.lbExtractedColor, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(59, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(199, 95);
            this.tableLayoutPanel7.TabIndex = 2694;
            // 
            // btnJobColor_Roi
            // 
            this.btnJobColor_Roi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJobColor_Roi.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnJobColor_Roi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobColor_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobColor_Roi.ForeColor = System.Drawing.Color.White;
            this.btnJobColor_Roi.Image = global::IntelligentFactory.Properties.Resources.Roi50_Normal;
            this.btnJobColor_Roi.Location = new System.Drawing.Point(3, 3);
            this.btnJobColor_Roi.Name = "btnJobColor_Roi";
            this.btnJobColor_Roi.Size = new System.Drawing.Size(93, 41);
            this.btnJobColor_Roi.TabIndex = 2683;
            this.btnJobColor_Roi.Text = "ROI";
            this.btnJobColor_Roi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobColor_Roi.UseVisualStyleBackColor = true;
            // 
            // btnJobColor_AutoColor
            // 
            this.btnJobColor_AutoColor.BackColor = System.Drawing.Color.Transparent;
            this.btnJobColor_AutoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJobColor_AutoColor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnJobColor_AutoColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobColor_AutoColor.Font = new System.Drawing.Font("Arial", 9F);
            this.btnJobColor_AutoColor.ForeColor = System.Drawing.Color.White;
            this.btnJobColor_AutoColor.Image = global::IntelligentFactory.Properties.Resources.AutoColor50_Normal;
            this.btnJobColor_AutoColor.Location = new System.Drawing.Point(102, 3);
            this.btnJobColor_AutoColor.Name = "btnJobColor_AutoColor";
            this.btnJobColor_AutoColor.Size = new System.Drawing.Size(94, 41);
            this.btnJobColor_AutoColor.TabIndex = 2729;
            this.btnJobColor_AutoColor.Text = "Auto \r\nColor";
            this.btnJobColor_AutoColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobColor_AutoColor.UseVisualStyleBackColor = false;
            // 
            // lbExtractedColor2
            // 
            this.lbExtractedColor2.BackColor = System.Drawing.Color.Transparent;
            this.lbExtractedColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbExtractedColor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbExtractedColor2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbExtractedColor2.Font = new System.Drawing.Font("Arial", 9F);
            this.lbExtractedColor2.ForeColor = System.Drawing.Color.White;
            this.lbExtractedColor2.Location = new System.Drawing.Point(102, 47);
            this.lbExtractedColor2.Name = "lbExtractedColor2";
            this.lbExtractedColor2.Size = new System.Drawing.Size(94, 48);
            this.lbExtractedColor2.TabIndex = 2730;
            this.lbExtractedColor2.Text = "RGB";
            this.lbExtractedColor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbExtractedColor
            // 
            this.lbExtractedColor.BackColor = System.Drawing.Color.Transparent;
            this.lbExtractedColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbExtractedColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbExtractedColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbExtractedColor.Font = new System.Drawing.Font("Arial", 9F);
            this.lbExtractedColor.ForeColor = System.Drawing.Color.White;
            this.lbExtractedColor.Location = new System.Drawing.Point(3, 47);
            this.lbExtractedColor.Name = "lbExtractedColor";
            this.lbExtractedColor.Size = new System.Drawing.Size(93, 48);
            this.lbExtractedColor.TabIndex = 2419;
            this.lbExtractedColor.Text = "RGB";
            this.lbExtractedColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.cboColorAlg);
            this.panel23.Controls.Add(this.label102);
            this.panel23.Location = new System.Drawing.Point(0, 38);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(307, 35);
            this.panel23.TabIndex = 3545;
            // 
            // cboColorAlg
            // 
            this.cboColorAlg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboColorAlg.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
            this.cboColorAlg.ForeColor = System.Drawing.Color.White;
            this.cboColorAlg.FormattingEnabled = true;
            this.cboColorAlg.ItemHeight = 23;
            this.cboColorAlg.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cboColorAlg.Location = new System.Drawing.Point(73, 0);
            this.cboColorAlg.Name = "cboColorAlg";
            this.cboColorAlg.Size = new System.Drawing.Size(234, 29);
            this.cboColorAlg.Style = MetroFramework.MetroColorStyle.Orange;
            this.cboColorAlg.TabIndex = 3415;
            this.cboColorAlg.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cboColorAlg.UseCustomForeColor = true;
            this.cboColorAlg.UseSelectable = true;
            // 
            // label102
            // 
            this.label102.BackColor = System.Drawing.Color.Transparent;
            this.label102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label102.Dock = System.Windows.Forms.DockStyle.Left;
            this.label102.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label102.Font = new System.Drawing.Font("Arial", 9F);
            this.label102.ForeColor = System.Drawing.Color.White;
            this.label102.Location = new System.Drawing.Point(0, 0);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(73, 35);
            this.label102.TabIndex = 2788;
            this.label102.Text = "ColorAlg";
            this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.cboColorCoordinate);
            this.panel19.Controls.Add(this.label103);
            this.panel19.Location = new System.Drawing.Point(0, 3);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(307, 35);
            this.panel19.TabIndex = 3544;
            // 
            // cboColorCoordinate
            // 
            this.cboColorCoordinate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboColorCoordinate.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
            this.cboColorCoordinate.ForeColor = System.Drawing.Color.White;
            this.cboColorCoordinate.FormattingEnabled = true;
            this.cboColorCoordinate.ItemHeight = 23;
            this.cboColorCoordinate.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cboColorCoordinate.Location = new System.Drawing.Point(73, 0);
            this.cboColorCoordinate.Name = "cboColorCoordinate";
            this.cboColorCoordinate.Size = new System.Drawing.Size(234, 29);
            this.cboColorCoordinate.Style = MetroFramework.MetroColorStyle.Orange;
            this.cboColorCoordinate.TabIndex = 3414;
            this.cboColorCoordinate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cboColorCoordinate.UseCustomForeColor = true;
            this.cboColorCoordinate.UseSelectable = true;
            // 
            // label103
            // 
            this.label103.BackColor = System.Drawing.Color.Transparent;
            this.label103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label103.Dock = System.Windows.Forms.DockStyle.Left;
            this.label103.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label103.Font = new System.Drawing.Font("Arial", 9F);
            this.label103.ForeColor = System.Drawing.Color.White;
            this.label103.Location = new System.Drawing.Point(0, 0);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(73, 35);
            this.label103.TabIndex = 2788;
            this.label103.Text = "Color\r\nCoordinate";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage28
            // 
            this.tabPage28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage28.Controls.Add(this.panel64);
            this.tabPage28.Controls.Add(this.chkColorEx_SimpleMode);
            this.tabPage28.Controls.Add(this.label167);
            this.tabPage28.Controls.Add(this.btnJobColorEx_Roi);
            this.tabPage28.Controls.Add(this.lblJobColorEx_ResultColor);
            this.tabPage28.Controls.Add(this.btnJobColorEx_Get);
            this.tabPage28.Controls.Add(this.label130);
            this.tabPage28.Controls.Add(this.button4);
            this.tabPage28.Controls.Add(this.comboCorrectColorEx);
            this.tabPage28.Controls.Add(this.label132);
            this.tabPage28.Controls.Add(this.uiSymbolButton67);
            this.tabPage28.Controls.Add(this.label133);
            this.tabPage28.Location = new System.Drawing.Point(91, 0);
            this.tabPage28.Name = "tabPage28";
            this.tabPage28.Size = new System.Drawing.Size(564, 512);
            this.tabPage28.TabIndex = 5;
            this.tabPage28.Text = "ColorEx";
            // 
            // panel64
            // 
            this.panel64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel64.Controls.Add(this.txtColorEx_B);
            this.panel64.Controls.Add(this.txtColorEx_G);
            this.panel64.Controls.Add(this.txtColorEx_R);
            this.panel64.Controls.Add(this.label168);
            this.panel64.Controls.Add(this.radioColorEx_Range45);
            this.panel64.Controls.Add(this.radioColorEx_Range30);
            this.panel64.Controls.Add(this.radioColorEx_Range15);
            this.panel64.Controls.Add(this.label171);
            this.panel64.Controls.Add(this.label170);
            this.panel64.Controls.Add(this.label169);
            this.panel64.Location = new System.Drawing.Point(80, 60);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(199, 82);
            this.panel64.TabIndex = 3557;
            // 
            // txtColorEx_B
            // 
            this.txtColorEx_B.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtColorEx_B.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtColorEx_B.Font = new System.Drawing.Font("Arial", 8F);
            this.txtColorEx_B.ForeColor = System.Drawing.Color.White;
            this.txtColorEx_B.Location = new System.Drawing.Point(158, 5);
            this.txtColorEx_B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtColorEx_B.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtColorEx_B.Name = "txtColorEx_B";
            this.txtColorEx_B.Padding = new System.Windows.Forms.Padding(5);
            this.txtColorEx_B.RectColor = System.Drawing.Color.White;
            this.txtColorEx_B.ShowText = false;
            this.txtColorEx_B.Size = new System.Drawing.Size(29, 20);
            this.txtColorEx_B.Style = Sunny.UI.UIStyle.Custom;
            this.txtColorEx_B.TabIndex = 3552;
            this.txtColorEx_B.Text = "0";
            this.txtColorEx_B.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtColorEx_B.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtColorEx_B.Watermark = "W";
            // 
            // txtColorEx_G
            // 
            this.txtColorEx_G.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtColorEx_G.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtColorEx_G.Font = new System.Drawing.Font("Arial", 8F);
            this.txtColorEx_G.ForeColor = System.Drawing.Color.White;
            this.txtColorEx_G.Location = new System.Drawing.Point(93, 5);
            this.txtColorEx_G.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtColorEx_G.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtColorEx_G.Name = "txtColorEx_G";
            this.txtColorEx_G.Padding = new System.Windows.Forms.Padding(5);
            this.txtColorEx_G.RectColor = System.Drawing.Color.White;
            this.txtColorEx_G.ShowText = false;
            this.txtColorEx_G.Size = new System.Drawing.Size(29, 20);
            this.txtColorEx_G.Style = Sunny.UI.UIStyle.Custom;
            this.txtColorEx_G.TabIndex = 3550;
            this.txtColorEx_G.Text = "0";
            this.txtColorEx_G.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtColorEx_G.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtColorEx_G.Watermark = "W";
            // 
            // txtColorEx_R
            // 
            this.txtColorEx_R.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtColorEx_R.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtColorEx_R.Font = new System.Drawing.Font("Arial", 8F);
            this.txtColorEx_R.ForeColor = System.Drawing.Color.White;
            this.txtColorEx_R.Location = new System.Drawing.Point(28, 5);
            this.txtColorEx_R.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtColorEx_R.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtColorEx_R.Name = "txtColorEx_R";
            this.txtColorEx_R.Padding = new System.Windows.Forms.Padding(5);
            this.txtColorEx_R.RectColor = System.Drawing.Color.White;
            this.txtColorEx_R.ShowText = false;
            this.txtColorEx_R.Size = new System.Drawing.Size(29, 20);
            this.txtColorEx_R.Style = Sunny.UI.UIStyle.Custom;
            this.txtColorEx_R.TabIndex = 3548;
            this.txtColorEx_R.Text = "0";
            this.txtColorEx_R.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtColorEx_R.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtColorEx_R.Watermark = "W";
            // 
            // label168
            // 
            this.label168.BackColor = System.Drawing.Color.Transparent;
            this.label168.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label168.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label168.Font = new System.Drawing.Font("Arial", 8F);
            this.label168.ForeColor = System.Drawing.Color.White;
            this.label168.Location = new System.Drawing.Point(31, 57);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(134, 20);
            this.label168.TabIndex = 3547;
            this.label168.Text = "Diff Range (R,G,B)";
            this.label168.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioColorEx_Range45
            // 
            this.radioColorEx_Range45.AutoSize = true;
            this.radioColorEx_Range45.ForeColor = System.Drawing.Color.White;
            this.radioColorEx_Range45.Location = new System.Drawing.Point(132, 32);
            this.radioColorEx_Range45.Name = "radioColorEx_Range45";
            this.radioColorEx_Range45.Size = new System.Drawing.Size(46, 20);
            this.radioColorEx_Range45.TabIndex = 3546;
            this.radioColorEx_Range45.Text = "±45";
            this.radioColorEx_Range45.UseVisualStyleBackColor = true;
            // 
            // radioColorEx_Range30
            // 
            this.radioColorEx_Range30.AutoSize = true;
            this.radioColorEx_Range30.Checked = true;
            this.radioColorEx_Range30.ForeColor = System.Drawing.Color.White;
            this.radioColorEx_Range30.Location = new System.Drawing.Point(78, 32);
            this.radioColorEx_Range30.Name = "radioColorEx_Range30";
            this.radioColorEx_Range30.Size = new System.Drawing.Size(46, 20);
            this.radioColorEx_Range30.TabIndex = 3545;
            this.radioColorEx_Range30.TabStop = true;
            this.radioColorEx_Range30.Text = "±30";
            this.radioColorEx_Range30.UseVisualStyleBackColor = true;
            // 
            // radioColorEx_Range15
            // 
            this.radioColorEx_Range15.AutoSize = true;
            this.radioColorEx_Range15.ForeColor = System.Drawing.Color.White;
            this.radioColorEx_Range15.Location = new System.Drawing.Point(21, 32);
            this.radioColorEx_Range15.Name = "radioColorEx_Range15";
            this.radioColorEx_Range15.Size = new System.Drawing.Size(46, 20);
            this.radioColorEx_Range15.TabIndex = 3544;
            this.radioColorEx_Range15.Text = "±15";
            this.radioColorEx_Range15.UseVisualStyleBackColor = true;
            // 
            // label171
            // 
            this.label171.BackColor = System.Drawing.Color.Transparent;
            this.label171.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label171.Font = new System.Drawing.Font("Arial", 8F);
            this.label171.ForeColor = System.Drawing.Color.White;
            this.label171.Location = new System.Drawing.Point(134, 5);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(27, 20);
            this.label171.TabIndex = 3553;
            this.label171.Text = "B :";
            this.label171.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label170
            // 
            this.label170.BackColor = System.Drawing.Color.Transparent;
            this.label170.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label170.Font = new System.Drawing.Font("Arial", 8F);
            this.label170.ForeColor = System.Drawing.Color.White;
            this.label170.Location = new System.Drawing.Point(69, 5);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(27, 20);
            this.label170.TabIndex = 3551;
            this.label170.Text = "G :";
            this.label170.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label169
            // 
            this.label169.BackColor = System.Drawing.Color.Transparent;
            this.label169.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label169.Font = new System.Drawing.Font("Arial", 8F);
            this.label169.ForeColor = System.Drawing.Color.White;
            this.label169.Location = new System.Drawing.Point(4, 5);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(27, 20);
            this.label169.TabIndex = 3549;
            this.label169.Text = "R :";
            this.label169.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkColorEx_SimpleMode
            // 
            this.chkColorEx_SimpleMode.AutoSize = true;
            this.chkColorEx_SimpleMode.Font = new System.Drawing.Font("Arial", 8F);
            this.chkColorEx_SimpleMode.ForeColor = System.Drawing.Color.White;
            this.chkColorEx_SimpleMode.Location = new System.Drawing.Point(6, 63);
            this.chkColorEx_SimpleMode.Name = "chkColorEx_SimpleMode";
            this.chkColorEx_SimpleMode.Size = new System.Drawing.Size(15, 14);
            this.chkColorEx_SimpleMode.TabIndex = 3556;
            this.chkColorEx_SimpleMode.UseVisualStyleBackColor = true;
            // 
            // label167
            // 
            this.label167.BackColor = System.Drawing.Color.Transparent;
            this.label167.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label167.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label167.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label167.ForeColor = System.Drawing.Color.White;
            this.label167.Location = new System.Drawing.Point(2, 60);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(77, 82);
            this.label167.TabIndex = 3555;
            this.label167.Text = "Simple Mode";
            this.label167.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobColorEx_Roi
            // 
            this.btnJobColorEx_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobColorEx_Roi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobColorEx_Roi.Location = new System.Drawing.Point(70, 189);
            this.btnJobColorEx_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobColorEx_Roi.Name = "btnJobColorEx_Roi";
            this.btnJobColorEx_Roi.RectColor = System.Drawing.Color.White;
            this.btnJobColorEx_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobColorEx_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobColorEx_Roi.Size = new System.Drawing.Size(140, 42);
            this.btnJobColorEx_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobColorEx_Roi.StyleCustomMode = true;
            this.btnJobColorEx_Roi.Symbol = 362923;
            this.btnJobColorEx_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobColorEx_Roi.SymbolSize = 16;
            this.btnJobColorEx_Roi.TabIndex = 3554;
            this.btnJobColorEx_Roi.Text = "Roi";
            this.btnJobColorEx_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // lblJobColorEx_ResultColor
            // 
            this.lblJobColorEx_ResultColor.BackColor = System.Drawing.Color.Transparent;
            this.lblJobColorEx_ResultColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobColorEx_ResultColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblJobColorEx_ResultColor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobColorEx_ResultColor.ForeColor = System.Drawing.Color.White;
            this.lblJobColorEx_ResultColor.Location = new System.Drawing.Point(80, 143);
            this.lblJobColorEx_ResultColor.Name = "lblJobColorEx_ResultColor";
            this.lblJobColorEx_ResultColor.Size = new System.Drawing.Size(155, 29);
            this.lblJobColorEx_ResultColor.TabIndex = 3553;
            this.lblJobColorEx_ResultColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobColorEx_Get
            // 
            this.btnJobColorEx_Get.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Get.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnJobColorEx_Get.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobColorEx_Get.Font = new System.Drawing.Font("Arial", 9F);
            this.btnJobColorEx_Get.ForeColor = System.Drawing.Color.White;
            this.btnJobColorEx_Get.Location = new System.Drawing.Point(236, 143);
            this.btnJobColorEx_Get.Name = "btnJobColorEx_Get";
            this.btnJobColorEx_Get.Size = new System.Drawing.Size(43, 29);
            this.btnJobColorEx_Get.TabIndex = 3552;
            this.btnJobColorEx_Get.Text = "Get";
            this.btnJobColorEx_Get.UseVisualStyleBackColor = false;
            // 
            // label130
            // 
            this.label130.BackColor = System.Drawing.Color.Transparent;
            this.label130.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label130.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label130.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.ForeColor = System.Drawing.Color.White;
            this.label130.Location = new System.Drawing.Point(2, 143);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(77, 29);
            this.label130.TabIndex = 3551;
            this.label130.Text = "Result\r\nColor";
            this.label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 9F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(236, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 29);
            this.button4.TabIndex = 3550;
            this.button4.Text = "Get";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // comboCorrectColorEx
            // 
            this.comboCorrectColorEx.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
            this.comboCorrectColorEx.ForeColor = System.Drawing.Color.White;
            this.comboCorrectColorEx.FormattingEnabled = true;
            this.comboCorrectColorEx.ItemHeight = 23;
            this.comboCorrectColorEx.Location = new System.Drawing.Point(80, 30);
            this.comboCorrectColorEx.Name = "comboCorrectColorEx";
            this.comboCorrectColorEx.Size = new System.Drawing.Size(155, 29);
            this.comboCorrectColorEx.Style = MetroFramework.MetroColorStyle.Orange;
            this.comboCorrectColorEx.TabIndex = 3549;
            this.comboCorrectColorEx.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboCorrectColorEx.UseCustomForeColor = true;
            this.comboCorrectColorEx.UseSelectable = true;
            // 
            // label132
            // 
            this.label132.BackColor = System.Drawing.Color.Transparent;
            this.label132.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label132.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label132.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.ForeColor = System.Drawing.Color.White;
            this.label132.Location = new System.Drawing.Point(2, 30);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(77, 29);
            this.label132.TabIndex = 3548;
            this.label132.Text = "Correct\r\nColor";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiSymbolButton67
            // 
            this.uiSymbolButton67.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton67.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton67.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton67.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton67.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton67.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton67.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton67.Location = new System.Drawing.Point(454, 3);
            this.uiSymbolButton67.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton67.Name = "uiSymbolButton67";
            this.uiSymbolButton67.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton67.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton67.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton67.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton67.Size = new System.Drawing.Size(100, 22);
            this.uiSymbolButton67.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton67.StyleCustomMode = true;
            this.uiSymbolButton67.Symbol = 61459;
            this.uiSymbolButton67.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton67.SymbolSize = 20;
            this.uiSymbolButton67.TabIndex = 3547;
            this.uiSymbolButton67.Text = "Setting";
            this.uiSymbolButton67.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label133
            // 
            this.label133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label133.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label133.Dock = System.Windows.Forms.DockStyle.Top;
            this.label133.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label133.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label133.ForeColor = System.Drawing.Color.White;
            this.label133.Location = new System.Drawing.Point(0, 0);
            this.label133.Name = "label133";
            this.label133.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label133.Size = new System.Drawing.Size(564, 27);
            this.label133.TabIndex = 3546;
            this.label133.Text = "     Color Extract";
            this.label133.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage29
            // 
            this.tabPage29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage29.Controls.Add(this.tbIgnoreCount);
            this.tabPage29.Controls.Add(this.tbCircleThickness);
            this.tabPage29.Controls.Add(this.tbCircleContrast);
            this.tabPage29.Controls.Add(this.tbCondensorRectRadio);
            this.tabPage29.Controls.Add(this.tbCircleRectH);
            this.tabPage29.Controls.Add(this.tbCircleRectW);
            this.tabPage29.Controls.Add(this.btnJobCondensor_DistSetting);
            this.tabPage29.Controls.Add(this.btnJobCondensor_DistInsp);
            this.tabPage29.Controls.Add(this.chkCondensor_UseDist);
            this.tabPage29.Controls.Add(this.label149);
            this.tabPage29.Controls.Add(this.btnCondensorAutoRegion);
            this.tabPage29.Controls.Add(this.label104);
            this.tabPage29.Controls.Add(this.comboCondensorPolarity);
            this.tabPage29.Controls.Add(this.label105);
            this.tabPage29.Controls.Add(this.label108);
            this.tabPage29.Controls.Add(this.label114);
            this.tabPage29.Controls.Add(this.label115);
            this.tabPage29.Controls.Add(this.btnJobCondensor_Inspection);
            this.tabPage29.Controls.Add(this.label116);
            this.tabPage29.Controls.Add(this.panel13);
            this.tabPage29.Controls.Add(this.label119);
            this.tabPage29.Controls.Add(this.label120);
            this.tabPage29.Controls.Add(this.btnJobCondensor_Roi);
            this.tabPage29.Controls.Add(this.uiSymbolButton68);
            this.tabPage29.Location = new System.Drawing.Point(91, 0);
            this.tabPage29.Name = "tabPage29";
            this.tabPage29.Size = new System.Drawing.Size(564, 512);
            this.tabPage29.TabIndex = 6;
            this.tabPage29.Text = "Condensor";
            // 
            // tbIgnoreCount
            // 
            this.tbIgnoreCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbIgnoreCount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbIgnoreCount.Font = new System.Drawing.Font("Arial", 9F);
            this.tbIgnoreCount.ForeColor = System.Drawing.Color.DimGray;
            this.tbIgnoreCount.Location = new System.Drawing.Point(83, 253);
            this.tbIgnoreCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIgnoreCount.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbIgnoreCount.Name = "tbIgnoreCount";
            this.tbIgnoreCount.Padding = new System.Windows.Forms.Padding(5);
            this.tbIgnoreCount.RectColor = System.Drawing.Color.White;
            this.tbIgnoreCount.ShowText = false;
            this.tbIgnoreCount.Size = new System.Drawing.Size(217, 30);
            this.tbIgnoreCount.Style = Sunny.UI.UIStyle.Custom;
            this.tbIgnoreCount.TabIndex = 3569;
            this.tbIgnoreCount.Text = "( 10 ~ 200 )";
            this.tbIgnoreCount.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbIgnoreCount.Watermark = "";
            // 
            // tbCircleThickness
            // 
            this.tbCircleThickness.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCircleThickness.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbCircleThickness.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCircleThickness.ForeColor = System.Drawing.Color.DimGray;
            this.tbCircleThickness.Location = new System.Drawing.Point(83, 218);
            this.tbCircleThickness.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCircleThickness.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCircleThickness.Name = "tbCircleThickness";
            this.tbCircleThickness.Padding = new System.Windows.Forms.Padding(5);
            this.tbCircleThickness.RectColor = System.Drawing.Color.White;
            this.tbCircleThickness.ShowText = false;
            this.tbCircleThickness.Size = new System.Drawing.Size(217, 30);
            this.tbCircleThickness.Style = Sunny.UI.UIStyle.Custom;
            this.tbCircleThickness.TabIndex = 3568;
            this.tbCircleThickness.Text = "( 10 ~ 200 )";
            this.tbCircleThickness.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbCircleThickness.Watermark = "";
            // 
            // tbCircleContrast
            // 
            this.tbCircleContrast.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCircleContrast.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbCircleContrast.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCircleContrast.ForeColor = System.Drawing.Color.DimGray;
            this.tbCircleContrast.Location = new System.Drawing.Point(83, 182);
            this.tbCircleContrast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCircleContrast.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCircleContrast.Name = "tbCircleContrast";
            this.tbCircleContrast.Padding = new System.Windows.Forms.Padding(5);
            this.tbCircleContrast.RectColor = System.Drawing.Color.White;
            this.tbCircleContrast.ShowText = false;
            this.tbCircleContrast.Size = new System.Drawing.Size(217, 30);
            this.tbCircleContrast.Style = Sunny.UI.UIStyle.Custom;
            this.tbCircleContrast.TabIndex = 3567;
            this.tbCircleContrast.Text = "( 10 ~ 200 )";
            this.tbCircleContrast.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbCircleContrast.Watermark = "";
            // 
            // tbCondensorRectRadio
            // 
            this.tbCondensorRectRadio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCondensorRectRadio.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbCondensorRectRadio.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCondensorRectRadio.ForeColor = System.Drawing.Color.DimGray;
            this.tbCondensorRectRadio.Location = new System.Drawing.Point(83, 146);
            this.tbCondensorRectRadio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCondensorRectRadio.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCondensorRectRadio.Name = "tbCondensorRectRadio";
            this.tbCondensorRectRadio.Padding = new System.Windows.Forms.Padding(5);
            this.tbCondensorRectRadio.RectColor = System.Drawing.Color.White;
            this.tbCondensorRectRadio.ShowText = false;
            this.tbCondensorRectRadio.Size = new System.Drawing.Size(217, 30);
            this.tbCondensorRectRadio.Style = Sunny.UI.UIStyle.Custom;
            this.tbCondensorRectRadio.TabIndex = 3566;
            this.tbCondensorRectRadio.Text = "( 10 ~ 200 )";
            this.tbCondensorRectRadio.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbCondensorRectRadio.Watermark = "";
            // 
            // tbCircleRectH
            // 
            this.tbCircleRectH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCircleRectH.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbCircleRectH.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCircleRectH.ForeColor = System.Drawing.Color.DimGray;
            this.tbCircleRectH.Location = new System.Drawing.Point(83, 112);
            this.tbCircleRectH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCircleRectH.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCircleRectH.Name = "tbCircleRectH";
            this.tbCircleRectH.Padding = new System.Windows.Forms.Padding(5);
            this.tbCircleRectH.RectColor = System.Drawing.Color.White;
            this.tbCircleRectH.ShowText = false;
            this.tbCircleRectH.Size = new System.Drawing.Size(217, 30);
            this.tbCircleRectH.Style = Sunny.UI.UIStyle.Custom;
            this.tbCircleRectH.TabIndex = 3565;
            this.tbCircleRectH.Text = "( 10 ~ 200 )";
            this.tbCircleRectH.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbCircleRectH.Watermark = "";
            // 
            // tbCircleRectW
            // 
            this.tbCircleRectW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCircleRectW.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbCircleRectW.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCircleRectW.ForeColor = System.Drawing.Color.DimGray;
            this.tbCircleRectW.Location = new System.Drawing.Point(83, 74);
            this.tbCircleRectW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCircleRectW.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCircleRectW.Name = "tbCircleRectW";
            this.tbCircleRectW.Padding = new System.Windows.Forms.Padding(5);
            this.tbCircleRectW.RectColor = System.Drawing.Color.White;
            this.tbCircleRectW.ShowText = false;
            this.tbCircleRectW.Size = new System.Drawing.Size(217, 30);
            this.tbCircleRectW.Style = Sunny.UI.UIStyle.Custom;
            this.tbCircleRectW.TabIndex = 3564;
            this.tbCircleRectW.Text = "( 10 ~ 200 )";
            this.tbCircleRectW.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tbCircleRectW.Watermark = "";
            // 
            // btnJobCondensor_DistSetting
            // 
            this.btnJobCondensor_DistSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobCondensor_DistSetting.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistSetting.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistSetting.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistSetting.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistSetting.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistSetting.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobCondensor_DistSetting.Location = new System.Drawing.Point(11, 473);
            this.btnJobCondensor_DistSetting.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobCondensor_DistSetting.Name = "btnJobCondensor_DistSetting";
            this.btnJobCondensor_DistSetting.RectColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistSetting.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistSetting.RectPressColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistSetting.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistSetting.Size = new System.Drawing.Size(140, 30);
            this.btnJobCondensor_DistSetting.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobCondensor_DistSetting.StyleCustomMode = true;
            this.btnJobCondensor_DistSetting.Symbol = 61459;
            this.btnJobCondensor_DistSetting.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobCondensor_DistSetting.SymbolSize = 20;
            this.btnJobCondensor_DistSetting.TabIndex = 3563;
            this.btnJobCondensor_DistSetting.Text = "Setting";
            this.btnJobCondensor_DistSetting.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnJobCondensor_DistInsp
            // 
            this.btnJobCondensor_DistInsp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobCondensor_DistInsp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistInsp.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistInsp.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistInsp.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistInsp.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistInsp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobCondensor_DistInsp.Location = new System.Drawing.Point(157, 473);
            this.btnJobCondensor_DistInsp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobCondensor_DistInsp.Name = "btnJobCondensor_DistInsp";
            this.btnJobCondensor_DistInsp.RectColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistInsp.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistInsp.RectPressColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistInsp.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistInsp.Size = new System.Drawing.Size(140, 30);
            this.btnJobCondensor_DistInsp.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobCondensor_DistInsp.StyleCustomMode = true;
            this.btnJobCondensor_DistInsp.Symbol = 61515;
            this.btnJobCondensor_DistInsp.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobCondensor_DistInsp.SymbolSize = 20;
            this.btnJobCondensor_DistInsp.TabIndex = 3562;
            this.btnJobCondensor_DistInsp.Text = "Inspection";
            this.btnJobCondensor_DistInsp.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // chkCondensor_UseDist
            // 
            this.chkCondensor_UseDist.AutoSize = true;
            this.chkCondensor_UseDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.chkCondensor_UseDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCondensor_UseDist.ForeColor = System.Drawing.Color.White;
            this.chkCondensor_UseDist.Location = new System.Drawing.Point(3, 448);
            this.chkCondensor_UseDist.Name = "chkCondensor_UseDist";
            this.chkCondensor_UseDist.Size = new System.Drawing.Size(15, 14);
            this.chkCondensor_UseDist.TabIndex = 3561;
            this.chkCondensor_UseDist.UseVisualStyleBackColor = false;
            // 
            // label149
            // 
            this.label149.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label149.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label149.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label149.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.ForeColor = System.Drawing.Color.White;
            this.label149.Location = new System.Drawing.Point(-1, 442);
            this.label149.Name = "label149";
            this.label149.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label149.Size = new System.Drawing.Size(308, 27);
            this.label149.TabIndex = 3560;
            this.label149.Text = "     Distance Measure From Fiducial Mark";
            this.label149.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCondensorAutoRegion
            // 
            this.btnCondensorAutoRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCondensorAutoRegion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnCondensorAutoRegion.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnCondensorAutoRegion.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnCondensorAutoRegion.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCondensorAutoRegion.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCondensorAutoRegion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCondensorAutoRegion.Location = new System.Drawing.Point(29, 384);
            this.btnCondensorAutoRegion.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCondensorAutoRegion.Name = "btnCondensorAutoRegion";
            this.btnCondensorAutoRegion.RectColor = System.Drawing.Color.White;
            this.btnCondensorAutoRegion.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnCondensorAutoRegion.RectPressColor = System.Drawing.Color.White;
            this.btnCondensorAutoRegion.RectSelectedColor = System.Drawing.Color.White;
            this.btnCondensorAutoRegion.Size = new System.Drawing.Size(248, 44);
            this.btnCondensorAutoRegion.Style = Sunny.UI.UIStyle.Custom;
            this.btnCondensorAutoRegion.StyleCustomMode = true;
            this.btnCondensorAutoRegion.Symbol = 362923;
            this.btnCondensorAutoRegion.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnCondensorAutoRegion.SymbolSize = 20;
            this.btnCondensorAutoRegion.TabIndex = 3559;
            this.btnCondensorAutoRegion.Text = "Recommand Region";
            this.btnCondensorAutoRegion.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.Color.Transparent;
            this.label104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label104.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label104.Font = new System.Drawing.Font("Arial", 8F);
            this.label104.ForeColor = System.Drawing.Color.White;
            this.label104.Location = new System.Drawing.Point(3, 141);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(80, 35);
            this.label104.TabIndex = 3558;
            this.label104.Text = "RectDistance";
            this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboCondensorPolarity
            // 
            this.comboCondensorPolarity.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
            this.comboCondensorPolarity.ForeColor = System.Drawing.Color.White;
            this.comboCondensorPolarity.FormattingEnabled = true;
            this.comboCondensorPolarity.ItemHeight = 23;
            this.comboCondensorPolarity.Items.AddRange(new object[] {
            "T",
            "B",
            "L",
            "R"});
            this.comboCondensorPolarity.Location = new System.Drawing.Point(84, 39);
            this.comboCondensorPolarity.Name = "comboCondensorPolarity";
            this.comboCondensorPolarity.Size = new System.Drawing.Size(220, 29);
            this.comboCondensorPolarity.Style = MetroFramework.MetroColorStyle.Orange;
            this.comboCondensorPolarity.TabIndex = 3557;
            this.comboCondensorPolarity.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboCondensorPolarity.UseCustomForeColor = true;
            this.comboCondensorPolarity.UseSelectable = true;
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.Color.Transparent;
            this.label105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label105.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label105.Font = new System.Drawing.Font("Arial", 8F);
            this.label105.ForeColor = System.Drawing.Color.White;
            this.label105.Location = new System.Drawing.Point(3, 39);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(80, 29);
            this.label105.TabIndex = 3556;
            this.label105.Text = "Polarity";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label108
            // 
            this.label108.BackColor = System.Drawing.Color.Transparent;
            this.label108.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label108.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label108.Font = new System.Drawing.Font("Arial", 8F);
            this.label108.ForeColor = System.Drawing.Color.White;
            this.label108.Location = new System.Drawing.Point(3, 249);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(80, 35);
            this.label108.TabIndex = 3555;
            this.label108.Text = "IgnoreCount";
            this.label108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label114
            // 
            this.label114.BackColor = System.Drawing.Color.Transparent;
            this.label114.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label114.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label114.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.ForeColor = System.Drawing.Color.White;
            this.label114.Location = new System.Drawing.Point(3, 213);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(80, 35);
            this.label114.TabIndex = 3554;
            this.label114.Text = "Thickness";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label115
            // 
            this.label115.BackColor = System.Drawing.Color.Transparent;
            this.label115.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label115.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label115.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.ForeColor = System.Drawing.Color.White;
            this.label115.Location = new System.Drawing.Point(3, 177);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(80, 35);
            this.label115.TabIndex = 3553;
            this.label115.Text = "Contrast";
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobCondensor_Inspection
            // 
            this.btnJobCondensor_Inspection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobCondensor_Inspection.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Inspection.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Inspection.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Inspection.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Inspection.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Inspection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobCondensor_Inspection.Location = new System.Drawing.Point(17, 336);
            this.btnJobCondensor_Inspection.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobCondensor_Inspection.Name = "btnJobCondensor_Inspection";
            this.btnJobCondensor_Inspection.RectColor = System.Drawing.Color.White;
            this.btnJobCondensor_Inspection.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Inspection.RectPressColor = System.Drawing.Color.White;
            this.btnJobCondensor_Inspection.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobCondensor_Inspection.Size = new System.Drawing.Size(269, 42);
            this.btnJobCondensor_Inspection.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobCondensor_Inspection.StyleCustomMode = true;
            this.btnJobCondensor_Inspection.Symbol = 61515;
            this.btnJobCondensor_Inspection.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobCondensor_Inspection.SymbolSize = 20;
            this.btnJobCondensor_Inspection.TabIndex = 3552;
            this.btnJobCondensor_Inspection.Text = "Inspection";
            this.btnJobCondensor_Inspection.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.Color.Transparent;
            this.label116.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label116.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label116.Font = new System.Drawing.Font("Arial", 8F);
            this.label116.ForeColor = System.Drawing.Color.White;
            this.label116.Location = new System.Drawing.Point(3, 3);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(80, 35);
            this.label116.TabIndex = 3551;
            this.label116.Text = "Type";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.radioCondensorTB);
            this.panel13.Controls.Add(this.radioCondensorLR);
            this.panel13.Location = new System.Drawing.Point(84, 3);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(220, 35);
            this.panel13.TabIndex = 3550;
            // 
            // radioCondensorTB
            // 
            this.radioCondensorTB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioCondensorTB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioCondensorTB.ForeColor = System.Drawing.Color.White;
            this.radioCondensorTB.Location = new System.Drawing.Point(98, 6);
            this.radioCondensorTB.MinimumSize = new System.Drawing.Size(1, 1);
            this.radioCondensorTB.Name = "radioCondensorTB";
            this.radioCondensorTB.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.radioCondensorTB.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.radioCondensorTB.Size = new System.Drawing.Size(55, 21);
            this.radioCondensorTB.Style = Sunny.UI.UIStyle.Custom;
            this.radioCondensorTB.TabIndex = 3400;
            this.radioCondensorTB.Text = "T-B";
            // 
            // radioCondensorLR
            // 
            this.radioCondensorLR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioCondensorLR.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioCondensorLR.ForeColor = System.Drawing.Color.White;
            this.radioCondensorLR.Location = new System.Drawing.Point(29, 6);
            this.radioCondensorLR.MinimumSize = new System.Drawing.Size(1, 1);
            this.radioCondensorLR.Name = "radioCondensorLR";
            this.radioCondensorLR.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.radioCondensorLR.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.radioCondensorLR.Size = new System.Drawing.Size(55, 21);
            this.radioCondensorLR.Style = Sunny.UI.UIStyle.Custom;
            this.radioCondensorLR.TabIndex = 3399;
            this.radioCondensorLR.Text = "L-R";
            // 
            // label119
            // 
            this.label119.BackColor = System.Drawing.Color.Transparent;
            this.label119.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label119.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label119.Font = new System.Drawing.Font("Arial", 8F);
            this.label119.ForeColor = System.Drawing.Color.White;
            this.label119.Location = new System.Drawing.Point(3, 69);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(80, 35);
            this.label119.TabIndex = 3549;
            this.label119.Text = "Region\r\nWidth";
            this.label119.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label120
            // 
            this.label120.BackColor = System.Drawing.Color.Transparent;
            this.label120.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label120.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label120.Font = new System.Drawing.Font("Arial", 8F);
            this.label120.ForeColor = System.Drawing.Color.White;
            this.label120.Location = new System.Drawing.Point(3, 105);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(80, 35);
            this.label120.TabIndex = 3548;
            this.label120.Text = "Region\r\nHeight";
            this.label120.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobCondensor_Roi
            // 
            this.btnJobCondensor_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobCondensor_Roi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobCondensor_Roi.Location = new System.Drawing.Point(17, 290);
            this.btnJobCondensor_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobCondensor_Roi.Name = "btnJobCondensor_Roi";
            this.btnJobCondensor_Roi.RectColor = System.Drawing.Color.White;
            this.btnJobCondensor_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobCondensor_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobCondensor_Roi.Size = new System.Drawing.Size(134, 44);
            this.btnJobCondensor_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobCondensor_Roi.StyleCustomMode = true;
            this.btnJobCondensor_Roi.Symbol = 362923;
            this.btnJobCondensor_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobCondensor_Roi.SymbolSize = 20;
            this.btnJobCondensor_Roi.TabIndex = 3546;
            this.btnJobCondensor_Roi.Text = "Roi";
            this.btnJobCondensor_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton68
            // 
            this.uiSymbolButton68.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton68.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton68.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton68.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton68.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton68.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton68.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton68.Location = new System.Drawing.Point(152, 290);
            this.uiSymbolButton68.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton68.Name = "uiSymbolButton68";
            this.uiSymbolButton68.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton68.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton68.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton68.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton68.Size = new System.Drawing.Size(134, 44);
            this.uiSymbolButton68.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton68.StyleCustomMode = true;
            this.uiSymbolButton68.Symbol = 61442;
            this.uiSymbolButton68.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton68.SymbolSize = 20;
            this.uiSymbolButton68.TabIndex = 3547;
            this.uiSymbolButton68.Text = "Find";
            this.uiSymbolButton68.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPage30
            // 
            this.tabPage30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage30.Controls.Add(this.txtJobConnector_OKArea);
            this.tabPage30.Controls.Add(this.label163);
            this.tabPage30.Controls.Add(this.panel62);
            this.tabPage30.Controls.Add(this.uiSymbolButton69);
            this.tabPage30.Controls.Add(this.btnJobConnector_Projection);
            this.tabPage30.Controls.Add(this.label162);
            this.tabPage30.Controls.Add(this.txtJobConnector_AreaMax);
            this.tabPage30.Controls.Add(this.txtJobConnector_AreaMin);
            this.tabPage30.Controls.Add(this.label161);
            this.tabPage30.Controls.Add(this.label155);
            this.tabPage30.Controls.Add(this.txtJobConnector_BoxHeight);
            this.tabPage30.Controls.Add(this.label160);
            this.tabPage30.Controls.Add(this.txtJobConnector_BoxWidth);
            this.tabPage30.Controls.Add(this.chkJobConnector_BinInv);
            this.tabPage30.Controls.Add(this.label157);
            this.tabPage30.Controls.Add(this.txtJobConnector_Threshold);
            this.tabPage30.Controls.Add(this.label159);
            this.tabPage30.Controls.Add(this.label158);
            this.tabPage30.Controls.Add(this.checkBox60);
            this.tabPage30.Controls.Add(this.uiSymbolButton70);
            this.tabPage30.Controls.Add(this.label154);
            this.tabPage30.Controls.Add(this.button1);
            this.tabPage30.Controls.Add(this.button2);
            this.tabPage30.Controls.Add(this.metroComboBox3);
            this.tabPage30.Controls.Add(this.label152);
            this.tabPage30.Controls.Add(this.label156);
            this.tabPage30.Controls.Add(this.txtJobConnector_Score);
            this.tabPage30.Controls.Add(this.label151);
            this.tabPage30.Controls.Add(this.panel61);
            this.tabPage30.Controls.Add(this.label153);
            this.tabPage30.Controls.Add(this.panel58);
            this.tabPage30.Controls.Add(this.btnJobConnector_Roi);
            this.tabPage30.Controls.Add(this.btnJobConnector_Train);
            this.tabPage30.Controls.Add(this.btnJobConnector_Find);
            this.tabPage30.Controls.Add(this.label164);
            this.tabPage30.Location = new System.Drawing.Point(91, 0);
            this.tabPage30.Name = "tabPage30";
            this.tabPage30.Size = new System.Drawing.Size(564, 512);
            this.tabPage30.TabIndex = 7;
            this.tabPage30.Text = "Connector";
            // 
            // txtJobConnector_OKArea
            // 
            this.txtJobConnector_OKArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobConnector_OKArea.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtJobConnector_OKArea.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txtJobConnector_OKArea.ForeColor = System.Drawing.Color.White;
            this.txtJobConnector_OKArea.Location = new System.Drawing.Point(210, 444);
            this.txtJobConnector_OKArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJobConnector_OKArea.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtJobConnector_OKArea.Name = "txtJobConnector_OKArea";
            this.txtJobConnector_OKArea.Padding = new System.Windows.Forms.Padding(5);
            this.txtJobConnector_OKArea.RectColor = System.Drawing.Color.White;
            this.txtJobConnector_OKArea.ShowText = false;
            this.txtJobConnector_OKArea.Size = new System.Drawing.Size(98, 34);
            this.txtJobConnector_OKArea.Style = Sunny.UI.UIStyle.Custom;
            this.txtJobConnector_OKArea.TabIndex = 3633;
            this.txtJobConnector_OKArea.Text = "0";
            this.txtJobConnector_OKArea.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtJobConnector_OKArea.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtJobConnector_OKArea.Watermark = "";
            // 
            // label163
            // 
            this.label163.BackColor = System.Drawing.Color.Transparent;
            this.label163.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label163.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label163.Font = new System.Drawing.Font("Arial", 8F);
            this.label163.ForeColor = System.Drawing.Color.White;
            this.label163.Location = new System.Drawing.Point(3, 444);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(80, 35);
            this.label163.TabIndex = 3632;
            this.label163.Text = "Area\r\n(OK Minimum)";
            this.label163.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel62
            // 
            this.panel62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel62.Controls.Add(this.radioJobConnector_AreaRB);
            this.panel62.Controls.Add(this.radioJobConnector_AreaLT);
            this.panel62.Location = new System.Drawing.Point(84, 444);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(111, 35);
            this.panel62.TabIndex = 3631;
            // 
            // radioJobConnector_AreaRB
            // 
            this.radioJobConnector_AreaRB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioJobConnector_AreaRB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioJobConnector_AreaRB.ForeColor = System.Drawing.Color.White;
            this.radioJobConnector_AreaRB.Location = new System.Drawing.Point(54, 6);
            this.radioJobConnector_AreaRB.MinimumSize = new System.Drawing.Size(1, 1);
            this.radioJobConnector_AreaRB.Name = "radioJobConnector_AreaRB";
            this.radioJobConnector_AreaRB.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.radioJobConnector_AreaRB.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.radioJobConnector_AreaRB.Size = new System.Drawing.Size(53, 21);
            this.radioJobConnector_AreaRB.Style = Sunny.UI.UIStyle.Custom;
            this.radioJobConnector_AreaRB.TabIndex = 3404;
            this.radioJobConnector_AreaRB.Text = "R/B";
            // 
            // radioJobConnector_AreaLT
            // 
            this.radioJobConnector_AreaLT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioJobConnector_AreaLT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioJobConnector_AreaLT.ForeColor = System.Drawing.Color.White;
            this.radioJobConnector_AreaLT.Location = new System.Drawing.Point(1, 6);
            this.radioJobConnector_AreaLT.MinimumSize = new System.Drawing.Size(1, 1);
            this.radioJobConnector_AreaLT.Name = "radioJobConnector_AreaLT";
            this.radioJobConnector_AreaLT.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.radioJobConnector_AreaLT.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.radioJobConnector_AreaLT.Size = new System.Drawing.Size(53, 21);
            this.radioJobConnector_AreaLT.Style = Sunny.UI.UIStyle.Custom;
            this.radioJobConnector_AreaLT.TabIndex = 3403;
            this.radioJobConnector_AreaLT.Text = "L/T";
            // 
            // uiSymbolButton69
            // 
            this.uiSymbolButton69.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton69.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton69.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton69.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton69.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton69.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton69.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton69.Location = new System.Drawing.Point(6, 483);
            this.uiSymbolButton69.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton69.Name = "uiSymbolButton69";
            this.uiSymbolButton69.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton69.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton69.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton69.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton69.Size = new System.Drawing.Size(299, 24);
            this.uiSymbolButton69.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton69.StyleCustomMode = true;
            this.uiSymbolButton69.Symbol = 108;
            this.uiSymbolButton69.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton69.SymbolSize = 20;
            this.uiSymbolButton69.TabIndex = 3630;
            this.uiSymbolButton69.Text = "Master";
            this.uiSymbolButton69.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnJobConnector_Projection
            // 
            this.btnJobConnector_Projection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobConnector_Projection.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Projection.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Projection.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobConnector_Projection.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Projection.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Projection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobConnector_Projection.Location = new System.Drawing.Point(212, 132);
            this.btnJobConnector_Projection.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobConnector_Projection.Name = "btnJobConnector_Projection";
            this.btnJobConnector_Projection.RectColor = System.Drawing.Color.White;
            this.btnJobConnector_Projection.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobConnector_Projection.RectPressColor = System.Drawing.Color.White;
            this.btnJobConnector_Projection.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobConnector_Projection.Size = new System.Drawing.Size(96, 42);
            this.btnJobConnector_Projection.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobConnector_Projection.StyleCustomMode = true;
            this.btnJobConnector_Projection.Symbol = 61442;
            this.btnJobConnector_Projection.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobConnector_Projection.SymbolSize = 20;
            this.btnJobConnector_Projection.TabIndex = 3629;
            this.btnJobConnector_Projection.Text = "Projection";
            this.btnJobConnector_Projection.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label162
            // 
            this.label162.BackColor = System.Drawing.Color.Transparent;
            this.label162.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label162.Font = new System.Drawing.Font("Arial", 12F);
            this.label162.ForeColor = System.Drawing.Color.White;
            this.label162.Location = new System.Drawing.Point(184, 407);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(23, 35);
            this.label162.TabIndex = 3628;
            this.label162.Text = "/";
            this.label162.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJobConnector_AreaMax
            // 
            this.txtJobConnector_AreaMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobConnector_AreaMax.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtJobConnector_AreaMax.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txtJobConnector_AreaMax.ForeColor = System.Drawing.Color.White;
            this.txtJobConnector_AreaMax.Location = new System.Drawing.Point(210, 408);
            this.txtJobConnector_AreaMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJobConnector_AreaMax.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtJobConnector_AreaMax.Name = "txtJobConnector_AreaMax";
            this.txtJobConnector_AreaMax.Padding = new System.Windows.Forms.Padding(5);
            this.txtJobConnector_AreaMax.RectColor = System.Drawing.Color.White;
            this.txtJobConnector_AreaMax.ShowText = false;
            this.txtJobConnector_AreaMax.Size = new System.Drawing.Size(98, 34);
            this.txtJobConnector_AreaMax.Style = Sunny.UI.UIStyle.Custom;
            this.txtJobConnector_AreaMax.TabIndex = 3627;
            this.txtJobConnector_AreaMax.Text = "0";
            this.txtJobConnector_AreaMax.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtJobConnector_AreaMax.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtJobConnector_AreaMax.Watermark = "";
            // 
            // txtJobConnector_AreaMin
            // 
            this.txtJobConnector_AreaMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobConnector_AreaMin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtJobConnector_AreaMin.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txtJobConnector_AreaMin.ForeColor = System.Drawing.Color.White;
            this.txtJobConnector_AreaMin.Location = new System.Drawing.Point(84, 408);
            this.txtJobConnector_AreaMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJobConnector_AreaMin.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtJobConnector_AreaMin.Name = "txtJobConnector_AreaMin";
            this.txtJobConnector_AreaMin.Padding = new System.Windows.Forms.Padding(5);
            this.txtJobConnector_AreaMin.RectColor = System.Drawing.Color.White;
            this.txtJobConnector_AreaMin.ShowText = false;
            this.txtJobConnector_AreaMin.Size = new System.Drawing.Size(98, 34);
            this.txtJobConnector_AreaMin.Style = Sunny.UI.UIStyle.Custom;
            this.txtJobConnector_AreaMin.TabIndex = 3626;
            this.txtJobConnector_AreaMin.Text = "0";
            this.txtJobConnector_AreaMin.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtJobConnector_AreaMin.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtJobConnector_AreaMin.Watermark = "";
            // 
            // label161
            // 
            this.label161.BackColor = System.Drawing.Color.Transparent;
            this.label161.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label161.Font = new System.Drawing.Font("Arial", 12F);
            this.label161.ForeColor = System.Drawing.Color.White;
            this.label161.Location = new System.Drawing.Point(184, 371);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(23, 35);
            this.label161.TabIndex = 3625;
            this.label161.Text = "/";
            this.label161.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label155
            // 
            this.label155.BackColor = System.Drawing.Color.Transparent;
            this.label155.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label155.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label155.Font = new System.Drawing.Font("Arial", 8F);
            this.label155.ForeColor = System.Drawing.Color.White;
            this.label155.Location = new System.Drawing.Point(3, 408);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(80, 35);
            this.label155.TabIndex = 3624;
            this.label155.Text = "Area\r\n(Min ~ Max)";
            this.label155.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJobConnector_BoxHeight
            // 
            this.txtJobConnector_BoxHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobConnector_BoxHeight.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtJobConnector_BoxHeight.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txtJobConnector_BoxHeight.ForeColor = System.Drawing.Color.White;
            this.txtJobConnector_BoxHeight.Location = new System.Drawing.Point(210, 372);
            this.txtJobConnector_BoxHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJobConnector_BoxHeight.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtJobConnector_BoxHeight.Name = "txtJobConnector_BoxHeight";
            this.txtJobConnector_BoxHeight.Padding = new System.Windows.Forms.Padding(5);
            this.txtJobConnector_BoxHeight.RectColor = System.Drawing.Color.White;
            this.txtJobConnector_BoxHeight.ShowText = false;
            this.txtJobConnector_BoxHeight.Size = new System.Drawing.Size(98, 34);
            this.txtJobConnector_BoxHeight.Style = Sunny.UI.UIStyle.Custom;
            this.txtJobConnector_BoxHeight.TabIndex = 3623;
            this.txtJobConnector_BoxHeight.Text = "0";
            this.txtJobConnector_BoxHeight.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtJobConnector_BoxHeight.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtJobConnector_BoxHeight.Watermark = "";
            // 
            // label160
            // 
            this.label160.BackColor = System.Drawing.Color.Transparent;
            this.label160.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label160.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label160.Font = new System.Drawing.Font("Arial", 8F);
            this.label160.ForeColor = System.Drawing.Color.White;
            this.label160.Location = new System.Drawing.Point(3, 372);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(80, 35);
            this.label160.TabIndex = 3622;
            this.label160.Text = "Projection\r\n(Width/Height)";
            this.label160.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJobConnector_BoxWidth
            // 
            this.txtJobConnector_BoxWidth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobConnector_BoxWidth.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtJobConnector_BoxWidth.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txtJobConnector_BoxWidth.ForeColor = System.Drawing.Color.White;
            this.txtJobConnector_BoxWidth.Location = new System.Drawing.Point(84, 372);
            this.txtJobConnector_BoxWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJobConnector_BoxWidth.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtJobConnector_BoxWidth.Name = "txtJobConnector_BoxWidth";
            this.txtJobConnector_BoxWidth.Padding = new System.Windows.Forms.Padding(5);
            this.txtJobConnector_BoxWidth.RectColor = System.Drawing.Color.White;
            this.txtJobConnector_BoxWidth.ShowText = false;
            this.txtJobConnector_BoxWidth.Size = new System.Drawing.Size(98, 34);
            this.txtJobConnector_BoxWidth.Style = Sunny.UI.UIStyle.Custom;
            this.txtJobConnector_BoxWidth.TabIndex = 3621;
            this.txtJobConnector_BoxWidth.Text = "0";
            this.txtJobConnector_BoxWidth.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtJobConnector_BoxWidth.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtJobConnector_BoxWidth.Watermark = "";
            // 
            // chkJobConnector_BinInv
            // 
            this.chkJobConnector_BinInv.AutoSize = true;
            this.chkJobConnector_BinInv.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJobConnector_BinInv.ForeColor = System.Drawing.Color.White;
            this.chkJobConnector_BinInv.Location = new System.Drawing.Point(202, 344);
            this.chkJobConnector_BinInv.Name = "chkJobConnector_BinInv";
            this.chkJobConnector_BinInv.Size = new System.Drawing.Size(103, 19);
            this.chkJobConnector_BinInv.TabIndex = 3620;
            this.chkJobConnector_BinInv.Text = "Binary Inverter";
            this.chkJobConnector_BinInv.UseVisualStyleBackColor = true;
            // 
            // label157
            // 
            this.label157.BackColor = System.Drawing.Color.Transparent;
            this.label157.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label157.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label157.Font = new System.Drawing.Font("Arial", 8F);
            this.label157.ForeColor = System.Drawing.Color.White;
            this.label157.Location = new System.Drawing.Point(3, 336);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(80, 35);
            this.label157.TabIndex = 3619;
            this.label157.Text = "Threshold";
            this.label157.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJobConnector_Threshold
            // 
            this.txtJobConnector_Threshold.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobConnector_Threshold.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtJobConnector_Threshold.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txtJobConnector_Threshold.ForeColor = System.Drawing.Color.White;
            this.txtJobConnector_Threshold.Location = new System.Drawing.Point(84, 336);
            this.txtJobConnector_Threshold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJobConnector_Threshold.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtJobConnector_Threshold.Name = "txtJobConnector_Threshold";
            this.txtJobConnector_Threshold.Padding = new System.Windows.Forms.Padding(5);
            this.txtJobConnector_Threshold.RectColor = System.Drawing.Color.White;
            this.txtJobConnector_Threshold.ShowText = false;
            this.txtJobConnector_Threshold.Size = new System.Drawing.Size(113, 34);
            this.txtJobConnector_Threshold.Style = Sunny.UI.UIStyle.Custom;
            this.txtJobConnector_Threshold.TabIndex = 3618;
            this.txtJobConnector_Threshold.Text = "0.00";
            this.txtJobConnector_Threshold.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtJobConnector_Threshold.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtJobConnector_Threshold.Watermark = "";
            // 
            // label159
            // 
            this.label159.BackColor = System.Drawing.Color.Transparent;
            this.label159.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label159.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label159.Font = new System.Drawing.Font("Arial", 8F);
            this.label159.ForeColor = System.Drawing.Color.White;
            this.label159.Location = new System.Drawing.Point(84, 277);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(52, 29);
            this.label159.TabIndex = 3617;
            this.label159.Text = "Measure";
            this.label159.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label158
            // 
            this.label158.BackColor = System.Drawing.Color.Transparent;
            this.label158.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label158.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label158.Font = new System.Drawing.Font("Arial", 8F);
            this.label158.ForeColor = System.Drawing.Color.White;
            this.label158.Location = new System.Drawing.Point(84, 247);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(52, 29);
            this.label158.TabIndex = 3616;
            this.label158.Text = "Master";
            this.label158.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox60
            // 
            this.checkBox60.AutoSize = true;
            this.checkBox60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.checkBox60.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox60.ForeColor = System.Drawing.Color.White;
            this.checkBox60.Location = new System.Drawing.Point(9, 252);
            this.checkBox60.Name = "checkBox60";
            this.checkBox60.Size = new System.Drawing.Size(15, 14);
            this.checkBox60.TabIndex = 3615;
            this.checkBox60.UseVisualStyleBackColor = false;
            // 
            // uiSymbolButton70
            // 
            this.uiSymbolButton70.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton70.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton70.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton70.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton70.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton70.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton70.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton70.Location = new System.Drawing.Point(84, 307);
            this.uiSymbolButton70.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton70.Name = "uiSymbolButton70";
            this.uiSymbolButton70.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton70.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton70.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton70.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton70.Size = new System.Drawing.Size(225, 28);
            this.uiSymbolButton70.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton70.StyleCustomMode = true;
            this.uiSymbolButton70.Symbol = 362923;
            this.uiSymbolButton70.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton70.SymbolSize = 16;
            this.uiSymbolButton70.TabIndex = 3614;
            this.uiSymbolButton70.Text = "Roi";
            this.uiSymbolButton70.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label154
            // 
            this.label154.BackColor = System.Drawing.Color.Transparent;
            this.label154.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label154.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label154.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label154.ForeColor = System.Drawing.Color.White;
            this.label154.Location = new System.Drawing.Point(137, 277);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(128, 29);
            this.label154.TabIndex = 3613;
            this.label154.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(266, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 29);
            this.button1.TabIndex = 3612;
            this.button1.Text = "Get";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 9F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(266, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 29);
            this.button2.TabIndex = 3611;
            this.button2.Text = "Get";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // metroComboBox3
            // 
            this.metroComboBox3.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
            this.metroComboBox3.ForeColor = System.Drawing.Color.White;
            this.metroComboBox3.FormattingEnabled = true;
            this.metroComboBox3.ItemHeight = 23;
            this.metroComboBox3.Location = new System.Drawing.Point(137, 247);
            this.metroComboBox3.Name = "metroComboBox3";
            this.metroComboBox3.Size = new System.Drawing.Size(128, 29);
            this.metroComboBox3.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroComboBox3.TabIndex = 3610;
            this.metroComboBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox3.UseCustomForeColor = true;
            this.metroComboBox3.UseSelectable = true;
            // 
            // label152
            // 
            this.label152.BackColor = System.Drawing.Color.Transparent;
            this.label152.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label152.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label152.Font = new System.Drawing.Font("Arial", 8F);
            this.label152.ForeColor = System.Drawing.Color.White;
            this.label152.Location = new System.Drawing.Point(3, 247);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(80, 88);
            this.label152.TabIndex = 3609;
            this.label152.Text = "Color";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label156
            // 
            this.label156.BackColor = System.Drawing.Color.Transparent;
            this.label156.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label156.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label156.Font = new System.Drawing.Font("Arial", 8F);
            this.label156.ForeColor = System.Drawing.Color.White;
            this.label156.Location = new System.Drawing.Point(3, 211);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(80, 35);
            this.label156.TabIndex = 3608;
            this.label156.Text = "Score Min\r\n(0.00 ~ 1.00)";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJobConnector_Score
            // 
            this.txtJobConnector_Score.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobConnector_Score.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtJobConnector_Score.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.txtJobConnector_Score.ForeColor = System.Drawing.Color.White;
            this.txtJobConnector_Score.Location = new System.Drawing.Point(84, 211);
            this.txtJobConnector_Score.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJobConnector_Score.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtJobConnector_Score.Name = "txtJobConnector_Score";
            this.txtJobConnector_Score.Padding = new System.Windows.Forms.Padding(5);
            this.txtJobConnector_Score.RectColor = System.Drawing.Color.White;
            this.txtJobConnector_Score.ShowText = false;
            this.txtJobConnector_Score.Size = new System.Drawing.Size(113, 35);
            this.txtJobConnector_Score.Style = Sunny.UI.UIStyle.Custom;
            this.txtJobConnector_Score.TabIndex = 3607;
            this.txtJobConnector_Score.Text = "0.00";
            this.txtJobConnector_Score.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtJobConnector_Score.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtJobConnector_Score.Watermark = "";
            // 
            // label151
            // 
            this.label151.BackColor = System.Drawing.Color.Transparent;
            this.label151.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label151.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label151.Font = new System.Drawing.Font("Arial", 8F);
            this.label151.ForeColor = System.Drawing.Color.White;
            this.label151.Location = new System.Drawing.Point(3, 175);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(80, 35);
            this.label151.TabIndex = 3606;
            this.label151.Text = "Type";
            this.label151.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel61
            // 
            this.panel61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel61.Controls.Add(this.radioJobConnector_TB);
            this.panel61.Controls.Add(this.radioJobConnector_LR);
            this.panel61.Location = new System.Drawing.Point(84, 175);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(225, 35);
            this.panel61.TabIndex = 3605;
            // 
            // radioJobConnector_TB
            // 
            this.radioJobConnector_TB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioJobConnector_TB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioJobConnector_TB.ForeColor = System.Drawing.Color.White;
            this.radioJobConnector_TB.Location = new System.Drawing.Point(114, 6);
            this.radioJobConnector_TB.MinimumSize = new System.Drawing.Size(1, 1);
            this.radioJobConnector_TB.Name = "radioJobConnector_TB";
            this.radioJobConnector_TB.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.radioJobConnector_TB.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.radioJobConnector_TB.Size = new System.Drawing.Size(55, 21);
            this.radioJobConnector_TB.Style = Sunny.UI.UIStyle.Custom;
            this.radioJobConnector_TB.TabIndex = 3402;
            this.radioJobConnector_TB.Text = "T-B";
            // 
            // radioJobConnector_LR
            // 
            this.radioJobConnector_LR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioJobConnector_LR.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.radioJobConnector_LR.ForeColor = System.Drawing.Color.White;
            this.radioJobConnector_LR.Location = new System.Drawing.Point(45, 6);
            this.radioJobConnector_LR.MinimumSize = new System.Drawing.Size(1, 1);
            this.radioJobConnector_LR.Name = "radioJobConnector_LR";
            this.radioJobConnector_LR.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.radioJobConnector_LR.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.radioJobConnector_LR.Size = new System.Drawing.Size(55, 21);
            this.radioJobConnector_LR.Style = Sunny.UI.UIStyle.Custom;
            this.radioJobConnector_LR.TabIndex = 3401;
            this.radioJobConnector_LR.Text = "L-R";
            // 
            // label153
            // 
            this.label153.BackColor = System.Drawing.Color.Transparent;
            this.label153.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label153.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label153.Font = new System.Drawing.Font("Arial", 9F);
            this.label153.ForeColor = System.Drawing.Color.White;
            this.label153.Location = new System.Drawing.Point(198, 211);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(111, 35);
            this.label153.TabIndex = 3604;
            this.label153.Text = "Count : 0";
            this.label153.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel58
            // 
            this.panel58.Controls.Add(this.cogDisplay_Connector);
            this.panel58.Controls.Add(this.label165);
            this.panel58.Location = new System.Drawing.Point(3, 3);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(208, 171);
            this.panel58.TabIndex = 3600;
            // 
            // cogDisplay_Connector
            // 
            this.cogDisplay_Connector.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Connector.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_Connector.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_Connector.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Connector.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_Connector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay_Connector.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_Connector.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_Connector.Location = new System.Drawing.Point(0, 25);
            this.cogDisplay_Connector.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay_Connector.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_Connector.MouseWheelSensitivity = 1D;
            this.cogDisplay_Connector.Name = "cogDisplay_Connector";
            this.cogDisplay_Connector.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_Connector.OcxState")));
            this.cogDisplay_Connector.Size = new System.Drawing.Size(208, 146);
            this.cogDisplay_Connector.TabIndex = 3301;
            // 
            // label165
            // 
            this.label165.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(77)))), ((int)(((byte)(86)))));
            this.label165.Dock = System.Windows.Forms.DockStyle.Top;
            this.label165.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label165.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label165.ForeColor = System.Drawing.Color.White;
            this.label165.Location = new System.Drawing.Point(0, 0);
            this.label165.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(208, 25);
            this.label165.TabIndex = 3300;
            this.label165.Text = "Pattern";
            this.label165.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobConnector_Roi
            // 
            this.btnJobConnector_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobConnector_Roi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobConnector_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobConnector_Roi.Location = new System.Drawing.Point(212, 3);
            this.btnJobConnector_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobConnector_Roi.Name = "btnJobConnector_Roi";
            this.btnJobConnector_Roi.RectColor = System.Drawing.Color.White;
            this.btnJobConnector_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobConnector_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobConnector_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobConnector_Roi.Size = new System.Drawing.Size(96, 42);
            this.btnJobConnector_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobConnector_Roi.StyleCustomMode = true;
            this.btnJobConnector_Roi.Symbol = 362923;
            this.btnJobConnector_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobConnector_Roi.SymbolSize = 20;
            this.btnJobConnector_Roi.TabIndex = 3601;
            this.btnJobConnector_Roi.Text = "Roi";
            this.btnJobConnector_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnJobConnector_Train
            // 
            this.btnJobConnector_Train.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobConnector_Train.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Train.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Train.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobConnector_Train.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Train.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Train.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobConnector_Train.Location = new System.Drawing.Point(212, 46);
            this.btnJobConnector_Train.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobConnector_Train.Name = "btnJobConnector_Train";
            this.btnJobConnector_Train.RectColor = System.Drawing.Color.White;
            this.btnJobConnector_Train.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobConnector_Train.RectPressColor = System.Drawing.Color.White;
            this.btnJobConnector_Train.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobConnector_Train.Size = new System.Drawing.Size(96, 42);
            this.btnJobConnector_Train.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobConnector_Train.StyleCustomMode = true;
            this.btnJobConnector_Train.Symbol = 108;
            this.btnJobConnector_Train.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobConnector_Train.SymbolSize = 20;
            this.btnJobConnector_Train.TabIndex = 3602;
            this.btnJobConnector_Train.Text = "Train";
            this.btnJobConnector_Train.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnJobConnector_Find
            // 
            this.btnJobConnector_Find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobConnector_Find.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Find.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Find.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobConnector_Find.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Find.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobConnector_Find.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobConnector_Find.Location = new System.Drawing.Point(212, 89);
            this.btnJobConnector_Find.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobConnector_Find.Name = "btnJobConnector_Find";
            this.btnJobConnector_Find.RectColor = System.Drawing.Color.White;
            this.btnJobConnector_Find.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobConnector_Find.RectPressColor = System.Drawing.Color.White;
            this.btnJobConnector_Find.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobConnector_Find.Size = new System.Drawing.Size(96, 42);
            this.btnJobConnector_Find.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobConnector_Find.StyleCustomMode = true;
            this.btnJobConnector_Find.Symbol = 61442;
            this.btnJobConnector_Find.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobConnector_Find.SymbolSize = 20;
            this.btnJobConnector_Find.TabIndex = 3603;
            this.btnJobConnector_Find.Text = "Find";
            this.btnJobConnector_Find.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label164
            // 
            this.label164.BackColor = System.Drawing.Color.Transparent;
            this.label164.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label164.Font = new System.Drawing.Font("Arial", 12F);
            this.label164.ForeColor = System.Drawing.Color.White;
            this.label164.Location = new System.Drawing.Point(191, 445);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(23, 35);
            this.label164.TabIndex = 3634;
            this.label164.Text = "<";
            this.label164.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage31
            // 
            this.tabPage31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage31.Controls.Add(this.panel63);
            this.tabPage31.Controls.Add(this.chk_BlobPos_UseAlign);
            this.tabPage31.Controls.Add(this.panel55);
            this.tabPage31.Controls.Add(this.btnJobPin_Master);
            this.tabPage31.Controls.Add(this.panel53);
            this.tabPage31.Controls.Add(this.panel47);
            this.tabPage31.Controls.Add(this.panel42);
            this.tabPage31.Controls.Add(this.btnJobPin_Roi);
            this.tabPage31.Controls.Add(this.btnJobPin_Find);
            this.tabPage31.Controls.Add(this.panel59);
            this.tabPage31.Location = new System.Drawing.Point(91, 0);
            this.tabPage31.Name = "tabPage31";
            this.tabPage31.Size = new System.Drawing.Size(564, 512);
            this.tabPage31.TabIndex = 8;
            this.tabPage31.Text = "Pin";
            // 
            // panel63
            // 
            this.panel63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel63.Controls.Add(this.lblJobPin_MeasColor);
            this.panel63.Controls.Add(this.lblJobPin_ShapeColor);
            this.panel63.Controls.Add(this.chkJobPin_UseColorMatching);
            this.panel63.Controls.Add(this.label166);
            this.panel63.Location = new System.Drawing.Point(1, 260);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(306, 152);
            this.panel63.TabIndex = 3531;
            // 
            // lblJobPin_MeasColor
            // 
            this.lblJobPin_MeasColor.BackColor = System.Drawing.Color.Transparent;
            this.lblJobPin_MeasColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobPin_MeasColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblJobPin_MeasColor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobPin_MeasColor.ForeColor = System.Drawing.Color.White;
            this.lblJobPin_MeasColor.Location = new System.Drawing.Point(10, 95);
            this.lblJobPin_MeasColor.Name = "lblJobPin_MeasColor";
            this.lblJobPin_MeasColor.Size = new System.Drawing.Size(286, 48);
            this.lblJobPin_MeasColor.TabIndex = 3523;
            this.lblJobPin_MeasColor.Text = "-";
            this.lblJobPin_MeasColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJobPin_ShapeColor
            // 
            this.lblJobPin_ShapeColor.BackColor = System.Drawing.Color.Transparent;
            this.lblJobPin_ShapeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobPin_ShapeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblJobPin_ShapeColor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobPin_ShapeColor.ForeColor = System.Drawing.Color.White;
            this.lblJobPin_ShapeColor.Location = new System.Drawing.Point(10, 40);
            this.lblJobPin_ShapeColor.Name = "lblJobPin_ShapeColor";
            this.lblJobPin_ShapeColor.Size = new System.Drawing.Size(286, 48);
            this.lblJobPin_ShapeColor.TabIndex = 3522;
            this.lblJobPin_ShapeColor.Text = "-";
            this.lblJobPin_ShapeColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkJobPin_UseColorMatching
            // 
            this.chkJobPin_UseColorMatching.AutoSize = true;
            this.chkJobPin_UseColorMatching.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.chkJobPin_UseColorMatching.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJobPin_UseColorMatching.ForeColor = System.Drawing.Color.White;
            this.chkJobPin_UseColorMatching.Location = new System.Drawing.Point(7, 7);
            this.chkJobPin_UseColorMatching.Name = "chkJobPin_UseColorMatching";
            this.chkJobPin_UseColorMatching.Size = new System.Drawing.Size(15, 14);
            this.chkJobPin_UseColorMatching.TabIndex = 3521;
            this.chkJobPin_UseColorMatching.UseVisualStyleBackColor = false;
            // 
            // label166
            // 
            this.label166.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label166.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label166.Dock = System.Windows.Forms.DockStyle.Top;
            this.label166.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label166.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label166.ForeColor = System.Drawing.Color.White;
            this.label166.Location = new System.Drawing.Point(0, 0);
            this.label166.Name = "label166";
            this.label166.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label166.Size = new System.Drawing.Size(304, 27);
            this.label166.TabIndex = 3517;
            this.label166.Text = "    Use Color Compare (Pin Shift CAse)";
            this.label166.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chk_BlobPos_UseAlign
            // 
            this.chk_BlobPos_UseAlign.AutoSize = true;
            this.chk_BlobPos_UseAlign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.chk_BlobPos_UseAlign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_BlobPos_UseAlign.ForeColor = System.Drawing.Color.White;
            this.chk_BlobPos_UseAlign.Location = new System.Drawing.Point(7, 155);
            this.chk_BlobPos_UseAlign.Name = "chk_BlobPos_UseAlign";
            this.chk_BlobPos_UseAlign.Size = new System.Drawing.Size(15, 14);
            this.chk_BlobPos_UseAlign.TabIndex = 3530;
            this.chk_BlobPos_UseAlign.UseVisualStyleBackColor = false;
            this.chk_BlobPos_UseAlign.Visible = false;
            // 
            // panel55
            // 
            this.panel55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel55.Controls.Add(this.label145);
            this.panel55.Location = new System.Drawing.Point(1, 147);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(306, 112);
            this.panel55.TabIndex = 3529;
            this.panel55.Visible = false;
            // 
            // label145
            // 
            this.label145.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label145.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label145.Dock = System.Windows.Forms.DockStyle.Top;
            this.label145.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label145.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label145.ForeColor = System.Drawing.Color.White;
            this.label145.Location = new System.Drawing.Point(0, 0);
            this.label145.Name = "label145";
            this.label145.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label145.Size = new System.Drawing.Size(304, 27);
            this.label145.TabIndex = 3517;
            this.label145.Text = "    Use Alignment";
            this.label145.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnJobPin_Master
            // 
            this.btnJobPin_Master.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPin_Master.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Master.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Master.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Master.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Master.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Master.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPin_Master.Location = new System.Drawing.Point(12, 465);
            this.btnJobPin_Master.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPin_Master.Name = "btnJobPin_Master";
            this.btnJobPin_Master.RectColor = System.Drawing.Color.White;
            this.btnJobPin_Master.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Master.RectPressColor = System.Drawing.Color.White;
            this.btnJobPin_Master.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPin_Master.Size = new System.Drawing.Size(286, 42);
            this.btnJobPin_Master.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPin_Master.StyleCustomMode = true;
            this.btnJobPin_Master.Symbol = 108;
            this.btnJobPin_Master.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPin_Master.SymbolSize = 20;
            this.btnJobPin_Master.TabIndex = 3528;
            this.btnJobPin_Master.Text = "Master";
            this.btnJobPin_Master.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // panel53
            // 
            this.panel53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel53.Controls.Add(this.label144);
            this.panel53.Controls.Add(this.panel54);
            this.panel53.Controls.Add(this.checkBox53);
            this.panel53.Controls.Add(this.checkBox54);
            this.panel53.Location = new System.Drawing.Point(0, 111);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(307, 35);
            this.panel53.TabIndex = 3527;
            // 
            // label144
            // 
            this.label144.BackColor = System.Drawing.Color.Transparent;
            this.label144.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label144.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label144.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label144.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.ForeColor = System.Drawing.Color.White;
            this.label144.Location = new System.Drawing.Point(0, 0);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(97, 33);
            this.label144.TabIndex = 3434;
            this.label144.Text = "Threshold";
            this.label144.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel54
            // 
            this.panel54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel54.Controls.Add(this.chk_Pin_BinaryInv);
            this.panel54.Controls.Add(this.nb_Pin_Threshold);
            this.panel54.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel54.Location = new System.Drawing.Point(97, 0);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(208, 33);
            this.panel54.TabIndex = 3408;
            // 
            // chk_Pin_BinaryInv
            // 
            this.chk_Pin_BinaryInv.AutoSize = true;
            this.chk_Pin_BinaryInv.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Pin_BinaryInv.ForeColor = System.Drawing.Color.White;
            this.chk_Pin_BinaryInv.Location = new System.Drawing.Point(97, 7);
            this.chk_Pin_BinaryInv.Name = "chk_Pin_BinaryInv";
            this.chk_Pin_BinaryInv.Size = new System.Drawing.Size(103, 19);
            this.chk_Pin_BinaryInv.TabIndex = 2772;
            this.chk_Pin_BinaryInv.Text = "Binary Inverter";
            this.chk_Pin_BinaryInv.UseVisualStyleBackColor = true;
            // 
            // nb_Pin_Threshold
            // 
            this.nb_Pin_Threshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nb_Pin_Threshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_Threshold.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_Threshold.ForeColor = System.Drawing.Color.White;
            this.nb_Pin_Threshold.Location = new System.Drawing.Point(0, 0);
            this.nb_Pin_Threshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nb_Pin_Threshold.Name = "nb_Pin_Threshold";
            this.nb_Pin_Threshold.Size = new System.Drawing.Size(90, 30);
            this.nb_Pin_Threshold.TabIndex = 2771;
            this.nb_Pin_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nb_Pin_Threshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox53
            // 
            this.checkBox53.AutoSize = true;
            this.checkBox53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox53.ForeColor = System.Drawing.Color.White;
            this.checkBox53.Location = new System.Drawing.Point(11, 105);
            this.checkBox53.Name = "checkBox53";
            this.checkBox53.Size = new System.Drawing.Size(112, 20);
            this.checkBox53.TabIndex = 1;
            this.checkBox53.Text = "Use \'EYE-D\'";
            this.checkBox53.UseVisualStyleBackColor = true;
            // 
            // checkBox54
            // 
            this.checkBox54.AutoSize = true;
            this.checkBox54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox54.ForeColor = System.Drawing.Color.White;
            this.checkBox54.Location = new System.Drawing.Point(3, 153);
            this.checkBox54.Name = "checkBox54";
            this.checkBox54.Size = new System.Drawing.Size(112, 20);
            this.checkBox54.TabIndex = 0;
            this.checkBox54.Text = "Use \'EYE-D\'";
            this.checkBox54.UseVisualStyleBackColor = true;
            // 
            // panel47
            // 
            this.panel47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel47.Controls.Add(this.label142);
            this.panel47.Controls.Add(this.panel48);
            this.panel47.Controls.Add(this.checkBox51);
            this.panel47.Controls.Add(this.checkBox52);
            this.panel47.Location = new System.Drawing.Point(0, 76);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(307, 35);
            this.panel47.TabIndex = 3526;
            // 
            // label142
            // 
            this.label142.BackColor = System.Drawing.Color.Transparent;
            this.label142.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label142.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label142.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label142.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label142.ForeColor = System.Drawing.Color.White;
            this.label142.Location = new System.Drawing.Point(0, 0);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(97, 33);
            this.label142.TabIndex = 3434;
            this.label142.Text = "Spec Roi\r\n(Width / Height)";
            this.label142.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel48
            // 
            this.panel48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel48.Controls.Add(this.nb_Pin_SpecRoi_Height);
            this.panel48.Controls.Add(this.label143);
            this.panel48.Controls.Add(this.nb_Pin_SpecRoi_Width);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel48.Location = new System.Drawing.Point(97, 0);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(208, 33);
            this.panel48.TabIndex = 3408;
            // 
            // nb_Pin_SpecRoi_Height
            // 
            this.nb_Pin_SpecRoi_Height.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nb_Pin_SpecRoi_Height.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_SpecRoi_Height.Dock = System.Windows.Forms.DockStyle.Right;
            this.nb_Pin_SpecRoi_Height.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_SpecRoi_Height.ForeColor = System.Drawing.Color.White;
            this.nb_Pin_SpecRoi_Height.Location = new System.Drawing.Point(116, 0);
            this.nb_Pin_SpecRoi_Height.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nb_Pin_SpecRoi_Height.Name = "nb_Pin_SpecRoi_Height";
            this.nb_Pin_SpecRoi_Height.Size = new System.Drawing.Size(90, 30);
            this.nb_Pin_SpecRoi_Height.TabIndex = 3427;
            this.nb_Pin_SpecRoi_Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nb_Pin_SpecRoi_Height.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label143
            // 
            this.label143.BackColor = System.Drawing.Color.Transparent;
            this.label143.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label143.Font = new System.Drawing.Font("Arial", 12F);
            this.label143.ForeColor = System.Drawing.Color.White;
            this.label143.Location = new System.Drawing.Point(92, 1);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(21, 29);
            this.label143.TabIndex = 3426;
            this.label143.Text = "/";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nb_Pin_SpecRoi_Width
            // 
            this.nb_Pin_SpecRoi_Width.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nb_Pin_SpecRoi_Width.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_SpecRoi_Width.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_SpecRoi_Width.ForeColor = System.Drawing.Color.White;
            this.nb_Pin_SpecRoi_Width.Location = new System.Drawing.Point(0, 0);
            this.nb_Pin_SpecRoi_Width.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nb_Pin_SpecRoi_Width.Name = "nb_Pin_SpecRoi_Width";
            this.nb_Pin_SpecRoi_Width.Size = new System.Drawing.Size(90, 30);
            this.nb_Pin_SpecRoi_Width.TabIndex = 2771;
            this.nb_Pin_SpecRoi_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nb_Pin_SpecRoi_Width.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // checkBox51
            // 
            this.checkBox51.AutoSize = true;
            this.checkBox51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox51.ForeColor = System.Drawing.Color.White;
            this.checkBox51.Location = new System.Drawing.Point(11, 105);
            this.checkBox51.Name = "checkBox51";
            this.checkBox51.Size = new System.Drawing.Size(112, 20);
            this.checkBox51.TabIndex = 1;
            this.checkBox51.Text = "Use \'EYE-D\'";
            this.checkBox51.UseVisualStyleBackColor = true;
            // 
            // checkBox52
            // 
            this.checkBox52.AutoSize = true;
            this.checkBox52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox52.ForeColor = System.Drawing.Color.White;
            this.checkBox52.Location = new System.Drawing.Point(3, 153);
            this.checkBox52.Name = "checkBox52";
            this.checkBox52.Size = new System.Drawing.Size(112, 20);
            this.checkBox52.TabIndex = 0;
            this.checkBox52.Text = "Use \'EYE-D\'";
            this.checkBox52.UseVisualStyleBackColor = true;
            // 
            // panel42
            // 
            this.panel42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel42.Controls.Add(this.label139);
            this.panel42.Controls.Add(this.panel44);
            this.panel42.Controls.Add(this.checkBox49);
            this.panel42.Controls.Add(this.checkBox50);
            this.panel42.Location = new System.Drawing.Point(0, 41);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(307, 35);
            this.panel42.TabIndex = 3525;
            // 
            // label139
            // 
            this.label139.BackColor = System.Drawing.Color.Transparent;
            this.label139.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label139.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label139.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label139.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.ForeColor = System.Drawing.Color.White;
            this.label139.Location = new System.Drawing.Point(0, 0);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(97, 33);
            this.label139.TabIndex = 3434;
            this.label139.Text = "Area\r\n( Min ~ Max )";
            this.label139.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel44
            // 
            this.panel44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel44.Controls.Add(this.nb_Pin_AreaMax);
            this.panel44.Controls.Add(this.label141);
            this.panel44.Controls.Add(this.nb_Pin_AreaMin);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel44.Location = new System.Drawing.Point(97, 0);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(208, 33);
            this.panel44.TabIndex = 3408;
            // 
            // nb_Pin_AreaMax
            // 
            this.nb_Pin_AreaMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nb_Pin_AreaMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_AreaMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.nb_Pin_AreaMax.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_AreaMax.ForeColor = System.Drawing.Color.White;
            this.nb_Pin_AreaMax.Location = new System.Drawing.Point(116, 0);
            this.nb_Pin_AreaMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nb_Pin_AreaMax.Name = "nb_Pin_AreaMax";
            this.nb_Pin_AreaMax.Size = new System.Drawing.Size(90, 30);
            this.nb_Pin_AreaMax.TabIndex = 3427;
            this.nb_Pin_AreaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nb_Pin_AreaMax.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label141
            // 
            this.label141.BackColor = System.Drawing.Color.Transparent;
            this.label141.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label141.Font = new System.Drawing.Font("Arial", 12F);
            this.label141.ForeColor = System.Drawing.Color.White;
            this.label141.Location = new System.Drawing.Point(92, 1);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(21, 29);
            this.label141.TabIndex = 3426;
            this.label141.Text = "~";
            this.label141.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nb_Pin_AreaMin
            // 
            this.nb_Pin_AreaMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nb_Pin_AreaMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_AreaMin.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_AreaMin.ForeColor = System.Drawing.Color.White;
            this.nb_Pin_AreaMin.Location = new System.Drawing.Point(0, 0);
            this.nb_Pin_AreaMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nb_Pin_AreaMin.Name = "nb_Pin_AreaMin";
            this.nb_Pin_AreaMin.Size = new System.Drawing.Size(90, 30);
            this.nb_Pin_AreaMin.TabIndex = 2771;
            this.nb_Pin_AreaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nb_Pin_AreaMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBox49
            // 
            this.checkBox49.AutoSize = true;
            this.checkBox49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox49.ForeColor = System.Drawing.Color.White;
            this.checkBox49.Location = new System.Drawing.Point(11, 105);
            this.checkBox49.Name = "checkBox49";
            this.checkBox49.Size = new System.Drawing.Size(112, 20);
            this.checkBox49.TabIndex = 1;
            this.checkBox49.Text = "Use \'EYE-D\'";
            this.checkBox49.UseVisualStyleBackColor = true;
            // 
            // checkBox50
            // 
            this.checkBox50.AutoSize = true;
            this.checkBox50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox50.ForeColor = System.Drawing.Color.White;
            this.checkBox50.Location = new System.Drawing.Point(3, 153);
            this.checkBox50.Name = "checkBox50";
            this.checkBox50.Size = new System.Drawing.Size(112, 20);
            this.checkBox50.TabIndex = 0;
            this.checkBox50.Text = "Use \'EYE-D\'";
            this.checkBox50.UseVisualStyleBackColor = true;
            // 
            // btnJobPin_Roi
            // 
            this.btnJobPin_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPin_Roi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPin_Roi.Location = new System.Drawing.Point(12, 418);
            this.btnJobPin_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPin_Roi.Name = "btnJobPin_Roi";
            this.btnJobPin_Roi.RectColor = System.Drawing.Color.White;
            this.btnJobPin_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobPin_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPin_Roi.Size = new System.Drawing.Size(140, 42);
            this.btnJobPin_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPin_Roi.StyleCustomMode = true;
            this.btnJobPin_Roi.Symbol = 362923;
            this.btnJobPin_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPin_Roi.SymbolSize = 16;
            this.btnJobPin_Roi.TabIndex = 3524;
            this.btnJobPin_Roi.Text = "Roi";
            this.btnJobPin_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnJobPin_Find
            // 
            this.btnJobPin_Find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPin_Find.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Find.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Find.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Find.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Find.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Find.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPin_Find.Location = new System.Drawing.Point(158, 418);
            this.btnJobPin_Find.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPin_Find.Name = "btnJobPin_Find";
            this.btnJobPin_Find.RectColor = System.Drawing.Color.White;
            this.btnJobPin_Find.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Find.RectPressColor = System.Drawing.Color.White;
            this.btnJobPin_Find.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPin_Find.Size = new System.Drawing.Size(140, 42);
            this.btnJobPin_Find.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPin_Find.StyleCustomMode = true;
            this.btnJobPin_Find.Symbol = 61442;
            this.btnJobPin_Find.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPin_Find.SymbolSize = 20;
            this.btnJobPin_Find.TabIndex = 3523;
            this.btnJobPin_Find.Text = "Find";
            this.btnJobPin_Find.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // panel59
            // 
            this.panel59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel59.Controls.Add(this.label146);
            this.panel59.Controls.Add(this.panel60);
            this.panel59.Controls.Add(this.checkBox71);
            this.panel59.Controls.Add(this.checkBox72);
            this.panel59.Location = new System.Drawing.Point(0, 6);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(307, 35);
            this.panel59.TabIndex = 3522;
            // 
            // label146
            // 
            this.label146.BackColor = System.Drawing.Color.Transparent;
            this.label146.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label146.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label146.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label146.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label146.ForeColor = System.Drawing.Color.White;
            this.label146.Location = new System.Drawing.Point(0, 0);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(97, 33);
            this.label146.TabIndex = 3434;
            this.label146.Text = "OK Count";
            this.label146.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel60
            // 
            this.panel60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel60.Controls.Add(this.nb_Pin_OkCount);
            this.panel60.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel60.Location = new System.Drawing.Point(97, 0);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(208, 33);
            this.panel60.TabIndex = 3408;
            // 
            // nb_Pin_OkCount
            // 
            this.nb_Pin_OkCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nb_Pin_OkCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_OkCount.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_OkCount.ForeColor = System.Drawing.Color.White;
            this.nb_Pin_OkCount.Location = new System.Drawing.Point(0, 0);
            this.nb_Pin_OkCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nb_Pin_OkCount.Name = "nb_Pin_OkCount";
            this.nb_Pin_OkCount.Size = new System.Drawing.Size(206, 30);
            this.nb_Pin_OkCount.TabIndex = 2771;
            this.nb_Pin_OkCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nb_Pin_OkCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox71
            // 
            this.checkBox71.AutoSize = true;
            this.checkBox71.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox71.ForeColor = System.Drawing.Color.White;
            this.checkBox71.Location = new System.Drawing.Point(11, 105);
            this.checkBox71.Name = "checkBox71";
            this.checkBox71.Size = new System.Drawing.Size(112, 20);
            this.checkBox71.TabIndex = 1;
            this.checkBox71.Text = "Use \'EYE-D\'";
            this.checkBox71.UseVisualStyleBackColor = true;
            // 
            // checkBox72
            // 
            this.checkBox72.AutoSize = true;
            this.checkBox72.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox72.ForeColor = System.Drawing.Color.White;
            this.checkBox72.Location = new System.Drawing.Point(3, 153);
            this.checkBox72.Name = "checkBox72";
            this.checkBox72.Size = new System.Drawing.Size(112, 20);
            this.checkBox72.TabIndex = 0;
            this.checkBox72.Text = "Use \'EYE-D\'";
            this.checkBox72.UseVisualStyleBackColor = true;
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
            // DgvLogicList
            // 
            this.DgvLogicList.AllowUserToAddRows = false;
            this.DgvLogicList.AllowUserToDeleteRows = false;
            this.DgvLogicList.AllowUserToResizeColumns = false;
            this.DgvLogicList.AllowUserToResizeRows = false;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Yellow;
            this.DgvLogicList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle23;
            this.DgvLogicList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DgvLogicList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLogicList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.DgvLogicList.ColumnHeadersHeight = 25;
            this.DgvLogicList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvLogicList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewTextBoxColumn8,
            this.Column4});
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvLogicList.DefaultCellStyle = dataGridViewCellStyle25;
            this.DgvLogicList.EnableHeadersVisualStyles = false;
            this.DgvLogicList.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DgvLogicList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DgvLogicList.Location = new System.Drawing.Point(283, 361);
            this.DgvLogicList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvLogicList.MultiSelect = false;
            this.DgvLogicList.Name = "DgvLogicList";
            this.DgvLogicList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvLogicList.RowHeadersVisible = false;
            this.DgvLogicList.RowHeadersWidth = 51;
            this.DgvLogicList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvLogicList.RowTemplate.Height = 23;
            this.DgvLogicList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLogicList.Size = new System.Drawing.Size(263, 390);
            this.DgvLogicList.TabIndex = 3682;
            this.DgvLogicList.SelectionChanged += new System.EventHandler(this.DgvLogicList_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "No";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.Width = 25;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn3.HeaderText = "Enabled";
            this.dataGridViewCheckBoxColumn3.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn3.Width = 68;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.FillWeight = 50F;
            this.dataGridViewTextBoxColumn8.HeaderText = "LogicName";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "Algorithm";
            this.Column4.Name = "Column4";
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
            // BtnLogicAdd
            // 
            this.BtnLogicAdd.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.CircleRectWidth = 0;
            this.BtnLogicAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogicAdd.FillColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnLogicAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicAdd.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.ForeHoverColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogicAdd.Location = new System.Drawing.Point(338, 332);
            this.BtnLogicAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnLogicAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnLogicAdd.Name = "BtnLogicAdd";
            this.BtnLogicAdd.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnLogicAdd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicAdd.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.RectHoverColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.Size = new System.Drawing.Size(55, 24);
            this.BtnLogicAdd.Style = Sunny.UI.UIStyle.Custom;
            this.BtnLogicAdd.StyleCustomMode = true;
            this.BtnLogicAdd.Symbol = 61543;
            this.BtnLogicAdd.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicAdd.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.BtnLogicAdd.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnLogicAdd.SymbolSize = 16;
            this.BtnLogicAdd.TabIndex = 3674;
            this.BtnLogicAdd.Tag = "ZoomIn";
            this.BtnLogicAdd.Text = "Add";
            this.BtnLogicAdd.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnLogicAdd.Click += new System.EventHandler(this.BtnLogicAdd_Click);
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
            // BtnSettingLogic
            // 
            this.BtnSettingLogic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSettingLogic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingLogic.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnSettingLogic.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingLogic.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnSettingLogic.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnSettingLogic.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSettingLogic.Location = new System.Drawing.Point(501, 135);
            this.BtnSettingLogic.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnSettingLogic.Name = "BtnSettingLogic";
            this.BtnSettingLogic.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingLogic.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingLogic.RectPressColor = System.Drawing.Color.White;
            this.BtnSettingLogic.RectSelectedColor = System.Drawing.Color.White;
            this.BtnSettingLogic.Size = new System.Drawing.Size(45, 53);
            this.BtnSettingLogic.Style = Sunny.UI.UIStyle.Custom;
            this.BtnSettingLogic.StyleCustomMode = true;
            this.BtnSettingLogic.SymbolSize = 16;
            this.BtnSettingLogic.TabIndex = 3658;
            this.BtnSettingLogic.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSettingLogic.Click += new System.EventHandler(this.BtnSettingLogic_Click);
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
            // tbLogicName
            // 
            this.tbLogicName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbLogicName.FillColor = System.Drawing.SystemColors.Control;
            this.tbLogicName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLogicName.ForeColor = System.Drawing.Color.Black;
            this.tbLogicName.Location = new System.Drawing.Point(374, 135);
            this.tbLogicName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbLogicName.MinimumSize = new System.Drawing.Size(1, 20);
            this.tbLogicName.Name = "tbLogicName";
            this.tbLogicName.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbLogicName.RectColor = System.Drawing.Color.DimGray;
            this.tbLogicName.ShowText = false;
            this.tbLogicName.Size = new System.Drawing.Size(125, 25);
            this.tbLogicName.TabIndex = 3655;
            this.tbLogicName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbLogicName.Watermark = "";
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
            // DgvJobList
            // 
            this.DgvJobList.AllowUserToAddRows = false;
            this.DgvJobList.AllowUserToDeleteRows = false;
            this.DgvJobList.AllowUserToResizeColumns = false;
            this.DgvJobList.AllowUserToResizeRows = false;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Yellow;
            this.DgvJobList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            this.DgvJobList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DgvJobList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvJobList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.DgvJobList.ColumnHeadersHeight = 25;
            this.DgvJobList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvJobList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.gridLibraryName,
            this.gridLibraryEnabled});
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvJobList.DefaultCellStyle = dataGridViewCellStyle28;
            this.DgvJobList.EnableHeadersVisualStyles = false;
            this.DgvJobList.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DgvJobList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DgvJobList.Location = new System.Drawing.Point(1, 29);
            this.DgvJobList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvJobList.MultiSelect = false;
            this.DgvJobList.Name = "DgvJobList";
            this.DgvJobList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvJobList.RowHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.DgvJobList.RowHeadersVisible = false;
            this.DgvJobList.RowHeadersWidth = 51;
            this.DgvJobList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvJobList.RowTemplate.Height = 23;
            this.DgvJobList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvJobList.Size = new System.Drawing.Size(278, 751);
            this.DgvJobList.TabIndex = 3639;
            this.DgvJobList.SelectionChanged += new System.EventHandler(this.DgvJobList_SelectionChanged);
            // 
            // No
            // 
            this.No.HeaderText = "Location No";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.Width = 75;
            // 
            // gridLibraryName
            // 
            this.gridLibraryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridLibraryName.HeaderText = "Enabled";
            this.gridLibraryName.MinimumWidth = 6;
            this.gridLibraryName.Name = "gridLibraryName";
            this.gridLibraryName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLibraryName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridLibraryName.Width = 68;
            // 
            // gridLibraryEnabled
            // 
            this.gridLibraryEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridLibraryEnabled.HeaderText = "Part Code";
            this.gridLibraryEnabled.MinimumWidth = 6;
            this.gridLibraryEnabled.Name = "gridLibraryEnabled";
            this.gridLibraryEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLibraryEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // cbAlgorithm
            // 
            this.cbAlgorithm.DataSource = null;
            this.cbAlgorithm.FillColor = System.Drawing.SystemColors.Control;
            this.cbAlgorithm.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.cbAlgorithm.ForeColor = System.Drawing.Color.Black;
            this.cbAlgorithm.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbAlgorithm.ItemForeColor = System.Drawing.Color.White;
            this.cbAlgorithm.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.cbAlgorithm.Items.AddRange(new object[] {
            "Pattern",
            "Blob",
            "Distance",
            "EYE-D",
            "Color",
            "ColorEx",
            "Condensor",
            "Connector",
            "Pin"});
            this.cbAlgorithm.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.cbAlgorithm.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbAlgorithm.Location = new System.Drawing.Point(374, 163);
            this.cbAlgorithm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAlgorithm.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbAlgorithm.Name = "cbAlgorithm";
            this.cbAlgorithm.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbAlgorithm.RectColor = System.Drawing.Color.DimGray;
            this.cbAlgorithm.Size = new System.Drawing.Size(125, 25);
            this.cbAlgorithm.SymbolSize = 24;
            this.cbAlgorithm.TabIndex = 3659;
            this.cbAlgorithm.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbAlgorithm.Watermark = "";
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
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView5.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle40;
            this.uiDataGridView5.BackgroundColor = System.Drawing.Color.Silver;
            this.uiDataGridView5.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
            this.uiDataGridView5.ColumnHeadersHeight = 20;
            this.uiDataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView5.DefaultCellStyle = dataGridViewCellStyle42;
            this.uiDataGridView5.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uiDataGridView5.EnableHeadersVisualStyles = false;
            this.uiDataGridView5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiDataGridView5.GridColor = System.Drawing.Color.Silver;
            this.uiDataGridView5.Location = new System.Drawing.Point(4, 4);
            this.uiDataGridView5.MultiSelect = false;
            this.uiDataGridView5.Name = "uiDataGridView5";
            this.uiDataGridView5.ReadOnly = true;
            this.uiDataGridView5.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle43.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView5.RowHeadersDefaultCellStyle = dataGridViewCellStyle43;
            this.uiDataGridView5.RowHeadersVisible = false;
            this.uiDataGridView5.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView5.RowsDefaultCellStyle = dataGridViewCellStyle44;
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // metroContextMenu1
            // 
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 512);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.label87, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label85, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TbThresholdEYED, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label55, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label39, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TbOnnxPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnOpenOnnx, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CbRotateImageEYED, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LblResultEYED, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.BtnFindEYED, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.BtnRoiEYED, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(564, 512);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label39.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(0, 5);
            this.label39.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(187, 35);
            this.label39.TabIndex = 0;
            this.label39.Text = "Model Path";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbOnnxPath
            // 
            this.TbOnnxPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbOnnxPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbOnnxPath.FillColor = System.Drawing.Color.Black;
            this.TbOnnxPath.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.TbOnnxPath.ForeColor = System.Drawing.Color.White;
            this.TbOnnxPath.Location = new System.Drawing.Point(189, 5);
            this.TbOnnxPath.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.TbOnnxPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbOnnxPath.Name = "TbOnnxPath";
            this.TbOnnxPath.Padding = new System.Windows.Forms.Padding(5);
            this.TbOnnxPath.RectColor = System.Drawing.Color.White;
            this.TbOnnxPath.ShowText = false;
            this.TbOnnxPath.Size = new System.Drawing.Size(184, 35);
            this.TbOnnxPath.TabIndex = 1;
            this.TbOnnxPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TbOnnxPath.Watermark = "";
            // 
            // BtnOpenOnnx
            // 
            this.BtnOpenOnnx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOpenOnnx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOpenOnnx.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BtnOpenOnnx.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnOpenOnnx.Location = new System.Drawing.Point(375, 5);
            this.BtnOpenOnnx.Margin = new System.Windows.Forms.Padding(0, 5, 2, 5);
            this.BtnOpenOnnx.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnOpenOnnx.Name = "BtnOpenOnnx";
            this.BtnOpenOnnx.RectColor = System.Drawing.Color.White;
            this.BtnOpenOnnx.Size = new System.Drawing.Size(187, 35);
            this.BtnOpenOnnx.Symbol = 61717;
            this.BtnOpenOnnx.TabIndex = 2;
            this.BtnOpenOnnx.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label55.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label55.ForeColor = System.Drawing.Color.White;
            this.label55.Location = new System.Drawing.Point(0, 50);
            this.label55.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(187, 35);
            this.label55.TabIndex = 3;
            this.label55.Text = "Score (OK) Minimum";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbThresholdEYED
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TbThresholdEYED, 2);
            this.TbThresholdEYED.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbThresholdEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbThresholdEYED.DoubleValue = 1D;
            this.TbThresholdEYED.FillColor = System.Drawing.Color.Black;
            this.TbThresholdEYED.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.TbThresholdEYED.ForeColor = System.Drawing.Color.White;
            this.TbThresholdEYED.Location = new System.Drawing.Point(189, 50);
            this.TbThresholdEYED.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.TbThresholdEYED.Maximum = 1D;
            this.TbThresholdEYED.Minimum = 0D;
            this.TbThresholdEYED.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbThresholdEYED.Name = "TbThresholdEYED";
            this.TbThresholdEYED.Padding = new System.Windows.Forms.Padding(5);
            this.TbThresholdEYED.RectColor = System.Drawing.Color.White;
            this.TbThresholdEYED.ShowText = false;
            this.TbThresholdEYED.Size = new System.Drawing.Size(373, 35);
            this.TbThresholdEYED.TabIndex = 4;
            this.TbThresholdEYED.Text = "1.00";
            this.TbThresholdEYED.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TbThresholdEYED.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.TbThresholdEYED.Watermark = "";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label85.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label85.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label85.ForeColor = System.Drawing.Color.White;
            this.label85.Location = new System.Drawing.Point(0, 95);
            this.label85.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(187, 35);
            this.label85.TabIndex = 5;
            this.label85.Text = "Rotate Image";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CbRotateImageEYED
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CbRotateImageEYED, 2);
            this.CbRotateImageEYED.DataSource = null;
            this.CbRotateImageEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CbRotateImageEYED.FillColor = System.Drawing.Color.Black;
            this.CbRotateImageEYED.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.CbRotateImageEYED.ForeColor = System.Drawing.Color.White;
            this.CbRotateImageEYED.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CbRotateImageEYED.ItemForeColor = System.Drawing.Color.White;
            this.CbRotateImageEYED.ItemHoverColor = System.Drawing.Color.Gray;
            this.CbRotateImageEYED.ItemRectColor = System.Drawing.Color.White;
            this.CbRotateImageEYED.ItemSelectBackColor = System.Drawing.Color.Gray;
            this.CbRotateImageEYED.ItemSelectForeColor = System.Drawing.Color.White;
            this.CbRotateImageEYED.Location = new System.Drawing.Point(189, 95);
            this.CbRotateImageEYED.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.CbRotateImageEYED.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbRotateImageEYED.Name = "CbRotateImageEYED";
            this.CbRotateImageEYED.Padding = new System.Windows.Forms.Padding(5, 0, 30, 2);
            this.CbRotateImageEYED.RectColor = System.Drawing.Color.White;
            this.CbRotateImageEYED.Size = new System.Drawing.Size(373, 35);
            this.CbRotateImageEYED.SymbolSize = 24;
            this.CbRotateImageEYED.TabIndex = 6;
            this.CbRotateImageEYED.Text = "0";
            this.CbRotateImageEYED.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbRotateImageEYED.Watermark = "";
            // 
            // BtnRoiEYED
            // 
            this.BtnRoiEYED.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRoiEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRoiEYED.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnRoiEYED.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnRoiEYED.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRoiEYED.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnRoiEYED.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnRoiEYED.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRoiEYED.Location = new System.Drawing.Point(190, 228);
            this.BtnRoiEYED.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnRoiEYED.Name = "BtnRoiEYED";
            this.BtnRoiEYED.RectColor = System.Drawing.Color.White;
            this.BtnRoiEYED.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRoiEYED.RectPressColor = System.Drawing.Color.White;
            this.BtnRoiEYED.RectSelectedColor = System.Drawing.Color.White;
            this.BtnRoiEYED.Size = new System.Drawing.Size(182, 39);
            this.BtnRoiEYED.Style = Sunny.UI.UIStyle.Custom;
            this.BtnRoiEYED.StyleCustomMode = true;
            this.BtnRoiEYED.Symbol = 362923;
            this.BtnRoiEYED.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnRoiEYED.SymbolSize = 20;
            this.BtnRoiEYED.TabIndex = 3542;
            this.BtnRoiEYED.Text = "Roi";
            this.BtnRoiEYED.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // BtnFindEYED
            // 
            this.BtnFindEYED.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFindEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFindEYED.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnFindEYED.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnFindEYED.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnFindEYED.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnFindEYED.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnFindEYED.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFindEYED.Location = new System.Drawing.Point(378, 228);
            this.BtnFindEYED.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnFindEYED.Name = "BtnFindEYED";
            this.BtnFindEYED.RectColor = System.Drawing.Color.White;
            this.BtnFindEYED.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnFindEYED.RectPressColor = System.Drawing.Color.White;
            this.BtnFindEYED.RectSelectedColor = System.Drawing.Color.White;
            this.BtnFindEYED.Size = new System.Drawing.Size(183, 39);
            this.BtnFindEYED.Style = Sunny.UI.UIStyle.Custom;
            this.BtnFindEYED.StyleCustomMode = true;
            this.BtnFindEYED.Symbol = 61442;
            this.BtnFindEYED.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnFindEYED.SymbolSize = 20;
            this.BtnFindEYED.TabIndex = 3544;
            this.BtnFindEYED.Text = "Find";
            this.BtnFindEYED.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 3);
            this.panel3.Controls.Add(this.ChkSpecRegionEYED);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 136);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 1, 2, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(562, 43);
            this.panel3.TabIndex = 3545;
            // 
            // ChkSpecRegionEYED
            // 
            this.ChkSpecRegionEYED.AutoSize = true;
            this.ChkSpecRegionEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkSpecRegionEYED.Font = new System.Drawing.Font("Arial", 9.75F);
            this.ChkSpecRegionEYED.ForeColor = System.Drawing.Color.White;
            this.ChkSpecRegionEYED.Location = new System.Drawing.Point(0, 0);
            this.ChkSpecRegionEYED.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.ChkSpecRegionEYED.Name = "ChkSpecRegionEYED";
            this.ChkSpecRegionEYED.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ChkSpecRegionEYED.Size = new System.Drawing.Size(558, 39);
            this.ChkSpecRegionEYED.TabIndex = 0;
            this.ChkSpecRegionEYED.Text = "     Use Spec Region (Color : Orange)";
            this.ChkSpecRegionEYED.UseVisualStyleBackColor = true;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label87.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label87.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label87.ForeColor = System.Drawing.Color.White;
            this.label87.Location = new System.Drawing.Point(0, 185);
            this.label87.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(187, 35);
            this.label87.TabIndex = 3546;
            this.label87.Text = "Result";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblResultEYED
            // 
            this.LblResultEYED.AutoSize = true;
            this.LblResultEYED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.LblResultEYED, 2);
            this.LblResultEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblResultEYED.ForeColor = System.Drawing.Color.White;
            this.LblResultEYED.Location = new System.Drawing.Point(189, 185);
            this.LblResultEYED.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.LblResultEYED.Name = "LblResultEYED";
            this.LblResultEYED.Size = new System.Drawing.Size(373, 35);
            this.LblResultEYED.TabIndex = 3546;
            this.LblResultEYED.Text = "-";
            this.LblResultEYED.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.uiGroupBox12.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.uiTabControl6.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.uiGroupBox18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGerberInfo)).EndInit();
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
            this.tabPage5.ResumeLayout(false);
            this.uiTabControl4.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.uiTabControlMenu1.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_JobPattern)).EndInit();
            this.tabPage18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CogDisplay_FinMatchingTemplateImg)).EndInit();
            this.panel15.ResumeLayout(false);
            this.tabPage19.ResumeLayout(false);
            this.tabPage19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDistanceSamplingCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDistanceThickness)).EndInit();
            this.tabPage26.ResumeLayout(false);
            this.tabPage27.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.tabPage28.ResumeLayout(false);
            this.tabPage28.PerformLayout();
            this.panel64.ResumeLayout(false);
            this.panel64.PerformLayout();
            this.tabPage29.ResumeLayout(false);
            this.tabPage29.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.tabPage30.ResumeLayout(false);
            this.tabPage30.PerformLayout();
            this.panel62.ResumeLayout(false);
            this.panel61.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Connector)).EndInit();
            this.tabPage31.ResumeLayout(false);
            this.tabPage31.PerformLayout();
            this.panel63.ResumeLayout(false);
            this.panel63.PerformLayout();
            this.panel55.ResumeLayout(false);
            this.panel53.ResumeLayout(false);
            this.panel53.PerformLayout();
            this.panel54.ResumeLayout(false);
            this.panel54.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_Threshold)).EndInit();
            this.panel47.ResumeLayout(false);
            this.panel47.PerformLayout();
            this.panel48.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_SpecRoi_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_SpecRoi_Width)).EndInit();
            this.panel42.ResumeLayout(false);
            this.panel42.PerformLayout();
            this.panel44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_AreaMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_AreaMin)).EndInit();
            this.panel59.ResumeLayout(false);
            this.panel59.PerformLayout();
            this.panel60.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nb_Pin_OkCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLogicList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvJobList)).EndInit();
            this.tabPage15.ResumeLayout(false);
            this.uiTabControl7.ResumeLayout(false);
            this.tabPage16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private Sunny.UI.UITextBox tbPixelSize;
        private Sunny.UI.UITextBox tbMasterWidth;
        private Label label34;
        private Label label35;
        private TabPage tabPage10;
        private Sunny.UI.UIGroupBox uiGroupBox13;
        private Sunny.UI.UITextBox uiTextBox41;
        private Label label67;
        private Sunny.UI.UILine uiLine17;
        private Label lbCurrentFocusValue;
        private Label lbBestFocusValue;
        private Sunny.UI.UISymbolButton btnIQStop;
        private Sunny.UI.UISymbolButton btnIQStart;
        private Sunny.UI.UITextBox tbMasterHeight;
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
        private CheckBox ChkEnable5;
        private Sunny.UI.UITextBox TbExposure5;
        private Sunny.UI.UILine uiLine12;
        private Label label46;
        private Sunny.UI.UITextBox TbLight4;
        private Label label47;
        private Sunny.UI.UITextBox TbGain4;
        private Label label48;
        private CheckBox ChkEnable4;
        private Sunny.UI.UITextBox TbExposure4;
        private Sunny.UI.UILine uiLine10;
        private Label label49;
        private Sunny.UI.UITextBox TbLight3;
        private Label label50;
        private Sunny.UI.UITextBox TbGain3;
        private Label label51;
        private CheckBox ChkEnable3;
        private Sunny.UI.UITextBox TbExposure3;
        private Sunny.UI.UILine uiLine11;
        private Label label40;
        private Sunny.UI.UITextBox TbLight2;
        private Label label41;
        private Sunny.UI.UITextBox TbGain2;
        private Label label45;
        private CheckBox ChkEnable2;
        private Sunny.UI.UITextBox TbExposure2;
        private Sunny.UI.UILine uiLine9;
        private Label label44;
        private Sunny.UI.UITextBox TbLight1;
        private Label label43;
        private Sunny.UI.UITextBox TbGain1;
        private Label label42;
        private CheckBox ChkEnable1;
        private Sunny.UI.UISymbolButton BtnIQHWApply;
        private Sunny.UI.UITextBox TbExposure1;
        private Sunny.UI.UILine uiLine8;
        private Sunny.UI.UIGroupBox uiGroupBox18;
        private Sunny.UI.UITextBox TbGerberPath;
        private Label label59;
        private Sunny.UI.UIGroupBox uiGroupBox15;
        private Sunny.UI.UITextBox uiTextBox33;
        private Label label63;
        private Sunny.UI.UIGroupBox uiGroupBox17;
        private Sunny.UI.UIComboBox uiComboBox5;
        private Sunny.UI.UISymbolButton uiSymbolButton51;
        private Sunny.UI.UISymbolButton uiSymbolButton52;
        private Label label60;
        private Sunny.UI.UISymbolButton BtnRegionVisible;
        private Sunny.UI.UIDataGridView DgvGerberInfo;
        private Sunny.UI.UISymbolButton BtnGerberLoad;
        private Sunny.UI.UISymbolButton uiSymbolButton54;
        private Sunny.UI.UISymbolButton uiSymbolButton55;
        private Sunny.UI.UISymbolButton uiSymbolButton53;
        private Sunny.UI.UISymbolButton uiSymbolButton50;
        private Sunny.UI.UISymbolButton BtnReplaceLibrary;
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
        private Sunny.UI.UISymbolButton uiSymbolButton56;
        private Sunny.UI.UISymbolButton uiSymbolButton46;
        private Sunny.UI.UISymbolButton uiSymbolButton45;
        public DataGridView DgvJobList;
        private Sunny.UI.UISymbolButton uiSymbolButton36;
        private Sunny.UI.UISymbolButton uiSymbolButton22;
        private Sunny.UI.UISymbolButton uiSymbolButton37;
        private CheckBox checkBox7;
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
        private Sunny.UI.UISymbolButton BtnSettingLogic;
        private Label label18;
        private Sunny.UI.UITextBox tbLogicName;
        private Label label19;
        private Sunny.UI.UIComboBox cbAlgorithm;
        private Sunny.UI.UILine uiLine25;
        private Sunny.UI.UISymbolButton uiSymbolButton59;
        private Sunny.UI.UISymbolButton uiSymbolButton63;
        private Label label25;
        private Label label24;
        private CheckBox checkBox8;
        private Sunny.UI.UISymbolButton uiSymbolButton60;
        private Sunny.UI.UISymbolButton uiSymbolButton61;
        private Sunny.UI.UISymbolButton BtnLogicAdd;
        private Label label7;
        private Label label89;
        private Sunny.UI.UIComboBox CbTriggerMode;
        private Sunny.UI.UISymbolButton uiSymbolButton28;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn No;
        private DataGridViewCheckBoxColumn gridLibraryName;
        private DataGridViewTextBoxColumn gridLibraryEnabled;
        public DataGridView DgvLogicList;
        private Sunny.UI.UITabControl uiTabControl3;
        private TabPage tabPage4;
        private Label label90;
        private Label label76;
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
        private Label label8;
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
        private TabPage tabPage5;
        private Sunny.UI.UITabControl uiTabControl4;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage6;
        private Sunny.UI.UITabControlMenu uiTabControlMenu1;
        private TabPage tabPage11;
        private Sunny.UI.UITextBox tbJobPattern_AcceptScore;
        private Sunny.UI.UITextBox tbJobPattern_MinScore;
        private Sunny.UI.UITextBox tbPatternMasterCount;
        private Label label137;
        private Label lblDetectedPatternCount;
        private Sunny.UI.UISymbolButton btnJobPatternDelete;
        private MetroFramework.Controls.MetroComboBox comboJobPattern_PatternType;
        private Label lblTrained;
        private Label label100;
        private Label label69;
        private Sunny.UI.UISymbolButton uiSymbolButton12;
        private Label label70;
        private Label label71;
        private Sunny.UI.UISymbolButton btnJobPattern_Roi;
        private Sunny.UI.UISymbolButton btnJobPattern_Train;
        private Sunny.UI.UISymbolButton btnJobPattern_Find;
        private Label label110;
        private Panel panel14;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay_JobPattern;
        private Label label65;
        private TabPage tabPage18;
        private Sunny.UI.UITextBox txt_PinMatchingScoreMin;
        private Sunny.UI.UITextBox txtBlobThreshold;
        private Sunny.UI.UITextBox tbAreaMax;
        private Sunny.UI.UITextBox tbAreaMin;
        private Button btnGetBlobPos;
        private Sunny.UI.UISymbolButton btnJobBlob_Roi;
        internal Cognex.VisionPro.Display.CogDisplay CogDisplay_FinMatchingTemplateImg;
        private Sunny.UI.UISymbolButton uiSymbolButton29;
        private Label label83;
        private Label label82;
        private Label label72;
        private Label label73;
        private Label label86;
        private Sunny.UI.UISymbolButton uiSymbolButton32;
        private Label label88;
        private Panel panel15;
        private Label label118;
        private Sunny.UI.UISymbolButton uiSymbolButton33;
        private Sunny.UI.UISymbolButton uiSymbolButton64;
        private Sunny.UI.UISymbolButton uiSymbolButton65;
        private Button btnJobBlobInsp;
        private TabPage tabPage19;
        private Sunny.UI.UITextBox tbYMaxValue;
        private Sunny.UI.UITextBox tbYMinValue;
        private Sunny.UI.UITextBox tbXMaxValue;
        private Sunny.UI.UITextBox tbXMinValue;
        private Sunny.UI.UITextBox tbAngleMaxValue;
        private Sunny.UI.UITextBox tbAngleMinValue;
        private Sunny.UI.UITextBox tbLineEdgeContrast;
        private Sunny.UI.UISymbolButton btnDistanceDetail;
        private NumericUpDown numericDistanceSamplingCount;
        private NumericUpDown numericDistanceThickness;
        private Label label74;
        private Label label75;
        private CheckBox cbYValue;
        private CheckBox cbXValue;
        private CheckBox cbAngle;
        private Label label117;
        private Label label111;
        private Label label112;
        private Label label113;
        private Label label106;
        private Label label107;
        private Label label109;
        private Label label77;
        private Label label78;
        private Label label79;
        private Sunny.UI.UISymbolButton btnJobDistanceInsp;
        private Sunny.UI.UISymbolButton btnJobDistance_Roi;
        private Sunny.UI.UISymbolButton uiSymbolButton66;
        private MetroFramework.Controls.MetroComboBox comboLineEdgePolarity;
        private Label label80;
        private MetroFramework.Controls.MetroComboBox comboLineEdgeScorer;
        private Label label81;
        private Label label84;
        private TabPage tabPage27;
        private Sunny.UI.UITextBox lbColorMaxArea;
        private Sunny.UI.UITextBox lbColorMinArea;
        private Label label94;
        private Label label95;
        private Label label96;
        private Panel panel43;
        private Label lbThreshold_Color;
        private MetroFramework.Controls.MetroTrackBar trbThreshold_Color;
        private Label label97;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label98;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label99;
        private Label lbJobColor_Area;
        private Button btnJobColor_Insp;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label101;
        private TableLayoutPanel tableLayoutPanel7;
        private Button btnJobColor_Roi;
        private Button btnJobColor_AutoColor;
        private Label lbExtractedColor2;
        private Label lbExtractedColor;
        private Panel panel23;
        private MetroFramework.Controls.MetroComboBox cboColorAlg;
        private Label label102;
        private Panel panel19;
        private MetroFramework.Controls.MetroComboBox cboColorCoordinate;
        private Label label103;
        private TabPage tabPage28;
        private Panel panel64;
        private Sunny.UI.UITextBox txtColorEx_B;
        private Sunny.UI.UITextBox txtColorEx_G;
        private Sunny.UI.UITextBox txtColorEx_R;
        private Label label168;
        private RadioButton radioColorEx_Range45;
        private RadioButton radioColorEx_Range30;
        private RadioButton radioColorEx_Range15;
        private Label label171;
        private Label label170;
        private Label label169;
        private CheckBox chkColorEx_SimpleMode;
        private Label label167;
        private Sunny.UI.UISymbolButton btnJobColorEx_Roi;
        private Label lblJobColorEx_ResultColor;
        private Button btnJobColorEx_Get;
        private Label label130;
        private Button button4;
        private MetroFramework.Controls.MetroComboBox comboCorrectColorEx;
        private Label label132;
        private Sunny.UI.UISymbolButton uiSymbolButton67;
        private Label label133;
        private TabPage tabPage29;
        private Sunny.UI.UITextBox tbIgnoreCount;
        private Sunny.UI.UITextBox tbCircleThickness;
        private Sunny.UI.UITextBox tbCircleContrast;
        private Sunny.UI.UITextBox tbCondensorRectRadio;
        private Sunny.UI.UITextBox tbCircleRectH;
        private Sunny.UI.UITextBox tbCircleRectW;
        private Sunny.UI.UISymbolButton btnJobCondensor_DistSetting;
        private Sunny.UI.UISymbolButton btnJobCondensor_DistInsp;
        private CheckBox chkCondensor_UseDist;
        private Label label149;
        private Sunny.UI.UISymbolButton btnCondensorAutoRegion;
        private Label label104;
        private MetroFramework.Controls.MetroComboBox comboCondensorPolarity;
        private Label label105;
        private Label label108;
        private Label label114;
        private Label label115;
        private Sunny.UI.UISymbolButton btnJobCondensor_Inspection;
        private Label label116;
        private Panel panel13;
        private Sunny.UI.UIRadioButton radioCondensorTB;
        private Sunny.UI.UIRadioButton radioCondensorLR;
        private Label label119;
        private Label label120;
        private Sunny.UI.UISymbolButton btnJobCondensor_Roi;
        private Sunny.UI.UISymbolButton uiSymbolButton68;
        private TabPage tabPage30;
        private Sunny.UI.UITextBox txtJobConnector_OKArea;
        private Label label163;
        private Panel panel62;
        private Sunny.UI.UIRadioButton radioJobConnector_AreaRB;
        private Sunny.UI.UIRadioButton radioJobConnector_AreaLT;
        private Sunny.UI.UISymbolButton uiSymbolButton69;
        private Sunny.UI.UISymbolButton btnJobConnector_Projection;
        private Label label162;
        private Sunny.UI.UITextBox txtJobConnector_AreaMax;
        private Sunny.UI.UITextBox txtJobConnector_AreaMin;
        private Label label161;
        private Label label155;
        private Sunny.UI.UITextBox txtJobConnector_BoxHeight;
        private Label label160;
        private Sunny.UI.UITextBox txtJobConnector_BoxWidth;
        private CheckBox chkJobConnector_BinInv;
        private Label label157;
        private Sunny.UI.UITextBox txtJobConnector_Threshold;
        private Label label159;
        private Label label158;
        private CheckBox checkBox60;
        private Sunny.UI.UISymbolButton uiSymbolButton70;
        private Label label154;
        private Button button1;
        private Button button2;
        private MetroFramework.Controls.MetroComboBox metroComboBox3;
        private Label label152;
        private Label label156;
        private Sunny.UI.UITextBox txtJobConnector_Score;
        private Label label151;
        private Panel panel61;
        private Sunny.UI.UIRadioButton radioJobConnector_TB;
        private Sunny.UI.UIRadioButton radioJobConnector_LR;
        private Label label153;
        private Panel panel58;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay_Connector;
        private Label label165;
        private Sunny.UI.UISymbolButton btnJobConnector_Roi;
        private Sunny.UI.UISymbolButton btnJobConnector_Train;
        private Sunny.UI.UISymbolButton btnJobConnector_Find;
        private Label label164;
        private TabPage tabPage31;
        private Panel panel63;
        private Label lblJobPin_MeasColor;
        private Label lblJobPin_ShapeColor;
        private CheckBox chkJobPin_UseColorMatching;
        private Label label166;
        private CheckBox chk_BlobPos_UseAlign;
        private Panel panel55;
        private Label label145;
        private Sunny.UI.UISymbolButton btnJobPin_Master;
        private Panel panel53;
        private Label label144;
        private Panel panel54;
        private CheckBox chk_Pin_BinaryInv;
        private NumericUpDown nb_Pin_Threshold;
        private CheckBox checkBox53;
        private CheckBox checkBox54;
        private Panel panel47;
        private Label label142;
        private Panel panel48;
        private NumericUpDown nb_Pin_SpecRoi_Height;
        private Label label143;
        private NumericUpDown nb_Pin_SpecRoi_Width;
        private CheckBox checkBox51;
        private CheckBox checkBox52;
        private Panel panel42;
        private Label label139;
        private Panel panel44;
        private NumericUpDown nb_Pin_AreaMax;
        private Label label141;
        private NumericUpDown nb_Pin_AreaMin;
        private CheckBox checkBox49;
        private CheckBox checkBox50;
        private Sunny.UI.UISymbolButton btnJobPin_Roi;
        private Sunny.UI.UISymbolButton btnJobPin_Find;
        private Panel panel59;
        private Label label146;
        private Panel panel60;
        private NumericUpDown nb_Pin_OkCount;
        private CheckBox checkBox71;
        private CheckBox checkBox72;
        private CheckBox cbIQContinuous;
        private Sunny.UI.UITreeView TrvLogic;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn Column4;
        private TabPage tabPage26;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label39;
        private Sunny.UI.UITextBox TbOnnxPath;
        private Sunny.UI.UISymbolButton BtnOpenOnnx;
        private Sunny.UI.UITextBox TbThresholdEYED;
        private Label label55;
        private Label label85;
        private Sunny.UI.UISymbolButton BtnFindEYED;
        private Sunny.UI.UIComboBox CbRotateImageEYED;
        private Sunny.UI.UISymbolButton BtnRoiEYED;
        private Panel panel3;
        private CheckBox ChkSpecRegionEYED;
        private Label label87;
        private Label LblResultEYED;
    }
}