using OpenCvSharp;
using System.Xml.Schema;

namespace FrameworkOnnxTest
{
    partial class IFOnnxRuntimeControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.TbPath = new Sunny.UI.UITextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnLoadPath = new Sunny.UI.UISymbolButton();
            this.DgvModel = new Sunny.UI.UIDataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnRemoveModel = new Sunny.UI.UISymbolButton();
            this.BtnAddModel = new Sunny.UI.UISymbolButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.TbNmsThreshold = new Sunny.UI.UITextBox();
            this.TbName = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CbDevice = new Sunny.UI.UIComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModel)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DgvModel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1069, 814);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.Controls.Add(this.uiLabel4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.TbPath, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1069, 40);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.uiLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.uiLabel4.ForeColor = System.Drawing.Color.White;
            this.uiLabel4.Location = new System.Drawing.Point(0, 0);
            this.uiLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 40);
            this.uiLabel4.TabIndex = 7;
            this.uiLabel4.Text = "Onnx Path";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbPath
            // 
            this.TbPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TbPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbPath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TbPath.Font = new System.Drawing.Font("Arial", 10F);
            this.TbPath.ForeColor = System.Drawing.Color.White;
            this.TbPath.Location = new System.Drawing.Point(100, 0);
            this.TbPath.Margin = new System.Windows.Forms.Padding(0);
            this.TbPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbPath.Name = "TbPath";
            this.TbPath.Padding = new System.Windows.Forms.Padding(5);
            this.TbPath.Radius = 0;
            this.TbPath.RectColor = System.Drawing.Color.DimGray;
            this.TbPath.ShowText = false;
            this.TbPath.Size = new System.Drawing.Size(919, 40);
            this.TbPath.TabIndex = 1;
            this.TbPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TbPath.Watermark = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.BtnLoadPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1019, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(50, 40);
            this.panel1.TabIndex = 2;
            // 
            // BtnLoadPath
            // 
            this.BtnLoadPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLoadPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoadPath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BtnLoadPath.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnLoadPath.Location = new System.Drawing.Point(0, 0);
            this.BtnLoadPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnLoadPath.Name = "BtnLoadPath";
            this.BtnLoadPath.Radius = 0;
            this.BtnLoadPath.RectColor = System.Drawing.Color.DimGray;
            this.BtnLoadPath.Size = new System.Drawing.Size(50, 40);
            this.BtnLoadPath.Symbol = 61564;
            this.BtnLoadPath.TabIndex = 0;
            this.BtnLoadPath.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnLoadPath.Click += new System.EventHandler(this.BtnLoadPath_Click);
            // 
            // DgvModel
            // 
            this.DgvModel.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            this.DgvModel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvModel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DgvModel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvModel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvModel.ColumnHeadersHeight = 40;
            this.DgvModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvModel.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvModel.EnableHeadersVisualStyles = false;
            this.DgvModel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DgvModel.GridColor = System.Drawing.Color.DimGray;
            this.DgvModel.Location = new System.Drawing.Point(0, 110);
            this.DgvModel.Margin = new System.Windows.Forms.Padding(0);
            this.DgvModel.MultiSelect = false;
            this.DgvModel.Name = "DgvModel";
            this.DgvModel.RectColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvModel.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvModel.RowHeadersVisible = false;
            this.DgvModel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            this.DgvModel.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.tableLayoutPanel1.SetRowSpan(this.DgvModel, 2);
            this.DgvModel.RowTemplate.Height = 50;
            this.DgvModel.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvModel.SelectedIndex = -1;
            this.DgvModel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvModel.Size = new System.Drawing.Size(1069, 704);
            this.DgvModel.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DgvModel.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DgvModel.TabIndex = 3;
            this.DgvModel.SelectIndexChange += new Sunny.UI.UIDataGridView.OnSelectIndexChange(this.DgvModel_SelectIndexChange);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 50;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Model Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BtnRemoveModel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnAddModel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1069, 30);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // BtnRemoveModel
            // 
            this.BtnRemoveModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRemoveModel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnRemoveModel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnRemoveModel.Location = new System.Drawing.Point(1022, 3);
            this.BtnRemoveModel.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnRemoveModel.Name = "BtnRemoveModel";
            this.BtnRemoveModel.RectColor = System.Drawing.Color.DimGray;
            this.BtnRemoveModel.Size = new System.Drawing.Size(44, 24);
            this.BtnRemoveModel.Symbol = 61544;
            this.BtnRemoveModel.SymbolSize = 20;
            this.BtnRemoveModel.TabIndex = 0;
            this.BtnRemoveModel.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnRemoveModel.Click += new System.EventHandler(this.BtnModelRemove_Click);
            // 
            // BtnAddModel
            // 
            this.BtnAddModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddModel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.BtnAddModel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnAddModel.Location = new System.Drawing.Point(972, 3);
            this.BtnAddModel.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnAddModel.Name = "BtnAddModel";
            this.BtnAddModel.RectColor = System.Drawing.Color.DimGray;
            this.BtnAddModel.Size = new System.Drawing.Size(44, 24);
            this.BtnAddModel.Symbol = 61543;
            this.BtnAddModel.SymbolSize = 20;
            this.BtnAddModel.TabIndex = 1;
            this.BtnAddModel.TipsFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnAddModel.Click += new System.EventHandler(this.BtnModelAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(963, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Model Info";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.Controls.Add(this.uiLabel3, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.TbNmsThreshold, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.TbName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1069, 40);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.uiLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.uiLabel3.ForeColor = System.Drawing.Color.White;
            this.uiLabel3.Location = new System.Drawing.Point(668, 0);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(120, 40);
            this.uiLabel3.TabIndex = 8;
            this.uiLabel3.Text = "Nms Threshold";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.uiLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.uiLabel2.ForeColor = System.Drawing.Color.White;
            this.uiLabel2.Location = new System.Drawing.Point(329, 0);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(60, 40);
            this.uiLabel2.TabIndex = 7;
            this.uiLabel2.Text = "Device";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbNmsThreshold
            // 
            this.TbNmsThreshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TbNmsThreshold.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbNmsThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbNmsThreshold.DoubleValue = 0.5D;
            this.TbNmsThreshold.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TbNmsThreshold.Font = new System.Drawing.Font("Arial", 10F);
            this.TbNmsThreshold.ForeColor = System.Drawing.Color.White;
            this.TbNmsThreshold.Location = new System.Drawing.Point(788, 0);
            this.TbNmsThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.TbNmsThreshold.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbNmsThreshold.Name = "TbNmsThreshold";
            this.TbNmsThreshold.Padding = new System.Windows.Forms.Padding(5);
            this.TbNmsThreshold.Radius = 0;
            this.TbNmsThreshold.RectColor = System.Drawing.Color.DimGray;
            this.TbNmsThreshold.ShowText = false;
            this.TbNmsThreshold.Size = new System.Drawing.Size(281, 40);
            this.TbNmsThreshold.TabIndex = 5;
            this.TbNmsThreshold.Text = "0.5";
            this.TbNmsThreshold.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TbNmsThreshold.Watermark = "";
            // 
            // TbName
            // 
            this.TbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TbName.Font = new System.Drawing.Font("Arial", 10F);
            this.TbName.ForeColor = System.Drawing.Color.White;
            this.TbName.Location = new System.Drawing.Point(50, 0);
            this.TbName.Margin = new System.Windows.Forms.Padding(0);
            this.TbName.MinimumSize = new System.Drawing.Size(1, 16);
            this.TbName.Name = "TbName";
            this.TbName.Padding = new System.Windows.Forms.Padding(5);
            this.TbName.Radius = 0;
            this.TbName.RectColor = System.Drawing.Color.DimGray;
            this.TbName.ShowText = false;
            this.TbName.Size = new System.Drawing.Size(279, 40);
            this.TbName.TabIndex = 1;
            this.TbName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TbName.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.uiLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(50, 40);
            this.uiLabel1.TabIndex = 6;
            this.uiLabel1.Text = "Name";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel2.Controls.Add(this.CbDevice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(389, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 40);
            this.panel2.TabIndex = 9;
            // 
            // CbDevice
            // 
            this.CbDevice.DataSource = null;
            this.CbDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CbDevice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CbDevice.Font = new System.Drawing.Font("Arial", 10F);
            this.CbDevice.ForeColor = System.Drawing.Color.White;
            this.CbDevice.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CbDevice.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CbDevice.Location = new System.Drawing.Point(0, 0);
            this.CbDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbDevice.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbDevice.Name = "CbDevice";
            this.CbDevice.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbDevice.Radius = 0;
            this.CbDevice.RectColor = System.Drawing.Color.DimGray;
            this.CbDevice.Size = new System.Drawing.Size(279, 40);
            this.CbDevice.SymbolSize = 24;
            this.CbDevice.TabIndex = 3;
            this.CbDevice.Text = "CPU";
            this.CbDevice.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbDevice.Watermark = "";
            // 
            // IFOnnxRuntimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "IFOnnxRuntimeControl";
            this.Size = new System.Drawing.Size(1069, 814);
            this.Load += new System.EventHandler(this.IFOnnxRuntimeControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvModel)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public Sunny.UI.UIDataGridView DgvModel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Sunny.UI.UITextBox TbName;
        private Sunny.UI.UIComboBox CbDevice;
        private Sunny.UI.UITextBox TbNmsThreshold;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Sunny.UI.UITextBox TbPath;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UISymbolButton BtnLoadPath;
        private Sunny.UI.UILabel uiLabel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private Sunny.UI.UISymbolButton BtnRemoveModel;
        private Sunny.UI.UISymbolButton BtnAddModel;
    }
}
