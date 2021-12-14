﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.DbContextDbContextUtilities
{
    public static class DbContextSupportMethods
    {
        public static void BeforeSaveChanges(ChangeTracker changeTracker, ITenantService tenantService)
        {
            int branchId = tenantService.GetBranchId();

            foreach (var entry in changeTracker.Entries<ITenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.BranchId = branchId;
                        break;
                }
            }
        }
    }
}
