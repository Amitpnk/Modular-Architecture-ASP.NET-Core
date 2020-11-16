using HA.Adapter.DealModule;
using HA.Adapter.Persistence;
using HA.Application;
using HA.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace HA.WebAPI
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        private AppSettings appSettings { get; set; }
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            _configuration = configuration;

            appSettings = new AppSettings();
            _configuration.Bind(appSettings);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApplication();

            services.AddDealModule();

            services.AddPersistence(_configuration, appSettings);

            // Todo: move to infrastucture layer
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Hexagonal Architecture WebAPI",
                        Version = "1",
                        Description = "Through this API you can access details",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "amit.naik8103@gmail.com",
                            Name = "Amit Naik",
                            Url = new Uri(appSettings.ApplicationDetail.ContactWebsite)
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri(appSettings.ApplicationDetail.LicenseDetail)
                        }
                    });
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            log.AddSerilog();

            app.UseExceptionHandlerMiddleware();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "Hexagonal Architecture WebAPI");
                setupAction.RoutePrefix = "OpenAPI";
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
