using Microsoft.AspNetCore.Mvc;
using MVC.DataBase;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCContext context;
        public EmployeeController() { 
            
            context = new MVCContext();
        }


        public IActionResult GetAll()
        {
            var res = context.Employees.ToList();
            return View(res);
        }
    }
}
