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
    public partial class CreateItem : Form
    {
        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        public CreateItem()
        {
            InitializeComponent();
        }

        private void createItemButton_Click(object sender, EventArgs e)
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
                cmd.CommandText = "insert into EQUIPMENT (EQUIPMENT_NAME, BARCODE, CATEGORY) values " + "('" + textBox1.Text + "','" + textBox2.Text + "','" + categoryCombobox.Text + "')"; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close(); //Close connection to DB

                textBox1.Text = ""; //Clear textboxes
                textBox2.Text = "";

                display_data();
                MessageBox.Show("Data inserted successfully!");
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            display_data();
        }

        public void display_data()
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT EQUIPMENT_NAME, BARCODE, CATEGORY FROM EQUIPMENT";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();
        }

        private void CreateItem_Load(object sender, EventArgs e)
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            string q = "SELECT * FROM CATEGORY";
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(q, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                categoryCombobox.DataSource = dt;
                categoryCombobox.DisplayMember = "CAT_NAME";
                categoryCombobox.ValueMember = "CAT_ID";
                connection.Close();
            }
        }
    }
}
