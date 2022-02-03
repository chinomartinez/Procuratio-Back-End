
namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds
{
    internal static class OrdersSeedStart
    {
        internal static void CreateSeeds(OrderDbContext ordersDbContext)
        {
            ProductionEnviromentSeeds(ordersDbContext);
            TestingSeeds(ordersDbContext);
        }

        private static void ProductionEnviromentSeeds(OrderDbContext ordersDbContext)
        {
            ordersDbContext.SaveChanges();
        }

        private static void TestingSeeds(OrderDbContext ordersDbContext)
        {
            ordersDbContext.SaveChanges();
        }
    }
}
