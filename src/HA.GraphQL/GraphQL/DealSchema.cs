using GraphQL;
using GraphQL.Types;
using HA.GraphQL.Queries;

namespace HA.GraphQL
{
    public class DealSchema : Schema
    {
        public DealSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<DealQuery>();
        }
    }
}
