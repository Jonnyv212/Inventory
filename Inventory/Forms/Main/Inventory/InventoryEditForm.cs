using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Inventory
{
    public partial class InventoryEditForm : Form
    {
        Main main = new Main();

        public OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        //private bool eqCheck;
        //private bool tmCheck;

        public InventoryEditForm()
        {
            InitializeComponent();
        }

        
        private void InventoryEditForm_Load(object sender, EventArgs e)
        {
            
        }
        /*
        public void LoadInventoryEdit(string rowID, string pName, string cName, string eName)
        {


            string query = "SELECT CATEGORY.CATEGORY_NAME, EQUIPMENT.EQUIPMENT_NAME, PROJECT.PROJECT_NAME, INVENTORY.TERM_ID, INVENTORY.INVENTORY_ID " +
                "FROM INVENTORY " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "WHERE INVENTORY.INVENTORY_ID = '" + rowID + "' ";

            string cat = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY ";
            string pj = "SELECT * FROM PROJECT ";




            main.ComboAddRowData(pj, "PROJECT_NAME", editInvenProjectCombobox);
            editInvenProjectCombobox.Text = pName;

            main.ComboAddRowData(cat, "CATEGORY_NAME", editInvenCategoryCombobox);
            editInvenCategoryCombobox.Text = cName;

            editInvenEquipCombobox.Text = eName;




            OracleCommand cmd = new OracleCommand(query, con);
            try
            {
                con.Open();

                using (OracleDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        editInvenTermIDTextbox.Text = (read["TERM_ID"].ToString());
                        editInvenIDTextbox.Text = (read["INVENTORY_ID"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        public void ReloadEquipmentEditData()
        {
            string eq = "SELECT EQUIPMENT_NAME " +
                        "FROM EQUIPMENT " +
                        "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                        "WHERE CATEGORY.CATEGORY_NAME = '" + editInvenCategoryCombobox.Text + "' ";

            main.ComboAddRowData(eq, "EQUIPMENT_NAME", editInvenEquipCombobox);

        }

        public void EditChecking(string query)
        {
            eqCheck = false;
            //CHECK DATABASE TO SEE IF EQUIPMENT EXISTS
            OracleCommand editCheck = con.CreateCommand();
            editCheck.CommandType = CommandType.Text;
            editCheck.CommandText = query;
            editCheck.ExecuteNonQuery(); //Execute command

            OracleDataAdapter eSda = new OracleDataAdapter(editCheck);
            DataTable eDt = new DataTable();
            eSda.Fill(eDt);
            //IF THE LOCATION DOES NOT EXIST THEN CREATE THAT LOCATION
            if (eDt.Rows[0][0].ToString() == "0") //Checks in DB if first column, first row equals 0
            {
                MessageBox.Show("Not a valid value");
            }
            else
            {
                eqCheck = true;
            }
        }

        public void EditTermIDCheck(string query)
        {
            tmCheck = false;
            //CHECK DATABASE TO SEE IF EQUIPMENT EXISTS
            OracleCommand editCheck = con.CreateCommand();
            editCheck.CommandType = CommandType.Text;
            editCheck.CommandText = query;
            editCheck.ExecuteNonQuery(); //Execute command

            OracleDataAdapter eSda = new OracleDataAdapter(editCheck);
            DataTable eDt = new DataTable();
            eSda.Fill(eDt);
            //IF THE LOCATION DOES NOT EXIST THEN CREATE THAT LOCATION
            if (eDt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 0
            {
                MessageBox.Show("TERM ID already exists in record");
            }
            else
            {
                tmCheck = true;
            }
        }

        private void editApplyButton_Click(object sender, EventArgs e)
        {
            string q1 = "SELECT COUNT(*) FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + editInvenEquipCombobox.Text + "' ";
            string q2 = "SELECT COUNT(*) FROM INVENTORY WHERE INVENTORY.TERM_ID = '" + editInvenTermIDTextbox.Text + "' AND INVENTORY.STATUS = '1' ";

            con.Open();

            EditChecking(q1);
            EditTermIDCheck(q2);

            if (eqCheck == true & tmCheck == true)
            {
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.EQUIPMENT_ID = (SELECT EQUIPMENT.EQUIPMENT_ID FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + editInvenEquipCombobox.Text + "'), " +
                    "INVENTORY.CATEGORY_ID = (SELECT CATEGORY.CATEGORY_ID FROM CATEGORY WHERE CATEGORY.CATEGORY_NAME = '" + editInvenCategoryCombobox.Text + "'), " +
                    "INVENTORY.PROJECT_ID = (SELECT PROJECT.PROJECT_ID FROM PROJECT WHERE PROJECT.PROJECT_NAME = '" + editInvenProjectCombobox.Text + "'), " +
                    "INVENTORY.TERM_ID = ('" + editInvenTermIDTextbox.Text + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + editInvenIDTextbox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command

                MessageBox.Show("Inventory ID: " + editInvenIDTextbox.Text + " was edited.");

                eqCheck = false;
                tmCheck = false;
            }
            con.Close();
        }

        private void editCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editInvenCategoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadEquipmentEditData();
        }
        */
    }
}
