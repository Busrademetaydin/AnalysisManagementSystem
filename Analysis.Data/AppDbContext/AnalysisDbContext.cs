using Analysis.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Analysis.Data.AppDbContext
{
    public class AnalysisDbContext : DbContext
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



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=AnalysisManagement;Trusted_Connection=true;Trust server Certificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Analysis.Entities"));

        }
    }
}