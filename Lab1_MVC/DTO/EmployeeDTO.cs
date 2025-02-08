using System.ComponentModel.DataAnnotations;

namespace Lab1_MVC.DTO
{
    public class EmployeeDTO
    {
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee Name is required")]
        [MinLength(3, ErrorMessage = "Employee Name must be at least 3 characters")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Employee Name can only contain letters")]
        public string employeeName { get; set; }

        [Display(Name = "Employee Age")]
        [Required(ErrorMessage = "Employee Age is required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Employee Age can only contain numbers")]
        public int employeeAge { get; set; }

        [Display(Name = "Employee Salary")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Employee Salary can only contain numbers")]
        public decimal employeeSalary { get; set; }

        [Display(Name = "Employee Department")]
        [Required(ErrorMessage = "Employee Department is required")]
        public int Dep_id { get; set; }
    }
}
