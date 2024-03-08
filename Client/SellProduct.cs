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
    public partial class SellProduct : Form
    {
        private int id;
        private int quantity;
        public SellProduct()
        {
            InitializeComponent();
        }
        private void SellProduct_Load(object sender, EventArgs e)
        {
            try
            {
                // Assuming you have a DataGridView named dataGridView on your form
                Client.ProductServiceReference.ProductServiceClient proxy = new Client.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
                DataSet ds = proxy.GetProducts();

                // Check if the DataSet contains tables
                if (ds != null && ds.Tables.Count > 0)
                {
                    // Assuming you want to display the first table in the DataSet
                    /*DisplayDataSet(ds.Tables[0]);*/
                    listBox1.DataSource = ds.Tables[0].DefaultView;
                    listBox1.DisplayMember = "Name";
                    listBox1.ValueMember = "Id";

                }
                else
                {
                    MessageBox.Show("No data found in the DataSet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            id = int.Parse(listBox1.SelectedValue.ToString());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            quantity = int.Parse(numericUpDown1.Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Client.ProductServiceReference.ProductServiceClient proxy = new Client.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
                string result = proxy.SellProduct(id, quantity);
                if (result != null)
                {
                    MessageBox.Show(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
