using Microsoft.AspNetCore.Identity;

namespace FirstProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
