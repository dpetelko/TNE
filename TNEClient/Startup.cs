using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Refit;
using System;
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
            
            
            services.AddRefitClient<ILeadDivisionRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration.GetSection("TNERestApi.Url").Value));

            services.AddRefitClient<ISubDivisionRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration.GetSection("TNERestApi.Url").Value));

            services.AddRefitClient<IVoltageTransformerRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration.GetSection("TNERestApi.Url").Value));

            services.AddRefitClient<ICurrentTransformerRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration.GetSection("TNERestApi.Url").Value));

            services.AddScoped<ILeadDivisionService, LeadDivisionServiceImpl>();
            services.AddScoped<IVoltageTransformerService, VoltageTransformerServiceImpl>();
            services.AddScoped<ICurrentTransformerService, CurrentTransformerServiceImpl>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id:Guid?}");
                //endpoints.MapGet("/", async context =>
                //{

                //    var service = context.Request.HttpContext.RequestServices.GetRequiredService<ILeadDivisionService>();
                //    var countries = await service.GetAllAsync();
                //    await context.Response.WriteAsync(JsonConvert.SerializeObject(countries));
                //});
            });
        }
    }
}
