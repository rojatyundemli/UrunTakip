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
    public class PurchaseOrderRepository
    {

        private readonly string _connectionString =
          @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";
       

        public int AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {

            int newPurchaseOrderId = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string AddPurchaseOrderQuery = @"INSERT INTO dbo.PurchaseOrders (SupplierId, OrderDate, Status, Description) OUTPUT INSERTED.Id  VALUES (@SupplierId, @OrderDate, @Status, @Description)";
                string AddPurchaseOrderDetailQuery = @"INSERT INTO dbo.PurchaseOrderDetails (PurchaseOrderId, ProductId, Quantity, UnitPrice) VALUES (@PurchaseOrderId, @ProductId, @Quantity, @UnitPrice)";
                using (SqlTransaction transaction = connection.BeginTransaction())
                {

                    try
                    {
                        using (SqlCommand AddPurchaseOrderCommand = new SqlCommand(AddPurchaseOrderQuery, connection, transaction))
                        {
                            AddPurchaseOrderCommand.Parameters.Add("@SupplierId", System.Data.SqlDbType.Int).Value = purchaseOrder.SupplierId;
                            AddPurchaseOrderCommand.Parameters.Add("@OrderDate", System.Data.SqlDbType.DateTime).Value = purchaseOrder.OrderDate;
                            AddPurchaseOrderCommand.Parameters.Add("@Status", System.Data.SqlDbType.NVarChar, 30).Value = purchaseOrder.Status;
                            AddPurchaseOrderCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value = (object?)purchaseOrder.Description ?? DBNull.Value;

                            newPurchaseOrderId = (int)AddPurchaseOrderCommand.ExecuteScalar();



                        }

                        using (SqlCommand AddPurchaseOrderDetailCommand = new SqlCommand(AddPurchaseOrderDetailQuery, connection, transaction))
                        {

                            var orderIdParameter = AddPurchaseOrderDetailCommand.Parameters.Add("@PurchaseOrderId", SqlDbType.Int);
                            var productIdParameter = AddPurchaseOrderDetailCommand.Parameters.Add("@ProductId", SqlDbType.Int);
                            var quantityParameter = AddPurchaseOrderDetailCommand.Parameters.Add("@Quantity", SqlDbType.Int);
                            var unitPriceParameter = AddPurchaseOrderDetailCommand.Parameters.Add("@UnitPrice", SqlDbType.Decimal);

                            unitPriceParameter.Precision = 18;
                            unitPriceParameter.Scale = 2;

                            foreach (PurchaseOrderDetail detail in purchaseOrder.Details)
                            {
                                orderIdParameter.Value = newPurchaseOrderId;
                                productIdParameter.Value = detail.ProductId;
                                quantityParameter.Value = detail.Quantity;
                                unitPriceParameter.Value = detail.UnitPrice;

                                AddPurchaseOrderDetailCommand.ExecuteNonQuery();
                            }


                        }

                        transaction.Commit();
                        return newPurchaseOrderId;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;


                    }


                }

            }



        }




        public bool UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
                throw new ArgumentNullException(nameof(purchaseOrder));

            if (purchaseOrder.Id <= 0)
                throw new ArgumentException("Geçersiz sipariş ID.");

            if (purchaseOrder.Details == null ||
                purchaseOrder.Details.Count == 0)
                throw new Exception("Siparişte en az bir ürün bulunmalıdır.");

            if (purchaseOrder.Details.Any(x =>
                x.ProductId <= 0 || x.Quantity <= 0 || x.UnitPrice < 0))
            {
                throw new Exception("Sipariş ürünlerinin bilgileri geçersiz.");
            }

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction =
                       connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Siparişin ana bilgilerini güncelle
                        string updatePurchaseOrderQuery = @"
    UPDATE dbo.PurchaseOrders
    SET
        SupplierId = @SupplierId,
        OrderDate = @OrderDate,
        Description = @Description
    WHERE Id = @Id
    AND Status = N'Pending'
    AND NOT EXISTS
    (
        SELECT 1
        FROM dbo.PurchaseOrderDetails
        WHERE PurchaseOrderId = @Id
        AND ReceivedQuantity > 0
    )";

                        using (SqlCommand command =
                               new SqlCommand(updatePurchaseOrderQuery,connection,transaction))
                        {
                            command.Parameters.Add(
                                "@Id", SqlDbType.Int).Value =
                                purchaseOrder.Id;

                            command.Parameters.Add(
                                "@SupplierId", SqlDbType.Int).Value =
                                purchaseOrder.SupplierId;

                            command.Parameters.Add(
                                "@OrderDate", SqlDbType.DateTime2).Value =
                                purchaseOrder.OrderDate;

                            command.Parameters.Add(
                                "@Description",
                                SqlDbType.NVarChar, 500).Value =
                                (object?)purchaseOrder.Description
                                ?? DBNull.Value;

                            int affectedRows = command.ExecuteNonQuery();

                            if (affectedRows == 0)
                            {
                                throw new Exception(
                                    "Sipariş bulunamadı veya düzenlemeye uygun değil.");
                            }
                        }

                        // 2. Eski sipariş detaylarını sil
                        string deleteDetailsQuery = @"
                    DELETE FROM dbo.PurchaseOrderDetails
                    WHERE PurchaseOrderId = @PurchaseOrderId";

                        using (SqlCommand command =
                               new SqlCommand(
                                   deleteDetailsQuery,
                                   connection,
                                   transaction))
                        {
                            command.Parameters.Add(
                                "@PurchaseOrderId",
                                SqlDbType.Int).Value = purchaseOrder.Id;

                            command.ExecuteNonQuery();
                        }

                        // 3. Yeni ürün detaylarını ekle
                        string insertDetailQuery = @"
                    INSERT INTO dbo.PurchaseOrderDetails
                    (
                        PurchaseOrderId,
                        ProductId,
                        Quantity,
                        UnitPrice
                    )
                    VALUES
                    (
                        @PurchaseOrderId,
                        @ProductId,
                        @Quantity,
                        @UnitPrice
                    )";

                        using (SqlCommand command =
                               new SqlCommand(
                                   insertDetailQuery,
                                   connection,
                                   transaction))
                        {
                            var orderIdParameter =
                                command.Parameters.Add(
                                    "@PurchaseOrderId", SqlDbType.Int);

                            var productIdParameter =
                                command.Parameters.Add(
                                    "@ProductId", SqlDbType.Int);

                            var quantityParameter =
                                command.Parameters.Add(
                                    "@Quantity", SqlDbType.Int);

                            var unitPriceParameter =
                                command.Parameters.Add(
                                    "@UnitPrice", SqlDbType.Decimal);

                            unitPriceParameter.Precision = 18;
                            unitPriceParameter.Scale = 2;

                            foreach (PurchaseOrderDetail detail
                                     in purchaseOrder.Details)
                            {
                                orderIdParameter.Value =
                                    purchaseOrder.Id;

                                productIdParameter.Value =
                                    detail.ProductId;

                                quantityParameter.Value =
                                    detail.Quantity;

                                unitPriceParameter.Value =
                                    detail.UnitPrice;

                                command.ExecuteNonQuery();
                            }
                        }

                        // 4. Her şey başarılıysa işlemleri kaydet
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


        public List<PurchaseOrder> GetAllPurchaseOrders()
        {
            List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();

            try
            {
                String query = @"Select * From dbo.PurchaseOrders ORDER BY Id DESC";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PurchaseOrder purchaseOrder = new PurchaseOrder
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    SupplierId = reader.GetInt32(reader.GetOrdinal("SupplierId")),
                                    OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                    Status = reader.GetString(reader.GetOrdinal("Status")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),

                                };
                                purchaseOrders.Add(purchaseOrder);
                            }
                        }
                    }
                }

                return purchaseOrders;
            }
            catch (Exception ex)
            {
                throw;
            }




        }


        public List<PurchaseOrderDetail> GetPurchaseOrderDetails(int purchaseOrderId)
        {


            List<PurchaseOrderDetail> PurchaseDetails = new List<PurchaseOrderDetail>();

            string query = @"SELECT pod.*, p.Name AS ProductName FROM dbo.PurchaseOrderDetails pod INNER JOIN dbo.Products p ON pod.ProductId = p.Id WHERE pod.PurchaseOrderId = @PurchaseOrderId";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PurchaseOrderId", purchaseOrderId);
                        SqlDataReader reader = command.ExecuteReader();


                        while (reader.Read())
                        {

                            PurchaseOrderDetail detail = new PurchaseOrderDetail
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                PurchaseOrderId = reader.GetInt32(reader.GetOrdinal("PurchaseOrderId")),
                                ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                ReceivedQuantity = reader.GetInt32(reader.GetOrdinal("ReceivedQuantity")),
                                UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),



                                CurrentlyReceivedQuantity = 0
                            };
                            PurchaseDetails.Add(detail);

                        }


                    }


                }
                return PurchaseDetails;
            }
            catch (Exception ex) { throw; }

        }
    }
}
