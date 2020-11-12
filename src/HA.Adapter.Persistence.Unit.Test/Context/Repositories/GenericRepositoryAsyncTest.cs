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

        Deal deal;
        Deal deal2;
        Guid id1 = Guid.NewGuid();
        Guid id2 = Guid.NewGuid();

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
        }

        [Test]
        public async Task CheckGenenricRepositoryAddDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(deal);
            var result = genericRepository.SaveChanges();
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CheckGenenricRepositoryUpdateDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var customerRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await customerRepository.UpdateAsync(deal);
            var result = customerRepository.SaveChanges();
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CheckGenenricRepositoryDeleteDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);

            await genericRepository.AddAsync(deal);
            Assert.IsTrue(genericRepository.SaveChanges());
            await genericRepository.DeleteAsync(deal.Id);
            Assert.IsTrue(genericRepository.SaveChanges());
        }

        [Test]
        public async Task CheckGenenricRepositoryGetDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(deal);
            await genericRepository.AddAsync(deal2);
            genericRepository.SaveChanges();

            var deals = await genericRepository.GetAllAsync();

            Assert.LessOrEqual(2, deals.Count());
        }

        [Test]
        public async Task CheckGenenricRepositoryGetByIdDeal()
        {
            using var context = new ApplicationDbContext(builder.Options);
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(deal);
            await genericRepository.AddAsync(deal2);
            genericRepository.SaveChanges();

            var getdeal = genericRepository.GetByIdAsync(id1);
            Assert.AreEqual(id1, getdeal.Result.Id);

        }

    }
}
