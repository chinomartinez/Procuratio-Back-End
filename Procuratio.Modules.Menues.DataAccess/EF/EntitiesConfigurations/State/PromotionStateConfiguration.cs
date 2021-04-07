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
    public class PromotionStateConfiguration : IEntityTypeConfiguration<PromotionState>
    {
        public void Configure(EntityTypeBuilder<PromotionState> builder)
        {
            builder.Property(x => x.StateName).HasMaxLength(30).IsRequired();
        }
    }
}
