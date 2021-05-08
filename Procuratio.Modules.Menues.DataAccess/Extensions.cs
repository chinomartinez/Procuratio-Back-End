using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware;
using Procuratio.Shared.Infrastructure.SQLServer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Menues.Service")]
namespace Procuratio.Modules.Menues.DataAccess
{
    internal static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<ICategoryItemRepository, CategoryItemRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ISubCategoryItemRepository, SubCategoryItemRepository>();

            services.AddSQLServer<MenuesDbContext>();

            return services;
        }

        public static IApplicationBuilder AddDatabase(this IApplicationBuilder app)
        {
            app.AddSeedDataBase<MenuesDbContext>();

            return app;
        }
    }
}
