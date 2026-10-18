using Eccomerce_API2.Models;
using System.ComponentModel.DataAnnotations;

namespace Eccomerce_API2.DTOs.AuthDTO
{
    public class RegisterDTO
    {
        [Required, StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public UseRole Role { get; set; }
    }
}
