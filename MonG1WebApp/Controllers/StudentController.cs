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
    }
}
