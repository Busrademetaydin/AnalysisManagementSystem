using Analysis.Entities.Concrete;
using Analysis.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analysis.Entities.EntityConfig.Concrete
{
    public class DrugConfig : BaseConfig<Drug, int>
    {
        public override void Configure(EntityTypeBuilder<Drug> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.ProductCode).IsRequired().HasMaxLength(5);
            builder.Property(p => p.BatchNo).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.MFGDate).HasDefaultValueSql("GetDate()");
            builder.Property(p => p.EXPDate).HasDefaultValueSql("GetDate()");
            builder.Property(p => p.DosageForm).IsRequired().HasMaxLength(15);
            builder.Property(p => p.StorageCondition).IsRequired().HasMaxLength(20);

        }
    }
}
