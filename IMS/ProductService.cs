using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Linq;


namespace IMS
{
    public class ProductService : IProductService
    {
        private string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        DataSet IProductService.GetProducts()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Name, Description, Quantity, Price FROM [Products]", connection_string);
            DataSet ds = new DataSet();
            da.Fill(ds, "products");
            return ds;
        }

        string IProductService.AddProduct(Product p)
        {
            string resultMessage = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO Products (Name, Description, Quantity, Price) VALUES (@name, @description, @quantity, @price); SELECT SCOPE_IDENTITY()", connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@name", p.ProductName);
                        command.Parameters.AddWithValue("@description", p.ProductDescription);
                        command.Parameters.AddWithValue("@price", p.ProductPrice);
                        command.Parameters.AddWithValue("@quantity", p.ProductQuantity);

                        // ExecuteScalar is used to get the ID of the newly inserted product
                        int newProductId = Convert.ToInt32(command.ExecuteScalar());

                        if (newProductId > 0)
                        {
                            resultMessage = $"Product added successfully. New Product ID: {newProductId}";
                        }
                        else
                        { 
                            resultMessage = "Error adding product. Please check your input.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log or rethrow)
                resultMessage = $"Error adding product: {ex.Message}";
            }
            return resultMessage;
        }

        string IProductService.UpdateProduct(Product p)
        {
            string resultMessage = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UPDATE Products SET Name = @name, Description = @description, Price = @price, Quantity = @quantity WHERE Id = @id", connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@id", p.ProductId);
                        command.Parameters.AddWithValue("@name", p.ProductName);
                        command.Parameters.AddWithValue("@description", p.ProductName);
                        command.Parameters.AddWithValue("@price", p.ProductPrice);
                        command.Parameters.AddWithValue("@quantity", p.ProductQuantity);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            resultMessage = $"Product with ID {p.ProductId} updated successfully.";
                        }
                        else
                        {
                            resultMessage = $"Product with ID {p.ProductId} not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log or rethrow)
                resultMessage = $"Error updating product: {ex.Message}";
            }

            return resultMessage;
        }



        string IProductService.DeleteProduct(int id)
        {
            string resultMessage = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE Id = @id", connection))
                    {
                        // Add parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            resultMessage = $"Product with ID {id} deleted successfully.";
                        }
                        else
                        {
                            resultMessage = $"Product with ID {id} not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log or rethrow)
                resultMessage = $"Error deleting product: {ex.Message}";
            }

            return resultMessage;
        }

        string IProductService.PurchaseProduct(int id, int quantity)
        {
            string resultMessage = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();

                    // Retrieve product information
                    Product product = GetProductById(id);

                    if (product != null)
                    {
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Update product quantity in the Products table
                                using (SqlCommand updateCommand = new SqlCommand("UPDATE Products SET Quantity = Quantity + @quantity WHERE Id = @id", connection, transaction))
                                {
                                    // Add parameters to prevent SQL injection
                                    updateCommand.Parameters.AddWithValue("@id", id);
                                    updateCommand.Parameters.AddWithValue("@quantity", quantity);

                                    int rowsAffected = updateCommand.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // Insert entry into PurchasedProduct table
                                        using (SqlCommand insertCommand = new SqlCommand("INSERT INTO PurchasedProducts (ProductId, ProductName, PreviousQuantity, PurchasedQuantity, CurrentQuantity, PurchasedDate) VALUES (@productId, @productName, @previousQuantity, @purchasedQuantity, @currentQuantity, @purchasedDate)", connection, transaction))
                                        {
                                            // Add parameters to prevent SQL injection
                                            insertCommand.Parameters.AddWithValue("@productId", id);
                                            insertCommand.Parameters.AddWithValue("@productName", product.ProductName);
                                            insertCommand.Parameters.AddWithValue("@previousQuantity", product.ProductQuantity);
                                            insertCommand.Parameters.AddWithValue("@purchasedQuantity", quantity);
                                            insertCommand.Parameters.AddWithValue("@currentQuantity", product.ProductQuantity + quantity);
                                            insertCommand.Parameters.AddWithValue("@purchasedDate", DateTime.Now);

                                            insertCommand.ExecuteNonQuery();
                                        }

                                        transaction.Commit();

                                        resultMessage = $"{quantity} units of Product with ID {id} purchased successfully.";
                                    }
                                    else
                                    {
                                        resultMessage = $"Product with ID {id} not found.";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                resultMessage = $"Transaction failed: {ex.Message}";
                            }
                        }
                    }
                    else
                    {
                        resultMessage = $"Product with ID {id} not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log or rethrow)
                resultMessage = $"Error purchasing product: {ex.Message}";
            }

            return resultMessage;
        }

        // Helper function to retrieve product information by ID
        private Product GetProductById(int id)
        {
            Product product = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT Id, Name, Price, Quantity FROM Products WHERE Id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new Product
                                {
                                    ProductId = reader.GetInt32(0),
                                    ProductName = reader.GetString(1),
                                    ProductPrice = reader.GetInt32(2),
                                    ProductQuantity = reader.GetInt32(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log or rethrow)
                Console.WriteLine($"Error retrieving product information: {ex.Message}");
            }

            return product;
        }


        string IProductService.SellProduct(int id, int quantity)
        {
            string resultMessage = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();

                    // Retrieve product information
                    Product product = GetProductById(id);

                    if (product != null)
                    {
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Check if there is enough stock to sell
                                if (product.ProductQuantity >= quantity)
                                {
                                    // Update product quantity in the Products table
                                    using (SqlCommand updateCommand = new SqlCommand("UPDATE Products SET Quantity = Quantity - @quantity WHERE Id = @id", connection, transaction))
                                    {
                                        // Add parameters to prevent SQL injection
                                        updateCommand.Parameters.AddWithValue("@id", id);
                                        updateCommand.Parameters.AddWithValue("@quantity", quantity);

                                        int rowsAffected = updateCommand.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            // Insert entry into SoldProducts table
                                            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO SoldProducts (ProductId, ProductName, PreviousQuantity, SoldQuantity, CurrentQuantity, SoldDate) VALUES (@productId, @productName, @previousQuantity, @soldQuantity, @currentQuantity, @soldDate)", connection, transaction))
                                            {
                                                // Add parameters to prevent SQL injection
                                                insertCommand.Parameters.AddWithValue("@productId", id);
                                                insertCommand.Parameters.AddWithValue("@productName", product.ProductName);
                                                insertCommand.Parameters.AddWithValue("@previousQuantity", product.ProductQuantity);
                                                insertCommand.Parameters.AddWithValue("@soldQuantity", quantity);
                                                insertCommand.Parameters.AddWithValue("@currentQuantity", product.ProductQuantity - quantity);
                                                insertCommand.Parameters.AddWithValue("@soldDate", DateTime.Now);

                                                insertCommand.ExecuteNonQuery();
                                            }

                                            transaction.Commit();

                                            resultMessage = $"{quantity} units of Product with ID {id} sold successfully.";
                                        }
                                        else
                                        {
                                            resultMessage = $"Product with ID {id} not found.";
                                        }
                                    }
                                }
                                else
                                {
                                    resultMessage = $"Not enough stock available for Product with ID {id}. Available stock: {product.ProductQuantity}.";
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                resultMessage = $"Transaction failed: {ex.Message}";
                            }
                        }
                    }
                    else
                    {
                        resultMessage = $"Product with ID {id} not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log or rethrow)
                resultMessage = $"Error selling product: {ex.Message}";
            }

            return resultMessage;
        }

        public DataSet GetPurchasedProducts()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM PurchasedProducts", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet, "PurchasedProducts");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log or rethrow)
                Console.WriteLine($"Error getting purchased products: {ex.Message}");
            }

            return dataSet;
        }

        public DataSet GetSoldProducts()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM SoldProducts", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet, "SoldProducts");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log or rethrow)
                Console.WriteLine($"Error getting sold products: {ex.Message}");
            }

            return dataSet;
        }
    }
}
