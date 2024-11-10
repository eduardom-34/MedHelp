using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using FluentValidation;
using MedHelpApi.DTOs;
using MedHelpApi.Services;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService _doctorService;
        private IValidator<DoctorInsertDto> _doctorInsertValidator;
        private IValidator<DoctorUpdateDto> _doctorUpdateValidator;
        public DoctorController(IDoctorService doctorService,
        IValidator<DoctorInsertDto> doctorInsertValidator,
        IValidator<DoctorUpdateDto> doctorUpdateValidator
        )
        {
            _doctorService = doctorService;     
            _doctorInsertValidator = doctorInsertValidator;
            _doctorUpdateValidator = doctorUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<DoctorDto>> Get() =>
            await _doctorService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<DoctorDto>> GetById(int id)
        {
            var doctor = await _doctorService.GetById(id);
            
            return doctor == null ? NotFound() : Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto>> Add(DoctorInsertDto doctorInsertDto)
        {
            var result = _doctorInsertValidator.Validate(doctorInsertDto);
            
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            if( _doctorService.Validate(doctorInsertDto) == false )
            {
                return BadRequest(_doctorService.Errors);
            }

            var doctorDto = await _doctorService.Add(doctorInsertDto);

            return CreatedAtAction(nameof(GetById), new {id = doctorDto.Id}, doctorDto );

        }
    }
}
