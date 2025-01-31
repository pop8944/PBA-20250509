namespace IntelligentFactory
{
    partial class FormMenu_PbaLibrary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbRecipe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnRecipeAdd = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbLibrary_Add_Reference = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbRecipe_Add_Name = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_SelectModelLibrary = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRecipeAdd_Cancel = new System.Windows.Forms.Button();
            this.btnRecipeAdd_OK = new System.Windows.Forms.Button();
            this.lbCurr = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnRecipeAdd.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = System.Drawing.Color.White;
            this.grid.Location = new System.Drawing.Point(3, 86);
            this.grid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 62;
            this.grid.RowTemplate.Height = 50;
            this.grid.RowTemplate.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(423, 476);
            this.grid.TabIndex = 2449;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRecipe_CellClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.FillWeight = 300F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 400;
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
            this.btnClose.Location = new System.Drawing.Point(425, 517);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnClose.Size = new System.Drawing.Size(150, 75);
            this.btnClose.TabIndex = 2518;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelect.FlatAppearance.BorderSize = 2;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Image = global::IntelligentFactory.Properties.Resources.Check50_Normal;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(425, 289);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnSelect.Size = new System.Drawing.Size(150, 75);
            this.btnSelect.TabIndex = 2519;
            this.btnSelect.Text = "SELECT";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // tbRecipe
            // 
            this.tbRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbRecipe.Font = new System.Drawing.Font("Arial", 14F);
            this.tbRecipe.ForeColor = System.Drawing.Color.White;
            this.tbRecipe.Location = new System.Drawing.Point(102, 54);
            this.tbRecipe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRecipe.Name = "tbRecipe";
            this.tbRecipe.Size = new System.Drawing.Size(475, 29);
            this.tbRecipe.TabIndex = 2532;
            this.tbRecipe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbRecipe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRecipe_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 30);
            this.label3.TabIndex = 2533;
            this.label3.Text = "NAME";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(102, 564);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(322, 29);
            this.lbName.TabIndex = 2523;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::IntelligentFactory.Properties.Resources.DeleteTrash50_Normal;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(425, 441);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnDelete.Size = new System.Drawing.Size(150, 75);
            this.btnDelete.TabIndex = 2520;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::IntelligentFactory.Properties.Resources.AddNew50_Normal;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(425, 365);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnAdd.Size = new System.Drawing.Size(150, 75);
            this.btnAdd.TabIndex = 2521;
            this.btnAdd.Text = "ADD";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnRecipeAdd
            // 
            this.pnRecipeAdd.Controls.Add(this.panel3);
            this.pnRecipeAdd.Controls.Add(this.panel2);
            this.pnRecipeAdd.Controls.Add(this.btn_SelectModelLibrary);
            this.pnRecipeAdd.Controls.Add(this.label9);
            this.pnRecipeAdd.Controls.Add(this.panel1);
            this.pnRecipeAdd.Location = new System.Drawing.Point(63, 289);
            this.pnRecipeAdd.Name = "pnRecipeAdd";
            this.pnRecipeAdd.Size = new System.Drawing.Size(302, 151);
            this.pnRecipeAdd.TabIndex = 2534;
            this.pnRecipeAdd.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbLibrary_Add_Reference);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 27);
            this.panel3.TabIndex = 2536;
            // 
            // cbLibrary_Add_Reference
            // 
            this.cbLibrary_Add_Reference.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbLibrary_Add_Reference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLibrary_Add_Reference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLibrary_Add_Reference.Font = new System.Drawing.Font("Arial", 11F);
            this.cbLibrary_Add_Reference.ForeColor = System.Drawing.Color.White;
            this.cbLibrary_Add_Reference.FormattingEnabled = true;
            this.cbLibrary_Add_Reference.Location = new System.Drawing.Point(87, 0);
            this.cbLibrary_Add_Reference.Name = "cbLibrary_Add_Reference";
            this.cbLibrary_Add_Reference.Size = new System.Drawing.Size(215, 25);
            this.cbLibrary_Add_Reference.TabIndex = 2534;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial", 8.75F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 27);
            this.label6.TabIndex = 2535;
            this.label6.Text = "REFERENCE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbRecipe_Add_Name);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 27);
            this.panel2.TabIndex = 2533;
            // 
            // tbRecipe_Add_Name
            // 
            this.tbRecipe_Add_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbRecipe_Add_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRecipe_Add_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRecipe_Add_Name.Font = new System.Drawing.Font("Arial", 13F);
            this.tbRecipe_Add_Name.ForeColor = System.Drawing.Color.Yellow;
            this.tbRecipe_Add_Name.Location = new System.Drawing.Point(87, 0);
            this.tbRecipe_Add_Name.Name = "tbRecipe_Add_Name";
            this.tbRecipe_Add_Name.Size = new System.Drawing.Size(215, 27);
            this.tbRecipe_Add_Name.TabIndex = 2524;
            this.tbRecipe_Add_Name.Text = "-";
            this.tbRecipe_Add_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 27);
            this.label10.TabIndex = 2528;
            this.label10.Text = "Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SelectModelLibrary
            // 
            this.btn_SelectModelLibrary.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_SelectModelLibrary.FlatAppearance.BorderSize = 2;
            this.btn_SelectModelLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectModelLibrary.Font = new System.Drawing.Font("Arial", 12F);
            this.btn_SelectModelLibrary.ForeColor = System.Drawing.Color.White;
            this.btn_SelectModelLibrary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectModelLibrary.Location = new System.Drawing.Point(219, 0);
            this.btn_SelectModelLibrary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SelectModelLibrary.Name = "btn_SelectModelLibrary";
            this.btn_SelectModelLibrary.Size = new System.Drawing.Size(83, 28);
            this.btn_SelectModelLibrary.TabIndex = 2520;
            this.btn_SelectModelLibrary.Text = "SELECT";
            this.btn_SelectModelLibrary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SelectModelLibrary.UseVisualStyleBackColor = true;
            this.btn_SelectModelLibrary.Visible = false;
            this.btn_SelectModelLibrary.Click += new System.EventHandler(this.btn_SelectModelLibrary_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(302, 28);
            this.label9.TabIndex = 2527;
            this.label9.Text = "PBA Library";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRecipeAdd_Cancel);
            this.panel1.Controls.Add(this.btnRecipeAdd_OK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 70);
            this.panel1.TabIndex = 2532;
            // 
            // btnRecipeAdd_Cancel
            // 
            this.btnRecipeAdd_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRecipeAdd_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRecipeAdd_Cancel.FlatAppearance.BorderSize = 2;
            this.btnRecipeAdd_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipeAdd_Cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecipeAdd_Cancel.ForeColor = System.Drawing.Color.White;
            this.btnRecipeAdd_Cancel.Image = global::IntelligentFactory.Properties.Resources.Cancel50_Normal;
            this.btnRecipeAdd_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeAdd_Cancel.Location = new System.Drawing.Point(152, 0);
            this.btnRecipeAdd_Cancel.Name = "btnRecipeAdd_Cancel";
            this.btnRecipeAdd_Cancel.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnRecipeAdd_Cancel.Size = new System.Drawing.Size(150, 70);
            this.btnRecipeAdd_Cancel.TabIndex = 2530;
            this.btnRecipeAdd_Cancel.Text = "CANCEL";
            this.btnRecipeAdd_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecipeAdd_Cancel.UseVisualStyleBackColor = true;
            this.btnRecipeAdd_Cancel.Click += new System.EventHandler(this.btnRecipeAdd_Cancel_Click);
            // 
            // btnRecipeAdd_OK
            // 
            this.btnRecipeAdd_OK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRecipeAdd_OK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRecipeAdd_OK.FlatAppearance.BorderSize = 2;
            this.btnRecipeAdd_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipeAdd_OK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnRecipeAdd_OK.ForeColor = System.Drawing.Color.White;
            this.btnRecipeAdd_OK.Image = global::IntelligentFactory.Properties.Resources.Check50_Normal;
            this.btnRecipeAdd_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeAdd_OK.Location = new System.Drawing.Point(0, 0);
            this.btnRecipeAdd_OK.Name = "btnRecipeAdd_OK";
            this.btnRecipeAdd_OK.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnRecipeAdd_OK.Size = new System.Drawing.Size(150, 70);
            this.btnRecipeAdd_OK.TabIndex = 2531;
            this.btnRecipeAdd_OK.Text = "OK";
            this.btnRecipeAdd_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecipeAdd_OK.UseVisualStyleBackColor = true;
            this.btnRecipeAdd_OK.Click += new System.EventHandler(this.btnRecipeAdd_OK_Click);
            // 
            // lbCurr
            // 
            this.lbCurr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lbCurr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCurr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCurr.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurr.ForeColor = System.Drawing.Color.White;
            this.lbCurr.Location = new System.Drawing.Point(1, 2);
            this.lbCurr.Name = "lbCurr";
            this.lbCurr.Size = new System.Drawing.Size(575, 51);
            this.lbCurr.TabIndex = 2535;
            this.lbCurr.Text = "Model : -";
            this.lbCurr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1, 564);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 29);
            this.label7.TabIndex = 2196;
            this.label7.Text = "NAME";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMenu_PbaLibrary
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(577, 594);
            this.ControlBox = false;
            this.Controls.Add(this.lbCurr);
            this.Controls.Add(this.pnRecipeAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbRecipe);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMenu_PbaLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PBA LIBRARY";
            this.Load += new System.EventHandler(this.FormMenu_PbaLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnRecipeAdd.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox tbRecipe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnRecipeAdd;
        private System.Windows.Forms.Button btnRecipeAdd_OK;
        private System.Windows.Forms.Button btnRecipeAdd_Cancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRecipe_Add_Name;
        private System.Windows.Forms.Label lbCurr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_SelectModelLibrary;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbLibrary_Add_Reference;
        private System.Windows.Forms.Label label6;
    }
}