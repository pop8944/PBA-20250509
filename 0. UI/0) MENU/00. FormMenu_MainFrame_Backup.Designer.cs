using System;

namespace IntelligentFactory
{
    partial class FormMenu_MainFrame_Backup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu_MainFrame));
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.timerAlarmWarning = new System.Windows.Forms.Timer(this.components);
            this.timerConnection = new System.Windows.Forms.Timer(this.components);
            this.timerAlarm = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnMDI = new System.Windows.Forms.Panel();
            this.btnMenuModel = new System.Windows.Forms.Button();
            this.btnMenuVisionTeaching = new System.Windows.Forms.Button();
            this.btnMenuIO = new System.Windows.Forms.Button();
            this.btnMenuMain = new System.Windows.Forms.Button();
            this.btnMenuSetting = new System.Windows.Forms.Button();
            this.btnMenuAuthorization = new System.Windows.Forms.Button();
            this.btnMenuRMS = new System.Windows.Forms.Button();
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.lbAuthorization = new Sunny.UI.UIButton();
            this.uiSymbolButton4 = new Sunny.UI.UISymbolButton();
            this.btnLogin = new Sunny.UI.UIAvatar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.btnClose = new Sunny.UI.UISymbolButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAutoStart = new Sunny.UI.UISymbolButton();
            this.lblSeqStatus = new System.Windows.Forms.Label();
            this.btnCountReset = new System.Windows.Forms.Button();
            this.processBar_TrainImage = new System.Windows.Forms.ProgressBar();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.uiSymbolButton3 = new Sunny.UI.UISymbolButton();
            this.lblNotice = new System.Windows.Forms.Label();
            this.statusEyeD = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.statusARC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusLicense = new System.Windows.Forms.Label();
            this.btnScreenCapture = new Sunny.UI.UISymbolButton();
            this.picCountry = new System.Windows.Forms.PictureBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.comboCountry = new MetroFramework.Controls.MetroComboBox();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.label4 = new System.Windows.Forms.Label();
            this.statusBuffer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusIO = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusLightController = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.statusCamera = new System.Windows.Forms.Label();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCountReset_M = new System.Windows.Forms.Button();
            this.lbYield_M = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbNG_M = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbOK_M = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbTotal_M = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlRecipeLoading = new System.Windows.Forms.Panel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.lblRecipeLoading = new Sunny.UI.UILabel();
            this.lblStopReason = new Sunny.UI.UILedLabel();
            this.lbRecipeName = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbCountYield = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbCountNG_F = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbCountOK = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCountTOTAL = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.pnlAlarm = new System.Windows.Forms.Panel();
            this.btnAlarmReset = new Sunny.UI.UISymbolButton();
            this.lblAlarm = new Sunny.UI.UILedLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCountry)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlRecipeLoading.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlAlarm.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 300;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // timerAlarmWarning
            // 
            this.timerAlarmWarning.Enabled = true;
            // 
            // timerConnection
            // 
            this.timerConnection.Enabled = true;
            this.timerConnection.Interval = 1000;
            this.timerConnection.Tick += new System.EventHandler(this.timerConnection_Tick);
            // 
            // timerAlarm
            // 
            this.timerAlarm.Enabled = true;
            this.timerAlarm.Interval = 1000;
            this.timerAlarm.Tick += new System.EventHandler(this.timerAlarm_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::IntelligentFactory.Properties.Resources.IF_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1236;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // pnMDI
            // 
            this.pnMDI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnMDI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnMDI.Location = new System.Drawing.Point(85, 118);
            this.pnMDI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnMDI.Name = "pnMDI";
            this.pnMDI.Size = new System.Drawing.Size(1835, 909);
            this.pnMDI.TabIndex = 1258;
            // 
            // btnMenuModel
            // 
            this.btnMenuModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMenuModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuModel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuModel.ForeColor = System.Drawing.Color.White;
            this.btnMenuModel.Image = global::IntelligentFactory.Properties.Resources.Model50_Normal;
            this.btnMenuModel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuModel.Location = new System.Drawing.Point(0, 170);
            this.btnMenuModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenuModel.Name = "btnMenuModel";
            this.btnMenuModel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnMenuModel.Size = new System.Drawing.Size(85, 85);
            this.btnMenuModel.TabIndex = 2569;
            this.btnMenuModel.Text = "MODEL";
            this.btnMenuModel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuModel.UseVisualStyleBackColor = false;
            this.btnMenuModel.Click += new System.EventHandler(this.OnMenuClick);
            this.btnMenuModel.MouseLeave += new System.EventHandler(this.btnMenuModel_MouseLeave);
            this.btnMenuModel.MouseHover += new System.EventHandler(this.btnMenuModel_MouseHover);
            // 
            // btnMenuVisionTeaching
            // 
            this.btnMenuVisionTeaching.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMenuVisionTeaching.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuVisionTeaching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuVisionTeaching.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuVisionTeaching.ForeColor = System.Drawing.Color.White;
            this.btnMenuVisionTeaching.Image = global::IntelligentFactory.Properties.Resources.Vision50_Normal;
            this.btnMenuVisionTeaching.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuVisionTeaching.Location = new System.Drawing.Point(0, 255);
            this.btnMenuVisionTeaching.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenuVisionTeaching.Name = "btnMenuVisionTeaching";
            this.btnMenuVisionTeaching.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnMenuVisionTeaching.Size = new System.Drawing.Size(85, 85);
            this.btnMenuVisionTeaching.TabIndex = 2570;
            this.btnMenuVisionTeaching.Text = "VISION";
            this.btnMenuVisionTeaching.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuVisionTeaching.UseVisualStyleBackColor = false;
            this.btnMenuVisionTeaching.Click += new System.EventHandler(this.OnMenuClick);
            this.btnMenuVisionTeaching.MouseLeave += new System.EventHandler(this.btnMenuVisionTeaching_MouseLeave);
            this.btnMenuVisionTeaching.MouseHover += new System.EventHandler(this.btnMenuVisionTeaching_MouseHover);
            // 
            // btnMenuIO
            // 
            this.btnMenuIO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMenuIO.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuIO.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuIO.ForeColor = System.Drawing.Color.White;
            this.btnMenuIO.Image = global::IntelligentFactory.Properties.Resources.DIO50_Normal;
            this.btnMenuIO.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuIO.Location = new System.Drawing.Point(0, 340);
            this.btnMenuIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenuIO.Name = "btnMenuIO";
            this.btnMenuIO.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnMenuIO.Size = new System.Drawing.Size(85, 85);
            this.btnMenuIO.TabIndex = 2571;
            this.btnMenuIO.Text = "DI/DO";
            this.btnMenuIO.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuIO.UseVisualStyleBackColor = false;
            this.btnMenuIO.Click += new System.EventHandler(this.OnMenuClick);
            this.btnMenuIO.MouseLeave += new System.EventHandler(this.btnMenuIO_MouseLeave);
            this.btnMenuIO.MouseHover += new System.EventHandler(this.btnMenuIO_MouseHover);
            // 
            // btnMenuMain
            // 
            this.btnMenuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMenuMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuMain.ForeColor = System.Drawing.Color.White;
            this.btnMenuMain.Image = global::IntelligentFactory.Properties.Resources.Home50_Normal;
            this.btnMenuMain.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuMain.Location = new System.Drawing.Point(0, 85);
            this.btnMenuMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenuMain.Name = "btnMenuMain";
            this.btnMenuMain.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnMenuMain.Size = new System.Drawing.Size(85, 85);
            this.btnMenuMain.TabIndex = 2572;
            this.btnMenuMain.Text = "MAIN";
            this.btnMenuMain.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuMain.UseVisualStyleBackColor = false;
            this.btnMenuMain.Click += new System.EventHandler(this.OnMenuClick);
            this.btnMenuMain.MouseLeave += new System.EventHandler(this.btnMenuMain_MouseLeave);
            this.btnMenuMain.MouseHover += new System.EventHandler(this.btnMenuMain_MouseHover);
            // 
            // btnMenuSetting
            // 
            this.btnMenuSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMenuSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSetting.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSetting.ForeColor = System.Drawing.Color.White;
            this.btnMenuSetting.Image = global::IntelligentFactory.Properties.Resources.Setting50_Normal;
            this.btnMenuSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuSetting.Location = new System.Drawing.Point(0, 510);
            this.btnMenuSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenuSetting.Name = "btnMenuSetting";
            this.btnMenuSetting.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnMenuSetting.Size = new System.Drawing.Size(85, 85);
            this.btnMenuSetting.TabIndex = 2573;
            this.btnMenuSetting.Text = "SETTINGS";
            this.btnMenuSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuSetting.UseVisualStyleBackColor = false;
            this.btnMenuSetting.Click += new System.EventHandler(this.OnMenuClick);
            this.btnMenuSetting.MouseLeave += new System.EventHandler(this.btnMenuSetting_MouseLeave);
            this.btnMenuSetting.MouseHover += new System.EventHandler(this.btnMenuSetting_MouseHover);
            // 
            // btnMenuAuthorization
            // 
            this.btnMenuAuthorization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMenuAuthorization.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuAuthorization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAuthorization.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAuthorization.ForeColor = System.Drawing.Color.White;
            this.btnMenuAuthorization.Image = global::IntelligentFactory.Properties.Resources.Login50_Normal;
            this.btnMenuAuthorization.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuAuthorization.Location = new System.Drawing.Point(0, 595);
            this.btnMenuAuthorization.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenuAuthorization.Name = "btnMenuAuthorization";
            this.btnMenuAuthorization.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnMenuAuthorization.Size = new System.Drawing.Size(85, 85);
            this.btnMenuAuthorization.TabIndex = 2574;
            this.btnMenuAuthorization.Text = "LOGIN";
            this.btnMenuAuthorization.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuAuthorization.UseVisualStyleBackColor = false;
            this.btnMenuAuthorization.Visible = false;
            this.btnMenuAuthorization.Click += new System.EventHandler(this.OnMenuClick);
            this.btnMenuAuthorization.MouseLeave += new System.EventHandler(this.btnMenuAuthorization_MouseLeave);
            this.btnMenuAuthorization.MouseHover += new System.EventHandler(this.btnMenuAuthorization_MouseHover);
            // 
            // btnMenuRMS
            // 
            this.btnMenuRMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMenuRMS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuRMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuRMS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuRMS.ForeColor = System.Drawing.Color.White;
            this.btnMenuRMS.Image = global::IntelligentFactory.Properties.Resources.RMS50_Normal;
            this.btnMenuRMS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuRMS.Location = new System.Drawing.Point(0, 425);
            this.btnMenuRMS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenuRMS.Name = "btnMenuRMS";
            this.btnMenuRMS.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnMenuRMS.Size = new System.Drawing.Size(85, 85);
            this.btnMenuRMS.TabIndex = 2575;
            this.btnMenuRMS.Text = "RMS";
            this.btnMenuRMS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuRMS.UseVisualStyleBackColor = false;
            this.btnMenuRMS.Click += new System.EventHandler(this.OnMenuClick);
            this.btnMenuRMS.MouseLeave += new System.EventHandler(this.btnMenuRMS_MouseLeave);
            this.btnMenuRMS.MouseHover += new System.EventHandler(this.btnMenuRMS_MouseHover);
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnl_Menu.Controls.Add(this.lbAuthorization);
            this.pnl_Menu.Controls.Add(this.uiSymbolButton4);
            this.pnl_Menu.Controls.Add(this.btnLogin);
            this.pnl_Menu.Controls.Add(this.btnMenuAuthorization);
            this.pnl_Menu.Controls.Add(this.btnMenuSetting);
            this.pnl_Menu.Controls.Add(this.btnMenuRMS);
            this.pnl_Menu.Controls.Add(this.btnMenuIO);
            this.pnl_Menu.Controls.Add(this.btnMenuVisionTeaching);
            this.pnl_Menu.Controls.Add(this.btnMenuModel);
            this.pnl_Menu.Controls.Add(this.btnMenuMain);
            this.pnl_Menu.Controls.Add(this.pictureBox1);
            this.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(85, 1027);
            this.pnl_Menu.TabIndex = 3181;
            // 
            // lbAuthorization
            // 
            this.lbAuthorization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbAuthorization.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAuthorization.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbAuthorization.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lbAuthorization.ForeColor = System.Drawing.Color.DimGray;
            this.lbAuthorization.Location = new System.Drawing.Point(3, 980);
            this.lbAuthorization.MinimumSize = new System.Drawing.Size(1, 1);
            this.lbAuthorization.Name = "lbAuthorization";
            this.lbAuthorization.RectColor = System.Drawing.Color.DimGray;
            this.lbAuthorization.Size = new System.Drawing.Size(80, 22);
            this.lbAuthorization.Style = Sunny.UI.UIStyle.Custom;
            this.lbAuthorization.TabIndex = 3252;
            this.lbAuthorization.Text = "OPERATOR";
            this.lbAuthorization.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton4
            // 
            this.uiSymbolButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.Font = new System.Drawing.Font("Arial", 8F);
            this.uiSymbolButton4.ForeColor = System.Drawing.Color.Silver;
            this.uiSymbolButton4.ForeDisableColor = System.Drawing.Color.Silver;
            this.uiSymbolButton4.ForeSelectedColor = System.Drawing.Color.Silver;
            this.uiSymbolButton4.Location = new System.Drawing.Point(0, 1003);
            this.uiSymbolButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uiSymbolButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton4.Name = "uiSymbolButton4";
            this.uiSymbolButton4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.uiSymbolButton4.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton4.Size = new System.Drawing.Size(84, 24);
            this.uiSymbolButton4.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton4.StyleCustomMode = true;
            this.uiSymbolButton4.Symbol = 61501;
            this.uiSymbolButton4.SymbolColor = System.Drawing.Color.Silver;
            this.uiSymbolButton4.SymbolDisableColor = System.Drawing.Color.Silver;
            this.uiSymbolButton4.SymbolSelectedColor = System.Drawing.Color.Silver;
            this.uiSymbolButton4.SymbolSize = 20;
            this.uiSymbolButton4.TabIndex = 3251;
            this.uiSymbolButton4.Text = "화면 캡쳐";
            this.uiSymbolButton4.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton4.Click += new System.EventHandler(this.uiSymbolButton4_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogin.Location = new System.Drawing.Point(12, 914);
            this.btnLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(60, 60);
            this.btnLogin.TabIndex = 3246;
            this.btnLogin.Text = "Operator";
            this.btnLogin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(85, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1835, 25);
            this.panel1.TabIndex = 3182;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.uiSymbolButton1);
            this.pnlTitle.Controls.Add(this.btnClose);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1835, 25);
            this.pnlTitle.TabIndex = 3252;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1773, 25);
            this.lblTitle.TabIndex = 3058;
            this.lblTitle.Text = "-";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.CircleRectWidth = 0;
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillColor2 = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.FillSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiSymbolButton1.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.ForeHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Location = new System.Drawing.Point(1773, 0);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Size = new System.Drawing.Size(31, 25);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.StyleCustomMode = true;
            this.uiSymbolButton1.Symbol = 75;
            this.uiSymbolButton1.SymbolSize = 30;
            this.uiSymbolButton1.TabIndex = 3240;
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.CircleRectWidth = 0;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.FillColor2 = System.Drawing.Color.Transparent;
            this.btnClose.FillDisableColor = System.Drawing.Color.Transparent;
            this.btnClose.FillHoverColor = System.Drawing.Color.Transparent;
            this.btnClose.FillPressColor = System.Drawing.Color.Transparent;
            this.btnClose.FillSelectedColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnClose.ForeDisableColor = System.Drawing.Color.Transparent;
            this.btnClose.ForeHoverColor = System.Drawing.Color.Transparent;
            this.btnClose.ForePressColor = System.Drawing.Color.Transparent;
            this.btnClose.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(1804, 0);
            this.btnClose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.RectColor = System.Drawing.Color.Transparent;
            this.btnClose.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnClose.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnClose.RectPressColor = System.Drawing.Color.Transparent;
            this.btnClose.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(31, 25);
            this.btnClose.Style = Sunny.UI.UIStyle.Custom;
            this.btnClose.StyleCustomMode = true;
            this.btnClose.Symbol = 77;
            this.btnClose.SymbolDisableColor = System.Drawing.Color.White;
            this.btnClose.SymbolSize = 30;
            this.btnClose.TabIndex = 3239;
            this.btnClose.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnClose.Click += new System.EventHandler(this.btnMenuClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(723, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1197, 47);
            this.panel2.TabIndex = 3183;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel4.Controls.Add(this.btnAutoStart);
            this.panel4.Controls.Add(this.lblSeqStatus);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1197, 47);
            this.panel4.TabIndex = 2580;
            // 
            // btnAutoStart
            // 
            this.btnAutoStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAutoStart.FillColor = System.Drawing.Color.Green;
            this.btnAutoStart.FillColor2 = System.Drawing.Color.Green;
            this.btnAutoStart.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAutoStart.FillPressColor = System.Drawing.Color.Green;
            this.btnAutoStart.FillSelectedColor = System.Drawing.Color.Green;
            this.btnAutoStart.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnAutoStart.Location = new System.Drawing.Point(810, 0);
            this.btnAutoStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAutoStart.Name = "btnAutoStart";
            this.btnAutoStart.RectColor = System.Drawing.Color.White;
            this.btnAutoStart.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAutoStart.RectPressColor = System.Drawing.Color.White;
            this.btnAutoStart.RectSelectedColor = System.Drawing.Color.White;
            this.btnAutoStart.Size = new System.Drawing.Size(387, 47);
            this.btnAutoStart.Style = Sunny.UI.UIStyle.Custom;
            this.btnAutoStart.StyleCustomMode = true;
            this.btnAutoStart.Symbol = 61515;
            this.btnAutoStart.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnAutoStart.SymbolSize = 35;
            this.btnAutoStart.TabIndex = 3391;
            this.btnAutoStart.Text = "AUTO";
            this.btnAutoStart.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAutoStart.Click += new System.EventHandler(this.btnAutoStart_Click);
            // 
            // lblSeqStatus
            // 
            this.lblSeqStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblSeqStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSeqStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSeqStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSeqStatus.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSeqStatus.ForeColor = System.Drawing.Color.White;
            this.lblSeqStatus.Location = new System.Drawing.Point(0, 0);
            this.lblSeqStatus.Name = "lblSeqStatus";
            this.lblSeqStatus.Size = new System.Drawing.Size(809, 47);
            this.lblSeqStatus.TabIndex = 3378;
            this.lblSeqStatus.Text = "VISION SEQUENCE : IDLE";
            this.lblSeqStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCountReset
            // 
            this.btnCountReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCountReset.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCountReset.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCountReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCountReset.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCountReset.ForeColor = System.Drawing.Color.White;
            this.btnCountReset.Location = new System.Drawing.Point(630, 0);
            this.btnCountReset.Name = "btnCountReset";
            this.btnCountReset.Size = new System.Drawing.Size(81, 45);
            this.btnCountReset.TabIndex = 3390;
            this.btnCountReset.Text = "RESET";
            this.btnCountReset.UseVisualStyleBackColor = false;
            this.btnCountReset.Click += new System.EventHandler(this.btnCountReset_Click);
            // 
            // processBar_TrainImage
            // 
            this.processBar_TrainImage.Location = new System.Drawing.Point(221, 15);
            this.processBar_TrainImage.Maximum = 10;
            this.processBar_TrainImage.Name = "processBar_TrainImage";
            this.processBar_TrainImage.Size = new System.Drawing.Size(159, 20);
            this.processBar_TrainImage.TabIndex = 3353;
            this.processBar_TrainImage.Value = 1;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlStatus.Controls.Add(this.uiSymbolButton3);
            this.pnlStatus.Controls.Add(this.lblNotice);
            this.pnlStatus.Controls.Add(this.statusEyeD);
            this.pnlStatus.Controls.Add(this.label17);
            this.pnlStatus.Controls.Add(this.statusARC);
            this.pnlStatus.Controls.Add(this.label1);
            this.pnlStatus.Controls.Add(this.statusLicense);
            this.pnlStatus.Controls.Add(this.btnScreenCapture);
            this.pnlStatus.Controls.Add(this.picCountry);
            this.pnlStatus.Controls.Add(this.lblDateTime);
            this.pnlStatus.Controls.Add(this.comboCountry);
            this.pnlStatus.Controls.Add(this.uiSymbolButton2);
            this.pnlStatus.Controls.Add(this.label4);
            this.pnlStatus.Controls.Add(this.statusBuffer);
            this.pnlStatus.Controls.Add(this.label2);
            this.pnlStatus.Controls.Add(this.statusIO);
            this.pnlStatus.Controls.Add(this.label3);
            this.pnlStatus.Controls.Add(this.statusLightController);
            this.pnlStatus.Controls.Add(this.label13);
            this.pnlStatus.Controls.Add(this.statusCamera);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 1027);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1920, 25);
            this.pnlStatus.TabIndex = 3184;
            // 
            // uiSymbolButton3
            // 
            this.uiSymbolButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton3.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.FillColor2 = System.Drawing.Color.Green;
            this.uiSymbolButton3.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.FillPressColor = System.Drawing.Color.Green;
            this.uiSymbolButton3.FillSelectedColor = System.Drawing.Color.Green;
            this.uiSymbolButton3.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.uiSymbolButton3.Location = new System.Drawing.Point(1722, 0);
            this.uiSymbolButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton3.Name = "uiSymbolButton3";
            this.uiSymbolButton3.RectColor = System.Drawing.Color.White;
            this.uiSymbolButton3.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiSymbolButton3.RectPressColor = System.Drawing.Color.White;
            this.uiSymbolButton3.RectSelectedColor = System.Drawing.Color.White;
            this.uiSymbolButton3.Size = new System.Drawing.Size(37, 25);
            this.uiSymbolButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton3.StyleCustomMode = true;
            this.uiSymbolButton3.Symbol = 61639;
            this.uiSymbolButton3.SymbolSize = 20;
            this.uiSymbolButton3.TabIndex = 3392;
            this.uiSymbolButton3.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolButton3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton3.Click += new System.EventHandler(this.btnCountrySave_Click);
            // 
            // lblNotice
            // 
            this.lblNotice.BackColor = System.Drawing.Color.Transparent;
            this.lblNotice.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNotice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.ForeColor = System.Drawing.Color.White;
            this.lblNotice.Location = new System.Drawing.Point(716, 0);
            this.lblNotice.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(855, 25);
            this.lblNotice.TabIndex = 3364;
            this.lblNotice.Text = "-";
            this.lblNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusEyeD
            // 
            this.statusEyeD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.statusEyeD.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusEyeD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusEyeD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusEyeD.ForeColor = System.Drawing.Color.White;
            this.statusEyeD.Location = new System.Drawing.Point(630, 0);
            this.statusEyeD.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.statusEyeD.Name = "statusEyeD";
            this.statusEyeD.Size = new System.Drawing.Size(86, 25);
            this.statusEyeD.TabIndex = 3372;
            this.statusEyeD.Text = "EYE-D";
            this.statusEyeD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("Arial", 30F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(620, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(10, 25);
            this.label17.TabIndex = 3371;
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusARC
            // 
            this.statusARC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.statusARC.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusARC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusARC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusARC.ForeColor = System.Drawing.Color.White;
            this.statusARC.Location = new System.Drawing.Point(534, 0);
            this.statusARC.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.statusARC.Name = "statusARC";
            this.statusARC.Size = new System.Drawing.Size(86, 25);
            this.statusARC.TabIndex = 3363;
            this.statusARC.Text = "A.R.C";
            this.statusARC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statusARC.Click += new System.EventHandler(this.lbl_ARC_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 30F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(524, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 25);
            this.label1.TabIndex = 3360;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLicense
            // 
            this.statusLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.statusLicense.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLicense.ForeColor = System.Drawing.Color.White;
            this.statusLicense.Location = new System.Drawing.Point(438, 0);
            this.statusLicense.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.statusLicense.Name = "statusLicense";
            this.statusLicense.Size = new System.Drawing.Size(86, 25);
            this.statusLicense.TabIndex = 3359;
            this.statusLicense.Text = "LICENSE";
            this.statusLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnScreenCapture
            // 
            this.btnScreenCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnScreenCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScreenCapture.FillColor = System.Drawing.Color.Transparent;
            this.btnScreenCapture.FillColor2 = System.Drawing.Color.Transparent;
            this.btnScreenCapture.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnScreenCapture.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnScreenCapture.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnScreenCapture.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnScreenCapture.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScreenCapture.ForeColor = System.Drawing.Color.Silver;
            this.btnScreenCapture.ForeDisableColor = System.Drawing.Color.Silver;
            this.btnScreenCapture.ForeSelectedColor = System.Drawing.Color.Silver;
            this.btnScreenCapture.Location = new System.Drawing.Point(1474, 0);
            this.btnScreenCapture.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnScreenCapture.Name = "btnScreenCapture";
            this.btnScreenCapture.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnScreenCapture.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnScreenCapture.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnScreenCapture.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnScreenCapture.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnScreenCapture.Size = new System.Drawing.Size(100, 25);
            this.btnScreenCapture.Style = Sunny.UI.UIStyle.Custom;
            this.btnScreenCapture.StyleCustomMode = true;
            this.btnScreenCapture.Symbol = 61501;
            this.btnScreenCapture.SymbolColor = System.Drawing.Color.Silver;
            this.btnScreenCapture.SymbolDisableColor = System.Drawing.Color.Silver;
            this.btnScreenCapture.SymbolSelectedColor = System.Drawing.Color.Silver;
            this.btnScreenCapture.SymbolSize = 20;
            this.btnScreenCapture.TabIndex = 3357;
            this.btnScreenCapture.Text = "Capture";
            this.btnScreenCapture.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScreenCapture.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnScreenCapture.Click += new System.EventHandler(this.btnScreenCapture_Click);
            // 
            // picCountry
            // 
            this.picCountry.Image = global::IntelligentFactory.Properties.Resources.IF_LOGO;
            this.picCountry.Location = new System.Drawing.Point(1574, 0);
            this.picCountry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picCountry.Name = "picCountry";
            this.picCountry.Size = new System.Drawing.Size(53, 25);
            this.picCountry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCountry.TabIndex = 3358;
            this.picCountry.TabStop = false;
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblDateTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDateTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(1785, 2);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(135, 22);
            this.lblDateTime.TabIndex = 3335;
            this.lblDateTime.Text = "2018/02/22 02:22:22";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboCountry
            // 
            this.comboCountry.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboCountry.FontWeight = MetroFramework.MetroComboBoxWeight.Light;
            this.comboCountry.ForeColor = System.Drawing.Color.White;
            this.comboCountry.FormattingEnabled = true;
            this.comboCountry.ItemHeight = 19;
            this.comboCountry.Items.AddRange(new object[] {
            "KOR",
            "POL",
            "MAL"});
            this.comboCountry.Location = new System.Drawing.Point(1628, 0);
            this.comboCountry.Name = "comboCountry";
            this.comboCountry.Size = new System.Drawing.Size(94, 25);
            this.comboCountry.Style = MetroFramework.MetroColorStyle.Orange;
            this.comboCountry.TabIndex = 3357;
            this.comboCountry.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboCountry.UseCustomForeColor = true;
            this.comboCountry.UseSelectable = true;
            this.comboCountry.SelectedIndexChanged += new System.EventHandler(this.comboCountry_SelectedIndexChanged);
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiSymbolButton2.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.Location = new System.Drawing.Point(1763, 5);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.uiSymbolButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.uiSymbolButton2.Selected = true;
            this.uiSymbolButton2.Size = new System.Drawing.Size(23, 20);
            this.uiSymbolButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton2.StyleCustomMode = true;
            this.uiSymbolButton2.Symbol = 361463;
            this.uiSymbolButton2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.uiSymbolButton2.SymbolHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.uiSymbolButton2.SymbolPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.uiSymbolButton2.SymbolSize = 20;
            this.uiSymbolButton2.TabIndex = 3336;
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Arial", 30F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(428, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 25);
            this.label4.TabIndex = 3332;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusBuffer
            // 
            this.statusBuffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.statusBuffer.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusBuffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusBuffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBuffer.ForeColor = System.Drawing.Color.White;
            this.statusBuffer.Location = new System.Drawing.Point(288, 0);
            this.statusBuffer.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.statusBuffer.Name = "statusBuffer";
            this.statusBuffer.Size = new System.Drawing.Size(140, 25);
            this.statusBuffer.TabIndex = 3331;
            this.statusBuffer.Text = "NG Bufffer";
            this.statusBuffer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 30F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(278, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 25);
            this.label2.TabIndex = 3330;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusIO
            // 
            this.statusIO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.statusIO.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusIO.ForeColor = System.Drawing.Color.White;
            this.statusIO.Location = new System.Drawing.Point(192, 0);
            this.statusIO.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.statusIO.Name = "statusIO";
            this.statusIO.Size = new System.Drawing.Size(86, 25);
            this.statusIO.TabIndex = 3329;
            this.statusIO.Text = "I/O";
            this.statusIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 30F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(182, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 25);
            this.label3.TabIndex = 3326;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLightController
            // 
            this.statusLightController.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.statusLightController.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusLightController.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusLightController.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLightController.ForeColor = System.Drawing.Color.White;
            this.statusLightController.Location = new System.Drawing.Point(96, 0);
            this.statusLightController.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.statusLightController.Name = "statusLightController";
            this.statusLightController.Size = new System.Drawing.Size(86, 25);
            this.statusLightController.TabIndex = 3325;
            this.statusLightController.Text = "LIGHT";
            this.statusLightController.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Arial", 30F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(86, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 25);
            this.label13.TabIndex = 3324;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusCamera
            // 
            this.statusCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.statusCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCamera.ForeColor = System.Drawing.Color.White;
            this.statusCamera.Location = new System.Drawing.Point(0, 0);
            this.statusCamera.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.statusCamera.Name = "statusCamera";
            this.statusCamera.Size = new System.Drawing.Size(86, 25);
            this.statusCamera.TabIndex = 3323;
            this.statusCamera.Text = "CAMERA";
            this.statusCamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.btnCountReset_M);
            this.panel3.Controls.Add(this.lbYield_M);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.lbNG_M);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.lbOK_M);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lbTotal_M);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(85, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(737, 45);
            this.panel3.TabIndex = 3185;
            // 
            // btnCountReset_M
            // 
            this.btnCountReset_M.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCountReset_M.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCountReset_M.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCountReset_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCountReset_M.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCountReset_M.ForeColor = System.Drawing.Color.White;
            this.btnCountReset_M.Location = new System.Drawing.Point(655, 0);
            this.btnCountReset_M.Name = "btnCountReset_M";
            this.btnCountReset_M.Size = new System.Drawing.Size(81, 45);
            this.btnCountReset_M.TabIndex = 3399;
            this.btnCountReset_M.Text = "RESET";
            this.btnCountReset_M.UseVisualStyleBackColor = false;
            this.btnCountReset_M.Click += new System.EventHandler(this.btnCountReset_M_Click);
            // 
            // lbYield_M
            // 
            this.lbYield_M.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbYield_M.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbYield_M.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbYield_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbYield_M.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYield_M.ForeColor = System.Drawing.Color.White;
            this.lbYield_M.Location = new System.Drawing.Point(587, 0);
            this.lbYield_M.Name = "lbYield_M";
            this.lbYield_M.Size = new System.Drawing.Size(68, 45);
            this.lbYield_M.TabIndex = 3398;
            this.lbYield_M.Text = "0000";
            this.lbYield_M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(516, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 45);
            this.label16.TabIndex = 3397;
            this.label16.Text = "YIELD";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNG_M
            // 
            this.lbNG_M.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbNG_M.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNG_M.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNG_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbNG_M.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNG_M.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.lbNG_M.Location = new System.Drawing.Point(448, 0);
            this.lbNG_M.Name = "lbNG_M";
            this.lbNG_M.Size = new System.Drawing.Size(68, 45);
            this.lbNG_M.TabIndex = 3396;
            this.lbNG_M.Text = "0000";
            this.lbNG_M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.label12.Location = new System.Drawing.Point(377, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 45);
            this.label12.TabIndex = 3395;
            this.label12.Text = "NG";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOK_M
            // 
            this.lbOK_M.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbOK_M.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOK_M.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbOK_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbOK_M.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOK_M.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.lbOK_M.Location = new System.Drawing.Point(309, 0);
            this.lbOK_M.Name = "lbOK_M";
            this.lbOK_M.Size = new System.Drawing.Size(68, 45);
            this.lbOK_M.TabIndex = 3383;
            this.lbOK_M.Text = "0000";
            this.lbOK_M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.label14.Location = new System.Drawing.Point(238, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 45);
            this.label14.TabIndex = 3382;
            this.label14.Text = "OK";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotal_M
            // 
            this.lbTotal_M.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbTotal_M.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotal_M.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTotal_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTotal_M.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal_M.ForeColor = System.Drawing.Color.White;
            this.lbTotal_M.Location = new System.Drawing.Point(170, 0);
            this.lbTotal_M.Name = "lbTotal_M";
            this.lbTotal_M.Size = new System.Drawing.Size(68, 45);
            this.lbTotal_M.TabIndex = 3378;
            this.lbTotal_M.Text = "0000";
            this.lbTotal_M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(99, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 45);
            this.label9.TabIndex = 3377;
            this.label9.Text = "Total";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 45);
            this.label8.TabIndex = 3400;
            this.label8.Text = "Monthly";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pnlRecipeLoading);
            this.panel5.Controls.Add(this.lblStopReason);
            this.panel5.Controls.Add(this.lbRecipeName);
            this.panel5.Location = new System.Drawing.Point(85, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(737, 47);
            this.panel5.TabIndex = 3186;
            // 
            // pnlRecipeLoading
            // 
            this.pnlRecipeLoading.Controls.Add(this.uiLabel1);
            this.pnlRecipeLoading.Controls.Add(this.lblRecipeLoading);
            this.pnlRecipeLoading.Controls.Add(this.processBar_TrainImage);
            this.pnlRecipeLoading.Location = new System.Drawing.Point(0, 0);
            this.pnlRecipeLoading.Name = "pnlRecipeLoading";
            this.pnlRecipeLoading.Size = new System.Drawing.Size(389, 47);
            this.pnlRecipeLoading.TabIndex = 3379;
            this.pnlRecipeLoading.Visible = false;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.uiLabel1.Location = new System.Drawing.Point(9, 3);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(211, 20);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 3381;
            this.uiLabel1.Text = "Recipe Loading...";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblRecipeLoading
            // 
            this.lblRecipeLoading.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeLoading.ForeColor = System.Drawing.Color.Silver;
            this.lblRecipeLoading.Location = new System.Drawing.Point(5, 25);
            this.lblRecipeLoading.Name = "lblRecipeLoading";
            this.lblRecipeLoading.Size = new System.Drawing.Size(211, 17);
            this.lblRecipeLoading.Style = Sunny.UI.UIStyle.Custom;
            this.lblRecipeLoading.TabIndex = 3380;
            this.lblRecipeLoading.Text = "IDLE";
            this.lblRecipeLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecipeLoading.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.lblRecipeLoading.Click += new System.EventHandler(this.lblRecipeLoading_Click);
            // 
            // lblStopReason
            // 
            this.lblStopReason.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.lblStopReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(127)))), ((int)(((byte)(187)))));
            this.lblStopReason.Location = new System.Drawing.Point(389, 0);
            this.lblStopReason.MinimumSize = new System.Drawing.Size(1, 1);
            this.lblStopReason.Name = "lblStopReason";
            this.lblStopReason.Size = new System.Drawing.Size(247, 47);
            this.lblStopReason.Style = Sunny.UI.UIStyle.Custom;
            this.lblStopReason.TabIndex = 3378;
            this.lblStopReason.Text = "uiLedLabel1";
            this.lblStopReason.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbRecipeName
            // 
            this.lbRecipeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbRecipeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRecipeName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbRecipeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbRecipeName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecipeName.ForeColor = System.Drawing.Color.White;
            this.lbRecipeName.Location = new System.Drawing.Point(0, 0);
            this.lbRecipeName.Name = "lbRecipeName";
            this.lbRecipeName.Size = new System.Drawing.Size(389, 47);
            this.lbRecipeName.TabIndex = 3377;
            this.lbRecipeName.Text = "PBA_DA91-012696";
            this.lbRecipeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel6.Controls.Add(this.btnCountReset);
            this.panel6.Controls.Add(this.lbCountYield);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.lbCountNG_F);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.lbCountOK);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.lbCountTOTAL);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.lblMode);
            this.panel6.Location = new System.Drawing.Point(821, 72);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1099, 45);
            this.panel6.TabIndex = 3187;
            // 
            // lbCountYield
            // 
            this.lbCountYield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbCountYield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCountYield.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCountYield.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCountYield.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountYield.ForeColor = System.Drawing.Color.White;
            this.lbCountYield.Location = new System.Drawing.Point(549, 0);
            this.lbCountYield.Name = "lbCountYield";
            this.lbCountYield.Size = new System.Drawing.Size(81, 45);
            this.lbCountYield.TabIndex = 3390;
            this.lbCountYield.Text = "0000";
            this.lbCountYield.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(484, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 45);
            this.label7.TabIndex = 3389;
            this.label7.Text = "YIELD";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCountNG_F
            // 
            this.lbCountNG_F.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbCountNG_F.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCountNG_F.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCountNG_F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCountNG_F.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountNG_F.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.lbCountNG_F.Location = new System.Drawing.Point(419, 0);
            this.lbCountNG_F.Name = "lbCountNG_F";
            this.lbCountNG_F.Size = new System.Drawing.Size(65, 45);
            this.lbCountNG_F.TabIndex = 3387;
            this.lbCountNG_F.Text = "0000";
            this.lbCountNG_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.label10.Location = new System.Drawing.Point(340, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 45);
            this.label10.TabIndex = 3386;
            this.label10.Text = "NG";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCountOK
            // 
            this.lbCountOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbCountOK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCountOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCountOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCountOK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.lbCountOK.Location = new System.Drawing.Point(275, 0);
            this.lbCountOK.Name = "lbCountOK";
            this.lbCountOK.Size = new System.Drawing.Size(65, 45);
            this.lbCountOK.TabIndex = 3382;
            this.lbCountOK.Text = "0000";
            this.lbCountOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.label5.Location = new System.Drawing.Point(210, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 45);
            this.label5.TabIndex = 3381;
            this.label5.Text = "OK";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCountTOTAL
            // 
            this.lbCountTOTAL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbCountTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCountTOTAL.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCountTOTAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCountTOTAL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountTOTAL.ForeColor = System.Drawing.Color.White;
            this.lbCountTOTAL.Location = new System.Drawing.Point(145, 0);
            this.lbCountTOTAL.Name = "lbCountTOTAL";
            this.lbCountTOTAL.Size = new System.Drawing.Size(65, 45);
            this.lbCountTOTAL.TabIndex = 3380;
            this.lbCountTOTAL.Text = "0000";
            this.lbCountTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(80, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 45);
            this.label11.TabIndex = 3378;
            this.label11.Text = "TOTAL";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 45);
            this.label6.TabIndex = 3391;
            this.label6.Text = "Daily";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMode
            // 
            this.lblMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMode.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMode.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.White;
            this.lblMode.Location = new System.Drawing.Point(712, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(387, 45);
            this.lblMode.TabIndex = 3371;
            this.lblMode.Text = "0000";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMode.DoubleClick += new System.EventHandler(this.lblMode_DoubleClick);
            // 
            // pnlAlarm
            // 
            this.pnlAlarm.Controls.Add(this.btnAlarmReset);
            this.pnlAlarm.Controls.Add(this.lblAlarm);
            this.pnlAlarm.Location = new System.Drawing.Point(821, 25);
            this.pnlAlarm.Name = "pnlAlarm";
            this.pnlAlarm.Size = new System.Drawing.Size(711, 92);
            this.pnlAlarm.TabIndex = 3393;
            this.pnlAlarm.Visible = false;
            // 
            // btnAlarmReset
            // 
            this.btnAlarmReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlarmReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAlarmReset.FillColor = System.Drawing.Color.Orange;
            this.btnAlarmReset.FillColor2 = System.Drawing.Color.Orange;
            this.btnAlarmReset.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAlarmReset.FillPressColor = System.Drawing.Color.Orange;
            this.btnAlarmReset.FillSelectedColor = System.Drawing.Color.Orange;
            this.btnAlarmReset.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnAlarmReset.Location = new System.Drawing.Point(563, 0);
            this.btnAlarmReset.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAlarmReset.Name = "btnAlarmReset";
            this.btnAlarmReset.RectColor = System.Drawing.Color.White;
            this.btnAlarmReset.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnAlarmReset.RectPressColor = System.Drawing.Color.White;
            this.btnAlarmReset.RectSelectedColor = System.Drawing.Color.White;
            this.btnAlarmReset.Size = new System.Drawing.Size(148, 92);
            this.btnAlarmReset.Style = Sunny.UI.UIStyle.Custom;
            this.btnAlarmReset.StyleCustomMode = true;
            this.btnAlarmReset.Symbol = 61515;
            this.btnAlarmReset.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnAlarmReset.SymbolSize = 35;
            this.btnAlarmReset.TabIndex = 3392;
            this.btnAlarmReset.Text = "RESET";
            this.btnAlarmReset.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarmReset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAlarmReset.Click += new System.EventHandler(this.btnAlarmReset_Click);
            // 
            // lblAlarm
            // 
            this.lblAlarm.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.lblAlarm.ForeColor = System.Drawing.Color.Red;
            this.lblAlarm.IntervalOn = 1;
            this.lblAlarm.Location = new System.Drawing.Point(7, 12);
            this.lblAlarm.MinimumSize = new System.Drawing.Size(1, 1);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(647, 65);
            this.lblAlarm.Style = Sunny.UI.UIStyle.Custom;
            this.lblAlarm.TabIndex = 0;
            this.lblAlarm.Text = "uiLedLabel1";
            this.lblAlarm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormMenu_MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1052);
            this.ControlBox = false;
            this.Controls.Add(this.pnlAlarm);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnMDI);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_Menu);
            this.Controls.Add(this.pnlStatus);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenu_MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenu_MainFrame_FormClosing);
            this.Load += new System.EventHandler(this.FormMenu_MainFrame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_Menu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCountry)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.pnlRecipeLoading.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.pnlAlarm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.Timer timerAlarmWarning;
        private System.Windows.Forms.Timer timerConnection;
        private System.Windows.Forms.Timer timerAlarm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnMDI;
        private System.Windows.Forms.Button btnMenuRMS;
        private System.Windows.Forms.Button btnMenuAuthorization;
        private System.Windows.Forms.Button btnMenuSetting;
        private System.Windows.Forms.Button btnMenuMain;
        private System.Windows.Forms.Button btnMenuIO;
        private System.Windows.Forms.Button btnMenuVisionTeaching;
        private System.Windows.Forms.Button btnMenuModel;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton btnClose;
        private IF_UI.RJControls.RJDragControl dragControl_Title;
        private IF_UI.RJControls.RJDragControl dragControl_Title2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label statusBuffer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label statusIO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusLightController;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label statusCamera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDateTime;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private System.Windows.Forms.ProgressBar processBar_TrainImage;
        private Sunny.UI.UISymbolButton btnScreenCapture;
        private System.Windows.Forms.PictureBox picCountry;
        private MetroFramework.Controls.MetroComboBox comboCountry;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusLicense;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Label statusARC;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbRecipeName;
        private System.Windows.Forms.Label lbTotal_M;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCountReset;
        private System.Windows.Forms.Label lblSeqStatus;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbCountYield;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbCountNG_F;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbCountOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCountTOTAL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lbYield_M;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbNG_M;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbOK_M;
        private System.Windows.Forms.Label label14;
        private Sunny.UI.UISymbolButton btnAutoStart;
        private System.Windows.Forms.Label statusEyeD;
        private System.Windows.Forms.Label label17;
        private Sunny.UI.UISymbolButton uiSymbolButton3;
        private System.Windows.Forms.Panel pnlAlarm;
        private Sunny.UI.UILedLabel lblAlarm;
        private Sunny.UI.UISymbolButton btnAlarmReset;
        private Sunny.UI.UIAvatar btnLogin;
        private Sunny.UI.UISymbolButton uiSymbolButton4;
        private Sunny.UI.UILedLabel lblStopReason;
        private System.Windows.Forms.Panel pnlRecipeLoading;
        private Sunny.UI.UILabel lblRecipeLoading;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton lbAuthorization;
        private System.Windows.Forms.Button btnCountReset_M;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}