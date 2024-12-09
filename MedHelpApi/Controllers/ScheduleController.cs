using FluentValidation;
using MedHelpApi.DTOs;
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

    }
}
