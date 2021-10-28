using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Report.API")]
namespace Procuratio.Modules.Report.Service
{
    internal static class Extensions
    {
        public static IServiceCollection AddReportServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Extensions).GetTypeInfo().Assembly);

            return services;
        }

        public static IApplicationBuilder AddReportApps(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
