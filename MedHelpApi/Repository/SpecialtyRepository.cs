using System;
using MedHelpApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.VisualBasic.FileIO;

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
    
    public async Task Add(Specialty specialty)
        => await _context.Specialties.AddAsync(specialty);

    public void Update(Specialty specialty)
    {
        _context.Specialties.Attach(specialty);
        _context.Specialties.Entry(specialty).State = EntityState.Modified;
    }

    public void Delete(Specialty specialty)
    => _context.Specialties.Remove(specialty);

    public async Task Save()
        => await _context.SaveChangesAsync();

    public IEnumerable<Specialty> Search(Func<Specialty, bool> filter)
    => _context.Specialties.Where(filter).ToList();
}
