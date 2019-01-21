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
    public partial class AddProjectEquipment : Form
    {
        OracleConnection connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");


        public AddProjectEquipment()
        {
            InitializeComponent();
        }

        private void AddProjectEquipment_Load(object sender, EventArgs e)
        {
            displayEquipment();
        }

        public void displayEquipment()
        {

            dataGridView1.DataSource = null;

            connection.Open();

            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, CATEGORY.CATEGORY_NAME AS Category, " +
                        "(BUILDING.BUILDING_NAME || '-' || ROOM.ROOM_NAME) AS Location, INVENTORY.INVENTORY_DATE AS InvDate " +
                        "FROM INVENTORY " +
                        "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                        "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                        "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                        "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                        "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                        "WHERE INVENTORY.STATUS = '1' " +
                        "ORDER BY cast(INVENTORY_ID AS int) desc "; // SQL Command
            cmd.ExecuteNonQuery();

            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);

            dataGridView1.DataSource = dta;
            connection.Close();

        }
    }
}
