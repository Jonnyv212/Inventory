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
            cItem.Show();
            this.Hide();
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
