namespace Inventory
{
    partial class EquipmentEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentEditForm));
            this.equipCategoryCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.equipTextbox = new System.Windows.Forms.TextBox();
            this.equipProductTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.equipCloseButton = new System.Windows.Forms.Button();
            this.EquipmentDataGrid2 = new System.Windows.Forms.DataGridView();
            this.equipmentMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainClose = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentDataGrid2)).BeginInit();
            this.equipmentMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // equipCategoryCombobox
            // 
            this.equipCategoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equipCategoryCombobox.FormattingEnabled = true;
            this.equipCategoryCombobox.Location = new System.Drawing.Point(11, 89);
            this.equipCategoryCombobox.Name = "equipCategoryCombobox";
            this.equipCategoryCombobox.Size = new System.Drawing.Size(176, 21);
            this.equipCategoryCombobox.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Category";
            // 
            // equipTextbox
            // 
            this.equipTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.equipTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.equipTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.equipTextbox.Location = new System.Drawing.Point(12, 172);
            this.equipTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.equipTextbox.Name = "equipTextbox";
            this.equipTextbox.Size = new System.Drawing.Size(176, 20);
            this.equipTextbox.TabIndex = 65;
            // 
            // equipProductTextbox
            // 
            this.equipProductTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.equipProductTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.equipProductTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.equipProductTextbox.Location = new System.Drawing.Point(12, 257);
            this.equipProductTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.equipProductTextbox.Name = "equipProductTextbox";
            this.equipProductTextbox.Size = new System.Drawing.Size(176, 20);
            this.equipProductTextbox.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Equipment";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Product Number";
            // 
            // equipCloseButton
            // 
            this.equipCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.equipCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.equipCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.equipCloseButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipCloseButton.ForeColor = System.Drawing.Color.White;
            this.equipCloseButton.Location = new System.Drawing.Point(106, 327);
            this.equipCloseButton.Name = "equipCloseButton";
            this.equipCloseButton.Size = new System.Drawing.Size(82, 34);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.EquipmentDataGrid2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EquipmentDataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EquipmentDataGrid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EquipmentDataGrid2.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.EquipmentDataGrid2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.EquipmentDataGrid2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EquipmentDataGrid2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.EquipmentDataGrid2.ColumnHeadersHeight = 30;
            this.EquipmentDataGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.EquipmentDataGrid2.ContextMenuStrip = this.equipmentMenuStrip;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EquipmentDataGrid2.DefaultCellStyle = dataGridViewCellStyle3;
            this.EquipmentDataGrid2.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EquipmentDataGrid2.Location = new System.Drawing.Point(205, 67);
            this.EquipmentDataGrid2.Margin = new System.Windows.Forms.Padding(2);
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
            this.EquipmentDataGrid2.Size = new System.Drawing.Size(389, 294);
            this.EquipmentDataGrid2.TabIndex = 72;
            this.EquipmentDataGrid2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EquipmentDataGrid2_CellMouseClick);
            this.EquipmentDataGrid2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EquipmentDataGrid2_CellMouseDoubleClick);
            this.EquipmentDataGrid2.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EquipmentDataGrid2_CellMouseDown);
            // 
            // equipmentMenuStrip
            // 
            this.equipmentMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.equipmentMenuStrip.Name = "equipmentMenuStrip";
            this.equipmentMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(42)))), ((int)(((byte)(84)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.mainClose);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(599, 55);
            this.panel2.TabIndex = 73;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // mainClose
            // 
            this.mainClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mainClose.AutoSize = true;
            this.mainClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.mainClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainClose.ForeColor = System.Drawing.Color.White;
            this.mainClose.Location = new System.Drawing.Point(564, 9);
            this.mainClose.Margin = new System.Windows.Forms.Padding(0);
            this.mainClose.Name = "mainClose";
            this.mainClose.Size = new System.Drawing.Size(26, 27);
            this.mainClose.TabIndex = 39;
            this.mainClose.Text = "X";
            this.mainClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mainClose.Click += new System.EventHandler(this.mainClose_Click_1);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(76, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(261, 30);
            this.label19.TabIndex = 0;
            this.label19.Text = "Inventory - Edit Equipment";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            this.label19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label19_MouseDown);
            this.label19.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label19_MouseMove);
            this.label19.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label19_MouseUp);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 34);
            this.button1.TabIndex = 74;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EquipmentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(599, 369);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.EquipmentDataGrid2);
            this.Controls.Add(this.equipCloseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.equipProductTextbox);
            this.Controls.Add(this.equipTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.equipCategoryCombobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(601, 371);
            this.MinimumSize = new System.Drawing.Size(601, 371);
            this.Name = "EquipmentEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EquipmentNewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentDataGrid2)).EndInit();
            this.equipmentMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button equipCloseButton;
        private System.Windows.Forms.DataGridView EquipmentDataGrid2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mainClose;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ContextMenuStrip equipmentMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}