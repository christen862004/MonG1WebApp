using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MonG1WebApp.Controllers
{
    public class StateController : Controller
    {

        //State/TestData
        public IActionResult TestData()
        {
            if (User.Identity.IsAuthenticated == true)
            {

                //bool admin= User.IsInRole("Admin");//Claim
                string name = User.Identity.Name;//get username loged user
                Claim idClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string id = idClaim.Value;

                // Claim addClaim = User.Claims.FirstOrDefault(c => c.Type == "Address");

                //User Weleomce NAme
                return Content($"Welcoem {name} \nId: {id}");//\nAddress:{addClaim.Value}");
            }
            else
            {
                //Gust wElcome Gust
                return Content("Welcome Gust");
            }
        }










        // public - non ststiac  -no overload only in one case

        [HttpGet]//State/MEhod1 (get)
        public IActionResult Method1()
        {
            return Content("Method1 Overload 1");
        }
        [HttpPost]
        public IActionResult Method1(int id)
        {
            return Content("Method1 Overload 2");
        }



        public IActionResult SetSession(string name)
        {
            //logic
            //info state management using session
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", 39);

            return Content("Save Data Sucees");
        }

        public IActionResult GetSession()
        {
            //logic
            string? n= HttpContext.Session.GetString("Name");
            int? a =  HttpContext.Session.GetInt32("Age");
            return Content($"name={n} \n age ={a}");
        }

        public IActionResult SetCookie(string name)
        {
            //logic
            //Session Cookie
            HttpContext.Response.Cookies.Append("Name", name);
            //Presisitent Cookie "Expriation Date"
            CookieOptions cookieOption = new CookieOptions() { 
                Expires = DateTime.Now.AddHours(1),
            };
            HttpContext.Response.Cookies.Append("Age", "20",cookieOption);
            return Content("Cookie Save Success");
        }

        public IActionResult GetCookie()
        {
            //logic
            string name= HttpContext.Request.Cookies["Name"];
            string age= HttpContext.Request.Cookies["Age"];

            return Content($" Name={name}\t age={age}");
        }
    }
}
