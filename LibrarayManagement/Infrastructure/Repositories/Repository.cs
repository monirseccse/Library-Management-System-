using Domain.Common;
using Domain.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;
        protected int CommandTimeout { get; set; }

        public Repository(DbContext context)
        {
            CommandTimeout = 300;
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
           // await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual  void EditAsync(TEntity entityToUpdate)
        {
            if (_dbContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual Task<int> GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            var count = 0;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            count = query.Count();
            return Task.FromResult(count);
        }

    }
}
