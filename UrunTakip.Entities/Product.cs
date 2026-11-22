using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public decimal Price { get; set; }

        public decimal Stock { get; set; }

        public string ProductCode { get; set; } = "";

        public decimal PurchasePrice { get; set; }

        public int? MainUnitId { get; set; }

        public string? MainUnitName { get; set; }

        public string Category { get; set; } = "";

        public string Barcode { get; set; } = "";

        public decimal MinStock { get; set; }
        public decimal MaxStock { get; set; }

        public string Descraption { get; set; } = "";

    }
}
