using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IF
{
    partial class Form_MenuMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MenuMain));
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.timerInit = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.uiLedBulb12 = new Sunny.UI.UILedBulb();
            this.label16 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.uiLedBulb13 = new Sunny.UI.UILedBulb();
            this.uiLedBulb17 = new Sunny.UI.UILedBulb();
            this.label17 = new System.Windows.Forms.Label();
            this.uiLedBulb18 = new Sunny.UI.UILedBulb();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.uiLedBulb7 = new Sunny.UI.UILedBulb();
            this.label14 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.uiLedBulb2 = new Sunny.UI.UILedBulb();
            this.uiLedBulb5 = new Sunny.UI.UILedBulb();
            this.label8 = new System.Windows.Forms.Label();
            this.uiLedBulb6 = new Sunny.UI.UILedBulb();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.uiLine6 = new Sunny.UI.UILine();
            this.uiLine5 = new Sunny.UI.UILine();
            this.uiLine4 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine1 = new Sunny.UI.UILine();
            this.label2 = new System.Windows.Forms.Label();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.uiDataGridView2 = new Sunny.UI.UIDataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiSymbolButton3 = new Sunny.UI.UISymbolButton();
            this.label20 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lbCurrentNG = new System.Windows.Forms.Label();
            this.lbCurrentYield = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbCurrentOK = new System.Windows.Forms.Label();
            this.lbCurrentTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlArray4 = new System.Windows.Forms.Panel();
            this.cogDisplay_Array4 = new Cognex.VisionPro.Display.CogDisplay();
            this.lblArray4 = new System.Windows.Forms.Label();
            this.pnlArray3 = new System.Windows.Forms.Panel();
            this.cogDisplay_Array3 = new Cognex.VisionPro.Display.CogDisplay();
            this.lblArray3 = new System.Windows.Forms.Label();
            this.pnlArray2 = new System.Windows.Forms.Panel();
            this.cogDisplay_Array2 = new Cognex.VisionPro.Display.CogDisplay();
            this.lblArray2 = new System.Windows.Forms.Label();
            this.pnlArray1 = new System.Windows.Forms.Panel();
            this.cogDisplay_Array1 = new Cognex.VisionPro.Display.CogDisplay();
            this.lblArray1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView2)).BeginInit();
            this.pnlArray4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Array4)).BeginInit();
            this.pnlArray3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Array3)).BeginInit();
            this.pnlArray2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Array2)).BeginInit();
            this.pnlArray1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Array1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // timerInit
            // 
            this.timerInit.Enabled = true;
            this.timerInit.Interval = 1000;
            this.timerInit.Tick += new System.EventHandler(this.timerInit_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.uiLine6);
            this.panel2.Controls.Add(this.uiLine5);
            this.panel2.Controls.Add(this.uiLine4);
            this.panel2.Controls.Add(this.uiLine3);
            this.panel2.Controls.Add(this.uiLine2);
            this.panel2.Controls.Add(this.uiLine1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.uiDataGridView1);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.uiDataGridView2);
            this.panel2.Controls.Add(this.uiSymbolButton3);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.lbCurrentNG);
            this.panel2.Controls.Add(this.lbCurrentYield);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lbCurrentOK);
            this.panel2.Controls.Add(this.lbCurrentTotal);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1470, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 860);
            this.panel2.TabIndex = 3189;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Location = new System.Drawing.Point(146, 615);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(151, 84);
            this.panel6.TabIndex = 3444;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.uiLedBulb12);
            this.panel10.Controls.Add(this.label16);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 59);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(151, 25);
            this.panel10.TabIndex = 3443;
            // 
            // uiLedBulb12
            // 
            this.uiLedBulb12.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb12.Location = new System.Drawing.Point(3, 1);
            this.uiLedBulb12.Name = "uiLedBulb12";
            this.uiLedBulb12.On = false;
            this.uiLedBulb12.Size = new System.Drawing.Size(15, 15);
            this.uiLedBulb12.TabIndex = 3447;
            this.uiLedBulb12.Text = "uiLedBulb1";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(21, 0);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label16.Size = new System.Drawing.Size(144, 19);
            this.label16.TabIndex = 3444;
            this.label16.Text = "[D2004] GRAB START";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.uiLedBulb13);
            this.panel11.Controls.Add(this.uiLedBulb17);
            this.panel11.Controls.Add(this.label17);
            this.panel11.Controls.Add(this.uiLedBulb18);
            this.panel11.Controls.Add(this.label18);
            this.panel11.Controls.Add(this.label19);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(151, 59);
            this.panel11.TabIndex = 3442;
            // 
            // uiLedBulb13
            // 
            this.uiLedBulb13.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb13.Location = new System.Drawing.Point(3, 40);
            this.uiLedBulb13.Name = "uiLedBulb13";
            this.uiLedBulb13.On = false;
            this.uiLedBulb13.Size = new System.Drawing.Size(15, 15);
            this.uiLedBulb13.TabIndex = 3449;
            this.uiLedBulb13.Text = "uiLedBulb4";
            // 
            // uiLedBulb17
            // 
            this.uiLedBulb17.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb17.Location = new System.Drawing.Point(3, 20);
            this.uiLedBulb17.Name = "uiLedBulb17";
            this.uiLedBulb17.On = false;
            this.uiLedBulb17.Size = new System.Drawing.Size(15, 15);
            this.uiLedBulb17.TabIndex = 3448;
            this.uiLedBulb17.Text = "uiLedBulb2";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(21, 40);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label17.Size = new System.Drawing.Size(144, 19);
            this.label17.TabIndex = 3448;
            this.label17.Text = "[D2003] MOVE START";
            // 
            // uiLedBulb18
            // 
            this.uiLedBulb18.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb18.Location = new System.Drawing.Point(3, 1);
            this.uiLedBulb18.Name = "uiLedBulb18";
            this.uiLedBulb18.On = false;
            this.uiLedBulb18.Size = new System.Drawing.Size(15, 15);
            this.uiLedBulb18.TabIndex = 3447;
            this.uiLedBulb18.Text = "uiLedBulb1";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(21, 20);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label18.Size = new System.Drawing.Size(144, 19);
            this.label18.TabIndex = 3446;
            this.label18.Text = "[DO-002] JUDGE NG";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(21, 0);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label19.Size = new System.Drawing.Size(144, 19);
            this.label19.TabIndex = 3444;
            this.label19.Text = "[DO-001] JUDGE OK";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 587);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 3549;
            this.label3.Text = "Monitoring";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(3, 615);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(151, 84);
            this.panel5.TabIndex = 3443;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.uiLedBulb7);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 59);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(151, 25);
            this.panel8.TabIndex = 3443;
            // 
            // uiLedBulb7
            // 
            this.uiLedBulb7.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb7.Location = new System.Drawing.Point(3, 1);
            this.uiLedBulb7.Name = "uiLedBulb7";
            this.uiLedBulb7.On = false;
            this.uiLedBulb7.Size = new System.Drawing.Size(15, 15);
            this.uiLedBulb7.TabIndex = 3447;
            this.uiLedBulb7.Text = "uiLedBulb1";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(21, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label14.Size = new System.Drawing.Size(144, 19);
            this.label14.TabIndex = 3444;
            this.label14.Text = "[D2004] GRAB START";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.uiLedBulb2);
            this.panel7.Controls.Add(this.uiLedBulb5);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.uiLedBulb6);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(151, 59);
            this.panel7.TabIndex = 3442;
            // 
            // uiLedBulb2
            // 
            this.uiLedBulb2.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb2.Location = new System.Drawing.Point(3, 40);
            this.uiLedBulb2.Name = "uiLedBulb2";
            this.uiLedBulb2.On = false;
            this.uiLedBulb2.Size = new System.Drawing.Size(15, 15);
            this.uiLedBulb2.TabIndex = 3449;
            this.uiLedBulb2.Text = "uiLedBulb4";
            // 
            // uiLedBulb5
            // 
            this.uiLedBulb5.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb5.Location = new System.Drawing.Point(3, 20);
            this.uiLedBulb5.Name = "uiLedBulb5";
            this.uiLedBulb5.On = false;
            this.uiLedBulb5.Size = new System.Drawing.Size(15, 15);
            this.uiLedBulb5.TabIndex = 3448;
            this.uiLedBulb5.Text = "uiLedBulb2";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(21, 40);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label8.Size = new System.Drawing.Size(144, 19);
            this.label8.TabIndex = 3448;
            this.label8.Text = "[D2003] MOVE START";
            // 
            // uiLedBulb6
            // 
            this.uiLedBulb6.Color = System.Drawing.Color.LimeGreen;
            this.uiLedBulb6.Location = new System.Drawing.Point(3, 1);
            this.uiLedBulb6.Name = "uiLedBulb6";
            this.uiLedBulb6.On = false;
            this.uiLedBulb6.Size = new System.Drawing.Size(15, 15);
            this.uiLedBulb6.TabIndex = 3447;
            this.uiLedBulb6.Text = "uiLedBulb1";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(21, 20);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label10.Size = new System.Drawing.Size(144, 19);
            this.label10.TabIndex = 3446;
            this.label10.Text = "[D2002] LOT START";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(21, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.label11.Size = new System.Drawing.Size(144, 19);
            this.label11.TabIndex = 3444;
            this.label11.Text = "[DI-001] INSP START";
            // 
            // uiLine6
            // 
            this.uiLine6.BackColor = System.Drawing.Color.Transparent;
            this.uiLine6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine6.LineColor = System.Drawing.Color.Black;
            this.uiLine6.Location = new System.Drawing.Point(56, 54);
            this.uiLine6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine6.Name = "uiLine6";
            this.uiLine6.Size = new System.Drawing.Size(150, 10);
            this.uiLine6.TabIndex = 3548;
            // 
            // uiLine5
            // 
            this.uiLine5.BackColor = System.Drawing.Color.Transparent;
            this.uiLine5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine5.LineColor = System.Drawing.Color.Black;
            this.uiLine5.Location = new System.Drawing.Point(56, 188);
            this.uiLine5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(150, 2);
            this.uiLine5.TabIndex = 3547;
            // 
            // uiLine4
            // 
            this.uiLine4.BackColor = System.Drawing.Color.Transparent;
            this.uiLine4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine4.LineColor = System.Drawing.Color.Black;
            this.uiLine4.Location = new System.Drawing.Point(56, 216);
            this.uiLine4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(150, 2);
            this.uiLine4.TabIndex = 3546;
            // 
            // uiLine3
            // 
            this.uiLine3.BackColor = System.Drawing.Color.Transparent;
            this.uiLine3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine3.LineColor = System.Drawing.Color.Black;
            this.uiLine3.Location = new System.Drawing.Point(56, 154);
            this.uiLine3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(150, 2);
            this.uiLine3.TabIndex = 3545;
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine2.LineColor = System.Drawing.Color.Black;
            this.uiLine2.Location = new System.Drawing.Point(56, 124);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(150, 2);
            this.uiLine2.TabIndex = 3544;
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.LineColor = System.Drawing.Color.Black;
            this.uiLine1.Location = new System.Drawing.Point(56, 93);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(150, 2);
            this.uiLine1.TabIndex = 3543;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 8F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(211, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3542;
            this.label2.Text = "(Tact Time : 00000 ms)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiDataGridView1
            // 
            this.uiDataGridView1.AllowUserToAddRows = false;
            this.uiDataGridView1.AllowUserToDeleteRows = false;
            this.uiDataGridView1.AllowUserToResizeColumns = false;
            this.uiDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.Silver;
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 260);
            this.uiDataGridView1.MultiSelect = false;
            this.uiDataGridView1.Name = "uiDataGridView1";
            this.uiDataGridView1.ReadOnly = true;
            this.uiDataGridView1.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.uiDataGridView1.RowHeadersVisible = false;
            this.uiDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridView1.RowTemplate.Height = 25;
            this.uiDataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView1.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView1.ScrollBarStyleInherited = false;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridView1.Size = new System.Drawing.Size(446, 315);
            this.uiDataGridView1.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView1.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView1.TabIndex = 3516;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Result";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Entered";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Font = new System.Drawing.Font("Arial", 8F);
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(323, 221);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(123, 13);
            this.label29.TabIndex = 3541;
            this.label29.Text = "Overkill Rank 1~5";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label30.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(8, 237);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(169, 20);
            this.label30.TabIndex = 3541;
            this.label30.Text = "Result View";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label28.Font = new System.Drawing.Font("Arial", 8F);
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(89, 8);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(123, 20);
            this.label28.TabIndex = 3540;
            this.label28.Text = "(Current Model / Total)";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(8, 6);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 20);
            this.label27.TabIndex = 3539;
            this.label27.Text = "Summary";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiDataGridView2
            // 
            this.uiDataGridView2.AllowUserToAddRows = false;
            this.uiDataGridView2.AllowUserToDeleteRows = false;
            this.uiDataGridView2.AllowUserToResizeColumns = false;
            this.uiDataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.uiDataGridView2.BackgroundColor = System.Drawing.Color.Silver;
            this.uiDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.uiDataGridView2.ColumnHeadersHeight = 24;
            this.uiDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView2.DefaultCellStyle = dataGridViewCellStyle8;
            this.uiDataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uiDataGridView2.EnableHeadersVisualStyles = false;
            this.uiDataGridView2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiDataGridView2.GridColor = System.Drawing.Color.Silver;
            this.uiDataGridView2.Location = new System.Drawing.Point(214, 34);
            this.uiDataGridView2.MultiSelect = false;
            this.uiDataGridView2.Name = "uiDataGridView2";
            this.uiDataGridView2.ReadOnly = true;
            this.uiDataGridView2.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.uiDataGridView2.RowHeadersVisible = false;
            this.uiDataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.uiDataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.uiDataGridView2.RowTemplate.Height = 25;
            this.uiDataGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView2.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView2.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.uiDataGridView2.ScrollBarStyleInherited = false;
            this.uiDataGridView2.SelectedIndex = -1;
            this.uiDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridView2.Size = new System.Drawing.Size(233, 184);
            this.uiDataGridView2.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView2.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uiDataGridView2.TabIndex = 3538;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "No";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 30;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Location";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Part";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 75;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Count";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 45;
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
            this.uiSymbolButton3.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.uiSymbolButton3.ForeColor = System.Drawing.Color.DimGray;
            this.uiSymbolButton3.ForeDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ForeHoverColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton3.ForePressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ForeSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButton3.Location = new System.Drawing.Point(348, 5);
            this.uiSymbolButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiSymbolButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton3.Name = "uiSymbolButton3";
            this.uiSymbolButton3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.uiSymbolButton3.RectColor = System.Drawing.Color.DimGray;
            this.uiSymbolButton3.RectDisableColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.RectHoverColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton3.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton3.Size = new System.Drawing.Size(95, 25);
            this.uiSymbolButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton3.StyleCustomMode = true;
            this.uiSymbolButton3.Symbol = 362201;
            this.uiSymbolButton3.SymbolColor = System.Drawing.Color.DimGray;
            this.uiSymbolButton3.SymbolHoverColor = System.Drawing.Color.SlateGray;
            this.uiSymbolButton3.SymbolSize = 16;
            this.uiSymbolButton3.TabIndex = 3535;
            this.uiSymbolButton3.Tag = "";
            this.uiSymbolButton3.Text = "RESET";
            this.uiSymbolButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiSymbolButton3.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Maroon;
            this.label20.Location = new System.Drawing.Point(62, 188);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label20.Size = new System.Drawing.Size(150, 30);
            this.label20.TabIndex = 3537;
            this.label20.Text = "0000 / 000000";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Maroon;
            this.label24.Location = new System.Drawing.Point(0, 188);
            this.label24.Name = "label24";
            this.label24.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label24.Size = new System.Drawing.Size(61, 30);
            this.label24.TabIndex = 3536;
            this.label24.Text = "NG (F)";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(0, 34);
            this.label25.Name = "label25";
            this.label25.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label25.Size = new System.Drawing.Size(61, 30);
            this.label25.TabIndex = 3522;
            this.label25.Text = "MODEL";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label26.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(62, 34);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(150, 30);
            this.label26.TabIndex = 3523;
            this.label26.Text = "-";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCurrentNG
            // 
            this.lbCurrentNG.BackColor = System.Drawing.Color.Transparent;
            this.lbCurrentNG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCurrentNG.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentNG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCurrentNG.Location = new System.Drawing.Point(62, 157);
            this.lbCurrentNG.Name = "lbCurrentNG";
            this.lbCurrentNG.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lbCurrentNG.Size = new System.Drawing.Size(150, 30);
            this.lbCurrentNG.TabIndex = 3396;
            this.lbCurrentNG.Text = "0000 / 000000";
            this.lbCurrentNG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCurrentYield
            // 
            this.lbCurrentYield.BackColor = System.Drawing.Color.Transparent;
            this.lbCurrentYield.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCurrentYield.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentYield.ForeColor = System.Drawing.Color.Black;
            this.lbCurrentYield.Location = new System.Drawing.Point(62, 95);
            this.lbCurrentYield.Name = "lbCurrentYield";
            this.lbCurrentYield.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lbCurrentYield.Size = new System.Drawing.Size(150, 30);
            this.lbCurrentYield.TabIndex = 3398;
            this.lbCurrentYield.Text = "0000 / 000000";
            this.lbCurrentYield.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(0, 157);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(61, 30);
            this.label4.TabIndex = 3395;
            this.label4.Text = "NG (T)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 95);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(61, 30);
            this.label1.TabIndex = 3397;
            this.label1.Text = "YIELD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 65);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(61, 30);
            this.label6.TabIndex = 3377;
            this.label6.Text = "TOTAL";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCurrentOK
            // 
            this.lbCurrentOK.BackColor = System.Drawing.Color.Transparent;
            this.lbCurrentOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCurrentOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentOK.ForeColor = System.Drawing.Color.Green;
            this.lbCurrentOK.Location = new System.Drawing.Point(62, 126);
            this.lbCurrentOK.Name = "lbCurrentOK";
            this.lbCurrentOK.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lbCurrentOK.Size = new System.Drawing.Size(150, 30);
            this.lbCurrentOK.TabIndex = 3383;
            this.lbCurrentOK.Text = "0000 / 000000";
            this.lbCurrentOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCurrentTotal
            // 
            this.lbCurrentTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbCurrentTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCurrentTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentTotal.ForeColor = System.Drawing.Color.Black;
            this.lbCurrentTotal.Location = new System.Drawing.Point(62, 65);
            this.lbCurrentTotal.Name = "lbCurrentTotal";
            this.lbCurrentTotal.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lbCurrentTotal.Size = new System.Drawing.Size(150, 30);
            this.lbCurrentTotal.TabIndex = 3378;
            this.lbCurrentTotal.Text = "0000 / 000000";
            this.lbCurrentTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(0, 126);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(61, 30);
            this.label5.TabIndex = 3382;
            this.label5.Text = "OK";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlArray4
            // 
            this.pnlArray4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlArray4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArray4.Controls.Add(this.cogDisplay_Array4);
            this.pnlArray4.Controls.Add(this.lblArray4);
            this.pnlArray4.Location = new System.Drawing.Point(723, 444);
            this.pnlArray4.Name = "pnlArray4";
            this.pnlArray4.Size = new System.Drawing.Size(722, 400);
            this.pnlArray4.TabIndex = 3198;
            // 
            // cogDisplay_Array4
            // 
            this.cogDisplay_Array4.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Array4.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_Array4.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_Array4.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Array4.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_Array4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay_Array4.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_Array4.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_Array4.Location = new System.Drawing.Point(0, 25);
            this.cogDisplay_Array4.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay_Array4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_Array4.MouseWheelSensitivity = 1D;
            this.cogDisplay_Array4.Name = "cogDisplay_Array4";
            this.cogDisplay_Array4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_Array4.OcxState")));
            this.cogDisplay_Array4.Size = new System.Drawing.Size(720, 373);
            this.cogDisplay_Array4.TabIndex = 3057;
            // 
            // lblArray4
            // 
            this.lblArray4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.lblArray4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblArray4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblArray4.Font = new System.Drawing.Font("Arial", 10F);
            this.lblArray4.ForeColor = System.Drawing.Color.White;
            this.lblArray4.Location = new System.Drawing.Point(0, 0);
            this.lblArray4.Name = "lblArray4";
            this.lblArray4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblArray4.Size = new System.Drawing.Size(720, 25);
            this.lblArray4.TabIndex = 3056;
            this.lblArray4.Text = "Array [4]";
            this.lblArray4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlArray3
            // 
            this.pnlArray3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlArray3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArray3.Controls.Add(this.cogDisplay_Array3);
            this.pnlArray3.Controls.Add(this.lblArray3);
            this.pnlArray3.Location = new System.Drawing.Point(-1, 444);
            this.pnlArray3.Name = "pnlArray3";
            this.pnlArray3.Size = new System.Drawing.Size(1447, 400);
            this.pnlArray3.TabIndex = 3197;
            // 
            // cogDisplay_Array3
            // 
            this.cogDisplay_Array3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Array3.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_Array3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_Array3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Array3.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_Array3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay_Array3.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_Array3.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_Array3.Location = new System.Drawing.Point(0, 25);
            this.cogDisplay_Array3.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay_Array3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_Array3.MouseWheelSensitivity = 1D;
            this.cogDisplay_Array3.Name = "cogDisplay_Array3";
            this.cogDisplay_Array3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_Array3.OcxState")));
            this.cogDisplay_Array3.Size = new System.Drawing.Size(1445, 373);
            this.cogDisplay_Array3.TabIndex = 3057;
            // 
            // lblArray3
            // 
            this.lblArray3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.lblArray3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblArray3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblArray3.Font = new System.Drawing.Font("Arial", 10F);
            this.lblArray3.ForeColor = System.Drawing.Color.White;
            this.lblArray3.Location = new System.Drawing.Point(0, 0);
            this.lblArray3.Name = "lblArray3";
            this.lblArray3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblArray3.Size = new System.Drawing.Size(1445, 25);
            this.lblArray3.TabIndex = 3056;
            this.lblArray3.Text = "Array [3]";
            this.lblArray3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlArray2
            // 
            this.pnlArray2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlArray2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArray2.Controls.Add(this.cogDisplay_Array2);
            this.pnlArray2.Controls.Add(this.lblArray2);
            this.pnlArray2.Location = new System.Drawing.Point(723, 0);
            this.pnlArray2.Name = "pnlArray2";
            this.pnlArray2.Size = new System.Drawing.Size(722, 445);
            this.pnlArray2.TabIndex = 3196;
            // 
            // cogDisplay_Array2
            // 
            this.cogDisplay_Array2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Array2.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_Array2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_Array2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Array2.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_Array2.Dock = System.Windows.Forms.DockStyle.Top;
            this.cogDisplay_Array2.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_Array2.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_Array2.Location = new System.Drawing.Point(0, 25);
            this.cogDisplay_Array2.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay_Array2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_Array2.MouseWheelSensitivity = 1D;
            this.cogDisplay_Array2.Name = "cogDisplay_Array2";
            this.cogDisplay_Array2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_Array2.OcxState")));
            this.cogDisplay_Array2.Size = new System.Drawing.Size(720, 800);
            this.cogDisplay_Array2.TabIndex = 3057;
            // 
            // lblArray2
            // 
            this.lblArray2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.lblArray2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblArray2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblArray2.Font = new System.Drawing.Font("Arial", 10F);
            this.lblArray2.ForeColor = System.Drawing.Color.White;
            this.lblArray2.Location = new System.Drawing.Point(0, 0);
            this.lblArray2.Name = "lblArray2";
            this.lblArray2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblArray2.Size = new System.Drawing.Size(720, 25);
            this.lblArray2.TabIndex = 3056;
            this.lblArray2.Text = "Array [2]";
            this.lblArray2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlArray1
            // 
            this.pnlArray1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlArray1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArray1.Controls.Add(this.cogDisplay_Array1);
            this.pnlArray1.Controls.Add(this.lblArray1);
            this.pnlArray1.Location = new System.Drawing.Point(0, 0);
            this.pnlArray1.Name = "pnlArray1";
            this.pnlArray1.Size = new System.Drawing.Size(722, 843);
            this.pnlArray1.TabIndex = 3195;
            // 
            // cogDisplay_Array1
            // 
            this.cogDisplay_Array1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Array1.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_Array1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_Array1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Array1.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_Array1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cogDisplay_Array1.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_Array1.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_Array1.Location = new System.Drawing.Point(0, 25);
            this.cogDisplay_Array1.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay_Array1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_Array1.MouseWheelSensitivity = 1D;
            this.cogDisplay_Array1.Name = "cogDisplay_Array1";
            this.cogDisplay_Array1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_Array1.OcxState")));
            this.cogDisplay_Array1.Size = new System.Drawing.Size(720, 800);
            this.cogDisplay_Array1.TabIndex = 3057;
            // 
            // lblArray1
            // 
            this.lblArray1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.lblArray1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblArray1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblArray1.Font = new System.Drawing.Font("Arial", 10F);
            this.lblArray1.ForeColor = System.Drawing.Color.White;
            this.lblArray1.Location = new System.Drawing.Point(0, 0);
            this.lblArray1.Name = "lblArray1";
            this.lblArray1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblArray1.Size = new System.Drawing.Size(720, 25);
            this.lblArray1.TabIndex = 3056;
            this.lblArray1.Text = "Array [1]";
            this.lblArray1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_MenuMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 860);
            this.Controls.Add(this.pnlArray4);
            this.Controls.Add(this.pnlArray3);
            this.Controls.Add(this.pnlArray2);
            this.Controls.Add(this.pnlArray1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 910);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "Form_MenuMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form_MenuMain_Load);
            this.Shown += new System.EventHandler(this.Form_MenuMain_Shown);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView2)).EndInit();
            this.pnlArray4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Array4)).EndInit();
            this.pnlArray3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Array3)).EndInit();
            this.pnlArray2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Array2)).EndInit();
            this.pnlArray1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Array1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerStatus;
        private Sunny.UI.UIPanel pnlRegist;
        private Sunny.UI.UITextBox uiTextBox5;
        private Sunny.UI.UISymbolButton uiSymbolButton4;
        private PropertyGrid propertyGrid1;
        private Timer timerInit;
        private Panel panel2;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Panel panel5;
        private Panel panel8;
        private Sunny.UI.UILedBulb uiLedBulb7;
        private Label label14;
        private Panel panel7;
        private Sunny.UI.UILedBulb uiLedBulb2;
        private Sunny.UI.UILedBulb uiLedBulb5;
        private Label label8;
        private Sunny.UI.UILedBulb uiLedBulb6;
        private Label label10;
        private Label label11;
        private Panel pnlArray4;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay_Array4;
        private Label lblArray4;
        private Panel pnlArray3;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay_Array3;
        private Label lblArray3;
        private Panel pnlArray2;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay_Array2;
        private Label lblArray2;
        private Panel pnlArray1;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay_Array1;
        private Label lblArray1;
        private Panel panel6;
        private Panel panel10;
        private Sunny.UI.UILedBulb uiLedBulb12;
        private Label label16;
        private Panel panel11;
        private Sunny.UI.UILedBulb uiLedBulb13;
        private Sunny.UI.UILedBulb uiLedBulb17;
        private Label label17;
        private Sunny.UI.UILedBulb uiLedBulb18;
        private Label label18;
        private Label label19;
        private Label lbCurrentNG;
        private Label lbCurrentYield;
        private Label label4;
        private Label label1;
        private Label label6;
        private Label lbCurrentOK;
        private Label lbCurrentTotal;
        private Label label5;
        private Sunny.UI.UISymbolButton uiSymbolButton3;
        private Label label25;
        private Label label26;
        private Label label20;
        private Label label24;
        private Label label27;
        private Sunny.UI.UIDataGridView uiDataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Column2;
        private Label label29;
        private Label label30;
        private Label label28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn Column1;
        private Label label2;
        private Label label3;
        private Sunny.UI.UILine uiLine6;
        private Sunny.UI.UILine uiLine5;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine1;
    }
}