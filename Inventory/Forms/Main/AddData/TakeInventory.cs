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
    public partial class TakeInventory : Form
    {
        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        public TakeInventory()
        {
            InitializeComponent();
        }

        private void TakeInventory_Load(object sender, EventArgs e)
        {
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
                locationCombobox.DataSource = dt3;
                locationCombobox.DisplayMember = "CAT_NAME";
                locationCombobox.ValueMember = "CAT_ID";
                connection.Close();
            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(equipmentCombobox.Text) || String.IsNullOrEmpty(locationCombobox.Text) || String.IsNullOrEmpty(quantityTextbox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                string equipment = equipmentCombobox.SelectedItem.ToString();
                string location = locationCombobox.SelectedItem.ToString();
                string quantity = quantityTextbox.SelectedText.ToString();

                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                //cmd.CommandText = "insert into INVENTORY (ITEM_NAME, CATEGORY, LOCATION, ACTIVITY_BY, ACTIVITY) values " + "('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', 'Jonnyv', 'Item Added')"; // SQL Command
                cmd.CommandText = "insert into INVENTORY_PREVIEW (EQUIPMENT_NAME, CATEGORY, LOCATION ) values " + "('" + equipment + "','', '" + location + "')"; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close(); //Close connection to DB

                //textBox1.Text = ""; //Clear textboxes
                //textBox2.Text = "";

                //display_data();
                MessageBox.Show("Data inserted successfully!");
            }
        }

        private void categoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
