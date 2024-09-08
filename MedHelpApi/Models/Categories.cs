using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class Categories
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int CategoriesID { get; set;}
  public string? CategoriesName { get; set;}
  public string? CategoriesDescription { get; set;}

}
