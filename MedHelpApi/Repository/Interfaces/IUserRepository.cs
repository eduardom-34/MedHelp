using System;
using MedHelpApi.Models;

namespace MedHelpApi.Repository;

public interface IUserRepository : IRepository<User>
{
  Task<User> GetByUsername(string username);
}
