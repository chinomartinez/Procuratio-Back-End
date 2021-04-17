using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Cashes.Domain.Entities;

namespace Procuratio.Modules.Cashes.DataAccess.EF.EntitiesConfigurations
{
    public class MountTypeConfiguration : IEntityTypeConfiguration<MountType>
    {
        public void Configure(EntityTypeBuilder<MountType> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        }
    }
}
