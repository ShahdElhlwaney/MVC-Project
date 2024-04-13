using FirstProject.Models;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterViewModel newUserVM)
        {
            if(ModelState.IsValid)
            {
               
                ApplicationUser user = new ApplicationUser();
                user.UserName = newUserVM.UserName;
                user.Address = newUserVM.Address;
                user.PasswordHash = newUserVM.Password;
               var result=await userManager.CreateAsync(user,newUserVM.Password);
                if(result.Succeeded)
                {
                    //create cookie   
                   await signInManager.SignInAsync(user, isPersistent: false);// Id,Name,Roles
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("password", errorItem.Description);
                    }
                }
            }
            return View();
        }
        public  IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginVM)
        {
            if(ModelState.IsValid)
            {
               ApplicationUser user=await userManager.FindByNameAsync(userLoginVM.UserName);
                if(user != null) 
                {
                    bool found =await userManager.CheckPasswordAsync(user, userLoginVM.Password);
                    if (found==true)
                    {
                        //create cokie
                       await signInManager.SignInAsync(user,userLoginVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Name or Password is Invalid, Please Enter Your Information Correctly ");

            }
            return View(userLoginVM);

        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult AddAdmin() {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(UserRegisterViewModel newUserVM) {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = newUserVM.UserName;
                user.Address = newUserVM.Address;
                user.PasswordHash = newUserVM.Password;
                var result = await userManager.CreateAsync(user, newUserVM.Password);
                if (result.Succeeded)
                {
                   await userManager.AddToRoleAsync(user,"Admin");
                    // create cookie
                    await signInManager.SignInAsync(user, isPersistent: false);// Id,Name,Roles
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("password", errorItem.Description);
                    }
                }
            }
            return View(newUserVM);
        }


    }
}
