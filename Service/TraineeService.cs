using FirstProject.Models;
using FirstProject.Repository;
using FirstProject.ViewModel;

namespace FirstProject.Service
{
    public class TraineeService : ITraineeService
    {
        ITraineeRepository traineeRepo;
        public TraineeService(ITraineeRepository traineeRepo)
        {
            this.traineeRepo = traineeRepo;
        }

        public TraineeViewModel Details(int id)
        {
            TraineeViewModel traineeView = new TraineeViewModel();

            var TraineeResult = traineeRepo.GetCrsResultWithTrainee(id);

           Trainee trainee = traineeRepo.GetByIdWithCrsResults(id);
            traineeView.Id = trainee.Id;
            traineeView.Name = trainee.Name;
            traineeView.Degree =
               TraineeResult.Degree;
            traineeView.CourseName = TraineeResult.Course.Name;
            traineeView.Color = traineeView.Degree >= 60 ? "green" : "red";
            return traineeView;
        }

        public TraineeResultsViewModel GetTraineeCrsResults(int id)
        {
            TraineeResultsViewModel traineeResultsViewModel = new TraineeResultsViewModel();
            Trainee trainee = traineeRepo.GetTraineeCrsResults(id);
            traineeResultsViewModel.Id = trainee.Id;
            traineeResultsViewModel.Name = trainee.Name;
            traineeResultsViewModel.Results = traineeRepo.GetCrsResults();
            return traineeResultsViewModel;
        }

        public List<Trainee> GetTrainees()
        {
            return traineeRepo.GetAll();
        }
    }
}
