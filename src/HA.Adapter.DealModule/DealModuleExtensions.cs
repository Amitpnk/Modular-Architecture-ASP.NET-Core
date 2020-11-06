//using HA.Adapter.DealModule.Service;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace HA.Adapter.DealModule
{
    public static class DealModuleExtensions
    {
        public static void AddDealModule(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<IDealRepositoryAsync, DealRepositoryAsync>();
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

         
        }
    }
}
