using Eccomerce_API2.DTOs.OrderItemDTO;
using Eccomerce_API2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eccomerce_API2.DTOs.OrderDTO
{
    public class CreateOrderDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public CreateOrderItemDTO orderItem { get; set; }
        public int CustomerId { get; set; }
    }
}
