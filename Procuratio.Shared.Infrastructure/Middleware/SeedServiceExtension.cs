using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware
{
    public static class SeedServiceExtension
    {
        public static IApplicationBuilder AddSeedDataBase<TContext>(this IApplicationBuilder app) where TContext : DbContext
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                TContext currentContext = serviceScope.ServiceProvider.GetService<TContext>();

                if (!currentContext.AllMigrationsApplied())
                {
                    currentContext.Database.Migrate();
                }

                currentContext.EnsureSeeded();
            }

            return app;
        }

        private static bool AllMigrationsApplied(this DbContext context)
        {
            IEnumerable<string> applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            IEnumerable<string> total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        private static void EnsureSeeded(this DbContext dbContext)
        {
            if (dbContext is ISeed dbContextSeedToStart) { dbContextSeedToStart.Seed(); }
        }
    }
}