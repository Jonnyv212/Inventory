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
    public class Inventory
    {
        public static void InventorySearchComboFill(ComboBox InvenFilter)
        {
            string E = "SELECT DISTINCT column_name FROM all_tab_cols WHERE column_name IN('EQUIPMENT_NAME', 'CATEGORY_NAME', 'TERM_ID', 'PROJECT_NAME') ";
            Main.ComboAddRowData(E, "column_name", InvenFilter);
        }

        public static void DisplayInventory(DataGridView dGridView, OracleConnection connection)
        {
            string query = "SELECT INVENTORY.INVENTORY_ID as ID, EQUIPMENT.EQUIPMENT_NAME as Equipment, CATEGORY.CATEGORY_NAME as Category, " +
                "PROJECT.PROJECT_NAME as Project, INVENTORY.TERM_ID as Term_ID, INVENTORY.INVENTORY_DATE AS Inv_Date " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                "WHERE INVENTORY.STATUS = '1' AND EQUIPMENT.STATUS = '1' " +
                "ORDER BY TO_NUMBER(INVENTORY_ID) DESC ";


            dGridView.DataSource = null;
            dGridView.DataSource = Main.DataTableSQLQuery(query);
            Main.InventoryDataGridAppearance(dGridView);
        }

        public static void InventoryComboFill(ComboBox Project, ComboBox Category, ComboBox Equipment)
        {
            string pj = "SELECT PROJECT_NAME FROM PROJECT WHERE PROJECT.STATUS = '1' ";
            string eq = "SELECT EQUIPMENT_NAME FROM EQUIPMENT JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID WHERE CATEGORY.CATEGORY_NAME = '" + Category.Text + "' ";
            string cat = "SELECT CATEGORY_NAME FROM CATEGORY";

            Main.ComboAddRowData(pj, "PROJECT_NAME", Project);
            Main.ComboAddRowData(cat, "CATEGORY_NAME", Category);
            Main.ComboAddRowData(eq, "EQUIPMENT_NAME", Equipment);
        }

        public static void ReloadEquipmentData(ComboBox Category, ComboBox Equipment)
        {
            string eq = "SELECT EQUIPMENT_NAME " +
                        "FROM EQUIPMENT " +
                        "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                        "WHERE CATEGORY.CATEGORY_NAME = '" + Category.Text + "' ";

            Main.ComboAddRowData(eq, "EQUIPMENT_NAME", Equipment);
        }

        public static void ReloadProductNo(ComboBox Equipment, TextBox Product, OracleConnection connection)
        {
            string productNo = "SELECT PRODUCT_NO FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + Equipment.Text + "' ";

            try
            {
                OracleCommand cmd = new OracleCommand(productNo, connection);
                connection.Open();
                cmd.CommandText = productNo;
                cmd.CommandType = CommandType.Text;
                String PJ = cmd.ExecuteScalar().ToString();
                Product.Text = PJ;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void InventorySearch(DataGridView dGridView, string iFilterCombo, string iSearchText, OracleConnection connection)
        {
            string query = "SELECT INVENTORY.INVENTORY_ID as ID, EQUIPMENT.EQUIPMENT_NAME as Equipment, CATEGORY.CATEGORY_NAME as Category, " +
                "PROJECT.PROJECT_NAME as Project, INVENTORY.TERM_ID as Term_ID, INVENTORY.INVENTORY_DATE AS Inv_Date " +
                "FROM INVENTORY " +
                "LEFT JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "WHERE REGEXP_LIKE((" + iFilterCombo + "), ('" + iSearchText + "'), 'i')  AND " +
                "INVENTORY.STATUS = '1' " +
                "ORDER BY cast(INVENTORY_ID AS int) desc ";

            dGridView.DataSource = null;
            dGridView.DataSource = Main.DataTableSQLQuery(query);
            Main.InventoryDataGridAppearance(dGridView);

        }

        public static void UpdateButton(ComboBox Equipment, ComboBox Project, TextBox TermID, TextBox IDText, OracleConnection connection)
        {
            string query = "UPDATE INVENTORY " +
                    "SET INVENTORY.EQUIPMENT_ID = (SELECT EQUIPMENT.EQUIPMENT_ID FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + Equipment.Text + "'), " +
                    //"INVENTORY.CATEGORY_ID = (SELECT CATEGORY.CATEGORY_ID FROM CATEGORY WHERE CATEGORY.CATEGORY_NAME = '" + Category.Text + "'), " +
                    "INVENTORY.PROJECT_ID = (SELECT PROJECT.PROJECT_ID FROM PROJECT WHERE PROJECT.PROJECT_NAME = '" + Project.Text + "' AND PROJECT.STATUS = '1'), " +
                    "INVENTORY.TERM_ID = ('" + TermID.Text + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + IDText.Text + "' ";

            Main.RunSQLQuery(query);
            MessageBox.Show("Inventory ID: " + IDText.Text + " was edited.");
        }

        public static void DeleteInventory(string invID, DataGridView dGridView)
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
                History.HistoryInventoryDelete("[Inventory ID " + dGridView.SelectedRows[0].Cells[0].Value.ToString() + "]: " + "was removed.");
                Main.RunSQLQuery(query);
                DataTable inventoryDataTable = (DataTable)dGridView.DataSource;
                inventoryDataTable.Rows.RemoveAt(dGridView.SelectedRows[0].Index);

                MessageBox.Show("Data deleted successfully!");
            }
        }
    }
}
