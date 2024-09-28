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
        private IValidator<CategoryInsertDto> _categoryInsertValidator;
        private IValidator<CategoryUpdateDto> _categoryUpdateValidator;
        private ICategoryService _categoryService;

        public CategoryController(
        IValidator<CategoryInsertDto> categoryInsertValidator, 
        IValidator<CategoryUpdateDto> categoryUpdateValidator,
        ICategoryService categoryService)
        {
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

            if( !_categoryService.Validate(categoryInsertDto))
            {
                return BadRequest(_categoryService.Errors);
            }
            
            var categoryDto = await _categoryService.Add(categoryInsertDto);
            
            return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id}, categoryDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Update(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var validationResult = await _categoryUpdateValidator.ValidateAsync(categoryUpdateDto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if( !_categoryService.Validate(categoryUpdateDto))
            {
                return BadRequest(_categoryService.Errors);
            }
            
            
            var categoryDto = await _categoryService.Update(id, categoryUpdateDto);

            return categoryDto == null ? NotFound() : Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDto>> Delete(int id)
        {
            var categoryDto = await _categoryService.Delete(id);

            return categoryDto == null ? NotFound() : Ok(categoryDto);
        }

    }
}
