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
    internal class ItemAttributeXItemConfiguration : IEntityTypeConfiguration<ItemAttributeXItem>
    {
        public void Configure(EntityTypeBuilder<ItemAttributeXItem> builder)
        {
            builder.HasKey(x => new { x.ItemAttributeID, x.ItemID });

            builder.Property(x => x.PriceInsideRestaurant).HasPrecision(19, 4);

            builder.Property(x => x.PriceOutsideRestaurant).HasPrecision(19, 4);
        }
    }
}
