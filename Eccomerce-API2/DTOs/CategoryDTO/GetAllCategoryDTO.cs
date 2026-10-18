using System.ComponentModel.DataAnnotations;

namespace Eccomerce_API2.DTOs.CategoryDTO
{
    public class GetAllCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
