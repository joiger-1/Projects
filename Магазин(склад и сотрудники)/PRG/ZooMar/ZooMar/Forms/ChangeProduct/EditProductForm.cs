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
    public partial class EditProductForm : Form
    {
        public EditProductForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }
        public EditProductForm(string name, double price, int count) : this()
        {
            nameTextBox.Text = name;
            priceTextBox.Text = price.ToString();
            countTextBox.Text = count.ToString();
        }

        private void EditProductForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void EditProductForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }
    }
}
