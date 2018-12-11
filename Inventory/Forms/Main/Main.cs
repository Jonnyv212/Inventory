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
            var y = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2;

            g.DrawString(text, this.inventoryTabControl.Font, Brushes.Black, x, y);
        }

        //Loads these functions on main form load
        private void Main_Load_1(object sender, EventArgs e)
        {
            TakeInventoryComboBoxData();
            CreateItemData();
            editInventoryData();
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
                connection.Close(); //Close connection to DB

                display_inventory_data();
                MessageBox.Show("Data inserted successfully!");

            }
        }




        //Create tab - Display data function with datagridview3
        private void display_create_data()
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM EQUIPMENT";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView3.DataSource = dta;
            connection.Close();
        }

        //Create tab - Use combobox text and insert that data into database with insert query
        private void createButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(tInvenCategoryCombobox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "SELECT COUNT(*) FROM EQUIPMENT WHERE EQUIPMENT_NAME= '" + textBox1.Text + "' OR PRODUCT_NO= '" + textBox2.Text + "' "; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    MessageBox.Show("Already exists!");
                    connection.Close();
                    display_data();
                }
                else
                {
                    //connection.Open(); // Connects to DB
                    OracleCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandType = CommandType.Text; //Command to send to DB
                    cmd2.CommandText = "insert into EQUIPMENT (EQUIPMENT_NAME, PRODUCT_NO, CATEGORY) values " + "('" + textBox1.Text + "','" + textBox2.Text + "','" +  createCategoryCombobox.Text + "')"; // SQL Command
                    cmd2.ExecuteNonQuery(); //Execute command
                    //connection.Close(); //Close connection to DB

                    textBox1.Text = ""; //Clear textboxes
                    textBox2.Text = "";
                    connection.Close();

                    display_data();
                    MessageBox.Show("Data inserted");
                }
            }
        }

        //Create tab - Call display_create_data() function
        private void refreshButton_Click(object sender, EventArgs e)
        {
            display_create_data();
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
        private void roomEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (roomEditCheckbox.Checked == true)
            {
                roomEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();

                string r = "SELECT * FROM ROOM";

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
                string r = "SELECT * FROM ROOM " +
                "JOIN LOCATION ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

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
                roomEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab - Checkbox to enable/disable comboboxes and display appropriate data
        private void buildingEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (buildingEditCheckbox.Checked == true)
            {
                buildingEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();

                string b = "SELECT * FROM BUILDING";

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
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string b = "SELECT * FROM BUILDING " +
                "JOIN LOCATION ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
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
                    userEditCombobox.DataSource = daUE2;
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

            string b = "SELECT * FROM BUILDING " +
                        "JOIN LOCATION ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                        "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.INVENTORY_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

            string r = "SELECT * FROM ROOM " +
                        "JOIN LOCATION ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                        "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.INVENTORY_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

            string u = "SELECT * FROM LOGIN " +
                        "JOIN INVENTORY ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

            string c = "SELECT * FROM CATEGORY " +
                        "JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

          /*  DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(i, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                inventoryEditCombobox.DataSource = dt;
                inventoryEditCombobox.DisplayMember = "INVENTORY_ID";
                inventoryEditCombobox.ValueMember = "INVENTORY_ID";
                connection.Close();
            } */

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

            DataTable dtEI2 = new DataTable();
            OracleDataAdapter daEI2 = new OracleDataAdapter(b, connection);
            daEI2.Fill(dtEI2);
            if (dtEI2.Rows.Count > 0)
            {
                buildingEditCombobox.DataSource = dtEI2;
                buildingEditCombobox.DisplayMember = "BUILDING_NAME";
                buildingEditCombobox.ValueMember = "BUILDING_ID";
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

            DataTable dtEI5 = new DataTable();
            OracleDataAdapter daEI5 = new OracleDataAdapter(r, connection);
            daEI5.Fill(dtEI5);
            if (dtEI5.Rows.Count > 0)
            {
                roomEditCombobox.DataSource = dtEI5;
                roomEditCombobox.DisplayMember = "ROOM_NAME";
                roomEditCombobox.ValueMember = "ROOM_ID";
                connection.Close();
            }
        }

        //Edit Inventory tab - Changing this combobox will execute these functions
        private void inventoryEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Attempt to uncheck edit checkboxes");
            nameEditCheckbox.Checked = false;
            categoryEditCheckbox.Checked = false;
            buildingEditCheckbox.Checked = false;
            serialEditCheckbox.Checked = false;
            userEditCheckbox.Checked = false;
            roomEditCheckbox.Checked = false;


            nameEditCheckbox_CheckedChanged(sender, e);
            categoryEditCheckbox_CheckedChanged(sender, e);
            roomEditCheckbox_CheckedChanged(sender, e);
            serialEditCheckbox_CheckedChanged(sender, e);
            userEditCheckbox_CheckedChanged(sender, e);
            buildingEditCheckbox_CheckedChanged(sender, e);
            /*
            editInventoryData(); */
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


    }
}
