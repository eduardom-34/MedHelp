using FluentValidation;
using MedHelpApi.AutoMappers;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services;
using MedHelpApi.Services.Interfaces;
using MedHelpApi.Validators;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<ISpecialtiesService, SpecialtiesService>();
builder.Services.AddKeyedScoped<ICommonService<SpecialtyDto, SpecialtyInsertDto, SpecialtyUpdateDto>, SpecialtyService>("specialtyService");
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddKeyedScoped<IUserService<UserDto, UserInsertDto, UserUpdateDto, UserTokenDto>, UserService>("userService");

//Token Services
builder.Services.AddScoped<ITokenService<UserDto>, TokenService>();

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


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
