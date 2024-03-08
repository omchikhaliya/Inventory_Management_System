using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PurchasedProductForm form = new PurchasedProductForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoldProductForm form = new SoldProductForm();
            form.ShowDialog();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            PurchasedProduct form = new PurchasedProduct();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SellProduct form = new SellProduct();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateProductForm form = new UpdateProductForm();
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteProductForm form = new DeleteProductForm();
            form.ShowDialog();
        }
    }
}
