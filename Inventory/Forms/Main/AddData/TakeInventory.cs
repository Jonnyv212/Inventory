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
            display_data();
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

        private void Insert_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(equipmentCombobox.Text) || String.IsNullOrEmpty(locationCombobox.Text) || String.IsNullOrEmpty(quantityTextbox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                Login loginC = new Login();
                string loginUser = Login.user;
                int quantity = Convert.ToInt32(quantityTextbox.Text);

                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "insert into INVENTORY (EQUIPMENT_NAME, CATEGORY, LOCATION, ACTIVITY_BY, ACTIVITY ) values " + "('" + equipmentCombobox.Text + "','" + categoryCombobox.Text + "', '" + locationCombobox.Text + "', '" + loginUser + "', 'Inventory')"; // SQL Command
                for (int i = 0; i < quantity; i++)
                {
                    cmd.ExecuteNonQuery(); //Execute command
                }
                connection.Close(); //Close connection to DB

                clear_data();

                display_data();
                MessageBox.Show("Data inserted successfully!");
            }
        }
        private void clear_data()
        {
            equipmentCombobox.Text = ""; //Clear textboxes
            locationCombobox.Text = "";
            categoryCombobox.Text = "";
            quantityTextbox.Text = "";
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

        private void Clear_Click(object sender, EventArgs e)
        {
            string tempUser = Login.user;
            Console.WriteLine(tempUser);
            Console.WriteLine(Login.user);
            clear_data();
        }
    }
}
