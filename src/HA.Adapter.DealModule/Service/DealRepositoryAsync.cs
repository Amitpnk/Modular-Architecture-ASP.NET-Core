//using HA.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace HA.Adapter.DealModule.Service
//{
//    public class DealRepositoryAsync : IDealRepositoryAsync//, GenericRepositoryAsync<Deal, Guid>,
//    {
//        private readonly DbSet<Group> _group;
//        public DealRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
//        {
//            _group = dbContext.Set<Group>();
//        }
//        public Task<bool> IsUniqueGroupNameAsync(string name)
//        {
//            return _group
//               .AllAsync(p => p.Name != name);
//        }
//    }
//}
