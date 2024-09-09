using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class SpecialtyInsertValidator : AbstractValidator<SpecialtyInsertDto>
{
  public SpecialtyInsertValidator()
  {
    RuleFor(x => x.Name).NotEmpty();
  }
}
