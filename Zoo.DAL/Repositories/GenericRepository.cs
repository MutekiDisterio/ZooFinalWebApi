using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Zoo.DAL.Data;
using Zoo.DAL.Repositories.Interfaces;

namespace Zoo.DAL.Repositories
{
    public class GenericRepository<TEntity> : IEFGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ZooManagementContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ZooManagementContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GetCompleteEntityAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public IQueryable<TEntity> FindAll()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<IQueryable<TEntity>> FindByCondotion(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.FromResult(_dbSet.Where(expression).AsNoTracking());
        }
    }
}
