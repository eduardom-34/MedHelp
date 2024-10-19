using System;
using MedHelpApi.DTOs;
using MedHelpApi.Models;

namespace MedHelpApi.Services.Interfaces;

public interface ITokenService<T> //Note: T = userDto
{
  string CreateToken(T userDto);

  bool ValidateToken(string token);

  string GetUserFromToken(string token);
}
