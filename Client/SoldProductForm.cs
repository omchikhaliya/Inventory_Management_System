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
    public partial class SoldProductForm : Form
    {
        public SoldProductForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SoldProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Assuming you have a DataGridView named dataGridView on your form
                Client.ProductServiceReference.ProductServiceClient proxy = new Client.ProductServiceReference.ProductServiceClient("BasicHttpBinding_IProductService");
                DataSet ds = proxy.GetSoldProducts();

                // Check if the DataSet contains tables
                if (ds != null && ds.Tables.Count > 0)
                {
                    // Assuming you want to display the first table in the DataSet
                    DisplayDataSet(ds.Tables[0]);
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

        private void DisplayDataSet(DataTable dataTable)
        {
            // Clear existing rows and columns in the DataGridView
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Add columns to the DataGridView
            foreach (DataColumn column in dataTable.Columns)
            {
                dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
            }

            // Add rows from the DataTable to the DataGridView
            foreach (DataRow row in dataTable.Rows)
            {
                // Add a new row to the DataGridView
                int rowIndex = dataGridView1.Rows.Add();

                // Set values for each cell in the DataGridView
                for (int columnIndex = 0; columnIndex < dataGridView1.Columns.Count; columnIndex++)
                {
                    dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = row[columnIndex];
                }
            }
        }
    }
}
