using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations.State
{
    public class TableStateConfiguration : IEntityTypeConfiguration<TableState>
    {
        public void Configure(EntityTypeBuilder<TableState> builder)
        {
            builder.Property(x => x.StateName).HasMaxLength(30).IsRequired();
        }
    }
}
