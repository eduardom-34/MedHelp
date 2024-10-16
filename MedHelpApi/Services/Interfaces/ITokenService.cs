using System;
using MedHelpApi.DTOs;
using MedHelpApi.Models;

namespace MedHelpApi.Services.Interfaces;

public interface ITokenService<T> //Note: T = userDto
{

  

  string CreateToken(T userDto);

}
