using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public string Description { get; set; } = null!;
        public double UnitPrice { get; set; }
        public int? Stock { get; set; }
        public int CompanyId { get; set; }
        public string Status { get; set; } = null!;
    }
}
