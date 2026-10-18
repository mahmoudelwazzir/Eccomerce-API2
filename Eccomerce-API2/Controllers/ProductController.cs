using AutoMapper;
using Eccomerce_API2.DTOs.ProductDTO;
using Eccomerce_API2.Models;
using Eccomerce_API2.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Eccomerce_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfwork _unitofwork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfwork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        [HttpGet("paginationwithsort")]
        public async Task<IActionResult> GetAllpaginationwithsorting(int pagenumber, int pagesize, bool sortbyprice)
        {
            var product = await _unitofwork.Products.paginationWithsorting(pagenumber, pagesize, sortbyprice);
            var productdto = _mapper.Map<IEnumerable<GetProductDTO>>(product);
            return Ok(productdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByd(int id)
        {
            var product = await _unitofwork.Products.GetItemById(id);
            if(product == null) 
                return BadRequest();
            var productdto = _mapper.Map<GetProductDTO>(product);
            return Ok(productdto);  
        }
        [HttpGet("secondprice")]
        public async Task<IActionResult> lkdsjgk(int categoryid)
        {
            var product = await _unitofwork.Products.secondmostexpinsize(categoryid);
            if(product == null)
                return NotFound();
            var productdto = _mapper.Map<GetProductDTO>(product);
            return Ok(productdto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewproduct(CreateProductDTO dto)
        {
            if (dto == null)
                return BadRequest();
            var product = _mapper.Map<Product>(dto);
            await _unitofwork.Products.AddItem(product);
            await _unitofwork.save();
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateProduct(int id, CreateProductDTO dto)
        {
            if (dto == null)
                return BadRequest();
            var product = await _unitofwork.Products.GetItemById(id);
            _mapper.Map(dto, product);
            await _unitofwork.Products.UpdateItem(product);
            await _unitofwork.save();
            return Ok();
        }
        [HttpPatch("id")]
        public async Task<IActionResult> patchrpoduct(int id, PatchProductDTO dto)
        {
            if (dto == null)
                return BadRequest();
            var product = await _unitofwork.Products.GetItemById(id);
            if (product == null)
                return NotFound();
            _mapper.Map(dto, product);
            await _unitofwork.Products.UpdateItem(product);
            await _unitofwork.save();
            return Ok();
        }
        [HttpGet("Searchbyname")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var product = await _unitofwork.Products.searchByname(name);
            var productdto = _mapper.Map<IEnumerable<GetProductDTO>>(product);
            return Ok(productdto);
        }
    }
}
