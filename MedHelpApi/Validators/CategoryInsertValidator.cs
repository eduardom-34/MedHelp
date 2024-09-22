using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class CategoryInsertValidator : AbstractValidator<CategoryInsertDto>
{
  public CategoryInsertValidator()
  {
    RuleFor(c => c.Name).NotEmpty();
  }
}
