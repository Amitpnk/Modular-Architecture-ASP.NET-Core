using HA.Adapter.DealModule.ViewModel;
using MediatR;

namespace HA.Adapter.DealModule.Commands
{
    public class CreateDealCommand : IRequest<DealViewModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

