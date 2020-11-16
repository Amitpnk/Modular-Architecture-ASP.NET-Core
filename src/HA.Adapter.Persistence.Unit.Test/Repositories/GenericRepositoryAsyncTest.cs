using HA.Adapter.Persistence.Repositories;
using HA.Adapter.Persistence.Unit.Test.Common;
using HA.Domain.Entities;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HA.Adapter.Persistence.Unit.Test.Repositories
{
    public class GenericRepositoryAsyncTest
    {

        [Test, Order(1)]
        public async Task CheckGenenricRepositoryAddDeal()
        {
            using var context = ApplicationDbContextFactory.Create();
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            await genericRepository.AddAsync(ApplicationDbContextFactory.DealList()[0]);
            var result = genericRepository.SaveChanges();
            Assert.IsTrue(result);
        }

        [Test, Order(2)]
        public async Task CheckGenenricRepositoryGetDeal()
        {
            using var context = ApplicationDbContextFactory.Create();
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);

            var deal = new Deal() { Id = Guid.NewGuid(), Name = "IRD", Description = "IRD Deal XXX" };

            await genericRepository.AddAsync(deal);
            genericRepository.SaveChanges();

            var getAllDeal = await genericRepository.GetAllAsync();

            Assert.LessOrEqual(2, getAllDeal.Count());
        }

        [Test, Order(3)]
        public async Task CheckGenenricRepositoryGetByIdDeal()
        {
            using var context = ApplicationDbContextFactory.Create();
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);
            var dealId = Guid.NewGuid();
            var deal = new Deal() { Id = dealId, Name = "IRD", Description = "IRD Deal XXX" };
            await genericRepository.AddAsync(deal);
            genericRepository.SaveChanges();

            var getdeal = genericRepository.GetByIdAsync(dealId);
            Assert.AreEqual(dealId, getdeal.Result.Id);

        }

        [Test, Order(4)]
        public async Task CheckGenenricRepositoryUpdateDeal()
        {
            using var context = ApplicationDbContextFactory.Create();
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);

            var dealId = Guid.NewGuid();
            var deal = new Deal() { Id = dealId, Name = "IRD", Description = "IRD Deal XXX" };
            await genericRepository.AddAsync(deal);
            genericRepository.SaveChanges();

            await genericRepository.UpdateAsync(deal);
            Assert.IsTrue(genericRepository.SaveChanges());

        }

        [Test, Order(5)]
        public async Task CheckGenenricRepositoryDeleteDeal()
        {
            using var context = ApplicationDbContextFactory.Create();
            var genericRepository = new GenericRepositoryAsync<Deal, Guid>(context);

            var dealId = Guid.NewGuid();
            var deal = new Deal() { Id = dealId, Name = "IRD", Description = "IRD Deal XXX" };
            await genericRepository.AddAsync(deal);
            genericRepository.SaveChanges();

            await genericRepository.DeleteAsync(dealId);
            Assert.IsTrue(genericRepository.SaveChanges());
        }

    }
}
