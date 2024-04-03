using Analysis.Entities.Concrete;
using Analysis.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analysis.Entities.EntityConfig.Concrete
{
    public class AnalyzeTypeConfig : BaseConfig<AnalyzeType, int>
    {
        public override void Configure(EntityTypeBuilder<AnalyzeType> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Active).IsRequired();


        }
    }
}
