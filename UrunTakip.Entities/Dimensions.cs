using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Entities
{

    public class Dimensions
    {
        public int Id { get; set; }

        public string DimensionCode { get; set; } = string.Empty;

        public string DimensionName { get; set; } = string.Empty;

        public int? BaseUnitId { get; set; }
        public String? BaseUnitName { get; set; }
       
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public int? CreatedBy { get; set; }
    }

}
