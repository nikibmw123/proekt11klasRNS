using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fruitShopDataSet.Vegans' table. You can move, or remove it, as needed.
            this.vegansTableAdapter.Fill(this.fruitShopDataSet.Vegans);
            // TODO: This line of code loads data into the 'fruitShopDataSet.VeganTypes' table. You can move, or remove it, as needed.
            this.veganTypesTableAdapter.Fill(this.fruitShopDataSet.VeganTypes);

        }
    }
}
