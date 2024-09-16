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

    }
}