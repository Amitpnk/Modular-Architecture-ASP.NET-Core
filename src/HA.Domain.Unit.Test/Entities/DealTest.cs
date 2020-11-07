using HA.Domain.Entities;
using NUnit.Framework;
using System;

namespace HA.Domain.Unit.Test.Entities
{
    public class GroupTest
    {
        private readonly Deal _deal;
        private readonly Guid Id = Guid.NewGuid();
        private const string Name = "Test";
        private const string Description = "Test Description";

        public GroupTest()
        {
            _deal = new Deal();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _deal.Id = Id;
            Assert.That(_deal.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetName()
        {
            _deal.Name = Name;
            Assert.That(_deal.Name, Is.EqualTo(Name));
        }

        [Test]
        public void TestSetAndGetDescription()
        {
            _deal.Description = Description;
            Assert.That(_deal.Description, Is.EqualTo(Description));
        }
    }
}
