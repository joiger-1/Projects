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
    partial class WarehouseForm : Form
    {
        private Form _pref;
        private Market _market;

        public WarehouseForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }
        public WarehouseForm(Form pref, Market market) : this()
        {
            _pref = pref;
            _market = market;

            Text = $"Склад магазина {_market.Name}";
            label1.Text = $"Склад магазина {_market.Name}";
        }
        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new string[] { "Наименование товара", "Цена", "Количество" }.Select(x => new DataColumn(x)).ToArray());
            object[][] data = _market.Warehouse.GetTable();
            for (int i = 0; i < data.Length; i++)
            {
                dt.Rows.Add(data[i][0], data[i][1], data[i][2]);
            }
            productGridView.DataSource = dt;
            productGridView.Columns[0].Width = 220;
            productGridView.Columns[1].Width = 50;
            productGridView.Columns[2].Width = 80;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _pref.Show();
            Dispose();
        }


        private void addProductButton_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
            if (addProductForm.DialogResult == DialogResult.OK)
            {
                (string name, int count, double price) product = (addProductForm.nameTextBox.Text, int.Parse(addProductForm.countTextBox.Text), double.Parse(addProductForm.priceTextBox.Text.Replace(".", ",")));

                string CommandText = $"select * from [Products] where [Name]='{product.name}' and [MarketId]='{_market.Id}'";
                SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
                DataSet ds = new DataSet();
                da.Fill(ds, "[Products]");
                if (ds.Tables["[Products]"].Rows.Count != 0)
                {
                    new ErrorForm("Такой продукт уже есть").ShowDialog();
                    return;
                }
                _market.Warehouse.AddProduct(product.name, product.count, product.price);
                LoadDataGrid();
            }
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            if (productGridView.SelectedRows.Count == 0)
                return;
            string productName = productGridView.SelectedRows[0].Cells[0].Value as string;
            Product changeProduct = _market.Warehouse.Products[productName];

            EditProductForm editProductForm = new EditProductForm(changeProduct.Name, changeProduct.Price, changeProduct.Count);
            editProductForm.ShowDialog();
            if (editProductForm.DialogResult == DialogResult.OK)
            {
                (string name, int count, double price) product = (editProductForm.nameTextBox.Text, int.Parse(editProductForm.countTextBox.Text), double.Parse(editProductForm.priceTextBox.Text.Replace(".", ",")));

                changeProduct.Name = product.name;
                changeProduct.Count = product.count;
                changeProduct.Price = product.price;

                changeProduct.Update();
                LoadDataGrid();
            }
        }
        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            if (productGridView.SelectedRows.Count == 0)
                return;
            _market.Warehouse.DeleteProduct(productGridView.SelectedRows[0].Cells[0].Value as string);
            LoadDataGrid();
        }
        private void WarehouseForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }

        private void WarehouseForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }
    }
}
