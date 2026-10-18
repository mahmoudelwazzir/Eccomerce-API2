using AutoMapper;
using Eccomerce_API2.DTOs.CategoryDTO;
using Eccomerce_API2.Models;

namespace Eccomerce_API2.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetAllCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
        }
    }
}
