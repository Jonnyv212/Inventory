namespace Inventory
{
    partial class Barcode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.barcodeTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.quantityTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.insertButton = new System.Windows.Forms.Button();
            this.bInvenBuildingCombobox = new System.Windows.Forms.ComboBox();
            this.bInvenRoomCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.barcodeDescriptionCheckbox = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(2, 18);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1756, 683);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Equipment";
            this.Column1.MinimumWidth = 30;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Category";
            this.Column2.MinimumWidth = 30;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Product Number";
            this.Column3.MinimumWidth = 30;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Building";
            this.Column4.MinimumWidth = 30;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Room";
            this.Column5.MinimumWidth = 30;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(1591, 822);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(152, 62);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(1431, 822);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(152, 62);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // barcodeTextbox
            // 
            this.barcodeTextbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.barcodeTextbox.Enabled = false;
            this.barcodeTextbox.Location = new System.Drawing.Point(983, 827);
            this.barcodeTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barcodeTextbox.Name = "barcodeTextbox";
            this.barcodeTextbox.Size = new System.Drawing.Size(390, 26);
            this.barcodeTextbox.TabIndex = 3;
            this.barcodeTextbox.TextChanged += new System.EventHandler(this.barcodeTextbox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(994, 787);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "SCAN PRODUCT NUMBER";
            // 
            // quantityTextbox
            // 
            this.quantityTextbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.quantityTextbox.Location = new System.Drawing.Point(46, 824);
            this.quantityTextbox.Name = "quantityTextbox";
            this.quantityTextbox.Size = new System.Drawing.Size(151, 26);
            this.quantityTextbox.TabIndex = 5;
            this.quantityTextbox.TextChanged += new System.EventHandler(this.quantityTextbox_TextChanged);
            this.quantityTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quantityTextbox_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 782);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "QUANTITY";
            // 
            // insertButton
            // 
            this.insertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.insertButton.Enabled = false;
            this.insertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertButton.Location = new System.Drawing.Point(1474, 729);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(220, 85);
            this.insertButton.TabIndex = 7;
            this.insertButton.Text = "INSERT";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // bInvenBuildingCombobox
            // 
            this.bInvenBuildingCombobox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bInvenBuildingCombobox.FormattingEnabled = true;
            this.bInvenBuildingCombobox.Location = new System.Drawing.Point(305, 824);
            this.bInvenBuildingCombobox.Name = "bInvenBuildingCombobox";
            this.bInvenBuildingCombobox.Size = new System.Drawing.Size(244, 28);
            this.bInvenBuildingCombobox.TabIndex = 8;
            // 
            // bInvenRoomCombobox
            // 
            this.bInvenRoomCombobox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bInvenRoomCombobox.FormattingEnabled = true;
            this.bInvenRoomCombobox.Location = new System.Drawing.Point(637, 822);
            this.bInvenRoomCombobox.Name = "bInvenRoomCombobox";
            this.bInvenRoomCombobox.Size = new System.Drawing.Size(247, 28);
            this.bInvenRoomCombobox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(343, 787);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "BUILDING";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(707, 787);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "ROOM";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.barcodeDescriptionCheckbox);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(1037, 709);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 63);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // barcodeDescriptionCheckbox
            // 
            this.barcodeDescriptionCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.barcodeDescriptionCheckbox.AutoSize = true;
            this.barcodeDescriptionCheckbox.Location = new System.Drawing.Point(113, 37);
            this.barcodeDescriptionCheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barcodeDescriptionCheckbox.Name = "barcodeDescriptionCheckbox";
            this.barcodeDescriptionCheckbox.Size = new System.Drawing.Size(22, 21);
            this.barcodeDescriptionCheckbox.TabIndex = 23;
            this.barcodeDescriptionCheckbox.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(256, 32);
            this.label17.TabIndex = 22;
            this.label17.Text = "Include Description";
            // 
            // Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1776, 898);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bInvenRoomCombobox);
            this.Controls.Add(this.bInvenBuildingCombobox);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quantityTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barcodeTextbox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.dataGridView1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1789, 893);
            this.Name = "Barcode";
            this.Text = "Barcode";
            this.Load += new System.EventHandler(this.Barcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox barcodeTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox quantityTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.ComboBox bInvenBuildingCombobox;
        private System.Windows.Forms.ComboBox bInvenRoomCombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox barcodeDescriptionCheckbox;
        private System.Windows.Forms.Label label17;
    }
}