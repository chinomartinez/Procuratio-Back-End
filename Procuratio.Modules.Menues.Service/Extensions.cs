﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Menues.DataAccess;
using Procuratio.Modules.Menues.Service.Services;
using Procuratio.Modules.Menues.Service.Services.Interfaces;

namespace Procuratio.Modules.Menues.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddMenuesServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryItemService, CategoryItemService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ISubCategoryItemService, SubCategoryItemService>();

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddMenuesApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
