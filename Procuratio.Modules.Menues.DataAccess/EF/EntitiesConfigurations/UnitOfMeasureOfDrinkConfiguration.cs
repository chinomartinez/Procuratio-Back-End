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
    public class UnitOfMeasureOfDrinkConfiguration : IEntityTypeConfiguration<UnitOfMeasureOfDrink>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasureOfDrink> builder)
        {
            builder.Property(x => x.UnitOfMeasureOfDrinkName).HasMaxLength(5).IsRequired();

            builder.Property(x => x.UnitOfMeasureOfDrinkName);
        }
    }
}
