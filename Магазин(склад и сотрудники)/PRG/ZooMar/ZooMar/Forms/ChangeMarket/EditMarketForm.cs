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
    public partial class EditMarketForm : Form
    {
        public EditMarketForm()
        {
            InitializeComponent();
        }
        public EditMarketForm(string name, string adress) : this()
        {
            nameTextBox.Text = name;
            adressTextBox.Text = adress;
        }
    }
}
