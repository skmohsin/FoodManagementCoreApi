using FoodManagementCore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagementCore.Services
{
    public interface IUser
    {
        List<User> GetUser();
        string Authenticate(User user);
    }

    public class UserService : IUser
    {
        public FoodManagementContext _dbContext;
        public readonly IConfiguration _configuration;
        public UserService(FoodManagementContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public string Authenticate(User user)
        {
            User response;
            try
            {
                response = _dbContext.Users.Where(x => x.Email == user.Email && x.Password == user.Password).SingleOrDefault();

                if (response == null)
                {
                    return null;
                }

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningSecret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, response.UserID.ToString()),
                    new Claim(ClaimTypes.Role, response.Role)
                };

                var tokeOptions = new JwtSecurityToken(
                   issuer: "http://localhost:5000",
                   audience: "http://localhost:5000",
                   claims: claims,
                   expires: DateTime.Now.AddMinutes(1),
                   signingCredentials: signinCredentials
               );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<User> GetUser()
        {
            return _dbContext.Users.Where(u => u.Role != "Admin").ToList();
        }
    }
}
