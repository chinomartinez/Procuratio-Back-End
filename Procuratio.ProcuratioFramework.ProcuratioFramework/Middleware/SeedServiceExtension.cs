using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware
{
    /// <summary>
    /// Middleware que corre las migraciones y se asegura del estado de las base de datos
    /// al iniciar el servidor
    /// </summary>
    public static class SeedServiceExtension
    {
        public static IApplicationBuilder AddSeedDataBase<TContext>(this IApplicationBuilder app) where TContext : DbContext
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                TContext context = serviceScope.ServiceProvider.GetService<TContext>();

                if (!context.AllMigrationsApplied())
                {
                    context.Database.Migrate();
                }
                context.EnsureSeeded();
            }

            return app;
        }

    }
}
