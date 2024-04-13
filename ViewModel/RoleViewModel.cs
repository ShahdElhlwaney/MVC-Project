using System.ComponentModel.DataAnnotations;

namespace FirstProject.ViewModel
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }    
    }
}
