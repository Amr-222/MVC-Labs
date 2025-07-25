using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC.DataBase;
using MVC.DTO;
using MVC.Models;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCContext context;
        public EmployeeController()
        {

            context = new MVCContext();
        }



        public IActionResult SaveEmployee(EmployeeDTO empDTO)
        {
            if (empDTO.name != null && empDTO.salary > 0 && empDTO.age > 0)
            {

                Employee emp = new Employee(empDTO.name, empDTO.age, empDTO.salary, empDTO.createdby);
                context.Employees.Add(emp);
                context.SaveChanges();

                return RedirectToAction("GetAll", "Employee");
            }
            return View("Operations", empDTO);
        }



        public IActionResult GetDeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return View("Operations");
            }

            var emp = context.Employees.Where(a => a.Id == id).FirstOrDefault();

            if (emp == null)
            {
                ViewBag.ActiveTab = "delete";
                return View("Operations");
            }


            EmployeeDTO empDTO = new EmployeeDTO()
            {

                Id = id,
                name = emp.Name,
                age = emp.Age,
                salary = emp.Salary,
                createdby = emp.CreatedBy
            };
            ViewBag.ActiveTab = "delete";

            return View("Operations", empDTO);

        }

        public IActionResult GetEditEmployee(int id)
        {
            if (id <= 0)
            {
                return View("Operations");
            }

            var emp = context.Employees.Where(a => a.Id == id).FirstOrDefault();

            if (emp == null)
            {
                ViewBag.ActiveTab = "edit";
                return View("Operations");
            }


            EmployeeDTO empDTO = new EmployeeDTO()
            {

                Id = id,
                name = emp.Name,
                age = emp.Age,
                salary = emp.Salary,
                createdby = emp.CreatedBy
            };
            ViewBag.ActiveTab = "edit";

            return View("Operations", empDTO);

        }
        public IActionResult EditEmployee(EmployeeDTO empDTO)
        {

            var emp = context.Employees.Where(a => a.Id == empDTO.Id).FirstOrDefault();
           
            if (emp == null)
            {

                ViewBag.ActiveTab = "edit";
                return View("Operations");

            }

            emp.Edit(empDTO.name, empDTO.age, empDTO.salary);
            context.SaveChanges();

            return View("GetAll", context.Employees.ToList());
        }

        public IActionResult DeleteEmployee(EmployeeDTO empDTO)
        {
            var emp = context.Employees.Where(a => a.Id == empDTO.Id).FirstOrDefault();

            if (emp == null)
            {

                ViewBag.ActiveTab = "delete";
                return View("Operations");

            }

            emp.Delete();

            context.SaveChanges();

            return View("GetAll", context.Employees.ToList());


        }
        public IActionResult Operations()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var res = context.Employees.ToList();
            return View(res);
        }
    }
}
