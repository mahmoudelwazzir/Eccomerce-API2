using Eccomerce_API2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eccomerce_API2.DTOs.OrderItemDTO
{
    public class CreateOrderItemDTO
    {
        [Required, Range(1, 1000)]
        public int Quantity { get; set; }
        [Required, Range(0.01, 1000000)]
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
