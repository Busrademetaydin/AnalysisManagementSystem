using Analysis.Entities.Concrete;
using Analysis.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analysis.Entities.EntityConfig.Concrete
{
    public class AnalystConfig : BaseConfig<Analyst, int>
    {
        public override void Configure(EntityTypeBuilder<Analyst> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
            builder.Property(p => p.IdentificationNumber).HasMaxLength(11);
            builder.HasIndex(p => p.IdentificationNumber).IsUnique();
            builder.Property(p => p.Title).HasMaxLength(50);
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.Phone).HasMaxLength(20);
            builder.HasIndex(p => p.Phone).IsUnique();
        }

    }
}
