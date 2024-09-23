using FluentValidation;
using FluentValidation.Validators;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private MedHelpContext _context;
        private IValidator<CategoryInsertDto> _categoryInsertValidator;
        private IValidator<CategoryUpdateDto> _categoryUpdateValidator;
        private ICategoryService _categoryService;

        public CategoryController(MedHelpContext context, 
        IValidator<CategoryInsertDto> categoryInsertValidator, 
        IValidator<CategoryUpdateDto> categoryUpdateValidator,
        ICategoryService categoryService)
        {
            _context = context;
            _categoryInsertValidator = categoryInsertValidator;
            _categoryUpdateValidator = categoryUpdateValidator;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get() =>
            await _categoryService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var categoryDto = await _categoryService.GetById(id);

            return categoryDto == null ? NotFound() : Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Add(CategoryInsertDto categoryInsertDto)
        {
            var validationResult = await _categoryInsertValidator.ValidateAsync(categoryInsertDto);

            if( !validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var category = new Category()
            {
                Name = categoryInsertDto.Name,
                Description = categoryInsertDto.Description
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var categoryDto = new CategoryDto
            { 
                Id = category.CategoryID,
                Name = category.Name,
                Description = category.Description
            };

            return CreatedAtAction(nameof(GetById), new { id = category.CategoryID}, categoryDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Update(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var validationResult = await _categoryUpdateValidator.ValidateAsync(categoryUpdateDto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var category = await _context.Categories.FindAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            category.Name = categoryUpdateDto.Name;
            category.Description = categoryUpdateDto.Description;
            await _context.SaveChangesAsync();

            var categoryDto = new CategoryDto
            {
                Id = category.CategoryID,
                Name = category.Name,
                Description = category.Description
            };

            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDto>> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            var categoryDto = new CategoryDto
            {
                Id = category.CategoryID,
                Name = category.Name,
                Description = category.Description
            };

            return Ok(categoryDto);
        }

    }
}
