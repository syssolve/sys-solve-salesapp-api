using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeProjectPe.DB.Entities;

[Table("parameters")]
public class Parameter
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Value { get; set; } = null!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; } = null!;
    public string? Description { get; set; }
}
