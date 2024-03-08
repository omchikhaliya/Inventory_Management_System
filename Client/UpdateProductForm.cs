using Client.ProductServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class UpdateProductForm : Form
    {
        private Client.ProductServiceReference.ProductServiceClient proxy;
        private int updatedQuantity;
        public UpdateProductForm()
        {
            InitializeComponent();

            proxy = new Client.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(textBoxId.Text);
                Client.ProductServiceReference.Product product = proxy.GetProductById(productId);

                if (product != null)
                {
                    // Populate textboxes with product details
                    textBoxName.Text = product.ProductName;
                    textBoxDescription.Text = product.ProductDescription;
                    textBoxPrice.Text = product.ProductPrice.ToString();
                    updatedQuantity = int .Parse(product.ProductQuantity.ToString());
                    // Add other textboxes for additional product properties

                    // Enable update button
                    button1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Product not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Clear textboxes
                    ClearTextBoxes();
                    // Disable update button
                    button1.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            // Clear all textboxes
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox) control).Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input (you may want to add more validation based on your requirements)
                if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxPrice.Text) || string.IsNullOrEmpty(textBoxDescription.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the updated values from the textboxes
                int productId = Convert.ToInt32(textBoxId.Text);
                string updatedProductName = textBoxName.Text;
                string updatedProductDescription = textBoxDescription.Text;
                int updatedPrice = Convert.ToInt32(textBoxPrice.Text);
                // Get other updated product properties from corresponding textboxes

                // Call the UpdateProduct method
                string resultMessage = proxy.UpdateProduct(new Client.ProductServiceReference.Product
                {
                    ProductId = productId,
                    ProductName = updatedProductName,
                    ProductDescription = updatedProductDescription,
                    ProductQuantity = updatedQuantity,
                    ProductPrice = updatedPrice,
                    // Set other updated product properties
                });

                MessageBox.Show(resultMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
