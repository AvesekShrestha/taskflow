using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Taskflow.Application.User.Authentication;
using Taskflow.Domain.User;

namespace Taskflow.Infrastructure.Authentication;

public sealed class JWTTokenService(IConfiguration configuration) : ITokenService
{

  private readonly IConfiguration _configuration = configuration;

  public string GenerateToken(UserAggregate user)
  {
    List<Claim> claims = [
        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new(ClaimTypes.Email, user.Email.Value.ToString()),
        new(ClaimTypes.Role, user.Role.ToString())
    ];

    SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]!));
    SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

    JwtSecurityToken token = new(
        issuer: _configuration["JwtSettings:Issuer"],
        audience: _configuration["JwtSettings:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddHours(12),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
