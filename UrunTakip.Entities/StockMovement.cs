using System;


namespace UrunTakip.Entities
{
    public class StockMovement
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string MovementType { get; set; } = "";

        public int Quantity { get; set; }

        public string Description { get; set; } = "";

        public DateTime CreatedAt { get; set; }
    }
}