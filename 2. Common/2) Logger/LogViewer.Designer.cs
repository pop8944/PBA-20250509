namespace IntelligentFactory
{
    partial class LogViewer
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerDisplayLog = new System.Windows.Forms.Timer(this.components);
            this.richTextBoxExLog = new IntelligentFactory.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // timerDisplayLog
            // 
            this.timerDisplayLog.Enabled = true;
            this.timerDisplayLog.Interval = 1000;
            this.timerDisplayLog.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // richTextBoxExLog
            // 
            this.richTextBoxExLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.richTextBoxExLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxExLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxExLog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxExLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxExLog.Name = "richTextBoxExLog";
            this.richTextBoxExLog.Size = new System.Drawing.Size(398, 368);
            this.richTextBoxExLog.TabIndex = 0;
            this.richTextBoxExLog.Text = "";
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.richTextBoxExLog);
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "LogViewer";
            this.Size = new System.Drawing.Size(398, 368);
            this.Load += new System.EventHandler(this.LogViewList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerDisplayLog;
        private RichTextBoxEx richTextBoxExLog;
    }
}
