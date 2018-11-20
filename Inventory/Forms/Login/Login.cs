using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Login : Form
    {
        
        Main menu = new Main();
        public string user;

        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        public Login()
        {
            InitializeComponent();
        }

        private void BarcodeLoginButton_Click(object sender, EventArgs e)
        {
            connection.Open(); // Connects to DB
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text; //Command to send to DB
            cmd.CommandText = "SELECT COUNT(*) FROM LOGIN WHERE L_BARCODE='" + barcodeTextbox.Text + "' "; // SQL Command
            cmd.ExecuteNonQuery(); //Execute command
            OracleDataAdapter sda = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Console.WriteLine(dt.Rows[0][0].ToString());
            if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
            {
                this.Hide();

                user = usernameTextbox.Text;
                connection.Close();
                menu.Show();

                Console.WriteLine(dt.Rows[0][0].ToString());
            }
            else
            {
                connection.Close();
                MessageBox.Show("Please check your username and password");
            }
        }

            private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            connection.Open(); // Connects to DB
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text; //Command to send to DB
            cmd.CommandText = "SELECT COUNT(*) FROM LOGIN WHERE USER_NAME= '" + usernameTextbox.Text + "' AND PASSWORD= '" + passwordTextbox.Text + "' "; // SQL Command
            cmd.ExecuteNonQuery(); //Execute command
            OracleDataAdapter sda = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
            {
                this.Hide();
                user = usernameTextbox.Text;
                
                connection.Close();
                menu.Show();

                Console.WriteLine(dt.Rows[0][0].ToString());
            }
            else
            {
                connection.Close();
                MessageBox.Show("Please check your username and password");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TakeInventory tInv = new TakeInventory();
            tInv.Show();
        }
    }
}
