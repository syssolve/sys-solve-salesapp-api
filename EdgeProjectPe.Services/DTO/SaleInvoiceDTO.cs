using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.DTO
{
    public class SaleInvoiceDTO
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
    }
}
