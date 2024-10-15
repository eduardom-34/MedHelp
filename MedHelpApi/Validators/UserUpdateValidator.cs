using System;
using System.Data;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{

  public UserUpdateValidator()
  {
    RuleFor(x => x.UserName).NotEmpty().WithMessage("The username cannot be empty");
    RuleFor(x => x.Password).NotEmpty().WithMessage("The password cannot be empty");
    RuleFor(x => x.Email).NotEmpty().WithMessage("The email cannot be empty");
  }

}
