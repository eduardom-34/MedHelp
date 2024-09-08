using MedHelpApi.DTOs;
using MedHelpApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private MedHelpContext _context;

        public SpecialtyController(MedHelpContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<SpecialtyDto>> Get() => 
        await _context.Specialty.Select(s => new SpecialtyDto{
            Id = s.SpecialtyID,
            Name = s.Name,
            Description = s.Description,
            CategoryID = s.CategoryID

        }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialtyDto>> GetById(int id)
        {
            var specialty = await _context.Specialty.FindAsync(id);

            if (specialty == null) 
            {
                return NotFound();
            }

            var specialtyDto = new SpecialtyDto
            {
                Id = specialty.SpecialtyID,
                Name = specialty.Name,
                Description = specialty.Description,
                CategoryID = specialty.CategoryID
            };

            return Ok(specialtyDto);
        }

    }
}
