using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Drawing;

namespace Inventory
{
    class Barcode
    {
        //Main main = new Main();

        public static void DisplayEquipment(DataGridView dGridView)
        {
            string query = "SELECT CATEGORY.CATEGORY_NAME as Category, EQUIPMENT.EQUIPMENT_NAME as Equipment, EQUIPMENT.PRODUCT_NO as Product_No " +
                "FROM EQUIPMENT " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                "WHERE EQUIPMENT.STATUS = '1' " +
                "ORDER BY CATEGORY_NAME, EQUIPMENT_NAME DESC";

            dGridView.DataSource = null;
            dGridView.DataSource = Main.DataTableSQLQuery(query);

            DataGridViewColumn column1 = dGridView.Columns[0];
            column1.Width = 100;

            DataGridViewColumn column2 = dGridView.Columns[1];
            column2.Width = 150;
            dGridView.Rows[0].Selected = true;
        }

        public static void BarcodeTimer(string quantity, string barcode, TextBox textBarcode, Button barcodeBtn, DataGridView dGridView, OracleConnection connection)
        {
            if (String.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("Please select a quantity!");

                barcodeBtn.Enabled = false;
                barcodeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
                barcodeBtn.ForeColor = Color.Black;
            }
            else
            {
               // connection.Close();

                //connection.Open();
                string queryCheck = "SELECT COUNT(*) FROM EQUIPMENT WHERE PRODUCT_NO = '" + barcode + "' ";


                DataTable dt = new DataTable();
                dt = Main.DataTableSQLQuery(queryCheck);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    barcodeBtn.Enabled = true;
                    barcodeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
                    barcodeBtn.ForeColor = Color.White;

                    string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT WHERE lower(PRODUCT_NO) = '" + barcode + "' OR upper(PRODUCT_NO) = '" + barcode + "' ";
                    string c = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY JOIN EQUIPMENT ON EQUIPMENT.CATEGORY_ID = CATEGORY.CATEGORY_ID WHERE lower(PRODUCT_NO) = '" + barcode + "' OR upper(PRODUCT_NO) = '" + barcode + "' ";
                    string p = "SELECT PRODUCT_NO FROM EQUIPMENT WHERE lower(PRODUCT_NO) = '" + barcode + "' OR upper(PRODUCT_NO) = '" + barcode + "' ";

                    int quan = int.Parse(quantity);

                    OracleCommand cmd2 = new OracleCommand(q, connection);
                    OracleCommand cmd3 = new OracleCommand(c, connection);
                    OracleCommand cmd4 = new OracleCommand(p, connection);
                    try
                    {
                        connection.Open();
                        cmd2.CommandText = q;
                        cmd2.CommandType = CommandType.Text;
                        String Eq = cmd2.ExecuteScalar().ToString();

                        cmd3.CommandText = c;
                        cmd3.CommandType = CommandType.Text;
                        String Cat = cmd3.ExecuteScalar().ToString();

                        cmd4.CommandText = p;
                        cmd4.CommandType = CommandType.Text;
                        String Prod = cmd4.ExecuteScalar().ToString();

                        for (int i = 0; i < quan; i++)
                        {
                            dGridView.Rows.Add(Eq, Cat, Prod);
                        }
                        connection.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBarcode.Clear();
                    quantity = "1";
                }
                else
                {
                    textBarcode.Clear();
                }
               // barcodeBtn.Enabled = false;
            }
        }

        public static void BarcodeInsert(Button barcodeBtn, DataGridView dGridView, OracleConnection connection)
        {
            if (String.IsNullOrEmpty(dGridView.Rows[0].Cells[0].Value as String))
            {
                MessageBox.Show("No data");
                return;
            }
            else
            {
                for (int i = 0; i < dGridView.Rows.Count; i++)
                {
                string query = "INSERT INTO INVENTORY (EQUIPMENT_ID, EVENT_ID, PROJECT_ID)" +
                                "SELECT " +

                                "(SELECT EQUIPMENT_ID FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + dGridView.Rows[i].Cells[0].Value + "') " +
                                "AS EQUIPMENT_ID," +
                                "(SELECT EVENT_ID FROM EVENT WHERE EVENT.EVENT_ID = 1) " +
                                "AS EVENT_ID, " +
                                "(SELECT PROJECT_ID FROM PROJECT WHERE PROJECT.PROJECT_ID = 1) " +
                                "AS PROJECT_ID " +

                                "FROM DUAL";
                    Main.RunSQLQuery(query);
                    History.HistoryBarcodeInsert("[Inventory ID: "+ Main.ScalarSQLQuery("SELECT MAX(TO_NUMBER(INVENTORY_ID)) FROM INVENTORY", connection)+"]: Barcode scanned "+ dGridView.Rows[i].Cells[0].Value + " into inventory.");
                    /*
                    //History log of insert
                    cmd.CommandText = "INSERT INTO HISTORY" +
                    "(EVENT_ID, USER_ID, HISTORY_DESCRIPTION, D_INVENTORY_ID)" +
                    "VALUES('1', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME = '" + Login.user + "'), " +
                    "('New inventory taken. Inventory ID: ' || (SELECT MAX(INVENTORY_ID) FROM INVENTORY)), " +
                    "(SELECT MAX(INVENTORY_ID) FROM INVENTORY))";
                    cmd.ExecuteNonQuery();
                    */
                }
                barcodeBtn.Enabled = false;
                barcodeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))));
                barcodeBtn.ForeColor = Color.Black;
                dGridView.Rows.Clear();
                MessageBox.Show("Inserted all rows.");
            }
        }
    }
}
