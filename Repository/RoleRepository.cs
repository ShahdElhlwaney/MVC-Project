using FirstProject.Models;
using Microsoft.AspNetCore.Identity;

namespace FirstProject.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ITIEntity context;

        public RoleRepository(ITIEntity context)
        {
            this.context = context;
        }
        public List<IdentityRole> GetRoles()
        {
            return context.identityRoles.ToList();
        }
    }
}
