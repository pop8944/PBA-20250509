using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IF
{
    partial class Form_MainFrame
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
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnMinimize = new Sunny.UI.UISymbolButton();
            this.btnClose = new Sunny.UI.UISymbolButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.uiLedBulb3 = new Sunny.UI.UILedBulb();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bulbLicense = new Sunny.UI.UILedBulb();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bulbCamera = new Sunny.UI.UILedBulb();
            this.lblStatus = new Sunny.UI.UIButton();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.statusBar = new Sunny.UI.UIPanel();
            this.uiLine2 = new Sunny.UI.UILine();
            this.processBar_DiskD = new Sunny.UI.UIProcessBar();
            this.label4 = new System.Windows.Forms.Label();
            this.uiSymbolButton13 = new Sunny.UI.UISymbolButton();
            this.uiLine1 = new Sunny.UI.UILine();
            this.btnLogView = new Sunny.UI.UISymbolButton();
            this.processBar_CPU = new Sunny.UI.UIProcessBar();
            this.label34 = new System.Windows.Forms.Label();
            this.processBar_RAM = new Sunny.UI.UIProcessBar();
            this.label33 = new System.Windows.Forms.Label();
            this.processBar_DiskC = new Sunny.UI.UIProcessBar();
            this.label7 = new System.Windows.Forms.Label();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.uiProgressIndicator1 = new Sunny.UI.UIProgressIndicator();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblVersion = new Sunny.UI.UISymbolButton();
            this.btnMenu_Setting = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.btnMenu_Device = new Sunny.UI.UISymbolButton();
            this.btnMenu_Vision = new Sunny.UI.UISymbolButton();
            this.btnMenu_Model = new Sunny.UI.UISymbolButton();
            this.btnMenu_Main = new Sunny.UI.UISymbolButton();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.pnlMainFrame = new Sunny.UI.UIPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Mode = new Sunny.UI.UILedLabel();
            this.btnOper_Start = new Sunny.UI.UISymbolButton();
            this.btnOper_Reset = new Sunny.UI.UISymbolButton();
            this.btnOper_Pause = new Sunny.UI.UISymbolButton();
            this.btnOper_Stop = new Sunny.UI.UISymbolButton();
            this.uiGroupBox5 = new Sunny.UI.UIGroupBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.statusCamera = new Sunny.UI.UILedBulb();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.uiLedBulb24 = new Sunny.UI.UILedBulb();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.uiLedBulb23 = new Sunny.UI.UILedBulb();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.uiLedBulb20 = new Sunny.UI.UILedBulb();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.uiLedBulb22 = new Sunny.UI.UILedBulb();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.uiLedBulb21 = new Sunny.UI.UILedBulb();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.lblModelName = new System.Windows.Forms.Label();
            this.lblRunState = new System.Windows.Forms.Label();
            this.btnAuthorization = new Sunny.UI.UISymbolButton();
            this.lbl_DateTime = new System.Windows.Forms.Label();
            this.pnlLogViewer = new Sunny.UI.UIPanel();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.uiPanel4 = new Sunny.UI.UIPanel();
            this.pnlLog = new Sunny.UI.UIPanel();
            this.uiPanel5 = new Sunny.UI.UIPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOpenLogFolder = new Sunny.UI.UISymbolButton();
            this.timerInit = new System.Windows.Forms.Timer(this.components);
            this.pnlMDI = new Sunny.UI.UIPanel();
            this.pnlTitle.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.pnlMainFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.uiGroupBox5.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel6.SuspendLayout();
            this.uiPanel3.SuspendLayout();
            this.pnlLogViewer.SuspendLayout();
            this.uiPanel4.SuspendLayout();
            this.uiPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlTitle.Controls.Add(this.label11);
            this.pnlTitle.Controls.Add(this.btnMinimize);
            this.pnlTitle.Controls.Add(this.btnClose);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlTitle.FillColor2 = System.Drawing.Color.SlateGray;
            this.pnlTitle.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.pnlTitle.ForeColor = System.Drawing.Color.White;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnlTitle.Radius = 0;
            this.pnlTitle.RectColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Size = new System.Drawing.Size(1920, 30);
            this.pnlTitle.TabIndex = 9;
            this.pnlTitle.Text = "          IF AOI / OP 1.0.0 2024.06.16 / VP 1.0.0 2024.06.16";
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            this.pnlTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseMove);
            this.pnlTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Bodoni MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(-1, 5);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label11.Size = new System.Drawing.Size(64, 19);
            this.label11.TabIndex = 3463;
            this.label11.Text = "(주)이프";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FillColor2 = System.Drawing.Color.SlateGray;
            this.btnMinimize.FillDisableColor = System.Drawing.Color.DimGray;
            this.btnMinimize.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnMinimize.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnMinimize.FillSelectedColor = System.Drawing.Color.SlateGray;
            this.btnMinimize.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.Location = new System.Drawing.Point(1860, 0);
            this.btnMinimize.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Radius = 0;
            this.btnMinimize.RectColor = System.Drawing.Color.Transparent;
            this.btnMinimize.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnMinimize.RectHoverColor = System.Drawing.Color.White;
            this.btnMinimize.RectPressColor = System.Drawing.Color.Transparent;
            this.btnMinimize.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.Symbol = 75;
            this.btnMinimize.SymbolSize = 36;
            this.btnMinimize.TabIndex = 12;
            this.btnMinimize.TipsFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.FillColor2 = System.Drawing.Color.SlateGray;
            this.btnClose.FillDisableColor = System.Drawing.Color.DimGray;
            this.btnClose.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnClose.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnClose.FillSelectedColor = System.Drawing.Color.SlateGray;
            this.btnClose.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(1890, 0);
            this.btnClose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 0;
            this.btnClose.RectColor = System.Drawing.Color.Transparent;
            this.btnClose.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnClose.RectHoverColor = System.Drawing.Color.White;
            this.btnClose.RectPressColor = System.Drawing.Color.Transparent;
            this.btnClose.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.Symbol = 77;
            this.btnClose.SymbolSize = 36;
            this.btnClose.TabIndex = 11;
            this.btnClose.TipsFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.uiLedBulb3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 15);
            this.panel3.TabIndex = 3443;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(16, 14);
            this.label3.TabIndex = 3439;
            this.label3.Text = "-";
            // 
            // uiLedBulb3
            // 
            this.uiLedBulb3.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLedBulb3.Location = new System.Drawing.Point(0, 0);
            this.uiLedBulb3.Name = "uiLedBulb3";
            this.uiLedBulb3.On = false;
            this.uiLedBulb3.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.uiLedBulb3.Size = new System.Drawing.Size(10, 15);
            this.uiLedBulb3.TabIndex = 3438;
            this.uiLedBulb3.Text = "uiLedBulb3";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.bulbLicense);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 15);
            this.panel2.TabIndex = 3442;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 3439;
            this.label2.Text = "LICENSE";
            // 
            // bulbLicense
            // 
            this.bulbLicense.Dock = System.Windows.Forms.DockStyle.Left;
            this.bulbLicense.Location = new System.Drawing.Point(0, 0);
            this.bulbLicense.Name = "bulbLicense";
            this.bulbLicense.On = false;
            this.bulbLicense.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.bulbLicense.Size = new System.Drawing.Size(10, 15);
            this.bulbLicense.TabIndex = 3438;
            this.bulbLicense.Text = "uiLedBulb2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bulbCamera);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 15);
            this.panel1.TabIndex = 3441;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 3439;
            this.label1.Text = "CAMERA";
            // 
            // bulbCamera
            // 
            this.bulbCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.bulbCamera.Location = new System.Drawing.Point(0, 0);
            this.bulbCamera.Name = "bulbCamera";
            this.bulbCamera.On = false;
            this.bulbCamera.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.bulbCamera.Size = new System.Drawing.Size(10, 15);
            this.bulbCamera.TabIndex = 3438;
            this.bulbCamera.Text = "uiLedBulb1";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStatus.FillColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.FillColor2 = System.Drawing.Color.LightGray;
            this.lblStatus.FillColorGradient = true;
            this.lblStatus.FillDisableColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.FillHoverColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.FillPressColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.FillSelectedColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.ForeDisableColor = System.Drawing.Color.DimGray;
            this.lblStatus.ForeHoverColor = System.Drawing.Color.DimGray;
            this.lblStatus.ForePressColor = System.Drawing.Color.DimGray;
            this.lblStatus.ForeSelectedColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(6, 27);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatus.MinimumSize = new System.Drawing.Size(2, 1);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RectColor = System.Drawing.Color.Silver;
            this.lblStatus.RectSize = 2;
            this.lblStatus.Size = new System.Drawing.Size(300, 41);
            this.lblStatus.TabIndex = 3434;
            this.lblStatus.Tag = "SWITCH";
            this.lblStatus.Text = "IDLE";
            this.lblStatus.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // uiButton1
            // 
            this.uiButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.uiButton1.FillColor2 = System.Drawing.Color.LightGray;
            this.uiButton1.FillColorGradient = true;
            this.uiButton1.FillDisableColor = System.Drawing.Color.WhiteSmoke;
            this.uiButton1.FillHoverColor = System.Drawing.Color.WhiteSmoke;
            this.uiButton1.FillPressColor = System.Drawing.Color.WhiteSmoke;
            this.uiButton1.FillSelectedColor = System.Drawing.Color.WhiteSmoke;
            this.uiButton1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.ForeColor = System.Drawing.Color.DimGray;
            this.uiButton1.ForeDisableColor = System.Drawing.Color.DimGray;
            this.uiButton1.ForeHoverColor = System.Drawing.Color.DimGray;
            this.uiButton1.ForePressColor = System.Drawing.Color.DimGray;
            this.uiButton1.ForeSelectedColor = System.Drawing.Color.DimGray;
            this.uiButton1.Location = new System.Drawing.Point(6, 27);
            this.uiButton1.Margin = new System.Windows.Forms.Padding(0);
            this.uiButton1.MinimumSize = new System.Drawing.Size(2, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.RectColor = System.Drawing.Color.Silver;
            this.uiButton1.RectSize = 2;
            this.uiButton1.Size = new System.Drawing.Size(300, 41);
            this.uiButton1.TabIndex = 3434;
            this.uiButton1.Tag = "SWITCH";
            this.uiButton1.Text = "IDLE";
            this.uiButton1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.statusBar.Controls.Add(this.uiLine2);
            this.statusBar.Controls.Add(this.processBar_DiskD);
            this.statusBar.Controls.Add(this.label4);
            this.statusBar.Controls.Add(this.uiSymbolButton13);
            this.statusBar.Controls.Add(this.uiLine1);
            this.statusBar.Controls.Add(this.btnLogView);
            this.statusBar.Controls.Add(this.processBar_CPU);
            this.statusBar.Controls.Add(this.label34);
            this.statusBar.Controls.Add(this.processBar_RAM);
            this.statusBar.Controls.Add(this.label33);
            this.statusBar.Controls.Add(this.processBar_DiskC);
            this.statusBar.Controls.Add(this.label7);
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.statusBar.FillColor2 = System.Drawing.Color.SlateGray;
            this.statusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBar.ForeColor = System.Drawing.Color.White;
            this.statusBar.Location = new System.Drawing.Point(0, 1031);
            this.statusBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statusBar.MinimumSize = new System.Drawing.Size(1, 1);
            this.statusBar.Name = "statusBar";
            this.statusBar.Radius = 0;
            this.statusBar.RectColor = System.Drawing.Color.Transparent;
            this.statusBar.Size = new System.Drawing.Size(1920, 30);
            this.statusBar.TabIndex = 11;
            this.statusBar.Text = "-";
            this.statusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.uiLine2.Location = new System.Drawing.Point(1660, 0);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Padding = new System.Windows.Forms.Padding(5, 8, 5, 0);
            this.uiLine2.Size = new System.Drawing.Size(20, 30);
            this.uiLine2.TabIndex = 3452;
            this.uiLine2.Text = "uiLine2";
            // 
            // processBar_DiskD
            // 
            this.processBar_DiskD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.processBar_DiskD.Font = new System.Drawing.Font("Arial", 8F);
            this.processBar_DiskD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.processBar_DiskD.Location = new System.Drawing.Point(1583, 5);
            this.processBar_DiskD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.processBar_DiskD.MinimumSize = new System.Drawing.Size(61, 1);
            this.processBar_DiskD.Name = "processBar_DiskD";
            this.processBar_DiskD.RectColor = System.Drawing.Color.White;
            this.processBar_DiskD.Size = new System.Drawing.Size(75, 20);
            this.processBar_DiskD.Style = Sunny.UI.UIStyle.Custom;
            this.processBar_DiskD.TabIndex = 3164;
            this.processBar_DiskD.Value = 90;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Arial", 8F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1559, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 3160;
            this.label4.Text = "D:\\";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton13
            // 
            this.uiSymbolButton13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton13.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiSymbolButton13.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.FillColor2 = System.Drawing.Color.SlateGray;
            this.uiSymbolButton13.FillDisableColor = System.Drawing.Color.DimGray;
            this.uiSymbolButton13.FillHoverColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton13.FillPressColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton13.FillSelectedColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton13.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiSymbolButton13.Location = new System.Drawing.Point(1680, 0);
            this.uiSymbolButton13.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton13.Name = "uiSymbolButton13";
            this.uiSymbolButton13.Radius = 0;
            this.uiSymbolButton13.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.RectHoverColor = System.Drawing.Color.White;
            this.uiSymbolButton13.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton13.Size = new System.Drawing.Size(120, 30);
            this.uiSymbolButton13.Symbol = 61502;
            this.uiSymbolButton13.TabIndex = 3451;
            this.uiSymbolButton13.Text = "Screen Capture";
            this.uiSymbolButton13.TipsFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
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
            this.uiLine1.Location = new System.Drawing.Point(1800, 0);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Padding = new System.Windows.Forms.Padding(5, 8, 5, 0);
            this.uiLine1.Size = new System.Drawing.Size(20, 30);
            this.uiLine1.TabIndex = 3450;
            this.uiLine1.Text = "uiLine1";
            // 
            // btnLogView
            // 
            this.btnLogView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogView.FillColor = System.Drawing.Color.Transparent;
            this.btnLogView.FillColor2 = System.Drawing.Color.SlateGray;
            this.btnLogView.FillDisableColor = System.Drawing.Color.DimGray;
            this.btnLogView.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnLogView.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnLogView.FillSelectedColor = System.Drawing.Color.SlateGray;
            this.btnLogView.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.btnLogView.Location = new System.Drawing.Point(1820, 0);
            this.btnLogView.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogView.Name = "btnLogView";
            this.btnLogView.Radius = 0;
            this.btnLogView.RectColor = System.Drawing.Color.Transparent;
            this.btnLogView.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnLogView.RectHoverColor = System.Drawing.Color.White;
            this.btnLogView.RectPressColor = System.Drawing.Color.Transparent;
            this.btnLogView.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnLogView.Size = new System.Drawing.Size(100, 30);
            this.btnLogView.Symbol = 261568;
            this.btnLogView.TabIndex = 3447;
            this.btnLogView.Text = "Log View";
            this.btnLogView.TipsFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogView.Click += new System.EventHandler(this.btnLogView_Click);
            // 
            // processBar_CPU
            // 
            this.processBar_CPU.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.processBar_CPU.Font = new System.Drawing.Font("Arial", 8F);
            this.processBar_CPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.processBar_CPU.Location = new System.Drawing.Point(1253, 5);
            this.processBar_CPU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.processBar_CPU.MinimumSize = new System.Drawing.Size(61, 1);
            this.processBar_CPU.Name = "processBar_CPU";
            this.processBar_CPU.RectColor = System.Drawing.Color.White;
            this.processBar_CPU.Size = new System.Drawing.Size(75, 20);
            this.processBar_CPU.Style = Sunny.UI.UIStyle.Custom;
            this.processBar_CPU.TabIndex = 3161;
            this.processBar_CPU.Value = 90;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label34.Font = new System.Drawing.Font("Arial", 8F);
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(1224, 5);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(30, 20);
            this.label34.TabIndex = 3154;
            this.label34.Text = "CPU";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // processBar_RAM
            // 
            this.processBar_RAM.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.processBar_RAM.Font = new System.Drawing.Font("Arial", 8F);
            this.processBar_RAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.processBar_RAM.Location = new System.Drawing.Point(1368, 5);
            this.processBar_RAM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.processBar_RAM.MinimumSize = new System.Drawing.Size(61, 1);
            this.processBar_RAM.Name = "processBar_RAM";
            this.processBar_RAM.RectColor = System.Drawing.Color.White;
            this.processBar_RAM.Size = new System.Drawing.Size(75, 20);
            this.processBar_RAM.Style = Sunny.UI.UIStyle.Custom;
            this.processBar_RAM.TabIndex = 3162;
            this.processBar_RAM.Value = 90;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label33.Font = new System.Drawing.Font("Arial", 8F);
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(1337, 5);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(30, 20);
            this.label33.TabIndex = 3156;
            this.label33.Text = "RAM";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // processBar_DiskC
            // 
            this.processBar_DiskC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.processBar_DiskC.Font = new System.Drawing.Font("Arial", 8F);
            this.processBar_DiskC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.processBar_DiskC.Location = new System.Drawing.Point(1473, 5);
            this.processBar_DiskC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.processBar_DiskC.MinimumSize = new System.Drawing.Size(61, 1);
            this.processBar_DiskC.Name = "processBar_DiskC";
            this.processBar_DiskC.RectColor = System.Drawing.Color.White;
            this.processBar_DiskC.Size = new System.Drawing.Size(75, 20);
            this.processBar_DiskC.Style = Sunny.UI.UIStyle.Custom;
            this.processBar_DiskC.TabIndex = 3163;
            this.processBar_DiskC.Value = 90;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial", 8F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1449, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 3158;
            this.label7.Text = "C:\\";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiPanel1
            // 
            this.uiPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.uiPanel1.Controls.Add(this.pnlMessage);
            this.uiPanel1.Controls.Add(this.lblVersion);
            this.uiPanel1.Controls.Add(this.btnMenu_Setting);
            this.uiPanel1.Controls.Add(this.uiSymbolButton1);
            this.uiPanel1.Controls.Add(this.btnMenu_Device);
            this.uiPanel1.Controls.Add(this.btnMenu_Vision);
            this.uiPanel1.Controls.Add(this.btnMenu_Model);
            this.uiPanel1.Controls.Add(this.btnMenu_Main);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPanel1.FillColor = System.Drawing.Color.Gainsboro;
            this.uiPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(103)))), ((int)(((byte)(139)))));
            this.uiPanel1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 976);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.Gainsboro;
            this.uiPanel1.Size = new System.Drawing.Size(1920, 55);
            this.uiPanel1.TabIndex = 13;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.DimGray;
            this.pnlMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessage.Controls.Add(this.uiProgressIndicator1);
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Location = new System.Drawing.Point(589, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(1124, 54);
            this.pnlMessage.TabIndex = 3252;
            // 
            // uiProgressIndicator1
            // 
            this.uiProgressIndicator1.Active = true;
            this.uiProgressIndicator1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiProgressIndicator1.Location = new System.Drawing.Point(5, 4);
            this.uiProgressIndicator1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiProgressIndicator1.Name = "uiProgressIndicator1";
            this.uiProgressIndicator1.Size = new System.Drawing.Size(45, 42);
            this.uiProgressIndicator1.Style = Sunny.UI.UIStyle.Custom;
            this.uiProgressIndicator1.TabIndex = 3238;
            this.uiProgressIndicator1.Text = "uiProgressIndicator1";
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMessage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(66, 11);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(365, 29);
            this.lblMessage.TabIndex = 3237;
            this.lblMessage.Text = "P/G Init... Please wait";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblVersion.FillColor = System.Drawing.Color.Transparent;
            this.lblVersion.FillColor2 = System.Drawing.Color.SlateGray;
            this.lblVersion.FillDisableColor = System.Drawing.Color.DimGray;
            this.lblVersion.FillHoverColor = System.Drawing.Color.DimGray;
            this.lblVersion.FillPressColor = System.Drawing.Color.DimGray;
            this.lblVersion.FillSelectedColor = System.Drawing.Color.DimGray;
            this.lblVersion.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.lblVersion.ForeColor = System.Drawing.Color.DimGray;
            this.lblVersion.ForeHoverColor = System.Drawing.Color.DimGray;
            this.lblVersion.ForePressColor = System.Drawing.Color.DimGray;
            this.lblVersion.ForeSelectedColor = System.Drawing.Color.DimGray;
            this.lblVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVersion.Location = new System.Drawing.Point(1730, 0);
            this.lblVersion.MinimumSize = new System.Drawing.Size(1, 1);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Radius = 0;
            this.lblVersion.RectColor = System.Drawing.Color.Transparent;
            this.lblVersion.RectDisableColor = System.Drawing.Color.Transparent;
            this.lblVersion.RectHoverColor = System.Drawing.Color.White;
            this.lblVersion.RectPressColor = System.Drawing.Color.Transparent;
            this.lblVersion.RectSelectedColor = System.Drawing.Color.Transparent;
            this.lblVersion.Size = new System.Drawing.Size(190, 55);
            this.lblVersion.Symbol = 62087;
            this.lblVersion.SymbolColor = System.Drawing.Color.DimGray;
            this.lblVersion.TabIndex = 3448;
            this.lblVersion.Text = "Build (yyyy.MM.dd HH:mm:ss)  ";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVersion.TipsFont = new System.Drawing.Font("Arial", 12F);
            // 
            // btnMenu_Setting
            // 
            this.btnMenu_Setting.CircleRectWidth = 0;
            this.btnMenu_Setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu_Setting.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu_Setting.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Setting.FillColor2 = System.Drawing.Color.Gray;
            this.btnMenu_Setting.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.btnMenu_Setting.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Setting.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Setting.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Setting.FillSelectedColor = System.Drawing.Color.White;
            this.btnMenu_Setting.Font = new System.Drawing.Font("Arial", 9F);
            this.btnMenu_Setting.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Setting.Location = new System.Drawing.Point(490, 0);
            this.btnMenu_Setting.Margin = new System.Windows.Forms.Padding(1);
            this.btnMenu_Setting.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMenu_Setting.Name = "btnMenu_Setting";
            this.btnMenu_Setting.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnMenu_Setting.Radius = 0;
            this.btnMenu_Setting.RectColor = System.Drawing.Color.Transparent;
            this.btnMenu_Setting.RectHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Setting.RectPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Setting.RectSelectedColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Setting.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnMenu_Setting.Size = new System.Drawing.Size(98, 55);
            this.btnMenu_Setting.Symbol = 61573;
            this.btnMenu_Setting.SymbolColor = System.Drawing.Color.Gainsboro;
            this.btnMenu_Setting.SymbolOffset = new System.Drawing.Point(0, -7);
            this.btnMenu_Setting.SymbolPressColor = System.Drawing.Color.PaleGoldenrod;
            this.btnMenu_Setting.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Setting.SymbolSize = 36;
            this.btnMenu_Setting.TabIndex = 26;
            this.btnMenu_Setting.Tag = "";
            this.btnMenu_Setting.Text = "SETTING";
            this.btnMenu_Setting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenu_Setting.TipsFont = new System.Drawing.Font("Arial", 9.75F);
            this.btnMenu_Setting.Click += new System.EventHandler(this.OnClickMenu);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.CircleRectWidth = 0;
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton1.FillColor2 = System.Drawing.Color.Gray;
            this.uiSymbolButton1.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.uiSymbolButton1.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton1.FillHoverColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton1.FillPressColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton1.FillSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton1.Font = new System.Drawing.Font("Arial", 9F);
            this.uiSymbolButton1.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton1.Location = new System.Drawing.Point(392, 0);
            this.uiSymbolButton1.Margin = new System.Windows.Forms.Padding(1);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.uiSymbolButton1.Radius = 0;
            this.uiSymbolButton1.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectHoverColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton1.RectPressColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton1.RectSelectedColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiSymbolButton1.Size = new System.Drawing.Size(98, 55);
            this.uiSymbolButton1.Symbol = 561487;
            this.uiSymbolButton1.SymbolColor = System.Drawing.Color.Gainsboro;
            this.uiSymbolButton1.SymbolOffset = new System.Drawing.Point(0, -7);
            this.uiSymbolButton1.SymbolPressColor = System.Drawing.Color.PaleGoldenrod;
            this.uiSymbolButton1.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton1.SymbolSize = 36;
            this.uiSymbolButton1.TabIndex = 28;
            this.uiSymbolButton1.Tag = "";
            this.uiSymbolButton1.Text = "HISTORY";
            this.uiSymbolButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("Arial", 9.75F);
            // 
            // btnMenu_Device
            // 
            this.btnMenu_Device.CircleRectWidth = 0;
            this.btnMenu_Device.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu_Device.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu_Device.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Device.FillColor2 = System.Drawing.Color.Gray;
            this.btnMenu_Device.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.btnMenu_Device.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Device.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Device.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Device.FillSelectedColor = System.Drawing.Color.White;
            this.btnMenu_Device.Font = new System.Drawing.Font("Arial", 9F);
            this.btnMenu_Device.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Device.Location = new System.Drawing.Point(294, 0);
            this.btnMenu_Device.Margin = new System.Windows.Forms.Padding(1);
            this.btnMenu_Device.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMenu_Device.Name = "btnMenu_Device";
            this.btnMenu_Device.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnMenu_Device.Radius = 0;
            this.btnMenu_Device.RectColor = System.Drawing.Color.Transparent;
            this.btnMenu_Device.RectHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Device.RectPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Device.RectSelectedColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Device.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnMenu_Device.Size = new System.Drawing.Size(98, 55);
            this.btnMenu_Device.Symbol = 61600;
            this.btnMenu_Device.SymbolColor = System.Drawing.Color.Gainsboro;
            this.btnMenu_Device.SymbolOffset = new System.Drawing.Point(0, -7);
            this.btnMenu_Device.SymbolPressColor = System.Drawing.Color.PaleGoldenrod;
            this.btnMenu_Device.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Device.SymbolSize = 36;
            this.btnMenu_Device.TabIndex = 24;
            this.btnMenu_Device.Tag = "";
            this.btnMenu_Device.Text = "DEVICE";
            this.btnMenu_Device.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenu_Device.TipsFont = new System.Drawing.Font("Arial", 9.75F);
            // 
            // btnMenu_Vision
            // 
            this.btnMenu_Vision.CircleRectWidth = 0;
            this.btnMenu_Vision.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu_Vision.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu_Vision.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Vision.FillColor2 = System.Drawing.Color.Gray;
            this.btnMenu_Vision.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.btnMenu_Vision.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Vision.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Vision.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Vision.FillSelectedColor = System.Drawing.Color.White;
            this.btnMenu_Vision.Font = new System.Drawing.Font("Arial", 9F);
            this.btnMenu_Vision.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Vision.Location = new System.Drawing.Point(196, 0);
            this.btnMenu_Vision.Margin = new System.Windows.Forms.Padding(1);
            this.btnMenu_Vision.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMenu_Vision.Name = "btnMenu_Vision";
            this.btnMenu_Vision.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnMenu_Vision.Radius = 0;
            this.btnMenu_Vision.RectColor = System.Drawing.Color.Transparent;
            this.btnMenu_Vision.RectHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Vision.RectPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Vision.RectSelectedColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Vision.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnMenu_Vision.Size = new System.Drawing.Size(98, 55);
            this.btnMenu_Vision.Symbol = 558371;
            this.btnMenu_Vision.SymbolColor = System.Drawing.Color.Gainsboro;
            this.btnMenu_Vision.SymbolOffset = new System.Drawing.Point(0, -7);
            this.btnMenu_Vision.SymbolPressColor = System.Drawing.Color.PaleGoldenrod;
            this.btnMenu_Vision.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Vision.SymbolSize = 36;
            this.btnMenu_Vision.TabIndex = 27;
            this.btnMenu_Vision.Tag = "";
            this.btnMenu_Vision.Text = "VISION";
            this.btnMenu_Vision.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenu_Vision.TipsFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu_Vision.Click += new System.EventHandler(this.OnClickMenu);
            // 
            // btnMenu_Model
            // 
            this.btnMenu_Model.CircleRectWidth = 0;
            this.btnMenu_Model.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu_Model.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu_Model.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Model.FillColor2 = System.Drawing.Color.Gray;
            this.btnMenu_Model.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.btnMenu_Model.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Model.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Model.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Model.FillSelectedColor = System.Drawing.Color.White;
            this.btnMenu_Model.Font = new System.Drawing.Font("Arial", 9F);
            this.btnMenu_Model.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Model.Location = new System.Drawing.Point(98, 0);
            this.btnMenu_Model.Margin = new System.Windows.Forms.Padding(1);
            this.btnMenu_Model.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMenu_Model.Name = "btnMenu_Model";
            this.btnMenu_Model.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnMenu_Model.Radius = 0;
            this.btnMenu_Model.RectColor = System.Drawing.Color.Transparent;
            this.btnMenu_Model.RectHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Model.RectPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Model.RectSelectedColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Model.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnMenu_Model.Size = new System.Drawing.Size(98, 55);
            this.btnMenu_Model.Symbol = 61474;
            this.btnMenu_Model.SymbolColor = System.Drawing.Color.Gainsboro;
            this.btnMenu_Model.SymbolOffset = new System.Drawing.Point(0, -7);
            this.btnMenu_Model.SymbolPressColor = System.Drawing.Color.PaleGoldenrod;
            this.btnMenu_Model.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Model.SymbolSize = 36;
            this.btnMenu_Model.TabIndex = 21;
            this.btnMenu_Model.Tag = "";
            this.btnMenu_Model.Text = "MODEL";
            this.btnMenu_Model.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenu_Model.TipsFont = new System.Drawing.Font("Arial", 9.75F);
            // 
            // btnMenu_Main
            // 
            this.btnMenu_Main.CircleRectWidth = 0;
            this.btnMenu_Main.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu_Main.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu_Main.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Main.FillColor2 = System.Drawing.Color.Gray;
            this.btnMenu_Main.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.btnMenu_Main.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Main.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Main.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Main.FillSelectedColor = System.Drawing.Color.White;
            this.btnMenu_Main.Font = new System.Drawing.Font("Arial", 9F);
            this.btnMenu_Main.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Main.Location = new System.Drawing.Point(0, 0);
            this.btnMenu_Main.Margin = new System.Windows.Forms.Padding(1);
            this.btnMenu_Main.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMenu_Main.Name = "btnMenu_Main";
            this.btnMenu_Main.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnMenu_Main.Radius = 0;
            this.btnMenu_Main.RectColor = System.Drawing.Color.Transparent;
            this.btnMenu_Main.RectHoverColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Main.RectPressColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Main.RectSelectedColor = System.Drawing.Color.SlateGray;
            this.btnMenu_Main.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnMenu_Main.Selected = true;
            this.btnMenu_Main.Size = new System.Drawing.Size(98, 55);
            this.btnMenu_Main.Symbol = 61704;
            this.btnMenu_Main.SymbolColor = System.Drawing.Color.Gainsboro;
            this.btnMenu_Main.SymbolOffset = new System.Drawing.Point(0, -7);
            this.btnMenu_Main.SymbolPressColor = System.Drawing.Color.PaleGoldenrod;
            this.btnMenu_Main.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnMenu_Main.SymbolSize = 36;
            this.btnMenu_Main.TabIndex = 6;
            this.btnMenu_Main.Tag = "";
            this.btnMenu_Main.Text = "MAIN";
            this.btnMenu_Main.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenu_Main.TipsFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu_Main.Click += new System.EventHandler(this.OnClickMenu);
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 500;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // pnlMainFrame
            // 
            this.pnlMainFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.pnlMainFrame.Controls.Add(this.pictureBox1);
            this.pnlMainFrame.Controls.Add(this.lbl_Mode);
            this.pnlMainFrame.Controls.Add(this.btnOper_Start);
            this.pnlMainFrame.Controls.Add(this.btnOper_Reset);
            this.pnlMainFrame.Controls.Add(this.btnOper_Pause);
            this.pnlMainFrame.Controls.Add(this.btnOper_Stop);
            this.pnlMainFrame.Controls.Add(this.uiGroupBox5);
            this.pnlMainFrame.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainFrame.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.pnlMainFrame.FillColor2 = System.Drawing.Color.SlateGray;
            this.pnlMainFrame.FillColorGradientDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlMainFrame.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlMainFrame.Location = new System.Drawing.Point(0, 30);
            this.pnlMainFrame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMainFrame.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMainFrame.Name = "pnlMainFrame";
            this.pnlMainFrame.Radius = 0;
            this.pnlMainFrame.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlMainFrame.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pnlMainFrame.Size = new System.Drawing.Size(1920, 59);
            this.pnlMainFrame.TabIndex = 11;
            this.pnlMainFrame.Text = null;
            this.pnlMainFrame.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMainFrame.Click += new System.EventHandler(this.pnlMainFrame_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3462;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Mode.ForeColor = System.Drawing.Color.White;
            this.lbl_Mode.Location = new System.Drawing.Point(59, 12);
            this.lbl_Mode.MinimumSize = new System.Drawing.Size(1, 1);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(100, 36);
            this.lbl_Mode.TabIndex = 3434;
            this.lbl_Mode.Text = "AUTO";
            // 
            // btnOper_Start
            // 
            this.btnOper_Start.CircleRectWidth = 0;
            this.btnOper_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOper_Start.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Start.FillColor2 = System.Drawing.Color.Gray;
            this.btnOper_Start.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.btnOper_Start.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Start.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnOper_Start.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnOper_Start.FillSelectedColor = System.Drawing.Color.White;
            this.btnOper_Start.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btnOper_Start.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Start.Location = new System.Drawing.Point(168, 7);
            this.btnOper_Start.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOper_Start.Name = "btnOper_Start";
            this.btnOper_Start.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnOper_Start.Radius = 4;
            this.btnOper_Start.RectColor = System.Drawing.Color.White;
            this.btnOper_Start.RectHoverColor = System.Drawing.Color.White;
            this.btnOper_Start.RectPressColor = System.Drawing.Color.White;
            this.btnOper_Start.RectSelectedColor = System.Drawing.Color.White;
            this.btnOper_Start.RectSize = 2;
            this.btnOper_Start.Size = new System.Drawing.Size(75, 45);
            this.btnOper_Start.Symbol = 61515;
            this.btnOper_Start.SymbolOffset = new System.Drawing.Point(0, -7);
            this.btnOper_Start.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Start.SymbolSize = 20;
            this.btnOper_Start.TabIndex = 13;
            this.btnOper_Start.Tag = "MAIN";
            this.btnOper_Start.Text = "START";
            this.btnOper_Start.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOper_Start.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOper_Start.Click += new System.EventHandler(this.OnClickOperation);
            // 
            // btnOper_Reset
            // 
            this.btnOper_Reset.CircleRectWidth = 0;
            this.btnOper_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOper_Reset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Reset.FillColor2 = System.Drawing.Color.Gray;
            this.btnOper_Reset.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.btnOper_Reset.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Reset.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnOper_Reset.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnOper_Reset.FillSelectedColor = System.Drawing.Color.White;
            this.btnOper_Reset.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btnOper_Reset.Location = new System.Drawing.Point(396, 7);
            this.btnOper_Reset.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOper_Reset.Name = "btnOper_Reset";
            this.btnOper_Reset.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnOper_Reset.Radius = 4;
            this.btnOper_Reset.RectColor = System.Drawing.Color.White;
            this.btnOper_Reset.RectHoverColor = System.Drawing.Color.White;
            this.btnOper_Reset.RectPressColor = System.Drawing.Color.White;
            this.btnOper_Reset.RectSelectedColor = System.Drawing.Color.White;
            this.btnOper_Reset.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.btnOper_Reset.RectSize = 2;
            this.btnOper_Reset.Size = new System.Drawing.Size(75, 45);
            this.btnOper_Reset.Symbol = 557410;
            this.btnOper_Reset.SymbolOffset = new System.Drawing.Point(0, -7);
            this.btnOper_Reset.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Reset.SymbolSize = 20;
            this.btnOper_Reset.TabIndex = 3433;
            this.btnOper_Reset.Tag = "MAIN";
            this.btnOper_Reset.Text = "RESET";
            this.btnOper_Reset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOper_Reset.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOper_Reset.Click += new System.EventHandler(this.OnClickOperation);
            // 
            // btnOper_Pause
            // 
            this.btnOper_Pause.CircleRectWidth = 0;
            this.btnOper_Pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOper_Pause.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Pause.FillColor2 = System.Drawing.Color.Gray;
            this.btnOper_Pause.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.btnOper_Pause.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Pause.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnOper_Pause.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnOper_Pause.FillSelectedColor = System.Drawing.Color.White;
            this.btnOper_Pause.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btnOper_Pause.Location = new System.Drawing.Point(244, 7);
            this.btnOper_Pause.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOper_Pause.Name = "btnOper_Pause";
            this.btnOper_Pause.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnOper_Pause.Radius = 4;
            this.btnOper_Pause.RectColor = System.Drawing.Color.White;
            this.btnOper_Pause.RectHoverColor = System.Drawing.Color.White;
            this.btnOper_Pause.RectPressColor = System.Drawing.Color.White;
            this.btnOper_Pause.RectSelectedColor = System.Drawing.Color.White;
            this.btnOper_Pause.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.btnOper_Pause.RectSize = 2;
            this.btnOper_Pause.Size = new System.Drawing.Size(75, 45);
            this.btnOper_Pause.Symbol = 61516;
            this.btnOper_Pause.SymbolOffset = new System.Drawing.Point(0, -7);
            this.btnOper_Pause.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Pause.SymbolSize = 20;
            this.btnOper_Pause.TabIndex = 15;
            this.btnOper_Pause.Tag = "MAIN";
            this.btnOper_Pause.Text = "PAUSE";
            this.btnOper_Pause.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOper_Pause.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOper_Pause.Click += new System.EventHandler(this.OnClickOperation);
            // 
            // btnOper_Stop
            // 
            this.btnOper_Stop.CircleRectWidth = 0;
            this.btnOper_Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOper_Stop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Stop.FillColor2 = System.Drawing.Color.Gray;
            this.btnOper_Stop.FillColorGradientDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.btnOper_Stop.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Stop.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnOper_Stop.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnOper_Stop.FillSelectedColor = System.Drawing.Color.White;
            this.btnOper_Stop.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btnOper_Stop.Location = new System.Drawing.Point(320, 7);
            this.btnOper_Stop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOper_Stop.Name = "btnOper_Stop";
            this.btnOper_Stop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnOper_Stop.Radius = 4;
            this.btnOper_Stop.RectColor = System.Drawing.Color.White;
            this.btnOper_Stop.RectHoverColor = System.Drawing.Color.White;
            this.btnOper_Stop.RectPressColor = System.Drawing.Color.White;
            this.btnOper_Stop.RectSelectedColor = System.Drawing.Color.White;
            this.btnOper_Stop.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.btnOper_Stop.RectSize = 2;
            this.btnOper_Stop.Size = new System.Drawing.Size(75, 45);
            this.btnOper_Stop.Symbol = 61517;
            this.btnOper_Stop.SymbolOffset = new System.Drawing.Point(0, -7);
            this.btnOper_Stop.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnOper_Stop.SymbolSize = 20;
            this.btnOper_Stop.TabIndex = 3432;
            this.btnOper_Stop.Tag = "MAIN";
            this.btnOper_Stop.Text = "STOP";
            this.btnOper_Stop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOper_Stop.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOper_Stop.Click += new System.EventHandler(this.OnClickOperation);
            // 
            // uiGroupBox5
            // 
            this.uiGroupBox5.Controls.Add(this.panel17);
            this.uiGroupBox5.Controls.Add(this.uiSymbolButton2);
            this.uiGroupBox5.Controls.Add(this.panel16);
            this.uiGroupBox5.Controls.Add(this.panel15);
            this.uiGroupBox5.Controls.Add(this.panel4);
            this.uiGroupBox5.Controls.Add(this.panel14);
            this.uiGroupBox5.Controls.Add(this.panel6);
            this.uiGroupBox5.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox5.FillColor2 = System.Drawing.Color.Transparent;
            this.uiGroupBox5.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.uiGroupBox5.ForeColor = System.Drawing.Color.White;
            this.uiGroupBox5.Location = new System.Drawing.Point(1481, -9);
            this.uiGroupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox5.Name = "uiGroupBox5";
            this.uiGroupBox5.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox5.RectColor = System.Drawing.Color.White;
            this.uiGroupBox5.Size = new System.Drawing.Size(436, 62);
            this.uiGroupBox5.TabIndex = 3452;
            this.uiGroupBox5.Text = null;
            this.uiGroupBox5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.label37);
            this.panel17.Controls.Add(this.statusCamera);
            this.panel17.Location = new System.Drawing.Point(7, 20);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(108, 18);
            this.panel17.TabIndex = 3443;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Dock = System.Windows.Forms.DockStyle.Left;
            this.label37.Font = new System.Drawing.Font("Arial", 8F);
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(18, 0);
            this.label37.Name = "label37";
            this.label37.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label37.Size = new System.Drawing.Size(49, 16);
            this.label37.TabIndex = 3449;
            this.label37.Text = "Camera";
            // 
            // statusCamera
            // 
            this.statusCamera.Color = System.Drawing.Color.LimeGreen;
            this.statusCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusCamera.Location = new System.Drawing.Point(0, 0);
            this.statusCamera.Name = "statusCamera";
            this.statusCamera.On = false;
            this.statusCamera.Size = new System.Drawing.Size(18, 18);
            this.statusCamera.TabIndex = 3448;
            this.statusCamera.Text = "uiLedBulb25";
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.CircleRectWidth = 0;
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(110)))));
            this.uiSymbolButton2.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.FillHoverColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton2.FillPressColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton2.FillSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiSymbolButton2.Location = new System.Drawing.Point(355, 21);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.uiSymbolButton2.Radius = 4;
            this.uiSymbolButton2.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton2.RectHoverColor = System.Drawing.Color.White;
            this.uiSymbolButton2.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton2.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.uiSymbolButton2.RectSize = 2;
            this.uiSymbolButton2.Size = new System.Drawing.Size(75, 35);
            this.uiSymbolButton2.Symbol = 61473;
            this.uiSymbolButton2.SymbolOffset = new System.Drawing.Point(0, -7);
            this.uiSymbolButton2.SymbolSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton2.SymbolSize = 16;
            this.uiSymbolButton2.TabIndex = 3449;
            this.uiSymbolButton2.Tag = "MAIN";
            this.uiSymbolButton2.Text = "RE-INIT";
            this.uiSymbolButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.label36);
            this.panel16.Controls.Add(this.uiLedBulb24);
            this.panel16.Location = new System.Drawing.Point(7, 40);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(108, 18);
            this.panel16.TabIndex = 3444;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Dock = System.Windows.Forms.DockStyle.Left;
            this.label36.Font = new System.Drawing.Font("Arial", 8F);
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(18, 0);
            this.label36.Name = "label36";
            this.label36.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label36.Size = new System.Drawing.Size(84, 16);
            this.label36.TabIndex = 3449;
            this.label36.Text = "Light Controller";
            // 
            // uiLedBulb24
            // 
            this.uiLedBulb24.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb24.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLedBulb24.Location = new System.Drawing.Point(0, 0);
            this.uiLedBulb24.Name = "uiLedBulb24";
            this.uiLedBulb24.On = false;
            this.uiLedBulb24.Size = new System.Drawing.Size(18, 18);
            this.uiLedBulb24.TabIndex = 3448;
            this.uiLedBulb24.Text = "uiLedBulb24";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label35);
            this.panel15.Controls.Add(this.uiLedBulb23);
            this.panel15.Location = new System.Drawing.Point(124, 20);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(108, 18);
            this.panel15.TabIndex = 3445;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Dock = System.Windows.Forms.DockStyle.Left;
            this.label35.Font = new System.Drawing.Font("Arial", 8F);
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(18, 0);
            this.label35.Name = "label35";
            this.label35.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label35.Size = new System.Drawing.Size(25, 16);
            this.label35.TabIndex = 3449;
            this.label35.Text = "I/O";
            // 
            // uiLedBulb23
            // 
            this.uiLedBulb23.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb23.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLedBulb23.Location = new System.Drawing.Point(0, 0);
            this.uiLedBulb23.Name = "uiLedBulb23";
            this.uiLedBulb23.On = false;
            this.uiLedBulb23.Size = new System.Drawing.Size(18, 18);
            this.uiLedBulb23.TabIndex = 3448;
            this.uiLedBulb23.Text = "uiLedBulb23";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.uiLedBulb20);
            this.panel4.Location = new System.Drawing.Point(241, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(108, 18);
            this.panel4.TabIndex = 3448;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Arial", 8F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 3449;
            this.label5.Text = "EYE-D (Server)";
            // 
            // uiLedBulb20
            // 
            this.uiLedBulb20.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb20.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLedBulb20.Location = new System.Drawing.Point(0, 0);
            this.uiLedBulb20.Name = "uiLedBulb20";
            this.uiLedBulb20.On = false;
            this.uiLedBulb20.Size = new System.Drawing.Size(18, 18);
            this.uiLedBulb20.TabIndex = 3448;
            this.uiLedBulb20.Text = "uiLedBulb20";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label12);
            this.panel14.Controls.Add(this.uiLedBulb22);
            this.panel14.Location = new System.Drawing.Point(124, 40);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(108, 18);
            this.panel14.TabIndex = 3446;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Arial", 8F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(18, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 3449;
            this.label12.Text = "Loader";
            // 
            // uiLedBulb22
            // 
            this.uiLedBulb22.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb22.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLedBulb22.Location = new System.Drawing.Point(0, 0);
            this.uiLedBulb22.Name = "uiLedBulb22";
            this.uiLedBulb22.On = false;
            this.uiLedBulb22.Size = new System.Drawing.Size(18, 18);
            this.uiLedBulb22.TabIndex = 3448;
            this.uiLedBulb22.Text = "uiLedBulb22";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.uiLedBulb21);
            this.panel6.Location = new System.Drawing.Point(241, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(108, 18);
            this.panel6.TabIndex = 3447;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Arial", 8F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 3449;
            this.label6.Text = "MES";
            // 
            // uiLedBulb21
            // 
            this.uiLedBulb21.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb21.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLedBulb21.Location = new System.Drawing.Point(0, 0);
            this.uiLedBulb21.Name = "uiLedBulb21";
            this.uiLedBulb21.On = false;
            this.uiLedBulb21.Size = new System.Drawing.Size(18, 18);
            this.uiLedBulb21.TabIndex = 3448;
            this.uiLedBulb21.Text = "uiLedBulb21";
            // 
            // uiPanel3
            // 
            this.uiPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiPanel3.Controls.Add(this.lblModelName);
            this.uiPanel3.Controls.Add(this.lblRunState);
            this.uiPanel3.Controls.Add(this.btnAuthorization);
            this.uiPanel3.Controls.Add(this.lbl_DateTime);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiPanel3.FillColor2 = System.Drawing.Color.SlateGray;
            this.uiPanel3.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.uiPanel3.ForeColor = System.Drawing.Color.White;
            this.uiPanel3.Location = new System.Drawing.Point(0, 89);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Radius = 0;
            this.uiPanel3.RectColor = System.Drawing.Color.Transparent;
            this.uiPanel3.Size = new System.Drawing.Size(1920, 25);
            this.uiPanel3.TabIndex = 10;
            this.uiPanel3.Text = null;
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Arial", 10F);
            this.lblModelName.ForeColor = System.Drawing.Color.White;
            this.lblModelName.Location = new System.Drawing.Point(401, 4);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblModelName.Size = new System.Drawing.Size(97, 16);
            this.lblModelName.TabIndex = 3456;
            this.lblModelName.Text = "Model : IDLE";
            this.lblModelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRunState
            // 
            this.lblRunState.AutoSize = true;
            this.lblRunState.Font = new System.Drawing.Font("Arial", 10F);
            this.lblRunState.ForeColor = System.Drawing.Color.White;
            this.lblRunState.Location = new System.Drawing.Point(65, 4);
            this.lblRunState.Name = "lblRunState";
            this.lblRunState.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRunState.Size = new System.Drawing.Size(122, 16);
            this.lblRunState.TabIndex = 3455;
            this.lblRunState.Text = "Run State : IDLE";
            this.lblRunState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAuthorization
            // 
            this.btnAuthorization.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuthorization.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAuthorization.FillColor = System.Drawing.Color.Transparent;
            this.btnAuthorization.FillColor2 = System.Drawing.Color.SlateGray;
            this.btnAuthorization.FillDisableColor = System.Drawing.Color.DimGray;
            this.btnAuthorization.FillHoverColor = System.Drawing.Color.SlateGray;
            this.btnAuthorization.FillPressColor = System.Drawing.Color.SlateGray;
            this.btnAuthorization.FillSelectedColor = System.Drawing.Color.SlateGray;
            this.btnAuthorization.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.btnAuthorization.Location = new System.Drawing.Point(1576, 0);
            this.btnAuthorization.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAuthorization.Name = "btnAuthorization";
            this.btnAuthorization.Radius = 0;
            this.btnAuthorization.RectColor = System.Drawing.Color.Transparent;
            this.btnAuthorization.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnAuthorization.RectHoverColor = System.Drawing.Color.White;
            this.btnAuthorization.RectPressColor = System.Drawing.Color.Transparent;
            this.btnAuthorization.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnAuthorization.Size = new System.Drawing.Size(224, 25);
            this.btnAuthorization.Symbol = 62142;
            this.btnAuthorization.SymbolSize = 20;
            this.btnAuthorization.TabIndex = 3447;
            this.btnAuthorization.Text = "LOGIN [OPERATOR / ID : 0000]";
            this.btnAuthorization.TipsFont = new System.Drawing.Font("Arial", 12F);
            // 
            // lbl_DateTime
            // 
            this.lbl_DateTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_DateTime.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_DateTime.ForeColor = System.Drawing.Color.White;
            this.lbl_DateTime.Location = new System.Drawing.Point(1800, 0);
            this.lbl_DateTime.Name = "lbl_DateTime";
            this.lbl_DateTime.Size = new System.Drawing.Size(120, 25);
            this.lbl_DateTime.TabIndex = 3443;
            this.lbl_DateTime.Text = "0000-00-00 00:00:00";
            this.lbl_DateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogViewer
            // 
            this.pnlLogViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.pnlLogViewer.Controls.Add(this.checkBox5);
            this.pnlLogViewer.Controls.Add(this.checkBox4);
            this.pnlLogViewer.Controls.Add(this.checkBox3);
            this.pnlLogViewer.Controls.Add(this.checkBox2);
            this.pnlLogViewer.Controls.Add(this.checkBox1);
            this.pnlLogViewer.Controls.Add(this.uiPanel4);
            this.pnlLogViewer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlLogViewer.FillColor2 = System.Drawing.Color.Silver;
            this.pnlLogViewer.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlLogViewer.Location = new System.Drawing.Point(1412, 115);
            this.pnlLogViewer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLogViewer.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlLogViewer.Name = "pnlLogViewer";
            this.pnlLogViewer.Radius = 0;
            this.pnlLogViewer.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlLogViewer.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pnlLogViewer.Size = new System.Drawing.Size(506, 857);
            this.pnlLogViewer.TabIndex = 16;
            this.pnlLogViewer.Text = null;
            this.pnlLogViewer.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.Color.Transparent;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox5.ForeColor = System.Drawing.Color.White;
            this.checkBox5.Location = new System.Drawing.Point(242, 7);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 18);
            this.checkBox5.TabIndex = 3471;
            this.checkBox5.Text = "Abnromal";
            this.checkBox5.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.Transparent;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox4.ForeColor = System.Drawing.Color.White;
            this.checkBox4.Location = new System.Drawing.Point(182, 8);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(54, 18);
            this.checkBox4.TabIndex = 3470;
            this.checkBox4.Text = "Alarm";
            this.checkBox4.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox3.ForeColor = System.Drawing.Color.White;
            this.checkBox3.Location = new System.Drawing.Point(131, 7);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(45, 18);
            this.checkBox3.TabIndex = 3469;
            this.checkBox3.Text = "Seq";
            this.checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(72, 7);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 18);
            this.checkBox2.TabIndex = 3468;
            this.checkBox2.Text = "Comm";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 8F);
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(7, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 18);
            this.checkBox1.TabIndex = 3467;
            this.checkBox1.Text = "Normal";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // uiPanel4
            // 
            this.uiPanel4.Controls.Add(this.pnlLog);
            this.uiPanel4.Controls.Add(this.uiPanel5);
            this.uiPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel4.Location = new System.Drawing.Point(5, 30);
            this.uiPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel4.Name = "uiPanel4";
            this.uiPanel4.Size = new System.Drawing.Size(497, 821);
            this.uiPanel4.TabIndex = 3466;
            this.uiPanel4.Text = null;
            this.uiPanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLog
            // 
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlLog.Location = new System.Drawing.Point(0, 20);
            this.pnlLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLog.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.pnlLog.Size = new System.Drawing.Size(497, 801);
            this.pnlLog.TabIndex = 3464;
            this.pnlLog.Text = "uiPanel3";
            this.pnlLog.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel5
            // 
            this.uiPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiPanel5.Controls.Add(this.label8);
            this.uiPanel5.Controls.Add(this.btnOpenLogFolder);
            this.uiPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiPanel5.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiPanel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPanel5.Location = new System.Drawing.Point(0, 0);
            this.uiPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel5.Name = "uiPanel5";
            this.uiPanel5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiPanel5.Size = new System.Drawing.Size(497, 20);
            this.uiPanel5.TabIndex = 0;
            this.uiPanel5.Text = null;
            this.uiPanel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Log";
            // 
            // btnOpenLogFolder
            // 
            this.btnOpenLogFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenLogFolder.FillColor = System.Drawing.Color.Transparent;
            this.btnOpenLogFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOpenLogFolder.Location = new System.Drawing.Point(460, -2);
            this.btnOpenLogFolder.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOpenLogFolder.Name = "btnOpenLogFolder";
            this.btnOpenLogFolder.RectColor = System.Drawing.Color.Transparent;
            this.btnOpenLogFolder.Size = new System.Drawing.Size(29, 28);
            this.btnOpenLogFolder.Style = Sunny.UI.UIStyle.Custom;
            this.btnOpenLogFolder.Symbol = 61564;
            this.btnOpenLogFolder.TabIndex = 0;
            this.btnOpenLogFolder.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // timerInit
            // 
            this.timerInit.Tick += new System.EventHandler(this.timerInit_Tick);
            // 
            // pnlMDI
            // 
            this.pnlMDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMDI.FillColor = System.Drawing.Color.White;
            this.pnlMDI.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlMDI.FillColorGradient = true;
            this.pnlMDI.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlMDI.Location = new System.Drawing.Point(0, 114);
            this.pnlMDI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMDI.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMDI.Name = "pnlMDI";
            this.pnlMDI.Radius = 0;
            this.pnlMDI.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlMDI.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pnlMDI.Size = new System.Drawing.Size(1920, 862);
            this.pnlMDI.TabIndex = 18;
            this.pnlMDI.Text = null;
            this.pnlMDI.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_MainFrame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1061);
            this.Controls.Add(this.pnlLogViewer);
            this.Controls.Add(this.pnlMDI);
            this.Controls.Add(this.uiPanel3);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.pnlMainFrame);
            this.Controls.Add(this.pnlTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "Form_MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form_MainFrame_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.pnlMainFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.uiGroupBox5.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.uiPanel3.ResumeLayout(false);
            this.uiPanel3.PerformLayout();
            this.pnlLogViewer.ResumeLayout(false);
            this.pnlLogViewer.PerformLayout();
            this.uiPanel4.ResumeLayout(false);
            this.uiPanel5.ResumeLayout(false);
            this.uiPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnMinimize;
        private Sunny.UI.UISymbolButton btnClose;
        private Sunny.UI.UIPanel statusBar;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton btnMenu_Main;
        private System.Windows.Forms.Timer timerStatus;
        private Sunny.UI.UISymbolButton btnMenu_Model;
        private Sunny.UI.UISymbolButton btnMenu_Device;
        private Sunny.UI.UISymbolButton btnMenu_Setting;
        public Sunny.UI.UIButton lblStatus;
        public Sunny.UI.UIButton uiButton1;
        private Panel panel3;
        private Label label3;
        private Sunny.UI.UILedBulb uiLedBulb3;
        private Panel panel2;
        private Label label2;
        private Sunny.UI.UILedBulb bulbLicense;
        private Panel panel1;
        private Label label1;
        private Sunny.UI.UILedBulb bulbCamera;
        private Sunny.UI.UIPanel pnlMainFrame;
        private Sunny.UI.UISymbolButton btnOper_Reset;
        private Sunny.UI.UISymbolButton btnOper_Start;
        private Sunny.UI.UISymbolButton btnOper_Stop;
        private Sunny.UI.UISymbolButton btnOper_Pause;
        private Sunny.UI.UIPanel uiPanel3;
        private Label lbl_DateTime;
        private Sunny.UI.UILedLabel lbl_Mode;
        private Sunny.UI.UISymbolButton uiSymbolButton13;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UISymbolButton btnLogView;
        private Sunny.UI.UISymbolButton btnAuthorization;
        private Sunny.UI.UISymbolButton btnMenu_Vision;
        private Sunny.UI.UIProcessBar processBar_DiskD;
        private Label label4;
        private Panel panel17;
        private Label label37;
        private Sunny.UI.UILedBulb statusCamera;
        private Panel panel4;
        private Label label5;
        private Sunny.UI.UILedBulb uiLedBulb20;
        private Panel panel16;
        private Label label36;
        private Sunny.UI.UILedBulb uiLedBulb24;
        private Panel panel6;
        private Label label6;
        private Sunny.UI.UILedBulb uiLedBulb21;
        private Panel panel15;
        private Label label35;
        private Sunny.UI.UILedBulb uiLedBulb23;
        private Sunny.UI.UIProcessBar processBar_DiskC;
        private Label label34;
        private Label label7;
        private Label label33;
        private Sunny.UI.UIProcessBar processBar_CPU;
        private Sunny.UI.UIProcessBar processBar_RAM;
        private Panel panel14;
        private Label label12;
        private Sunny.UI.UILedBulb uiLedBulb22;
        private Label lblModelName;
        private Label lblRunState;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UIPanel pnlLogViewer;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Sunny.UI.UIPanel uiPanel4;
        private Sunny.UI.UIPanel pnlLog;
        private Sunny.UI.UIPanel uiPanel5;
        private Label label8;
        private Sunny.UI.UISymbolButton btnOpenLogFolder;
        private Sunny.UI.UISymbolButton lblVersion;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private PictureBox pictureBox1;
        private Sunny.UI.UIGroupBox uiGroupBox5;
        private Label label11;
        private Panel pnlMessage;
        private Sunny.UI.UIProgressIndicator uiProgressIndicator1;
        private Label lblMessage;
        private Timer timerInit;
        private Sunny.UI.UIPanel pnlMDI;
    }
}