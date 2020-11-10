using HA.Adapter.Persistence.Context;
using HA.Adapter.Persistence.Repositories;
using HA.Application.Contract;
using HA.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HA.Adapter.Persistence
{
    public static class PersistenceExtensions
    {
        public static void AddPersistence(this IServiceCollection serviceCollection,
            IConfiguration configuration,
            AppSettings appSettings)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("HexaArchConnInMemoryDb"));
            }
            else
            {
                serviceCollection.AddDbContext<ApplicationDbContext>(opt =>
                {
                    opt.EnableSensitiveDataLogging(false);
                    opt.UseSqlServer(appSettings.ConnectionStrings.HexaArchConn);
                });
            }

            serviceCollection.AddTransient(typeof(IGenericRepositoryAsync<,>), typeof(GenericRepositoryAsync<,>));
        }
    }
}
