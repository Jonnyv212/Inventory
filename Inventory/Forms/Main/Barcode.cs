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
    public partial class Barcode : Form
    {
        OracleConnection connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");


        public Barcode()
        {
            InitializeComponent();
        }

        private void Barcode_Load(object sender, EventArgs e)
        {

        }

        private void barcodeTextbox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(quantityTextbox.Text))
            {
                MessageBox.Show("Please select a quantity!");
            }
            else
            {
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

                    //DISPLAY PREVIEW
                    string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT WHERE PRODUCT_NO = '" + barcodeTextbox.Text + "' ";
                    string c = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY " +
                        "JOIN EQUIPMENT ON EQUIPMENT.CATEGORY_ID = CATEGORY.CATEGORY_ID WHERE PRODUCT_NO = '" + barcodeTextbox.Text + "' ";
                    int quan = int.Parse(quantityTextbox.Text);

                    OracleCommand cmd2 = new OracleCommand(q, connection);
                    OracleCommand cmd3 = new OracleCommand(c, connection);
                    try
                    {
                        cmd2.CommandText = q;
                        cmd2.CommandType = CommandType.Text;
                        String Eq = cmd2.ExecuteScalar().ToString();

                        cmd3.CommandText = c;
                        cmd3.CommandType = CommandType.Text;
                        String Cat = cmd3.ExecuteScalar().ToString();

                        for (int i = 0; i < quan; i++)
                        {
                            dataGridView1.Rows.Add(Eq, Cat);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                connection.Close();
                quantityTextbox.Text = "0";
                barcodeTextbox.Clear();
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quantityTextbox_TextChanged(object sender, EventArgs e)
        {
                if (System.Text.RegularExpressions.Regex.IsMatch(quantityTextbox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    quantityTextbox.Text = "0";
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
    }
}
