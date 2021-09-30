using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.BranchId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(200).IsRequired(false);

            builder.Property(x => x.Code).HasMaxLength(10).IsRequired();

            builder.Property(x => x.Image).HasMaxLength(200).IsRequired(false);

            builder.Property(x => x.PriceInsideRestaurant).HasPrecision(19, 4);

            builder.Property(x => x.PriceOutsideRestaurant).HasPrecision(19, 4);

            builder.HasIndex(x => new { x.BranchId, x.Order, x.SubCategoryItemId }).IsUnique();
        }
    }
}
