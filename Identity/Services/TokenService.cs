using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Identity.Api.Data.Models;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Services
{
    #region ITokenService
    public interface ITokenService
    {
        string CreateToken(User user);
        string GenerateRefreshToken();
        Task StoreRefreshToken(string userId, string refreshToken);
        Task<string> GetStoredRefreshToken(string userId);
        Task RemoveStoredRefreshToken(string userId);
    }
    #endregion

    public class TokenService(IConfiguration configuration) : ITokenService
    {
        protected readonly IConfiguration _configuration  = configuration;
        public string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task StoreRefreshToken(string userId, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetStoredRefreshToken(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveStoredRefreshToken(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
