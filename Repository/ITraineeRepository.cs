using FirstProject.Models;
using FirstProject.ViewModel;

namespace FirstProject.Repository
{
    public interface ITraineeRepository
    {
        Trainee GetTraineeCrsResults(int id);
        Trainee GetByIdWithCrsResults(int id);
        List<CrsResult> GetCrsResults();
        CrsResult GetCrsResultWithTrainee(int id);
        List<Trainee> GetAll();
    }
}
