using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.ItemName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();

            builder.Property(x => x.Image).HasMaxLength(200);
        }
    }
}
