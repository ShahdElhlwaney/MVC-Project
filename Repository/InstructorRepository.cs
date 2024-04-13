using FirstProject.Models;

namespace FirstProject.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        ITIEntity context;
        public InstructorRepository(ITIEntity context)
        {
            this.context=context;
        }
        public List<Instructor> GetAll()
        {
            return context.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return context.Instructors.FirstOrDefault(i => i.Id == id);
        }
    }
}
