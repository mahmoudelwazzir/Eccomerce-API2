using System.ComponentModel.DataAnnotations;

namespace Eccomerce_API2.DTOs.CategoryDTO
{
    public class CreateCategoryDTO
    {
        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
