using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonG1WebApp.Models;
using MonG1WebApp.ViewModels;
using System.Security.Claims;

namespace MonG1WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //---------------------------------------------
        #region Register
        public IActionResult register()
        {
            return View("register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> register(RegisterUserViewModel userFromRequest)
        {
            if (ModelState.IsValid) //use ValidationAttribute
            {
                //create user db
                ApplicationUser User = new ApplicationUser() {
                    UserName = userFromRequest.UserName,
                    PasswordHash = userFromRequest.Password,
                    Address = userFromRequest.Address
                };
                IdentityResult result=await userManager.CreateAsync(User,userFromRequest.Password); //Passwordd Validation
                if(result.Succeeded)
                {
                    //assign role to specific user
                    IdentityResult roleResult=await userManager.AddToRoleAsync(User, "Admin");
                    //create cookie
                    await signInManager.SignInAsync(User, false);//create cookie[username, id,email ,role ]
                    //action
                    return RedirectToAction("Index", "Department");
                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);//Div 
                } 

            }
            
            return View("register", userFromRequest);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //check 
                ApplicationUser userFromDb=await userManager.FindByNameAsync(userFromReq.UserName);
                if(userFromDb != null) {
                    bool found=await userManager.CheckPasswordAsync(userFromDb, userFromReq.Password);
                    if (found)
                    {
                        //create cookie(id,name,role,email)
                        //await signInManager.SignInAsync(userFromDb, userFromReq.RememberMe);
                        List<Claim> Claims = new ();
                        Claims.Add(new Claim("Address", userFromDb.Address));

                        await signInManager.SignInWithClaimsAsync(userFromDb, userFromReq.RememberMe, Claims);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login",userFromReq);
        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }
        #endregion
    }
}
