using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    public partial class Main : Form
    {
        //Establish Oracle database connection using my username and password.
        public static OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        public int projectEditGridIndex = 0;
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
            InventoryPanelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));
            fakeSearchTextbox.ForeColor = Color.LightGray;
            quantityTextbox.Text = "1";
            label19.Text = "Pathology Informatics - Inventory";

            InventoryDataGrid.EnableHeadersVisualStyles = false;

            Inventory.InventorySearchComboFill(InventoryFilterCombo);
            InventoryFilterCombo.SelectedIndex = 3;
            fakeSearchTextbox.Text = "Search " + InventoryFilterCombo.Text;
            Inventory.DisplayInventory(InventoryDataGrid, con);
            Inventory.InventoryComboFill(ProjectCombobox, CategoryCombobox, EquipCombobox);


            EditData(IDTextbox, TermIDTextbox, ProjectCombobox, CategoryCombobox, EquipCombobox, ProductTextbox, InventoryDataGrid, con);
            barcodeTextbox.Select();
        }


        private void mainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            //Refresh displayed data when switching between tabs.
            Inventory.DisplayInventory(InventoryDataGrid, con);
        }


        //Insert rows of data into a ComboBox. Query outputting the data, column containing the data, combobox for output.
        public static void ComboAddRowData(string query, string column, ComboBox combo)
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

        //Change tab colors when switching between them.
        public void TabBtnColor(Button selectedButton, Button button1, Button button2, Button button3)
        {
            var btnColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(75)))));
            var btnColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));

            selectedButton.BackColor = btnColorOn;
            selectedButton.ForeColor = System.Drawing.Color.White;

            button1.BackColor = btnColorOff;
            button2.BackColor = btnColorOff;
            button3.BackColor = btnColorOff;
        }

        //Display history panel and hide every other panel.
        private void HistoryPanelButton_Click(object sender, EventArgs e)
        {
            historyPanel.Visible = true;
            inventoryPanel.Visible = false;
            projectsPanel.Visible = false;
            barcodePanel.Visible = false;
            insertBarcodeButton.Enabled = false;

            insertBarcodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            insertBarcodeButton.ForeColor = Color.Black;
            inventoryGridIndex = 0;
            label19.Text = "Pathology Informatics - History";

            TabBtnColor(HistoryPanelButton, InventoryPanelButton, ProjectsPanelButton, BarcodePanelButton);

            History.DisplayHistory(HistoryDataGrid);
            History.HistoryDataGridAppearance(HistoryDataGrid);
        }

        //////Mouse drag fucntions that allows the top panel and label to be moved.//////
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

        //Run a SQL query that returns a datatable type for DataGridViews.
        public static DataTable DataTableSQLQuery(string query)
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

        //Run a SQL query with no return type that can alter data in the database.
        public static void RunSQLQuery(string query)
        {
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        ////////// INVENTORY ////////////

        //Change the width of the datagridview columns
        public static void InventoryDataGridAppearance(DataGridView dGridView)
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

        /*
        public void DisplayStock(DataGridView dataGrid)
        {
            string query =  "SELECT EQUIPMENT.EQUIPMENT_NAME as Equipment, CATEGORY.CATEGORY_NAME as Category, COUNT(INVENTORY.EQUIPMENT_ID) AS Stock, PROJECT.PROJECT_NAME as Project " +
                            "FROM INVENTORY " +
                            "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                            "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                            "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                            "WHERE INVENTORY.STATUS = '1' " +
                            "GROUP BY INVENTORY.EQUIPMENT_ID, EQUIPMENT.EQUIPMENT_NAME, PROJECT.PROJECT_NAME, CATEGORY.CATEGORY_NAME " +
                            "ORDER BY STOCK DESC";

            dataGrid.DataSource = null;
            dataGrid.DataSource = DataTableSQLQuery(query);
        }

        
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

        //Allows a textbox to be automatically filled while typing
        public static void AutofillInventoryTextbox(OracleConnection connection, string query, string column, TextBox textbox)
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
        //Allows a combobox to be automatically filled while typing
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

        //Display inventory panel and hide every other panel.
        private void InventoryPanelButton_Click(object sender, EventArgs e)
        {
            inventoryPanel.Visible = true;
            projectsPanel.Visible = false;
            historyPanel.Visible = false;
            barcodePanel.Visible = false;
            insertBarcodeButton.Enabled = false;
            insertBarcodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            insertBarcodeButton.ForeColor = Color.Black;

            InventoryDataGrid.DataSource = null;
            inventoryGridIndex = 0;
            label19.Text = "Pathology Informatics - Inventory";

            TabBtnColor(InventoryPanelButton, ProjectsPanelButton, HistoryPanelButton, BarcodePanelButton);
            Inventory.DisplayInventory(InventoryDataGrid, con);
        }

        //Inventory Tab - Runs a sql query with every keystroke within searchTextbox.
        private void InventorySearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (inventoryGridIndex == 0)
            {
                inventoryGridIndex = 1;
            }

            if (String.IsNullOrEmpty(InventorySearchTextbox.Text))
            {
                Inventory.DisplayInventory(InventoryDataGrid, con);
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(InventorySearchTextbox.Text, "^[a-zA-Z0-9]"))
            {
                Inventory.InventorySearch(InventoryDataGrid, InventoryFilterCombo.Text, InventorySearchTextbox.Text, con);
            }
        }

        private void newInventoryButton_Click(object sender, EventArgs e)
        {
            inventoryNewButtonMenuStrip.Show(newInventoryButton, 0, newInventoryButton.Height);
        }

        private void manuallyInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryAddForm invenAddForm = new InventoryAddForm();
            invenAddForm.Show();
        }

        private void barcodeScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarcodePanelButton_Click(sender, e);
        }


        private void inventoryBackButton_Click(object sender, EventArgs e)
        {
            //Inventory inven = new Inventory();

            inventoryGridIndex = 0;
            Inventory.DisplayInventory(InventoryDataGrid, con);

            // inventoryBackButton.Enabled = false;
            // inventoryBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            // inventoryBackButton.ForeColor = Color.Black;
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
            //Inventory inven = new Inventory();

            Inventory.DeleteInventory(InventoryDataGrid.SelectedRows[0].Cells[0].Value.ToString(), InventoryDataGrid);
        }


        public void TextboxEnable()
        {
            ////Inventory inven = new Inventory();

            EditData(IDTextbox, TermIDTextbox, ProjectCombobox, CategoryCombobox, EquipCombobox, ProductTextbox, InventoryDataGrid, con);

            if (checkBox1.Checked == true)
            {
                IDTextbox.Enabled = true;
                CategoryCombobox.Enabled = true;
                EquipCombobox.Enabled = true;
                ProductTextbox.Enabled = true;
                TermIDTextbox.Enabled = true;
                ProjectCombobox.Enabled = true;

                updateButton.Enabled = true;
                ButtonColor(updateButton);
                deleteButton.Enabled = true;
                ButtonColor(deleteButton);
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
                ButtonColor(updateButton);
                deleteButton.Enabled = false;
                ButtonColor(deleteButton);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TextboxEnable();
        }

        private void CategoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Inventory.ReloadEquipmentData(CategoryCombobox, EquipCombobox);
            EquipCombobox.SelectedIndex = 0;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string q1 =          "SELECT COUNT(*) FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + EquipCombobox.Text + "' AND EQUIPMENT.STATUS = '1' ";
            string q2 =          "SELECT COUNT(*) FROM INVENTORY WHERE INVENTORY.TERM_ID = '" + TermIDTextbox.Text + "' AND INVENTORY.STATUS = '1' ";
            string query =       "SELECT TERM_ID FROM INVENTORY WHERE INVENTORY_ID = '" + IDTextbox.Text + "' ";

            string queryCheck1 = "SELECT PROJECT_NAME FROM PROJECT JOIN INVENTORY ON INVENTORY.PROJECT_ID = PROJECT.PROJECT_ID " +
                                 "WHERE INVENTORY.INVENTORY_ID = '" + IDTextbox.Text + "' ";
            string queryCheck2 = "SELECT EQUIPMENT_NAME FROM EQUIPMENT JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID " +
                                 "WHERE INVENTORY.INVENTORY_ID = '" + IDTextbox.Text + "' ";
            string queryCheck3 = "SELECT TERM_ID FROM INVENTORY WHERE INVENTORY.INVENTORY_ID = '" + IDTextbox.Text + "' ";

            List<string> editList = new List<string>();


            //EditChecking(q1);
            //EditTermIDCheck(q2);

            if (DataTableSQLQuery(q1).Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("Not a valid value");
            }
            else
            {
                eqCheck = true;
            }

            if ((DataTableSQLQuery(q2).Rows[0][0].ToString() == "1") && (ScalarSQLQuery(query, con) != TermIDTextbox.Text))
            {
                MessageBox.Show("TERM ID already exists.");
            }
            else
            {
                tmCheck = true;
            }

            if ((eqCheck == true) && (tmCheck == true))
            {
                eqCheck = false;
                tmCheck = false;
                UpdateList(queryCheck1, IDTextbox.Text, ProjectCombobox.Text, editList);
                UpdateList(queryCheck2, IDTextbox.Text, EquipCombobox.Text, editList);
                UpdateList(queryCheck3, IDTextbox.Text, TermIDTextbox.Text, editList);

                for(int i = 0; i < editList.Count; i++)
                {
                    Console.WriteLine(editList[i]);
                    History.HistoryInventoryUpdate(editList[i]);
                }
                Inventory.UpdateButton(EquipCombobox, ProjectCombobox, TermIDTextbox, IDTextbox, con);
            }
            
            InventoryDataGrid.DataSource = null;
            Inventory.DisplayInventory(InventoryDataGrid, con);
            checkBox1.Checked = false; 
        }

        public void UpdateList(string query, string ID, string editBoxNew, List<string> list)
        {
            if (ScalarSQLQuery(query, con) != editBoxNew)
            {
                if (String.IsNullOrEmpty(ScalarSQLQuery(query, con)))
                {
                    list.Add("[Inventory ID "+ ID +"]: " + editBoxNew + " was added.");
                }
                else
                {
                    list.Add("[Inventory ID " + ID + "]: " + ScalarSQLQuery(query, con) + " changed to " + editBoxNew + ".");
                }
            }
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
        private void InventoryDataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.InventoryDataGrid.ClearSelection();
                    this.InventoryDataGrid.Rows[rowSelected].Selected = true;

                    EditData(IDTextbox, TermIDTextbox, ProjectCombobox, CategoryCombobox, EquipCombobox, ProductTextbox, InventoryDataGrid, con);

                    checkBox1.Checked = false;
                }
            }
        }

        ////////// PROJECTS ////////////

        private void ProjectsPanelButton_Click(object sender, EventArgs e)
        {

            ///string pj = "SELECT * FROM PROJECT WHERE PROJECT_NAME != 'Unassigned' AND PROJECT.STATUS = '1' ";
            string pj2 = "SELECT * FROM PROJECT WHERE PROJECT.STATUS = '1' ORDER BY PROJECT_ID";

            //projectsEditPanel.Visible = true;
            projectsPanel.Visible = true;
            TabBtnColor(ProjectsPanelButton, InventoryPanelButton, HistoryPanelButton, BarcodePanelButton);
            inventoryGridIndex = 0;

            inventoryPanel.Visible = false;
            historyPanel.Visible = false;
            barcodePanel.Visible = false;

            insertBarcodeButton.Enabled = false;
            insertBarcodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            insertBarcodeButton.ForeColor = Color.Black;

            //Projects.DisplayProjects(projectsDataGrid);
            //projectBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            // projectBackButton.ForeColor = Color.Black;
            //projectBackButton.Enabled = false;
            projectGridIndex = 0;
            label19.Text = "Pathology Informatics - Projects";

            ComboAddRowData(pj2, "PROJECT_NAME", projectComboList);

            projectComboList.SelectedIndex = 0;
        }


        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectNewForm pNewForm = new ProjectNewForm();
            pNewForm.Show();
        }


        private void newEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EquipmentAddForm equipNewForm = new EquipmentAddForm();
            equipNewForm.Show();
        }


        private void projectButton_Click(object sender, EventArgs e)
        {
            projectContextMenuStrip.Show(newProjectButton, 0, newProjectButton.Height);
        }



        ////////// BARCODE ////////////

        private void BarcodePanelButton_Click(object sender, EventArgs e)
        {
            //Barcode barcode = new Barcode();

            inventoryPanel.Visible = false;
            projectsPanel.Visible = false;
            historyPanel.Visible = false;
            barcodePanel.Visible = true;

            insertBarcodeButton.Enabled = false;
            insertBarcodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            insertBarcodeButton.ForeColor = Color.Black;

            Barcode.DisplayEquipment(barcodeEquipment);
            barcodeGrid.Rows.Clear();
            barcodeTextbox.Focus();
            barcodeLabel.Visible = true;

            TabBtnColor(BarcodePanelButton, InventoryPanelButton, ProjectsPanelButton, HistoryPanelButton);
            inventoryGridIndex = 0;
            label19.Text = "Pathology Informatics - Barcode Scan";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Barcode barcode = new Barcode();

            barcodeLabel.Visible = false;
            timer1.Enabled = false;
            barcodeTextbox.Focus();

            Barcode.BarcodeTimer(quantityTextbox.Text, barcodeTextbox.Text, barcodeTextbox, insertBarcodeButton, barcodeGrid, con);
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
            Barcode.BarcodeInsert(insertBarcodeButton, barcodeGrid, con);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Inventory.DeleteInventory(InventoryDataGrid.SelectedRows[0].Cells[0].Value.ToString(), InventoryDataGrid);
            checkBox1.Checked = false;
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Inventory.DeleteInventory(InventoryDataGrid.SelectedRows[0].Cells[0].Value.ToString(), InventoryDataGrid);
            checkBox1.Checked = false;
        }

        private void newEquipment_Click(object sender, EventArgs e)
        {
            EquipmentAddForm Equip = new EquipmentAddForm();

            Equip.Show();
        }

        private void projectsDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Projects projects = new Projects();

            if (projectGridIndex == 0)
            {
                projectGridIndex = 1;

                //projectsLabel.Text = projectsDataGrid.SelectedRows[0].Cells[0].Value.ToString();
                Projects.DisplayProjectData(projectsDataGrid.SelectedRows[0].Cells[0].Value.ToString(), projectsDataGrid);

                //projectBackButton.Enabled = true;
                //projectBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
                //projectBackButton.ForeColor = Color.White;
            }
        }

        private void projectBackButton_Click(object sender, EventArgs e)
        {

            projectGridIndex = 0;
            Projects.DisplayProjects(projectsDataGrid);
            //projectBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
            //projectBackButton.ForeColor = Color.Black;
            // projectBackButton.Enabled = false;
            //projectsLabel.Text = "Select A Project";
        }

        private void editProjectButton_Click(object sender, EventArgs e)
        {
            string query = "UPDATE PROJECT " +
                            "SET PROJECT.PROJECT_DESCRIPTION = '" + projectRichTextbox.Text + "', " +
                            "PROJECT.TICKET_NO = '" + ticketTextbox.Text + "', " +
                            "PROJECT.PROJECT_NAME = '" + projectNameTextbox.Text + "' " +
                            "WHERE PROJECT.PROJECT_NAME = '" + projectComboList.Text + "' ";

            if (projectComboList.SelectedIndex == 0)
            {
                MessageBox.Show("Cannot edit this project.");
            }
            else
            {
                List<string> editProjectList = new List<string>();

                string queryCheck1 = "SELECT PROJECT_NAME FROM PROJECT WHERE PROJECT_NAME = '" + projectComboList.Text + "' ";
                string queryCheck2 = "SELECT TICKET_NO FROM PROJECT WHERE PROJECT_NAME = '" + projectComboList.Text + "' ";
                string queryCheck3 = "SELECT PROJECT_DESCRIPTION FROM PROJECT WHERE PROJECT_NAME = '" + projectComboList.Text + "' ";

                UpdateProjectList(queryCheck1, projectComboList.Text, projectComboList.Text, editProjectList);
                UpdateProjectList(queryCheck2, projectComboList.Text, ticketTextbox.Text, editProjectList);
                UpdateProjectList(queryCheck3, projectComboList.Text, projectRichTextbox.Text, editProjectList);

                for (int i = 0; i < editProjectList.Count; i++)
                {
                    //Console.WriteLine(editProjectList[i]);
                    History.HistoryProjectUpdate(editProjectList[i]);
                }

                RunSQLQuery(query);
                MessageBox.Show(projectComboList.Text + " has been edited.");
                projectComboList.SelectedIndex = 0;
                Projects.DisplayProjectData(projectComboList.Text, projectsDataGrid);
            }
        }
        public void UpdateProjectList(string query, string project, string editBoxNew, List<string> list)
        {
            if (ScalarSQLQuery(query, con) != editBoxNew)
            {
                list.Add("[Project " + project + "]: " + ScalarSQLQuery(query, con) + " changed to " + editBoxNew + ".");
            }
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            ProjectNewForm newProject = new ProjectNewForm();
            newProject.Show();
        }

        private void deleteProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Projects.DeleteProject(projectComboList, projectsDataGrid);
        }


        private void InventoryDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditData(IDTextbox, TermIDTextbox, ProjectCombobox, CategoryCombobox, EquipCombobox, ProductTextbox, InventoryDataGrid, con);
            checkBox1.Checked = false;
        }

        private void projectsDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string projectDesc = projectRichTextbox.Text;
            string query = "SELECT PROJECT.PROJECT_DESCRIPTION FROM PROJECT WHERE PROJECT.PROJECT_NAME = '" + projectsDataGrid.SelectedRows[0].Cells[0].Value.ToString() + "' ";

            OracleCommand cmd = new OracleCommand(query, con);
            try
            {
                con.Open();

                using (OracleDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        projectRichTextbox.Text = (read["PROJECT_DESCRIPTION"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        public void EditData(TextBox IDText, TextBox TermID, ComboBox Project, ComboBox Category, ComboBox Equipment, TextBox Product, DataGridView dGriView, OracleConnection connection)
        {
            IDText.Text = dGriView.SelectedRows[0].Cells[0].Value.ToString();

            string query = "SELECT TERM_ID FROM INVENTORY WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";
            string pjName = "SELECT PROJECT_NAME FROM PROJECT JOIN INVENTORY ON INVENTORY.PROJECT_ID = PROJECT.PROJECT_ID WHERE INVENTORY_ID = '" + IDText.Text + "' ";
            string catName = "SELECT CATEGORY_NAME FROM CATEGORY JOIN EQUIPMENT ON EQUIPMENT.CATEGORY_ID = CATEGORY.CATEGORY_ID JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";
            string eqName = "SELECT EQUIPMENT_NAME FROM EQUIPMENT JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";
            string productNo = "SELECT PRODUCT_NO FROM EQUIPMENT JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";

            Project.Text = ScalarSQLQuery(pjName, connection);
            Category.Text = ScalarSQLQuery(catName, connection);
            Equipment.Text = ScalarSQLQuery(eqName, connection);
            Product.Text = ScalarSQLQuery(productNo, connection);


            OracleCommand cmd = new OracleCommand(query, connection);
            connection.Open();
            using (OracleDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    TermID.Text = (read["TERM_ID"].ToString());
                }
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EquipmentEditForm form = new EquipmentEditForm();
            if (form.Visible == false)
            {
                form.Show();
            }
            else
            {
                form.Hide();
            }
        }

        private void InventoryFilterCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fakeSearchTextbox.Text = "Search " + InventoryFilterCombo.Text;
        }

        private void EquipCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                string productNo = "SELECT PRODUCT_NO FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + EquipCombobox.Text + "' ";
                ProductTextbox.Text = ScalarSQLQuery(productNo, con);
            }
        }

        public static string ScalarSQLQuery(string query, OracleConnection connection)
        {
            connection.Open();
            OracleCommand cmd = new OracleCommand(query, connection);
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            String scalar = cmd.ExecuteScalar().ToString();
            connection.Close();
            return scalar;
        }

        private void projectComboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT PROJECT.PROJECT_DESCRIPTION FROM PROJECT WHERE PROJECT.PROJECT_NAME = '"+ projectComboList.Text+ "' AND PROJECT.STATUS = '1' ";
            string query2 = "SELECT PROJECT.TICKET_NO FROM PROJECT WHERE PROJECT.PROJECT_NAME = '" + projectComboList.Text + "' AND PROJECT.STATUS = '1' ";

            if(projectComboList.SelectedIndex == 0)
            {
                projectRichTextbox.ReadOnly = true;
                projectRichTextbox.BackColor = Color.LightGray;
                ticketTextbox.ReadOnly = true;
                projectNameTextbox.ReadOnly = true;
                deleteProjectButton.Enabled = false;
            }
            else
            {
                projectRichTextbox.ReadOnly = false;
                projectRichTextbox.BackColor = Color.White;
                ticketTextbox.ReadOnly = false;
                projectNameTextbox.ReadOnly = false;
                deleteProjectButton.Enabled = true;
            }
            Projects.DisplayProjectData(projectComboList.Text, projectsDataGrid);
            projectRichTextbox.Text = ScalarSQLQuery(query, con);
            ticketTextbox.Text = ScalarSQLQuery(query2, con);
            projectNameTextbox.Text = projectComboList.Text;

            Load_MenuToolStripMenuItem();
            editProjectButton.Enabled = false;
            //deleteProjectButton.Enabled = false;
            ButtonColor(editProjectButton);
            ButtonColor(deleteProjectButton);
        }

        private void projectsDataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            ContextMenu projectContextMenuStrip = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.InventoryDataGrid.ClearSelection();
                    this.InventoryDataGrid.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void Load_MenuToolStripMenuItem()
        {
            ToolStripDropDownItem item = this.projectContextMenuStrip.Items[1] as ToolStripDropDownItem;
            item.DropDownItems.Clear();
            foreach (String items in Get_Menu_Items())
            {
                item.DropDownItems.Add(items);
            }
            item.DropDownItemClicked -= new ToolStripItemClickedEventHandler(Item_DropDownItemClicked);
            item.DropDownItemClicked += new ToolStripItemClickedEventHandler(Item_DropDownItemClicked);
        }

        private void Item_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            projectContextMenuStrip.Hide();
            string msg = null;
            msg = String.Format(e.ClickedItem.Text);

            string query = "UPDATE INVENTORY " +
                            "SET INVENTORY.PROJECT_ID = (SELECT PROJECT.PROJECT_ID FROM PROJECT WHERE PROJECT.PROJECT_NAME = '" + e.ClickedItem.Text + "' AND PROJECT.STATUS = '1') " +
                            "WHERE INVENTORY.INVENTORY_ID = '" + projectsDataGrid.SelectedRows[0].Cells[0].Value.ToString() + "' ";

            var confirmResult = MessageBox.Show("Are you sure you want to move this record to '" + e.ClickedItem.Text + "'?",
                         "Confirm Move!",
                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                RunSQLQuery(query);
                projectsDataGrid.DataSource = null;
                Projects.DisplayProjectData(projectComboList.Text, projectsDataGrid);
            }
            if (confirmResult == DialogResult.No)
            {
                Console.WriteLine(e.ClickedItem.Text);
                Console.WriteLine(projectsDataGrid.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
       

        private List<String> Get_Menu_Items()
        {
            List<String> menu_items = new List<String>();
            string query = "SELECT PROJECT.PROJECT_NAME FROM PROJECT " +
                "WHERE PROJECT.STATUS = 1 AND PROJECT.PROJECT_NAME != '"+ projectComboList.Text + "' ";

            menu_items.Clear();
            foreach (DataRow row in DataTableSQLQuery(query).Rows)
            {
                menu_items.Add(row["PROJECT_NAME"].ToString());
            }
            return menu_items;
        }

        private void projectRichTextbox_TextChanged(object sender, EventArgs e)
        {
            editProjectButton.Enabled = true;
           // deleteProjectButton.Enabled = false;
            ButtonColor(editProjectButton);
        }

        private void ticketTextbox_TextChanged(object sender, EventArgs e)
        {
            editProjectButton.Enabled = true;
            //deleteProjectButton.Enabled = false;
            ButtonColor(editProjectButton);
        }

        public void ButtonColor(Button button)
        {
            if(button.Enabled == true)
            {
                button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
                button.ForeColor = Color.White;
            }
            else
            {
                button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
                button.ForeColor = Color.Black;
            }
        }

        private void deleteProjectButton_Click(object sender, EventArgs e)
        {
            Projects.DeleteProject(projectComboList, projectsDataGrid);
            Projects.DisplayProjectData(projectComboList.Text, projectsDataGrid);
            History.HistoryProjectDelete(projectComboList.Text + " deleted from the projects list." );
            RefreshProjectCombobox();
        }

        public void RefreshProjectCombobox()
        {
            string pj = "SELECT * FROM PROJECT WHERE PROJECT.STATUS = '1' ORDER BY PROJECT_ID";

            projectComboList.Items.Clear();
            ComboAddRowData(pj, "PROJECT_NAME", projectComboList);
            projectComboList.SelectedIndex = 0;
        }

        private void projectNameTextbox_TextChanged(object sender, EventArgs e)
        {
            //deleteProjectButton.Enabled = false;
            editProjectButton.Enabled = true;
            ButtonColor(editProjectButton);
        }

    }
}   