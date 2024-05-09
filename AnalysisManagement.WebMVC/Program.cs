
using Analysis.Business.Abstract;
using Analysis.Business.Concrete;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.AutoMapperProfile;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AnalysisManagement.WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .WriteTo.Seq(@"http://localhost:5341")
                            .CreateLogger();
            try
            {

                Log.Information("The system has started working.");

                Log.Error("An error has occurred.");

                var builder = WebApplication.CreateBuilder(args);


                builder.Services.AddControllersWithViews();
                builder.Services.AddDbContext<AnalysisDbContext>(options => options.UseSqlServer
                (builder.Configuration.GetConnectionString("AnalysisManagement")));

                builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

                builder.Services.AddScoped<IHPLCEquipmentManager, HPLCEquipmentManager>();
                builder.Services.AddScoped<IDrugManager, DrugManager>();
                builder.Services.AddScoped<IAnalysisManager, AnalysisManager>();
                builder.Services.AddScoped<IAnalystManager, AnalystManager>();
                builder.Services.AddScoped<IAnalyzeDetailManager, AnalyzeDetailManager>();

                builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;

                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                    options.Lockout.MaxFailedAccessAttempts = 5;

                }).AddEntityFrameworkStores<AnalysisDbContext>();

                builder.Services.AddNotyf(config =>
                {
                    config.DurationInSeconds = 10;
                    config.IsDismissable = true;
                    config.Position = NotyfPosition.BottomRight;
                });

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

                app.UseAuthentication();
                app.UseAuthorization();
                app.UseNotyf();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Login}/{action=Index}/{id?}");
                });


                app.Run();

            }
            catch (Exception ex)
            {

                Log.Fatal(ex, "The system has unexpectedly stopped working!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
