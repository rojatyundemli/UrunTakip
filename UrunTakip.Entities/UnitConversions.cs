using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Entities
{
    public class UnitConversions
    {
        public int Id { get; set; }

        public int UnitId { get; set; }

        public decimal Numerator { get; set; }

        public decimal Denominator { get; set; }

        public string? DimensionName { get; set; }

        public string? BaseUnitName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Listeleme ekranında göstermek için
        public string? UnitName { get; set; }

    }
}
