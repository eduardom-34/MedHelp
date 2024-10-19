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


  public bool ValidateToken(string token)
  {
    if (string.IsNullOrEmpty(token))
      return false;

    var tokenHandler = new JwtSecurityTokenHandler();

    if (!tokenHandler.CanReadToken(token))
      return false;

    var validationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = _key,
      ValidateIssuer = false,
      ValidateAudience = false
    };
    
    try
    {
        tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        return validatedToken != null; 
    }
    catch (SecurityTokenException)
    {
        return false;
    }
    catch (Exception)
    {
        // hanlde other erros if needed
        return false;
    }
  }

  public string GetUserFromToken(string token)
  {
    if (string.IsNullOrEmpty(token)) return null;

    var tokenHandler = new JwtSecurityTokenHandler();

    var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
    
    if (jwtToken == null)
        return null;

    
    var nameid = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId)?.Value;

    return nameid;

  }


}
