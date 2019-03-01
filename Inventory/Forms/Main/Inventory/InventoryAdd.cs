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
        /*
        //TakeInventory tab - Function that loads data into TakeInventory tab comboboxes
        public void AddInventoryTextboxData(OracleConnection connection, TextBox iEquipCombo, TextBox iBldCombo, TextBox iRoomCombo)
        {
            //Queries for adapters
            string e = "SELECT * FROM EQUIPMENT";
            string b = "SELECT * FROM BUILDING";
            string r = "SELECT * FROM ROOM";
            //string c = "SELECT * FROM CATEGORY";


            connection.Open();

            //Display queried data within combobox
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(e, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //tInvenEquipmentCombobox
                iEquipCombo.DataSource = dt;
                iEquipCombo.DisplayMember = "EQUIPMENT_NAME";
                iEquipCombo.ValueMember = "EQUIPMENT_ID";
                connection.Close();
            }
            //Display queried data within combobox
            DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter(b, connection);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                iBldCombo.DataSource = dt2;
                iBldCombo.DisplayMember = "BUILDING_NAME";
                iBldCombo.ValueMember = "BUILDING_ID";
                connection.Close();
            }
            
            //Display queried data within combobox
            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter(c, connection);
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                iCatCombo.DataSource = dt3;
                iCatCombo.DisplayMember = "CATEGORY_NAME";
                iCatCombo.ValueMember = "CATEGORY_ID";
                connection.Close();
            }
            
            //Display queried data within combobox
            DataTable dt4 = new DataTable();
            OracleDataAdapter da4 = new OracleDataAdapter(r, connection);
            da4.Fill(dt4);
            if (dt2.Rows.Count > 0)
            {
                iRoomCombo.DataSource = dt4;
                iRoomCombo.DisplayMember = "ROOM_NAME";
                iRoomCombo.ValueMember = "ROOM_ID";
                connection.Close();
            }
        }
*/




        public void clear_data(ComboBox iEquipText, ComboBox iBldText, ComboBox iRoomText, TextBox iQuanText)
        {
            //Clear Comboboxes
            iEquipText.Text = "";
            iBldText.Text = "";
            iRoomText.Text = "";
            iQuanText.Text = "";
        }


        public void OnInsertClick(OracleConnection connection, String iEquipText, String iBldText, String iQuanText, String iRoomText)
        {
            DescriptionInsert descForm = new DescriptionInsert();
            Main main = new Main();

            //Inventory tab - If any of the comboboxes are empty then show messagebox
            if (string.IsNullOrEmpty(iEquipText) || string.IsNullOrEmpty(iBldText) ||  string.IsNullOrEmpty(iQuanText))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                string loginUser = Login.user;
                int quantity = Convert.ToInt32(iQuanText);

                connection.Open(); // Connects to DB


                //CHECK DATABASE TO SEE IF LOCATION EXISTS
                OracleCommand locCheck = connection.CreateCommand();
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
                //IF THE LOCATION DOES NOT EXIST THEN CREATE THAT LOCATION
                if (locDt.Rows[0][0].ToString() == "0") //Checks in DB if first column, first row equals 0
                {
                    OracleCommand locIns = connection.CreateCommand();
                    locIns.CommandType = CommandType.Text;
                    locIns.CommandText = "INSERT INTO LOCATION (BUILDING_ID, ROOM_ID)" +
                        "VALUES((SELECT BUILDING.BUILDING_ID FROM BUILDING WHERE BUILDING.BUILDING_NAME = '" + iBldText + "' ), " +
                        "(SELECT ROOM.ROOM_ID FROM ROOM WHERE ROOM.ROOM_NAME = '" + iRoomText + "' )) ";

                    locIns.ExecuteNonQuery();

                    MessageBox.Show("New location inserted!");
                }

                //INCLUDE A DESCRIPTION
                OracleCommand descIns = connection.CreateCommand();

                descIns.CommandType = CommandType.Text;
                descIns.CommandText = "INSERT INTO INVENTORY_DESCRIPTION " +
                    "(DESCRIPTION) " +
                    "VALUES('No Description.') " +
                    "RETURNING DESCRIPTION_ID INTO :desc_id ";
                OracleParameter outputParameter = new OracleParameter("desc_id", OracleDbType.Decimal);
                outputParameter.Direction = ParameterDirection.Output;
                descIns.Parameters.Add(outputParameter);
                descIns.ExecuteNonQuery();

                //ADD NEW INVENTORY MULTIPLE TIMES BASED ON COMBOBOX DATA AND QUANTITY
                for (int i = 0; i< quantity; i++)
                {
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO INVENTORY (EQUIPMENT_ID, CATEGORY_ID, EVENT_ID, USER_ID, LOCATION_ID, DESCRIPTION_ID)" +
                        "SELECT " +
                        "(SELECT EQUIPMENT_ID " +
                        "FROM EQUIPMENT " +
                        "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + iEquipText + "') " +
                        "AS EQUIPMENT_ID," +

                        "(SELECT CATEGORY_ID " +
                        "FROM CATEGORY " +
                        "JOIN EQUIPMENT ON EQUIPMENT.CATEGORY_ID = CATEGORY.CATEGORY_ID " +
                        "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + iEquipText + "') " +
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

                    /*
                    //IF DESCRIPTION CHECKBOX IS CHECKED THEN OPEN A NEW WINDOW TO EDIT THAT DESCRIPTION
                    if (descCheckbox.Checked == true)
                    {
                        descForm.Show();
                        main.Hide();
                    } */
                }

                connection.Close(); //Close connection to DB

                MessageBox.Show("Data inserted successfully!");
            }
        }

        public void Display_ProjectsInAdd(OracleConnection connection, DataGridView dataGrid)
        {
            connection.Open();

            dataGrid.DataSource = null;
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PROJECT_NAME as Project, TICKET_NO as Ticket, COUNT(INVENTORY.EQUIPMENT_ID) AS Stock " +
                "FROM PROJECT " +
                "LEFT JOIN INVENTORY ON INVENTORY.PROJECT_ID = PROJECT.PROJECT_ID " +
                "WHERE INVENTORY.STATUS = '1' " +
                "GROUP BY PROJECT_NAME, TICKET_NO";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGrid.DataSource = dta;

            connection.Close();

        }
    }
}
