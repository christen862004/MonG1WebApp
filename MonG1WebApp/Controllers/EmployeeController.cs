using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonG1WebApp.Models;
using MonG1WebApp.ViewModels;

namespace MonG1WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public EmployeeController()
        {
            
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Details(int id)
        {
            //send to view Extar info
            string msg = "Hello FRom Back";
            int Temp = 30;
            List<string> branches= 
                new List<string>() { "Alex","Smart","New Capital","Monofia"};
            //Send Info Using Viewdata Dictionary
         
            ViewData["Msg"] = msg;//boxing
            ViewData["Temp"] = Temp;
            ViewData["Brch"] = branches;
            
            ViewData["Clr"] = "Red";
            ViewBag.Clr = "Blue";//Override 


            ViewBag.xyz = "Hello";//set ugin viewbag ViewData["xyz"]="Hello
            
            //Send Employee in Model
            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);
            return View("Details",empModel); //Model =Employee
        }

        public IActionResult DetailsVM(int id)
        {
            //Collected Data Frm Differernt Source
            string msg = "Hello FRom Back";
            int Temp = 30;
            List<string> branches =
                new List<string>() { "Alex", "Smart", "New Capital", "Monofia" };
            Employee empModel = context.Employees.Include(e=>e.Department).FirstOrDefault(e => e.Id == id);

            //Declare VM Object
            EmpNameWithMSgClrTempBrachListViewModel EmpVM = new();

            //Map Get Data From Sourec set In VM 
            EmpVM.EmpId = empModel.Id;
            EmpVM.EmpName = empModel.Name;
            EmpVM.DeptName = empModel.Department.Name;
            EmpVM.Message = msg;
            EmpVM.Temp = Temp;
            EmpVM.Branches = branches;
            EmpVM.Color = "red";

            //send ViewModel to View 
            return View("DetailsVM", EmpVM);
            //View "DetailsVM"
            //Model EmpNameWithMSgClrTempBrachListViewModel
        }
    }
}
