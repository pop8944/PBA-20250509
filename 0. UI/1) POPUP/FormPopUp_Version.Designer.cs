namespace IntelligentFactory.Version
{
    partial class FormPopUp_Version
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
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbLiberary = new System.Windows.Forms.ComboBox();
            this.btnMakeSWDocuments = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbVersion
            // 
            this.tbVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.tbVersion.ForeColor = System.Drawing.SystemColors.Window;
            this.tbVersion.Location = new System.Drawing.Point(1, 38);
            this.tbVersion.Multiline = true;
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbVersion.Size = new System.Drawing.Size(798, 364);
            this.tbVersion.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(680, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 41);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbLiberary
            // 
            this.cmbLiberary.FormattingEnabled = true;
            this.cmbLiberary.Location = new System.Drawing.Point(1, 12);
            this.cmbLiberary.Name = "cmbLiberary";
            this.cmbLiberary.Size = new System.Drawing.Size(256, 20);
            this.cmbLiberary.TabIndex = 5;
            this.cmbLiberary.SelectedIndexChanged += new System.EventHandler(this.cmbLiberary_SelectedIndexChanged);
            // 
            // btnMakeSWDocuments
            // 
            this.btnMakeSWDocuments.Location = new System.Drawing.Point(661, 7);
            this.btnMakeSWDocuments.Name = "btnMakeSWDocuments";
            this.btnMakeSWDocuments.Size = new System.Drawing.Size(137, 25);
            this.btnMakeSWDocuments.TabIndex = 6;
            this.btnMakeSWDocuments.Text = "Make SW Documents";
            this.btnMakeSWDocuments.UseVisualStyleBackColor = true;
            this.btnMakeSWDocuments.Visible = false;
            this.btnMakeSWDocuments.Click += new System.EventHandler(this.btnMakeSWDocuments_Click);
            // 
            // FormPopUp_Version
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(53)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(800, 447);
            this.Controls.Add(this.btnMakeSWDocuments);
            this.Controls.Add(this.cmbLiberary);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbVersion);
            this.Name = "FormPopUp_Version";
            this.Text = "FormPopUp_Version";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbLiberary;
        private System.Windows.Forms.Button btnMakeSWDocuments;
    }
}