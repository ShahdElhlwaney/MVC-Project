using FirstProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorRepository instructorRepo;
        public InstructorController(IInstructorRepository instructorRepo)
        {
            this.instructorRepo=instructorRepo;
        }
       
        public IActionResult Index()
        {

            return View(instructorRepo.GetAll());
        }
        public IActionResult Details(int id)
        {

            return View(instructorRepo.GetById(id));// ViewName="Index", Model=deptListModel
        }
    }
}
