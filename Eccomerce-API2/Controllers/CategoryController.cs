using AutoMapper;
using Eccomerce_API2.DTOs.CategoryDTO;
using Eccomerce_API2.Models;
using Eccomerce_API2.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eccomerce_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfwork _unitofwork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfwork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProdut()
        {
            var category = await _unitofwork.Categories.GetAllitem();
            var categorydto = _mapper.Map<IEnumerable<GetAllCategoryDTO>>(category);
            return Ok(categorydto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO dto)
        {
            if(dto == null)
            {
                return BadRequest();
            }
            var category = _mapper.Map<Category>(dto);
            await _unitofwork.Categories.AddItem(category);
            await _unitofwork.save();
            return Created();
        }
    }
}