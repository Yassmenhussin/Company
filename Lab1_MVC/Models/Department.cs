using System.ComponentModel.DataAnnotations;

namespace Lab1_MVC.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        List<Employee> departments { get; set; }
    }
}
