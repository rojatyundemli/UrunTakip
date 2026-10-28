using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Entities
{
    public class Supplier
    {

        // Benzersiz tedarikçi kimliği
        public int Id { get; set; }

        // Zorunlu tedarikçi bilgisi
        public string SupplierName { get; set; } = string.Empty;

        // İsteğe bağlı bilgiler
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? TaxOffice { get; set; }
        public string? TaxNumber { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }

        // Veritabanı tarafından oluşturulan bilgiler
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }


    }
}
