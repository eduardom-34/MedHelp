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
    public class ScheduleController : ControllerBase
    {
        private IScheduleService<ScheduleDto, ScheduleInsertDto, ScheduleUpdateDto> _scheduleService;
        private IValidator<ScheduleInsertDto> _scheduleInsertValidator;
        private IValidator<ScheduleUpdateDto> _scheduleUpdateValidator;

        public ScheduleController(
            [FromKeyedServices("scheduleService")]IScheduleService<ScheduleDto, ScheduleInsertDto, ScheduleUpdateDto> scheduleService,
            IValidator<ScheduleInsertDto> scheduleInsertValidator,
            IValidator<ScheduleUpdateDto> scheduleUpdateValidator
        )
        {
            _scheduleService = scheduleService;
            _scheduleInsertValidator = scheduleInsertValidator;
            _scheduleUpdateValidator = scheduleUpdateValidator;
            
        }

        [HttpGet]
        public async Task<IEnumerable<ScheduleDto>> Get()
            => await _scheduleService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDto>> GetById(int id)
        {
            var scheduleDto = await _scheduleService.GetById(id);

            return scheduleDto == null ? NotFound() : Ok(scheduleDto);
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleDto>> Add(ScheduleInsertDto scheduleInsertDto)
        {
            var result = _scheduleInsertValidator.Validate(scheduleInsertDto);

            if( !result.IsValid )
            {
                return BadRequest(result.Errors);
            }

            var scheduleDto = await _scheduleService.Add(scheduleInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = scheduleDto.ScheduleId }, scheduleDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ScheduleDto>> Update(ScheduleUpdateDto scheduleUpdateDto, int id)
        {
            var result = _scheduleUpdateValidator.Validate(scheduleUpdateDto);

            if( !result.IsValid ){
                return BadRequest(result.Errors);
            }

            var scheduleDto = await _scheduleService.Update(id, scheduleUpdateDto);

            return scheduleDto == null ? NotFound() : Ok(scheduleDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ScheduleDto>> Delete(int id)
        {
            var scheduleDto = await _scheduleService.Delete(id);
            return scheduleDto == null ? NotFound() : Ok(scheduleDto);
        }

        [HttpGet("doctor/{id}")]
        public async Task<ActionResult<ScheduleDate>> GetByDoctorId(int id)
        {
            var scheduleDto = await _scheduleService.GetByDoctorId(id);
            return scheduleDto == null ? NotFound() : Ok(scheduleDto);

        }

    }
}
