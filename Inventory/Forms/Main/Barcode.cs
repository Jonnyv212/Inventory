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
            barcodeComboboxData();
        }

        private void barcodeTextbox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(quantityTextbox.Text))
            {
                MessageBox.Show("Please select a quantity!");
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
                    //DISPLAY PREVIEW
                    string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT WHERE PRODUCT_NO = '" + barcodeTextbox.Text + "' ";
                    string c = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY " +
                        "JOIN EQUIPMENT ON EQUIPMENT.CATEGORY_ID = CATEGORY.CATEGORY_ID WHERE PRODUCT_NO = '" + barcodeTextbox.Text + "' ";
                    string p = "SELECT PRODUCT_NO FROM EQUIPMENT WHERE PRODUCT_NO = '" + barcodeTextbox.Text + "' ";
                    string b = "SELECT BUILDING_NAME FROM BUILDING WHERE BUILDING_NAME = '" + bInvenBuildingCombobox.Text + "' ";
                    string r = "SELECT ROOM_NAME FROM ROOM WHERE ROOM_NAME = '" + bInvenRoomCombobox.Text + "' ";


                    int quan = int.Parse(quantityTextbox.Text);

                    OracleCommand cmd2 = new OracleCommand(q, connection);
                    OracleCommand cmd3 = new OracleCommand(c, connection);
                    OracleCommand cmd4 = new OracleCommand(p, connection);
                    OracleCommand cmd5 = new OracleCommand(b, connection);
                    OracleCommand cmd6 = new OracleCommand(r, connection);
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

                        cmd5.CommandText = b;
                        cmd5.CommandType = CommandType.Text;
                        String Bld = cmd5.ExecuteScalar().ToString();

                        cmd6.CommandText = r;
                        cmd6.CommandType = CommandType.Text;
                        String Room = cmd6.ExecuteScalar().ToString();

                        for (int i = 0; i < quan; i++)
                        {
                            dataGridView1.Rows.Add(Eq, Cat, Prod, Bld, Room);
                            
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                    barcodeTextbox.Clear();
                    quantityTextbox.Text = "0";
                }
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            quantityTextbox.Text = "0";
            barcodeTextbox.Clear();
            barcodeTextbox.Enabled = false;
            dataGridView1.Rows.Clear();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            string loginUser = Login.user;

            if (String.IsNullOrEmpty(dataGridView1.Rows[0].Cells[0].Value as String))
            {
                MessageBox.Show("No data");
                return;
            }
            else
            {
                //CREATE NEW LOCATION IF IT DOES NOT EXIST
                OracleCommand locCheck = connection.CreateCommand();
                locCheck.CommandType = CommandType.Text;
                locCheck.CommandText = "SELECT COUNT(*) FROM LOCATION " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE BUILDING.BUILDING_NAME = '" + bInvenBuildingCombobox.Text + "' " +
                    "AND ROOM.ROOM_NAME = '" + bInvenRoomCombobox.Text + "' ";
                locCheck.ExecuteNonQuery(); //Execute command
                Console.WriteLine(locCheck.CommandText);
                OracleDataAdapter locSda = new OracleDataAdapter(locCheck);
                DataTable locDt = new DataTable();
                locSda.Fill(locDt);
                if (locDt.Rows[0][0].ToString() == "0") //Checks in DB if first column, first row equals 0
                {
                    OracleCommand locIns = connection.CreateCommand();
                    locIns.CommandType = CommandType.Text;
                    locIns.CommandText = "INSERT INTO LOCATION (BUILDING_ID, ROOM_ID)" +
                        "VALUES((SELECT BUILDING.BUILDING_ID FROM BUILDING WHERE BUILDING.BUILDING_NAME = '" + bInvenBuildingCombobox.Text + "' ), " +
                        "(SELECT ROOM.ROOM_ID FROM ROOM WHERE ROOM.ROOM_NAME = '" + bInvenRoomCombobox.Text + "' )) ";

                    locIns.ExecuteNonQuery();

                    MessageBox.Show("New location inserted!");
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    connection.Open(); // Connects to DB
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO INVENTORY (EQUIPMENT_ID, CATEGORY_ID, EVENT_ID, USER_ID, LOCATION_ID)" +
                                       "SELECT " +
                                       "(SELECT EQUIPMENT_ID " +
                                       "FROM EQUIPMENT " +
                                       "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + dataGridView1.Rows[i].Cells[0].Value + "') " +
                                       "AS EQUIPMENT_ID," +

                                       "(SELECT CATEGORY_ID " +
                                       "FROM CATEGORY " +
                                       "WHERE CATEGORY.CATEGORY_NAME = '" + dataGridView1.Rows[i].Cells[1].Value + "') " +
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
                                       "WHERE BUILDING.BUILDING_NAME = '" + dataGridView1.Rows[i].Cells[3].Value + "' " +
                                       "AND ROOM.ROOM_NAME = '" + dataGridView1.Rows[i].Cells[4].Value + "') " +
                                       "AS LOCATION_ID " +

                                       "FROM DUAL";
                    cmd.ExecuteNonQuery(); //Execute command

                    connection.Close();
                }
                quantityTextbox.Text = "0";
                barcodeTextbox.Clear();
                barcodeTextbox.Enabled = false;
                dataGridView1.Rows.Clear();
                MessageBox.Show("Inserted all rows.");
            }
        }

        private void barcodeComboboxData()
        {
            string b = "SELECT * FROM BUILDING";
            string r = "SELECT * FROM ROOM";

            connection.Open();

            //Display queried data within combobox
            DataTable dt1 = new DataTable();
            OracleDataAdapter da1 = new OracleDataAdapter(b, connection);
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                bInvenBuildingCombobox.DataSource = dt1;
                bInvenBuildingCombobox.DisplayMember = "BUILDING_NAME";
                bInvenBuildingCombobox.ValueMember = "BUILDING_ID";
                connection.Close();
            }

            //Display queried data within combobox
            DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter(r, connection);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                bInvenRoomCombobox.DataSource = dt2;
                bInvenRoomCombobox.DisplayMember = "ROOM_NAME";
                bInvenRoomCombobox.ValueMember = "ROOM_ID";
                connection.Close();
            }
        }
    }
}
