using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonG1WebApp.ViewModels;

namespace MonG1WebApp.Controllers
{
    [Authorize(Roles ="Admin")]//check Cookie ==> Role="Admin"
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult New()
        {
            return View("New");
        }
        
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel roleFromReq)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { 
                    Name=roleFromReq.RoleName
                };
                IdentityResult result= await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View("New");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);//div
                }
            }
            return View("New",roleFromReq);
        }
    }
}
