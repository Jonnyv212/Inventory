using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Windows.Forms;


namespace Inventory
{
    class HistorySearch : Main
    {
        public void Display_History_Data(OracleConnection connection, DataGridView dGridView3)
        {

            connection.Open();
            dGridView3.DataSource = null;

            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT INVENTORY_ID AS INVENTORY_ID, EVENT.EVENT, LOGIN.USERNAME " +
                "FROM INVENTORY " +
                "JOIN EVENT ON EVENT.EVENT_ID = INVENTORY.EVENT_ID " +
                "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                "ORDER BY INVENTORY_DATE DESC";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);

            dGridView3.DataSource = dta;
            connection.Close();
        }
    }
}
