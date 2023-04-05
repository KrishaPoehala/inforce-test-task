using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Entities;
using Shortify.Common.ClaimNames;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shortify.Infrastucture.Services;

public class TokenProvider : ITokenProvider
{
    private readonly IConfiguration _configuration;

    public TokenProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
        var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
        var options = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: new List<Claim>()
            {
                new(ClaimNames.ID,user.Id),
                new(ClaimNames.ROLE, user.Role.ToString()),
            },
            expires:DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiryTime"])),
            signingCredentials:signInCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(options);
        return token;
    }
}
