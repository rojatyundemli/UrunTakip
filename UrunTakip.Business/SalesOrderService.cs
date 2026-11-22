using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class SalesOrderService
    {

        public String AddSalesOrder(SalesOrder salesOrder) 
        {
            try 
            {
                SalesOrderRepository repository = new SalesOrderRepository();
                repository.AddSalesOrder(salesOrder);

                return "Satış Siparişi Eklendi";
            }
            catch (Exception ex)
            {
                return "Satış Siparişi Eklenemedi: " + ex.Message;
            }

            

        }

        public List<SalesOrder> GetAllSalesOrders()
        {
            try
            {
                SalesOrderRepository repository = new SalesOrderRepository();
                return repository.GetAllSalesOrders();
            }
            catch (Exception ex)
            {
                throw new Exception("Satış siparişleri alınamadı: " + ex.Message);
            }
        }
        public List<SalesOrderDetail> GetSalesOrderDetailsByOrderId(int orderId)
        {
            try
            {
                SalesOrderRepository repository = new SalesOrderRepository();
                return repository.GetAllSalesOrderDetails(orderId);
            }
            catch (Exception ex)
            {
                throw new Exception("Satış siparişi detayları alınamadı: " + ex.Message);
            }
        }
    }
}
