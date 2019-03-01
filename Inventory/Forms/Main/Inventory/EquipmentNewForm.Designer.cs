namespace Inventory
{
    partial class EquipmentNewForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.equipCategoryCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.equipTextbox = new System.Windows.Forms.TextBox();
            this.equipProductTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.equipCreateButton = new System.Windows.Forms.Button();
            this.equipCloseButton = new System.Windows.Forms.Button();
            this.EquipmentDataGrid2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainClose = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentDataGrid2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // equipCategoryCombobox
            // 
            this.equipCategoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equipCategoryCombobox.FormattingEnabled = true;
            this.equipCategoryCombobox.Location = new System.Drawing.Point(18, 112);
            this.equipCategoryCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.equipCategoryCombobox.Name = "equipCategoryCombobox";
            this.equipCategoryCombobox.Size = new System.Drawing.Size(262, 28);
            this.equipCategoryCombobox.TabIndex = 63;
            this.equipCategoryCombobox.SelectedIndexChanged += new System.EventHandler(this.equipCategoryCombobox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 64;
            this.label5.Text = "Category";
            // 
            // equipTextbox
            // 
            this.equipTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.equipTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.equipTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.equipTextbox.Location = new System.Drawing.Point(18, 253);
            this.equipTextbox.Name = "equipTextbox";
            this.equipTextbox.Size = new System.Drawing.Size(262, 26);
            this.equipTextbox.TabIndex = 65;
            // 
            // equipProductTextbox
            // 
            this.equipProductTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.equipProductTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.equipProductTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.equipProductTextbox.Location = new System.Drawing.Point(18, 396);
            this.equipProductTextbox.Name = "equipProductTextbox";
            this.equipProductTextbox.Size = new System.Drawing.Size(262, 26);
            this.equipProductTextbox.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 67;
            this.label1.Text = "Equipment";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 68;
            this.label2.Text = "Product Number";
            // 
            // equipCreateButton
            // 
            this.equipCreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.equipCreateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.equipCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.equipCreateButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipCreateButton.ForeColor = System.Drawing.Color.White;
            this.equipCreateButton.Location = new System.Drawing.Point(13, 503);
            this.equipCreateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.equipCreateButton.Name = "equipCreateButton";
            this.equipCreateButton.Size = new System.Drawing.Size(112, 53);
            this.equipCreateButton.TabIndex = 69;
            this.equipCreateButton.Text = "Create";
            this.equipCreateButton.UseVisualStyleBackColor = false;
            this.equipCreateButton.Click += new System.EventHandler(this.equipCreateButton_Click);
            // 
            // equipCloseButton
            // 
            this.equipCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.equipCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.equipCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.equipCloseButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipCloseButton.ForeColor = System.Drawing.Color.White;
            this.equipCloseButton.Location = new System.Drawing.Point(168, 503);
            this.equipCloseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.equipCloseButton.Name = "equipCloseButton";
            this.equipCloseButton.Size = new System.Drawing.Size(112, 53);
            this.equipCloseButton.TabIndex = 70;
            this.equipCloseButton.Text = "Close";
            this.equipCloseButton.UseVisualStyleBackColor = false;
            this.equipCloseButton.Click += new System.EventHandler(this.equipCloseButton_Click);
            // 
            // EquipmentDataGrid2
            // 
            this.EquipmentDataGrid2.AllowUserToAddRows = false;
            this.EquipmentDataGrid2.AllowUserToDeleteRows = false;
            this.EquipmentDataGrid2.AllowUserToResizeColumns = false;
            this.EquipmentDataGrid2.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            this.EquipmentDataGrid2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.EquipmentDataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EquipmentDataGrid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EquipmentDataGrid2.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.EquipmentDataGrid2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.EquipmentDataGrid2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EquipmentDataGrid2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.EquipmentDataGrid2.ColumnHeadersHeight = 30;
            this.EquipmentDataGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EquipmentDataGrid2.DefaultCellStyle = dataGridViewCellStyle12;
            this.EquipmentDataGrid2.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EquipmentDataGrid2.Location = new System.Drawing.Point(287, 103);
            this.EquipmentDataGrid2.MultiSelect = false;
            this.EquipmentDataGrid2.Name = "EquipmentDataGrid2";
            this.EquipmentDataGrid2.ReadOnly = true;
            this.EquipmentDataGrid2.RowHeadersVisible = false;
            this.EquipmentDataGrid2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.EquipmentDataGrid2.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.EquipmentDataGrid2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentDataGrid2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.EquipmentDataGrid2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(56)))));
            this.EquipmentDataGrid2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.EquipmentDataGrid2.RowTemplate.Height = 30;
            this.EquipmentDataGrid2.RowTemplate.ReadOnly = true;
            this.EquipmentDataGrid2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EquipmentDataGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EquipmentDataGrid2.Size = new System.Drawing.Size(604, 453);
            this.EquipmentDataGrid2.TabIndex = 72;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel2.Controls.Add(this.mainClose);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 66);
            this.panel2.TabIndex = 73;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // mainClose
            // 
            this.mainClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mainClose.AutoSize = true;
            this.mainClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.mainClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainClose.ForeColor = System.Drawing.Color.White;
            this.mainClose.Location = new System.Drawing.Point(847, 12);
            this.mainClose.Margin = new System.Windows.Forms.Padding(0);
            this.mainClose.Name = "mainClose";
            this.mainClose.Size = new System.Drawing.Size(38, 42);
            this.mainClose.TabIndex = 39;
            this.mainClose.Text = "X";
            this.mainClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mainClose.Click += new System.EventHandler(this.mainClose_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(18, 12);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(689, 45);
            this.label19.TabIndex = 0;
            this.label19.Text = "Pathology Informatics - Create New Equipment";
            this.label19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label19_MouseDown);
            this.label19.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label19_MouseMove);
            this.label19.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label19_MouseUp);
            // 
            // EquipmentNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 568);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.EquipmentDataGrid2);
            this.Controls.Add(this.equipCloseButton);
            this.Controls.Add(this.equipCreateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.equipProductTextbox);
            this.Controls.Add(this.equipTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.equipCategoryCombobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(900, 570);
            this.MinimumSize = new System.Drawing.Size(900, 570);
            this.Name = "EquipmentNewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EquipmentNewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentDataGrid2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox equipCategoryCombobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox equipTextbox;
        private System.Windows.Forms.TextBox equipProductTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button equipCreateButton;
        private System.Windows.Forms.Button equipCloseButton;
        private System.Windows.Forms.DataGridView EquipmentDataGrid2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label mainClose;
        private System.Windows.Forms.Label label19;
    }
}