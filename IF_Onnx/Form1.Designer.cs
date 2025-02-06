namespace IFOnnxRuntime
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LblModel = new System.Windows.Forms.Label();
            this.LblImage = new System.Windows.Forms.Label();
            this.PbOrigin = new System.Windows.Forms.PictureBox();
            this.PbResult = new System.Windows.Forms.PictureBox();
            this.BtnRun = new System.Windows.Forms.Button();
            this.ifOnnxRuntimeControl1 = new FrameworkOnnxTest.IFOnnxRuntimeControl();
            ((System.ComponentModel.ISupportInitialize)(this.PbOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Onnx Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Image Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LblModel
            // 
            this.LblModel.AutoSize = true;
            this.LblModel.Location = new System.Drawing.Point(161, 30);
            this.LblModel.Name = "LblModel";
            this.LblModel.Size = new System.Drawing.Size(0, 12);
            this.LblModel.TabIndex = 4;
            // 
            // LblImage
            // 
            this.LblImage.AutoSize = true;
            this.LblImage.Location = new System.Drawing.Point(136, 79);
            this.LblImage.Name = "LblImage";
            this.LblImage.Size = new System.Drawing.Size(0, 12);
            this.LblImage.TabIndex = 5;
            // 
            // PbOrigin
            // 
            this.PbOrigin.Location = new System.Drawing.Point(31, 128);
            this.PbOrigin.Name = "PbOrigin";
            this.PbOrigin.Size = new System.Drawing.Size(302, 267);
            this.PbOrigin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbOrigin.TabIndex = 6;
            this.PbOrigin.TabStop = false;
            // 
            // PbResult
            // 
            this.PbResult.Location = new System.Drawing.Point(411, 128);
            this.PbResult.Name = "PbResult";
            this.PbResult.Size = new System.Drawing.Size(302, 267);
            this.PbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbResult.TabIndex = 7;
            this.PbResult.TabStop = false;
            // 
            // BtnRun
            // 
            this.BtnRun.Location = new System.Drawing.Point(763, 128);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(75, 23);
            this.BtnRun.TabIndex = 8;
            this.BtnRun.Text = "Run";
            this.BtnRun.UseVisualStyleBackColor = true;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // ifOnnxRuntimeControl1
            // 
            this.ifOnnxRuntimeControl1.Location = new System.Drawing.Point(250, 178);
            this.ifOnnxRuntimeControl1.Name = "ifOnnxRuntimeControl1";
            this.ifOnnxRuntimeControl1.Size = new System.Drawing.Size(759, 446);
            this.ifOnnxRuntimeControl1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 676);
            this.Controls.Add(this.ifOnnxRuntimeControl1);
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.PbResult);
            this.Controls.Add(this.PbOrigin);
            this.Controls.Add(this.LblImage);
            this.Controls.Add(this.LblModel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PbOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LblModel;
        private System.Windows.Forms.Label LblImage;
        private System.Windows.Forms.PictureBox PbOrigin;
        private System.Windows.Forms.PictureBox PbResult;
        private System.Windows.Forms.Button BtnRun;
        private FrameworkOnnxTest.IFOnnxRuntimeControl ifOnnxRuntimeControl1;
    }
}

