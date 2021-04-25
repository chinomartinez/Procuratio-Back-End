﻿using Procuratio.Modules.Customers.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Customers.DataAccess.EF.Seeds
{
    internal static class CustomersSeedStart
    {
        internal static void CreateSeeds(CustomersDbContext customersDbContext)
        {
            ProductionEnviromentSeeds(customersDbContext);
            TestingSeeds(customersDbContext);

            customersDbContext.SaveChanges();
        }

        private static void ProductionEnviromentSeeds(CustomersDbContext customersDbContext)
        {
            CustomerXOrderStateSeed.StartCashStateSeed(customersDbContext.CustomerXOrderState);
        }

        private static void TestingSeeds(CustomersDbContext customersDbContext)
        {
        }
    }
}
