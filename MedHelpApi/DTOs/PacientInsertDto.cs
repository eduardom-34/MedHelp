using System;

namespace MedHelpApi.DTOs;

public class PacientInsertDto
{
  public string? Name { get; set; }
  public string? Username { get; set; }
  public DateOnly BirthDate { get; set; }
  public string? Password { get; set; }
}
