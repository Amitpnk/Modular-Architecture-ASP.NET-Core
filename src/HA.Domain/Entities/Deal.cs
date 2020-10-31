using HA.Domain.Common;
using System;

namespace HA.Domain.Entities
{
    public class Deal : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
