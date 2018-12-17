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
        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
       
        public Main()
        {
            InitializeComponent();

        }

        //GUI for Inventory Tab Control (text, layout, size)
        private void inventoryTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            var text = this.inventoryTabControl.TabPages[e.Index].Text;
            var sizeText = g.MeasureString(text, this.inventoryTabControl.Font);

            var x = e.Bounds.Left + 3;
            var y = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 4;

            g.DrawString(text, this.inventoryTabControl.Font, Brushes.Black, x, y);
        }

        //Loads these functions on main form load
        private void Main_Load_1(object sender, EventArgs e)
        {
            TakeInventoryComboBoxData();
            CreateItemData();
            editInventoryData();
            deleteInventoryData();
            displayCreateEquipmentListview();
        }

        //Call clear_data() function
        private void clearButton_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        //Exit application from Menu toolstrip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Refresh displayed data when switching between tabs
        private void inventoryInnerTabs_Selected(object sender, TabControlEventArgs e)
        {
            //Refresh all displayed data after selecting a different tab
            TakeInventoryComboBoxData();
            CreateItemData();
            editInventoryData();
            deleteInventoryData();
            Console.WriteLine("Connection refreshed!");
        }



        //Search tab - Runs cmd.CommandText query with every keystroke within searchTextbox.
        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            string filterCB = searchCombobox.Text;
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Query for case insensitive(i) searching
            cmd.CommandText = "  SELECT EQUIPMENT.EQUIPMENT_NAME, CATEGORY.CATEGORY_NAME, LOGIN.USERNAME " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                "WHERE REGEXP_LIKE(" + filterCB + ", '(" + searchTextbox.Text + ")', 'i')"; // SQL Command
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();

        }

        //Search tab - Display data function with datagridview1
        private void display_data()
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "EQUIPMENT.EQUIPMENT_NAME AS EQUIPMENT," +
                "CATEGORY.CATEGORY_NAME AS CATEGORY," +
                "SERIAL_NO," +
                "LOGIN.USERNAME," +
                "(LOCATION.BUILDING_NAME || '_' || LOCATION.ROOM_NAME) AS BUILDING_ROOM," +
                "DATE" +
                "FROM INVENTORY" +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID" +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID" +
                "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID" +
                "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();
        }



        //TakeInventory tab - Function that loads data into TakeInventory tab comboboxes
        private void TakeInventoryComboBoxData()
        {
            //Call display data function
            display_inventory_data();
            connection.Open();
            //Queries for adapters
            string e = "SELECT * FROM EQUIPMENT";
            string b = "SELECT * FROM BUILDING";
            string r = "SELECT * FROM ROOM";
            string c = "SELECT * FROM CATEGORY";

            //Display queried data within combobox
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(e, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                tInvenEquipmentCombobox.DataSource = dt;
                tInvenEquipmentCombobox.DisplayMember = "EQUIPMENT_NAME";
                tInvenEquipmentCombobox.ValueMember = "EQUIPMENT_ID";
                connection.Close();
            }
            //Display queried data within combobox
            DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter(b, connection);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                tInvenBuildingCombobox.DataSource = dt2;
                tInvenBuildingCombobox.DisplayMember = "BUILDING_NAME";
                tInvenBuildingCombobox.ValueMember = "BUILDING_ID";
                connection.Close();
            }
            //Display queried data within combobox
            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter(c, connection);
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                tInvenCategoryCombobox.DataSource = dt3;
                tInvenCategoryCombobox.DisplayMember = "CATEGORY_NAME";
                tInvenCategoryCombobox.ValueMember = "CATEGORY_ID";
                connection.Close();
            }
            //Display queried data within combobox
            DataTable dt4 = new DataTable();
            OracleDataAdapter da4= new OracleDataAdapter(r, connection);
            da4.Fill(dt4);
            if (dt2.Rows.Count > 0)
            {
                tInvenRoomCombobox.DataSource = dt4;
                tInvenRoomCombobox.DisplayMember = "ROOM_NAME";
                tInvenRoomCombobox.ValueMember = "ROOM_ID";
                connection.Close();
            }
        }

        //TakeInventory tab - Display data function with datagridview2
        private void display_inventory_data()
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT EQUIPMENT.EQUIPMENT_NAME AS EQUIPMENT," +
                "CATEGORY.CATEGORY_NAME AS CATEGORY, " +
                "SERIAL_NO, " +
                "LOGIN.USERNAME, " +
                "(BUILDING.BUILDING_NAME || '_' || ROOM.ROOM_NAME) AS BUILDING_ROOM, " +
                "INVENTORY_DATE " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.LOCATION_ID " +
                "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.LOCATION_ID ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView2.DataSource = dta;
            connection.Close();
        }

        //TakeInventory tab - Function that clears data in comboboxes.
        private void clear_data()
        {
            tInvenEquipmentCombobox.Text = ""; //Clear textboxes
            tInvenBuildingCombobox.Text = "";
            tInvenCategoryCombobox.Text = "";
            //tInvenQuantityTextbox.Text = "";
        }

        //TakeInventory tab - If Enter is pressed(scanners have the Enter keystroke per scan) serialTextbox calls insertButton function
        private void serialTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                insertButton_Click(sender, e);
                tInvenSerialTextbox.Text = "";
                Console.WriteLine("Inserted");
            }
        }

        //TakeInventory tab - Use combobox text and insert that data into database with insert query
        private void insertButton_Click(object sender, EventArgs e)
        {
            //Inventory tab - If any of the comboboxes are empty then show messagebox
            if (String.IsNullOrEmpty(tInvenEquipmentCombobox.Text) || String.IsNullOrEmpty(tInvenBuildingCombobox.Text) || String.IsNullOrEmpty(tInvenCategoryCombobox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                string loginUser = Login.user;
                //int quantity = Convert.ToInt32(quantityTextbox.Text);

                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO INVENTORY (EQUIPMENT_ID, CATEGORY_ID, EVENT_ID, USER_ID, LOCATION_ID, SERIAL_NO)" +
                    "SELECT " +
                    "(SELECT EQUIPMENT_ID " +
                    "FROM EQUIPMENT " +
                    "WHERE EQUIPMENT.EQUIPMENT_NAME = '"+ tInvenEquipmentCombobox.Text + "') " +
                    "AS EQUIPMENT_ID," +

                    "(SELECT CATEGORY_ID " +
                    "FROM CATEGORY " +
                    "WHERE CATEGORY.CATEGORY_NAME = '" + tInvenCategoryCombobox.Text + "') " +
                    "AS CATEGORY_ID, " +

                    "(SELECT EVENT_ID " +
                    "FROM EVENT " +
                    "WHERE EVENT.EVENT_ID = 1) " +
                    "AS EVENT_ID, " +

                    "(SELECT USER_ID " +
                    "FROM LOGIN " +
                    "WHERE LOGIN.USERNAME = '"+ loginUser +"' ) " +
                    "AS USER_ID, " +

                    "(SELECT LOCATION_ID " +
                    "FROM LOCATION " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.LOCATION_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.LOCATION_ID " +
                    "WHERE BUILDING.BUILDING_NAME = '" + tInvenBuildingCombobox.Text + "' " +
                    "AND ROOM.ROOM_NAME = '" + tInvenRoomCombobox.Text + "') " +
                    "AS LOCATION_ID, " +

                    "(SELECT '" + tInvenSerialTextbox.Text + "' " +
                    "FROM DUAL) " +
                    "AS SERIAL_NO " +

                    "FROM DUAL";

                Console.WriteLine(cmd.CommandText);

                cmd.ExecuteNonQuery(); //Execute command

                cmd.CommandText = "INSERT INTO HISTORY" +
                    "(EVENT_ID, USER_ID, INVENTORY_ID)" +
                    "VALUES('1', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME ='" + loginUser + "'), (SELECT max(INVENTORY_ID) FROM INVENTORY))";
                cmd.ExecuteNonQuery();

                connection.Close(); //Close connection to DB

                display_inventory_data();
                MessageBox.Show("Data inserted successfully!");

            }
        }



        //Create tab - Use combobox text and insert that data into database with insert query
        private void createButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(createEquipmentCombobox.Text) || String.IsNullOrEmpty(productNoTextbox.Text) || String.IsNullOrEmpty(createCategoryCombobox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "SELECT COUNT(*) FROM EQUIPMENT WHERE EQUIPMENT_NAME= '" + createEquipmentCombobox.Text + "' OR PRODUCT_NO= '" + productNoTextbox.Text + "' "; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    MessageBox.Show("Already exists!");
                    createEquipmentListview.Refresh();
                    connection.Close();
                }
                else
                {
                    //connection.Open(); // Connects to DB
                    OracleCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandType = CommandType.Text; //Command to send to DB
                    cmd2.CommandText = "INSERT INTO EQUIPMENT " +
                                        "(PRODUCT_NO, EQUIPMENT_NAME, CATEGORY_ID) VALUES " +
                                        "('" + productNoTextbox.Text + "','" + createEquipmentCombobox.Text + "', " +
                                        "(SELECT CATEGORY.CATEGORY_ID FROM CATEGORY WHERE CATEGORY_NAME = '" +  createCategoryCombobox.Text + "') )"; // SQL Command
                    cmd2.ExecuteNonQuery(); //Execute command
                    //connection.Close(); //Close connection to DB

                    productNoTextbox.Text = ""; //Clear textboxes
                    createEquipmentCombobox.Text = "";

                    createEquipmentListview.Refresh();
                    connection.Close();
                    MessageBox.Show("Data inserted");
                }
            }
        }

        //Create tab - Call createEquipmentListview.Refresh() function
        private void refreshButton_Click(object sender, EventArgs e)
        {
            createEquipmentListview.Refresh();
        }

        //Create tab - display category table data into createCategoryCombobox
        private void CreateItemData()
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            string q = "SELECT * FROM CATEGORY";
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(q, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                createCategoryCombobox.DataSource = dt;
                createCategoryCombobox.DisplayMember = "CATEGORY_NAME";
                createCategoryCombobox.ValueMember = "CATEGORY_ID";
                connection.Close();
            }
        }

        //Create tab - 
        private void displayCreateEquipmentListview()
        {
            string q = "SELECT * " +
                        "FROM EQUIPMENT " +
                        "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID";

            connection.Open();

            OracleCommand cmd = new OracleCommand(q, connection);

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["EQUIPMENT_NAME"].ToString());
                    item.SubItems.Add(dr["CATEGORY_NAME"].ToString());
                    item.SubItems.Add(dr["PRODUCT_NO"].ToString());

                    createEquipmentListview.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }



        //Edit Inventory tab - Checkbox to enable/disable comboboxes and display appropriate data
        private void nameEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (nameEditCheckbox.Checked == true)
            {
                nameEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM EQUIPMENT";


                DataTable dtNE = new DataTable();
                OracleDataAdapter daNE = new OracleDataAdapter(w, connection);
                daNE.Fill(dtNE);
                if (dtNE.Rows.Count > 0)
                {
                    nameEditCombobox.DataSource = dtNE;
                    nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                    nameEditCombobox.ValueMember = "EQUIPMENT_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM EQUIPMENT " +
                    "JOIN INVENTORY ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dtNE2 = new DataTable();
                OracleDataAdapter daNE2 = new OracleDataAdapter(w, connection);
                daNE2.Fill(dtNE2);
                if (dtNE2.Rows.Count > 0)
                {
                    nameEditCombobox.DataSource = dtNE2;
                    nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                    nameEditCombobox.ValueMember = "EQUIPMENT_ID";
                    connection.Close();
                }

                nameEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab - Checkbox to enable/disable comboboxes and display appropriate data
        private void locationEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (locationEditCheckbox.Checked == true)
            {
                buildingEditCombobox.Enabled = true;
                roomEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();

                string b = "SELECT * FROM BUILDING";
                string r = "SELECT * FROM ROOM";

                DataTable dtBE = new DataTable();
                OracleDataAdapter daBE = new OracleDataAdapter(b, connection);
                daBE.Fill(dtBE);
                if (dtBE.Rows.Count > 0)
                {
                    buildingEditCombobox.DataSource = dtBE;
                    buildingEditCombobox.DisplayMember = "BUILDING_NAME";
                    buildingEditCombobox.ValueMember = "BUILDING_ID";
                    connection.Close();
                }

                DataTable dtRE = new DataTable();
                OracleDataAdapter daRE = new OracleDataAdapter(r, connection);
                daRE.Fill(dtRE);
                if (dtRE.Rows.Count > 0)
                {
                    roomEditCombobox.DataSource = dtRE;
                    roomEditCombobox.DisplayMember = "ROOM_NAME";
                    roomEditCombobox.ValueMember = "ROOM_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string b = "SELECT * FROM BUILDING " +
                "JOIN LOCATION ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                string r = "SELECT * FROM ROOM " +
                "JOIN LOCATION ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dtBE2 = new DataTable();
                OracleDataAdapter daBE2 = new OracleDataAdapter(b, connection);
                daBE2.Fill(dtBE2);
                if (dtBE2.Rows.Count > 0)
                {
                    buildingEditCombobox.DataSource = dtBE2;
                    buildingEditCombobox.DisplayMember = "BUILDING_NAME";
                    buildingEditCombobox.ValueMember = "BUILDING_ID";
                    connection.Close();
                }
                DataTable dtRE2 = new DataTable();
                OracleDataAdapter daRE2 = new OracleDataAdapter(r, connection);
                daRE2.Fill(dtRE2);
                if (dtRE2.Rows.Count > 0)
                {
                    roomEditCombobox.DataSource = dtRE2;
                    roomEditCombobox.DisplayMember = "ROOM_NAME";
                    roomEditCombobox.ValueMember = "ROOM_ID";
                    connection.Close();
                }
                buildingEditCombobox.Enabled = false;
                roomEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab - Checkbox to enable/disable comboboxes and display appropriate data
        private void userEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (userEditCheckbox.Checked == true)
            {
                userEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM LOGIN";

                DataTable dtUE = new DataTable();
                OracleDataAdapter daUE = new OracleDataAdapter(w, connection);
                daUE.Fill(dtUE);
                if (dtUE.Rows.Count > 0)
                {
                    userEditCombobox.DataSource = dtUE;
                    userEditCombobox.DisplayMember = "USERNAME";
                    userEditCombobox.ValueMember = "USER_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM LOGIN " +
                    "JOIN INVENTORY ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                    "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dtUE2 = new DataTable();
                OracleDataAdapter daUE2 = new OracleDataAdapter(w, connection);
                daUE2.Fill(dtUE2);
                if (dtUE2.Rows.Count > 0)
                {
                    userEditCombobox.DataSource = dtUE2;
                    userEditCombobox.DisplayMember = "USERNAME";
                    userEditCombobox.ValueMember = "USER_ID";
                    connection.Close();
                }
                userEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab - Checkbox to enable/disable comboboxes and display appropriate data
        private void categoryEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (categoryEditCheckbox.Checked == true)
            {
                categoryEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM CATEGORY";

                DataTable dtCE = new DataTable();
                OracleDataAdapter daCE = new OracleDataAdapter(w, connection);
                daCE.Fill(dtCE);
                if (dtCE.Rows.Count > 0)
                {
                    categoryEditCombobox.DataSource = dtCE;
                    categoryEditCombobox.DisplayMember = "CATEGORY_NAME";
                    categoryEditCombobox.ValueMember = "CATEGORY_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM CATEGORY " +
                    "JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                    "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dtCE2 = new DataTable();
                OracleDataAdapter daCE2 = new OracleDataAdapter(w, connection);
                daCE2.Fill(dtCE2);
                if (dtCE2.Rows.Count > 0)
                {
                    categoryEditCombobox.DataSource = dtCE2;
                    categoryEditCombobox.DisplayMember = "CATEGORY_NAME";
                    categoryEditCombobox.ValueMember = "CATEGORY_ID";
                    connection.Close();
                }
                categoryEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab - Checkbox to enable/disable comboboxes and display appropriate data
        private void serialEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (serialEditCheckbox.Checked == true)
            {
                serialEditTextbox.Enabled = true;
            }
            else
            {
                serialEditTextbox.Enabled = false;
            }
        }

        //Edit Inventory tab - Pull data from various tables and display them.
        private void editInventoryData()
        {
           
            //connection.Open();
            OracleCommand cmd = connection.CreateCommand();

            string i = "SELECT * FROM INVENTORY";

            string e = "SELECT * FROM EQUIPMENT " +
                        "JOIN INVENTORY ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";


            string u = "SELECT * FROM LOGIN " +
                        "JOIN INVENTORY ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

            string c = "SELECT * FROM CATEGORY " +
                        "JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

            DataTable dtEI = new DataTable();
            OracleDataAdapter daEI = new OracleDataAdapter(i, connection);
            daEI.Fill(dtEI);
            if (dtEI.Rows.Count > 0)
            {
                inventoryEditCombobox.DataSource = dtEI;
                inventoryEditCombobox.DisplayMember = "INVENTORY_ID";
                inventoryEditCombobox.ValueMember = "INVENTORY_ID";
                connection.Close();
            } 

            DataTable dtEI1 = new DataTable();
            OracleDataAdapter daEI1 = new OracleDataAdapter(e, connection);
            daEI1.Fill(dtEI1);
            if (dtEI1.Rows.Count > 0)
            {
                nameEditCombobox.DataSource = dtEI1;
                nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                nameEditCombobox.ValueMember = "EQUIPMENT_ID";
                connection.Close();
            }

            DataTable dtEI3 = new DataTable();
            OracleDataAdapter daEI3 = new OracleDataAdapter(u, connection);
            daEI3.Fill(dtEI3);
            if (dtEI3.Rows.Count > 0)
            {
                userEditCombobox.DataSource = dtEI3;
                userEditCombobox.DisplayMember = "USERNAME";
                userEditCombobox.ValueMember = "USER_ID";
                connection.Close();
            }

            DataTable dtEI4 = new DataTable();
            OracleDataAdapter daEI4 = new OracleDataAdapter(c, connection);
            daEI4.Fill(dtEI4);
            if (dtEI4.Rows.Count > 0)
            {
                categoryEditCombobox.DataSource = dtEI4;
                categoryEditCombobox.DisplayMember = "CATEGORY_NAME";
                categoryEditCombobox.ValueMember = "CATEGORY_ID";
                connection.Close();
            }

        }

        //Edit Inventory tab - Changing this combobox will execute these functions
        private void inventoryEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Attempt to uncheck edit checkboxes");
            nameEditCheckbox.Checked = false;
            categoryEditCheckbox.Checked = false;
            locationEditCheckbox.Checked = false;
            serialEditCheckbox.Checked = false;
            userEditCheckbox.Checked = false;


            nameEditCheckbox_CheckedChanged(sender, e);
            categoryEditCheckbox_CheckedChanged(sender, e);
            serialEditCheckbox_CheckedChanged(sender, e);
            userEditCheckbox_CheckedChanged(sender, e);
            locationEditCheckbox_CheckedChanged(sender, e);
            
            //editInventoryData();
            readSerialEdit(); 
        }

        //Edit Inventory tab - Select query to retrieve serial number data into serialEditTextbox
        private void readSerialEdit()
        {
            string q = "SELECT SERIAL_NO FROM INVENTORY WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "'";

            connection.Open();

            OracleCommand cmd2 = new OracleCommand(q, connection);
            OracleDataReader dr = cmd2.ExecuteReader();

            if (dr.Read())
            {
                serialEditTextbox.Text = (dr["SERIAL_NO"].ToString());
            }
            connection.Close();
        }

        //Edit Inventory tab - If a checkbox is true then run an update query from the specified combobox by INVENTORY_ID to update the inventory table
        private void editApplyButton_Click(object sender, EventArgs e)
        {

            if (nameEditCheckbox.Checked == true)
            {
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.EQUIPMENT_ID = " +
                    "(SELECT EQUIPMENT.EQUIPMENT_ID " +
                    "FROM EQUIPMENT " +
                    "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + nameEditCombobox.Text + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '"+ inventoryEditCombobox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close();
            }
            if (categoryEditCheckbox.Checked == true)
            {
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.CATEGORY_ID = " +
                    "(SELECT CATEGORY.CATEGORY_ID " +
                    "FROM CATEGORY " +
                    "WHERE CATEGORY.CATEGORY_NAME = '" + categoryEditCombobox.Text + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close();
            }
            if (userEditCheckbox.Checked == true)
            {
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.USER_ID = " +
                    "(SELECT LOGIN.USER_ID " +
                    "FROM LOGIN " +
                    "WHERE LOGIN.USERNAME = '" + userEditCombobox.Text + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close();
            }
            if (serialEditCheckbox.Checked == true)
            {
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.SERIAL_NO = '" + serialEditTextbox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close();
            }
            if (locationEditCheckbox.Checked == true)
            {
                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "SELECT COUNT(*) " +
                    "FROM LOCATION " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE BUILDING.BUILDING_NAME = '" + buildingEditCombobox.Text + "' " +
                    "AND ROOM.ROOM_NAME= '" + roomEditCombobox.Text + "' "; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter odaL = new OracleDataAdapter(cmd);
                DataTable dtL = new DataTable();
                odaL.Fill(dtL);
                if (dtL.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    connection.Close();

                    connection.Open();
                    OracleCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandType = CommandType.Text; //Command to send to DB
                    cmd2.CommandText = "UPDATE INVENTORY " +
                        "SET INVENTORY.LOCATION_ID = " +
                            "(SELECT LOCATION_ID " +
                            "FROM LOCATION " +
                            "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                            "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                            "WHERE BUILDING.BUILDING_NAME = '" + buildingEditCombobox.Text + "' " +
                            "AND ROOM.ROOM_NAME = '" + roomEditCombobox.Text + "') " +
                        "WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";
                    cmd2.ExecuteNonQuery(); //Execute command
                    connection.Close();
                    MessageBox.Show("Edited location");
                }
                else
                {
                    connection.Close();

                    connection.Open();
                    OracleCommand cmd3 = connection.CreateCommand();
                    cmd3.CommandType = CommandType.Text; //Command to send to DB
                    cmd3.CommandText = "INSERT INTO LOCATION" +
                        "(BUILDING_ID, ROOM_ID) " +
                        "SELECT(SELECT BUILDING_ID FROM BUILDING WHERE BUILDING_NAME = '" + buildingEditCombobox.Text + "' ) AS BUILDING_ID, " +
                        "(SELECT ROOM_ID FROM ROOM WHERE ROOM_NAME = '" + roomEditCombobox.Text + "' ) AS ROOM_ID " +
                        "FROM DUAL";
                    cmd3.ExecuteNonQuery(); //Execute command

                    OracleCommand cmd4 = connection.CreateCommand();
                    cmd4.CommandType = CommandType.Text; //Command to send to DB
                    cmd4.CommandText = "UPDATE INVENTORY " +
                        "SET INVENTORY.LOCATION_ID = " +
                            "(SELECT LOCATION_ID " +
                            "FROM LOCATION " +
                            "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                            "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                            "WHERE BUILDING.BUILDING_NAME = '" + buildingEditCombobox.Text + "' " +
                            "AND ROOM.ROOM_NAME = '" + roomEditCombobox.Text + "') " +
                        "WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";
                    cmd4.ExecuteNonQuery(); //Execute command
                    connection.Close();
                    MessageBox.Show("Added new location");
                }
            }
        }



        //Delete Inventory tab - Delete an inventory record by selecting the INVENTORY_ID 
        private void deleteButton_Click(object sender, EventArgs e)
        {

            connection.Open(); // Connects to DB
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM INVENTORY WHERE INVENTORY_ID = '"+ inventoryDeleteCombobox.Text +"' ";

            Console.WriteLine(cmd.CommandText);

            cmd.ExecuteNonQuery(); //Execute command
            connection.Close(); //Close connection to DB

            MessageBox.Show("Data deleted successfully!");
        }
        
        //Delete Inventory tab - Search record information based on inventory_id and display to datagridview in delete tab
        private void searchDeleteTextbox_TextChanged(object sender, EventArgs e)
        {
            string filterCB = searchCombobox.Text;
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Query for case insensitive(i) searching
            cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, CATEGORY.CATEGORY_NAME AS Category, BUILDING.BUILDING_NAME AS Building, ROOM.ROOM_NAME AS Room, LOGIN.USERNAME AS Username " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                "WHERE REGEXP_LIKE(" + filterDeleteCombobox.Text + ", '(" + searchDeleteTextbox.Text + ")', 'i')"; // SQL Command
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView4.DataSource = dta;
            connection.Close();
        }

        //Delete Inventory tab - 
        private void deleteInventoryData()
        {
            string i = "SELECT * FROM INVENTORY";


            DataTable dtDI = new DataTable();
            OracleDataAdapter daDI = new OracleDataAdapter(i, connection);
            daDI.Fill(dtDI);
            if (dtDI.Rows.Count > 0)
            {
                inventoryDeleteCombobox.DataSource = dtDI;
                inventoryDeleteCombobox.DisplayMember = "INVENTORY_ID";
                inventoryDeleteCombobox.ValueMember = "INVENTORY_ID";
                connection.Close();
            }
        }

    }
}
