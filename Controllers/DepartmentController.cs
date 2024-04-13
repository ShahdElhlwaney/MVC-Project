using FirstProject.Models;
using FirstProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{
	public class DepartmentController : Controller
	{
		IDepartmentRepository deptRepo; 
		IEmployeeRepository empRepo; 
        public DepartmentController(IDepartmentRepository deptRepo, IEmployeeRepository empRepo)
        {
			this.deptRepo = deptRepo;
			this.empRepo=empRepo;
        }
        [HttpGet]
		public IActionResult Index()
		{
			List<Department> deptList = deptRepo.GetAll();			
			return View(deptList);// ViewName="Index", Model=deptListModel
		}
		[HttpGet]
       public IActionResult New()
		{
			return View(new Department { });
		}
		[HttpPost]
        public IActionResult SaveNew(Department dept)
        {
			if(dept.Name!=null)
			{
				deptRepo.Insert(dept);
				return RedirectToAction("Index");
			}
			return View("New",dept);
        }
        // Department/GetDepartmentEmployee
        public IActionResult GetDepartmentEmployee() 
		{
			List<Department> deptList = deptRepo.GetAll();
			return View(deptList);
		}
        // Department/GetEmployeesPerDepartment?deptId=2
        public IActionResult GetEmployeesPerDepartment(int deptId)
		{
			List<Employee> emps = empRepo.GetByDeptId(deptId);
			return Json(emps);
		}
    }
}
