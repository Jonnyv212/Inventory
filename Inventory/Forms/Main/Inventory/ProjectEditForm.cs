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
    public partial class ProjectEditForm : Form
    {
        Main main = new Main();
         public OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.26.41)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= Dev.path.med.umich.edu))); USER ID = JONNYV;PASSWORD = AjGoEnvA101");

        public ProjectEditForm()
        {
            InitializeComponent();
        }
        /*
        private void pEditCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pEditApplyButton_Click(object sender, EventArgs e)
        {

        }

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

        public void DisplayRightProjectEditInventory()
        {
            con.Open();
            ProjectsRightDataGrid.DataSource = null;
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            //INDIVIDUAL EQUIPMENT DISPLAY
            cmd.CommandText = "SELECT PROJECT.PROJECT_NAME as Project, INVENTORY.TERM_ID as Term_ID, INVENTORY.INVENTORY_ID AS ID, EQUIPMENT.EQUIPMENT_NAME as Equipment " +
                "FROM INVENTORY " +
                "JOIN EQUIPMENT ON EQUIPMENT.EQUIPMENT_ID = INVENTORY.EQUIPMENT_ID " +
                "JOIN PROJECT ON PROJECT.PROJECT_ID = INVENTORY.PROJECT_ID " +
                "JOIN CATEGORY ON CATEGORY.CATEGORY_ID = INVENTORY.CATEGORY_ID " +
                "WHERE INVENTORY.STATUS = '1' AND PROJECT.PROJECT_NAME =  '" + pNameCombobox.Text + "' " +
                "ORDER BY TERM_ID, TO_NUMBER(INVENTORY_ID) DESC ";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            ProjectsRightDataGrid.DataSource = dta;

            con.Close();

            DataGridViewColumn column1 = ProjectsRightDataGrid.Columns[0];
            column1.Width = 70;

            DataGridViewColumn column2 = ProjectsRightDataGrid.Columns[1];
            column2.Width = 65;

            DataGridViewColumn column3 = ProjectsLeftDataGrid.Columns[2];
            column3.Width = 30;
        }

        public void LoadProjectEdit( string pjName)
        {
            string query = "SELECT PROJECT.PROJECT_NAME, PROJECT.TICKET_NO, PROJECT.PROJECT_DESCRIPTION FROM PROJECT WHERE PROJECT.PROJECT_NAME = '" + pjName + "' ";
            string pj = "SELECT * FROM PROJECT ";


            main.ComboAddRowData(pj, "PROJECT_NAME", ProjectCombobox);
            ProjectCombobox.Text = pjName;


            DisplayLeftProjectEditInventory();
            DisplayRightProjectEditInventory();

            OracleCommand cmd = new OracleCommand(query, con);
            try
            {
                con.Open();

                using (OracleDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        //Read data from column names and display them within textboxes
                        //projectEditNameTextbox.Text = (read["PROJECT_NAME"].ToString());
                        ticketEditNoTextbox.Text = (read["TICKET_NO"].ToString());
                        descEditTextbox.Text = (read["PROJECT_DESCRIPTION"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void ProjectCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProjectEditForm_Load(object sender, EventArgs e)
        {
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            string invenID = ProjectsLeftDataGrid.SelectedRows[0].Cells[2].Value.ToString();
            DataTable rightDataTable = (DataTable)ProjectsRightDataGrid.DataSource;
            DataTable leftDataTable = (DataTable)ProjectsLeftDataGrid.DataSource;

            //string pj = "SELECT PROJECT.PROJECT_NAME FROM PROJECT JOIN INVENTORY ON INVENTORY.PROJECT_ID = PROJECT.PROJECT_ID WHERE INVENTORY_ID = '" + invenID + "' ";

            string pjName = "SELECT PROJECT.PROJECT_NAME FROM PROJECT WHERE PROJECT_NAME = '" + ProjectCombobox.Text + "' ";
            string tID = "SELECT TERM_ID FROM INVENTORY WHERE INVENTORY_ID = '" + invenID + "' ";
            string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE INVENTORY_ID = '" + invenID + "' ";

            con.Open();
            OracleCommand cmd1 = new OracleCommand(pjName, con);
            OracleCommand cmd2 = new OracleCommand(tID, con);
            OracleCommand cmd3 = new OracleCommand(q, con);
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

                rightDataTable.Rows.Add(PJ, TermID, invenID, Eq);
                leftDataTable.Rows.RemoveAt(ProjectsLeftDataGrid.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            string invenID = ProjectsRightDataGrid.SelectedRows[0].Cells[2].Value.ToString();
            DataTable rightDataTable = (DataTable)ProjectsRightDataGrid.DataSource;
            DataTable leftDataTable = (DataTable)ProjectsLeftDataGrid.DataSource;

            int dGridCount = ProjectsRightDataGrid.RowCount;

            string pjName = "SELECT PROJECT.PROJECT_NAME FROM PROJECT JOIN INVENTORY ON INVENTORY.PROJECT_ID = PROJECT.PROJECT_ID WHERE INVENTORY.INVENTORY_ID = '" + invenID + "' ";
            string tID = "SELECT TERM_ID FROM INVENTORY WHERE INVENTORY_ID = '" + invenID + "' ";
            string q = "SELECT EQUIPMENT_NAME FROM EQUIPMENT JOIN INVENTORY ON INVENTORY.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE INVENTORY_ID = '" + invenID + "' ";
            //string IV = "SELECT INVENTORY.INVENTORY_ID FROM INVENTORY WHERE INVENTORY_ID = '" + ProjectsRightDataGrid.SelectedRows[0].Cells[2].Value.ToString() + "' ";

            con.Open();
            OracleCommand cmd1 = new OracleCommand(pjName, con);
            OracleCommand cmd2 = new OracleCommand(tID, con);
            OracleCommand cmd3 = new OracleCommand(q, con);
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

                leftDataTable.Rows.Add(PJ, TermID, invenID, Eq);
                rightDataTable.Rows.RemoveAt(ProjectsRightDataGrid.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

            if (ProjectsRightDataGrid.SelectedRows.Count < 0)
            {
                // ProjectsRightDataGrid.Rows[ProjectsRightDataGrid.Rows.Count - 2].Selected = true;
                leftButton.Enabled = false;
            } 
        }

        private void ProjectsRightDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            leftButton.Enabled = true;
        }
        */
    }
}
