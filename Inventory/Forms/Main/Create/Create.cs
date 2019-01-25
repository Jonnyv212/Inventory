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
    class CreateEquipment : Main
    {
        public void InsertEquipment(OracleConnection connection, String cEquipText, String cProductText, String cCategoryCombo, ListView EquipListview)
        {
            if (String.IsNullOrEmpty(cEquipText) || String.IsNullOrEmpty(cProductText) || String.IsNullOrEmpty(cCategoryCombo))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                con.Open(); // Connects to DB
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "SELECT COUNT(*) FROM EQUIPMENT WHERE EQUIPMENT_NAME= '" + cEquipText + "' OR PRODUCT_NO= '" + cProductText + "' "; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    MessageBox.Show("Already exists!");
                    EquipListview.Refresh();
                    con.Close();
                }
                else
                {
                    //connection.Open(); // Connects to DB
                    OracleCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text; //Command to send to DB
                    cmd2.CommandText = "INSERT INTO EQUIPMENT " +
                                        "(PRODUCT_NO, EQUIPMENT_NAME, CATEGORY_ID) VALUES " +
                                        "('" + cProductText + "','" + cEquipText + "', " +
                                        "(SELECT CATEGORY.CATEGORY_ID FROM CATEGORY WHERE CATEGORY_NAME = '" + cCategoryCombo + "') )"; // SQL Command
                    cmd2.ExecuteNonQuery(); //Execute command

                    //History log of equipment addition
                    cmd2.CommandText = "INSERT INTO HISTORY" +
                        "(EVENT_ID, USER_ID, HISTORY_DESCRIPTION)" +
                        "VALUES('3', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME = 'jonnyv'), " +
                        "('Added Equipment: ' || (SELECT EQUIPMENT_NAME FROM EQUIPMENT WHERE EQUIPMENT_ID = " +
                        "(SELECT MAX(EQUIPMENT_ID) FROM EQUIPMENT)))";
                    cmd2.ExecuteNonQuery();

                    cProductText = ""; //Clear textboxes
                    cEquipText = "";

                    EquipListview.Refresh();
                    con.Close();
                    MessageBox.Show("Data inserted");
                }
            }
        }

        //Create tab - display category table data into createCategoryCombobox
        public void CreateItemData(OracleConnection connection, ComboBox cCategoryCombo)
        {
         string q = "SELECT * FROM CATEGORY";

         con.Open();

         OracleCommand cmd = con.CreateCommand();
         DataTable dt = new DataTable();
         OracleDataAdapter da = new OracleDataAdapter(q, con);
         da.Fill(dt);
             if (dt.Rows.Count > 0)
             {
                cCategoryCombo.DataSource = dt;
                cCategoryCombo.DisplayMember = "CATEGORY_NAME";
                cCategoryCombo.ValueMember = "CATEGORY_ID";
             }

         con.Close();
        }

        //Create tab - display list of equipment into createEquipmentListview
        public void displayCreateEquipmentListview(OracleConnection connection, ListView EquipList)
        {
            string q = "SELECT EQUIPMENT.EQUIPMENT_NAME, CATEGORY.CATEGORY_NAME, EQUIPMENT.PRODUCT_NO " +
                        "FROM EQUIPMENT " +
                        "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID";

            connection.Open();

            OracleCommand cmd = new OracleCommand(q, connection);

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["EQUIPMENT_NAME"].ToString());
                    item.SubItems.Add(dr["CATEGORY_NAME"].ToString());
                    item.SubItems.Add(dr["PRODUCT_NO"].ToString());

                    EquipList.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        //Create tab - display list of buildings into createBuildingListview
        public void displayCreateBuildingListview(OracleConnection connection, ListView BuildList)
        {
            string q = "SELECT BUILDING.BUILDING_NAME " +
                        "FROM BUILDING ";

            connection.Open();

            OracleCommand cmd = new OracleCommand(q, connection);

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(dr["BUILDING_NAME"].ToString());

                    BuildList.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

        }

        //Create tab - display list of rooms into createRoomListview
        public void displayCreateRoomListview(OracleConnection connection, ListView RoomList)
        {
            string q = "SELECT ROOM.ROOM_NAME " +
                        "FROM ROOM ";

            connection.Open();

            OracleCommand cmd = new OracleCommand(q, connection);

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(dr["ROOM_NAME"].ToString());

                    RoomList.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        //Create tab - Create buildings using combobox text and insert that data into database with insert query
        public void CreateBuilding(String cBuildText, ListView cBuildList)
        {
            if (String.IsNullOrEmpty(cBuildText))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                con.Open(); // Connects to DB
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "SELECT COUNT(*) FROM BUILDING WHERE BUILDING_NAME= '" + cBuildText + "' "; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    MessageBox.Show("Already exists!");
                    cBuildList.Refresh();
                    con.Close();
                }
                else
                {
                    //connection.Open(); // Connects to DB
                    OracleCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text; //Command to send to DB
                    cmd2.CommandText = "INSERT INTO BUILDING " +
                                        "(BUILDING_NAME) VALUES " +
                                        "('" + cBuildText + "' )"; // SQL Command
                    cmd2.ExecuteNonQuery(); //Execute command
                    //connection.Close(); //Close connection to DB

                    cBuildText = ""; //Clear textboxes

                    cBuildList.Refresh();
                    con.Close();
                    MessageBox.Show("Data inserted");
                }
            }
        }
    }
}
