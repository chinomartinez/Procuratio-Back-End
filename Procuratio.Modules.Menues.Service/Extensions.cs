using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Menues.DataAccess;
using Procuratio.Modules.Menues.Service.Services;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using System.Reflection;

namespace Procuratio.Modules.Menues.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddMenuServices(this IServiceCollection services)
        {
            services.AddScoped<IMenuCategoryService, MenuCategoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IMenuSubcategoryService, MenuSubCategoryService>();

            services.AddAutoMapper(typeof(Extensions).GetTypeInfo().Assembly);

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddMenuApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
