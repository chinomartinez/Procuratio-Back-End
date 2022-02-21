using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Report.Service.Services;
using Procuratio.Modules.Report.Service.Services.Interfaces;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Report.API")]
namespace Procuratio.Modules.Report.Service
{
    internal static class Extensions
    {
        public static IServiceCollection AddReportServices(this IServiceCollection services)
        {
            services.AddScoped<IReportService, ReportService>();

            services.AddAutoMapper(typeof(Extensions).GetTypeInfo().Assembly);

            return services;
        }

        public static IApplicationBuilder AddReportApps(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
