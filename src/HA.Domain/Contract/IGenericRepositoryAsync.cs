using HA.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HA.Domain.Contract
{
    public interface IGenericRepositoryAsync<TEntity, TKey>
        where TEntity : AggregateRoot<TKey>
    {

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task AddAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(TKey id);
        bool SaveChanges();
    }
}
