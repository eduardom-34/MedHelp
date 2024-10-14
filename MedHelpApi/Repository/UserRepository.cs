using System;
using MedHelpApi.Models;

namespace MedHelpApi.Repository;

public class UserRepository : IRepository<User>
{
    public Task<IEnumerable<User>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }
    public Task Add(User entity)
    {
        throw new NotImplementedException();
    }
    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }


    public Task Save()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> Search(Func<User, bool> filter)
    {
        throw new NotImplementedException();
    }

}
