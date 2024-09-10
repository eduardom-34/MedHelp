using System;
using MedHelpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Repository;

public class SpecialtyRepository : IRepository<Specialty>
{
    private MedHelpContext _context;

    public SpecialtyRepository(MedHelpContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Specialty>> Get()
        => await _context.Specialties.ToListAsync();

    public async Task<Specialty> GetById(int id)
        => await _context.Specialties.FindAsync(id);
    
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
