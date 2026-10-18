using System.ComponentModel.DataAnnotations;

namespace Eccomerce_API2.DTOs.ProductDTO
{
    public class PatchProductDTO
    {
        [Required, Range(0, 1000000)]
        public int StockQuantity { get; set; }
    }
}
