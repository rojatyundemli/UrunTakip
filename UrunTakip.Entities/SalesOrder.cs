using System;
using System.Collections.Generic;

namespace UrunTakip.Entities
{
    public class SalesOrder
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = "Pending";

        public string? Description { get; set; }

        public List<SalesOrderDetail> Details { get; set; }
            = new List<SalesOrderDetail>();
    }
}