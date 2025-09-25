namespace MonG1WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. //service
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);
            });

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

            app.UseRouting();
            
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
