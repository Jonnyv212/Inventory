using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddItem : Form
    {
        CreateItem cItem = new CreateItem();
        public AddItem()
        {
            InitializeComponent();
        }

        private void createItemButton_Click(object sender, EventArgs e)
        {
            cItem.Show();
            this.Hide();
        }
    }
}
