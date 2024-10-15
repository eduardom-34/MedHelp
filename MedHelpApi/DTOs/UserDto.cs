using System;

namespace MedHelpApi.DTOs;

public class UserDto
{
  public int Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? UserName { get; set; }
  public string? Email { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateTime SignUpDate { get; set; } = DateTime.Now;
  public byte[]? PasswordHash { get; set; }
  public byte[]? PasswordSalt { get; set; }

}
