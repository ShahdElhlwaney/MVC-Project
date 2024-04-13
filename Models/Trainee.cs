using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProject.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public string Address { get; set; }
        public int Grade { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public virtual List<CrsResult>? CrsResults { get; set; }
        public virtual Department? Department { get; set; }

    }
}
