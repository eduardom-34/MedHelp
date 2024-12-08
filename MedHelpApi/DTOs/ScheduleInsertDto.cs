using System;

namespace MedHelpApi.DTOs;

public class ScheduleInsertDto
{
  public int DoctorID { get; set; }
  public DayOfWeek Day { get; set; }
  public TimeSpan StartTime { get; set; }
  public TimeSpan EndTime { get; set; }

}
