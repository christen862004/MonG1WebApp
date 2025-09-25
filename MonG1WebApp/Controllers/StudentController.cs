using Microsoft.AspNetCore.Mvc;
using MonG1WebApp.Models;

namespace MonG1WebApp.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();
        //Student/All
        public IActionResult All()
        {
            
            List<Student> stdListModel = 
                studentBL.GetAll();
            //send View
            return View("ShowAll", stdListModel);//Search form View in this path
            //Views/Student/ShowAll.cshtml
            //Model : List<Student>
        }


        public IActionResult Details(int id)
        {
            Student stdModel= studentBL.GetByID(id);
            //1) return View();// Search View With the same Action Name "Details" ,Model=Null
            //2) return View("Details");// Search For Details View ,Model=Null
            //3) return View("Details",stdModel);// Search For Details View ,Model=Student
            return View(stdModel);// Search For Details View ,Model=Student
        }
    }
}
