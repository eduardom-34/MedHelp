using System;
using FluentValidation;
using MedHelpApi.AutoMappers;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Repository.Interfaces;
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
    //Token Services
    services.AddScoped<ITokenService<UserDto>, TokenService>();
    //Doctor Service
    services.AddKeyedScoped<IDoctorService<DoctorDto, DoctorInsertDto, DoctorUpdateDto>, DoctorService>("doctorService");
    // Schedule Service
    services.AddKeyedScoped<IScheduleService<ScheduleDto, ScheduleInsertDto, ScheduleUpdateDto>, ScheduleService>("scheduleService");
    // ScheduleDate Service
    services.AddKeyedScoped<IScheduleDateService<ScheduleDateDto, ScheduleDateInsertDto, ScheduleDateUpdateDto>, ScheduleDateService>("scheduleDateService");


    //Repository
    // services.AddScoped<IRepository<Specialty>, SpecialtyRepository>();
    services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
    services.AddScoped<IRepository<Category>, CategoryRepository>();
    // builder.Services.AddScoped<IRepository<User>, UserRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IDoctorRepository, DoctorRepository>();
    services.AddScoped<IScheduleRepository, ScheduleRepository>();
    services.AddScoped<IScheduleDateRepository, ScheduleDateRepository>();

    //Validators
    services.AddScoped<IValidator<SpecialtyInsertDto>, SpecialtyInsertValidator>();
    services.AddScoped<IValidator<SpecialtyUpdateDto>, SpecialtyUpdateValidator>();
    services.AddScoped<IValidator<CategoryInsertDto>, CategoryInsertValidator>();
    services.AddScoped<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
    services.AddScoped<IValidator<UserInsertDto>, UserInsertValidator>();
    services.AddScoped<IValidator<UserUpdateDto>, UserUpdateValidator>();
    services.AddScoped<IValidator<UserLoginDto>, UserLoginValidator>();
    services.AddScoped<IValidator<DoctorInsertDto>, DoctorInsertValidator>();
    services.AddScoped<IValidator<DoctorUpdateDto>, DoctorUpdateValidator>();
    services.AddScoped<IValidator<ScheduleInsertDto>, ScheduleInsertValidator>();
    services.AddScoped<IValidator<ScheduleUpdateDto>, ScheduleUpdateValidator>();
    services.AddScoped<IValidator<ScheduleDateInsertDto>, ScheduleDateInsertValidator>();
    services.AddScoped<IValidator<ScheduleDateUpdateDto>, ScheduleDateUpdateValidator>();

    // Mappers
    services.AddAutoMapper(typeof(MappingProfile));


    return services;
  }

}
