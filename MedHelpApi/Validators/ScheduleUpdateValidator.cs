using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class ScheduleUpdateValidator: AbstractValidator<ScheduleUpdateDto>
{
  
  public ScheduleUpdateValidator()
  {
    // RuleFor(s => s.Day).NotEmpty();
    
  }

}
