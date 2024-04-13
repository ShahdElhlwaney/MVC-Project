using FirstProject.Models;
using FirstProject.Repository;
using FirstProject.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FirstProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddDbContext<ITIEntity>
                (optionBuilder =>
                {
                    optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                    optionBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(Options =>
            {
                Options.Password.RequireUppercase = false;
                Options.Password.RequireDigit = false;

            }

            ).AddEntityFrameworkStores<ITIEntity>();
        


            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<ICourseRepository,CourseRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<ITraineeRepository,TraineeRepository>();
            builder.Services.AddScoped<ITraineeService, TraineeService>();

            builder.Services.AddScoped<IRoleRepository, RoleRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // built in middlewares (components)
            /// Custom middlewares

          /*  app.Use(async(http, next) => 
            {
                await http.Response.WriteAsync("1)middleware 1");
                next.Invoke();
            });
            app.Use(async (http, next) =>
            {
                // write response
                await http.Response.WriteAsync("2)middleware 2");
                // call next middleware
                next.Invoke();
            });
            // Terminate
            app.Run(async(http) => 
            {
               await http.Response.WriteAsync("3)middleware 3");
            });*/

             if (!app.Environment.IsDevelopment())
             {
                 app.UseExceptionHandler("/Home/Error");
                 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                 app.UseHsts();
             }

             app.UseHttpsRedirection();
             app.UseStaticFiles();

             app.UseRouting(); /// catch the request 
                               /// and use MapControllerRoute to map the url to "ControllerName/ActionName"
                               /// and pass these information to UseAuthorization to check the Authorization
            app.UseAuthentication();
             app.UseAuthorization();
            app.UseSession();

             app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}