using Domain.Common;
using Domain.Repositories;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
         Task<int> Complete();
    }
}