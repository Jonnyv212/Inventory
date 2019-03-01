namespace Inventory
{
    partial class InventoryAddForm
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
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addInvenEquipTextbox = new System.Windows.Forms.TextBox();
            this.addInvenQuantityTextbox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.insertAddInventoryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.closeAddInventoryButton = new System.Windows.Forms.Button();
            this.addInvenCategoryCombobox = new System.Windows.Forms.ComboBox();
            this.addInvenProjectCombobox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainClose = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(443, 232);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 20);
            this.label17.TabIndex = 45;
            this.label17.Text = "Project:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "* Category:";
            // 
            // addInvenEquipTextbox
            // 
            this.addInvenEquipTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.addInvenEquipTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.addInvenEquipTextbox.Location = new System.Drawing.Point(552, 128);
            this.addInvenEquipTextbox.Name = "addInvenEquipTextbox";
            this.addInvenEquipTextbox.Size = new System.Drawing.Size(262, 26);
            this.addInvenEquipTextbox.TabIndex = 39;
            // 
            // addInvenQuantityTextbox
            // 
            this.addInvenQuantityTextbox.Location = new System.Drawing.Point(125, 232);
            this.addInvenQuantityTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addInvenQuantityTextbox.Name = "addInvenQuantityTextbox";
            this.addInvenQuantityTextbox.Size = new System.Drawing.Size(262, 26);
            this.addInvenQuantityTextbox.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(11, 232);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 20);
            this.label16.TabIndex = 37;
            this.label16.Text = "* Quantity:";
            // 
            // insertAddInventoryButton
            // 
            this.insertAddInventoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.insertAddInventoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.insertAddInventoryButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertAddInventoryButton.ForeColor = System.Drawing.Color.White;
            this.insertAddInventoryButton.Location = new System.Drawing.Point(243, 351);
            this.insertAddInventoryButton.Name = "insertAddInventoryButton";
            this.insertAddInventoryButton.Size = new System.Drawing.Size(144, 65);
            this.insertAddInventoryButton.TabIndex = 33;
            this.insertAddInventoryButton.Text = "Insert";
            this.insertAddInventoryButton.UseVisualStyleBackColor = false;
            this.insertAddInventoryButton.Click += new System.EventHandler(this.insertAddInventoryButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(443, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "* Equipment:";
            // 
            // closeAddInventoryButton
            // 
            this.closeAddInventoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.closeAddInventoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeAddInventoryButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeAddInventoryButton.ForeColor = System.Drawing.Color.White;
            this.closeAddInventoryButton.Location = new System.Drawing.Point(471, 351);
            this.closeAddInventoryButton.Name = "closeAddInventoryButton";
            this.closeAddInventoryButton.Size = new System.Drawing.Size(144, 65);
            this.closeAddInventoryButton.TabIndex = 47;
            this.closeAddInventoryButton.Text = "Close";
            this.closeAddInventoryButton.UseVisualStyleBackColor = false;
            this.closeAddInventoryButton.Click += new System.EventHandler(this.closeAddInventoryButton_Click);
            // 
            // addInvenCategoryCombobox
            // 
            this.addInvenCategoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addInvenCategoryCombobox.FormattingEnabled = true;
            this.addInvenCategoryCombobox.Location = new System.Drawing.Point(125, 125);
            this.addInvenCategoryCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addInvenCategoryCombobox.Name = "addInvenCategoryCombobox";
            this.addInvenCategoryCombobox.Size = new System.Drawing.Size(262, 28);
            this.addInvenCategoryCombobox.TabIndex = 63;
            this.addInvenCategoryCombobox.SelectedIndexChanged += new System.EventHandler(this.addInvenCategoryCombobox_SelectedIndexChanged);
            // 
            // addInvenProjectCombobox
            // 
            this.addInvenProjectCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addInvenProjectCombobox.FormattingEnabled = true;
            this.addInvenProjectCombobox.Location = new System.Drawing.Point(552, 229);
            this.addInvenProjectCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addInvenProjectCombobox.Name = "addInvenProjectCombobox";
            this.addInvenProjectCombobox.Size = new System.Drawing.Size(262, 28);
            this.addInvenProjectCombobox.TabIndex = 64;
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
            this.panel2.Size = new System.Drawing.Size(858, 66);
            this.panel2.TabIndex = 65;
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
            this.mainClose.Location = new System.Drawing.Point(807, 12);
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
            this.label19.Size = new System.Drawing.Size(608, 45);
            this.label19.TabIndex = 0;
            this.label19.Text = "Pathology Informatics - Manual Inventory";
            this.label19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plabel19_MouseDown);
            this.label19.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label19_MouseMove);
            this.label19.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label19_MouseUp);
            // 
            // InventoryAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(858, 448);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.addInvenProjectCombobox);
            this.Controls.Add(this.addInvenCategoryCombobox);
            this.Controls.Add(this.closeAddInventoryButton);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addInvenEquipTextbox);
            this.Controls.Add(this.addInvenQuantityTextbox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.insertAddInventoryButton);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(860, 600);
            this.MinimumSize = new System.Drawing.Size(860, 450);
            this.Name = "InventoryAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.InventoryAddForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addInvenEquipTextbox;
        public System.Windows.Forms.TextBox addInvenQuantityTextbox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button insertAddInventoryButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closeAddInventoryButton;
        private System.Windows.Forms.ComboBox addInvenCategoryCombobox;
        private System.Windows.Forms.ComboBox addInvenProjectCombobox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label mainClose;
        private System.Windows.Forms.Label label19;
    }
}