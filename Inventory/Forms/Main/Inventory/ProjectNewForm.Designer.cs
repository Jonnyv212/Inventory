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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectNewForm));
            this.createPbutton = new System.Windows.Forms.Button();
            this.ticketNoTextbox = new System.Windows.Forms.TextBox();
            this.pNameTextbox = new System.Windows.Forms.TextBox();
            this.descTextbox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainClose = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // createPbutton
            // 
            this.createPbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.createPbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createPbutton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPbutton.ForeColor = System.Drawing.Color.White;
            this.createPbutton.Location = new System.Drawing.Point(110, 313);
            this.createPbutton.Margin = new System.Windows.Forms.Padding(2);
            this.createPbutton.Name = "createPbutton";
            this.createPbutton.Size = new System.Drawing.Size(87, 45);
            this.createPbutton.TabIndex = 51;
            this.createPbutton.Text = "Create";
            this.createPbutton.UseVisualStyleBackColor = false;
            this.createPbutton.Click += new System.EventHandler(this.createPbutton_Click);
            // 
            // ticketNoTextbox
            // 
            this.ticketNoTextbox.Location = new System.Drawing.Point(249, 95);
            this.ticketNoTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.ticketNoTextbox.Name = "ticketNoTextbox";
            this.ticketNoTextbox.Size = new System.Drawing.Size(163, 20);
            this.ticketNoTextbox.TabIndex = 50;
            // 
            // pNameTextbox
            // 
            this.pNameTextbox.Location = new System.Drawing.Point(22, 95);
            this.pNameTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.pNameTextbox.Name = "pNameTextbox";
            this.pNameTextbox.Size = new System.Drawing.Size(163, 20);
            this.pNameTextbox.TabIndex = 49;
            // 
            // descTextbox
            // 
            this.descTextbox.BackColor = System.Drawing.Color.White;
            this.descTextbox.Location = new System.Drawing.Point(22, 161);
            this.descTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.descTextbox.Name = "descTextbox";
            this.descTextbox.Size = new System.Drawing.Size(390, 140);
            this.descTextbox.TabIndex = 48;
            this.descTextbox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(165, 140);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(276, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 18);
            this.label8.TabIndex = 46;
            this.label8.Text = "Ticket Number";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(50, 75);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 18);
            this.label9.TabIndex = 45;
            this.label9.Text = "Project Name";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(229, 313);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 45);
            this.button1.TabIndex = 53;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.mainClose_Click);
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
            this.panel2.Size = new System.Drawing.Size(441, 55);
            this.panel2.TabIndex = 54;
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
            this.mainClose.Location = new System.Drawing.Point(406, 9);
            this.mainClose.Margin = new System.Windows.Forms.Padding(0);
            this.mainClose.Name = "mainClose";
            this.mainClose.Size = new System.Drawing.Size(26, 27);
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
            this.label19.Location = new System.Drawing.Point(76, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(298, 30);
            this.label19.TabIndex = 0;
            this.label19.Text = "Inventory - Create New Project";
            this.label19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label19_MouseDown);
            this.label19.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label19_MouseMove);
            this.label19.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label19_MouseUp);
            // 
            // ProjectNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 384);
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
            this.MaximumSize = new System.Drawing.Size(443, 386);
            this.MinimumSize = new System.Drawing.Size(443, 386);
            this.Name = "ProjectNewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mainClose;
        private System.Windows.Forms.Label label19;
    }
}