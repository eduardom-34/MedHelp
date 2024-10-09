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
  public async Task<Pacient> GetById(int id)
    => await _context.Pacients.FindAsync(id);
    
  public async Task Add(Pacient pacient)
    => await _context.Pacients.AddAsync(pacient);

  public void Update(Pacient pacient)
  {
    throw new NotImplementedException();
  }
  public void Delete(Pacient pacient)
  {
    throw new NotImplementedException();
  }


  public async Task Save()
    => await _context.SaveChangesAsync();

  public IEnumerable<Pacient> Search(Func<Pacient, bool> filter)
  {
    throw new NotImplementedException();
  }

}
