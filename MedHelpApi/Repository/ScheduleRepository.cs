using System;
using MedHelpApi.Models;
using MedHelpApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Repository;

public class ScheduleRepository : IScheduleRepository
{
  private MedHelpContext _context;

  public ScheduleRepository( MedHelpContext context )
  {
    _context = context;
  }

  public async Task<IEnumerable<Schedule>> Get()
  {
    return await _context.Schedules.ToListAsync();
  }

  public async Task<Schedule> GetById(int id)
  => await _context.Schedules.FindAsync(id);

  public async Task Add(Schedule schedule)
    => await _context.Schedules.AddAsync(schedule);

  public void Update(Schedule schedule)
  {
    _context.Attach(schedule);
    _context.Schedules.Entry(schedule).State = EntityState.Modified;
  }
  public void Delete(Schedule schedule)
  => _context.Schedules.Remove(schedule);

  public async Task Save()
    => await _context.SaveChangesAsync();

  public IEnumerable<Schedule> Search(Func<Schedule, bool> filter)
    => _context.Schedules.Where(filter).ToList();

  public async Task<List<Schedule>> GetByDoctorId(int id)
  => await _context.Schedules.Where( s => s.DoctorID == id).ToListAsync();
  
}
