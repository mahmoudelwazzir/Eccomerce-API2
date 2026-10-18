using AutoMapper;
using Eccomerce_API2.DTOs.OrderDTO;
using Eccomerce_API2.Models;

namespace Eccomerce_API2.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, GetOrderDTO>().ReverseMap();
        }
    }
}
