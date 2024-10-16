using System;

namespace MedHelpApi.Services.Interfaces;

public interface IUserService<T, TI, TU>
{

  public List<string> Errors{ get; }
  Task<IEnumerable<T>> Get();
  Task<T> GetById(int id);
  Task<T> Add(TI userInsertDto);
  Task<T> Update(int id, TU userUpdateDto);
  Task<T> Delete(int id);

  Task<T> Login(string username, string password); 
  bool Validate(TI userInsertDto);
  bool Validate(TU userInsertDto);
  bool ValidateEmail(TI userInsertDto);
}
