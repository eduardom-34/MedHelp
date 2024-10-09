using System;

namespace MedHelpApi.DTOs;

public class PacientDto
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Username { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateTime SignUpDate { get; set; } = DateTime.Now;
  public byte[]? PasswordHash { get; set; }
  public byte[]? PasswordSalt { get; set; }
}
