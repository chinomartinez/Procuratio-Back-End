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
    internal class ItemAttributeConfiguration : IEntityTypeConfiguration<ItemAttribute>
    {
        public void Configure(EntityTypeBuilder<ItemAttribute> builder)
        {
            builder.Property(x => x.Attribute).HasMaxLength(10).IsRequired();
        }
    }
}
