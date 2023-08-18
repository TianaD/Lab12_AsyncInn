using Lab12_AsyncInn.Data; // incorporate data namespace to give me access to context name class
using Lab12_AsyncInn.Models.Interfaces;
using Lab12_AsyncInn.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using static System.Net.WebRequestMethods;

namespace Lab12_AsyncInn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddDbContext<Async_Inn_Context>(options =>
            options.UseSqlServer(
                builder.Configuration
                .GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<iHotel, HotelService>();

            builder.Services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "YOUR PROJECT TITLE HERE",
                    Version = "v1",
                });
            });


            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn");
                options.RoutePrefix = "docs";
            });


            // < https://localhost:PORT/api/v1/swagger.json>
            // <http://localhost:PORT/docs> is the actual documentation for your API.

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