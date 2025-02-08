using Lab1_MVC.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab1_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CompanyContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnect"))
            ;
            });
            builder.Services.AddSession();

            var app = builder.Build();

            #region Custome Mw
            /*app.Use(async (mycontext,next) =>
            {
                await mycontext.Response.WriteAsync("first_in_response\n"); 
                next();
            });
            app.Run(async (x) =>
            {
                await x.Response.WriteAsync("terminate_request\n");
            });*/
            #endregion
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}