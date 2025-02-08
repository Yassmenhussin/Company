using Lab1_MVC.DTO;
using Lab1_MVC.Models;
using Lab1_MVC.Models.Context;
using Lab1_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly CompanyContext context;
        public EmployeeController(CompanyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            /*var emps = context.employees.Include(d => d.department).ToList();

            List<EmpDepViewModel> employees = new List<EmpDepViewModel>();
            foreach (var item in emps)
            {
                employees.Add(new EmpDepViewModel()
                {
                    id = item.id,
                    name = item.name,
                    age = item.age,
                    salary = item.salary,
                    departmentName = item.department.name,
                });
            }*/
            var employees = context.employees.ToList();
            return View(employees);
        }

        public IActionResult Info(int id)
        {
            var employee = context.employees.FirstOrDefault(e => e.id == id);
            return View(employee);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = context.departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = context.departments.ToList();
                return View(employeeDTO);
            }
            Employee employee = new Employee()
            {
                name = employeeDTO.employeeName,
                age = employeeDTO.employeeAge,
                salary = employeeDTO.employeeSalary,
                Dep_id = employeeDTO.Dep_id,
            };
            context.employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Departments = context.departments.ToList();

            var employee = context.employees.FirstOrDefault(e => e.id == id);
            EmployeeDTO employeeDTO = new EmployeeDTO()
            {
                employeeName = employee.name,
                employeeAge = employee.age,
                employeeSalary = employee.salary,
                Dep_id = employee.Dep_id,
            };
            ViewBag.id = id;
            return View(employeeDTO);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeDTO employeeDTO)
        {
            var employee = context.employees.FirstOrDefault(e => e.id == id);
            if (!ModelState.IsValid)
            {
                ViewBag.id = id;
                return View(employeeDTO);
            }
            employee.name = employeeDTO.employeeName;
            employee.age = employeeDTO.employeeAge;
            employee.salary = employeeDTO.employeeSalary;
            employee.Dep_id = employeeDTO.Dep_id;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var employee = context.employees.FirstOrDefault(e => e.id == id);
            context.employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
