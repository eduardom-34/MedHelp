using System;

namespace MedHelpApi.DTOs;

public class SpecialtyInsertDto
{
  public string? Name { get; set; }
  public string? Description { get; set; }
  public int CategoryID { get; set; }
}
