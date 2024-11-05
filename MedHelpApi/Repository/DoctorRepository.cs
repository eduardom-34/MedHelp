using System;
using MedHelpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Repository;

public class DoctorRepository : IDoctorRepository
{
  private MedHelpContext _context;

  public DoctorRepository(MedHelpContext context ) {
    _context = context;
  }
    public async Task<IEnumerable<Doctor>> Get()
        => await _context.Doctors.ToListAsync();

    public async Task<Doctor> GetById(int id)
        => await _context.Doctors.FindAsync(id);

    public async Task Add(Doctor doctor)
        => await _context.Doctors.AddAsync(doctor);

    public void Update(Doctor doctor){
        _context.Attach(doctor);
        _context.Doctors.Entry(doctor).State = EntityState.Modified;
    }

    public void Delete(Doctor doctor)
        => _context.Doctors.Remove(doctor);


    public async Task Save()
        => await _context.SaveChangesAsync();

    public IEnumerable<Doctor> Search(Func<Doctor, bool> filter)
    {
        return _context.Doctors.Where(filter).ToList();
    }

}
