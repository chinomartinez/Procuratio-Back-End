using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using System.Collections.Generic;
using System.Linq;

namespace Procuratio.Shared.Infrastructure.DbContextDbContextUtilities
{
    public static class DbContextSupportMethods
    {
        public static void BeforeSaveChanges(ChangeTracker changeTracker, ITenantService tenantService)
        {
            int? branchId = tenantService.GetBranchId();

            if (branchId is not null)
            {
                List<EntityEntry<ITenant>> entries = changeTracker.Entries<ITenant>().ToList();

                foreach (var entry in entries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.BranchId = (int)branchId;
                            break;
                    }
                }
            }
        }
    }
}
