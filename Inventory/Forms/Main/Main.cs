using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Inventory
{
    public partial class Main : Form
    {
        //Establish Oracle database connection using my username and password.
        public OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");

        public Main()
        {
            InitializeComponent();

            inventoryInnerTabs.Appearance = TabAppearance.Buttons;
        }

        //Loads these functions on main form load
        private void Main_Load_1(object sender, EventArgs e)
        {
            InventorySearch invenSearch = new InventorySearch();
            CreateEquipment createEquip = new CreateEquipment();
            InventoryEdit invenEdit = new InventoryEdit();
            InventoryDelete invenDelete = new InventoryDelete();
            HistorySearch hisSearch = new HistorySearch();

            //invenAdd.TakeInventoryComboBoxData(con, tInvenEquipmentCombobox, tInvenBuildingCombobox, tInvenRoomCombobox, tInvenCategoryCombobox);
            createEquip.CreateItemData(con, createCategoryCombo);

            invenEdit.EditDisplayData(con, inventoryEditCombobox.Text, inventoryEditCombobox, nameEditCombobox, userEditCombobox, categoryEditCombobox);

            invenDelete.DeleteInventoryData(con, inventoryDeleteCombobox);
            createEquip.displayCreateEquipmentListview(con, EquipListview);
            createEquip.displayCreateBuildingListview(con, createBuildingListview);
            createEquip.displayCreateRoomListview(con, createRoomListview);
            hisSearch.Display_History_Data(con, dataGridView3);
            invenSearch.Display_Search_Data(con, dataGridView1);
            invenEdit.Display_BeforeEdit_data(con, dataGridView5, inventoryEditCombobox.Text);

            searchInventoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(57)))));
            searchInventoryButton.ForeColor = System.Drawing.Color.White;
            equipmentTabButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(57)))));
            equipmentTabButton.ForeColor = System.Drawing.Color.White;

            dataGridView6.Rows.Clear();
            dataGridView2.Rows.Clear();
        }


        //Refresh displayed data when switching between tabs
        private void inventoryTabControl_Selected(object sender, TabControlEventArgs e)
        {
            InventorySearch invenSearch = new InventorySearch();
            InventoryEdit invenEdit = new InventoryEdit();
            HistorySearch hisSearch = new HistorySearch();
            Project project = new Project();

            //Refresh all displayed data after selecting a different tab
            hisSearch.Display_History_Data(con, dataGridView3);
            invenSearch.Display_Search_Data(con, dataGridView1);
            //display_inventory_data();
            invenEdit.Display_BeforeEdit_data(con, dataGridView5, inventoryEditCombobox.Text);
            dataGridView2.Rows.Clear();
            project.Display_Project_Data(con, dataGridView7);
        }

        //Refresh displayed data when switching between inventory inner tabs
        private void inventoryInnerTabs_Selected(object sender, TabControlEventArgs e)
        {
            InventorySearch invenSearch = new InventorySearch();
            InventoryAdd invenAdd = new InventoryAdd();
            CreateEquipment createEquip = new CreateEquipment();
            InventoryEdit invenEdit = new InventoryEdit();
            InventoryDelete invenDelete = new InventoryDelete();

            //Refresh all displayed data after selecting a different tab
            invenAdd.TakeInventoryComboBoxData(con, addInvenEquipmentCombobox, addInvenBuildingCombobox, addInvenRoomCombobox, addInvenCategoryCombobox);
            createEquip.CreateItemData(con, createCategoryCombo);
            invenEdit.EditDisplayData(con, inventoryEditCombobox.Text, inventoryEditCombobox, nameEditCombobox, userEditCombobox, categoryEditCombobox);
            invenDelete.DeleteInventoryData(con, inventoryDeleteCombobox);
            invenSearch.Display_Search_Data(con, dataGridView1);

            Console.WriteLine("Connection refreshed!");
        }




        //Inventory Search - Runs cmd.CommandText query within searchTextbox.
        private void searchButton_Click(object sender, EventArgs e)
        {
            InventorySearch invenSearch = new InventorySearch();
            invenSearch.searchTextboxChanged(con, searchCombobox.Text, dataGridView1, searchTextbox.Text);
        }

        //Inventory Search - Runs cmd.CommandText query with every keystroke within searchTextbox.
        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            InventorySearch invenSearch = new InventorySearch();
            invenSearch.searchTextboxChanged(con, searchCombobox.Text, dataGridView1, searchTextbox.Text);
        } 

        //InventoryAdd - Use combobox text and insert that data into database with insert query
        private void insertButton_Click(object sender, EventArgs e)
        {
            InventoryAdd invenAdd = new InventoryAdd();

            invenAdd.OnInsertClick(con, addInvenEquipmentCombobox.Text, addInvenBuildingCombobox.Text, addInvenCategoryCombobox.Text, addInvenQuantityTextbox.Text, addInvenRoomCombobox.Text, InvenDescriptionCheckbox);
        }

        //InventoryAdd - Call clear_data() function
        private void clearInventoryButton_Click(object sender, EventArgs e)
        {
            InventoryAdd invenAdd = new InventoryAdd();
            invenAdd.clear_data(addInvenEquipmentCombobox, addInvenBuildingCombobox, addInvenRoomCombobox, addInvenCategoryCombobox, addInvenQuantityTextbox, InvenDescriptionCheckbox);
        }




        //Create tab - Use combobox text and insert that data into database with insert query
        private void createButton_Click(object sender, EventArgs e)
        {
            CreateEquipment createEquip = new CreateEquipment();

            createEquip.InsertEquipment(con, createEquipText.Text, createProductText.Text, createCategoryCombo.Text, EquipListview);
        }

        //Create tab - Call createEquipmentListview.Refresh() function
        private void refreshButton_Click(object sender, EventArgs e)
        {
            EquipListview.Refresh();
        }

        //Create tab - Create buildings using combobox text and insert that data into database with insert query
        private void createBuildingButton_Click(object sender, EventArgs e)
        {
            CreateEquipment createEquip = new CreateEquipment();
            createEquip.CreateBuilding(createBuildingTextbox.Text, createBuildingListview);
        }
        

        //Edit Inventory tab - Changing this combobox will execute these functions
        private void inventoryEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InventoryEdit invenEdit = new InventoryEdit();


            invenEdit.Display_BeforeEdit_data(con, dataGridView5, inventoryEditCombobox.Text);
            invenEdit.Display_AfterEdit_data(con, nameEditCombobox.Text, inventoryEditCombobox.Text, dataGridView6);

            
            invenEdit.EquipmentNameEdit(con, nameEditCombobox, inventoryEditCombobox.Text);
            invenEdit.UserEdit(con, userEditCombobox, inventoryEditCombobox.Text);
            invenEdit.LocationEdit(con, buildingEditCombobox, roomEditCombobox, inventoryEditCombobox.Text);
            invenEdit.CategoryEdit(con, categoryEditCombobox, inventoryEditCombobox.Text);
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

        
        /*public void RunSQLQuery(params string query, string qrNameEditComboText, string qrInvenEditComboText)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text; //Command to send to DB
            cmd.CommandText = "UPDATE INVENTORY " +
                "SET INVENTORY.EQUIPMENT_ID = " +
                "(SELECT EQUIPMENT.EQUIPMENT_ID " +
                "FROM EQUIPMENT " +
                "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + qrNameEditCombo + "') " +
                "WHERE INVENTORY.INVENTORY_ID = '" + qrInvenEditCombo + "' ";
            cmd.ExecuteNonQuery(); //Execute command
            con.Close();
        } */

         //Edit Inventory tab - If a checkbox is true then run an update query from the specified combobox by INVENTORY_ID to update the inventory table
         private void editApplyButton_Click(object sender, EventArgs e)
        {
            InventoryEdit invenEdit = new InventoryEdit();
            invenEdit.EditApplyData(con, nameEditCombobox.Text, inventoryEditCombobox.Text, categoryEditCombobox.Text, userEditCombobox.Text,
            buildingEditCombobox.Text, roomEditCombobox.Text, dataGridView6);
        }



        //Delete Inventory tab - Delete an inventory record by selecting the INVENTORY_ID 
        private void deleteButton_Click(object sender, EventArgs e)
        {
            InventoryDelete invenDelete = new InventoryDelete();

            invenDelete.DeleteInventory(con, inventoryDeleteCombobox.Text, dataGridView4);
        }

        //Delete Inventory tab - Search record information based on inventory_id and display to datagridview in delete tab
        private void searchDeleteTextbox_TextChanged(object sender, EventArgs e)
        {
            InventoryDelete invenDelete = new InventoryDelete();

            invenDelete.OnDeletedSearch(con, filterDeleteCombobox.Text, dataGridView4, searchDeleteTextbox.Text);
        }


        //Edit Inventory - FIX THIS
        private void refreshEditButton_Click(object sender, EventArgs e)
        {
            InventoryEdit invenEdit = new InventoryEdit();
            invenEdit.Display_BeforeEdit_data(con, dataGridView5, inventoryEditCombobox.Text);
            invenEdit.RefreshEdit(con, dataGridView5, inventoryEditCombobox.Text, nameEditCombobox, buildingEditCombobox, roomEditCombobox, userEditCombobox, categoryEditCombobox);
        }

        private void barcodeButton_Click(object sender, EventArgs e)
        {
            Barcode bar = new Barcode();
            bar.Show();
        }

        private void rButton_Click(object sender, EventArgs e)
        {
            //display_inventory_data();
        }

        private void nameEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void categoryEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void userEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void buildingEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void roomEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void editAfterGridUpdate(object sender, EventArgs e)
        {
            dataGridView6.Rows.Clear();

            String Eqs = nameEditCombobox.Text.ToString();
            String Cat = categoryEditCombobox.Text.ToString();
            String User = userEditCombobox.Text.ToString();
            String Bld = buildingEditCombobox.Text.ToString();
            String Room = roomEditCombobox.Text.ToString();

            dataGridView6.Rows.Add(Eqs, Cat, Bld, Room, User);
        }

        private void deleteBuildingButton_Click(object sender, EventArgs e)
        {
            InventoryDelete invenDelete = new InventoryDelete();
            invenDelete.DeleteBuilding(con, createBuildingTextbox.Text);
        }

        private void deleteRoomButton_Click(object sender, EventArgs e)
        {
            InventoryDelete invenDelete = new InventoryDelete();
            invenDelete.DeleteRoom(con, createRoomTextbox.Text);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            InventorySearch invenSearch = new InventorySearch();
            invenSearch.Display_Search_InformationTextbox(con, dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), searchInfoTextbox.Text);
        }

        private void inventoryInsertPreview(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            String Eqs = addInvenEquipmentCombobox.Text.ToString();
            String Cat = addInvenCategoryCombobox.Text.ToString();
            String Bld = addInvenBuildingCombobox.Text.ToString();
            String Room = addInvenRoomCombobox.Text.ToString();

            if (String.IsNullOrEmpty(addInvenQuantityTextbox.Text))
            {
                dataGridView2.Rows.Add(Eqs, Cat, Bld, Room);
            }
            else
            {
                int tQuan = int.Parse(addInvenQuantityTextbox.Text);

                for (int i = 0; i < tQuan; i++)
                {
                    dataGridView2.Rows.Add(Eqs, Cat, Bld, Room);
                }
            }

        }

        private void tInvenEquipmentCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inventoryInsertPreview(sender, e);
        }

        private void tInvenCategoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inventoryInsertPreview(sender, e);
        }

        private void tInvenBuildingCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inventoryInsertPreview(sender, e);
        }

        private void tInvenRoomCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inventoryInsertPreview(sender, e);
        }

        private void tInvenQuantityTextbox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(addInvenQuantityTextbox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                addInvenQuantityTextbox.Text = addInvenQuantityTextbox.Text.Remove(addInvenQuantityTextbox.Text.Length - 1);
            }
            else
            {
                inventoryInsertPreview(sender, e);
            }
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            NewProject newProject = new NewProject();
            newProject.Show();
        }


        private void dataGridView7_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Project project = new Project();

            projectEquipmentList.Items.Clear();
            project.Display_Project_EquipmentList(con, dataGridView7.SelectedRows[0].Cells[0].Value.ToString(), projectEquipmentList);

        }

        private void dataGridView7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(dataGridView7.SelectedRows[0].Cells[0].Value.ToString());
            AddProjectEquipment addEquipment = new AddProjectEquipment();


            addEquipment.Show();
        }


        private void InventoryTabButton_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectedTab = inventoryTab;
        }

        private void createTabButton_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectedTab = createTab;
        }

        private void historyTabButton_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectedTab = historyTab;
        }

        private void projectsTabButton_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectedTab = projectsTab;
        }

        private void outgoingTabButton_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectedTab = outgoingTab;
        }

        public void InventoryBtnColor(Button selectedButton, Button button1, Button button2, Button button3)
        {
            var btnColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(57)))));
            var btnColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));

            selectedButton.BackColor = btnColorOn;
            selectedButton.ForeColor = System.Drawing.Color.White;

            button1.BackColor = btnColorOff;
            button2.BackColor = btnColorOff;
            button3.BackColor = btnColorOff;
        }

        private void searchInnerButton_Click(object sender, EventArgs e)
        {

            InventoryBtnColor(searchInventoryButton, addInventoryButton, editInventoryButton, deleteInventoryButton);
            inventoryInnerTabs.SelectedTab = searchInventoryTab;
        }

        private void addInnerButton_Click(object sender, EventArgs e)
        {
            InventoryBtnColor(addInventoryButton, searchInventoryButton, editInventoryButton, deleteInventoryButton);
            inventoryInnerTabs.SelectedTab = addInventoryTab;
        }

        private void editInventoryButton_Click(object sender, EventArgs e)
        {
            inventoryInnerTabs.SelectedTab = editInventoryTab;
            InventoryBtnColor(editInventoryButton, searchInventoryButton, addInventoryButton, deleteInventoryButton);
        }

        private void deleteInventoryButton_Click(object sender, EventArgs e)
        {
            inventoryInnerTabs.SelectedTab = deleteInventoryTab;
            InventoryBtnColor(deleteInventoryButton, searchInventoryButton, editInventoryButton, addInventoryButton);
        }

        public void CreateBtnColor(Button selectedButton, Button button)
        {
            var btnColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(57)))));
            var btnColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));

            selectedButton.BackColor = btnColorOn;
            selectedButton.ForeColor = System.Drawing.Color.White;

            button.BackColor = btnColorOff;
        }

        private void equipmentTabButton_Click(object sender, EventArgs e)
        {
            createInnerTab.SelectedTab = equipmentTab;
            CreateBtnColor(equipmentTabButton, locationTabButton);
        }

        private void locationTabButton_Click(object sender, EventArgs e)
        {
            createInnerTab.SelectedTab = locationTab;
            CreateBtnColor(locationTabButton, equipmentTabButton);
        }
    }
}