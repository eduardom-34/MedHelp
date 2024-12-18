using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class ScheduleDateUpdateValidator: AbstractValidator<ScheduleDateUpdateDto>
{

  public ScheduleDateUpdateValidator()
  {
    RuleFor(s => s.Date).NotNull().WithMessage("You need to select a date");    
  }

}
