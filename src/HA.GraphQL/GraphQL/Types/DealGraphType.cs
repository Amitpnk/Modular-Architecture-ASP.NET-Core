using GraphQL.Types;
using HA.Domain.Entities;

namespace HA.GraphQL.Types
{
    public class DealGraphType : ObjectGraphType<Deal>
    {
        public DealGraphType()
        {
            Name = "Deal";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Deal Id");
            Field(x => x.Name).Description("Deal Name");
            Field(x => x.Description).Description("Deal descriptions");
        }
    }
}
