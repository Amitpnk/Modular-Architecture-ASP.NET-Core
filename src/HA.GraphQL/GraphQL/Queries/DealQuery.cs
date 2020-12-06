using GraphQL.Types;
using HA.Application.Contract;
using HA.Domain.Entities;
using HA.GraphQL.Types;
using System;

namespace HA.GraphQL.Queries
{
    public class DealQuery : ObjectGraphType
    {
        private readonly IGenericRepositoryAsync<Deal, Guid> _genericRepository;

        public DealQuery(IGenericRepositoryAsync<Deal, Guid> genericRepository)
        {
            _genericRepository = genericRepository;
            Name = "DealQuery";
            Field<ListGraphType<DealGraphType>>(
                "deals",
                "Returns a list of Deal",
                resolve: context => _genericRepository.GetAllAsync());

            Field<DealGraphType>(
                "deal",
                "Returns a Single Deal",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return _genericRepository.GetByIdAsync(id);
                }
            );
        }
    }
}
