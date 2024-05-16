using Analysis.Business.Abstract;
using Analysis.Business.Concrete;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;


namespace Analysis.WebAPI
{
    public class Program2
    {
        public static void Main2(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AnalysisDbContext>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("AnalysisManagement")));

            builder.Services.AddScoped<IDrugManager, DrugManager>();
            //builder.Services.AddScoped<IHPLCEquipmentManager,HPLCEquipmentManager();

            //void ConfigureServices(IServiceCollection services)
            //{
            //    // ASP.NET Core Identity hizmetlerini ekleyin
            //    services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //    {
            //        // Gerekli yapılandırmaları burada yapabilirsiniz
            //    })
            //    .AddEntityFrameworkStores<AnalysisDbContext>() // Identity verilerini saklamak için Entity Framework kullanın
            //    .AddDefaultTokenProviders(); // Parola sıfırlama ve e-posta doğrulama gibi token sağlayıcıları ekleyin

            //    // Diğer hizmetlerinizi burada ekleyin
            //}




            HttpClient client = new HttpClient();

            string baseAddress = "https://localhost:7144/";
            //UserLogin login = new UserLogin() { Email = "", Password = "" };
            //var jsonstr = System.Text.Json.JsonSerializer.Serialize(login);
            //StringContent content = new StringContent(jsonstr, Encoding.UTF8, "application/json");




            try
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var loginData = new { email, password };

                //HttpResponseMessage response = await client.PostAsJsonAsync("api/Login/Login", loginData);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
            }
            finally
            {
                // HttpClient kullanımdan kaldırılmalıdır.
                // Bu nedenle, işiniz bittiğinde HttpClient'i dispose edin.
                client.Dispose();
            }




            //client.BaseAddress = new Uri("http://localhost:7144/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var result = client.GetAsync("api/Drug").Result;

            //if (result.IsSuccessStatusCode)
            //{
            //    var content = result.Content.ReadAsStringAsync();
            //}

            //Console.WriteLine("Hello");


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


            //builder.Services.AddControllers();

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
                                                                      builder.AllowAnyHeader()
                                                                      .AllowAnyMethod()
                                                                      .AllowAnyOrigin()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
            builder.Services.AddSwaggerGen();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,// token üzerinde Audience doðrulamasýný aktifleþtirdik.
                    ValidateIssuer = true,//token üzerinde Issuer doðrulamasýný aktifleþtirdik.
                    ValidateLifetime = true,// token deðerinin kullaným süresi doðrulamasýný aktifleþtirdik.
                    ValidateIssuerSigningKey = true,//token deðerinin bu uygulamaya ait olup olmadýðýný anlamamýzý saðlayan Security Key doðrulamasýný aktifleþtirdik.
                    ValidIssuer = "https://localhost:7144",//uygulamadaki tokenýn Issuer deðerini belirledik.
                    ValidAudience = "https://localhost:7144",//uygulamadaki tokenýn Audience deðerini belirledik.
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Benim Super Sifrem Benim Super Sifrem Benim Super Sifrem")),// Security Key doðrulamasý için SymmetricSecurityKey nesnesi aracýlýðýyla mevcut keyi belirtiyoruz.
                    ClockSkew = TimeSpan.Zero //TimeSpan.Zero deðeri ile token süresinin üzerine ekstra bir zaman eklemeksizin sýfýr deðerini belirtiyoruz.

                });

            //Youtubeden izlediğim video
            builder.Services.AddAuthorization();
            //Youtubeden izlediğim video
            builder.Services.AddIdentityApiEndpoints<AppUser>()
                .AddEntityFrameworkStores<AnalysisDbContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapIdentityApi<IdentityUser>();


            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
