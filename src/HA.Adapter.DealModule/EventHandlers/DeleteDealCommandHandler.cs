using AutoMapper;
using HA.Adapter.DealModule.Commands;
using HA.Application.Contract;
using HA.Application.Exceptions;
using HA.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Adapter.DealModule.EventHandlers
{
    public class DeleteDealCommandHandler : IRequestHandler<DeleteDealCommand>
    {
        private readonly IGenericRepositoryAsync<Deal, Guid> _genericRepository;
        private readonly IMapper _mapper;
        public DeleteDealCommandHandler(IGenericRepositoryAsync<Deal, Guid> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDealCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new BadRequestException("Null exception");
            }

            var deal = await _genericRepository.GetByIdAsync(request.DealId);

            if (deal == null)
            {
                throw new NotFoundException(nameof(Deal), request.DealId);
            }

            await _genericRepository.DeleteAsync(request.DealId);
            _genericRepository.SaveChanges();

            return Unit.Value;
        }
    }
}
