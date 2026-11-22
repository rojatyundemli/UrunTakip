
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
                INSERT INTO dbo.Products (Name, Price,Stock,ProductCode,PurchasePrice,MainUnitId, Category, Barcode, MinStock, MaxStock,Description)
                VALUES (@Name, @Price, @Stock, @ProductCode,@PurchasePrice, @MainUnitId, @Category, @Barcode, @MinStock, @MaxStock, @Description);";

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))
            {
                using (SqlCommand command =
                       new SqlCommand(query, connection))

                {
                    command.Parameters.Add("@MainUnitId", SqlDbType.Int).Value = product.MainUnitId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = product.Name;
                    command.Parameters.Add("@Stock",SqlDbType.Decimal).Value =product.Stock;
                    command.Parameters.Add("@ProductCode", SqlDbType.NVarChar, 15).Value =product.ProductCode;
                    command.Parameters.Add("@PurchasePrice", SqlDbType.Decimal).Value =product.PurchasePrice;
                    command.Parameters.Add("@Category", SqlDbType.NVarChar, 25).Value =product.Category;
                    command.Parameters.Add("@Barcode",SqlDbType.NVarChar,50).Value =product.Barcode;
                    command.Parameters.Add("@MinStock", SqlDbType.Decimal).Value =product.MinStock;
                    command.Parameters.Add("@MaxStock", SqlDbType.Decimal).Value =product.MaxStock;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value =product.Descraption;
                    
                    SqlParameter priceParameter =command.Parameters.Add("@Price", SqlDbType.Decimal);

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
            String query = @"Update dbo.Products Set Name = @ProductName, Price = @ProductPrice, Stock=@Stock , ProductCode=@ProductCode,PurchasePrice = @PurchasePrice, MainUnitId = @MainUnitId, Category=@Category ,Barcode=@Barcode, MinStock = @MinStock , MaxStock = @MaxStock, Description = @Description Where Id = @ProductId";

            using (SqlConnection connection =
       new SqlConnection(_connectionString))
            {
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", product.Id);
                    command.Parameters.AddWithValue("@MainUnitId", product.MainUnitId);
                    command.Parameters.AddWithValue("@ProductName", product.Name);
                    command.Parameters.AddWithValue("@ProductPrice", product.Price);
                    command.Parameters.AddWithValue("@Stock ", product.Stock);
                    command.Parameters.AddWithValue("@ProductCode ", product.ProductCode);
                    command.Parameters.AddWithValue("@PurchasePrice", product.PurchasePrice);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Barcode", product.Barcode);
                    command.Parameters.AddWithValue("@MinStock", product.MinStock);
                    command.Parameters.AddWithValue("@MaxStock", product.MaxStock);
                    command.Parameters.AddWithValue("@Description", product.Descraption);
                   

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
                SELECT P.Id, P.Name, P.Price, P.Stock, P.ProductCode, P.PurchasePrice, P.MainUnitId, U.UnitName, P.Category, P.Barcode, P.MinStock, P.MaxStock, P.Description FROM dbo.Products P LEFT JOIN dbo.UnitsOfMeasure U ON P.MainUnitId = U.Id   ORDER BY P.Id DESC;";

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

                        product.Id = reader.GetInt32(reader.GetOrdinal("Id"));

                        product.Name = reader.GetString(reader.GetOrdinal("Name"));

                        product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));

                        product.Stock = reader.GetDecimal(reader.GetOrdinal("Stock"));

                        product.MainUnitName = reader.GetString(reader.GetOrdinal("UnitName"));

                        product.MainUnitId = reader.GetInt32(reader.GetOrdinal("MainUnitId"));

                        product.ProductCode = reader.IsDBNull(reader.GetOrdinal("ProductCode"))? null: reader.GetString(reader.GetOrdinal("ProductCode"));


                        product.PurchasePrice = reader.IsDBNull(reader.GetOrdinal("PurchasePrice")) ? 0 : reader.GetDecimal(reader.GetOrdinal("PurchasePrice"));

                        product.Category = reader.IsDBNull(reader.GetOrdinal("Category"))  ? null : reader.GetString(reader.GetOrdinal("Category"));

                        product.Barcode = reader.IsDBNull(reader.GetOrdinal("Barcode"))  ? null : reader.GetString(reader.GetOrdinal("Barcode"));

                        product.MinStock = reader.IsDBNull(reader.GetOrdinal("MinStock"))  ? 0 : reader.GetDecimal(reader.GetOrdinal("MinStock"));

                        product.MaxStock = reader.IsDBNull(reader.GetOrdinal("MaxStock"))  ? 0 : reader.GetDecimal(reader.GetOrdinal("MaxStock"));

                        product.Descraption = reader.IsDBNull(reader.GetOrdinal("Description"))   ? null : reader.GetString(reader.GetOrdinal("Description"));


                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public List<Product> GetWithSearch(String Name)
        {
            List<Product> products = new List<Product>();

            String query = @"Select Id, Name, Price, Stock ,ProductCode,PurchasePrice, UnitName, Category, Barcode, MinStock, MaxStock,Description FROM dbo.Products Where Name Like @Name";



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

                        product.Id = reader.GetInt32(reader.GetOrdinal("Id"));

                        product.Name = reader.GetString(reader.GetOrdinal("Name"));

                        product.Price = reader.GetDecimal( reader.GetOrdinal("Price"));

                        product.Stock = reader.GetDecimal(reader.GetOrdinal("Stock"));

                        product.MainUnitName = reader.GetString(reader.GetOrdinal("UnitName"));
                        product.MainUnitId = reader.GetInt32(reader.GetOrdinal("MainUnitId"));
                        product.ProductCode = reader.IsDBNull(reader.GetOrdinal("ProductCode"))? null: reader.GetString(reader.GetOrdinal("ProductCode"));

                        products.Add(product);
                    }







                }
            }






            return products;

        }

    
    }
}


