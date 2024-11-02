using System;
using MedHelpApi.Models;

namespace MedHelpApi.DTOs;

public class DoctorUpdateDto
{
  public int Id { get; set; }
  public string?  FirstName { get; set; }
  public string? LastName { get; set; }
  public string? UserName { get; set; }  
  public string?  Email { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateTime SignUpDate { get; set; }
  public string? Password { get; set; }
  public virtual List<Specialty>? Specialties {get; set;} = new List<Specialty>();
}
