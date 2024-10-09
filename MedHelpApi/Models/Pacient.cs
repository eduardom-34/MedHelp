using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class Pacient
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int PacientID { get; set; }
  public string? Name { get; set; }
  public string? Username { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateTime SignUpDate { get; set; } = DateTime.Now;
  public byte[]? PasswordHash { get; set; }
  public byte[]? PasswordSalt { get; set; }

}
