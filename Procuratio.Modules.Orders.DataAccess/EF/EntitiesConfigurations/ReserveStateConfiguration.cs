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
    internal class ReserveStateConfiguration : IEntityTypeConfiguration<ReserveState>
    {
        public void Configure(EntityTypeBuilder<ReserveState> builder)
        {
            builder.HasData(
                new ReserveState() { Id = (short)ReserveState.State.Pending, StateName = "Pendiente" },
                new ReserveState() { Id = (short)ReserveState.State.Unconfirmed, StateName = "Sin confirmar" },
                new ReserveState() { Id = (short)ReserveState.State.InProgress, StateName = "En curso" },
                new ReserveState() { Id = (short)ReserveState.State.Completed, StateName = "Completada" },
                new ReserveState() { Id = (short)ReserveState.State.DidNotCome, StateName = "No vino" });
        }
    }
}
