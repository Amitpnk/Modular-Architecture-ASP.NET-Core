using MediatR;
using System;

namespace HA.Application.DealFeature.Commands
{
    public class DeleteDealCommand : IRequest
    {
        public Guid DealId { get; set; }

        public DeleteDealCommand(Guid id)
        {
            DealId = id;
        }

    }
}
