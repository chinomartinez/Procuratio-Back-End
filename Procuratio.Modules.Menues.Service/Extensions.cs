using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Menues.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddMenuesServices(this IServiceCollection services)
        {
            //services.AddScoped<INTERFAZSERVICIO, CLASESERVICIO>();
            //services.AddSingleton<INTERFAZREPOSITORIO, REPOSITORIO>();

            return services;
        }
    }
}
