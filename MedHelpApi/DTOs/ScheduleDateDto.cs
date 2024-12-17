using System;

namespace MedHelpApi.DTOs;

public class ScheduleDateDto
{
  public int Id { get; set; }
  public DateOnly Date { get; set; }
  public int ScheduleID { get; set; }
}
