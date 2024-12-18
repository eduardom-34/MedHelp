using System;

namespace MedHelpApi.DTOs;

public class ScheduleDateDto
{
  public int ScheduleDateID { get; set; }
  public DateOnly Date { get; set; }
  public int ScheduleID { get; set; }
}
