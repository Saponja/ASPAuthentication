using Airport.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Airport.Api.Services
{
    public class AuthService : IAuthService
    {
        string jwtSecret;
        int jwtLifespan;

        public AuthService(string jwtSecret, int jwtLifespan)
        {
            this.jwtSecret = jwtSecret;
            this.jwtLifespan = jwtLifespan;

        }

        public AuthData GetAuthData(string id, string role)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(jwtLifespan);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id),
                    new Claim(ClaimTypes.Role, role)
                    
                }),
                Expires = expirationTime,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthData
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                Id = id,
                Role = role
            };
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}
