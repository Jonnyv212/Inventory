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
    class InventoryAdd : Main
    {
        //TakeInventory tab - Function that loads data into TakeInventory tab comboboxes
        public void TakeInventoryComboBoxData(OracleConnection con, ComboBox iEquipCombo, ComboBox iBldCombo, ComboBox iRoomCombo, ComboBox iCatCombo)
        {
            //Queries for adapters
            string e = "SELECT * FROM EQUIPMENT";
            string b = "SELECT * FROM BUILDING";
            string r = "SELECT * FROM ROOM";
            string c = "SELECT * FROM CATEGORY";


            con.Open();

            //Display queried data within combobox
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(e, con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //tInvenEquipmentCombobox
                iEquipCombo.DataSource = dt;
                iEquipCombo.DisplayMember = "EQUIPMENT_NAME";
                iEquipCombo.ValueMember = "EQUIPMENT_ID";
                con.Close();
            }
            //Display queried data within combobox
            DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter(b, con);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                iBldCombo.DataSource = dt2;
                iBldCombo.DisplayMember = "BUILDING_NAME";
                iBldCombo.ValueMember = "BUILDING_ID";
                con.Close();
            }
            //Display queried data within combobox
            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter(c, con);
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                iCatCombo.DataSource = dt3;
                iCatCombo.DisplayMember = "CATEGORY_NAME";
                iCatCombo.ValueMember = "CATEGORY_ID";
                con.Close();
            }
            //Display queried data within combobox
            DataTable dt4 = new DataTable();
            OracleDataAdapter da4 = new OracleDataAdapter(r, con);
            da4.Fill(dt4);
            if (dt2.Rows.Count > 0)
            {
                iRoomCombo.DataSource = dt4;
                iRoomCombo.DisplayMember = "ROOM_NAME";
                iRoomCombo.ValueMember = "ROOM_ID";
                con.Close();
            }
        }


        public void clear_data(ComboBox iEquipText, ComboBox iBldText, ComboBox iRoomText, ComboBox iCatText, TextBox iQuanText, CheckBox DescCheckbox)
        {
            //Clear Comboboxes
            iEquipText.Text = "";
            iBldText.Text = "";
            iRoomText.Text = "";
            iCatText.Text = "";
            iQuanText.Text = "";
            DescCheckbox.Checked = false;
        }


        public void OnInsertClick(OracleConnection con, String iEquipText, String iBldText, String iCatText, String iQuanText, String iRoomText, CheckBox descCheckbox)
        {
            DescriptionInsert descForm = new DescriptionInsert();
            Main main = new Main();

            //Inventory tab - If any of the comboboxes are empty then show messagebox
            if (string.IsNullOrEmpty(iEquipText) || string.IsNullOrEmpty(iBldText) || string.IsNullOrEmpty(iCatText) || string.IsNullOrEmpty(iQuanText))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                string loginUser = Login.user;
                int quantity = Convert.ToInt32(iQuanText);

                con.Open(); // Connects to DB


                OracleCommand locCheck = con.CreateCommand();
                locCheck.CommandType = CommandType.Text;
                locCheck.CommandText = "SELECT COUNT(*) FROM LOCATION " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE BUILDING.BUILDING_NAME = '" + iBldText + "' " +
                    "AND ROOM.ROOM_NAME = '" + iRoomText + "' ";
                locCheck.ExecuteNonQuery(); //Execute command

                OracleDataAdapter locSda = new OracleDataAdapter(locCheck);
                DataTable locDt = new DataTable();
                locSda.Fill(locDt);
                if (locDt.Rows[0][0].ToString() == "0") //Checks in DB if first column, first row equals 0
                {
                    OracleCommand locIns = con.CreateCommand();
                    locIns.CommandType = CommandType.Text;
                    locIns.CommandText = "INSERT INTO LOCATION (BUILDING_ID, ROOM_ID)" +
                        "VALUES((SELECT BUILDING.BUILDING_ID FROM BUILDING WHERE BUILDING.BUILDING_NAME = '" + iBldText + "' ), " +
                        "(SELECT ROOM.ROOM_ID FROM ROOM WHERE ROOM.ROOM_NAME = '" + iRoomText + "' )) ";

                    locIns.ExecuteNonQuery();

                    MessageBox.Show("New location inserted!");
                }


                OracleCommand descIns = con.CreateCommand();

                descIns.CommandType = CommandType.Text;
                descIns.CommandText = "INSERT INTO INVENTORY_DESCRIPTION " +
                    "(DESCRIPTION) " +
                    "VALUES('No Description.') " +
                    "RETURNING DESCRIPTION_ID INTO :desc_id ";
                OracleParameter outputParameter = new OracleParameter("desc_id", OracleDbType.Decimal);
                outputParameter.Direction = ParameterDirection.Output;
                descIns.Parameters.Add(outputParameter);
                descIns.ExecuteNonQuery();


                for (int i = 0; i< quantity; i++)
                {
                    OracleCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO INVENTORY (EQUIPMENT_ID, CATEGORY_ID, EVENT_ID, USER_ID, LOCATION_ID, DESCRIPTION_ID)" +
                        "SELECT " +
                        "(SELECT EQUIPMENT_ID " +
                        "FROM EQUIPMENT " +
                        "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + iEquipText + "') " +
                        "AS EQUIPMENT_ID," +

                        "(SELECT CATEGORY_ID " +
                        "FROM CATEGORY " +
                        "WHERE CATEGORY.CATEGORY_NAME = '" + iCatText + "') " +
                        "AS CATEGORY_ID, " +

                        "(SELECT EVENT_ID " +
                        "FROM EVENT " +
                        "WHERE EVENT.EVENT_ID = 1) " +
                        "AS EVENT_ID, " +

                        "(SELECT USER_ID " +
                        "FROM LOGIN " +
                        "WHERE LOGIN.USERNAME = '" + loginUser + "' ) " +
                        "AS USER_ID, " +

                        "(SELECT LOCATION_ID " +
                        "FROM LOCATION " +
                        "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                        "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                        "WHERE BUILDING.BUILDING_NAME = '" + iBldText + "' " +
                        "AND ROOM.ROOM_NAME = '" + iRoomText + "') " +
                        "AS LOCATION_ID, " +


                        "(SELECT  ('" + descIns.Parameters["desc_id"].Value + "') " +
                        "AS DESCRIPTION_ID " +
                        "FROM DUAL )" +

                        "FROM DUAL";

                    cmd.ExecuteNonQuery(); //Execute command

                    descForm.descID = descIns.Parameters["desc_id"].Value.ToString();

                    Console.WriteLine("descForm.descID: " + descForm.descID);
                    Console.WriteLine("descIns.desc_id: " + descIns.Parameters["desc_id"].Value);
                    if (descCheckbox.Checked == true)
                    {
                        descForm.Show();
                        main.Hide();
                    }

                }

                con.Close(); //Close connection to DB

                //display_inventory_data();
                //MessageBox.Show("Data inserted successfully!");
            }
        }


    }
}
