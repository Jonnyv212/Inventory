namespace WindowsFormsApp1
{
    partial class AddItem
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
            this.createItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createItemButton
            // 
            this.createItemButton.Location = new System.Drawing.Point(289, 56);
            this.createItemButton.Name = "createItemButton";
            this.createItemButton.Size = new System.Drawing.Size(106, 51);
            this.createItemButton.TabIndex = 0;
            this.createItemButton.Text = "Create Item";
            this.createItemButton.UseVisualStyleBackColor = true;
            this.createItemButton.Click += new System.EventHandler(this.createItemButton_Click);
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.createItemButton);
            this.Name = "AddItem";
            this.Text = "AddItem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createItemButton;
    }
}