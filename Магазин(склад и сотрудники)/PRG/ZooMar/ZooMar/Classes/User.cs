using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooMar
{
    class User
    {
        static public List<User> Users { get; private set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public string Type { get; set; }
        public Market Market { get; set; }

        internal Market Market1
        {
            get => default;
            set
            {
            }
        }

        static User()
        {
            Users = new List<User>();
        }
        public User(int id, string name, string login, string password, double salary, string type, Market market)
        {
            if(Users.Where(x => x.Id == id).Count() == 0)
                Users.Add(this);

            Name = name;
            Login = login;
            Password = password;
            Market = market;
            Salary = salary;
            Type = type;
            Id = id;
        }
        public void Update()
        {
            string command = $"update [Users] set Name={Name}, Login={Login}, Password={Password}, Salary={Salary.ToString().Replace(',', '.')}, Type={Type}, MarketId={Market.Id} where Id={Id}";
            Program.My_Execute_Non_Query(command);
        }
        static public void DeleteUser(int id)
        {
            Users = Users.Where(x => x.Id != id).ToList();
        }
    }
}