using AutoMapper;
using Eccomerce_API2.DTOs.OrderDTO;
using Eccomerce_API2.DTOs.OrderItemDTO;
using Eccomerce_API2.Models;
using Eccomerce_API2.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Eccomerce_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfwork _unitofwork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfwork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO dto)
        {
            if (dto == null)
                return BadRequest();
            var order = _mapper.Map<Order>(dto);
            await _unitofwork.Orders.AddItem(order);
            await _unitofwork.save();
            var orderitem = _mapper.Map<OrderItem>(dto.orderItem);
            orderitem.OrderId = order.Id;
            await _unitofwork.OrderItems.AddItem(orderitem);
            await _unitofwork.save();
            return Created();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByDetails(int id)
        {
            var order = await _unitofwork.Orders.GetOrderByDetails(id);
            if(order == null)
                return NotFound();
            var orderdto = _mapper.Map<GetOrderDTO>(order);
            return Ok(orderdto);
        }
    }
}
 