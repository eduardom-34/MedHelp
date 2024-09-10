using System;
using MedHelpApi.Models;

namespace MedHelpApi.Repository;

public class SpecialtyRepository : IRepository<Specialty>
{
  public Task<IEnumerable<Specialty>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Specialty> GetById()
    {
        throw new NotImplementedException();
    }
    
    public Task Add(Specialty entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Specialty entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Specialty entity)
    {
        throw new NotImplementedException();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }
}
