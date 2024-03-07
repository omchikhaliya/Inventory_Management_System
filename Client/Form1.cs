﻿using System;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
