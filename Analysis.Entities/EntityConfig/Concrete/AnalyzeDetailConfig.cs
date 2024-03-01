using Analysis.Entities.Concrete;
using Analysis.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analysis.Entities.EntityConfig.Concrete
{
    public class AnalyzeDetailConfig : BaseConfig<AnalyzeDetail, int>
    {
        public override void Configure(EntityTypeBuilder<AnalyzeDetail> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Limit).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Comments).IsRequired();
            builder.Property(p => p.Result).IsRequired();
        }
    }
}
