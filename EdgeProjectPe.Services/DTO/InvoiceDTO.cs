using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string Serial { get; set; } = null!;
        public double TaxAmount { get; set; }
        public double Total { get; set; }
        public string Status { get; set; } = null!;
        public sbyte Online { get; set; }
        public string? Message { get; set; }
        public string? File { get; set; }
    }
}
