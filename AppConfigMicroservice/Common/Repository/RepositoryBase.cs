using AppConfigMicroservice.Common.Services.CacheService;
using AppConfigMicroservice.DataAccess;
using AppConfigMicroservice.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppConfigMicroservice.Common.Repository
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : ApplicationContext
    {
        private readonly TContext _context;
        private readonly ICacheService _cacheService;
        public RepositoryBase(TContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        public async Task Delete(long id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);

                _context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            string cacheKey = $"{typeof(TEntity).Name}-{id}";
            var entity = _cacheService.CheckCachedData<TEntity>(cacheKey);

            if (entity is null)
            {
                entity = await _context.Set<TEntity>().FindAsync(id);

                if (entity is not null)
                {
                    _cacheService.CheckAndAddToCache(cacheKey, entity);
                }
            }

            return entity;
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ? _context.Set<TEntity>().ToList() : _context.Set<TEntity>().Where(filter).ToList();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return entity;
        }
        async Task<List<TEntity>> IRepositoryBase<TEntity>.GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ? _context.Set<TEntity>().ToList() : _context.Set<TEntity>().Where(filter).ToList();
        }
    }
}
