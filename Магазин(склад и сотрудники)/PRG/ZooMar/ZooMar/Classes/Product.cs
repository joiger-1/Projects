using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ZooMar
{
    class Product
    {
        private static int MAX_ID;
        private int _id;
        private string _name;
        private int _count;
        private double _price;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Count { get => _count; set => _count = value; }
        public double Price { get => _price; set => _price = value; }

        public Product() { }
        public Product(string name, int count, double price)
        {
            string CommandText = $"select * from [Products]";
            SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Products]");
            _id = ds.Tables["[Products]"].Rows.Count;
            _id = MAX_ID + 1;
            MAX_ID++;
            _name = name;
            _count = count;
            _price = price;
        }
        public Product(int id, string name, int count, double price)
        {
            _id = id;
            if (id >= MAX_ID)
                MAX_ID = id;
            _name = name;
            _count = count;
            _price = price;
        }
        public void Add(Product product)
        {
            if (product._name != _name)
                throw new Exception("Товары различны.");

            _count += product._count;
            product._count = 0;
        }
        public Product Get(int count)
        {
            if(_count < count)
                throw new Exception("Товара не достаточно.");

            _count -= count;
            return new Product(_id, _name, count, _price);
        }
        public void Update()
        {
            string command = $"update [Products] set Name=N'{_name}', Count={_count}, Price={_price} where [Products].Id={_id}";
            Program.My_Execute_Non_Query(command);
        }
        public void Delete()
        {
            string command = $"delete from [Products] where [Products].Id={_id}";
            Program.My_Execute_Non_Query(command);
        }
    }
}