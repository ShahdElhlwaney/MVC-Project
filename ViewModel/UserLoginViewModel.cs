using System.ComponentModel.DataAnnotations;

namespace FirstProject.ViewModel
{
    public class UserLoginViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
        public bool RememberMe { get; set;}
    }
}
