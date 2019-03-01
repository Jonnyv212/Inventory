using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Inventory
{
    public partial class Main : Form
    {
        //Establish Oracle database connection using my username and password.
        public OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        public int projectGridIndex = 0;
        public int inventoryGridIndex = 0;
        public int equipmentGridIndex = 0;

        bool eqCheck = false;
        bool tmCheck = false;

        private bool mouseDown;
        private Point lastLocation;

        // GET; SET; value
        private static string rowID;
        private static string pjName;
        private static string pjInven;

        public string GetRowID()
        {
            return rowID;
        }
        public void SetRowID(string ID)
        {
            rowID = ID;
        }

        public string GetRowPjName()
        {
            return pjName;
        }
        public void SetRowPjName(string name)
        {
            pjName = name;
        }

        public string GetPjInvenID()
        {
            return pjInven;
        }
        public void SetPjInvenID(string InvenID)
        {
            pjInven = InvenID;
        }

        public Main()
        {
            InitializeComponent();
        }

        ////////// MAIN FORM ////////////
        
        //Loads these functions on main form load
        private void Main_Load_1(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();

            quantityTextbox.Text = "1";
            barcodeTextbox.Select();

            InventoryDataGrid.EnableHeadersVisualStyles = false;


            inven.InventorySearchComboFill(InventoryFilterCombo);
            inven.DisplayInventory(InventoryDataGrid, con);

            InventoryPanelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));

            InventoryFilterCombo.SelectedIndex = 3;
            inven.EditData(IDTextbox, TermIDTextbox, ProjectCombobox, CategoryCombobox, EquipCombobox, ProductTextbox, InventoryDataGrid, con);
            inven.InventoryComboboFill(ProjectCombobox, CategoryCombobox, EquipCombobox);

            fakeSearchTextbox.ForeColor = Color.LightGray;
            fakeSearchTextbox.Text = "Search " + InventoryFilterCombo.Text;
        }


        //Refresh displayed data when switching between tabs
        private void mainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            Inventory inven = new Inventory();
            inven.DisplayInventory(InventoryDataGrid, con);
        }

        //Insert rows of data into a ComboBox. Query of the data, column containing the data, combobox for output.
        public void ComboAddRowData(string query, string column, ComboBox combo)
        {
            combo.Items.Clear();
            DataTable dtEI = new DataTable();
            OracleDataAdapter daEI = new OracleDataAdapter(query, con);
            daEI.Fill(dtEI);
            foreach (DataRow ROW in dtEI.Rows)
            {
                combo.Items.Add(ROW[column].ToString());
            }
        }

        public void TabBtnColor(Button selectedButton, Button button1, Button button2, Button button3)
        {
            var btnColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));
            var btnColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            //var btnFontOff = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(2)))));
            
            selectedButton.BackColor = btnColorOn;
            selectedButton.ForeColor = System.Drawing.Color.White;

            button1.BackColor = btnColorOff;
           // button1.ForeColor = btnFontOff;

            button2.BackColor = btnColorOff;
            //button2.ForeColor = btnFontOff;

            button3.BackColor = btnColorOff;
        }

        private void HistoryPanelButton_Click(object sender, EventArgs e)
        {
            historyPanel.Visible = true;
            TabBtnColor(HistoryPanelButton, InventoryPanelButton, ProjectsPanelButton, BarcodePanelButton);
            inventoryGridIndex = 0;
            inventoryBackButton.Enabled = false;
            inventoryBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            inventoryBackButton.ForeColor = Color.Black;
            //InventorySearchTextbox.Text = "";

            inventoryPanel.Visible = false;
            projectsPanel.Visible = false;
            barcodePanel.Visible = false;
        }


        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }


        private void label19_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label19_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label19_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }



        private void mainClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DataTable DataTableSQLQuery(string query)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            con.Close();
            
            return dta;
        }

        public void RunSQLQuery(string query)
        {
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            con.Close();
        }
        ////////// INVENTORY ////////////

        public void InventoryDataGridAppearance(DataGridView dGridView)
        {
            DataGridViewColumn column1 = dGridView.Columns[0];
            column1.Width = 50;

            DataGridViewColumn column2 = dGridView.Columns[1];
            column2.Width = 200;

            DataGridViewColumn column3 = dGridView.Columns[2];
            column3.Width = 80;

            DataGridViewColumn column4 = dGridView.Columns[3];
            column4.Width = 100;

            DataGridViewColumn column5 = dGridView.Columns[4];
            column5.Width = 80;


        }

        public void EditChecking(string query)
        {
            con.Open();
            //CHECK DATABASE TO SEE IF EQUIPMENT EXISTS
            OracleCommand editCheck = con.CreateCommand();
            editCheck.CommandType = CommandType.Text;
            editCheck.CommandText = query;
            editCheck.ExecuteNonQuery(); 

            OracleDataAdapter eSda = new OracleDataAdapter(editCheck);
            DataTable eDt = new DataTable();
            eSda.Fill(eDt);

            if (eDt.Rows[0][0].ToString() == "0") 
            {
                MessageBox.Show("Not a valid value");
            }
            else
            {
                eqCheck = true;
            }
            con.Close();
        }

        public void EditTermIDCheck(string query)
        {
            con.Open();
            //CHECK DATABASE TO SEE IF EQUIPMENT EXISTS
            OracleCommand editCheck = con.CreateCommand();
            editCheck.CommandType = CommandType.Text;
            editCheck.CommandText = query;
            editCheck.ExecuteNonQuery(); //Execute command

            OracleDataAdapter eSda = new OracleDataAdapter(editCheck);
            DataTable eDt = new DataTable();
            eSda.Fill(eDt);
            if (eDt.Rows[0][0].ToString() == "1") 
            {
                MessageBox.Show("TERM ID already exists in record");
            }
            else
            {
                tmCheck = true;
            }
            con.Close();
        }

        public void DisplayStock(DataGridView dataGrid)
        {
            string query =  "SELECT EQUIPMENT.EQUIPMENT_NAME as Equipment, CATEGORY.CATEGORY_NAME as Category, COUNT(INVENTORY.EQUIPMENT_ID) AS Stock, PROJECT.PROJECT_NAME as Project " +
                            "FROM INVENTORY " +
                            "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                            "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                            "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                            "WHERE INVENTORY.STATUS = '1' " +
                            "GROUP BY INVENTORY.EQUIPMENT_ID, EQUIPMENT.EQUIPMENT_NAME, PROJECT.PROJECT_NAME, CATEGORY.CATEGORY_NAME " +
                            "ORDER BY STOCK DESC";

            dataGrid.DataSource = null;
            dataGrid.DataSource = DataTableSQLQuery(query);
        }

        /*
          public void DataGridInventoryInformation(DataGridView dGridView, RichTextBox richTextBox)
          {
              string inventory = "SELECT * FROM INVENTORY " +
                  "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                  "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                  "WHERE INVENTORY.INVENTORY_ID = '" + dGridView.SelectedRows[0].Cells[0].Value.ToString() + "' ";

              con.Open();

              OracleCommand cmd = new OracleCommand(inventory, con);

              //String InventoryID = cmd.ExecuteScalar().ToString();


              try
              {
                  OracleDataReader dr = cmd.ExecuteReader();
                  // OracleDataReader dr2 = cmd1.ExecuteReader();

                  while (dr.Read())
                  {
                      richTextBox.Text = ("Description for: " + dr["EQUIPMENT_NAME"].ToString() + "\n\n\n" + dr["PROJECT_NAME"].ToString() + "\n\n\n");
                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
              con.Close();
          }
          */

          public void AutofillInventoryTextbox(OracleConnection connection, string query, string column, TextBox textbox)
          {
                  con.Open();
                  OracleDataAdapter sda = new OracleDataAdapter(query, con);
                  AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                  DataTable dt = new DataTable();

                  sda.Fill(dt);

                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      string name = dt.Rows[i][column].ToString();
                      col.Add(name);
                  }
                  textbox.AutoCompleteCustomSource = col;
                  con.Close();
          }

          public void AutofillInventoryCombobox(OracleConnection connection, string query, string column, ComboBox combobox)
          {
              con.Open();
              OracleDataAdapter sda = new OracleDataAdapter(query, con);
              AutoCompleteStringCollection col = new AutoCompleteStringCollection();
              DataTable dt = new DataTable();

              sda.Fill(dt);

              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  string name = dt.Rows[i][column].ToString();
                  col.Add(name);
              }
              combobox.AutoCompleteCustomSource = col;
              con.Close();
          }
          

        private void InventoryPanelButton_Click(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();

            inventoryGridIndex = 0;

            inventoryPanel.Visible = true;
            projectsPanel.Visible = false;
            historyPanel.Visible = false;
            barcodePanel.Visible = false;

            TabBtnColor(InventoryPanelButton, ProjectsPanelButton, HistoryPanelButton, BarcodePanelButton);

            inventoryBackButton.Enabled = false;
            inventoryBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            inventoryBackButton.ForeColor = Color.Black;

            inven.InventoryComboboFill(pNameCombobox, CategoryCombobox, EquipCombobox);
            InventoryDataGrid.DataSource = null;
            inven.DisplayInventory(InventoryDataGrid, con);
        }

        //Inventory Tab - Runs cmd.CommandText query with every keystroke within searchTextbox.
        private void InventorySearchTextbox_TextChanged(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();

            if (inventoryGridIndex == 0 )
            {
                inventoryGridIndex = 1;
                inventoryBackButton.Enabled = true;
                inventoryBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
                inventoryBackButton.ForeColor = Color.White;
            }

            if (String.IsNullOrEmpty(InventorySearchTextbox.Text))
            {
                inven.DisplayInventory(InventoryDataGrid, con);
                inventoryBackButton.Enabled = false;
            }
            else
            {
                inven.InventorySearch(InventoryDataGrid, InventoryFilterCombo.Text, InventorySearchTextbox.Text, con);
            }
        }

        private void newInventoryButton_Click(object sender, EventArgs e)
        {
            inventoryNewButtonMenuStrip.Show(newInventoryButton, 0, newInventoryButton.Height);
        }

        private void manuallyInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryAddForm iAddForm = new InventoryAddForm();
            iAddForm.Show();
        }

        private void barcodeScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarcodePanelButton_Click(sender, e);
        }


        private void inventoryBackButton_Click(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();

            inventoryGridIndex = 0;
            inven.DisplayInventory(InventoryDataGrid, con);

            inventoryBackButton.Enabled = false;
            inventoryBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            inventoryBackButton.ForeColor = Color.Black;
        }

        /*
        public void DisplayCategories(DataGridView eDataGrid)
        {
            con.Open();
            eDataGrid.DataSource = null;
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            //INDIVIDUAL EQUIPMENT DISPLAY
            cmd.CommandText = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            eDataGrid.DataSource = dta;

            con.Close();
        } */


        /*
    public void DisplayEquipment(string catName, DataGridView eDataGrid)
    {
        con.Open();
        eDataGrid.DataSource = null;
        OracleCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;

        //INDIVIDUAL EQUIPMENT DISPLAY
        cmd.CommandText = "SELECT EQUIPMENT.EQUIPMENT_NAME as Equipment, EQUIPMENT.PRODUCT_NO as Product_No " +
            "FROM EQUIPMENT " +
            "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
            "WHERE CATEGORY.CATEGORY_NAME = '"+catName+"' " +
            "ORDER BY EQUIPMENT_NAME DESC" ;
        cmd.ExecuteNonQuery();
        DataTable dta = new DataTable();
        OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
        dataadp.Fill(dta);
        eDataGrid.DataSource = dta;

        con.Close();
    }
    */


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();

            inven.DeleteInventory(InventoryDataGrid.SelectedRows[0].Cells[0].Value.ToString(), InventoryDataGrid);
        }


        public void TextboxEnable()
        {
            Inventory inven = new Inventory();

            inven.EditData(IDTextbox, TermIDTextbox, ProjectCombobox, CategoryCombobox, EquipCombobox, ProductTextbox, InventoryDataGrid, con);

            if (checkBox1.Checked == true)
            {
                IDTextbox.Enabled = true;
                CategoryCombobox.Enabled = true;
                EquipCombobox.Enabled = true;
                ProductTextbox.Enabled = true;
                TermIDTextbox.Enabled = true;
                ProjectCombobox.Enabled = true;
                updateButton.Enabled = true;
                updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
                updateButton.ForeColor = Color.White;
                deleteButton.Enabled = true;
                deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
                deleteButton.ForeColor = Color.White;
            }
            else
            {
                IDTextbox.Enabled = false;
                CategoryCombobox.Enabled = false;
                EquipCombobox.Enabled = false;
                ProductTextbox.Enabled = false;
                TermIDTextbox.Enabled = false;
                ProjectCombobox.Enabled = false;
                updateButton.Enabled = false;
                updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
                updateButton.ForeColor = Color.Black;
                deleteButton.Enabled = false;
                deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
                deleteButton.ForeColor = Color.Black;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TextboxEnable();
        }

        private void CategoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();

            inven.ReloadEquipmentData(CategoryCombobox, EquipCombobox);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();

            string q1 = "SELECT COUNT(*) FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + EquipCombobox.Text + "' ";
            string q2 = "SELECT COUNT(*) FROM INVENTORY WHERE INVENTORY.TERM_ID = '" + TermIDTextbox.Text + "' AND INVENTORY.STATUS = '1' ";

            EditChecking(q1);
            EditTermIDCheck(q2);

            if (eqCheck == true & tmCheck == true)
            {
                inven.UpdateButton(EquipCombobox, CategoryCombobox, ProjectCombobox, TermIDTextbox, IDTextbox, con);

                eqCheck = false;
                tmCheck = false;
            }
            InventoryDataGrid.DataSource = null;
            inven.DisplayInventory(InventoryDataGrid, con);
            checkBox1.Checked = false;
        }

        private void fakeSearchTextbox_Click(object sender, EventArgs e)
        {
            fakeSearchTextbox.Visible = false;
            InventorySearchTextbox.Focus();
        }

        private void InventorySearchTextbox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(InventorySearchTextbox.Text))
            {
                fakeSearchTextbox.Visible = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
        }

        private void InventoryDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory inven = new Inventory();
            inven.EditData(IDTextbox, TermIDTextbox, ProjectCombobox, CategoryCombobox, EquipCombobox, ProductTextbox, InventoryDataGrid, con);

            checkBox1.Checked = false;
        }

        private void InventoryDataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Inventory inven = new Inventory();
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.InventoryDataGrid.ClearSelection();
                    this.InventoryDataGrid.Rows[rowSelected].Selected = true;

                    inven.EditData(IDTextbox, TermIDTextbox, ProjectCombobox, CategoryCombobox, EquipCombobox, ProductTextbox, InventoryDataGrid, con);

                    checkBox1.Checked = false;
                }
            }
        }

        ////////// PROJECTS ////////////



        private void ProjectsPanelButton_Click(object sender, EventArgs e)
        {
            Projects projects = new Projects();

            string pj = "SELECT * FROM PROJECT WHERE PROJECT_NAME != 'Unassigned' ";

            projectsPanel.Visible = true;
            TabBtnColor(ProjectsPanelButton, InventoryPanelButton, HistoryPanelButton, BarcodePanelButton);
            inventoryGridIndex = 0;
            inventoryBackButton.Enabled = false;
            inventoryBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            inventoryBackButton.ForeColor = Color.Black;
            //InventorySearchTextbox.Text = "";

            inventoryPanel.Visible = false;
            historyPanel.Visible = false;
            barcodePanel.Visible = false;

            projects.DisplayRightProjectGrid(pNameCombobox, ProjectsRightDataGrid);
            projects.DisplayProjects(pNameCombobox, ProjectsLeftDataGrid);
            projects.LoadProjectEdit(pNameCombobox, ticketEditNoTextbox, descEditTextbox, con);
            projectBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            projectBackButton.ForeColor = Color.Black;

            ComboAddRowData(pj, "PROJECT_NAME", pNameCombobox);
            pNameCombobox.SelectedIndex = 1;

            if(ProjectsRightDataGrid.Rows.Count == 0)
            {
                Console.WriteLine("Right is empty");
            }
        }


        private void projectBackButton_Click(object sender, EventArgs e)
        {
            Projects projects = new Projects();

            if (projectGridIndex == 1)
            {
                projectBackButton.Enabled = false;
                // projectBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
                // projectBackButton.ForeColor = Color.Black;
                projectBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
                projectBackButton.ForeColor = Color.Black;
                projectGridIndex = 0;
                projects.DisplayProjects(pNameCombobox, ProjectsLeftDataGrid);
                Console.WriteLine("Test 1");
            }
            else if (projectGridIndex == 2)
            {
                projects.DisplayProjectStock(ProjectsLeftDataGrid.SelectedRows[0].Cells[0].Value.ToString(), ProjectsLeftDataGrid);
                Console.WriteLine("Test 2");
                projectGridIndex = 1;
            }
            rightButton.Enabled = false;
            leftButton.Enabled = false;
            //projects.DisplayRightProjectGrid(pNameCombobox, ProjectsRightDataGrid);
            //projects.DisplayProjects(pNameCombobox, ProjectsLeftDataGrid);
            //projects.LoadProjectEdit(pNameCombobox, ticketEditNoTextbox, descEditTextbox, con);
        }


        private void ProjectsLeftDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Projects projects = new Projects();

            if (projectGridIndex == 0)
            {
                rightButton.Enabled = false;
                projectGridIndex = 1;
                projects.DisplayProjectStock(ProjectsLeftDataGrid.SelectedRows[0].Cells[0].Value.ToString(), ProjectsLeftDataGrid);
                projectBackButton.Enabled = true;
                projectBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
                projectBackButton.ForeColor = Color.White;
            }
            else if (projectGridIndex == 1)
            {
                projectGridIndex = 2;
                projects.DisplayProjectData(ProjectsLeftDataGrid.SelectedRows[0].Cells[0].Value.ToString(), ProjectsLeftDataGrid.SelectedRows[0].Cells[1].Value.ToString(), ProjectsLeftDataGrid);
                rightButton.Enabled = true;
                leftButton.Enabled = true;

            }
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            ProjectNewForm newProject = new ProjectNewForm();
            newProject.Show();
        }


        private void newProject_Click(object sender, EventArgs e)
        {
            ProjectNewForm newProject = new ProjectNewForm();

            newProject.Show();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectNewForm pNewForm = new ProjectNewForm();
            pNewForm.Show();
        }


        private void newEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EquipmentNewForm equipNewForm = new EquipmentNewForm();
            equipNewForm.Show();
        }


        private void projectButton_Click(object sender, EventArgs e)
        {
            projectContextMenuStrip.Show(projectButton, 0, projectButton.Height);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            Projects projects = new Projects();
            projects.MoveToRight(pNameCombobox, leftButton, ProjectsRightDataGrid, ProjectsLeftDataGrid, con);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            Projects projects = new Projects();
            projects.MoveToLeft(leftButton, ProjectsLeftDataGrid, ProjectsRightDataGrid, con);
        }

        private void ProjectsRightDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (ProjectsRightDataGrid.Rows.Count > 0 & projectGridIndex == 2)
            {
                leftButton.Enabled = true;
            }
        }

        private void pNameCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Projects projects = new Projects();

            projects.DisplayRightProjectGrid(pNameCombobox, ProjectsRightDataGrid);
            projects.DisplayProjects(pNameCombobox, ProjectsLeftDataGrid);
            projects.LoadProjectEdit(pNameCombobox, ticketEditNoTextbox, descEditTextbox, con);
            projectGridIndex = 0;
            projectBackButton.Enabled = false;
            rightButton.Enabled = false;

            if (ProjectsRightDataGrid.Rows.Count == 0)
            {
                Console.WriteLine("Right is empty");
                leftButton.Enabled = false;
            }
        }

        private void ProjectsLeftDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProjectsLeftDataGrid.Rows.Count > 0 & projectGridIndex == 2)
            {
                rightButton.Enabled = true;
            }
        }

        ////////// BARCODE ////////////

        private void BarcodePanelButton_Click(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();

            inventoryPanel.Visible = false;
            projectsPanel.Visible = false;
            historyPanel.Visible = false;

            barcodePanel.Visible = true;

            barcode.DisplayEquipment(barcodeEquipment);
            barcodeGrid.Rows.Clear();
            barcodeTextbox.Focus();
            barcodeLabel.Visible = true;

            TabBtnColor(BarcodePanelButton, InventoryPanelButton, ProjectsPanelButton, HistoryPanelButton);
            inventoryGridIndex = 0;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();

            barcodeLabel.Visible = false;
            timer1.Enabled = false;
            barcodeTextbox.Focus();

            barcode.BarcodeTimer(quantityTextbox.Text, barcodeTextbox.Text, barcodeTextbox, insertBarcodeButton, barcodeGrid, con);
        }

        /*
        private void quantityTextbox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(quantityTextbox.Text, "[^1-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                quantityTextbox.Text = "1";
            }
            else
            {
                if (String.IsNullOrEmpty(quantityTextbox.Text))
                {
                    barcodeTextbox.Enabled = false;
                }
                else
                {
                    int quan = int.Parse(quantityTextbox.Text);
                    if (quan > 0)
                    {
                        barcodeTextbox.Enabled = true;
                    }
                    else
                    {
                        barcodeTextbox.Enabled = false;
                    }
                }
            }
            barcodeTextbox.Focus();
        }
        */

        private void barcodeTextbox_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void barcodePanel_MouseClick(object sender, MouseEventArgs e)
        {
            barcodeTextbox.Focus();
        }

        private void barcodeGrid_Click(object sender, EventArgs e)
        {
            barcodeTextbox.Focus();
        }

        private void barcodeEquipment_Click(object sender, EventArgs e)
        {
            barcodeTextbox.Focus();
        }

        private void insertBarcodeButton_Click(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();
            barcode.BarcodeInsert(insertBarcodeButton, barcodeGrid, con);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();

            inven.DeleteInventory(InventoryDataGrid.SelectedRows[0].Cells[0].Value.ToString(), InventoryDataGrid);
            checkBox1.Checked = false;
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();

            inven.DeleteInventory(InventoryDataGrid.SelectedRows[0].Cells[0].Value.ToString(), InventoryDataGrid);
            checkBox1.Checked = false;
        }

        private void newEquipment_Click(object sender, EventArgs e)
        {
            EquipmentNewForm Equip = new EquipmentNewForm();

            Equip.Show();
        }
    }
}   