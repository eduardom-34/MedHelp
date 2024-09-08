using System;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Models;

public class MedHelpContext : DbContext
{
  public MedHelpContext(DbContextOptions<MedHelpContext> options)
  : base(options)
  {}

  public DbSet<Specialties> Specialties { get; set; }
  public DbSet<Categories> Categories { get; set; } 


}
