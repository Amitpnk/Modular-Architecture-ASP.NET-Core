using HA.Adapter.Persistence.Unit.Test.Common;
using HA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HA.Adapter.Persistence.Unit.Test.Context
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertDealIntoDatabase()
        {
            using var context = ApplicationDbContextFactory.Create();
            var deal = new Deal();
            context.Deals.Add(deal);
            Assert.AreEqual(EntityState.Added, context.Entry(deal).State);
            var result = context.SaveChangesAsync();
            Assert.AreEqual(1, result.Result);
            Assert.AreEqual(Task.CompletedTask.Status, result.Status);
            Assert.AreEqual(EntityState.Unchanged, context.Entry(deal).State);
        }

        [Test]
        public void CanUpdateDealIntoDatabase()
        {
            using var context = ApplicationDbContextFactory.Create();
            var deal = new Deal();
            context.Deals.Update(deal);
            Assert.AreEqual(EntityState.Added, context.Entry(deal).State);
            var result = context.SaveChangesAsync();
            Assert.AreEqual(1, result.Result);
            Assert.AreEqual(Task.CompletedTask.Status, result.Status);
            Assert.AreEqual(EntityState.Unchanged, context.Entry(deal).State);
        }

        [Test]
        public void CanDeleteDealIntoDatabase()
        {
            using var context = ApplicationDbContextFactory.Create();
            var deal = new Deal();
            context.Deals.Remove(deal);
            Assert.AreEqual(EntityState.Deleted, context.Entry(deal).State);
        }

    }
}
