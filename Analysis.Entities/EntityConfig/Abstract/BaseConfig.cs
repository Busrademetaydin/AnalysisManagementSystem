using Analysis.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analysis.Entities.EntityConfig.Abstract
{
    public abstract class BaseConfig<T, TId> : IEntityTypeConfiguration<T> where T : BaseEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CreateDate).HasDefaultValueSql("GetDate()");
            builder.Property(p => p.UpdateDate).HasDefaultValueSql("GetDate()");

        }

    }
}
