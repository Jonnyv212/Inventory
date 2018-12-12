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
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchCombobox = new System.Windows.Forms.ComboBox();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.inventoryTab = new System.Windows.Forms.TabPage();
            this.inventoryInnerTabs = new System.Windows.Forms.TabControl();
            this.takeInventoryTab = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tInvenRoomCombobox = new System.Windows.Forms.ComboBox();
            this.tInvenEquipmentCombobox = new System.Windows.Forms.ComboBox();
            this.insertButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tInvenSerialTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tInvenBuildingCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tInvenCategoryCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.editInventoryTab = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.inventoryEditCombobox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.roomEditCombobox = new System.Windows.Forms.ComboBox();
            this.roomEditCheckbox = new System.Windows.Forms.CheckBox();
            this.serialEditCheckbox = new System.Windows.Forms.CheckBox();
            this.categoryEditCheckbox = new System.Windows.Forms.CheckBox();
            this.userEditCheckbox = new System.Windows.Forms.CheckBox();
            this.buildingEditCheckbox = new System.Windows.Forms.CheckBox();
            this.nameEditCheckbox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.categoryEditCombobox = new System.Windows.Forms.ComboBox();
            this.serialEditTextbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.userEditCombobox = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.buildingEditCombobox = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.nameEditCombobox = new System.Windows.Forms.ComboBox();
            this.createTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.createCategoryCombobox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.removeTab = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryTabControl.SuspendLayout();
            this.searchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.inventoryTab.SuspendLayout();
            this.inventoryInnerTabs.SuspendLayout();
            this.takeInventoryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.editInventoryTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.createTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inventoryTabControl
            // 
            this.inventoryTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.inventoryTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryTabControl.Controls.Add(this.searchTab);
            this.inventoryTabControl.Controls.Add(this.inventoryTab);
            this.inventoryTabControl.Controls.Add(this.createTab);
            this.inventoryTabControl.Controls.Add(this.removeTab);
            this.inventoryTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.inventoryTabControl.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryTabControl.HotTrack = true;
            this.inventoryTabControl.ItemSize = new System.Drawing.Size(50, 130);
            this.inventoryTabControl.Location = new System.Drawing.Point(2, 36);
            this.inventoryTabControl.Multiline = true;
            this.inventoryTabControl.Name = "inventoryTabControl";
            this.inventoryTabControl.SelectedIndex = 0;
            this.inventoryTabControl.Size = new System.Drawing.Size(1466, 746);
            this.inventoryTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.inventoryTabControl.TabIndex = 8;
            this.inventoryTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.inventoryTabControl_DrawItem);
            // 
            // searchTab
            // 
            this.searchTab.BackColor = System.Drawing.Color.Gray;
            this.searchTab.Controls.Add(this.label12);
            this.searchTab.Controls.Add(this.label1);
            this.searchTab.Controls.Add(this.searchButton);
            this.searchTab.Controls.Add(this.dataGridView1);
            this.searchTab.Controls.Add(this.searchCombobox);
            this.searchTab.Controls.Add(this.searchTextbox);
            this.searchTab.Location = new System.Drawing.Point(134, 4);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(1328, 738);
            this.searchTab.TabIndex = 0;
            this.searchTab.Text = "Search";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(449, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 25);
            this.label12.TabIndex = 17;
            this.label12.Text = "Search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Filters";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchButton.Location = new System.Drawing.Point(633, 107);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(110, 35);
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
            this.dataGridView1.Location = new System.Drawing.Point(6, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1114, 365);
            this.dataGridView1.TabIndex = 13;
            // 
            // searchCombobox
            // 
            this.searchCombobox.FormattingEnabled = true;
            this.searchCombobox.Items.AddRange(new object[] {
            "EQUIPMENT_NAME",
            "CATEGORY_NAME",
            "USERNAME"});
            this.searchCombobox.Location = new System.Drawing.Point(18, 41);
            this.searchCombobox.Name = "searchCombobox";
            this.searchCombobox.Size = new System.Drawing.Size(208, 33);
            this.searchCombobox.TabIndex = 15;
            // 
            // searchTextbox
            // 
            this.searchTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchTextbox.Location = new System.Drawing.Point(18, 107);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(573, 33);
            this.searchTextbox.TabIndex = 7;
            this.searchTextbox.TextChanged += new System.EventHandler(this.searchTextbox_TextChanged);
            // 
            // inventoryTab
            // 
            this.inventoryTab.Controls.Add(this.inventoryInnerTabs);
            this.inventoryTab.Location = new System.Drawing.Point(134, 4);
            this.inventoryTab.Name = "inventoryTab";
            this.inventoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.inventoryTab.Size = new System.Drawing.Size(1328, 738);
            this.inventoryTab.TabIndex = 1;
            this.inventoryTab.Text = "Inventory";
            this.inventoryTab.UseVisualStyleBackColor = true;
            // 
            // inventoryInnerTabs
            // 
            this.inventoryInnerTabs.Controls.Add(this.takeInventoryTab);
            this.inventoryInnerTabs.Controls.Add(this.editInventoryTab);
            this.inventoryInnerTabs.Location = new System.Drawing.Point(6, 6);
            this.inventoryInnerTabs.Name = "inventoryInnerTabs";
            this.inventoryInnerTabs.SelectedIndex = 0;
            this.inventoryInnerTabs.Size = new System.Drawing.Size(1316, 732);
            this.inventoryInnerTabs.TabIndex = 17;
            // 
            // takeInventoryTab
            // 
            this.takeInventoryTab.Controls.Add(this.dataGridView2);
            this.takeInventoryTab.Controls.Add(this.tInvenRoomCombobox);
            this.takeInventoryTab.Controls.Add(this.tInvenEquipmentCombobox);
            this.takeInventoryTab.Controls.Add(this.insertButton);
            this.takeInventoryTab.Controls.Add(this.clearButton);
            this.takeInventoryTab.Controls.Add(this.label7);
            this.takeInventoryTab.Controls.Add(this.tInvenSerialTextbox);
            this.takeInventoryTab.Controls.Add(this.label2);
            this.takeInventoryTab.Controls.Add(this.label3);
            this.takeInventoryTab.Controls.Add(this.tInvenBuildingCombobox);
            this.takeInventoryTab.Controls.Add(this.label4);
            this.takeInventoryTab.Controls.Add(this.tInvenCategoryCombobox);
            this.takeInventoryTab.Controls.Add(this.label5);
            this.takeInventoryTab.Location = new System.Drawing.Point(4, 34);
            this.takeInventoryTab.Name = "takeInventoryTab";
            this.takeInventoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.takeInventoryTab.Size = new System.Drawing.Size(1308, 694);
            this.takeInventoryTab.TabIndex = 0;
            this.takeInventoryTab.Text = "Take Inventory";
            this.takeInventoryTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(-4, 248);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1316, 443);
            this.dataGridView2.TabIndex = 4;
            // 
            // tInvenRoomCombobox
            // 
            this.tInvenRoomCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tInvenRoomCombobox.FormattingEnabled = true;
            this.tInvenRoomCombobox.Location = new System.Drawing.Point(419, 181);
            this.tInvenRoomCombobox.Name = "tInvenRoomCombobox";
            this.tInvenRoomCombobox.Size = new System.Drawing.Size(288, 33);
            this.tInvenRoomCombobox.TabIndex = 16;
            // 
            // tInvenEquipmentCombobox
            // 
            this.tInvenEquipmentCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tInvenEquipmentCombobox.FormattingEnabled = true;
            this.tInvenEquipmentCombobox.Location = new System.Drawing.Point(32, 76);
            this.tInvenEquipmentCombobox.Name = "tInvenEquipmentCombobox";
            this.tInvenEquipmentCombobox.Size = new System.Drawing.Size(333, 33);
            this.tInvenEquipmentCombobox.TabIndex = 0;
            // 
            // insertButton
            // 
            this.insertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insertButton.Location = new System.Drawing.Point(1068, 48);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(223, 61);
            this.insertButton.TabIndex = 5;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(1068, 149);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(223, 65);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(764, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Serial Number";
            // 
            // tInvenSerialTextbox
            // 
            this.tInvenSerialTextbox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tInvenSerialTextbox.Location = new System.Drawing.Point(769, 181);
            this.tInvenSerialTextbox.Multiline = true;
            this.tInvenSerialTextbox.Name = "tInvenSerialTextbox";
            this.tInvenSerialTextbox.Size = new System.Drawing.Size(236, 33);
            this.tInvenSerialTextbox.TabIndex = 13;
            this.tInvenSerialTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serialTextbox_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(27, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Equipment";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(27, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Building";
            // 
            // tInvenBuildingCombobox
            // 
            this.tInvenBuildingCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tInvenBuildingCombobox.FormattingEnabled = true;
            this.tInvenBuildingCombobox.Location = new System.Drawing.Point(32, 181);
            this.tInvenBuildingCombobox.Name = "tInvenBuildingCombobox";
            this.tInvenBuildingCombobox.Size = new System.Drawing.Size(333, 33);
            this.tInvenBuildingCombobox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(414, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Room";
            // 
            // tInvenCategoryCombobox
            // 
            this.tInvenCategoryCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tInvenCategoryCombobox.FormattingEnabled = true;
            this.tInvenCategoryCombobox.Location = new System.Drawing.Point(419, 76);
            this.tInvenCategoryCombobox.Name = "tInvenCategoryCombobox";
            this.tInvenCategoryCombobox.Size = new System.Drawing.Size(278, 33);
            this.tInvenCategoryCombobox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(414, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Category";
            // 
            // editInventoryTab
            // 
            this.editInventoryTab.Controls.Add(this.label25);
            this.editInventoryTab.Controls.Add(this.inventoryEditCombobox);
            this.editInventoryTab.Controls.Add(this.groupBox2);
            this.editInventoryTab.Location = new System.Drawing.Point(4, 34);
            this.editInventoryTab.Name = "editInventoryTab";
            this.editInventoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.editInventoryTab.Size = new System.Drawing.Size(1308, 694);
            this.editInventoryTab.TabIndex = 1;
            this.editInventoryTab.Text = "Edit Inventory";
            this.editInventoryTab.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(50, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(135, 25);
            this.label25.TabIndex = 6;
            this.label25.Text = "Inventory ID";
            // 
            // inventoryEditCombobox
            // 
            this.inventoryEditCombobox.DisplayMember = "INVENTORY_ID";
            this.inventoryEditCombobox.FormattingEnabled = true;
            this.inventoryEditCombobox.Location = new System.Drawing.Point(11, 45);
            this.inventoryEditCombobox.Name = "inventoryEditCombobox";
            this.inventoryEditCombobox.Size = new System.Drawing.Size(218, 33);
            this.inventoryEditCombobox.TabIndex = 5;
            this.inventoryEditCombobox.ValueMember = "INVENTORY_ID";
            this.inventoryEditCombobox.SelectedIndexChanged += new System.EventHandler(this.inventoryEditCombobox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.roomEditCombobox);
            this.groupBox2.Controls.Add(this.roomEditCheckbox);
            this.groupBox2.Controls.Add(this.serialEditCheckbox);
            this.groupBox2.Controls.Add(this.categoryEditCheckbox);
            this.groupBox2.Controls.Add(this.userEditCheckbox);
            this.groupBox2.Controls.Add(this.buildingEditCheckbox);
            this.groupBox2.Controls.Add(this.nameEditCheckbox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.categoryEditCombobox);
            this.groupBox2.Controls.Add(this.serialEditTextbox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.userEditCombobox);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.buildingEditCombobox);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.nameEditCombobox);
            this.groupBox2.Location = new System.Drawing.Point(288, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(963, 600);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // roomEditCombobox
            // 
            this.roomEditCombobox.Enabled = false;
            this.roomEditCombobox.FormattingEnabled = true;
            this.roomEditCombobox.Location = new System.Drawing.Point(473, 409);
            this.roomEditCombobox.Name = "roomEditCombobox";
            this.roomEditCombobox.Size = new System.Drawing.Size(303, 33);
            this.roomEditCombobox.TabIndex = 22;
            // 
            // roomEditCheckbox
            // 
            this.roomEditCheckbox.AutoSize = true;
            this.roomEditCheckbox.Location = new System.Drawing.Point(698, 369);
            this.roomEditCheckbox.Name = "roomEditCheckbox";
            this.roomEditCheckbox.Size = new System.Drawing.Size(78, 29);
            this.roomEditCheckbox.TabIndex = 21;
            this.roomEditCheckbox.Text = "Edit";
            this.roomEditCheckbox.UseVisualStyleBackColor = true;
            this.roomEditCheckbox.CheckedChanged += new System.EventHandler(this.roomEditCheckbox_CheckedChanged);
            // 
            // serialEditCheckbox
            // 
            this.serialEditCheckbox.AutoSize = true;
            this.serialEditCheckbox.Location = new System.Drawing.Point(698, 232);
            this.serialEditCheckbox.Name = "serialEditCheckbox";
            this.serialEditCheckbox.Size = new System.Drawing.Size(78, 29);
            this.serialEditCheckbox.TabIndex = 20;
            this.serialEditCheckbox.Text = "Edit";
            this.serialEditCheckbox.UseVisualStyleBackColor = true;
            this.serialEditCheckbox.CheckedChanged += new System.EventHandler(this.serialEditCheckbox_CheckedChanged);
            // 
            // categoryEditCheckbox
            // 
            this.categoryEditCheckbox.AutoSize = true;
            this.categoryEditCheckbox.Location = new System.Drawing.Point(698, 104);
            this.categoryEditCheckbox.Name = "categoryEditCheckbox";
            this.categoryEditCheckbox.Size = new System.Drawing.Size(78, 29);
            this.categoryEditCheckbox.TabIndex = 19;
            this.categoryEditCheckbox.Text = "Edit";
            this.categoryEditCheckbox.UseVisualStyleBackColor = true;
            this.categoryEditCheckbox.CheckedChanged += new System.EventHandler(this.categoryEditCheckbox_CheckedChanged);
            // 
            // userEditCheckbox
            // 
            this.userEditCheckbox.AutoSize = true;
            this.userEditCheckbox.Location = new System.Drawing.Point(194, 232);
            this.userEditCheckbox.Name = "userEditCheckbox";
            this.userEditCheckbox.Size = new System.Drawing.Size(78, 29);
            this.userEditCheckbox.TabIndex = 18;
            this.userEditCheckbox.Text = "Edit";
            this.userEditCheckbox.UseVisualStyleBackColor = true;
            this.userEditCheckbox.CheckedChanged += new System.EventHandler(this.userEditCheckbox_CheckedChanged);
            // 
            // buildingEditCheckbox
            // 
            this.buildingEditCheckbox.AutoSize = true;
            this.buildingEditCheckbox.Location = new System.Drawing.Point(194, 373);
            this.buildingEditCheckbox.Name = "buildingEditCheckbox";
            this.buildingEditCheckbox.Size = new System.Drawing.Size(78, 29);
            this.buildingEditCheckbox.TabIndex = 17;
            this.buildingEditCheckbox.Text = "Edit";
            this.buildingEditCheckbox.UseVisualStyleBackColor = true;
            this.buildingEditCheckbox.CheckedChanged += new System.EventHandler(this.buildingEditCheckbox_CheckedChanged);
            // 
            // nameEditCheckbox
            // 
            this.nameEditCheckbox.AutoSize = true;
            this.nameEditCheckbox.Location = new System.Drawing.Point(194, 101);
            this.nameEditCheckbox.Name = "nameEditCheckbox";
            this.nameEditCheckbox.Size = new System.Drawing.Size(78, 29);
            this.nameEditCheckbox.TabIndex = 16;
            this.nameEditCheckbox.Text = "Edit";
            this.nameEditCheckbox.UseVisualStyleBackColor = true;
            this.nameEditCheckbox.CheckedChanged += new System.EventHandler(this.nameEditCheckbox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(468, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "CATEGORY";
            // 
            // categoryEditCombobox
            // 
            this.categoryEditCombobox.Enabled = false;
            this.categoryEditCombobox.FormattingEnabled = true;
            this.categoryEditCombobox.Location = new System.Drawing.Point(473, 136);
            this.categoryEditCombobox.Name = "categoryEditCombobox";
            this.categoryEditCombobox.Size = new System.Drawing.Size(303, 33);
            this.categoryEditCombobox.TabIndex = 14;
            // 
            // serialEditTextbox
            // 
            this.serialEditTextbox.Enabled = false;
            this.serialEditTextbox.Location = new System.Drawing.Point(473, 267);
            this.serialEditTextbox.Name = "serialEditTextbox";
            this.serialEditTextbox.Size = new System.Drawing.Size(303, 33);
            this.serialEditTextbox.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(468, 236);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 25);
            this.label13.TabIndex = 11;
            this.label13.Text = "SERIAL #";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(468, 373);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 25);
            this.label18.TabIndex = 9;
            this.label18.Text = "ROOM";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(27, 239);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 25);
            this.label22.TabIndex = 5;
            this.label22.Text = "USER";
            // 
            // userEditCombobox
            // 
            this.userEditCombobox.Enabled = false;
            this.userEditCombobox.FormattingEnabled = true;
            this.userEditCombobox.Location = new System.Drawing.Point(23, 267);
            this.userEditCombobox.Name = "userEditCombobox";
            this.userEditCombobox.Size = new System.Drawing.Size(303, 33);
            this.userEditCombobox.TabIndex = 4;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(27, 377);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 25);
            this.label23.TabIndex = 3;
            this.label23.Text = "BUILDING";
            // 
            // buildingEditCombobox
            // 
            this.buildingEditCombobox.Enabled = false;
            this.buildingEditCombobox.FormattingEnabled = true;
            this.buildingEditCombobox.Location = new System.Drawing.Point(23, 409);
            this.buildingEditCombobox.Name = "buildingEditCombobox";
            this.buildingEditCombobox.Size = new System.Drawing.Size(303, 33);
            this.buildingEditCombobox.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(27, 101);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(78, 25);
            this.label24.TabIndex = 1;
            this.label24.Text = "NAME";
            // 
            // nameEditCombobox
            // 
            this.nameEditCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameEditCombobox.Enabled = false;
            this.nameEditCombobox.FormattingEnabled = true;
            this.nameEditCombobox.Location = new System.Drawing.Point(23, 136);
            this.nameEditCombobox.Name = "nameEditCombobox";
            this.nameEditCombobox.Size = new System.Drawing.Size(303, 33);
            this.nameEditCombobox.TabIndex = 0;
            // 
            // createTab
            // 
            this.createTab.Controls.Add(this.panel1);
            this.createTab.Location = new System.Drawing.Point(134, 4);
            this.createTab.Name = "createTab";
            this.createTab.Size = new System.Drawing.Size(1328, 738);
            this.createTab.TabIndex = 3;
            this.createTab.Text = "Create";
            this.createTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.createCategoryCombobox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.dataGridView3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.createButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1328, 738);
            this.panel1.TabIndex = 1;
            // 
            // createCategoryCombobox
            // 
            this.createCategoryCombobox.FormattingEnabled = true;
            this.createCategoryCombobox.Location = new System.Drawing.Point(63, 148);
            this.createCategoryCombobox.Name = "createCategoryCombobox";
            this.createCategoryCombobox.Size = new System.Drawing.Size(251, 33);
            this.createCategoryCombobox.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(59, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Category";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(606, 140);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(113, 47);
            this.refreshButton.TabIndex = 14;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(12, 191);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 28;
            this.dataGridView3.Size = new System.Drawing.Size(1304, 533);
            this.dataGridView3.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(450, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 33);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(63, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(251, 33);
            this.textBox2.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(446, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "Product Number";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(59, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 25);
            this.label10.TabIndex = 1;
            this.label10.Text = "Item Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(451, 138);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(112, 47);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // removeTab
            // 
            this.removeTab.Location = new System.Drawing.Point(134, 4);
            this.removeTab.Name = "removeTab";
            this.removeTab.Size = new System.Drawing.Size(1328, 738);
            this.removeTab.TabIndex = 4;
            this.removeTab.Text = "History";
            this.removeTab.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1471, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(50, 29);
            this.File.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1471, 782);
            this.Controls.Add(this.inventoryTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load_1);
            this.inventoryTabControl.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.searchTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.inventoryTab.ResumeLayout(false);
            this.inventoryInnerTabs.ResumeLayout(false);
            this.takeInventoryTab.ResumeLayout(false);
            this.takeInventoryTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.editInventoryTab.ResumeLayout(false);
            this.editInventoryTab.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.createTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl inventoryTabControl;
        private System.Windows.Forms.TabPage searchTab;
        private System.Windows.Forms.TabPage inventoryTab;
        private System.Windows.Forms.TabPage createTab;
        private System.Windows.Forms.TabPage removeTab;
        private System.Windows.Forms.ComboBox searchCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox tInvenEquipmentCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tInvenBuildingCombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tInvenCategoryCombobox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox tInvenSerialTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox createCategoryCombobox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox tInvenRoomCombobox;
        private System.Windows.Forms.TabControl inventoryInnerTabs;
        private System.Windows.Forms.TabPage takeInventoryTab;
        private System.Windows.Forms.TabPage editInventoryTab;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox inventoryEditCombobox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox roomEditCheckbox;
        private System.Windows.Forms.CheckBox serialEditCheckbox;
        private System.Windows.Forms.CheckBox categoryEditCheckbox;
        private System.Windows.Forms.CheckBox userEditCheckbox;
        private System.Windows.Forms.CheckBox buildingEditCheckbox;
        private System.Windows.Forms.CheckBox nameEditCheckbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox categoryEditCombobox;
        private System.Windows.Forms.TextBox serialEditTextbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox userEditCombobox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox buildingEditCombobox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox nameEditCombobox;
        private System.Windows.Forms.ComboBox roomEditCombobox;
    }
}