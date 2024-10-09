using System;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Models;

public class MedHelpContext : DbContext
{
  public MedHelpContext(DbContextOptions<MedHelpContext> options)
  : base(options)
  {}

  public DbSet<Specialty> Specialties { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Pacient> Pacients { get; set; }


}
