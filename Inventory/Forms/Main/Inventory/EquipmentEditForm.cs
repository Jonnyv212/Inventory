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

namespace Inventory
{
    public partial class EquipmentEditForm : Form
    {
        public OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        private bool mouseDown;
        private Point lastLocation;

        //Main main = new Main();
        //Barcode barcode = new Barcode();

        public EquipmentEditForm()
        {
            InitializeComponent();
        }

        private void EquipmentNewForm_Load(object sender, EventArgs e)
        {
            string cat = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY ";

            Main.ComboAddRowData(cat, "CATEGORY_NAME", equipCategoryCombobox);
            equipCategoryCombobox.Text = "Desktop";
            Barcode.DisplayEquipment(EquipmentDataGrid2);
            FillEditEquipment(equipCategoryCombobox, equipTextbox, equipProductTextbox, EquipmentDataGrid2);

            EquipmentDataGrid2.EnableHeadersVisualStyles = false;
        }

        private void equipCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void mainClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEquipment();
        }

        public void DeleteEquipment()
        {
            string query = "UPDATE EQUIPMENT SET EQUIPMENT.STATUS = 0 WHERE EQUIPMENT_NAME = '" + EquipmentDataGrid2.SelectedRows[0].Cells[1].Value.ToString() + "' ";
            string checkQuery = "SELECT COUNT(INVENTORY.EQUIPMENT_ID) FROM INVENTORY JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "WHERE EQUIPMENT_NAME = '" + EquipmentDataGrid2.SelectedRows[0].Cells[1].Value.ToString() + "' AND INVENTORY.STATUS = '1' ";

            if (Convert.ToInt32(Main.DataTableSQLQuery(checkQuery).Rows[0][0]) > 0)
            {
                MessageBox.Show((Convert.ToInt32(Main.DataTableSQLQuery(checkQuery).Rows[0][0])) +" Inventory records exist with equipment: \n" + 
                    EquipmentDataGrid2.SelectedRows[0].Cells[1].Value.ToString() +
                    "\nDelete the inventory records or change their equipment to continue.");
            }
            else
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this equipment?",
                                                     "Confirm Delete!",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Main.RunSQLQuery(query);
                    MessageBox.Show("Data deleted successfully!");
                }
            }
        }

        public void EditEquipment(ComboBox Category, TextBox Equipment, TextBox Product, DataGridView dGriView)
        {
            string query = "UPDATE EQUIPMENT SET EQUIPMENT.CATEGORY_ID = (SELECT CATEGORY.CATEGORY_ID FROM CATEGORY WHERE CATEGORY.CATEGORY_NAME = '"+ Category.Text +"' ), " +
                            "EQUIPMENT.EQUIPMENT_NAME = '"+ Equipment.Text +"', " +
                            "EQUIPMENT.PRODUCT_NO = '"+ Product.Text +"' " +
                            "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + EquipmentDataGrid2.SelectedRows[0].Cells[1].Value.ToString() + "' ";

            string checkQuery = "SELECT COUNT(EQUIPMENT.EQUIPMENT_NAME) FROM EQUIPMENT " +
                                "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + Equipment.Text + "' AND EQUIPMENT.STATUS = '1' ";


            string checkEquipmentQuery = "SELECT COUNT(INVENTORY.EQUIPMENT_ID) FROM INVENTORY JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                                 "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + EquipmentDataGrid2.SelectedRows[0].Cells[1].Value.ToString() + "' AND INVENTORY.STATUS = '1' ";

            string checkProductQuery = "SELECT COUNT(INVENTORY.EQUIPMENT_ID) FROM INVENTORY JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                                       "WHERE EQUIPMENT.PRODUCT_NO = '" + EquipmentDataGrid2.SelectedRows[0].Cells[2].Value.ToString() + "' AND INVENTORY.STATUS = '1' ";

            // Check if equipment in textbox already exists.
                // Check if any Equipment name or Product Number are attached to any inventory records.
                if (Convert.ToInt32(Main.DataTableSQLQuery(checkEquipmentQuery).Rows[0][0]) > 0 || Convert.ToInt32(Main.DataTableSQLQuery(checkProductQuery).Rows[0][0]) > 0)
                {
                    var confirmResult = MessageBox.Show("All inventory records with equipment: " + EquipmentDataGrid2.SelectedRows[0].Cells[1].Value.ToString() +
                        " will be edited. Continue?",
                                         "Confirm!",
                                         MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        History.HistoryEquipmentEdit("Category:[" + EquipmentDataGrid2.SelectedRows[0].Cells[0].Value.ToString() + "], " +
                                                    "Equipment: [" + EquipmentDataGrid2.SelectedRows[0].Cells[1].Value.ToString()+ "], " +
                                                    "Code: ["+ EquipmentDataGrid2.SelectedRows[0].Cells[2].Value.ToString() + "] " +
                                                    "changed to " +Category.Text+ ", " + Equipment.Text + ", " + Product.Text + ".");
                        Main.RunSQLQuery(query);
                        MessageBox.Show("Data edited successfully!");
                    }
                }
                else
                {
                    History.HistoryEquipmentEdit("Category:[" + EquipmentDataGrid2.SelectedRows[0].Cells[0].Value.ToString() + "], " +
                                                "Equipment: [" + EquipmentDataGrid2.SelectedRows[0].Cells[1].Value.ToString() + "], " +
                                                "Code: [" + EquipmentDataGrid2.SelectedRows[0].Cells[2].Value.ToString() + "] " +
                                                "changed to " + Category.Text + ", " + Equipment.Text + ", " + Product.Text + ".");
                    Main.RunSQLQuery(query);
                    MessageBox.Show("Data edited successfully!");
                }
            
        }

        private void mainClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EquipmentDataGrid2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.EquipmentDataGrid2.ClearSelection();
                    this.EquipmentDataGrid2.Rows[rowSelected].Selected = true;
                }
            } 
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditEquipment(equipCategoryCombobox, equipTextbox, equipProductTextbox, EquipmentDataGrid2);
        }

        private void EquipmentDataGrid2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void EquipmentDataGrid2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillEditEquipment(equipCategoryCombobox, equipTextbox, equipProductTextbox, EquipmentDataGrid2);
        }

        public void FillEditEquipment(ComboBox Category, TextBox Equipment, TextBox Product, DataGridView dGriView)
        {
            Category.Text = dGriView.SelectedRows[0].Cells[0].Value.ToString();
            Equipment.Text = dGriView.SelectedRows[0].Cells[1].Value.ToString();
            Product.Text = dGriView.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
