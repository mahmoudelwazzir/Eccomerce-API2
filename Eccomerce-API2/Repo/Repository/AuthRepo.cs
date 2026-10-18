using Eccomerce_API2.Data;
using Eccomerce_API2.DTOs.AuthDTO;
using Eccomerce_API2.Models;
using Eccomerce_API2.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;

namespace Eccomerce_API2.Repo.Repository
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepo(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if(user == null)
            {
                return null;
            }
            if(user.PasswordHash == dto.Password)
            {
                return GenerateToken(user);
            }
            return null;
        }

        public async Task<bool> Register(ApplicationUser user)
        {
            var ex = await _context.Users.AnyAsync(u => u.Email ==  user.Email);
            if (ex)
            {
                return false;
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
        private string GenerateToken(ApplicationUser user)
        {
            #region user_claim
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            #endregion
            #region user_credit
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Key"]));
            var Credit = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            #endregion
            var tokenobj = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claim,
                signingCredentials: Credit,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["JWT:ExpiresInHoures"]))
                );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenobj);
            return token;
        }
    }
}
