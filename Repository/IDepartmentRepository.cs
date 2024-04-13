using FirstProject.Models;

namespace FirstProject.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department employee);
        void Update(Department employee);
        void Delete(int id);
    }
}
