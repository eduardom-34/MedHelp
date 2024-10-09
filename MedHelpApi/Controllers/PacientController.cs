using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientController : ControllerBase
    {
        private ICommonService<PacientDto, PacientInsertDto, PacientUpdateDto> _pacientService;

        public PacientController([FromKeyedServices("pacientService")] ICommonService<PacientDto, PacientInsertDto, PacientUpdateDto> pacientService)
        {
            _pacientService = pacientService;
        }

        [HttpGet]
        public async Task<IEnumerable<PacientDto>> Get()
            => await _pacientService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<PacientDto>> GetById(int id)
        {
            var pacientDto = await _pacientService.GetById(id);

            return pacientDto == null ? NotFound() : Ok(pacientDto);
        }
        
        [HttpPost("register")] //POST: api/Pacient/register
        public async Task<ActionResult<PacientDto>> Add(PacientInsertDto pacientInsertDto)
        {
            var pacientDto = await _pacientService.Add(pacientInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = pacientDto.Id }, pacientDto);
        }

    }
}
