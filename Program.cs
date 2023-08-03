using Lab12_AsyncInn.Data; // incorporate data namespace to give me access to context name class
using Microsoft.EntityFrameworkCore;

namespace Lab12_AsyncInn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Async_Inn_Context>(options => 
            options.UseSqlServer(
                builder.Configuration
                .GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //https://localhost:44391/Hotel/CheckIn/1

            app.Run();
        }
    }
}