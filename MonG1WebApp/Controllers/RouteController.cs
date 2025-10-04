using Microsoft.AspNetCore.Mvc;
using MonG1WebApp.Filters;

namespace MonG1WebApp.Controllers
{
    //[Route("r/{action}")]
    //[HandeError]//action -conteroller -app
    public class RouteController : Controller
    {
        //Route/MEthod1?age=12&name=ahmed
        //r1?name=ahmed&age=12 ==>queryString
        //r1/{age}/{name}
        //r1/12/ahmed          ==>RouteValues
        //r1/23/christe          ==>RouteValues
        //r1/40/zarif          ==>RouteValues
        //r1/12
        //r1/45
        //[Route("r1/{age:int}/{name}")]
       // [HttpGet("r1/{age:int}/{name}")]
        public IActionResult Method1(string name,int age)
        {
                       
            return Content("M1");
        }
        //Route/MEthod2
        //r2 => Controller=Route ,Action=Method2
        public IActionResult Method2()
        {
            return Content("M2");
        }

        [HandeError]//action - controller  - app
        public IActionResult Method3()
        {
            throw new Exception();
        }
        //[HandeError]//action - controller  - app
        [MyFilter]
        public IActionResult Method4()
        {
            throw new Exception();
        }
    }
}
