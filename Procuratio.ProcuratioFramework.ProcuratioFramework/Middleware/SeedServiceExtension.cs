using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration;

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
    }
}