using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MedHelpApi.Models;

public class Schedule
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int ScheduleID { get; set; }

  [Required]
  public int DoctorID { get; set; }

  [ForeignKey("DoctorID")]
  public virtual Doctor Doctor { get; set; }

  
  [Required]
  public DayOfWeek Day { get; set; }
  [Required]
  public DateOnly Date { get; set; }
  public TimeSpan StartTime { get; set; }
  public TimeSpan EndTime { get; set; }

  [NotMapped]
  public bool IsValidTimeRange => StartTime < EndTime;

}
