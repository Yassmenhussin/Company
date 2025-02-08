using System.ComponentModel.DataAnnotations;

namespace Lab1_MVC.DTO
{
    public class DepartmentDTO
    {
        [Display(Name = "Enter Department Name")]
        [Required(ErrorMessage = "Department Name Required")]
        [MinLength(3, ErrorMessage = "Minimum 3 Character")]
        [MaxLength(10, ErrorMessage = "Maximum 10 Character")]
        public string departmentName { get; set; }
    }
}
