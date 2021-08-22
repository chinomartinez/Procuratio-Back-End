using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Procuratio.Modules.Customers.API;
using Procuratio.Modules.Menues.API;
using Procuratio.Modules.Orders.API;
using Procuratio.Modules.Restaurants.API;
using Procuratio.Modules.Securities.API;
using Procuratio.Shared.Infrastructure;

namespace Procuratio.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(Configuration.GetValue<string>("Local_FrontEnd_URL")).AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Procuratio.API", Version = "v1" });
            });

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddInfrastructure();

            services.AddOrderModule();
            services.AddMenuModule();
            services.AddCustomerModule();
            services.AddRestaurantModule();
            services.AddSecurityModule();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Procuratio.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseInfrastructure();

            app.UseRouting();

            app.UseCors();

            app.UseOrderModule();
            app.UseMenuModule();
            app.UseCustomerModule();
            app.UseRestaurantModule();
            app.UseSecurityModule();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
