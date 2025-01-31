namespace IntelligentFactory
{
    partial class FormMenu_ARC_Tester
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
            this.btn_ARC_PREPARE = new System.Windows.Forms.Button();
            this.btn_ARC_MACHINESTART = new System.Windows.Forms.Button();
            this.btn_ARC_Mchange_End = new System.Windows.Forms.Button();
            this.btn_ARC_NowModel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_ARC_PREPARE_NG = new System.Windows.Forms.RadioButton();
            this.rb_ARC_PREPARE_OK = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rb_ARC_MACHINEEND_WAIT = new System.Windows.Forms.RadioButton();
            this.rb_ARC_MACHINEEND_NG = new System.Windows.Forms.RadioButton();
            this.rb_ARC_MACHINEEND_OK = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ARC_NOWMODEL_NAME = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tmr_ARC_Log = new System.Windows.Forms.Timer(this.components);
            this.lbl_ARC = new System.Windows.Forms.Label();
            this.lb_ARC_Log = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ARC_PREPARE
            // 
            this.btn_ARC_PREPARE.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ARC_PREPARE.Location = new System.Drawing.Point(13, 40);
            this.btn_ARC_PREPARE.Name = "btn_ARC_PREPARE";
            this.btn_ARC_PREPARE.Size = new System.Drawing.Size(94, 35);
            this.btn_ARC_PREPARE.TabIndex = 0;
            this.btn_ARC_PREPARE.Text = "PREPARE";
            this.btn_ARC_PREPARE.UseVisualStyleBackColor = true;
            this.btn_ARC_PREPARE.Click += new System.EventHandler(this.btn_ARC_PREPARE_Click);
            // 
            // btn_ARC_MACHINESTART
            // 
            this.btn_ARC_MACHINESTART.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ARC_MACHINESTART.Location = new System.Drawing.Point(14, 40);
            this.btn_ARC_MACHINESTART.Name = "btn_ARC_MACHINESTART";
            this.btn_ARC_MACHINESTART.Size = new System.Drawing.Size(282, 35);
            this.btn_ARC_MACHINESTART.TabIndex = 2;
            this.btn_ARC_MACHINESTART.Text = "MACHINE_START";
            this.btn_ARC_MACHINESTART.UseVisualStyleBackColor = true;
            this.btn_ARC_MACHINESTART.Click += new System.EventHandler(this.btn_ARC_MACHINESTART_Click);
            // 
            // btn_ARC_Mchange_End
            // 
            this.btn_ARC_Mchange_End.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ARC_Mchange_End.Location = new System.Drawing.Point(13, 35);
            this.btn_ARC_Mchange_End.Name = "btn_ARC_Mchange_End";
            this.btn_ARC_Mchange_End.Size = new System.Drawing.Size(104, 43);
            this.btn_ARC_Mchange_End.TabIndex = 3;
            this.btn_ARC_Mchange_End.Text = "MCHANGE_END";
            this.btn_ARC_Mchange_End.UseVisualStyleBackColor = true;
            this.btn_ARC_Mchange_End.Click += new System.EventHandler(this.btn_ARC_Mchange_End_Click);
            // 
            // btn_ARC_NowModel
            // 
            this.btn_ARC_NowModel.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ARC_NowModel.Location = new System.Drawing.Point(13, 35);
            this.btn_ARC_NowModel.Name = "btn_ARC_NowModel";
            this.btn_ARC_NowModel.Size = new System.Drawing.Size(100, 43);
            this.btn_ARC_NowModel.TabIndex = 4;
            this.btn_ARC_NowModel.Text = "NOW_MODEL";
            this.btn_ARC_NowModel.UseVisualStyleBackColor = true;
            this.btn_ARC_NowModel.Click += new System.EventHandler(this.btn_ARC_NowModel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_ARC_PREPARE_NG);
            this.panel1.Controls.Add(this.rb_ARC_PREPARE_OK);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btn_ARC_PREPARE);
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 89);
            this.panel1.TabIndex = 5;
            // 
            // rb_ARC_PREPARE_NG
            // 
            this.rb_ARC_PREPARE_NG.AutoSize = true;
            this.rb_ARC_PREPARE_NG.ForeColor = System.Drawing.Color.White;
            this.rb_ARC_PREPARE_NG.Location = new System.Drawing.Point(176, 49);
            this.rb_ARC_PREPARE_NG.Name = "rb_ARC_PREPARE_NG";
            this.rb_ARC_PREPARE_NG.Size = new System.Drawing.Size(41, 16);
            this.rb_ARC_PREPARE_NG.TabIndex = 2755;
            this.rb_ARC_PREPARE_NG.Text = "NG";
            this.rb_ARC_PREPARE_NG.UseVisualStyleBackColor = true;
            // 
            // rb_ARC_PREPARE_OK
            // 
            this.rb_ARC_PREPARE_OK.AutoSize = true;
            this.rb_ARC_PREPARE_OK.Checked = true;
            this.rb_ARC_PREPARE_OK.ForeColor = System.Drawing.Color.White;
            this.rb_ARC_PREPARE_OK.Location = new System.Drawing.Point(130, 49);
            this.rb_ARC_PREPARE_OK.Name = "rb_ARC_PREPARE_OK";
            this.rb_ARC_PREPARE_OK.Size = new System.Drawing.Size(40, 16);
            this.rb_ARC_PREPARE_OK.TabIndex = 2754;
            this.rb_ARC_PREPARE_OK.TabStop = true;
            this.rb_ARC_PREPARE_OK.Text = "OK";
            this.rb_ARC_PREPARE_OK.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 28);
            this.label4.TabIndex = 2753;
            this.label4.Text = "REQUEST,MCHANGE,PREPARE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_ARC_MACHINESTART);
            this.panel2.Location = new System.Drawing.Point(273, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 89);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 28);
            this.label1.TabIndex = 2753;
            this.label1.Text = "EQUIP_NAME,MCHANGE,MACHINE_START";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rb_ARC_MACHINEEND_WAIT);
            this.panel3.Controls.Add(this.rb_ARC_MACHINEEND_NG);
            this.panel3.Controls.Add(this.rb_ARC_MACHINEEND_OK);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btn_ARC_Mchange_End);
            this.panel3.Location = new System.Drawing.Point(12, 149);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 89);
            this.panel3.TabIndex = 7;
            // 
            // rb_ARC_MACHINEEND_WAIT
            // 
            this.rb_ARC_MACHINEEND_WAIT.AutoSize = true;
            this.rb_ARC_MACHINEEND_WAIT.ForeColor = System.Drawing.Color.White;
            this.rb_ARC_MACHINEEND_WAIT.Location = new System.Drawing.Point(223, 48);
            this.rb_ARC_MACHINEEND_WAIT.Name = "rb_ARC_MACHINEEND_WAIT";
            this.rb_ARC_MACHINEEND_WAIT.Size = new System.Drawing.Size(52, 16);
            this.rb_ARC_MACHINEEND_WAIT.TabIndex = 2756;
            this.rb_ARC_MACHINEEND_WAIT.Text = "WAIT";
            this.rb_ARC_MACHINEEND_WAIT.UseVisualStyleBackColor = true;
            // 
            // rb_ARC_MACHINEEND_NG
            // 
            this.rb_ARC_MACHINEEND_NG.AutoSize = true;
            this.rb_ARC_MACHINEEND_NG.ForeColor = System.Drawing.Color.White;
            this.rb_ARC_MACHINEEND_NG.Location = new System.Drawing.Point(176, 48);
            this.rb_ARC_MACHINEEND_NG.Name = "rb_ARC_MACHINEEND_NG";
            this.rb_ARC_MACHINEEND_NG.Size = new System.Drawing.Size(41, 16);
            this.rb_ARC_MACHINEEND_NG.TabIndex = 2755;
            this.rb_ARC_MACHINEEND_NG.Text = "NG";
            this.rb_ARC_MACHINEEND_NG.UseVisualStyleBackColor = true;
            // 
            // rb_ARC_MACHINEEND_OK
            // 
            this.rb_ARC_MACHINEEND_OK.AutoSize = true;
            this.rb_ARC_MACHINEEND_OK.Checked = true;
            this.rb_ARC_MACHINEEND_OK.ForeColor = System.Drawing.Color.White;
            this.rb_ARC_MACHINEEND_OK.Location = new System.Drawing.Point(130, 48);
            this.rb_ARC_MACHINEEND_OK.Name = "rb_ARC_MACHINEEND_OK";
            this.rb_ARC_MACHINEEND_OK.Size = new System.Drawing.Size(40, 16);
            this.rb_ARC_MACHINEEND_OK.TabIndex = 2754;
            this.rb_ARC_MACHINEEND_OK.TabStop = true;
            this.rb_ARC_MACHINEEND_OK.Text = "OK";
            this.rb_ARC_MACHINEEND_OK.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 28);
            this.label2.TabIndex = 2753;
            this.label2.Text = "EQUIP_NAME,MCHANGE,MACHINE_END";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txt_ARC_NOWMODEL_NAME);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btn_ARC_NowModel);
            this.panel4.Location = new System.Drawing.Point(312, 149);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(274, 89);
            this.panel4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(119, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 12);
            this.label5.TabIndex = 2755;
            this.label5.Text = "NOW Model : ";
            // 
            // txt_ARC_NOWMODEL_NAME
            // 
            this.txt_ARC_NOWMODEL_NAME.Location = new System.Drawing.Point(119, 57);
            this.txt_ARC_NOWMODEL_NAME.Name = "txt_ARC_NOWMODEL_NAME";
            this.txt_ARC_NOWMODEL_NAME.Size = new System.Drawing.Size(138, 21);
            this.txt_ARC_NOWMODEL_NAME.TabIndex = 2754;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 28);
            this.label3.TabIndex = 2753;
            this.label3.Text = "EQUIP_NAME,MCHANGE,NOW_MODEL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmr_ARC_Log
            // 
            this.tmr_ARC_Log.Enabled = true;
            this.tmr_ARC_Log.Interval = 1;
            this.tmr_ARC_Log.Tick += new System.EventHandler(this.tmr_ARC_Log_Tick);
            // 
            // lbl_ARC
            // 
            this.lbl_ARC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(79)))), ((int)(((byte)(82)))));
            this.lbl_ARC.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_ARC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_ARC.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ARC.ForeColor = System.Drawing.Color.White;
            this.lbl_ARC.Location = new System.Drawing.Point(0, 0);
            this.lbl_ARC.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lbl_ARC.Name = "lbl_ARC";
            this.lbl_ARC.Size = new System.Drawing.Size(604, 34);
            this.lbl_ARC.TabIndex = 3364;
            this.lbl_ARC.Text = "A.R.C";
            this.lbl_ARC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_ARC_Log
            // 
            this.lb_ARC_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(76)))));
            this.lb_ARC_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_ARC_Log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lb_ARC_Log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_ARC_Log.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ARC_Log.ForeColor = System.Drawing.Color.White;
            this.lb_ARC_Log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lb_ARC_Log.HideSelection = false;
            this.lb_ARC_Log.Location = new System.Drawing.Point(0, 256);
            this.lb_ARC_Log.MultiSelect = false;
            this.lb_ARC_Log.Name = "lb_ARC_Log";
            this.lb_ARC_Log.Size = new System.Drawing.Size(604, 131);
            this.lb_ARC_Log.TabIndex = 3365;
            this.lb_ARC_Log.UseCompatibleStateImageBehavior = false;
            this.lb_ARC_Log.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 800;
            // 
            // FormMenu_ARC_Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(604, 387);
            this.Controls.Add(this.lb_ARC_Log);
            this.Controls.Add(this.lbl_ARC);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenu_ARC_Tester";
            this.Text = "ARC TCP Tester";
            this.Load += new System.EventHandler(this.FormMenu_ARC_Tester_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ARC_PREPARE;
        private System.Windows.Forms.Button btn_ARC_MACHINESTART;
        private System.Windows.Forms.Button btn_ARC_Mchange_End;
        private System.Windows.Forms.Button btn_ARC_NowModel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rb_ARC_PREPARE_NG;
        private System.Windows.Forms.RadioButton rb_ARC_PREPARE_OK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rb_ARC_MACHINEEND_NG;
        private System.Windows.Forms.RadioButton rb_ARC_MACHINEEND_OK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_ARC_MACHINEEND_WAIT;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ARC_NOWMODEL_NAME;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer tmr_ARC_Log;
        private System.Windows.Forms.Label lbl_ARC;
        private System.Windows.Forms.ListView lb_ARC_Log;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}