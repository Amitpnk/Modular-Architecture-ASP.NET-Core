using HA.Adapter.DealModule.ViewModel;
using MediatR;
using System;

namespace HA.Adapter.DealModule.Commands
{
    public class UpdateDealCommand : IRequest<DealViewModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
