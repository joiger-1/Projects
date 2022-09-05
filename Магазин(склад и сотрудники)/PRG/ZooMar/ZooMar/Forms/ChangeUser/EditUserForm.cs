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
    partial class EditUserForm : Form
    {
        private User _user;
        private User _editUser;
        private EditUserForm()
        {
            InitializeComponent();
        }
        public EditUserForm(User user, User editUser) : this()
        {
            _user = user;
            _editUser = editUser;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = _editUser.Name;
            loginTextBox.Text = _editUser.Login;
            passwordTextBox.Text = _editUser.Password;
            salaryTextBox.Text = _editUser.Salary.ToString();
            if (_user.Type == "Manager")
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
            marketComboBox.SelectedIndex = _editUser.Market.Id;
            accessComboBox.SelectedItem = _editUser.Type;
        }
    }
}
