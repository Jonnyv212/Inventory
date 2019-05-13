using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class EquipmentAddForm : Form
    {
       // Main main = new Main();
        private bool mouseDown;
        private Point lastLocation;

        public EquipmentAddForm()
        {
            InitializeComponent();
        }

        private void EquipmentEditForm_Load(object sender, EventArgs e)
        {
            string cat = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY ";

            Main.ComboAddRowData(cat, "CATEGORY_NAME", equipCategoryCombobox);
            equipCategoryCombobox.Text = "Desktop";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(equipTextbox.Text) || string.IsNullOrEmpty(equipProductTextbox.Text))
            {
                MessageBox.Show("Fill in the data.");
            }
            else
            {
                string checkQuery = "SELECT COUNT(*) FROM EQUIPMENT WHERE EQUIPMENT.STATUS = '1' AND (EQUIPMENT_NAME= '" + equipTextbox.Text + "' OR PRODUCT_NO= '" + equipProductTextbox.Text + "' )";
                string query = "INSERT INTO EQUIPMENT (EQUIPMENT_NAME, PRODUCT_NO, CATEGORY_ID)" +
                                "VALUES('" + equipTextbox.Text + "', '" + equipProductTextbox.Text + "', (SELECT CATEGORY_ID FROM CATEGORY WHERE CATEGORY_NAME = '" + equipCategoryCombobox.Text + "') ) ";

                if (Main.DataTableSQLQuery(checkQuery).Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    MessageBox.Show("Already exists!");
                    equipTextbox.Text = "";
                    equipProductTextbox.Text = "";
                }
                else
                {
                    History.HistoryEquipmentAdd(" New equipment added: [" + equipCategoryCombobox.Text + "], [" + equipTextbox.Text + "], [" + equipProductTextbox.Text + "].");
                    Main.RunSQLQuery(query);

                    MessageBox.Show("New equipment created!");

                    equipTextbox.Text = "";
                    equipProductTextbox.Text = "";
                }
            }
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
    }
}
