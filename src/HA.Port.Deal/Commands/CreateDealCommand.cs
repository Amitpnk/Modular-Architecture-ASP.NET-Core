using HA.Application.DealFeature.ViewModel;
using MediatR;

namespace HA.Application.DealFeature.Commands
{
    public class CreateDealCommand : IRequest<DealViewModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
