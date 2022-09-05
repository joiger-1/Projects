using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooMar
{
    partial class UsersListForm : Form
    {
        Form _pref;
        User _user;
        Market _market;
        public UsersListForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }
        public UsersListForm(Form pref, User user) : this()
        {
            _pref = pref;
            _user = user;
            _market = _user.Market;

            Text = "Персонал";
            label1.Text = "Персонал";

            LoadDataGrid();
        }
        public UsersListForm(Form pref, User user, Market market) : this()
        {
            _pref = pref;
            _user = user;
            _market = market;

            Text = "Персонал";
            label1.Text = "Персонал";

            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            if(_market != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new string[] { "Id", "Имя", "Доступ", "Запрлата(руб.)" }.Select(x => new DataColumn(x)).ToArray());
                List<User> data = _market.Sellers.Select(x => x.Value).ToList();
                data.AddRange(_market.Managers.Select(x => x.Value));
                for (int i = 0; i < data.Count; i++)
                {
                    dt.Rows.Add(data[i].Id, data[i].Name, data[i].Type, data[i].Salary);
                }
                usersGridView.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new string[] { "Id", "Имя", "Доступ", "Запрлата(руб.)", "Магазин" }.Select(x => new DataColumn(x)).ToArray());
                List<User> data = User.Users;
                for (int i = 0; i < data.Count; i++)
                {
                    if(data[i].Market != null)
                        dt.Rows.Add(data[i].Id, data[i].Name, data[i].Type, data[i].Salary, $"({data[i].Market.Id}){data[i].Market.Name}");
                    else
                        dt.Rows.Add(data[i].Id, data[i].Name, data[i].Type, data[i].Salary, "");
                }
                usersGridView.DataSource = dt;
            }
            
        }
        private void UsersListForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }

        private void UsersListForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _pref.Show();
            Dispose();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(_user);
            addUserForm.ShowDialog();
            if (addUserForm.DialogResult == DialogResult.OK)
            {
                (string name, string login, string password, double salary, string type, int marketId) tempUser;
                tempUser.name = addUserForm.nameTextBox.Text;
                tempUser.login = addUserForm.loginTextBox.Text;
                tempUser.password = addUserForm.passwordTextBox.Text;
                tempUser.type = addUserForm.accessComboBox.SelectedItem as string;
                tempUser.marketId = addUserForm.marketComboBox.SelectedIndex;

                try
                {
                    tempUser.salary = double.Parse(addUserForm.salaryTextBox.Text.Replace(',', '.'));
                }
                catch(Exception err){
                    new ErrorForm("Поле запрлата заполнено неккоректно").ShowDialog();return;
                }

                string CommandText = $"select * from [Users] where [Login]='{tempUser.login}'";
                SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
                DataSet ds = new DataSet();
                da.Fill(ds, "[Users]");
                if (ds.Tables["[Users]"].Rows.Count != 0)
                {
                    new ErrorForm("Такой пользователь уже есть").ShowDialog();
                    return;
                }

                CommandText = $"select max(Id) from [Users]";
                da = new SqlDataAdapter(CommandText, Program.conStr);
                ds = new DataSet();
                da.Fill(ds, "[Users]");
                object[] data = ds.Tables["[Users]"].Rows[0].ItemArray;
                int maxId = (int)data[0] + 1;

                Market market;
                if (_user.Type == "Manager")
                {
                    CommandText = $"insert into [Users] values({maxId}, N'{tempUser.name}', N'{tempUser.login}', N'{tempUser.password}', {tempUser.salary.ToString().Replace(',', '.')}, '{tempUser.type}', {_user.Market.Id})";
                    market = _user.Market;
                }
                else
                {
                    CommandText = $"insert into [Users] values({maxId}, N'{tempUser.name}', N'{tempUser.login}', N'{tempUser.password}', {tempUser.salary.ToString().Replace(',', '.')}, '{tempUser.type}', {tempUser.marketId})";
                    market = Market.Markets.Where(x => x.Id == tempUser.marketId).ToArray()[0];
                }
                Program.My_Execute_Non_Query(CommandText);

                market.AddUser(new User(maxId, tempUser.name, tempUser.login, tempUser.password, tempUser.salary, tempUser.type, market));
                LoadDataGrid();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (usersGridView.SelectedRows.Count == 0)
                return;
            string type = usersGridView.SelectedRows[0].Cells[2].Value as string;
            if (((type == "Manager" || type == "Admin") && _user.Type == "Manager") ||
                (type == "Admin" && _user.Type == "Admin"))
            {
                new ErrorForm("Отказано в доступе").ShowDialog();
                return;
            }
            int id = int.Parse(usersGridView.SelectedRows[0].Cells[0].Value as string);

            EditUserForm editUserForm = new EditUserForm(_user, User.Users.Where(x => x.Id==id).ToArray()[0]);
            editUserForm.ShowDialog();
            if (editUserForm.DialogResult == DialogResult.OK)
            {
                (string name, string login, string password, double salary, string type, int marketId) tempUser;
                tempUser.name = editUserForm.nameTextBox.Text;
                tempUser.login = editUserForm.loginTextBox.Text;
                tempUser.password = editUserForm.passwordTextBox.Text;
                tempUser.type = editUserForm.accessComboBox.SelectedItem as string;
                tempUser.marketId = editUserForm.marketComboBox.SelectedIndex;

                try
                {
                    tempUser.salary = double.Parse(editUserForm.salaryTextBox.Text.Replace('.', ','));
                }
                catch (Exception err)
                {
                    new ErrorForm("Поле запрлата заполнено неккоректно").ShowDialog(); return;
                }
                string CommandText = $"select * from [Users] where [Login]='{tempUser.login}'";
                SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
                DataSet ds = new DataSet();
                da.Fill(ds, "[Users]");
                if (ds.Tables["[Users]"].Rows.Count != 0 && (int)ds.Tables["[Users]"].Rows[0].ItemArray[0] != id)
                {
                    new ErrorForm("Такой пользователь уже есть").ShowDialog();
                    return;
                }

                CommandText = $"update [Users] set Name=N'{tempUser.name}', Login=N'{tempUser.login}', Password=N'{tempUser.password}', Salary={tempUser.salary.ToString().Replace(',', '.')}, Type='{tempUser.type}', MarketId={tempUser.marketId} where [Id]={id}";
                Program.My_Execute_Non_Query(CommandText);

                User user = User.Users.Where(x => x.Id == id).ToArray()[0];
                user.Name = tempUser.name;
                user.Login = tempUser.login;
                user.Password = tempUser.password;
                user.Salary = tempUser.salary;
                user.Type = tempUser.type;
                user.Market = Market.Markets.Where(x => x.Id == tempUser.marketId).ToArray()[0];

                LoadDataGrid();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (usersGridView.SelectedRows.Count == 0)
                return;
            string type = usersGridView.SelectedRows[0].Cells[2].Value as string;
            if (((type == "Manager" || type == "Admin") && _user.Type == "Manager")||
                (type == "Admin" && _user.Type == "Admin"))
            {
                new ErrorForm("Отказано в доступе").ShowDialog();
                return;
            }

            int id = int.Parse(usersGridView.SelectedRows[0].Cells[0].Value as string);

            string CommandText = $"delete from [Users] where [Id]={id}";
            Program.My_Execute_Non_Query(CommandText);

            User user = User.Users.Where(x => x.Id==id).ToArray()[0];
            user.Market.DeleteUser(user.Id);
            User.DeleteUser(user.Id);

            LoadDataGrid();
        }
    }
}
