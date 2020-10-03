using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using TNE.Data;
using TNE.Data.Implementations;
using TNE.Services;
using TNE.Services.Implementations;

namespace TNE
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
            services.AddSingleton(Log.Logger);
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            services.AddLogging();
            services.AddDbContextPool<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ILeadDivisionService, LeadDivisionServiceImpl>();
            services.AddScoped<ISubDivisionService, SubDivisionServiceImpl>();
            services.AddScoped<IProviderService, ProviderServiceImpl>();
            services.AddScoped<IDeliveryPointService, DeliveryPointServiceImpl>();
            services.AddScoped<ICurrentTransformerService, CurrentTransformerServiceImpl>();
            services.AddScoped<IVoltageTransformerService, VoltageTransformerServiceImpl>();
            services.AddScoped<IControlPointService, ControlPointServiceImpl>();
            services.AddScoped<IElectricityMeterService, ElectricityMeterServiceImpl>();

            services.AddScoped<ILeadDivisionRepository, LeadDivisionRepositoryImpl>();
            services.AddScoped<ISubDivisionRepository, SubDivisionRepositoryImpl>();
            services.AddScoped<IProviderRepository, ProviderRepositoryImpl>();
            services.AddScoped<IDeliveryPointRepository, DeliveryPointRepositoryImpl>();
            services.AddScoped<ICurrentTransformerRepository, CurrentTransformerRepositoryImpl>();
            services.AddScoped<IVoltageTransformerRepository, VoltageTransformerRepositoryImpl>();
            services.AddScoped<IControlPointRepository, ControlPointRepositoryImpl>();
            services.AddScoped<IElectricityMeterRepository, ElectricityMeterRepositoryImpl>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error");
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("ping", async context =>
                {
                    await context.Response.WriteAsync($"Don't worry! I'm alive! Current time is: {DateTime.Now}");
                });
            });
        }
    }
}
