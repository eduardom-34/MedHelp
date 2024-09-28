using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
{
  public CategoryUpdateValidator()
  {
    RuleFor(c => c.Id).NotNull().WithMessage("Id must not be empty");
    RuleFor(c => c.Name).NotEmpty().WithMessage("The name is required");
    RuleFor(c => c.Name).Length(2, 200).WithMessage("The names must have 2 to 200 chars");
    RuleFor(c => c.Description).NotEmpty().WithMessage("Description cannot be empty");
  }
}
