using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    public class ExtraIngredientConfiguration : IEntityTypeConfiguration<ExtraIngredient>
    {
        public void Configure(EntityTypeBuilder<ExtraIngredient> builder)
        {
            builder.Property(x => x.ExtraIngredientName).HasMaxLength(70).IsRequired();

            builder.Property(x => x.PriceInsideRestaurant).HasPrecision(18, 2);

            builder.Property(x => x.PriceOutsideRestaurant).HasPrecision(18, 2);

            builder.Property(x => x.PromotionPriceInsideRestaurant).HasPrecision(18, 2);

            builder.Property(x => x.PromotionPriceOutsideRestaurant).HasPrecision(18, 2);
        }
    }
}
