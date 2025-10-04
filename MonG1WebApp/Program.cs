using Microsoft.EntityFrameworkCore;
using MonG1WebApp.Filters;
using MonG1WebApp.Models;
using MonG1WebApp.Repository;

namespace MonG1WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. //service
            //1) Built in service and alread register Containe
            //2) Built in Service but need to register
            //builder.Services.AddControllersWithViews(
            //    options=>options.Filters.Add(new HandeErrorAttribute())//global filter attribute
            //    ); 
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);
            });
            //register ITIContext, options 
            builder.Services.AddDbContext<ITIContext>(optionsBuilder => { 
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));            
            });

            //3) Custom srevice need to register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IService, Service>();



            var app = builder.Build();//


            // Configure the HTTP request pipeline. (middleware)
            #region Custom Middleware : inline Middelware
            //app.Use(async(httpcontext, next) => {
            //    await httpcontext.Response.WriteAsync("1) Middleware 1\n"); //<--
            //    await next.Invoke();
            //    //----------------------
            //    await httpcontext.Response.WriteAsync("1-1) return back  Middleware 1-1\n"); //<--

            //});

            //app.Use(async (httpcontext, next) => {
            //    await httpcontext.Response.WriteAsync("2) Middleware 2 \n"); //1
            //    await next.Invoke();//2  go 
            //    //----------------------//3
            //    await httpcontext.Response.WriteAsync("2-2) Return Back Middleware 2-2 \n"); //1

            //});
            //app.Run(async(httpcontext) => { 
            //    await httpcontext.Response.WriteAsync("3) Terminate \n"); //<--

            //});//terminate
            #endregion
            #region Built In Pipeline

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//can change folder name

            app.UseRouting();//Security
            
            app.UseSession();

            app.UseAuthorization();


            #region Custom Route
            //naming convention Route

            //app.MapControllerRoute("Route1", "r/{action=Method1}", new { controller = "Route" });
            //app.MapControllerRoute("Route2", "e/{action=index}", new { controller = "Employee" });
            //app.MapControllerRoute("Route2", "{controller=Home}/{action=index}/{id?}");

            //r1=>Route MEthod1
            //Route Constraint
            //app.MapControllerRoute("Rout1", "r1/{age:int:range(20,50)}/{name?}", new { controller = "Route",action="Method1" });
            //r2=>Route MEthod2
            //app.MapControllerRoute("Rout2", "r2", new { controller = "Route", action = "Method2" });

            #endregion

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");//default route "Staff" 
            #endregion
            app.Run();
        }
    }
}
