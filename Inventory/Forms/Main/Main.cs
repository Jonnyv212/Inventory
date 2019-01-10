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
    public partial class Main : Form
    {
        //Establish Oracle database connection using my username and password.
        OracleConnection connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");


        public Main()
        {
            InitializeComponent();

            inventoryTabControl.DrawItem += new DrawItemEventHandler(inventoryTabControl_DrawItem);

        }

        private void inventoryTabControl_Selected(object sender, TabControlEventArgs e)
        {
            //Refresh all displayed data after selecting a different tab
            display_history_data();
            display_search_data();
            display_inventory_data();
            display_beforeEdit_data();
        }

        //GUI for Inventory Tab Control (text, layout, size)
        private void inventoryTabControl_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = inventoryTabControl.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = inventoryTabControl.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(Brushes.Black, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", 17.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }



        //Loads these functions on main form load
        private void Main_Load_1(object sender, EventArgs e)
        {
            TakeInventoryComboBoxData();
            CreateItemData();
            editInventoryData();
            deleteInventoryData();
            displayCreateEquipmentListview();
            displayCreateBuildingListview();
            displayCreateRoomListview();
            display_history_data();
            display_search_data();
            display_inventory_data();
            display_beforeEdit_data();
            dataGridView6.Rows.Clear();
        }

        //Take Inventory - Call clear_data() function
        private void clearInventoryButton_Click(object sender, EventArgs e)
        {
            //clear_data();
        }

        //Exit application from Menu toolstrip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Refresh displayed data when switching between tabs
        private void inventoryInnerTabs_Selected(object sender, TabControlEventArgs e)
        {
            //Refresh all displayed data after selecting a different tab
            TakeInventoryComboBoxData();
            CreateItemData();
            editInventoryData();
            deleteInventoryData();
            Console.WriteLine("Connection refreshed!");
        }



        //Search tab - Runs cmd.CommandText query with every keystroke within searchTextbox.
        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchCombobox.Text))
            {
                MessageBox.Show("Please select a valid filter!");
            }
            else
            {
                dataGridView1.DataSource = null;
                string filterCB = searchCombobox.Text;
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //Query for case insensitive(i) searching
                cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                    "CATEGORY.CATEGORY_NAME AS Category, EQUIPMENT.PRODUCT_NO AS Product, " +
                    "INVENTORY.SERIAL_NO AS Serial, (BUILDING.BUILDING_NAME || '-' || ROOM.ROOM_NAME) AS Location, " +
                    "LOGIN.USERNAME AS Users, INVENTORY.INVENTORY_DATE AS InvDate " +
                    "FROM INVENTORY " +
                    "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                    "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                    "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE REGEXP_LIKE(" + filterCB + ", '(" + searchTextbox.Text + ")', 'i') AND " +
                    "INVENTORY.STATUS = '1' " +
                    "ORDER BY INVDATE DESC "; // SQL Command
                cmd.ExecuteNonQuery();
                DataTable dta = new DataTable();
                OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
                dataadp.Fill(dta);
                dataGridView1.DataSource = dta;
                connection.Close();
            }
        }

        //Search tab - Display data function with datagridview1
        private void display_search_data()
        {
            connection.Open();
            dataGridView1.DataSource = null;
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                    "CATEGORY.CATEGORY_NAME AS Category, EQUIPMENT.PRODUCT_NO AS Product, " +
                    "INVENTORY.SERIAL_NO AS Serial, (BUILDING.BUILDING_NAME || '-' || ROOM.ROOM_NAME) AS Location, " +
                    "LOGIN.USERNAME AS Users, INVENTORY.INVENTORY_DATE AS InvDate " +
                    "FROM INVENTORY " +
                    "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                    "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                    "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE INVENTORY.STATUS = '1' ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();
        }



        //TakeInventory tab - Function that loads data into TakeInventory tab comboboxes
        private void TakeInventoryComboBoxData()
        {
            //Call display data function
            display_inventory_data();
            connection.Open();
            //Queries for adapters
            string e = "SELECT * FROM EQUIPMENT";
            string b = "SELECT * FROM BUILDING";
            string r = "SELECT * FROM ROOM";
            string c = "SELECT * FROM CATEGORY";

            //Display queried data within combobox
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(e, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                tInvenEquipmentCombobox.DataSource = dt;
                tInvenEquipmentCombobox.DisplayMember = "EQUIPMENT_NAME";
                tInvenEquipmentCombobox.ValueMember = "EQUIPMENT_ID";
                connection.Close();
            }
            //Display queried data within combobox
            DataTable dt2 = new DataTable();
            OracleDataAdapter da2 = new OracleDataAdapter(b, connection);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                tInvenBuildingCombobox.DataSource = dt2;
                tInvenBuildingCombobox.DisplayMember = "BUILDING_NAME";
                tInvenBuildingCombobox.ValueMember = "BUILDING_ID";
                connection.Close();
            }
            //Display queried data within combobox
            DataTable dt3 = new DataTable();
            OracleDataAdapter da3 = new OracleDataAdapter(c, connection);
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                tInvenCategoryCombobox.DataSource = dt3;
                tInvenCategoryCombobox.DisplayMember = "CATEGORY_NAME";
                tInvenCategoryCombobox.ValueMember = "CATEGORY_ID";
                connection.Close();
            }
            //Display queried data within combobox
            DataTable dt4 = new DataTable();
            OracleDataAdapter da4= new OracleDataAdapter(r, connection);
            da4.Fill(dt4);
            if (dt2.Rows.Count > 0)
            {
                tInvenRoomCombobox.DataSource = dt4;
                tInvenRoomCombobox.DisplayMember = "ROOM_NAME";
                tInvenRoomCombobox.ValueMember = "ROOM_ID";
                connection.Close();
            }
        }

        //TakeInventory tab - Display data function with datagridview2
        private void display_inventory_data()
        {
            connection.Open();
            dataGridView2.DataSource = null;
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                    "CATEGORY.CATEGORY_NAME AS Category, EQUIPMENT.PRODUCT_NO AS Product, " +
                    "INVENTORY.SERIAL_NO AS Serial, (BUILDING.BUILDING_NAME || '-' || ROOM.ROOM_NAME) AS Location, " +
                    "LOGIN.USERNAME AS Users, INVENTORY.INVENTORY_DATE AS InvDate " +
                    "FROM INVENTORY " +
                    "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                    "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                    "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE INVENTORY.STATUS = '1' " +
                    "ORDER BY INVDATE DESC ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView2.DataSource = dta;
            connection.Close();
        }

        //TakeInventory tab - Function that clears data in comboboxes.
        private void clear_data()
        {
            tInvenEquipmentCombobox.Text = ""; //Clear textboxes
            tInvenBuildingCombobox.Text = "";
            tInvenCategoryCombobox.Text = "";
            //tInvenQuantityTextbox.Text = "";
        }

        //TakeInventory tab - Use combobox text and insert that data into database with insert query
        private void insertButton_Click(object sender, EventArgs e)
        {
            DescriptionInsert descForm = new DescriptionInsert();
            //Inventory tab - If any of the comboboxes are empty then show messagebox
            if (String.IsNullOrEmpty(tInvenEquipmentCombobox.Text) || String.IsNullOrEmpty(tInvenBuildingCombobox.Text) || String.IsNullOrEmpty(tInvenCategoryCombobox.Text) || String.IsNullOrEmpty(tInvenQuantityTextbox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                string loginUser = Login.user;
                int quantity = Convert.ToInt32(tInvenQuantityTextbox.Text);

                connection.Open(); // Connects to DB


                OracleCommand locCheck = connection.CreateCommand();
                locCheck.CommandType = CommandType.Text;
                locCheck.CommandText = "SELECT COUNT(*) FROM LOCATION " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE BUILDING.BUILDING_NAME = '" + tInvenBuildingCombobox.Text + "' " +
                    "AND ROOM.ROOM_NAME = '" + tInvenRoomCombobox.Text + "' ";
                locCheck.ExecuteNonQuery(); //Execute command

                OracleDataAdapter locSda = new OracleDataAdapter(locCheck);
                DataTable locDt = new DataTable();
                locSda.Fill(locDt);
                if (locDt.Rows[0][0].ToString() == "0") //Checks in DB if first column, first row equals 0
                {
                    OracleCommand locIns = connection.CreateCommand();
                    locIns.CommandType = CommandType.Text;
                    locIns.CommandText = "INSERT INTO LOCATION (BUILDING_ID, ROOM_ID)" +
                        "VALUES((SELECT BUILDING.BUILDING_ID FROM BUILDING WHERE BUILDING.BUILDING_NAME = '" + tInvenBuildingCombobox.Text + "' ), " +
                        "(SELECT ROOM.ROOM_ID FROM ROOM WHERE ROOM.ROOM_NAME = '" + tInvenRoomCombobox.Text + "' )) ";

                    locIns.ExecuteNonQuery();

                    MessageBox.Show("New location inserted!");
                }


                OracleCommand descIns = connection.CreateCommand();

                descIns.CommandType = CommandType.Text;
                descIns.CommandText = "INSERT INTO INVENTORY_DESCRIPTION " +
                    "(DESCRIPTION) " +
                    "VALUES('No Description.') " +
                    "RETURNING DESCRIPTION_ID INTO :desc_id ";
                OracleParameter outputParameter = new OracleParameter("desc_id", OracleDbType.Decimal);
                outputParameter.Direction = ParameterDirection.Output;
                descIns.Parameters.Add(outputParameter);
                descIns.ExecuteNonQuery();


                for (int i = 0; i < quantity; i++)
                {
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO INVENTORY (EQUIPMENT_ID, CATEGORY_ID, EVENT_ID, USER_ID, LOCATION_ID, SERIAL_NO, DESCRIPTION_ID)" +
                        "SELECT " +
                        "(SELECT EQUIPMENT_ID " +
                        "FROM EQUIPMENT " +
                        "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + tInvenEquipmentCombobox.Text + "') " +
                        "AS EQUIPMENT_ID," +

                        "(SELECT CATEGORY_ID " +
                        "FROM CATEGORY " +
                        "WHERE CATEGORY.CATEGORY_NAME = '" + tInvenCategoryCombobox.Text + "') " +
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
                        "WHERE BUILDING.BUILDING_NAME = '" + tInvenBuildingCombobox.Text + "' " +
                        "AND ROOM.ROOM_NAME = '" + tInvenRoomCombobox.Text + "') " +
                        "AS LOCATION_ID, " +

                        "('" + tInvenSerialTextbox.Text + "') " +
                        "AS SERIAL_NO, " +

                        "(SELECT  ('" + descIns.Parameters["desc_id"].Value + "') " +
                        "AS DESCRIPTION_ID " +
                        "FROM DUAL )" +

                        "FROM DUAL";


                    cmd.ExecuteNonQuery(); //Execute command
                    descForm.descID = descIns.Parameters["desc_id"].Value.ToString();



                    string maxI = "SELECT MAX(INVENTORY_ID) FROM INVENTORY";
                    OracleCommand cmd3 = new OracleCommand(maxI, connection);

                    try
                    {
                       /* cmd3.CommandText = maxI;
                        cmd3.CommandType = CommandType.Text;
                        String maxInven = cmd3.ExecuteScalar().ToString();
                        maxInven = maxInven + i;

                        //History log of insert
                        cmd.CommandText = "INSERT INTO HISTORY" +
                            "(EVENT_ID, USER_ID, HISTORY_DESCRIPTION, D_INVENTORY_ID)" +
                            "VALUES('1', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME = '" + Login.user + "'), " +
                            "('New inventory taken. Inventory ID: ' || '" + maxInven + "'), " +
                            " '" + maxInven + "' )";
                        cmd.ExecuteNonQuery();
                        */

                        //displays query into datagridiew2
                        dataGridView2.DataSource = null;
                        OracleCommand cmd2 = connection.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                                "CATEGORY.CATEGORY_NAME AS Category, EQUIPMENT.PRODUCT_NO AS Product, " +
                                "INVENTORY.SERIAL_NO AS Serial, (BUILDING.BUILDING_NAME || '-' || ROOM.ROOM_NAME) AS Location, " +
                                "LOGIN.USERNAME AS Users, INVENTORY.INVENTORY_DATE AS InvDate " +
                                "FROM INVENTORY " +
                                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID " +
                                "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                                "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                                "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                                "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                                "WHERE INVENTORY.STATUS = '1' ";
                        cmd2.ExecuteNonQuery();
                        DataTable dta2 = new DataTable();
                        OracleDataAdapter dataadp2 = new OracleDataAdapter(cmd2);
                        dataadp2.Fill(dta2);
                        dataGridView2.DataSource = dta2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                if (InvenDescriptionCheckbox.Checked == true)
                {
                    descForm.Show(); 
                }

                connection.Close(); //Close connection to DB

                //display_inventory_data();
                MessageBox.Show("Data inserted successfully!");
            }
        }



        //Create tab - Use combobox text and insert that data into database with insert query
        private void createButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(createEquipmentCombobox.Text) || String.IsNullOrEmpty(productNoTextbox.Text) || String.IsNullOrEmpty(createCategoryCombobox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "SELECT COUNT(*) FROM EQUIPMENT WHERE EQUIPMENT_NAME= '" + createEquipmentCombobox.Text + "' OR PRODUCT_NO= '" + productNoTextbox.Text + "' "; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    MessageBox.Show("Already exists!");
                    createEquipmentListview.Refresh();
                    connection.Close();
                }
                else
                {
                    //connection.Open(); // Connects to DB
                    OracleCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandType = CommandType.Text; //Command to send to DB
                    cmd2.CommandText = "INSERT INTO EQUIPMENT " +
                                        "(PRODUCT_NO, EQUIPMENT_NAME, CATEGORY_ID) VALUES " +
                                        "('" + productNoTextbox.Text + "','" + createEquipmentCombobox.Text + "', " +
                                        "(SELECT CATEGORY.CATEGORY_ID FROM CATEGORY WHERE CATEGORY_NAME = '" +  createCategoryCombobox.Text + "') )"; // SQL Command
                    cmd2.ExecuteNonQuery(); //Execute command

                    //History log of equipment addition
                    cmd2.CommandText = "INSERT INTO HISTORY" +
                        "(EVENT_ID, USER_ID, HISTORY_DESCRIPTION)" +
                        "VALUES('3', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME = 'jonnyv'), " +
                        "('Added Equipment: ' || (SELECT EQUIPMENT_NAME FROM EQUIPMENT WHERE EQUIPMENT_ID = " +
                        "(SELECT MAX(EQUIPMENT_ID) FROM EQUIPMENT)))";
                    cmd2.ExecuteNonQuery();

                    productNoTextbox.Text = ""; //Clear textboxes
                    createEquipmentCombobox.Text = "";

                    createEquipmentListview.Refresh();
                    connection.Close();
                    MessageBox.Show("Data inserted");
                }
            }
        }

        //Create tab - Call createEquipmentListview.Refresh() function
        private void refreshButton_Click(object sender, EventArgs e)
        {
            createEquipmentListview.Refresh();
        }

        //Create tab - display category table data into createCategoryCombobox
        private void CreateItemData()
        {
            connection.Open();
            OracleCommand cmd = connection.CreateCommand();
            string q = "SELECT * FROM CATEGORY";
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(q, connection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                createCategoryCombobox.DataSource = dt;
                createCategoryCombobox.DisplayMember = "CATEGORY_NAME";
                createCategoryCombobox.ValueMember = "CATEGORY_ID";
                connection.Close();
            }
        }

        //Create tab - display list of equipment into createEquipmentListview
        private void displayCreateEquipmentListview()
        {
            string q = "SELECT EQUIPMENT.EQUIPMENT_NAME, CATEGORY.CATEGORY_NAME, EQUIPMENT.PRODUCT_NO " +
                        "FROM EQUIPMENT " +
                        "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = EQUIPMENT.CATEGORY_ID";

            connection.Open();

            OracleCommand cmd = new OracleCommand(q, connection);

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["EQUIPMENT_NAME"].ToString());
                    item.SubItems.Add(dr["CATEGORY_NAME"].ToString());
                    item.SubItems.Add(dr["PRODUCT_NO"].ToString());

                    createEquipmentListview.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }



        //Create tab - display list of buildings into createBuildingListview
        private void displayCreateBuildingListview()
        {
            string q = "SELECT BUILDING.BUILDING_NAME " +
                        "FROM BUILDING ";

            connection.Open();

            OracleCommand cmd = new OracleCommand(q, connection);

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(dr["BUILDING_NAME"].ToString());

                    createBuildingListview.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

        }


        //Create tab - display list of rooms into createRoomListview
        private void displayCreateRoomListview()
        {
            string q = "SELECT ROOM.ROOM_NAME " +
                        "FROM ROOM ";

            connection.Open();

            OracleCommand cmd = new OracleCommand(q, connection);

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(dr["ROOM_NAME"].ToString());

                    createRoomListview.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        //Create tab - Create buildings using combobox text and insert that data into database with insert query
        private void createBuildingButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(createBuildingTextbox.Text))
            {
                MessageBox.Show("Please fill in the the data.");
            }
            else
            {
                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "SELECT COUNT(*) FROM BUILDING WHERE BUILDING_NAME= '" + createBuildingTextbox.Text + "' "; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    MessageBox.Show("Already exists!");
                    createBuildingListview.Refresh();
                    connection.Close();
                }
                else
                {
                    //connection.Open(); // Connects to DB
                    OracleCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandType = CommandType.Text; //Command to send to DB
                    cmd2.CommandText = "INSERT INTO BUILDING " +
                                        "(BUILDING_NAME) VALUES " +
                                        "('" + createBuildingTextbox.Text + "' )"; // SQL Command
                    cmd2.ExecuteNonQuery(); //Execute command
                    //connection.Close(); //Close connection to DB

                    createBuildingTextbox.Text = ""; //Clear textboxes

                    createBuildingListview.Refresh();
                    connection.Close();
                    MessageBox.Show("Data inserted");
                }
            }
        }


        //Edit Inventory tab EQUIPMENT combobox - Checkbox to enable/disable comboboxes and display appropriate data
        private void nameEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (nameEditCheckbox.Checked == true)
            {
                nameEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM EQUIPMENT";


                DataTable dtNE = new DataTable();
                OracleDataAdapter daNE = new OracleDataAdapter(w, connection);
                daNE.Fill(dtNE);
                if (dtNE.Rows.Count > 0)
                {
                    nameEditCombobox.DataSource = dtNE;
                    nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                    nameEditCombobox.ValueMember = "EQUIPMENT_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM EQUIPMENT " +
                    "JOIN INVENTORY ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dtNE2 = new DataTable();
                OracleDataAdapter daNE2 = new OracleDataAdapter(w, connection);
                daNE2.Fill(dtNE2);
                if (dtNE2.Rows.Count > 0)
                {
                    nameEditCombobox.DataSource = dtNE2;
                    nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                    nameEditCombobox.ValueMember = "EQUIPMENT_ID";
                    connection.Close();
                }

                nameEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab BUILDING ROOM comboboxes- Checkbox to enable/disable comboboxes and display appropriate data
        private void locationEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (locationEditCheckbox.Checked == true)
            {
                buildingEditCombobox.Enabled = true;
                roomEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();

                string b = "SELECT * FROM BUILDING";
                string r = "SELECT * FROM ROOM";

                DataTable dtBE = new DataTable();
                OracleDataAdapter daBE = new OracleDataAdapter(b, connection);
                daBE.Fill(dtBE);
                if (dtBE.Rows.Count > 0)
                {
                    buildingEditCombobox.DataSource = dtBE;
                    buildingEditCombobox.DisplayMember = "BUILDING_NAME";
                    buildingEditCombobox.ValueMember = "BUILDING_ID";
                    connection.Close();
                }

                DataTable dtRE = new DataTable();
                OracleDataAdapter daRE = new OracleDataAdapter(r, connection);
                daRE.Fill(dtRE);
                if (dtRE.Rows.Count > 0)
                {
                    roomEditCombobox.DataSource = dtRE;
                    roomEditCombobox.DisplayMember = "ROOM_NAME";
                    roomEditCombobox.ValueMember = "ROOM_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string b = "SELECT * FROM BUILDING " +
                "JOIN LOCATION ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                string r = "SELECT * FROM ROOM " +
                "JOIN LOCATION ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dtBE2 = new DataTable();
                OracleDataAdapter daBE2 = new OracleDataAdapter(b, connection);
                daBE2.Fill(dtBE2);
                if (dtBE2.Rows.Count > 0)
                {
                    buildingEditCombobox.DataSource = dtBE2;
                    buildingEditCombobox.DisplayMember = "BUILDING_NAME";
                    buildingEditCombobox.ValueMember = "BUILDING_ID";
                    connection.Close();
                }
                DataTable dtRE2 = new DataTable();
                OracleDataAdapter daRE2 = new OracleDataAdapter(r, connection);
                daRE2.Fill(dtRE2);
                if (dtRE2.Rows.Count > 0)
                {
                    roomEditCombobox.DataSource = dtRE2;
                    roomEditCombobox.DisplayMember = "ROOM_NAME";
                    roomEditCombobox.ValueMember = "ROOM_ID";
                    connection.Close();
                }
                buildingEditCombobox.Enabled = false;
                roomEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab LOGIN combobox - Checkbox to enable/disable comboboxes and display appropriate data
        private void userEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (userEditCheckbox.Checked == true)
            {
                userEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM LOGIN";

                DataTable dtUE = new DataTable();
                OracleDataAdapter daUE = new OracleDataAdapter(w, connection);
                daUE.Fill(dtUE);
                if (dtUE.Rows.Count > 0)
                {
                    userEditCombobox.DataSource = dtUE;
                    userEditCombobox.DisplayMember = "USERNAME";
                    userEditCombobox.ValueMember = "USER_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM LOGIN " +
                    "JOIN INVENTORY ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                    "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dtUE2 = new DataTable();
                OracleDataAdapter daUE2 = new OracleDataAdapter(w, connection);
                daUE2.Fill(dtUE2);
                if (dtUE2.Rows.Count > 0)
                {
                    userEditCombobox.DataSource = dtUE2;
                    userEditCombobox.DisplayMember = "USERNAME";
                    userEditCombobox.ValueMember = "USER_ID";
                    connection.Close();
                }
                userEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab CATEGORY combobox - Checkbox to enable/disable comboboxes and display appropriate data
        private void categoryEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (categoryEditCheckbox.Checked == true)
            {
                categoryEditCombobox.Enabled = true;

                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM CATEGORY";

                DataTable dtCE = new DataTable();
                OracleDataAdapter daCE = new OracleDataAdapter(w, connection);
                daCE.Fill(dtCE);
                if (dtCE.Rows.Count > 0)
                {
                    categoryEditCombobox.DataSource = dtCE;
                    categoryEditCombobox.DisplayMember = "CATEGORY_NAME";
                    categoryEditCombobox.ValueMember = "CATEGORY_ID";
                    connection.Close();
                }
            }
            else
            {
                OracleCommand cmd = connection.CreateCommand();
                string w = "SELECT * FROM CATEGORY " +
                    "JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                    "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";

                DataTable dtCE2 = new DataTable();
                OracleDataAdapter daCE2 = new OracleDataAdapter(w, connection);
                daCE2.Fill(dtCE2);
                if (dtCE2.Rows.Count > 0)
                {
                    categoryEditCombobox.DataSource = dtCE2;
                    categoryEditCombobox.DisplayMember = "CATEGORY_NAME";
                    categoryEditCombobox.ValueMember = "CATEGORY_ID";
                    connection.Close();
                }
                categoryEditCombobox.Enabled = false;
            }
        }

        //Edit Inventory tab SERIAL textbox - Checkbox to enable/disable comboboxes and display appropriate data
        private void serialEditCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (serialEditCheckbox.Checked == true)
            {
                serialEditTextbox.Enabled = true;
            }
            else
            {
                serialEditTextbox.Enabled = false;
            }
        }

        //Edit Inventory tab - Pull data from various tables and display them.
        private void editInventoryData()
        {
           
            //connection.Open();
            OracleCommand cmd = connection.CreateCommand();

            string i = "SELECT * FROM INVENTORY WHERE INVENTORY.STATUS = '1' ";

            string e = "SELECT * FROM EQUIPMENT " +
                        "JOIN INVENTORY ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";


            string u = "SELECT * FROM LOGIN " +
                        "JOIN INVENTORY ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";

            string c = "SELECT * FROM CATEGORY " +
                        "JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                        "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";

            DataTable dtEI = new DataTable();
            OracleDataAdapter daEI = new OracleDataAdapter(i, connection);
            daEI.Fill(dtEI);
            if (dtEI.Rows.Count > 0)
            {
                inventoryEditCombobox.DataSource = dtEI;
                inventoryEditCombobox.DisplayMember = "INVENTORY_ID";
                inventoryEditCombobox.ValueMember = "INVENTORY_ID";
                connection.Close();
            } 

            DataTable dtEI1 = new DataTable();
            OracleDataAdapter daEI1 = new OracleDataAdapter(e, connection);
            daEI1.Fill(dtEI1);
            if (dtEI1.Rows.Count > 0)
            {
                nameEditCombobox.DataSource = dtEI1;
                nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                nameEditCombobox.ValueMember = "EQUIPMENT_ID";
                connection.Close();
            }

            DataTable dtEI3 = new DataTable();
            OracleDataAdapter daEI3 = new OracleDataAdapter(u, connection);
            daEI3.Fill(dtEI3);
            if (dtEI3.Rows.Count > 0)
            {
                userEditCombobox.DataSource = dtEI3;
                userEditCombobox.DisplayMember = "USERNAME";
                userEditCombobox.ValueMember = "USER_ID";
                connection.Close();
            }

            DataTable dtEI4 = new DataTable();
            OracleDataAdapter daEI4 = new OracleDataAdapter(c, connection);
            daEI4.Fill(dtEI4);
            if (dtEI4.Rows.Count > 0)
            {
                categoryEditCombobox.DataSource = dtEI4;
                categoryEditCombobox.DisplayMember = "CATEGORY_NAME";
                categoryEditCombobox.ValueMember = "CATEGORY_ID";
                connection.Close();
            }

        }

        //Edit Inventory tab - Changing this combobox will execute these functions
        private void inventoryEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameEditCheckbox.Checked = false;
            categoryEditCheckbox.Checked = false;
            locationEditCheckbox.Checked = false;
            serialEditCheckbox.Checked = false;
            userEditCheckbox.Checked = false;


            nameEditCheckbox_CheckedChanged(sender, e);
            categoryEditCheckbox_CheckedChanged(sender, e);
            serialEditCheckbox_CheckedChanged(sender, e);
            userEditCheckbox_CheckedChanged(sender, e);
            locationEditCheckbox_CheckedChanged(sender, e);
            display_beforeEdit_data();
            //display_afterEdit_data();

            readSerialEdit(); 
        }

        //Edit Inventory tab - Select query to retrieve serial number data into serialEditTextbox
        private void readSerialEdit()
        {
            string q = "SELECT SERIAL_NO FROM INVENTORY WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";

            connection.Open();

            OracleCommand cmd2 = new OracleCommand(q, connection);
            OracleDataReader dr = cmd2.ExecuteReader();

            if (dr.Read())
            {
                serialEditTextbox.Text = (dr["SERIAL_NO"].ToString());
            }
            connection.Close();
        }

        //Edit Inventory tab - If a checkbox is true then run an update query from the specified combobox by INVENTORY_ID to update the inventory table
        private void editApplyButton_Click(object sender, EventArgs e)
        {

            bool checkEnabled = false; 

            if (nameEditCheckbox.Checked == true)
            {
                checkEnabled = true;
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.EQUIPMENT_ID = " +
                    "(SELECT EQUIPMENT.EQUIPMENT_ID " +
                    "FROM EQUIPMENT " +
                    "WHERE EQUIPMENT.EQUIPMENT_NAME = '" + nameEditCombobox.Text + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '"+ inventoryEditCombobox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close();
            }
            else
            {
                checkEnabled = false;
            }
            if (categoryEditCheckbox.Checked == true)
            {
                checkEnabled = true;
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.CATEGORY_ID = " +
                    "(SELECT CATEGORY.CATEGORY_ID " +
                    "FROM CATEGORY " +
                    "WHERE CATEGORY.CATEGORY_NAME = '" + categoryEditCombobox.Text + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close();
            }
            else
            {
                checkEnabled = false;
            }
            if (userEditCheckbox.Checked == true)
            {
                checkEnabled = true;
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.USER_ID = " +
                    "(SELECT LOGIN.USER_ID " +
                    "FROM LOGIN " +
                    "WHERE LOGIN.USERNAME = '" + userEditCombobox.Text + "') " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close();
            }
            else
            {
                checkEnabled = false;
            }
            if (serialEditCheckbox.Checked == true)
            {
                checkEnabled = true;
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.SERIAL_NO = '" + serialEditTextbox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command
                connection.Close();
            }
            else
            {
                checkEnabled = false;
            }
            if (locationEditCheckbox.Checked == true)
            {
                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB
                //Check to see if location exists
                cmd.CommandText = "SELECT COUNT(*) " +
                    "FROM LOCATION " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE BUILDING.BUILDING_NAME = '" + buildingEditCombobox.Text + "' " +
                    "AND ROOM.ROOM_NAME= '" + roomEditCombobox.Text + "' "; // SQL Command
                cmd.ExecuteNonQuery(); //Execute command
                OracleDataAdapter odaL = new OracleDataAdapter(cmd);
                DataTable dtL = new DataTable();
                odaL.Fill(dtL);
                if (dtL.Rows[0][0].ToString() == "1") //Checks in DB if first column, first row equals 1.
                {
                    //If the location exists then continue the update
                    connection.Close();

                    checkEnabled = true;

                    connection.Open();
                    OracleCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandType = CommandType.Text; //Command to send to DB
                    cmd2.CommandText = "UPDATE INVENTORY " +
                        "SET INVENTORY.LOCATION_ID = " +
                            "(SELECT LOCATION_ID " +
                            "FROM LOCATION " +
                            "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                            "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                            "WHERE BUILDING.BUILDING_NAME = '" + buildingEditCombobox.Text + "' " +
                            "AND ROOM.ROOM_NAME = '" + roomEditCombobox.Text + "') " +
                        "WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";
                    cmd2.ExecuteNonQuery(); //Execute command
                    connection.Close();
                    MessageBox.Show("Edited location");
                }
                else
                {
                    //else create new a new ID with the new building/room combination for the Location table
                    connection.Close();

                    connection.Open();
                    OracleCommand cmd3 = connection.CreateCommand();
                    cmd3.CommandType = CommandType.Text; //Command to send to DB
                    cmd3.CommandText = "INSERT INTO LOCATION" +
                        "(BUILDING_ID, ROOM_ID) " +
                        "SELECT(SELECT BUILDING_ID FROM BUILDING WHERE BUILDING_NAME = '" + buildingEditCombobox.Text + "' ) AS BUILDING_ID, " +
                        "(SELECT ROOM_ID FROM ROOM WHERE ROOM_NAME = '" + roomEditCombobox.Text + "' ) AS ROOM_ID " +
                        "FROM DUAL";
                    cmd3.ExecuteNonQuery(); //Execute command
                    //update with new location ID
                    OracleCommand cmd4 = connection.CreateCommand();
                    cmd4.CommandType = CommandType.Text; //Command to send to DB
                    cmd4.CommandText = "UPDATE INVENTORY " +
                        "SET INVENTORY.LOCATION_ID = " +
                            "(SELECT LOCATION_ID " +
                            "FROM LOCATION " +
                            "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                            "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                            "WHERE BUILDING.BUILDING_NAME = '" + buildingEditCombobox.Text + "' " +
                            "AND ROOM.ROOM_NAME = '" + roomEditCombobox.Text + "') " +
                        "WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";
                    cmd4.ExecuteNonQuery(); //Execute command
                    connection.Close();
                    MessageBox.Show("Added new location");
                    checkEnabled = true;
                }
            }
            else
            {
                checkEnabled = false;
            }
            if (checkEnabled == true){
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text; //Command to send to DB

                //History log of edit
                cmd.CommandText = "INSERT INTO HISTORY" +
                    "(EVENT_ID, USER_ID, HISTORY_DESCRIPTION)" +
                    "VALUES('2', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME = 'jonnyv'), " +
                    "('Inventory edited. Inventory ID: ' ||  '" + inventoryEditCombobox.Text +"' ))";
                cmd.ExecuteNonQuery();
                connection.Close();

                checkEnabled = false;
            }
            refreshEditButton_Click(sender, e);
            dataGridView6.Rows.Clear();
        }

        private void display_beforeEdit_data()
        {
            connection.Open();
            dataGridView5.DataSource = null;
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                    "CATEGORY.CATEGORY_NAME AS Category, " +
                    "INVENTORY.SERIAL_NO AS Serial, BUILDING.BUILDING_NAME AS Building, ROOM.ROOM_NAME AS Room, " +
                    "LOGIN.USERNAME AS Users " +
                    "FROM INVENTORY " +
                    "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                    "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                    "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView5.DataSource = dta;
            connection.Close();
        }

        private void display_afterEdit_data()
        {
            connection.Open();
            //DISPLAY PREVIEW
            string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT WHERE EQUIPMENT_NAME = '" + nameEditCombobox.Text + "' ";
            string c = "SELECT CATEGORY.CATEGORY_NAME FROM CATEGORY JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' ";
            string s = "SELECT SERIAL_NO FROM INVENTORY WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";
            string u = "SELECT LOGIN.USERNAME FROM INVENTORY JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";
            string b = "SELECT BUILDING.BUILDING_NAME FROM BUILDING JOIN LOCATION ON LOCATION.BUILDING_ID = BUILDING.BUILDING_ID JOIN INVENTORY ON INVENTORY.LOCATION_ID = LOCATION.LOCATION_ID WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";
            string r = "SELECT ROOM.ROOM_NAME FROM ROOM JOIN LOCATION ON LOCATION.ROOM_ID = ROOM.ROOM_ID JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID WHERE INVENTORY.INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";



            OracleCommand cmd2 = new OracleCommand(q, connection);
            OracleCommand cmd3 = new OracleCommand(c, connection);
            OracleCommand cmd4 = new OracleCommand(s, connection);
            OracleCommand cmd5 = new OracleCommand(u, connection);
            OracleCommand cmd6 = new OracleCommand(b, connection);
            OracleCommand cmd7 = new OracleCommand(r, connection);
            try
            {
                cmd2.CommandText = q;
                cmd2.CommandType = CommandType.Text;
                String Eq = cmd2.ExecuteScalar().ToString();

                cmd3.CommandText = c;
                cmd3.CommandType = CommandType.Text;
                String Cat = cmd3.ExecuteScalar().ToString();

                cmd4.CommandText = s;
                cmd4.CommandType = CommandType.Text;
                String Serial = cmd4.ExecuteScalar().ToString();

                cmd5.CommandText = u;
                cmd5.CommandType = CommandType.Text;
                String User = cmd5.ExecuteScalar().ToString();

                cmd6.CommandText = b;
                cmd6.CommandType = CommandType.Text;
                String Bld = cmd6.ExecuteScalar().ToString();

                cmd7.CommandText = r;
                cmd7.CommandType = CommandType.Text;
                String Room = cmd7.ExecuteScalar().ToString();

                dataGridView6.Rows.Add(Eq, Cat, Serial, Bld, Room, User);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }



        //Delete Inventory tab - Delete an inventory record by selecting the INVENTORY_ID 
        private void deleteButton_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure you want to delete this record?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string loginUser = Login.user;

                connection.Open(); // Connects to DB
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;



                //Select event 4 (removed inventory), current user_id, and insert inventory_ID value into the HISTORY table
                cmd.CommandText = "INSERT INTO HISTORY " +
                    "(EVENT_ID, USER_ID, D_INVENTORY_ID) " +
                    "VALUES('4', (SELECT USER_ID FROM LOGIN WHERE LOGIN.USERNAME ='" + loginUser + "'), " +
                    " '" + inventoryDeleteCombobox.Text + "' ) ";
                    //"(SELECT last_number FROM user_sequences WHERE sequence_name = 'D_INVENTORY_SEQUENCE'))";
                cmd.ExecuteNonQuery();



                cmd.CommandText = "UPDATE INVENTORY " +
                    "SET INVENTORY.STATUS = 0" +
                    "WHERE INVENTORY_ID = '" + inventoryDeleteCombobox.Text + "' ";
                cmd.ExecuteNonQuery(); //Execute command

               // connection.Close(); //Close connection to DB

                MessageBox.Show("Data deleted successfully!");

                dataGridView4.DataSource = null;

                OracleCommand cmd2 = connection.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                //Query for case insensitive(i) searching
                cmd2.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, " +
                    "CATEGORY.CATEGORY_NAME AS Category, BUILDING.BUILDING_NAME AS Building, ROOM.ROOM_NAME AS Room, LOGIN.USERNAME AS Username " +
                    "FROM INVENTORY " +
                    "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                    "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                    "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                    "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                    "WHERE REGEXP_LIKE(" + filterDeleteCombobox.Text + ", '(" + searchDeleteTextbox.Text + ")', 'i') AND INVENTORY.STATUS = '1' "; // SQL Command
                cmd2.ExecuteNonQuery();
                DataTable dta2 = new DataTable();
                OracleDataAdapter dataadp2 = new OracleDataAdapter(cmd2);
                dataadp2.Fill(dta2);
                dataGridView4.DataSource = dta2;
                connection.Close();
            }
            else
            {
                // If 'No', do something here.
            }
        }
        
        //Delete Inventory tab - Search record information based on inventory_id and display to datagridview in delete tab
        private void searchDeleteTextbox_TextChanged(object sender, EventArgs e)
        {
            string filterCB = filterDeleteCombobox.Text;
            connection.Open();
            dataGridView4.DataSource = null;
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Query for case insensitive(i) searching
            cmd.CommandText = "SELECT INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME AS Equipment, CATEGORY.CATEGORY_NAME AS Category, BUILDING.BUILDING_NAME AS Building, ROOM.ROOM_NAME AS Room, LOGIN.USERNAME AS Username " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                "JOIN LOGIN ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                "WHERE REGEXP_LIKE(" + filterDeleteCombobox.Text + ", '(" + searchDeleteTextbox.Text + ")', 'i') AND INVENTORY.STATUS = '1' ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView4.DataSource = dta;
            connection.Close();
        }

        //Delete Inventory tab - 
        private void deleteInventoryData()
        {
            string i = "SELECT * FROM INVENTORY WHERE INVENTORY.STATUS = '1' ";


            DataTable dtDI = new DataTable();
            OracleDataAdapter daDI = new OracleDataAdapter(i, connection);
            daDI.Fill(dtDI);
            if (dtDI.Rows.Count > 0)
            {
                inventoryDeleteCombobox.DataSource = dtDI;
                inventoryDeleteCombobox.DisplayMember = "INVENTORY_ID";
                inventoryDeleteCombobox.ValueMember = "INVENTORY_ID";
                connection.Close();
            }
        }

        private void refreshEditButton_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
            display_beforeEdit_data();
            // EQUIPMENT COMBOBOX
            OracleCommand cmd = connection.CreateCommand();
            string w = "SELECT * FROM EQUIPMENT " +
                "JOIN INVENTORY ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";

            DataTable dtNE2 = new DataTable();
            OracleDataAdapter daNE2 = new OracleDataAdapter(w, connection);
            daNE2.Fill(dtNE2);
            if (dtNE2.Rows.Count > 0)
            {
                nameEditCombobox.DataSource = dtNE2;
                nameEditCombobox.DisplayMember = "EQUIPMENT_NAME";
                nameEditCombobox.ValueMember = "EQUIPMENT_ID";
                connection.Close();
            }

            //BUILDING & ROOM COMBOBOX
            OracleCommand cmd2 = connection.CreateCommand();
            string b = "SELECT * FROM BUILDING " +
            "JOIN LOCATION ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
            "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
            "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";

            string r = "SELECT * FROM ROOM " +
            "JOIN LOCATION ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
            "JOIN INVENTORY ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
            "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";

            DataTable dtBE2 = new DataTable();
            OracleDataAdapter daBE2 = new OracleDataAdapter(b, connection);
            daBE2.Fill(dtBE2);
            if (dtBE2.Rows.Count > 0)
            {
                buildingEditCombobox.DataSource = dtBE2;
                buildingEditCombobox.DisplayMember = "BUILDING_NAME";
                buildingEditCombobox.ValueMember = "BUILDING_ID";
                connection.Close();
            }
            DataTable dtRE2 = new DataTable();
            OracleDataAdapter daRE2 = new OracleDataAdapter(r, connection);
            daRE2.Fill(dtRE2);
            if (dtRE2.Rows.Count > 0)
            {
                roomEditCombobox.DataSource = dtRE2;
                roomEditCombobox.DisplayMember = "ROOM_NAME";
                roomEditCombobox.ValueMember = "ROOM_ID";
                connection.Close();
            }
            //LOGIN COMBOBOX
            OracleCommand cmd3 = connection.CreateCommand();
            string l = "SELECT * FROM LOGIN " +
                "JOIN INVENTORY ON LOGIN.USER_ID = INVENTORY.USER_ID " +
                "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";

            DataTable dtUE2 = new DataTable();
            OracleDataAdapter daUE2 = new OracleDataAdapter(l, connection);
            daUE2.Fill(dtUE2);
            if (dtUE2.Rows.Count > 0)
            {
                userEditCombobox.DataSource = dtUE2;
                userEditCombobox.DisplayMember = "USERNAME";
                userEditCombobox.ValueMember = "USER_ID";
                connection.Close();
            }
            //CATEGORY COMBOBOX
            OracleCommand cmd4 = connection.CreateCommand();
            string c = "SELECT * FROM CATEGORY " +
                "JOIN INVENTORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "WHERE INVENTORY_ID = '" + inventoryEditCombobox.Text + "' AND INVENTORY.STATUS = '1' ";

            DataTable dtCE2 = new DataTable();
            OracleDataAdapter daCE2 = new OracleDataAdapter(c, connection);
            daCE2.Fill(dtCE2);
            if (dtCE2.Rows.Count > 0)
            {
                categoryEditCombobox.DataSource = dtCE2;
                categoryEditCombobox.DisplayMember = "CATEGORY_NAME";
                categoryEditCombobox.ValueMember = "CATEGORY_ID";
                connection.Close();
            }

            readSerialEdit();

            nameEditCheckbox.Checked = false;
            categoryEditCheckbox.Checked = false;
            locationEditCheckbox.Checked = false;
            serialEditCheckbox.Checked = false;
            userEditCheckbox.Checked = false;
        }

        //still using D_INVENTORY
        private void display_history_data()
        {
            //dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


            connection.Open();
            dataGridView3.DataSource = null;
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT D_INVENTORY_ID AS INVENTORY_ID, EVENT.EVENT, LOGIN.USERNAME, HISTORY_DATE " +
                "FROM HISTORY " +
                "JOIN EVENT ON EVENT.EVENT_ID = HISTORY.EVENT_ID " +
                "JOIN LOGIN ON LOGIN.USER_ID = HISTORY.USER_ID " +
                "ORDER BY HISTORY_DATE DESC";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView3.DataSource = dta;
            connection.Close();
        }

        private void barcodeButton_Click(object sender, EventArgs e)
        {
            Barcode bar = new Barcode();
            bar.Show();
        }

        private void rButton_Click(object sender, EventArgs e)
        {
            display_inventory_data();
        }



        private void nameEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void categoryEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void userEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void serialEditTextbox_TextChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void buildingEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void roomEditCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAfterGridUpdate(sender, e);
        }

        private void editAfterGridUpdate(object sender, EventArgs e)
        {
            dataGridView6.Rows.Clear();

            String Eqs = nameEditCombobox.Text.ToString();
            String Cat = categoryEditCombobox.Text.ToString();
            String User = userEditCombobox.Text.ToString();
            String Srl = serialEditTextbox.Text.ToString();
            String Bld = buildingEditCombobox.Text.ToString();
            String Room = roomEditCombobox.Text.ToString();

            dataGridView6.Rows.Add(Eqs, Cat, Srl, Bld, Room, User);
        }

        private void deleteBuildingButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this building?",
                            "Confirm Delete!",
                            MessageBoxButtons.YesNo);
                connection.Open();
                OracleCommand invLocCheck = connection.CreateCommand();
                invLocCheck.CommandType = CommandType.Text;
                invLocCheck.CommandText = "SELECT COUNT(*) FROM INVENTORY JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                    "JOIN BUILDING ON BUILDING.BUILDING_ID = LOCATION.BUILDING_ID " +
                    "WHERE BUILDING.BUILDING_NAME = '"+ createBuildingTextbox.Text + "' ";
                invLocCheck.ExecuteNonQuery(); //Execute command
                OracleDataAdapter InvLocSda = new OracleDataAdapter(invLocCheck);
                DataTable invLocDt = new DataTable();
                InvLocSda.Fill(invLocDt);
                if (invLocDt.Rows[0][0].ToString() == "0") //Checks in DB if first column, first row equals 0
                {

                    string loginUser = Login.user;
                    if (confirmResult == DialogResult.Yes)
                    {
                        OracleCommand cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;


                        cmd.CommandText = "DELETE FROM LOCATION WHERE LOCATION.BUILDING_ID = " +
                            "(SELECT BUILDING.BUILDING_ID FROM BUILDING WHERE BUILDING.BUILDING_NAME = '" + createBuildingTextbox.Text + "' ) ";
                        cmd.ExecuteNonQuery(); //Execute command


                        cmd.CommandText = "DELETE FROM BUILDING WHERE BUILDING_NAME = '" + createBuildingTextbox.Text + "' ";
                        cmd.ExecuteNonQuery();


                        connection.Close(); //Close connection to DB

                        MessageBox.Show("Data deleted successfully!");
                    }
                }
                else
                {
                    MessageBox.Show("Building " + createBuildingTextbox.Text + " is already used in previous inventories. Edit or remove them before deleting this building.");
                    connection.Close();
                }
        }

        private void deleteRoomButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this building?",
                "Confirm Delete!",
                MessageBoxButtons.YesNo);
            connection.Open();
            OracleCommand invLocCheck = connection.CreateCommand();
            invLocCheck.CommandType = CommandType.Text;
            invLocCheck.CommandText = "SELECT COUNT(*) FROM INVENTORY JOIN LOCATION ON LOCATION.LOCATION_ID = INVENTORY.LOCATION_ID " +
                "JOIN ROOM ON ROOM.ROOM_ID = LOCATION.ROOM_ID " +
                "WHERE ROOM.ROOM_NAME = '" + createRoomTextbox.Text + "' ";
            invLocCheck.ExecuteNonQuery(); //Execute command

            OracleDataAdapter InvLocSda = new OracleDataAdapter(invLocCheck);
            DataTable invLocDt = new DataTable();
            InvLocSda.Fill(invLocDt);
            if (invLocDt.Rows[0][0].ToString() == "0") //Checks in DB if first column, first row equals 0
            {

                string loginUser = Login.user;
                if (confirmResult == DialogResult.Yes)
                {
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;


                    cmd.CommandText = "DELETE FROM LOCATION WHERE LOCATION.ROOM_ID = " +
                        "(SELECT ROOM.ROOM_ID FROM ROOM WHERE ROOM.ROOM_NAME = '" + createRoomTextbox.Text + "' ) ";
                    cmd.ExecuteNonQuery(); //Execute command


                    cmd.CommandText = "DELETE FROM ROOM WHERE ROOM_NAME = '" + createRoomTextbox.Text + "' ";
                    cmd.ExecuteNonQuery();


                    connection.Close(); //Close connection to DB

                    MessageBox.Show("Data deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Room " + createBuildingTextbox.Text + " is already used in previous inventories. Edit or remove them before deleting this room.");
                connection.Close();
            }
        }

        private void displaySearchDescriptionListview(string sDesc_ID)
        {
            string q = "SELECT INVENTORY_DESCRIPTION.DESCRIPTION FROM INVENTORY_DESCRIPTION " +
                       "JOIN INVENTORY ON INVENTORY.DESCRIPTION_ID = INVENTORY_DESCRIPTION.DESCRIPTION_ID " +
                       "WHERE INVENTORY.INVENTORY_ID = '"+ sDesc_ID + "' AND ROWNUM <= 1";

            connection.Open();

            OracleCommand cmd = new OracleCommand(q, connection);

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();

                Console.WriteLine(dr);
                Console.WriteLine(q);
                while (dr.Read())
                {
                    searchDescTextbox.Text = (dr["DESCRIPTION"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            searchDescTextbox.Clear();
            displaySearchDescriptionListview(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}
