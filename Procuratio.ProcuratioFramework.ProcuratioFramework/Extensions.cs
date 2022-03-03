using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Shared.Abstractions.Azure;
using Procuratio.Shared.ProcuratioFramework.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Shared.ProcuratioFramework
{
    internal static class Extensions
    {
        public static IServiceCollection AddFramework(this IServiceCollection services)
        {
            services.AddTransient<IFileStorage, AzureStorageContainer>();

            return services;
        }

        public static IApplicationBuilder UseFramework(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
