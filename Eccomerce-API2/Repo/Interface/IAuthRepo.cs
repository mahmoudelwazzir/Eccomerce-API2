using Eccomerce_API2.DTOs.AuthDTO;
using Eccomerce_API2.Models;

namespace Eccomerce_API2.Repo.Interface
{
    public interface IAuthRepo
    {
        Task<string> Login(LoginDTO dto);
        Task<bool> Register(ApplicationUser user);
    }
}
