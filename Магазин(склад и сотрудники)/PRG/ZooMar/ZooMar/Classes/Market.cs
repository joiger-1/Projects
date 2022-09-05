using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ZooMar
{
    class Market
    {
        static public List<Market> Markets { get; private set; }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public Dictionary<int, User> Managers { get; private set; }
        public Dictionary<int, User> Sellers { get; private set; }
        public Warehouse Warehouse { get; private set; }
        static Market()
        {
            Markets = new List<Market>();
        }
        static public void LoadAddData()
        {
            string CommandText = $"select [Id] from [Markets]";
            SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Markets]");
            for(int i = 0; i < ds.Tables["[Markets]"].Rows.Count; i++)
            {
                object[] data = ds.Tables["[Markets]"].Rows[i].ItemArray;

                new Market((int)data[0]);
            }
        }
        public Market(int id)
        {
            if(Markets.Where(x => x.Id==id).Count() == 0)
                Markets.Add(this);
            Id = id;
            FillInfo();
            Managers = new Dictionary<int, User>();
            Sellers = new Dictionary<int, User>();
            FillUsers();
            Warehouse = new Warehouse(this);
        }
        private void FillInfo()
        {
            string CommandText = $"select * from [Markets] where [Id]={Id}";
            SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Markets]");
            object[] data = ds.Tables["[Markets]"].Rows[0].ItemArray;

            Name = data[1] as string;
            Adress = data[2] as string;
        }
        private void FillUsers()
        {
            string CommandText = $"select * from [Users] where [MarketId]={Id}";
            SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Users]");
            DataRowCollection table = ds.Tables["[Users]"].Rows;
            List<object[]> dataList = new List<object[]>();
            for(int i = 0; i < table.Count; i++)
            {
                object[] data = table[i].ItemArray;
                if(data[5] as string == "Seller")
                {
                    if (Sellers.ContainsKey((int)data[0]))
                        continue;
                    Sellers[(int)data[0]] = new User((int)data[0], data[1] as string, data[2] as string, data[3] as string, (double)data[4], data[5] as string, this);
                }
                if (data[5] as string == "Manager")
                {
                    if (Managers.ContainsKey((int)data[0]))
                        continue;
                    Managers[(int)data[0]] = new User((int)data[0], data[1] as string, data[2] as string, data[3] as string, (double)data[4], data[5] as string, this);
                }
            }

        }
        public void UpdateUserData()
        {
            Sellers = new Dictionary<int, User>();
            FillUsers();
        }
        public void AddUser(User user)
        {
            Sellers[user.Id] = (user);
        }
        public void DeleteUser(int id)
        {
            Sellers.Remove(Id);
        }

        static public void DeleteMarket(int id)
        {
            Markets = Markets.Where(x => x.Id != id).ToList();

            string command = $"delete from [Markets] where [Id]={id}";
            Program.My_Execute_Non_Query(command);
        }
        static public void AddMarket(string name, string adress)
        {
            int id = Markets.Select(x => x.Id).Max()+1;
            string command = $"insert into [Markets] values({id}, N'{name}', N'{adress}')";
            Program.My_Execute_Non_Query(command);
            new Market(id);
        }
        public void Update()
        {
            string command = $"update [Markets] set Name=N'{Name}', Adress=N'{Adress}' where Id={Id}";
            Program.My_Execute_Non_Query(command);
        }

        internal User User
        {
            get => default;
            set
            {
            }
        }
    }
}