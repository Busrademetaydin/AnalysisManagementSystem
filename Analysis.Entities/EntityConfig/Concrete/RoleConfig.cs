using Analysis.Entities.Concrete;
using Analysis.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analysis.Entities.EntityConfig.Concrete
{
    public class RoleConfig : BaseConfig<Role, int>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {

            base.Configure(builder);
            builder.Property(p => p.RoleName).HasMaxLength(50);
            builder.HasIndex(p => p.RoleName).IsUnique();
            builder.HasData(new Role { Id = 1, RoleName = "Analyst" },
                new Role { Id = 2, RoleName = "Supervisor" },
                new Role { Id = 3, RoleName = "Director" }
                );

        }
    }
}
