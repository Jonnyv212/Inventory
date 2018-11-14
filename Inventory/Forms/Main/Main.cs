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
    public partial class Main : Form
    {
        CreateItem aItem = new CreateItem();
        DeleteData dItem = new DeleteData();
        TakeInventory tInv = new TakeInventory();
        public Main()
        {
            InitializeComponent();
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            Search sr = new Search();
            sr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 sa = new Form1();
            sa.Show();
            this.Hide();
        }

        private void addEquipmentButton_Click(object sender, EventArgs e)
        {
            aItem.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            dItem.Show();
        }

        private void takeInventoryButton_Click(object sender, EventArgs e)
        {
            tInv.Show();
        }
    }
}
