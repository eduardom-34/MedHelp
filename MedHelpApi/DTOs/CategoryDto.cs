using System;

namespace MedHelpApi.DTOs;

public class CategoryDto
{

  public int Id { get; set;}
  public string Name { get; set;}
  public string Description { get; set;}
  public virtual List<string> SpecialtyNames { get; set; }

}
