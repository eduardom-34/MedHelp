using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class Specialty
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int SpecialtyID { get; set;}
  public string? Name { get; set;}
  public string? Description { get; set;}

  [ForeignKey("CategoriesID")]
  public virtual required Category Categories {get; set;}

}
