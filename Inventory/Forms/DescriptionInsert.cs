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
    public partial class DescriptionInsert : Form
    {
        OracleConnection connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        Main mainIns = new Main();

        public string descID;

        public DescriptionInsert()
        {
            InitializeComponent();
        }

        public void DescriptionInsert_Load(object sender, EventArgs e)
        {
                this.TopMost = true;
        }


        private void applyButton_Click(object sender, EventArgs e)
        {

            connection.Open();
            OracleCommand descIns2 = connection.CreateCommand();

            descIns2.CommandType = CommandType.Text;
            descIns2.CommandText = "UPDATE INVENTORY_DESCRIPTION " +
                    "SET INVENTORY_DESCRIPTION.DESCRIPTION = " +
                    " '" + descriptionRichTextBox.Text + "' " +
                    "WHERE DESCRIPTION_ID = '" + descID + "' ";
            Console.WriteLine(descIns2.CommandText);
            Console.WriteLine(descID);
            descIns2.ExecuteNonQuery();
           
            connection.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.Close();
            mainIns.Show();
        }
    }
}
