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
    internal class WithoutReserveStateConfiguration : IEntityTypeConfiguration<WithoutReserveState>
    {
        public void Configure(EntityTypeBuilder<WithoutReserveState> builder)
        {
            builder.HasData(
                new WithoutReserveState() { Id = (short)WithoutReserveState.State.InProgress, StateName = "En curso" },
                new WithoutReserveState() { Id = (short)WithoutReserveState.State.Completed, StateName = "Completada" });
        }
    }
}
