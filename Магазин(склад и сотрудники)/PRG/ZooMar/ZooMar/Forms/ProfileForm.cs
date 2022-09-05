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
    partial class ProfileForm : Form
    {
        Form _pref;
        User _user;
        public ProfileForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }
        public ProfileForm(Form pref, User user) : this()
        {
            _pref = pref;
            _user = user;

            Text = user.Name;
            label1.Text += user.Name;
            label2.Text += user.Login;
            label3.Text += user.Password;
            label4.Text += user.Salary;
            label5.Text += user.Market.Name;
            label6.Text += user.Type;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            _pref.Show();
            Dispose();
        }

        private void ProfileForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void ProfileForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }
    }
}
