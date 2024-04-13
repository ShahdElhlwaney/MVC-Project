using FirstProject.Repository;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        IRoleRepository roleRepo;
        public RoleController(RoleManager<IdentityRole> roleManager, IRoleRepository roleRepo)
        {
            this.roleManager = roleManager;
            this.roleRepo=roleRepo;
        }
        public IActionResult Index()
        {
            return View(roleRepo.GetRoles());
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(RoleViewModel roleVM)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleVM.RoleName;
              IdentityResult result= await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("", errorItem.Description);
                    }
                }
            }
            return View(roleVM);
        }
    }
}
