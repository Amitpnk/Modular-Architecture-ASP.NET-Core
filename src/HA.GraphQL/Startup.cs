using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using HA.Adapter.Persistence;
using HA.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HA.GraphQL
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private AppSettings AppSettings { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AppSettings = new AppSettings();
            Configuration.Bind(AppSettings);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration, AppSettings);

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<DealSchema>();

            services.AddGraphQL(o => o.ExposeExceptions = true)
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();
            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseGraphQL<DealSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
        }
    }
}
