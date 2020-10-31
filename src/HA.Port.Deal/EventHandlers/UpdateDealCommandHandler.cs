using AutoMapper;
using HA.Application.DealFeature.Commands;
using HA.Application.DealFeature.ViewModel;
using HA.CrossCuttingConcerns.Exceptions;
using HA.Domain.Contract;
using HA.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Application.DealFeature.EventHandlers
{
    public class UpdateDealCommandHandler : IRequestHandler<UpdateDealCommand, DealViewModel>
    {
        private readonly IGenericRepositoryAsync<Deal, Guid> _genericRepository;
        private readonly IMapper _mapper;
        public UpdateDealCommandHandler(IGenericRepositoryAsync<Deal, Guid> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<DealViewModel> Handle(UpdateDealCommand request, CancellationToken cancellationToken)
        {
            var entity = new Deal
            {
                Id = request.Id,
                Description = request.Description,
                Name = request.Name
            };

            var card = await _genericRepository.GetByIdAsync(request.Id);
            if (card == null)
            {
                throw new NotFoundException(nameof(Deal), request.Id);
            }

            await _genericRepository.UpdateAsync(entity);
            _genericRepository.SaveChanges();

            return _mapper.Map<DealViewModel>(entity);
        }
    }
}