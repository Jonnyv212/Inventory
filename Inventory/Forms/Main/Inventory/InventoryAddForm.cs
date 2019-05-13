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
    public partial class InventoryAddForm : Form
    {
        public OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        private bool mouseDown;
        private Point lastLocation;

        //Main main = new Main();

        public InventoryAddForm()
        {
            InitializeComponent();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }


        private void label19_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label19_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label19_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;


        }
        private void InventoryAddForm_Load(object sender, EventArgs e)
        {

            string cat = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY JOIN EQUIPMENT ON EQUIPMENT.CATEGORY_ID = CATEGORY.CATEGORY_ID " +
                "WHERE EQUIPMENT.STATUS = 1 GROUP BY CATEGORY_NAME ORDER BY CATEGORY_NAME ASC";
            string pj = "SELECT * FROM PROJECT WHERE PROJECT.STATUS = '1' ";


            Main.ComboAddRowData(pj, "PROJECT_NAME", addInvenProjectCombobox);
            addInvenProjectCombobox.SelectedIndex = 0;

            Main.ComboAddRowData(cat, "CATEGORY_NAME", addInvenCategoryCombobox);
            addInvenCategoryCombobox.SelectedIndex = 0;



            ReloadEquipmentAddData();
        }

        public void ReloadEquipmentAddData()
        {
            string eq = "SELECT * " +
                        "FROM EQUIPMENT " +
                        "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                        "WHERE CATEGORY.CATEGORY_NAME = '" + addInvenCategoryCombobox.Text + "' AND EQUIPMENT.STATUS = '1' ";

            Main.ComboAddRowData(eq, "EQUIPMENT_NAME", addInvenEquipmentCombo);
            addInvenEquipmentCombo.SelectedIndex = 0;
            /*
            if ((addInvenEquipmentCombo.SelectedIndex == -1))
            {
                //addInvenEquipmentCombo.SelectedIndex = 0;
                MessageBox.Show("Empty");
            }
            else
            {
                //addInvenEquipmentCombo.SelectedIndex = 0;
            } */

        }


        public void OnInsertClick()
        {
            ComboBox iEquipCombo = addInvenEquipmentCombo;
            TextBox iQuanText = addInvenQuantityTextbox;
            ComboBox iProjectCombo = addInvenProjectCombobox;
            ComboBox iCategoryCombo = addInvenCategoryCombobox;


            bool equipCheck = false;

            string query = "INSERT INTO INVENTORY (EQUIPMENT_ID, EVENT_ID, PROJECT_ID) " +
                            "SELECT " +
                            "(SELECT EQUIPMENT_ID " +
                            "FROM EQUIPMENT " +
                            "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + addInvenEquipmentCombo.Text + "') " +
                            "AS EQUIPMENT_ID," +

                            "(SELECT EVENT_ID " +
                            "FROM EVENT " +
                            "WHERE EVENT.EVENT_ID = '1') " +
                            "AS EVENT_ID, " +

                            "(SELECT PROJECT_ID " +
                            "FROM PROJECT " +
                            "WHERE PROJECT.PROJECT_NAME = '" + iProjectCombo.Text + "' AND PROJECT.STATUS = '1') " +
                            "AS PROJECT_ID " +

                            "FROM DUAL";

            string queryCheck = "SELECT COUNT(*) FROM EQUIPMENT " +
                                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                                "WHERE EQUIPMENT_NAME = '" + addInvenEquipmentCombo.Text + "' AND CATEGORY.CATEGORY_NAME = '"+ iCategoryCombo.Text +"' AND EQUIPMENT.STATUS = '1' ";


            DataTable dt = new DataTable();
            dt = Main.DataTableSQLQuery(queryCheck);
            if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
            {
                equipCheck = true;
            }
            if (string.IsNullOrEmpty(addInvenEquipmentCombo.Text) || string.IsNullOrEmpty(iQuanText.Text) || equipCheck == false)
            {
                if(equipCheck == false)
                {
                    MessageBox.Show("Equipment does not exist.");
                }
                else
                {
                    MessageBox.Show("Please fill in the appropriate data.");
                }
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(iQuanText.Text, "^[0-9]") && (int.Parse(iQuanText.Text) > 0)) //&& (int.TryParse(iQuanText.Text, out quantity)))
                {

                    //ADD NEW INVENTORY MULTIPLE TIMES BASED ON TEXTBOX DATA AND QUANTITY
                    for (int i = 0; i < int.Parse(iQuanText.Text); i++)
                    {
                        if (string.IsNullOrEmpty(iProjectCombo.Text))
                        {
                            iProjectCombo.Text = "1";
                        }
                        Main.RunSQLQuery(query);
                    }
                    MessageBox.Show("Data inserted successfully!");
                    equipCheck = false;
                }
                else
                {
                    MessageBox.Show("Not a valid quantity");
                }
            }
        }

        private void insertAddInventoryButton_Click(object sender, EventArgs e)
        {
            //Main main = new Main();
            OnInsertClick();
            History.HistoryManualInsert(addInvenEquipmentCombo, addInvenQuantityTextbox, addInvenProjectCombobox);
            addInvenEquipmentCombo.Text = "";
            addInvenQuantityTextbox.Text = "";
            addInvenProjectCombobox.Text = "";
        }

        private void clearAddInventoryButton_Click(object sender, EventArgs e)
        {
          addInvenEquipmentCombo.Text = "";
          addInvenQuantityTextbox.Text = "";
        }

        private void addInvenCategoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadEquipmentAddData();
        }

        private void closeAddInventoryButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }


        private void mainClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
