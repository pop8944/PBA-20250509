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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnView_Full = new Sunny.UI.UISymbolButton();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uiTabControl2 = new Sunny.UI.UITabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.cogdis_IQPreView = new Cognex.VisionPro.Display.CogDisplay();
            this.uiGroupBox14 = new Sunny.UI.UIGroupBox();
            this.label89 = new System.Windows.Forms.Label();
            this.CbTriggerMode = new Sunny.UI.UIComboBox();
            this.uiSymbolButton28 = new Sunny.UI.UISymbolButton();
            this.BtnGrab5 = new Sunny.UI.UISymbolButton();
            this.BtnGrab4 = new Sunny.UI.UISymbolButton();
            this.BtnGrab3 = new Sunny.UI.UISymbolButton();
            this.BtnGrab2 = new Sunny.UI.UISymbolButton();
            this.BtnGrab1 = new Sunny.UI.UISymbolButton();
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
            this.uiGroupBox5 = new Sunny.UI.UIGroupBox();
            this.TbTransparent = new Sunny.UI.UITextBox();
            this.chkAlphaImg = new System.Windows.Forms.CheckBox();
            this.lblMasterPixel = new System.Windows.Forms.Label();
            this.lblMasterHeight = new System.Windows.Forms.Label();
            this.lblMasterWidth = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lblMasterFocus = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.BtnIQDataSave = new Sunny.UI.UISymbolButton();
            this.BtnIQLoad = new Sunny.UI.UISymbolButton();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.uiTabControl6 = new Sunny.UI.UITabControl();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.txtArrayCount = new Sunny.UI.UITextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Cogdis_FiducialPreView = new Cognex.VisionPro.Display.CogDisplay();
            this.label78 = new System.Windows.Forms.Label();
            this.TbLibraryName = new Sunny.UI.UITextBox();
            this.btnLibrarySelect = new Sunny.UI.UISymbolButton();
            this.label80 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.uiGroupBox17 = new Sunny.UI.UIGroupBox();
            this.lbQrCodeData = new System.Windows.Forms.Label();
            this.btnQrRead = new Sunny.UI.UISymbolButton();
            this.uiLine20 = new Sunny.UI.UILine();
            this.btnQrSet = new Sunny.UI.UISymbolButton();
            this.btnQrRoi = new Sunny.UI.UISymbolButton();
            this.label3 = new System.Windows.Forms.Label();
            this.uiLine18 = new Sunny.UI.UILine();
            this.comboArray = new Sunny.UI.UIComboBox();
            this.btnSave_QR = new Sunny.UI.UISymbolButton();
            this.btnArrayCrop_Set = new Sunny.UI.UISymbolButton();
            this.btnArrayCrop_Roi = new Sunny.UI.UISymbolButton();
            this.label60 = new System.Windows.Forms.Label();
            this.uiGroupBox16 = new Sunny.UI.UIGroupBox();
            this.chkChangeFiducialMark = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImageAlign_Rotate = new Sunny.UI.UISymbolButton();
            this.btnResetMaster = new Sunny.UI.UISymbolButton();
            this.btnFiducial_MeasureToMaster = new Sunny.UI.UISymbolButton();
            this.uiLine26 = new Sunny.UI.UILine();
            this.lblDegreeDelta = new System.Windows.Forms.Label();
            this.uiLine24 = new Sunny.UI.UILine();
            this.btnFiducial_Measure = new Sunny.UI.UISymbolButton();
            this.lblDegreeMeasure = new System.Windows.Forms.Label();
            this.lblDegreeMaster = new System.Windows.Forms.Label();
            this.uiLine22 = new Sunny.UI.UILine();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.chkAlignNoUse = new System.Windows.Forms.CheckBox();
            this.btnFiducialFind2 = new Sunny.UI.UISymbolButton();
            this.btnFiducialFind1 = new Sunny.UI.UISymbolButton();
            this.cogDisplay_Fiducial_Pattern1 = new Cognex.VisionPro.Display.CogDisplay();
            this.btnFiducialTrain2 = new Sunny.UI.UISymbolButton();
            this.btnFiducialROI2 = new Sunny.UI.UISymbolButton();
            this.uiLine16 = new Sunny.UI.UILine();
            this.btnFiducialTrain1 = new Sunny.UI.UISymbolButton();
            this.btnFiducialROI1 = new Sunny.UI.UISymbolButton();
            this.uiLine19 = new Sunny.UI.UILine();
            this.label68 = new System.Windows.Forms.Label();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.uiTabControl3 = new Sunny.UI.UITabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.uiGroupBox18 = new Sunny.UI.UIGroupBox();
            this.chkEnalbenouse = new System.Windows.Forms.CheckBox();
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
            this.Angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnGerberLoad = new Sunny.UI.UISymbolButton();
            this.TbGerberPath = new Sunny.UI.UITextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.Cogdis_Master = new Cognex.VisionPro.Display.CogDisplay();
            this.BtnMasterBoardLoad = new Sunny.UI.UISymbolButton();
            this.BtnMasterBoardSave = new Sunny.UI.UISymbolButton();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.Cogdis_Bare = new Cognex.VisionPro.Display.CogDisplay();
            this.BtnBareBoardLoad = new Sunny.UI.UISymbolButton();
            this.BtnBareBoardSave = new Sunny.UI.UISymbolButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Library_Update = new Sunny.UI.UISymbolButton();
            this.btn_Library_Clear = new Sunny.UI.UISymbolButton();
            this.btn_Library_Refresh = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.TvLocal = new Sunny.UI.UITreeView();
            this.label27 = new System.Windows.Forms.Label();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Library_ServerName = new System.Windows.Forms.Label();
            this.btn_Library_LoadServerFolder = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Library_LocalName = new System.Windows.Forms.Label();
            this.btn_Library_LoadLocalFolder = new Sunny.UI.UISymbolButton();
            this.label28 = new System.Windows.Forms.Label();
            this.TvServer = new Sunny.UI.UITreeView();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.btnUpLoadAll = new Sunny.UI.UISymbolButton();
            this.BtnModelDownAll = new Sunny.UI.UISymbolButton();
            this.label57 = new System.Windows.Forms.Label();
            this.BtnJobDownLoad = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton7 = new Sunny.UI.UISymbolButton();
            this.BtnGrabMove = new Sunny.UI.UIButton();
            this.btnDownLoadPartLibrary = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton9 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TabMenuLogic = new Sunny.UI.UITabControlMenu();
            this.tpPattern = new System.Windows.Forms.TabPage();
            this.richtxtPatternResult = new Sunny.UI.UIRichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uiLine23 = new Sunny.UI.UILine();
            this.BtnDeletePattern = new Sunny.UI.UISymbolButton();
            this.label26 = new System.Windows.Forms.Label();
            this.comboJobPattern_PatternType = new Sunny.UI.UIComboBox();
            this.tbJobPattern_AcceptScore = new Sunny.UI.UITextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.uiLine3 = new Sunny.UI.UILine();
            this.tbJobPattern_MinScore = new Sunny.UI.UITextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPatternMasterCount = new Sunny.UI.UITextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnJobPattern_Roi = new Sunny.UI.UISymbolButton();
            this.btnJobPattern_Train = new Sunny.UI.UISymbolButton();
            this.btnJobPattern_Find = new Sunny.UI.UISymbolButton();
            this.label110 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.cogDisplay_JobPattern = new Cognex.VisionPro.Display.CogDisplay();
            this.label65 = new System.Windows.Forms.Label();
            this.lblSubPatternInfo = new System.Windows.Forms.Label();
            this.tpEYED = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEyeD_ColorEx_Result = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radioColorEx_Range45 = new System.Windows.Forms.RadioButton();
            this.radioColorEx_Range30 = new System.Windows.Forms.RadioButton();
            this.radioColorEx_Range15 = new System.Windows.Forms.RadioButton();
            this.txtEyeD_ColorEx_B = new Sunny.UI.UITextBox();
            this.txtEyeD_ColorEx_G = new Sunny.UI.UITextBox();
            this.txtEyeD_ColorEx_R = new Sunny.UI.UITextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.chkEyeD_UseColor = new System.Windows.Forms.CheckBox();
            this.label58 = new System.Windows.Forms.Label();
            this.btnEyeD_ColorEx_Get = new Sunny.UI.UISymbolButton();
            this.btnEyeD_ColorExRoi = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CbbModelList = new Sunny.UI.UIComboBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.TbThresholdEYED = new Sunny.UI.UITextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.BtnOpenOnnx = new Sunny.UI.UISymbolButton();
            this.CbRotateImageEYED = new Sunny.UI.UIComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChkSpecRegionEYED = new System.Windows.Forms.CheckBox();
            this.LblResultEYED = new System.Windows.Forms.Label();
            this.BtnFindEYED = new Sunny.UI.UISymbolButton();
            this.BtnRoiEYED = new Sunny.UI.UISymbolButton();
            this.tpCondensor = new System.Windows.Forms.TabPage();
            this.tbIgnoreCount = new Sunny.UI.UITextBox();
            this.tbCircleThickness = new Sunny.UI.UITextBox();
            this.tbCircleContrast = new Sunny.UI.UITextBox();
            this.tbCondensorRectRadio = new Sunny.UI.UITextBox();
            this.tbCircleRectH = new Sunny.UI.UITextBox();
            this.tbCircleRectW = new Sunny.UI.UITextBox();
            this.btnJobCondensor_DistSetting = new Sunny.UI.UISymbolButton();
            this.btnJobCondensor_DistInsp = new Sunny.UI.UISymbolButton();
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
            this.tpColorEx = new System.Windows.Forms.TabPage();
            this.btnJobColorEx_Get = new Sunny.UI.UISymbolButton();
            this.panel64 = new System.Windows.Forms.Panel();
            this.TbColorEXRangeMax_B = new Sunny.UI.UITextBox();
            this.TbColorEXRangeMax_G = new Sunny.UI.UITextBox();
            this.TbColorEXRangeMax_R = new Sunny.UI.UITextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TbColorEXRangeMin_B = new Sunny.UI.UITextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.TbColorEXRangeMin_G = new Sunny.UI.UITextBox();
            this.TbColorEXRangeMin_R = new Sunny.UI.UITextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtColorEx_B = new Sunny.UI.UITextBox();
            this.txtColorEx_G = new Sunny.UI.UITextBox();
            this.txtColorEx_R = new Sunny.UI.UITextBox();
            this.label168 = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.chkColorEx_SimpleMode = new System.Windows.Forms.CheckBox();
            this.label167 = new System.Windows.Forms.Label();
            this.btnJobColorEx_Roi = new Sunny.UI.UISymbolButton();
            this.lblJobColorEx_ResultColor = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.uiSymbolButton67 = new Sunny.UI.UISymbolButton();
            this.label133 = new System.Windows.Forms.Label();
            this.tpPin = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.chkThresholdInv = new System.Windows.Forms.CheckBox();
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
            this.trackbarThreshold = new IF_UI.RJControls.RJTrackBar();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BtnApplyCore = new Sunny.UI.UISymbolButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbbMethod = new System.Windows.Forms.ComboBox();
            this.dgvParameter = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.uiSymbolButton3 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton8 = new Sunny.UI.UISymbolButton();
            this.DgvProcessingList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvLogicList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnUpLoadPartLibrary = new Sunny.UI.UISymbolButton();
            this.label24 = new System.Windows.Forms.Label();
            this.BtnLogicDelete = new Sunny.UI.UISymbolButton();
            this.BtnLogicAdd = new Sunny.UI.UISymbolButton();
            this.uiLine25 = new Sunny.UI.UILine();
            this.label20 = new System.Windows.Forms.Label();
            this.BtnNA_ng = new Sunny.UI.UIButton();
            this.label23 = new System.Windows.Forms.Label();
            this.BtnNA_ok = new Sunny.UI.UIButton();
            this.cbGrabIndex = new Sunny.UI.UIComboBox();
            this.BtnSettingLogic = new Sunny.UI.UISymbolButton();
            this.label18 = new System.Windows.Forms.Label();
            this.tbLogicName = new Sunny.UI.UITextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.BtnSettingJob = new Sunny.UI.UISymbolButton();
            this.uiLine21 = new Sunny.UI.UILine();
            this.TbPartName = new Sunny.UI.UITextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TbLocationNo = new Sunny.UI.UITextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CbJobAll = new System.Windows.Forms.CheckBox();
            this.BtnJobListCopy = new Sunny.UI.UISymbolButton();
            this.BtnJobDelete = new Sunny.UI.UISymbolButton();
            this.DgvJobList = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLibraryName = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridLibraryEnabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnJobAdd = new Sunny.UI.UISymbolButton();
            this.cbAlgorithm = new Sunny.UI.UIComboBox();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.DgvRecentImages = new Sunny.UI.UIDataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiGroupBox6 = new Sunny.UI.UIGroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.DisplayDataMatrix = new Cognex.VisionPro.Display.CogDisplay();
            this.DisplayArray = new Cognex.VisionPro.Display.CogDisplay();
            this.uiLine14 = new Sunny.UI.UILine();
            this.uiTableLayoutPanel6 = new Sunny.UI.UITableLayoutPanel();
            this.BtnDataMatrixRoiRead = new Sunny.UI.UISymbolButton();
            this.label70 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.uiTableLayoutPanel5 = new Sunny.UI.UITableLayoutPanel();
            this.BtnDataMatrixRoi = new Sunny.UI.UISymbolButton();
            this.BtnDataMatrixRoiSet = new Sunny.UI.UISymbolButton();
            this.uiTableLayoutPanel4 = new Sunny.UI.UITableLayoutPanel();
            this.BtnArrayRoi = new Sunny.UI.UISymbolButton();
            this.comboArrayNumber = new Sunny.UI.UIComboBox();
            this.uiTableLayoutPanel7 = new Sunny.UI.UITableLayoutPanel();
            this.BtnArraySet = new Sunny.UI.UISymbolButton();
            this.uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            this.LblDataMatrixData = new System.Windows.Forms.Label();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.BtnViewJobs = new Sunny.UI.UISymbolButton();
            this.BtnInspectAuto = new Sunny.UI.UISymbolButton();
            this.Btn_Inspect = new Sunny.UI.UISymbolButton();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.uiMarkLabel3 = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel2 = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel4 = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            this.label124 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.btnView_ResultNG4 = new Sunny.UI.UIButton();
            this.btnView_ResultNG3 = new Sunny.UI.UIButton();
            this.btnView_ResultNG2 = new Sunny.UI.UIButton();
            this.btnView_ResultNG1 = new Sunny.UI.UIButton();
            this.label66 = new System.Windows.Forms.Label();
            this.uiLine13 = new Sunny.UI.UILine();
            this.btnAction = new Sunny.UI.UISymbolButton();
            this.btnOriginal = new Sunny.UI.UISymbolButton();
            this.btnView_Setting5 = new Sunny.UI.UIButton();
            this.btnView_Setting6 = new Sunny.UI.UIButton();
            this.btnView_Setting7 = new Sunny.UI.UIButton();
            this.btnView_Setting8 = new Sunny.UI.UIButton();
            this.btnView_Setting9 = new Sunny.UI.UIButton();
            this.btnView_Setting10 = new Sunny.UI.UIButton();
            this.btnView_Setting11 = new Sunny.UI.UIButton();
            this.btnView_Setting12 = new Sunny.UI.UIButton();
            this.comboViewType = new Sunny.UI.UIComboBox();
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
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogdis_IQPreView)).BeginInit();
            this.uiGroupBox14.SuspendLayout();
            this.uiGroupBox12.SuspendLayout();
            this.uiGroupBox5.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.uiTabControl6.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cogdis_FiducialPreView)).BeginInit();
            this.uiGroupBox17.SuspendLayout();
            this.uiGroupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Fiducial_Pattern1)).BeginInit();
            this.tabPage12.SuspendLayout();
            this.uiTabControl3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.uiGroupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGerberInfo)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cogdis_Master)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.uiGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cogdis_Bare)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.TabMenuLogic.SuspendLayout();
            this.tpPattern.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_JobPattern)).BeginInit();
            this.tpEYED.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tpCondensor.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tpColorEx.SuspendLayout();
            this.panel64.SuspendLayout();
            this.tpPin.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackbarThreshold)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcessingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLogicList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvJobList)).BeginInit();
            this.tabPage15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecentImages)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiGroupBox6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayDataMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayArray)).BeginInit();
            this.uiTableLayoutPanel6.SuspendLayout();
            this.uiTableLayoutPanel5.SuspendLayout();
            this.uiTableLayoutPanel4.SuspendLayout();
            this.uiTableLayoutPanel7.SuspendLayout();
            this.uiTableLayoutPanel3.SuspendLayout();
            this.pnlHelp.SuspendLayout();
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
            this.pnlCogDisplay.Size = new System.Drawing.Size(966, 792);
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
            this.DispMain.Size = new System.Drawing.Size(966, 726);
            this.DispMain.TabIndex = 3255;
            this.DispMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DispMain_MouseDown);
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
            this.uiPanel3.Size = new System.Drawing.Size(966, 41);
            this.uiPanel3.TabIndex = 3253;
            this.uiPanel3.Text = null;
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton12
            // 
            this.uiButton12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton12.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton12.Location = new System.Drawing.Point(76, 20);
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
            this.uiButton7.Location = new System.Drawing.Point(228, 20);
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
            this.pnlDisplayStatus.Location = new System.Drawing.Point(471, 0);
            this.pnlDisplayStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlDisplayStatus.Name = "pnlDisplayStatus";
            this.pnlDisplayStatus.Size = new System.Drawing.Size(495, 41);
            this.pnlDisplayStatus.TabIndex = 3061;
            // 
            // uiButton8
            // 
            this.uiButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton8.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton8.Location = new System.Drawing.Point(228, -1);
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
            this.btnLive.Location = new System.Drawing.Point(76, -1);
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
            this.uiButton4.Location = new System.Drawing.Point(152, 20);
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
            this.uiButton2.Location = new System.Drawing.Point(0, -1);
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
            this.uiButton6.Location = new System.Drawing.Point(152, -1);
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
            this.uiButton3.Location = new System.Drawing.Point(0, 20);
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
            this.pnl_CogDisplay_Operation.Size = new System.Drawing.Size(966, 25);
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
            this.uiSymbolButton6.Location = new System.Drawing.Point(441, 0);
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
            this.uiLine4.Location = new System.Drawing.Point(471, 0);
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
            this.btn_CogDisplay_OverlayClear.Location = new System.Drawing.Point(496, 0);
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
            this.uiLine2.Location = new System.Drawing.Point(596, 0);
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
            this.btn_CogDisplay_SearchROI.Location = new System.Drawing.Point(621, 0);
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
            this.uiLine1.Location = new System.Drawing.Point(651, 0);
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
            this.btn_CogDisplay_ImageLoad.Location = new System.Drawing.Point(676, 0);
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
            this.btn_CogDisplay_ImageSave.Location = new System.Drawing.Point(706, 0);
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
            this.line1.Location = new System.Drawing.Point(736, 0);
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
            this.btn_CogDisplay_Measure.Location = new System.Drawing.Point(761, 0);
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
            this.line2.Location = new System.Drawing.Point(791, 0);
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
            this.btn_CogDisplay_Point.Location = new System.Drawing.Point(816, 0);
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
            this.btn_CogDisplay_Pan.Location = new System.Drawing.Point(841, 0);
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
            this.line3.Location = new System.Drawing.Point(866, 0);
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
            this.btn_CogDisplay_ZoomIn.Location = new System.Drawing.Point(891, 0);
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
            this.btn_CogDisplay_ZoomOut.Location = new System.Drawing.Point(916, 0);
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
            this.btn_CogDisplay_ZoomFit.Location = new System.Drawing.Point(941, 0);
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
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
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
            this.uiLine6.Size = new System.Drawing.Size(266, 10);
            this.uiLine6.TabIndex = 3549;
            // 
            // btnView_Setting1
            // 
            this.btnView_Setting1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting1.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting1.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting1.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting1.GroupIndex = 1;
            this.btnView_Setting1.Location = new System.Drawing.Point(56, 6);
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
            this.btnView_Setting2.Location = new System.Drawing.Point(112, 6);
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
            this.btnView_Setting4.Location = new System.Drawing.Point(224, 6);
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
            this.btnView_Setting3.Location = new System.Drawing.Point(168, 6);
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
            this.btnView_Result4.Location = new System.Drawing.Point(225, 37);
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
            this.btnView_Result3.Location = new System.Drawing.Point(169, 37);
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
            this.btnView_Result2.Location = new System.Drawing.Point(113, 37);
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
            this.btnView_Result1.Location = new System.Drawing.Point(57, 37);
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
            this.uiLine5.Size = new System.Drawing.Size(266, 10);
            this.uiLine5.TabIndex = 3556;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
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
            this.uiLine7.Location = new System.Drawing.Point(631, 56);
            this.uiLine7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine7.Name = "uiLine7";
            this.uiLine7.Size = new System.Drawing.Size(336, 10);
            this.uiLine7.TabIndex = 3562;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Arial", 10F);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(851, 4);
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
            this.btnViewGrabIndex4.Location = new System.Drawing.Point(786, 124);
            this.btnViewGrabIndex4.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnViewGrabIndex4.Name = "btnViewGrabIndex4";
            this.btnViewGrabIndex4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnViewGrabIndex4.Size = new System.Drawing.Size(50, 20);
            this.btnViewGrabIndex4.TabIndex = 3566;
            this.btnViewGrabIndex4.Text = "4";
            this.btnViewGrabIndex4.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGrabIndex4.Visible = false;
            this.btnViewGrabIndex4.Click += new System.EventHandler(this.OnClickGrabIndex);
            // 
            // btnViewGrabIndex3
            // 
            this.btnViewGrabIndex3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewGrabIndex3.FillColor = System.Drawing.Color.DimGray;
            this.btnViewGrabIndex3.FillSelectedColor = System.Drawing.Color.Green;
            this.btnViewGrabIndex3.Font = new System.Drawing.Font("Arial", 8F);
            this.btnViewGrabIndex3.GroupIndex = 2;
            this.btnViewGrabIndex3.Location = new System.Drawing.Point(730, 124);
            this.btnViewGrabIndex3.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnViewGrabIndex3.Name = "btnViewGrabIndex3";
            this.btnViewGrabIndex3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnViewGrabIndex3.Size = new System.Drawing.Size(50, 20);
            this.btnViewGrabIndex3.TabIndex = 3565;
            this.btnViewGrabIndex3.Text = "3";
            this.btnViewGrabIndex3.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGrabIndex3.Visible = false;
            this.btnViewGrabIndex3.Click += new System.EventHandler(this.OnClickGrabIndex);
            // 
            // btnViewGrabIndex2
            // 
            this.btnViewGrabIndex2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewGrabIndex2.FillColor = System.Drawing.Color.DimGray;
            this.btnViewGrabIndex2.FillSelectedColor = System.Drawing.Color.Green;
            this.btnViewGrabIndex2.Font = new System.Drawing.Font("Arial", 8F);
            this.btnViewGrabIndex2.GroupIndex = 2;
            this.btnViewGrabIndex2.Location = new System.Drawing.Point(674, 124);
            this.btnViewGrabIndex2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnViewGrabIndex2.Name = "btnViewGrabIndex2";
            this.btnViewGrabIndex2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnViewGrabIndex2.Size = new System.Drawing.Size(50, 20);
            this.btnViewGrabIndex2.TabIndex = 3564;
            this.btnViewGrabIndex2.Text = "2";
            this.btnViewGrabIndex2.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGrabIndex2.Visible = false;
            this.btnViewGrabIndex2.Click += new System.EventHandler(this.OnClickGrabIndex);
            // 
            // btnViewGrabIndex1
            // 
            this.btnViewGrabIndex1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewGrabIndex1.FillColor = System.Drawing.Color.DimGray;
            this.btnViewGrabIndex1.FillSelectedColor = System.Drawing.Color.Green;
            this.btnViewGrabIndex1.Font = new System.Drawing.Font("Arial", 8F);
            this.btnViewGrabIndex1.GroupIndex = 2;
            this.btnViewGrabIndex1.Location = new System.Drawing.Point(903, 39);
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
            this.btnViewGrabIndex5.Location = new System.Drawing.Point(842, 124);
            this.btnViewGrabIndex5.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnViewGrabIndex5.Name = "btnViewGrabIndex5";
            this.btnViewGrabIndex5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnViewGrabIndex5.Size = new System.Drawing.Size(50, 20);
            this.btnViewGrabIndex5.TabIndex = 3567;
            this.btnViewGrabIndex5.Text = "5";
            this.btnViewGrabIndex5.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGrabIndex5.Visible = false;
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
            this.DisplayGrabIdx1.Location = new System.Drawing.Point(903, 5);
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
            this.DisplayGrabIdx2.Location = new System.Drawing.Point(674, 90);
            this.DisplayGrabIdx2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayGrabIdx2.MouseWheelSensitivity = 1D;
            this.DisplayGrabIdx2.Name = "DisplayGrabIdx2";
            this.DisplayGrabIdx2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayGrabIdx2.OcxState")));
            this.DisplayGrabIdx2.Size = new System.Drawing.Size(50, 33);
            this.DisplayGrabIdx2.TabIndex = 3569;
            this.DisplayGrabIdx2.TabStop = false;
            this.DisplayGrabIdx2.Tag = "2";
            this.DisplayGrabIdx2.Visible = false;
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
            this.DisplayGrabIdx4.Location = new System.Drawing.Point(786, 90);
            this.DisplayGrabIdx4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayGrabIdx4.MouseWheelSensitivity = 1D;
            this.DisplayGrabIdx4.Name = "DisplayGrabIdx4";
            this.DisplayGrabIdx4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayGrabIdx4.OcxState")));
            this.DisplayGrabIdx4.Size = new System.Drawing.Size(50, 33);
            this.DisplayGrabIdx4.TabIndex = 3571;
            this.DisplayGrabIdx4.TabStop = false;
            this.DisplayGrabIdx4.Tag = "2";
            this.DisplayGrabIdx4.Visible = false;
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
            this.DisplayGrabIdx3.Location = new System.Drawing.Point(730, 90);
            this.DisplayGrabIdx3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayGrabIdx3.MouseWheelSensitivity = 1D;
            this.DisplayGrabIdx3.Name = "DisplayGrabIdx3";
            this.DisplayGrabIdx3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayGrabIdx3.OcxState")));
            this.DisplayGrabIdx3.Size = new System.Drawing.Size(50, 33);
            this.DisplayGrabIdx3.TabIndex = 3570;
            this.DisplayGrabIdx3.TabStop = false;
            this.DisplayGrabIdx3.Tag = "2";
            this.DisplayGrabIdx3.Visible = false;
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
            this.DisplayGrabIdx5.Location = new System.Drawing.Point(842, 90);
            this.DisplayGrabIdx5.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayGrabIdx5.MouseWheelSensitivity = 1D;
            this.DisplayGrabIdx5.Name = "DisplayGrabIdx5";
            this.DisplayGrabIdx5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayGrabIdx5.OcxState")));
            this.DisplayGrabIdx5.Size = new System.Drawing.Size(50, 33);
            this.DisplayGrabIdx5.TabIndex = 3572;
            this.DisplayGrabIdx5.TabStop = false;
            this.DisplayGrabIdx5.Tag = "2";
            this.DisplayGrabIdx5.Visible = false;
            // 
            // timerCalibration
            // 
            this.timerCalibration.Tick += new System.EventHandler(this.timerCalibration_Tick);
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
            this.btnView_Full.Location = new System.Drawing.Point(788, 6);
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
            this.uiTabControl1.Controls.Add(this.tabPage4);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(100, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(968, -2);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(954, 824);
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
            this.tabPage1.Size = new System.Drawing.Size(954, 784);
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
            this.uiTabControl2.Size = new System.Drawing.Size(954, 784);
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
            this.tabPage3.Controls.Add(this.uiGroupBox1);
            this.tabPage3.Controls.Add(this.uiGroupBox14);
            this.tabPage3.Controls.Add(this.uiGroupBox12);
            this.tabPage3.Controls.Add(this.uiGroupBox5);
            this.tabPage3.Controls.Add(this.DisplayGrabIdx2);
            this.tabPage3.Controls.Add(this.btnViewGrabIndex2);
            this.tabPage3.Controls.Add(this.btnViewGrabIndex3);
            this.tabPage3.Controls.Add(this.btnViewGrabIndex4);
            this.tabPage3.Controls.Add(this.btnViewGrabIndex5);
            this.tabPage3.Controls.Add(this.DisplayGrabIdx3);
            this.tabPage3.Controls.Add(this.DisplayGrabIdx4);
            this.tabPage3.Controls.Add(this.DisplayGrabIdx5);
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(954, 744);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "01) Equipment";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.cogdis_IQPreView);
            this.uiGroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox1.Location = new System.Drawing.Point(233, 265);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Radius = 10;
            this.uiGroupBox1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox1.Size = new System.Drawing.Size(706, 473);
            this.uiGroupBox1.TabIndex = 3542;
            this.uiGroupBox1.Text = "I.Q PreView";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cogdis_IQPreView
            // 
            this.cogdis_IQPreView.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogdis_IQPreView.ColorMapLowerRoiLimit = 0D;
            this.cogdis_IQPreView.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogdis_IQPreView.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogdis_IQPreView.ColorMapUpperRoiLimit = 1D;
            this.cogdis_IQPreView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogdis_IQPreView.DoubleTapZoomCycleLength = 2;
            this.cogdis_IQPreView.DoubleTapZoomSensitivity = 2.5D;
            this.cogdis_IQPreView.Location = new System.Drawing.Point(0, 32);
            this.cogdis_IQPreView.Margin = new System.Windows.Forms.Padding(4);
            this.cogdis_IQPreView.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogdis_IQPreView.MouseWheelSensitivity = 1D;
            this.cogdis_IQPreView.Name = "cogdis_IQPreView";
            this.cogdis_IQPreView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogdis_IQPreView.OcxState")));
            this.cogdis_IQPreView.Size = new System.Drawing.Size(706, 441);
            this.cogdis_IQPreView.TabIndex = 3256;
            // 
            // uiGroupBox14
            // 
            this.uiGroupBox14.Controls.Add(this.label89);
            this.uiGroupBox14.Controls.Add(this.CbTriggerMode);
            this.uiGroupBox14.Controls.Add(this.uiSymbolButton28);
            this.uiGroupBox14.Controls.Add(this.BtnGrab5);
            this.uiGroupBox14.Controls.Add(this.BtnGrab4);
            this.uiGroupBox14.Controls.Add(this.BtnGrab3);
            this.uiGroupBox14.Controls.Add(this.BtnGrab2);
            this.uiGroupBox14.Controls.Add(this.BtnGrab1);
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
            this.uiSymbolButton28.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            this.uiSymbolButton28.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton28.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton28.Size = new System.Drawing.Size(223, 33);
            this.uiSymbolButton28.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton28.StyleCustomMode = true;
            this.uiSymbolButton28.Symbol = 61671;
            this.uiSymbolButton28.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton28.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton28.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiSymbolButton28.SymbolSize = 20;
            this.uiSymbolButton28.TabIndex = 3597;
            this.uiSymbolButton28.Tag = "";
            this.uiSymbolButton28.Text = "Light Command Setting";
            this.uiSymbolButton28.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // BtnGrab5
            // 
            this.BtnGrab5.BackColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.CircleRectWidth = 0;
            this.BtnGrab5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrab5.FillColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnGrab5.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnGrab5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab5.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab5.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGrab5.Location = new System.Drawing.Point(514, 173);
            this.BtnGrab5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGrab5.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnGrab5.Name = "BtnGrab5";
            this.BtnGrab5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnGrab5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab5.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab5.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab5.Size = new System.Drawing.Size(100, 23);
            this.BtnGrab5.Style = Sunny.UI.UIStyle.Custom;
            this.BtnGrab5.StyleCustomMode = true;
            this.BtnGrab5.Symbol = 57359;
            this.BtnGrab5.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab5.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab5.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnGrab5.SymbolSize = 18;
            this.BtnGrab5.TabIndex = 3596;
            this.BtnGrab5.Tag = "Grab5";
            this.BtnGrab5.Text = "Grab";
            this.BtnGrab5.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGrab5.Click += new System.EventHandler(this.OnClickGrabImages);
            // 
            // BtnGrab4
            // 
            this.BtnGrab4.BackColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.CircleRectWidth = 0;
            this.BtnGrab4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrab4.FillColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnGrab4.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnGrab4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab4.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab4.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGrab4.Location = new System.Drawing.Point(514, 137);
            this.BtnGrab4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGrab4.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnGrab4.Name = "BtnGrab4";
            this.BtnGrab4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnGrab4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab4.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab4.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab4.Size = new System.Drawing.Size(100, 23);
            this.BtnGrab4.Style = Sunny.UI.UIStyle.Custom;
            this.BtnGrab4.StyleCustomMode = true;
            this.BtnGrab4.Symbol = 57359;
            this.BtnGrab4.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab4.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab4.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnGrab4.SymbolSize = 18;
            this.BtnGrab4.TabIndex = 3595;
            this.BtnGrab4.Tag = "Grab4";
            this.BtnGrab4.Text = "Grab";
            this.BtnGrab4.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGrab4.Click += new System.EventHandler(this.OnClickGrabImages);
            // 
            // BtnGrab3
            // 
            this.BtnGrab3.BackColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.CircleRectWidth = 0;
            this.BtnGrab3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrab3.FillColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnGrab3.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnGrab3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab3.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab3.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGrab3.Location = new System.Drawing.Point(514, 101);
            this.BtnGrab3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGrab3.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnGrab3.Name = "BtnGrab3";
            this.BtnGrab3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnGrab3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab3.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab3.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab3.Size = new System.Drawing.Size(100, 23);
            this.BtnGrab3.Style = Sunny.UI.UIStyle.Custom;
            this.BtnGrab3.StyleCustomMode = true;
            this.BtnGrab3.Symbol = 57359;
            this.BtnGrab3.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab3.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab3.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnGrab3.SymbolSize = 18;
            this.BtnGrab3.TabIndex = 3594;
            this.BtnGrab3.Tag = "Grab3";
            this.BtnGrab3.Text = "Grab";
            this.BtnGrab3.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGrab3.Click += new System.EventHandler(this.OnClickGrabImages);
            // 
            // BtnGrab2
            // 
            this.BtnGrab2.BackColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.CircleRectWidth = 0;
            this.BtnGrab2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrab2.FillColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnGrab2.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnGrab2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab2.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab2.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGrab2.Location = new System.Drawing.Point(514, 67);
            this.BtnGrab2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGrab2.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnGrab2.Name = "BtnGrab2";
            this.BtnGrab2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnGrab2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab2.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab2.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab2.Size = new System.Drawing.Size(100, 23);
            this.BtnGrab2.Style = Sunny.UI.UIStyle.Custom;
            this.BtnGrab2.StyleCustomMode = true;
            this.BtnGrab2.Symbol = 57359;
            this.BtnGrab2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab2.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab2.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnGrab2.SymbolSize = 18;
            this.BtnGrab2.TabIndex = 3593;
            this.BtnGrab2.Tag = "Grab2";
            this.BtnGrab2.Text = "Grab";
            this.BtnGrab2.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGrab2.Click += new System.EventHandler(this.OnClickGrabImages);
            // 
            // BtnGrab1
            // 
            this.BtnGrab1.BackColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.CircleRectWidth = 0;
            this.BtnGrab1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrab1.FillColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnGrab1.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnGrab1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab1.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab1.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGrab1.Location = new System.Drawing.Point(514, 31);
            this.BtnGrab1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGrab1.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnGrab1.Name = "BtnGrab1";
            this.BtnGrab1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnGrab1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab1.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab1.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGrab1.Size = new System.Drawing.Size(100, 23);
            this.BtnGrab1.Style = Sunny.UI.UIStyle.Custom;
            this.BtnGrab1.StyleCustomMode = true;
            this.BtnGrab1.Symbol = 57359;
            this.BtnGrab1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab1.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrab1.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnGrab1.SymbolSize = 18;
            this.BtnGrab1.TabIndex = 3592;
            this.BtnGrab1.Tag = "Grab1";
            this.BtnGrab1.Text = "Grab";
            this.BtnGrab1.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGrab1.Click += new System.EventHandler(this.OnClickGrabImages);
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
            this.lbCurrentFocusValue.Location = new System.Drawing.Point(7, 157);
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
            this.btnIQStop.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStop.ForePressColor = System.Drawing.Color.Transparent;
            this.btnIQStop.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIQStop.Location = new System.Drawing.Point(112, 216);
            this.btnIQStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIQStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnIQStop.Name = "btnIQStop";
            this.btnIQStop.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnIQStop.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStop.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnIQStop.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStop.RectPressColor = System.Drawing.Color.Transparent;
            this.btnIQStop.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStop.Size = new System.Drawing.Size(85, 30);
            this.btnIQStop.Style = Sunny.UI.UIStyle.Custom;
            this.btnIQStop.StyleCustomMode = true;
            this.btnIQStop.Symbol = 61517;
            this.btnIQStop.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStop.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            this.btnIQStart.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStart.ForePressColor = System.Drawing.Color.Transparent;
            this.btnIQStart.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIQStart.Location = new System.Drawing.Point(21, 216);
            this.btnIQStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIQStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnIQStart.Name = "btnIQStart";
            this.btnIQStart.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnIQStart.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStart.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnIQStart.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStart.RectPressColor = System.Drawing.Color.Transparent;
            this.btnIQStart.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnIQStart.Size = new System.Drawing.Size(85, 30);
            this.btnIQStart.Style = Sunny.UI.UIStyle.Custom;
            this.btnIQStart.StyleCustomMode = true;
            this.btnIQStart.Symbol = 61515;
            this.btnIQStart.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnIQStart.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            this.tbPixelSize.DecimalPlaces = 3;
            this.tbPixelSize.DoubleValue = 0.071D;
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
            this.tbPixelSize.Text = "0.071";
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
            // uiGroupBox5
            // 
            this.uiGroupBox5.Controls.Add(this.TbTransparent);
            this.uiGroupBox5.Controls.Add(this.chkAlphaImg);
            this.uiGroupBox5.Controls.Add(this.lblMasterPixel);
            this.uiGroupBox5.Controls.Add(this.lblMasterHeight);
            this.uiGroupBox5.Controls.Add(this.lblMasterWidth);
            this.uiGroupBox5.Controls.Add(this.label32);
            this.uiGroupBox5.Controls.Add(this.label36);
            this.uiGroupBox5.Controls.Add(this.label37);
            this.uiGroupBox5.Controls.Add(this.lblMasterFocus);
            this.uiGroupBox5.Controls.Add(this.label30);
            this.uiGroupBox5.Controls.Add(this.BtnIQDataSave);
            this.uiGroupBox5.Controls.Add(this.BtnIQLoad);
            this.uiGroupBox5.FillColor = System.Drawing.Color.White;
            this.uiGroupBox5.FillColor2 = System.Drawing.Color.White;
            this.uiGroupBox5.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox5.Location = new System.Drawing.Point(5, 535);
            this.uiGroupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox5.Name = "uiGroupBox5";
            this.uiGroupBox5.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox5.Size = new System.Drawing.Size(220, 203);
            this.uiGroupBox5.TabIndex = 3579;
            this.uiGroupBox5.Text = "I.Q MaterData";
            this.uiGroupBox5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbTransparent
            // 
            this.TbTransparent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbTransparent.FillColor = System.Drawing.SystemColors.Control;
            this.TbTransparent.Font = new System.Drawing.Font("Arial", 8F);
            this.TbTransparent.ForeColor = System.Drawing.Color.Black;
            this.TbTransparent.Location = new System.Drawing.Point(112, 136);
            this.TbTransparent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbTransparent.Maximum = 1D;
            this.TbTransparent.Minimum = 0D;
            this.TbTransparent.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbTransparent.Name = "TbTransparent";
            this.TbTransparent.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbTransparent.RectColor = System.Drawing.Color.DimGray;
            this.TbTransparent.ShowText = false;
            this.TbTransparent.Size = new System.Drawing.Size(60, 20);
            this.TbTransparent.TabIndex = 3588;
            this.TbTransparent.Text = "0.00";
            this.TbTransparent.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbTransparent.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.TbTransparent.Watermark = "";
            // 
            // chkAlphaImg
            // 
            this.chkAlphaImg.AutoSize = true;
            this.chkAlphaImg.Location = new System.Drawing.Point(15, 139);
            this.chkAlphaImg.Name = "chkAlphaImg";
            this.chkAlphaImg.Size = new System.Drawing.Size(86, 17);
            this.chkAlphaImg.TabIndex = 3587;
            this.chkAlphaImg.Text = "Transparent";
            this.chkAlphaImg.UseVisualStyleBackColor = true;
            // 
            // lblMasterPixel
            // 
            this.lblMasterPixel.Font = new System.Drawing.Font("Arial", 8F);
            this.lblMasterPixel.ForeColor = System.Drawing.Color.Black;
            this.lblMasterPixel.Location = new System.Drawing.Point(125, 81);
            this.lblMasterPixel.Name = "lblMasterPixel";
            this.lblMasterPixel.Size = new System.Drawing.Size(91, 25);
            this.lblMasterPixel.TabIndex = 3586;
            this.lblMasterPixel.Text = "000.000";
            this.lblMasterPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMasterHeight
            // 
            this.lblMasterHeight.Font = new System.Drawing.Font("Arial", 8F);
            this.lblMasterHeight.ForeColor = System.Drawing.Color.Black;
            this.lblMasterHeight.Location = new System.Drawing.Point(125, 55);
            this.lblMasterHeight.Name = "lblMasterHeight";
            this.lblMasterHeight.Size = new System.Drawing.Size(91, 25);
            this.lblMasterHeight.TabIndex = 3585;
            this.lblMasterHeight.Text = "000.000";
            this.lblMasterHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMasterWidth
            // 
            this.lblMasterWidth.Font = new System.Drawing.Font("Arial", 8F);
            this.lblMasterWidth.ForeColor = System.Drawing.Color.Black;
            this.lblMasterWidth.Location = new System.Drawing.Point(125, 32);
            this.lblMasterWidth.Name = "lblMasterWidth";
            this.lblMasterWidth.Size = new System.Drawing.Size(91, 25);
            this.lblMasterWidth.TabIndex = 3584;
            this.lblMasterWidth.Text = "000.000";
            this.lblMasterWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Arial", 8F);
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(7, 55);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(100, 25);
            this.label32.TabIndex = 3583;
            this.label32.Text = "Master Height (mm)";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Arial", 8F);
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(7, 81);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(109, 25);
            this.label36.TabIndex = 3582;
            this.label36.Text = "Pixel Size (mm)";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Arial", 8F);
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(7, 29);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 25);
            this.label37.TabIndex = 3581;
            this.label37.Text = "Master Width (mm)";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMasterFocus
            // 
            this.lblMasterFocus.Font = new System.Drawing.Font("Arial", 8F);
            this.lblMasterFocus.ForeColor = System.Drawing.Color.Black;
            this.lblMasterFocus.Location = new System.Drawing.Point(125, 110);
            this.lblMasterFocus.Name = "lblMasterFocus";
            this.lblMasterFocus.Size = new System.Drawing.Size(91, 25);
            this.lblMasterFocus.TabIndex = 3580;
            this.lblMasterFocus.Text = "000.000";
            this.lblMasterFocus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Arial", 8F);
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(7, 110);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(113, 25);
            this.label30.TabIndex = 3579;
            this.label30.Text = "Master Focus Value :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnIQDataSave
            // 
            this.BtnIQDataSave.BackColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.CircleRectWidth = 0;
            this.BtnIQDataSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIQDataSave.FillColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnIQDataSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQDataSave.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQDataSave.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIQDataSave.Location = new System.Drawing.Point(112, 162);
            this.BtnIQDataSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnIQDataSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnIQDataSave.Name = "BtnIQDataSave";
            this.BtnIQDataSave.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BtnIQDataSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQDataSave.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQDataSave.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnIQDataSave.Size = new System.Drawing.Size(85, 30);
            this.BtnIQDataSave.Style = Sunny.UI.UIStyle.Custom;
            this.BtnIQDataSave.StyleCustomMode = true;
            this.BtnIQDataSave.Symbol = 61639;
            this.BtnIQDataSave.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQDataSave.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQDataSave.SymbolSize = 18;
            this.BtnIQDataSave.TabIndex = 3578;
            this.BtnIQDataSave.Tag = "ZoomIn";
            this.BtnIQDataSave.Text = "Save";
            this.BtnIQDataSave.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnIQDataSave.Click += new System.EventHandler(this.BtnIQDataSave_Click);
            // 
            // BtnIQLoad
            // 
            this.BtnIQLoad.BackColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.CircleRectWidth = 0;
            this.BtnIQLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIQLoad.FillColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnIQLoad.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnIQLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQLoad.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQLoad.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIQLoad.Location = new System.Drawing.Point(21, 162);
            this.BtnIQLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnIQLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnIQLoad.Name = "BtnIQLoad";
            this.BtnIQLoad.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BtnIQLoad.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQLoad.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQLoad.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnIQLoad.Size = new System.Drawing.Size(85, 30);
            this.BtnIQLoad.Style = Sunny.UI.UIStyle.Custom;
            this.BtnIQLoad.StyleCustomMode = true;
            this.BtnIQLoad.Symbol = 61717;
            this.BtnIQLoad.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQLoad.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnIQLoad.SymbolSize = 18;
            this.BtnIQLoad.TabIndex = 3543;
            this.BtnIQLoad.Tag = "ZoomIn";
            this.BtnIQLoad.Text = "Load";
            this.BtnIQLoad.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnIQLoad.Click += new System.EventHandler(this.BtnIQLoad_Click);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.uiTabControl6);
            this.tabPage10.Location = new System.Drawing.Point(0, 40);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(954, 744);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "02) Model";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // uiTabControl6
            // 
            this.uiTabControl6.Controls.Add(this.tabPage13);
            this.uiTabControl6.Controls.Add(this.tabPage12);
            this.uiTabControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl6.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl6.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiTabControl6.ItemSize = new System.Drawing.Size(140, 40);
            this.uiTabControl6.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl6.MainPage = "";
            this.uiTabControl6.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl6.Name = "uiTabControl6";
            this.uiTabControl6.SelectedIndex = 0;
            this.uiTabControl6.Size = new System.Drawing.Size(954, 744);
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
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.uiGroupBox2);
            this.tabPage13.Controls.Add(this.panel1);
            this.tabPage13.Controls.Add(this.uiGroupBox17);
            this.tabPage13.Controls.Add(this.uiGroupBox16);
            this.tabPage13.Location = new System.Drawing.Point(0, 40);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(954, 704);
            this.tabPage13.TabIndex = 3;
            this.tabPage13.Text = "Fiducial and QR Code";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.txtArrayCount);
            this.uiGroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox2.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox2.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox2.Location = new System.Drawing.Point(5, 0);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Radius = 10;
            this.uiGroupBox2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox2.Size = new System.Drawing.Size(323, 69);
            this.uiGroupBox2.TabIndex = 3615;
            this.uiGroupBox2.Text = "Array Setting";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtArrayCount
            // 
            this.txtArrayCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArrayCount.FillColor = System.Drawing.SystemColors.Control;
            this.txtArrayCount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArrayCount.ForeColor = System.Drawing.Color.Black;
            this.txtArrayCount.Location = new System.Drawing.Point(11, 26);
            this.txtArrayCount.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtArrayCount.MinimumSize = new System.Drawing.Size(1, 20);
            this.txtArrayCount.Name = "txtArrayCount";
            this.txtArrayCount.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtArrayCount.RectColor = System.Drawing.Color.DimGray;
            this.txtArrayCount.ShowText = false;
            this.txtArrayCount.Size = new System.Drawing.Size(264, 37);
            this.txtArrayCount.TabIndex = 3705;
            this.txtArrayCount.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtArrayCount.Watermark = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.TbLibraryName);
            this.panel1.Controls.Add(this.btnLibrarySelect);
            this.panel1.Controls.Add(this.label80);
            this.panel1.Controls.Add(this.label75);
            this.panel1.Location = new System.Drawing.Point(330, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 696);
            this.panel1.TabIndex = 3614;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Cogdis_FiducialPreView);
            this.panel4.Controls.Add(this.label78);
            this.panel4.Location = new System.Drawing.Point(3, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(616, 621);
            this.panel4.TabIndex = 3615;
            // 
            // Cogdis_FiducialPreView
            // 
            this.Cogdis_FiducialPreView.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.Cogdis_FiducialPreView.ColorMapLowerRoiLimit = 0D;
            this.Cogdis_FiducialPreView.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.Cogdis_FiducialPreView.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.Cogdis_FiducialPreView.ColorMapUpperRoiLimit = 1D;
            this.Cogdis_FiducialPreView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cogdis_FiducialPreView.DoubleTapZoomCycleLength = 2;
            this.Cogdis_FiducialPreView.DoubleTapZoomSensitivity = 2.5D;
            this.Cogdis_FiducialPreView.Location = new System.Drawing.Point(0, 37);
            this.Cogdis_FiducialPreView.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.Cogdis_FiducialPreView.MouseWheelSensitivity = 1D;
            this.Cogdis_FiducialPreView.Name = "Cogdis_FiducialPreView";
            this.Cogdis_FiducialPreView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cogdis_FiducialPreView.OcxState")));
            this.Cogdis_FiducialPreView.Size = new System.Drawing.Size(616, 584);
            this.Cogdis_FiducialPreView.TabIndex = 3453;
            this.Cogdis_FiducialPreView.TabStop = false;
            this.Cogdis_FiducialPreView.Tag = "0";
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label78.Dock = System.Windows.Forms.DockStyle.Top;
            this.label78.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label78.Font = new System.Drawing.Font("Arial", 15F);
            this.label78.ForeColor = System.Drawing.Color.White;
            this.label78.Location = new System.Drawing.Point(0, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(616, 37);
            this.label78.TabIndex = 3452;
            this.label78.Text = "Fiducial PreView";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbLibraryName
            // 
            this.TbLibraryName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbLibraryName.FillColor = System.Drawing.SystemColors.Control;
            this.TbLibraryName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbLibraryName.ForeColor = System.Drawing.Color.Black;
            this.TbLibraryName.Location = new System.Drawing.Point(79, 29);
            this.TbLibraryName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbLibraryName.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbLibraryName.Name = "TbLibraryName";
            this.TbLibraryName.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbLibraryName.RectColor = System.Drawing.Color.DimGray;
            this.TbLibraryName.ShowText = false;
            this.TbLibraryName.Size = new System.Drawing.Size(395, 37);
            this.TbLibraryName.TabIndex = 3704;
            this.TbLibraryName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbLibraryName.Watermark = "";
            // 
            // btnLibrarySelect
            // 
            this.btnLibrarySelect.BackColor = System.Drawing.Color.White;
            this.btnLibrarySelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLibrarySelect.FillColor = System.Drawing.Color.White;
            this.btnLibrarySelect.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLibrarySelect.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLibrarySelect.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLibrarySelect.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btnLibrarySelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.Location = new System.Drawing.Point(476, 29);
            this.btnLibrarySelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLibrarySelect.Name = "btnLibrarySelect";
            this.btnLibrarySelect.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.Size = new System.Drawing.Size(142, 37);
            this.btnLibrarySelect.Style = Sunny.UI.UIStyle.Custom;
            this.btnLibrarySelect.StyleCustomMode = true;
            this.btnLibrarySelect.Symbol = 61442;
            this.btnLibrarySelect.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.SymbolPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnLibrarySelect.SymbolSize = 10;
            this.btnLibrarySelect.TabIndex = 3703;
            this.btnLibrarySelect.Text = "Select";
            this.btnLibrarySelect.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLibrarySelect.Click += new System.EventHandler(this.btnLibrarySelect_Click);
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label80.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label80.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label80.Location = new System.Drawing.Point(2, 29);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(75, 37);
            this.label80.TabIndex = 3454;
            this.label80.Text = "Name";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label75.Dock = System.Windows.Forms.DockStyle.Top;
            this.label75.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label75.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.White;
            this.label75.Location = new System.Drawing.Point(0, 0);
            this.label75.Name = "label75";
            this.label75.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label75.Size = new System.Drawing.Size(621, 27);
            this.label75.TabIndex = 3444;
            this.label75.Text = "Fiducial Library";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox17
            // 
            this.uiGroupBox17.Controls.Add(this.lbQrCodeData);
            this.uiGroupBox17.Controls.Add(this.btnQrRead);
            this.uiGroupBox17.Controls.Add(this.uiLine20);
            this.uiGroupBox17.Controls.Add(this.btnQrSet);
            this.uiGroupBox17.Controls.Add(this.btnQrRoi);
            this.uiGroupBox17.Controls.Add(this.label3);
            this.uiGroupBox17.Controls.Add(this.uiLine18);
            this.uiGroupBox17.Controls.Add(this.comboArray);
            this.uiGroupBox17.Controls.Add(this.btnSave_QR);
            this.uiGroupBox17.Controls.Add(this.btnArrayCrop_Set);
            this.uiGroupBox17.Controls.Add(this.btnArrayCrop_Roi);
            this.uiGroupBox17.Controls.Add(this.label60);
            this.uiGroupBox17.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox17.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox17.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox17.Location = new System.Drawing.Point(5, 518);
            this.uiGroupBox17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox17.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox17.Name = "uiGroupBox17";
            this.uiGroupBox17.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox17.Radius = 10;
            this.uiGroupBox17.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox17.Size = new System.Drawing.Size(323, 181);
            this.uiGroupBox17.TabIndex = 3613;
            this.uiGroupBox17.Text = "Array Region";
            this.uiGroupBox17.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbQrCodeData
            // 
            this.lbQrCodeData.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQrCodeData.ForeColor = System.Drawing.Color.Black;
            this.lbQrCodeData.Location = new System.Drawing.Point(8, 103);
            this.lbQrCodeData.Name = "lbQrCodeData";
            this.lbQrCodeData.Size = new System.Drawing.Size(289, 20);
            this.lbQrCodeData.TabIndex = 3626;
            this.lbQrCodeData.Text = "Data :";
            this.lbQrCodeData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnQrRead
            // 
            this.btnQrRead.BackColor = System.Drawing.Color.Transparent;
            this.btnQrRead.CircleRectWidth = 0;
            this.btnQrRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQrRead.FillColor = System.Drawing.Color.Transparent;
            this.btnQrRead.FillColor2 = System.Drawing.Color.Transparent;
            this.btnQrRead.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnQrRead.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnQrRead.FillPressColor = System.Drawing.Color.Transparent;
            this.btnQrRead.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnQrRead.Font = new System.Drawing.Font("Arial", 10F);
            this.btnQrRead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRead.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnQrRead.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRead.ForePressColor = System.Drawing.Color.Transparent;
            this.btnQrRead.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnQrRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQrRead.Location = new System.Drawing.Point(223, 73);
            this.btnQrRead.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnQrRead.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnQrRead.Name = "btnQrRead";
            this.btnQrRead.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQrRead.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRead.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnQrRead.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRead.RectPressColor = System.Drawing.Color.Transparent;
            this.btnQrRead.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnQrRead.Size = new System.Drawing.Size(74, 23);
            this.btnQrRead.Style = Sunny.UI.UIStyle.Custom;
            this.btnQrRead.StyleCustomMode = true;
            this.btnQrRead.Symbol = 361482;
            this.btnQrRead.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRead.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRead.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnQrRead.SymbolSize = 18;
            this.btnQrRead.TabIndex = 3625;
            this.btnQrRead.Tag = "ZoomIn";
            this.btnQrRead.Text = "Read";
            this.btnQrRead.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQrRead.Click += new System.EventHandler(this.OnClickArrayDMCode);
            // 
            // uiLine20
            // 
            this.uiLine20.BackColor = System.Drawing.Color.Transparent;
            this.uiLine20.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine20.LineColor = System.Drawing.Color.Black;
            this.uiLine20.Location = new System.Drawing.Point(6, 126);
            this.uiLine20.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine20.Name = "uiLine20";
            this.uiLine20.Size = new System.Drawing.Size(313, 10);
            this.uiLine20.TabIndex = 3624;
            // 
            // btnQrSet
            // 
            this.btnQrSet.BackColor = System.Drawing.Color.Transparent;
            this.btnQrSet.CircleRectWidth = 0;
            this.btnQrSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQrSet.FillColor = System.Drawing.Color.Transparent;
            this.btnQrSet.FillColor2 = System.Drawing.Color.Transparent;
            this.btnQrSet.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnQrSet.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnQrSet.FillPressColor = System.Drawing.Color.Transparent;
            this.btnQrSet.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnQrSet.Font = new System.Drawing.Font("Arial", 10F);
            this.btnQrSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrSet.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnQrSet.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrSet.ForePressColor = System.Drawing.Color.Transparent;
            this.btnQrSet.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnQrSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQrSet.Location = new System.Drawing.Point(155, 73);
            this.btnQrSet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnQrSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnQrSet.Name = "btnQrSet";
            this.btnQrSet.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQrSet.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrSet.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnQrSet.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrSet.RectPressColor = System.Drawing.Color.Transparent;
            this.btnQrSet.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnQrSet.Size = new System.Drawing.Size(66, 23);
            this.btnQrSet.Style = Sunny.UI.UIStyle.Custom;
            this.btnQrSet.StyleCustomMode = true;
            this.btnQrSet.Symbol = 361773;
            this.btnQrSet.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrSet.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrSet.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnQrSet.SymbolSize = 18;
            this.btnQrSet.TabIndex = 3622;
            this.btnQrSet.Tag = "ZoomIn";
            this.btnQrSet.Text = "SET";
            this.btnQrSet.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQrSet.Click += new System.EventHandler(this.OnClickArrayDMCode);
            // 
            // btnQrRoi
            // 
            this.btnQrRoi.BackColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.CircleRectWidth = 0;
            this.btnQrRoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQrRoi.FillColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.FillColor2 = System.Drawing.Color.Transparent;
            this.btnQrRoi.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.FillPressColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.Font = new System.Drawing.Font("Arial", 10F);
            this.btnQrRoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRoi.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRoi.ForePressColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQrRoi.Location = new System.Drawing.Point(86, 73);
            this.btnQrRoi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnQrRoi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnQrRoi.Name = "btnQrRoi";
            this.btnQrRoi.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQrRoi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRoi.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRoi.RectPressColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnQrRoi.Size = new System.Drawing.Size(66, 23);
            this.btnQrRoi.Style = Sunny.UI.UIStyle.Custom;
            this.btnQrRoi.StyleCustomMode = true;
            this.btnQrRoi.Symbol = 62024;
            this.btnQrRoi.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRoi.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnQrRoi.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnQrRoi.SymbolSize = 18;
            this.btnQrRoi.TabIndex = 3621;
            this.btnQrRoi.Tag = "ZoomIn";
            this.btnQrRoi.Text = "ROI";
            this.btnQrRoi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQrRoi.Click += new System.EventHandler(this.OnClickArrayDMCode);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 3620;
            this.label3.Text = "Data Matrix";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine18
            // 
            this.uiLine18.BackColor = System.Drawing.Color.Transparent;
            this.uiLine18.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine18.LineColor = System.Drawing.Color.Black;
            this.uiLine18.Location = new System.Drawing.Point(6, 60);
            this.uiLine18.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine18.Name = "uiLine18";
            this.uiLine18.Size = new System.Drawing.Size(313, 10);
            this.uiLine18.TabIndex = 3619;
            // 
            // comboArray
            // 
            this.comboArray.DataSource = null;
            this.comboArray.FillColor = System.Drawing.SystemColors.Control;
            this.comboArray.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.comboArray.ForeColor = System.Drawing.Color.Black;
            this.comboArray.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboArray.ItemForeColor = System.Drawing.Color.White;
            this.comboArray.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboArray.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboArray.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboArray.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboArray.Location = new System.Drawing.Point(87, 33);
            this.comboArray.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboArray.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboArray.Name = "comboArray";
            this.comboArray.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboArray.RectColor = System.Drawing.Color.DimGray;
            this.comboArray.Size = new System.Drawing.Size(74, 26);
            this.comboArray.SymbolSize = 24;
            this.comboArray.TabIndex = 3618;
            this.comboArray.Text = "1";
            this.comboArray.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboArray.Watermark = "";
            this.comboArray.SelectedIndexChanged += new System.EventHandler(this.comboArrayNumberSelectedIndexChanged);
            // 
            // btnSave_QR
            // 
            this.btnSave_QR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave_QR.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnSave_QR.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSave_QR.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnSave_QR.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSave_QR.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSave_QR.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave_QR.Location = new System.Drawing.Point(187, 140);
            this.btnSave_QR.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave_QR.Name = "btnSave_QR";
            this.btnSave_QR.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnSave_QR.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnSave_QR.RectPressColor = System.Drawing.Color.White;
            this.btnSave_QR.RectSelectedColor = System.Drawing.Color.White;
            this.btnSave_QR.Size = new System.Drawing.Size(133, 33);
            this.btnSave_QR.Style = Sunny.UI.UIStyle.Custom;
            this.btnSave_QR.StyleCustomMode = true;
            this.btnSave_QR.Symbol = 61639;
            this.btnSave_QR.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnSave_QR.SymbolSize = 20;
            this.btnSave_QR.TabIndex = 3617;
            this.btnSave_QR.Text = "Save";
            this.btnSave_QR.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnArrayCrop_Set
            // 
            this.btnArrayCrop_Set.BackColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.CircleRectWidth = 0;
            this.btnArrayCrop_Set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArrayCrop_Set.FillColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.FillColor2 = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.FillPressColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.Font = new System.Drawing.Font("Arial", 10F);
            this.btnArrayCrop_Set.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Set.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Set.ForePressColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArrayCrop_Set.Location = new System.Drawing.Point(231, 34);
            this.btnArrayCrop_Set.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnArrayCrop_Set.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnArrayCrop_Set.Name = "btnArrayCrop_Set";
            this.btnArrayCrop_Set.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnArrayCrop_Set.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Set.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Set.RectPressColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Set.Size = new System.Drawing.Size(66, 23);
            this.btnArrayCrop_Set.Style = Sunny.UI.UIStyle.Custom;
            this.btnArrayCrop_Set.StyleCustomMode = true;
            this.btnArrayCrop_Set.Symbol = 361773;
            this.btnArrayCrop_Set.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Set.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Set.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnArrayCrop_Set.SymbolSize = 18;
            this.btnArrayCrop_Set.TabIndex = 3598;
            this.btnArrayCrop_Set.Tag = "ZoomIn";
            this.btnArrayCrop_Set.Text = "SET";
            this.btnArrayCrop_Set.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnArrayCrop_Set.Click += new System.EventHandler(this.btnArrayCrop_Set_Click);
            // 
            // btnArrayCrop_Roi
            // 
            this.btnArrayCrop_Roi.BackColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.CircleRectWidth = 0;
            this.btnArrayCrop_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArrayCrop_Roi.FillColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.FillColor2 = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.FillPressColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.Font = new System.Drawing.Font("Arial", 10F);
            this.btnArrayCrop_Roi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Roi.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Roi.ForePressColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArrayCrop_Roi.Location = new System.Drawing.Point(164, 34);
            this.btnArrayCrop_Roi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnArrayCrop_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnArrayCrop_Roi.Name = "btnArrayCrop_Roi";
            this.btnArrayCrop_Roi.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnArrayCrop_Roi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Roi.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Roi.RectPressColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnArrayCrop_Roi.Size = new System.Drawing.Size(66, 23);
            this.btnArrayCrop_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnArrayCrop_Roi.StyleCustomMode = true;
            this.btnArrayCrop_Roi.Symbol = 62024;
            this.btnArrayCrop_Roi.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Roi.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnArrayCrop_Roi.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnArrayCrop_Roi.SymbolSize = 18;
            this.btnArrayCrop_Roi.TabIndex = 3597;
            this.btnArrayCrop_Roi.Tag = "ZoomIn";
            this.btnArrayCrop_Roi.Text = "ROI";
            this.btnArrayCrop_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnArrayCrop_Roi.Click += new System.EventHandler(this.btnArrayCrop_Roi_Click);
            // 
            // label60
            // 
            this.label60.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(8, 33);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(72, 20);
            this.label60.TabIndex = 3590;
            this.label60.Text = "Array Index";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox16
            // 
            this.uiGroupBox16.Controls.Add(this.chkChangeFiducialMark);
            this.uiGroupBox16.Controls.Add(this.label21);
            this.uiGroupBox16.Controls.Add(this.label7);
            this.uiGroupBox16.Controls.Add(this.label2);
            this.uiGroupBox16.Controls.Add(this.btnImageAlign_Rotate);
            this.uiGroupBox16.Controls.Add(this.btnResetMaster);
            this.uiGroupBox16.Controls.Add(this.btnFiducial_MeasureToMaster);
            this.uiGroupBox16.Controls.Add(this.uiLine26);
            this.uiGroupBox16.Controls.Add(this.lblDegreeDelta);
            this.uiGroupBox16.Controls.Add(this.uiLine24);
            this.uiGroupBox16.Controls.Add(this.btnFiducial_Measure);
            this.uiGroupBox16.Controls.Add(this.lblDegreeMeasure);
            this.uiGroupBox16.Controls.Add(this.lblDegreeMaster);
            this.uiGroupBox16.Controls.Add(this.uiLine22);
            this.uiGroupBox16.Controls.Add(this.uiButton1);
            this.uiGroupBox16.Controls.Add(this.chkAlignNoUse);
            this.uiGroupBox16.Controls.Add(this.btnFiducialFind2);
            this.uiGroupBox16.Controls.Add(this.btnFiducialFind1);
            this.uiGroupBox16.Controls.Add(this.cogDisplay_Fiducial_Pattern1);
            this.uiGroupBox16.Controls.Add(this.btnFiducialTrain2);
            this.uiGroupBox16.Controls.Add(this.btnFiducialROI2);
            this.uiGroupBox16.Controls.Add(this.uiLine16);
            this.uiGroupBox16.Controls.Add(this.btnFiducialTrain1);
            this.uiGroupBox16.Controls.Add(this.btnFiducialROI1);
            this.uiGroupBox16.Controls.Add(this.uiLine19);
            this.uiGroupBox16.Controls.Add(this.label68);
            this.uiGroupBox16.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox16.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox16.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox16.Location = new System.Drawing.Point(5, 61);
            this.uiGroupBox16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox16.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox16.Name = "uiGroupBox16";
            this.uiGroupBox16.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox16.Radius = 10;
            this.uiGroupBox16.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox16.Size = new System.Drawing.Size(323, 456);
            this.uiGroupBox16.TabIndex = 3470;
            this.uiGroupBox16.Text = "Fiducial Mark";
            this.uiGroupBox16.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkChangeFiducialMark
            // 
            this.chkChangeFiducialMark.AutoSize = true;
            this.chkChangeFiducialMark.BackColor = System.Drawing.Color.Transparent;
            this.chkChangeFiducialMark.Font = new System.Drawing.Font("Arial", 8F);
            this.chkChangeFiducialMark.ForeColor = System.Drawing.Color.Black;
            this.chkChangeFiducialMark.Location = new System.Drawing.Point(11, 47);
            this.chkChangeFiducialMark.Name = "chkChangeFiducialMark";
            this.chkChangeFiducialMark.Size = new System.Drawing.Size(125, 18);
            this.chkChangeFiducialMark.TabIndex = 3641;
            this.chkChangeFiducialMark.Text = "Change FiducialMark";
            this.chkChangeFiducialMark.UseVisualStyleBackColor = false;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(8, 291);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 20);
            this.label21.TabIndex = 3640;
            this.label21.Text = "Delta :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 3639;
            this.label7.Text = "Measure :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 3638;
            this.label2.Text = "Master :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnImageAlign_Rotate
            // 
            this.btnImageAlign_Rotate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImageAlign_Rotate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnImageAlign_Rotate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnImageAlign_Rotate.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnImageAlign_Rotate.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnImageAlign_Rotate.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnImageAlign_Rotate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImageAlign_Rotate.Location = new System.Drawing.Point(6, 418);
            this.btnImageAlign_Rotate.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnImageAlign_Rotate.Name = "btnImageAlign_Rotate";
            this.btnImageAlign_Rotate.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnImageAlign_Rotate.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnImageAlign_Rotate.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnImageAlign_Rotate.RectSelectedColor = System.Drawing.Color.White;
            this.btnImageAlign_Rotate.Size = new System.Drawing.Size(167, 33);
            this.btnImageAlign_Rotate.Style = Sunny.UI.UIStyle.Custom;
            this.btnImageAlign_Rotate.StyleCustomMode = true;
            this.btnImageAlign_Rotate.Symbol = 61473;
            this.btnImageAlign_Rotate.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnImageAlign_Rotate.SymbolSize = 20;
            this.btnImageAlign_Rotate.TabIndex = 3637;
            this.btnImageAlign_Rotate.Text = "Image Align (Rotate)";
            this.btnImageAlign_Rotate.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImageAlign_Rotate.Click += new System.EventHandler(this.btnImageAlign_Rotate_Click);
            // 
            // btnResetMaster
            // 
            this.btnResetMaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetMaster.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnResetMaster.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnResetMaster.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnResetMaster.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnResetMaster.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnResetMaster.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetMaster.Location = new System.Drawing.Point(190, 418);
            this.btnResetMaster.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnResetMaster.Name = "btnResetMaster";
            this.btnResetMaster.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnResetMaster.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnResetMaster.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnResetMaster.RectSelectedColor = System.Drawing.Color.White;
            this.btnResetMaster.Size = new System.Drawing.Size(133, 33);
            this.btnResetMaster.Style = Sunny.UI.UIStyle.Custom;
            this.btnResetMaster.StyleCustomMode = true;
            this.btnResetMaster.Symbol = 261773;
            this.btnResetMaster.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnResetMaster.SymbolSize = 20;
            this.btnResetMaster.TabIndex = 3636;
            this.btnResetMaster.Text = "Reset Master";
            this.btnResetMaster.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnResetMaster.Click += new System.EventHandler(this.btnResetMaster_Click);
            // 
            // btnFiducial_MeasureToMaster
            // 
            this.btnFiducial_MeasureToMaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiducial_MeasureToMaster.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_MeasureToMaster.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFiducial_MeasureToMaster.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_MeasureToMaster.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFiducial_MeasureToMaster.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFiducial_MeasureToMaster.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiducial_MeasureToMaster.Location = new System.Drawing.Point(6, 374);
            this.btnFiducial_MeasureToMaster.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFiducial_MeasureToMaster.Name = "btnFiducial_MeasureToMaster";
            this.btnFiducial_MeasureToMaster.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_MeasureToMaster.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_MeasureToMaster.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_MeasureToMaster.RectSelectedColor = System.Drawing.Color.White;
            this.btnFiducial_MeasureToMaster.Size = new System.Drawing.Size(167, 33);
            this.btnFiducial_MeasureToMaster.Style = Sunny.UI.UIStyle.Custom;
            this.btnFiducial_MeasureToMaster.StyleCustomMode = true;
            this.btnFiducial_MeasureToMaster.Symbol = 57513;
            this.btnFiducial_MeasureToMaster.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnFiducial_MeasureToMaster.SymbolSize = 20;
            this.btnFiducial_MeasureToMaster.TabIndex = 3635;
            this.btnFiducial_MeasureToMaster.Text = "Measure -> Master";
            this.btnFiducial_MeasureToMaster.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFiducial_MeasureToMaster.Click += new System.EventHandler(this.btnFiducial_MeasureToMaster_Click);
            // 
            // uiLine26
            // 
            this.uiLine26.BackColor = System.Drawing.Color.Transparent;
            this.uiLine26.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine26.LineColor = System.Drawing.Color.Black;
            this.uiLine26.Location = new System.Drawing.Point(6, 314);
            this.uiLine26.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine26.Name = "uiLine26";
            this.uiLine26.Size = new System.Drawing.Size(313, 10);
            this.uiLine26.TabIndex = 3634;
            // 
            // lblDegreeDelta
            // 
            this.lblDegreeDelta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDegreeDelta.ForeColor = System.Drawing.Color.Black;
            this.lblDegreeDelta.Location = new System.Drawing.Point(86, 290);
            this.lblDegreeDelta.Name = "lblDegreeDelta";
            this.lblDegreeDelta.Size = new System.Drawing.Size(157, 20);
            this.lblDegreeDelta.TabIndex = 3633;
            this.lblDegreeDelta.Text = "--";
            this.lblDegreeDelta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine24
            // 
            this.uiLine24.BackColor = System.Drawing.Color.Transparent;
            this.uiLine24.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine24.LineColor = System.Drawing.Color.Black;
            this.uiLine24.Location = new System.Drawing.Point(6, 277);
            this.uiLine24.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine24.Name = "uiLine24";
            this.uiLine24.Size = new System.Drawing.Size(313, 10);
            this.uiLine24.TabIndex = 3632;
            // 
            // btnFiducial_Measure
            // 
            this.btnFiducial_Measure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiducial_Measure.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_Measure.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFiducial_Measure.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_Measure.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFiducial_Measure.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFiducial_Measure.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiducial_Measure.Location = new System.Drawing.Point(6, 330);
            this.btnFiducial_Measure.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFiducial_Measure.Name = "btnFiducial_Measure";
            this.btnFiducial_Measure.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_Measure.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_Measure.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducial_Measure.RectSelectedColor = System.Drawing.Color.White;
            this.btnFiducial_Measure.Size = new System.Drawing.Size(167, 33);
            this.btnFiducial_Measure.Style = Sunny.UI.UIStyle.Custom;
            this.btnFiducial_Measure.StyleCustomMode = true;
            this.btnFiducial_Measure.Symbol = 362790;
            this.btnFiducial_Measure.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnFiducial_Measure.SymbolSize = 20;
            this.btnFiducial_Measure.TabIndex = 3631;
            this.btnFiducial_Measure.Text = "Measure";
            this.btnFiducial_Measure.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFiducial_Measure.Click += new System.EventHandler(this.btnFiducial_Measure_Click);
            // 
            // lblDegreeMeasure
            // 
            this.lblDegreeMeasure.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDegreeMeasure.ForeColor = System.Drawing.Color.Black;
            this.lblDegreeMeasure.Location = new System.Drawing.Point(86, 254);
            this.lblDegreeMeasure.Name = "lblDegreeMeasure";
            this.lblDegreeMeasure.Size = new System.Drawing.Size(154, 20);
            this.lblDegreeMeasure.TabIndex = 3630;
            this.lblDegreeMeasure.Text = "--";
            this.lblDegreeMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDegreeMaster
            // 
            this.lblDegreeMaster.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDegreeMaster.ForeColor = System.Drawing.Color.Black;
            this.lblDegreeMaster.Location = new System.Drawing.Point(86, 217);
            this.lblDegreeMaster.Name = "lblDegreeMaster";
            this.lblDegreeMaster.Size = new System.Drawing.Size(157, 20);
            this.lblDegreeMaster.TabIndex = 3628;
            this.lblDegreeMaster.Text = "--";
            this.lblDegreeMaster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine22
            // 
            this.uiLine22.BackColor = System.Drawing.Color.Transparent;
            this.uiLine22.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine22.LineColor = System.Drawing.Color.Black;
            this.uiLine22.Location = new System.Drawing.Point(6, 240);
            this.uiLine22.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine22.Name = "uiLine22";
            this.uiLine22.Size = new System.Drawing.Size(313, 10);
            this.uiLine22.TabIndex = 3627;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton1.Font = new System.Drawing.Font("Arial", 8F);
            this.uiButton1.Location = new System.Drawing.Point(232, 26);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiButton1.Size = new System.Drawing.Size(78, 24);
            this.uiButton1.TabIndex = 3618;
            this.uiButton1.Text = "GRAB (5)";
            this.uiButton1.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiButton1.Click += new System.EventHandler(this.OnClickCameraOperation);
            // 
            // chkAlignNoUse
            // 
            this.chkAlignNoUse.AutoSize = true;
            this.chkAlignNoUse.BackColor = System.Drawing.Color.Transparent;
            this.chkAlignNoUse.Font = new System.Drawing.Font("Arial", 8F);
            this.chkAlignNoUse.ForeColor = System.Drawing.Color.Black;
            this.chkAlignNoUse.Location = new System.Drawing.Point(11, 26);
            this.chkAlignNoUse.Name = "chkAlignNoUse";
            this.chkAlignNoUse.Size = new System.Drawing.Size(187, 18);
            this.chkAlignNoUse.TabIndex = 3616;
            this.chkAlignNoUse.Text = "No Align (When you set first time)";
            this.chkAlignNoUse.UseVisualStyleBackColor = false;
            // 
            // btnFiducialFind2
            // 
            this.btnFiducialFind2.BackColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.CircleRectWidth = 0;
            this.btnFiducialFind2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiducialFind2.FillColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.FillColor2 = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.FillPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.Font = new System.Drawing.Font("Arial", 10F);
            this.btnFiducialFind2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind2.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind2.ForePressColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiducialFind2.Location = new System.Drawing.Point(177, 178);
            this.btnFiducialFind2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFiducialFind2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFiducialFind2.Name = "btnFiducialFind2";
            this.btnFiducialFind2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFiducialFind2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind2.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind2.RectPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind2.Size = new System.Drawing.Size(133, 23);
            this.btnFiducialFind2.Style = Sunny.UI.UIStyle.Custom;
            this.btnFiducialFind2.StyleCustomMode = true;
            this.btnFiducialFind2.Symbol = 61442;
            this.btnFiducialFind2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind2.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind2.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnFiducialFind2.SymbolSize = 18;
            this.btnFiducialFind2.TabIndex = 3615;
            this.btnFiducialFind2.Tag = "Find2";
            this.btnFiducialFind2.Text = "Find";
            this.btnFiducialFind2.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFiducialFind2.Click += new System.EventHandler(this.OnClick_Fiducial);
            // 
            // btnFiducialFind1
            // 
            this.btnFiducialFind1.BackColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.CircleRectWidth = 0;
            this.btnFiducialFind1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiducialFind1.FillColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.FillColor2 = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.FillPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.Font = new System.Drawing.Font("Arial", 10F);
            this.btnFiducialFind1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind1.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind1.ForePressColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiducialFind1.Location = new System.Drawing.Point(177, 105);
            this.btnFiducialFind1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFiducialFind1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFiducialFind1.Name = "btnFiducialFind1";
            this.btnFiducialFind1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFiducialFind1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind1.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind1.RectPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialFind1.Size = new System.Drawing.Size(133, 23);
            this.btnFiducialFind1.Style = Sunny.UI.UIStyle.Custom;
            this.btnFiducialFind1.StyleCustomMode = true;
            this.btnFiducialFind1.Symbol = 61442;
            this.btnFiducialFind1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind1.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialFind1.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnFiducialFind1.SymbolSize = 18;
            this.btnFiducialFind1.TabIndex = 3614;
            this.btnFiducialFind1.Tag = "Find1";
            this.btnFiducialFind1.Text = "Find";
            this.btnFiducialFind1.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFiducialFind1.Click += new System.EventHandler(this.OnClick_Fiducial);
            // 
            // cogDisplay_Fiducial_Pattern1
            // 
            this.cogDisplay_Fiducial_Pattern1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Fiducial_Pattern1.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_Fiducial_Pattern1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_Fiducial_Pattern1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Fiducial_Pattern1.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_Fiducial_Pattern1.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_Fiducial_Pattern1.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_Fiducial_Pattern1.Location = new System.Drawing.Point(86, 77);
            this.cogDisplay_Fiducial_Pattern1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_Fiducial_Pattern1.MouseWheelSensitivity = 1D;
            this.cogDisplay_Fiducial_Pattern1.Name = "cogDisplay_Fiducial_Pattern1";
            this.cogDisplay_Fiducial_Pattern1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_Fiducial_Pattern1.OcxState")));
            this.cogDisplay_Fiducial_Pattern1.Size = new System.Drawing.Size(71, 56);
            this.cogDisplay_Fiducial_Pattern1.TabIndex = 3612;
            this.cogDisplay_Fiducial_Pattern1.TabStop = false;
            this.cogDisplay_Fiducial_Pattern1.Tag = "2";
            // 
            // btnFiducialTrain2
            // 
            this.btnFiducialTrain2.BackColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.CircleRectWidth = 0;
            this.btnFiducialTrain2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiducialTrain2.FillColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.FillColor2 = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.FillPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.Font = new System.Drawing.Font("Arial", 10F);
            this.btnFiducialTrain2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain2.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain2.ForePressColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiducialTrain2.Location = new System.Drawing.Point(244, 149);
            this.btnFiducialTrain2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFiducialTrain2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFiducialTrain2.Name = "btnFiducialTrain2";
            this.btnFiducialTrain2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFiducialTrain2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain2.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain2.RectPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain2.Size = new System.Drawing.Size(66, 23);
            this.btnFiducialTrain2.Style = Sunny.UI.UIStyle.Custom;
            this.btnFiducialTrain2.StyleCustomMode = true;
            this.btnFiducialTrain2.Symbol = 361773;
            this.btnFiducialTrain2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain2.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain2.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnFiducialTrain2.SymbolSize = 18;
            this.btnFiducialTrain2.TabIndex = 3610;
            this.btnFiducialTrain2.Tag = "Train2";
            this.btnFiducialTrain2.Text = "Train";
            this.btnFiducialTrain2.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFiducialTrain2.Click += new System.EventHandler(this.OnClick_Fiducial);
            // 
            // btnFiducialROI2
            // 
            this.btnFiducialROI2.BackColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.CircleRectWidth = 0;
            this.btnFiducialROI2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiducialROI2.FillColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.FillColor2 = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.FillPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.Font = new System.Drawing.Font("Arial", 10F);
            this.btnFiducialROI2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI2.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI2.ForePressColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiducialROI2.Location = new System.Drawing.Point(177, 149);
            this.btnFiducialROI2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFiducialROI2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFiducialROI2.Name = "btnFiducialROI2";
            this.btnFiducialROI2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFiducialROI2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI2.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI2.RectPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI2.Size = new System.Drawing.Size(66, 23);
            this.btnFiducialROI2.Style = Sunny.UI.UIStyle.Custom;
            this.btnFiducialROI2.StyleCustomMode = true;
            this.btnFiducialROI2.Symbol = 62024;
            this.btnFiducialROI2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI2.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI2.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnFiducialROI2.SymbolSize = 18;
            this.btnFiducialROI2.TabIndex = 3609;
            this.btnFiducialROI2.Tag = "ROI2";
            this.btnFiducialROI2.Text = "ROI";
            this.btnFiducialROI2.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFiducialROI2.Click += new System.EventHandler(this.OnClick_Fiducial);
            // 
            // uiLine16
            // 
            this.uiLine16.BackColor = System.Drawing.Color.Transparent;
            this.uiLine16.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine16.LineColor = System.Drawing.Color.Black;
            this.uiLine16.Location = new System.Drawing.Point(6, 204);
            this.uiLine16.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine16.Name = "uiLine16";
            this.uiLine16.Size = new System.Drawing.Size(313, 10);
            this.uiLine16.TabIndex = 3605;
            // 
            // btnFiducialTrain1
            // 
            this.btnFiducialTrain1.BackColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.CircleRectWidth = 0;
            this.btnFiducialTrain1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiducialTrain1.FillColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.FillColor2 = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.FillPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.Font = new System.Drawing.Font("Arial", 10F);
            this.btnFiducialTrain1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain1.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain1.ForePressColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiducialTrain1.Location = new System.Drawing.Point(244, 77);
            this.btnFiducialTrain1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFiducialTrain1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFiducialTrain1.Name = "btnFiducialTrain1";
            this.btnFiducialTrain1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFiducialTrain1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain1.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain1.RectPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialTrain1.Size = new System.Drawing.Size(66, 23);
            this.btnFiducialTrain1.Style = Sunny.UI.UIStyle.Custom;
            this.btnFiducialTrain1.StyleCustomMode = true;
            this.btnFiducialTrain1.Symbol = 361773;
            this.btnFiducialTrain1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain1.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialTrain1.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnFiducialTrain1.SymbolSize = 18;
            this.btnFiducialTrain1.TabIndex = 3598;
            this.btnFiducialTrain1.Tag = "Train1";
            this.btnFiducialTrain1.Text = "Train";
            this.btnFiducialTrain1.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFiducialTrain1.Click += new System.EventHandler(this.OnClick_Fiducial);
            // 
            // btnFiducialROI1
            // 
            this.btnFiducialROI1.BackColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.CircleRectWidth = 0;
            this.btnFiducialROI1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiducialROI1.FillColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.FillColor2 = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.FillPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.Font = new System.Drawing.Font("Arial", 10F);
            this.btnFiducialROI1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI1.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI1.ForePressColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiducialROI1.Location = new System.Drawing.Point(177, 77);
            this.btnFiducialROI1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFiducialROI1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFiducialROI1.Name = "btnFiducialROI1";
            this.btnFiducialROI1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFiducialROI1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI1.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI1.RectPressColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnFiducialROI1.Size = new System.Drawing.Size(66, 23);
            this.btnFiducialROI1.Style = Sunny.UI.UIStyle.Custom;
            this.btnFiducialROI1.StyleCustomMode = true;
            this.btnFiducialROI1.Symbol = 62024;
            this.btnFiducialROI1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI1.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnFiducialROI1.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnFiducialROI1.SymbolSize = 18;
            this.btnFiducialROI1.TabIndex = 3597;
            this.btnFiducialROI1.Tag = "ROI1";
            this.btnFiducialROI1.Text = "ROI";
            this.btnFiducialROI1.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFiducialROI1.Click += new System.EventHandler(this.OnClick_Fiducial);
            // 
            // uiLine19
            // 
            this.uiLine19.BackColor = System.Drawing.Color.Transparent;
            this.uiLine19.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine19.LineColor = System.Drawing.Color.Black;
            this.uiLine19.Location = new System.Drawing.Point(6, 134);
            this.uiLine19.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine19.Name = "uiLine19";
            this.uiLine19.Size = new System.Drawing.Size(313, 10);
            this.uiLine19.TabIndex = 3593;
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.Color.Black;
            this.label68.Location = new System.Drawing.Point(8, 77);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(72, 20);
            this.label68.TabIndex = 3590;
            this.label68.Text = "Position #1";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.uiTabControl3);
            this.tabPage12.Location = new System.Drawing.Point(0, 40);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(200, 60);
            this.tabPage12.TabIndex = 2;
            this.tabPage12.Text = "Board";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // uiTabControl3
            // 
            this.uiTabControl3.Controls.Add(this.tabPage5);
            this.uiTabControl3.Controls.Add(this.tabPage6);
            this.uiTabControl3.Controls.Add(this.tabPage7);
            this.uiTabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl3.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl3.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiTabControl3.ItemSize = new System.Drawing.Size(120, 40);
            this.uiTabControl3.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl3.MainPage = "";
            this.uiTabControl3.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl3.Name = "uiTabControl3";
            this.uiTabControl3.SelectedIndex = 0;
            this.uiTabControl3.Size = new System.Drawing.Size(200, 60);
            this.uiTabControl3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl3.TabBackColor = System.Drawing.SystemColors.Control;
            this.uiTabControl3.TabIndex = 3619;
            this.uiTabControl3.TabSelectedColor = System.Drawing.Color.White;
            this.uiTabControl3.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl3.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiTabControl3.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.uiGroupBox18);
            this.tabPage5.Location = new System.Drawing.Point(0, 40);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(200, 20);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Gerber";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox18
            // 
            this.uiGroupBox18.Controls.Add(this.chkEnalbenouse);
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
            this.uiGroupBox18.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox18.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox18.Name = "uiGroupBox18";
            this.uiGroupBox18.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox18.Radius = 10;
            this.uiGroupBox18.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox18.Size = new System.Drawing.Size(946, 654);
            this.uiGroupBox18.TabIndex = 3615;
            this.uiGroupBox18.Text = "Gerber";
            this.uiGroupBox18.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEnalbenouse
            // 
            this.chkEnalbenouse.AutoSize = true;
            this.chkEnalbenouse.BackColor = System.Drawing.Color.Transparent;
            this.chkEnalbenouse.Font = new System.Drawing.Font("Arial", 8F);
            this.chkEnalbenouse.ForeColor = System.Drawing.Color.Black;
            this.chkEnalbenouse.Location = new System.Drawing.Point(617, 413);
            this.chkEnalbenouse.Name = "chkEnalbenouse";
            this.chkEnalbenouse.Size = new System.Drawing.Size(139, 18);
            this.chkEnalbenouse.TabIndex = 3619;
            this.chkEnalbenouse.Text = "Enable is not used at all";
            this.chkEnalbenouse.UseVisualStyleBackColor = false;
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
            this.BtnReplaceLibrary.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            this.BtnReplaceLibrary.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnReplaceLibrary.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnReplaceLibrary.Size = new System.Drawing.Size(148, 26);
            this.BtnReplaceLibrary.Style = Sunny.UI.UIStyle.Custom;
            this.BtnReplaceLibrary.StyleCustomMode = true;
            this.BtnReplaceLibrary.Symbol = 362023;
            this.BtnReplaceLibrary.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnReplaceLibrary.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnReplaceLibrary.SymbolSize = 18;
            this.BtnReplaceLibrary.TabIndex = 3535;
            this.BtnReplaceLibrary.Tag = "ZoomIn";
            this.BtnReplaceLibrary.Text = "Auto Import";
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
            this.BtnRegionVisible.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            this.BtnRegionVisible.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRegionVisible.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnRegionVisible.Size = new System.Drawing.Size(148, 26);
            this.BtnRegionVisible.Style = Sunny.UI.UIStyle.Custom;
            this.BtnRegionVisible.StyleCustomMode = true;
            this.BtnRegionVisible.Symbol = 61717;
            this.BtnRegionVisible.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRegionVisible.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DgvGerberInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvGerberInfo.BackgroundColor = System.Drawing.Color.Silver;
            this.DgvGerberInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGerberInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvGerberInfo.ColumnHeadersHeight = 20;
            this.DgvGerberInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvGerberInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.Column1,
            this.Column2,
            this.dataGridViewTextBoxColumn12,
            this.Angle});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvGerberInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvGerberInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvGerberInfo.EnableHeadersVisualStyles = false;
            this.DgvGerberInfo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DgvGerberInfo.GridColor = System.Drawing.Color.Silver;
            this.DgvGerberInfo.Location = new System.Drawing.Point(10, 65);
            this.DgvGerberInfo.MultiSelect = false;
            this.DgvGerberInfo.Name = "DgvGerberInfo";
            this.DgvGerberInfo.ReadOnly = true;
            this.DgvGerberInfo.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGerberInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvGerberInfo.RowHeadersVisible = false;
            this.DgvGerberInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.DgvGerberInfo.RowsDefaultCellStyle = dataGridViewCellStyle5;
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
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.HeaderText = "Location No";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Enabled";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.HeaderText = "Position";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // Angle
            // 
            this.Angle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Angle.HeaderText = "Angle";
            this.Angle.Name = "Angle";
            this.Angle.ReadOnly = true;
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
            this.BtnGerberLoad.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            this.BtnGerberLoad.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGerberLoad.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnGerberLoad.Size = new System.Drawing.Size(100, 26);
            this.BtnGerberLoad.Style = Sunny.UI.UIStyle.Custom;
            this.BtnGerberLoad.StyleCustomMode = true;
            this.BtnGerberLoad.Symbol = 61717;
            this.BtnGerberLoad.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGerberLoad.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.uiGroupBox3);
            this.tabPage6.Controls.Add(this.BtnMasterBoardLoad);
            this.tabPage6.Controls.Add(this.BtnMasterBoardSave);
            this.tabPage6.Location = new System.Drawing.Point(0, 40);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(200, 60);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "MasterBoard";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.Cogdis_Master);
            this.uiGroupBox3.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox3.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox3.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox3.Location = new System.Drawing.Point(14, 60);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Radius = 10;
            this.uiGroupBox3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox3.Size = new System.Drawing.Size(915, 590);
            this.uiGroupBox3.TabIndex = 3622;
            this.uiGroupBox3.Text = "Master PreView";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cogdis_Master
            // 
            this.Cogdis_Master.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.Cogdis_Master.ColorMapLowerRoiLimit = 0D;
            this.Cogdis_Master.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.Cogdis_Master.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.Cogdis_Master.ColorMapUpperRoiLimit = 1D;
            this.Cogdis_Master.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cogdis_Master.DoubleTapZoomCycleLength = 2;
            this.Cogdis_Master.DoubleTapZoomSensitivity = 2.5D;
            this.Cogdis_Master.Location = new System.Drawing.Point(0, 32);
            this.Cogdis_Master.Margin = new System.Windows.Forms.Padding(4);
            this.Cogdis_Master.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.Cogdis_Master.MouseWheelSensitivity = 1D;
            this.Cogdis_Master.Name = "Cogdis_Master";
            this.Cogdis_Master.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cogdis_Master.OcxState")));
            this.Cogdis_Master.Size = new System.Drawing.Size(915, 558);
            this.Cogdis_Master.TabIndex = 3256;
            // 
            // BtnMasterBoardLoad
            // 
            this.BtnMasterBoardLoad.BackColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.CircleRectWidth = 0;
            this.BtnMasterBoardLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMasterBoardLoad.FillColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnMasterBoardLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardLoad.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardLoad.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMasterBoardLoad.Location = new System.Drawing.Point(196, 20);
            this.BtnMasterBoardLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnMasterBoardLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnMasterBoardLoad.Name = "BtnMasterBoardLoad";
            this.BtnMasterBoardLoad.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnMasterBoardLoad.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardLoad.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardLoad.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardLoad.Size = new System.Drawing.Size(174, 32);
            this.BtnMasterBoardLoad.Style = Sunny.UI.UIStyle.Custom;
            this.BtnMasterBoardLoad.StyleCustomMode = true;
            this.BtnMasterBoardLoad.Symbol = 361773;
            this.BtnMasterBoardLoad.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardLoad.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardLoad.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnMasterBoardLoad.SymbolSize = 18;
            this.BtnMasterBoardLoad.TabIndex = 3621;
            this.BtnMasterBoardLoad.Tag = "ZoomIn";
            this.BtnMasterBoardLoad.Text = "Load Master Board";
            this.BtnMasterBoardLoad.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnMasterBoardLoad.Click += new System.EventHandler(this.BtnMasterBoardLoad_Click);
            // 
            // BtnMasterBoardSave
            // 
            this.BtnMasterBoardSave.BackColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.CircleRectWidth = 0;
            this.BtnMasterBoardSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMasterBoardSave.FillColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnMasterBoardSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardSave.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardSave.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMasterBoardSave.Location = new System.Drawing.Point(14, 20);
            this.BtnMasterBoardSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnMasterBoardSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnMasterBoardSave.Name = "BtnMasterBoardSave";
            this.BtnMasterBoardSave.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnMasterBoardSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardSave.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardSave.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnMasterBoardSave.Size = new System.Drawing.Size(174, 32);
            this.BtnMasterBoardSave.Style = Sunny.UI.UIStyle.Custom;
            this.BtnMasterBoardSave.StyleCustomMode = true;
            this.BtnMasterBoardSave.Symbol = 361773;
            this.BtnMasterBoardSave.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardSave.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnMasterBoardSave.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnMasterBoardSave.SymbolSize = 18;
            this.BtnMasterBoardSave.TabIndex = 3620;
            this.BtnMasterBoardSave.Tag = "ZoomIn";
            this.BtnMasterBoardSave.Text = "Save Master Board";
            this.BtnMasterBoardSave.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnMasterBoardSave.Click += new System.EventHandler(this.BtnMasterBoardSave_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.uiGroupBox4);
            this.tabPage7.Controls.Add(this.BtnBareBoardLoad);
            this.tabPage7.Controls.Add(this.BtnBareBoardSave);
            this.tabPage7.Location = new System.Drawing.Point(0, 40);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(200, 60);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "BareBoard";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.Cogdis_Bare);
            this.uiGroupBox4.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox4.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox4.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox4.Location = new System.Drawing.Point(14, 60);
            this.uiGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox4.Radius = 10;
            this.uiGroupBox4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox4.Size = new System.Drawing.Size(915, 590);
            this.uiGroupBox4.TabIndex = 3627;
            this.uiGroupBox4.Text = "Bare PreView";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cogdis_Bare
            // 
            this.Cogdis_Bare.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.Cogdis_Bare.ColorMapLowerRoiLimit = 0D;
            this.Cogdis_Bare.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.Cogdis_Bare.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.Cogdis_Bare.ColorMapUpperRoiLimit = 1D;
            this.Cogdis_Bare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cogdis_Bare.DoubleTapZoomCycleLength = 2;
            this.Cogdis_Bare.DoubleTapZoomSensitivity = 2.5D;
            this.Cogdis_Bare.Location = new System.Drawing.Point(0, 32);
            this.Cogdis_Bare.Margin = new System.Windows.Forms.Padding(4);
            this.Cogdis_Bare.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.Cogdis_Bare.MouseWheelSensitivity = 1D;
            this.Cogdis_Bare.Name = "Cogdis_Bare";
            this.Cogdis_Bare.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Cogdis_Bare.OcxState")));
            this.Cogdis_Bare.Size = new System.Drawing.Size(915, 558);
            this.Cogdis_Bare.TabIndex = 3256;
            // 
            // BtnBareBoardLoad
            // 
            this.BtnBareBoardLoad.BackColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.CircleRectWidth = 0;
            this.BtnBareBoardLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBareBoardLoad.FillColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnBareBoardLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardLoad.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardLoad.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBareBoardLoad.Location = new System.Drawing.Point(196, 20);
            this.BtnBareBoardLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnBareBoardLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnBareBoardLoad.Name = "BtnBareBoardLoad";
            this.BtnBareBoardLoad.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnBareBoardLoad.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardLoad.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardLoad.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardLoad.Size = new System.Drawing.Size(174, 32);
            this.BtnBareBoardLoad.Style = Sunny.UI.UIStyle.Custom;
            this.BtnBareBoardLoad.StyleCustomMode = true;
            this.BtnBareBoardLoad.Symbol = 361773;
            this.BtnBareBoardLoad.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardLoad.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardLoad.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnBareBoardLoad.SymbolSize = 18;
            this.BtnBareBoardLoad.TabIndex = 3626;
            this.BtnBareBoardLoad.Tag = "ZoomIn";
            this.BtnBareBoardLoad.Text = "Load Bare Board";
            this.BtnBareBoardLoad.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnBareBoardLoad.Click += new System.EventHandler(this.BtnBareBoardLoad_Click);
            // 
            // BtnBareBoardSave
            // 
            this.BtnBareBoardSave.BackColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.CircleRectWidth = 0;
            this.BtnBareBoardSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBareBoardSave.FillColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnBareBoardSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardSave.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardSave.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBareBoardSave.Location = new System.Drawing.Point(14, 20);
            this.BtnBareBoardSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnBareBoardSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnBareBoardSave.Name = "BtnBareBoardSave";
            this.BtnBareBoardSave.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnBareBoardSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardSave.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardSave.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnBareBoardSave.Size = new System.Drawing.Size(174, 32);
            this.BtnBareBoardSave.Style = Sunny.UI.UIStyle.Custom;
            this.BtnBareBoardSave.StyleCustomMode = true;
            this.BtnBareBoardSave.Symbol = 361773;
            this.BtnBareBoardSave.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardSave.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnBareBoardSave.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnBareBoardSave.SymbolSize = 18;
            this.BtnBareBoardSave.TabIndex = 3625;
            this.BtnBareBoardSave.Tag = "ZoomIn";
            this.BtnBareBoardSave.Text = "Save Bare Board";
            this.BtnBareBoardSave.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnBareBoardSave.Click += new System.EventHandler(this.BtnBareBoardSave_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel18);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 60);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "02. LIBRARY";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 1;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel19, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel15, 0, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 2;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(200, 60);
            this.tableLayoutPanel18.TabIndex = 1;
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 4;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel19.Controls.Add(this.btn_Library_Update, 3, 0);
            this.tableLayoutPanel19.Controls.Add(this.btn_Library_Clear, 2, 0);
            this.tableLayoutPanel19.Controls.Add(this.btn_Library_Refresh, 1, 0);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(0, 10);
            this.tableLayoutPanel19.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 1;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(200, 50);
            this.tableLayoutPanel19.TabIndex = 1;
            this.tableLayoutPanel19.Visible = false;
            // 
            // btn_Library_Update
            // 
            this.btn_Library_Update.BackColor = System.Drawing.Color.White;
            this.btn_Library_Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Library_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Library_Update.FillColor = System.Drawing.Color.White;
            this.btn_Library_Update.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_Update.FillHoverColor = System.Drawing.Color.White;
            this.btn_Library_Update.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_Update.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_Update.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Library_Update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_Update.Location = new System.Drawing.Point(93, 3);
            this.btn_Library_Update.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Library_Update.Name = "btn_Library_Update";
            this.btn_Library_Update.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_Update.RectHoverColor = System.Drawing.Color.Black;
            this.btn_Library_Update.RectPressColor = System.Drawing.Color.White;
            this.btn_Library_Update.RectSelectedColor = System.Drawing.Color.White;
            this.btn_Library_Update.Size = new System.Drawing.Size(104, 44);
            this.btn_Library_Update.Style = Sunny.UI.UIStyle.Custom;
            this.btn_Library_Update.StyleCustomMode = true;
            this.btn_Library_Update.Symbol = 61717;
            this.btn_Library_Update.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_Update.SymbolSize = 20;
            this.btn_Library_Update.TabIndex = 3531;
            this.btn_Library_Update.Tag = "Update";
            this.btn_Library_Update.Text = "Update All";
            this.btn_Library_Update.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btn_Library_Clear
            // 
            this.btn_Library_Clear.BackColor = System.Drawing.Color.White;
            this.btn_Library_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Library_Clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Library_Clear.FillColor = System.Drawing.Color.White;
            this.btn_Library_Clear.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_Clear.FillHoverColor = System.Drawing.Color.White;
            this.btn_Library_Clear.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_Clear.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_Clear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Library_Clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_Clear.Location = new System.Drawing.Point(-17, 3);
            this.btn_Library_Clear.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Library_Clear.Name = "btn_Library_Clear";
            this.btn_Library_Clear.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_Clear.RectHoverColor = System.Drawing.Color.Black;
            this.btn_Library_Clear.RectPressColor = System.Drawing.Color.White;
            this.btn_Library_Clear.RectSelectedColor = System.Drawing.Color.White;
            this.btn_Library_Clear.Size = new System.Drawing.Size(104, 44);
            this.btn_Library_Clear.Style = Sunny.UI.UIStyle.Custom;
            this.btn_Library_Clear.StyleCustomMode = true;
            this.btn_Library_Clear.Symbol = 61717;
            this.btn_Library_Clear.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_Clear.SymbolSize = 20;
            this.btn_Library_Clear.TabIndex = 3530;
            this.btn_Library_Clear.Tag = "Clear";
            this.btn_Library_Clear.Text = "Clear";
            this.btn_Library_Clear.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btn_Library_Refresh
            // 
            this.btn_Library_Refresh.BackColor = System.Drawing.Color.White;
            this.btn_Library_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Library_Refresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Library_Refresh.FillColor = System.Drawing.Color.White;
            this.btn_Library_Refresh.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_Refresh.FillHoverColor = System.Drawing.Color.White;
            this.btn_Library_Refresh.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_Refresh.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_Refresh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Library_Refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_Refresh.Location = new System.Drawing.Point(-127, 3);
            this.btn_Library_Refresh.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Library_Refresh.Name = "btn_Library_Refresh";
            this.btn_Library_Refresh.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_Refresh.RectHoverColor = System.Drawing.Color.Black;
            this.btn_Library_Refresh.RectPressColor = System.Drawing.Color.White;
            this.btn_Library_Refresh.RectSelectedColor = System.Drawing.Color.White;
            this.btn_Library_Refresh.Size = new System.Drawing.Size(104, 44);
            this.btn_Library_Refresh.Style = Sunny.UI.UIStyle.Custom;
            this.btn_Library_Refresh.StyleCustomMode = true;
            this.btn_Library_Refresh.Symbol = 61717;
            this.btn_Library_Refresh.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_Refresh.SymbolSize = 20;
            this.btn_Library_Refresh.TabIndex = 3528;
            this.btn_Library_Refresh.Tag = "Refresh";
            this.btn_Library_Refresh.Text = "Refresh";
            this.btn_Library_Refresh.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.Controls.Add(this.TvLocal, 1, 2);
            this.tableLayoutPanel15.Controls.Add(this.label27, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.tableLayoutPanel16, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.tableLayoutPanel17, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.label28, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.TvServer, 0, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 3;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(200, 10);
            this.tableLayoutPanel15.TabIndex = 0;
            // 
            // TvLocal
            // 
            this.TvLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvLocal.FillColor = System.Drawing.Color.White;
            this.TvLocal.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TvLocal.Location = new System.Drawing.Point(104, 73);
            this.TvLocal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TvLocal.MinimumSize = new System.Drawing.Size(1, 1);
            this.TvLocal.Name = "TvLocal";
            this.TvLocal.ScrollBarStyleInherited = false;
            this.TvLocal.ShowText = false;
            this.TvLocal.Size = new System.Drawing.Size(91, 1);
            this.TvLocal.TabIndex = 5;
            this.TvLocal.Text = "uiTreeView1";
            this.TvLocal.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(101, 1);
            this.label27.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(97, 25);
            this.label27.TabIndex = 3;
            this.label27.Text = "Local";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel16.Controls.Add(this.lb_Library_ServerName, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.btn_Library_LoadServerFolder, 0, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(1, 27);
            this.tableLayoutPanel16.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(98, 40);
            this.tableLayoutPanel16.TabIndex = 0;
            // 
            // lb_Library_ServerName
            // 
            this.lb_Library_ServerName.AutoSize = true;
            this.lb_Library_ServerName.BackColor = System.Drawing.Color.White;
            this.lb_Library_ServerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Library_ServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Library_ServerName.ForeColor = System.Drawing.Color.Black;
            this.lb_Library_ServerName.Location = new System.Drawing.Point(53, 3);
            this.lb_Library_ServerName.Margin = new System.Windows.Forms.Padding(3);
            this.lb_Library_ServerName.Name = "lb_Library_ServerName";
            this.lb_Library_ServerName.Size = new System.Drawing.Size(42, 34);
            this.lb_Library_ServerName.TabIndex = 3527;
            this.lb_Library_ServerName.Text = "C:\\PBA_EXEPATH_TEST";
            this.lb_Library_ServerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Library_LoadServerFolder
            // 
            this.btn_Library_LoadServerFolder.BackColor = System.Drawing.Color.White;
            this.btn_Library_LoadServerFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Library_LoadServerFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Library_LoadServerFolder.FillColor = System.Drawing.Color.White;
            this.btn_Library_LoadServerFolder.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_LoadServerFolder.FillHoverColor = System.Drawing.Color.White;
            this.btn_Library_LoadServerFolder.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_LoadServerFolder.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_LoadServerFolder.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Library_LoadServerFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadServerFolder.Location = new System.Drawing.Point(3, 3);
            this.btn_Library_LoadServerFolder.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Library_LoadServerFolder.Name = "btn_Library_LoadServerFolder";
            this.btn_Library_LoadServerFolder.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadServerFolder.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadServerFolder.RectPressColor = System.Drawing.Color.White;
            this.btn_Library_LoadServerFolder.RectSelectedColor = System.Drawing.Color.White;
            this.btn_Library_LoadServerFolder.Size = new System.Drawing.Size(44, 34);
            this.btn_Library_LoadServerFolder.Style = Sunny.UI.UIStyle.Custom;
            this.btn_Library_LoadServerFolder.StyleCustomMode = true;
            this.btn_Library_LoadServerFolder.Symbol = 61717;
            this.btn_Library_LoadServerFolder.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadServerFolder.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadServerFolder.SymbolSize = 20;
            this.btn_Library_LoadServerFolder.TabIndex = 3525;
            this.btn_Library_LoadServerFolder.Tag = "Server";
            this.btn_Library_LoadServerFolder.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Library_LoadServerFolder.Click += new System.EventHandler(this.btnSelectServerFolder_Click);
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel17.Controls.Add(this.lb_Library_LocalName, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.btn_Library_LoadLocalFolder, 0, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(100, 27);
            this.tableLayoutPanel17.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(99, 40);
            this.tableLayoutPanel17.TabIndex = 1;
            // 
            // lb_Library_LocalName
            // 
            this.lb_Library_LocalName.AutoSize = true;
            this.lb_Library_LocalName.BackColor = System.Drawing.Color.White;
            this.lb_Library_LocalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Library_LocalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Library_LocalName.ForeColor = System.Drawing.Color.Black;
            this.lb_Library_LocalName.Location = new System.Drawing.Point(53, 3);
            this.lb_Library_LocalName.Margin = new System.Windows.Forms.Padding(3);
            this.lb_Library_LocalName.Name = "lb_Library_LocalName";
            this.lb_Library_LocalName.Size = new System.Drawing.Size(43, 34);
            this.lb_Library_LocalName.TabIndex = 3529;
            this.lb_Library_LocalName.Text = "C:\\Test\\IQResultData";
            this.lb_Library_LocalName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Library_LoadLocalFolder
            // 
            this.btn_Library_LoadLocalFolder.BackColor = System.Drawing.Color.White;
            this.btn_Library_LoadLocalFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Library_LoadLocalFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Library_LoadLocalFolder.FillColor = System.Drawing.Color.White;
            this.btn_Library_LoadLocalFolder.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_LoadLocalFolder.FillHoverColor = System.Drawing.Color.White;
            this.btn_Library_LoadLocalFolder.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_LoadLocalFolder.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Library_LoadLocalFolder.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Library_LoadLocalFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadLocalFolder.Location = new System.Drawing.Point(3, 3);
            this.btn_Library_LoadLocalFolder.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Library_LoadLocalFolder.Name = "btn_Library_LoadLocalFolder";
            this.btn_Library_LoadLocalFolder.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadLocalFolder.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadLocalFolder.RectPressColor = System.Drawing.Color.White;
            this.btn_Library_LoadLocalFolder.RectSelectedColor = System.Drawing.Color.White;
            this.btn_Library_LoadLocalFolder.Size = new System.Drawing.Size(44, 34);
            this.btn_Library_LoadLocalFolder.Style = Sunny.UI.UIStyle.Custom;
            this.btn_Library_LoadLocalFolder.StyleCustomMode = true;
            this.btn_Library_LoadLocalFolder.Symbol = 61717;
            this.btn_Library_LoadLocalFolder.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadLocalFolder.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btn_Library_LoadLocalFolder.SymbolSize = 20;
            this.btn_Library_LoadLocalFolder.TabIndex = 3527;
            this.btn_Library_LoadLocalFolder.Tag = "Local";
            this.btn_Library_LoadLocalFolder.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Library_LoadLocalFolder.Click += new System.EventHandler(this.btnSelectLocalFolder_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(2, 1);
            this.label28.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(96, 25);
            this.label28.TabIndex = 2;
            this.label28.Text = "Server";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TvServer
            // 
            this.TvServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvServer.FillColor = System.Drawing.Color.White;
            this.TvServer.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TvServer.Location = new System.Drawing.Point(5, 73);
            this.TvServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TvServer.MinimumSize = new System.Drawing.Size(1, 1);
            this.TvServer.Name = "TvServer";
            this.TvServer.ScrollBarStyleInherited = false;
            this.TvServer.ShowText = false;
            this.TvServer.Size = new System.Drawing.Size(90, 1);
            this.TvServer.TabIndex = 4;
            this.TvServer.Text = "uiTreeView1";
            this.TvServer.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.btnUpLoadAll);
            this.tabPage14.Controls.Add(this.BtnModelDownAll);
            this.tabPage14.Controls.Add(this.label57);
            this.tabPage14.Controls.Add(this.BtnJobDownLoad);
            this.tabPage14.Controls.Add(this.uiSymbolButton7);
            this.tabPage14.Controls.Add(this.BtnGrabMove);
            this.tabPage14.Controls.Add(this.btnDownLoadPartLibrary);
            this.tabPage14.Controls.Add(this.uiSymbolButton9);
            this.tabPage14.Controls.Add(this.uiSymbolButton2);
            this.tabPage14.Controls.Add(this.tableLayoutPanel2);
            this.tabPage14.Controls.Add(this.panel7);
            this.tabPage14.Controls.Add(this.label4);
            this.tabPage14.Controls.Add(this.uiSymbolButton3);
            this.tabPage14.Controls.Add(this.uiSymbolButton8);
            this.tabPage14.Controls.Add(this.DgvProcessingList);
            this.tabPage14.Controls.Add(this.DgvLogicList);
            this.tabPage14.Controls.Add(this.btnUpLoadPartLibrary);
            this.tabPage14.Controls.Add(this.label24);
            this.tabPage14.Controls.Add(this.BtnLogicDelete);
            this.tabPage14.Controls.Add(this.BtnLogicAdd);
            this.tabPage14.Controls.Add(this.uiLine25);
            this.tabPage14.Controls.Add(this.label20);
            this.tabPage14.Controls.Add(this.BtnNA_ng);
            this.tabPage14.Controls.Add(this.label23);
            this.tabPage14.Controls.Add(this.BtnNA_ok);
            this.tabPage14.Controls.Add(this.cbGrabIndex);
            this.tabPage14.Controls.Add(this.BtnSettingLogic);
            this.tabPage14.Controls.Add(this.label18);
            this.tabPage14.Controls.Add(this.tbLogicName);
            this.tabPage14.Controls.Add(this.label19);
            this.tabPage14.Controls.Add(this.label16);
            this.tabPage14.Controls.Add(this.label15);
            this.tabPage14.Controls.Add(this.BtnSettingJob);
            this.tabPage14.Controls.Add(this.uiLine21);
            this.tabPage14.Controls.Add(this.TbPartName);
            this.tabPage14.Controls.Add(this.label14);
            this.tabPage14.Controls.Add(this.TbLocationNo);
            this.tabPage14.Controls.Add(this.label17);
            this.tabPage14.Controls.Add(this.label6);
            this.tabPage14.Controls.Add(this.CbJobAll);
            this.tabPage14.Controls.Add(this.BtnJobListCopy);
            this.tabPage14.Controls.Add(this.BtnJobDelete);
            this.tabPage14.Controls.Add(this.DgvJobList);
            this.tabPage14.Controls.Add(this.BtnJobAdd);
            this.tabPage14.Controls.Add(this.cbAlgorithm);
            this.tabPage14.Location = new System.Drawing.Point(0, 40);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Size = new System.Drawing.Size(200, 60);
            this.tabPage14.TabIndex = 2;
            this.tabPage14.Text = "03. JOB";
            this.tabPage14.UseVisualStyleBackColor = true;
            this.tabPage14.DoubleClick += new System.EventHandler(this.tabPage14_DoubleClick);
            // 
            // btnUpLoadAll
            // 
            this.btnUpLoadAll.BackColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.CircleRectWidth = 0;
            this.btnUpLoadAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpLoadAll.FillColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.FillColor2 = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.FillPressColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.Font = new System.Drawing.Font("Arial", 8F);
            this.btnUpLoadAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadAll.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadAll.ForePressColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpLoadAll.Location = new System.Drawing.Point(204, 755);
            this.btnUpLoadAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpLoadAll.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnUpLoadAll.Name = "btnUpLoadAll";
            this.btnUpLoadAll.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUpLoadAll.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadAll.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadAll.RectPressColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnUpLoadAll.Size = new System.Drawing.Size(75, 25);
            this.btnUpLoadAll.Style = Sunny.UI.UIStyle.Custom;
            this.btnUpLoadAll.StyleCustomMode = true;
            this.btnUpLoadAll.Symbol = 57489;
            this.btnUpLoadAll.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadAll.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadAll.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnUpLoadAll.SymbolSize = 18;
            this.btnUpLoadAll.TabIndex = 3705;
            this.btnUpLoadAll.Tag = "ZoomIn";
            this.btnUpLoadAll.Text = "UpLoad";
            this.btnUpLoadAll.TipsFont = new System.Drawing.Font("Microsoft YaHei", 7F);
            this.btnUpLoadAll.Visible = false;
            this.btnUpLoadAll.Click += new System.EventHandler(this.btnUpLoadAll_Click);
            // 
            // BtnModelDownAll
            // 
            this.BtnModelDownAll.BackColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.CircleRectWidth = 0;
            this.BtnModelDownAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnModelDownAll.FillColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnModelDownAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnModelDownAll.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnModelDownAll.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnModelDownAll.Location = new System.Drawing.Point(455, 755);
            this.BtnModelDownAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnModelDownAll.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnModelDownAll.Name = "BtnModelDownAll";
            this.BtnModelDownAll.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnModelDownAll.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnModelDownAll.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnModelDownAll.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnModelDownAll.Size = new System.Drawing.Size(91, 25);
            this.BtnModelDownAll.Style = Sunny.UI.UIStyle.Custom;
            this.BtnModelDownAll.StyleCustomMode = true;
            this.BtnModelDownAll.Symbol = 57490;
            this.BtnModelDownAll.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnModelDownAll.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnModelDownAll.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnModelDownAll.SymbolSize = 18;
            this.BtnModelDownAll.TabIndex = 3704;
            this.BtnModelDownAll.Tag = "ZoomIn";
            this.BtnModelDownAll.Text = "Models All";
            this.BtnModelDownAll.TipsFont = new System.Drawing.Font("Microsoft YaHei", 7F);
            this.BtnModelDownAll.Click += new System.EventHandler(this.BtnModelDownAll_Click);
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Arial", 8F);
            this.label57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label57.Location = new System.Drawing.Point(3, 756);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(78, 25);
            this.label57.TabIndex = 3703;
            this.label57.Text = "Master Library";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnJobDownLoad
            // 
            this.BtnJobDownLoad.BackColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.CircleRectWidth = 0;
            this.BtnJobDownLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnJobDownLoad.FillColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnJobDownLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDownLoad.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDownLoad.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnJobDownLoad.Location = new System.Drawing.Point(88, 755);
            this.BtnJobDownLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnJobDownLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnJobDownLoad.Name = "BtnJobDownLoad";
            this.BtnJobDownLoad.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnJobDownLoad.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDownLoad.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDownLoad.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobDownLoad.Size = new System.Drawing.Size(84, 25);
            this.BtnJobDownLoad.Style = Sunny.UI.UIStyle.Custom;
            this.BtnJobDownLoad.StyleCustomMode = true;
            this.BtnJobDownLoad.Symbol = 57490;
            this.BtnJobDownLoad.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDownLoad.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDownLoad.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnJobDownLoad.SymbolSize = 18;
            this.BtnJobDownLoad.TabIndex = 3702;
            this.BtnJobDownLoad.Tag = "ZoomIn";
            this.BtnJobDownLoad.Text = "Jobs All";
            this.BtnJobDownLoad.TipsFont = new System.Drawing.Font("Microsoft YaHei", 7F);
            this.BtnJobDownLoad.Click += new System.EventHandler(this.BtnJobDownLoad_Click);
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
            this.uiSymbolButton7.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton7.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton7.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton7.Location = new System.Drawing.Point(895, 3);
            this.uiSymbolButton7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton7.Name = "uiSymbolButton7";
            this.uiSymbolButton7.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton7.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton7.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton7.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.Size = new System.Drawing.Size(56, 24);
            this.uiSymbolButton7.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton7.StyleCustomMode = true;
            this.uiSymbolButton7.Symbol = 61473;
            this.uiSymbolButton7.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton7.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton7.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton7.SymbolSize = 16;
            this.uiSymbolButton7.TabIndex = 3701;
            this.uiSymbolButton7.Tag = "ZoomIn";
            this.uiSymbolButton7.Text = "Clear";
            this.uiSymbolButton7.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton7.Click += new System.EventHandler(this.OnClickPreProcessing);
            // 
            // BtnGrabMove
            // 
            this.BtnGrabMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrabMove.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrabMove.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrabMove.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrabMove.FillPressColor = System.Drawing.Color.White;
            this.BtnGrabMove.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrabMove.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnGrabMove.Location = new System.Drawing.Point(438, 169);
            this.BtnGrabMove.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnGrabMove.Name = "BtnGrabMove";
            this.BtnGrabMove.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrabMove.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrabMove.RectPressColor = System.Drawing.Color.White;
            this.BtnGrabMove.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnGrabMove.Size = new System.Drawing.Size(61, 25);
            this.BtnGrabMove.TabIndex = 3700;
            this.BtnGrabMove.Tag = "Setting";
            this.BtnGrabMove.Text = "Grab Move";
            this.BtnGrabMove.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnGrabMove.Click += new System.EventHandler(this.BtnGrabMove_Click);
            // 
            // btnDownLoadPartLibrary
            // 
            this.btnDownLoadPartLibrary.BackColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.CircleRectWidth = 0;
            this.btnDownLoadPartLibrary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownLoadPartLibrary.FillColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.FillColor2 = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.FillPressColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.Font = new System.Drawing.Font("Arial", 8F);
            this.btnDownLoadPartLibrary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnDownLoadPartLibrary.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnDownLoadPartLibrary.ForePressColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownLoadPartLibrary.Location = new System.Drawing.Point(362, 755);
            this.btnDownLoadPartLibrary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDownLoadPartLibrary.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDownLoadPartLibrary.Name = "btnDownLoadPartLibrary";
            this.btnDownLoadPartLibrary.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDownLoadPartLibrary.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnDownLoadPartLibrary.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnDownLoadPartLibrary.RectPressColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnDownLoadPartLibrary.Size = new System.Drawing.Size(91, 25);
            this.btnDownLoadPartLibrary.Style = Sunny.UI.UIStyle.Custom;
            this.btnDownLoadPartLibrary.StyleCustomMode = true;
            this.btnDownLoadPartLibrary.Symbol = 57490;
            this.btnDownLoadPartLibrary.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnDownLoadPartLibrary.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnDownLoadPartLibrary.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnDownLoadPartLibrary.SymbolSize = 18;
            this.btnDownLoadPartLibrary.TabIndex = 3694;
            this.btnDownLoadPartLibrary.Tag = "ZoomIn";
            this.btnDownLoadPartLibrary.Text = "DownLoad";
            this.btnDownLoadPartLibrary.TipsFont = new System.Drawing.Font("Microsoft YaHei", 7F);
            this.btnDownLoadPartLibrary.Click += new System.EventHandler(this.btnDownLoadPartLibrary_Click);
            // 
            // uiSymbolButton9
            // 
            this.uiSymbolButton9.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.CircleRectWidth = 0;
            this.uiSymbolButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton9.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton9.Location = new System.Drawing.Point(809, 3);
            this.uiSymbolButton9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton9.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton9.Name = "uiSymbolButton9";
            this.uiSymbolButton9.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton9.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton9.Size = new System.Drawing.Size(52, 24);
            this.uiSymbolButton9.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton9.StyleCustomMode = true;
            this.uiSymbolButton9.Symbol = 61515;
            this.uiSymbolButton9.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton9.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton9.SymbolSize = 16;
            this.uiSymbolButton9.TabIndex = 3693;
            this.uiSymbolButton9.Tag = "ZoomIn";
            this.uiSymbolButton9.Text = "Run";
            this.uiSymbolButton9.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton9.Click += new System.EventHandler(this.OnClickPreProcessing);
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
            this.uiSymbolButton2.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton2.Location = new System.Drawing.Point(752, 3);
            this.uiSymbolButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton2.Size = new System.Drawing.Size(55, 24);
            this.uiSymbolButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton2.StyleCustomMode = true;
            this.uiSymbolButton2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton2.SymbolSize = 16;
            this.uiSymbolButton2.TabIndex = 3692;
            this.uiSymbolButton2.Tag = "ZoomIn";
            this.uiSymbolButton2.Text = "Apply";
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.Click += new System.EventHandler(this.OnClickPreProcessing);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.TabMenuLogic, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(551, 229);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(400, 555);
            this.tableLayoutPanel2.TabIndex = 3691;
            // 
            // TabMenuLogic
            // 
            this.TabMenuLogic.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabMenuLogic.Controls.Add(this.tpPattern);
            this.TabMenuLogic.Controls.Add(this.tpEYED);
            this.TabMenuLogic.Controls.Add(this.tpCondensor);
            this.TabMenuLogic.Controls.Add(this.tpColorEx);
            this.TabMenuLogic.Controls.Add(this.tpPin);
            this.TabMenuLogic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMenuLogic.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TabMenuLogic.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.TabMenuLogic.ItemSize = new System.Drawing.Size(90, 30);
            this.TabMenuLogic.Location = new System.Drawing.Point(0, 0);
            this.TabMenuLogic.Margin = new System.Windows.Forms.Padding(0);
            this.TabMenuLogic.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.TabMenuLogic.Multiline = true;
            this.TabMenuLogic.Name = "TabMenuLogic";
            this.TabMenuLogic.SelectedIndex = 0;
            this.TabMenuLogic.Size = new System.Drawing.Size(400, 515);
            this.TabMenuLogic.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabMenuLogic.TabBackColor = System.Drawing.Color.SlateGray;
            this.TabMenuLogic.TabIndex = 0;
            this.TabMenuLogic.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.TabMenuLogic.TabSelectedForeColor = System.Drawing.Color.Black;
            this.TabMenuLogic.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.TabMenuLogic.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tpPattern
            // 
            this.tpPattern.BackColor = System.Drawing.Color.White;
            this.tpPattern.Controls.Add(this.richtxtPatternResult);
            this.tpPattern.Controls.Add(this.label9);
            this.tpPattern.Controls.Add(this.uiLine23);
            this.tpPattern.Controls.Add(this.BtnDeletePattern);
            this.tpPattern.Controls.Add(this.label26);
            this.tpPattern.Controls.Add(this.comboJobPattern_PatternType);
            this.tpPattern.Controls.Add(this.tbJobPattern_AcceptScore);
            this.tpPattern.Controls.Add(this.label13);
            this.tpPattern.Controls.Add(this.label10);
            this.tpPattern.Controls.Add(this.uiLine3);
            this.tpPattern.Controls.Add(this.tbJobPattern_MinScore);
            this.tpPattern.Controls.Add(this.label11);
            this.tpPattern.Controls.Add(this.tbPatternMasterCount);
            this.tpPattern.Controls.Add(this.label12);
            this.tpPattern.Controls.Add(this.btnJobPattern_Roi);
            this.tpPattern.Controls.Add(this.btnJobPattern_Train);
            this.tpPattern.Controls.Add(this.btnJobPattern_Find);
            this.tpPattern.Controls.Add(this.label110);
            this.tpPattern.Controls.Add(this.panel14);
            this.tpPattern.Controls.Add(this.lblSubPatternInfo);
            this.tpPattern.Location = new System.Drawing.Point(91, 0);
            this.tpPattern.Name = "tpPattern";
            this.tpPattern.Size = new System.Drawing.Size(309, 515);
            this.tpPattern.TabIndex = 0;
            this.tpPattern.Text = "Pattern";
            // 
            // richtxtPatternResult
            // 
            this.richtxtPatternResult.FillColor = System.Drawing.Color.White;
            this.richtxtPatternResult.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richtxtPatternResult.Location = new System.Drawing.Point(14, 394);
            this.richtxtPatternResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richtxtPatternResult.MinimumSize = new System.Drawing.Size(1, 1);
            this.richtxtPatternResult.Name = "richtxtPatternResult";
            this.richtxtPatternResult.Padding = new System.Windows.Forms.Padding(2);
            this.richtxtPatternResult.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.richtxtPatternResult.ShowText = false;
            this.richtxtPatternResult.Size = new System.Drawing.Size(281, 113);
            this.richtxtPatternResult.TabIndex = 3681;
            this.richtxtPatternResult.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 369);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(260, 20);
            this.label9.TabIndex = 3680;
            this.label9.Text = "Result";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine23
            // 
            this.uiLine23.BackColor = System.Drawing.Color.Transparent;
            this.uiLine23.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine23.LineColor = System.Drawing.Color.Black;
            this.uiLine23.Location = new System.Drawing.Point(5, 252);
            this.uiLine23.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine23.Name = "uiLine23";
            this.uiLine23.Size = new System.Drawing.Size(298, 10);
            this.uiLine23.TabIndex = 3677;
            // 
            // BtnDeletePattern
            // 
            this.BtnDeletePattern.BackColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.CircleRectWidth = 0;
            this.BtnDeletePattern.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDeletePattern.FillColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnDeletePattern.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDeletePattern.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDeletePattern.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDeletePattern.Location = new System.Drawing.Point(212, 225);
            this.BtnDeletePattern.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnDeletePattern.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnDeletePattern.Name = "BtnDeletePattern";
            this.BtnDeletePattern.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnDeletePattern.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDeletePattern.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDeletePattern.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDeletePattern.Size = new System.Drawing.Size(91, 24);
            this.BtnDeletePattern.Style = Sunny.UI.UIStyle.Custom;
            this.BtnDeletePattern.StyleCustomMode = true;
            this.BtnDeletePattern.Symbol = 61453;
            this.BtnDeletePattern.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDeletePattern.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDeletePattern.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnDeletePattern.SymbolSize = 16;
            this.BtnDeletePattern.TabIndex = 3676;
            this.BtnDeletePattern.Tag = "ZoomIn";
            this.BtnDeletePattern.Text = "Delete";
            this.BtnDeletePattern.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnDeletePattern.Click += new System.EventHandler(this.OnClickAlgorithm_Pattern);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(6, 205);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(260, 20);
            this.label26.TabIndex = 3674;
            this.label26.Text = "Pattern";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboJobPattern_PatternType
            // 
            this.comboJobPattern_PatternType.DataSource = null;
            this.comboJobPattern_PatternType.FillColor = System.Drawing.SystemColors.Control;
            this.comboJobPattern_PatternType.Font = new System.Drawing.Font("Arial", 9.75F);
            this.comboJobPattern_PatternType.ForeColor = System.Drawing.Color.Black;
            this.comboJobPattern_PatternType.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboJobPattern_PatternType.ItemForeColor = System.Drawing.Color.White;
            this.comboJobPattern_PatternType.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboJobPattern_PatternType.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboJobPattern_PatternType.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboJobPattern_PatternType.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboJobPattern_PatternType.Location = new System.Drawing.Point(108, 225);
            this.comboJobPattern_PatternType.Margin = new System.Windows.Forms.Padding(0);
            this.comboJobPattern_PatternType.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboJobPattern_PatternType.Name = "comboJobPattern_PatternType";
            this.comboJobPattern_PatternType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboJobPattern_PatternType.RectColor = System.Drawing.Color.DimGray;
            this.comboJobPattern_PatternType.Size = new System.Drawing.Size(102, 25);
            this.comboJobPattern_PatternType.SymbolSize = 24;
            this.comboJobPattern_PatternType.TabIndex = 3670;
            this.comboJobPattern_PatternType.Text = "1";
            this.comboJobPattern_PatternType.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.comboJobPattern_PatternType.Watermark = "";
            this.comboJobPattern_PatternType.SelectedIndexChanged += new System.EventHandler(this.comboJobPattern_PatternType_SelectedIndexChanged);
            // 
            // tbJobPattern_AcceptScore
            // 
            this.tbJobPattern_AcceptScore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbJobPattern_AcceptScore.FillColor = System.Drawing.SystemColors.Control;
            this.tbJobPattern_AcceptScore.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbJobPattern_AcceptScore.ForeColor = System.Drawing.Color.Black;
            this.tbJobPattern_AcceptScore.Location = new System.Drawing.Point(110, 335);
            this.tbJobPattern_AcceptScore.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbJobPattern_AcceptScore.MinimumSize = new System.Drawing.Size(1, 20);
            this.tbJobPattern_AcceptScore.Name = "tbJobPattern_AcceptScore";
            this.tbJobPattern_AcceptScore.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbJobPattern_AcceptScore.RectColor = System.Drawing.Color.DimGray;
            this.tbJobPattern_AcceptScore.ShowText = false;
            this.tbJobPattern_AcceptScore.Size = new System.Drawing.Size(132, 25);
            this.tbJobPattern_AcceptScore.TabIndex = 3663;
            this.tbJobPattern_AcceptScore.Text = "0.00";
            this.tbJobPattern_AcceptScore.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbJobPattern_AcceptScore.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.tbJobPattern_AcceptScore.Watermark = "";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Arial", 8F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(11, 335);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 25);
            this.label13.TabIndex = 3662;
            this.label13.Text = "Find Score (Min)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(6, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(260, 20);
            this.label10.TabIndex = 3660;
            this.label10.Text = "Parameter";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine3
            // 
            this.uiLine3.BackColor = System.Drawing.Color.Transparent;
            this.uiLine3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine3.LineColor = System.Drawing.Color.Black;
            this.uiLine3.Location = new System.Drawing.Point(5, 362);
            this.uiLine3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(298, 10);
            this.uiLine3.TabIndex = 3658;
            // 
            // tbJobPattern_MinScore
            // 
            this.tbJobPattern_MinScore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbJobPattern_MinScore.FillColor = System.Drawing.SystemColors.Control;
            this.tbJobPattern_MinScore.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbJobPattern_MinScore.ForeColor = System.Drawing.Color.Black;
            this.tbJobPattern_MinScore.Location = new System.Drawing.Point(110, 307);
            this.tbJobPattern_MinScore.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbJobPattern_MinScore.MinimumSize = new System.Drawing.Size(1, 20);
            this.tbJobPattern_MinScore.Name = "tbJobPattern_MinScore";
            this.tbJobPattern_MinScore.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbJobPattern_MinScore.RectColor = System.Drawing.Color.DimGray;
            this.tbJobPattern_MinScore.ShowText = false;
            this.tbJobPattern_MinScore.Size = new System.Drawing.Size(132, 25);
            this.tbJobPattern_MinScore.TabIndex = 3657;
            this.tbJobPattern_MinScore.Text = "0.00";
            this.tbJobPattern_MinScore.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbJobPattern_MinScore.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.tbJobPattern_MinScore.Watermark = "";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 8F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(11, 307);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 25);
            this.label11.TabIndex = 3656;
            this.label11.Text = "Judge Score (Min)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPatternMasterCount
            // 
            this.tbPatternMasterCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPatternMasterCount.FillColor = System.Drawing.SystemColors.Control;
            this.tbPatternMasterCount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPatternMasterCount.ForeColor = System.Drawing.Color.Black;
            this.tbPatternMasterCount.Location = new System.Drawing.Point(110, 279);
            this.tbPatternMasterCount.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbPatternMasterCount.MinimumSize = new System.Drawing.Size(1, 20);
            this.tbPatternMasterCount.Name = "tbPatternMasterCount";
            this.tbPatternMasterCount.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbPatternMasterCount.RectColor = System.Drawing.Color.DimGray;
            this.tbPatternMasterCount.ShowText = false;
            this.tbPatternMasterCount.Size = new System.Drawing.Size(132, 25);
            this.tbPatternMasterCount.TabIndex = 3655;
            this.tbPatternMasterCount.Text = "0";
            this.tbPatternMasterCount.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbPatternMasterCount.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.tbPatternMasterCount.Watermark = "";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 8F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(11, 279);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 25);
            this.label12.TabIndex = 3654;
            this.label12.Text = "Master Count";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnJobPattern_Roi
            // 
            this.btnJobPattern_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPattern_Roi.FillColor = System.Drawing.Color.Transparent;
            this.btnJobPattern_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPattern_Roi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Roi.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Roi.Location = new System.Drawing.Point(212, 30);
            this.btnJobPattern_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPattern_Roi.Name = "btnJobPattern_Roi";
            this.btnJobPattern_Roi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobPattern_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPattern_Roi.Size = new System.Drawing.Size(91, 42);
            this.btnJobPattern_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPattern_Roi.StyleCustomMode = true;
            this.btnJobPattern_Roi.Symbol = 362923;
            this.btnJobPattern_Roi.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Roi.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPattern_Roi.SymbolSize = 20;
            this.btnJobPattern_Roi.TabIndex = 3541;
            this.btnJobPattern_Roi.Text = "Roi";
            this.btnJobPattern_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobPattern_Roi.Click += new System.EventHandler(this.OnClickAlgorithm_Pattern);
            // 
            // btnJobPattern_Train
            // 
            this.btnJobPattern_Train.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPattern_Train.FillColor = System.Drawing.Color.Transparent;
            this.btnJobPattern_Train.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Train.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Train.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Train.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Train.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPattern_Train.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Train.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Train.Location = new System.Drawing.Point(212, 73);
            this.btnJobPattern_Train.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPattern_Train.Name = "btnJobPattern_Train";
            this.btnJobPattern_Train.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Train.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Train.RectPressColor = System.Drawing.Color.White;
            this.btnJobPattern_Train.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPattern_Train.Size = new System.Drawing.Size(91, 42);
            this.btnJobPattern_Train.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPattern_Train.StyleCustomMode = true;
            this.btnJobPattern_Train.Symbol = 108;
            this.btnJobPattern_Train.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Train.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Train.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPattern_Train.SymbolSize = 20;
            this.btnJobPattern_Train.TabIndex = 3542;
            this.btnJobPattern_Train.Text = "Train";
            this.btnJobPattern_Train.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobPattern_Train.Click += new System.EventHandler(this.OnClickAlgorithm_Pattern);
            // 
            // btnJobPattern_Find
            // 
            this.btnJobPattern_Find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPattern_Find.FillColor = System.Drawing.Color.Transparent;
            this.btnJobPattern_Find.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Find.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Find.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Find.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPattern_Find.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPattern_Find.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Find.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Find.Location = new System.Drawing.Point(212, 121);
            this.btnJobPattern_Find.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPattern_Find.Name = "btnJobPattern_Find";
            this.btnJobPattern_Find.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Find.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Find.RectPressColor = System.Drawing.Color.White;
            this.btnJobPattern_Find.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPattern_Find.Size = new System.Drawing.Size(91, 42);
            this.btnJobPattern_Find.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPattern_Find.StyleCustomMode = true;
            this.btnJobPattern_Find.Symbol = 61442;
            this.btnJobPattern_Find.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Find.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPattern_Find.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPattern_Find.SymbolSize = 20;
            this.btnJobPattern_Find.TabIndex = 3543;
            this.btnJobPattern_Find.Text = "Find";
            this.btnJobPattern_Find.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobPattern_Find.Click += new System.EventHandler(this.OnClickAlgorithm_Pattern);
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
            this.label110.Size = new System.Drawing.Size(309, 27);
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
            this.label65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            // lblSubPatternInfo
            // 
            this.lblSubPatternInfo.Font = new System.Drawing.Font("Arial", 8F);
            this.lblSubPatternInfo.ForeColor = System.Drawing.Color.Black;
            this.lblSubPatternInfo.Location = new System.Drawing.Point(11, 225);
            this.lblSubPatternInfo.Name = "lblSubPatternInfo";
            this.lblSubPatternInfo.Size = new System.Drawing.Size(80, 25);
            this.lblSubPatternInfo.TabIndex = 3671;
            this.lblSubPatternInfo.Text = "Index (00/05)";
            this.lblSubPatternInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpEYED
            // 
            this.tpEYED.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tpEYED.Controls.Add(this.panel2);
            this.tpEYED.Location = new System.Drawing.Point(91, 0);
            this.tpEYED.Name = "tpEYED";
            this.tpEYED.Size = new System.Drawing.Size(309, 515);
            this.tpEYED.TabIndex = 3;
            this.tpEYED.Text = "EYE-D";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblEyeD_ColorEx_Result);
            this.panel2.Controls.Add(this.label67);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label84);
            this.panel2.Controls.Add(this.chkEyeD_UseColor);
            this.panel2.Controls.Add(this.label58);
            this.panel2.Controls.Add(this.btnEyeD_ColorEx_Get);
            this.panel2.Controls.Add(this.btnEyeD_ColorExRoi);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 515);
            this.panel2.TabIndex = 0;
            // 
            // lblEyeD_ColorEx_Result
            // 
            this.lblEyeD_ColorEx_Result.BackColor = System.Drawing.Color.Transparent;
            this.lblEyeD_ColorEx_Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEyeD_ColorEx_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEyeD_ColorEx_Result.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEyeD_ColorEx_Result.ForeColor = System.Drawing.Color.Black;
            this.lblEyeD_ColorEx_Result.Location = new System.Drawing.Point(80, 404);
            this.lblEyeD_ColorEx_Result.Name = "lblEyeD_ColorEx_Result";
            this.lblEyeD_ColorEx_Result.Size = new System.Drawing.Size(226, 35);
            this.lblEyeD_ColorEx_Result.TabIndex = 3561;
            this.lblEyeD_ColorEx_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label67.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label67.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.Black;
            this.label67.Location = new System.Drawing.Point(2, 404);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(77, 35);
            this.label67.TabIndex = 3560;
            this.label67.Text = "Result\r\nColor";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.radioColorEx_Range45);
            this.panel6.Controls.Add(this.radioColorEx_Range30);
            this.panel6.Controls.Add(this.radioColorEx_Range15);
            this.panel6.Controls.Add(this.txtEyeD_ColorEx_B);
            this.panel6.Controls.Add(this.txtEyeD_ColorEx_G);
            this.panel6.Controls.Add(this.txtEyeD_ColorEx_R);
            this.panel6.Controls.Add(this.label81);
            this.panel6.Controls.Add(this.label82);
            this.panel6.Controls.Add(this.label83);
            this.panel6.ForeColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(80, 338);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(226, 63);
            this.panel6.TabIndex = 3559;
            // 
            // radioColorEx_Range45
            // 
            this.radioColorEx_Range45.AutoSize = true;
            this.radioColorEx_Range45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.radioColorEx_Range45.Location = new System.Drawing.Point(140, 30);
            this.radioColorEx_Range45.Name = "radioColorEx_Range45";
            this.radioColorEx_Range45.Size = new System.Drawing.Size(46, 20);
            this.radioColorEx_Range45.TabIndex = 3556;
            this.radioColorEx_Range45.Text = "±45";
            this.radioColorEx_Range45.UseVisualStyleBackColor = true;
            // 
            // radioColorEx_Range30
            // 
            this.radioColorEx_Range30.AutoSize = true;
            this.radioColorEx_Range30.Checked = true;
            this.radioColorEx_Range30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.radioColorEx_Range30.Location = new System.Drawing.Point(86, 30);
            this.radioColorEx_Range30.Name = "radioColorEx_Range30";
            this.radioColorEx_Range30.Size = new System.Drawing.Size(46, 20);
            this.radioColorEx_Range30.TabIndex = 3555;
            this.radioColorEx_Range30.TabStop = true;
            this.radioColorEx_Range30.Text = "±30";
            this.radioColorEx_Range30.UseVisualStyleBackColor = true;
            // 
            // radioColorEx_Range15
            // 
            this.radioColorEx_Range15.AutoSize = true;
            this.radioColorEx_Range15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.radioColorEx_Range15.Location = new System.Drawing.Point(29, 30);
            this.radioColorEx_Range15.Name = "radioColorEx_Range15";
            this.radioColorEx_Range15.Size = new System.Drawing.Size(46, 20);
            this.radioColorEx_Range15.TabIndex = 3554;
            this.radioColorEx_Range15.Text = "±15";
            this.radioColorEx_Range15.UseVisualStyleBackColor = true;
            // 
            // txtEyeD_ColorEx_B
            // 
            this.txtEyeD_ColorEx_B.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEyeD_ColorEx_B.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEyeD_ColorEx_B.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtEyeD_ColorEx_B.Location = new System.Drawing.Point(175, 2);
            this.txtEyeD_ColorEx_B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEyeD_ColorEx_B.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtEyeD_ColorEx_B.Name = "txtEyeD_ColorEx_B";
            this.txtEyeD_ColorEx_B.Padding = new System.Windows.Forms.Padding(5);
            this.txtEyeD_ColorEx_B.RectColor = System.Drawing.Color.White;
            this.txtEyeD_ColorEx_B.ShowText = false;
            this.txtEyeD_ColorEx_B.Size = new System.Drawing.Size(29, 20);
            this.txtEyeD_ColorEx_B.Style = Sunny.UI.UIStyle.Custom;
            this.txtEyeD_ColorEx_B.TabIndex = 3552;
            this.txtEyeD_ColorEx_B.Text = "0";
            this.txtEyeD_ColorEx_B.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtEyeD_ColorEx_B.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtEyeD_ColorEx_B.Watermark = "W";
            // 
            // txtEyeD_ColorEx_G
            // 
            this.txtEyeD_ColorEx_G.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEyeD_ColorEx_G.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEyeD_ColorEx_G.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtEyeD_ColorEx_G.Location = new System.Drawing.Point(120, 2);
            this.txtEyeD_ColorEx_G.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEyeD_ColorEx_G.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtEyeD_ColorEx_G.Name = "txtEyeD_ColorEx_G";
            this.txtEyeD_ColorEx_G.Padding = new System.Windows.Forms.Padding(5);
            this.txtEyeD_ColorEx_G.RectColor = System.Drawing.Color.White;
            this.txtEyeD_ColorEx_G.ShowText = false;
            this.txtEyeD_ColorEx_G.Size = new System.Drawing.Size(29, 20);
            this.txtEyeD_ColorEx_G.Style = Sunny.UI.UIStyle.Custom;
            this.txtEyeD_ColorEx_G.TabIndex = 3550;
            this.txtEyeD_ColorEx_G.Text = "0";
            this.txtEyeD_ColorEx_G.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtEyeD_ColorEx_G.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtEyeD_ColorEx_G.Watermark = "W";
            // 
            // txtEyeD_ColorEx_R
            // 
            this.txtEyeD_ColorEx_R.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEyeD_ColorEx_R.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEyeD_ColorEx_R.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtEyeD_ColorEx_R.Location = new System.Drawing.Point(65, 2);
            this.txtEyeD_ColorEx_R.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEyeD_ColorEx_R.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtEyeD_ColorEx_R.Name = "txtEyeD_ColorEx_R";
            this.txtEyeD_ColorEx_R.Padding = new System.Windows.Forms.Padding(5);
            this.txtEyeD_ColorEx_R.RectColor = System.Drawing.Color.White;
            this.txtEyeD_ColorEx_R.ShowText = false;
            this.txtEyeD_ColorEx_R.Size = new System.Drawing.Size(29, 20);
            this.txtEyeD_ColorEx_R.Style = Sunny.UI.UIStyle.Custom;
            this.txtEyeD_ColorEx_R.TabIndex = 3548;
            this.txtEyeD_ColorEx_R.Text = "0";
            this.txtEyeD_ColorEx_R.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtEyeD_ColorEx_R.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtEyeD_ColorEx_R.Watermark = "W";
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label81.Font = new System.Drawing.Font("Arial", 10F);
            this.label81.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label81.Location = new System.Drawing.Point(151, 2);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(27, 20);
            this.label81.TabIndex = 3553;
            this.label81.Text = "B :";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label82.Font = new System.Drawing.Font("Arial", 10F);
            this.label82.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label82.Location = new System.Drawing.Point(96, 2);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(27, 20);
            this.label82.TabIndex = 3551;
            this.label82.Text = "G :";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label83.Font = new System.Drawing.Font("Arial", 10F);
            this.label83.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label83.Location = new System.Drawing.Point(41, 2);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(27, 20);
            this.label83.TabIndex = 3549;
            this.label83.Text = "R :";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label84.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label84.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label84.Location = new System.Drawing.Point(2, 338);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(77, 63);
            this.label84.TabIndex = 3558;
            this.label84.Text = "Simple Mode";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkEyeD_UseColor
            // 
            this.chkEyeD_UseColor.AutoSize = true;
            this.chkEyeD_UseColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.chkEyeD_UseColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEyeD_UseColor.ForeColor = System.Drawing.Color.White;
            this.chkEyeD_UseColor.Location = new System.Drawing.Point(12, 310);
            this.chkEyeD_UseColor.Name = "chkEyeD_UseColor";
            this.chkEyeD_UseColor.Size = new System.Drawing.Size(15, 14);
            this.chkEyeD_UseColor.TabIndex = 3556;
            this.chkEyeD_UseColor.UseVisualStyleBackColor = false;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label58.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label58.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.White;
            this.label58.Location = new System.Drawing.Point(1, 297);
            this.label58.Name = "label58";
            this.label58.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label58.Size = new System.Drawing.Size(308, 39);
            this.label58.TabIndex = 3555;
            this.label58.Text = "     Color Extract";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEyeD_ColorEx_Get
            // 
            this.btnEyeD_ColorEx_Get.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEyeD_ColorEx_Get.FillColor = System.Drawing.Color.Transparent;
            this.btnEyeD_ColorEx_Get.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEyeD_ColorEx_Get.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorEx_Get.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEyeD_ColorEx_Get.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEyeD_ColorEx_Get.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEyeD_ColorEx_Get.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorEx_Get.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorEx_Get.Location = new System.Drawing.Point(218, 462);
            this.btnEyeD_ColorEx_Get.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEyeD_ColorEx_Get.Name = "btnEyeD_ColorEx_Get";
            this.btnEyeD_ColorEx_Get.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorEx_Get.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorEx_Get.RectPressColor = System.Drawing.Color.White;
            this.btnEyeD_ColorEx_Get.RectSelectedColor = System.Drawing.Color.White;
            this.btnEyeD_ColorEx_Get.Size = new System.Drawing.Size(89, 39);
            this.btnEyeD_ColorEx_Get.Style = Sunny.UI.UIStyle.Custom;
            this.btnEyeD_ColorEx_Get.StyleCustomMode = true;
            this.btnEyeD_ColorEx_Get.Symbol = 0;
            this.btnEyeD_ColorEx_Get.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorEx_Get.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorEx_Get.SymbolSize = 20;
            this.btnEyeD_ColorEx_Get.TabIndex = 3554;
            this.btnEyeD_ColorEx_Get.Text = "Get";
            this.btnEyeD_ColorEx_Get.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEyeD_ColorEx_Get.Click += new System.EventHandler(this.btnEyeD_ColorEx_Get_Click);
            // 
            // btnEyeD_ColorExRoi
            // 
            this.btnEyeD_ColorExRoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEyeD_ColorExRoi.FillColor = System.Drawing.Color.Transparent;
            this.btnEyeD_ColorExRoi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEyeD_ColorExRoi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorExRoi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEyeD_ColorExRoi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEyeD_ColorExRoi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEyeD_ColorExRoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorExRoi.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorExRoi.Location = new System.Drawing.Point(123, 462);
            this.btnEyeD_ColorExRoi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEyeD_ColorExRoi.Name = "btnEyeD_ColorExRoi";
            this.btnEyeD_ColorExRoi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorExRoi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorExRoi.RectPressColor = System.Drawing.Color.White;
            this.btnEyeD_ColorExRoi.RectSelectedColor = System.Drawing.Color.White;
            this.btnEyeD_ColorExRoi.Size = new System.Drawing.Size(88, 39);
            this.btnEyeD_ColorExRoi.Style = Sunny.UI.UIStyle.Custom;
            this.btnEyeD_ColorExRoi.StyleCustomMode = true;
            this.btnEyeD_ColorExRoi.Symbol = 362923;
            this.btnEyeD_ColorExRoi.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorExRoi.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnEyeD_ColorExRoi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnEyeD_ColorExRoi.SymbolSize = 20;
            this.btnEyeD_ColorExRoi.TabIndex = 3553;
            this.btnEyeD_ColorExRoi.Text = "Roi";
            this.btnEyeD_ColorExRoi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEyeD_ColorExRoi.Click += new System.EventHandler(this.OnClickAlgorithm_EYED_ColorEx);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.CbbModelList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label87, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label85, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TbThresholdEYED, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label55, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label39, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnOpenOnnx, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CbRotateImageEYED, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LblResultEYED, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.BtnFindEYED, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.BtnRoiEYED, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 270);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CbbModelList
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CbbModelList, 2);
            this.CbbModelList.DataSource = null;
            this.CbbModelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CbbModelList.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbbModelList.FillColor = System.Drawing.Color.White;
            this.CbbModelList.FillDisableColor = System.Drawing.Color.Black;
            this.CbbModelList.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.CbbModelList.ForeColor = System.Drawing.Color.Black;
            this.CbbModelList.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CbbModelList.ItemForeColor = System.Drawing.Color.White;
            this.CbbModelList.ItemHoverColor = System.Drawing.Color.Gray;
            this.CbbModelList.ItemRectColor = System.Drawing.Color.White;
            this.CbbModelList.ItemSelectBackColor = System.Drawing.Color.Gray;
            this.CbbModelList.ItemSelectForeColor = System.Drawing.Color.White;
            this.CbbModelList.Location = new System.Drawing.Point(122, 5);
            this.CbbModelList.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.CbbModelList.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbbModelList.Name = "CbbModelList";
            this.CbbModelList.Padding = new System.Windows.Forms.Padding(5, 0, 30, 2);
            this.CbbModelList.RectColor = System.Drawing.Color.Black;
            this.CbbModelList.Size = new System.Drawing.Size(137, 35);
            this.CbbModelList.SymbolSize = 24;
            this.CbbModelList.TabIndex = 3549;
            this.CbbModelList.Text = "-";
            this.CbbModelList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbbModelList.Watermark = "";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label87.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label87.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label87.ForeColor = System.Drawing.Color.Black;
            this.label87.Location = new System.Drawing.Point(0, 185);
            this.label87.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(120, 35);
            this.label87.TabIndex = 3546;
            this.label87.Text = "Result";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label85.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label85.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label85.ForeColor = System.Drawing.Color.Black;
            this.label85.Location = new System.Drawing.Point(0, 95);
            this.label85.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(120, 35);
            this.label85.TabIndex = 5;
            this.label85.Text = "Rotate Image";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbThresholdEYED
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TbThresholdEYED, 3);
            this.TbThresholdEYED.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbThresholdEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbThresholdEYED.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.TbThresholdEYED.ForeColor = System.Drawing.Color.Black;
            this.TbThresholdEYED.Location = new System.Drawing.Point(122, 50);
            this.TbThresholdEYED.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.TbThresholdEYED.Maximum = 1D;
            this.TbThresholdEYED.Minimum = 0D;
            this.TbThresholdEYED.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbThresholdEYED.Name = "TbThresholdEYED";
            this.TbThresholdEYED.Padding = new System.Windows.Forms.Padding(5);
            this.TbThresholdEYED.RectColor = System.Drawing.Color.Black;
            this.TbThresholdEYED.ShowText = false;
            this.TbThresholdEYED.Size = new System.Drawing.Size(185, 35);
            this.TbThresholdEYED.TabIndex = 4;
            this.TbThresholdEYED.Text = "0.00";
            this.TbThresholdEYED.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TbThresholdEYED.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.TbThresholdEYED.Watermark = "( 0.0 ~ 1.0 )";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label55.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(0, 50);
            this.label55.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(120, 35);
            this.label55.TabIndex = 3;
            this.label55.Text = "Score (OK) Minimum";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label39.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(0, 5);
            this.label39.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(120, 35);
            this.label39.TabIndex = 0;
            this.label39.Text = "Model List";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnOpenOnnx
            // 
            this.BtnOpenOnnx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOpenOnnx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOpenOnnx.FillColor = System.Drawing.Color.Transparent;
            this.BtnOpenOnnx.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnOpenOnnx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnOpenOnnx.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnOpenOnnx.Location = new System.Drawing.Point(261, 5);
            this.BtnOpenOnnx.Margin = new System.Windows.Forms.Padding(0, 5, 2, 5);
            this.BtnOpenOnnx.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnOpenOnnx.Name = "BtnOpenOnnx";
            this.BtnOpenOnnx.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnOpenOnnx.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnOpenOnnx.Size = new System.Drawing.Size(46, 35);
            this.BtnOpenOnnx.Symbol = 61717;
            this.BtnOpenOnnx.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnOpenOnnx.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnOpenOnnx.TabIndex = 2;
            this.BtnOpenOnnx.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnOpenOnnx.Click += new System.EventHandler(this.BtnOpenOnnx_Click_1);
            // 
            // CbRotateImageEYED
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CbRotateImageEYED, 3);
            this.CbRotateImageEYED.DataSource = null;
            this.CbRotateImageEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CbRotateImageEYED.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbRotateImageEYED.FillColor = System.Drawing.Color.White;
            this.CbRotateImageEYED.FillDisableColor = System.Drawing.Color.Black;
            this.CbRotateImageEYED.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.CbRotateImageEYED.ForeColor = System.Drawing.Color.Black;
            this.CbRotateImageEYED.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CbRotateImageEYED.ItemForeColor = System.Drawing.Color.White;
            this.CbRotateImageEYED.ItemHoverColor = System.Drawing.Color.Gray;
            this.CbRotateImageEYED.ItemRectColor = System.Drawing.Color.White;
            this.CbRotateImageEYED.ItemSelectBackColor = System.Drawing.Color.Gray;
            this.CbRotateImageEYED.ItemSelectForeColor = System.Drawing.Color.White;
            this.CbRotateImageEYED.Location = new System.Drawing.Point(122, 95);
            this.CbRotateImageEYED.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.CbRotateImageEYED.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbRotateImageEYED.Name = "CbRotateImageEYED";
            this.CbRotateImageEYED.Padding = new System.Windows.Forms.Padding(5, 0, 30, 2);
            this.CbRotateImageEYED.RectColor = System.Drawing.Color.Black;
            this.CbRotateImageEYED.Size = new System.Drawing.Size(185, 35);
            this.CbRotateImageEYED.SymbolSize = 24;
            this.CbRotateImageEYED.TabIndex = 6;
            this.CbRotateImageEYED.Text = "0";
            this.CbRotateImageEYED.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbRotateImageEYED.Watermark = "";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 4);
            this.panel3.Controls.Add(this.ChkSpecRegionEYED);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 136);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 1, 2, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 43);
            this.panel3.TabIndex = 3545;
            // 
            // ChkSpecRegionEYED
            // 
            this.ChkSpecRegionEYED.AutoSize = true;
            this.ChkSpecRegionEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkSpecRegionEYED.Font = new System.Drawing.Font("Arial", 9.75F);
            this.ChkSpecRegionEYED.ForeColor = System.Drawing.Color.Black;
            this.ChkSpecRegionEYED.Location = new System.Drawing.Point(0, 0);
            this.ChkSpecRegionEYED.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.ChkSpecRegionEYED.Name = "ChkSpecRegionEYED";
            this.ChkSpecRegionEYED.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ChkSpecRegionEYED.Size = new System.Drawing.Size(303, 39);
            this.ChkSpecRegionEYED.TabIndex = 0;
            this.ChkSpecRegionEYED.Text = "     Use Spec Region (Color : Orange)";
            this.ChkSpecRegionEYED.UseVisualStyleBackColor = true;
            // 
            // LblResultEYED
            // 
            this.LblResultEYED.AutoSize = true;
            this.LblResultEYED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.LblResultEYED, 3);
            this.LblResultEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblResultEYED.ForeColor = System.Drawing.Color.Black;
            this.LblResultEYED.Location = new System.Drawing.Point(122, 185);
            this.LblResultEYED.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.LblResultEYED.Name = "LblResultEYED";
            this.LblResultEYED.Size = new System.Drawing.Size(185, 35);
            this.LblResultEYED.TabIndex = 3546;
            this.LblResultEYED.Text = "-";
            this.LblResultEYED.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnFindEYED
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.BtnFindEYED, 2);
            this.BtnFindEYED.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFindEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFindEYED.FillColor = System.Drawing.Color.Transparent;
            this.BtnFindEYED.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnFindEYED.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnFindEYED.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnFindEYED.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnFindEYED.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFindEYED.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnFindEYED.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnFindEYED.Location = new System.Drawing.Point(217, 228);
            this.BtnFindEYED.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnFindEYED.Name = "BtnFindEYED";
            this.BtnFindEYED.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnFindEYED.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnFindEYED.RectPressColor = System.Drawing.Color.White;
            this.BtnFindEYED.RectSelectedColor = System.Drawing.Color.White;
            this.BtnFindEYED.Size = new System.Drawing.Size(89, 39);
            this.BtnFindEYED.Style = Sunny.UI.UIStyle.Custom;
            this.BtnFindEYED.StyleCustomMode = true;
            this.BtnFindEYED.Symbol = 61442;
            this.BtnFindEYED.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnFindEYED.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnFindEYED.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnFindEYED.SymbolSize = 20;
            this.BtnFindEYED.TabIndex = 3544;
            this.BtnFindEYED.Text = "Find";
            this.BtnFindEYED.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnFindEYED.Click += new System.EventHandler(this.OnClickAlgorithm_EyeD);
            // 
            // BtnRoiEYED
            // 
            this.BtnRoiEYED.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRoiEYED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRoiEYED.FillColor = System.Drawing.Color.Transparent;
            this.BtnRoiEYED.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnRoiEYED.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRoiEYED.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnRoiEYED.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnRoiEYED.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRoiEYED.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRoiEYED.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRoiEYED.Location = new System.Drawing.Point(123, 228);
            this.BtnRoiEYED.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnRoiEYED.Name = "BtnRoiEYED";
            this.BtnRoiEYED.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRoiEYED.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRoiEYED.RectPressColor = System.Drawing.Color.White;
            this.BtnRoiEYED.RectSelectedColor = System.Drawing.Color.White;
            this.BtnRoiEYED.Size = new System.Drawing.Size(88, 39);
            this.BtnRoiEYED.Style = Sunny.UI.UIStyle.Custom;
            this.BtnRoiEYED.StyleCustomMode = true;
            this.BtnRoiEYED.Symbol = 362923;
            this.BtnRoiEYED.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRoiEYED.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRoiEYED.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnRoiEYED.SymbolSize = 20;
            this.BtnRoiEYED.TabIndex = 3542;
            this.BtnRoiEYED.Text = "Roi";
            this.BtnRoiEYED.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRoiEYED.Click += new System.EventHandler(this.OnClickAlgorithm_EyeD);
            // 
            // tpCondensor
            // 
            this.tpCondensor.BackColor = System.Drawing.Color.White;
            this.tpCondensor.Controls.Add(this.tbIgnoreCount);
            this.tpCondensor.Controls.Add(this.tbCircleThickness);
            this.tpCondensor.Controls.Add(this.tbCircleContrast);
            this.tpCondensor.Controls.Add(this.tbCondensorRectRadio);
            this.tpCondensor.Controls.Add(this.tbCircleRectH);
            this.tpCondensor.Controls.Add(this.tbCircleRectW);
            this.tpCondensor.Controls.Add(this.btnJobCondensor_DistSetting);
            this.tpCondensor.Controls.Add(this.btnJobCondensor_DistInsp);
            this.tpCondensor.Controls.Add(this.btnCondensorAutoRegion);
            this.tpCondensor.Controls.Add(this.label104);
            this.tpCondensor.Controls.Add(this.comboCondensorPolarity);
            this.tpCondensor.Controls.Add(this.label105);
            this.tpCondensor.Controls.Add(this.label108);
            this.tpCondensor.Controls.Add(this.label114);
            this.tpCondensor.Controls.Add(this.label115);
            this.tpCondensor.Controls.Add(this.btnJobCondensor_Inspection);
            this.tpCondensor.Controls.Add(this.label116);
            this.tpCondensor.Controls.Add(this.panel13);
            this.tpCondensor.Controls.Add(this.label119);
            this.tpCondensor.Controls.Add(this.label120);
            this.tpCondensor.Controls.Add(this.btnJobCondensor_Roi);
            this.tpCondensor.Controls.Add(this.uiSymbolButton68);
            this.tpCondensor.Location = new System.Drawing.Point(91, 0);
            this.tpCondensor.Name = "tpCondensor";
            this.tpCondensor.Size = new System.Drawing.Size(309, 515);
            this.tpCondensor.TabIndex = 6;
            this.tpCondensor.Text = "Condensor";
            // 
            // tbIgnoreCount
            // 
            this.tbIgnoreCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbIgnoreCount.Font = new System.Drawing.Font("Arial", 9F);
            this.tbIgnoreCount.ForeColor = System.Drawing.Color.Black;
            this.tbIgnoreCount.Location = new System.Drawing.Point(83, 253);
            this.tbIgnoreCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIgnoreCount.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbIgnoreCount.Name = "tbIgnoreCount";
            this.tbIgnoreCount.Padding = new System.Windows.Forms.Padding(5);
            this.tbIgnoreCount.RectColor = System.Drawing.Color.Black;
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
            this.tbCircleThickness.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCircleThickness.ForeColor = System.Drawing.Color.Black;
            this.tbCircleThickness.Location = new System.Drawing.Point(83, 218);
            this.tbCircleThickness.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCircleThickness.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCircleThickness.Name = "tbCircleThickness";
            this.tbCircleThickness.Padding = new System.Windows.Forms.Padding(5);
            this.tbCircleThickness.RectColor = System.Drawing.Color.Black;
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
            this.tbCircleContrast.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCircleContrast.ForeColor = System.Drawing.Color.Black;
            this.tbCircleContrast.Location = new System.Drawing.Point(83, 182);
            this.tbCircleContrast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCircleContrast.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCircleContrast.Name = "tbCircleContrast";
            this.tbCircleContrast.Padding = new System.Windows.Forms.Padding(5);
            this.tbCircleContrast.RectColor = System.Drawing.Color.Black;
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
            this.tbCondensorRectRadio.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCondensorRectRadio.ForeColor = System.Drawing.Color.Black;
            this.tbCondensorRectRadio.Location = new System.Drawing.Point(83, 146);
            this.tbCondensorRectRadio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCondensorRectRadio.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCondensorRectRadio.Name = "tbCondensorRectRadio";
            this.tbCondensorRectRadio.Padding = new System.Windows.Forms.Padding(5);
            this.tbCondensorRectRadio.RectColor = System.Drawing.Color.Black;
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
            this.tbCircleRectH.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCircleRectH.ForeColor = System.Drawing.Color.Black;
            this.tbCircleRectH.Location = new System.Drawing.Point(83, 112);
            this.tbCircleRectH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCircleRectH.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCircleRectH.Name = "tbCircleRectH";
            this.tbCircleRectH.Padding = new System.Windows.Forms.Padding(5);
            this.tbCircleRectH.RectColor = System.Drawing.Color.Black;
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
            this.tbCircleRectW.Font = new System.Drawing.Font("Arial", 9F);
            this.tbCircleRectW.ForeColor = System.Drawing.Color.Black;
            this.tbCircleRectW.Location = new System.Drawing.Point(83, 74);
            this.tbCircleRectW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCircleRectW.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCircleRectW.Name = "tbCircleRectW";
            this.tbCircleRectW.Padding = new System.Windows.Forms.Padding(5);
            this.tbCircleRectW.RectColor = System.Drawing.Color.Black;
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
            this.btnJobCondensor_DistSetting.FillColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistSetting.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistSetting.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistSetting.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistSetting.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistSetting.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobCondensor_DistSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistSetting.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistSetting.Location = new System.Drawing.Point(11, 473);
            this.btnJobCondensor_DistSetting.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobCondensor_DistSetting.Name = "btnJobCondensor_DistSetting";
            this.btnJobCondensor_DistSetting.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistSetting.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistSetting.RectPressColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistSetting.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistSetting.Size = new System.Drawing.Size(140, 30);
            this.btnJobCondensor_DistSetting.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobCondensor_DistSetting.StyleCustomMode = true;
            this.btnJobCondensor_DistSetting.Symbol = 61459;
            this.btnJobCondensor_DistSetting.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistSetting.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistSetting.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobCondensor_DistSetting.SymbolSize = 20;
            this.btnJobCondensor_DistSetting.TabIndex = 3563;
            this.btnJobCondensor_DistSetting.Text = "Setting";
            this.btnJobCondensor_DistSetting.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobCondensor_DistSetting.Visible = false;
            // 
            // btnJobCondensor_DistInsp
            // 
            this.btnJobCondensor_DistInsp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobCondensor_DistInsp.FillColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistInsp.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistInsp.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistInsp.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistInsp.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_DistInsp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobCondensor_DistInsp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistInsp.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistInsp.Location = new System.Drawing.Point(157, 473);
            this.btnJobCondensor_DistInsp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobCondensor_DistInsp.Name = "btnJobCondensor_DistInsp";
            this.btnJobCondensor_DistInsp.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistInsp.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistInsp.RectPressColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistInsp.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobCondensor_DistInsp.Size = new System.Drawing.Size(140, 30);
            this.btnJobCondensor_DistInsp.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobCondensor_DistInsp.StyleCustomMode = true;
            this.btnJobCondensor_DistInsp.Symbol = 61515;
            this.btnJobCondensor_DistInsp.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistInsp.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_DistInsp.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobCondensor_DistInsp.SymbolSize = 20;
            this.btnJobCondensor_DistInsp.TabIndex = 3562;
            this.btnJobCondensor_DistInsp.Text = "Inspection";
            this.btnJobCondensor_DistInsp.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobCondensor_DistInsp.Visible = false;
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
            this.btnCondensorAutoRegion.Visible = false;
            this.btnCondensorAutoRegion.Click += new System.EventHandler(this.btnCondensorAutoRegion_Click);
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.Color.Transparent;
            this.label104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label104.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label104.Font = new System.Drawing.Font("Arial", 8F);
            this.label104.ForeColor = System.Drawing.Color.Black;
            this.label104.Location = new System.Drawing.Point(3, 141);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(80, 35);
            this.label104.TabIndex = 3558;
            this.label104.Text = "RectDistance";
            this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboCondensorPolarity
            // 
            this.comboCondensorPolarity.BackColor = System.Drawing.Color.White;
            this.comboCondensorPolarity.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
            this.comboCondensorPolarity.ForeColor = System.Drawing.Color.Black;
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
            this.comboCondensorPolarity.Theme = MetroFramework.MetroThemeStyle.Light;
            this.comboCondensorPolarity.UseCustomForeColor = true;
            this.comboCondensorPolarity.UseSelectable = true;
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.Color.Transparent;
            this.label105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label105.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label105.Font = new System.Drawing.Font("Arial", 8F);
            this.label105.ForeColor = System.Drawing.Color.Black;
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
            this.label108.ForeColor = System.Drawing.Color.Black;
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
            this.label114.ForeColor = System.Drawing.Color.Black;
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
            this.label115.ForeColor = System.Drawing.Color.Black;
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
            this.btnJobCondensor_Inspection.FillColor = System.Drawing.Color.White;
            this.btnJobCondensor_Inspection.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Inspection.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Inspection.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Inspection.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Inspection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobCondensor_Inspection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Inspection.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Inspection.Location = new System.Drawing.Point(17, 336);
            this.btnJobCondensor_Inspection.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobCondensor_Inspection.Name = "btnJobCondensor_Inspection";
            this.btnJobCondensor_Inspection.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Inspection.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Inspection.RectPressColor = System.Drawing.Color.White;
            this.btnJobCondensor_Inspection.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobCondensor_Inspection.Size = new System.Drawing.Size(269, 42);
            this.btnJobCondensor_Inspection.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobCondensor_Inspection.StyleCustomMode = true;
            this.btnJobCondensor_Inspection.Symbol = 61515;
            this.btnJobCondensor_Inspection.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Inspection.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Inspection.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobCondensor_Inspection.SymbolSize = 20;
            this.btnJobCondensor_Inspection.TabIndex = 3552;
            this.btnJobCondensor_Inspection.Text = "Inspection";
            this.btnJobCondensor_Inspection.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobCondensor_Inspection.Visible = false;
            this.btnJobCondensor_Inspection.Click += new System.EventHandler(this.OnClickAlgorithm_Condensor);
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.Color.Transparent;
            this.label116.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label116.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label116.Font = new System.Drawing.Font("Arial", 8F);
            this.label116.ForeColor = System.Drawing.Color.Black;
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
            this.radioCondensorTB.ForeColor = System.Drawing.Color.Black;
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
            this.radioCondensorLR.ForeColor = System.Drawing.Color.Black;
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
            this.label119.ForeColor = System.Drawing.Color.Black;
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
            this.label120.ForeColor = System.Drawing.Color.Black;
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
            this.btnJobCondensor_Roi.FillColor = System.Drawing.Color.White;
            this.btnJobCondensor_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobCondensor_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobCondensor_Roi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Roi.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Roi.Location = new System.Drawing.Point(17, 290);
            this.btnJobCondensor_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobCondensor_Roi.Name = "btnJobCondensor_Roi";
            this.btnJobCondensor_Roi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobCondensor_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobCondensor_Roi.Size = new System.Drawing.Size(134, 44);
            this.btnJobCondensor_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobCondensor_Roi.StyleCustomMode = true;
            this.btnJobCondensor_Roi.Symbol = 362923;
            this.btnJobCondensor_Roi.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Roi.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobCondensor_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobCondensor_Roi.SymbolSize = 20;
            this.btnJobCondensor_Roi.TabIndex = 3546;
            this.btnJobCondensor_Roi.Text = "Roi";
            this.btnJobCondensor_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobCondensor_Roi.Click += new System.EventHandler(this.OnClickAlgorithm_Condensor);
            // 
            // uiSymbolButton68
            // 
            this.uiSymbolButton68.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton68.FillColor = System.Drawing.Color.White;
            this.uiSymbolButton68.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton68.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton68.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton68.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton68.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton68.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton68.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton68.Location = new System.Drawing.Point(152, 290);
            this.uiSymbolButton68.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton68.Name = "uiSymbolButton68";
            this.uiSymbolButton68.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton68.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton68.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton68.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton68.Size = new System.Drawing.Size(134, 44);
            this.uiSymbolButton68.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton68.StyleCustomMode = true;
            this.uiSymbolButton68.Symbol = 61442;
            this.uiSymbolButton68.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton68.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton68.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton68.SymbolSize = 20;
            this.uiSymbolButton68.TabIndex = 3547;
            this.uiSymbolButton68.Text = "Find";
            this.uiSymbolButton68.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton68.Click += new System.EventHandler(this.OnClickAlgorithm_Condensor);
            // 
            // tpColorEx
            // 
            this.tpColorEx.BackColor = System.Drawing.Color.White;
            this.tpColorEx.Controls.Add(this.btnJobColorEx_Get);
            this.tpColorEx.Controls.Add(this.panel64);
            this.tpColorEx.Controls.Add(this.chkColorEx_SimpleMode);
            this.tpColorEx.Controls.Add(this.label167);
            this.tpColorEx.Controls.Add(this.btnJobColorEx_Roi);
            this.tpColorEx.Controls.Add(this.lblJobColorEx_ResultColor);
            this.tpColorEx.Controls.Add(this.label130);
            this.tpColorEx.Controls.Add(this.uiSymbolButton67);
            this.tpColorEx.Controls.Add(this.label133);
            this.tpColorEx.Location = new System.Drawing.Point(91, 0);
            this.tpColorEx.Name = "tpColorEx";
            this.tpColorEx.Size = new System.Drawing.Size(309, 515);
            this.tpColorEx.TabIndex = 5;
            this.tpColorEx.Text = "ColorEx";
            // 
            // btnJobColorEx_Get
            // 
            this.btnJobColorEx_Get.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobColorEx_Get.FillColor = System.Drawing.Color.White;
            this.btnJobColorEx_Get.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Get.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Get.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Get.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Get.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobColorEx_Get.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Get.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Get.Location = new System.Drawing.Point(196, 302);
            this.btnJobColorEx_Get.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobColorEx_Get.Name = "btnJobColorEx_Get";
            this.btnJobColorEx_Get.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Get.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Get.RectPressColor = System.Drawing.Color.White;
            this.btnJobColorEx_Get.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobColorEx_Get.Size = new System.Drawing.Size(106, 42);
            this.btnJobColorEx_Get.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobColorEx_Get.StyleCustomMode = true;
            this.btnJobColorEx_Get.Symbol = 0;
            this.btnJobColorEx_Get.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Get.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Get.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobColorEx_Get.SymbolSize = 16;
            this.btnJobColorEx_Get.TabIndex = 3559;
            this.btnJobColorEx_Get.Text = "Get";
            this.btnJobColorEx_Get.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobColorEx_Get.Click += new System.EventHandler(this.btnJobColorEx_Get_Click);
            // 
            // panel64
            // 
            this.panel64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel64.Controls.Add(this.TbColorEXRangeMax_B);
            this.panel64.Controls.Add(this.TbColorEXRangeMax_G);
            this.panel64.Controls.Add(this.TbColorEXRangeMax_R);
            this.panel64.Controls.Add(this.label56);
            this.panel64.Controls.Add(this.label31);
            this.panel64.Controls.Add(this.TbColorEXRangeMin_B);
            this.panel64.Controls.Add(this.label77);
            this.panel64.Controls.Add(this.TbColorEXRangeMin_G);
            this.panel64.Controls.Add(this.TbColorEXRangeMin_R);
            this.panel64.Controls.Add(this.label63);
            this.panel64.Controls.Add(this.label22);
            this.panel64.Controls.Add(this.txtColorEx_B);
            this.panel64.Controls.Add(this.txtColorEx_G);
            this.panel64.Controls.Add(this.txtColorEx_R);
            this.panel64.Controls.Add(this.label168);
            this.panel64.Controls.Add(this.label171);
            this.panel64.Controls.Add(this.label170);
            this.panel64.Controls.Add(this.label169);
            this.panel64.ForeColor = System.Drawing.Color.Black;
            this.panel64.Location = new System.Drawing.Point(80, 29);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(226, 192);
            this.panel64.TabIndex = 3557;
            // 
            // TbColorEXRangeMax_B
            // 
            this.TbColorEXRangeMax_B.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbColorEXRangeMax_B.Font = new System.Drawing.Font("Arial", 7F);
            this.TbColorEXRangeMax_B.ForeColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMax_B.Location = new System.Drawing.Point(157, 97);
            this.TbColorEXRangeMax_B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbColorEXRangeMax_B.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbColorEXRangeMax_B.Name = "TbColorEXRangeMax_B";
            this.TbColorEXRangeMax_B.Padding = new System.Windows.Forms.Padding(5);
            this.TbColorEXRangeMax_B.RectColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMax_B.ShowText = false;
            this.TbColorEXRangeMax_B.Size = new System.Drawing.Size(47, 28);
            this.TbColorEXRangeMax_B.Style = Sunny.UI.UIStyle.Custom;
            this.TbColorEXRangeMax_B.TabIndex = 3565;
            this.TbColorEXRangeMax_B.Text = "0";
            this.TbColorEXRangeMax_B.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbColorEXRangeMax_B.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbColorEXRangeMax_B.Watermark = "W";
            // 
            // TbColorEXRangeMax_G
            // 
            this.TbColorEXRangeMax_G.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbColorEXRangeMax_G.Font = new System.Drawing.Font("Arial", 7F);
            this.TbColorEXRangeMax_G.ForeColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMax_G.Location = new System.Drawing.Point(102, 97);
            this.TbColorEXRangeMax_G.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbColorEXRangeMax_G.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbColorEXRangeMax_G.Name = "TbColorEXRangeMax_G";
            this.TbColorEXRangeMax_G.Padding = new System.Windows.Forms.Padding(5);
            this.TbColorEXRangeMax_G.RectColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMax_G.ShowText = false;
            this.TbColorEXRangeMax_G.Size = new System.Drawing.Size(47, 28);
            this.TbColorEXRangeMax_G.Style = Sunny.UI.UIStyle.Custom;
            this.TbColorEXRangeMax_G.TabIndex = 3564;
            this.TbColorEXRangeMax_G.Text = "0";
            this.TbColorEXRangeMax_G.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbColorEXRangeMax_G.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbColorEXRangeMax_G.Watermark = "W";
            // 
            // TbColorEXRangeMax_R
            // 
            this.TbColorEXRangeMax_R.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbColorEXRangeMax_R.Font = new System.Drawing.Font("Arial", 7F);
            this.TbColorEXRangeMax_R.ForeColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMax_R.Location = new System.Drawing.Point(47, 97);
            this.TbColorEXRangeMax_R.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbColorEXRangeMax_R.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbColorEXRangeMax_R.Name = "TbColorEXRangeMax_R";
            this.TbColorEXRangeMax_R.Padding = new System.Windows.Forms.Padding(5);
            this.TbColorEXRangeMax_R.RectColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMax_R.ShowText = false;
            this.TbColorEXRangeMax_R.Size = new System.Drawing.Size(47, 28);
            this.TbColorEXRangeMax_R.Style = Sunny.UI.UIStyle.Custom;
            this.TbColorEXRangeMax_R.TabIndex = 3563;
            this.TbColorEXRangeMax_R.Text = "0";
            this.TbColorEXRangeMax_R.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbColorEXRangeMax_R.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbColorEXRangeMax_R.Watermark = "W";
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label56.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label56.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.Color.Black;
            this.label56.Location = new System.Drawing.Point(3, 97);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(40, 28);
            this.label56.TabIndex = 3562;
            this.label56.Text = "Max";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label31.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(3, 63);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(40, 28);
            this.label31.TabIndex = 3561;
            this.label31.Text = "Min";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbColorEXRangeMin_B
            // 
            this.TbColorEXRangeMin_B.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbColorEXRangeMin_B.Font = new System.Drawing.Font("Arial", 7F);
            this.TbColorEXRangeMin_B.ForeColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMin_B.Location = new System.Drawing.Point(157, 63);
            this.TbColorEXRangeMin_B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbColorEXRangeMin_B.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbColorEXRangeMin_B.Name = "TbColorEXRangeMin_B";
            this.TbColorEXRangeMin_B.Padding = new System.Windows.Forms.Padding(5);
            this.TbColorEXRangeMin_B.RectColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMin_B.ShowText = false;
            this.TbColorEXRangeMin_B.Size = new System.Drawing.Size(47, 28);
            this.TbColorEXRangeMin_B.Style = Sunny.UI.UIStyle.Custom;
            this.TbColorEXRangeMin_B.TabIndex = 3560;
            this.TbColorEXRangeMin_B.Text = "0";
            this.TbColorEXRangeMin_B.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbColorEXRangeMin_B.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbColorEXRangeMin_B.Watermark = "W";
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.Transparent;
            this.label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label77.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label77.Font = new System.Drawing.Font("Arial", 7F);
            this.label77.ForeColor = System.Drawing.Color.Black;
            this.label77.Location = new System.Drawing.Point(157, 30);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(47, 28);
            this.label77.TabIndex = 3559;
            this.label77.Text = "Range (B)";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbColorEXRangeMin_G
            // 
            this.TbColorEXRangeMin_G.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbColorEXRangeMin_G.Font = new System.Drawing.Font("Arial", 7F);
            this.TbColorEXRangeMin_G.ForeColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMin_G.Location = new System.Drawing.Point(102, 63);
            this.TbColorEXRangeMin_G.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbColorEXRangeMin_G.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbColorEXRangeMin_G.Name = "TbColorEXRangeMin_G";
            this.TbColorEXRangeMin_G.Padding = new System.Windows.Forms.Padding(5);
            this.TbColorEXRangeMin_G.RectColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMin_G.ShowText = false;
            this.TbColorEXRangeMin_G.Size = new System.Drawing.Size(47, 28);
            this.TbColorEXRangeMin_G.Style = Sunny.UI.UIStyle.Custom;
            this.TbColorEXRangeMin_G.TabIndex = 3558;
            this.TbColorEXRangeMin_G.Text = "0";
            this.TbColorEXRangeMin_G.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbColorEXRangeMin_G.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbColorEXRangeMin_G.Watermark = "W";
            // 
            // TbColorEXRangeMin_R
            // 
            this.TbColorEXRangeMin_R.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbColorEXRangeMin_R.Font = new System.Drawing.Font("Arial", 7F);
            this.TbColorEXRangeMin_R.ForeColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMin_R.Location = new System.Drawing.Point(47, 63);
            this.TbColorEXRangeMin_R.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbColorEXRangeMin_R.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbColorEXRangeMin_R.Name = "TbColorEXRangeMin_R";
            this.TbColorEXRangeMin_R.Padding = new System.Windows.Forms.Padding(5);
            this.TbColorEXRangeMin_R.RectColor = System.Drawing.Color.Black;
            this.TbColorEXRangeMin_R.ShowText = false;
            this.TbColorEXRangeMin_R.Size = new System.Drawing.Size(47, 28);
            this.TbColorEXRangeMin_R.Style = Sunny.UI.UIStyle.Custom;
            this.TbColorEXRangeMin_R.TabIndex = 3557;
            this.TbColorEXRangeMin_R.Text = "0";
            this.TbColorEXRangeMin_R.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbColorEXRangeMin_R.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.TbColorEXRangeMin_R.Watermark = "W";
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label63.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label63.Font = new System.Drawing.Font("Arial", 7F);
            this.label63.ForeColor = System.Drawing.Color.Black;
            this.label63.Location = new System.Drawing.Point(102, 30);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(47, 28);
            this.label63.TabIndex = 3556;
            this.label63.Text = "Range (G)";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("Arial", 7F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(47, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 28);
            this.label22.TabIndex = 3554;
            this.label22.Text = "Range (R)";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtColorEx_B
            // 
            this.txtColorEx_B.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtColorEx_B.Font = new System.Drawing.Font("Arial", 10F);
            this.txtColorEx_B.ForeColor = System.Drawing.Color.Black;
            this.txtColorEx_B.Location = new System.Drawing.Point(178, 5);
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
            this.txtColorEx_G.Font = new System.Drawing.Font("Arial", 10F);
            this.txtColorEx_G.ForeColor = System.Drawing.Color.Black;
            this.txtColorEx_G.Location = new System.Drawing.Point(123, 5);
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
            this.txtColorEx_R.Font = new System.Drawing.Font("Arial", 10F);
            this.txtColorEx_R.ForeColor = System.Drawing.Color.Black;
            this.txtColorEx_R.Location = new System.Drawing.Point(68, 5);
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
            this.label168.Font = new System.Drawing.Font("Arial", 9F);
            this.label168.ForeColor = System.Drawing.Color.Black;
            this.label168.Location = new System.Drawing.Point(38, 152);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(141, 33);
            this.label168.TabIndex = 3547;
            this.label168.Text = "Diff Range (R,G,B)";
            this.label168.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label168.Visible = false;
            // 
            // label171
            // 
            this.label171.BackColor = System.Drawing.Color.Transparent;
            this.label171.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label171.Font = new System.Drawing.Font("Arial", 10F);
            this.label171.ForeColor = System.Drawing.Color.Black;
            this.label171.Location = new System.Drawing.Point(154, 5);
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
            this.label170.Font = new System.Drawing.Font("Arial", 10F);
            this.label170.ForeColor = System.Drawing.Color.Black;
            this.label170.Location = new System.Drawing.Point(99, 5);
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
            this.label169.Font = new System.Drawing.Font("Arial", 10F);
            this.label169.ForeColor = System.Drawing.Color.Black;
            this.label169.Location = new System.Drawing.Point(44, 5);
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
            this.chkColorEx_SimpleMode.Visible = false;
            // 
            // label167
            // 
            this.label167.BackColor = System.Drawing.Color.Transparent;
            this.label167.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label167.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label167.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label167.ForeColor = System.Drawing.Color.Black;
            this.label167.Location = new System.Drawing.Point(2, 29);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(77, 192);
            this.label167.TabIndex = 3555;
            this.label167.Text = "Simple Mode";
            this.label167.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJobColorEx_Roi
            // 
            this.btnJobColorEx_Roi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobColorEx_Roi.FillColor = System.Drawing.Color.White;
            this.btnJobColorEx_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnJobColorEx_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobColorEx_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobColorEx_Roi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Roi.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Roi.Location = new System.Drawing.Point(84, 302);
            this.btnJobColorEx_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobColorEx_Roi.Name = "btnJobColorEx_Roi";
            this.btnJobColorEx_Roi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobColorEx_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobColorEx_Roi.Size = new System.Drawing.Size(106, 42);
            this.btnJobColorEx_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobColorEx_Roi.StyleCustomMode = true;
            this.btnJobColorEx_Roi.Symbol = 362923;
            this.btnJobColorEx_Roi.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Roi.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobColorEx_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobColorEx_Roi.SymbolSize = 16;
            this.btnJobColorEx_Roi.TabIndex = 3554;
            this.btnJobColorEx_Roi.Text = "Roi";
            this.btnJobColorEx_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobColorEx_Roi.Click += new System.EventHandler(this.OnClickAlgorithm_ColorEx);
            // 
            // lblJobColorEx_ResultColor
            // 
            this.lblJobColorEx_ResultColor.BackColor = System.Drawing.Color.Transparent;
            this.lblJobColorEx_ResultColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobColorEx_ResultColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblJobColorEx_ResultColor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobColorEx_ResultColor.ForeColor = System.Drawing.Color.Black;
            this.lblJobColorEx_ResultColor.Location = new System.Drawing.Point(80, 239);
            this.lblJobColorEx_ResultColor.Name = "lblJobColorEx_ResultColor";
            this.lblJobColorEx_ResultColor.Size = new System.Drawing.Size(226, 35);
            this.lblJobColorEx_ResultColor.TabIndex = 3553;
            this.lblJobColorEx_ResultColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label130
            // 
            this.label130.BackColor = System.Drawing.Color.Transparent;
            this.label130.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label130.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label130.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.ForeColor = System.Drawing.Color.Black;
            this.label130.Location = new System.Drawing.Point(2, 239);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(77, 35);
            this.label130.TabIndex = 3551;
            this.label130.Text = "Result\r\nColor";
            this.label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label133.Size = new System.Drawing.Size(309, 27);
            this.label133.TabIndex = 3546;
            this.label133.Text = "     Color Extract";
            this.label133.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpPin
            // 
            this.tpPin.BackColor = System.Drawing.Color.White;
            this.tpPin.Controls.Add(this.label8);
            this.tpPin.Controls.Add(this.chkThresholdInv);
            this.tpPin.Controls.Add(this.btnJobPin_Master);
            this.tpPin.Controls.Add(this.panel53);
            this.tpPin.Controls.Add(this.panel47);
            this.tpPin.Controls.Add(this.panel42);
            this.tpPin.Controls.Add(this.btnJobPin_Roi);
            this.tpPin.Controls.Add(this.btnJobPin_Find);
            this.tpPin.Controls.Add(this.panel59);
            this.tpPin.Controls.Add(this.trackbarThreshold);
            this.tpPin.Location = new System.Drawing.Point(91, 0);
            this.tpPin.Name = "tpPin";
            this.tpPin.Size = new System.Drawing.Size(309, 515);
            this.tpPin.TabIndex = 8;
            this.tpPin.Text = "Pin";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Arial", 8F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(2, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 30);
            this.label8.TabIndex = 3533;
            this.label8.Text = "Threshold";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkThresholdInv
            // 
            this.chkThresholdInv.AutoSize = true;
            this.chkThresholdInv.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkThresholdInv.ForeColor = System.Drawing.Color.Black;
            this.chkThresholdInv.Location = new System.Drawing.Point(2, 191);
            this.chkThresholdInv.Name = "chkThresholdInv";
            this.chkThresholdInv.Size = new System.Drawing.Size(97, 19);
            this.chkThresholdInv.TabIndex = 3534;
            this.chkThresholdInv.Text = "ThresholdInv";
            this.chkThresholdInv.UseVisualStyleBackColor = true;
            // 
            // btnJobPin_Master
            // 
            this.btnJobPin_Master.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPin_Master.FillColor = System.Drawing.Color.White;
            this.btnJobPin_Master.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Master.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnJobPin_Master.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Master.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Master.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPin_Master.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Master.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Master.Location = new System.Drawing.Point(12, 465);
            this.btnJobPin_Master.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPin_Master.Name = "btnJobPin_Master";
            this.btnJobPin_Master.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Master.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Master.RectPressColor = System.Drawing.Color.White;
            this.btnJobPin_Master.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPin_Master.Size = new System.Drawing.Size(286, 42);
            this.btnJobPin_Master.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPin_Master.StyleCustomMode = true;
            this.btnJobPin_Master.Symbol = 108;
            this.btnJobPin_Master.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Master.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Master.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPin_Master.SymbolSize = 20;
            this.btnJobPin_Master.TabIndex = 3528;
            this.btnJobPin_Master.Text = "Master";
            this.btnJobPin_Master.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobPin_Master.Click += new System.EventHandler(this.OnClickAlgorithm_Pin);
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
            this.label144.ForeColor = System.Drawing.Color.Black;
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
            this.chk_Pin_BinaryInv.ForeColor = System.Drawing.Color.Black;
            this.chk_Pin_BinaryInv.Location = new System.Drawing.Point(97, 7);
            this.chk_Pin_BinaryInv.Name = "chk_Pin_BinaryInv";
            this.chk_Pin_BinaryInv.Size = new System.Drawing.Size(103, 19);
            this.chk_Pin_BinaryInv.TabIndex = 2772;
            this.chk_Pin_BinaryInv.Text = "Binary Inverter";
            this.chk_Pin_BinaryInv.UseVisualStyleBackColor = true;
            // 
            // nb_Pin_Threshold
            // 
            this.nb_Pin_Threshold.BackColor = System.Drawing.Color.White;
            this.nb_Pin_Threshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_Threshold.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_Threshold.ForeColor = System.Drawing.Color.Black;
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
            this.label142.ForeColor = System.Drawing.Color.Black;
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
            this.nb_Pin_SpecRoi_Height.BackColor = System.Drawing.Color.White;
            this.nb_Pin_SpecRoi_Height.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_SpecRoi_Height.Dock = System.Windows.Forms.DockStyle.Right;
            this.nb_Pin_SpecRoi_Height.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_SpecRoi_Height.ForeColor = System.Drawing.Color.Black;
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
            this.label143.ForeColor = System.Drawing.Color.Black;
            this.label143.Location = new System.Drawing.Point(92, 1);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(21, 29);
            this.label143.TabIndex = 3426;
            this.label143.Text = "/";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nb_Pin_SpecRoi_Width
            // 
            this.nb_Pin_SpecRoi_Width.BackColor = System.Drawing.Color.White;
            this.nb_Pin_SpecRoi_Width.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_SpecRoi_Width.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_SpecRoi_Width.ForeColor = System.Drawing.Color.Black;
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
            this.label139.ForeColor = System.Drawing.Color.Black;
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
            this.nb_Pin_AreaMax.BackColor = System.Drawing.Color.White;
            this.nb_Pin_AreaMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_AreaMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.nb_Pin_AreaMax.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_AreaMax.ForeColor = System.Drawing.Color.Black;
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
            this.label141.ForeColor = System.Drawing.Color.Black;
            this.label141.Location = new System.Drawing.Point(92, 1);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(21, 29);
            this.label141.TabIndex = 3426;
            this.label141.Text = "~";
            this.label141.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nb_Pin_AreaMin
            // 
            this.nb_Pin_AreaMin.BackColor = System.Drawing.Color.White;
            this.nb_Pin_AreaMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_AreaMin.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_AreaMin.ForeColor = System.Drawing.Color.Black;
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
            this.btnJobPin_Roi.FillColor = System.Drawing.Color.White;
            this.btnJobPin_Roi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Roi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnJobPin_Roi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Roi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Roi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPin_Roi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Roi.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Roi.Location = new System.Drawing.Point(12, 418);
            this.btnJobPin_Roi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPin_Roi.Name = "btnJobPin_Roi";
            this.btnJobPin_Roi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Roi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Roi.RectPressColor = System.Drawing.Color.White;
            this.btnJobPin_Roi.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPin_Roi.Size = new System.Drawing.Size(140, 42);
            this.btnJobPin_Roi.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPin_Roi.StyleCustomMode = true;
            this.btnJobPin_Roi.Symbol = 362923;
            this.btnJobPin_Roi.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Roi.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Roi.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPin_Roi.SymbolSize = 16;
            this.btnJobPin_Roi.TabIndex = 3524;
            this.btnJobPin_Roi.Text = "Roi";
            this.btnJobPin_Roi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobPin_Roi.Click += new System.EventHandler(this.OnClickAlgorithm_Pin);
            // 
            // btnJobPin_Find
            // 
            this.btnJobPin_Find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobPin_Find.FillColor = System.Drawing.Color.White;
            this.btnJobPin_Find.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Find.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnJobPin_Find.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Find.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnJobPin_Find.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobPin_Find.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Find.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Find.Location = new System.Drawing.Point(158, 418);
            this.btnJobPin_Find.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJobPin_Find.Name = "btnJobPin_Find";
            this.btnJobPin_Find.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Find.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Find.RectPressColor = System.Drawing.Color.White;
            this.btnJobPin_Find.RectSelectedColor = System.Drawing.Color.White;
            this.btnJobPin_Find.Size = new System.Drawing.Size(140, 42);
            this.btnJobPin_Find.Style = Sunny.UI.UIStyle.Custom;
            this.btnJobPin_Find.StyleCustomMode = true;
            this.btnJobPin_Find.Symbol = 61442;
            this.btnJobPin_Find.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Find.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnJobPin_Find.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.btnJobPin_Find.SymbolSize = 20;
            this.btnJobPin_Find.TabIndex = 3523;
            this.btnJobPin_Find.Text = "Find";
            this.btnJobPin_Find.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobPin_Find.Click += new System.EventHandler(this.OnClickAlgorithm_Pin);
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
            this.label146.ForeColor = System.Drawing.Color.Black;
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
            this.nb_Pin_OkCount.BackColor = System.Drawing.Color.White;
            this.nb_Pin_OkCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nb_Pin_OkCount.Font = new System.Drawing.Font("Arial", 15F);
            this.nb_Pin_OkCount.ForeColor = System.Drawing.Color.Black;
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
            // trackbarThreshold
            // 
            this.trackbarThreshold.ChannelColor = System.Drawing.Color.LightGray;
            this.trackbarThreshold.Customizable = false;
            this.trackbarThreshold.Location = new System.Drawing.Point(78, 155);
            this.trackbarThreshold.Maximum = 255;
            this.trackbarThreshold.Minimum = 1;
            this.trackbarThreshold.Name = "trackbarThreshold";
            this.trackbarThreshold.ShowValue = true;
            this.trackbarThreshold.Size = new System.Drawing.Size(232, 45);
            this.trackbarThreshold.SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(97)))), ((int)(((byte)(212)))));
            this.trackbarThreshold.TabIndex = 3532;
            this.trackbarThreshold.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(160)))), ((int)(((byte)(162)))));
            this.trackbarThreshold.Value = 1;
            this.trackbarThreshold.Scroll += new System.EventHandler(this.trackbarThreshold_Scroll);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 515);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(400, 40);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.BtnApplyCore);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.panel5.Size = new System.Drawing.Size(400, 40);
            this.panel5.TabIndex = 1;
            // 
            // BtnApplyCore
            // 
            this.BtnApplyCore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnApplyCore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnApplyCore.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnApplyCore.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnApplyCore.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnApplyCore.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnApplyCore.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnApplyCore.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyCore.Location = new System.Drawing.Point(0, 0);
            this.BtnApplyCore.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnApplyCore.Name = "BtnApplyCore";
            this.BtnApplyCore.RectColor = System.Drawing.Color.White;
            this.BtnApplyCore.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnApplyCore.RectPressColor = System.Drawing.Color.White;
            this.BtnApplyCore.RectSelectedColor = System.Drawing.Color.White;
            this.BtnApplyCore.Size = new System.Drawing.Size(397, 37);
            this.BtnApplyCore.Style = Sunny.UI.UIStyle.Custom;
            this.BtnApplyCore.StyleCustomMode = true;
            this.BtnApplyCore.Symbol = 61452;
            this.BtnApplyCore.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnApplyCore.SymbolSize = 20;
            this.BtnApplyCore.TabIndex = 3542;
            this.BtnApplyCore.Text = "Apply";
            this.BtnApplyCore.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnApplyCore.Click += new System.EventHandler(this.BtnApplyCore_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbbMethod);
            this.panel7.Controls.Add(this.dgvParameter);
            this.panel7.Location = new System.Drawing.Point(695, 29);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(256, 197);
            this.panel7.TabIndex = 3690;
            // 
            // cbbMethod
            // 
            this.cbbMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbMethod.FormattingEnabled = true;
            this.cbbMethod.Location = new System.Drawing.Point(0, 0);
            this.cbbMethod.Name = "cbbMethod";
            this.cbbMethod.Size = new System.Drawing.Size(256, 25);
            this.cbbMethod.TabIndex = 6;
            this.cbbMethod.SelectedIndexChanged += new System.EventHandler(this.cbbMethod_SelectedIndexChanged);
            // 
            // dgvParameter
            // 
            this.dgvParameter.AllowUserToAddRows = false;
            this.dgvParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParameter.Location = new System.Drawing.Point(0, 0);
            this.dgvParameter.Name = "dgvParameter";
            this.dgvParameter.RowHeadersVisible = false;
            this.dgvParameter.RowHeadersWidth = 62;
            this.dgvParameter.RowTemplate.Height = 23;
            this.dgvParameter.Size = new System.Drawing.Size(256, 197);
            this.dgvParameter.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(552, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 3689;
            this.label4.Text = "Image PreProcessing";
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
            this.uiSymbolButton3.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton3.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.Location = new System.Drawing.Point(643, 32);
            this.uiSymbolButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton3.Name = "uiSymbolButton3";
            this.uiSymbolButton3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.Size = new System.Drawing.Size(49, 24);
            this.uiSymbolButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton3.StyleCustomMode = true;
            this.uiSymbolButton3.Symbol = 61453;
            this.uiSymbolButton3.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton3.SymbolSize = 16;
            this.uiSymbolButton3.TabIndex = 3688;
            this.uiSymbolButton3.Tag = "ZoomIn";
            this.uiSymbolButton3.Text = "Del";
            this.uiSymbolButton3.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton3.Click += new System.EventHandler(this.OnClickPreProcessing);
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
            this.uiSymbolButton8.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton8.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton8.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton8.Location = new System.Drawing.Point(695, 3);
            this.uiSymbolButton8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton8.Name = "uiSymbolButton8";
            this.uiSymbolButton8.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.uiSymbolButton8.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton8.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton8.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton8.Size = new System.Drawing.Size(55, 24);
            this.uiSymbolButton8.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton8.StyleCustomMode = true;
            this.uiSymbolButton8.Symbol = 61543;
            this.uiSymbolButton8.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton8.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton8.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton8.SymbolSize = 16;
            this.uiSymbolButton8.TabIndex = 3687;
            this.uiSymbolButton8.Tag = "ZoomIn";
            this.uiSymbolButton8.Text = "Add";
            this.uiSymbolButton8.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton8.Click += new System.EventHandler(this.OnClickPreProcessing);
            // 
            // DgvProcessingList
            // 
            this.DgvProcessingList.AllowUserToAddRows = false;
            this.DgvProcessingList.AllowUserToDeleteRows = false;
            this.DgvProcessingList.AllowUserToResizeColumns = false;
            this.DgvProcessingList.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow;
            this.DgvProcessingList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvProcessingList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DgvProcessingList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcessingList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvProcessingList.ColumnHeadersHeight = 30;
            this.DgvProcessingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvProcessingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvProcessingList.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvProcessingList.EnableHeadersVisualStyles = false;
            this.DgvProcessingList.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DgvProcessingList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DgvProcessingList.Location = new System.Drawing.Point(551, 29);
            this.DgvProcessingList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvProcessingList.MultiSelect = false;
            this.DgvProcessingList.Name = "DgvProcessingList";
            this.DgvProcessingList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProcessingList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvProcessingList.RowHeadersVisible = false;
            this.DgvProcessingList.RowHeadersWidth = 51;
            this.DgvProcessingList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvProcessingList.RowTemplate.Height = 23;
            this.DgvProcessingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProcessingList.Size = new System.Drawing.Size(143, 197);
            this.DgvProcessingList.TabIndex = 3686;
            this.DgvProcessingList.SelectionChanged += new System.EventHandler(this.DgvProcessingList_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 50F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvLogicList
            // 
            this.DgvLogicList.AllowUserToAddRows = false;
            this.DgvLogicList.AllowUserToDeleteRows = false;
            this.DgvLogicList.AllowUserToResizeColumns = false;
            this.DgvLogicList.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Yellow;
            this.DgvLogicList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvLogicList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DgvLogicList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLogicList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DgvLogicList.ColumnHeadersHeight = 30;
            this.DgvLogicList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvLogicList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewTextBoxColumn8,
            this.Grab,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvLogicList.DefaultCellStyle = dataGridViewCellStyle12;
            this.DgvLogicList.EnableHeadersVisualStyles = false;
            this.DgvLogicList.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DgvLogicList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DgvLogicList.Location = new System.Drawing.Point(283, 264);
            this.DgvLogicList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvLogicList.MultiSelect = false;
            this.DgvLogicList.Name = "DgvLogicList";
            this.DgvLogicList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLogicList.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DgvLogicList.RowHeadersVisible = false;
            this.DgvLogicList.RowHeadersWidth = 51;
            this.DgvLogicList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvLogicList.RowTemplate.Height = 23;
            this.DgvLogicList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLogicList.Size = new System.Drawing.Size(263, 487);
            this.DgvLogicList.TabIndex = 3682;
            this.DgvLogicList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLogicList_CellContentClick);
            this.DgvLogicList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLogicList_CellValueChanged);
            this.DgvLogicList.SelectionChanged += new System.EventHandler(this.DgvLogicList_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "No";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 25;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.HeaderText = "Enabled";
            this.dataGridViewCheckBoxColumn3.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn3.Width = 45;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 50F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Name";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // Grab
            // 
            this.Grab.HeaderText = "Grab Index";
            this.Grab.Name = "Grab";
            this.Grab.ReadOnly = true;
            this.Grab.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Grab.Width = 40;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "Algorithm";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "N/A";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.Width = 50;
            // 
            // btnUpLoadPartLibrary
            // 
            this.btnUpLoadPartLibrary.BackColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.CircleRectWidth = 0;
            this.btnUpLoadPartLibrary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpLoadPartLibrary.FillColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.FillColor2 = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.FillPressColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.Font = new System.Drawing.Font("Arial", 8F);
            this.btnUpLoadPartLibrary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadPartLibrary.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadPartLibrary.ForePressColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpLoadPartLibrary.Location = new System.Drawing.Point(283, 755);
            this.btnUpLoadPartLibrary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpLoadPartLibrary.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnUpLoadPartLibrary.Name = "btnUpLoadPartLibrary";
            this.btnUpLoadPartLibrary.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUpLoadPartLibrary.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadPartLibrary.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadPartLibrary.RectPressColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnUpLoadPartLibrary.Size = new System.Drawing.Size(75, 25);
            this.btnUpLoadPartLibrary.Style = Sunny.UI.UIStyle.Custom;
            this.btnUpLoadPartLibrary.StyleCustomMode = true;
            this.btnUpLoadPartLibrary.Symbol = 57489;
            this.btnUpLoadPartLibrary.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadPartLibrary.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpLoadPartLibrary.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnUpLoadPartLibrary.SymbolSize = 18;
            this.btnUpLoadPartLibrary.TabIndex = 3680;
            this.btnUpLoadPartLibrary.Tag = "ZoomIn";
            this.btnUpLoadPartLibrary.Text = "UpLoad";
            this.btnUpLoadPartLibrary.TipsFont = new System.Drawing.Font("Microsoft YaHei", 7F);
            this.btnUpLoadPartLibrary.Click += new System.EventHandler(this.btnUpLoadPartLibrary_Click);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(286, 236);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 20);
            this.label24.TabIndex = 3678;
            this.label24.Text = "Logics";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnLogicDelete
            // 
            this.BtnLogicDelete.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.CircleRectWidth = 0;
            this.BtnLogicDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogicDelete.FillColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnLogicDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicDelete.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicDelete.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogicDelete.Location = new System.Drawing.Point(491, 234);
            this.BtnLogicDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnLogicDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnLogicDelete.Name = "BtnLogicDelete";
            this.BtnLogicDelete.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnLogicDelete.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicDelete.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicDelete.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnLogicDelete.Size = new System.Drawing.Size(55, 24);
            this.BtnLogicDelete.Style = Sunny.UI.UIStyle.Custom;
            this.BtnLogicDelete.StyleCustomMode = true;
            this.BtnLogicDelete.Symbol = 61453;
            this.BtnLogicDelete.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicDelete.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicDelete.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnLogicDelete.SymbolSize = 16;
            this.BtnLogicDelete.TabIndex = 3675;
            this.BtnLogicDelete.Tag = "ZoomIn";
            this.BtnLogicDelete.Text = "Del";
            this.BtnLogicDelete.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnLogicDelete.Click += new System.EventHandler(this.BtnLogicDelete_Click);
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
            this.BtnLogicAdd.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicAdd.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogicAdd.Location = new System.Drawing.Point(435, 234);
            this.BtnLogicAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnLogicAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnLogicAdd.Name = "BtnLogicAdd";
            this.BtnLogicAdd.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnLogicAdd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicAdd.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicAdd.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnLogicAdd.Size = new System.Drawing.Size(55, 24);
            this.BtnLogicAdd.Style = Sunny.UI.UIStyle.Custom;
            this.BtnLogicAdd.StyleCustomMode = true;
            this.BtnLogicAdd.Symbol = 61543;
            this.BtnLogicAdd.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnLogicAdd.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
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
            this.uiLine25.Location = new System.Drawing.Point(285, 223);
            this.uiLine25.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine25.Name = "uiLine25";
            this.uiLine25.Size = new System.Drawing.Size(266, 10);
            this.uiLine25.TabIndex = 3673;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Arial", 8F);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(291, 170);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 25);
            this.label20.TabIndex = 3668;
            this.label20.Text = "Grab Index";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnNA_ng
            // 
            this.BtnNA_ng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNA_ng.FillColor = System.Drawing.Color.DimGray;
            this.BtnNA_ng.FillSelectedColor = System.Drawing.Color.Green;
            this.BtnNA_ng.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnNA_ng.Location = new System.Drawing.Point(374, 198);
            this.BtnNA_ng.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnNA_ng.Name = "BtnNA_ng";
            this.BtnNA_ng.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnNA_ng.Selected = true;
            this.BtnNA_ng.Size = new System.Drawing.Size(61, 25);
            this.BtnNA_ng.TabIndex = 3663;
            this.BtnNA_ng.Tag = "Setting";
            this.BtnNA_ng.Text = "N/A = NG";
            this.BtnNA_ng.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnNA_ng.Click += new System.EventHandler(this.OnclickSelectJudge);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Arial", 8F);
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(291, 198);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 25);
            this.label23.TabIndex = 3662;
            this.label23.Text = "Judge Type";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnNA_ok
            // 
            this.BtnNA_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNA_ok.FillColor = System.Drawing.Color.DimGray;
            this.BtnNA_ok.FillSelectedColor = System.Drawing.Color.Red;
            this.BtnNA_ok.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnNA_ok.Location = new System.Drawing.Point(438, 198);
            this.BtnNA_ok.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnNA_ok.Name = "BtnNA_ok";
            this.BtnNA_ok.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnNA_ok.Size = new System.Drawing.Size(61, 25);
            this.BtnNA_ok.TabIndex = 3664;
            this.BtnNA_ok.Tag = "Setting";
            this.BtnNA_ok.Text = "N/A = OK";
            this.BtnNA_ok.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnNA_ok.Click += new System.EventHandler(this.OnclickSelectJudge);
            // 
            // cbGrabIndex
            // 
            this.cbGrabIndex.DataSource = null;
            this.cbGrabIndex.FillColor = System.Drawing.SystemColors.Control;
            this.cbGrabIndex.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cbGrabIndex.ForeColor = System.Drawing.Color.Black;
            this.cbGrabIndex.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbGrabIndex.ItemForeColor = System.Drawing.Color.White;
            this.cbGrabIndex.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.cbGrabIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cbGrabIndex.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.cbGrabIndex.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbGrabIndex.Location = new System.Drawing.Point(374, 169);
            this.cbGrabIndex.Margin = new System.Windows.Forms.Padding(0);
            this.cbGrabIndex.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbGrabIndex.Name = "cbGrabIndex";
            this.cbGrabIndex.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbGrabIndex.RectColor = System.Drawing.Color.DimGray;
            this.cbGrabIndex.Size = new System.Drawing.Size(63, 25);
            this.cbGrabIndex.SymbolSize = 24;
            this.cbGrabIndex.TabIndex = 3669;
            this.cbGrabIndex.Text = "0";
            this.cbGrabIndex.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGrabIndex.Watermark = "";
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
            this.BtnSettingLogic.Location = new System.Drawing.Point(501, 111);
            this.BtnSettingLogic.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnSettingLogic.Name = "BtnSettingLogic";
            this.BtnSettingLogic.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingLogic.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingLogic.RectPressColor = System.Drawing.Color.White;
            this.BtnSettingLogic.RectSelectedColor = System.Drawing.Color.White;
            this.BtnSettingLogic.Size = new System.Drawing.Size(45, 112);
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
            this.label18.Location = new System.Drawing.Point(291, 139);
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
            this.tbLogicName.Location = new System.Drawing.Point(374, 111);
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
            this.label19.Location = new System.Drawing.Point(291, 111);
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
            this.label16.Location = new System.Drawing.Point(286, 91);
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
            this.label15.Location = new System.Drawing.Point(286, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(260, 20);
            this.label15.TabIndex = 3652;
            this.label15.Text = "Selected Job : ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnSettingJob
            // 
            this.BtnSettingJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSettingJob.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingJob.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnSettingJob.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingJob.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnSettingJob.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnSettingJob.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSettingJob.Location = new System.Drawing.Point(501, 25);
            this.BtnSettingJob.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnSettingJob.Name = "BtnSettingJob";
            this.BtnSettingJob.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingJob.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnSettingJob.RectPressColor = System.Drawing.Color.White;
            this.BtnSettingJob.RectSelectedColor = System.Drawing.Color.White;
            this.BtnSettingJob.Size = new System.Drawing.Size(45, 53);
            this.BtnSettingJob.Style = Sunny.UI.UIStyle.Custom;
            this.BtnSettingJob.StyleCustomMode = true;
            this.BtnSettingJob.SymbolSize = 16;
            this.BtnSettingJob.TabIndex = 3651;
            this.BtnSettingJob.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSettingJob.Click += new System.EventHandler(this.BtnSettingJob_Click);
            // 
            // uiLine21
            // 
            this.uiLine21.BackColor = System.Drawing.Color.Transparent;
            this.uiLine21.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine21.LineColor = System.Drawing.Color.Black;
            this.uiLine21.Location = new System.Drawing.Point(285, 84);
            this.uiLine21.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine21.Name = "uiLine21";
            this.uiLine21.Size = new System.Drawing.Size(266, 10);
            this.uiLine21.TabIndex = 3650;
            // 
            // TbPartName
            // 
            this.TbPartName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbPartName.FillColor = System.Drawing.SystemColors.Control;
            this.TbPartName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName.ForeColor = System.Drawing.Color.Black;
            this.TbPartName.Location = new System.Drawing.Point(374, 53);
            this.TbPartName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbPartName.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbPartName.Name = "TbPartName";
            this.TbPartName.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbPartName.RectColor = System.Drawing.Color.DimGray;
            this.TbPartName.ShowText = false;
            this.TbPartName.Size = new System.Drawing.Size(125, 25);
            this.TbPartName.TabIndex = 3649;
            this.TbPartName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbPartName.Watermark = "";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Arial", 8F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(291, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 25);
            this.label14.TabIndex = 3648;
            this.label14.Text = "Part Name";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TbLocationNo
            // 
            this.TbLocationNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbLocationNo.FillColor = System.Drawing.SystemColors.Control;
            this.TbLocationNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbLocationNo.ForeColor = System.Drawing.Color.Black;
            this.TbLocationNo.Location = new System.Drawing.Point(374, 25);
            this.TbLocationNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TbLocationNo.MinimumSize = new System.Drawing.Size(1, 20);
            this.TbLocationNo.Name = "TbLocationNo";
            this.TbLocationNo.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TbLocationNo.RectColor = System.Drawing.Color.DimGray;
            this.TbLocationNo.ShowText = false;
            this.TbLocationNo.Size = new System.Drawing.Size(125, 25);
            this.TbLocationNo.TabIndex = 3647;
            this.TbLocationNo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TbLocationNo.Watermark = "";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Arial", 8F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(291, 25);
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
            // CbJobAll
            // 
            this.CbJobAll.AutoSize = true;
            this.CbJobAll.BackColor = System.Drawing.Color.Transparent;
            this.CbJobAll.Font = new System.Drawing.Font("Arial", 8F);
            this.CbJobAll.ForeColor = System.Drawing.Color.Black;
            this.CbJobAll.Location = new System.Drawing.Point(186, 8);
            this.CbJobAll.Name = "CbJobAll";
            this.CbJobAll.Size = new System.Drawing.Size(38, 18);
            this.CbJobAll.TabIndex = 3643;
            this.CbJobAll.Text = "All";
            this.CbJobAll.UseVisualStyleBackColor = false;
            // 
            // BtnJobListCopy
            // 
            this.BtnJobListCopy.BackColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.CircleRectWidth = 0;
            this.BtnJobListCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnJobListCopy.FillColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnJobListCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobListCopy.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobListCopy.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnJobListCopy.Location = new System.Drawing.Point(224, 3);
            this.BtnJobListCopy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnJobListCopy.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnJobListCopy.Name = "BtnJobListCopy";
            this.BtnJobListCopy.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnJobListCopy.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobListCopy.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobListCopy.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobListCopy.Size = new System.Drawing.Size(55, 24);
            this.BtnJobListCopy.Style = Sunny.UI.UIStyle.Custom;
            this.BtnJobListCopy.StyleCustomMode = true;
            this.BtnJobListCopy.Symbol = 62029;
            this.BtnJobListCopy.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobListCopy.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobListCopy.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnJobListCopy.SymbolSize = 16;
            this.BtnJobListCopy.TabIndex = 3642;
            this.BtnJobListCopy.Tag = "ZoomIn";
            this.BtnJobListCopy.Text = "Copy";
            this.BtnJobListCopy.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJobListCopy.Click += new System.EventHandler(this.BtnJobListCopy_Click);
            // 
            // BtnJobDelete
            // 
            this.BtnJobDelete.BackColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.CircleRectWidth = 0;
            this.BtnJobDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnJobDelete.FillColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnJobDelete.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnJobDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDelete.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDelete.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnJobDelete.Location = new System.Drawing.Point(123, 3);
            this.BtnJobDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnJobDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnJobDelete.Name = "BtnJobDelete";
            this.BtnJobDelete.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnJobDelete.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDelete.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDelete.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobDelete.Size = new System.Drawing.Size(55, 24);
            this.BtnJobDelete.Style = Sunny.UI.UIStyle.Custom;
            this.BtnJobDelete.StyleCustomMode = true;
            this.BtnJobDelete.Symbol = 61453;
            this.BtnJobDelete.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDelete.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobDelete.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnJobDelete.SymbolSize = 16;
            this.BtnJobDelete.TabIndex = 3641;
            this.BtnJobDelete.Tag = "ZoomIn";
            this.BtnJobDelete.Text = "Del";
            this.BtnJobDelete.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJobDelete.Click += new System.EventHandler(this.BtnJobDelete_Click);
            // 
            // DgvJobList
            // 
            this.DgvJobList.AllowUserToAddRows = false;
            this.DgvJobList.AllowUserToDeleteRows = false;
            this.DgvJobList.AllowUserToResizeColumns = false;
            this.DgvJobList.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Yellow;
            this.DgvJobList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.DgvJobList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DgvJobList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvJobList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DgvJobList.ColumnHeadersHeight = 30;
            this.DgvJobList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvJobList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.gridLibraryName,
            this.gridLibraryEnabled,
            this.Column3,
            this.Colum3});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvJobList.DefaultCellStyle = dataGridViewCellStyle16;
            this.DgvJobList.EnableHeadersVisualStyles = false;
            this.DgvJobList.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DgvJobList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DgvJobList.Location = new System.Drawing.Point(1, 29);
            this.DgvJobList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvJobList.MultiSelect = false;
            this.DgvJobList.Name = "DgvJobList";
            this.DgvJobList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvJobList.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.DgvJobList.RowHeadersVisible = false;
            this.DgvJobList.RowHeadersWidth = 51;
            this.DgvJobList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvJobList.RowTemplate.Height = 23;
            this.DgvJobList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvJobList.Size = new System.Drawing.Size(278, 722);
            this.DgvJobList.TabIndex = 3639;
            this.DgvJobList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJobList_CellContentClick);
            this.DgvJobList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJobList_CellValueChanged);
            this.DgvJobList.SelectionChanged += new System.EventHandler(this.DgvJobList_SelectionChanged);
            // 
            // No
            // 
            this.No.HeaderText = "Location No";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.Width = 90;
            // 
            // gridLibraryName
            // 
            this.gridLibraryName.HeaderText = "Enabled";
            this.gridLibraryName.MinimumWidth = 6;
            this.gridLibraryName.Name = "gridLibraryName";
            this.gridLibraryName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLibraryName.Width = 45;
            // 
            // gridLibraryEnabled
            // 
            this.gridLibraryEnabled.HeaderText = "Part Code";
            this.gridLibraryEnabled.MinimumWidth = 6;
            this.gridLibraryEnabled.Name = "gridLibraryEnabled";
            this.gridLibraryEnabled.ReadOnly = true;
            this.gridLibraryEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLibraryEnabled.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Logic Count";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 40;
            // 
            // Colum3
            // 
            this.Colum3.HeaderText = "Angle";
            this.Colum3.Name = "Colum3";
            this.Colum3.ReadOnly = true;
            this.Colum3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Colum3.Width = 40;
            // 
            // BtnJobAdd
            // 
            this.BtnJobAdd.BackColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.CircleRectWidth = 0;
            this.BtnJobAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnJobAdd.FillColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnJobAdd.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.Font = new System.Drawing.Font("Arial", 8F);
            this.BtnJobAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobAdd.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobAdd.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnJobAdd.Location = new System.Drawing.Point(67, 3);
            this.BtnJobAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnJobAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnJobAdd.Name = "BtnJobAdd";
            this.BtnJobAdd.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnJobAdd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobAdd.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobAdd.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnJobAdd.Size = new System.Drawing.Size(55, 24);
            this.BtnJobAdd.Style = Sunny.UI.UIStyle.Custom;
            this.BtnJobAdd.StyleCustomMode = true;
            this.BtnJobAdd.Symbol = 61543;
            this.BtnJobAdd.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobAdd.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnJobAdd.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.BtnJobAdd.SymbolSize = 16;
            this.BtnJobAdd.TabIndex = 3626;
            this.BtnJobAdd.Tag = "ZoomIn";
            this.BtnJobAdd.Text = "Add";
            this.BtnJobAdd.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJobAdd.Click += new System.EventHandler(this.BtnJobAdd_Click);
            // 
            // cbAlgorithm
            // 
            this.cbAlgorithm.DataSource = null;
            this.cbAlgorithm.FillColor = System.Drawing.SystemColors.Control;
            this.cbAlgorithm.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cbAlgorithm.ForeColor = System.Drawing.Color.Black;
            this.cbAlgorithm.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbAlgorithm.ItemForeColor = System.Drawing.Color.White;
            this.cbAlgorithm.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.cbAlgorithm.Items.AddRange(new object[] {
            "Pattern",
            "EYE-D",
            "Condensor",
            "ColorEx",
            "Pin"});
            this.cbAlgorithm.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.cbAlgorithm.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbAlgorithm.Location = new System.Drawing.Point(374, 139);
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
            this.tabPage15.Controls.Add(this.DgvRecentImages);
            this.tabPage15.Location = new System.Drawing.Point(0, 40);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Size = new System.Drawing.Size(200, 60);
            this.tabPage15.TabIndex = 3;
            this.tabPage15.Text = "04. RECENT";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // DgvRecentImages
            // 
            this.DgvRecentImages.AllowUserToAddRows = false;
            this.DgvRecentImages.AllowUserToDeleteRows = false;
            this.DgvRecentImages.AllowUserToResizeColumns = false;
            this.DgvRecentImages.AllowUserToResizeRows = false;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            this.DgvRecentImages.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle18;
            this.DgvRecentImages.BackgroundColor = System.Drawing.Color.Silver;
            this.DgvRecentImages.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRecentImages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.DgvRecentImages.ColumnHeadersHeight = 20;
            this.DgvRecentImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvRecentImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvRecentImages.DefaultCellStyle = dataGridViewCellStyle20;
            this.DgvRecentImages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvRecentImages.EnableHeadersVisualStyles = false;
            this.DgvRecentImages.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DgvRecentImages.GridColor = System.Drawing.Color.Silver;
            this.DgvRecentImages.Location = new System.Drawing.Point(3, 3);
            this.DgvRecentImages.MultiSelect = false;
            this.DgvRecentImages.Name = "DgvRecentImages";
            this.DgvRecentImages.ReadOnly = true;
            this.DgvRecentImages.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRecentImages.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.DgvRecentImages.RowHeadersVisible = false;
            this.DgvRecentImages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White;
            this.DgvRecentImages.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.DgvRecentImages.RowTemplate.Height = 25;
            this.DgvRecentImages.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvRecentImages.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.DgvRecentImages.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.DgvRecentImages.ScrollBarStyleInherited = false;
            this.DgvRecentImages.SelectedIndex = -1;
            this.DgvRecentImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRecentImages.Size = new System.Drawing.Size(631, 772);
            this.DgvRecentImages.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DgvRecentImages.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DgvRecentImages.TabIndex = 3535;
            this.DgvRecentImages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRecentImages_CellDoubleClick);
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
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.uiTableLayoutPanel1);
            this.tabPage4.Location = new System.Drawing.Point(0, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(200, 60);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "00.SET-UP";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 1;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiGroupBox6, 0, 0);
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 1;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(954, 783);
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiGroupBox6
            // 
            this.uiGroupBox6.Controls.Add(this.tableLayoutPanel4);
            this.uiGroupBox6.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox6.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox6.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox6.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox6.Name = "uiGroupBox6";
            this.uiGroupBox6.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox6.Radius = 10;
            this.uiGroupBox6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiGroupBox6.Size = new System.Drawing.Size(946, 773);
            this.uiGroupBox6.TabIndex = 3614;
            this.uiGroupBox6.Text = "Array Region";
            this.uiGroupBox6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.uiTableLayoutPanel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.uiTableLayoutPanel3, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 32);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(946, 741);
            this.tableLayoutPanel4.TabIndex = 3628;
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 4;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.Controls.Add(this.DisplayDataMatrix, 1, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.DisplayArray, 1, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLine14, 0, 1);
            this.uiTableLayoutPanel2.Controls.Add(this.uiTableLayoutPanel6, 3, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.label70, 0, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.label69, 0, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.uiTableLayoutPanel5, 2, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.uiTableLayoutPanel4, 2, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.uiTableLayoutPanel7, 3, 0);
            this.uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 3;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(940, 344);
            this.uiTableLayoutPanel2.TabIndex = 3627;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // DisplayDataMatrix
            // 
            this.DisplayDataMatrix.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.DisplayDataMatrix.ColorMapLowerRoiLimit = 0D;
            this.DisplayDataMatrix.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.DisplayDataMatrix.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.DisplayDataMatrix.ColorMapUpperRoiLimit = 1D;
            this.DisplayDataMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayDataMatrix.DoubleTapZoomCycleLength = 2;
            this.DisplayDataMatrix.DoubleTapZoomSensitivity = 2.5D;
            this.DisplayDataMatrix.Location = new System.Drawing.Point(238, 180);
            this.DisplayDataMatrix.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayDataMatrix.MouseWheelSensitivity = 1D;
            this.DisplayDataMatrix.Name = "DisplayDataMatrix";
            this.DisplayDataMatrix.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayDataMatrix.OcxState")));
            this.DisplayDataMatrix.Size = new System.Drawing.Size(229, 161);
            this.DisplayDataMatrix.TabIndex = 3631;
            this.DisplayDataMatrix.TabStop = false;
            this.DisplayDataMatrix.Tag = "2";
            // 
            // DisplayArray
            // 
            this.DisplayArray.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.DisplayArray.ColorMapLowerRoiLimit = 0D;
            this.DisplayArray.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.DisplayArray.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.DisplayArray.ColorMapUpperRoiLimit = 1D;
            this.DisplayArray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayArray.DoubleTapZoomCycleLength = 2;
            this.DisplayArray.DoubleTapZoomSensitivity = 2.5D;
            this.DisplayArray.Location = new System.Drawing.Point(238, 3);
            this.DisplayArray.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.DisplayArray.MouseWheelSensitivity = 1D;
            this.DisplayArray.Name = "DisplayArray";
            this.DisplayArray.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DisplayArray.OcxState")));
            this.DisplayArray.Size = new System.Drawing.Size(229, 161);
            this.DisplayArray.TabIndex = 3630;
            this.DisplayArray.TabStop = false;
            this.DisplayArray.Tag = "2";
            // 
            // uiLine14
            // 
            this.uiLine14.BackColor = System.Drawing.Color.Transparent;
            this.uiTableLayoutPanel2.SetColumnSpan(this.uiLine14, 4);
            this.uiLine14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine14.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine14.LineColor = System.Drawing.Color.Black;
            this.uiLine14.Location = new System.Drawing.Point(3, 170);
            this.uiLine14.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine14.Name = "uiLine14";
            this.uiLine14.Size = new System.Drawing.Size(934, 4);
            this.uiLine14.TabIndex = 3628;
            // 
            // uiTableLayoutPanel6
            // 
            this.uiTableLayoutPanel6.ColumnCount = 1;
            this.uiTableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel6.Controls.Add(this.BtnDataMatrixRoiRead, 0, 0);
            this.uiTableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel6.Location = new System.Drawing.Point(708, 180);
            this.uiTableLayoutPanel6.Name = "uiTableLayoutPanel6";
            this.uiTableLayoutPanel6.RowCount = 2;
            this.uiTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel6.Size = new System.Drawing.Size(229, 161);
            this.uiTableLayoutPanel6.TabIndex = 3628;
            this.uiTableLayoutPanel6.TagString = null;
            // 
            // BtnDataMatrixRoiRead
            // 
            this.BtnDataMatrixRoiRead.BackColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.CircleRectWidth = 0;
            this.BtnDataMatrixRoiRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDataMatrixRoiRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDataMatrixRoiRead.FillColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDataMatrixRoiRead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiRead.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiRead.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDataMatrixRoiRead.Location = new System.Drawing.Point(4, 3);
            this.BtnDataMatrixRoiRead.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnDataMatrixRoiRead.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnDataMatrixRoiRead.Name = "BtnDataMatrixRoiRead";
            this.BtnDataMatrixRoiRead.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnDataMatrixRoiRead.Radius = 1;
            this.BtnDataMatrixRoiRead.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiRead.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiRead.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiRead.Size = new System.Drawing.Size(221, 74);
            this.BtnDataMatrixRoiRead.Style = Sunny.UI.UIStyle.Custom;
            this.BtnDataMatrixRoiRead.StyleCustomMode = true;
            this.BtnDataMatrixRoiRead.Symbol = 61442;
            this.BtnDataMatrixRoiRead.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiRead.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiRead.SymbolSize = 37;
            this.BtnDataMatrixRoiRead.TabIndex = 3625;
            this.BtnDataMatrixRoiRead.Tag = "ZoomIn";
            this.BtnDataMatrixRoiRead.Text = "Read";
            this.BtnDataMatrixRoiRead.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnDataMatrixRoiRead.Click += new System.EventHandler(this.OnClickArrayDMCode);
            // 
            // label70
            // 
            this.label70.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label70.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(3, 58);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(229, 51);
            this.label70.TabIndex = 3590;
            this.label70.Text = "Array Index";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label69
            // 
            this.label69.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label69.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.Black;
            this.label69.Location = new System.Drawing.Point(3, 238);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(229, 45);
            this.label69.TabIndex = 3620;
            this.label69.Text = "Data Matrix Code";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel5
            // 
            this.uiTableLayoutPanel5.ColumnCount = 1;
            this.uiTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel5.Controls.Add(this.BtnDataMatrixRoi, 0, 0);
            this.uiTableLayoutPanel5.Controls.Add(this.BtnDataMatrixRoiSet, 0, 1);
            this.uiTableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel5.Location = new System.Drawing.Point(473, 180);
            this.uiTableLayoutPanel5.Name = "uiTableLayoutPanel5";
            this.uiTableLayoutPanel5.RowCount = 2;
            this.uiTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel5.Size = new System.Drawing.Size(229, 161);
            this.uiTableLayoutPanel5.TabIndex = 3627;
            this.uiTableLayoutPanel5.TagString = null;
            // 
            // BtnDataMatrixRoi
            // 
            this.BtnDataMatrixRoi.BackColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.CircleRectWidth = 0;
            this.BtnDataMatrixRoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDataMatrixRoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDataMatrixRoi.FillColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDataMatrixRoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoi.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoi.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDataMatrixRoi.Location = new System.Drawing.Point(4, 3);
            this.BtnDataMatrixRoi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnDataMatrixRoi.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnDataMatrixRoi.Name = "BtnDataMatrixRoi";
            this.BtnDataMatrixRoi.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnDataMatrixRoi.Radius = 1;
            this.BtnDataMatrixRoi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoi.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoi.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoi.Size = new System.Drawing.Size(221, 74);
            this.BtnDataMatrixRoi.Style = Sunny.UI.UIStyle.Custom;
            this.BtnDataMatrixRoi.StyleCustomMode = true;
            this.BtnDataMatrixRoi.Symbol = 62024;
            this.BtnDataMatrixRoi.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoi.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoi.SymbolSize = 37;
            this.BtnDataMatrixRoi.TabIndex = 3597;
            this.BtnDataMatrixRoi.Tag = "ZoomIn";
            this.BtnDataMatrixRoi.Text = "ROI";
            this.BtnDataMatrixRoi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnDataMatrixRoi.Click += new System.EventHandler(this.OnClickArrayDMCode);
            // 
            // BtnDataMatrixRoiSet
            // 
            this.BtnDataMatrixRoiSet.BackColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.CircleRectWidth = 0;
            this.BtnDataMatrixRoiSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDataMatrixRoiSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDataMatrixRoiSet.FillColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDataMatrixRoiSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiSet.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiSet.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDataMatrixRoiSet.Location = new System.Drawing.Point(4, 83);
            this.BtnDataMatrixRoiSet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnDataMatrixRoiSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnDataMatrixRoiSet.Name = "BtnDataMatrixRoiSet";
            this.BtnDataMatrixRoiSet.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnDataMatrixRoiSet.Radius = 1;
            this.BtnDataMatrixRoiSet.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiSet.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiSet.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnDataMatrixRoiSet.Size = new System.Drawing.Size(221, 75);
            this.BtnDataMatrixRoiSet.Style = Sunny.UI.UIStyle.Custom;
            this.BtnDataMatrixRoiSet.StyleCustomMode = true;
            this.BtnDataMatrixRoiSet.Symbol = 361773;
            this.BtnDataMatrixRoiSet.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiSet.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnDataMatrixRoiSet.SymbolSize = 37;
            this.BtnDataMatrixRoiSet.TabIndex = 3598;
            this.BtnDataMatrixRoiSet.Tag = "ZoomIn";
            this.BtnDataMatrixRoiSet.Text = "SET";
            this.BtnDataMatrixRoiSet.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnDataMatrixRoiSet.Click += new System.EventHandler(this.OnClickArrayDMCode);
            // 
            // uiTableLayoutPanel4
            // 
            this.uiTableLayoutPanel4.ColumnCount = 1;
            this.uiTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel4.Controls.Add(this.BtnArrayRoi, 0, 1);
            this.uiTableLayoutPanel4.Controls.Add(this.comboArrayNumber, 0, 0);
            this.uiTableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel4.Location = new System.Drawing.Point(473, 3);
            this.uiTableLayoutPanel4.Name = "uiTableLayoutPanel4";
            this.uiTableLayoutPanel4.RowCount = 2;
            this.uiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel4.Size = new System.Drawing.Size(229, 161);
            this.uiTableLayoutPanel4.TabIndex = 3626;
            this.uiTableLayoutPanel4.TagString = null;
            // 
            // BtnArrayRoi
            // 
            this.BtnArrayRoi.BackColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.CircleRectWidth = 0;
            this.BtnArrayRoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnArrayRoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnArrayRoi.FillColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnArrayRoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArrayRoi.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArrayRoi.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnArrayRoi.Location = new System.Drawing.Point(4, 83);
            this.BtnArrayRoi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnArrayRoi.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnArrayRoi.Name = "BtnArrayRoi";
            this.BtnArrayRoi.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnArrayRoi.Radius = 1;
            this.BtnArrayRoi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArrayRoi.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArrayRoi.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnArrayRoi.Size = new System.Drawing.Size(221, 75);
            this.BtnArrayRoi.Style = Sunny.UI.UIStyle.Custom;
            this.BtnArrayRoi.StyleCustomMode = true;
            this.BtnArrayRoi.Symbol = 62024;
            this.BtnArrayRoi.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArrayRoi.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArrayRoi.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnArrayRoi.SymbolSize = 37;
            this.BtnArrayRoi.TabIndex = 3621;
            this.BtnArrayRoi.Tag = "ZoomIn";
            this.BtnArrayRoi.Text = "ROI";
            this.BtnArrayRoi.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnArrayRoi.Click += new System.EventHandler(this.BtnArrayRoi_Click);
            // 
            // comboArrayNumber
            // 
            this.comboArrayNumber.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.comboArrayNumber.DataSource = null;
            this.comboArrayNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboArrayNumber.FillColor = System.Drawing.Color.White;
            this.comboArrayNumber.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.comboArrayNumber.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.comboArrayNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboArrayNumber.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboArrayNumber.Location = new System.Drawing.Point(4, 5);
            this.comboArrayNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboArrayNumber.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboArrayNumber.Name = "comboArrayNumber";
            this.comboArrayNumber.Padding = new System.Windows.Forms.Padding(100, 0, 30, 2);
            this.comboArrayNumber.Radius = 1;
            this.comboArrayNumber.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboArrayNumber.Size = new System.Drawing.Size(221, 70);
            this.comboArrayNumber.SymbolSize = 24;
            this.comboArrayNumber.TabIndex = 3618;
            this.comboArrayNumber.Text = "1";
            this.comboArrayNumber.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboArrayNumber.Watermark = "";
            this.comboArrayNumber.SelectedIndexChanged += new System.EventHandler(this.comboArrayNumberSelectedIndexChanged);
            // 
            // uiTableLayoutPanel7
            // 
            this.uiTableLayoutPanel7.ColumnCount = 1;
            this.uiTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel7.Controls.Add(this.BtnArraySet, 0, 0);
            this.uiTableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel7.Location = new System.Drawing.Point(708, 3);
            this.uiTableLayoutPanel7.Name = "uiTableLayoutPanel7";
            this.uiTableLayoutPanel7.RowCount = 2;
            this.uiTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel7.Size = new System.Drawing.Size(229, 161);
            this.uiTableLayoutPanel7.TabIndex = 3629;
            this.uiTableLayoutPanel7.TagString = null;
            // 
            // BtnArraySet
            // 
            this.BtnArraySet.BackColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.CircleRectWidth = 0;
            this.BtnArraySet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnArraySet.FillColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnArraySet.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnArraySet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArraySet.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArraySet.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnArraySet.Location = new System.Drawing.Point(4, 3);
            this.BtnArraySet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnArraySet.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnArraySet.Name = "BtnArraySet";
            this.BtnArraySet.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnArraySet.Radius = 1;
            this.BtnArraySet.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArraySet.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArraySet.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnArraySet.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiTableLayoutPanel7.SetRowSpan(this.BtnArraySet, 2);
            this.BtnArraySet.Size = new System.Drawing.Size(221, 72);
            this.BtnArraySet.Style = Sunny.UI.UIStyle.Custom;
            this.BtnArraySet.StyleCustomMode = true;
            this.BtnArraySet.Symbol = 361773;
            this.BtnArraySet.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArraySet.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnArraySet.SymbolSize = 37;
            this.BtnArraySet.TabIndex = 3622;
            this.BtnArraySet.Tag = "ZoomIn";
            this.BtnArraySet.Text = "SET";
            this.BtnArraySet.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnArraySet.Click += new System.EventHandler(this.BtnArraySetClick);
            // 
            // uiTableLayoutPanel3
            // 
            this.uiTableLayoutPanel3.ColumnCount = 1;
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel3.Controls.Add(this.LblDataMatrixData, 0, 0);
            this.uiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel3.Location = new System.Drawing.Point(3, 353);
            this.uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            this.uiTableLayoutPanel3.RowCount = 2;
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.Size = new System.Drawing.Size(940, 94);
            this.uiTableLayoutPanel3.TabIndex = 3615;
            this.uiTableLayoutPanel3.TagString = null;
            // 
            // LblDataMatrixData
            // 
            this.LblDataMatrixData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblDataMatrixData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDataMatrixData.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDataMatrixData.ForeColor = System.Drawing.Color.Black;
            this.LblDataMatrixData.Location = new System.Drawing.Point(3, 0);
            this.LblDataMatrixData.Name = "LblDataMatrixData";
            this.LblDataMatrixData.Size = new System.Drawing.Size(934, 47);
            this.LblDataMatrixData.TabIndex = 3626;
            this.LblDataMatrixData.Text = "Data :";
            this.LblDataMatrixData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnSave.Location = new System.Drawing.Point(1759, 824);
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
            // BtnViewJobs
            // 
            this.BtnViewJobs.BackColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.CircleRectWidth = 0;
            this.BtnViewJobs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnViewJobs.FillColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnViewJobs.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnViewJobs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnViewJobs.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnViewJobs.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnViewJobs.Location = new System.Drawing.Point(1330, 825);
            this.BtnViewJobs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnViewJobs.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnViewJobs.Name = "BtnViewJobs";
            this.BtnViewJobs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnViewJobs.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnViewJobs.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnViewJobs.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnViewJobs.Size = new System.Drawing.Size(101, 32);
            this.BtnViewJobs.Style = Sunny.UI.UIStyle.Custom;
            this.BtnViewJobs.StyleCustomMode = true;
            this.BtnViewJobs.Symbol = 361773;
            this.BtnViewJobs.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnViewJobs.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnViewJobs.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnViewJobs.SymbolSize = 18;
            this.BtnViewJobs.TabIndex = 3618;
            this.BtnViewJobs.Tag = "ZoomIn";
            this.BtnViewJobs.Text = "View Jobs";
            this.BtnViewJobs.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnViewJobs.Click += new System.EventHandler(this.BtnViewJobs_Click);
            // 
            // BtnInspectAuto
            // 
            this.BtnInspectAuto.BackColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.CircleRectWidth = 0;
            this.BtnInspectAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnInspectAuto.FillColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.FillColor2 = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.FillDisableColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.FillHoverColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.FillPressColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.FillSelectedColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.Font = new System.Drawing.Font("Arial", 10F);
            this.BtnInspectAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnInspectAuto.ForeDisableColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnInspectAuto.ForePressColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInspectAuto.Location = new System.Drawing.Point(1439, 825);
            this.BtnInspectAuto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnInspectAuto.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnInspectAuto.Name = "BtnInspectAuto";
            this.BtnInspectAuto.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnInspectAuto.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnInspectAuto.RectDisableColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnInspectAuto.RectPressColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.RectSelectedColor = System.Drawing.Color.Transparent;
            this.BtnInspectAuto.Size = new System.Drawing.Size(145, 32);
            this.BtnInspectAuto.Style = Sunny.UI.UIStyle.Custom;
            this.BtnInspectAuto.StyleCustomMode = true;
            this.BtnInspectAuto.Symbol = 361773;
            this.BtnInspectAuto.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnInspectAuto.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnInspectAuto.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.BtnInspectAuto.SymbolSize = 18;
            this.BtnInspectAuto.TabIndex = 3619;
            this.BtnInspectAuto.Tag = "ZoomIn";
            this.BtnInspectAuto.Text = "Inspection (Auto)";
            this.BtnInspectAuto.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnInspectAuto.Click += new System.EventHandler(this.BtnInspectAuto_Click);
            // 
            // Btn_Inspect
            // 
            this.Btn_Inspect.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.CircleRectWidth = 0;
            this.Btn_Inspect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Inspect.FillColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.FillColor2 = System.Drawing.Color.Transparent;
            this.Btn_Inspect.FillDisableColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.FillHoverColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.FillPressColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.FillSelectedColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.Font = new System.Drawing.Font("Arial", 10F);
            this.Btn_Inspect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.Btn_Inspect.ForeDisableColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.Btn_Inspect.ForePressColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Inspect.Location = new System.Drawing.Point(1592, 824);
            this.Btn_Inspect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Btn_Inspect.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Inspect.Name = "Btn_Inspect";
            this.Btn_Inspect.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Btn_Inspect.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.Btn_Inspect.RectDisableColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.Btn_Inspect.RectPressColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.RectSelectedColor = System.Drawing.Color.Transparent;
            this.Btn_Inspect.Size = new System.Drawing.Size(163, 32);
            this.Btn_Inspect.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Inspect.StyleCustomMode = true;
            this.Btn_Inspect.Symbol = 361773;
            this.Btn_Inspect.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.Btn_Inspect.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.Btn_Inspect.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.Btn_Inspect.SymbolSize = 18;
            this.Btn_Inspect.TabIndex = 3620;
            this.Btn_Inspect.Tag = "ZoomIn";
            this.Btn_Inspect.Text = "Inspection (Manual)";
            this.Btn_Inspect.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Inspect.Click += new System.EventHandler(this.Btn_Inspect_Click);
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Arial", 12F);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(977, 828);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(163, 25);
            this.label25.TabIndex = 3621;
            this.label25.Text = "T/T :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlHelp
            // 
            this.pnlHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlHelp.Controls.Add(this.uiMarkLabel3);
            this.pnlHelp.Controls.Add(this.uiMarkLabel2);
            this.pnlHelp.Controls.Add(this.uiMarkLabel4);
            this.pnlHelp.Controls.Add(this.uiMarkLabel1);
            this.pnlHelp.Controls.Add(this.label124);
            this.pnlHelp.Controls.Add(this.label123);
            this.pnlHelp.Controls.Add(this.label122);
            this.pnlHelp.Controls.Add(this.label121);
            this.pnlHelp.Controls.Add(this.label72);
            this.pnlHelp.Controls.Add(this.label73);
            this.pnlHelp.Controls.Add(this.label74);
            this.pnlHelp.Controls.Add(this.label76);
            this.pnlHelp.Location = new System.Drawing.Point(13, 93);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(927, 744);
            this.pnlHelp.TabIndex = 3622;
            this.pnlHelp.Visible = false;
            // 
            // uiMarkLabel3
            // 
            this.uiMarkLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiMarkLabel3.ForeColor = System.Drawing.Color.White;
            this.uiMarkLabel3.Location = new System.Drawing.Point(427, 485);
            this.uiMarkLabel3.MarkColor = System.Drawing.Color.IndianRed;
            this.uiMarkLabel3.Name = "uiMarkLabel3";
            this.uiMarkLabel3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel3.Size = new System.Drawing.Size(409, 255);
            this.uiMarkLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiMarkLabel3.TabIndex = 3418;
            this.uiMarkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiMarkLabel2
            // 
            this.uiMarkLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiMarkLabel2.ForeColor = System.Drawing.Color.White;
            this.uiMarkLabel2.Location = new System.Drawing.Point(12, 213);
            this.uiMarkLabel2.MarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiMarkLabel2.Name = "uiMarkLabel2";
            this.uiMarkLabel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel2.Size = new System.Drawing.Size(409, 266);
            this.uiMarkLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiMarkLabel2.TabIndex = 3414;
            this.uiMarkLabel2.Text = resources.GetString("uiMarkLabel2.Text");
            this.uiMarkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiMarkLabel4
            // 
            this.uiMarkLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiMarkLabel4.ForeColor = System.Drawing.Color.White;
            this.uiMarkLabel4.Location = new System.Drawing.Point(12, 485);
            this.uiMarkLabel4.MarkColor = System.Drawing.Color.IndianRed;
            this.uiMarkLabel4.Name = "uiMarkLabel4";
            this.uiMarkLabel4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel4.Size = new System.Drawing.Size(409, 255);
            this.uiMarkLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiMarkLabel4.TabIndex = 3416;
            this.uiMarkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiMarkLabel1
            // 
            this.uiMarkLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiMarkLabel1.ForeColor = System.Drawing.Color.White;
            this.uiMarkLabel1.Location = new System.Drawing.Point(85, 168);
            this.uiMarkLabel1.MarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiMarkLabel1.Name = "uiMarkLabel1";
            this.uiMarkLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel1.Size = new System.Drawing.Size(409, 41);
            this.uiMarkLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiMarkLabel1.TabIndex = 3413;
            this.uiMarkLabel1.Text = "  1) Alt + Mouse Left Click : Set Roi on Position of Mouse";
            this.uiMarkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label124
            // 
            this.label124.BackColor = System.Drawing.Color.Black;
            this.label124.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label124.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label124.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label124.ForeColor = System.Drawing.Color.Orange;
            this.label124.Location = new System.Drawing.Point(166, 118);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(266, 40);
            this.label124.TabIndex = 3412;
            this.label124.Text = "ROI COLOR (ORANGE) : EYE-D";
            this.label124.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.Color.Transparent;
            this.label123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label123.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label123.Font = new System.Drawing.Font("Arial", 8F);
            this.label123.ForeColor = System.Drawing.Color.White;
            this.label123.Location = new System.Drawing.Point(80, 118);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(85, 40);
            this.label123.TabIndex = 3411;
            this.label123.Text = "EYE-D\r\n(DeepLearning)";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label122
            // 
            this.label122.BackColor = System.Drawing.Color.Transparent;
            this.label122.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label122.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label122.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label122.ForeColor = System.Drawing.Color.White;
            this.label122.Location = new System.Drawing.Point(80, 77);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(85, 40);
            this.label122.TabIndex = 3410;
            this.label122.Text = "Pattern";
            this.label122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label121
            // 
            this.label121.BackColor = System.Drawing.Color.Transparent;
            this.label121.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label121.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label121.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label121.ForeColor = System.Drawing.Color.White;
            this.label121.Location = new System.Drawing.Point(80, 36);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(85, 40);
            this.label121.TabIndex = 3409;
            this.label121.Text = "Search";
            this.label121.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.Transparent;
            this.label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label72.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label72.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.White;
            this.label72.Location = new System.Drawing.Point(13, 36);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(66, 173);
            this.label72.TabIndex = 3408;
            this.label72.Text = "ROI";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(77)))), ((int)(((byte)(86)))));
            this.label73.Dock = System.Windows.Forms.DockStyle.Top;
            this.label73.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label73.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label73.ForeColor = System.Drawing.Color.White;
            this.label73.Location = new System.Drawing.Point(0, 0);
            this.label73.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(927, 25);
            this.label73.TabIndex = 3300;
            this.label73.Text = "Help";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.Black;
            this.label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label74.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label74.ForeColor = System.Drawing.Color.Red;
            this.label74.Location = new System.Drawing.Point(166, 36);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(266, 40);
            this.label74.TabIndex = 2812;
            this.label74.Text = "ROI COLOR (RED) : Search";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.Black;
            this.label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label76.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label76.ForeColor = System.Drawing.Color.Blue;
            this.label76.Location = new System.Drawing.Point(166, 77);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(266, 40);
            this.label76.TabIndex = 2813;
            this.label76.Text = "ROI COLOR (BLUE) : Pattern";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnView_ResultNG4
            // 
            this.btnView_ResultNG4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_ResultNG4.FillColor = System.Drawing.Color.DimGray;
            this.btnView_ResultNG4.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_ResultNG4.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_ResultNG4.GroupIndex = 1;
            this.btnView_ResultNG4.Location = new System.Drawing.Point(516, 37);
            this.btnView_ResultNG4.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_ResultNG4.Name = "btnView_ResultNG4";
            this.btnView_ResultNG4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_ResultNG4.Size = new System.Drawing.Size(50, 20);
            this.btnView_ResultNG4.TabIndex = 3628;
            this.btnView_ResultNG4.Tag = "ResultNG";
            this.btnView_ResultNG4.Text = "4";
            this.btnView_ResultNG4.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_ResultNG4.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_ResultNG3
            // 
            this.btnView_ResultNG3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_ResultNG3.FillColor = System.Drawing.Color.DimGray;
            this.btnView_ResultNG3.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_ResultNG3.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_ResultNG3.GroupIndex = 1;
            this.btnView_ResultNG3.Location = new System.Drawing.Point(460, 37);
            this.btnView_ResultNG3.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_ResultNG3.Name = "btnView_ResultNG3";
            this.btnView_ResultNG3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_ResultNG3.Size = new System.Drawing.Size(50, 20);
            this.btnView_ResultNG3.TabIndex = 3627;
            this.btnView_ResultNG3.Tag = "ResultNG";
            this.btnView_ResultNG3.Text = "3";
            this.btnView_ResultNG3.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_ResultNG3.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_ResultNG2
            // 
            this.btnView_ResultNG2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_ResultNG2.FillColor = System.Drawing.Color.DimGray;
            this.btnView_ResultNG2.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_ResultNG2.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_ResultNG2.GroupIndex = 1;
            this.btnView_ResultNG2.Location = new System.Drawing.Point(404, 37);
            this.btnView_ResultNG2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_ResultNG2.Name = "btnView_ResultNG2";
            this.btnView_ResultNG2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_ResultNG2.Size = new System.Drawing.Size(50, 20);
            this.btnView_ResultNG2.TabIndex = 3626;
            this.btnView_ResultNG2.Tag = "ResultNG";
            this.btnView_ResultNG2.Text = "2";
            this.btnView_ResultNG2.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_ResultNG2.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_ResultNG1
            // 
            this.btnView_ResultNG1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_ResultNG1.FillColor = System.Drawing.Color.DimGray;
            this.btnView_ResultNG1.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_ResultNG1.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_ResultNG1.GroupIndex = 1;
            this.btnView_ResultNG1.Location = new System.Drawing.Point(348, 37);
            this.btnView_ResultNG1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_ResultNG1.Name = "btnView_ResultNG1";
            this.btnView_ResultNG1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_ResultNG1.Size = new System.Drawing.Size(50, 20);
            this.btnView_ResultNG1.TabIndex = 3625;
            this.btnView_ResultNG1.Tag = "ResultNG";
            this.btnView_ResultNG1.Text = "1";
            this.btnView_ResultNG1.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_ResultNG1.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("Arial", 9F);
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(283, 37);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(65, 20);
            this.label66.TabIndex = 3623;
            this.label66.Text = "Result NG";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine13
            // 
            this.uiLine13.BackColor = System.Drawing.Color.Transparent;
            this.uiLine13.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine13.LineColor = System.Drawing.Color.Black;
            this.uiLine13.Location = new System.Drawing.Point(284, 56);
            this.uiLine13.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine13.Name = "uiLine13";
            this.uiLine13.Size = new System.Drawing.Size(286, 10);
            this.uiLine13.TabIndex = 3624;
            // 
            // btnAction
            // 
            this.btnAction.BackColor = System.Drawing.Color.Transparent;
            this.btnAction.CircleRectWidth = 0;
            this.btnAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAction.FillColor = System.Drawing.Color.Transparent;
            this.btnAction.FillColor2 = System.Drawing.Color.Transparent;
            this.btnAction.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnAction.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnAction.FillPressColor = System.Drawing.Color.Transparent;
            this.btnAction.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnAction.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAction.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnAction.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAction.ForePressColor = System.Drawing.Color.Transparent;
            this.btnAction.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.Location = new System.Drawing.Point(1147, 825);
            this.btnAction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAction.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAction.Name = "btnAction";
            this.btnAction.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAction.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnAction.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAction.RectPressColor = System.Drawing.Color.Transparent;
            this.btnAction.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnAction.Size = new System.Drawing.Size(101, 32);
            this.btnAction.Style = Sunny.UI.UIStyle.Custom;
            this.btnAction.StyleCustomMode = true;
            this.btnAction.Symbol = 0;
            this.btnAction.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAction.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAction.SymbolSize = 18;
            this.btnAction.TabIndex = 3629;
            this.btnAction.Tag = "ZoomIn";
            this.btnAction.Text = "Action Result";
            this.btnAction.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnOriginal
            // 
            this.btnOriginal.BackColor = System.Drawing.Color.Transparent;
            this.btnOriginal.CircleRectWidth = 0;
            this.btnOriginal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOriginal.FillColor = System.Drawing.Color.Transparent;
            this.btnOriginal.FillColor2 = System.Drawing.Color.Transparent;
            this.btnOriginal.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnOriginal.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnOriginal.FillPressColor = System.Drawing.Color.Transparent;
            this.btnOriginal.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnOriginal.Font = new System.Drawing.Font("Arial", 10F);
            this.btnOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOriginal.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnOriginal.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOriginal.ForePressColor = System.Drawing.Color.Transparent;
            this.btnOriginal.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnOriginal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOriginal.Location = new System.Drawing.Point(1257, 825);
            this.btnOriginal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOriginal.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOriginal.Name = "btnOriginal";
            this.btnOriginal.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOriginal.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnOriginal.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOriginal.RectPressColor = System.Drawing.Color.Transparent;
            this.btnOriginal.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnOriginal.Size = new System.Drawing.Size(66, 32);
            this.btnOriginal.Style = Sunny.UI.UIStyle.Custom;
            this.btnOriginal.StyleCustomMode = true;
            this.btnOriginal.Symbol = 0;
            this.btnOriginal.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOriginal.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOriginal.SymbolSize = 18;
            this.btnOriginal.TabIndex = 3630;
            this.btnOriginal.Tag = "ZoomIn";
            this.btnOriginal.Text = "Original";
            this.btnOriginal.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOriginal.Click += new System.EventHandler(this.btnOriginal_Click);
            // 
            // btnView_Setting5
            // 
            this.btnView_Setting5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting5.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting5.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting5.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting5.GroupIndex = 1;
            this.btnView_Setting5.Location = new System.Drawing.Point(280, 6);
            this.btnView_Setting5.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting5.Name = "btnView_Setting5";
            this.btnView_Setting5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting5.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting5.TabIndex = 3631;
            this.btnView_Setting5.Tag = "Setting";
            this.btnView_Setting5.Text = "5";
            this.btnView_Setting5.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting5.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting6
            // 
            this.btnView_Setting6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting6.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting6.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting6.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting6.GroupIndex = 1;
            this.btnView_Setting6.Location = new System.Drawing.Point(336, 6);
            this.btnView_Setting6.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting6.Name = "btnView_Setting6";
            this.btnView_Setting6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting6.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting6.TabIndex = 3632;
            this.btnView_Setting6.Tag = "Setting";
            this.btnView_Setting6.Text = "6";
            this.btnView_Setting6.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting6.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting7
            // 
            this.btnView_Setting7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting7.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting7.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting7.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting7.GroupIndex = 1;
            this.btnView_Setting7.Location = new System.Drawing.Point(392, 6);
            this.btnView_Setting7.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting7.Name = "btnView_Setting7";
            this.btnView_Setting7.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting7.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting7.TabIndex = 3633;
            this.btnView_Setting7.Tag = "Setting";
            this.btnView_Setting7.Text = "7";
            this.btnView_Setting7.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting7.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting8
            // 
            this.btnView_Setting8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting8.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting8.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting8.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting8.GroupIndex = 1;
            this.btnView_Setting8.Location = new System.Drawing.Point(448, 6);
            this.btnView_Setting8.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting8.Name = "btnView_Setting8";
            this.btnView_Setting8.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting8.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting8.TabIndex = 3634;
            this.btnView_Setting8.Tag = "Setting";
            this.btnView_Setting8.Text = "8";
            this.btnView_Setting8.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting8.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting9
            // 
            this.btnView_Setting9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting9.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting9.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting9.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting9.GroupIndex = 1;
            this.btnView_Setting9.Location = new System.Drawing.Point(504, 6);
            this.btnView_Setting9.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting9.Name = "btnView_Setting9";
            this.btnView_Setting9.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting9.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting9.TabIndex = 3635;
            this.btnView_Setting9.Tag = "Setting";
            this.btnView_Setting9.Text = "9";
            this.btnView_Setting9.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting9.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting10
            // 
            this.btnView_Setting10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting10.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting10.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting10.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting10.GroupIndex = 1;
            this.btnView_Setting10.Location = new System.Drawing.Point(560, 6);
            this.btnView_Setting10.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting10.Name = "btnView_Setting10";
            this.btnView_Setting10.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting10.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting10.TabIndex = 3636;
            this.btnView_Setting10.Tag = "Setting";
            this.btnView_Setting10.Text = "10";
            this.btnView_Setting10.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting10.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting11
            // 
            this.btnView_Setting11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting11.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting11.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting11.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting11.GroupIndex = 1;
            this.btnView_Setting11.Location = new System.Drawing.Point(616, 6);
            this.btnView_Setting11.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting11.Name = "btnView_Setting11";
            this.btnView_Setting11.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting11.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting11.TabIndex = 3637;
            this.btnView_Setting11.Tag = "Setting";
            this.btnView_Setting11.Text = "11";
            this.btnView_Setting11.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting11.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // btnView_Setting12
            // 
            this.btnView_Setting12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView_Setting12.FillColor = System.Drawing.Color.DimGray;
            this.btnView_Setting12.FillSelectedColor = System.Drawing.Color.Green;
            this.btnView_Setting12.Font = new System.Drawing.Font("Arial", 8F);
            this.btnView_Setting12.GroupIndex = 1;
            this.btnView_Setting12.Location = new System.Drawing.Point(672, 6);
            this.btnView_Setting12.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnView_Setting12.Name = "btnView_Setting12";
            this.btnView_Setting12.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnView_Setting12.Size = new System.Drawing.Size(50, 20);
            this.btnView_Setting12.TabIndex = 3638;
            this.btnView_Setting12.Tag = "Setting";
            this.btnView_Setting12.Text = "12";
            this.btnView_Setting12.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView_Setting12.Click += new System.EventHandler(this.OnClickViewMode);
            // 
            // comboViewType
            // 
            this.comboViewType.DataSource = null;
            this.comboViewType.FillColor = System.Drawing.SystemColors.Control;
            this.comboViewType.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.comboViewType.ForeColor = System.Drawing.Color.Black;
            this.comboViewType.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboViewType.ItemForeColor = System.Drawing.Color.White;
            this.comboViewType.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboViewType.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboViewType.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.comboViewType.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboViewType.Location = new System.Drawing.Point(598, 29);
            this.comboViewType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboViewType.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboViewType.Name = "comboViewType";
            this.comboViewType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboViewType.RectColor = System.Drawing.Color.DimGray;
            this.comboViewType.Size = new System.Drawing.Size(154, 26);
            this.comboViewType.SymbolSize = 24;
            this.comboViewType.TabIndex = 3620;
            this.comboViewType.Text = "1";
            this.comboViewType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboViewType.Watermark = "";
            // 
            // Form_MenuVision
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 860);
            this.Controls.Add(this.comboViewType);
            this.Controls.Add(this.btnView_Setting12);
            this.Controls.Add(this.btnView_Setting11);
            this.Controls.Add(this.btnView_Setting10);
            this.Controls.Add(this.btnView_Setting9);
            this.Controls.Add(this.btnView_Setting8);
            this.Controls.Add(this.btnView_Setting7);
            this.Controls.Add(this.btnView_Setting6);
            this.Controls.Add(this.btnView_Setting5);
            this.Controls.Add(this.btnOriginal);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnView_ResultNG4);
            this.Controls.Add(this.pnlHelp);
            this.Controls.Add(this.btnView_ResultNG3);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.Btn_Inspect);
            this.Controls.Add(this.btnView_ResultNG2);
            this.Controls.Add(this.BtnInspectAuto);
            this.Controls.Add(this.BtnViewJobs);
            this.Controls.Add(this.btnView_ResultNG1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.uiTabControl1);
            this.Controls.Add(this.uiLine13);
            this.Controls.Add(this.btnView_Full);
            this.Controls.Add(this.DisplayGrabIdx1);
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_MenuVision_KeyDown);
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
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogdis_IQPreView)).EndInit();
            this.uiGroupBox14.ResumeLayout(false);
            this.uiGroupBox14.PerformLayout();
            this.uiGroupBox12.ResumeLayout(false);
            this.uiGroupBox12.PerformLayout();
            this.uiGroupBox5.ResumeLayout(false);
            this.uiGroupBox5.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.uiTabControl6.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cogdis_FiducialPreView)).EndInit();
            this.uiGroupBox17.ResumeLayout(false);
            this.uiGroupBox16.ResumeLayout(false);
            this.uiGroupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Fiducial_Pattern1)).EndInit();
            this.tabPage12.ResumeLayout(false);
            this.uiTabControl3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.uiGroupBox18.ResumeLayout(false);
            this.uiGroupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGerberInfo)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cogdis_Master)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.uiGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cogdis_Bare)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.TabMenuLogic.ResumeLayout(false);
            this.tpPattern.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_JobPattern)).EndInit();
            this.tpEYED.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tpCondensor.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.tpColorEx.ResumeLayout(false);
            this.tpColorEx.PerformLayout();
            this.panel64.ResumeLayout(false);
            this.tpPin.ResumeLayout(false);
            this.tpPin.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackbarThreshold)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProcessingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLogicList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvJobList)).EndInit();
            this.tabPage15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecentImages)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiGroupBox6.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayDataMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayArray)).EndInit();
            this.uiTableLayoutPanel6.ResumeLayout(false);
            this.uiTableLayoutPanel5.ResumeLayout(false);
            this.uiTableLayoutPanel4.ResumeLayout(false);
            this.uiTableLayoutPanel7.ResumeLayout(false);
            this.uiTableLayoutPanel3.ResumeLayout(false);
            this.pnlHelp.ResumeLayout(false);
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
        private Sunny.UI.UIButton btnViewGrabIndex6;
        private Sunny.UI.UIButton btnViewGrabIndex7;
        private Sunny.UI.UIButton btnViewGrabIndex8;
        private Sunny.UI.UIButton btnViewGrabIndex9;
        private Sunny.UI.UIButton btnViewGrabIndex10;
        private Sunny.UI.UIButton btnViewGrabIndex11;
        private Sunny.UI.UIButton btnViewGrabIndex12;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx1;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx2;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx4;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx3;
        private Cognex.VisionPro.Display.CogDisplay DisplayGrabIdx5;
        private Timer timerCalibration;
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
        private Label lbCurrentFocusValue;
        private Label lbBestFocusValue;
        private Sunny.UI.UISymbolButton btnIQStop;
        private Sunny.UI.UISymbolButton btnIQStart;
        private Sunny.UI.UITextBox tbMasterHeight;
        private Label label38;
        private Sunny.UI.UITabControl uiTabControl6;
        private TabPage tabPage12;
        private TabPage tabPage13;
        private Sunny.UI.UIGroupBox uiGroupBox16;
        private Sunny.UI.UISymbolButton btnFiducialTrain2;
        private Sunny.UI.UISymbolButton btnFiducialROI2;
        private Sunny.UI.UILine uiLine16;
        private Sunny.UI.UISymbolButton btnFiducialTrain1;
        private Sunny.UI.UISymbolButton btnFiducialROI1;
        private Sunny.UI.UILine uiLine19;
        private Label label68;
        private Sunny.UI.UISymbolButton btnFiducialFind2;
        private Sunny.UI.UISymbolButton btnFiducialFind1;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay_Fiducial_Pattern1;
        private CheckBox chkAlignNoUse;
        private Sunny.UI.UIGroupBox uiGroupBox14;
        private Sunny.UI.UISymbolButton BtnGrab5;
        private Sunny.UI.UISymbolButton BtnGrab4;
        private Sunny.UI.UISymbolButton BtnGrab3;
        private Sunny.UI.UISymbolButton BtnGrab2;
        private Sunny.UI.UISymbolButton BtnGrab1;
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
        private Sunny.UI.UIGroupBox uiGroupBox17;
        private Sunny.UI.UIComboBox comboArray;
        private Sunny.UI.UISymbolButton btnArrayCrop_Set;
        private Sunny.UI.UISymbolButton btnArrayCrop_Roi;
        private Label label60;
        private TabPage tabPage14;
        private TabPage tabPage15;
        private Label lbQrCodeData;
        private Sunny.UI.UISymbolButton btnQrRead;
        private Sunny.UI.UILine uiLine20;
        private Sunny.UI.UISymbolButton btnQrSet;
        private Sunny.UI.UISymbolButton btnQrRoi;
        private Label label3;
        private Sunny.UI.UILine uiLine18;
        private Sunny.UI.UISymbolButton btnSave;
        private Sunny.UI.UISymbolButton BtnViewJobs;
        private Sunny.UI.UISymbolButton BtnInspectAuto;
        private Sunny.UI.UISymbolButton Btn_Inspect;
        private Sunny.UI.UISymbolButton btnSave_QR;
        public DataGridView DgvJobList;
        private Sunny.UI.UISymbolButton BtnJobListCopy;
        private Sunny.UI.UISymbolButton BtnJobDelete;
        private Sunny.UI.UISymbolButton BtnJobAdd;
        private CheckBox CbJobAll;
        private Sunny.UI.UILine uiLine21;
        private Sunny.UI.UITextBox TbPartName;
        private Label label14;
        private Sunny.UI.UITextBox TbLocationNo;
        private Label label17;
        private Label label6;
        private Label label16;
        private Label label15;
        private Sunny.UI.UISymbolButton BtnSettingJob;
        private Label label20;
        private Sunny.UI.UIButton BtnNA_ng;
        private Label label23;
        private Sunny.UI.UIComboBox cbGrabIndex;
        private Sunny.UI.UISymbolButton BtnSettingLogic;
        private Label label18;
        private Sunny.UI.UITextBox tbLogicName;
        private Label label19;
        private Sunny.UI.UIComboBox cbAlgorithm;
        private Sunny.UI.UILine uiLine25;
        private Sunny.UI.UISymbolButton btnUpLoadPartLibrary;
        private Label label24;
        private Sunny.UI.UISymbolButton BtnLogicDelete;
        private Sunny.UI.UISymbolButton BtnLogicAdd;
        private Label label89;
        private Sunny.UI.UIComboBox CbTriggerMode;
        private Sunny.UI.UISymbolButton uiSymbolButton28;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        public DataGridView DgvLogicList;
        private CheckBox cbIQContinuous;
        private TableLayoutPanel tableLayoutPanel18;
        private TableLayoutPanel tableLayoutPanel19;
        private Sunny.UI.UISymbolButton btn_Library_Update;
        private Sunny.UI.UISymbolButton btn_Library_Clear;
        private Sunny.UI.UISymbolButton btn_Library_Refresh;
        private TableLayoutPanel tableLayoutPanel15;
        private Label label27;
        private TableLayoutPanel tableLayoutPanel16;
        private Label lb_Library_ServerName;
        private Sunny.UI.UISymbolButton btn_Library_LoadServerFolder;
        private TableLayoutPanel tableLayoutPanel17;
        private Label lb_Library_LocalName;
        private Sunny.UI.UISymbolButton btn_Library_LoadLocalFolder;
        private Label label28;
        private Panel panel7;
        private ComboBox cbbMethod;
        private DataGridView dgvParameter;
        private Label label4;
        private Sunny.UI.UISymbolButton uiSymbolButton3;
        private Sunny.UI.UISymbolButton uiSymbolButton8;
        public DataGridView DgvProcessingList;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private TableLayoutPanel tableLayoutPanel2;
        private Sunny.UI.UITabControlMenu TabMenuLogic;
        private TabPage tpPattern;
        private Sunny.UI.UIRichTextBox richtxtPatternResult;
        private Label label9;
        private Sunny.UI.UILine uiLine23;
        private Sunny.UI.UISymbolButton BtnDeletePattern;
        private Label label26;
        private Sunny.UI.UIComboBox comboJobPattern_PatternType;
        private Sunny.UI.UITextBox tbJobPattern_AcceptScore;
        private Label label13;
        private Label label10;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UITextBox tbJobPattern_MinScore;
        private Label label11;
        private Sunny.UI.UITextBox tbPatternMasterCount;
        private Label label12;
        private Sunny.UI.UISymbolButton btnJobPattern_Roi;
        private Sunny.UI.UISymbolButton btnJobPattern_Train;
        private Sunny.UI.UISymbolButton btnJobPattern_Find;
        private Label label110;
        private Panel panel14;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay_JobPattern;
        private Label label65;
        private Label lblSubPatternInfo;
        private TabPage tpEYED;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label87;
        private Label label85;
        private Sunny.UI.UITextBox TbThresholdEYED;
        private Label label55;
        private Label label39;
        private Sunny.UI.UISymbolButton BtnOpenOnnx;
        private Sunny.UI.UIComboBox CbRotateImageEYED;
        private Panel panel3;
        private CheckBox ChkSpecRegionEYED;
        private Label LblResultEYED;
        private TabPage tpColorEx;
        private Panel panel64;
        private Sunny.UI.UITextBox txtColorEx_B;
        private Sunny.UI.UITextBox txtColorEx_G;
        private Sunny.UI.UITextBox txtColorEx_R;
        private Label label168;
        private Label label171;
        private Label label170;
        private Label label169;
        private CheckBox chkColorEx_SimpleMode;
        private Label label167;
        private Sunny.UI.UISymbolButton btnJobColorEx_Roi;
        private Label lblJobColorEx_ResultColor;
        private Label label130;
        private Sunny.UI.UISymbolButton uiSymbolButton67;
        private Label label133;
        private TabPage tpCondensor;
        private Sunny.UI.UITextBox tbIgnoreCount;
        private Sunny.UI.UITextBox tbCircleThickness;
        private Sunny.UI.UITextBox tbCircleContrast;
        private Sunny.UI.UITextBox tbCondensorRectRadio;
        private Sunny.UI.UITextBox tbCircleRectH;
        private Sunny.UI.UITextBox tbCircleRectW;
        private Sunny.UI.UISymbolButton btnJobCondensor_DistSetting;
        private Sunny.UI.UISymbolButton btnJobCondensor_DistInsp;
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
        private TabPage tpPin;
        private Label label8;
        private CheckBox chkThresholdInv;
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
        private IF_UI.RJControls.RJTrackBar trackbarThreshold;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel5;
        private Sunny.UI.UISymbolButton BtnApplyCore;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Sunny.UI.UISymbolButton uiSymbolButton9;
        private Sunny.UI.UIButton BtnNA_ok;
        private Sunny.UI.UIDataGridView DgvRecentImages;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private Sunny.UI.UISymbolButton btnJobColorEx_Get;
        private Panel panel1;
        private Label label80;
        private Label label75;
        private Panel panel4;
        private Cognex.VisionPro.Display.CogDisplay Cogdis_FiducialPreView;
        private Label label78;
        private Label lblDegreeMaster;
        private Sunny.UI.UILine uiLine22;
        private Sunny.UI.UIButton uiButton1;
        private Label lblDegreeMeasure;
        private Sunny.UI.UISymbolButton btnFiducial_Measure;
        private Sunny.UI.UILine uiLine24;
        private Sunny.UI.UILine uiLine26;
        private Label lblDegreeDelta;
        private Sunny.UI.UISymbolButton btnImageAlign_Rotate;
        private Sunny.UI.UISymbolButton btnResetMaster;
        private Sunny.UI.UISymbolButton btnFiducial_MeasureToMaster;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        public Cognex.VisionPro.Display.CogDisplay cogdis_IQPreView;
        private Label label7;
        private Label label2;
        private Label label21;
        private Sunny.UI.UITabControl uiTabControl3;
        private TabPage tabPage5;
        private Sunny.UI.UIGroupBox uiGroupBox18;
        private CheckBox chkEnalbenouse;
        private Sunny.UI.UISymbolButton uiSymbolButton56;
        private Sunny.UI.UITextBox uiTextBox34;
        private Label label64;
        private Sunny.UI.UITextBox uiTextBox32;
        private Label label62;
        private Sunny.UI.UISymbolButton BtnReplaceLibrary;
        private Sunny.UI.UISymbolButton BtnRegionVisible;
        private Sunny.UI.UIDataGridView DgvGerberInfo;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn Angle;
        private Sunny.UI.UISymbolButton BtnGerberLoad;
        private Sunny.UI.UITextBox TbGerberPath;
        private Label label59;
        private TabPage tabPage6;
        private Sunny.UI.UISymbolButton BtnMasterBoardLoad;
        private Sunny.UI.UISymbolButton BtnMasterBoardSave;
        private TabPage tabPage7;
        private Sunny.UI.UISymbolButton BtnBareBoardLoad;
        private Sunny.UI.UISymbolButton BtnBareBoardSave;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        public Cognex.VisionPro.Display.CogDisplay Cogdis_Master;
        private Sunny.UI.UIGroupBox uiGroupBox4;
        public Cognex.VisionPro.Display.CogDisplay Cogdis_Bare;
        private Label label25;
        private Sunny.UI.UISymbolButton btnDownLoadPartLibrary;
        private Sunny.UI.UISymbolButton BtnFindEYED;
        private Sunny.UI.UISymbolButton BtnRoiEYED;
        private Sunny.UI.UIComboBox CbbModelList;
        private Sunny.UI.UIButton BtnGrabMove;
        private Sunny.UI.UIGroupBox uiGroupBox5;
        private Sunny.UI.UISymbolButton BtnIQDataSave;
        private Sunny.UI.UISymbolButton BtnIQLoad;
        private Label lblMasterPixel;
        private Label lblMasterHeight;
        private Label lblMasterWidth;
        private Label label32;
        private Label label36;
        private Label label37;
        private Label lblMasterFocus;
        private Label label30;
        private Sunny.UI.UISymbolButton uiSymbolButton7;
        private CheckBox chkChangeFiducialMark;
        private Panel pnlHelp;
        private Sunny.UI.UIMarkLabel uiMarkLabel3;
        private Sunny.UI.UIMarkLabel uiMarkLabel2;
        private Sunny.UI.UIMarkLabel uiMarkLabel4;
        private Sunny.UI.UIMarkLabel uiMarkLabel1;
        private Label label124;
        private Label label123;
        private Label label122;
        private Label label121;
        private Label label72;
        private Label label73;
        private Label label74;
        private Label label76;
        private CheckBox chkAlphaImg;
        private Sunny.UI.UITextBox TbTransparent;
        private Sunny.UI.UITextBox TbLibraryName;
        private Sunny.UI.UISymbolButton btnLibrarySelect;
        private Label label22;
        private Sunny.UI.UITextBox TbColorEXRangeMin_G;
        private Sunny.UI.UITextBox TbColorEXRangeMin_B;
        private Label label77;
        private Sunny.UI.UITextBox TbColorEXRangeMin_R;
        private Label label63;
        private Sunny.UI.UITextBox TbColorEXRangeMax_B;
        private Sunny.UI.UITextBox TbColorEXRangeMax_G;
        private Sunny.UI.UITextBox TbColorEXRangeMax_R;
        private Label label56;
        private Label label31;
        private Label label57;
        private Sunny.UI.UISymbolButton BtnJobDownLoad;
        private Panel panel6;
        private RadioButton radioColorEx_Range45;
        private RadioButton radioColorEx_Range30;
        private RadioButton radioColorEx_Range15;
        private Sunny.UI.UITextBox txtEyeD_ColorEx_B;
        private Sunny.UI.UITextBox txtEyeD_ColorEx_G;
        private Sunny.UI.UITextBox txtEyeD_ColorEx_R;
        private Label label81;
        private Label label82;
        private Label label83;
        private Label label84;
        private CheckBox chkEyeD_UseColor;
        private Label label58;
        private Sunny.UI.UISymbolButton btnEyeD_ColorEx_Get;
        private Sunny.UI.UISymbolButton btnEyeD_ColorExRoi;
        private Label lblEyeD_ColorEx_Result;
        private Label label67;
        private Sunny.UI.UIButton btnView_ResultNG4;
        private Sunny.UI.UIButton btnView_ResultNG3;
        private Sunny.UI.UIButton btnView_ResultNG2;
        private Sunny.UI.UIButton btnView_ResultNG1;
        private Label label66;
        private Sunny.UI.UILine uiLine13;
        private Sunny.UI.UISymbolButton btnAction;
        private Sunny.UI.UISymbolButton btnOriginal;
        private Sunny.UI.UISymbolButton BtnModelDownAll;
        private DataGridViewTextBoxColumn No;
        private DataGridViewCheckBoxColumn gridLibraryName;
        private DataGridViewTextBoxColumn gridLibraryEnabled;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Colum3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn Grab;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewCheckBoxColumn Column5;
        private Sunny.UI.UITreeView TvServer;
        private Sunny.UI.UITreeView TvLocal;
        private Sunny.UI.UISymbolButton btnUpLoadAll;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UITextBox txtArrayCount;
        private Sunny.UI.UIButton btnView_Setting5;
        private Sunny.UI.UIButton btnView_Setting6;
        private Sunny.UI.UIButton btnView_Setting7;
        private Sunny.UI.UIButton btnView_Setting8;
        private Sunny.UI.UIButton btnView_Setting9;
        private Sunny.UI.UIButton btnView_Setting10;
        private Sunny.UI.UIButton btnView_Setting11;
        private Sunny.UI.UIButton btnView_Setting12;
        private Sunny.UI.UIComboBox comboViewType;
        private TabPage tabPage4;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UIGroupBox uiGroupBox6;
        private Label LblDataMatrixData;
        private Sunny.UI.UISymbolButton BtnDataMatrixRoiRead;
        private Sunny.UI.UISymbolButton BtnArraySet;
        private Sunny.UI.UISymbolButton BtnArrayRoi;
        private Label label69;
        private Sunny.UI.UIComboBox comboArrayNumber;
        private Sunny.UI.UISymbolButton BtnDataMatrixRoiSet;
        private Sunny.UI.UISymbolButton BtnDataMatrixRoi;
        private Label label70;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel5;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel4;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel6;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel7;
        private Cognex.VisionPro.Display.CogDisplay DisplayDataMatrix;
        private Cognex.VisionPro.Display.CogDisplay DisplayArray;
        private TableLayoutPanel tableLayoutPanel4;
        private Sunny.UI.UILine uiLine14;
    }
}