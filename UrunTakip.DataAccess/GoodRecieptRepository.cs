using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Entities;

namespace UrunTakip.DataAccess
{
    public class GoodRecieptRepository
    {

        private readonly string _connectionString =
          @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";

       


        public bool AddGoodReciept(GoodsReceipt goodsReceipt)
        {
            string addRecieptQuery = @"Insert into dbo.GoodsReceipts (PurchaseOrderId, ReceiptDate, Description) OUTPUT INSERTED.Id VALUES (@PurchaseOrderId, @ReceiptDate, @Description)";
            int newRecieptId;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {

                    try
                    {

                        //GoodReciept ekleme

                        using (SqlCommand addRecieptCommand = new SqlCommand(addRecieptQuery, connection, transaction))
                        {

                            addRecieptCommand.Parameters.Add("@PurchaseOrderId", System.Data.SqlDbType.Int).Value = goodsReceipt.PurchaseOrderId;
                            addRecieptCommand.Parameters.Add("@ReceiptDate", System.Data.SqlDbType.DateTime).Value = goodsReceipt.ReceiptDate;
                            addRecieptCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 500).Value = goodsReceipt.Description ?? (object)DBNull.Value;

                            newRecieptId = Convert.ToInt32(addRecieptCommand.ExecuteScalar());

                        }


                        //GoodRecieptDetail ekleme

                        String addRecieptDetailQuery = @"Insert into dbo.GoodsReceiptDetails(GoodsReceiptId, PurchaseOrderDetailId,QuantityReceived) VALUES(@GoodsReceiptId, @PurchaseOrderDetailId, @QuantityReceived)";

                        using (SqlCommand addRecieptDetailCommand = new SqlCommand(addRecieptDetailQuery, connection, transaction))
                        {
                            var GoodsReceiptId = addRecieptDetailCommand.Parameters.Add("@GoodsReceiptId", System.Data.SqlDbType.Int);
                            var PurchaseOrderDetailId = addRecieptDetailCommand.Parameters.Add("@PurchaseOrderDetailId", System.Data.SqlDbType.Int);
                            var QuantityReceived = addRecieptDetailCommand.Parameters.Add("@QuantityReceived", System.Data.SqlDbType.Int);


                            foreach (var detail in goodsReceipt.Details)
                            {

                                GoodsReceiptId.Value = newRecieptId;
                                PurchaseOrderDetailId.Value = detail.PurchaseOrderDetailId;
                                QuantityReceived.Value = detail.QuantityReceived;
                                addRecieptDetailCommand.ExecuteNonQuery();

                                string updateReceivedQuantityQuery = @"UPDATE dbo.PurchaseOrderDetails SET ReceivedQuantity = ReceivedQuantity + @QuantityReceived WHERE Id = @PurchaseOrderDetailId AND PurchaseOrderId = @PurchaseOrderId AND ReceivedQuantity + @QuantityReceived <= Quantity";
                                using (SqlCommand updateReceivedQuantityCommand = new SqlCommand(updateReceivedQuantityQuery, connection, transaction))
                                {
                                    updateReceivedQuantityCommand.Parameters.Add("@QuantityReceived", System.Data.SqlDbType.Int).Value = detail.QuantityReceived;
                                    updateReceivedQuantityCommand.Parameters.Add("@PurchaseOrderDetailId", System.Data.SqlDbType.Int).Value = detail.PurchaseOrderDetailId;
                                    updateReceivedQuantityCommand.Parameters.Add("@PurchaseOrderId", System.Data.SqlDbType.Int).Value = goodsReceipt.PurchaseOrderId;
                                    int affectedRows = updateReceivedQuantityCommand.ExecuteNonQuery();

                                    if (affectedRows != 1)
                                    {
                                        throw new Exception(
                                            "Teslim alınan miktar sipariş miktarını aşıyor veya sipariş ürünü bulunamadı.");
                                    }
                                }

                                //Supplier < PurchaseOrder <PurchaseOrderDetail
                                String getSupplierNameQuery = @"Select SupplierName  from dbo.Suppliers inner join  dbo.PurchaseOrders on dbo.Suppliers.Id = dbo.PurchaseOrders.SupplierId inner join dbo.PurchaseOrderDetails on dbo.PurchaseOrders.Id = dbo.PurchaseOrderDetails.PurchaseOrderId where dbo.PurchaseOrderDetails.Id = @PurchaseOrderDetailId";
                                String getProductIdQuery = @"Select ProductId from dbo.PurchaseOrderDetails where Id = @PurchaseOrderDetailId";
                                String addStockMovementQuery = @"Insert Into dbo.StockMovements (ProductId, MovementType, Quantity, Description) Values (@ProductId, @MovementType, @Quantity, @Description)";

                                //Stok hareketlerinde kullanmak için Tedarikçi Adı alındı
                                using (SqlCommand getSupplierNameCommand = new SqlCommand(getSupplierNameQuery, connection, transaction))
                                {
                                    getSupplierNameCommand.Parameters.Add("@PurchaseOrderDetailId", System.Data.SqlDbType.Int).Value = detail.PurchaseOrderDetailId;
                                    string supplierName = (string)getSupplierNameCommand.ExecuteScalar();

                                    //Stok hareketlerinde kullanmak için Ürün Id alındı
                                    using (SqlCommand getProductIdCommand = new SqlCommand(getProductIdQuery, connection, transaction))
                                    {
                                        getProductIdCommand.Parameters.Add("@PurchaseOrderDetailId", System.Data.SqlDbType.Int).Value = detail.PurchaseOrderDetailId;
                                        int productId = (int)getProductIdCommand.ExecuteScalar();

                                        //Stok hareketlerine kayıt oluşturuldu
                                        using (SqlCommand addStockMovementCommand = new SqlCommand(addStockMovementQuery, connection, transaction))
                                        {
                                            addStockMovementCommand.Parameters.Add("@ProductId", System.Data.SqlDbType.Int).Value = productId;
                                            addStockMovementCommand.Parameters.Add("@MovementType", System.Data.SqlDbType.NVarChar, 50).Value = "IN";
                                            addStockMovementCommand.Parameters.Add("@Quantity", System.Data.SqlDbType.Int).Value = detail.QuantityReceived;
                                            addStockMovementCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 500).Value = supplierName + "Tedarikçisinden Mal KAbul Alındı";

                                            addStockMovementCommand.ExecuteNonQuery();
                                        }

                                        // Stok güncelleme işlemi
                                        String updateStockQuery = @"Update dbo.Products set Stock = Stock + @Quantity where Id = @ProductId";
                                        using (SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection, transaction))
                                        {
                                            updateStockCommand.Parameters.Add("@Quantity", System.Data.SqlDbType.Int).Value = detail.QuantityReceived;
                                            updateStockCommand.Parameters.Add("@ProductId", System.Data.SqlDbType.Int).Value = productId;
                                            updateStockCommand.ExecuteNonQuery();
                                        }
                                    }

                                }




                            }


                            string updateStatusQuery = @"UPDATE dbo.PurchaseOrders SET Status =  CASE WHEN NOT EXISTS ( SELECT 1 FROM dbo.PurchaseOrderDetails WHERE PurchaseOrderId = @PurchaseOrderId AND ReceivedQuantity < Quantity ) THEN N'Received' ELSE N'PartiallyReceived' END WHERE Id = @PurchaseOrderId";

                            using (SqlCommand updateStatusCommand = new SqlCommand(updateStatusQuery, connection, transaction))
                            {
                                updateStatusCommand.Parameters.Add("@PurchaseOrderId", System.Data.SqlDbType.Int).Value = goodsReceipt.PurchaseOrderId;
                                updateStatusCommand.ExecuteNonQuery();
                            }



                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception ex) { transaction.Rollback(); throw; }







                }


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

