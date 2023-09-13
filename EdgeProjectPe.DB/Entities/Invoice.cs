using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeProjectPe.DB.Entities;

[Table("invoice")]
public partial class Invoice
{
    [Key]
    public int Id { get; set; }
    public string Serial { get; set; } = null!;
    public double TaxAmount { get; set; }
    public double Total { get; set; }
    public string Status { get; set; } = null!;
    public sbyte Online { get; set; }
    public string? Message { get; set; }
    public string? File { get; set; }
}
