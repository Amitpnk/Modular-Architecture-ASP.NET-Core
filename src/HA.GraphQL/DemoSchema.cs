using GraphQL;
using GraphQL.Types;
using HA.GraphQL.Queries;

namespace HA.GraphQL
{
    public class DemoSchema : Schema
    {
        public DemoSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<DealQuery>();
        }
    }
}
