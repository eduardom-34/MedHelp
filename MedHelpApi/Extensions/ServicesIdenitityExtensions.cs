using System;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MedHelpApi.Extensions;

public static class ServicesIdenitityExtensions
{
  public static IServiceCollection AddServiceIdentity(this IServiceCollection services, IConfiguration config)
  {
    //jwto Bearer
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                     .AddJwtBearer(options =>
                     {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["tokenKey"]!)),
                         ValidateIssuer = false,
                         ValidateAudience = false
                       };
                     });

    return services;
  }

}
