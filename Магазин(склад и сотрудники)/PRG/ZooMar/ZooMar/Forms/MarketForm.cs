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
    partial class MarketForm : Form
    {
        Form _pref;
        User _user;
        Market _market;
        public MarketForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }
        public MarketForm(Form pref, User user) : this()
        {
            _pref = pref;
            _user = user;
            _market = user.Market;

            Text = _market.Name;
            label1.Text += _market.Name;
            label2.Text += _market.Adress;
        }
        public MarketForm(Form pref, User user, Market market) : this()
        {
            _pref = pref;
            _user = user;
            _market = market;

            Text = _market.Name;
            label1.Text += _market.Name;
            label2.Text += _market.Adress;
        }

        private void warehouseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new WarehouseForm(this, _market).Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            _pref.Show();
            Dispose();
        }

        private void MarketForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void MarketForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UsersListForm(this, _user, _market).Show();
        }
    }
}
