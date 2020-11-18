using AutoMapper;
using HA.Adapter.DealModule.Commands;
using HA.Adapter.DealModule.ViewModel;
using HA.Application.Contract;
using HA.Application.Exceptions;
using HA.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Adapter.DealModule.EventHandlers
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
            if (request == null)
            {
                throw new BadRequestException("Null exception");
            }

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
