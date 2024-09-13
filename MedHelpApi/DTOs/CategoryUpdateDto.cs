using System;

namespace MedHelpApi.DTOs;

public class CategoryUpdateDto
{
  public int CategoryID { get; set;}
  public string? Name { get; set;}
  public string? Description { get; set;}
}
