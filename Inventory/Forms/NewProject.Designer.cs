namespace Inventory
{
    partial class NewProject
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
            this.projectNameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.projectTicketTextbox = new System.Windows.Forms.TextBox();
            this.projectDescTextbox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.projectCreateButton = new System.Windows.Forms.Button();
            this.projectCloseButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuspendLayout();
            // 
            // projectNameTextbox
            // 
            this.projectNameTextbox.Location = new System.Drawing.Point(37, 92);
            this.projectNameTextbox.Name = "projectNameTextbox";
            this.projectNameTextbox.Size = new System.Drawing.Size(194, 26);
            this.projectNameTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(416, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ticket #";
            // 
            // projectTicketTextbox
            // 
            this.projectTicketTextbox.Location = new System.Drawing.Point(394, 92);
            this.projectTicketTextbox.Name = "projectTicketTextbox";
            this.projectTicketTextbox.Size = new System.Drawing.Size(198, 26);
            this.projectTicketTextbox.TabIndex = 3;
            // 
            // projectDescTextbox
            // 
            this.projectDescTextbox.Location = new System.Drawing.Point(37, 196);
            this.projectDescTextbox.Name = "projectDescTextbox";
            this.projectDescTextbox.Size = new System.Drawing.Size(555, 161);
            this.projectDescTextbox.TabIndex = 4;
            this.projectDescTextbox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description";
            // 
            // projectCreateButton
            // 
            this.projectCreateButton.Location = new System.Drawing.Point(89, 363);
            this.projectCreateButton.Name = "projectCreateButton";
            this.projectCreateButton.Size = new System.Drawing.Size(142, 56);
            this.projectCreateButton.TabIndex = 6;
            this.projectCreateButton.Text = "Create";
            this.projectCreateButton.UseVisualStyleBackColor = true;
            this.projectCreateButton.Click += new System.EventHandler(this.projectCreateButton_Click);
            // 
            // projectCloseButton
            // 
            this.projectCloseButton.Location = new System.Drawing.Point(394, 363);
            this.projectCloseButton.Name = "projectCloseButton";
            this.projectCloseButton.Size = new System.Drawing.Size(142, 56);
            this.projectCloseButton.TabIndex = 7;
            this.projectCloseButton.Text = "Close";
            this.projectCloseButton.UseVisualStyleBackColor = true;
            this.projectCloseButton.Click += new System.EventHandler(this.projectCloseButton_Click);
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "INVENTORY_ID";
            this.dataGridViewTextBoxColumn15.HeaderText = "INVENTORY_ID";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "EVENT";
            this.dataGridViewTextBoxColumn16.HeaderText = "EVENT";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "USERNAME";
            this.dataGridViewTextBoxColumn17.HeaderText = "USERNAME";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "HISTORY_DATE";
            this.dataGridViewTextBoxColumn18.HeaderText = "HISTORY_DATE";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn19.HeaderText = "ID";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "EQUIPMENT";
            this.dataGridViewTextBoxColumn20.HeaderText = "EQUIPMENT";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "PRODUCT";
            this.dataGridViewTextBoxColumn21.HeaderText = "PRODUCT";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "INVDATE";
            this.dataGridViewTextBoxColumn22.HeaderText = "INVDATE";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "EQUIPMENT";
            this.dataGridViewTextBoxColumn10.HeaderText = "EQUIPMENT";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "CATEGORY";
            this.dataGridViewTextBoxColumn11.HeaderText = "CATEGORY";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "BUILDING";
            this.dataGridViewTextBoxColumn12.HeaderText = "BUILDING";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ROOM";
            this.dataGridViewTextBoxColumn13.HeaderText = "ROOM";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "USERS";
            this.dataGridViewTextBoxColumn14.HeaderText = "USERS";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 474);
            this.Controls.Add(this.projectCloseButton);
            this.Controls.Add(this.projectCreateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.projectDescTextbox);
            this.Controls.Add(this.projectTicketTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectNameTextbox);
            this.MinimumSize = new System.Drawing.Size(650, 530);
            this.Name = "NewProject";
            this.Text = "NewProject";
            this.Load += new System.EventHandler(this.NewProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectNameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox projectTicketTextbox;
        private System.Windows.Forms.RichTextBox projectDescTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button projectCreateButton;
        private System.Windows.Forms.Button projectCloseButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}