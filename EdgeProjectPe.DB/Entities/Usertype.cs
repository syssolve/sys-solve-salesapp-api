using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeProjectPe.DB.Entities;

[Table("usertype")]
public partial class Usertype
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public sbyte? Status { get; set; }
}
