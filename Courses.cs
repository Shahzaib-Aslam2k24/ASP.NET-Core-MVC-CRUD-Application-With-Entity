using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Practice.Models;

public class Courses
{
    public int CId { get; set; }
    [Required(ErrorMessage ="Please enter course name")]
    [Display(Name ="Course Name")]
    public string? CName { get; set; }
    [Required(ErrorMessage = "Please enter course fee")]
    [Display(Name = "Course Fees")]
    public int? CFee { get; set; }
    [Display(Name = "Course Duration")]
    [Required]
    public string? CDuration { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
