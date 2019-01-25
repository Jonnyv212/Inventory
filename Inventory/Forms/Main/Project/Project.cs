using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace Inventory
{
    class Project : Main
    {
        public void Display_Project_Data(OracleConnection connection, DataGridView dGridView7)
        {
            connection.Open();
            dGridView7.DataSource = null;

            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PROJECT.PROJECT_NAME AS Projects FROM PROJECT " +
                              "ORDER BY cast(PROJECT_ID AS int) desc ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);

            dGridView7.DataSource = dta;
            connection.Close();
        }

        public void Display_Project_EquipmentList(OracleConnection connection, string pInfo_ID, ListView pEquipList)
        {
            string searchEquipment = "SELECT INVENTORY.INVENTORY_ID, EQUIPMENT.EQUIPMENT_NAME " +
                "FROM INVENTORY JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "WHERE PROJECT.PROJECT_NAME = '" + pInfo_ID + "' ";


            OracleCommand cmd = new OracleCommand(searchEquipment, connection);
            connection.Open();
            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["INVENTORY_ID"].ToString());
                    item.SubItems.Add(dr["EQUIPMENT_NAME"].ToString());

                    pEquipList.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }
    }
}
