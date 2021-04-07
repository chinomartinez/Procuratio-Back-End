using Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds
{
    internal static class OrdersSeedStart
    {
        private static OrdersDbContext OrdersDbContext;

        internal static void CreateSeeds(OrdersDbContext ordersDbContext)
        {
            OrdersDbContext = ordersDbContext;

            ProductionEnviromentSeeds();
            TestingSeeds();
        }

        private static void ProductionEnviromentSeeds()
        {
            DeliveryStateSeed.StartDeliveryStateSeed(OrdersDbContext.DeliveryState);
            DinerInStateSeed.StartDinerInStateSeed(OrdersDbContext.DinerInState);
            OrderStateSeed.StartOrderStateSeed(OrdersDbContext.OrderState);
            ReserveStateSeed.StartReserveStateSeed(OrdersDbContext.ReserveState);
            TableStateSeed.StartTableStateSeed(OrdersDbContext.TableState);
            TakeAwayStateSeed.StartTakeAwayStateSeed(OrdersDbContext.TakeAwayState);
        }

        private static void TestingSeeds()
        {
            SaveChangesForSeed();
        }

        internal static void SaveChangesForSeed() => OrdersDbContext.SaveChanges();
    }
}
