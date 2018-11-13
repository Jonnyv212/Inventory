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


namespace WindowsFormsApp1
{
    public partial class AddItem : Form
    {
        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        CreateItem cItem = new CreateItem();
        public AddItem()
        {
            InitializeComponent();
        }

        private void createItemButton_Click(object sender, EventArgs e)
        {
            connection.Open(); // Connects to DB
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text; //Command to send to DB
            cmd.CommandText = "insert into INVENTORY (ITEM_NAME, CATEGORY, LOCATION, ACTIVITY_BY, ACTIVITY) values " + "('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"', 'Jonnyv', 'Item Added')"; // SQL Command
            cmd.Parameters.Add(new OracleParameter("dateParam", OracleDbType.Date)).Value = DateTime.Now;
            cmd.ExecuteNonQuery(); //Execute command
            connection.Close(); //Close connection to DB

            textBox1.Text = ""; //Clear textboxes
            textBox2.Text = "";
            textBox3.Text = "";
            display_data();
            MessageBox.Show("Data inserted successfully!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            display_data();
        }

        public void display_data()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
