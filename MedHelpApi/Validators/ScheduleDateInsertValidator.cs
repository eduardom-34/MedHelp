using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class ScheduleDateInsertValidator: AbstractValidator<ScheduleDateInsertDto>
{

  public ScheduleDateInsertValidator()
  {
    RuleFor(s => s.Date).NotNull().WithMessage("You need to select a date");    
  }

}
