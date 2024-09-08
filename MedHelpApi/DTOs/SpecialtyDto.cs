using System;

namespace MedHelpApi.DTOs;

public class SpecialtyDto
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  public int CategoryID { get; set; }

}
