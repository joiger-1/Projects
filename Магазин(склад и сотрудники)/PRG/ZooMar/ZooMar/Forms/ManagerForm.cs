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
    partial class ManagerForm : Form
    {
        Form _pref;
        User _user;
        public ManagerForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }
        public ManagerForm(Form pref, User user) : this()
        {
            _pref = pref;
            _user = user;

            Text = user.Name;
            label1.Text += user.Name;
            label2.Text += user.Market.Name;
        }
        public ManagerForm(Form pref) : this()
        {
            _pref = pref;
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ProfileForm(this, _user).Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _pref.Show();
            Dispose();
        }

        private void marketButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MarketForm(this, _user).Show();
        }

        private void ManagerForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void ManagerForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }
    }
}
