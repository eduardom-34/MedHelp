using System;
using MedHelpApi.DTOs;

namespace MedHelpApi.Services.Interfaces;

public interface IDoctorService
{
  public List<string> Errors { get; }
  Task<IEnumerable<DoctorDto>> Get();
  Task<DoctorDto> GetById(int id);
  Task<DoctorDto> Add(DoctorInsertDto doctorInsertDto);
  Task<DoctorDto> Update(int id, DoctorUpdateDto doctorUpdateDto);
  Task<DoctorDto> Delete(int id);

  bool Validate(DoctorInsertDto doctorInsertDto);
  bool Validate(DoctorUpdateDto doctorUpdateDto);
}
