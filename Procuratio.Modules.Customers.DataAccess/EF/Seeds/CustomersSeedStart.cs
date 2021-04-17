using Procuratio.Modules.Customers.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Customers.DataAccess.EF.Seeds
{
    internal static class CustomersSeedStart
    {
        private static CustomersDbContext CustomersDbContext;

        internal static void CreateSeeds(CustomersDbContext customersDbContext)
        {
            CustomersDbContext = customersDbContext;

            ProductionEnviromentSeeds();
            TestingSeeds();
        }

        private static void ProductionEnviromentSeeds()
        {
            CustomerXOrderStateSeed.StartCashStateSeed(CustomersDbContext.CustomerXOrderState);
        }

        private static void TestingSeeds()
        {
            SaveChangesForSeed();
        }

        internal static void SaveChangesForSeed() => CustomersDbContext.SaveChanges();
    }
}
