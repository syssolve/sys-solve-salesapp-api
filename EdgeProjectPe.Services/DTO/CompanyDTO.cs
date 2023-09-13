using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.DTO
{
    public class CompanyDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string NameRegistered { get; set; } = null!;

        public string Soluser { get; set; } = null!;

        public string Solpassword { get; set; } = null!;

        public string LastInvoice { get; set; } = null!;

        public string Status { get; set; } = null!;
    }
}
