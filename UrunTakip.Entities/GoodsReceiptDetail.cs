namespace UrunTakip.Entities
{
    public class GoodsReceiptDetail
    {
        public int Id { get; set; }

        public int GoodsReceiptId { get; set; }

        public int PurchaseOrderDetailId { get; set; }

        public int QuantityReceived { get; set; }
    }
}