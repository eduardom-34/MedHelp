using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class ScheduleDate
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int ScheduleDateID { get; set; }
  [Required]
  public DateOnly Date { get; set; }
  [Required]
  public int ScheduleID { get; set; }
  [ForeignKey("ScheduleID")]
  public virtual Schedule Schedule { get; set; }
}
