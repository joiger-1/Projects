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
    partial class AdminForm : Form
    {
        Form _pref;
        User _user;
        public AdminForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }
        public AdminForm(Form pref, User user) : this()
        {
            _pref = pref;
            _user = user;

            Text = user.Name;
            label1.Text += user.Name;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _pref.Show();
            Dispose();
        }

        private void AdminForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void AdminForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }

        private void usersListButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UsersListForm(this, _user).Show();
        }

        private void marketListButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MarketListForm(this, _user).Show();
        }
    }
}
