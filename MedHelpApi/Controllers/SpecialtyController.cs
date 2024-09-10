using FluentValidation;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services.Interfaces;
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
        private ISpecialtyService _specialtyService;

        public SpecialtyController(MedHelpContext context, 
            IValidator<SpecialtyInsertDto> specialtyInsertValidator, 
            IValidator<SpecialtyUpdateDto> specialtyUpdateValidator,
            ISpecialtyService specialtyService
            ){
            _context = context;
            _specialtyInsertValidator = specialtyInsertValidator;
            _specialtyUpdateValidator = specialtyUpdateValidator;
            _specialtyService = specialtyService;
        }

        [HttpGet]
        public async Task<IEnumerable<SpecialtyDto>> Get() => 
        await _specialtyService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialtyDto>> GetById(int id)
        {
            var specialtyDto = await _specialtyService.GetById(id);

            return specialtyDto == null ? NotFound() : Ok(specialtyDto);
        }

        [HttpPost]
        public async Task<ActionResult<SpecialtyDto>> Add(SpecialtyInsertDto specialtyInsertDto)
        {
            var validationResult = await _specialtyInsertValidator.ValidateAsync(specialtyInsertDto);

            if (!validationResult.IsValid )
            {
                return BadRequest(validationResult.Errors);
            }

            var specialtyDto = await _specialtyService.Add(specialtyInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = specialtyDto.Id }, specialtyDto);
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
        public async Task<ActionResult<SpecialtyDto>> Delete(int id)
        {
            var specialty = await _context.Specialty.FindAsync(id);

            if( specialty == null)
            {
                return NotFound();
            }

            _context.Specialty.Remove(specialty);
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

    }
}
