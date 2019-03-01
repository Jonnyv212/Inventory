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

namespace Inventory
{
    public partial class ProjectNewForm : Form
    {
        public OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        Main main = new Main();

        public ProjectNewForm()
        {
            InitializeComponent();
        }

        private void createPbutton_Click(object sender, EventArgs e)
        {
            con.Open();

            if (string.IsNullOrEmpty(pNameTextbox.Text))
            {
                MessageBox.Show("Please give the project a name.");
            }
            else
            {
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO PROJECT (PROJECT_NAME, TICKET_NO, PROJECT_DESCRIPTION)" +
                          "VALUES('" + pNameTextbox.Text + "', '" + ticketNoTextbox.Text + "', '" + descTextbox.Text + "') ";

                cmd.ExecuteNonQuery();

                MessageBox.Show("New project created!");

                pNameTextbox.Text = "";
                ticketNoTextbox.Text = "";
                descTextbox.Text = "";
            }
            con.Close();
        }

        private void mainClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
