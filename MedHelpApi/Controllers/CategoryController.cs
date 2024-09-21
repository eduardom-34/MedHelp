using FluentValidation.Validators;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
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

        public CategoryController(MedHelpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get() =>
            await _context.Categories.Select( c => new CategoryDto{
                Id = c.CategoryID,
                Name = c.Name,
                Description = c.Description
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            var categoryDto = new CategoryDto
            {
                Id = category.CategoryID,
                Name = category.Name,
                Description = category.Description
            };

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Add(CategoryInsertDto categoryInsertDto)
        {
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
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
