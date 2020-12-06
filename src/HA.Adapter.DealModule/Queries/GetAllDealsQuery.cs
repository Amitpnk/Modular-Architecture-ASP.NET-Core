using AutoMapper;
using HA.Adapter.DealModule.ViewModel;
using HA.Application.Contract;
using HA.Application.Exceptions;
using HA.Domain.Entities;
using HA.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Adapter.DealModule.Queries
{
    public class GetAllDealsQuery : IRequest<PagedResponse<DealViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllDealsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
    public class GetAllDealHandler : IRequestHandler<GetAllDealsQuery, PagedResponse<DealViewModel>>
    {
        private readonly IGenericRepositoryAsync<Deal, Guid> _genericRepository;
        private readonly IMapper _mapper;

        public GetAllDealHandler(IGenericRepositoryAsync<Deal, Guid> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<DealViewModel>> Handle(GetAllDealsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new BadRequestException("Null exception");
            }

            var DealsList = await _genericRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
            var DealsListVm = _mapper.Map<List<DealViewModel>>(DealsList);
            return new PagedResponse<DealViewModel>(DealsListVm, DealsList.TotalCount, request.PageNumber, request.PageSize);
        }
    }
}
