using Microsoft.AspNetCore.Mvc;
using MonG1WebApp.Models;

namespace MonG1WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult Index()
        {
            List<Department> departmentList = context.Departments.ToList();
            return View("Index",departmentList);
            //view Index ,Model Lsit<department>
        }
    }
}
