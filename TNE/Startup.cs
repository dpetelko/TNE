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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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
            //services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContextPool<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<DatabaseContext>(options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
            // ServiceLifetime.Transient);

            services.AddScoped<ILeadDivisionService, LeadDivisionServiceImpl>();
            services.AddScoped<ISubDivisionService, SubDivisionServiceImpl>();
            services.AddScoped<IProviderService, ProviderServiceImpl>();
            services.AddScoped<IDeliveryPointService, DeliveryPointServiceImpl>();

            services.AddScoped<ILeadDivisionRepository, LeadDivisionRepositoryImpl>();
            services.AddScoped<ISubDivisionRepository, SubDivisionRepositoryImpl>();
            services.AddScoped<IProviderRepository, ProviderRepositoryImpl>();
            services.AddScoped<IDeliveryPointRepository, DeliveryPointRepositoryImpl>();

            services.AddControllersWithViews();
            services.AddMvc();
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
