
using System.ComponentModel.DataAnnotations;

namespace AnkasChocolateFactory.Models.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Password must be {2} to {1} charecter long", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
