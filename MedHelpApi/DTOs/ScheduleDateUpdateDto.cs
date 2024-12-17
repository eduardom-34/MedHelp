using System;

namespace MedHelpApi.DTOs;

public class ScheduleDateUpdateDto
{
  public int ScheduleDateId { get; set; }
  public DateOnly Date { get; set; }
  public int ScheduleID { get; set; }

}
