﻿using System;
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
    public partial class Login : Form
    {
        Main menu = new Main();

        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            cmd.CommandText = "SELECT COUNT(*) FROM LOGIN WHERE USERNAME= '" + usernameTextbox.Text + "' AND PASSWORD= '" + passwordTextbox.Text + "' "; // SQL Command
            cmd.ExecuteNonQuery(); //Execute command
            OracleDataAdapter sda = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
            {
                this.Hide();

                
                connection.Close();
                menu.Show();
            }
            else
            {
                connection.Close();
                MessageBox.Show("Please check your username and password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //menu.Show();
        }
    }
}
