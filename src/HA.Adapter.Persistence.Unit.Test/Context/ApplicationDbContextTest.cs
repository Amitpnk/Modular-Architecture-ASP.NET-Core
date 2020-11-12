using HA.Adapter.Persistence.Context;
using HA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace HA.Adapter.Persistence.Unit.Test.Context
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertDealIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            var deal = new Deal();
            context.Deals.Add(deal);
            Assert.AreEqual(EntityState.Added, context.Entry(deal).State);
        }

        [Test]
        public void CanUpdateDealIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            var deal = new Deal();
            context.Deals.Update(deal);
            Assert.AreEqual(EntityState.Added, context.Entry(deal).State);
        }

        [Test]
        public void CanDeleteDealIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            var deal = new Deal();
            context.Deals.Remove(deal);
            Assert.AreEqual(EntityState.Deleted, context.Entry(deal).State);
        }

    }
}
