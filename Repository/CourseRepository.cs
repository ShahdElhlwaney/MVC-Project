using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ITIEntity context;
        public CourseRepository(ITIEntity context)
        {
            this.context=context;
        }
        public void Delete(int id)
        {
            Course course = GetById(id);
            context.Course.Remove(course);
            context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return context.Course.Include(c => c.Department)
                .Include(c=>c.CrsResults).ToList();
        }

        public Course GetById(int id)
        {
            return context.Course.Include(c => c.Department).FirstOrDefault(c => c.Id == id);
        }


        public void Insert(Course course)
        {
            context.Course.Add(course);
            context.SaveChanges();
        }

        public void Update(Course newCrs)
        {
            context.Course.Update(newCrs);
            context.SaveChanges();
        }

     
    }
}
