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
            string tableCB = searchCombobox.Text;
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Query for case insensitive(i) searching
            cmd.CommandText = "SELECT * FROM INVENTORY_DETAILS WHERE REGEXP_LIKE(" + tableCB + ", '(" + searchTextbox.Text + ")', 'i')"; // SQL Command
            Console.WriteLine(cmd.CommandText);
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
            string q = "SELECT * FROM EQUIPMENT";
            string w = "SELECT * FROM LOCATION";
            string d = "SELECT * FROM CATEGORY";

            //Display queried data within combobox
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(q, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                tInvenEquipmentCombobox.DataSource = dt;
                tInvenEquipmentCombobox.DisplayMember = "EQUIPMENT_NAME";
                tInvenEquipmentCombobox.ValueMember = "EQUIPMENT_ID";
                connection.Close();
            }
            //Display queried data within combobox
            /*DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter(w, connection);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                tInvenLocationCombobox.DataSource = dt2;
                tInvenLocationCombobox.DisplayMember = "ROOM";
                tInvenLocationCombobox.ValueMember = "LOCATION_ID";
                connection.Close();
            }*/
            //Display queried data within combobox
            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter(d, connection);
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                tInvenCategoryCombobox.DataSource = dt3;
                tInvenCategoryCombobox.DisplayMember = "CATEGORY_NAME";
                tInvenCategoryCombobox.ValueMember = "CATEGORY_ID";
                connection.Close();
            }
        }

        //TakeInventory tab - Display data function with datagridview2
        private void display_inventory_data()
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM INVENTORY";
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
            tInvenLocationCombobox.Text = "";
            tInvenCategoryCombobox.Text = "";
            //tInvenQuantityTextbox.Text = "";
        }

        //TakeInventory tab - Display data function with datagridview1
        private void display_data()
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM INVENTORY";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();
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
            if (String.IsNullOrEmpty(tInvenEquipmentCombobox.Text) || String.IsNullOrEmpty(tInvenLocationCombobox.Text) || String.IsNullOrEmpty(tInvenCategoryCombobox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                string loginUser = Login.user;
                //int quantity = Convert.ToInt32(quantityTextbox.Text);

                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "insert into INVENTORY (EQUIPMENT_NAME, CATEGORY_NAME, USERNAME, EVENT, SERIAL_NUMBER ) values " + "('" + tInvenEquipmentCombobox.Text + "','" + tInvenCategoryCombobox.Text + "', '" + loginUser + "', 'Inventory', '" + tInvenSerialTextbox.Text + "')"; // SQL Command
                Console.WriteLine(cmd.CommandText);
                //For Loop to execute command multiple times for multiple inserts
                /*for (int i = 0; i < quantity; i++)
                {
                    cmd.ExecuteNonQuery(); //Execute command
                }*/
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
        public void nameEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (nameEditCheckbox.Checked == true)
            {
                nameEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT DISTINCT EQUIPMENT_NAME FROM INVENTORY";

                DataTable dt1 = new DataTable();
                OracleDataAdapter da1 = new OracleDataAdapter(w, connection);
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    nameEditCombobox.DataSource = dt1;
                    nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                    nameEditCombobox.ValueMember = "INVENTORY_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM INVENTORY WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dt1 = new DataTable();
                OracleDataAdapter da1 = new OracleDataAdapter(w, connection);
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    nameEditCombobox.DataSource = dt1;
                    nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                    nameEditCombobox.ValueMember = "INVENTORY_ID";
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
                locationEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT DISTINCT LOCATION FROM INVENTORY";

                DataTable dt1 = new DataTable();
                OracleDataAdapter da1 = new OracleDataAdapter(w, connection);
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    locationEditCombobox.DataSource = dt1;
                    locationEditCombobox.DisplayMember = "LOCATION";
                    locationEditCombobox.ValueMember = "INVENTORY_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM INVENTORY WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dt1 = new DataTable();
                OracleDataAdapter da1 = new OracleDataAdapter(w, connection);
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    locationEditCombobox.DataSource = dt1;
                    locationEditCombobox.DisplayMember = "LOCATION";
                    locationEditCombobox.ValueMember = "INVENTORY_ID";
                    connection.Close();
                }
            locationEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab - Checkbox to enable/disable comboboxes and display appropriate data
        private void userEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (userEditCheckbox.Checked == true)
            {
                userEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT DISTINCT ACTIVITY_BY FROM INVENTORY";

                DataTable dt1 = new DataTable();
                OracleDataAdapter da1 = new OracleDataAdapter(w, connection);
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    userEditCombobox.DataSource = dt1;
                    userEditCombobox.DisplayMember = "ACTIVITY_BY";
                    userEditCombobox.ValueMember = "INVENTORY_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM INVENTORY WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dt1 = new DataTable();
                OracleDataAdapter da1 = new OracleDataAdapter(w, connection);
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    userEditCombobox.DataSource = dt1;
                    userEditCombobox.DisplayMember = "ACTIVITY_BY";
                    userEditCombobox.ValueMember = "INVENTORY_ID";
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
                string w = "SELECT DISTINCT CATEGORY FROM INVENTORY";

                DataTable dt1 = new DataTable();
                OracleDataAdapter da1 = new OracleDataAdapter(w, connection);
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    categoryEditCombobox.DataSource = dt1;
                    categoryEditCombobox.DisplayMember = "CATEGORY";
                    categoryEditCombobox.ValueMember = "INVENTORY_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM INVENTORY WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dt1 = new DataTable();
                OracleDataAdapter da1 = new OracleDataAdapter(w, connection);
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    categoryEditCombobox.DataSource = dt1;
                    categoryEditCombobox.DisplayMember = "CATEGORY";
                    categoryEditCombobox.ValueMember = "INVENTORY_ID";
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

        //Edit Inventory tab - Checkbox to enable/disable comboboxes and display appropriate data
        private void dateEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (dateEditCheckbox.Checked == true)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
            }
        }

        //Edit Inventory tab - Pull data from various tables and display them.
        private void editInventoryData()
        {
           
            //connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            string w = "SELECT * FROM INVENTORY WHERE INVENTORY_ID = '"+inventoryEditCombobox.Text+"' ";

            DataTable dt1 = new DataTable();
            OracleDataAdapter da1 = new OracleDataAdapter(w, connection);
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                nameEditCombobox.DataSource = dt1;
                nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                nameEditCombobox.ValueMember = "INVENTORY_ID";
                connection.Close();
            }
            DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter(w, connection);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                locationEditCombobox.DataSource = dt2;
                locationEditCombobox.DisplayMember = "LOCATION";
                locationEditCombobox.ValueMember = "INVENTORY_ID";
                connection.Close();
            }
            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter(w, connection);
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                userEditCombobox.DataSource = dt3;
                userEditCombobox.DisplayMember = "ACTIVITY_BY";
                userEditCombobox.ValueMember = "INVENTORY_ID";
                connection.Close();
            }
            DataTable dt4 = new DataTable();
            OracleDataAdapter da4 = new OracleDataAdapter(w, connection);
            da4.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {
                categoryEditCombobox.DataSource = dt4;
                categoryEditCombobox.DisplayMember = "CATEGORY";
                categoryEditCombobox.ValueMember = "INVENTORY_ID";
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
            dateEditCheckbox.Checked = false;


            nameEditCheckbox_CheckedChanged(sender, e);
            categoryEditCheckbox_CheckedChanged(sender, e);
            locationEditCheckbox_CheckedChanged(sender, e);
            serialEditCheckbox_CheckedChanged(sender, e);
            userEditCheckbox_CheckedChanged(sender, e);
            dateEditCheckbox_CheckedChanged(sender, e);

            editInventoryData();
            readSerialEdit();
        }

        //Edit Inventory tab - Select query to retrieve serial number data into serialEditTextbox
        private void readSerialEdit()
        {
            string q = "SELECT SERIAL_NUMBER FROM INVENTORY WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "'";

            connection.Open();

            OracleCommand cmd2 = new OracleCommand(q, connection);
            OracleDataReader dr = cmd2.ExecuteReader();

            if (dr.Read())
            {
                serialEditTextbox.Text = (dr["SERIAL_NUMBER"].ToString());
            }
            connection.Close();
        }
    }
}
