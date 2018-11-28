namespace Inventory
{
    partial class Main
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
            this.inventoryTabControl = new System.Windows.Forms.TabControl();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchCombobox = new System.Windows.Forms.ComboBox();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.takeTab = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.serialTextbox = new System.Windows.Forms.TextBox();
            this.equipmentCombobox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.locationCombobox = new System.Windows.Forms.ComboBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.insertButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.categoryCombobox = new System.Windows.Forms.ComboBox();
            this.quantityTextbox = new System.Windows.Forms.TextBox();
            this.editTab = new System.Windows.Forms.TabPage();
            this.addTab = new System.Windows.Forms.TabPage();
            this.removeTab = new System.Windows.Forms.TabPage();
            this.inventoryTabControl.SuspendLayout();
            this.searchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.takeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // inventoryTabControl
            // 
            this.inventoryTabControl.Controls.Add(this.searchTab);
            this.inventoryTabControl.Controls.Add(this.takeTab);
            this.inventoryTabControl.Controls.Add(this.editTab);
            this.inventoryTabControl.Controls.Add(this.addTab);
            this.inventoryTabControl.Controls.Add(this.removeTab);
            this.inventoryTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryTabControl.ItemSize = new System.Drawing.Size(97, 30);
            this.inventoryTabControl.Location = new System.Drawing.Point(0, 0);
            this.inventoryTabControl.Name = "inventoryTabControl";
            this.inventoryTabControl.SelectedIndex = 0;
            this.inventoryTabControl.Size = new System.Drawing.Size(1221, 449);
            this.inventoryTabControl.TabIndex = 8;
            // 
            // searchTab
            // 
            this.searchTab.Controls.Add(this.label1);
            this.searchTab.Controls.Add(this.searchButton);
            this.searchTab.Controls.Add(this.dataGridView1);
            this.searchTab.Controls.Add(this.searchCombobox);
            this.searchTab.Controls.Add(this.searchTextbox);
            this.searchTab.Location = new System.Drawing.Point(4, 34);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(1213, 411);
            this.searchTab.TabIndex = 0;
            this.searchTab.Text = "Search";
            this.searchTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Column";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchButton.Location = new System.Drawing.Point(783, 125);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(102, 35);
            this.searchButton.TabIndex = 11;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(867, 352);
            this.dataGridView1.TabIndex = 13;
            // 
            // searchCombobox
            // 
            this.searchCombobox.FormattingEnabled = true;
            this.searchCombobox.Items.AddRange(new object[] {
            "EQUIPMENT_NAME",
            "CATEGORY",
            "LOCATION",
            "ACTIVITY_BY",
            "DATE",
            "INVENTORY_ID",
            "ACTIVITY"});
            this.searchCombobox.Location = new System.Drawing.Point(18, 64);
            this.searchCombobox.Name = "searchCombobox";
            this.searchCombobox.Size = new System.Drawing.Size(208, 30);
            this.searchCombobox.TabIndex = 15;
            // 
            // searchTextbox
            // 
            this.searchTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextbox.Location = new System.Drawing.Point(18, 130);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(715, 28);
            this.searchTextbox.TabIndex = 7;
            this.searchTextbox.TextChanged += new System.EventHandler(this.searchTextbox_TextChanged);
            // 
            // takeTab
            // 
            this.takeTab.Controls.Add(this.label6);
            this.takeTab.Controls.Add(this.serialTextbox);
            this.takeTab.Controls.Add(this.equipmentCombobox);
            this.takeTab.Controls.Add(this.label7);
            this.takeTab.Controls.Add(this.label2);
            this.takeTab.Controls.Add(this.checkBox1);
            this.takeTab.Controls.Add(this.locationCombobox);
            this.takeTab.Controls.Add(this.clearButton);
            this.takeTab.Controls.Add(this.label3);
            this.takeTab.Controls.Add(this.insertButton);
            this.takeTab.Controls.Add(this.label5);
            this.takeTab.Controls.Add(this.label4);
            this.takeTab.Controls.Add(this.dataGridView2);
            this.takeTab.Controls.Add(this.categoryCombobox);
            this.takeTab.Controls.Add(this.quantityTextbox);
            this.takeTab.Location = new System.Drawing.Point(4, 34);
            this.takeTab.Name = "takeTab";
            this.takeTab.Padding = new System.Windows.Forms.Padding(3);
            this.takeTab.Size = new System.Drawing.Size(1213, 411);
            this.takeTab.TabIndex = 1;
            this.takeTab.Text = "Take Inventory";
            this.takeTab.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(750, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 32);
            this.label6.TabIndex = 14;
            this.label6.Text = "BARCODE";
            // 
            // serialTextbox
            // 
            this.serialTextbox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.serialTextbox.Location = new System.Drawing.Point(756, 102);
            this.serialTextbox.Multiline = true;
            this.serialTextbox.Name = "serialTextbox";
            this.serialTextbox.Size = new System.Drawing.Size(236, 28);
            this.serialTextbox.TabIndex = 13;
            this.serialTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serialTextbox_KeyDown);
            // 
            // equipmentCombobox
            // 
            this.equipmentCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equipmentCombobox.FormattingEnabled = true;
            this.equipmentCombobox.Location = new System.Drawing.Point(30, 39);
            this.equipmentCombobox.Name = "equipmentCombobox";
            this.equipmentCombobox.Size = new System.Drawing.Size(300, 30);
            this.equipmentCombobox.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(752, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "Serial Number";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(26, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Equipment";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(916, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 26);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Auto Insert";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // locationCombobox
            // 
            this.locationCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationCombobox.FormattingEnabled = true;
            this.locationCombobox.Location = new System.Drawing.Point(411, 39);
            this.locationCombobox.Name = "locationCombobox";
            this.locationCombobox.Size = new System.Drawing.Size(281, 30);
            this.locationCombobox.TabIndex = 2;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(1055, 77);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(150, 53);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(411, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Location";
            // 
            // insertButton
            // 
            this.insertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insertButton.Location = new System.Drawing.Point(1055, 13);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(150, 56);
            this.insertButton.TabIndex = 5;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(30, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Category";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(411, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantity";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 136);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1199, 267);
            this.dataGridView2.TabIndex = 4;
            // 
            // categoryCombobox
            // 
            this.categoryCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryCombobox.FormattingEnabled = true;
            this.categoryCombobox.Location = new System.Drawing.Point(34, 100);
            this.categoryCombobox.Name = "categoryCombobox";
            this.categoryCombobox.Size = new System.Drawing.Size(296, 30);
            this.categoryCombobox.TabIndex = 9;
            // 
            // quantityTextbox
            // 
            this.quantityTextbox.Enabled = false;
            this.quantityTextbox.Location = new System.Drawing.Point(411, 102);
            this.quantityTextbox.Name = "quantityTextbox";
            this.quantityTextbox.Size = new System.Drawing.Size(124, 28);
            this.quantityTextbox.TabIndex = 8;
            // 
            // editTab
            // 
            this.editTab.Location = new System.Drawing.Point(4, 34);
            this.editTab.Name = "editTab";
            this.editTab.Size = new System.Drawing.Size(1213, 411);
            this.editTab.TabIndex = 2;
            this.editTab.Text = "Edit Inventory";
            // 
            // addTab
            // 
            this.addTab.Location = new System.Drawing.Point(4, 34);
            this.addTab.Name = "addTab";
            this.addTab.Size = new System.Drawing.Size(1213, 411);
            this.addTab.TabIndex = 3;
            this.addTab.Text = "Add";
            this.addTab.UseVisualStyleBackColor = true;
            // 
            // removeTab
            // 
            this.removeTab.Location = new System.Drawing.Point(4, 34);
            this.removeTab.Name = "removeTab";
            this.removeTab.Size = new System.Drawing.Size(1213, 411);
            this.removeTab.TabIndex = 4;
            this.removeTab.Text = "Remove";
            this.removeTab.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 449);
            this.Controls.Add(this.inventoryTabControl);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load_1);
            this.inventoryTabControl.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.searchTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.takeTab.ResumeLayout(false);
            this.takeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl inventoryTabControl;
        private System.Windows.Forms.TabPage searchTab;
        private System.Windows.Forms.TabPage takeTab;
        private System.Windows.Forms.TabPage editTab;
        private System.Windows.Forms.TabPage addTab;
        private System.Windows.Forms.TabPage removeTab;
        private System.Windows.Forms.ComboBox searchCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox equipmentCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox locationCombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox categoryCombobox;
        private System.Windows.Forms.TextBox quantityTextbox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox serialTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button insertButton;
    }
}