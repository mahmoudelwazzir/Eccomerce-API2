using AutoMapper;
using Eccomerce_API2.DTOs.AuthDTO;
using Eccomerce_API2.Models;

namespace Eccomerce_API2.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<ApplicationUser, LoginDTO>().ReverseMap();
            CreateMap<ApplicationUser, RegisterDTO>().ReverseMap();
        }
    }
}
