using HA.Adapter.Persistence.Context;
using HA.Adapter.Persistence.Repositories;
using HA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HA.Adapter.Persistence.Unit.Test.Context.Repositories
{
    public class GenericRepositoryAsyncTest
    {
        private DbContextOptionsBuilder builder;

        Deal deal, deal2, deal3, deal4;
        Guid id1 = Guid.NewGuid();
        Guid id2 = Guid.NewGuid();
        Guid id3 = Guid.NewGuid();
        Guid id4 = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("InMemoryDealDB");

            deal = new Deal
            {
                Id = id1,
                Name = "IRD",
                Description = "IRD Deal 123"
            };
            deal2 = new Deal
            {
                Id = id2,
                Name = "IRD",
                Description = "IRD Deal 456"
            };
            deal3 = new Deal
            {
                Id = id3,
                Name = "IRD",
                Description = "IRD Deal 789"
            };
            deal4 = new Deal
            {
                Id = id4,
                Name = "IRD",
                Description = "IRD Deal 147"
            };
        }

        [Test, Order(1)]
        public async Task CheckGenenricRepositoryAddDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(deal);
            var result = genericRepository.SaveChanges();
            Assert.IsTrue(result);
        }

        [Test, Order(2)]
        public async Task CheckGenenricRepositoryGetDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(deal2);
            genericRepository.SaveChanges();

            var deals = await genericRepository.GetAllAsync();

            Assert.LessOrEqual(2, deals.Count());
        }

        [Test, Order(3)]
        public async Task CheckGenenricRepositoryGetByIdDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(deal3);
            genericRepository.SaveChanges();

            var getdeal = genericRepository.GetByIdAsync(id3);
            Assert.AreEqual(id3, getdeal.Result.Id);

        }

        [Test, Order(4)]
        public async Task CheckGenenricRepositoryUpdateDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var customerRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await customerRepository.UpdateAsync(deal);
            var result = customerRepository.SaveChanges();
            Assert.IsTrue(result);
        }

        [Test, Order(5)]
        public async Task CheckGenenricRepositoryDeleteDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);

            await genericRepository.AddAsync(deal4);
            Assert.IsTrue(genericRepository.SaveChanges());
            await genericRepository.DeleteAsync(deal4.Id);
            Assert.IsTrue(genericRepository.SaveChanges());
        }



    }
}
