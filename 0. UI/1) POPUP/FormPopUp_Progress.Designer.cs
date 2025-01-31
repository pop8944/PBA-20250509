﻿
namespace IntelligentFactory
{
    partial class FormPopup_Progress
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
            this.circularProgressBar5 = new CircularProgressBar.CircularProgressBar();
            this.lbTackTime = new System.Windows.Forms.Label();
            this.timerTackTime = new System.Windows.Forms.Timer(this.components);
            this.lbName = new System.Windows.Forms.Label();
            this.lbDesc = new System.Windows.Forms.Label();
            this.btnCancel = new Sunny.UI.UISymbolButton();
            this.timerSelected = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // circularProgressBar5
            // 
            this.circularProgressBar5.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar5.AnimationSpeed = 500;
            this.circularProgressBar5.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar5.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar5.InnerColor = System.Drawing.Color.Black;
            this.circularProgressBar5.InnerMargin = 0;
            this.circularProgressBar5.InnerWidth = 0;
            this.circularProgressBar5.Location = new System.Drawing.Point(245, 75);
            this.circularProgressBar5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.circularProgressBar5.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar5.Name = "circularProgressBar5";
            this.circularProgressBar5.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.circularProgressBar5.OuterMargin = -11;
            this.circularProgressBar5.OuterWidth = 8;
            this.circularProgressBar5.ProgressColor = System.Drawing.Color.LightGreen;
            this.circularProgressBar5.ProgressWidth = 14;
            this.circularProgressBar5.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 4.125F);
            this.circularProgressBar5.Size = new System.Drawing.Size(238, 181);
            this.circularProgressBar5.StartAngle = 270;
            this.circularProgressBar5.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar5.SubscriptColor = System.Drawing.Color.Transparent;
            this.circularProgressBar5.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBar5.SubscriptText = "";
            this.circularProgressBar5.SuperscriptColor = System.Drawing.Color.Transparent;
            this.circularProgressBar5.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBar5.SuperscriptText = "";
            this.circularProgressBar5.TabIndex = 11;
            this.circularProgressBar5.Text = "Please Wait";
            this.circularProgressBar5.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.circularProgressBar5.Value = 67;
            // 
            // lbTackTime
            // 
            this.lbTackTime.AutoSize = true;
            this.lbTackTime.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
            this.lbTackTime.ForeColor = System.Drawing.Color.White;
            this.lbTackTime.Location = new System.Drawing.Point(319, 190);
            this.lbTackTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTackTime.Name = "lbTackTime";
            this.lbTackTime.Size = new System.Drawing.Size(89, 32);
            this.lbTackTime.TabIndex = 12;
            this.lbTackTime.Text = "00:00";
            // 
            // timerTackTime
            // 
            this.timerTackTime.Enabled = true;
            this.timerTackTime.Tick += new System.EventHandler(this.timerTackTime_Tick);
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(7, 7);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(587, 60);
            this.lbName.TabIndex = 21;
            this.lbName.Text = "PROGRESS";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDesc
            // 
            this.lbDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbDesc.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesc.ForeColor = System.Drawing.Color.White;
            this.lbDesc.Location = new System.Drawing.Point(63, 281);
            this.lbDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(598, 62);
            this.lbDesc.TabIndex = 2461;
            this.lbDesc.Text = "Label Position";
            this.lbDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnCancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(581, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RectColor = System.Drawing.Color.White;
            this.btnCancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnCancel.RectPressColor = System.Drawing.Color.White;
            this.btnCancel.RectSelectedColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(134, 33);
            this.btnCancel.Style = Sunny.UI.UIStyle.Custom;
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.Symbol = 61453;
            this.btnCancel.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.btnCancel.SymbolSize = 20;
            this.btnCancel.TabIndex = 3253;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // timerSelected
            // 
            this.timerSelected.Enabled = true;
            this.timerSelected.Tick += new System.EventHandler(this.timerSelected_Tick);
            // 
            // FormPopup_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.ClientSize = new System.Drawing.Size(720, 371);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbTackTime);
            this.Controls.Add(this.circularProgressBar5);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.lbName);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormPopup_Progress";
            this.Opacity = 0.7D;
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROGRESS";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPopup_Progress_FormClosing);
            this.Load += new System.EventHandler(this.FormPopUp_Progress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularProgressBar.CircularProgressBar circularProgressBar5;
        private System.Windows.Forms.Label lbTackTime;
        private System.Windows.Forms.Timer timerTackTime;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDesc;
        private Sunny.UI.UISymbolButton btnCancel;
        private System.Windows.Forms.Timer timerSelected;
    }
}