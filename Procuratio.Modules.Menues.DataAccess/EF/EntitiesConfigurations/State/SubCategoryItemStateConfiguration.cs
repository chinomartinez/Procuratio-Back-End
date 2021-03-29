using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations.State
{
    public class SubCategoryItemStateConfiguration : IEntityTypeConfiguration<SubCategoryItemState>
    {
        public void Configure(EntityTypeBuilder<SubCategoryItemState> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        }
    }
}
