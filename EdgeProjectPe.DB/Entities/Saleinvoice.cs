using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeProjectPe.DB.Entities;

[Table("saleinvoice")]
public partial class Saleinvoice
{
    [Key]
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int SaleId { get; set; }

    public DateTime SaleDate { get; set; }
}
