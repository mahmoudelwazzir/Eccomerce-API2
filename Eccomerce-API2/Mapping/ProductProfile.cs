using AutoMapper;
using Eccomerce_API2.DTOs.ProductDTO;
using Eccomerce_API2.Models;

namespace Eccomerce_API2.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, PatchProductDTO>().ReverseMap();
        }
    }
}
