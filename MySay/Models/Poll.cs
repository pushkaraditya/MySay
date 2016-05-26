using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySay.Models
{
  public class Poll
  {
    public int Id { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")] 
    public DateTime EndingOn { get; set; }
  }
}