
namespace IntelligentFactory
{
    partial class FormPopUp_ImageView2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPopUp_ImageView2));
            this.cogDisplay_Master = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay_Result = new Cognex.VisionPro.Display.CogDisplay();
            this.btnClose = new System.Windows.Forms.Button();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lbSelectArray1 = new System.Windows.Forms.Label();
            this.lbSelectArray2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Master)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Result)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cogDisplay_Master
            // 
            this.cogDisplay_Master.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Master.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_Master.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_Master.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Master.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_Master.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay_Master.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_Master.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_Master.Location = new System.Drawing.Point(0, 25);
            this.cogDisplay_Master.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay_Master.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_Master.MouseWheelSensitivity = 1D;
            this.cogDisplay_Master.Name = "cogDisplay_Master";
            this.cogDisplay_Master.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_Master.OcxState")));
            this.cogDisplay_Master.Size = new System.Drawing.Size(494, 924);
            this.cogDisplay_Master.TabIndex = 2644;
            // 
            // cogDisplay_Result
            // 
            this.cogDisplay_Result.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Result.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_Result.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_Result.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Result.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay_Result.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_Result.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_Result.Location = new System.Drawing.Point(0, 25);
            this.cogDisplay_Result.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay_Result.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_Result.MouseWheelSensitivity = 1D;
            this.cogDisplay_Result.Name = "cogDisplay_Result";
            this.cogDisplay_Result.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_Result.OcxState")));
            this.cogDisplay_Result.Size = new System.Drawing.Size(515, 924);
            this.cogDisplay_Result.TabIndex = 2645;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::IntelligentFactory.Properties.Resources.Cancel50_Normal;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(860, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 2646;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.metroLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.ForeColor = System.Drawing.Color.White;
            this.metroLabel3.Location = new System.Drawing.Point(0, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(494, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel3.TabIndex = 2647;
            this.metroLabel3.Text = "MASTER IMG";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cogDisplay_Master);
            this.panel1.Controls.Add(this.metroLabel3);
            this.panel1.Location = new System.Drawing.Point(-3, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 949);
            this.panel1.TabIndex = 2648;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cogDisplay_Result);
            this.panel2.Controls.Add(this.metroLabel1);
            this.panel2.Location = new System.Drawing.Point(498, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 949);
            this.panel2.TabIndex = 2649;
            // 
            // metroLabel1
            // 
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.ForeColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(0, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(515, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel1.TabIndex = 2648;
            this.metroLabel1.Text = "RESULT IMG";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.ForeColor = System.Drawing.Color.White;
            this.metroLabel2.Location = new System.Drawing.Point(-3, 4);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(733, 38);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel2.TabIndex = 2650;
            this.metroLabel2.Text = "Viewer";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // lbSelectArray1
            // 
            this.lbSelectArray1.BackColor = System.Drawing.Color.Green;
            this.lbSelectArray1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSelectArray1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbSelectArray1.Font = new System.Drawing.Font("Arial", 9F);
            this.lbSelectArray1.ForeColor = System.Drawing.Color.White;
            this.lbSelectArray1.Location = new System.Drawing.Point(732, 4);
            this.lbSelectArray1.Name = "lbSelectArray1";
            this.lbSelectArray1.Size = new System.Drawing.Size(60, 38);
            this.lbSelectArray1.TabIndex = 2654;
            this.lbSelectArray1.Text = "1";
            this.lbSelectArray1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSelectArray1.Click += new System.EventHandler(this.OnClick);
            // 
            // lbSelectArray2
            // 
            this.lbSelectArray2.BackColor = System.Drawing.Color.Transparent;
            this.lbSelectArray2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSelectArray2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbSelectArray2.Font = new System.Drawing.Font("Arial", 9F);
            this.lbSelectArray2.ForeColor = System.Drawing.Color.White;
            this.lbSelectArray2.Location = new System.Drawing.Point(794, 4);
            this.lbSelectArray2.Name = "lbSelectArray2";
            this.lbSelectArray2.Size = new System.Drawing.Size(60, 38);
            this.lbSelectArray2.TabIndex = 2655;
            this.lbSelectArray2.Text = "2";
            this.lbSelectArray2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSelectArray2.Click += new System.EventHandler(this.OnClick);
            // 
            // FormPopUp_ImageView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1018, 1000);
            this.ControlBox = false;
            this.Controls.Add(this.lbSelectArray2);
            this.Controls.Add(this.lbSelectArray1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPopUp_ImageView2";
            this.Text = "Viewer";
            this.Load += new System.EventHandler(this.FormPopUp_ImageView2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Master)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Result)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Cognex.VisionPro.Display.CogDisplay cogDisplay_Master;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay_Result;
        private System.Windows.Forms.Button btnClose;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Label lbSelectArray1;
        private System.Windows.Forms.Label lbSelectArray2;
    }
}
