using System;
using MedHelpApi.Models;

namespace MedHelpApi.DTOs;

public class DoctorInsertDto
{
  public string  FirstName { get; set; }
  public string LastName { get; set; }
  public string UserName { get; set; }  
  public string  Email { get; set; }
  public DateOnly BirthDate { get; set; }
  public string Password { get; set; }
  public virtual List<int> SpecialtyIds {get; set;} = new List<int>();
}
