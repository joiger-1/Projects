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
    partial class AddUserForm : Form
    {
        private User _user;
        private AddUserForm()
        {
            InitializeComponent();
        }
        public AddUserForm(User user) : this()
        {
            _user = user;
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            if(_user.Type == "Manager")
            {
                accessComboBox.Items.Add("Seller");
                accessComboBox.SelectedIndex = 0;
                accessComboBox.Enabled = false;

                marketComboBox.Items.Add(_user.Market.Name);
                marketComboBox.SelectedIndex = 0;
                marketComboBox.Enabled = false;
            }
            if (_user.Type == "Admin")
            {
                accessComboBox.Items.Add("Seller");
                accessComboBox.Items.Add("Manager");
                accessComboBox.SelectedIndex = 0;

                string[] data = Market.Markets.Select(x => $"({x.Id}){x.Name}").ToArray();
                marketComboBox.Items.AddRange(data);
                marketComboBox.SelectedIndex = 0;
            }
            accessComboBox.SelectedIndex = 0;
        }
    }
}
