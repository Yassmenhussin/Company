using Lab1_MVC.Models;
using Lab1_MVC.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Lab1_MVC.DTO;

namespace Lab1_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        public readonly CompanyContext context;
        public DepartmentController(CompanyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            //ViewData["id"] = 111111;
            //ViewBag.name = "Yasmsen";
            ViewBag.id = TempData["id"];
            TempData.Keep();


            ViewBag.userName = HttpContext.Session.GetString("userName");

            var departments = context.departments.ToList();
            return View(departments);
            
        }
        public IActionResult Info(int id)
        {
            var department = context.departments.FirstOrDefault(d => d.id == id);
            return View(department); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentDTO);
            }
            Department department = new Department()
            {
                name = departmentDTO.departmentName
            };
            context.departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = context.departments.FirstOrDefault(d => d.id == id);
            DepartmentDTO departmentDTO = new DepartmentDTO()
            {
                departmentName = department.name
            };
            ViewBag.id = id;
            return View(departmentDTO);
        }

        [HttpPost]
        public IActionResult Edit(int id, DepartmentDTO departmentDTO)
        {
            var department = context.departments.FirstOrDefault(d => d.id == id);
            if (!ModelState.IsValid)
            {
                ViewBag.id = id;
                return View(departmentDTO);
            }
            department.name = departmentDTO.departmentName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            var department = context.departments.FirstOrDefault(d => d.id == id);
            context.departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




        public IActionResult vieww()
        {
            /*List<Department> departments = new List<Department>
            {
                new Department { id = 1, name = "HR" },
                new Department { id = 2, name = "IT" },
                new Department { id = 4, name = "Marketing" },
                new Department { id = 5, name = "Accounting" },
                new Department { id = 6, name = "Purchasing" }
            };

            return View(departments);*/
            //ViewData["id"] = 111111;
            //var department = new Department();
            ViewBag.name = "Yasmsen";
            //ViewBag.id = 10;
            return View();
            //return View(department);
        }

    }
}