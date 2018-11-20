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
            this.inventoryButton = new System.Windows.Forms.Button();
            this.addEquipmentButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.takeInventoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inventoryButton
            // 
            this.inventoryButton.BackColor = System.Drawing.Color.Snow;
            this.inventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryButton.ForeColor = System.Drawing.SystemColors.MenuText;
            this.inventoryButton.Location = new System.Drawing.Point(51, 24);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(264, 179);
            this.inventoryButton.TabIndex = 0;
            this.inventoryButton.Text = "Search Inventory";
            this.inventoryButton.UseVisualStyleBackColor = false;
            this.inventoryButton.Click += new System.EventHandler(this.inventoryButton_Click);
            // 
            // addEquipmentButton
            // 
            this.addEquipmentButton.BackColor = System.Drawing.Color.Snow;
            this.addEquipmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEquipmentButton.ForeColor = System.Drawing.SystemColors.MenuText;
            this.addEquipmentButton.Location = new System.Drawing.Point(441, 24);
            this.addEquipmentButton.Name = "addEquipmentButton";
            this.addEquipmentButton.Size = new System.Drawing.Size(264, 179);
            this.addEquipmentButton.TabIndex = 2;
            this.addEquipmentButton.Text = "Create New Equipment";
            this.addEquipmentButton.UseVisualStyleBackColor = false;
            this.addEquipmentButton.Click += new System.EventHandler(this.addEquipmentButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Snow;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.SystemColors.MenuText;
            this.deleteButton.Location = new System.Drawing.Point(441, 230);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(264, 178);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete From Inventory";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Snow;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(738, 382);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(122, 65);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // takeInventoryButton
            // 
            this.takeInventoryButton.BackColor = System.Drawing.Color.Snow;
            this.takeInventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeInventoryButton.ForeColor = System.Drawing.SystemColors.MenuText;
            this.takeInventoryButton.Location = new System.Drawing.Point(51, 230);
            this.takeInventoryButton.Name = "takeInventoryButton";
            this.takeInventoryButton.Size = new System.Drawing.Size(264, 178);
            this.takeInventoryButton.TabIndex = 7;
            this.takeInventoryButton.Text = "Take Inventory";
            this.takeInventoryButton.UseVisualStyleBackColor = false;
            this.takeInventoryButton.Click += new System.EventHandler(this.takeInventoryButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 479);
            this.Controls.Add(this.takeInventoryButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addEquipmentButton);
            this.Controls.Add(this.inventoryButton);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button inventoryButton;
        private System.Windows.Forms.Button addEquipmentButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button takeInventoryButton;
    }
}