using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void EditAsync(TEntity entityToUpdate);
        Task<int> GetCount(Expression<Func<TEntity, bool>> filter = null);
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, string includeProperties = "");
    }
}
