using System;
using MedHelpApi.Models;

namespace MedHelpApi.DTOs;

public class DoctorDto
{
  public int Id { get; set; }
  public string?  FirstName { get; set; }
  public string? LastName { get; set; }
  public string?  Email { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateTime SignUpDate { get; set; }
  public byte[]? PasswordHash { get; set; }
  public byte[]? PasswordSalt { get; set; }
  public virtual List<Specialty>? Specialties {get; set;} = new List<Specialty>();
}