using FirstProject.Models;
using FirstProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository crsRepo;
        public CourseController(ICourseRepository crsRepo)
        {
            this.crsRepo = crsRepo;
        }

        public IActionResult Index()
        {
            
            return View(crsRepo.GetAll());
        }
        public IActionResult New() {
         
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//taghelper,htmlhelper
        public IActionResult SaveNew(Course course) {
           if(ModelState.IsValid)
            {
                crsRepo.Insert(course);
                return RedirectToAction("Index");
            }
           
            return View("New", course);
        }
        public IActionResult Edit(int id) {

            var course = crsRepo.GetById(id);
            return View(course);
        }
        public IActionResult SaveEdit(int id,Course newCourse) {
            Course oldCourse = crsRepo.GetById(id);
            if (oldCourse.Name!=null)
            {
                crsRepo.Update(newCourse);
                return RedirectToAction("Index");
            }
            return View("Edit", oldCourse);
        }
        public IActionResult CheckMinDegree(int minDegree,int Degree)
        {
            if(minDegree<Degree)
            {
                return Json(true);
            }
            return Json(false);
        }

    }
}
