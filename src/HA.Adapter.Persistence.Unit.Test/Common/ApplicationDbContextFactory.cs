using HA.Adapter.Persistence.Context;
using HA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HA.Adapter.Persistence.Unit.Test.Common
{
    public static class ApplicationDbContextFactory
    {
        public static List<Deal> DealList()
        {
            return new List<Deal>()
            {
                new Deal() {Id=Guid.NewGuid(), Name= "IRD", Description= "IRD Deal 123"  },
                new Deal() {Id=Guid.NewGuid(), Name= "IRD", Description= "IRD Deal 456" },
                new Deal() {Id=Guid.NewGuid(), Name= "IRD", Description= "IRD Deal 789"  },
                new Deal() {Id=Guid.NewGuid(), Name= "IRD", Description= "IRD Deal 147"  },
                new Deal() {Id=Guid.NewGuid(), Name= "IRD", Description= "IRD Deal 258"  }
            };
        }
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            context.Deals.AddRange(DealList());
            context.SaveChanges();
            return context;
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}