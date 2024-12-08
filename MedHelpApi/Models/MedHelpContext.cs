using System;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Models;

public class MedHelpContext : DbContext
{
  public MedHelpContext(DbContextOptions<MedHelpContext> options)
  : base(options)
  {}

  public required DbSet<Specialty> Specialties { get; set; }
  public required DbSet<Category> Categories { get; set; }
  public required DbSet<User> Users { get; set; }
  public required DbSet<Doctor> Doctors { get; set; }
  public required DbSet<Schedule> Schedules { get; set; }


}
