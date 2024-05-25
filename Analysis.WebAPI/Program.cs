using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Analysis.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AnalysisDbContext>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("AnalysisManagement")));


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

            builder.Services.AddAuthorization();

            builder.Services.AddIdentityApiEndpoints<AppUser>(options =>
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
                //options.SignIn.RequireConfirmedAccount = false;
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<AnalysisDbContext>();

            builder.Services.AddOptions<BearerTokenOptions>(IdentityConstants.BearerScheme).Configure(options =>
            {
                options.BearerTokenExpiration = TimeSpan.FromSeconds(60);
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapIdentityApi<AppUser>();


            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
