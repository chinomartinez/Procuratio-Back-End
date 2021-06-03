using Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds
{
    internal static class OrdersSeedStart
    {
        internal static void CreateSeeds(OrdersDbContext ordersDbContext)
        {
            ProductionEnviromentSeeds(ordersDbContext);
            TestingSeeds(ordersDbContext);

            ordersDbContext.SaveChanges();
        }

        private static void ProductionEnviromentSeeds(OrdersDbContext ordersDbContext)
        {
            DeliveryStateSeed.StartDeliveryStateSeed(ordersDbContext.DeliveryState);
            DinerInStateSeed.StartDineInStateSeed(ordersDbContext.DineInState);
            OrderStateSeed.StartOrderStateSeed(ordersDbContext.OrderState);
            ReserveStateSeed.StartReserveStateSeed(ordersDbContext.ReserveState);
            TableStateSeed.StartTableStateSeed(ordersDbContext.TableState);
            TakeAwayStateSeed.StartTakeAwayStateSeed(ordersDbContext.TakeAwayState);
        }

        private static void TestingSeeds(OrdersDbContext ordersDbContext)
        {
        }
    }
}
