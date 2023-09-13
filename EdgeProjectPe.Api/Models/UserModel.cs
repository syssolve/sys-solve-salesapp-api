using System;
namespace EdgeProjectPe.Api.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int CompanyId { get; set; }

        public string UserTypeId { get; set; } = null!;

        public string Email { get; set; } = null!;

        public sbyte? Status { get; set; }
    }
}

