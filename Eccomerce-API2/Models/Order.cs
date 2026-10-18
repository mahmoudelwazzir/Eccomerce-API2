using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eccomerce_API2.Models
{
    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public ApplicationUser Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
