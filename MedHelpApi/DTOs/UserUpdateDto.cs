using System;

namespace MedHelpApi.DTOs;

public class UserUpdateDto
{
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string UserName { get; set; }
  public string Email { get; set; }
  public DateOnly BirthDate { get; set; }
  public string Password { get; set; }

}
