using System.ComponentModel.DataAnnotations;

namespace WebApplicationData.Models
{
    public class Studentdata
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int age { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }
        [Required(ErrorMessage = "Course is required")]
        public string course { get; set; }
        [Required(ErrorMessage = "Number is required")]
        [Phone(ErrorMessage ="Pleas enter valid formate")]
        public string phone { get; set; }
    }
}
