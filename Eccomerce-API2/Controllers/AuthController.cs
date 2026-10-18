using AutoMapper;
using Eccomerce_API2.DTOs.AuthDTO;
using Eccomerce_API2.Models;
using Eccomerce_API2.Repo.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eccomerce_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _repo;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> userLogin(LoginDTO dto)
        {
            var user = await _repo.Login(dto);
            if(user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> userRegister(RegisterDTO dto)
        {
            var ex = _mapper.Map<ApplicationUser>(dto);
            var user = await _repo.Register(ex);
            if (user)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
