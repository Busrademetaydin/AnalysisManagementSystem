
using Analysis.Business.Abstract;
using Analysis.Business.Concrete;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.AutoMapperProfile;
using AnalysisManagement.WebMVC.Extensions;
using AnalysisManagement.WebMVC.Models;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Net;
using System.Net.Mail;

namespace AnalysisManagement.WebMVC
{
    public class Program
    {
        public static async Task Main(string[] args)
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
                builder.Services.AddScoped<IAnalyzeTypeManager, AnalyzeTypeManager>();

                builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

                builder.Services.AddTransient<IEmailSender, EmailSender>(serviceProvider =>
                {
                    var smtpSettings = serviceProvider.GetRequiredService<IOptions<SmtpSettings>>().Value;
                    var smtpClient = new SmtpClient(smtpSettings.Server, smtpSettings.Port)
                    {
                        Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password),
                        EnableSsl = true
                    };

                    return new EmailSender(smtpClient, smtpSettings.SenderEmail);
                });

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
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                    options.Lockout.MaxFailedAccessAttempts = 5;

                }).AddEntityFrameworkStores<AnalysisDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

                builder.Services.AddCookieAyarlar();

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
                      name: "Admin",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });

                using (var scope = app.Services.CreateScope())
                {
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    var roles = new[] { "Admin", "User" };
                    foreach (var role in roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                            await roleManager.CreateAsync(new IdentityRole(role));
                    }

                }


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
