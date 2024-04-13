using FirstProject.Models;

namespace FirstProject.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course course);
        void Update(Course course);
        void Delete(int id);
    }
}
