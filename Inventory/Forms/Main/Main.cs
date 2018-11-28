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
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
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
            InventoryComboBoxData();
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

    }
}
