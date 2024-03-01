using Analysis.Entities.Concrete;
using Analysis.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analysis.Entities.EntityConfig.Concrete
{
    public class AnalyzeConfig : BaseConfig<Analyze, int>
    {
        public override void Configure(EntityTypeBuilder<Analyze> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.AnalyzeName).IsRequired().HasMaxLength(20);
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();

        }
    }
}
