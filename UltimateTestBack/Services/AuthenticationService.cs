using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Services
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly IConfiguration _config;

        public AuthenticationService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> Login(UserLoginDto userLogin)
        {
            var Users = new List<UserModel> {
                new UserModel { Username="farid",Role="normal",Password="123"},
                new UserModel { Username="samer",Role="normal",Password="123"}
            };
            var currentUser = Users.FirstOrDefault(x => x.Username.ToLower() ==
                 userLogin.Username.ToLower() && x.Password == userLogin.Password);
            if (currentUser != null)
            {
                return GenerateToken(currentUser);
            }
            return null;
        }

        private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
