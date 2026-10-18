using Eccomerce_API2.DTOs.OrderItemDTO;
using Eccomerce_API2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eccomerce_API2.DTOs.OrderDTO
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public ICollection<GetOrderItemDTO> OrderItems { get; set; } = new List<GetOrderItemDTO>();
    }
}
