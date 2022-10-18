using AutoMapper;
using Entities.Context;
using Microsoft.IdentityModel.Tokens;
using P2P.Base.Services;
using P2P.DTO.Output;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace P2P.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserODTO user);
        bool IsTokenValid(string key, string issuer, string token);
    }
    public class TokenService : BaseService, ITokenService
    {
        private const double EXPIRY_DURATION_MINUTES = 240;
        public TokenService(MainContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public string BuildToken(string key, string issuer, UserODTO user)
        {
            var claims = new[] {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier,
            Guid.NewGuid().ToString())
        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        public bool IsTokenValid(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
