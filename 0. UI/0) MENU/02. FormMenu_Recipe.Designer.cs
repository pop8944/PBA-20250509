namespace IntelligentFactory
{
    partial class FormMenuRecipe
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
            this.gridRecipe = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbRecipe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbRecipeName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnRecipeAdd = new System.Windows.Forms.Panel();
            this.btnRecipeAdd_OK = new System.Windows.Forms.Button();
            this.btnRecipeAdd_Cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRecipe_Add_Name = new System.Windows.Forms.TextBox();
            this.cbRecipe_Add_Reference = new System.Windows.Forms.ComboBox();
            this.lbRecipeCurr = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecipe)).BeginInit();
            this.pnRecipeAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridRecipe
            // 
            this.gridRecipe.AllowUserToAddRows = false;
            this.gridRecipe.AllowUserToDeleteRows = false;
            this.gridRecipe.AllowUserToResizeColumns = false;
            this.gridRecipe.AllowUserToResizeRows = false;
            this.gridRecipe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gridRecipe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRecipe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRecipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRecipe.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridRecipe.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRecipe.EnableHeadersVisualStyles = false;
            this.gridRecipe.GridColor = System.Drawing.Color.White;
            this.gridRecipe.Location = new System.Drawing.Point(1, 86);
            this.gridRecipe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridRecipe.MultiSelect = false;
            this.gridRecipe.Name = "gridRecipe";
            this.gridRecipe.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRecipe.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridRecipe.RowHeadersVisible = false;
            this.gridRecipe.RowHeadersWidth = 62;
            this.gridRecipe.RowTemplate.Height = 50;
            this.gridRecipe.RowTemplate.ReadOnly = true;
            this.gridRecipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRecipe.Size = new System.Drawing.Size(806, 476);
            this.gridRecipe.TabIndex = 2449;
            this.gridRecipe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRecipe_CellClick);
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
            this.btnClose.Location = new System.Drawing.Point(648, 596);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnClose.Size = new System.Drawing.Size(160, 75);
            this.btnClose.TabIndex = 2518;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
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
            this.btnSelect.Location = new System.Drawing.Point(1, 596);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnSelect.Size = new System.Drawing.Size(160, 75);
            this.btnSelect.TabIndex = 2519;
            this.btnSelect.Text = "SELECT";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            this.btnSelect.MouseLeave += new System.EventHandler(this.btnSelect_MouseLeave);
            this.btnSelect.MouseHover += new System.EventHandler(this.btnSelect_MouseHover);
            // 
            // tbRecipe
            // 
            this.tbRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbRecipe.Font = new System.Drawing.Font("Arial", 14F);
            this.tbRecipe.ForeColor = System.Drawing.Color.White;
            this.tbRecipe.Location = new System.Drawing.Point(153, 54);
            this.tbRecipe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRecipe.Name = "tbRecipe";
            this.tbRecipe.Size = new System.Drawing.Size(654, 29);
            this.tbRecipe.TabIndex = 2532;
            this.tbRecipe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbRecipe.TextChanged += new System.EventHandler(this.tbRecipe_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 30);
            this.label3.TabIndex = 2533;
            this.label3.Text = "NAME";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1, 565);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 29);
            this.label7.TabIndex = 2196;
            this.label7.Text = "NAME";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRecipeName
            // 
            this.lbRecipeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbRecipeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRecipeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbRecipeName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecipeName.ForeColor = System.Drawing.Color.White;
            this.lbRecipeName.Location = new System.Drawing.Point(102, 565);
            this.lbRecipeName.Name = "lbRecipeName";
            this.lbRecipeName.Size = new System.Drawing.Size(328, 29);
            this.lbRecipeName.TabIndex = 2523;
            this.lbRecipeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(430, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 2198;
            this.label1.Text = "UPDATED";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(531, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 29);
            this.label2.TabIndex = 2199;
            this.label2.Text = "0000/00/00 00:00:000";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSave
            // 
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSave.FlatAppearance.BorderSize = 2;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Image = global::IntelligentFactory.Properties.Resources.Save50_Normal;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(486, 596);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.buttonSave.Size = new System.Drawing.Size(160, 75);
            this.buttonSave.TabIndex = 2517;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.MouseLeave += new System.EventHandler(this.buttonSave_MouseLeave);
            this.buttonSave.MouseHover += new System.EventHandler(this.buttonSave_MouseHover);
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
            this.btnDelete.Location = new System.Drawing.Point(324, 596);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnDelete.Size = new System.Drawing.Size(160, 75);
            this.btnDelete.TabIndex = 2520;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            this.btnDelete.MouseHover += new System.EventHandler(this.btnDelete_MouseHover);
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
            this.btnAdd.Location = new System.Drawing.Point(163, 596);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnAdd.Size = new System.Drawing.Size(160, 75);
            this.btnAdd.TabIndex = 2521;
            this.btnAdd.Text = "ADD";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnAdd_MouseLeave);
            this.btnAdd.MouseHover += new System.EventHandler(this.btnAdd_MouseHover);
            // 
            // pnRecipeAdd
            // 
            this.pnRecipeAdd.Controls.Add(this.btnRecipeAdd_OK);
            this.pnRecipeAdd.Controls.Add(this.btnRecipeAdd_Cancel);
            this.pnRecipeAdd.Controls.Add(this.label6);
            this.pnRecipeAdd.Controls.Add(this.label10);
            this.pnRecipeAdd.Controls.Add(this.label9);
            this.pnRecipeAdd.Controls.Add(this.tbRecipe_Add_Name);
            this.pnRecipeAdd.Controls.Add(this.cbRecipe_Add_Reference);
            this.pnRecipeAdd.Location = new System.Drawing.Point(228, 232);
            this.pnRecipeAdd.Name = "pnRecipeAdd";
            this.pnRecipeAdd.Size = new System.Drawing.Size(302, 160);
            this.pnRecipeAdd.TabIndex = 2534;
            this.pnRecipeAdd.Visible = false;
            // 
            // btnRecipeAdd_OK
            // 
            this.btnRecipeAdd_OK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRecipeAdd_OK.FlatAppearance.BorderSize = 2;
            this.btnRecipeAdd_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipeAdd_OK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnRecipeAdd_OK.ForeColor = System.Drawing.Color.White;
            this.btnRecipeAdd_OK.Image = global::IntelligentFactory.Properties.Resources.Check50_Normal;
            this.btnRecipeAdd_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeAdd_OK.Location = new System.Drawing.Point(1, 86);
            this.btnRecipeAdd_OK.Name = "btnRecipeAdd_OK";
            this.btnRecipeAdd_OK.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnRecipeAdd_OK.Size = new System.Drawing.Size(150, 70);
            this.btnRecipeAdd_OK.TabIndex = 2531;
            this.btnRecipeAdd_OK.Text = "OK";
            this.btnRecipeAdd_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecipeAdd_OK.UseVisualStyleBackColor = true;
            this.btnRecipeAdd_OK.Click += new System.EventHandler(this.btnRecipeAdd_OK_Click);
            this.btnRecipeAdd_OK.MouseLeave += new System.EventHandler(this.btnRecipeAdd_OK_MouseLeave);
            this.btnRecipeAdd_OK.MouseHover += new System.EventHandler(this.btnRecipeAdd_OK_MouseHover);
            // 
            // btnRecipeAdd_Cancel
            // 
            this.btnRecipeAdd_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRecipeAdd_Cancel.FlatAppearance.BorderSize = 2;
            this.btnRecipeAdd_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipeAdd_Cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecipeAdd_Cancel.ForeColor = System.Drawing.Color.White;
            this.btnRecipeAdd_Cancel.Image = global::IntelligentFactory.Properties.Resources.Cancel50_Normal;
            this.btnRecipeAdd_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipeAdd_Cancel.Location = new System.Drawing.Point(152, 86);
            this.btnRecipeAdd_Cancel.Name = "btnRecipeAdd_Cancel";
            this.btnRecipeAdd_Cancel.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.btnRecipeAdd_Cancel.Size = new System.Drawing.Size(150, 70);
            this.btnRecipeAdd_Cancel.TabIndex = 2530;
            this.btnRecipeAdd_Cancel.Text = "CANCEL";
            this.btnRecipeAdd_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecipeAdd_Cancel.UseVisualStyleBackColor = true;
            this.btnRecipeAdd_Cancel.Click += new System.EventHandler(this.btnRecipeAdd_Cancel_Click);
            this.btnRecipeAdd_Cancel.MouseLeave += new System.EventHandler(this.btnRecipeAdd_Cancel_MouseLeave);
            this.btnRecipeAdd_Cancel.MouseHover += new System.EventHandler(this.btnRecipeAdd_Cancel_MouseHover);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial", 8.75F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 28);
            this.label6.TabIndex = 2529;
            this.label6.Text = "REFERENCE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 28);
            this.label10.TabIndex = 2528;
            this.label10.Text = "Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(302, 28);
            this.label9.TabIndex = 2527;
            this.label9.Text = "Recipe Manager";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbRecipe_Add_Name
            // 
            this.tbRecipe_Add_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbRecipe_Add_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRecipe_Add_Name.Font = new System.Drawing.Font("Arial", 13F);
            this.tbRecipe_Add_Name.ForeColor = System.Drawing.Color.Yellow;
            this.tbRecipe_Add_Name.Location = new System.Drawing.Point(88, 30);
            this.tbRecipe_Add_Name.Name = "tbRecipe_Add_Name";
            this.tbRecipe_Add_Name.Size = new System.Drawing.Size(214, 27);
            this.tbRecipe_Add_Name.TabIndex = 2524;
            this.tbRecipe_Add_Name.Text = "-";
            this.tbRecipe_Add_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbRecipe_Add_Reference
            // 
            this.cbRecipe_Add_Reference.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbRecipe_Add_Reference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRecipe_Add_Reference.Font = new System.Drawing.Font("Arial", 11F);
            this.cbRecipe_Add_Reference.ForeColor = System.Drawing.Color.White;
            this.cbRecipe_Add_Reference.FormattingEnabled = true;
            this.cbRecipe_Add_Reference.Location = new System.Drawing.Point(88, 59);
            this.cbRecipe_Add_Reference.Name = "cbRecipe_Add_Reference";
            this.cbRecipe_Add_Reference.Size = new System.Drawing.Size(214, 25);
            this.cbRecipe_Add_Reference.TabIndex = 2523;
            // 
            // lbRecipeCurr
            // 
            this.lbRecipeCurr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lbRecipeCurr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRecipeCurr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbRecipeCurr.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecipeCurr.ForeColor = System.Drawing.Color.White;
            this.lbRecipeCurr.Location = new System.Drawing.Point(1, 2);
            this.lbRecipeCurr.Name = "lbRecipeCurr";
            this.lbRecipeCurr.Size = new System.Drawing.Size(806, 51);
            this.lbRecipeCurr.TabIndex = 2535;
            this.lbRecipeCurr.Text = "Model : -";
            this.lbRecipeCurr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 150F;
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.dataGridViewTextBoxColumn2.Width = 353;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Code";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 350;
            // 
            // FormMenuRecipe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(811, 673);
            this.ControlBox = false;
            this.Controls.Add(this.lbRecipeCurr);
            this.Controls.Add(this.pnRecipeAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbRecipe);
            this.Controls.Add(this.lbRecipeName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gridRecipe);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMenuRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECIPE";
            this.Load += new System.EventHandler(this.FormMenuRecipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecipe)).EndInit();
            this.pnRecipeAdd.ResumeLayout(false);
            this.pnRecipeAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gridRecipe;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox tbRecipe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbRecipeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnRecipeAdd;
        private System.Windows.Forms.Button btnRecipeAdd_OK;
        private System.Windows.Forms.Button btnRecipeAdd_Cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRecipe_Add_Name;
        private System.Windows.Forms.ComboBox cbRecipe_Add_Reference;
        private System.Windows.Forms.Label lbRecipeCurr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}