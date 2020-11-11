using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using Polly;
using Polly.Timeout;
using TNEClient.Data;
using TNEClient.Services;
using TNEClient.Services.Implementations;

namespace TNEClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddRefitClient<ILeadDivisionRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());

            services.AddRefitClient<ISubDivisionRepository>(new RefitSettings())
                .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());

            services.AddRefitClient<IProviderRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());

            services.AddRefitClient<IControlPointRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());

            services.AddRefitClient<IDeliveryPointRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());

            services.AddRefitClient<IBillingPointRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());

            services.AddRefitClient<IVoltageTransformerRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());

            services.AddRefitClient<ICurrentTransformerRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());

            services.AddRefitClient<IElectricityMeterRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());
            
            services.AddRefitClient<IDbUtilsRepository>()
                .ConfigureHttpClient(c => c.BaseAddress = GetBaseAddress());

            services.AddScoped<ILeadDivisionService, LeadDivisionServiceImpl>();
            services.AddScoped<ISubDivisionService, SubDivisionServiceImpl>();
            services.AddScoped<IProviderService, ProviderServiceImpl>();
            services.AddScoped<IControlPointService, ControlPointServiceImpl>();
            services.AddScoped<IDeliveryPointService, DeliveryPointServiceImpl>();
            services.AddScoped<IBillingPointService, BillingPointServiceImpl>();
            services.AddScoped<IVoltageTransformerService, VoltageTransformerServiceImpl>();
            services.AddScoped<ICurrentTransformerService, CurrentTransformerServiceImpl>();
            services.AddScoped<IElectricityMeterService, ElectricityMeterServiceImpl>();
            services.AddScoped<IDbUtilsService, DbUtilsServiceImpl>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();

            //}
            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id:Guid?}");
            });
        }

        private Uri GetBaseAddress()
        {
            return new Uri(Configuration.GetSection("TNERestApi.Url").Value);
        }
    }
}
