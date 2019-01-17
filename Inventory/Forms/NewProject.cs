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
    public partial class NewProject : Form
    {
        OracleConnection connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");

        public NewProject()
        {
            InitializeComponent();
        }

        private void NewProject_Load(object sender, EventArgs e)
        {

        }

        private void projectCreateButton_Click(object sender, EventArgs e)
        {
            Main main = new Main();

           
            connection.Open();

            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO PROJECT (PROJECT_NAME, TICKET_NO, PROJECT_DESCRIPTION)" +
                        "VALUES ('" + projectNameTextbox.Text + "', '" + projectTicketTextbox.Text + "', '" + projectDescTextbox.Text + "')";
            cmd.ExecuteNonQuery();

            MessageBox.Show("New project created!");


            connection.Close();
        }

        private void projectCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
