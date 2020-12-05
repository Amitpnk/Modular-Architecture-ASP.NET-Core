using HA.Domain.Common;
using HA.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HA.Application.Contract
{
    public interface IGenericRepositoryAsync<TEntity, TKey>
        where TEntity : AggregateRoot<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PagedList<TEntity>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<TEntity> GetByIdAsync(TKey id);
        Task AddAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(TKey id);
        bool SaveChanges();
    }
}
