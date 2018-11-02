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
    public partial class Form1 : Form
    {
        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open(); // Connects to DB
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text; //Command to send to DB
            //cmd.CommandText = "insert into FACULTY_NEW (Name, Room, CM) values " +
             //   "('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')"; // SQL Command
            string text1 = textBox1.Text;
            string eth1 = "50074983171373";
            if (text1 == eth1) {
                text1 = "Ethernet-7FT-Y";
            }
            //cmd.CommandText = "insert into INVENTORY (item) values " +
            // "('" + textBox1.Text + "')"; // SQL Command

            cmd.CommandText = "insert into INVENTORY (item) values " +
             "('" + text1 + "')"; // SQL Command

            cmd.ExecuteNonQuery(); //Execute command
            connection.Close(); //Close connection to DB

            textBox1.Text = ""; //Clear textboxes
            textBox2.Text = "";
            textBox3.Text = ""; 
            textBox4.Text = "";
            display_data();
            MessageBox.Show("Data inserted successfully!");
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

        private void button5_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open(); // Connects to DB
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text; //Command to send to DB
            cmd.CommandText = "delete from FACULTY_NEW WHERE Name = '" + textBox1.Text + "' "; // SQL Command
            cmd.ExecuteNonQuery(); //Execute command
            connection.Close(); //Close connection to DB
            textBox1.Text = ""; //Clear textboxes
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            display_data();
            MessageBox.Show("Data deleted successfully!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open(); // Connects to DB
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text; //Command to send to DB
            cmd.CommandText = "SELECT * FROM FACULTY_NEW WHERE Name LIKE '" + textBox4.Text + "%' "; // SQL Command
            cmd.ExecuteNonQuery(); //Execute command
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close(); //Close connection to DB
            textBox1.Text = ""; //Clear textboxes
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Insert(0, "Copenhagen");
        }
    }
}
