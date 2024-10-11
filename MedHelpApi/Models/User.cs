using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class User
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int UserID { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? UserName { get; set; }
  public string? Email { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateTime SignUpDae { get; set; } = DateTime.Now;
  public byte[]? PasswordHash { get; set; }
  public byte[]? PasswordSalt { get; set; }

}
