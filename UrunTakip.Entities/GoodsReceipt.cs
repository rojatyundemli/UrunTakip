using System;
using System.Collections.Generic;

namespace UrunTakip.Entities
{
    public class GoodsReceipt
    {
        public int Id { get; set; }

        public int PurchaseOrderId { get; set; }

        public DateTime ReceiptDate { get; set; }

        public string? Description { get; set; }

        public List<GoodsReceiptDetail> Details { get; set; }
            = new List<GoodsReceiptDetail>();
    }
}