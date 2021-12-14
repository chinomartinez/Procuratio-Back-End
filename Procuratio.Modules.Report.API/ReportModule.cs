using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Report.Service;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Report.API
{
    internal static class ReportModule
    {
        public static IServiceCollection AddReportModule(this IServiceCollection services)
        {
            services.AddReportServices();

            return services;
        }

        public static IApplicationBuilder UseReportModule(this IApplicationBuilder app)
        {
            app.AddReportApps();

            return app;
        }
    }
}
