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
    class InventoryTab : Main
    {
        Main main = new Main(); 

        public void InventorySearchTextboxChanged(OracleConnection connection, string sCombobox, DataGridView dataGrid1, string sText)
        {
            if (String.IsNullOrEmpty(sCombobox))
            {
                MessageBox.Show("Please select a valid filter!");
            }
            else
            {
                dataGrid1.DataSource = null;
                string filterCB = sCombobox;
                connection.Open();

                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                //Query for case insensitive(i) searching
                cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID as ID, EQUIPMENT.EQUIPMENT_NAME as Equipment, CATEGORY.CATEGORY_NAME as Category, " +
                "PROJECT.PROJECT_NAME as Project, INVENTORY.TERM_ID as Term_ID, INVENTORY.INVENTORY_DATE AS Inv_Date " +
                    "FROM INVENTORY " +
                    "LEFT JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                    "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                    "WHERE REGEXP_LIKE(("+sCombobox+"), ('"+sText+"'), 'i')  AND " +
                    "INVENTORY.STATUS = '1' " +
                    "ORDER BY cast(INVENTORY_ID AS int) desc "; // SQL Command

                cmd.ExecuteNonQuery();
                DataTable dta = new DataTable();
                OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
                dataadp.Fill(dta);
                dataGrid1.DataSource = dta;

                connection.Close();
            }
        }

        public void InventorySearchComboFill(OracleConnection connection, ComboBox sCombobox)
        {
            string E = "SELECT DISTINCT column_name FROM all_tab_cols WHERE column_name IN('EQUIPMENT_NAME', 'CATEGORY_NAME', 'TERM_ID', 'PROJECT_NAME') ";
            main.ComboAddRowData(E, "column_name", sCombobox);
        }

    }
}
