using Aviation.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Aviation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //IOC DataBase
            builder.Services.AddScoped<IDbConnection>((s) =>
            {
                IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
                conn.Open();
                return conn;
            });
            //IOC Data End

            builder.Services.AddTransient<IFalconRepository, FalconRepository>();  //Constructor Injection 


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            //API 

            var client = new HttpClient();
        }
    }
}
