using System.Data;

namespace HA.Domain.Contract
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        void CommitTransaction();
    }
}
