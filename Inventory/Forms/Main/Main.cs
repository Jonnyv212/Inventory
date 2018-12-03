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
        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
       
        public Main()
        {
            InitializeComponent();

        }
        private void inventoryTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            var text = this.inventoryTabControl.TabPages[e.Index].Text;
            var sizeText = g.MeasureString(text, this.inventoryTabControl.Font);

            var x = e.Bounds.Left + 3;
            var y = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2;

            g.DrawString(text, this.inventoryTabControl.Font, Brushes.Black, x, y);
        }

        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            string tableCB = searchCombobox.Text;
            Console.WriteLine(tableCB);
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM INVENTORY WHERE REGEXP_LIKE(" + tableCB + ", '(" + searchTextbox.Text + ")', 'i')"; // SQL Command
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();

        }

        private void Main_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.INVENTORY' table. You can move, or remove it, as needed.
            this.iNVENTORYTableAdapter.Fill(this.dataSet1.INVENTORY);
            InventoryComboBoxData();
            CreateItemData();
            EditInventoryData();
        }

        private void InventoryComboBoxData()
        {
            display_inventory_data();
            connection.Open();
            string q = "SELECT * FROM EQUIPMENT";
            string w = "SELECT * FROM LOCATION";
            string d = "SELECT * FROM CATEGORY";

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(q, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                equipmentCombobox.DataSource = dt;
                equipmentCombobox.DisplayMember = "EQUIPMENT_NAME";
                equipmentCombobox.ValueMember = "EQUIPMENT_ID";
                connection.Close();
            }

            DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter(w, connection);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                locationCombobox.DataSource = dt2;
                locationCombobox.DisplayMember = "ROOM";
                locationCombobox.ValueMember = "LOCATION_ID";
                connection.Close();
            }

            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter(d, connection);
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                categoryCombobox.DataSource = dt3;
                categoryCombobox.DisplayMember = "CAT_NAME";
                categoryCombobox.ValueMember = "CAT_ID";
                connection.Close();
            }
        }

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
        private void clear_data()
        {
            equipmentCombobox.Text = ""; //Clear textboxes
            locationCombobox.Text = "";
            categoryCombobox.Text = "";
            //quantityTextbox.Text = "";
        }
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

        private void serialTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                insertButton_Click(sender, e);
                serialTextbox.Text = "";
                Console.WriteLine("Inserted");
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(equipmentCombobox.Text) || String.IsNullOrEmpty(locationCombobox.Text) || String.IsNullOrEmpty(categoryCombobox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                Login loginC = new Login();
                string loginUser = Login.user;
                //int quantity = Convert.ToInt32(quantityTextbox.Text);

                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "insert into INVENTORY (EQUIPMENT_NAME, CATEGORY, LOCATION, ACTIVITY_BY, ACTIVITY, SERIAL_NUMBER ) values " + "('" + equipmentCombobox.Text + "','" + categoryCombobox.Text + "', '" + locationCombobox.Text + "', '" + loginUser + "', 'Inventory', '" + serialTextbox.Text + "')"; // SQL Command
                Console.WriteLine(cmd.CommandText);
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(categoryCombobox.Text))
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

        private void refreshButton_Click(object sender, EventArgs e)
        {
            display_create_data();
        }

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
                createCategoryCombobox.DisplayMember = "CAT_NAME";
                createCategoryCombobox.ValueMember = "CAT_ID";
                connection.Close();
            }
        }

        private void EditInventoryData()
        {
            //connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            string w = "SELECT * FROM INVENTORY WHERE INVENTORY_ID = '"+inventoryEditCombobox.Text+"' ";
            string q = "SELECT SERIAL_NUMBER FROM INVENTORY WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "'";

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

        private void inventoryEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            EditInventoryData();
            readSerialEdit();
        }

        private void readSerialEdit()
        {
            connection.Open();

            string q = "SELECT SERIAL_NUMBER FROM INVENTORY WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "'";
            OracleCommand cmd2 = new OracleCommand(q, connection);
            OracleDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                serialEditTextbox.Text = (dr["SERIAL_NUMBER"].ToString());
            }
            connection.Close();
        }

        private void editNameCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (nameEditCheckbox.Checked == true)
            {
                nameEditCombobox.Enabled = true;
            }
            else
            {
                nameEditCombobox.Enabled = false;
            }
        }

        private void locationEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (locationEditCheckbox.Checked == true)
            {
                locationEditCombobox.Enabled = true;
            }
            else
            {
                locationEditCombobox.Enabled = false;
            }
        }

        private void userEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (userEditCheckbox.Checked == true)
            {
                userEditCombobox.Enabled = true;
            }
            else
            {
                userEditCombobox.Enabled = false;
            }
        }

        private void categoryEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (categoryEditCheckbox.Checked == true)
            {
                categoryEditCombobox.Enabled = true;
            }
            else
            {
                categoryEditCombobox.Enabled = false;
            }
        }

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
    }
}
