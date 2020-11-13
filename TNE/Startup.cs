using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using TNE.Data;
using TNE.Data.Implementations;
using TNE.Services;
using TNE.Services.Implementations;
using TNE.Services.Mappings;
using TNE.Services.Utils;

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
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddSingleton(Log.Logger);
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            services.AddLogging();
            services.AddDbContextPool<DatabaseContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TNE REST API",
                    Description = "REST API for TransNeftEnergo",
                    Contact = new OpenApiContact
                    {
                        Name = "Dmitry Petelko",
                        Email = "dpetelko@gmail.com"
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddControllers();

            services.AddScoped<ILeadDivisionService, LeadDivisionServiceImpl>();
            services.AddScoped<ISubDivisionService, SubDivisionServiceImpl>();
            services.AddScoped<IProviderService, ProviderServiceImpl>();
            services.AddScoped<IDeliveryPointService, DeliveryPointServiceImpl>();
            services.AddScoped<IBillingPointService, BillingPointServiceImpl>();
            services.AddScoped<ICurrentTransformerService, CurrentTransformerServiceImpl>();
            services.AddScoped<IVoltageTransformerService, VoltageTransformerServiceImpl>();
            services.AddScoped<IControlPointService, ControlPointServiceImpl>();
            services.AddScoped<IElectricityMeterService, ElectricityMeterServiceImpl>();
            services.AddScoped<IDbGenerator, DbGeneratorImpl>();

            services.AddScoped<ILeadDivisionRepository, LeadDivisionRepositoryImpl>();
            services.AddScoped<ISubDivisionRepository, SubDivisionRepositoryImpl>();
            services.AddScoped<IProviderRepository, ProviderRepositoryImpl>();
            services.AddScoped<IDeliveryPointRepository, DeliveryPointRepositoryImpl>();
            services.AddScoped<IBillingPointRepository, BillingPointRepositoryImpl>();
            services.AddScoped<ICurrentTransformerRepository, CurrentTransformerRepositoryImpl>();
            services.AddScoped<IVoltageTransformerRepository, VoltageTransformerRepositoryImpl>();
            services.AddScoped<IControlPointRepository, ControlPointRepositoryImpl>();
            services.AddScoped<IElectricityMeterRepository, ElectricityMeterRepositoryImpl>();
            services.AddScoped<IDbUtils, DbUtilsImpl>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseExceptionHandler("/error");
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
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
