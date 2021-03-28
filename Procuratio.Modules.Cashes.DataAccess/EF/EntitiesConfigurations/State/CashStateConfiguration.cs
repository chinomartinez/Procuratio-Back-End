using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Cashes.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Cashes.DataAccess.EF.EntitiesConfigurations.State
{
    public class CashStateConfiguration : IEntityTypeConfiguration<CashState>
    {
        public void Configure(EntityTypeBuilder<CashState> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30);
        }
    }
}
