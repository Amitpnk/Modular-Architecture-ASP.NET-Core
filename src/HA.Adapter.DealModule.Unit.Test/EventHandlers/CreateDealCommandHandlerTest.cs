using AutoMapper;
using HA.Adapter.DealModule.Commands;
using HA.Adapter.DealModule.EventHandlers;
using HA.Application.Contract;
using HA.Domain.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Adapter.DealModule.Unit.Test.EventHandlers
{
    public class CreateDealCommandHandlerTest
    {
        [Test]
        public void Handle_CheckCompletionStatus_ShouldCreateCustomer()
        {
            // Arrange
            var genericRepositoryMock = new Mock<IGenericRepositoryAsync<Deal, Guid>>();
            var mapperMock = new Mock<IMapper>();
            var createDealCommand = new CreateDealCommand { Name = "IRD", Description = "IRD 123" };
            var createDealCommandHandler = new CreateDealCommandHandler(genericRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = createDealCommandHandler.Handle(createDealCommand, new CancellationToken());

            // Assert
            Assert.AreEqual(Task.CompletedTask.Status, result.Status);
        }

    }
}
