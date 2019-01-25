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
    class InventoryDelete : Main
    {

        public void DeleteInventory(OracleConnection connection, String iDeleteCombo, DataGridView dGridView4)
        {

            var confirmResult = MessageBox.Show("Are you sure you want to delete this record?",
                         "Confirm Delete!",
                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string loginUser = Login.user;

                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;



                //Select event 4 (removed inventory), current user_id, and insert inventory_ID value into the HISTORY table
                cmd.CommandText = "INSERT INTO HISTORY " +
                    "(EVENT_ID, USER_ID, D_INVENTORY_ID) " +
                    "VALUES('4', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME ='" + loginUser + "'), " +
                    " '" + iDeleteCombo + "' ) ";
                //"(SELECT last_number FROM user_sequences WHERE sequence_name = 'D_INVENTORY_SEQUENCE'))";
                cmd.ExecuteNonQuery();



                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.STATUS = 0" +
                    "WHERE INVENTORY_ID = '" + iDeleteCombo + "' ";
                cmd.ExecuteNonQuery(); //Execute command


                MessageBox.Show("Data deleted successfully!");

                dGridView4.DataSource = null;

                OracleCommand cmd2 = connection.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                //Query for case insensitive(i) searching
                cmd2.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                    "CATEGORY.CATEGORY_NAME AS Category, BUILDING.BUILDING_NAME AS Building, ROOM.ROOM_NAME AS Room, LOGIN.USERNAME AS Username " +
                    "FROM INVENTORY " +
                    "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                    "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                    "WHERE INVENTORY.STATUS = '1' "; // SQL Command
                cmd2.ExecuteNonQuery();
                DataTable dta2 = new DataTable();
                OracleDataAdapter dataadp2 = new OracleDataAdapter(cmd2);
                dataadp2.Fill(dta2);

                dGridView4.DataSource = dta2;
                connection.Close();
            }
            else
            {
                // If 'No', do something here.
            }
        }

        public void OnDeletedSearch(OracleConnection connection, String fDeleteCombo, DataGridView dGridView4, String sDeleteTextbox)
        {
            string filterCB = fDeleteCombo;
            connection.Open();
            dGridView4.DataSource = null;

            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Query for case insensitive(i) searching
            cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, CATEGORY.CATEGORY_NAME AS Category, BUILDING.BUILDING_NAME AS Building, ROOM.ROOM_NAME AS Room, LOGIN.USERNAME AS Username " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                "WHERE REGEXP_LIKE(" + fDeleteCombo + ", '(" + sDeleteTextbox + ")', 'i') AND INVENTORY.STATUS = '1' ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);

            dGridView4.DataSource = dta;
            connection.Close();
        }

        public void DeleteInventoryData(OracleConnection connection, ComboBox invenDeleteCombo)
        {
            string i = "SELECT * FROM INVENTORY WHERE INVENTORY.STATUS = '1' ";

            connection.Open();

            DataTable dtDI = new DataTable();
            OracleDataAdapter daDI = new OracleDataAdapter(i, connection);
            daDI.Fill(dtDI);
            if (dtDI.Rows.Count > 0)
            {
                invenDeleteCombo.DataSource = dtDI;
                invenDeleteCombo.DisplayMember = "INVENTORY_ID";
                invenDeleteCombo.ValueMember = "INVENTORY_ID";
                connection.Close();
            }
        }

        public void DeleteBuilding(OracleConnection connection, string cBldTextbox)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this building?",
                            "Confirm Delete!",
                            MessageBoxButtons.YesNo);
            connection.Open();

            OracleCommand invLocCheck = connection.CreateCommand();
            invLocCheck.CommandType = CommandType.Text;
            invLocCheck.CommandText = "SELECT COUNT(*) FROM INVENTORY JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                "WHERE BUILDING.BUILDING_NAME = '" + cBldTextbox + "' ";
            invLocCheck.ExecuteNonQuery(); //Execute command

            OracleDataAdapter InvLocSda = new OracleDataAdapter(invLocCheck);
            DataTable invLocDt = new DataTable();
            InvLocSda.Fill(invLocDt);
            if (invLocDt.Rows[0][0].ToString() == "0") //Checks in DB if first column, first row equals 0
            {

                string loginUser = Login.user;
                if (confirmResult == DialogResult.Yes)
                {
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM LOCATION WHERE LOCATION.BUILDING_ID = " +
                        "(SELECT BUILDING.BUILDING_ID FROM BUILDING WHERE BUILDING.BUILDING_NAME = '" + cBldTextbox + "' ) ";
                    cmd.ExecuteNonQuery(); //Execute command


                    cmd.CommandText = "DELETE FROM BUILDING WHERE BUILDING_NAME = '" + cBldTextbox + "' ";
                    cmd.ExecuteNonQuery();


                    connection.Close(); //Close connection to DB

                    MessageBox.Show("Data deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Building " + cBldTextbox + " is already used in previous inventories. Edit or remove them before deleting this building.");
                connection.Close();
            }
        }

        public void DeleteRoom(OracleConnection connection, string cRoomTextbox)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this building?",
                "Confirm Delete!",
                MessageBoxButtons.YesNo);
            con.Open();
            OracleCommand invLocCheck = con.CreateCommand();
            invLocCheck.CommandType = CommandType.Text;
            invLocCheck.CommandText = "SELECT COUNT(*) FROM INVENTORY JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                "WHERE ROOM.ROOM_NAME = '" + cRoomTextbox + "' ";
            invLocCheck.ExecuteNonQuery(); //Execute command

            OracleDataAdapter InvLocSda = new OracleDataAdapter(invLocCheck);
            DataTable invLocDt = new DataTable();
            InvLocSda.Fill(invLocDt);
            if (invLocDt.Rows[0][0].ToString() == "0") //Checks in DB if first column, first row equals 0
            {

                string loginUser = Login.user;
                if (confirmResult == DialogResult.Yes)
                {
                    OracleCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;


                    cmd.CommandText = "DELETE FROM LOCATION WHERE LOCATION.ROOM_ID = " +
                        "(SELECT ROOM.ROOM_ID FROM ROOM WHERE ROOM.ROOM_NAME = '" + cRoomTextbox + "' ) ";
                    cmd.ExecuteNonQuery(); //Execute command


                    cmd.CommandText = "DELETE FROM ROOM WHERE ROOM_NAME = '" + cRoomTextbox + "' ";
                    cmd.ExecuteNonQuery();


                    con.Close(); //Close connection to DB

                    MessageBox.Show("Data deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Room " + cRoomTextbox + " is already used in previous inventories. Edit or remove them before deleting this room.");
                con.Close();
            }
        }
    }
}
