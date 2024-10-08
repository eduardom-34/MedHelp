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
        private IValidator<SpecialtyInsertDto> _specialtyInsertValidator;
        private IValidator<SpecialtyUpdateDto> _specialtyUpdateValidator;
        private ICommonService<SpecialtyDto, SpecialtyInsertDto, SpecialtyUpdateDto> _specialtyService;

        public SpecialtyController(
            IValidator<SpecialtyInsertDto> specialtyInsertValidator, 
            IValidator<SpecialtyUpdateDto> specialtyUpdateValidator,
            [FromKeyedServices("specialtyService")] ICommonService<SpecialtyDto, SpecialtyInsertDto, SpecialtyUpdateDto> specialtyService
            ){
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

            if( !_specialtyService.Validate(specialtyInsertDto) )
            {
                return BadRequest(_specialtyService.Errors);
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

            if( !_specialtyService.Validate(specialtyUpdateDto) )
            {
                return BadRequest(_specialtyService.Errors);
            }
            
            var specialtyDto = await _specialtyService.Update(id, specialtyUpdateDto);

            return specialtyDto == null ? BadRequest(validationResult.Errors) : Ok(specialtyDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialtyDto>> Delete(int id)
        {
            var specialtyDto = await _specialtyService.Delete(id);
            return specialtyDto == null ? NotFound() : Ok(specialtyDto);
            
        }

    }
}
