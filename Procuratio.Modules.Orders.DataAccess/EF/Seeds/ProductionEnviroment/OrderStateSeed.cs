﻿using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class OrderStateSeed
    {
        internal static void StartOrderStateSeed(DbSet<OrderState> orderStateDbSet)
        {
            if (orderStateDbSet.Any()) return;

            orderStateDbSet.Add(new OrderState() { StateName = "Sin Ordenar" });
            OrdersSeedStart.SaveChangesForSeed();

            orderStateDbSet.Add(new OrderState() { StateName = "En proceso" });
            OrdersSeedStart.SaveChangesForSeed();

            orderStateDbSet.Add(new OrderState() { StateName = "Para entrega" });
            OrdersSeedStart.SaveChangesForSeed();

            orderStateDbSet.Add(new OrderState() { StateName = "Entregado" });
            OrdersSeedStart.SaveChangesForSeed();
        }
    }
}