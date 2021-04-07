using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class OrderStateSeed
    {
        internal static void StartOrderStateSeed(DbSet<OrderState> orderStateDbSet)
        {
            if (orderStateDbSet.Any()) return;

            orderStateDbSet.Add(new OrderState() { StateName = "Pendiente" });
            OrdersSeedStart.SaveChangesForSeed();

            orderStateDbSet.Add(new OrderState() { StateName = "En proceso" });
            OrdersSeedStart.SaveChangesForSeed();

            orderStateDbSet.Add(new OrderState() { StateName = "Para entrega" });
            OrdersSeedStart.SaveChangesForSeed();

            orderStateDbSet.Add(new OrderState() { StateName = "Entregado" });
            OrdersSeedStart.SaveChangesForSeed();

            orderStateDbSet.Add(new OrderState() { StateName = "Esperando pago" });
            OrdersSeedStart.SaveChangesForSeed();

            orderStateDbSet.Add(new OrderState() { StateName = "Eliminado" });
            OrdersSeedStart.SaveChangesForSeed();

            orderStateDbSet.Add(new OrderState() { StateName = "Completado" });
            OrdersSeedStart.SaveChangesForSeed();
        }
    }
}
