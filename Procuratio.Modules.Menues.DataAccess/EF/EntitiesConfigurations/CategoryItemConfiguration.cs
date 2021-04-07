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
    public class CategoryItemConfiguration : IEntityTypeConfiguration<CategoryItem>
    {
        public void Configure(EntityTypeBuilder<CategoryItem> builder)
        {
            builder.Property(x => x.CategoryItemName).HasMaxLength(70).IsRequired();
        }
    }
}
