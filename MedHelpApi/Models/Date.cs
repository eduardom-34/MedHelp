using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedHelpApi.Models;

public class Date
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int DateID { get; set; }
  


}
