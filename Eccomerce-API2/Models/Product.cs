using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eccomerce_API2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required, Range(0.01, 1000000)]
        public decimal Price { get; set; }
        [Required, Range(0, 1000000)]
        public int StockQuantity { get; set; }
        public Category Category
        {
            get; set;
        }
        [ForeignKey("Category")]
        public int CategoryId
        {
            get; set;
        }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
