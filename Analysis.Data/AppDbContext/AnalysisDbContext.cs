using Analysis.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Analysis.Data.AppDbContext
{
    public class AnalysisDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AnalysisDbContext()
        {

        }
        public AnalysisDbContext(DbContextOptions<AnalysisDbContext> options) : base(options)
        {

        }

        public DbSet<Analyst> Analysts { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<HPLCEquipment> HPLCEquipments { get; set; }
        public DbSet<Analyze> Analyzes { get; set; }

        public DbSet<AnalyzeDetail> AnalyzeDetails { get; set; }

        public DbSet<AnalyzeType> AnalyzeTypes { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=AnalysisManagement;Trusted_Connection=true;Trust server Certificate=true;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Analysis.Entities"));
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Analysis.Entities"));

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(p => p.UserId);
            });
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Analyst", ConcurrencyStamp = "1", NormalizedName = "Analyst" },
                new IdentityRole() { Name = "Supervisor", ConcurrencyStamp = "2", NormalizedName = "Supervisor" },
                new IdentityRole() { Name = "Manager", ConcurrencyStamp = "3", NormalizedName = "Manager" }

                );
        }
    }
}