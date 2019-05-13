namespace Inventory
{
    partial class InventoryEditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editInvenTermIDTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editApplyButton = new System.Windows.Forms.Button();
            this.editCloseButton = new System.Windows.Forms.Button();
            this.editInvenIDTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.editInvenProjectCombobox = new System.Windows.Forms.ComboBox();
            this.editInvenCategoryCombobox = new System.Windows.Forms.ComboBox();
            this.editInvenEquipCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(295, 195);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 53;
            this.label17.Text = "Project:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "* Category:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(284, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "* Equipment:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 199);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Term ID:";
            // 
            // editInvenTermIDTextbox
            // 
            this.editInvenTermIDTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editInvenTermIDTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.editInvenTermIDTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.editInvenTermIDTextbox.Location = new System.Drawing.Point(89, 193);
            this.editInvenTermIDTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.editInvenTermIDTextbox.Name = "editInvenTermIDTextbox";
            this.editInvenTermIDTextbox.Size = new System.Drawing.Size(176, 20);
            this.editInvenTermIDTextbox.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(198, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 29);
            this.label3.TabIndex = 56;
            this.label3.Text = "Edit Inventory";
            // 
            // editApplyButton
            // 
            this.editApplyButton.Location = new System.Drawing.Point(174, 263);
            this.editApplyButton.Name = "editApplyButton";
            this.editApplyButton.Size = new System.Drawing.Size(83, 32);
            this.editApplyButton.TabIndex = 57;
            this.editApplyButton.Text = "Apply";
            this.editApplyButton.UseVisualStyleBackColor = true;
            // 
            // editCloseButton
            // 
            this.editCloseButton.Location = new System.Drawing.Point(322, 263);
            this.editCloseButton.Name = "editCloseButton";
            this.editCloseButton.Size = new System.Drawing.Size(83, 32);
            this.editCloseButton.TabIndex = 58;
            this.editCloseButton.Text = "Close";
            this.editCloseButton.UseVisualStyleBackColor = true;
            // 
            // editInvenIDTextbox
            // 
            this.editInvenIDTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.editInvenIDTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.editInvenIDTextbox.Location = new System.Drawing.Point(44, 25);
            this.editInvenIDTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.editInvenIDTextbox.Name = "editInvenIDTextbox";
            this.editInvenIDTextbox.ReadOnly = true;
            this.editInvenIDTextbox.Size = new System.Drawing.Size(84, 20);
            this.editInvenIDTextbox.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "*ID:";
            // 
            // editInvenProjectCombobox
            // 
            this.editInvenProjectCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editInvenProjectCombobox.FormattingEnabled = true;
            this.editInvenProjectCombobox.Location = new System.Drawing.Point(357, 191);
            this.editInvenProjectCombobox.Name = "editInvenProjectCombobox";
            this.editInvenProjectCombobox.Size = new System.Drawing.Size(176, 21);
            this.editInvenProjectCombobox.TabIndex = 61;
            // 
            // editInvenCategoryCombobox
            // 
            this.editInvenCategoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editInvenCategoryCombobox.FormattingEnabled = true;
            this.editInvenCategoryCombobox.Location = new System.Drawing.Point(89, 114);
            this.editInvenCategoryCombobox.Name = "editInvenCategoryCombobox";
            this.editInvenCategoryCombobox.Size = new System.Drawing.Size(176, 21);
            this.editInvenCategoryCombobox.TabIndex = 62;
            // 
            // editInvenEquipCombobox
            // 
            this.editInvenEquipCombobox.FormattingEnabled = true;
            this.editInvenEquipCombobox.Location = new System.Drawing.Point(357, 114);
            this.editInvenEquipCombobox.Name = "editInvenEquipCombobox";
            this.editInvenEquipCombobox.Size = new System.Drawing.Size(176, 21);
            this.editInvenEquipCombobox.TabIndex = 63;
            // 
            // InventoryEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 306);
            this.Controls.Add(this.editInvenEquipCombobox);
            this.Controls.Add(this.editInvenCategoryCombobox);
            this.Controls.Add(this.editInvenProjectCombobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.editInvenIDTextbox);
            this.Controls.Add(this.editCloseButton);
            this.Controls.Add(this.editApplyButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editInvenTermIDTextbox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.MaximumSize = new System.Drawing.Size(580, 345);
            this.MinimumSize = new System.Drawing.Size(580, 345);
            this.Name = "InventoryEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryEditForm";
            this.Load += new System.EventHandler(this.InventoryEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editInvenTermIDTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editApplyButton;
        private System.Windows.Forms.Button editCloseButton;
        private System.Windows.Forms.TextBox editInvenIDTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox editInvenProjectCombobox;
        private System.Windows.Forms.ComboBox editInvenCategoryCombobox;
        private System.Windows.Forms.ComboBox editInvenEquipCombobox;
    }
}