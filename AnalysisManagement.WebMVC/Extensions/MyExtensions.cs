using Microsoft.AspNetCore.Authentication.Cookies;

namespace AnalysisManagement.WebMVC.Extensions
{
    public static class MyExtensions
    {

        public static IServiceCollection AddCookieAyarlar(this IServiceCollection services)
        {


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "AnalysisCookie";
                options.LoginPath = "/Login/Index";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.HttpOnly = true; //Tarayicidaki diger scriptler okuyamasin
                options.Cookie.SameSite = SameSiteMode.Strict; // Bizim tarayicimiz disinda kullanilamasin

                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.SlidingExpiration = true;


            });
            return services;
        }
    }
}