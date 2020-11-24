using HA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HA.Adapter.Persistence.Context
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            CreateDeals(modelBuilder);
        }

        private static void CreateDeals(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deal>().HasData(DealList());
        }

        private static List<Deal> DealList()
        {
            return new List<Deal>
            {
                new Deal {Id=Guid.NewGuid(), Name= "IRD", Description= "IRD Deal 123"  },
                new Deal {Id=Guid.NewGuid(), Name= "IRD", Description= "IRD Deal 456" },
                new Deal {Id=Guid.NewGuid(), Name= "IRD", Description= "IRD Deal 789"  }
            };
        }
    }
}
