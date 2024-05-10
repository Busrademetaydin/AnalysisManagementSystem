using Analysis.Business.Abstract;
using Analysis.Business.Concrete;
using Analysis.Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
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

            builder.Services.AddScoped<IDrugManager, DrugManager>();

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:5143/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var result = client.GetAsync("api/Drug").Result;

            //if (result.IsSuccessStatusCode)
            //{
            //    var content = result.Content.ReadAsStringAsync();
            //}

            //Console.WriteLine("Hello");


            // Add services to the container.
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //                .AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        //burada yazdıgımız kodlar token validation için yani jwt nin dogru
            //        //olup olmadıgının anlasılması ıcın kullanılmasını istedigimiz ayarlar.

            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = builder.Configuration["Jwt: Issuer"],
            //        ValidAudience = builder.Configuration["Jwt: Audience"],
            //        //ValidIssuer = "https://localhost:7003",
            //        //ValidAudience = "https://localhost:7003",
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt: Key"] ?? string.Empty))
            //    };


            //});

            //ValidAudiences =

            //builder.Services.AddControllers();

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
