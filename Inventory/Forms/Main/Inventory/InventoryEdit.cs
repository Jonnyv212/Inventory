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
    class InventoryEdit : Main
    {
        public void EquipmentNameEdit(OracleConnection connection, ComboBox nEditCombo, String invEditCombo)
        {
            Main main = new Main();

            string w = "SELECT * FROM EQUIPMENT";


            nEditCombo.Enabled = true;
            main.ComboAddRowData(w, "EQUIPMENT_NAME", nEditCombo);
            nEditCombo.SelectedIndex = 0;
        }

        public void LocationEdit(OracleConnection connection, ComboBox bEditCombo, ComboBox rEditCombo, String iEditCombo)
        {
            Main main = new Main();

            string b = "SELECT * FROM BUILDING";
            string r = "SELECT * FROM ROOM";

            bEditCombo.Enabled = true;
            rEditCombo.Enabled = true;


            main.ComboAddRowData(b, "BUILDING_NAME", bEditCombo);
            main.ComboAddRowData(r, "ROOM_NAME", rEditCombo);
            bEditCombo.SelectedIndex = 0;
            rEditCombo.SelectedIndex = 0;
        }

        public void UserEdit(OracleConnection connection, ComboBox uEditCombo, String iEditCombo)
        {
            Main main = new Main();

            string w = "SELECT * FROM LOGIN";

            uEditCombo.Enabled = true;


            main.ComboAddRowData(w, "USERNAME", uEditCombo);
            uEditCombo.SelectedIndex = 0;
        }

        public void CategoryEdit(OracleConnection connection, ComboBox cEditCombo, String iEditCombo)
        {
            Main main = new Main();

            string w = "SELECT * FROM CATEGORY";

            cEditCombo.Enabled = true;


            main.ComboAddRowData(w, "CATEGORY_NAME", cEditCombo);
            cEditCombo.SelectedIndex = 0;
        }


        //Edit Inventory tab - Pull data from various tables and display them.
        public void EditDisplayData(OracleConnection connection, String invenEditComboText, ComboBox invenEditCombo, ComboBox nameEditCombo, ComboBox userEditCombo, ComboBox categoryEditCombo)
        {
            Main main = new Main();

            string i = "SELECT * FROM INVENTORY WHERE INVENTORY.STATUS = '1' ORDER BY INVENTORY_DATE desc ";

            string e = "SELECT * FROM EQUIPMENT " +
                        "JOIN INVENTORY ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                        "WHERE INVENTORY_ID = '" + invenEditComboText + "' AND INVENTORY.STATUS = '1' ";


            string u = "SELECT * FROM LOGIN " +
                        "JOIN INVENTORY ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                        "WHERE INVENTORY_ID = '" + invenEditComboText + "' AND INVENTORY.STATUS = '1' ";

            string c = "SELECT * FROM CATEGORY " +
                        "JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                        "WHERE INVENTORY_ID = '" + invenEditComboText + "' AND INVENTORY.STATUS = '1' ";


            main.ComboAddRowData(i, "inventory_id", invenEditCombo);
            main.ComboAddRowData(e, "EQUIPMENT_NAME", nameEditCombo);
            main.ComboAddRowData(u, "USERNAME", userEditCombo);
            main.ComboAddRowData(c, "CATEGORY_NAME", categoryEditCombo);
        }

        
        public void EditApplyData(OracleConnection connection, String nEditCombo, String iEditCombo, String cEditCombo, 
            String uEditCombo, String bldEditCombo, String rmEditCombo, DataGridView dGridView)
        {

                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.EQUIPMENT_ID = " +
                    "(SELECT EQUIPMENT.EQUIPMENT_ID " +
                    "FROM EQUIPMENT " +
                    "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + nEditCombo + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close();


                connection.Open();
                OracleCommand cmd2 = connection.CreateCommand();
                cmd2.CommandType = CommandType.Text; //Command to send to DB
                cmd2.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.CATEGORY_ID = " +
                    "(SELECT CATEGORY.CATEGORY_ID " +
                    "FROM CATEGORY " +
                    "WHERE CATEGORY.CATEGORY_NAME = '" + cEditCombo + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' ";
                cmd2.ExecuteNonQuery(); //Execute command
                connection.Close();


                connection.Open();
                OracleCommand cmd3 = connection.CreateCommand();
                cmd3.CommandType = CommandType.Text; //Command to send to DB
                cmd3.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.USER_ID = " +
                    "(SELECT LOGIN.USER_ID " +
                    "FROM LOGIN " +
                    "WHERE LOGIN.USERNAME = '" + uEditCombo + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' ";
                cmd3.ExecuteNonQuery(); //Execute command
                connection.Close();


                connection.Open(); // Connects to DB
                OracleCommand cmd4 = connection.CreateCommand();
                cmd4.CommandType = CommandType.Text; //Command to send to DB
                //Check to see if location exists
                cmd4.CommandText = "SELECT COUNT(*) " +
                    "FROM LOCATION " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE BUILDING.BUILDING_NAME = '" + bldEditCombo + "' " +
                    "AND ROOM.ROOM_NAME= '" + rmEditCombo + "' "; // SQL Command
                cmd4.ExecuteNonQuery(); //Execute command
                OracleDataAdapter odaL = new OracleDataAdapter(cmd4);
                DataTable dtL = new DataTable();
                odaL.Fill(dtL);
                if (dtL.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    //If the location exists then continue the update
                    connection.Close();


                    connection.Open();
                    OracleCommand cmd5 = connection.CreateCommand();
                    cmd5.CommandType = CommandType.Text; //Command to send to DB
                    cmd5.CommandText = "UPDATE INVENTORY " +
                        "SET INVENTORY.LOCATION_ID = " +
                            "(SELECT LOCATION_ID " +
                            "FROM LOCATION " +
                            "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                            "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                            "WHERE BUILDING.BUILDING_NAME = '" + bldEditCombo + "' " +
                            "AND ROOM.ROOM_NAME = '" + rmEditCombo + "') " +
                        "WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' ";
                    cmd5.ExecuteNonQuery(); //Execute command
                    connection.Close();
                    MessageBox.Show("Edited location");
                }
                else
                {
                    //else create new a new ID with the new building/room combination for the Location table
                    connection.Close();

                    connection.Open();
                    OracleCommand cmd6 = connection.CreateCommand();
                    cmd6.CommandType = CommandType.Text; //Command to send to DB
                    cmd6.CommandText = "INSERT INTO LOCATION" +
                        "(BUILDING_ID, ROOM_ID) " +
                        "SELECT(SELECT BUILDING_ID FROM BUILDING WHERE BUILDING_NAME = '" + bldEditCombo + "' ) AS BUILDING_ID, " +
                        "(SELECT ROOM_ID FROM ROOM WHERE ROOM_NAME = '" + rmEditCombo + "' ) AS ROOM_ID " +
                        "FROM DUAL";
                    cmd6.ExecuteNonQuery(); //Execute command

                    //update with new location ID
                    OracleCommand cmd7 = connection.CreateCommand();
                    cmd7.CommandType = CommandType.Text; //Command to send to DB
                    cmd7.CommandText = "UPDATE INVENTORY " +
                        "SET INVENTORY.LOCATION_ID = " +
                            "(SELECT LOCATION_ID " +
                            "FROM LOCATION " +
                            "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                            "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                            "WHERE BUILDING.BUILDING_NAME = '" + bldEditCombo + "' " +
                            "AND ROOM.ROOM_NAME = '" + rmEditCombo + "') " +
                        "WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' ";
                    cmd7.ExecuteNonQuery(); //Execute command
                    connection.Close();
                    MessageBox.Show("Added new location");
                }
                connection.Open();
                OracleCommand cmd8 = connection.CreateCommand();
                cmd8.CommandType = CommandType.Text; //Command to send to DB

                //History log of edit
                cmd8.CommandText = "INSERT INTO HISTORY" +
                    "(EVENT_ID, USER_ID, HISTORY_DESCRIPTION)" +
                    "VALUES('2', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME = 'jonnyv'), " +
                    "('Inventory edited. Inventory ID: ' ||  '" + iEditCombo + "' ))";
                cmd8.ExecuteNonQuery();
                connection.Close();

            dGridView.Rows.Clear();
        }

   
        public void Display_BeforeEdit_data(OracleConnection connection, DataGridView dGridView5, String iEditCombo)
        {
            connection.Open();

            dGridView5.DataSource = null;

            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                    "CATEGORY.CATEGORY_NAME AS Category, " +
                    "BUILDING.BUILDING_NAME AS Building, ROOM.ROOM_NAME AS Room, " +
                    "LOGIN.USERNAME AS Users " +
                    "FROM INVENTORY " +
                    "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                    "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                    "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' AND INVENTORY.STATUS = '1' ";
            cmd.ExecuteNonQuery();

            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);

            dGridView5.DataSource = dta;
            connection.Close();
        }


        public void Display_AfterEdit_data(OracleConnection connection, String nEditCombo, String iEditCombo, DataGridView dGridView)
        {
            connection.Open();
            dGridView.Rows.Clear();

            //DISPLAY PREVIEW
            string q = "SELECT EQUIPMENT.EQUIPMENT_NAME FROM EQUIPMENT JOIN INVENTORY ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' ";
            string c = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' ";
            string u = "SELECT LOGIN.USERNAME FROM INVENTORY JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' AND INVENTORY.STATUS = '1' ";
            string b = "SELECT BUILDING.BUILDING_NAME FROM BUILDING JOIN LOCATION ON LOCATION.BUILDING_ID = BUILDING.BUILDING_ID JOIN INVENTORY ON INVENTORY.LOCATION_ID = LOCATION.LOCATION_ID WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' AND INVENTORY.STATUS = '1' ";
            string r = "SELECT ROOM.ROOM_NAME FROM ROOM JOIN LOCATION ON LOCATION.ROOM_ID = ROOM.ROOM_ID JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID WHERE INVENTORY.INVENTORY_ID = '" + iEditCombo + "' AND INVENTORY.STATUS = '1' ";


            OracleCommand cmd2 = new OracleCommand(q, connection);
            OracleCommand cmd3 = new OracleCommand(c, connection);
            OracleCommand cmd5 = new OracleCommand(u, connection);
            OracleCommand cmd6 = new OracleCommand(b, connection);
            OracleCommand cmd7 = new OracleCommand(r, connection);
            try
            {
                cmd2.CommandText = q;
                cmd2.CommandType = CommandType.Text;
                String Eq = cmd2.ExecuteScalar().ToString();

                cmd3.CommandText = c;
                cmd3.CommandType = CommandType.Text;
                String Cat = cmd3.ExecuteScalar().ToString();

                cmd5.CommandText = u;
                cmd5.CommandType = CommandType.Text;
                String User = cmd5.ExecuteScalar().ToString();

                cmd6.CommandText = b;
                cmd6.CommandType = CommandType.Text;
                String Bld = cmd6.ExecuteScalar().ToString();

                cmd7.CommandText = r;
                cmd7.CommandType = CommandType.Text;
                String Room = cmd7.ExecuteScalar().ToString();

                dGridView.Rows.Add(Eq, Cat, Bld, Room, User);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public void RefreshEdit(OracleConnection connection, DataGridView dGridView5, String iEditCombo, ComboBox nEditCombo, ComboBox bEditCombo, ComboBox rEditCombo, 
            ComboBox uEditCombo, ComboBox cEditCombo)
        {
            Main main = new Main();
            dGridView5.DataSource = null;
            nEditCombo.DataSource = null;
            bEditCombo.DataSource = null;
            rEditCombo.DataSource = null;
            uEditCombo.DataSource = null;
            cEditCombo.DataSource = null;

            string w = "SELECT * FROM EQUIPMENT " +
            "JOIN INVENTORY ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
            "WHERE INVENTORY_ID = '" + iEditCombo + "' AND INVENTORY.STATUS = '1' ";

            string b = "SELECT * FROM BUILDING " +
            "JOIN LOCATION ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
            "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
            "WHERE INVENTORY_ID = '" + iEditCombo + "' AND INVENTORY.STATUS = '1' ";

            string r = "SELECT * FROM ROOM " +
            "JOIN LOCATION ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
            "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
            "WHERE INVENTORY_ID = '" + iEditCombo + "' AND INVENTORY.STATUS = '1' ";

            string u = "SELECT * FROM LOGIN " +
            "JOIN INVENTORY ON LOGIN.USER_ID = INVENTORY.USER_ID " +
            "WHERE INVENTORY_ID = '" + iEditCombo + "' AND INVENTORY.STATUS = '1' ";

            string c = "SELECT * FROM CATEGORY " +
            "JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
            "WHERE INVENTORY_ID = '" + iEditCombo + "' AND INVENTORY.STATUS = '1' ";


            main.ComboAddRowData(w, "EQUIPMENT_NAME", nEditCombo);
            main.ComboAddRowData(b, "BUILDING_NAME", bEditCombo);
            main.ComboAddRowData(r, "ROOM_NAME", rEditCombo);
            main.ComboAddRowData(u, "USERNAME", uEditCombo);
            main.ComboAddRowData(c, "CATEGORY_NAME", cEditCombo);
        }
    }
}
