using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MonG1WebApp.Models;

namespace MonG1WebApp.Controllers
{
    public class BindController : Controller
    {
        //test different parameter data type 
        /*
         <form method="get" action="/Bind/TestPrimitive">
            <input name="name">
            <input name="age">
            <input type=submit>
         </form>
         */
        //bind/TestPrimitive?name=ahmed&age=10&id=99&color=red
        //bind/TestPrimitive/99?name=ahmed&age=10&color[1]=red&color[0]=blue

        //test primitive data type
        public IActionResult testPrimitive(int age ,string name,int id,string[] color)
        {
            return Content("HIIIIIIIIIIIII");
        }

        //Test Collection (list | Dictionary ...)
        //Bind/TestDic?name=Christen&PhoneBook[ahmed]=123&PhoneBook[mohamed]=456
        public IActionResult TestDic(Dictionary<string, int> PhoneBook,string name) {
        
            return Content("HIIIIIIIIIIIII");

        }


        //Test Complex (Class)
        //Bind/TestObj/1?Name=SD&ManagerName=ahmed&Employees[0].Name=Hamada
        //public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee> Employees)
        public IActionResult TestObj(Department dept)//create =new DEpartment()
        {
            return Content("HIIIIIIIIIII");
        }


    }
}
