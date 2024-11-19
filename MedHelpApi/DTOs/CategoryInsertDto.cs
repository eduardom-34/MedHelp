using System;

namespace MedHelpApi.DTOs;

public class CategoryInsertDto
{
  public string Name { get; set;}
  public string Description { get; set;}
  public virtual List<int> SpecialtyID { get; set; }

}
