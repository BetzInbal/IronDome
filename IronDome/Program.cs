using IronDome.Data;
using IronDome.Dto;
using IronDome.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IronDome
{
    public class Program
    { 
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddSingleton<LaunchDto>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IThreatManagementService, ThreatManagementService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
        }
    }
}
