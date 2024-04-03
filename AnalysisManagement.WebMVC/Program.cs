
using Analysis.Business.Abstract;
using Analysis.Business.Concrete;
using Analysis.Data.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace AnalysisManagement.WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AnalysisDbContext>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("AnalysisManagement")));

            builder.Services.AddScoped<IHPLCEquipmentManager, HPLCEquipmentManager>();
            builder.Services.AddScoped<IDrugManager, DrugManager>();
            builder.Services.AddScoped<IAnalysisManager, AnalysisManager>();
            builder.Services.AddScoped<IAnalystManager, AnalystManager>();
            builder.Services.AddScoped<IAnalyzeDetailManager, AnalyzeDetailManager>();


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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Analysis}/{action=Index}/{id?}");
            });


            app.Run();
        }
    }
}
