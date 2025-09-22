using Microsoft.AspNetCore.Mvc;
using MonG1WebApp.Models;
using System.Diagnostics;

namespace MonG1WebApp.Controllers
{
    //any class can be controller can handel request
    // 1 ) class Name End with (suffix) Controller KeyWord
    // 2 ) class inherit from Controller

    
    public class HomeController : Controller
    {
        /*
            any action Can request in URL (endpoint)
            1) Method must  be Public 
            2) Method Can't be Static
            3) MEthod can't be Overload only in one case 
         */
        //domain/Home/ShowMsg
        public ContentResult ShowMsg()
        {
            //logic...........................
            //declare
            ContentResult result = new ContentResult();
            //set value
            result.Content = "Hello from  Backend ";
            //return 
            return result;
        }

        //Home/ShowView
        //Views/Home/View1.cshtml
        //Views/Shared/View1.cshtml
        //throw exception
        public ViewResult ShowView()
        {
            //logic
            return View("View1");
        }

        //Home/ShowMix?val=10&id=1  as Query string
        //Home/ShowMix?val=11&id=2  as Query string
        //Home/ShowMix/1111?val=11  as avl send Query string ,id send in route value

        public IActionResult ShowMix(int val,int id)
        {
            if (val % 2 == 0)
            {
                return View("View1");
            }
            else
            {
                //loicg
                return Content("Hello FRom Back");
            }
        }
        //ViewResult View(string ViewNAme)
        //{
        //    //logic
        //    ViewResult result = new ViewResult();
        //    //set
        //    result.ViewName = "View1";
        //    //return 
        //    return result;
        //}

        /* ActonResult==>IActionResult
         1) Content ==> ContentREsult
         2) View    ==> ViewResult
         3) Json    ==> JsonResult
         4) File    ==> FileResult
         5) NotFound==> NotFoundResult
         6) .......
         
         
         */



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
