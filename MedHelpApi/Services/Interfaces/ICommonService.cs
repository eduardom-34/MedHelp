using System;
using MedHelpApi.DTOs;

namespace MedHelpApi.Services.Interfaces;

public interface ICommonService<T, TI, TU>
{
  Task<IEnumerable<T>> Get();
  Task<T> GetById(int id);
  Task<T> Add(TI specialtyInsertDto);
  Task<T> Update(int id, TU specialtyUpdateDto);
  Task<T> Delete(int id);
}
