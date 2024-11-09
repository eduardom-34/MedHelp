using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class Specialty
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int SpecialtyID { get; set;}
  public string Name { get; set;}
  public string Description { get; set;}

  public int CategoryID { get; set;}

  [ForeignKey("CategoryID")]
  public virtual Category Category {get; set;}
  public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
