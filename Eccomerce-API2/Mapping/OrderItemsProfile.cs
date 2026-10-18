using AutoMapper;
using Eccomerce_API2.DTOs.OrderItemDTO;
using Eccomerce_API2.Models;

namespace Eccomerce_API2.Mapping
{
    public class OrderItemsProfile : Profile
    {
        public OrderItemsProfile()
        {
            CreateMap<OrderItem, CreateOrderItemDTO>().ReverseMap();
            CreateMap<OrderItem, GetOrderItemDTO>().ReverseMap();
        }
    }
}
