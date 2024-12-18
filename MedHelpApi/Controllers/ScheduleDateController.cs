using FluentValidation;
using MedHelpApi.DTOs;
using MedHelpApi.Migrations;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleDateController : ControllerBase
    {
        private IScheduleDateService<ScheduleDateDto, ScheduleDateInsertDto, ScheduleDateUpdateDto> _scheduleDateService;
        private IValidator<ScheduleDateInsertDto> _scheduleDateInsertValidator;
        private IValidator<ScheduleDateUpdateDto> _scheduleDateUpdateValidator;


        public ScheduleDateController(
            [FromKeyedServices("scheduleDateService")] IScheduleDateService<ScheduleDateDto, ScheduleDateInsertDto, ScheduleDateUpdateDto> scheduleDateService,
            IValidator<ScheduleDateInsertDto> scheduleDateInsertValidator,
            IValidator<ScheduleDateUpdateDto> scheduleDateUpdateValidator
            )
        {
            _scheduleDateService = scheduleDateService;
            _scheduleDateInsertValidator = scheduleDateInsertValidator;
            _scheduleDateUpdateValidator = scheduleDateUpdateValidator;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleDateDto>>> Get()
        {
            var schedulesDateDto = await _scheduleDateService.Get();

            return schedulesDateDto == null ? NotFound(): Ok(schedulesDateDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDateDto>> GetById(int id)
        {
            var scheduleDateDto = await _scheduleDateService.GetById(id);

            return scheduleDateDto == null ? NotFound() : Ok(scheduleDateDto);
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleDateDto>> Add(ScheduleDateInsertDto scheduleDateInsertDto)
        {
            var result = _scheduleDateInsertValidator.Validate(scheduleDateInsertDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var scheduleDateDto = await _scheduleDateService.Add(scheduleDateInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = scheduleDateDto.ScheduleID }, scheduleDateDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ScheduleDateDto>> Update(ScheduleDateUpdateDto scheduleDateUpdateDto, int id)
        {
            var result = _scheduleDateUpdateValidator.Validate(scheduleDateUpdateDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var scheduleDateDto = await _scheduleDateService.Update(id, scheduleDateUpdateDto);

            return scheduleDateDto == null ? NotFound() : Ok(scheduleDateDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ScheduleDateDto>> Delete(int id)
        {
            var scheduleDateDto = await _scheduleDateService.Delete(id);

            return scheduleDateDto == null ? NotFound() : Ok(scheduleDateDto);
        }

    }
}
