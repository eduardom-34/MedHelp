using System;

namespace MedHelpApi.Services.Interfaces;

public interface IScheduleDateService<T, TI, TU>
{
  public List<string> Errors{ get; }
  Task<IEnumerable<T>> Get();
  Task<T> GetById(int id);
  Task<T> Add(TI scheduleDateInsertDto);
  Task<T> Update(int id, TU scheduleDateUpdateDto);
  Task<T> Delete(int id);
}
