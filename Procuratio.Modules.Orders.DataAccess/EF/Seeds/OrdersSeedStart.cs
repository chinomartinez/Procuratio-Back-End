﻿using Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds
{
    internal static class OrdersSeedStart
    {
        internal static void CreateSeeds(OrderDbContext ordersDbContext)
        {
            ProductionEnviromentSeeds(ordersDbContext);
            TestingSeeds(ordersDbContext);

            ordersDbContext.SaveChangesAsync();
        }

        private static void ProductionEnviromentSeeds(OrderDbContext ordersDbContext)
        {
            DeliveryStateSeed.StartDeliveryStateSeed(ordersDbContext.DeliveryState);
            WithoutReserveStateSeed.StartWithoutReserveStateSeed(ordersDbContext.WithoutReserveState);
            OrderStateSeed.StartOrderStateSeed(ordersDbContext.OrderState);
            ReserveStateSeed.StartReserveStateSeed(ordersDbContext.ReserveState);
            TableStateSeed.StartTableStateSeed(ordersDbContext.TableState);
            TakeAwayStateSeed.StartTakeAwayStateSeed(ordersDbContext.TakeAwayState);
        }

        private static void TestingSeeds(OrderDbContext ordersDbContext)
        {
        }
    }
}
