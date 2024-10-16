using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class UserLoginValidator : AbstractValidator<UserLoginDto>
{
  public UserLoginValidator()
    {
      RuleFor(x => x.Username).NotEmpty().WithMessage("You must enter your username");
      RuleFor(x => x.Password).NotEmpty().WithMessage("You must enter your password");
    }
}
