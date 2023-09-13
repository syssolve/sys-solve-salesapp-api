using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int ProductId { get; set; }

        public double Quantity { get; set; }

        public double SubTotal { get; set; }
    }
}
