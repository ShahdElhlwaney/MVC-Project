using FirstProject.Models;

namespace FirstProject.Repository
{
    public interface IInstructorRepository
    {
        List<Instructor> GetAll();
        Instructor GetById(int id);
    }
}
