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
    internal class DeliveryStateConfiguration : IEntityTypeConfiguration<DeliveryState>
    {
        public void Configure(EntityTypeBuilder<DeliveryState> builder)
        {
            builder.HasData(
                new DeliveryState() { Id = (short)DeliveryState.State.Completed, StateName = "Completado" },
                new DeliveryState() { Id = (short)DeliveryState.State.InProgress, StateName = "En curso" });
        }
    }
}
