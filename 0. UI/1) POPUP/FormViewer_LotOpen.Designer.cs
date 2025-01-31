namespace IntelligentFactory
{
    partial class FormViewer_LotOpen
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
            this.timerView = new System.Windows.Forms.Timer(this.components);
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.pnLotOpen = new System.Windows.Forms.Panel();
            this.btnLotClear = new MetroFramework.Controls.MetroTile();
            this.tbLotTrayCount = new MetroFramework.Controls.MetroTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.btnLotLastLoad = new MetroFramework.Controls.MetroTile();
            this.lbStatusLoaderEmpty = new System.Windows.Forms.Label();
            this.lbLotOpenTime = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tbLotWorker = new MetroFramework.Controls.MetroTextBox();
            this.tbLotTopCoverID = new MetroFramework.Controls.MetroTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbLotMetalTrayID = new MetroFramework.Controls.MetroTextBox();
            this.btnLotOpen = new MetroFramework.Controls.MetroTile();
            this.label30 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tbLotNo = new MetroFramework.Controls.MetroTextBox();
            this.tbLotTrayCols = new MetroFramework.Controls.MetroTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbLotTrayRows = new MetroFramework.Controls.MetroTextBox();
            this.tbLotDeviceCount = new MetroFramework.Controls.MetroTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.pnLotOpen.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerView
            // 
            this.timerView.Enabled = true;
            this.timerView.Interval = 1000;
            this.timerView.Tick += new System.EventHandler(this.timerView_Tick);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Style = MetroFramework.MetroColorStyle.Lime;
            // 
            // pnLotOpen
            // 
            this.pnLotOpen.Controls.Add(this.btnLotClear);
            this.pnLotOpen.Controls.Add(this.tbLotTrayCount);
            this.pnLotOpen.Controls.Add(this.label33);
            this.pnLotOpen.Controls.Add(this.btnLotLastLoad);
            this.pnLotOpen.Controls.Add(this.lbStatusLoaderEmpty);
            this.pnLotOpen.Controls.Add(this.lbLotOpenTime);
            this.pnLotOpen.Controls.Add(this.label32);
            this.pnLotOpen.Controls.Add(this.label31);
            this.pnLotOpen.Controls.Add(this.tbLotWorker);
            this.pnLotOpen.Controls.Add(this.tbLotTopCoverID);
            this.pnLotOpen.Controls.Add(this.label5);
            this.pnLotOpen.Controls.Add(this.tbLotMetalTrayID);
            this.pnLotOpen.Controls.Add(this.btnLotOpen);
            this.pnLotOpen.Controls.Add(this.label30);
            this.pnLotOpen.Controls.Add(this.label17);
            this.pnLotOpen.Controls.Add(this.label29);
            this.pnLotOpen.Controls.Add(this.tbLotNo);
            this.pnLotOpen.Controls.Add(this.tbLotTrayCols);
            this.pnLotOpen.Controls.Add(this.label25);
            this.pnLotOpen.Controls.Add(this.tbLotTrayRows);
            this.pnLotOpen.Controls.Add(this.tbLotDeviceCount);
            this.pnLotOpen.Controls.Add(this.label27);
            this.pnLotOpen.Controls.Add(this.label26);
            this.pnLotOpen.Controls.Add(this.label28);
            this.pnLotOpen.Location = new System.Drawing.Point(23, 63);
            this.pnLotOpen.Name = "pnLotOpen";
            this.pnLotOpen.Size = new System.Drawing.Size(395, 483);
            this.pnLotOpen.TabIndex = 1656;
            // 
            // btnLotClear
            // 
            this.btnLotClear.ActiveControl = null;
            this.btnLotClear.BackColor = System.Drawing.Color.Transparent;
            this.btnLotClear.Location = new System.Drawing.Point(2, 441);
            this.btnLotClear.Name = "btnLotClear";
            this.btnLotClear.Size = new System.Drawing.Size(155, 39);
            this.btnLotClear.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnLotClear.TabIndex = 1664;
            this.btnLotClear.Text = "LOT CLEAR";
            this.btnLotClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLotClear.TileImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLotClear.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnLotClear.UseSelectable = true;
            this.btnLotClear.UseTileImage = true;
            this.btnLotClear.Click += new System.EventHandler(this.btnLotClear_Click);
            // 
            // tbLotTrayCount
            // 
            // 
            // 
            // 
            this.tbLotTrayCount.CustomButton.Image = null;
            this.tbLotTrayCount.CustomButton.Location = new System.Drawing.Point(203, 1);
            this.tbLotTrayCount.CustomButton.Name = "";
            this.tbLotTrayCount.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.tbLotTrayCount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLotTrayCount.CustomButton.TabIndex = 1;
            this.tbLotTrayCount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotTrayCount.CustomButton.UseSelectable = true;
            this.tbLotTrayCount.CustomButton.Visible = false;
            this.tbLotTrayCount.DisplayIcon = true;
            this.tbLotTrayCount.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbLotTrayCount.Lines = new string[] {
        "0"};
            this.tbLotTrayCount.Location = new System.Drawing.Point(158, 185);
            this.tbLotTrayCount.MaxLength = 32767;
            this.tbLotTrayCount.Name = "tbLotTrayCount";
            this.tbLotTrayCount.PasswordChar = '\0';
            this.tbLotTrayCount.ReadOnly = true;
            this.tbLotTrayCount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLotTrayCount.SelectedText = "";
            this.tbLotTrayCount.SelectionLength = 0;
            this.tbLotTrayCount.SelectionStart = 0;
            this.tbLotTrayCount.ShortcutsEnabled = true;
            this.tbLotTrayCount.Size = new System.Drawing.Size(237, 35);
            this.tbLotTrayCount.Style = MetroFramework.MetroColorStyle.Teal;
            this.tbLotTrayCount.TabIndex = 1663;
            this.tbLotTrayCount.Text = "0";
            this.tbLotTrayCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLotTrayCount.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotTrayCount.UseSelectable = true;
            this.tbLotTrayCount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLotTrayCount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label33.Location = new System.Drawing.Point(80, 185);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(77, 35);
            this.label33.TabIndex = 1662;
            this.label33.Text = "COUNT";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLotLastLoad
            // 
            this.btnLotLastLoad.ActiveControl = null;
            this.btnLotLastLoad.BackColor = System.Drawing.Color.Transparent;
            this.btnLotLastLoad.Location = new System.Drawing.Point(2, 401);
            this.btnLotLastLoad.Name = "btnLotLastLoad";
            this.btnLotLastLoad.Size = new System.Drawing.Size(155, 39);
            this.btnLotLastLoad.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnLotLastLoad.TabIndex = 1661;
            this.btnLotLastLoad.Text = "LOT LAST LOAD";
            this.btnLotLastLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLotLastLoad.TileImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLotLastLoad.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnLotLastLoad.UseSelectable = true;
            this.btnLotLastLoad.UseTileImage = true;
            this.btnLotLastLoad.Click += new System.EventHandler(this.btnLotLastLoad_Click);
            // 
            // lbStatusLoaderEmpty
            // 
            this.lbStatusLoaderEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.lbStatusLoaderEmpty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbStatusLoaderEmpty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbStatusLoaderEmpty.ForeColor = System.Drawing.Color.White;
            this.lbStatusLoaderEmpty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbStatusLoaderEmpty.Location = new System.Drawing.Point(2, 36);
            this.lbStatusLoaderEmpty.Name = "lbStatusLoaderEmpty";
            this.lbStatusLoaderEmpty.Size = new System.Drawing.Size(392, 40);
            this.lbStatusLoaderEmpty.TabIndex = 1659;
            this.lbStatusLoaderEmpty.Text = "LOADER EMPTY";
            this.lbStatusLoaderEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLotOpenTime
            // 
            this.lbLotOpenTime.BackColor = System.Drawing.Color.Transparent;
            this.lbLotOpenTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLotOpenTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbLotOpenTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLotOpenTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.lbLotOpenTime.Location = new System.Drawing.Point(158, 365);
            this.lbLotOpenTime.Name = "lbLotOpenTime";
            this.lbLotOpenTime.Size = new System.Drawing.Size(237, 35);
            this.lbLotOpenTime.TabIndex = 1658;
            this.lbLotOpenTime.Text = "2021/10/22 18:03:55";
            this.lbLotOpenTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label32.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label32.Location = new System.Drawing.Point(1, 365);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(156, 35);
            this.label32.TabIndex = 1657;
            this.label32.Text = "DATETIME";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label31.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label31.Location = new System.Drawing.Point(1, 77);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(156, 35);
            this.label31.TabIndex = 1655;
            this.label31.Text = "WORKER";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLotWorker
            // 
            // 
            // 
            // 
            this.tbLotWorker.CustomButton.Image = null;
            this.tbLotWorker.CustomButton.Location = new System.Drawing.Point(203, 1);
            this.tbLotWorker.CustomButton.Name = "";
            this.tbLotWorker.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.tbLotWorker.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLotWorker.CustomButton.TabIndex = 1;
            this.tbLotWorker.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotWorker.CustomButton.UseSelectable = true;
            this.tbLotWorker.CustomButton.Visible = false;
            this.tbLotWorker.DisplayIcon = true;
            this.tbLotWorker.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbLotWorker.Lines = new string[] {
        "OPERATOR"};
            this.tbLotWorker.Location = new System.Drawing.Point(158, 77);
            this.tbLotWorker.MaxLength = 32767;
            this.tbLotWorker.Name = "tbLotWorker";
            this.tbLotWorker.PasswordChar = '\0';
            this.tbLotWorker.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLotWorker.SelectedText = "";
            this.tbLotWorker.SelectionLength = 0;
            this.tbLotWorker.SelectionStart = 0;
            this.tbLotWorker.ShortcutsEnabled = true;
            this.tbLotWorker.Size = new System.Drawing.Size(237, 35);
            this.tbLotWorker.Style = MetroFramework.MetroColorStyle.Teal;
            this.tbLotWorker.TabIndex = 1656;
            this.tbLotWorker.Text = "OPERATOR";
            this.tbLotWorker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLotWorker.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotWorker.UseSelectable = true;
            this.tbLotWorker.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLotWorker.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbLotTopCoverID
            // 
            // 
            // 
            // 
            this.tbLotTopCoverID.CustomButton.Image = null;
            this.tbLotTopCoverID.CustomButton.Location = new System.Drawing.Point(203, 1);
            this.tbLotTopCoverID.CustomButton.Name = "";
            this.tbLotTopCoverID.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.tbLotTopCoverID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLotTopCoverID.CustomButton.TabIndex = 1;
            this.tbLotTopCoverID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotTopCoverID.CustomButton.UseSelectable = true;
            this.tbLotTopCoverID.CustomButton.Visible = false;
            this.tbLotTopCoverID.DisplayIcon = true;
            this.tbLotTopCoverID.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbLotTopCoverID.Lines = new string[0];
            this.tbLotTopCoverID.Location = new System.Drawing.Point(158, 329);
            this.tbLotTopCoverID.MaxLength = 32767;
            this.tbLotTopCoverID.Name = "tbLotTopCoverID";
            this.tbLotTopCoverID.PasswordChar = '\0';
            this.tbLotTopCoverID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLotTopCoverID.SelectedText = "";
            this.tbLotTopCoverID.SelectionLength = 0;
            this.tbLotTopCoverID.SelectionStart = 0;
            this.tbLotTopCoverID.ShortcutsEnabled = true;
            this.tbLotTopCoverID.Size = new System.Drawing.Size(237, 35);
            this.tbLotTopCoverID.Style = MetroFramework.MetroColorStyle.Teal;
            this.tbLotTopCoverID.TabIndex = 1654;
            this.tbLotTopCoverID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLotTopCoverID.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotTopCoverID.UseSelectable = true;
            this.tbLotTopCoverID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLotTopCoverID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label5.Location = new System.Drawing.Point(1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(393, 35);
            this.label5.TabIndex = 1641;
            this.label5.Text = "LOT OPEN";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLotMetalTrayID
            // 
            // 
            // 
            // 
            this.tbLotMetalTrayID.CustomButton.Image = null;
            this.tbLotMetalTrayID.CustomButton.Location = new System.Drawing.Point(203, 1);
            this.tbLotMetalTrayID.CustomButton.Name = "";
            this.tbLotMetalTrayID.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.tbLotMetalTrayID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLotMetalTrayID.CustomButton.TabIndex = 1;
            this.tbLotMetalTrayID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotMetalTrayID.CustomButton.UseSelectable = true;
            this.tbLotMetalTrayID.CustomButton.Visible = false;
            this.tbLotMetalTrayID.DisplayIcon = true;
            this.tbLotMetalTrayID.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbLotMetalTrayID.Lines = new string[0];
            this.tbLotMetalTrayID.Location = new System.Drawing.Point(158, 293);
            this.tbLotMetalTrayID.MaxLength = 32767;
            this.tbLotMetalTrayID.Name = "tbLotMetalTrayID";
            this.tbLotMetalTrayID.PasswordChar = '\0';
            this.tbLotMetalTrayID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLotMetalTrayID.SelectedText = "";
            this.tbLotMetalTrayID.SelectionLength = 0;
            this.tbLotMetalTrayID.SelectionStart = 0;
            this.tbLotMetalTrayID.ShortcutsEnabled = true;
            this.tbLotMetalTrayID.Size = new System.Drawing.Size(237, 35);
            this.tbLotMetalTrayID.Style = MetroFramework.MetroColorStyle.Teal;
            this.tbLotMetalTrayID.TabIndex = 1653;
            this.tbLotMetalTrayID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLotMetalTrayID.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotMetalTrayID.UseSelectable = true;
            this.tbLotMetalTrayID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLotMetalTrayID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnLotOpen
            // 
            this.btnLotOpen.ActiveControl = null;
            this.btnLotOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnLotOpen.Location = new System.Drawing.Point(158, 401);
            this.btnLotOpen.Name = "btnLotOpen";
            this.btnLotOpen.Size = new System.Drawing.Size(235, 79);
            this.btnLotOpen.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btnLotOpen.TabIndex = 1640;
            this.btnLotOpen.Text = "LOT OPEN";
            this.btnLotOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLotOpen.TileImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLotOpen.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnLotOpen.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnLotOpen.UseSelectable = true;
            this.btnLotOpen.UseTileImage = true;
            this.btnLotOpen.Click += new System.EventHandler(this.btnLotOpen_Click);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label30.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label30.Location = new System.Drawing.Point(1, 329);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(156, 35);
            this.label30.TabIndex = 1652;
            this.label30.Text = "TOP COVER ID";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label17.Location = new System.Drawing.Point(1, 113);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(156, 35);
            this.label17.TabIndex = 1642;
            this.label17.Text = "LOT NO";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label29.Location = new System.Drawing.Point(1, 293);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(156, 35);
            this.label29.TabIndex = 1651;
            this.label29.Text = "METAL TRAY ID";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLotNo
            // 
            // 
            // 
            // 
            this.tbLotNo.CustomButton.Image = null;
            this.tbLotNo.CustomButton.Location = new System.Drawing.Point(203, 1);
            this.tbLotNo.CustomButton.Name = "";
            this.tbLotNo.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.tbLotNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLotNo.CustomButton.TabIndex = 1;
            this.tbLotNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotNo.CustomButton.UseSelectable = true;
            this.tbLotNo.CustomButton.Visible = false;
            this.tbLotNo.DisplayIcon = true;
            this.tbLotNo.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbLotNo.Lines = new string[0];
            this.tbLotNo.Location = new System.Drawing.Point(158, 113);
            this.tbLotNo.MaxLength = 32767;
            this.tbLotNo.Name = "tbLotNo";
            this.tbLotNo.PasswordChar = '\0';
            this.tbLotNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLotNo.SelectedText = "";
            this.tbLotNo.SelectionLength = 0;
            this.tbLotNo.SelectionStart = 0;
            this.tbLotNo.ShortcutsEnabled = true;
            this.tbLotNo.Size = new System.Drawing.Size(237, 35);
            this.tbLotNo.Style = MetroFramework.MetroColorStyle.Teal;
            this.tbLotNo.TabIndex = 1643;
            this.tbLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLotNo.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotNo.UseSelectable = true;
            this.tbLotNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLotNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbLotTrayCols
            // 
            // 
            // 
            // 
            this.tbLotTrayCols.CustomButton.Image = null;
            this.tbLotTrayCols.CustomButton.Location = new System.Drawing.Point(203, 1);
            this.tbLotTrayCols.CustomButton.Name = "";
            this.tbLotTrayCols.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.tbLotTrayCols.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLotTrayCols.CustomButton.TabIndex = 1;
            this.tbLotTrayCols.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotTrayCols.CustomButton.UseSelectable = true;
            this.tbLotTrayCols.CustomButton.Visible = false;
            this.tbLotTrayCols.DisplayIcon = true;
            this.tbLotTrayCols.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbLotTrayCols.Lines = new string[] {
        "10"};
            this.tbLotTrayCols.Location = new System.Drawing.Point(158, 257);
            this.tbLotTrayCols.MaxLength = 32767;
            this.tbLotTrayCols.Name = "tbLotTrayCols";
            this.tbLotTrayCols.PasswordChar = '\0';
            this.tbLotTrayCols.ReadOnly = true;
            this.tbLotTrayCols.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLotTrayCols.SelectedText = "";
            this.tbLotTrayCols.SelectionLength = 0;
            this.tbLotTrayCols.SelectionStart = 0;
            this.tbLotTrayCols.ShortcutsEnabled = true;
            this.tbLotTrayCols.Size = new System.Drawing.Size(237, 35);
            this.tbLotTrayCols.Style = MetroFramework.MetroColorStyle.Teal;
            this.tbLotTrayCols.TabIndex = 1650;
            this.tbLotTrayCols.Text = "10";
            this.tbLotTrayCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLotTrayCols.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotTrayCols.UseSelectable = true;
            this.tbLotTrayCols.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLotTrayCols.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label25.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label25.Location = new System.Drawing.Point(1, 149);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(156, 35);
            this.label25.TabIndex = 1644;
            this.label25.Text = "DEVICE COUNT";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLotTrayRows
            // 
            // 
            // 
            // 
            this.tbLotTrayRows.CustomButton.Image = null;
            this.tbLotTrayRows.CustomButton.Location = new System.Drawing.Point(203, 1);
            this.tbLotTrayRows.CustomButton.Name = "";
            this.tbLotTrayRows.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.tbLotTrayRows.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLotTrayRows.CustomButton.TabIndex = 1;
            this.tbLotTrayRows.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotTrayRows.CustomButton.UseSelectable = true;
            this.tbLotTrayRows.CustomButton.Visible = false;
            this.tbLotTrayRows.DisplayIcon = true;
            this.tbLotTrayRows.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbLotTrayRows.Lines = new string[] {
        "10"};
            this.tbLotTrayRows.Location = new System.Drawing.Point(158, 221);
            this.tbLotTrayRows.MaxLength = 32767;
            this.tbLotTrayRows.Name = "tbLotTrayRows";
            this.tbLotTrayRows.PasswordChar = '\0';
            this.tbLotTrayRows.ReadOnly = true;
            this.tbLotTrayRows.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLotTrayRows.SelectedText = "";
            this.tbLotTrayRows.SelectionLength = 0;
            this.tbLotTrayRows.SelectionStart = 0;
            this.tbLotTrayRows.ShortcutsEnabled = true;
            this.tbLotTrayRows.Size = new System.Drawing.Size(237, 35);
            this.tbLotTrayRows.Style = MetroFramework.MetroColorStyle.Teal;
            this.tbLotTrayRows.TabIndex = 1649;
            this.tbLotTrayRows.Text = "10";
            this.tbLotTrayRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLotTrayRows.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotTrayRows.UseSelectable = true;
            this.tbLotTrayRows.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLotTrayRows.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbLotDeviceCount
            // 
            // 
            // 
            // 
            this.tbLotDeviceCount.CustomButton.Image = null;
            this.tbLotDeviceCount.CustomButton.Location = new System.Drawing.Point(203, 1);
            this.tbLotDeviceCount.CustomButton.Name = "";
            this.tbLotDeviceCount.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.tbLotDeviceCount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLotDeviceCount.CustomButton.TabIndex = 1;
            this.tbLotDeviceCount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotDeviceCount.CustomButton.UseSelectable = true;
            this.tbLotDeviceCount.CustomButton.Visible = false;
            this.tbLotDeviceCount.DisplayIcon = true;
            this.tbLotDeviceCount.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbLotDeviceCount.Lines = new string[] {
        "10"};
            this.tbLotDeviceCount.Location = new System.Drawing.Point(158, 149);
            this.tbLotDeviceCount.MaxLength = 32767;
            this.tbLotDeviceCount.Name = "tbLotDeviceCount";
            this.tbLotDeviceCount.PasswordChar = '\0';
            this.tbLotDeviceCount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLotDeviceCount.SelectedText = "";
            this.tbLotDeviceCount.SelectionLength = 0;
            this.tbLotDeviceCount.SelectionStart = 0;
            this.tbLotDeviceCount.ShortcutsEnabled = true;
            this.tbLotDeviceCount.Size = new System.Drawing.Size(237, 35);
            this.tbLotDeviceCount.Style = MetroFramework.MetroColorStyle.Teal;
            this.tbLotDeviceCount.TabIndex = 1645;
            this.tbLotDeviceCount.Text = "10";
            this.tbLotDeviceCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLotDeviceCount.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLotDeviceCount.UseSelectable = true;
            this.tbLotDeviceCount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLotDeviceCount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbLotDeviceCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress_Device_Count);
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label27.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label27.Location = new System.Drawing.Point(80, 257);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(77, 35);
            this.label27.TabIndex = 1648;
            this.label27.Text = "COLS";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label26.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label26.Location = new System.Drawing.Point(1, 185);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(78, 107);
            this.label26.TabIndex = 1646;
            this.label26.Text = "TRAY";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label28.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            this.label28.Location = new System.Drawing.Point(80, 221);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 35);
            this.label28.TabIndex = 1647;
            this.label28.Text = "ROWS";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormViewer_LotOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 566);
            this.Controls.Add(this.pnLotOpen);
            this.Name = "FormViewer_LotOpen";
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "LOT OPEN";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormViewer_LotOpen_FormClosing);
            this.Load += new System.EventHandler(this.FormViewer_LotOpen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.pnLotOpen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerView;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private System.Windows.Forms.Panel pnLotOpen;
        private MetroFramework.Controls.MetroTextBox tbLotTrayCount;
        private System.Windows.Forms.Label label33;
        private MetroFramework.Controls.MetroTile btnLotLastLoad;
        private System.Windows.Forms.Label lbStatusLoaderEmpty;
        private System.Windows.Forms.Label lbLotOpenTime;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private MetroFramework.Controls.MetroTextBox tbLotWorker;
        private MetroFramework.Controls.MetroTextBox tbLotTopCoverID;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroTextBox tbLotMetalTrayID;
        private MetroFramework.Controls.MetroTile btnLotOpen;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label29;
        private MetroFramework.Controls.MetroTextBox tbLotNo;
        private MetroFramework.Controls.MetroTextBox tbLotTrayCols;
        private System.Windows.Forms.Label label25;
        private MetroFramework.Controls.MetroTextBox tbLotTrayRows;
        private MetroFramework.Controls.MetroTextBox tbLotDeviceCount;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private MetroFramework.Controls.MetroTile btnLotClear;
    }
}