namespace IntelligentFactory
{
    partial class FormMenu_Measure
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
            ImageGlass.DefaultGifAnimator defaultGifAnimator1 = new ImageGlass.DefaultGifAnimator();
            this.btnClose = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ibSource = new ImageGlass.ImageBoxEx();
            this.label18 = new System.Windows.Forms.Label();
            this.tbPixelSize = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnApply = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::IntelligentFactory.Properties.Resources.Cancel50_Normal;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(0, 758);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnClose.Size = new System.Drawing.Size(200, 75);
            this.btnClose.TabIndex = 2518;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1424, 28);
            this.label9.TabIndex = 2527;
            this.label9.Text = "Measure";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ibSource
            // 
            this.ibSource.Animator = defaultGifAnimator1;
            this.ibSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibSource.Location = new System.Drawing.Point(0, 28);
            this.ibSource.Name = "ibSource";
            this.ibSource.Size = new System.Drawing.Size(1224, 833);
            this.ibSource.TabIndex = 2528;
            this.ibSource.Zoom = 100D;
            this.ibSource.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ibSource_MouseDoubleClick);
            this.ibSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ibSource_MouseDown);
            this.ibSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ibSource_MouseMove);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("Arial", 9F);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(200, 23);
            this.label18.TabIndex = 2728;
            this.label18.Text = "Pixel Size (mm)";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPixelSize
            // 
            this.tbPixelSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.tbPixelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPixelSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbPixelSize.Font = new System.Drawing.Font("Arial", 10F);
            this.tbPixelSize.ForeColor = System.Drawing.Color.White;
            this.tbPixelSize.Location = new System.Drawing.Point(0, 23);
            this.tbPixelSize.Name = "tbPixelSize";
            this.tbPixelSize.Size = new System.Drawing.Size(200, 23);
            this.tbPixelSize.TabIndex = 2727;
            this.tbPixelSize.Text = "0.001";
            this.tbPixelSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Arial", 9F);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(90, 47);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 25);
            this.btnApply.TabIndex = 2729;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbPixelSize);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1224, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 833);
            this.panel1.TabIndex = 2730;
            // 
            // FormMenu_Measure
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1424, 861);
            this.ControlBox = false;
            this.Controls.Add(this.ibSource);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMenu_Measure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measure";
            this.Load += new System.EventHandler(this.FormMenu_Measure_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label9;
        private ImageGlass.ImageBoxEx ibSource;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbPixelSize;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel panel1;
    }
}