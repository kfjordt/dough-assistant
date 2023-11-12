using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DoughAssistantBackend.Models;
using Microsoft.IdentityModel.Tokens;

namespace DoughAssistantBackend.Services
{
    public class TokenService
    {
        private string _tokenKey;
        public TokenService(string tokenKey)
        {
            _tokenKey = tokenKey;
        }

        public string CreateNewToken(string name, TimeSpan tokenExpirationTime)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_tokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, name),
                }),
                Expires = DateTime.UtcNow.Add(tokenExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}