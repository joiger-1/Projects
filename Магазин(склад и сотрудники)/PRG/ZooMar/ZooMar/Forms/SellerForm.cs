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
    partial class SellerForm : Form
    {
        Form _pref;
        User _user;
        public SellerForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }
        public SellerForm(Form pref, User user) : this()
        {
            _pref = pref;
            _user = user;

            Text = user.Name;
            label1.Text = user.Name;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _pref.Show();
            Dispose();
        }

        private void warehouseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new WarehouseForm(this, _user.Market).Show();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ProfileForm(this, _user).Show();
        }

        private void requestButton_Click(object sender, EventArgs e)
        {

        }

        private void SellerForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void SellerForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }
    }
}
