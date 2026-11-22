namespace UrunTakip.Entities
{
    public class SalesOrderDetail
    {
        public int Id { get; set; }

        public int SalesOrderId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int ShippedQuantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal => Quantity * UnitPrice;
    }
}