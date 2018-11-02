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
    public partial class CreateItem : Form
    {
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
    }
}
