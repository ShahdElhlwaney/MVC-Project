using FirstProject.Models;
using FirstProject.Repository;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository empRepo; 
        IDepartmentRepository deptRepo; 
        public EmployeeController(IEmployeeRepository empRepo,  IDepartmentRepository deptRepo)
        {
            this.empRepo=empRepo;
            this.deptRepo = deptRepo;
            
        }
        public IActionResult Index()
        {
            return View(empRepo.GetAll());
        }

        public IActionResult Edit(int id)
        {

            ViewData["deptList"] = deptRepo.GetAll();
                return View(empRepo.GetById(id));
            
        }

        public IActionResult NEw()
        {
            ViewData["DeptNameList"] = deptRepo.GetAll();
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]//taghelper,htmlhelper
        public IActionResult SaveNew(Employee newEmployee)
        {
            if(newEmployee.Name!=null)
            {
                empRepo.Insert(newEmployee);
               return RedirectToAction("Index");
            }
            ViewData["DeptNameList"] = deptRepo.GetAll();
            return View("NEw", newEmployee);

        }
        public IActionResult SaveEdit(int id, Employee newEmployee) 
        {

            Employee oldEmp = empRepo.GetById(id);
            if (oldEmp.Name != null)
            {
                empRepo.Update(newEmployee);
                return RedirectToAction("Index");
            }
            ViewData["deptList"] = deptRepo.GetAll();
            return View("Edit", newEmployee);
        }
        public IActionResult CheckSalary(int Salary)
        {
            if(Salary>2000)
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Details(int id)
        {
            Employee emp = empRepo.GetById(id);
            return PartialView("_DetailsPartial",emp);
        }

    }
}
