using FirstProject.Models;

namespace FirstProject.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        List<Employee> GetByDeptId(int deptId);
        Employee GetById(int id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
