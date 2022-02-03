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
    internal class TakeAwayStateConfiguration : IEntityTypeConfiguration<TakeAwayState>
    {
        public void Configure(EntityTypeBuilder<TakeAwayState> builder)
        {
            builder.HasData(
                new TakeAwayState() { Id = (short)TakeAwayState.State.InProgress, StateName = "En curso" },
                new TakeAwayState() { Id = (short)TakeAwayState.State.Completed, StateName = "Completado" },
                new TakeAwayState() { Id = (short)TakeAwayState.State.DidNotCome, StateName = "No vino" });
        }
    }
}
