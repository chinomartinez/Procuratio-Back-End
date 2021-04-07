using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.Property(x => x.PromotionName).HasMaxLength(70).IsRequired();

            builder.Property(x => x.MenuPrice).HasPrecision(18, 4);

            builder.Property(x => x.DinerInPrice).HasPrecision(18, 4);

            builder.Property(x => x.TakeAwayPrice).HasPrecision(18, 4);

            builder.Property(x => x.DeliveryPrice).HasPrecision(18, 4);
        }
    }
}
