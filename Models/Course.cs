using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProject.Models
{
    
    public class Course
    {
        public int Id { get; set; }
        [Required]
       //[UniqueCourseName]
        public string Name { get; set; }
        [Range(50,100)]
        [Remote("CheckMinDegree", "Course", AdditionalFields = "minDegree")]
        public int Degree { get; set; }
        [Remote("CheckMinDegree","Course",AdditionalFields ="Degree")]
        public int minDegree { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
        public virtual List<CrsResult>?CrsResults { get; set; }
        public virtual Department? Department { get; set; }
    }
}
