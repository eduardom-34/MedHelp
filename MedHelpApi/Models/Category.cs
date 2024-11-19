using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class Category
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int CategoryID { get; set;}
  public string Name { get; set;}
  public string Description { get; set;}
  public virtual List<Specialty> Specialties { get; set; } = new List<Specialty>();

}
