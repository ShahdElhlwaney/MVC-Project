using FirstProject.Models;

namespace FirstProject.ViewModel
{
    public class TraineeResultsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public List<CrsResult> Results { get; set; }
    }
}
