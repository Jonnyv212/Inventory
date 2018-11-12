namespace WindowsFormsApp1
{
    partial class CreateItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.catTextbox = new System.Windows.Forms.TextBox();
            this.sub3Textbox = new System.Windows.Forms.TextBox();
            this.sub1Textbox = new System.Windows.Forms.TextBox();
            this.sub2Textbox = new System.Windows.Forms.TextBox();
            this.locationTextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.previewButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sub Category 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sub Category 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sub Category 3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Location";
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(140, 104);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(186, 26);
            this.nameTextbox.TabIndex = 6;
            // 
            // catTextbox
            // 
            this.catTextbox.Location = new System.Drawing.Point(140, 189);
            this.catTextbox.Name = "catTextbox";
            this.catTextbox.Size = new System.Drawing.Size(186, 26);
            this.catTextbox.TabIndex = 7;
            // 
            // sub3Textbox
            // 
            this.sub3Textbox.Location = new System.Drawing.Point(546, 273);
            this.sub3Textbox.Name = "sub3Textbox";
            this.sub3Textbox.Size = new System.Drawing.Size(186, 26);
            this.sub3Textbox.TabIndex = 8;
            // 
            // sub1Textbox
            // 
            this.sub1Textbox.Location = new System.Drawing.Point(546, 107);
            this.sub1Textbox.Name = "sub1Textbox";
            this.sub1Textbox.Size = new System.Drawing.Size(186, 26);
            this.sub1Textbox.TabIndex = 9;
            // 
            // sub2Textbox
            // 
            this.sub2Textbox.Location = new System.Drawing.Point(546, 189);
            this.sub2Textbox.Name = "sub2Textbox";
            this.sub2Textbox.Size = new System.Drawing.Size(186, 26);
            this.sub2Textbox.TabIndex = 10;
            // 
            // locationTextbox
            // 
            this.locationTextbox.Location = new System.Drawing.Point(140, 279);
            this.locationTextbox.Name = "locationTextbox";
            this.locationTextbox.Size = new System.Drawing.Size(186, 26);
            this.locationTextbox.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(207, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(367, 40);
            this.label7.TabIndex = 12;
            this.label7.Text = "CREATE NEW ITEM";
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(140, 365);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(125, 42);
            this.previewButton.TabIndex = 13;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(567, 365);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(125, 42);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(361, 365);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(122, 41);
            this.createButton.TabIndex = 15;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // CreateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 419);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.locationTextbox);
            this.Controls.Add(this.sub2Textbox);
            this.Controls.Add(this.sub1Textbox);
            this.Controls.Add(this.sub3Textbox);
            this.Controls.Add(this.catTextbox);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateItem";
            this.Text = "CreateItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.TextBox catTextbox;
        private System.Windows.Forms.TextBox sub3Textbox;
        private System.Windows.Forms.TextBox sub1Textbox;
        private System.Windows.Forms.TextBox sub2Textbox;
        private System.Windows.Forms.TextBox locationTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
    }
}