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
    class Barcode
    {
        Main main = new Main();

        public void DisplayEquipment(DataGridView dGridView)
        {
            string query = "SELECT CATEGORY.CATEGORY_NAME as Category, EQUIPMENT.EQUIPMENT_NAME as Equipment, EQUIPMENT.PRODUCT_NO as Product_No " +
                "FROM EQUIPMENT " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                "ORDER BY CATEGORY_NAME, EQUIPMENT_NAME DESC";

            dGridView.DataSource = null;
            dGridView.DataSource = main.DataTableSQLQuery(query);

            DataGridViewColumn column1 = dGridView.Columns[0];
            column1.Width = 100;

            DataGridViewColumn column2 = dGridView.Columns[1];
            column2.Width = 150;
        }

        public void BarcodeTimer(string quantity, string barcode, TextBox textBarcode, Button barcodeBtn, DataGridView dGridView, OracleConnection connection)
        {
            if (String.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("Please select a quantity!");

                barcodeBtn.Enabled = false;
            }
            else
            {
                connection.Close();

                connection.Open();


                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) FROM EQUIPMENT WHERE PRODUCT_NO = '" + barcode + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    barcodeBtn.Enabled = true;
                    string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT WHERE lower(PRODUCT_NO) = '" + barcode + "' OR upper(PRODUCT_NO) = '" + barcode + "' ";
                    string c = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY JOIN EQUIPMENT ON EQUIPMENT.CATEGORY_ID = CATEGORY.CATEGORY_ID WHERE lower(PRODUCT_NO) = '" + barcode + "' OR upper(PRODUCT_NO) = '" + barcode + "' ";
                    string p = "SELECT PRODUCT_NO FROM EQUIPMENT WHERE lower(PRODUCT_NO) = '" + barcode + "' OR upper(PRODUCT_NO) = '" + barcode + "' ";

                    int quan = int.Parse(quantity);

                    OracleCommand cmd2 = new OracleCommand(q, connection);
                    OracleCommand cmd3 = new OracleCommand(c, connection);
                    OracleCommand cmd4 = new OracleCommand(p, connection);
                    try
                    {
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
                connection.Close();
            }
        }

        public void BarcodeInsert(Button barcodeBtn, DataGridView dGridView, OracleConnection connection)
        {
            if (String.IsNullOrEmpty(dGridView.Rows[0].Cells[0].Value as String))
            {
                MessageBox.Show("No data");
                return;
            }
            else
            {
                connection.Open(); // Connects to DB

                for (int i = 0; i < dGridView.Rows.Count; i++)
                {
                string query = "INSERT INTO INVENTORY (EQUIPMENT_ID, CATEGORY_ID, EVENT_ID, PROJECT_ID)" +
                                "SELECT " +

                                "(SELECT EQUIPMENT_ID FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + dGridView.Rows[i].Cells[0].Value + "') " +
                                "AS EQUIPMENT_ID," +
                                "(SELECT CATEGORY_ID FROM CATEGORY WHERE CATEGORY.CATEGORY_NAME = '" + dGridView.Rows[i].Cells[1].Value + "') " +
                                "AS CATEGORY_ID, " +
                                "(SELECT EVENT_ID FROM EVENT WHERE EVENT.EVENT_ID = 1) " +
                                "AS EVENT_ID, " +
                                "(SELECT PROJECT_ID FROM PROJECT WHERE PROJECT.PROJECT_ID = 1) " +
                                "AS PROJECT_ID " +

                                "FROM DUAL";
                    main.RunSQLQuery(query);

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

                // quantityTextbox_TextChanged(sender, e);
                barcodeBtn.Enabled = false;
                dGridView.Rows.Clear();
                connection.Close();
                MessageBox.Show("Inserted all rows.");
            }
        }
    }
}
