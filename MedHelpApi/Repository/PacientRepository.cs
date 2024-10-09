using System;
using MedHelpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Repository;

public class PacientRepository : IRepository<Pacient>
{
  private MedHelpContext _context;

public PacientRepository( MedHelpContext context)
{
  _context = context;
}

    public async Task<IEnumerable<Pacient>> Get()
      => await _context.Pacients.ToListAsync();
  public Task<Pacient> GetById(int id)
  {
    throw new NotImplementedException();
  }
  public Task Add(Pacient entity)
  {
    throw new NotImplementedException();
  }

  public void Update(Pacient entity)
  {
    throw new NotImplementedException();
  }
  public void Delete(Pacient entity)
  {
    throw new NotImplementedException();
  }


  public Task Save()
  {
    throw new NotImplementedException();
  }

  public IEnumerable<Pacient> Search(Func<Pacient, bool> filter)
  {
    throw new NotImplementedException();
  }

}
