namespace UrunTakip.Entities
{
    public class PurchaseOrderDetail
    {
        public int Id { get; set; }

        public int PurchaseOrderId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public int ReceivedQuantity { get; set; }

        public decimal UnitPrice { get; set; }

       

        public int RemainingQuantity => Quantity - ReceivedQuantity;

        public int CurrentlyReceivedQuantity { get; set; }

        // Uygulama tarafında hesaplanır, veritabanında ayrı tutulmaz.
        public decimal LineTotal => Quantity * UnitPrice;
    }
}