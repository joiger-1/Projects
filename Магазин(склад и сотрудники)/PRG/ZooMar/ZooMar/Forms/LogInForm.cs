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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;
            if(login == "")
                new ErrorForm("Поле логин не заполнено").ShowDialog();
            if (password == "")
                new ErrorForm("Поле пароль не заполнено").ShowDialog();

            if (login.Where(x => x == ' ' || x == ',' || x == '.' || x == ';' || x == ':' || x == '"' || x == '\'').Any())
                new ErrorForm("Инвалидный логин").ShowDialog();
            if (password.Where(x => x == ' ' || x == ',' || x == '.' || x == ';' || x == ':' || x == '"' || x == '\'').Any())
                new ErrorForm("Инвалидный пароль").ShowDialog();


            string CommandText = $"select * from [Users] where [Login]='{login}' and [Password]='{password}'";
            SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Users]");

            if(ds.Tables["[Users]"].Rows.Count == 0)
            {
                new ErrorForm("Пользователь не найден").ShowDialog();
                return;
            }

            object[] data = ds.Tables["[Users]"].Rows[0].ItemArray;

            (int id, string name, string login, string password, double salary, string type, Market market) user = ((int)data[0], data[1] as string, data[2] as string, data[3] as string, (double)data[4], data[5] as string, null);
            try
            {
                user.market = new Market((int)data[6]);
            }
            catch { }

            User tempUser = new User(user.id, user.name, user.login, user.password, user.salary, user.type, user.market);
            switch (user.type)
            {
                case "Admin":
                    this.Hide();
                    Market.LoadAddData();
                    new AdminForm(this, tempUser).Show();
                    break;
                case "Manager":
                    this.Hide();
                    new ManagerForm(this, tempUser).Show();
                    break;
                case "Seller":
                    this.Hide();
                    user.market.AddUser(tempUser);
                    new SellerForm(this, tempUser).Show();
                    break;
                default:
                    new ErrorForm("Права пользователя не определены").ShowDialog();
                    break;
            }
            loginTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void LogIn_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void LogIn_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }
    }
}
