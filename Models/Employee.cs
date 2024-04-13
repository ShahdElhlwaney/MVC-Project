using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProject.Models
{
	public class Employee
	{
		/// ETIEntity
		public int Id { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(20)]
		public string Name { get; set; }
		[Required]
		[Range(2000,6000)]
		[RegularExpression(@"[0-9]{4}")]
		[Remote("CheckSalary","Employee")]
		public int Salary { get; set; }
		[RegularExpression("Assuit|Tanta|Cairo")]
        [Required]
        public string Address { get; set; }
		[RegularExpression(@"[a-z]+\.(png|jpg)")]
		public string Image { get; set; }

		[ForeignKey("Department")]
		public int Dept_Id { get; set; }
		public virtual Department? Department { get; set; }
	}
}
