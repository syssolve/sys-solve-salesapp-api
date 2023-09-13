using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeProjectPe.DB.Entities;

[Table("sale")]
public class Sale
{
    [Key]
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int ProductId { get; set; }

    public double Quantity { get; set; }

    public double SubTotal { get; set; }
}
