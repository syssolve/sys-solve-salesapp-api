using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeProjectPe.DB.Entities;

[Table("product")]
public class Product
{
    [Key]
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string Description { get; set; } = null!;

    public double UnitPrice { get; set; }

    public int? Stock { get; set; }

    public int CompanyId { get; set; }

    public string Status { get; set; } = null!;
}
