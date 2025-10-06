using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonG1WebApp.Models;
using MonG1WebApp.Repository;

namespace MonG1WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        // ITIContext context = new ITIContext();
        IDepartmentRepository DeptRepo;
        public DepartmentController(IDepartmentRepository deptrepo)
        {
            DeptRepo = deptrepo;// new DepartmentRepository();
        }
        [Authorize]//cookie iddenitty
        public IActionResult Index()
        {
            
            List<Department> departmentList = DeptRepo.GetAll();
            return View("Index",departmentList);
            //view Index ,Model Lsit<department>
        }


        public IActionResult New()
        {
            return View("New"); //Model =null
        }


        //Department/SaveNew?name=sd&ManagerName=valu
        // GET | POST
        [HttpPost]//check requet stype=post
        public IActionResult SaveNew(Department deptFromReq)//name input tag the same object property
        {
         //   if(Request.Method== "POST") { 
            //logic 
            if (deptFromReq.Name != null) {

                DeptRepo.Add(deptFromReq);
                DeptRepo.Save();
                //go to another Action "Request"
                return RedirectToAction("Index","Department");//searcj indein current controller
            }
            return View("New",deptFromReq);
            //view New
            //Model Department
        }  
        
        //Overload Case
    }
}
