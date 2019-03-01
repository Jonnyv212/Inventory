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

        Main main = new Main();

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

        private void plabel19_MouseDown(object sender, MouseEventArgs e)
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

            string cat = "SELECT * FROM CATEGORY ORDER BY CATEGORY_NAME ASC";
            string pj = "SELECT * FROM PROJECT ";


            main.ComboAddRowData(pj, "PROJECT_NAME", addInvenProjectCombobox);
            addInvenProjectCombobox.SelectedIndex = 0;

            main.ComboAddRowData(cat, "CATEGORY_NAME", addInvenCategoryCombobox);
            addInvenCategoryCombobox.SelectedIndex = 0;



            ReloadEquipmentAddData();
        }

        public void ReloadEquipmentAddData()
        {
            string eq = "SELECT * " +
                        "FROM EQUIPMENT " +
                        "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                        "WHERE CATEGORY.CATEGORY_NAME = '" + addInvenCategoryCombobox.Text + "' ";

            main.AutofillInventoryTextbox(con, eq, "EQUIPMENT_NAME", addInvenEquipTextbox);

        }


        public void OnInsertClick()
        {
            Main main = new Main();
            TextBox iEquipText = addInvenEquipTextbox;
            TextBox iQuanText = addInvenQuantityTextbox;
            ComboBox iProjectCombo = addInvenProjectCombobox;

            //Inventory tab - If any of the comboboxes are empty then show messagebox
            if (string.IsNullOrEmpty(iEquipText.Text) || string.IsNullOrEmpty(iQuanText.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                string loginUser = Login.user;
                int quantity = Convert.ToInt32(iQuanText.Text);

                con.Open(); // Connects to DB

                //ADD NEW INVENTORY MULTIPLE TIMES BASED ON TEXTBOX DATA AND QUANTITY
                for (int i = 0; i < quantity; i++)
                {
                    if (string.IsNullOrEmpty(iProjectCombo.Text))
                    {
                        iProjectCombo.Text = "1";
                    }
                    OracleCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO INVENTORY (EQUIPMENT_ID, CATEGORY_ID, EVENT_ID, PROJECT_ID) " +
                        "SELECT " +
                        "(SELECT EQUIPMENT_ID " +
                        "FROM EQUIPMENT " +
                        "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + iEquipText.Text + "') " +
                        "AS EQUIPMENT_ID," +

                        "(SELECT EQUIPMENT.CATEGORY_ID " +
                        "FROM CATEGORY " +
                        "JOIN EQUIPMENT ON EQUIPMENT.CATEGORY_ID = CATEGORY.CATEGORY_ID " +
                        "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + iEquipText.Text + "') " +
                        "AS CATEGORY_ID, " +

                        "(SELECT EVENT_ID " +
                        "FROM EVENT " +
                        "WHERE EVENT.EVENT_ID = 1) " +
                        "AS EVENT_ID, " +

                        "(SELECT PROJECT_ID " +
                        "FROM PROJECT " +
                        "WHERE PROJECT.PROJECT_NAME = '" + iProjectCombo.Text + "') " +
                        "AS PROJECT_ID " +

                        "FROM DUAL";

                    cmd.ExecuteNonQuery(); //Execute command
                }
                con.Close(); //Close connection to DB

                MessageBox.Show("Data inserted successfully!");
            }
        }

        private void insertAddInventoryButton_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            OnInsertClick();
            //main.DisplayInventory();
            this.Close();
        }

        private void clearAddInventoryButton_Click(object sender, EventArgs e)
        {
          addInvenEquipTextbox.Text = "";
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

        private void mainClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
