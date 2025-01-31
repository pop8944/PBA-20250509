namespace IntelligentFactory
{
    partial class FormPopUp_ProgressBar
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
            this.lbDesc = new System.Windows.Forms.Label();
            this.mPrsBar = new MetroFramework.Controls.MetroProgressBar();
            this.SuspendLayout();
            // 
            // lbDesc
            // 
            this.lbDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lbDesc.ForeColor = System.Drawing.Color.IndianRed;
            this.lbDesc.Location = new System.Drawing.Point(10, 0);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(815, 28);
            this.lbDesc.TabIndex = 2462;
            this.lbDesc.Text = "Label Position";
            this.lbDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mPrsBar
            // 
            this.mPrsBar.FontWeight = MetroFramework.MetroProgressBarWeight.Regular;
            this.mPrsBar.HideProgressText = false;
            this.mPrsBar.Location = new System.Drawing.Point(3, 60);
            this.mPrsBar.Name = "mPrsBar";
            this.mPrsBar.Size = new System.Drawing.Size(831, 59);
            this.mPrsBar.Style = MetroFramework.MetroColorStyle.Blue;
            this.mPrsBar.TabIndex = 2464;
            this.mPrsBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mPrsBar.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // FormPopUp_ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(836, 126);
            this.ControlBox = false;
            this.Controls.Add(this.mPrsBar);
            this.Controls.Add(this.lbDesc);
            this.ForeColor = System.Drawing.Color.IndianRed;
            this.Name = "FormPopUp_ProgressBar";
            this.Text = "FormPopUp_ProgressBar";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbDesc;
        private MetroFramework.Controls.MetroProgressBar mPrsBar;
    }
}