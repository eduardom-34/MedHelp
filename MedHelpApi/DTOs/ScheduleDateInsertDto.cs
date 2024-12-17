using System;

namespace MedHelpApi.DTOs;

public class ScheduleDateInsertDto
{
  public DateOnly Date { get; set; }
  public int ScheduleID { get; set; }

}
