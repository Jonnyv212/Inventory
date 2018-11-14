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
    public partial class TakeInventory : Form
    {
        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        public TakeInventory()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void locationCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void equipmentCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TakeInventory_Load(object sender, EventArgs e)
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT EQUIPMENT_NAME FROM EQUIPMENT";
            string q = "SELECT * FROM EQUIPMENT";
            string w = "SELECT * FROM LOCATION";
            //cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(q, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                equipmentCombobox.DataSource = dt;
                equipmentCombobox.DisplayMember = "EQUIPMENT_NAME";
                equipmentCombobox.ValueMember = "EQUIPMENT_ID";
                connection.Close();
            }
            DataTable dt2 = new DataTable();
            OracleDataAdapter de = new OracleDataAdapter(w, connection);
            de.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                locationCombobox.DataSource = dt2;
                locationCombobox.DisplayMember = "ROOM";
                locationCombobox.ValueMember = "LOCATION_ID";
                connection.Close();
            }
        }
    }
}
