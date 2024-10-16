using System;

namespace MedHelpApi.Services.Interfaces;

public interface IUserService<T, TI, TU, TT> //Note: TT = UserTokento
{

  public List<string> Errors{ get; }
  Task<IEnumerable<T>> Get();
  Task<T> GetById(int id);
  Task<T> GetByUsername(string username);
  Task<TT> Add(TI userInsertDto);
  Task<T> Update(int id, TU userUpdateDto);
  Task<T> Delete(int id);

  Task<TT> Login(string username, string password); 
  bool Validate(TI userInsertDto);
  bool Validate(TU userInsertDto);
  bool ValidateEmail(TI userInsertDto);
}
