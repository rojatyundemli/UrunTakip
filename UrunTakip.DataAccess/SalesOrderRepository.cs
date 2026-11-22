using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Entities;

namespace UrunTakip.DataAccess
{
    public class SalesOrderRepository
    {
        private readonly string _connectionString =
          @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";

        
        public bool AddSalesOrder(SalesOrder order)
        {
            int insertedId;
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Sales order cannot be null.");
            }

            String addSalesOrderQuery = @"Insert Into dbo.SalesOrders (CustomerId, OrderDate, Status, Description) Output Inserted.Id Values (@CustomerId, @OrderDate, @Status, @Description)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    //SalesOrders ekleme
                    using (SqlCommand addSalesOrdersCommand = new SqlCommand(addSalesOrderQuery, connection, transaction))
                    {
                        addSalesOrdersCommand.Parameters.Add("@CustomerId", System.Data.SqlDbType.Int).Value = order.CustomerId;
                        addSalesOrdersCommand.Parameters.Add("@OrderDate", System.Data.SqlDbType.DateTime2).Value = order.OrderDate;
                        addSalesOrdersCommand.Parameters.Add("@Status", System.Data.SqlDbType.NVarChar, 30).Value = order.Status;
                        addSalesOrdersCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 500).Value = (object)order.Description ?? DBNull.Value;
                       
                        insertedId = (int)addSalesOrdersCommand.ExecuteScalar();


                    }
                    //SalesOrderDetails ekleme
                    String addSalesOrderDetailQuery = @"Insert Into dbo.SalesOrderDetails (SalesOrderId, ProductId, Quantity, ShippedQuantity, UnitPrice) Values (@SalesOrderId, @ProductId, @Quantity, @ShippedQuantity, @UnitPrice)";
                    using (SqlCommand addSalesOrdersDetailsCommand = new SqlCommand(addSalesOrderDetailQuery, connection, transaction))
                    {

                        var ProductId = addSalesOrdersDetailsCommand.Parameters.Add("@ProductId", System.Data.SqlDbType.Int);
                        var Quantity = addSalesOrdersDetailsCommand.Parameters.Add("@Quantity", System.Data.SqlDbType.Int);
                        var ShippedQuantity = addSalesOrdersDetailsCommand.Parameters.Add("@ShippedQuantity", System.Data.SqlDbType.Int);
                        var UnitPrice = addSalesOrdersDetailsCommand.Parameters.Add("@UnitPrice", System.Data.SqlDbType.Decimal);
                        var SalesOrderId = addSalesOrdersDetailsCommand.Parameters.Add("@SalesOrderId", System.Data.SqlDbType.Int);

                        foreach (var detail in order.Details)
                        {
                            ProductId.Value = detail.ProductId;
                            Quantity.Value = detail.Quantity;
                            ShippedQuantity.Value = detail.ShippedQuantity;
                            UnitPrice.Value = detail.UnitPrice;
                            SalesOrderId.Value = insertedId;

                            addSalesOrdersDetailsCommand.ExecuteNonQuery();

                            

                           

                        }

                        transaction.Commit();
                        return true;
                    }





                }


            }




        }
        public List<SalesOrder> GetAllSalesOrders ()
        {
         List<SalesOrder> salesOrders = new List<SalesOrder>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                string query = "SELECT dbo.SalesOrders.* , dbo.Customers.CustomerName  FROM dbo.SalesOrders INNER JOIN dbo.Customers ON dbo.SalesOrders.CustomerId = dbo.Customers.Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesOrder order = new SalesOrder
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
                            };
                            salesOrders.Add(order);
                        }
                    }
                }
            }
            return salesOrders;


        }

        public List<SalesOrderDetail> GetAllSalesOrderDetails(int orderId)
        {
            List<SalesOrderDetail> salesOrderDetails = new List<SalesOrderDetail>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT dbo.SalesOrderDetails.* , dbo.Products.Name  FROM dbo.SalesOrderDetails INNER JOIN dbo.Products ON dbo.SalesOrderDetails.ProductId = dbo.Products.Id where SalesOrderId = @OrderId";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesOrderDetail detail = new SalesOrderDetail
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                SalesOrderId = reader.GetInt32(reader.GetOrdinal("SalesOrderId")),
                                ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                                ProductName = reader.GetString(reader.GetOrdinal("Name")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                ShippedQuantity = reader.GetInt32(reader.GetOrdinal("ShippedQuantity")),
                                UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"))
                            };
                            salesOrderDetails.Add(detail);
                        }
                    }
                }
            }
            return salesOrderDetails;
        }
    }
}