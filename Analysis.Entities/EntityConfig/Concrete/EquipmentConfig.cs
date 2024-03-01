using Analysis.Entities.Concrete;
using Analysis.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analysis.Entities.EntityConfig.Concrete
{
    public class HPLCEquipmentConfig : BaseConfig<HPLCEquipment, int>
    {
        public override void Configure(EntityTypeBuilder<HPLCEquipment> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Brand).IsRequired().HasMaxLength(30);
            builder.Property(p => p.SerialNumber).IsRequired().HasMaxLength(30);
            builder.Property(p => p.CalibrationDueDate).IsRequired();

        }
    }
}
