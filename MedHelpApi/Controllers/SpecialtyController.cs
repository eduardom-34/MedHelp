using FluentValidation;
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
        private IValidator<SpecialtyInsertDto> _specialtyInsertValidator;
        private IValidator<SpecialtyUpdateDto> _specialtyUpdateValidator;

        public SpecialtyController(MedHelpContext context, 
            IValidator<SpecialtyInsertDto> specialtyInsertValidator, 
            IValidator<SpecialtyUpdateDto> specialtyUpdateValidator){
            _context = context;
            _specialtyInsertValidator = specialtyInsertValidator;
            _specialtyUpdateValidator = specialtyUpdateValidator;
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

        [HttpPost]
        public async Task<ActionResult<SpecialtyDto>> Add(SpecialtyInsertDto specialtyInsertDto)
        {
            var validationResult = await _specialtyInsertValidator.ValidateAsync(specialtyInsertDto);

            if (!validationResult.IsValid )
            {
                return BadRequest(validationResult.Errors);
            }

            var specialty = new Specialty()
            {
                Name = specialtyInsertDto.Name,
                Description = specialtyInsertDto.Description,
                CategoryID = specialtyInsertDto.CategoryID

            };

            await _context.Specialty.AddAsync(specialty);
            await _context.SaveChangesAsync();

            var specialtyDto = new SpecialtyDto
            {
                Id = specialty.SpecialtyID,
                Name = specialty.Name,
                Description = specialty.Description,
                CategoryID = specialty.CategoryID
            };
            
            return CreatedAtAction(nameof(GetById), new { id = specialty.SpecialtyID }, specialtyDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SpecialtyDto>> Update(int id, SpecialtyUpdateDto specialtyUpdateDto)
        {
            var validationResult = await _specialtyUpdateValidator.ValidateAsync(specialtyUpdateDto);
            if( !validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var specialty = await _context.Specialty.FindAsync(id);

            if( specialty == null)
            {
                return NotFound();
            }

            specialty.Name = specialtyUpdateDto.Name;
            specialty.Description = specialtyUpdateDto.Description;
            specialty.CategoryID = specialtyUpdateDto.CategoryID;
            await _context.SaveChangesAsync();

            var specialtyDto = new SpecialtyDto
            {
                Id = specialty.SpecialtyID,
                Name = specialty.Name,
                Description = specialty.Description,
                CategoryID = specialty.CategoryID
            };

            return Ok(specialtyDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var specialty = await _context.Specialty.FindAsync(id);

            if( specialty == null)
            {
                return NotFound();
            }

            _context.Specialty.Remove(specialty);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
