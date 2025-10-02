using Microsoft.AspNetCore.Mvc;
using MonG1WebApp.Repository;

namespace MonG1WebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService service;

        public ServiceController(IService service)
        {
            this.service = service;
        }
        public IActionResult Index()//[FromServices]IService servce)//
        {
            ViewBag.Id = service.Id;
            return View();
        }
    }
}
