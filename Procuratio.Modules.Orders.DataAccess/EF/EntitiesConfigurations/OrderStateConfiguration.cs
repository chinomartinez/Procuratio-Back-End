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
    internal class OrderStateConfiguration : IEntityTypeConfiguration<OrderState>
    {
        public void Configure(EntityTypeBuilder<OrderState> builder)
        {
            builder.HasData(
                new OrderState() { Id = (short)OrderState.State.Pending, StateName = "Pendiente" },
                new OrderState() { Id = (short)OrderState.State.InProgress, StateName = "En proceso" },
                new OrderState() { Id = (short)OrderState.State.ForDelivery, StateName = "Para entrega" },
                new OrderState() { Id = (short)OrderState.State.Delivered, StateName = "Entregado" },
                new OrderState() { Id = (short)OrderState.State.WaitingForPayment, StateName = "Esperando el pago" },
                new OrderState() { Id = (short)OrderState.State.Paid, StateName = "Pagado" });
        }
    }
}
