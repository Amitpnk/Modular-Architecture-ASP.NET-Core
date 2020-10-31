using HA.Application.DealFeature.ViewModel;
using MediatR;
using System;

namespace HA.Application.DealFeature.Commands
{
    public class UpdateDealCommand : IRequest<DealViewModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
