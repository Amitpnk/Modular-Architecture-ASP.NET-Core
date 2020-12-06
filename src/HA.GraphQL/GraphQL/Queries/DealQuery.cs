using GraphQL;
using GraphQL.Types;
using HA.Adapter.Persistence.Context;
using HA.GraphQL.Types;
using System;
using System.Linq;

namespace HA.GraphQL.Queries
{
    public class DealQuery : ObjectGraphType
    {
        private readonly ApplicationDbContext _appContext;
        public DealQuery(ApplicationDbContext appContext)
        {
            this._appContext = appContext;
            Name = "Query";
            Field<ListGraphType<DealGraphType>>("deals", "Returns a list of Deal", resolve: context => _appContext.Deals.ToList());
            //Field<DealGraphType>("deal", "Returns a Single Deal",
            //    new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id", Description = "Deal Id" }),
            //        context => _appContext.Deals.Single(x => x.Id == context.Arguments["id"].GetPropertyValue<Guid>()));
        }
    }
}
