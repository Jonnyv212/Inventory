using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Login : Form
    {
        
        Main menu = new Main();
        public static string user;
                                              
        public Login()
        {
            InitializeComponent();
        }

      

        public void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
