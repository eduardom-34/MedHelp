using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class UserInsertValidator : AbstractValidator<UserInsertDto>
{
  public UserInsertValidator()
  {
    RuleFor(x => x.UserName).NotEmpty().WithMessage("The username is required");
    RuleFor(x => x.Password).NotEmpty().WithMessage("The password is required");
    
  }

}
