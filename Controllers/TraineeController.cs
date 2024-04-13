using FirstProject.Repository;
using FirstProject.Service;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class TraineeController : Controller
    {
        ITraineeService traineeService;
     
        public TraineeController(ITraineeService traineeService)
        {
            this.traineeService = traineeService;
        }
        public IActionResult Index()
        {
            return View(traineeService.GetTrainees());
        }
        public IActionResult Details(int id)
        {

            //Trainee/Details/2
            return View(traineeService.Details(id));
        }
        public IActionResult GetTraineeCrsResults(int id)
        {

            //Trainee/index/2
            return View(traineeService.GetTraineeCrsResults(id));
        }
    }   
}
