using System;

namespace MedHelpApi.DTOs;

public class SpecialtyUpdate
{
  public string? Name { get; set; }
  public string? Description { get; set; }
  public int CategoriesID { get; set; }
}
