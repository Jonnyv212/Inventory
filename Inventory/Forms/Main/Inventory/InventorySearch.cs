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
    class InventorySearch : Main
    {

        public void searchTextboxChanged(OracleConnection connection, string sCombobox, DataGridView dataGrid1, string sText)
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
                cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                    "EQUIPMENT.PRODUCT_NO AS Product, INVENTORY.INVENTORY_DATE AS InvDate " +
                    "FROM INVENTORY " +
                    "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "WHERE REGEXP_LIKE(" + filterCB + ", '(" + sText + ")', 'i') AND " +
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

        public void SearchComboFill(OracleConnection connection, ComboBox searchCombobox)
        {
            OracleCommand cmd = connection.CreateCommand();
            string w = "SELECT * FROM EQUIPMENT";


            DataTable dtNE = new DataTable();
            OracleDataAdapter daNE = new OracleDataAdapter(w, connection);
            daNE.Fill(dtNE);
            if (dtNE.Rows.Count > 0)
            {
                searchCombobox.DataSource = dtNE;
                searchCombobox.DisplayMember = "EQUIPMENT_NAME";
                searchCombobox.ValueMember = "EQUIPMENT_ID";

                connection.Close();
            }
        }
        //Search tab - Display data function with datagridview1
        public void Display_Search_Data(OracleConnection connection, DataGridView dataGrid)
        {
            connection.Open();
            dataGrid.DataSource = null;
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                    "EQUIPMENT.PRODUCT_NO AS Product, INVENTORY.INVENTORY_DATE AS InvDate " +
                    "FROM INVENTORY " +
                    "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "WHERE INVENTORY.STATUS = '1' " +
                    "ORDER BY cast(INVENTORY_ID AS int) desc ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGrid.DataSource = dta;

            connection.Close();
        }

        public void Display_Search_InformationTextbox(OracleConnection connection, string sInfo_ID, string infoTextbox)
        {
            string searchUser = "SELECT LOGIN.USERNAME FROM INVENTORY JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID WHERE INVENTORY.INVENTORY_ID = '" + sInfo_ID + "' AND ROWNUM  <= 1";
            string searchCategory = "SELECT CATEGORY.CATEGORY_NAME FROM INVENTORY JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID WHERE INVENTORY.INVENTORY_ID = '" + sInfo_ID + "' AND ROWNUM  <= 1";
            string searchLocation = "SELECT (BUILDING.BUILDING_NAME || '-' || ROOM.ROOM_NAME) AS Location FROM INVENTORY JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID WHERE INVENTORY.INVENTORY_ID = '" + sInfo_ID + "' AND ROWNUM  <= 1";
            string searchDate = "SELECT INVENTORY.INVENTORY_DATE FROM INVENTORY WHERE INVENTORY.INVENTORY_ID = '" + sInfo_ID + "' AND ROWNUM  <= 1";
            string q = "SELECT INVENTORY_DESCRIPTION.DESCRIPTION FROM INVENTORY_DESCRIPTION " +
                        "JOIN INVENTORY ON INVENTORY.DESCRIPTION_ID = INVENTORY_DESCRIPTION.DESCRIPTION_ID " +
                        "WHERE INVENTORY.INVENTORY_ID = '" + sInfo_ID + "' AND ROWNUM <= 1";

            con.Open();

            OracleCommand cmd = new OracleCommand(q, con);
            OracleCommand cmd1 = new OracleCommand(searchUser, con);
            OracleCommand cmd2 = new OracleCommand(searchCategory, con);
            OracleCommand cmd3 = new OracleCommand(searchLocation, con);
            OracleCommand cmd4 = new OracleCommand(searchDate, con);

            String sUserValue = cmd1.ExecuteScalar().ToString();
            String sCategoryValue = cmd2.ExecuteScalar().ToString();
            String sLocationValue = cmd3.ExecuteScalar().ToString();
            String sDateValue = cmd4.ExecuteScalar().ToString();


            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    infoTextbox = (dr["DESCRIPTION"].ToString() + "\n\n\n" + "Username: " + sUserValue + "\n\n" + "Category: " + sCategoryValue + "\n\n" + "Location: " + sLocationValue + "\n\n" + "Date: " + sDateValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }
    }
}
