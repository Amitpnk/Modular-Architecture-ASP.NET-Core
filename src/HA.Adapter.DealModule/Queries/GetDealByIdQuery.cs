using AutoMapper;
using HA.Adapter.DealModule.ViewModel;
using HA.Application.Contract;
using HA.Application.Exceptions;
using HA.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Adapter.DealModule.Queries
{
    public class GetDealByIdQuery : IRequest<DealViewModel>
    {
        public Guid DealId { get; set; }
        public GetDealByIdQuery(Guid id)
        {
            DealId = id;
        }
    }

    public class GetDealByIdHandler : IRequestHandler<GetDealByIdQuery, DealViewModel>
    {
        private readonly IGenericRepositoryAsync<Deal, Guid> _genericRepository;
        private readonly IMapper _mapper;

        public GetDealByIdHandler(IGenericRepositoryAsync<Deal, Guid> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<DealViewModel> Handle(GetDealByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _genericRepository.GetByIdAsync(request.DealId);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Deal), request.DealId);
            }
            return _mapper.Map<DealViewModel>(entity);
        }
    }
}
