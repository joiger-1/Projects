using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooMar
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void AddProductForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void AddProductForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }
    }
}
