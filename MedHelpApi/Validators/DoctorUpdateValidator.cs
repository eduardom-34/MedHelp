using System;
using FluentValidation;
using MedHelpApi.DTOs;

namespace MedHelpApi.Validators;

public class DoctorUpdateValidator: AbstractValidator<DoctorUpdateDto>
{
  public DoctorUpdateValidator() {
    RuleFor(d => d.FirstName).NotEmpty().WithMessage("Your first name can't be empty");
    RuleFor(d => d.LastName).NotEmpty().WithMessage("Your last name can't be empty");
    RuleFor(d => d.UserName).NotEmpty().WithMessage("The username is required");
    RuleFor(d => d.Email).NotEmpty().WithMessage("The email is required");
    RuleFor(d => d.Password).NotEmpty().WithMessage("The password is required");
  }

}
