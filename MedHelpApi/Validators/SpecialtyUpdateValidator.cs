using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class SpecialtyUpdateValidator : AbstractValidator<SpecialtyUpdateDto>
{
  public SpecialtyUpdateValidator()
  {
    RuleFor(x => x.Id).NotNull().WithMessage("The Id is required");
    RuleFor(x => x.Name).NotEmpty().WithMessage("The name is required");
    RuleFor(x => x.Name).Length(2, 30).WithMessage("The name must have at leat 2 characters and no more than 30 characters");
    RuleFor(x => x.CategoryID).NotEmpty().WithMessage("The Category is Required");
    RuleFor(x => x.CategoryID).GreaterThan(0).WithMessage("Error with the Category sent");
    RuleFor(x => x.CategoryID).GreaterThan(0).WithMessage("The {PropertyName} must be greater than 0");
  }
}
