using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class Specialties
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int SpecialtiesID { get; set;}
  public string? SpecialtiesName { get; set;}
  public string? SpecialtiesDescription { get; set;}

  [ForeignKey("CategoriesID")]
  public virtual required Categories Categories {get; set;}

}
