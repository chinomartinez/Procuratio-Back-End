using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.EntitiesConfigurations
{
    internal class TableStateConfiguration : IEntityTypeConfiguration<TableState>
    {
        public void Configure(EntityTypeBuilder<TableState> builder)
        {
            builder.HasData(
                new TableState() { Id = (short)TableState.State.Available, StateName = "Disponible" },
                new TableState() { Id = (short)TableState.State.Ocuped, StateName = "Ocupada" });
        }
    }
}
