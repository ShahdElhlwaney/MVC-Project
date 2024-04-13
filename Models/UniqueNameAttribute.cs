using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models
{
    public class UniqueNameAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            string name = value.ToString();
            ITIEntity _context = new ITIEntity();
            Employee emp=_context.Employees.FirstOrDefault(e=>e.Name== name);
            if(emp==null) {
                return ValidationResult.Success;
            }

            return new ValidationResult("Name already found");
        }
    }
}
