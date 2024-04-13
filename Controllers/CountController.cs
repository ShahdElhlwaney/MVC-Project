using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class CountController : Controller
    {
        static int count = 0;

        public IActionResult Index()
        {
            
            ViewBag.Count = count;
            return View();
        }
        [HttpPost]
        public IActionResult Increment()
        {
            count++;
            return RedirectToAction("Index");
        }
    }
}
