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
    partial class MarketListForm : Form
    {
        private Form _pref;
        private User _user;

        public MarketListForm()
        {
            InitializeComponent();
            Location = Program.FormLocation;
        }
        public MarketListForm(Form pref, User user) : this()
        {
            _pref = pref;
            _user = user;
        }
        private void MarketListForm_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            marketGridView.Rows.Clear();
            object[][] data = Market.Markets.Select(x => new object[] { x.Id, x.Name, x.Adress }).ToArray();
            for (int i = 0; i < data.Length; i++)
            {
                marketGridView.Rows.Add(data[i][0], data[i][1], data[i][2]);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _pref.Show();
            Dispose();
        }


        private void addProductButton_Click(object sender, EventArgs e)
        {
            AddMarketForm addMarketForm = new AddMarketForm();
            addMarketForm.ShowDialog();
            if (addMarketForm.DialogResult == DialogResult.OK)
            {
                (string name, string adress) market = (addMarketForm.nameTextBox.Text, addMarketForm.adressTextBox.Text);

                string CommandText = $"select * from [Markets] where [Name]='{market.name}' and [Adress]='{market.adress}'";
                SqlDataAdapter da = new SqlDataAdapter(CommandText, Program.conStr);
                DataSet ds = new DataSet();
                da.Fill(ds, "[Markets]");
                if (ds.Tables["[Markets]"].Rows.Count != 0)
                {
                    new ErrorForm("Такой магазин уже есть").ShowDialog();
                    return;
                }
                Market.AddMarket(market.name, market.adress);
                LoadDataGrid();
            }
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            if (marketGridView.SelectedRows.Count == 0)
                return;
            int marketId = (int)marketGridView.SelectedRows[0].Cells[0].Value;
            Market changeMarket = Market.Markets.Where(x => x.Id == marketId).ToArray()[0];

            EditMarketForm editMarketForm = new EditMarketForm(changeMarket.Name, changeMarket.Adress);
            editMarketForm.ShowDialog();
            if (editMarketForm.DialogResult == DialogResult.OK)
            {
                (string name, string adress) market = (editMarketForm.nameTextBox.Text, editMarketForm.adressTextBox.Text);

                changeMarket.Name = market.name;
                changeMarket.Adress = market.adress;

                changeMarket.Update();
                LoadDataGrid();
            }
        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            if (marketGridView.SelectedRows.Count == 0)
                return;

            int id = (int)marketGridView.SelectedRows[0].Cells[0].Value;

            Market.DeleteMarket(id);

            LoadDataGrid();
        }
        private void MarketListForm_Move(object sender, EventArgs e)
        {
            Program.FormMove(sender, e);
        }
        private void MarketListForm_Shown(object sender, EventArgs e)
        {
            Program.FormShown(sender, e);
        }

        private void openMarketButton_Click(object sender, EventArgs e)
        {
            if (marketGridView.SelectedRows.Count == 0)
                return;

            int id = (int)marketGridView.SelectedRows[0].Cells[0].Value;
            Market market = Market.Markets.Where(x => x.Id == id).ToArray()[0];
            this.Hide();
            new MarketForm(this, _user, market).Show();
        }
    }
}
