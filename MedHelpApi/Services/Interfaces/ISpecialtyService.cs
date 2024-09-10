using System;
using MedHelpApi.DTOs;

namespace MedHelpApi.Services.Interfaces;

public interface ISpecialtyService
{
  Task<IEnumerable<SpecialtyDto>> Get();
  Task<SpecialtyDto> GetById(int id);
  Task<SpecialtyDto> Add(SpecialtyInsertDto specialtyInsertDto);
  Task<SpecialtyDto> Update(int id, SpecialtyUpdateDto specialtyUpdateDto);
  Task<SpecialtyDto> Delete(int id);
}
