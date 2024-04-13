using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace FirstProject.Models
{
	public class ITIEntity:IdentityDbContext<ApplicationUser>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		     base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public ITIEntity():base()
		{

		}
		public ITIEntity(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Trainee> Trainee { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }

        public DbSet<Course> Course { get; set; }

		public DbSet<ApplicationUser> applicationUsers { get; set; } = default!;
        public DbSet<IdentityRole> identityRoles { get; set; } = default!;




    }
}
