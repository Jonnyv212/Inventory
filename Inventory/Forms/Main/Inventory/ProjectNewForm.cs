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

        private bool mouseDown;
        private Point lastLocation;

        //Main main = new Main();

        public ProjectNewForm()
        {
            InitializeComponent();
        }

        private void createPbutton_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO PROJECT (PROJECT_NAME, TICKET_NO, PROJECT_DESCRIPTION)" +
                          "VALUES('" + pNameTextbox.Text + "', '" + ticketNoTextbox.Text + "', '" + descTextbox.Text + "') ";

            if (string.IsNullOrEmpty(pNameTextbox.Text))
            {
                MessageBox.Show("Please give the project a name.");
            }
            else
            {
                Main.RunSQLQuery(query);
                MessageBox.Show("New project created!");
                History.HistoryProjectAdd(" ["+pNameTextbox.Text+ "] created. Ticket Number: [" + ticketNoTextbox.Text + "].");
                pNameTextbox.Text = "";
                ticketNoTextbox.Text = "";
                descTextbox.Text = "";

                this.Close();
            }
        }

        private void mainClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label19_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label19_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label19_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
