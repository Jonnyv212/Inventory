namespace Inventory
{
    partial class ProjectNewForm
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
            this.createPbutton = new System.Windows.Forms.Button();
            this.ticketNoTextbox = new System.Windows.Forms.TextBox();
            this.pNameTextbox = new System.Windows.Forms.TextBox();
            this.descTextbox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainClose = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // createPbutton
            // 
            this.createPbutton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.createPbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.createPbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createPbutton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPbutton.ForeColor = System.Drawing.Color.White;
            this.createPbutton.Location = new System.Drawing.Point(165, 482);
            this.createPbutton.Name = "createPbutton";
            this.createPbutton.Size = new System.Drawing.Size(131, 69);
            this.createPbutton.TabIndex = 51;
            this.createPbutton.Text = "Create Project";
            this.createPbutton.UseVisualStyleBackColor = false;
            this.createPbutton.Click += new System.EventHandler(this.createPbutton_Click);
            // 
            // ticketNoTextbox
            // 
            this.ticketNoTextbox.Location = new System.Drawing.Point(374, 146);
            this.ticketNoTextbox.Name = "ticketNoTextbox";
            this.ticketNoTextbox.Size = new System.Drawing.Size(242, 26);
            this.ticketNoTextbox.TabIndex = 50;
            // 
            // pNameTextbox
            // 
            this.pNameTextbox.Location = new System.Drawing.Point(33, 146);
            this.pNameTextbox.Name = "pNameTextbox";
            this.pNameTextbox.Size = new System.Drawing.Size(242, 26);
            this.pNameTextbox.TabIndex = 49;
            // 
            // descTextbox
            // 
            this.descTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.descTextbox.BackColor = System.Drawing.Color.White;
            this.descTextbox.Location = new System.Drawing.Point(33, 248);
            this.descTextbox.Name = "descTextbox";
            this.descTextbox.Size = new System.Drawing.Size(583, 213);
            this.descTextbox.TabIndex = 48;
            this.descTextbox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(247, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 29);
            this.label7.TabIndex = 47;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(414, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 26);
            this.label8.TabIndex = 46;
            this.label8.Text = "Ticket Number";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(75, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 26);
            this.label9.TabIndex = 45;
            this.label9.Text = "Project Name";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(344, 482);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 69);
            this.button1.TabIndex = 53;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.panel2.Size = new System.Drawing.Size(662, 66);
            this.panel2.TabIndex = 74;
            // 
            // mainClose
            // 
            this.mainClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mainClose.AutoSize = true;
            this.mainClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.mainClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainClose.ForeColor = System.Drawing.Color.White;
            this.mainClose.Location = new System.Drawing.Point(611, 12);
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
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(18, 12);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(550, 38);
            this.label19.TabIndex = 0;
            this.label19.Text = "Pathology Informatics - Create New Project";
            // 
            // ProjectNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 591);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createPbutton);
            this.Controls.Add(this.ticketNoTextbox);
            this.Controls.Add(this.pNameTextbox);
            this.Controls.Add(this.descTextbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(664, 593);
            this.MinimumSize = new System.Drawing.Size(664, 593);
            this.Name = "ProjectNewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createPbutton;
        private System.Windows.Forms.TextBox ticketNoTextbox;
        private System.Windows.Forms.TextBox pNameTextbox;
        private System.Windows.Forms.RichTextBox descTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label mainClose;
        private System.Windows.Forms.Label label19;
    }
}