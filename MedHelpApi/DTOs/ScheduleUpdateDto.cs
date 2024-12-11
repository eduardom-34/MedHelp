using System;

namespace MedHelpApi.DTOs;

public class ScheduleUpdateDto
{
  public int ScheduleId { get; set; }
  public int DoctorID { get; set; }
  public DateOnly Date { get; set; }
  public TimeSpan StartTime { get; set; }
  public TimeSpan EndTime { get; set; }
}