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
            return View("Index",context.Employees.ToList());
        }

        #region Edit
        public IActionResult Edit(int id) {
            //collecte
            Employee empFromDB = context.Employees.FirstOrDefault(e=>e.Id==id);
            List<Department> deptList = context.Departments.ToList();
            //ddeclare viewMoedl
            EmployeeWithDeptListViewModel EmpViewModel = new();
            //mapping
            EmpViewModel.Id = empFromDB.Id;
            EmpViewModel.Name = empFromDB.Name;
            EmpViewModel.Email = empFromDB.Email;
            EmpViewModel.Salary = empFromDB.Salary;
            EmpViewModel.ImageURL = empFromDB.ImageURL;
            EmpViewModel.DepartmentID = empFromDB.DepartmentID;
            EmpViewModel.DeptList=deptList;

            //send viewModel
            return View("Edit", EmpViewModel);//Mdel EmployeeWithDeptListViewModel
        }

        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel empFromReq)
        {
            if(empFromReq.Name != null)
            {
                //get oldd ref
                Employee EmpFromDb= context.Employees.FirstOrDefault(e => e.Id == empFromReq.Id);
                //map
                EmpFromDb.Salary= empFromReq.Salary;
                EmpFromDb.Name= empFromReq.Name;
                EmpFromDb.ImageURL=empFromReq.ImageURL;
                EmpFromDb.Email=empFromReq.Email;
                EmpFromDb.DepartmentID=empFromReq.DepartmentID;
                //save
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            
            //refill local lists
            empFromReq.DeptList = context.Departments.ToList();
            return View("Edit", empFromReq);
        }
        #endregion


        #region     DEtails
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
        #endregion
    }
}
