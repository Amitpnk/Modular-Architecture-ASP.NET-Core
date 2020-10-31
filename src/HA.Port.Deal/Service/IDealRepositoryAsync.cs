using HA.Domain.Contract;
using HA.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace HA.Application.DealFeature.Service
{
    public interface IDealRepositoryAsync : IGenericRepositoryAsync<Deal, Guid>
    {
        Task<bool> IsUniqueDealNameAsync(string name);
    }
}
