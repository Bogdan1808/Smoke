using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Smoke.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string UserName { get; set; }

        public required string Email { get; set; } = string.Empty;

        public required string Password { get; set; }
    }
}
