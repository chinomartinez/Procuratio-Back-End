
namespace Procuratio.Modules.Customers.DataAccess.EF.Seeds
{
    internal static class CustomersSeedStart
    {
        internal static void CreateSeeds(CustomerDbContext customersDbContext)
        {
            ProductionEnviromentSeeds(customersDbContext);
            TestingSeeds(customersDbContext);
        }

        private static void ProductionEnviromentSeeds(CustomerDbContext customersDbContext)
        {
            customersDbContext.SaveChanges();
        }

        private static void TestingSeeds(CustomerDbContext customersDbContext)
        {
            customersDbContext.SaveChanges();
        }
    }
}
