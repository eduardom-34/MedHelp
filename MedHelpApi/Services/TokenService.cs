using System;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using MedHelpApi.DTOs;
using MedHelpApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace MedHelpApi.Services;

public class TokenService : ITokenService<UserDto>
{
  private readonly SymmetricSecurityKey _key;

  public TokenService(IConfiguration config)
  {
    // _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
    var tokenKey = config["TokenKey"];

    if (string.IsNullOrEmpty(tokenKey))
    {
      throw new ArgumentNullException(nameof(tokenKey), "TokenKey configuration is missing or empty.");
    }

    _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
  }
  public string CreateToken(UserDto userDto)
  {
    var claims = new List<Claim>
    {
      new Claim(JwtRegisteredClaimNames.NameId, userDto.UserName!)
    };

    var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.Now.AddDays(7),
      SigningCredentials = credentials
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
}
