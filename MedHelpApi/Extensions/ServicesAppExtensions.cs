using System;
using FluentValidation;
using MedHelpApi.AutoMappers;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services;
using MedHelpApi.Services.Interfaces;
using MedHelpApi.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MedHelpApi.Extensions;

public static class ServicesAppExtensions
{

  public static IServiceCollection AddServicesApp(this IServiceCollection services, IConfiguration config)
  {
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
      options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Description = "Add Bearer [space] token \r\n\r\n "
                      + "Example: Bearer [space] 1234567890",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
      });
      options.AddSecurityRequirement(new OpenApiSecurityRequirement(){
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    });


    //CORS
    var allowedOrigins = config.GetValue<string>("AllowedOrigins")!.Split(",");


    //Token Services
    services.AddScoped<ITokenService<UserDto>, TokenService>();

    //Entity Framework Context
    services.AddDbContext<MedHelpContext>(options =>
    {
      options.UseSqlServer(config.GetConnectionString("MedhelpConnection"));
    });

    //Cors
    services.AddCors(opciones =>
    {
      opciones.AddDefaultPolicy(policy =>
      {
        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
      });
    });

    //Other Services


    // builder.Services.AddSingleton<ISpecialtiesService, SpecialtiesService>();
    services.AddKeyedScoped<ICommonService<SpecialtyDto, SpecialtyInsertDto, SpecialtyUpdateDto>, SpecialtyService>("specialtyService");
    services.AddScoped<ICategoryService, CategoryService>();
    services.AddKeyedScoped<IUserService<UserDto, UserInsertDto, UserUpdateDto, UserTokenDto>, UserService>("userService");



    //Repository
    services.AddScoped<IRepository<Specialty>, SpecialtyRepository>();
    services.AddScoped<IRepository<Category>, CategoryRepository>();
    // builder.Services.AddScoped<IRepository<User>, UserRepository>();
    services.AddScoped<IUserRepository, UserRepository>();

    //Validators
    services.AddScoped<IValidator<SpecialtyInsertDto>, SpecialtyInsertValidator>();
    services.AddScoped<IValidator<SpecialtyUpdateDto>, SpecialtyUpdateValidator>();
    services.AddScoped<IValidator<CategoryInsertDto>, CategoryInsertValidator>();
    services.AddScoped<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
    services.AddScoped<IValidator<UserInsertDto>, UserInsertValidator>();
    services.AddScoped<IValidator<UserUpdateDto>, UserUpdateValidator>();
    services.AddScoped<IValidator<UserLoginDto>, UserLoginValidator>();


    // Mappers
    services.AddAutoMapper(typeof(MappingProfile));


    return services;
  }

}
