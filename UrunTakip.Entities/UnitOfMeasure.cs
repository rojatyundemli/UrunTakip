using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Entities
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }

        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public int DimensionId { get; set; }
        public String? DimensionName { get; set; }

        public string? BaseUnitName { get; set; }

        public int DecimalPlaces { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        

    }
}
