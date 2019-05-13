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


namespace Inventory.old
{
    public partial class Barcode : Form
    {
        OracleConnection connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");

        public old_Barcode()
        {
            InitializeComponent();
        }

        private void Barcode_Load(object sender, EventArgs e)
        {

        }

        private void barcodeTextbox_TextChanged(object sender, EventArgs e)
        {
            
        }




        private void quantityTextbox_TextChanged(object sender, EventArgs e)
        {
                if (System.Text.RegularExpressions.Regex.IsMatch(quantityTextbox.Text, "[^1-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    quantityTextbox.Text = "1";
                }
                else
                {
                    if (String.IsNullOrEmpty(quantityTextbox.Text))
                    {
                        barcodeTextbox.Enabled = false;
                    }
                    else
                    { 
                        int quan = int.Parse(quantityTextbox.Text);
                        if (quan > 0)
                        {
                            barcodeTextbox.Enabled = true;
                        }
                        else
                        {
                            barcodeTextbox.Enabled = false;
                        }
                    }
                }
        }

        private void quantityTextbox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Return) && (barcodeTextbox.Enabled = true))
            {
                barcodeTextbox.Focus();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            quantityTextbox.Text = "1";
            barcodeTextbox.Clear();
            barcodeTextbox.Enabled = false;
            dataGridView1.Rows.Clear();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            string loginUser = Login.user;
            DescriptionInsert descForm = new DescriptionInsert();

            if (String.IsNullOrEmpty(dataGridView1.Rows[0].Cells[0].Value as String))
            {
                MessageBox.Show("No data");
                return;
            }
            else
            {
                connection.Open(); // Connects to DB

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                  
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO INVENTORY (EQUIPMENT_ID, CATEGORY_ID, EVENT_ID, PROJECT_ID)" +
                                       "SELECT " +
                                       "(SELECT EQUIPMENT_ID FROM EQUIPMENT WHERE EQUIPMENT.EQUIPMENT_NAME = '" + dataGridView1.Rows[i].Cells[0].Value + "') " +
                                       "AS EQUIPMENT_ID," +

                                       "(SELECT CATEGORY_ID FROM CATEGORY WHERE CATEGORY.CATEGORY_NAME = '" + dataGridView1.Rows[i].Cells[1].Value + "') " +
                                       "AS CATEGORY_ID, " +

                                       "(SELECT EVENT_ID FROM EVENT WHERE EVENT.EVENT_ID = 1) " +
                                       "AS EVENT_ID " +

                                       "FROM DUAL";

                    cmd.ExecuteNonQuery(); //Execute command

                    //descForm.descID = descIns.Parameters["desc_id"].Value.ToString();

                    /*
                    //History log of insert
                    cmd.CommandText = "INSERT INTO HISTORY" +
                    "(EVENT_ID, USER_ID, HISTORY_DESCRIPTION, D_INVENTORY_ID)" +
                    "VALUES('1', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME = '" + Login.user + "'), " +
                    "('New inventory taken. Inventory ID: ' || (SELECT MAX(INVENTORY_ID) FROM INVENTORY)), " +
                    "(SELECT MAX(INVENTORY_ID) FROM INVENTORY))";
                    cmd.ExecuteNonQuery();
                    */
                }

                quantityTextbox.Text = "1";
                barcodeTextbox.Clear();
                //barcodeTextbox.Enabled = false;
                quantityTextbox_TextChanged(sender, e);
                insertButton.Enabled = false;
                dataGridView1.Rows.Clear();

                MessageBox.Show("Inserted all rows.");

                connection.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(quantityTextbox.Text))
            {
                MessageBox.Show("Please select a quantity!");

                insertButton.Enabled = false;
            }
            else
            {
                connection.Close();

                connection.Open();


                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) FROM EQUIPMENT WHERE PRODUCT_NO = '" + barcodeTextbox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    insertButton.Enabled = true;
                    //DISPLAY PREVIEW
                    string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT WHERE PRODUCT_NO = '" + barcodeTextbox.Text + "' ";
                    string c = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY " +
                        "JOIN EQUIPMENT ON EQUIPMENT.CATEGORY_ID = CATEGORY.CATEGORY_ID WHERE PRODUCT_NO = '" + barcodeTextbox.Text + "' ";
                    string p = "SELECT PRODUCT_NO FROM EQUIPMENT WHERE PRODUCT_NO = '" + barcodeTextbox.Text + "' ";


                    int quan = int.Parse(quantityTextbox.Text);

                    OracleCommand cmd2 = new OracleCommand(q, connection);
                    OracleCommand cmd3 = new OracleCommand(c, connection);
                    OracleCommand cmd4 = new OracleCommand(p, connection);
                    try
                    {
                        cmd2.CommandText = q;
                        cmd2.CommandType = CommandType.Text;
                        String Eq = cmd2.ExecuteScalar().ToString();

                        cmd3.CommandText = c;
                        cmd3.CommandType = CommandType.Text;
                        String Cat = cmd3.ExecuteScalar().ToString();

                        cmd4.CommandText = p;
                        cmd4.CommandType = CommandType.Text;
                        String Prod = cmd4.ExecuteScalar().ToString();

                        for (int i = 0; i < quan; i++)
                        {
                            dataGridView1.Rows.Add(Eq, Cat, Prod);
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    barcodeTextbox.Clear();
                    quantityTextbox.Text = "1";
                    quantityTextbox_TextChanged(sender, e);
                }
                else
                {
                     barcodeTextbox.Clear();
                }
                connection.Close();
            }
            //timer1.Enabled = false;
            //barcodeTextbox.Text = "";
            barcodeTextbox.Focus();
        }
    }
}
