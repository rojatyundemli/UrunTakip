
using System.Data;
using Microsoft.Data.SqlClient;
using UrunTakip.Entities;

namespace UrunTakip.DataAccess
{
    public class ProductRepository
    {
        private readonly string _connectionString =
            @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";

        public bool Add(Product product)
        {
            string query = @"
                INSERT INTO dbo.Products (Name, Price)
                VALUES (@Name, @Price);";

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))
            {
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@Name", SqlDbType.NVarChar, 100
                    ).Value = product.Name;

                    SqlParameter priceParameter =
                        command.Parameters.Add(
                            "@Price", SqlDbType.Decimal
                        );

                    priceParameter.Precision = 18;
                    priceParameter.Scale = 2;
                    priceParameter.Value = product.Price;

                    

                    connection.Open();

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows == 1;
                }
            }
        }


        public bool UpdateProduct (Product product)
        {
            String query = @"Update dbo.Products Set Name = @ProductName, Price = @ProductPrice  Where Id = @ProductId";

            using (SqlConnection connection =
       new SqlConnection(_connectionString))
            {
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", product.Id);
                    command.Parameters.AddWithValue("@ProductName", product.Name);
                    command.Parameters.AddWithValue("@ProductPrice", product.Price);
                   

                    connection.Open();

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows > 0;
                }
            }

        }

        public bool DeleteProduct(int Id) 
        {
            String query = @"Delete From dbo.Products Where Id = @ProductId";
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
              

                    command.Parameters.AddWithValue("@ProductId",Id);

                    connection.Open();


                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows > 0;

                }
            
            }
        
        }

       

        // Veritabanındaki bütün ürünleri getir
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            string query = @"
                SELECT Id, Name, Price, Stock
                FROM dbo.Products
                ORDER BY Id DESC;";

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))

            using (SqlCommand command =
                   new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader =
                       command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();

                        product.Id = reader.GetInt32(
                            reader.GetOrdinal("Id"));

                        product.Name = reader.GetString(
                            reader.GetOrdinal("Name"));

                        product.Price = reader.GetDecimal(
                            reader.GetOrdinal("Price"));

                        product.Stock = reader.GetInt32(
                            reader.GetOrdinal("Stock"));

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public List<Product> GetWithSearch(String Name)
        {
            List<Product> products = new List<Product>();

            String query = @"Select Id, Name, Price, Stock
                FROM dbo.Products Where Name Like @Name";



            using (SqlConnection connection = new SqlConnection(_connectionString))

            using (SqlCommand command_ = new SqlCommand(query, connection))
            {
                connection.Open();
                command_.Parameters.AddWithValue("@Name", "%" + Name + "%");


                using (SqlDataReader reader = command_.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Product product = new Product();

                        product.Id = reader.GetInt32(
                               reader.GetOrdinal("Id"));

                        product.Name = reader.GetString(
                            reader.GetOrdinal("Name"));

                        product.Price = reader.GetDecimal(
                            reader.GetOrdinal("Price"));

                        product.Stock = reader.GetInt32(
                            reader.GetOrdinal("Stock"));

                        products.Add(product);
                    }







                }
            }






            return products;

        }
    }
}


