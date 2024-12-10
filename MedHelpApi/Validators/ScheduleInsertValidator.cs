using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class ScheduleInsertValidator: AbstractValidator<ScheduleInsertDto>
{
  public ScheduleInsertValidator()
  {
    // RuleFor(s => s.Day).NotEmpty();
  }

}
