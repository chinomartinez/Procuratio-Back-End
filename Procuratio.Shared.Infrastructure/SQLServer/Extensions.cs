using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Procuratio.Shared.Infrastructure.SQLServer
{
    public static class Extensions
    {
        internal static IServiceCollection AddSQLServer(this IServiceCollection services)
        {
            SQLServerOptions options = services.GetOptions<SQLServerOptions>(sectionName: "SQLServer");
            services.AddSingleton(options);

            return services;
        }

        public static IServiceCollection AddSQLServer<T>(this IServiceCollection services) where T : DbContext
        {
            SQLServerOptions options = services.GetOptions<SQLServerOptions>(sectionName: "SQLServer");

            services.AddDbContext<T>(x => x.UseSqlServer(options.Connectionstring));

            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();

            dbContext.Database.Migrate();

            return services;
        }
    }
}
