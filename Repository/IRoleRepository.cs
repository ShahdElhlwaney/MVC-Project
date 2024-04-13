using Microsoft.AspNetCore.Identity;

namespace FirstProject.Repository
{
    public interface IRoleRepository
    {
        public List<IdentityRole> GetRoles();
    }
}
