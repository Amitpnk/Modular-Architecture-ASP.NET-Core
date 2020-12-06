using HA.Adapter.Persistence.Context;
using HA.Application.Contract;
using HA.Domain.Common;
using HA.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HA.Adapter.Persistence.Repositories
{
    public class GenericRepositoryAsync<TEntity, TKey> : IGenericRepositoryAsync<TEntity, TKey>
         where TEntity : AggregateRoot<TKey>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> table;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity obj)
        {
            await table.AddAsync(obj);
        }

        public async Task DeleteAsync(TKey id)
        {
            TEntity existing = await table.FindAsync(id);
            table.Remove(existing);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await table.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await table.FindAsync(id);
        }

        public async Task<PagedList<TEntity>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            var count = table.Count();
            var items = table.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return await Task.Run(() => new PagedList<TEntity>(items, count, pageNumber, pageSize));
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() >= 0;
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await Task.Run(() => table.Update(obj));
        }
    }
}