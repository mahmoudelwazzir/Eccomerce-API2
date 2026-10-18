using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Eccomerce_API2.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UseRole
    {
        Admin,
        Customer
    }
    public class ApplicationUser
    {
        public int Id { get; set;  }
        [Required, StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public UseRole Role { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
