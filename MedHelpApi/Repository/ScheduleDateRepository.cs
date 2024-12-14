using System;
using MedHelpApi.Models;
using MedHelpApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Repository;

public class ScheduleDateRepository : IScheduleDateRepository
{

  private MedHelpContext _context;

  public ScheduleDateRepository( MedHelpContext context)
  {
    _context = context;
  }

    public async Task<IEnumerable<ScheduleDate>> Get()
      => await _context.ScheduleDate.ToListAsync();

    public async Task<ScheduleDate> GetById(int id)
    => await _context.ScheduleDate.FindAsync(id);


    public async Task Add(ScheduleDate scheduleDate)
    => await _context.ScheduleDate.AddAsync(scheduleDate);

    public void Update(ScheduleDate scheduleDate)
    {
      _context.ScheduleDate.Attach(scheduleDate);
      _context.Entry(scheduleDate).State = EntityState.Modified;
    }
    
    public void Delete(ScheduleDate scheduleDate)
      => _context.ScheduleDate.Remove(scheduleDate);

    public Task Save()
    => _context.SaveChangesAsync();

}
