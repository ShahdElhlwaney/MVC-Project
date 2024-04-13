
using FirstProject.Models;
using FirstProject.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        ITIEntity context;
        public TraineeRepository(ITIEntity context)
        {
            this.context=context;

        }
        public Trainee GetTraineeCrsResults(int id)
        {
            Trainee trainee = context.Trainee.Include(e => e.CrsResults)
                .Include(e => e.Department).FirstOrDefault(t => t.Id == id);
     
            return trainee;
        }

        public Trainee GetByIdWithCrsResults(int id)
        {
            
            return context.Trainee.Include(e => e.CrsResults)
                .Include(e => e.Department).FirstOrDefault(t => t.Id == id);
        }
       

       

        List<CrsResult> ITraineeRepository.GetCrsResults()
        {
           
            return context.CrsResult.Include(t => t.Course).ToList();
        }

        public CrsResult GetCrsResultWithTrainee(int id)
        {
            return context.CrsResult.Include(t => t.Course)
                .Include(t => t.Trainee)
               .FirstOrDefault(t => t.Trainee_Id == id);
        }

        public List<Trainee> GetAll()
        {
            return context.Trainee.Include(t=>t.Department).ToList();
        }
    }
}
