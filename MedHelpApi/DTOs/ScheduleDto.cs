using System;
using MedHelpApi.Models;

namespace MedHelpApi.DTOs;

public class ScheduleDto
{
  public int ScheduleId { get; set; }
  public int DoctorId { get; set; }
  public virtual Doctor Doctor { get; set; }
  public DayOfWeek Day { get; set; }
  public TimeSpan StartTime { get; set; }
  public TimeSpan EndTime { get; set; }

}
