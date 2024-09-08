using System;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Models;

public class MedHelpContext : DbContext
{
  public MedHelpContext(DbContextOptions<MedHelpContext> options)
  : base(options)
  {}

  public DbSet<Specialty> Specialty { get; set; }
  public DbSet<Category> Category { get; set; } 


}
