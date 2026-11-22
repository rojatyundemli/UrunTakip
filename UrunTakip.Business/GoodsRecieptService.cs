using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class GoodsRecieptService
    {

        public bool AddGoodsReciept(GoodsReceipt goodsReceipt)
        {
            try
            {
                GoodRecieptRepository repository =
                    new GoodRecieptRepository();

                return repository.AddGoodReciept(goodsReceipt);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Mal kabul işlemi gerçekleştirilemedi: " + ex.Message, ex);
            }
        }

        public List<PurchaseOrderDetail> GetPurchaseOrderDetails(int purchaseOrderId)
        {
            try
            {
                GoodRecieptRepository repository = new GoodRecieptRepository();
                return repository.GetPurchaseOrderDetails(purchaseOrderId);
            }
            catch (Exception ex)
            {
                throw new Exception("Sipariş detayları alınırken bir hata oluştu: " + ex.Message);
            }
        }


    }
}
