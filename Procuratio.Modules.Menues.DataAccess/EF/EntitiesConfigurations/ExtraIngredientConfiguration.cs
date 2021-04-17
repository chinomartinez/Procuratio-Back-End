﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    public class ExtraIngredientConfiguration : IEntityTypeConfiguration<ExtraIngredient>
    {
        public void Configure(EntityTypeBuilder<ExtraIngredient> builder)
        {
            builder.Property(x => x.ExtraIngredientName).HasMaxLength(70).IsRequired();

            builder.Property(x => x.MenuPrice).HasPrecision(18, 4);

            builder.Property(x => x.DinerInPrice).HasPrecision(18, 4);

            builder.Property(x => x.TakeAwayPrice).HasPrecision(18, 4);

            builder.Property(x => x.DeliveryPrice).HasPrecision(18, 4);

            builder.Property(x => x.PromotionPrice).HasPrecision(18, 4);
        }
    }
}
