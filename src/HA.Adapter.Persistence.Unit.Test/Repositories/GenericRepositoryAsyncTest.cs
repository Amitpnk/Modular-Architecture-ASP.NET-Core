using HA.Adapter.Persistence.Context;
using HA.Adapter.Persistence.Repositories;
using HA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HA.Adapter.Persistence.Unit.Test.Repositories
{
    public class GenericRepositoryAsyncTest
    {
        private DbContextOptionsBuilder builder;

        List<Deal> deals;

        private static List<Deal> DealList()
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

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            deals = DealList();
        }

        [Test, Order(1)]
        public async Task CheckGenenricRepositoryAddDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(deals[0]);
            var result = genericRepository.SaveChanges();
            Assert.IsTrue(result);
        }

        [Test, Order(2)]
        public async Task CheckGenenricRepositoryGetDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(deals[1]);
            genericRepository.SaveChanges();

            var getAllDeal = await genericRepository.GetAllAsync();

            Assert.LessOrEqual(2, getAllDeal.Count());
        }

        [Test, Order(3)]
        public async Task CheckGenenricRepositoryGetByIdDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(deals[2]);
            genericRepository.SaveChanges();

            var getdeal = genericRepository.GetByIdAsync(deals[2].Id);
            Assert.AreEqual(deals[2].Id, getdeal.Result.Id);

        }

        [Test, Order(4)]
        public async Task CheckGenenricRepositoryUpdateDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);

            await genericRepository.AddAsync(deals[3]);
            Assert.IsTrue(genericRepository.SaveChanges());

            await genericRepository.UpdateAsync(deals[3]);
            Assert.IsTrue(genericRepository.SaveChanges());
        }

        [Test, Order(5)]
        public async Task CheckGenenricRepositoryDeleteDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);

            await genericRepository.AddAsync(deals[4]);
            Assert.IsTrue(genericRepository.SaveChanges());
            await genericRepository.DeleteAsync(deals[4].Id);
            Assert.IsTrue(genericRepository.SaveChanges());
        }

    }
}
