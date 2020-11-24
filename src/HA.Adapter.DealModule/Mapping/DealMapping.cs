using AutoMapper;
using HA.Adapter.DealModule.ViewModel;
using HA.Domain.Entities;

namespace HA.Adapter.DealModule.Mapping
{
    public class DealMapping : Profile
    {
        public DealMapping()
        {
            CreateMap<Deal, DealViewModel>();
        }

    }
}
