using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProject.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        [ForeignKey("Course")]
        public int Crs_Id { get; set; }
        public virtual Course Course { get; set; }
        public virtual Department Department { get; set; }

    }
}
