using System;
using System.Data;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class CategoryInsertValidator : AbstractValidator<CategoryInsertDto>
{
  public CategoryInsertValidator()
  {
    RuleFor(c => c.Name).NotEmpty().WithMessage("The name is required");
    RuleFor(c => c.Name).Length(2, 200).WithMessage("The names must have 2 to 200 chars");
    RuleFor(c => c.Description).NotEmpty().WithMessage("Description cannot be empty");
  }
}