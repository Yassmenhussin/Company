using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1_MVC.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public decimal salary { get; set; }
        [ForeignKey("department")]
        public int Dep_id { get; set; }
        public Department department { get; set; }
    }
}
