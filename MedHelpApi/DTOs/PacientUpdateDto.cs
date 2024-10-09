using System;

namespace MedHelpApi.DTOs;

public class PacientUpdateDto
{

  public int PacientID { get; set; }
  public string? Name { get; set; }
  public string? Username { get; set; }
  public DateOnly BirthDate { get; set; }

}
