using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    public class ItemSizeXItemConfiguration : IEntityTypeConfiguration<ItemSizeXItem>
    {
        public void Configure(EntityTypeBuilder<ItemSizeXItem> builder)
        {
            builder.HasKey(x => new { x.ItemSizeID, x.ItemID });

            builder.Property(x => x.PriceInsideRestaurant).HasPrecision(18, 2);

            builder.Property(x => x.PriceOutsideRestaurant).HasPrecision(18, 2);

            builder.Property(x => x.PromotionPriceInsideRestaurant).HasPrecision(18, 2);

            builder.Property(x => x.PromotionPriceOutsideRestaurant).HasPrecision(18, 2);
        }
    }
}
