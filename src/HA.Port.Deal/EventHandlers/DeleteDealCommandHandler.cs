using AutoMapper;
using HA.Application.DealFeature.Commands;
using HA.CrossCuttingConcerns.Exceptions;
using HA.Domain.Contract;
using HA.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Application.DealFeature.EventHandlers
{
    public class DeleteDealCommandHandler : IRequestHandler<DeleteDealCommand>
    {
        private readonly IGenericRepositoryAsync<Deal, Guid> _genericRepository;
        public DeleteDealCommandHandler(IGenericRepositoryAsync<Deal, Guid> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(DeleteDealCommand request, CancellationToken cancellationToken)
        {
            var group = await _genericRepository.GetByIdAsync(request.DealId);
            if (group == null)
            {
                throw new NotFoundException(nameof(Deal), request.DealId);
            }

            await _genericRepository.DeleteAsync(request.DealId);
            _genericRepository.SaveChanges();

            return Unit.Value;
        }
    }
}