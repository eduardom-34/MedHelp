using System.Text;
using FluentValidation;
using MedHelpApi.AutoMappers;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services;
using MedHelpApi.Services.Interfaces;
using MedHelpApi.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<ISpecialtiesService, SpecialtiesService>();
builder.Services.AddKeyedScoped<ICommonService<SpecialtyDto, SpecialtyInsertDto, SpecialtyUpdateDto>, SpecialtyService>("specialtyService");
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddKeyedScoped<IUserService<UserDto, UserInsertDto, UserUpdateDto, UserTokenDto>, UserService>("userService");

//Token Services
builder.Services.AddScoped<ITokenService<UserDto>, TokenService>();

//jwto Bearer
builder.Services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer( options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["tokenKey"]!)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                 });

//Repository
builder.Services.AddScoped<IRepository<Specialty>, SpecialtyRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
// builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Entity Framework Context
builder.Services.AddDbContext<MedHelpContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedhelpConnection"));
});

//Validators
builder.Services.AddScoped<IValidator<SpecialtyInsertDto>, SpecialtyInsertValidator>();
builder.Services.AddScoped<IValidator<SpecialtyUpdateDto>, SpecialtyUpdateValidator>();
builder.Services.AddScoped<IValidator<CategoryInsertDto>, CategoryInsertValidator >();
builder.Services.AddScoped<IValidator<CategoryUpdateDto>, CategoryUpdateValidator >();
builder.Services.AddScoped<IValidator<UserInsertDto>, UserInsertValidator >();
builder.Services.AddScoped<IValidator<UserUpdateDto>, UserUpdateValidator >();
builder.Services.AddScoped<IValidator<UserLoginDto>, UserLoginValidator >();


// Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers(Options => {});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
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
var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins")!.Split(",");

builder.Services.AddCors( opciones => {
    opciones.AddDefaultPolicy( policy => {
        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
