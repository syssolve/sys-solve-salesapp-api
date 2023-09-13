using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.DTO
{
    public class ParameterDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Value { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = null!;
        public string? Description { get; set; }
    }
}
