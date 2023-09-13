using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeProjectPe.DB.Entities;

[Table("company")]
public class Company
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string NameRegistered { get; set; } = null!;

    public string Soluser { get; set; } = null!;

    public string Solpassword { get; set; } = null!;

    public string LastInvoice { get; set; } = null!;

    public string Status { get; set; } = null!;
}
