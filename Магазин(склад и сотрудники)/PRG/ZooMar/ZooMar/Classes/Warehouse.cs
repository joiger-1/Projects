using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ZooMar
{
    class Warehouse
    {
        private Dictionary<string, Product> _products;
        public Market Market { get; private set; }
        public Dictionary<string, Product> Products { get => _products; }

        internal Product Product
        {
            get => default;
            set
            {
            }
        }

        public Warehouse() {
            _products = new Dictionary<string, Product>();
        }

        public Warehouse(Market market) : this()
        {
            Market = market;
            //Достать продукты нужного магазина из бд
            string CommandText = $"select * from [Products] where [MarketId]='{Market.Id}'";

            SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Products]");
            foreach (DataRow row in ds.Tables["[Products]"].Rows)
            {
                object[] data = row.ItemArray;
                _products[data[1] as string] = new Product((int)data[0], data[1] as string, (int)data[3], (double)data[2]);
            }
        }
        public object[][] GetTable()
        {
            return _products.Select(x => new object[] { x.Value.Name, x.Value.Price, x.Value.Count }).ToArray();
        }
        public void AddProduct(string name, int count, double price)
        {
            if (_products.ContainsKey(name))
            {
                _products[name].Add(new Product(name, count, price));
                _products[name].Update();
            }
            else
            {
                _products[name] = new Product(name, count, price);

                string CommandText = $"insert into [Products] (Id, Name, Price, Count, MarketId) values({_products[name].Id}, N'{name}', {price.ToString().Replace(",", ".")}, {count}, {Market.Id})";
                Program.My_Execute_Non_Query(CommandText);
            }
        }
        public void DeleteProduct(string name)
        {
            if (!_products.ContainsKey(name))
            {
                new ErrorForm("Продукт не найден");
                return;
            }
            _products[name].Delete();
            _products.Remove(name);
        }
    }
}
