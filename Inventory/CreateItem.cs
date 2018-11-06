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

namespace WindowsFormsApp1
{
    public partial class CreateItem : Form
    {
        OracleConnection connection = new OracleConnection(@"DATA SOURCE = pathDEV2.world; PERSIST SECURITY INFO=True;USER ID = JONNYV;PASSWORD = AjGoEnvA101");
        CreateItemPreview pItem = new CreateItemPreview();
        public CreateItem()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            pItem.Show();
            pItem.display_preview_data();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            AddToDB();
        }
        public void AddToDB()
        {
            connection.Open();
            //Login login = new Login();
            //login.user = login.usernameTextbox.Text;
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into INVENTORY (NAME, ITEM_CAT, ITEM_SUB_CAT1, ITEM_SUB_CAT2, ITEM_SUB_CAT3, LOCATION, ACTIVITY_BY, DATE)" + "VALUES ('"+nameTextbox.Text+"','"+catTextbox.Text+"','" + sub1Textbox.Text + "','" + sub2Textbox.Text + "','" + sub3Textbox.Text + "','"+locationTextbox.Text+ "', 'Jonnyv', 'SYSDATE')"; // SQL Command
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            OracleDataAdapter dataadp = new OracleDataAdapter(cmd);
            dataadp.Fill(dta);
            //dataGridView1.DataSource = dta;
            connection.Close();
            nameTextbox.Text = ""; //Clear textboxes    
            catTextbox.Text = "";
            locationTextbox.Text = "";
            sub1Textbox.Text = "";
            sub2Textbox.Text = "";
            sub3Textbox.Text = "";
            MessageBox.Show("Data inserted successfully!");
        }
    }
}
