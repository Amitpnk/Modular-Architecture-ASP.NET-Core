using HA.Adapter.DealModule;
using HA.Adapter.Persistence;
using HA.Application;
using HA.Domain.Services;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
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
        private IConfiguration Configuration { get; }
        private AppSettings AppSettings { get; set; }
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;

            AppSettings = new AppSettings();
            Configuration.Bind(AppSettings);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApplication();

            services.AddDealModule();

            services.AddPersistence(Configuration, AppSettings);

            services.AddMemoryCache();

            services.AddMiniProfiler(options => options.RouteBasePath = "/profiler").AddEntityFramework();

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
                            Url = new Uri(AppSettings.ApplicationDetail.ContactWebsite)
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri(AppSettings.ApplicationDetail.LicenseDetail)
                        }
                    });
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });

            services.AddHealthChecks()
              .AddUrlGroup(new Uri(AppSettings.ApplicationDetail.ContactWebsite), name: "My personal website", failureStatus: HealthStatus.Degraded)
              .AddSqlServer(Configuration.GetConnectionString("HexaArchConn"));

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("Basic Health Check", $"/healthz");
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

            app.UseMiniProfiler();

            app.UseHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
                },
            }).UseHealthChecksUI(setup =>
            {
                setup.ApiPath = "/healthcheck";
                setup.UIPath = "/healthcheck-ui";
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
