using System;

namespace UrunTakip.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string? ContactName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? TaxOffice { get; set; }

        public string? TaxNumber { get; set; }

        public string? City { get; set; }

        public string? District { get; set; }

        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
    }
}