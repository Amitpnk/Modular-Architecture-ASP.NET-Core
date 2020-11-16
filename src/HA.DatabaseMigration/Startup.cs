using HA.Adapter.Persistence;
using HA.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HA.DatabaseMigration
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public AppSettings appSettings { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            appSettings = new AppSettings();
            Configuration.Bind(appSettings);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration, appSettings);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
