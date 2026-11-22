using System;
using System.Collections.Generic;

namespace UrunTakip.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = "Pending";

        public string? Description { get; set; }

        // Siparişin ürün satırları
        public List<PurchaseOrderDetail> Details { get; set; }= new List<PurchaseOrderDetail>();
    }
}