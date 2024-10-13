using System;

namespace MedHelpApi.Services.Interfaces;

public interface IUserService<T, TI, TU>
{

  public List<string> Errors{ get; }
  Task<IEnumerable<T>> Get();
  Task<T> GetById(int id);
  Task<T> Add(TI specialtyInsertDto);
  Task<T> Update(int id, TU specialtyUpdateDto);
  Task<T> Delete(int id);
  bool Validate(TI dto);
  bool Validate(TU dto);
}
