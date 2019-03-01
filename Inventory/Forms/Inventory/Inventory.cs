using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Inventory
{
    class Inventory
    {
        Main main = new Main();

        public void InventorySearchComboFill(ComboBox InvenFilter)
        {
            string E = "SELECT DISTINCT column_name FROM all_tab_cols WHERE column_name IN('EQUIPMENT_NAME', 'CATEGORY_NAME', 'TERM_ID', 'PROJECT_NAME') ";
            main.ComboAddRowData(E, "column_name", InvenFilter);
        }

        public void DisplayInventory(DataGridView dGridView, OracleConnection connection)
        {
            string query = "SELECT INVENTORY.INVENTORY_ID as ID, EQUIPMENT.EQUIPMENT_NAME as Equipment, CATEGORY.CATEGORY_NAME as Category, " +
                "PROJECT.PROJECT_NAME as Project, INVENTORY.TERM_ID as Term_ID, INVENTORY.INVENTORY_DATE AS Inv_Date " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "WHERE INVENTORY.STATUS = '1' " +
                "ORDER BY TO_NUMBER(INVENTORY_ID) DESC ";


            dGridView.DataSource = null;
            dGridView.DataSource = main.DataTableSQLQuery(query);
            main.InventoryDataGridAppearance(dGridView);
        }

        public void InventoryComboboFill(ComboBox Project, ComboBox Category, ComboBox Equipment)
        {
            string pj = "SELECT PROJECT_NAME FROM PROJECT";
            string eq = "SELECT EQUIPMENT_NAME FROM EQUIPMENT JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID WHERE CATEGORY.CATEGORY_NAME = '" + Category.Text + "' ";
            string cat = "SELECT CATEGORY_NAME FROM CATEGORY";

            main.ComboAddRowData(pj, "PROJECT_NAME", Project);
            main.ComboAddRowData(cat, "CATEGORY_NAME", Category);
            main.ComboAddRowData(eq, "EQUIPMENT_NAME", Equipment);
        }

        public void EditData(TextBox IDText, TextBox TermID, ComboBox Project, ComboBox Category, ComboBox Equipment, TextBox Product, DataGridView dGriView, OracleConnection connection)
        {
            IDText.Text = dGriView.SelectedRows[0].Cells[0].Value.ToString();

            string query = "SELECT * FROM INVENTORY WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";
            string pjName = "SELECT PROJECT_NAME FROM PROJECT JOIN INVENTORY ON INVENTORY.PROJECT_ID = PROJECT.PROJECT_ID WHERE INVENTORY_ID = '" + IDText.Text + "' ";
            string catName = "SELECT CATEGORY_NAME FROM CATEGORY JOIN INVENTORY ON INVENTORY.CATEGORY_ID = CATEGORY.CATEGORY_ID WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";
            string eqName = "SELECT EQUIPMENT_NAME FROM EQUIPMENT JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";
            string productNo = "SELECT PRODUCT_NO FROM EQUIPMENT JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";


            OracleCommand cmd = new OracleCommand(query, connection);
            OracleCommand cmd1 = new OracleCommand(pjName, connection);
            OracleCommand cmd2 = new OracleCommand(catName, connection);
            OracleCommand cmd3 = new OracleCommand(eqName, connection);
            OracleCommand cmd4 = new OracleCommand(productNo, connection);
            try
            {
                connection.Open();

                cmd1.CommandText = pjName;
                cmd1.CommandType = CommandType.Text;
                String PJ = cmd1.ExecuteScalar().ToString();

                cmd2.CommandText = catName;
                cmd2.CommandType = CommandType.Text;
                String CAT = cmd2.ExecuteScalar().ToString();

                cmd3.CommandText = eqName;
                cmd3.CommandType = CommandType.Text;
                String EQ = cmd3.ExecuteScalar().ToString();

                cmd4.CommandText = productNo;
                cmd4.CommandType = CommandType.Text;
                String PN = cmd4.ExecuteScalar().ToString();


                Project.Text = PJ;
                Category.Text = CAT;
                Equipment.Text = EQ;
                Product.Text = PN;

                using (OracleDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        TermID.Text = (read["TERM_ID"].ToString());
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void ReloadEquipmentData(ComboBox Category, ComboBox Equipment)
        {
            string eq = "SELECT EQUIPMENT_NAME " +
                        "FROM EQUIPMENT " +
                        "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                        "WHERE CATEGORY.CATEGORY_NAME = '" + Category.Text + "' ";

            main.ComboAddRowData(eq, "EQUIPMENT_NAME", Equipment);
        }

        public void InventorySearch(DataGridView dGridView, string iFilterCombo, string iSearchText, OracleConnection connection)
        {
            string query = "SELECT INVENTORY.INVENTORY_ID as ID, EQUIPMENT.EQUIPMENT_NAME as Equipment, CATEGORY.CATEGORY_NAME as Category, " +
                "PROJECT.PROJECT_NAME as Project, INVENTORY.TERM_ID as Term_ID, INVENTORY.INVENTORY_DATE AS Inv_Date " +
                "FROM INVENTORY " +
                "LEFT JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "WHERE REGEXP_LIKE((" + iFilterCombo + "), ('" + iSearchText + "'), 'i')  AND " +
                "INVENTORY.STATUS = '1' " +
                "ORDER BY cast(INVENTORY_ID AS int) desc ";

            dGridView.DataSource = null;
            dGridView.DataSource = main.DataTableSQLQuery(query);
            main.InventoryDataGridAppearance(dGridView);

        }

        public void UpdateButton(ComboBox Equipment, ComboBox Category, ComboBox Project, TextBox TermID, TextBox IDText, OracleConnection connection)
        {
            string query = "UPDATE INVENTORY " +
                    "SET INVENTORY.EQUIPMENT_ID = (SELECT EQUIPMENT.EQUIPMENT_ID FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + Equipment.Text + "'), " +
                    "INVENTORY.CATEGORY_ID = (SELECT CATEGORY.CATEGORY_ID FROM CATEGORY WHERE CATEGORY.CATEGORY_NAME = '" + Category.Text + "'), " +
                    "INVENTORY.PROJECT_ID = (SELECT PROJECT.PROJECT_ID FROM PROJECT WHERE PROJECT.PROJECT_NAME = '" + Project.Text + "'), " +
                    "INVENTORY.TERM_ID = ('" + TermID.Text + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";

            main.RunSQLQuery(query);
            MessageBox.Show("Inventory ID: " + IDText.Text + " was edited.");
        }

        public void DeleteInventory(string invID, DataGridView dGridView)
        {
            string query = "UPDATE INVENTORY " +
                    "SET INVENTORY.STATUS = 0, " +
                    "INVENTORY.PROJECT_ID = 1 " +
                    "WHERE INVENTORY_ID = '" + invID + "' ";

            var confirmResult = MessageBox.Show("Are you sure you want to delete this record?",
                         "Confirm Delete!",
                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                main.RunSQLQuery(query);

                DataTable inventoryDataTable = (DataTable)dGridView.DataSource;
                inventoryDataTable.Rows.RemoveAt(dGridView.SelectedRows[0].Index);

                MessageBox.Show("Data deleted successfully!");
            }
        }
    }
}
