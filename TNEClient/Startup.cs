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
            services.AddControllers();
            services.AddRefitClient<ILeadDivisionRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration.GetSection("TNERestApi.Url").Value));
            services.AddScoped<ILeadDivisionService, LeadDivisionServiceImpl>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("App starting...");
                    var service = context.Request.HttpContext.RequestServices.GetRequiredService<ILeadDivisionService>();
                    var countries = await service.GetAllAsync();

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(countries));
                });
            });
        }
    }
}
