using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class Doctor
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int DoctorId { get; set; }

}
