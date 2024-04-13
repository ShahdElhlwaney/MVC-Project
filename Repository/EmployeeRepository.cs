using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ITIEntity context; 
        public EmployeeRepository(ITIEntity context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
           Employee emp= GetById(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Insert(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }
        public List<Employee> GetByDeptId(int deptId)
        {
           return context.Employees.Include(e => e.Department)
                .Where(e => e.Dept_Id == deptId).ToList();

        }
        public void Update( Employee newEmp)
        {
            context.Employees.Update(newEmp);
            context.SaveChanges();
        }
    }
}
