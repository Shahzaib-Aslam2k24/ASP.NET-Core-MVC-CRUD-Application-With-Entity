using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Practice.Models;

public partial class Student
{
    public int SId { get; set; }

    [Display(Name ="Student Name")]
    [Required]
    public string? SName { get; set; }
    [Display(Name = "Student Caste")]
    [Required]
    public string? SCaste { get; set; }
    [Display(Name = "Course Phone")]
    [Required]
    public string? SPhone { get; set; }

    public string? SAddress { get; set; }

    [Display(Name = "Course Id")]
    [Required]
    public int? Id { get; set; }

    public virtual Courses? IdNavigation { get; set; }
}
