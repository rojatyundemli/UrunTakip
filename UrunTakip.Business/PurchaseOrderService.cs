using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class PurchaseOrderService
    {




        public string GetValidationError(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
            {
                return "Sipariş bilgisi boş olamaz.";
            }

            if (string.IsNullOrWhiteSpace(purchaseOrder.Status))
            {
                return "Sipariş durumu boş olamaz.";
            }

      
        

            return "";
        }




        public string AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            // 1. Önce siparişin geçerliliğini kontrol et.
            string error = GetValidationError(purchaseOrder);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try
            {
                // 2. Veritabanı işlemlerini yapacak nesneyi oluştur.
                PurchaseOrderRepository repository = new PurchaseOrderRepository();

              repository.AddPurchaseOrder(purchaseOrder);

                // 4. Sonucu geri döndür.
                return "Sipariş başarıyla kaydedildi.";
                
            }
            catch (Exception ex)
            {
                return "Kayıt sırasında hata oluştu: " + ex.Message;
            }
        }

        public List<PurchaseOrder> GetAllPurchaseOrders()
        {
            try
            {
                PurchaseOrderRepository repository = new PurchaseOrderRepository();
                return repository.GetAllPurchaseOrders();
            }
            catch (Exception ex)
            {
                throw new Exception("Siparişler yüklenirken hata oluştu: " + ex.Message);
            }
        }

        public List<PurchaseOrderDetail> GetPurchaseOrderDetails(int purchaseOrderId)
        {
            try
            {
                PurchaseOrderRepository repository = new PurchaseOrderRepository();
                return repository.GetPurchaseOrderDetails(purchaseOrderId);
            }
            catch (Exception ex)
            {
                throw new Exception("Sipariş detayları yüklenirken hata oluştu: " + ex.Message);
            }
        }

        public bool UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try {
                PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository();
                return purchaseOrderRepository.UpdatePurchaseOrder(purchaseOrder);
            }
            catch 
            {
              throw;
            }
           
        }
    }
}
