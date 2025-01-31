namespace IntelligentFactory
{
    partial class FormPopUp_Settings_DefaultParameter
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
            this.gridPart = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbPartName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.propertyGrid_Jobs = new System.Windows.Forms.PropertyGrid();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridPart)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPart
            // 
            this.gridPart.AllowUserToAddRows = false;
            this.gridPart.AllowUserToDeleteRows = false;
            this.gridPart.AllowUserToResizeColumns = false;
            this.gridPart.AllowUserToResizeRows = false;
            this.gridPart.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            this.gridPart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 14F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPart.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridPart.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridPart.EnableHeadersVisualStyles = false;
            this.gridPart.GridColor = System.Drawing.Color.White;
            this.gridPart.Location = new System.Drawing.Point(1, 31);
            this.gridPart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridPart.MultiSelect = false;
            this.gridPart.Name = "gridPart";
            this.gridPart.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPart.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridPart.RowHeadersVisible = false;
            this.gridPart.RowHeadersWidth = 62;
            this.gridPart.RowTemplate.Height = 50;
            this.gridPart.RowTemplate.ReadOnly = true;
            this.gridPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPart.Size = new System.Drawing.Size(328, 220);
            this.gridPart.TabIndex = 2449;
            this.gridPart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRecipe_CellClick);
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
            this.btnClose.Location = new System.Drawing.Point(179, 255);
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
            this.btnSelect.Location = new System.Drawing.Point(27, 255);
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
            // tbPartName
            // 
            this.tbPartName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.tbPartName.Font = new System.Drawing.Font("Arial", 14F);
            this.tbPartName.ForeColor = System.Drawing.Color.White;
            this.tbPartName.Location = new System.Drawing.Point(77, 2);
            this.tbPartName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPartName.Name = "tbPartName";
            this.tbPartName.Size = new System.Drawing.Size(252, 29);
            this.tbPartName.TabIndex = 2532;
            this.tbPartName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPartName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRecipe_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 30);
            this.label3.TabIndex = 2533;
            this.label3.Text = "NAME";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(330, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(403, 22);
            this.label16.TabIndex = 2721;
            this.label16.Text = "Property";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // propertyGrid_Jobs
            // 
            this.propertyGrid_Jobs.BackColor = System.Drawing.Color.Black;
            this.propertyGrid_Jobs.CategoryForeColor = System.Drawing.Color.White;
            this.propertyGrid_Jobs.CategorySplitterColor = System.Drawing.Color.Black;
            this.propertyGrid_Jobs.CommandsBorderColor = System.Drawing.Color.Black;
            this.propertyGrid_Jobs.CommandsDisabledLinkColor = System.Drawing.Color.White;
            this.propertyGrid_Jobs.CommandsForeColor = System.Drawing.Color.White;
            this.propertyGrid_Jobs.DisabledItemForeColor = System.Drawing.Color.White;
            this.propertyGrid_Jobs.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyGrid_Jobs.HelpBackColor = System.Drawing.Color.Black;
            this.propertyGrid_Jobs.HelpBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.propertyGrid_Jobs.HelpForeColor = System.Drawing.Color.White;
            this.propertyGrid_Jobs.HelpVisible = false;
            this.propertyGrid_Jobs.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.propertyGrid_Jobs.Location = new System.Drawing.Point(330, 57);
            this.propertyGrid_Jobs.Name = "propertyGrid_Jobs";
            this.propertyGrid_Jobs.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid_Jobs.SelectedItemWithFocusBackColor = System.Drawing.Color.Black;
            this.propertyGrid_Jobs.SelectedItemWithFocusForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.propertyGrid_Jobs.Size = new System.Drawing.Size(403, 273);
            this.propertyGrid_Jobs.TabIndex = 2720;
            this.propertyGrid_Jobs.ToolbarVisible = false;
            this.propertyGrid_Jobs.ViewBackColor = System.Drawing.Color.Black;
            this.propertyGrid_Jobs.ViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
            this.propertyGrid_Jobs.ViewForeColor = System.Drawing.Color.White;
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
            this.dataGridViewTextBoxColumn2.Width = 325;
            // 
            // FormPopUp_Settings_DefaultParameter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(736, 337);
            this.ControlBox = false;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.propertyGrid_Jobs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPartName);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridPart);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPopUp_Settings_DefaultParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Default Parameter";
            this.Load += new System.EventHandler(this.FormMenuRecipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gridPart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox tbPartName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PropertyGrid propertyGrid_Jobs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}