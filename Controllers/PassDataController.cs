using FirstProject.Models;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class PassDataController : Controller
    {
        ITIEntity context;
        public PassDataController(ITIEntity context)
        {
            this.context=context;
        }
        // PassDataController/TestViewData/1
        public IActionResult TestViewData(int id)
        {
            Employee emp = context.Employees.FirstOrDefault(P => P.Id == id);
            List<string> branches= new List<string>();
            branches.Add("Menia");
            branches.Add("Sohag");
            branches.Add("Smart");
            branches.Add("Assuit");
            int Temp =22;
            ViewData["brnch"] = branches;
            ViewData["temp"] = Temp;
            return View(emp);
        }
           // ViewModel: customize class Dta need to send to View
          // Model send extra info
         // Merge between 2 models
        // filter property
        public IActionResult TestViewModel(int id) 
        {
            Employee EmpModel = context.Employees.FirstOrDefault(e => e.Id == id);
            List<string> branches = new List<string>();
            branches.Add("Menia");
            branches.Add("Sohag");
            branches.Add("Smart");
            branches.Add("Assuit");
            int Temp = 22;
            EmployeeWithMessageAndBranchListViewModel EmpViewModel=
                new EmployeeWithMessageAndBranchListViewModel();
            EmpViewModel.branches=branches;
            EmpViewModel.Temp = Temp;
            EmpViewModel.Salary = EmpModel.Salary;
            EmpViewModel.EmpName = EmpModel.Name;
            return View(EmpViewModel);
        }
    }
}
