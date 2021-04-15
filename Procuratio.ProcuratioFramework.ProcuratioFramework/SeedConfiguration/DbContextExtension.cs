using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration
{
    public static class DbContextExtension
    {
        public static bool AllMigrationsApplied(this DbContext context)
        {
            IEnumerable<string> applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            IEnumerable<string> total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this DbContext dbContext)
        {
            if (dbContext is ISeed dbContextSeedToStart) { dbContextSeedToStart.Seed(); }
        }
    }
}
