using FirstProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Web;
namespace FirstProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

        }
        [Authorize]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Upload(ImageViewModel imageVM)
        {
            if (imageVM.imageFile != null && imageVM.imageFile.Length > 0)
            {
                // Define the path to save the uploaded image
                var uploadsFolder =  Path.Combine(_webHostEnvironment.WebRootPath, "Images");
               // string fileName =   Guid.NewGuid().ToString() + "_" + imageVM.imageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, imageVM.imageFile.FileName);
                // Save the uploaded image to disk
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageVM.imageFile.CopyToAsync(stream);
                }
                // Redirect to a view where you can display the uploaded image
                TempData["path"] = imageVM.imageFile.FileName;
                return RedirectToAction("Index");
            }


            return View("Index");
        }
    }
    
}