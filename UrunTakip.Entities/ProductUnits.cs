using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Entities
{
    public class ProductUnits
    {
        
            public int Id { get; set; }

            public int ProductId { get; set; }

            public int UnitId { get; set; }

            public decimal Numerator { get; set; }

            public decimal Denominator { get; set; }

            public bool IsPurchaseUnit { get; set; }

            public bool IsSalesUnit { get; set; }

            public bool IsActive { get; set; }

            public DateTime CreatedAt { get; set; }

            public DateTime? UpdatedAt { get; set; }

            // Listeleme ekranı için
            public string? ProductName { get; set; }

            public string? MainUnitName { get; set; }

            public string? AlternativeUnitName { get; set; }
    }
    
}

