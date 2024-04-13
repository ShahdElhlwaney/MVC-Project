using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        ITIEntity context;
        public DepartmentRepository(ITIEntity context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            Department dept = GetById(id);
             context.Departments.Remove(dept);
            context.SaveChanges();
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(e => e.Id == id);
        }
    

        public void Insert(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
        }

        public void Update(Department newEmp)
        {
            context.Departments.Update(newEmp);
            context.SaveChanges();
        }
    }
}
