using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models
{
    public class UniqueCourseNameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            
            
            Course CourseInstance = (Course) validationContext.ObjectInstance;
            ITIEntity _context =new ITIEntity();
            var name = value.ToString();
            Course course = _context.Course.Include(c=>c.Department)
                .FirstOrDefault
                (c => c.Name == name && c.Dept_Id == CourseInstance.Dept_Id);
            if(course==null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Course Already Found");
        }
    }
}
