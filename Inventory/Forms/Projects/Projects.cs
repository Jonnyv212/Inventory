using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Inventory
{
    class Projects
    {
        /*
        public void DisplayLeftProjectEditInventory()
        {
            con.Open();
            ProjectsLeftDataGrid.DataSource = null;
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            //INDIVIDUAL EQUIPMENT DISPLAY
            cmd.CommandText = "SELECT PROJECT.PROJECT_NAME as Project, INVENTORY.TERM_ID as Term_ID, INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME as Equipment " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "WHERE INVENTORY.STATUS = '1' AND PROJECT.PROJECT_NAME != '" + pNameCombobox.Text + "' " +
                "ORDER BY TERM_ID, PROJECT_NAME, TO_NUMBER(INVENTORY_ID) DESC ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            ProjectsLeftDataGrid.DataSource = dta;

            con.Close();

            DataGridViewColumn column1 = ProjectsLeftDataGrid.Columns[0];
            column1.Width = 70;

            DataGridViewColumn column2 = ProjectsLeftDataGrid.Columns[1];
            column2.Width = 65;

            DataGridViewColumn column3 = ProjectsLeftDataGrid.Columns[2];
            column3.Width = 30;
        }
        */

        Main main = new Main();

        public void DisplayRightProjectGrid(ComboBox Project, DataGridView dGridView)
        {
            string query = "SELECT PROJECT.PROJECT_NAME as Project, INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME as Equipment, CATEGORY.CATEGORY_NAME as Category, INVENTORY.TERM_ID as Term_ID " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "WHERE INVENTORY.STATUS = '1' AND PROJECT.PROJECT_NAME = '" + Project.Text + "' " +
                "ORDER BY TERM_ID, TO_NUMBER(INVENTORY_ID) DESC ";

            dGridView.DataSource = null;
            dGridView.DataSource = main.DataTableSQLQuery(query);

            DataGridViewColumn column1 = dGridView.Columns[0];
            column1.Width = 70;
            DataGridViewColumn column2 = dGridView.Columns[1];
            column2.Width = 35;
            DataGridViewColumn column3 = dGridView.Columns[2];
            column3.Width = 160;
            DataGridViewColumn column4 = dGridView.Columns[3];
            column4.Width = 70;
        }

        public void LoadProjectEdit(ComboBox Project, TextBox Ticket, RichTextBox Desc, OracleConnection connection)
        {
            string query = "SELECT PROJECT.PROJECT_NAME, PROJECT.TICKET_NO, PROJECT.PROJECT_DESCRIPTION FROM PROJECT WHERE PROJECT.PROJECT_NAME = '" + Project.Text + "' ";
            //string pj = "SELECT * FROM PROJECT WHERE PROJECT_NAME != 'Unassigned' ";

            //pNameCombobox.SelectedIndex = 2;

            //DisplayLeftProjectEditInventory();
            //DisplayProjects(ProjectsLeftDataGrid);

            OracleCommand cmd = new OracleCommand(query, connection);
            try
            {
                connection.Open();

                using (OracleDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        //Read data from column names and display them within textboxes
                        //projectEditNameTextbox.Text = (read["PROJECT_NAME"].ToString());
                        Ticket.Text = (read["TICKET_NO"].ToString());
                        Desc.Text = (read["PROJECT_DESCRIPTION"].ToString());
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void MoveToLeft(Button Left, DataGridView dGridViewLeft, DataGridView dGridViewRight, OracleConnection connection)
        {
            string invenID = dGridViewRight.SelectedRows[0].Cells[1].Value.ToString();
            DataTable rightDataTable = (DataTable)dGridViewRight.DataSource;
            DataTable leftDataTable = (DataTable)dGridViewLeft.DataSource;

            int dGridCount = dGridViewRight.Rows.Count;

            string pjName = "SELECT PROJECT.PROJECT_NAME FROM PROJECT JOIN INVENTORY ON INVENTORY.PROJECT_ID = PROJECT.PROJECT_ID WHERE INVENTORY.INVENTORY_ID = '" + invenID + "' ";
            string tID = "SELECT TERM_ID FROM INVENTORY WHERE INVENTORY_ID = '" + invenID + "' ";
            string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE INVENTORY_ID = '" + invenID + "' ";
            string c = "SELECT CATEGORY_NAME FROM CATEGORY JOIN INVENTORY ON INVENTORY.CATEGORY_ID = CATEGORY.CATEGORY_ID WHERE INVENTORY_ID = '" + invenID + "' ";

            connection.Open();
            OracleCommand cmd1 = new OracleCommand(pjName, connection);
            OracleCommand cmd2 = new OracleCommand(tID, connection);
            OracleCommand cmd3 = new OracleCommand(q, connection);
            OracleCommand cmd4 = new OracleCommand(c, connection);
            try
            {
                cmd1.CommandText = pjName;
                cmd1.CommandType = CommandType.Text;
                String PJ = cmd1.ExecuteScalar().ToString();

                cmd2.CommandText = tID;
                cmd2.CommandType = CommandType.Text;
                String TermID = cmd2.ExecuteScalar().ToString();

                cmd3.CommandText = q;
                cmd3.CommandType = CommandType.Text;
                String Eq = cmd3.ExecuteScalar().ToString();

                cmd4.CommandText = c;
                cmd4.CommandType = CommandType.Text;
                String Cat = cmd4.ExecuteScalar().ToString();

                leftDataTable.Rows.Add(PJ, invenID, Eq, Cat, TermID);
                rightDataTable.Rows.RemoveAt(dGridViewRight.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            if (dGridViewRight.Rows.Count == 0)
            {
                Console.WriteLine("Right is empty");
                Left.Enabled = false;
            }

            else if (dGridViewRight.CurrentRow.Index == dGridViewRight.Rows.Count - 1)
            {

                dGridViewRight.Rows[dGridViewRight.Rows.Count - 1].Selected = true;
            }
        }

        public void MoveToRight(ComboBox Project, Button Right, DataGridView dGridViewRight, DataGridView dGridViewLeft, OracleConnection connection)
        {
            string invenID = dGridViewLeft.SelectedRows[0].Cells[1].Value.ToString();
            DataTable rightDataTable = (DataTable)dGridViewRight.DataSource;
            DataTable leftDataTable = (DataTable)dGridViewLeft.DataSource;

            //string pj = "SELECT PROJECT.PROJECT_NAME FROM PROJECT JOIN INVENTORY ON INVENTORY.PROJECT_ID = PROJECT.PROJECT_ID WHERE INVENTORY_ID = '" + invenID + "' ";

            string pjName = "SELECT PROJECT.PROJECT_NAME FROM PROJECT WHERE PROJECT_NAME = '" + Project.Text + "' ";
            string tID = "SELECT TERM_ID FROM INVENTORY WHERE INVENTORY_ID = '" + invenID + "' ";
            string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE INVENTORY_ID = '" + invenID + "' ";
            string c = "SELECT CATEGORY_NAME FROM CATEGORY JOIN INVENTORY ON INVENTORY.CATEGORY_ID = CATEGORY.CATEGORY_ID WHERE INVENTORY_ID = '" + invenID + "' ";

            connection.Open();
            OracleCommand cmd1 = new OracleCommand(pjName, connection);
            OracleCommand cmd2 = new OracleCommand(tID, connection);
            OracleCommand cmd3 = new OracleCommand(q, connection);
            OracleCommand cmd4 = new OracleCommand(c, connection);
            try
            {
                cmd1.CommandText = pjName;
                cmd1.CommandType = CommandType.Text;
                String PJ = cmd1.ExecuteScalar().ToString();

                cmd2.CommandText = tID;
                cmd2.CommandType = CommandType.Text;
                String TermID = cmd2.ExecuteScalar().ToString();

                cmd3.CommandText = q;
                cmd3.CommandType = CommandType.Text;
                String Eq = cmd3.ExecuteScalar().ToString();

                cmd4.CommandText = c;
                cmd4.CommandType = CommandType.Text;
                String Cat = cmd4.ExecuteScalar().ToString();

                rightDataTable.Rows.Add(PJ, invenID, Eq, Cat, TermID);
                leftDataTable.Rows.RemoveAt(dGridViewLeft.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            if (dGridViewLeft.Rows.Count == 0)
            {
                Console.WriteLine("Right is empty");
                Right.Enabled = false;
            }

            else if (dGridViewLeft.CurrentRow.Index == dGridViewLeft.Rows.Count - 1)
            {
                dGridViewLeft.Rows[dGridViewLeft.Rows.Count - 1].Selected = true;
            }
        }

        public void DisplayProjects(ComboBox Project, DataGridView DataGrid)
        {
            string query = "SELECT PROJECT_NAME as Project, TICKET_NO as Ticket, COUNT(INVENTORY.EQUIPMENT_ID) AS Stock " +
                "FROM PROJECT " +
                "LEFT JOIN INVENTORY ON INVENTORY.PROJECT_ID = PROJECT.PROJECT_ID " +
                "WHERE PROJECT.PROJECT_NAME != '" + Project.Text + "' AND INVENTORY.STATUS = '1' " +
                "GROUP BY PROJECT.PROJECT_ID, PROJECT_NAME, TICKET_NO " +
                "ORDER BY PROJECT.PROJECT_ID ";

            DataGrid.DataSource = null;
            DataGrid.DataSource = main.DataTableSQLQuery(query);
            //DataGrid.Refresh();
        }

        public void DisplayProjectStock(string pName, DataGridView dataGrid)
        {
            string query =  "SELECT PROJECT.PROJECT_NAME as Project, CATEGORY.CATEGORY_NAME as Category, COUNT(INVENTORY.EQUIPMENT_ID) AS Stock " +
                            "FROM INVENTORY " +
                            "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                            "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                            "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                            "WHERE INVENTORY.STATUS = '1' AND PROJECT.PROJECT_NAME = ('" + pName + "') " +
                            "GROUP BY PROJECT.PROJECT_NAME, CATEGORY.CATEGORY_NAME " +
                            "ORDER BY STOCK DESC";

            dataGrid.DataSource = null;
            dataGrid.DataSource = main.DataTableSQLQuery(query);
        }

        public void DisplayProjectData(string pName, string catName, DataGridView dataGrid)
        {
            string query = "SELECT PROJECT.PROJECT_NAME as Project, INVENTORY.INVENTORY_ID as ID, EQUIPMENT.EQUIPMENT_NAME as Equipment, CATEGORY.CATEGORY_NAME as Category, INVENTORY.TERM_ID as Term_ID " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "WHERE INVENTORY.STATUS = '1' AND PROJECT.PROJECT_NAME = '" + pName + "' AND CATEGORY.CATEGORY_NAME = '" + catName + "' " +
                "ORDER BY INVENTORY_DATE DESC ";

            dataGrid.DataSource = null;
            dataGrid.DataSource = main.DataTableSQLQuery(query);

            DataGridViewColumn column1 = dataGrid.Columns[0];
            column1.Width = 70;
            DataGridViewColumn column2 = dataGrid.Columns[1];
            column2.Width = 30;
            DataGridViewColumn column3 = dataGrid.Columns[2];
            column3.Width = 150;
            DataGridViewColumn column4 = dataGrid.Columns[3];
            column4.Width = 90;
        }
    }
}
