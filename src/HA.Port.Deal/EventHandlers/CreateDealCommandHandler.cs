using AutoMapper;
using HA.Application.DealFeature.Commands;
using HA.Application.DealFeature.ViewModel;
using HA.Domain.Contract;
using HA.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Application.DealFeature.EventHandlers
{
    public class CreateDealCommandHandler : IRequestHandler<CreateDealCommand, DealViewModel>
    {
        private readonly IGenericRepositoryAsync<Deal, Guid> _genericRepository;
        private readonly IMapper _mapper;
        public CreateDealCommandHandler(IGenericRepositoryAsync<Deal, Guid> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<DealViewModel> Handle(CreateDealCommand request, CancellationToken cancellationToken)
        {
            var entity = new Deal
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
            };

            await _genericRepository.AddAsync(entity);
            _genericRepository.SaveChanges();

            return _mapper.Map<DealViewModel>(entity);
        }
    }
}