using System;

namespace MedHelpApi.DTOs;

public class SpecialtyUpdateDto
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public int CategoryID { get; set; }
}
