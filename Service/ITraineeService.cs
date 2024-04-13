using FirstProject.Models;
using FirstProject.ViewModel;

namespace FirstProject.Service
{
    public interface ITraineeService
    {
        List<Trainee> GetTrainees();

        TraineeResultsViewModel GetTraineeCrsResults(int id);
        TraineeViewModel Details(int id);
    }
}
