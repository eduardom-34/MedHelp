using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class Doctor
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int DoctorID { get; set; }
  public string  FirstName { get; set; }
  public string LastName { get; set; }
  public string UserName { get; set; }  
  public string  Email { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateTime SignUpDate { get; set; } = DateTime.Now;
  public byte[] PasswordHash { get; set; }
  public byte[] PasswordSalt { get; set; }
  public virtual List<Specialty> Specialties {get; set;} = new List<Specialty>();
}
