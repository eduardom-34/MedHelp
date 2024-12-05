using System;
using MedHelpApi.DTOs;

namespace MedHelpApi.Services.Interfaces;

public interface IDoctorService<T, TI, TU>
{
  public List<string> Errors { get; }
  Task<IEnumerable<T>> Get();
  Task<T> GetById(int id);
  Task<IEnumerable<T>> GetBySpecialty(int specialtyId);
  Task<T> Add(TI doctorInsertDto);
  Task<T> Update(int id, TU doctorUpdateDto);
  Task<T> Delete(int id);

  bool Validate(TI doctorInsertDto);
  bool Validate(TU doctorUpdateDto);
}
