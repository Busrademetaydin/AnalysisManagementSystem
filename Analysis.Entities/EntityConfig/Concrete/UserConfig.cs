using Analysis.Entities.Concrete;
using Analysis.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analysis.Entities.EntityConfig.Concrete
{
    public class UserConfig : BaseConfig<User, int>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {

            base.Configure(builder);
            builder.Property(p => p.UserName).HasMaxLength(50);
            builder.Property(p => p.Password).HasMaxLength(15);
            builder.HasIndex(p => p.UserName).IsUnique();

            //builder.HasData(new User { Id = 1, UserName = "Analyst", Password = "123456**" });
        }
    }
}
