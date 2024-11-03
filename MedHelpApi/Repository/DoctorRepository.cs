using System;
using MedHelpApi.Models;

namespace MedHelpApi.Repository;

public class DoctorRepository : IDoctorRepository
{
  private MedHelpContext _context;

  public DoctorRepository(MedHelpContext context ) {
    _context = context;
  }
    public Task<IEnumerable<Doctor>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Doctor entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Doctor entity)
    {
        throw new NotImplementedException();
    }
    public void Delete(Doctor entity)
    {
        throw new NotImplementedException();
    }


    public Task Save()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Doctor> Search(Func<Doctor, bool> filter)
    {
        throw new NotImplementedException();
    }

}
