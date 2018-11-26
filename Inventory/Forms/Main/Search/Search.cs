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
    public partial class Search : Form
    {
        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        DataTable dtas = new DataTable();
        public Search()
        {
            InitializeComponent();
        }


        private void menuButton_Click(object sender, EventArgs e)
        {
            Main menu = new Main();
            this.Hide();
            menu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display_search_data();
        }
        public void display_search_data()
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM INVENTORY WHERE ITEM_NAME LIKE '" + searchBox.Text + "%' "; // SQL Command
            //cmd.CommandText = "SELECT * FROM INVENTORY WHERE Item_Category LIKE '" + searchBox.Text + "%' ";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();
        }
        public void display_test(string test)
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM " + test + " ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display_test(searchBox.Text);
        }


        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string tableCB = tableComboBox.Text;
            Console.WriteLine(tableCB);
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM INVENTORY WHERE REGEXP_LIKE(" + tableCB + ", '(" + searchBox.Text + ")', 'i')"; // SQL Command
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();

        }

        private void tableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {
            /*string d = "SELECT * FROM INVENTORY";

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(d, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                tableComboBox.DataSource = dt;
                tableComboBox. = "EQUIPMENT_NAME";
                tableComboBox.ValueMember = "INVENTORY_ID";
                connection.Close();
            }*/
        }
    }
}
