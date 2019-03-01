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
    public partial class EquipmentNewForm : Form
    {
        public OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        private bool mouseDown;
        private Point lastLocation;

        Main main = new Main();
        Barcode barcode = new Barcode();

        public EquipmentNewForm()
        {
            InitializeComponent();
        }

        private void EquipmentNewForm_Load(object sender, EventArgs e)
        {
            string cat = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY ";

            main.ComboAddRowData(cat, "CATEGORY_NAME", equipCategoryCombobox);
            equipCategoryCombobox.Text = "Desktop";

            EquipmentDataGrid2.EnableHeadersVisualStyles = false;
        }

        private void equipCategoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
           barcode.DisplayEquipment(EquipmentDataGrid2);
        }

        private void equipCreateButton_Click(object sender, EventArgs e)
        {
            con.Open();

            if (string.IsNullOrEmpty(equipTextbox.Text) || string.IsNullOrEmpty(equipProductTextbox.Text))
            {
                MessageBox.Show("Fill in the data.");
            }
            else
            {
                OracleCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text; //Command to send to DB
                cmd1.CommandText = "SELECT COUNT(*) FROM EQUIPMENT WHERE EQUIPMENT_NAME= '" + equipTextbox.Text + "' OR PRODUCT_NO= '" + equipProductTextbox.Text + "' "; // SQL Command
                cmd1.ExecuteNonQuery(); //Execute command
                OracleDataAdapter sda = new OracleDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    MessageBox.Show("Already exists!");
                    con.Close();
                }
                else
                {
                    OracleCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO EQUIPMENT (EQUIPMENT_NAME, PRODUCT_NO, CATEGORY_ID)" +
                              "VALUES('" + equipTextbox.Text + "', '" + equipProductTextbox.Text + "', (SELECT CATEGORY_ID FROM CATEGORY WHERE CATEGORY_NAME = '" + equipCategoryCombobox.Text + "') ) ";

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("New equipment created!");

                    equipTextbox.Text = "";
                    equipProductTextbox.Text = "";
                }
            }
            //main.DisplayEquipment(equipCategoryCombobox.Text, EquipmentDataGrid2);
            con.Close();
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
