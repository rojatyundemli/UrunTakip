using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Entities;

namespace UrunTakip.DataAccess
{
    public class StockMovementRepository
    {
        private readonly string _connectionString =
           @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";

        public bool AddStockMovement(StockMovement stockmovement)
        {

            if (stockmovement == null)
            {
                throw new ArgumentNullException(nameof(stockmovement));
            }

            // 2. Miktar kontrolü
            if (stockmovement.Quantity <= 0)
            {
                throw new ArgumentException(
                    "Stok hareket miktarı sıfırdan büyük olmalıdır.");
            }

            // 3. Hareket türü kontrolü
            if (stockmovement.MovementType != "IN" &&
                stockmovement.MovementType != "OUT")
            {
                throw new ArgumentException(
                    "Hareket türü IN veya OUT olmalıdır.");
            }


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {

                   


                    try
                    {

                        // Önce sadece stok güncellemek için product tablosunda işlem yapıyoruz

                        String Stockquery;

                        if (stockmovement.MovementType == "IN")
                        {
                            Stockquery = @"Update dbo.Products Set Stock = Stock + @Quantity Where Id = @ProductId";
                        }
                        else if (stockmovement.MovementType == "OUT")
                        {
                            Stockquery = @"Update dbo.Products Set Stock = Stock - @Quantity Where Id = @ProductId And Stock >= @Quantity";
                        }
                        else { throw new ArgumentException("Geçersiz Stok Hareketi Türü"); }

                        using (SqlCommand command = new SqlCommand(Stockquery, connection, transaction))
                        {

                            command.Parameters.Add("@ProductId", SqlDbType.Int).Value = stockmovement.ProductId;
                            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = stockmovement.Quantity;

                            int affectedRows = command.ExecuteNonQuery();

                            if (affectedRows == 0)
                            {
                                throw new InvalidOperationException(
                                         "Ürün bulunamadı veya yeterli stok yok.");
                            }


                            // Burada ise üstte stok sayısını değiştirdiğimiz ürünün hareket kaydını StockMovements tablosuna ekliyoruz 


                            String MovementQuery = @"Insert Into dbo.StockMovements (ProductId, MovementType, Quantity, Description) 
                                                Values (@ProductId, @MovementType, @Quantity, @Description )";

                            using (SqlCommand movementCommand = new SqlCommand(MovementQuery, connection, transaction))
                            {

                                movementCommand.Parameters.Add("@ProductId", SqlDbType.Int).Value = stockmovement.ProductId;
                                movementCommand.Parameters.Add("@MovementType", SqlDbType.NVarChar, 10).Value = stockmovement.MovementType;
                                movementCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = stockmovement.Quantity;
                                SqlParameter descriptionParameter = movementCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 250);

                                descriptionParameter.Value = string.IsNullOrWhiteSpace(stockmovement.Description) ? DBNull.Value : stockmovement.Description.Trim();

                                movementCommand.ExecuteNonQuery();



                            }

                            transaction.Commit();
                            return true;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;

                    }



                }

            }

        }

        public bool UpdateStockMovement(StockMovement stockMovement)
        {
            if (stockMovement == null)
                throw new ArgumentNullException(nameof(stockMovement));

            if (stockMovement.Id <= 0)
                throw new ArgumentException("Geçersiz stok hareketi ID'si.");

            if (stockMovement.Quantity <= 0)
                throw new ArgumentException("Miktar sıfırdan büyük olmalıdır.");

            if (stockMovement.MovementType != "IN" &&
                stockMovement.MovementType != "OUT")
                throw new ArgumentException("Hareket türü IN veya OUT olmalıdır.");

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction =
                       connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Mevcut hareketin eski bilgilerini oku
                        int oldProductId;
                        int oldQuantity;
                        string oldMovementType;

                        string selectQuery = @"
                    SELECT ProductId, MovementType, Quantity
                    FROM dbo.StockMovements WITH (UPDLOCK, HOLDLOCK)
                    WHERE Id = @Id";

                        using (SqlCommand command =
                               new SqlCommand(selectQuery, connection, transaction))
                        {
                            command.Parameters.Add("@Id", SqlDbType.Int)
                                .Value = stockMovement.Id;

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (!reader.Read())
                                    throw new InvalidOperationException(
                                        "Güncellenecek stok hareketi bulunamadı.");

                                oldProductId = reader.GetInt32(
                                    reader.GetOrdinal("ProductId"));

                                oldMovementType = reader.GetString(
                                    reader.GetOrdinal("MovementType"));

                                oldQuantity = reader.GetInt32(
                                    reader.GetOrdinal("Quantity"));
                            }
                        }

                        // 2. Ürün değişikliğine izin verme
                        if (oldProductId != stockMovement.ProductId)
                            throw new InvalidOperationException(
                                "Bu işlemde ürün değiştirilemez.");

                        // 3. Eski ve yeni hareketin stok etkisini hesapla
                        int oldEffect = oldMovementType == "IN"
                            ? oldQuantity
                            : oldMovementType == "OUT"
                                ? -oldQuantity
                                : throw new InvalidOperationException(
                                    "Eski hareket türü geçersiz.");

                        int newEffect = stockMovement.MovementType == "IN"
                            ? stockMovement.Quantity
                            : -stockMovement.Quantity;

                        int delta = newEffect - oldEffect;

                        // 4. Stoğu yalnızca fark kadar güncelle
                        string stockQuery = @"
                    UPDATE dbo.Products
                    SET Stock = Stock + @Delta
                    WHERE Id = @ProductId
                      AND Stock + @Delta >= 0";

                        using (SqlCommand command =
                               new SqlCommand(stockQuery, connection, transaction))
                        {
                            command.Parameters.Add("@ProductId", SqlDbType.Int)
                                .Value = oldProductId;

                            command.Parameters.Add("@Delta", SqlDbType.Int)
                                .Value = delta;

                            int affectedRows = command.ExecuteNonQuery();

                            if (affectedRows == 0)
                                throw new InvalidOperationException(
                                    "Ürün bulunamadı veya güncelleme stok miktarını " +
                                    "negatif yapacağı için işlem yapılamadı.");
                        }

                        // 5. Hareket kaydını güncelle
                        string updateQuery = @"
                    UPDATE dbo.StockMovements
                    SET MovementType = @MovementType,
                        Quantity = @Quantity,
                        Description = @Description
                    WHERE Id = @Id
                      AND ProductId = @ProductId";

                        using (SqlCommand command =
                               new SqlCommand(updateQuery, connection, transaction))
                        {
                            command.Parameters.Add("@Id", SqlDbType.Int)
                                .Value = stockMovement.Id;

                            command.Parameters.Add("@ProductId", SqlDbType.Int)
                                .Value = oldProductId;

                            command.Parameters.Add("@MovementType",
                                SqlDbType.NVarChar, 10)
                                .Value = stockMovement.MovementType;

                            command.Parameters.Add("@Quantity", SqlDbType.Int)
                                .Value = stockMovement.Quantity;

                            command.Parameters.Add("@Description",
                                SqlDbType.NVarChar, 250)
                                .Value = string.IsNullOrWhiteSpace(
                                    stockMovement.Description)
                                    ? DBNull.Value
                                    : (object)stockMovement.Description.Trim();

                            if (command.ExecuteNonQuery() == 0)
                                throw new InvalidOperationException(
                                    "Stok hareketi güncellenemedi.");
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool DeleteStockMovement(StockMovement stockMovement) 
        {
            using(SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                   

                    String UpdateStockQuery;
                    if(stockMovement.MovementType == "IN") 
                    {
                        UpdateStockQuery = @"Update dbo.Products Set Stock = Stock - @Quantity where Id = @ProductId ";
                        
                    }
                    else if(stockMovement.MovementType == "OUT") 
                    {
                        UpdateStockQuery = @"Update dbo.Products Set Stock = Stock + @Quantity where Id = @ProductId ";
                    }
                    else 
                    {
                        throw new ArgumentException("Hareket Türü Geçerli Değil.");
                    }
                    try
                    {
                       
                        using (SqlCommand command = new SqlCommand(UpdateStockQuery, connection, transaction))
                        {
                            command.Parameters.Add("@ProductId", SqlDbType.Int).Value = stockMovement.ProductId;
                            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = stockMovement.Quantity;

                            int affectedRows = command.ExecuteNonQuery();

                            if (affectedRows == 0)
                                {
                                    throw new InvalidOperationException("Ürün bulunamadı veya Bir Hata Oluştu.");
                                }

                            

                            String deleteQuery = @"Delete From dbo.StockMovements where Id = @Id";

                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                deleteCommand.Parameters.Add("@Id", SqlDbType.Int).Value = stockMovement.Id;

                               int affectedRowsDelete = deleteCommand.ExecuteNonQuery();
                                if (affectedRowsDelete == 0)
                                {
                                    throw new ArgumentException("Kayıt Silinemedi");
                                }

                            }
                            transaction.Commit();
                            return true;
                        }
                    }
                    catch { transaction.Rollback(); throw; }
                }
            }

        }

        public List<StockMovement> GetStockMovements() 
        {
         List<StockMovement> movements = new List<StockMovement>();
            String query =@"Select * from dbo.StockMovements Order By Id DESC";
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            
              using(SqlCommand command = new SqlCommand(query, connection)) 
              {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        StockMovement movement = new StockMovement
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                            MovementType = reader.GetString(reader.GetOrdinal("MovementType")),
                            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                        };
                        movements.Add(movement);
                    }
                }
            }


            return movements;
        }

    }
}
