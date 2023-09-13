using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeProjectPe.DB.Entities;

[Table("user")]
public class User
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int CompanyId { get; set; }

    public string UserTypeId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public sbyte? Status { get; set; }
}
